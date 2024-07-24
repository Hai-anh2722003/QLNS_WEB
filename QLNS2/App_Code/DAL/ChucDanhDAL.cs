using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using QLNS2.DTO;
using System.Web;

namespace QLNS2.DAL
{
    public class ChucDanhDAL
    {
        private ConnectDB.KetNoi Kn = new ConnectDB.KetNoi();

        public List<ChucDanhDTO> LayChucDanh()
        {
            List<ChucDanhDTO> ChucDanhList = new List<ChucDanhDTO>();

            using (SqlConnection ketnoi = Kn.OpenConnection())
            {
                string query = "SELECT * FROM ChucDanh WHERE Status = 1;";
                using (SqlCommand cmd = new SqlCommand(query, ketnoi))
                {
                    using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            ChucDanhDTO CD = new ChucDanhDTO
                            {
                                Id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Id")),
                                TenChucDanh = sqlDataReader.GetString(sqlDataReader.GetOrdinal("TenChucDanh"))
                            };
                            ChucDanhList.Add(CD);
                        }
                    }
                }
            }
            return ChucDanhList;
        }

        public bool ThemChucDanh(string TenChucDanh, out string message)
        {
            try
            {
                using (SqlConnection ketnoi = Kn.OpenConnection())
                {
                    string query = "INSERT INTO ChucDanh (TenChucDanh) VALUES (@TenChucDanh);";
                    using (SqlCommand command = new SqlCommand(query, ketnoi))
                    {
                        command.Parameters.AddWithValue("@TenChucDanh", TenChucDanh);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            message = "Thêm chức danh thành công.";
                            return true;
                        }
                        else
                        {
                            message = "Thêm chức danh không thành công.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi: " + ex.Message;
                return false;
            }
        }

        public bool SuaChucDanh(int Id, string TenChucDanh, out string message)
        {
            try
            {
                using (SqlConnection ketnoi = Kn.OpenConnection())
                {
                    string query = "UPDATE ChucDanh SET TenChucDanh = @TenChucDanh WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(query, ketnoi))
                    {
                        command.Parameters.AddWithValue("@Id", Id);
                        command.Parameters.AddWithValue("@TenChucDanh", TenChucDanh);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Sửa thông tin chức danh thành công!";
                            return true;
                        }
                        else
                        {
                            message = "Sửa thông tin chức danh không thành công!";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi: " + ex.Message;
                return false;
            }
        }

        public bool XoaChucDanh(int id, out string message)
        {
            try
            {
                using (SqlConnection ketnoi = Kn.OpenConnection())
                {
                    string query = "UPDATE ChucDanh SET Status = @Status WHERE Id = @Id;";
                    using (SqlCommand command = new SqlCommand(query, ketnoi))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@Status", 0);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            message = "Xóa chức danh thành công.";
                            return true;
                        }
                        else
                        {
                            message = "Xóa chức danh không thành công.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi: " + ex.Message;
                return false;
            }
        }

        public bool ThemChucDanh(string tenChucDanh)
        {
            throw new NotImplementedException();
        }
    }
}
