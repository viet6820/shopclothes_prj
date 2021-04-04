using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlbanhang
{
    class ketnoi
    {
        public static String ConnectString = @"Data Source=DESKTOP-VH30DJO\SQLEXPRESS;Initial Catalog=QuanLy;Integrated Security=True";
        public static DataTable ExecuteDataTable_SQL(string sql)
        {
            using (SqlConnection con = new SqlConnection(ConnectString))
            {
                using (SqlDataAdapter dad = new SqlDataAdapter(sql, con))
                {
                    using (DataSet dst = new DataSet())
                    {
                        dad.Fill(dst);
                        return dst.Tables[0];
                    }
                }
            }
        }
        //Dung de xoa va update
        public static void ExecuteNonQuery_Pro(string sql, params object[] pars)
        {
            using (SqlConnection con = new SqlConnection(ConnectString))
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {

                    for (int i = 0; i < pars.Length; i += 2)
                    {
                        SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                        com.Parameters.Add(par);
                    }
                    com.ExecuteNonQuery();
                    com.Dispose();
                }
                con.Close();
                con.Dispose();
            }
        }



        //dung de intsert data
        public static void ExecuteNonData(string sql)
        {
            using (SqlConnection con = new SqlConnection(ConnectString))
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();
                using (SqlCommand comn = new SqlCommand(sql, con))
                {
                    comn.ExecuteNonQuery();
                    comn.Dispose();
                }
                con.Close();
                con.Dispose();
            }
        }

    }
}

