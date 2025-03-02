namespace KykCamasirhaneSistemi
{
    partial class girisFormu
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
            this.girisbutonu = new System.Windows.Forms.Button();
            this.labelkullanıcıg = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // girisbutonu
            // 
            this.girisbutonu.BackColor = System.Drawing.Color.LightSteelBlue;
            this.girisbutonu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.girisbutonu.ForeColor = System.Drawing.Color.Indigo;
            this.girisbutonu.Location = new System.Drawing.Point(285, 369);
            this.girisbutonu.Name = "girisbutonu";
            this.girisbutonu.Size = new System.Drawing.Size(211, 58);
            this.girisbutonu.TabIndex = 8;
            this.girisbutonu.Text = "GİRİŞ YAP";
            this.girisbutonu.UseVisualStyleBackColor = false;
            this.girisbutonu.Click += new System.EventHandler(this.girisbutonu_Click);
            // 
            // labelkullanıcıg
            // 
            this.labelkullanıcıg.AutoSize = true;
            this.labelkullanıcıg.BackColor = System.Drawing.Color.MediumPurple;
            this.labelkullanıcıg.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelkullanıcıg.ForeColor = System.Drawing.Color.Pink;
            this.labelkullanıcıg.Location = new System.Drawing.Point(50, 179);
            this.labelkullanıcıg.Name = "labelkullanıcıg";
            this.labelkullanıcıg.Size = new System.Drawing.Size(731, 76);
            this.labelkullanıcıg.TabIndex = 7;
            this.labelkullanıcıg.Text = "KYK ÇAMAŞIRHANE RANDEVU SİSTEMİNE \r\n                       HOŞGELDİNİZ!";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::KykCamasirhaneSistemi.Properties.Resources.WhatsApp_Image_2024_12_29_at_19_04_35;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(-2, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 63);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // girisFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::KykCamasirhaneSistemi.Properties.Resources.indir__5_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(840, 497);
            this.Controls.Add(this.girisbutonu);
            this.Controls.Add(this.labelkullanıcıg);
            this.Controls.Add(this.pictureBox1);
            this.Name = "girisFormu";
            this.Text = "girisFormu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button girisbutonu;
        private System.Windows.Forms.Label labelkullanıcıg;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}