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
    public partial class MakineSecimi : Form
    {
        public MakineSecimi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CamasirMakinesi CamasirMakinesi = new CamasirMakinesi();
            CamasirMakinesi.FormClosed += (s, args) => this.Show(); 
            CamasirMakinesi.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KurutmaMakinesi KurutmaMakinesi = new KurutmaMakinesi();
            KurutmaMakinesi.FormClosed += (s, args) => this.Show(); 
            KurutmaMakinesi.Show();
        }
    }
}
