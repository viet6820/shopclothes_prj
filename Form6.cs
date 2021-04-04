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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            LoadData();

        }
        private void LoadData()
        {
            string sql = "select *from doitac";
            DataTable mytable = ketnoi.ExecuteDataTable_SQL(sql);
            dgdoitac.DataSource = mytable;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql_ins = "insert into doitac (bengh,phi,nguoigiao,sdt) values ('" + cbgiaohang.Text + "', '" + txtphigiao.Text + "','" + txtnguoi.Text + "','" + txtsdt.Text + "',)";
            ketnoi.ExecuteNonData(sql_ins);
            LoadData();
            MessageBox.Show("them thanh cong");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql_sua = "update doitac set phi='" + txtphigiao.Text + "',nguoigiao ='" + txtnguoi.Text + "',sdt='" + txtsdt.Text + "' where bengh='" + cbgiaohang.Text + "'";
            ketnoi.ExecuteNonData(sql_sua);
            LoadData();
            MessageBox.Show("sua thanh cong");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql_xoa = "delete from doitac where bengh ='" + cbgiaohang.Text + "'";
            ketnoi.ExecuteNonData(sql_xoa);
            LoadData();
            MessageBox.Show("xoa thanh cong");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void dgdoitac_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgdoitac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int a = 0;
            cbgiaohang.Text = dgdoitac.Rows[row].Cells[0].Value.ToString();
            txtphigiao.Text = dgdoitac.Rows[row].Cells[1].Value.ToString();
            txtnguoi.Text = dgdoitac.Rows[row].Cells[2].Value.ToString();
            txtsdt.Text = dgdoitac.Rows[row].Cells[3].Value.ToString();
           
        }
    }
}
