using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KykCamasirhaneSistemi
{
    public partial class KurutmaMakinesi : Form
    {
        public KurutmaMakinesi()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=LAPTOP-A10RFBMB;Initial Catalog=KykCamasirhaneProjesi;Integrated Security=True;";

        private void KurutmaMakinesi_Load_1(object sender, EventArgs e)
        {
            LoadMakineDurumlari();
            LoadBosMakineler();
            LoadKullanicilar();
        }

        private void LoadMakineDurumlari()
        {
            string bosQuery = "SELECT KurutmaMakinesiNo FROM KurutmaMakinesiDurumu WHERE Dolu = 0";
            string doluQuery = "SELECT KurutmaMakinesiNo FROM KurutmaMakinesiDurumu WHERE Dolu = 1";

            List<int> bosMakineler = GetMakineList(bosQuery);
            List<int> doluMakineler = GetMakineList(doluQuery);

            label2.Text = "Boş Kurutma Makineleri: " + string.Join(", ", bosMakineler);
            label3.Text = "Dolu Kurutma Makineleri: " + string.Join(", ", doluMakineler);
        }

        private List<int> GetMakineList(string query)
        {
            List<int> makineListesi = new List<int>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        makineListesi.Add(reader.GetInt32(0));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }

            return makineListesi;
        }

        private void LoadBosMakineler()
        {
            string query = "SELECT KurutmaMakinesiNo FROM KurutmaMakinesiDurumu WHERE Dolu = 0";
            List<int> bosMakineler = GetMakineList(query);
            comboBox1.DataSource = bosMakineler;
        }

        private void LoadKullanicilar()
        {
            string query = "SELECT KullaniciID, CONCAT(Ad, ' ', Soyad) AS KullaniciAdi FROM Kullanici";
            Dictionary<int, string> kullanicilar = new Dictionary<int, string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int kullaniciID = reader.GetInt32(0);
                        string kullaniciAdi = reader.GetString(1);
                        kullanicilar.Add(kullaniciID, kullaniciAdi);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }

            comboBoxKullanicilar.DataSource = new BindingSource(kullanicilar, null);
            comboBoxKullanicilar.DisplayMember = "Value";
            comboBoxKullanicilar.ValueMember = "Key";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir makine seçin.");
                return;
            }

            if (comboBoxKullanicilar.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir kullanıcı seçin.");
                return;
            }

            int secilenMakineNo = (int)comboBox1.SelectedItem;
            int kullaniciID = ((KeyValuePair<int, string>)comboBoxKullanicilar.SelectedItem).Key;

            DateTime tarih = dateTimePickerTarih.Value.Date;

            if (!TimeSpan.TryParse(maskedTextBoxBaslangicSaati.Text, out TimeSpan baslangicSaat))
            {
                MessageBox.Show("Başlangıç saati geçerli bir formatta değil. Lütfen HH:mm formatında giriniz.");
                return;
            }

            if (!TimeSpan.TryParse(maskedTextBoxBitisSaati.Text, out TimeSpan bitisSaat))
            {
                MessageBox.Show("Bitiş saati geçerli bir formatta değil. Lütfen HH:mm formatında giriniz.");
                return;
            }

            if (bitisSaat <= baslangicSaat)
            {
                MessageBox.Show("Bitiş saati, başlangıç saatinden sonra olmalıdır.");
                return;
            }

            int secimID = AddMakineSecimi(secilenMakineNo);

            if (secimID > 0)
            {
                int rezervasyonID = AddRezervasyon(secimID, kullaniciID);

                if (rezervasyonID > 0)
                {
                    AddRezervasyonTarihSaat(rezervasyonID, tarih, baslangicSaat, bitisSaat);
                    UpdateMakineDurumu(secilenMakineNo);
                    LoadMakineDurumlari();
                    LoadBosMakineler();
                }
            }
        }

        private int AddMakineSecimi(int makineNo)
        {
            string query = "INSERT INTO MakineSecimi (KurutmaMakinesiNo) OUTPUT INSERTED.SecimID VALUES (@MakineNo)";
            int secimID = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MakineNo", makineNo);

                try
                {
                    connection.Open();
                    secimID = (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Makine seçimi eklenirken hata oluştu: " + ex.Message);
                }
            }

            return secimID;
        }

        private void AddRezervasyonTarihSaat(int rezervasyonID, DateTime tarih, TimeSpan baslangicSaat, TimeSpan bitisSaat)
        {
            string tarihSaatQuery = @"INSERT INTO RezervasyonTarihSaat (RezervasyonID, Tarih, BaslangicSaati, BitisSaati) 
                                      VALUES (@RezervasyonID, @Tarih, @BaslangicSaati, @BitisSaati)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(tarihSaatQuery, connection);

                command.Parameters.AddWithValue("@RezervasyonID", rezervasyonID);
                command.Parameters.AddWithValue("@Tarih", tarih);
                command.Parameters.AddWithValue("@BaslangicSaati", baslangicSaat.ToString(@"hh\:mm\:ss"));
                command.Parameters.AddWithValue("@BitisSaati", bitisSaat.ToString(@"hh\:mm\:ss"));

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Rezervasyon tarih ve saati eklenirken hata oluştu: " + ex.Message);
                }
            }
        }

        private void UpdateMakineDurumu(int makineNo)
        {
            string query = "UPDATE KurutmaMakinesiDurumu SET Dolu = 1 WHERE KurutmaMakinesiNo = @MakineNo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MakineNo", makineNo);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Makine durumu güncellenirken hata oluştu: " + ex.Message);
                }
            }
        }

        private int AddRezervasyon(int secimID, int kullaniciID)
        {
            string query = @"INSERT INTO Rezervasyon (SecimID, KullaniciID) 
                             OUTPUT INSERTED.RezervasyonID 
                             VALUES (@SecimID, @KullaniciID)";

            int rezervasyonID = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SecimID", secimID);
                command.Parameters.AddWithValue("@KullaniciID", kullaniciID);

                try
                {
                    connection.Open();
                    rezervasyonID = (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Rezervasyon eklenirken hata oluştu: " + ex.Message);
                }
            }

            return rezervasyonID;
        }
    }
}
