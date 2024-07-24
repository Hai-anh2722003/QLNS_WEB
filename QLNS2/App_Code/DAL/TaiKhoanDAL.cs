using QLNS2;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TaiKhoanDAL
/// </summary>
public class TaiKhoanDAL
{
    SqlConnection connection = null;
    SqlDataReader reader = null;
    SqlCommand cmd = null;
    SqlDataAdapter adapter = null;
    ConnectDB.KetNoi kn = new ConnectDB.KetNoi();
    public string SearchTaiKhoan(string MNV)
    {
        string TenNhanVien = ""; // Khởi tạo biến TenNhanVien trước khi sử dụng
        try
        {
            using (SqlConnection connection = kn.OpenConnection())
            {
                string query = "SELECT Users.HoTen\r\n\t\t\t\t\t\tFROM Users\r\n\t\t\t\t\t\tJOIN NhanVien ON Users.Id=NhanVien.IdUser\r\n\t\t\t\t\t\tWHERE NhanVien.MaNhanVien  LIKE @MaNhanVien;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaNhanVien", "%" + MNV + "%");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TenNhanVien = reader.GetString(reader.GetOrdinal("HoTen"));
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khi đọc dữ liệu từ cơ sở dữ liệu: " + ex.Message);
            throw new Exception("Error SearchTK: " + ex.Message, ex); return null;
        }
        return TenNhanVien;
    }

    public void ThemTaiKhoan(string MNV, string MatKhau, string IdRole)
    {
        int IdUser = 0;

        //Lay User
        try
        {
            using (SqlConnection connection = kn.OpenConnection())
            {
                string query = "SELECT NhanVien.IdUser FROM NhanVien WHERE NhanVien.MaNhanVien = @MaNhanVien;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaNhanVien", MNV);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            IdUser = reader.GetInt32(reader.GetOrdinal("IdUser"));
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khi đọc dữ liệu từ cơ sở dữ liệu: " + ex.Message);
            throw new Exception("Error in ThemTK: " + ex.Message, ex);
        }

        //Them tai khoan
        try
        {
            using (SqlConnection connection = kn.OpenConnection())
            {
                string query = "INSERT INTO Role_User(IdRole,IdUser)VALUES (@IdRole,@IdUser);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdUser", IdUser);
                    command.Parameters.AddWithValue("@IdRole", IdRole);

                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khi đọc dữ liệu từ cơ sở dữ liệu: " + ex.Message);
            throw new Exception("Error in SerchTenNhanVien: " + ex.Message, ex);
        }
        //ThemMatKhau

        try
        {
            using (SqlConnection connection = kn.OpenConnection())
            {
                string query = "UPDATE Users SET MatKhau = @MatKhau WHERE Id = @IdUser;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdUser", IdUser);
                    command.Parameters.AddWithValue("@MatKhau", MatKhau);

                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khi đọc dữ liệu từ cơ sở dữ liệu: " + ex.Message);
            throw new Exception("Error in SerchTenNhanVien: " + ex.Message, ex);
        }



    }

    public List<TaiKhoanDTO> GetTkList()
    {
        List<TaiKhoanDTO> TKList = new List<TaiKhoanDTO>();

        try
        {
            using (SqlConnection connection = kn.OpenConnection())
            {
                string query = "SELECT NhanVien.MaNhanVien,Role_User.Id AS IdUserRole, Users.HoTen,Users.Id AS IdUser ,Users.MatKhau ,Role.Role FROM Users JOIN Role_User ON Role_User.IdUser = Users.Id JOIN Role ON Role_User.IdRole = Role.Id JOIN NhanVien ON NhanVien.IdUser = Users.Id WHERE Role_User.Status = '1';";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TaiKhoanDTO taiKhoanDTO = new TaiKhoanDTO()
                            {
                                IdUser = reader.GetInt32(reader.GetOrdinal("IdUser")),
                                MaNhanVien = reader.GetString(reader.GetOrdinal("MaNhanVien")),
                                MatKhau = reader.GetString(reader.GetOrdinal("MatKhau")),
                                HoTen = reader.GetString(reader.GetOrdinal("HoTen")),
                                Role = reader.GetString(reader.GetOrdinal("Role")),
                                IdUserRole = reader.GetInt32(reader.GetOrdinal("IdUserRole"))

                            };

                            TKList.Add(taiKhoanDTO);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khi đọc dữ liệu từ cơ sở dữ liệu: " + ex.Message);
            throw new Exception("Error in GetTklist: " + ex.Message, ex); return null;
            return null;
        }

        return TKList;
    }

    public void SuaTK(string IdUser, string MatKhau, string IdUserRole, string IdRole)
    {
        try
        {
            using (connection = kn.OpenConnection())
            {
                string query = "UPDATE Users SET MatKhau=@MatKhau WHERE Users.Id=@IdUser";
                using (cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MatKhau", MatKhau);
                    cmd.Parameters.AddWithValue("@IdUser", IdUser);


                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khi đọc dữ liệu từ cơ sở dữ liệu: " + ex.Message);
            throw new Exception("Error in SerchTenNhanVien: " + ex.Message, ex);
        }

        //Sua userRole
        try
        {
            using (connection = kn.OpenConnection())
            {
                string query = "UPDATE Role_User SET IdRole=@IdRole WHERE Role_User.Id=@IdUserRole";
                using (cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@IdRole", IdRole);
                    cmd.Parameters.AddWithValue("@IdUserRole", IdUserRole);


                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khi đọc dữ liệu từ cơ sở dữ liệu: " + ex.Message);
            throw new Exception("Error in SerchTenNhanVien: " + ex.Message, ex);
        }

    }
    //Xoa TaiKhoan
    public void XoaTK(string IdUserRole)
    {
        try
        {
            using (connection = kn.OpenConnection())
            {
                string query = "UPDATE Role_User SET Status='0' WHERE Role_User.Id=@IdUserRole";
                using (cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@IdUserRole", IdUserRole);


                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khi đọc dữ liệu từ cơ sở dữ liệu: " + ex.Message);
            throw new Exception("Error in Xoatk: " + ex.Message, ex);
        }



    }
}
