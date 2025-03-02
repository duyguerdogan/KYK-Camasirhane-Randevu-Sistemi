using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KykCamasirhaneSistemi
{
    public partial class RezervasyonListele : Form
    {
        public RezervasyonListele()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=LAPTOP-A10RFBMB;Initial Catalog=KykCamasirhaneProjesi;Integrated Security=True;";

        private void RezervasyonListele_Load(object sender, EventArgs e)
        {
            LoadRezervasyonlar(); 

        }

        private void LoadRezervasyonlar()
        {
            string query = @"
        SELECT 
            r.RezervasyonID,
            rs.Tarih,
            rs.BaslangicSaati,
            rs.BitisSaati,
            k.Ad + ' ' + k.Soyad AS KullaniciAdi,
            ms.KurutmaMakinesiNo
        FROM RezervasyonTarihSaat rs
        INNER JOIN Rezervasyon r ON rs.RezervasyonID = r.RezervasyonID
        INNER JOIN Kullanici k ON r.KullaniciID = k.KullaniciID
        INNER JOIN MakineSecimi ms ON r.SecimID = ms.SecimID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                System.Data.DataTable dataTable = new System.Data.DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                    dataGridViewRezervasyonlar.DataSource = dataTable;

                    
                    dataGridViewRezervasyonlar.Columns["RezervasyonID"].HeaderText = "Rezervasyon No";
                    dataGridViewRezervasyonlar.Columns["Tarih"].HeaderText = "Tarih";
                    dataGridViewRezervasyonlar.Columns["BaslangicSaati"].HeaderText = "Başlangıç Saati";
                    dataGridViewRezervasyonlar.Columns["BitisSaati"].HeaderText = "Bitiş Saati";
                    dataGridViewRezervasyonlar.Columns["KullaniciAdi"].HeaderText = "Kullanıcı Adı";
                    dataGridViewRezervasyonlar.Columns["KurutmaMakinesiNo"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Rezervasyonlar yüklenirken hata oluştu: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadRezervasyonlar(); 
            MessageBox.Show("Veriler yenilendi!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MakineSecimi MakineSecimi = new MakineSecimi();
            MakineSecimi.FormClosed += (s, args) => this.Show(); 
            MakineSecimi.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RezervasyonSilmeFormu RezervasyonSilmeFormu = new RezervasyonSilmeFormu();
            RezervasyonSilmeFormu.FormClosed += (s, args) => this.Show(); 
            RezervasyonSilmeFormu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RezervasyonGuncellemeFormu RezervasyonGuncellemeFormu = new RezervasyonGuncellemeFormu();
            RezervasyonGuncellemeFormu.FormClosed += (s, args) => this.Show(); 
            RezervasyonGuncellemeFormu.Show();
        }
    }
}
