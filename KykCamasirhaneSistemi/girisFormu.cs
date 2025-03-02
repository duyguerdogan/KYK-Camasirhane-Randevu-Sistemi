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
    public partial class girisFormu : Form
    {
        public girisFormu()
        {
            InitializeComponent();
        }

        private void girisbutonu_Click(object sender, EventArgs e)
        {
            AnaSayfaFormu AnaSayfaFormu = new AnaSayfaFormu();
            AnaSayfaFormu.FormClosed += (s, args) => this.Show(); 
            AnaSayfaFormu.Show();
        }
    }
}
