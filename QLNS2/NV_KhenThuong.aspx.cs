using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static QLNS2.ConnectDB;
using System.Data;


public partial class NV_KhenThuong : System.Web.UI.Page
{
    private KetNoi ketNoi = new KetNoi();
    SqlConnection connection = null;
    SqlDataReader reader = null;
    SqlCommand cmd = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        string maNhanVienKhenThuong = Session["MaNhanVienKhenThuong"]?.ToString();
        if (string.IsNullOrEmpty(maNhanVienKhenThuong))
        {
            Response.Write("<script>alert('Mã nhân viên không tồn tại!');</script>");
            return;
        }
        try
        {
            using (SqlConnection connection = ketNoi.OpenConnection())
            {
                string sqlQuery = "SELECT NhanVien.MaNhanVien, KhenThuong.Id, KhenThuong.KhenThuong,KhenThuong.Tien " +
                                  "FROM KhenThuong_NhanVien " +
                                  "INNER JOIN KhenThuong ON KhenThuong_NhanVien.IdKhenThuong = KhenThuong.Id  " +
                                  "INNER JOIN NhanVien ON KhenThuong_NhanVien.IdNhanVien = NhanVien.Id " +
                                  "WHERE MaNhanVien = N'" + maNhanVienKhenThuong + "'";


                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVienKhenThuong);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Tạo DataTable để chứa dữ liệu
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    // Gán DataTable vào DataSource của DataGridView
                    GV_KhenThuong.DataSource = dataTable;
                    GV_KhenThuong.DataBind();

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
        string script = $"alert('{message}')";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "MessageBox", script, true);
    }
}