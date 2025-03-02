namespace KykCamasirhaneSistemi
{
    partial class RezervasyonGuncellemeFormu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxRezervasyonlar = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.maskedTextBoxBaslangicSaati = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxBitisSaati = new System.Windows.Forms.MaskedTextBox();
            this.dateTimePickerTarih = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxRezervasyonlar
            // 
            this.comboBoxRezervasyonlar.BackColor = System.Drawing.Color.Lavender;
            this.comboBoxRezervasyonlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxRezervasyonlar.FormattingEnabled = true;
            this.comboBoxRezervasyonlar.Location = new System.Drawing.Point(566, 93);
            this.comboBoxRezervasyonlar.Name = "comboBoxRezervasyonlar";
            this.comboBoxRezervasyonlar.Size = new System.Drawing.Size(398, 28);
            this.comboBoxRezervasyonlar.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lavender;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.HotPink;
            this.button1.Location = new System.Drawing.Point(315, 436);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(206, 78);
            this.button1.TabIndex = 1;
            this.button1.Text = "GÜNCELLE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // maskedTextBoxBaslangicSaati
            // 
            this.maskedTextBoxBaslangicSaati.BackColor = System.Drawing.Color.Lavender;
            this.maskedTextBoxBaslangicSaati.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.maskedTextBoxBaslangicSaati.Location = new System.Drawing.Point(352, 175);
            this.maskedTextBoxBaslangicSaati.Mask = "00:00";
            this.maskedTextBoxBaslangicSaati.Name = "maskedTextBoxBaslangicSaati";
            this.maskedTextBoxBaslangicSaati.Size = new System.Drawing.Size(117, 27);
            this.maskedTextBoxBaslangicSaati.TabIndex = 2;
            this.maskedTextBoxBaslangicSaati.ValidatingType = typeof(System.DateTime);
            // 
            // maskedTextBoxBitisSaati
            // 
            this.maskedTextBoxBitisSaati.BackColor = System.Drawing.Color.Lavender;
            this.maskedTextBoxBitisSaati.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.maskedTextBoxBitisSaati.Location = new System.Drawing.Point(352, 231);
            this.maskedTextBoxBitisSaati.Mask = "00:00";
            this.maskedTextBoxBitisSaati.Name = "maskedTextBoxBitisSaati";
            this.maskedTextBoxBitisSaati.Size = new System.Drawing.Size(117, 27);
            this.maskedTextBoxBitisSaati.TabIndex = 3;
            this.maskedTextBoxBitisSaati.ValidatingType = typeof(System.DateTime);
            // 
            // dateTimePickerTarih
            // 
            this.dateTimePickerTarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePickerTarih.Location = new System.Drawing.Point(352, 295);
            this.dateTimePickerTarih.Name = "dateTimePickerTarih";
            this.dateTimePickerTarih.Size = new System.Drawing.Size(200, 27);
            this.dateTimePickerTarih.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.MediumPurple;
            this.label1.Location = new System.Drawing.Point(12, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(548, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Güncellemek istediğiniz rezervasyonu seçiniz:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Lavender;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.HotPink;
            this.label2.Location = new System.Drawing.Point(48, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "BAŞLANGIÇ SAATİ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Lavender;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.HotPink;
            this.label3.Location = new System.Drawing.Point(48, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "BİTİŞ SAATİ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Lavender;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.HotPink;
            this.label4.Location = new System.Drawing.Point(48, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 29);
            this.label4.TabIndex = 8;
            this.label4.Text = "TARİH:";
            // 
            // RezervasyonGuncellemeFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::KykCamasirhaneSistemi.Properties.Resources.indir__6_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(976, 611);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerTarih);
            this.Controls.Add(this.maskedTextBoxBitisSaati);
            this.Controls.Add(this.maskedTextBoxBaslangicSaati);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxRezervasyonlar);
            this.Name = "RezervasyonGuncellemeFormu";
            this.Text = "RezervasyonGuncellemeFormu";
            this.Load += new System.EventHandler(this.RezervasyonGuncellemeFormu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxRezervasyonlar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxBaslangicSaati;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxBitisSaati;
        private System.Windows.Forms.DateTimePicker dateTimePickerTarih;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}