namespace KykCamasirhaneSistemi
{
    partial class RezervasyonListele
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
            this.components = new System.ComponentModel.Container();
            this.dataGridViewRezervasyonlar = new System.Windows.Forms.DataGridView();
            this.kykCamasirhaneProjesiDataSet = new KykCamasirhaneSistemi.KykCamasirhaneProjesiDataSet();
            this.kykCamasirhaneProjesiDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRezervasyonlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kykCamasirhaneProjesiDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kykCamasirhaneProjesiDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRezervasyonlar
            // 
            this.dataGridViewRezervasyonlar.AllowUserToDeleteRows = false;
            this.dataGridViewRezervasyonlar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRezervasyonlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRezervasyonlar.Location = new System.Drawing.Point(12, 392);
            this.dataGridViewRezervasyonlar.Name = "dataGridViewRezervasyonlar";
            this.dataGridViewRezervasyonlar.RowHeadersWidth = 51;
            this.dataGridViewRezervasyonlar.RowTemplate.Height = 24;
            this.dataGridViewRezervasyonlar.Size = new System.Drawing.Size(1329, 412);
            this.dataGridViewRezervasyonlar.TabIndex = 0;
            // 
            // kykCamasirhaneProjesiDataSet
            // 
            this.kykCamasirhaneProjesiDataSet.DataSetName = "KykCamasirhaneProjesiDataSet";
            this.kykCamasirhaneProjesiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // kykCamasirhaneProjesiDataSetBindingSource
            // 
            this.kykCamasirhaneProjesiDataSetBindingSource.DataSource = this.kykCamasirhaneProjesiDataSet;
            this.kykCamasirhaneProjesiDataSetBindingSource.Position = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.DarkMagenta;
            this.button1.Location = new System.Drawing.Point(1045, 158);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 78);
            this.button1.TabIndex = 1;
            this.button1.Text = "YENİLE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ForeColor = System.Drawing.Color.DarkMagenta;
            this.button2.Location = new System.Drawing.Point(698, 158);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 78);
            this.button2.TabIndex = 2;
            this.button2.Text = "GÜNCELLE";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.ForeColor = System.Drawing.Color.DarkMagenta;
            this.button3.Location = new System.Drawing.Point(348, 158);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(180, 78);
            this.button3.TabIndex = 3;
            this.button3.Text = "SİL";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button4.ForeColor = System.Drawing.Color.DarkMagenta;
            this.button4.Location = new System.Drawing.Point(32, 158);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(180, 78);
            this.button4.TabIndex = 4;
            this.button4.Text = "EKLE";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // RezervasyonListele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::KykCamasirhaneSistemi.Properties.Resources.Wallpaper;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1334, 799);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewRezervasyonlar);
            this.Name = "RezervasyonListele";
            this.Text = "RezervasyonListele";
            this.Load += new System.EventHandler(this.RezervasyonListele_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRezervasyonlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kykCamasirhaneProjesiDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kykCamasirhaneProjesiDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRezervasyonlar;
        private KykCamasirhaneProjesiDataSet kykCamasirhaneProjesiDataSet;
        private System.Windows.Forms.BindingSource kykCamasirhaneProjesiDataSetBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}