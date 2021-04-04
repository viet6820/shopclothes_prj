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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string sql_ins = "insert into HANG(masp,tensp,mau,lao,gia,sl) values ('" + txtmasp.Text + "', '" + txttensp.Text + "','" + txtmausac.Text + "','" + txtloai.Text + "','" + txtgiatien.Text + "','"+txtsl.Text+"')";
            ketnoi.ExecuteNonData(sql_ins);
            LoadData();
            MessageBox.Show("them thanh cong");
        }
        private void LoadData()
        {
            string sql = "select *from HANG";
            DataTable mytable = ketnoi.ExecuteDataTable_SQL(sql);
            dssanpham.DataSource = mytable;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyDataSet.HANG' table. You can move, or remove it, as needed.
            this.hANGTableAdapter.Fill(this.quanLyDataSet.HANG);
            LoadData();
        }

        private void dssanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int a = 0;
            txtmasp.Text = dssanpham.Rows[row].Cells[0].Value.ToString();
            txttensp.Text = dssanpham.Rows[row].Cells[1].Value.ToString();
            txtmausac.Text = dssanpham.Rows[row].Cells[2].Value.ToString();
            txtloai.Text = dssanpham.Rows[row].Cells[3].Value.ToString();
            txtgiatien.Text = dssanpham.Rows[row].Cells[4].Value.ToString();
            txtsl.Text = dssanpham.Rows[row].Cells[5].Value.ToString();


        }

        private void button8_Click(object sender, EventArgs e)
        {
            string sql_xoa = "delete from Hang where masp ='" + txtmasp.Text + "'";
            ketnoi.ExecuteNonData(sql_xoa);
            LoadData();
            MessageBox.Show("xoa thanh cong");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string sql_sua = "update HANG set tensp='" + txttensp.Text + "',mau ='" + txtmausac.Text + "',lao='" + txtloai.Text + "',gia='" + txtgiatien.Text + "',sl ='"+txtsl.Text+"' where masp='" + txtmasp.Text + "'";
            ketnoi.ExecuteNonData(sql_sua);
            LoadData();
            MessageBox.Show("sua thanh cong");
        }
        
       private void lodakey()
        {
            string con = @"Data Source=DESKTOP-VH30DJO\SQLEXPRESS;Initial Catalog=QuanLy;Integrated Security=True";
            SqlConnection conn = new SqlConnection(con);
            string masp = txtmacantim.Text;
            string sql_tim = ("select *from HANG where masp like '%" + txtmacantim.Text + "%'");
            SqlDataAdapter da = new SqlDataAdapter(sql_tim, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "masp");
            dssanpham.DataSource = ds.Tables["masp"];
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            lodakey();
        }

       

        private void button11_Click(object sender, EventArgs e)
        {
            base.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
