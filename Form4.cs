using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlbanhang
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyDataSet3.vanchuyen' table. You can move, or remove it, as needed.
            this.vanchuyenTableAdapter.Fill(this.quanLyDataSet3.vanchuyen);
            LoadData();

        }
        private void LoadData()
        {
            string sql = "select *from vanchuyen";
            DataTable mytable = ketnoi.ExecuteDataTable_SQL(sql);
            dgvanchuyen.DataSource = mytable;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void dgvanchuyen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int a = 0;
            txtmavc.Text = dgvanchuyen.Rows[row].Cells[0].Value.ToString();
            txtmadon.Text = dgvanchuyen.Rows[row].Cells[1].Value.ToString();
            txtdiachi.Text = dgvanchuyen.Rows[row].Cells[2].Value.ToString();
            dtngaygiao.Text = dgvanchuyen.Rows[row].Cells[3].Value.ToString();
            cbbengiao.Text = dgvanchuyen.Rows[row].Cells[4].Value.ToString();
            txtnguoigiao.Text = dgvanchuyen.Rows[row].Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql_xoa = "delete from vanchuyen where mavc ='" + txtmavc.Text + "'";
            ketnoi.ExecuteNonData(sql_xoa);
            LoadData();
            MessageBox.Show("xoa thanh cong");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql_sua = "update vanchuyen set madon='" + txtmadon.Text + "',diachi ='" + txtdiachi.Text + "',ngaygiao='" + dtngaygiao.Text + "',ghichu='" + cbbengiao.Text + "',nguoigiao ='" + txtnguoigiao.Text + "' where mavc='" + txtmavc.Text + "'";
            ketnoi.ExecuteNonData(sql_sua);
            LoadData();
            MessageBox.Show("sua thanh cong");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql_ins = "insert into vanchuyen(mavc,madon,diachi,ngaygiao,ghichu,nguoigiao) values ('" + txtmavc.Text + "', '" + txtmadon.Text + "','" + txtdiachi.Text + "','" + dtngaygiao.Text + "','" + cbbengiao.Text + "','" + txtnguoigiao.Text + "')";
            ketnoi.ExecuteNonData(sql_ins);
            LoadData();
            MessageBox.Show("them thanh cong");
        }
        private void lodakey()
        {
            string con = @"Data Source=DESKTOP-VH30DJO\SQLEXPRESS;Initial Catalog=QuanLy;Integrated Security=True";
            SqlConnection conn = new SqlConnection(con);
            string mavc = txtmavc.Text;
            string sql_tim = ("select *from vanchuyen where mavc like '%" + txtmavc.Text + "%'");
            SqlDataAdapter da = new SqlDataAdapter(sql_tim, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "mavc");
            dgvanchuyen.DataSource = ds.Tables["mavc"];
        }
        private void button5_Click(object sender, EventArgs e)
        {
            lodakey();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}
