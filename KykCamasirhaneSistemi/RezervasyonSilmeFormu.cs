using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KykCamasirhaneSistemi
{
    public partial class RezervasyonSilmeFormu : Form
    {
        public RezervasyonSilmeFormu()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=LAPTOP-A10RFBMB;Initial Catalog=KykCamasirhaneProjesi;Integrated Security=True;";

        private void RezervasyonSilmeFormu_Load(object sender, EventArgs e)
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
                        rezervasyonListesi.Add(new KeyValuePair<int, string>(
                            reader.GetInt32(0),  
                            reader.GetString(1)  
                        ));
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxRezervasyonlar.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir rezervasyon seçin.");
                return;
            }

            KeyValuePair<int, string> selectedRezervasyon = (KeyValuePair<int, string>)comboBoxRezervasyonlar.SelectedItem;
            int rezervasyonID = selectedRezervasyon.Key;

            string query = @"
                DELETE FROM RezervasyonTarihSaat WHERE RezervasyonID = @RezervasyonID;
                DELETE FROM Rezervasyon WHERE RezervasyonID = @RezervasyonID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RezervasyonID", rezervasyonID);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Rezervasyon başarıyla silindi.");
                        LoadRezervasyonlar(); 
                    }
                    else
                    {
                        MessageBox.Show("Rezervasyon silinirken bir hata oluştu.");
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
