using QLNS2.DAL;
using QLNS2.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FormPhongBan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HienThiDanhSachCongTac();
        }
    }
    private void HienThiDanhSachCongTac()
    {
        CongTacDAL congTacDAL = new CongTacDAL();
        List<CongTacDTO> congTacDTO = congTacDAL.LayCongTac();
        GV_CongTac.DataSource = congTacDTO;
        GV_CongTac.DataBind();
    }

    protected void GV_CongTac_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedRowIndex = GV_CongTac.SelectedRow.RowIndex;
        GridViewRow selectedRow = GV_CongTac.Rows[selectedRowIndex];

        string Id = selectedRow.Cells[1].Text;
        string TenCongTac = selectedRow.Cells[2].Text;

        txtMaCongTac.Text = Id;
        txtTenCongTac.Text = HttpUtility.HtmlDecode(TenCongTac);
    }

    protected void btnThem_Click(object sender, EventArgs e)
    {
        string positionName = txtTenCongTac.Text.Trim();

        if (!string.IsNullOrEmpty(positionName))
        {
            AddCongTac(positionName);
        }
        else
        {
            ShowMessage("Vui lòng nhập tên chức danh!", false);
        }
    }
    private void AddCongTac(string positionName)
    {
        CongTacDAL congTacDAL = new CongTacDAL();
        string message;
        bool success = congTacDAL.ThemCongTac(positionName, out message);

        ShowMessage(message, success);

        if (success)
        {
            HienThiDanhSachCongTac();
            ResetForm();
            HideAddPositionForm();
            ShowAlert("Thêm công tác thành công!");
        }
    }
    private void ShowMessage(string message, bool isSuccess)
    {
        if (isSuccess)
        {
            ShowAlert(message);
        }
        else
        {
            MessageBox(message);
        }
    }

    private void MessageBox(string message)
    {
        string script = $"alert('{message}')";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "MessageBox", script, true);
    }

    private void ShowAlert(string message)
    {
        string script = $"alert('{message}');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowAlert", script, true);
    }

    private void ResetForm()
    {
        txtTenCongTac.Text = string.Empty;
    }

    private void HideAddPositionForm()
    {
        string script = "document.getElementById('addPositionForm').style.display = 'none';";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "HideForm", script, true);
    }


    protected void btnSua_Click(object sender, EventArgs e)
    {
        if (int.TryParse(txtMaCongTac.Text, out int id) && !string.IsNullOrEmpty(txtTenCongTac.Text))
        {
            string tenCongTac = txtTenCongTac.Text.Trim();

            CongTacDAL congTacDAL = new CongTacDAL();
            string message;
            bool success = congTacDAL.SuaCongTac(id, tenCongTac, out message);

            ShowMessage(message, success);

            if (success)
            {
                HienThiDanhSachCongTac();
                ResetForm();
                HideAddPositionForm();
                ShowAlert("Sửa công tác thành công!");
            }
        }
        else
        {
            ShowMessage("Vui lòng nhập đầy đủ thông tin!", false);
        }
    }

    protected void btnXoa_Click(object sender, EventArgs e)
    {
        if (int.TryParse(txtMaCongTac.Text, out int id))
        {
            CongTacDAL congTacDAL = new CongTacDAL();
            string message;
            bool success = congTacDAL.XoaCongTac(id, out message);

            ShowMessage(message, success);

            if (success)
            {
                HienThiDanhSachCongTac();
                ResetForm();
                HideAddPositionForm();
                ShowAlert("Xóa công tác thành công!");
            }
        }
        else
        {
            ShowMessage("Vui lòng chọn công tác để xóa!", false);
        }
    }
}