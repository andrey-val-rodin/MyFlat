﻿using MyFlat.Common;
using MyFlat.Dto;
using MyFlat.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFlat
{
    public partial class Form1 : Form, IMessenger
    {
        private readonly MosOblEircService _mosOblEircService;
        private readonly GlobusService _globusService;
        private IList<MeterChildDto> _meters;

        // Kitchen cold water   323381, 17523577
        private MeterChildDto KitchenColdWater => GetMeter(17523577);
        // Kitchen hot water    206922, 16702145
        private MeterChildDto KitchenHotWater => GetMeter(16702145);
        // Bathroom hot water   204933, 16702144
        private MeterChildDto BathroomColdWater => GetMeter(17523578);
        // Bathroom hot water   204933, 16702144
        private MeterChildDto BathroomHotWater => GetMeter(16702144);
        // Electricity          19843385, 14680903
        private MeterChildDto Electricity => GetMeter(14680903);

        public Form1()
        {
            InitializeComponent();

            _mosOblEircService = new MosOblEircService(this);
            _globusService = new GlobusService(this);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            if (!await _mosOblEircService.AuthorizeAsync(Config.MosOblEircUser, Config.MosOblEircPassword) ||
                !await _globusService.AuthorizeAsync(Config.GlobusUser, Config.GlobusPassword))
                return;

            await ProcessMosOblEircAsync();
            await ProcessMetersAsync();
            await ProcessGlobusAsync();

            if (MustClose())
                Close();
        }

        private MeterChildDto GetMeter(int id)
        {
            return _meters?.FirstOrDefault(c => c.Id_counter == id);
        }

        private bool MustClose()
        {
            return
                labelMosOblEircCount.Text == "Оплачено" &&
                labelGlobusCount.Text == "Оплачено" &&
                !buttonMeters.Enabled &&
                !labelMessage.Visible;
        }

        private async Task ProcessMosOblEircAsync()
        {
            var tuple = await _mosOblEircService.GetBalanceAsync();
            if (tuple != null && tuple.Item2 != 0)
            {
                labelMosOblEircCount.Text = $"Cчёт на {tuple.Item2} руб с {tuple.Item1}";
                labelMosOblEircCount.ForeColor = Color.FromName("SaddleBrown");
            }
            else
            {
                labelMosOblEircCount.Text = "Оплачено";
                labelMosOblEircCount.ForeColor = Color.FromName("DimGray");
            }
        }

        private async Task ProcessMetersAsync()
        {
            _meters = await _mosOblEircService.GetMetersAsync();
            if (_meters == null)
                return;

            if (ShowOldMeters())
                EnableMeterCotrols();
        }

        private bool ShowOldMeters()
        {
            if (KitchenColdWater != null)
                labelKitchenColdWaterOld.Text = KitchenColdWater.Vl_last_indication.ToString();
            else
            {
                ShowError("Нет показаний счётчика");
                labelKitchenColdWaterOld.Text = string.Empty;
                return false;
            }

            if (KitchenHotWater != null)
                labelKitchenHotWaterOld.Text = KitchenHotWater.Vl_last_indication.ToString();
            else
            {
                ShowError("Нет показаний счётчика");
                labelKitchenHotWaterOld.Text = string.Empty;
                return false;
            }

            if (BathroomColdWater != null)
                labelBathroomColdWaterOld.Text = BathroomColdWater.Vl_last_indication.ToString();
            else
            {
                ShowError("Нет показаний счётчика");
                labelBathroomColdWaterOld.Text = string.Empty;
                return false;
            }

            if (BathroomHotWater != null)
                labelBathroomHotWaterOld.Text = BathroomHotWater.Vl_last_indication.ToString();
            else
            {
                ShowError("Нет показаний счётчика");
                labelBathroomHotWaterOld.Text = string.Empty;
                return false;
            }

            if (Electricity != null)
                labelElectricityOld.Text = Electricity.Vl_last_indication.ToString();
            else
            {
                ShowError("Нет показаний счётчика");
                labelElectricityOld.Text = string.Empty;
                return false;
            }

            return true;
        }

        private void EnableMeterCotrols()
        {
            var now = DateTime.Now;
            if (now.Day >= 5 && now.Day <= 25)
            {
                if (KitchenColdWater?.GetDate().Month != now.Month)
                    textBoxKitchenColdWater.Enabled = true;

                if (KitchenHotWater?.GetDate().Month != now.Month)
                    textBoxKitchenHotWater.Enabled = true;

                if (BathroomColdWater?.GetDate().Month != now.Month)
                    textBoxBathroomColdWater.Enabled = true;

                if (BathroomHotWater?.GetDate().Month != now.Month)
                    textBoxBathroomHotWater.Enabled = true;
            }

            if (now.Day >= 15 && now.Day <= 26)
            {
                if (Electricity?.GetDate().Month != now.Month)
                    textBoxElectricity.Enabled = true;
            }

            if (textBoxKitchenColdWater.Enabled ||
                textBoxKitchenHotWater.Enabled ||
                textBoxBathroomColdWater.Enabled ||
                textBoxBathroomHotWater.Enabled ||
                textBoxElectricity.Enabled)
                buttonMeters.Enabled = true;
        }

        public void ShowMessage(string message)
        {
            labelMessage.ForeColor = Color.Black;
            labelMessage.Text = message;
            labelMessage.Visible = true;
        }

        public void ShowError(string message)
        {
            labelMessage.ForeColor = Color.Red;
            labelMessage.Text = message;
            labelMessage.Visible = true;
        }

        private async Task ProcessGlobusAsync()
        {
            var balance = await _globusService.GetBalanceAsync();
            if (balance != null && balance.Value > 0)
            {
                labelGlobusCount.Text = $"Выставлен счёт на {balance} руб";
                labelGlobusCount.ForeColor = Color.FromName("SaddleBrown");
            }
            else
            {
                labelGlobusCount.Text = "Оплачено";
                labelGlobusCount.ForeColor = Color.FromName("DimGray");
            }
        }

        private void linkLabelMosOblEirc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://my.mosenergosbyt.ru/auth") { UseShellExecute = true });
        }

        private void linkLabelGlobus_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://lk.globusenergo.ru") { UseShellExecute = true });
        }

        private void textBoxKitchenColdWater_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!DoValidation(textBoxKitchenColdWater, KitchenColdWater))
                e.Cancel = true;
        }

        private void textBoxKitchenHotWater_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!DoValidation(textBoxKitchenHotWater, KitchenHotWater))
                e.Cancel = true;
        }

        private void textBoxBathroomColdWater_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!DoValidation(textBoxBathroomColdWater, BathroomColdWater))
                e.Cancel = true;
        }

        private void textBoxBathroomHotWater_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!DoValidation(textBoxBathroomHotWater, BathroomHotWater))
                e.Cancel = true;
        }

        private void textBoxElectricity_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!DoValidation(textBoxElectricity, Electricity))
                e.Cancel = true;
        }

        private bool DoValidation(TextBox textBox, MeterChildDto meter)
        {
            if (!textBox.Enabled)
                return true;

            string error = null;
            var oldValue = meter?.Vl_last_indication;
            if (string.IsNullOrEmpty(textBox.Text))
                error = "Значение должно быть заполнено";
            else if (!int.TryParse(textBox.Text, out int value))
                error = "Значение должно быть целочисленным";
            else if (value < oldValue)
                error = "Значение должно быть не меньше прежнего";

            if (!string.IsNullOrEmpty(error))
            {
                textBox.Select(0, textBox.Text.Length);
                errorProvider.SetError(textBox, error);
                return false;
            }

            return true;
        }

        private async void buttonMeters_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                var kitchenColdWater = textBoxKitchenColdWater.Enabled ?
                    int.Parse(textBoxKitchenColdWater.Text) : 0;
                var kitchenHotWater = textBoxKitchenHotWater.Enabled ?
                    int.Parse(textBoxKitchenHotWater.Text) : 0;
                var bathroomColdWater = textBoxBathroomColdWater.Enabled ?
                    int.Parse(textBoxBathroomColdWater.Text) : 0;
                var bathroomHotWater = textBoxBathroomHotWater.Enabled ?
                    int.Parse(textBoxBathroomHotWater.Text) : 0;
                var electricity = textBoxElectricity.Enabled ?
                    int.Parse(textBoxElectricity.Text) : 0;

                if (kitchenColdWater == 0 && kitchenHotWater == 0 &&
                    bathroomColdWater == 0 && bathroomHotWater == 0 &&
                    electricity == 0)
                    return; // Nothing to send

                if ((kitchenColdWater == 0 ||
                    await _mosOblEircService.SendMeterAsync(KitchenColdWater.Id_counter, kitchenColdWater)) &&
                    (kitchenHotWater == 0 ||
                    await _mosOblEircService.SendMeterAsync(KitchenHotWater.Id_counter, kitchenHotWater)) &&
                    (bathroomColdWater == 0 ||
                    await _mosOblEircService.SendMeterAsync(BathroomColdWater.Id_counter, bathroomColdWater)) &&
                    (bathroomHotWater == 0 ||
                    await _mosOblEircService.SendMeterAsync(BathroomHotWater.Id_counter, bathroomHotWater)) &&
                    (electricity == 0 ||
                    await _mosOblEircService.SendMeterAsync(Electricity.Id_counter, electricity)) &&
                    (kitchenHotWater == 0 || bathroomHotWater == 0 ||
                    await _globusService.SendMetersAsync(kitchenHotWater, bathroomHotWater)))
                    ShowMessage("Показания были успешно переданы");
                return;
            }
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            errorProvider.Clear();

            if (_mosOblEircService.IsAuthorized)
                await _mosOblEircService.LogoffAsync();
            if (_globusService.IsAuthorized)
                await _globusService.LogoffAsync();
        }
    }
}
