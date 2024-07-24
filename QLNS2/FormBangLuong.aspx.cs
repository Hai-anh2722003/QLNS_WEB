using DocumentFormat.OpenXml.Bibliography;
using QLNS2;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLNS2.DAL;
using QLNS2.DTO;
using OfficeOpenXml;
using static QLNS2.ConnectDB;
using System.Data;

public partial class FormBangLuong : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TienLuong_Load(sender, e);
    }
    ConnectDB.KetNoi kn = new ConnectDB.KetNoi();
    SqlConnection connection = null;
    SqlDataReader reader = null;
    SqlCommand cmd = null;
    SqlDataAdapter adapter = null;
    private void MessageBox(string message)
    {
        String script = $"alert('{message}')";
        ClientScript.RegisterStartupScript(this.GetType(), "MessageBox", script, true);
    }
    private void TienLuong_Load(object sender, EventArgs e)
    {
        TienLuongDAL tienLuongDAL = new TienLuongDAL();
        List<TienLuongDTO> tienLuongDTOs = tienLuongDAL.LayTienLuong();
        GV_Bangluong.DataSource = tienLuongDTOs;
        GV_Bangluong.DataBind();
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        TienLuongDAL tienLuongDAL = new TienLuongDAL();
        int Id = tienLuongDAL.AddTL(txtBacLuong.Text, txtHeSo.Text, txtPhuCap.Text, txtLuongCong.Text, txtGhiChu.Text);

        if (Id >= 0)
        {
            TienLuong_Load(sender, e);
            MessageBox("Thêm bậc lương thành công");
        }
        else
        {
            MessageBox("Đã xảy ra lỗi khi thêm bậc lương.");
        }
    }

    protected void btnSua_Click(object sender, EventArgs e)
    {
        // Lấy thông tin từ các textbox
        int Id = int.Parse(txtMaLuong.Text);
        string BacLuong = txtHeSo.Text;
        string HeSo = txtBacLuong.Text;
        string PhuCap = txtPhuCap.Text;
        string LuongCong = txtLuongCong.Text;
        string GhiChu = txtGhiChu.Text;

        // Tạo một thể hiện của lớp TienLuongDAL
        TienLuongDAL tienLuongDAL = new TienLuongDAL();

        // Gọi phương thức SuaTL với các tham số tương ứng
        int sua = tienLuongDAL.SuaTL(Id, BacLuong, HeSo, PhuCap, LuongCong, GhiChu);

        // Kiểm tra kết quả trả về từ hàm
        if (sua >= 0)
        {
            TienLuong_Load(sender, e);
            MessageBox("Sửa bậc lương thành công");
        }
        else
        {
            MessageBox("Đã xảy ra lỗi khi sửa bậc lương.");
        }
    }

    protected void btnXoa_Click(object sender, EventArgs e)
    {
        // Lấy thông tin từ các textbox
        int Id = int.Parse(txtMaLuong.Text);

        // Tạo một thể hiện của lớp TienLuongDAL
        TienLuongDAL tienLuongDAL = new TienLuongDAL();

        // Gọi phương thức SuaTL với các tham số tương ứng
        int sua = tienLuongDAL.XoaTL(Id);

        // Kiểm tra kết quả trả về từ hàm
        if (sua >= 0)
        {
            TienLuong_Load(sender, e);
            MessageBox("Xoa bậc lương thành công");
        }
        else
        {
            MessageBox("Đã xảy ra lỗi khi xóa bậc lương.");
        }
    }
    private DataTable GetDataFromDatabase()
    {
        DataTable dt = new DataTable();
        string query = "SELECT * FROM TienLuong Where TienLuong.Status = 1";

        try
        {
            KetNoi ketNoi = new KetNoi();
            dt = ketNoi.ExecuteQuery(query);
        }
        catch (Exception ex)
        {
            // Handle exception (e.g., log it)
            Console.WriteLine("Error getting data from database: " + ex.Message);
        }

        return dt;
    }

    private void ExportToExcel(DataTable dt)
    {
        using (ExcelPackage pck = new ExcelPackage())
        {
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Tính lương");
            ws.Cells["A1"].LoadFromDataTable(dt, true);

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Tinhluong.xlsx");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
        }
    }
    protected void btnEx_Click(object sender, EventArgs e)
    {
        DataTable dt = GetDataFromDatabase();
        ExportToExcel(dt);
    }

    protected void GV_Bangluong_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Lấy chỉ số của hàng được chọn
        int selectedRowIndex = GV_Bangluong.SelectedRow.RowIndex;
        // Lấy hàng được chọn
        GridViewRow selectedRow = GV_Bangluong.Rows[selectedRowIndex];

        // Lấy dữ liệu từ các ô trong hàng được chọn
        string id = selectedRow.Cells[1].Text; // Giả sử cột Id ở vị trí đầu tiên
        string heSo = selectedRow.Cells[2].Text;
        string bacLuong = selectedRow.Cells[3].Text;
        string phuCap = selectedRow.Cells[4].Text;
        string LuongCong = selectedRow.Cells[5].Text;
        string GhiChu = selectedRow.Cells[6].Text;

        txtMaLuong.Text = id;
        txtHeSo.Text = heSo;
        txtBacLuong.Text = bacLuong;
        txtLuongCong.Text = LuongCong;
        txtPhuCap.Text = phuCap;
        txtGhiChu.Text = GhiChu;
    }
}