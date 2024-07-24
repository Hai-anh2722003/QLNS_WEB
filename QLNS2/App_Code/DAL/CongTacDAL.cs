using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using QLNS2.DTO;
using System.Web;

namespace QLNS2.DAL
{
    public class CongTacDAL
    {
        private ConnectDB.KetNoi Kn = new ConnectDB.KetNoi();

        public List<CongTacDTO> LayCongTac()
        {
            List<CongTacDTO> CongTacList = new List<CongTacDTO>();

            try
            {
                using (SqlConnection ketnoi = Kn.OpenConnection())
                {
                    string query = "SELECT * FROM CongTac WHERE Status = 1;";
                    using (SqlCommand cmd = new SqlCommand(query, ketnoi))
                    {
                        using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                CongTacDTO CD = new CongTacDTO()
                                {
                                    Id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Id")),
                                    TenCongTac = sqlDataReader.GetString(sqlDataReader.GetOrdinal("TenCongTac")),
                                };
                                CongTacList.Add(CD);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (logging, etc.)
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            return CongTacList;
        }

        public bool ThemCongTac(string TenCongTac, out string message)
        {
            try
            {
                using (SqlConnection ketnoi = Kn.OpenConnection())
                {
                    string query = "INSERT INTO CongTac (TenCongTac) VALUES (@TenCongTac);";
                    using (SqlCommand command = new SqlCommand(query, ketnoi))
                    {
                        command.Parameters.AddWithValue("@TenCongTac", TenCongTac);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            message = "Thêm công tác thành công.";
                            return true;
                        }
                        else
                        {
                            message = "Thêm công tác không thành công.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi thêm công tác: " + ex.Message;
                return false;
            }
        }

        public bool SuaCongTac(int Id, string TenCongTac, out string message)
        {
            try
            {
                using (SqlConnection ketnoi = Kn.OpenConnection())
                {
                    string query = "UPDATE CongTac SET TenCongTac = @TenCongTac WHERE Id = @Id;";
                    using (SqlCommand command = new SqlCommand(query, ketnoi))
                    {
                        command.Parameters.AddWithValue("@Id", Id);
                        command.Parameters.AddWithValue("@TenCongTac", TenCongTac);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            message = "Sửa công tác thành công!";
                            return true;
                        }
                        else
                        {
                            message = "Sửa công tác không thành công!";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi sửa công tác: " + ex.Message;
                return false;
            }
        }

        public bool XoaCongTac(int Id, out string message)
        {
            try
            {
                using (SqlConnection ketnoi = Kn.OpenConnection())
                {
                    string query = "UPDATE CongTac SET Status = @Status WHERE Id = @Id;";
                    using (SqlCommand command = new SqlCommand(query, ketnoi))
                    {
                        command.Parameters.AddWithValue("@Id", Id);
                        command.Parameters.AddWithValue("@Status", 0);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            message = "Xóa công tác thành công.";
                            return true;
                        }
                        else
                        {
                            message = "Xóa công tác không thành công.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi xóa công tác: " + ex.Message;
                return false;
            }
        }
    }
}
