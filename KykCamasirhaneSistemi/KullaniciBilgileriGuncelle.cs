using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KykCamasirhaneSistemi
{
    public partial class KullaniciBilgileriGuncelle : Form
    {
        public KullaniciBilgileriGuncelle()
        {
            InitializeComponent();
        }

       
        string connectionString = "Data Source=LAPTOP-A10RFBMB;Initial Catalog=KykCamasirhaneProjesi;Integrated Security=True;";

        private void KullaniciBilgileriGuncelle_Load(object sender, EventArgs e)
        {
            LoadKullaniciListesi();
        }

      
        private void LoadKullaniciListesi()
        {
            string query = "SELECT KullaniciID, CONCAT(Ad, ' ', Soyad) AS KullaniciAdi FROM Kullanici";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBoxKullanici.Items.Add(new KeyValuePair<int, string>(
                            reader.GetInt32(0),
                            reader.GetString(1)
                        ));
                    }
                    comboBoxKullanici.DisplayMember = "Value";
                    comboBoxKullanici.ValueMember = "Key";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void comboBoxKullanici_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxKullanici.SelectedItem != null)
            {
                KeyValuePair<int, string> selectedKullanici = (KeyValuePair<int, string>)comboBoxKullanici.SelectedItem;
                int kullaniciID = selectedKullanici.Key;

                LoadKullaniciBilgileri(kullaniciID);
            }
        }

        private void LoadKullaniciBilgileri(int kullaniciID)
        {
            string query = "SELECT k.Ad, k.Soyad, k.Telefon, kb.BlokNo, kb.OdaNo " +
                           "FROM Kullanici k " +
                           "INNER JOIN KullaniciBilgileri kb ON k.KullaniciID = kb.KullaniciID " +
                           "WHERE k.KullaniciID = @KullaniciID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@KullaniciID", kullaniciID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        textBoxAd.Text = reader.GetString(0);
                        textBoxSoyad.Text = reader.GetString(1);
                        textBoxTelefon.Text = reader.GetString(2);
                        textBoxBlokNo.Text = reader.GetInt32(3).ToString();
                        textBoxOdaNo.Text = reader.GetInt32(4).ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        
       

        private void textBoxAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxKullanici.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir kullanıcı seçin.");
                return;
            }

            KeyValuePair<int, string> selectedKullanici = (KeyValuePair<int, string>)comboBoxKullanici.SelectedItem;
            int kullaniciID = selectedKullanici.Key;

            string ad = textBoxAd.Text;
            string soyad = textBoxSoyad.Text;
            string telefon = textBoxTelefon.Text;

           
            int blokNo = 0, odaNo = 0;
            int.TryParse(textBoxBlokNo.Text, out blokNo);
            int.TryParse(textBoxOdaNo.Text, out odaNo);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                
                List<string> queryParts = new List<string>();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                if (!string.IsNullOrEmpty(ad))
                {
                    queryParts.Add("Ad = @Ad");
                    command.Parameters.AddWithValue("@Ad", ad);
                }

                if (!string.IsNullOrEmpty(soyad))
                {
                    queryParts.Add("Soyad = @Soyad");
                    command.Parameters.AddWithValue("@Soyad", soyad);
                }

                if (!string.IsNullOrEmpty(telefon))
                {
                    queryParts.Add("Telefon = @Telefon");
                    command.Parameters.AddWithValue("@Telefon", telefon);
                }

                if (queryParts.Count > 0)
                {
                    string query = "UPDATE Kullanici SET " + string.Join(", ", queryParts) + " WHERE KullaniciID = @KullaniciID";
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@KullaniciID", kullaniciID);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                        return;
                    }
                }

                
                queryParts.Clear();
                SqlCommand commandBilgiler = new SqlCommand();
                commandBilgiler.Connection = connection;

                if (blokNo > 0)
                {
                    queryParts.Add("BlokNo = @BlokNo");
                    commandBilgiler.Parameters.AddWithValue("@BlokNo", blokNo);
                }

                if (odaNo > 0)
                {
                    queryParts.Add("OdaNo = @OdaNo");
                    commandBilgiler.Parameters.AddWithValue("@OdaNo", odaNo);
                }

                if (queryParts.Count > 0)
                {
                    string queryBilgiler = "UPDATE KullaniciBilgileri SET " + string.Join(", ", queryParts) + " WHERE KullaniciID = @KullaniciID";
                    commandBilgiler.CommandText = queryBilgiler;
                    commandBilgiler.Parameters.AddWithValue("@KullaniciID", kullaniciID);

                    try
                    {
                        commandBilgiler.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                        return;
                    }
                }

                MessageBox.Show("Kullanıcı bilgileri başarıyla güncellendi.");
            }
        }

    }
}
