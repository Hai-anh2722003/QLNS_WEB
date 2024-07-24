using DocumentFormat.OpenXml.Office2010.Excel;
using Irony;
using QLNS2.DAL;
using QLNS2.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FormChucVu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HienThiDanhSachChucDanh();
        }
    }

    private void HienThiDanhSachChucDanh()
    {
        ChucDanhDAL chucDanhDAL = new ChucDanhDAL();
        List<ChucDanhDTO> DsChucDanh = chucDanhDAL.LayChucDanh();
        GV_ChucDanh.DataSource = DsChucDanh;
        GV_ChucDanh.DataBind();
    }

    protected void GV_ChucDanh_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedRowIndex = GV_ChucDanh.SelectedRow.RowIndex;
        GridViewRow selectedRow = GV_ChucDanh.Rows[selectedRowIndex];

        string Id = selectedRow.Cells[1].Text;
        string TenChucDanh = selectedRow.Cells[2].Text;

        txtMaChucDanh.Text = Id;
        txtTenChucDanh.Text = HttpUtility.HtmlDecode(TenChucDanh); 
    }

    protected void btnThem_Click(object sender, EventArgs e)
    {
        string positionName = txtTenChucDanh.Text.Trim();

        if (!string.IsNullOrEmpty(positionName))
        {
            AddPosition(positionName);
        }
        else
        {
            ShowMessage("Vui lòng nhập tên chức danh!", false);
        }
    }

    private void AddPosition(string positionName)
    {
        ChucDanhDAL chucDanhDAL = new ChucDanhDAL();
        string message;
        bool success = chucDanhDAL.ThemChucDanh(positionName, out message);

        ShowMessage(message, success);

        if (success)
        {
            HienThiDanhSachChucDanh();
            ResetForm();
            HideAddPositionForm();
            ShowAlert("Thêm chức danh thành công!");
        }
    }

    protected void btnSua_Click(object sender, EventArgs e)
    {
        if (int.TryParse(txtMaChucDanh.Text, out int id) && !string.IsNullOrEmpty(txtTenChucDanh.Text))
        {
            string tenChucDanh = txtTenChucDanh.Text.Trim();

            ChucDanhDAL chucDanhDAL = new ChucDanhDAL();
            string message;
            bool success = chucDanhDAL.SuaChucDanh(id, tenChucDanh, out message);

            ShowMessage(message, success);

            if (success)
            {
                HienThiDanhSachChucDanh();
                ResetForm();
                HideAddPositionForm();
                ShowAlert("Sửa chức danh thành công!");
            }
        }
        else
        {
            ShowMessage("Vui lòng nhập đầy đủ thông tin!", false);
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
        txtTenChucDanh.Text = string.Empty;
    }

    private void HideAddPositionForm()
    {
        string script = "document.getElementById('addPositionForm').style.display = 'none';";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "HideForm", script, true);
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        if (int.TryParse(txtMaChucDanh.Text, out int id))
        {
            ChucDanhDAL chucDanhDAL = new ChucDanhDAL();
            string message;
            bool success = chucDanhDAL.XoaChucDanh(id, out message);

            ShowMessage(message, success);

            if (success)
            {
                HienThiDanhSachChucDanh();
                ResetForm();
                HideAddPositionForm();
                ShowAlert("Xóa chức danh thành công!");
            }
        }
        else
        {
            ShowMessage("Vui lòng chọn chức danh để xóa!", false);
        }
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        HienThiDanhSachChucDanh();
    }
}
