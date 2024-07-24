using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using static QLNS2.ConnectDB;

public partial class NV_TongLuong : System.Web.UI.Page
{
    private KetNoi ketNoi = new KetNoi();

    protected void Page_Load(object sender, EventArgs e)
    {
        string maNhanVienLuong = Session["MaNhanVienLuong"]?.ToString();
        if (string.IsNullOrEmpty(maNhanVienLuong))
        {
            MessageBox("Mã nhân viên không tồn tại!");
            return;
        }

        if (!IsPostBack)
        {
            LoadNgayCongData(maNhanVienLuong);
            LoadLuongData(maNhanVienLuong);
        }
    }

    private void LoadNgayCongData(string maNhanVienLuong)
    {
        try
        {
            using (SqlConnection connection = ketNoi.OpenConnection())
            {
                string sqlQuery = @"SELECT NhanVien.MaNhanVien, NgayCong.CongNgay, NgayCong.GioLamThem,NgayCong.NgayNghi 
                                    FROM NgayCong 
                                    INNER JOIN NhanVien ON NgayCong.IdNhanVien = NhanVien.Id 
                                    WHERE MaNhanVien = @MaNhanVien";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVienLuong);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        GV_NgayCong.DataSource = dataTable;
                        GV_NgayCong.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox(ex.Message);
        }
    }

    private void LoadLuongData(string maNhanVienLuong)
    {
        try
        {
            using (SqlConnection connection = ketNoi.OpenConnection())
            {
                string sqlQuery = @"SELECT MaNhanVien, TongLuong, Thang, Nam 
                                    FROM LuongThang 
                                    WHERE MaNhanVien = @MaNhanVien";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVienLuong);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        GV_Luong.DataSource = dataTable;
                        GV_Luong.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox(ex.Message);
        }
    }

    protected void cbThang_SelectedIndexChanged(object sender, EventArgs e)
    {
        string maNhanVienLuong = Session["MaNhanVienLuong"]?.ToString();
        string thang = cbThang.SelectedValue;

        if (string.IsNullOrEmpty(maNhanVienLuong) || string.IsNullOrEmpty(thang))
        {
            MessageBox("Mã nhân viên hoặc tháng không hợp lệ!");
            return;
        }

        LoadFilteredNgayCongData(maNhanVienLuong, thang);
        LoadFilteredLuongData(maNhanVienLuong, thang);
    }

    private void LoadFilteredNgayCongData(string maNhanVienLuong, string thang)
    {
        try
        {
            using (SqlConnection connection = ketNoi.OpenConnection())
            {
                string sqlQuery = @"SELECT NhanVien.MaNhanVien, NgayCong.CongNgay, NgayCong.GioLamThem, NgayCong.NgayNghi 
                                    FROM NgayCong 
                                    INNER JOIN NhanVien ON NgayCong.IdNhanVien = NhanVien.Id 
                                    WHERE MaNhanVien = @MaNhanVien AND MONTH(NgayCong.CongNgay) = @Thang";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVienLuong);
                    cmd.Parameters.AddWithValue("@Thang", thang);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        GV_NgayCong.DataSource = dataTable;
                        GV_NgayCong.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox(ex.Message);
        }
    }

    private void LoadFilteredLuongData(string maNhanVienLuong, string thang)
    {
        try
        {
            using (SqlConnection connection = ketNoi.OpenConnection())
            {
                string sqlQuery = @"SELECT MaNhanVien, TongLuong, Thang, Nam 
                                    FROM LuongThang 
                                    WHERE MaNhanVien = @MaNhanVien AND Thang = @Thang";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVienLuong);
                    cmd.Parameters.AddWithValue("@Thang", thang);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        GV_Luong.DataSource = dataTable;
                        GV_Luong.DataBind();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox(ex.Message);
        }
    }

    private void MessageBox(string message)
    {
        string script = $"alert('{message}');";
        ScriptManager.RegisterStartupScript(this, GetType(), "MessageBox", script, true);
    }
}
