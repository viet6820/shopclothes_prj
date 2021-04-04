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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            LoadData();
                
        }
        private void LoadData()
        {
            string sql = "select *from taodon";
            DataTable mytable = ketnoi.ExecuteDataTable_SQL(sql);
            donhang.DataSource = mytable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql_ins = "insert into taodon (madon,makh,tenkh,masp,ngay,diachi,ghichu) values ('" +txtmadon.Text + "', '" + txtmakh.Text + "','" + txttenkh.Text + "','" + txtmasp.Text + "','" + dtngay.Text + "','" + txtdiachi.Text + "','"+txtghichu.Text+"')";
            ketnoi.ExecuteNonData(sql_ins);
            LoadData();
            MessageBox.Show("them thanh cong");
        }

        private void donhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int a = 0;
            txtmadon.Text =donhang.Rows[row].Cells[0].Value.ToString();
            txtmakh.Text = donhang.Rows[row].Cells[1].Value.ToString();
            txttenkh.Text = donhang.Rows[row].Cells[2].Value.ToString();
            txtmasp.Text = donhang.Rows[row].Cells[3].Value.ToString();
            dtngay.Text = donhang.Rows[row].Cells[4].Value.ToString();
            txtdiachi.Text = donhang.Rows[row].Cells[5].Value.ToString();
            txtghichu.Text = donhang.Rows[row].Cells[6].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql_xoa = "delete from taodon where madon ='" + txtmadon.Text + "'";
            ketnoi.ExecuteNonData(sql_xoa);
            LoadData();
            MessageBox.Show("xoa thanh cong");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql_sua = "update taodon set makh='" + txtmakh.Text + "',tenkh ='" + txttenkh.Text + "',masp='" + txtmasp.Text + "',ngay='" + dtngay.Text + "',diachi ='" + txtdiachi.Text + "',ghichu='" + txtghichu.Text + "' where madon='" + txtmadon.Text + "'";
            ketnoi.ExecuteNonData(sql_sua);
            LoadData();
            MessageBox.Show("sua thanh cong");
        }
        private void lodakey()
        {
            string con = @"Data Source=DESKTOP-VH30DJO\SQLEXPRESS;Initial Catalog=QuanLy;Integrated Security=True";
            SqlConnection conn = new SqlConnection(con);
            string madon = txttim.Text;
            string sql_tim = ("select *from taodon where madon like '%" + txttim.Text + "%'");
            SqlDataAdapter da = new SqlDataAdapter(sql_tim, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "madon");
            donhang.DataSource = ds.Tables["madon"];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            lodakey();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            base.Close();

        }
    }
}
