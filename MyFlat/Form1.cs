using MyFlat.Common;
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
        private IList<CounterChildDto> _counters;

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
            await ProcessCountersAsync();
            await ProcessGlobusAsync();

            await _mosOblEircService.LogoffAsync();
            await _globusService.LogoffAsync();

            if (MustClose())
                Close();
        }

        private bool MustClose()
        {
            return
                labelMosOblEircCount.Text == "Оплачено" &&
                labelGlobusCount.Text == "Оплачено" &&
                !buttonCounters.Enabled &&
                !labelMessage.Visible;
        }

        private async Task ProcessMosOblEircAsync()
        {
            var tuple = await _mosOblEircService.GetBalanceAsync();
            if (tuple != null && tuple.Item2 != 0)
            {
                labelMosOblEircCount.Text = $"Cчёт на {tuple.Item2} руб. с {tuple.Item1}";
                labelMosOblEircCount.ForeColor = Color.FromName("SaddleBrown");
            }
            else
            {
                labelMosOblEircCount.Text = "Оплачено";
                labelMosOblEircCount.ForeColor = Color.FromName("DimGray");
            }
        }

        private async Task ProcessCountersAsync()
        {
            _counters = await _mosOblEircService.GetCountersAsync();
            if (_counters == null)
                return;

            if (ShowOldCounters())
                EnableCounterCotrols();
        }

        private bool ShowOldCounters()
        {
            // Kitchen cold water   323381
            var counter = GetCounter(323381);
            if (counter != null)
                labelKitchenColdWaterOld.Text = counter.Vl_last_indication.ToString();
            else
            {
                ShowError("Нет показаний счётчика");
                labelKitchenColdWaterOld.Text = string.Empty;
                return false;
            }

            // Kitchen hot water    206922
            counter = GetCounter(206922);
            if (counter != null)
                labelKitchenHotWaterOld.Text = counter.Vl_last_indication.ToString();
            else
            {
                ShowError("Нет показаний счётчика");
                labelKitchenHotWaterOld.Text = string.Empty;
                return false;
            }

            // Bathroom cold water  323391
            counter = GetCounter(323391);
            if (counter != null)
                labelBathroomColdWaterOld.Text = counter.Vl_last_indication.ToString();
            else
            {
                ShowError("Нет показаний счётчика");
                labelBathroomColdWaterOld.Text = string.Empty;
                return false;
            }

            // Bathroom hot water   204933
            counter = GetCounter(204933);
            if (counter != null)
                labelBathroomHotWaterOld.Text = counter.Vl_last_indication.ToString();
            else
            {
                ShowError("Нет показаний счётчика");
                labelBathroomHotWaterOld.Text = string.Empty;
                return false;
            }

            // Electricity          19843385
            counter = GetCounter(19843385);
            if (counter != null)
                labelElectricityOld.Text = counter.Vl_last_indication.ToString();
            else
            {
                ShowError("Нет показаний счётчика");
                labelElectricityOld.Text = string.Empty;
                return false;
            }

            return true;
        }

        private CounterChildDto GetCounter(int id)
        {
            return _counters?.FirstOrDefault(c => c.Nm_counter == id);
        }

        private void EnableCounterCotrols()
        {
            var now = DateTime.Now;
            if (now.Day >= 5)
            {
                // Kitchen cold water   323381
                var counter = GetCounter(323381);
                if (counter.GetDate().Month != now.Month)
                    textBoxKitchenColdWater.Enabled = true;

                // Kitchen hot water    206922
                counter = GetCounter(206922);
                if (counter.GetDate().Month != now.Month)
                    textBoxKitchenHotWater.Enabled = true;

                // Bathroom cold water  323391
                counter = GetCounter(323391);
                if (counter.GetDate().Month != now.Month)
                    textBoxBathroomColdWater.Enabled = true;

                // Bathroom hot water   204933
                counter = GetCounter(204933);
                if (counter.GetDate().Month != now.Month)
                    textBoxBathroomHotWater.Enabled = true;
            }

            if (now.Day >= 15)
            {
                // Electricity          19843385
                var counter = GetCounter(19843385);
                if (counter.GetDate().Month != now.Month)
                    textBoxElectricity.Enabled = true;
            }

            if (textBoxKitchenColdWater.Enabled ||
                textBoxKitchenHotWater.Enabled ||
                textBoxBathroomColdWater.Enabled ||
                textBoxBathroomHotWater.Enabled ||
                textBoxElectricity.Enabled)
                buttonCounters.Enabled = true;
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
                labelGlobusCount.Text = $"Выставлен счёт на {balance} руб.";
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
    }
}
