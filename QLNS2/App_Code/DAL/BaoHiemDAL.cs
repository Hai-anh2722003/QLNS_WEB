using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using QLNS2.DTO;
using System.Web;

namespace QLNS2.DAL
{
    public class BaoHiemDAL
    {
        private readonly ConnectDB.KetNoi Kn = new ConnectDB.KetNoi();

        public List<BaoHiemDTO> LayBaoHiem()
        {
            List<BaoHiemDTO> BaoHiemList = new List<BaoHiemDTO>();

            try
            {
                using (SqlConnection ketnoi = Kn.OpenConnection())
                {
                    string query = "SELECT * FROM BaoHiem WHERE Status = 1;";
                    using (SqlCommand cmd = new SqlCommand(query, ketnoi))
                    {
                        using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                BaoHiemDTO BH = new BaoHiemDTO()
                                {
                                    Id = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("Id")) ? 0 : sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Id")),
                                    NgayCap = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("NgayCap")) ? DateTime.MinValue : sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("NgayCap")),
                                    NoiCap = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("NoiCap")) ? string.Empty : sqlDataReader.GetString(sqlDataReader.GetOrdinal("NoiCap")),
                                    GhiChu = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("GhiChu")) ? string.Empty : sqlDataReader.GetString(sqlDataReader.GetOrdinal("GhiChu")),
                                    IdNhanVien = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("IdNhanVien")) ? 0 : sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("IdNhanVien")),
                                    TienBaoHiem = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("TienBaoHiem")) ? 0 : sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("TienBaoHiem"))
                                };
                                BaoHiemList.Add(BH);
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

            return BaoHiemList;
        }

        public bool ThemBaoHiem(string NgayCap, string NoiCap, string GhiChu, int TienBaoHiem, int IdNhanVien, out string message)
        {
            try
            {
                using (SqlConnection ketnoi = Kn.OpenConnection())
                {
                    string query = "INSERT INTO BaoHiem (NgayCap, NoiCap, GhiChu, TienBaoHiem, IdNhanVien) " +
                                   "VALUES (@NgayCap, @NoiCap, @GhiChu, @TienBaoHiem, @IdNhanVien);";
                    using (SqlCommand cmd = new SqlCommand(query, ketnoi))
                    {
                        cmd.Parameters.AddWithValue("@NgayCap", NgayCap);
                        cmd.Parameters.AddWithValue("@NoiCap", NoiCap);
                        cmd.Parameters.AddWithValue("@GhiChu", GhiChu);
                        cmd.Parameters.AddWithValue("@TienBaoHiem", TienBaoHiem);
                        cmd.Parameters.AddWithValue("@IdNhanVien", IdNhanVien);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            message = "Thêm bảo hiểm thành công.";
                            return true;
                        }
                        else
                        {
                            message = "Thêm bảo hiểm không thành công.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi thêm bảo hiểm: " + ex.Message;
                return false;
            }
        }

        public bool SuaBaoHiem(int Id, string NgayCap, string NoiCap, string GhiChu, int TienBaoHiem, int IdNhanVien, out string message)
        {
            try
            {
                using (SqlConnection ketnoi = Kn.OpenConnection())
                {
                    string query = "UPDATE BaoHiem SET NgayCap=@NgayCap, NoiCap=@NoiCap, GhiChu=@GhiChu, TienBaoHiem=@TienBaoHiem, IdNhanVien=@IdNhanVien WHERE Id=@Id;";
                    using (SqlCommand cmd = new SqlCommand(query, ketnoi))
                    {
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@NgayCap", NgayCap);
                        cmd.Parameters.AddWithValue("@NoiCap", NoiCap);
                        cmd.Parameters.AddWithValue("@GhiChu", GhiChu);
                        cmd.Parameters.AddWithValue("@TienBaoHiem", TienBaoHiem);
                        cmd.Parameters.AddWithValue("@IdNhanVien", IdNhanVien);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            message = "Sửa bảo hiểm thành công.";
                            return true;
                        }
                        else
                        {
                            message = "Sửa bảo hiểm không thành công.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi sửa bảo hiểm: " + ex.Message;
                return false;
            }
        }

        public bool XoaBaoHiem(int Id, out string message)
        {
            try
            {
                using (SqlConnection ketnoi = Kn.OpenConnection())
                {
                    string query = "UPDATE BaoHiem SET Status = @Status WHERE Id = @Id;";
                    using (SqlCommand cmd = new SqlCommand(query, ketnoi))
                    {
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@Status", 0);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            message = "Xóa bảo hiểm thành công.";
                            return true;
                        }
                        else
                        {
                            message = "Xóa bảo hiểm không thành công.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi khi xóa bảo hiểm: " + ex.Message;
                return false;
            }
        }
    }
}
