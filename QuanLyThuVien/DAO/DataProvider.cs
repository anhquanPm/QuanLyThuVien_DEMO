using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyThuVien.DAO
{
    class DataProvider
    {
        static string provider = @"Data Source=ANHQUAN;Initial Catalog=QLThuVien;Integrated Security=True";
        SqlConnection connect = new SqlConnection(provider);

        public DataTable GetData(string sql)
        {
            DataTable rs = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connect);
            adapter.Fill(rs);
            return rs;
        }
        //public void Excute(string sql)
        //{
        //    connect.Open();
        //    SqlCommand command = new SqlCommand(sql, connect);
        //    command.ExecuteNonQuery();
        //    connect.Close();
        //}

        public void Excute(string sql)
        {
            try
            {
                connect.Open();
                SqlCommand command = new SqlCommand(sql, connect);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Handle the exception, log, or rethrow if needed
                throw;
            }
            finally
            {
                // Ensure the connection is closed, whether there was an exception or not
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }

    }
}
