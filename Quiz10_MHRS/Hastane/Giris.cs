using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
       
        private void btnKayit_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string durum= DBIslem.KullaniciGiris(txtTc.Text,txtParola.Text);
            switch (durum)
           {
               case null: MdiHasta frm = new MdiHasta();
                   frm.Show();
                   this.Hide();
                   break;
               case "1": 
                   MdiDoktor frm2 = new MdiDoktor();
                   frm2.Show();
                   this.Hide();
                   break;
               case "2":
                    MdiAdmin frm3 = new MdiAdmin();
                    frm3.Show();
                    this.Hide();
                    break;
               default: MessageBox.Show(durum);
                   break;
           }
            
        }

        private void txtTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
