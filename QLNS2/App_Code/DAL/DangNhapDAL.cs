using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;

namespace QLNS2.DAL
{
    public class DangNhapDAL
    {
        private ConnectDB.KetNoi kn = new ConnectDB.KetNoi();

        public object DangNhap(string MaNhanVien, string MatKhau)
        {
            try
            {
                using (SqlConnection conn = kn.OpenConnection())
                {
                    string query = "SELECT Users.Id, Role_User.IdRole, NhanVien.MaNhanVien, Users.MatKhau From Users " +
                                    "JOIN Role_User ON Users.Id = Role_User.IdUser " +
                                    "JOIN NhanVien ON NhanVien.IdUser = Users.Id " +
                                    "WHERE MaNhanVien = @MaNhanVien AND MatKhau = @MatKhau AND NhanVien.Status=1";

                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                    command.Parameters.AddWithValue("@MatKhau", MatKhau);
                    object result = command.ExecuteScalar(); // Lấy IdRole từ câu lệnh SQL

                    return result; // Trả về kết quả của truy vấn
                }
            }
            catch (Exception ex)
            {
                // Xử lý exception nếu có
                Console.WriteLine("Lỗi khi đọc dữ liệu từ cơ sở dữ liệu: " + ex.Message);
                return null; // Trả về null trong trường hợp xử lý lỗi
            }
        }

        public List<string> GetUserRoles(string MaNhanVien, string MatKhau)
        {
            List<string> userRoles = new List<string>();

            try
            {
                using (SqlConnection conn = kn.OpenConnection())
                {
                    string query = "SELECT Role.Role, Users.HoTen, Users.Id, NhanVien.MaNhanVien FROM Users " +
                                    "JOIN Role_User ON Users.Id = Role_User.IdUser " +
                                    "JOIN NhanVien ON NhanVien.IdUser = Users.Id " +
                                    "JOIN Role ON Role_User.IdRole = Role.Id " +
                                    "WHERE MaNhanVien = @MaNhanVien AND MatKhau = @MatKhau AND NhanVien.Status=1";

                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                    command.Parameters.AddWithValue("@MatKhau", MatKhau);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string role = reader.GetString(reader.GetOrdinal("Role"));
                            userRoles.Add(role);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi đọc dữ liệu từ cơ sở dữ liệu: " + ex.Message);
                string script = $"alert('{ex.Message}');";
                HttpContext.Current.Response.Write("<script>" + script + "</script>");
            }

            return userRoles;
        }

        public object ExecuteScalar(string sql)
        {
            try
            {
                using (SqlConnection conn = kn.OpenConnection())
                {
                    SqlCommand command = new SqlCommand(sql, conn);
                    object kq = command.ExecuteScalar();
                    return kq != null ? kq.ToString() : ""; // Trả về kết quả của truy vấn hoặc chuỗi rỗng nếu không có kết quả
                }
            }
            catch (Exception ex)
            {
                // Xử lý exception nếu có
                Console.WriteLine("Lỗi khi thực hiện truy vấn: " + ex.Message);
                return null; // Trả về null trong trường hợp xử lý lỗi
            }
        }
    }
}
