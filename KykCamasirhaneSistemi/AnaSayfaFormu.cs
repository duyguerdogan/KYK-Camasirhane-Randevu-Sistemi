using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KykCamasirhaneSistemi
{
    public partial class AnaSayfaFormu : Form
    {
        public AnaSayfaFormu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MakineSecimi MakineSecimi = new MakineSecimi();
            MakineSecimi.FormClosed += (s, args) => this.Show(); 
            MakineSecimi.Show();
        }

        private void AnaSayfaFormu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            KullaniciBilgileri KullaniciBilgileri = new KullaniciBilgileri();
            KullaniciBilgileri.FormClosed += (s, args) => this.Show(); 
            KullaniciBilgileri.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RezervasyonListele RezervasyonListele = new RezervasyonListele();
            RezervasyonListele.FormClosed += (s, args) => this.Show(); 
            RezervasyonListele.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            KullaniciListele KullaniciListele = new KullaniciListele();
            KullaniciListele.FormClosed += (s, args) => this.Show(); 
            KullaniciListele.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
