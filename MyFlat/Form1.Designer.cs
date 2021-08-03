
namespace MyFlat
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxMosOblEirc = new System.Windows.Forms.GroupBox();
            this.linkLabelMosOblEirc = new System.Windows.Forms.LinkLabel();
            this.labelMosOblEircCount = new System.Windows.Forms.Label();
            this.groupBoxGlobus = new System.Windows.Forms.GroupBox();
            this.linkLabelGlobus = new System.Windows.Forms.LinkLabel();
            this.labelGlobusCount = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelElectricityOld = new System.Windows.Forms.Label();
            this.labelBathroomHotWaterOld = new System.Windows.Forms.Label();
            this.labelBathroomColdWaterOld = new System.Windows.Forms.Label();
            this.labelKitchenHotWaterOld = new System.Windows.Forms.Label();
            this.labelKitchenColdWaterOld = new System.Windows.Forms.Label();
            this.buttonCounters = new System.Windows.Forms.Button();
            this.textBoxElectricity = new System.Windows.Forms.TextBox();
            this.textBoxBathroomHotWater = new System.Windows.Forms.TextBox();
            this.textBoxBathroomColdWater = new System.Windows.Forms.TextBox();
            this.textBoxKitchenHotWater = new System.Windows.Forms.TextBox();
            this.textBoxKitchenColdWater = new System.Windows.Forms.TextBox();
            this.labelElectricity = new System.Windows.Forms.Label();
            this.labelBathroomHotWater = new System.Windows.Forms.Label();
            this.labelBathroomColdWater = new System.Windows.Forms.Label();
            this.labelKitchenHotWater = new System.Windows.Forms.Label();
            this.labelKitchenColdWater = new System.Windows.Forms.Label();
            this.labelMessage = new System.Windows.Forms.Label();
            this.groupBoxMosOblEirc.SuspendLayout();
            this.groupBoxGlobus.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxMosOblEirc
            // 
            this.groupBoxMosOblEirc.Controls.Add(this.linkLabelMosOblEirc);
            this.groupBoxMosOblEirc.Controls.Add(this.labelMosOblEircCount);
            this.groupBoxMosOblEirc.Location = new System.Drawing.Point(13, 13);
            this.groupBoxMosOblEirc.Name = "groupBoxMosOblEirc";
            this.groupBoxMosOblEirc.Size = new System.Drawing.Size(298, 84);
            this.groupBoxMosOblEirc.TabIndex = 0;
            this.groupBoxMosOblEirc.TabStop = false;
            this.groupBoxMosOblEirc.Text = "МосОблЕирц";
            // 
            // linkLabelMosOblEirc
            // 
            this.linkLabelMosOblEirc.AutoSize = true;
            this.linkLabelMosOblEirc.Location = new System.Drawing.Point(214, 54);
            this.linkLabelMosOblEirc.Name = "linkLabelMosOblEirc";
            this.linkLabelMosOblEirc.Size = new System.Drawing.Size(78, 20);
            this.linkLabelMosOblEirc.TabIndex = 2;
            this.linkLabelMosOblEirc.TabStop = true;
            this.linkLabelMosOblEirc.Text = "В кабинет";
            this.linkLabelMosOblEirc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelMosOblEirc_LinkClicked);
            // 
            // labelMosOblEircCount
            // 
            this.labelMosOblEircCount.AutoSize = true;
            this.labelMosOblEircCount.ForeColor = System.Drawing.Color.DimGray;
            this.labelMosOblEircCount.Location = new System.Drawing.Point(20, 29);
            this.labelMosOblEircCount.Name = "labelMosOblEircCount";
            this.labelMosOblEircCount.Size = new System.Drawing.Size(79, 20);
            this.labelMosOblEircCount.TabIndex = 1;
            this.labelMosOblEircCount.Text = "Оплачено";
            // 
            // groupBoxGlobus
            // 
            this.groupBoxGlobus.Controls.Add(this.linkLabelGlobus);
            this.groupBoxGlobus.Controls.Add(this.labelGlobusCount);
            this.groupBoxGlobus.Location = new System.Drawing.Point(329, 12);
            this.groupBoxGlobus.Name = "groupBoxGlobus";
            this.groupBoxGlobus.Size = new System.Drawing.Size(298, 85);
            this.groupBoxGlobus.TabIndex = 5;
            this.groupBoxGlobus.TabStop = false;
            this.groupBoxGlobus.Text = "Глобус";
            // 
            // linkLabelGlobus
            // 
            this.linkLabelGlobus.AutoSize = true;
            this.linkLabelGlobus.Location = new System.Drawing.Point(214, 55);
            this.linkLabelGlobus.Name = "linkLabelGlobus";
            this.linkLabelGlobus.Size = new System.Drawing.Size(78, 20);
            this.linkLabelGlobus.TabIndex = 4;
            this.linkLabelGlobus.TabStop = true;
            this.linkLabelGlobus.Text = "В кабинет";
            this.linkLabelGlobus.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGlobus_LinkClicked);
            // 
            // labelGlobusCount
            // 
            this.labelGlobusCount.AutoSize = true;
            this.labelGlobusCount.ForeColor = System.Drawing.Color.SaddleBrown;
            this.labelGlobusCount.Location = new System.Drawing.Point(18, 30);
            this.labelGlobusCount.Name = "labelGlobusCount";
            this.labelGlobusCount.Size = new System.Drawing.Size(233, 20);
            this.labelGlobusCount.TabIndex = 3;
            this.labelGlobusCount.Text = "Cчёт на 2010,12 руб. с 01.07.2021";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelElectricityOld);
            this.groupBox1.Controls.Add(this.labelBathroomHotWaterOld);
            this.groupBox1.Controls.Add(this.labelBathroomColdWaterOld);
            this.groupBox1.Controls.Add(this.labelKitchenHotWaterOld);
            this.groupBox1.Controls.Add(this.labelKitchenColdWaterOld);
            this.groupBox1.Controls.Add(this.buttonCounters);
            this.groupBox1.Controls.Add(this.textBoxElectricity);
            this.groupBox1.Controls.Add(this.textBoxBathroomHotWater);
            this.groupBox1.Controls.Add(this.textBoxBathroomColdWater);
            this.groupBox1.Controls.Add(this.textBoxKitchenHotWater);
            this.groupBox1.Controls.Add(this.textBoxKitchenColdWater);
            this.groupBox1.Controls.Add(this.labelElectricity);
            this.groupBox1.Controls.Add(this.labelBathroomHotWater);
            this.groupBox1.Controls.Add(this.labelBathroomColdWater);
            this.groupBox1.Controls.Add(this.labelKitchenHotWater);
            this.groupBox1.Controls.Add(this.labelKitchenColdWater);
            this.groupBox1.Location = new System.Drawing.Point(15, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(614, 210);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Счётчики";
            // 
            // labelElectricityOld
            // 
            this.labelElectricityOld.AutoSize = true;
            this.labelElectricityOld.Location = new System.Drawing.Point(291, 175);
            this.labelElectricityOld.Name = "labelElectricityOld";
            this.labelElectricityOld.Size = new System.Drawing.Size(41, 20);
            this.labelElectricityOld.TabIndex = 15;
            this.labelElectricityOld.Text = "9400";
            // 
            // labelBathroomHotWaterOld
            // 
            this.labelBathroomHotWaterOld.AutoSize = true;
            this.labelBathroomHotWaterOld.Location = new System.Drawing.Point(291, 141);
            this.labelBathroomHotWaterOld.Name = "labelBathroomHotWaterOld";
            this.labelBathroomHotWaterOld.Size = new System.Drawing.Size(25, 20);
            this.labelBathroomHotWaterOld.TabIndex = 14;
            this.labelBathroomHotWaterOld.Text = "62";
            // 
            // labelBathroomColdWaterOld
            // 
            this.labelBathroomColdWaterOld.AutoSize = true;
            this.labelBathroomColdWaterOld.Location = new System.Drawing.Point(291, 107);
            this.labelBathroomColdWaterOld.Name = "labelBathroomColdWaterOld";
            this.labelBathroomColdWaterOld.Size = new System.Drawing.Size(25, 20);
            this.labelBathroomColdWaterOld.TabIndex = 13;
            this.labelBathroomColdWaterOld.Text = "67";
            // 
            // labelKitchenHotWaterOld
            // 
            this.labelKitchenHotWaterOld.AutoSize = true;
            this.labelKitchenHotWaterOld.Location = new System.Drawing.Point(291, 72);
            this.labelKitchenHotWaterOld.Name = "labelKitchenHotWaterOld";
            this.labelKitchenHotWaterOld.Size = new System.Drawing.Size(25, 20);
            this.labelKitchenHotWaterOld.TabIndex = 12;
            this.labelKitchenHotWaterOld.Text = "44";
            // 
            // labelKitchenColdWaterOld
            // 
            this.labelKitchenColdWaterOld.AutoSize = true;
            this.labelKitchenColdWaterOld.Location = new System.Drawing.Point(291, 38);
            this.labelKitchenColdWaterOld.Name = "labelKitchenColdWaterOld";
            this.labelKitchenColdWaterOld.Size = new System.Drawing.Size(25, 20);
            this.labelKitchenColdWaterOld.TabIndex = 11;
            this.labelKitchenColdWaterOld.Text = "56";
            // 
            // buttonCounters
            // 
            this.buttonCounters.Enabled = false;
            this.buttonCounters.Location = new System.Drawing.Point(512, 170);
            this.buttonCounters.Name = "buttonCounters";
            this.buttonCounters.Size = new System.Drawing.Size(94, 29);
            this.buttonCounters.TabIndex = 10;
            this.buttonCounters.Text = "Передать";
            this.buttonCounters.UseVisualStyleBackColor = true;
            // 
            // textBoxElectricity
            // 
            this.textBoxElectricity.Enabled = false;
            this.textBoxElectricity.Location = new System.Drawing.Point(160, 172);
            this.textBoxElectricity.Name = "textBoxElectricity";
            this.textBoxElectricity.Size = new System.Drawing.Size(125, 27);
            this.textBoxElectricity.TabIndex = 9;
            // 
            // textBoxBathroomHotWater
            // 
            this.textBoxBathroomHotWater.Enabled = false;
            this.textBoxBathroomHotWater.Location = new System.Drawing.Point(160, 138);
            this.textBoxBathroomHotWater.Name = "textBoxBathroomHotWater";
            this.textBoxBathroomHotWater.Size = new System.Drawing.Size(125, 27);
            this.textBoxBathroomHotWater.TabIndex = 8;
            // 
            // textBoxBathroomColdWater
            // 
            this.textBoxBathroomColdWater.Enabled = false;
            this.textBoxBathroomColdWater.Location = new System.Drawing.Point(160, 104);
            this.textBoxBathroomColdWater.Name = "textBoxBathroomColdWater";
            this.textBoxBathroomColdWater.Size = new System.Drawing.Size(125, 27);
            this.textBoxBathroomColdWater.TabIndex = 7;
            // 
            // textBoxKitchenHotWater
            // 
            this.textBoxKitchenHotWater.Enabled = false;
            this.textBoxKitchenHotWater.Location = new System.Drawing.Point(160, 69);
            this.textBoxKitchenHotWater.Name = "textBoxKitchenHotWater";
            this.textBoxKitchenHotWater.Size = new System.Drawing.Size(125, 27);
            this.textBoxKitchenHotWater.TabIndex = 6;
            // 
            // textBoxKitchenColdWater
            // 
            this.textBoxKitchenColdWater.Enabled = false;
            this.textBoxKitchenColdWater.Location = new System.Drawing.Point(160, 35);
            this.textBoxKitchenColdWater.Name = "textBoxKitchenColdWater";
            this.textBoxKitchenColdWater.Size = new System.Drawing.Size(125, 27);
            this.textBoxKitchenColdWater.TabIndex = 5;
            // 
            // labelElectricity
            // 
            this.labelElectricity.AutoSize = true;
            this.labelElectricity.Location = new System.Drawing.Point(17, 175);
            this.labelElectricity.Name = "labelElectricity";
            this.labelElectricity.Size = new System.Drawing.Size(114, 20);
            this.labelElectricity.TabIndex = 4;
            this.labelElectricity.Text = "Электричество:";
            // 
            // labelBathroomHotWater
            // 
            this.labelBathroomHotWater.AutoSize = true;
            this.labelBathroomHotWater.Location = new System.Drawing.Point(18, 141);
            this.labelBathroomHotWater.Name = "labelBathroomHotWater";
            this.labelBathroomHotWater.Size = new System.Drawing.Size(136, 20);
            this.labelBathroomHotWater.TabIndex = 3;
            this.labelBathroomHotWater.Text = "Санузел гор. вода:";
            // 
            // labelBathroomColdWater
            // 
            this.labelBathroomColdWater.AutoSize = true;
            this.labelBathroomColdWater.Location = new System.Drawing.Point(18, 107);
            this.labelBathroomColdWater.Name = "labelBathroomColdWater";
            this.labelBathroomColdWater.Size = new System.Drawing.Size(136, 20);
            this.labelBathroomColdWater.TabIndex = 2;
            this.labelBathroomColdWater.Text = "Санузел хол. вода:";
            // 
            // labelKitchenHotWater
            // 
            this.labelKitchenHotWater.AutoSize = true;
            this.labelKitchenHotWater.Location = new System.Drawing.Point(17, 72);
            this.labelKitchenHotWater.Name = "labelKitchenHotWater";
            this.labelKitchenHotWater.Size = new System.Drawing.Size(120, 20);
            this.labelKitchenHotWater.TabIndex = 1;
            this.labelKitchenHotWater.Text = "Кухня гор. вода:";
            // 
            // labelKitchenColdWater
            // 
            this.labelKitchenColdWater.AutoSize = true;
            this.labelKitchenColdWater.Location = new System.Drawing.Point(16, 38);
            this.labelKitchenColdWater.Name = "labelKitchenColdWater";
            this.labelKitchenColdWater.Size = new System.Drawing.Size(120, 20);
            this.labelKitchenColdWater.TabIndex = 0;
            this.labelKitchenColdWater.Text = "Кухня хол. вода:";
            // 
            // labelMessage
            // 
            this.labelMessage.ForeColor = System.Drawing.Color.Red;
            this.labelMessage.Location = new System.Drawing.Point(13, 316);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(614, 413);
            this.labelMessage.TabIndex = 7;
            this.labelMessage.Text = "Сообщение об ошибке";
            this.labelMessage.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 341);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxGlobus);
            this.Controls.Add(this.groupBoxMosOblEirc);
            this.Name = "Form1";
            this.Text = "Моя квартира";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxMosOblEirc.ResumeLayout(false);
            this.groupBoxMosOblEirc.PerformLayout();
            this.groupBoxGlobus.ResumeLayout(false);
            this.groupBoxGlobus.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxMosOblEirc;
        private System.Windows.Forms.Label labelMosOblEircCount;
        private System.Windows.Forms.GroupBox groupBoxGlobus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelBathroomHotWater;
        private System.Windows.Forms.Label labelBathroomColdWater;
        private System.Windows.Forms.Label labelKitchenHotWater;
        private System.Windows.Forms.Label labelKitchenColdWater;
        private System.Windows.Forms.Button buttonCounters;
        private System.Windows.Forms.TextBox textBoxElectricity;
        private System.Windows.Forms.TextBox textBoxBathroomHotWater;
        private System.Windows.Forms.TextBox textBoxBathroomColdWater;
        private System.Windows.Forms.TextBox textBoxKitchenHotWater;
        private System.Windows.Forms.TextBox textBoxKitchenColdWater;
        private System.Windows.Forms.Label labelElectricity;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.LinkLabel linkLabelMosOblEirc;
        private System.Windows.Forms.LinkLabel linkLabelGlobus;
        private System.Windows.Forms.Label labelGlobusCount;
        private System.Windows.Forms.Label labelElectricityOld;
        private System.Windows.Forms.Label labelBathroomHotWaterOld;
        private System.Windows.Forms.Label labelBathroomColdWaterOld;
        private System.Windows.Forms.Label labelKitchenHotWaterOld;
        private System.Windows.Forms.Label labelKitchenColdWaterOld;
    }
}

