using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FormSinhNhat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadSinhNhat();
        }
    }
    private void ShowClientMessage(string message)
    {
        string script = $"alert('{message}');";
        ClientScript.RegisterStartupScript(this.GetType(), "ShowMessage", script, true);
    }
    private void LoadSinhNhat()
    {
        List<NhanVienDTO> nhanVienDTOs = new List<NhanVienDTO>();

        try
        {
            // Tạo một đối tượng của lớp NhanVienDAL để gọi phương thức GetNhanVienList() và lấy danh sách nhân viên
            NhanVienDAL nhanVienDAL = new NhanVienDAL();
            nhanVienDTOs = new List<NhanVienDTO>(nhanVienDAL.SinhNhatNV());

            // Gán danh sách nhân viên vào DataSource của DataGridView
            DGVSinhNhat.DataSource = nhanVienDTOs;
            DGVSinhNhat.DataBind();
        }
        catch (Exception ex)
        {
            ShowClientMessage("Lỗi khi tải danh sách nhân viên nghi huu: " + ex.Message);
        }
    }
}