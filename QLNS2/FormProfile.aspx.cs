using System;
using System.Data.SqlClient;
using System.Web.UI;
using QLNS2.DTO;
using static QLNS2.ConnectDB;

public partial class FormProfile : System.Web.UI.Page
{
    private KetNoi ketNoi = new KetNoi();
    SqlConnection connection = null;
    SqlDataReader reader = null;
    SqlCommand cmd = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MaNhanVien"] != null)
        {
            string maNhanVien = Session["MaNhanVien"].ToString();
        }
        else
        {
            Response.Write("<script>alert('Mã nhân viên không tồn tại!');</script>");
            return;
        }

        // Lưu mã nhân viên vào session khác
        if (!IsPostBack)
        {
            if (Session["MaNhanVien"] != null)
            {
                txtMaNhanVien.Text = Session["MaNhanVien"].ToString();
                String ma = txtMaNhanVien.Text;

                try
                {
                    using (SqlConnection connection = ketNoi.OpenConnection())
                    {
                        string sqlQuery = "SELECT Users.HoTen, Users.GioiTinh, Users.NgaySinh, Users.Email, Users.HocVan, " +
                                          "Users.DangVien, Users.CMND, Users.DiaChi, CongTac.TenCongTac, ChucDanh.TenChucDanh, " +
                                          "HopDong.NgayBatDau, Users.DuongDan, HopDong.LoaiHopDong, TienLuong.LuongCong " +
                                          "FROM NhanVien " +
                                          "JOIN Users ON NhanVien.IdUser = Users.Id " +
                                          "JOIN CongTac ON NhanVien.IdCongTac = CongTac.Id " +
                                          "JOIN ChucDanh ON NhanVien.IdChucDanh = ChucDanh.Id " +
                                          "JOIN HopDong ON NhanVien.IdHopDong = HopDong.Id " +
                                          "JOIN TienLuong ON NhanVien.IdTienLuong = TienLuong.Id " +
                                          "WHERE MaNhanVien = @MaNhanVien";


                        using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@MaNhanVien", ma);

                            // Execute the query and read data
                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {
                                // Read data from columns
                                txtHoTen.Text = reader["HoTen"].ToString();
                                txtGioiTinh.Text = reader["GioiTinh"].ToString();

                                // Format the date to display only the date part
                                DateTime ngaySinh;
                                if (DateTime.TryParse(reader["NgaySinh"].ToString(), out ngaySinh))
                                {
                                    txtNS.Text = ngaySinh.ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    txtNS.Text = reader["NgaySinh"].ToString();
                                }

                                // Format the start date to display only the date part
                                DateTime ngayBatDau;
                                if (DateTime.TryParse(reader["NgayBatDau"].ToString(), out ngayBatDau))
                                {
                                    txtBatDau.Text = ngayBatDau.ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    txtBatDau.Text = reader["NgayBatDau"].ToString();
                                }

                                txtEmail.Text = reader["Email"].ToString();
                                txtHocVan.Text = reader["HocVan"].ToString();
                                txtDangVien.Text = reader["DangVien"].ToString();
                                txtCMND.Text = reader["CMND"].ToString();
                                txtDiaChi.Text = reader["DiaChi"].ToString();
                                txtCongTac.Text = reader["TenCongTac"].ToString();
                                txtCD.Text = reader["TenChucDanh"].ToString();
                                txtHĐ.Text = reader["LoaiHopDong"].ToString();
                                txtLuong.Text = reader["LuongCong"].ToString();
                            }
                            else
                            {
                                MessageBox("Không tìm thấy thông tin nhân viên!");
                            }

                            // Close the reader after use
                            reader.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox(ex.Message);
                }
            }
            else
            {
                MessageBox("Bạn cần đăng nhập trước!");
                Response.Redirect("Dangnhap.aspx");
            }
        }
    }

    private void MessageBox(string message)
    {
        string script = $"alert('{message}')";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "MessageBox", script, true);
    }
}
