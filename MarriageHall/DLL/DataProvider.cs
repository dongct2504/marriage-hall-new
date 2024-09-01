using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System;
using System.Linq;

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
            string connectionString = "Data Source=.;Initial Catalog=MarriageHall;User ID=sa; Password=123456aA";
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

        public DataTable GetDataTable(string query, object[] parameter = null)
        {
            Connected();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlCommand command = new SqlCommand(query, conn);

            if (parameter != null)
            {
                string[] listPara = query.Split(' ');
                int i = 0;
                foreach (string item in listPara)
                {
                    if (item.Contains('@'))
                    {
                        string para = item.Replace(",", "").Replace("(", "").Replace(")", "");
                        command.Parameters.AddWithValue(para, parameter[i]);
                        i++;
                    }
                }
            }

            da = new SqlDataAdapter(command);
            dt = new DataTable();
            da.Fill(dt);

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return dt;
        }

        public bool RunQuery(string query, object[] parameter = null)
        {
            int data = 0;

            try
            {
                Connected();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand command = new SqlCommand(query, conn);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            string para = item.Replace(",", "").Replace("(", "").Replace(")", "");
                            command.Parameters.AddWithValue(para, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi: " + ex.Message, "Thong bao");
            }

            return data > 0;
        }
    }
}
