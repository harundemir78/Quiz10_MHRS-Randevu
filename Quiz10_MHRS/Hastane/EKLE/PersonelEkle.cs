using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane
{
    public partial class PersonelEkle : Form
    {
        public PersonelEkle()
        {
            InitializeComponent();
        }

        private void PersonelEkle_Load(object sender, EventArgs e)
        {
         
            DBIslem.PersonelTurGetir(cmdPersonelTur);
            cmdCins.SelectedIndex = 0;
            DBIslem.PersonelBransGetir(cmbBrans);
            cmbBrans.SelectedIndex = 0;

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
        
        byte[] resimDizi;
        private void btnResim_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Resim Seç";
            openFileDialog1.Filter = "Jpeg|*jpg|PNG(*.png)|*.png";
            MemoryStream resim = new MemoryStream();
            
            if (openFileDialog1.ShowDialog()==DialogResult.OK)

            {
                
                Image img = Image.FromFile(openFileDialog1.FileName);
                resimKutu.Image = img;
                img.Save(resim,ImageFormat.Bmp);
                resimDizi  = resim.ToArray();

            }
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            bool cins;
            if (cmdCins.SelectedItem.ToString() == "ERKEK")
                cins = Convert.ToBoolean(1);
            else
                cins = Convert.ToBoolean(0);
           
            string mesaj = DBIslem.PersonelKayit(int.Parse(cmdPersonelTur.SelectedValue.ToString()), txtTc.Text, txtAd.Text, txtSoyad.Text,cins, resimDizi, txtParola.Text, txtParola2.Text);
            MessageBox.Show(mesaj);
          
        }
    }
}
