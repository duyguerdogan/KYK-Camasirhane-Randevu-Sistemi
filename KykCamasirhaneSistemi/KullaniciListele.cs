using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KykCamasirhaneSistemi
{
    public partial class KullaniciListele : Form
    {
        public KullaniciListele()
        {
            InitializeComponent();
        }

       
        string connectionString = "Data Source=LAPTOP-A10RFBMB;Initial Catalog=KykCamasirhaneProjesi;Integrated Security=True;";

        private void KullaniciListele_Load(object sender, EventArgs e)
        {
            LoadKullaniciBilgileri();
        }

        private void LoadKullaniciBilgileri()
        {
            
            string query = @"
                SELECT k.KullaniciID, k.Ad, k.Soyad, k.Telefon, kb.BlokNo, kb.OdaNo
                FROM Kullanici k
                INNER JOIN KullaniciBilgileri kb ON k.KullaniciID = kb.KullaniciID
            ";

           
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                try
                {
                    connection.Open();
                    dataAdapter.Fill(dataTable); 
                    dataGridViewKullaniciBilgileri.DataSource = dataTable;  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KullaniciBilgileriGuncelle KullaniciBilgileriGuncelle = new KullaniciBilgileriGuncelle();
            KullaniciBilgileriGuncelle.FormClosed += (s, args) => this.Show(); 
            KullaniciBilgileriGuncelle.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KullaniciSil KullaniciSil = new KullaniciSil();
            KullaniciSil.FormClosed += (s, args) => this.Show(); 
            KullaniciSil.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KullaniciBilgileri KullaniciBilgileri = new KullaniciBilgileri();
            KullaniciBilgileri.FormClosed += (s, args) => this.Show(); 
            KullaniciBilgileri.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadKullaniciBilgileri(); 
            MessageBox.Show("Kullanıcı bilgileri yenilendi!"); 
        }
    }
}
