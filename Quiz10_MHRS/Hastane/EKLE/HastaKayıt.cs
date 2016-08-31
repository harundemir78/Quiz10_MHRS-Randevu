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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

       

        private void Form2_Load(object sender, EventArgs e)
        {
            cmdCins.SelectedIndex = 0;
        }
        //string tc, string ad, string soyad, DateTime dogumTarihi, string cins, string pass1, string pass2
        

        private void btnKayit_Click_1(object sender, EventArgs e)
        {
            bool cins;
            if(cmdCins.SelectedItem.ToString()=="ERKEK")
                cins=Convert.ToBoolean( 1);
            else
                cins=Convert.ToBoolean( 0);
            string dTarihi=dtTarih.Value.ToShortDateString();
            
            string kayit=DBIslem.HastaKayit(txtTc.Text,txtAd.Text,txtSoyad.Text,dTarihi,cins,txtParola.Text,txtParola2.Text);
            MessageBox.Show(kayit);


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
