using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLNS2;
using QLNS2.DAL;
using QLNS2.DTO;

public partial class Dangnhap : System.Web.UI.Page
{
    ConnectDB.KetNoi kn = new ConnectDB.KetNoi();
    SqlConnection connection = null;
    SqlDataReader reader = null;
    SqlCommand cmd = null;
    SqlDataAdapter adapter = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadRoles();
        }
    }

    private void MessageBox(string message)
    {
        string script = $"alert('{HttpUtility.JavaScriptStringEncode(message)}')";
        ClientScript.RegisterStartupScript(this.GetType(), "MessageBox", script, true);
    }

    private void LoadRoles()
    {
        try
        {
            using (connection = kn.OpenConnection())
            {
                string query = "SELECT * FROM Role";
                cmd = new SqlCommand(query, connection);
                adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cbRole.DataSource = dt;
                cbRole.DataTextField = "Role";
                cbRole.DataValueField = "Id";
                cbRole.DataBind();
            }
        }
        catch (Exception ex)
        {
            MessageBox(ex.Message);
        }
        finally
        {
            kn.CloseConnection(connection);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string MaNhanVien = txtTenDN.Text;
        DangNhapDAL ac = new DangNhapDAL();
        string tk = txtTenDN.Text;
        string mk = txtMk.Text;
        string selectedRole = cbRole.SelectedItem.Text;

        string sql = "SELECT Users.Id, Role_User.IdRole, NhanVien.MaNhanVien, Users.MatKhau FROM Users " +
                     "JOIN Role_User ON Users.Id = Role_User.IdUser " +
                     "JOIN NhanVien On NhanVien.IdUser = Users.Id " +
                     "WHERE MaNhanVien = @MaNhanVien AND NhanVien.Status = '1'";

        try
        {
            using (connection = kn.OpenConnection())
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@MaNhanVien", tk);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string hashedPasswordFromDB = reader["MatKhau"].ToString();
                        pass maHoaMK = new pass();

                        if (maHoaMK.VerifyPassword(mk, hashedPasswordFromDB))
                        {
                            // Save MaNhanVien in session
                            Session["MaNhanVien"] = reader["MaNhanVien"].ToString();
                            List<string> userRoles = ac.GetUserRoles(tk, hashedPasswordFromDB);

                            if (userRoles.Contains(selectedRole))
                            {
                                if (selectedRole == "Quản trị viên")
                                {
                                    Response.Redirect("FormBaoCaoThongKe.aspx");
                                }
                                else if (selectedRole == "Nhân viên")
                                {
                                    Response.Redirect("NV_TT.aspx");
                                }
                                else
                                {
                                    MessageBox("Vai trò không hợp lệ cho người dùng đã chọn.");
                                }
                            }
                            else
                            {
                                lblPass.Text = "Mật khẩu không đúng";
                            }
                        }
                        else
                        {
                            lblPass.Text = "Mật khẩu không đúng";
                        }
                    }
                    else
                    {
                        lblUser.Text = "Tên đăng nhập không đúng";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox(ex.Message);
        }
        finally
        {
            kn.CloseConnection(connection);
        }
    }
}
