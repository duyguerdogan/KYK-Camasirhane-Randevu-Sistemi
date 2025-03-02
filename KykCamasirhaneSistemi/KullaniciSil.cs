using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KykCamasirhaneSistemi
{
    public partial class KullaniciSil : Form
    {
        public KullaniciSil()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=LAPTOP-A10RFBMB;Initial Catalog=KykCamasirhaneProjesi;Integrated Security=True;";

        private void KullaniciSil_Load(object sender, EventArgs e)
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

       
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxKullanici.SelectedItem == null)
            {
                MessageBox.Show("Lütfen silmek istediğiniz kullanıcıyı seçin.");
                return;
            }

            KeyValuePair<int, string> selectedKullanici = (KeyValuePair<int, string>)comboBoxKullanici.SelectedItem;
            int kullaniciID = selectedKullanici.Key;

            string deleteRezervasyonQuery = "DELETE FROM Rezervasyon WHERE KullaniciID = @KullaniciID";
            string deleteKullaniciSecimiQuery = "DELETE FROM KullaniciSecimi WHERE KullaniciID = @KullaniciID";
            string deleteKullaniciBilgileriQuery = "DELETE FROM KullaniciBilgileri WHERE KullaniciID = @KullaniciID";
            string deleteKullaniciQuery = "DELETE FROM Kullanici WHERE KullaniciID = @KullaniciID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand commandRezervasyon = new SqlCommand(deleteRezervasyonQuery, connection);
                SqlCommand commandKullaniciSecimi = new SqlCommand(deleteKullaniciSecimiQuery, connection);
                SqlCommand commandBilgileri = new SqlCommand(deleteKullaniciBilgileriQuery, connection);
                SqlCommand commandKullanici = new SqlCommand(deleteKullaniciQuery, connection);

                commandRezervasyon.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                commandKullaniciSecimi.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                commandBilgileri.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                commandKullanici.Parameters.AddWithValue("@KullaniciID", kullaniciID);

                try
                {
                    connection.Open();

                    commandRezervasyon.ExecuteNonQuery();
                    commandKullaniciSecimi.ExecuteNonQuery();
                    commandBilgileri.ExecuteNonQuery();

                    commandKullanici.ExecuteNonQuery();

                    MessageBox.Show("Kullanıcı başarıyla silindi.");
                    comboBoxKullanici.Items.Remove(comboBoxKullanici.SelectedItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
    }
}
