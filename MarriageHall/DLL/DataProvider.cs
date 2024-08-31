using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System;

namespace MarriageHall.DLL
{
    public class DataProvider
    {
        private SqlDataAdapter da;
        private SqlConnection conn;
        private DataTable dt;

        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        private void Connected()
        {
            string connectionString = "Data Source=.;Initial Catalog=Demo;User ID=sa; Password=123456aA";
            try
            {
                if (conn == null)
                {
                    conn = new SqlConnection(connectionString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
        }

        public DataTable GetDataTable(string query)
        {
            Connected();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            da = new SqlDataAdapter(query, conn);
            dt = new DataTable();
            da.Fill(dt);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return dt;
        }

        public bool RunQuery(string query)
        {
            int check = 0;
            try
            {
                Connected();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand command = new SqlCommand(query, conn);
                check = command.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
            return check > 0;
        }
    }
}
