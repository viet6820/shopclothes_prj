using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlbanhang
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

       

     

       

        private void hàngĐãGiaoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sảnPhẩmToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();

        }

        private void quảnLýBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void hàngĐangGiaoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tạoĐơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show();

        }

        private void giaoHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void danhSáchSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void quảnLýGiaoHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
        }

        private void đóiTácToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6();
            frm.Show();

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
