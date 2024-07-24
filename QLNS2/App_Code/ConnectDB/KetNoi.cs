using System;
using System.Data;
using System.Data.SqlClient;

namespace QLNS2
{
    public class ConnectDB
    {
        public class KetNoi
        {
            string ConnectionStr = @"Data Source=HAIANH;Initial Catalog=QLNSChinh;Persist Security Info=True;User ID=ha;Password=1;Encrypt=True;TrustServerCertificate=True";

            public SqlConnection OpenConnection()
            {
                SqlConnection connection = new SqlConnection(ConnectionStr);

                try
                {
                    // Mở kết nối
                    connection.Open();
                    Console.WriteLine("Kết nối thành công!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi kết nối: " + ex.Message);
                }

                return connection;
            }

            // Hàm đóng kết nối
            public void CloseConnection(SqlConnection connection)
            {
                try
                {
                    // Đóng kết nối
                    connection.Close();
                    Console.WriteLine("Đóng kết nối thành công!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi đóng kết nối: " + ex.Message);
                }
            }

            public DataTable ExecuteQuery(string query)
            {
                DataTable dt = new DataTable();

                try
                {
                    using (SqlConnection con = OpenConnection())
                    {
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                da.Fill(dt);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception (e.g., log it)
                    Console.WriteLine("Error executing query: " + ex.Message);
                }

                return dt;
            }
        }
    }
}
