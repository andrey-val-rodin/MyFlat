
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
            this.components = new System.ComponentModel.Container();
            this.groupBoxMosOblEirc = new System.Windows.Forms.GroupBox();
            this.labelMosOblEircCount = new System.Windows.Forms.Label();
            this.linkLabelMosOblEirc = new System.Windows.Forms.LinkLabel();
            this.groupBoxGlobus = new System.Windows.Forms.GroupBox();
            this.labelGlobusCount = new System.Windows.Forms.Label();
            this.linkLabelGlobus = new System.Windows.Forms.LinkLabel();
            this.groupBoxMeters = new System.Windows.Forms.GroupBox();
            this.labelKitchenColdWater = new System.Windows.Forms.Label();
            this.textBoxKitchenColdWater = new System.Windows.Forms.TextBox();
            this.labelKitchenColdWaterOld = new System.Windows.Forms.Label();
            this.labelKitchenHotWater = new System.Windows.Forms.Label();
            this.textBoxKitchenHotWater = new System.Windows.Forms.TextBox();
            this.labelKitchenHotWaterOld = new System.Windows.Forms.Label();
            this.labelBathroomColdWater = new System.Windows.Forms.Label();
            this.textBoxBathroomColdWater = new System.Windows.Forms.TextBox();
            this.labelBathroomColdWaterOld = new System.Windows.Forms.Label();
            this.labelBathroomHotWater = new System.Windows.Forms.Label();
            this.textBoxBathroomHotWater = new System.Windows.Forms.TextBox();
            this.labelBathroomHotWaterOld = new System.Windows.Forms.Label();
            this.labelElectricity = new System.Windows.Forms.Label();
            this.textBoxElectricity = new System.Windows.Forms.TextBox();
            this.labelElectricityOld = new System.Windows.Forms.Label();
            this.buttonMeters = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBoxMosOblEirc.SuspendLayout();
            this.groupBoxGlobus.SuspendLayout();
            this.groupBoxMeters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxMosOblEirc
            // 
            this.groupBoxMosOblEirc.Controls.Add(this.labelMosOblEircCount);
            this.groupBoxMosOblEirc.Controls.Add(this.linkLabelMosOblEirc);
            this.groupBoxMosOblEirc.Location = new System.Drawing.Point(13, 13);
            this.groupBoxMosOblEirc.Name = "groupBoxMosOblEirc";
            this.groupBoxMosOblEirc.Size = new System.Drawing.Size(298, 84);
            this.groupBoxMosOblEirc.TabIndex = 0;
            this.groupBoxMosOblEirc.TabStop = false;
            this.groupBoxMosOblEirc.Text = "&МосОблЕирц";
            // 
            // labelMosOblEircCount
            // 
            this.labelMosOblEircCount.AutoSize = true;
            this.labelMosOblEircCount.Location = new System.Drawing.Point(20, 29);
            this.labelMosOblEircCount.Name = "labelMosOblEircCount";
            this.labelMosOblEircCount.Size = new System.Drawing.Size(0, 20);
            this.labelMosOblEircCount.TabIndex = 1;
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
            // groupBoxGlobus
            // 
            this.groupBoxGlobus.Controls.Add(this.labelGlobusCount);
            this.groupBoxGlobus.Controls.Add(this.linkLabelGlobus);
            this.groupBoxGlobus.Location = new System.Drawing.Point(329, 12);
            this.groupBoxGlobus.Name = "groupBoxGlobus";
            this.groupBoxGlobus.Size = new System.Drawing.Size(298, 85);
            this.groupBoxGlobus.TabIndex = 3;
            this.groupBoxGlobus.TabStop = false;
            this.groupBoxGlobus.Text = "&Глобус";
            // 
            // labelGlobusCount
            // 
            this.labelGlobusCount.AutoSize = true;
            this.labelGlobusCount.Location = new System.Drawing.Point(18, 30);
            this.labelGlobusCount.Name = "labelGlobusCount";
            this.labelGlobusCount.Size = new System.Drawing.Size(0, 20);
            this.labelGlobusCount.TabIndex = 4;
            // 
            // linkLabelGlobus
            // 
            this.linkLabelGlobus.AutoSize = true;
            this.linkLabelGlobus.Location = new System.Drawing.Point(214, 55);
            this.linkLabelGlobus.Name = "linkLabelGlobus";
            this.linkLabelGlobus.Size = new System.Drawing.Size(78, 20);
            this.linkLabelGlobus.TabIndex = 5;
            this.linkLabelGlobus.TabStop = true;
            this.linkLabelGlobus.Text = "В кабинет";
            this.linkLabelGlobus.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGlobus_LinkClicked);
            // 
            // groupBoxMeters
            // 
            this.groupBoxMeters.Controls.Add(this.labelKitchenColdWater);
            this.groupBoxMeters.Controls.Add(this.textBoxKitchenColdWater);
            this.groupBoxMeters.Controls.Add(this.labelKitchenColdWaterOld);
            this.groupBoxMeters.Controls.Add(this.labelKitchenHotWater);
            this.groupBoxMeters.Controls.Add(this.textBoxKitchenHotWater);
            this.groupBoxMeters.Controls.Add(this.labelKitchenHotWaterOld);
            this.groupBoxMeters.Controls.Add(this.labelBathroomColdWater);
            this.groupBoxMeters.Controls.Add(this.textBoxBathroomColdWater);
            this.groupBoxMeters.Controls.Add(this.labelBathroomColdWaterOld);
            this.groupBoxMeters.Controls.Add(this.labelBathroomHotWater);
            this.groupBoxMeters.Controls.Add(this.textBoxBathroomHotWater);
            this.groupBoxMeters.Controls.Add(this.labelBathroomHotWaterOld);
            this.groupBoxMeters.Controls.Add(this.labelElectricity);
            this.groupBoxMeters.Controls.Add(this.textBoxElectricity);
            this.groupBoxMeters.Controls.Add(this.labelElectricityOld);
            this.groupBoxMeters.Controls.Add(this.buttonMeters);
            this.groupBoxMeters.Location = new System.Drawing.Point(15, 103);
            this.groupBoxMeters.Name = "groupBoxMeters";
            this.groupBoxMeters.Size = new System.Drawing.Size(614, 210);
            this.groupBoxMeters.TabIndex = 6;
            this.groupBoxMeters.TabStop = false;
            this.groupBoxMeters.Text = "&Счётчики";
            // 
            // labelKitchenColdWater
            // 
            this.labelKitchenColdWater.AutoSize = true;
            this.labelKitchenColdWater.Location = new System.Drawing.Point(16, 38);
            this.labelKitchenColdWater.Name = "labelKitchenColdWater";
            this.labelKitchenColdWater.Size = new System.Drawing.Size(120, 20);
            this.labelKitchenColdWater.TabIndex = 7;
            this.labelKitchenColdWater.Text = "Кухня хол. вода:";
            // 
            // textBoxKitchenColdWater
            // 
            this.textBoxKitchenColdWater.Enabled = false;
            this.textBoxKitchenColdWater.Location = new System.Drawing.Point(160, 35);
            this.textBoxKitchenColdWater.Name = "textBoxKitchenColdWater";
            this.textBoxKitchenColdWater.Size = new System.Drawing.Size(125, 27);
            this.textBoxKitchenColdWater.TabIndex = 8;
            this.textBoxKitchenColdWater.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxKitchenColdWater_Validating);
            // 
            // labelKitchenColdWaterOld
            // 
            this.labelKitchenColdWaterOld.AutoSize = true;
            this.labelKitchenColdWaterOld.Location = new System.Drawing.Point(302, 38);
            this.labelKitchenColdWaterOld.Name = "labelKitchenColdWaterOld";
            this.labelKitchenColdWaterOld.Size = new System.Drawing.Size(0, 20);
            this.labelKitchenColdWaterOld.TabIndex = 9;
            // 
            // labelKitchenHotWater
            // 
            this.labelKitchenHotWater.AutoSize = true;
            this.labelKitchenHotWater.Location = new System.Drawing.Point(17, 72);
            this.labelKitchenHotWater.Name = "labelKitchenHotWater";
            this.labelKitchenHotWater.Size = new System.Drawing.Size(120, 20);
            this.labelKitchenHotWater.TabIndex = 10;
            this.labelKitchenHotWater.Text = "Кухня гор. вода:";
            // 
            // textBoxKitchenHotWater
            // 
            this.textBoxKitchenHotWater.Enabled = false;
            this.textBoxKitchenHotWater.Location = new System.Drawing.Point(160, 69);
            this.textBoxKitchenHotWater.Name = "textBoxKitchenHotWater";
            this.textBoxKitchenHotWater.Size = new System.Drawing.Size(125, 27);
            this.textBoxKitchenHotWater.TabIndex = 11;
            this.textBoxKitchenHotWater.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxKitchenHotWater_Validating);
            // 
            // labelKitchenHotWaterOld
            // 
            this.labelKitchenHotWaterOld.AutoSize = true;
            this.labelKitchenHotWaterOld.Location = new System.Drawing.Point(302, 72);
            this.labelKitchenHotWaterOld.Name = "labelKitchenHotWaterOld";
            this.labelKitchenHotWaterOld.Size = new System.Drawing.Size(0, 20);
            this.labelKitchenHotWaterOld.TabIndex = 12;
            // 
            // labelBathroomColdWater
            // 
            this.labelBathroomColdWater.AutoSize = true;
            this.labelBathroomColdWater.Location = new System.Drawing.Point(18, 107);
            this.labelBathroomColdWater.Name = "labelBathroomColdWater";
            this.labelBathroomColdWater.Size = new System.Drawing.Size(136, 20);
            this.labelBathroomColdWater.TabIndex = 13;
            this.labelBathroomColdWater.Text = "Санузел хол. вода:";
            // 
            // textBoxBathroomColdWater
            // 
            this.textBoxBathroomColdWater.Enabled = false;
            this.textBoxBathroomColdWater.Location = new System.Drawing.Point(160, 104);
            this.textBoxBathroomColdWater.Name = "textBoxBathroomColdWater";
            this.textBoxBathroomColdWater.Size = new System.Drawing.Size(125, 27);
            this.textBoxBathroomColdWater.TabIndex = 14;
            this.textBoxBathroomColdWater.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxBathroomColdWater_Validating);
            // 
            // labelBathroomColdWaterOld
            // 
            this.labelBathroomColdWaterOld.AutoSize = true;
            this.labelBathroomColdWaterOld.Location = new System.Drawing.Point(302, 107);
            this.labelBathroomColdWaterOld.Name = "labelBathroomColdWaterOld";
            this.labelBathroomColdWaterOld.Size = new System.Drawing.Size(0, 20);
            this.labelBathroomColdWaterOld.TabIndex = 15;
            // 
            // labelBathroomHotWater
            // 
            this.labelBathroomHotWater.AutoSize = true;
            this.labelBathroomHotWater.Location = new System.Drawing.Point(18, 141);
            this.labelBathroomHotWater.Name = "labelBathroomHotWater";
            this.labelBathroomHotWater.Size = new System.Drawing.Size(136, 20);
            this.labelBathroomHotWater.TabIndex = 16;
            this.labelBathroomHotWater.Text = "Санузел гор. вода:";
            // 
            // textBoxBathroomHotWater
            // 
            this.textBoxBathroomHotWater.Enabled = false;
            this.textBoxBathroomHotWater.Location = new System.Drawing.Point(160, 138);
            this.textBoxBathroomHotWater.Name = "textBoxBathroomHotWater";
            this.textBoxBathroomHotWater.Size = new System.Drawing.Size(125, 27);
            this.textBoxBathroomHotWater.TabIndex = 17;
            this.textBoxBathroomHotWater.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxBathroomHotWater_Validating);
            // 
            // labelBathroomHotWaterOld
            // 
            this.labelBathroomHotWaterOld.AutoSize = true;
            this.labelBathroomHotWaterOld.Location = new System.Drawing.Point(302, 141);
            this.labelBathroomHotWaterOld.Name = "labelBathroomHotWaterOld";
            this.labelBathroomHotWaterOld.Size = new System.Drawing.Size(0, 20);
            this.labelBathroomHotWaterOld.TabIndex = 18;
            // 
            // labelElectricity
            // 
            this.labelElectricity.AutoSize = true;
            this.labelElectricity.Location = new System.Drawing.Point(17, 175);
            this.labelElectricity.Name = "labelElectricity";
            this.labelElectricity.Size = new System.Drawing.Size(114, 20);
            this.labelElectricity.TabIndex = 19;
            this.labelElectricity.Text = "Электричество:";
            // 
            // textBoxElectricity
            // 
            this.textBoxElectricity.Enabled = false;
            this.textBoxElectricity.Location = new System.Drawing.Point(160, 172);
            this.textBoxElectricity.Name = "textBoxElectricity";
            this.textBoxElectricity.Size = new System.Drawing.Size(125, 27);
            this.textBoxElectricity.TabIndex = 20;
            this.textBoxElectricity.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxElectricity_Validating);
            // 
            // labelElectricityOld
            // 
            this.labelElectricityOld.AutoSize = true;
            this.labelElectricityOld.Location = new System.Drawing.Point(302, 175);
            this.labelElectricityOld.Name = "labelElectricityOld";
            this.labelElectricityOld.Size = new System.Drawing.Size(0, 20);
            this.labelElectricityOld.TabIndex = 21;
            // 
            // buttonMeters
            // 
            this.buttonMeters.Enabled = false;
            this.buttonMeters.Location = new System.Drawing.Point(512, 170);
            this.buttonMeters.Name = "buttonMeters";
            this.buttonMeters.Size = new System.Drawing.Size(94, 29);
            this.buttonMeters.TabIndex = 22;
            this.buttonMeters.Text = "&Передать";
            this.buttonMeters.UseVisualStyleBackColor = true;
            this.buttonMeters.Click += new System.EventHandler(this.buttonMeters_Click);
            // 
            // labelMessage
            // 
            this.labelMessage.ForeColor = System.Drawing.Color.Red;
            this.labelMessage.Location = new System.Drawing.Point(13, 316);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(614, 413);
            this.labelMessage.TabIndex = 23;
            this.labelMessage.Text = "Сообщение об ошибке";
            this.labelMessage.Visible = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 341);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.groupBoxMeters);
            this.Controls.Add(this.groupBoxGlobus);
            this.Controls.Add(this.groupBoxMosOblEirc);
            this.Name = "Form1";
            this.Text = "Моя квартира";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxMosOblEirc.ResumeLayout(false);
            this.groupBoxMosOblEirc.PerformLayout();
            this.groupBoxGlobus.ResumeLayout(false);
            this.groupBoxGlobus.PerformLayout();
            this.groupBoxMeters.ResumeLayout(false);
            this.groupBoxMeters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxMosOblEirc;
        private System.Windows.Forms.Label labelMosOblEircCount;
        private System.Windows.Forms.LinkLabel linkLabelMosOblEirc;
        private System.Windows.Forms.GroupBox groupBoxGlobus;
        private System.Windows.Forms.Label labelGlobusCount;
        private System.Windows.Forms.LinkLabel linkLabelGlobus;
        private System.Windows.Forms.GroupBox groupBoxMeters;
        private System.Windows.Forms.Label labelKitchenColdWater;
        private System.Windows.Forms.TextBox textBoxKitchenColdWater;
        private System.Windows.Forms.Label labelKitchenColdWaterOld;
        private System.Windows.Forms.Label labelKitchenHotWater;
        private System.Windows.Forms.TextBox textBoxKitchenHotWater;
        private System.Windows.Forms.Label labelKitchenHotWaterOld;
        private System.Windows.Forms.Label labelBathroomColdWater;
        private System.Windows.Forms.TextBox textBoxBathroomColdWater;
        private System.Windows.Forms.Label labelBathroomColdWaterOld;
        private System.Windows.Forms.Label labelBathroomHotWater;
        private System.Windows.Forms.TextBox textBoxBathroomHotWater;
        private System.Windows.Forms.Label labelBathroomHotWaterOld;
        private System.Windows.Forms.Label labelElectricity;
        private System.Windows.Forms.TextBox textBoxElectricity;
        private System.Windows.Forms.Label labelElectricityOld;
        private System.Windows.Forms.Button buttonMeters;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}

