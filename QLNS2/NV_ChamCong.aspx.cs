using Irony;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using static QLNS2.ConnectDB;

public partial class NV_ChamCong : System.Web.UI.Page
{
    private KetNoi ketNoi = new KetNoi();

    int idNhanVien;

    DateTime ngay;
    TimeSpan gioVao;
    TimeSpan gioRa;


    protected void btnChamCong_Click(object sender, EventArgs e)
    {
        string maNhanVienChamCong = Session["MaNhanVienChamCong"]?.ToString();
        if (string.IsNullOrEmpty(maNhanVienChamCong))
        {
            Response.Write("<script>alert('Mã nhân viên không tồn tại!');</script>");
            return;
        }

        string ngayText = txtNgay.Text;
        string gioVaoText = txtGioVao.Text;
        string gioRaText = txtGioRa.Text;

        if (!DateTime.TryParse(ngayText, out DateTime ngay))
        {
            Response.Write("<script>alert('Ngày không hợp lệ!');</script>");
            return;
        }

        if (!TimeSpan.TryParse(gioVaoText, out TimeSpan gioVao))
        {
            if (!Regex.IsMatch(gioVaoText, @"^(\d{1,2}):(\d{1,2}):(\d{1,2})(\.(\d{1,3}))?$"))
            {
                Response.Write("<script>alert('Giờ vào không hợp lệ!');</script>");
                return;
            }
            else
            {
                // Try to parse the input string again
                if (!TimeSpan.TryParse(gioVaoText, out gioVao))
                {
                    Response.Write("<script>alert('Giờ vào không hợp lệ!');</script>");
                    return;
                }
            }
        }
        if (!TimeSpan.TryParse(gioRaText, out TimeSpan gioRa))
        {
            if (!Regex.IsMatch(gioRaText, @"^(\d{1,2}):(\d{1,2}):(\d{1,2})(\.(\d{1,3}))?$"))
            {
                Response.Write("<script>alert('Giờ ra không hợp lệ!');</script>");
                return;
            }
            else
            {
                // Try to parse the input string again
                if (!TimeSpan.TryParse(gioRaText, out gioRa))
                {
                    Response.Write("<script>alert('Giờ ra không hợp lệ!');</script>");
                    return;
                }
            }
        }

        

        DateTime Vao = ngay + gioVao;
        DateTime Ra = ngay + gioRa;

        string gioVao1 = Vao.ToString("yyyy-MM-dd HH:mm:ss.fff");
        string gioRa1 = Ra.ToString("yyyy-MM-dd HH:mm:ss.fff");

        try
        {
            using (SqlConnection connection = ketNoi.OpenConnection())
            {
                using (SqlCommand command = new SqlCommand("SELECT Id FROM NhanVien WHERE MaNhanVien = @maNhanVien", connection))
                {
                    command.Parameters.AddWithValue("@maNhanVien", maNhanVienChamCong);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            idNhanVien = reader.GetInt32(0);
                        }
                        else
                        {
                            throw new Exception("Không tìm thấy nhân viên với mã: " + maNhanVienChamCong);
                        }
                    }
                }

                using (SqlCommand command = new SqlCommand("INSERT INTO ChamCong (GioVao, GioRa,IdNhanVien) VALUES (@gioVao, @gioRa, @IDNV)", connection))
                {
                    command.Parameters.AddWithValue("@gioVao", gioVao1);
                    command.Parameters.AddWithValue("@gioRa", gioRa1);
                    command.Parameters.AddWithValue("@IDNV", idNhanVien);

                    command.ExecuteNonQuery();
                }

                TimeSpan duration = Ra - Vao;
                int hoursWorked = (int)duration.TotalHours;
                int overtime = Math.Max(0, hoursWorked - 8);

                string congNgay = hoursWorked >= 8 ? Vao.ToString("yyyy-MM-dd") : null;

                using (SqlCommand command = new SqlCommand("INSERT INTO NgayCong (IdNhanVien, CongNgay, GioLamThem) VALUES (@IDNV, @CongNgay, @GioLamThem)", connection))
                {
                    command.Parameters.AddWithValue("@IDNV", idNhanVien);
                    command.Parameters.AddWithValue("@CongNgay", congNgay != null ? (object)congNgay : DBNull.Value);
                    command.Parameters.AddWithValue("@GioLamThem", overtime);

                    command.ExecuteNonQuery();
                }
            }

            Response.Write("<script>alert('Chấm công thành công!');</script>");
            
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Lỗi: " + ex.Message + "');</script>");
        }

    }




protected void Button1_Click(object sender, EventArgs e)
{
    string maNhanVienChamCong = Session["MaNhanVienChamCong"]?.ToString();
    string Ngaynghi = Nghi.Text;

        if (!DateTime.TryParse(Ngaynghi, out DateTime ngayn))
        {
            Response.Write("<script>alert('Ngày không hợp lệ!');</script>");
            return;
        }
        string nghi = ngayn.ToString("yyyy-MM-dd");
        try
        {
            using (SqlConnection connection = ketNoi.OpenConnection())
            {
                using (SqlCommand command = new SqlCommand("SELECT Id FROM NhanVien WHERE MaNhanVien = @maNhanVien", connection))
                {
                    command.Parameters.AddWithValue("@maNhanVien", maNhanVienChamCong);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            idNhanVien = reader.GetInt32(0);
                        }
                        else
                        {
                            throw new Exception("Không tìm thấy nhân viên với mã: " + maNhanVienChamCong);
                        }
                    }
                }
                using (SqlCommand command = new SqlCommand("INSERT INTO NgayCong (IdNhanVien, NgayNghi) VALUES (@IDNV, @NgayNghi)", connection))
                {
                    command.Parameters.AddWithValue("@IDNV", idNhanVien);
                    command.Parameters.AddWithValue("@NgayNghi", nghi);

                    command.ExecuteNonQuery();
                }
            }
            // Hiển thị thông báo thành công
            ClientScript.RegisterStartupScript(this.GetType(), "msgbxSuccess", "alert('Thành công!');", true);
        }
        catch (Exception ex)
        {
            // Handle the exception
            ClientScript.RegisterStartupScript(this.GetType(), "msgbxError", "alert('Lỗi: " + ex.Message + "');", true);
        }
    }
}

