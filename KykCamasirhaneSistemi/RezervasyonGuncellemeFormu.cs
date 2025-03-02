using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KykCamasirhaneSistemi
{
    public partial class RezervasyonGuncellemeFormu : Form
    {
        public RezervasyonGuncellemeFormu()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=LAPTOP-A10RFBMB;Initial Catalog=KykCamasirhaneProjesi;Integrated Security=True;";

        
        private void RezervasyonGuncellemeFormu_Load(object sender, EventArgs e)
        {
            LoadRezervasyonlar();
        }

        private void LoadRezervasyonlar()
        {
            string query = @"
                SELECT 
                    Rezervasyon.RezervasyonID, 
                    CONCAT(Kullanici.Ad, ' ', Kullanici.Soyad, ' - ', 
                           CONVERT(VARCHAR(10), RezervasyonTarihSaat.Tarih, 120), ' ', 
                           FORMAT(RezervasyonTarihSaat.BaslangicSaati, 'hh\:mm'), '-', 
                           FORMAT(RezervasyonTarihSaat.BitisSaati, 'hh\:mm')) AS RezervasyonBilgi
                FROM 
                    Rezervasyon
                INNER JOIN 
                    Kullanici ON Rezervasyon.KullaniciID = Kullanici.KullaniciID
                INNER JOIN 
                    RezervasyonTarihSaat ON Rezervasyon.RezervasyonID = RezervasyonTarihSaat.RezervasyonID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    var rezervasyonListesi = new List<KeyValuePair<int, string>>();

                    while (reader.Read())
                    {
                        rezervasyonListesi.Add(new KeyValuePair<int, string>(reader.GetInt32(0), reader.GetString(1)));
                    }

                    comboBoxRezervasyonlar.DataSource = rezervasyonListesi;
                    comboBoxRezervasyonlar.DisplayMember = "Value";
                    comboBoxRezervasyonlar.ValueMember = "Key";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        
        private void comboBoxRezervasyonlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRezervasyonlar.SelectedItem != null)
            {
                KeyValuePair<int, string> selectedRezervasyon = (KeyValuePair<int, string>)comboBoxRezervasyonlar.SelectedItem;
                int rezervasyonID = selectedRezervasyon.Key;

               
                LoadRezervasyonBilgileri(rezervasyonID);
            }
        }

       
        private void LoadRezervasyonBilgileri(int rezervasyonID)
        {
            string query = @"
                SELECT 
                    RezervasyonTarihSaat.Tarih, 
                    RezervasyonTarihSaat.BaslangicSaati, 
                    RezervasyonTarihSaat.BitisSaati
                FROM 
                    RezervasyonTarihSaat
                WHERE 
                    RezervasyonTarihSaat.RezervasyonID = @RezervasyonID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RezervasyonID", rezervasyonID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                       
                        dateTimePickerTarih.Value = reader.GetDateTime(0);
                        maskedTextBoxBaslangicSaati.Text = reader.GetTimeSpan(1).ToString(@"hh\:mm");
                        maskedTextBoxBitisSaati.Text = reader.GetTimeSpan(2).ToString(@"hh\:mm");
                    }
                    else
                    {
                        MessageBox.Show("Seçilen rezervasyona ait bilgiler bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxRezervasyonlar.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir rezervasyon seçin.");
                return;
            }

            KeyValuePair<int, string> selectedRezervasyon = (KeyValuePair<int, string>)comboBoxRezervasyonlar.SelectedItem;
            int rezervasyonID = selectedRezervasyon.Key;

            DateTime tarih = dateTimePickerTarih.Value;
            TimeSpan baslangicSaati;
            TimeSpan bitisSaati;

            
            if (!TimeSpan.TryParse(maskedTextBoxBaslangicSaati.Text, out baslangicSaati) ||
                !TimeSpan.TryParse(maskedTextBoxBitisSaati.Text, out bitisSaati))
            {
                MessageBox.Show("Geçersiz saat formatı. Lütfen saatleri HH:mm formatında girin.");
                return;
            }

            
            if (bitisSaati <= baslangicSaati)
            {
                MessageBox.Show("Bitiş saati başlangıç saatinden büyük olmalıdır.");
                return;
            }

            string query = @"
                UPDATE RezervasyonTarihSaat
                SET Tarih = @Tarih, BaslangicSaati = @BaslangicSaati, BitisSaati = @BitisSaati
                WHERE RezervasyonID = @RezervasyonID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Tarih", tarih);
                command.Parameters.AddWithValue("@BaslangicSaati", baslangicSaati);
                command.Parameters.AddWithValue("@BitisSaati", bitisSaati);
                command.Parameters.AddWithValue("@RezervasyonID", rezervasyonID);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Rezervasyon başarıyla güncellendi.");
                    }
                    else
                    {
                        MessageBox.Show("Güncellenebilecek rezervasyon bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
    }
}
