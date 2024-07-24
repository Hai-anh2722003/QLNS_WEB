using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static QLNS2.ConnectDB;
using System.Data;

public partial class NV_KiLuat : System.Web.UI.Page
{
    private KetNoi ketNoi = new KetNoi();
    SqlConnection connection = null;
    SqlDataReader reader = null;
    SqlCommand cmd = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        string maNhanVienKiluat = Session["MaNhanVienKiluat"]?.ToString();
        if (string.IsNullOrEmpty(maNhanVienKiluat))
        {
            Response.Write("<script>alert('Mã nhân viên không tồn tại!');</script>");
            return;
        }
        try
        {
            using (SqlConnection connection = ketNoi.OpenConnection())
            {
                string sqlQuery = "SELECT NhanVien.MaNhanVien, KiLuat.Id, KiLuat.KiLuat, KiLuat.Tien " +
                                  "FROM KiLuat " +
                                  "INNER JOIN KiLuat_NhanVien ON KiLuat.Id = KiLuat_NhanVien.IdKiLuat " +
                                  "INNER JOIN NhanVien ON KiLuat_NhanVien.IdNhanVien = NhanVien.Id " +
                                  "WHERE MaNhanVien = N'" + maNhanVienKiluat + "'";


                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVienKiluat);

                    SqlDataReader reader = cmd.ExecuteReader();

                    // Tạo DataTable để chứa dữ liệu
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    // Gán DataTable vào DataSource của DataGridView
                    GV_KiLuat.DataSource = dataTable;
                    GV_KiLuat.DataBind();

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