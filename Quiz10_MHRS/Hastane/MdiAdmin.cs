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
    public partial class MdiAdmin : Form
    {
        private int childFormNumber = 0;

        public MdiAdmin()
        {
            InitializeComponent();
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonelEkle frm = new PersonelEkle();
            frm.MdiParent = this;
            frm.Show();
        }

        private void personelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void bRANŞEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BransEkle frm = new BransEkle();
            frm.MdiParent = this;
            frm.Show();
        }

       
    }
}
