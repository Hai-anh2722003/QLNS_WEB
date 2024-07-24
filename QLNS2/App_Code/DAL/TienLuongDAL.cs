using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using QLNS2.DTO; // Ensure you have imported DTO namespace
using System.Web;

namespace QLNS2.DAL
{
    public class TienLuongDAL
    {
        SqlConnection connection = null;
        SqlDataReader reader = null;
        SqlCommand cmd = null;
        SqlDataAdapter adapter = null;
        ConnectDB.KetNoi kn = new ConnectDB.KetNoi();

        public List<DTO.TienLuongDTO> LayTienLuong()
        {
            List<DTO.TienLuongDTO> TienLuongList = new List<DTO.TienLuongDTO>();

            try
            {
                using (SqlConnection connection = kn.OpenConnection())
                {
                    string query =
                        "SELECT * FROM TienLuong " +
                        "WHERE TienLuong.Status = 1;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DTO.TienLuongDTO TienLuong = new DTO.TienLuongDTO()
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    BacLuong = reader.GetInt32(reader.GetOrdinal("BacLuong")),
                                    HeSo = reader.GetInt32(reader.GetOrdinal("HeSo")),
                                    PhuCap = reader.GetInt32(reader.GetOrdinal("PhuCap")),
                                    LuongCong = reader.GetInt32(reader.GetOrdinal("LuongCong")),
                                    GhiChu = reader.GetString(reader.GetOrdinal("GhiChu")),
                                };

                                TienLuongList.Add(TienLuong);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi đọc dữ liệu từ cơ sở dữ liệu: " + ex.Message);
                string script = $"alert('List bảng lương sai: {ex.Message}');";
                HttpContext.Current.Response.Write("<script>" + script + "</script>");
                return null;
            }

            return TienLuongList;
        }

        // Add Lương
        public int AddTL(string BacLuong, string HeSo, string PhuCap, string LuongCong, string GhiChu)
        {
            try
            {
                using (connection = kn.OpenConnection())
                {
                    string query = "INSERT INTO TienLuong(BacLuong, HeSo, PhuCap, LuongCong, GhiChu) " +
                                   "VALUES (@BacLuong, @HeSo, @PhuCap, @LuongCong, @GhiChu);";

                    using (cmd = new SqlCommand(query, connection))
                    {
                        // Add parameters and assign real values
                        cmd.Parameters.AddWithValue("@BacLuong", BacLuong);
                        cmd.Parameters.AddWithValue("@HeSo", HeSo);
                        cmd.Parameters.AddWithValue("@PhuCap", PhuCap);
                        cmd.Parameters.AddWithValue("@LuongCong", LuongCong);
                        cmd.Parameters.AddWithValue("@GhiChu", GhiChu);

                        // Execute the SQL command and return the number of rows affected
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Return the number of affected rows (usually the number of added rows)
                        return rowsAffected;
                    }
                }
            }
            catch (Exception ex)
            {
                string script = $"alert('Lỗi khi thêm bảng lương: {ex.Message}');";
                HttpContext.Current.Response.Write("<script>" + script + "</script>");
                return -1; // Return -1 if an error occurs
            }
        }

        public int SuaTL(int Id, string BacLuong, string HeSo, string PhuCap, string LuongCong, string GhiChu)
        {
            try
            {
                string query = "UPDATE TienLuong SET BacLuong = @BacLuong, HeSo = @HeSo, PhuCap = @PhuCap, LuongCong = @LuongCong, GhiChu = @GhiChu WHERE Id = @Id;";
                using (SqlConnection connection = kn.OpenConnection())
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Add parameters and assign real values
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@BacLuong", BacLuong);
                    cmd.Parameters.AddWithValue("@HeSo", HeSo);
                    cmd.Parameters.AddWithValue("@PhuCap", PhuCap);
                    cmd.Parameters.AddWithValue("@LuongCong", LuongCong);
                    cmd.Parameters.AddWithValue("@GhiChu", GhiChu);

                    // Return the number of updated rows
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                string script = $"alert('Lỗi khi sửa bảng lương: {ex.Message}');";
                HttpContext.Current.Response.Write("<script>" + script + "</script>");
                return -1; // Return -1 if an error occurs
            }
        }

        public int XoaTL(int Id)
        {
            try
            {
                string query = "DELETE FROM TienLuong WHERE Id = @Id";
                using (SqlConnection connection = kn.OpenConnection())
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    return cmd.ExecuteNonQuery(); // Return the number of deleted rows
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa bậc lương: " + ex.Message);
                return -1; // Return -1 if an error occurs
            }
        }
    }
}
