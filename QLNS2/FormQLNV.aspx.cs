using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static QLNS2.ConnectDB;
using System.Data;

public partial class FormQLNV : System.Web.UI.Page
{
    string User;

    private void ShowClientMessage(string message)
    {
        string script = $"alert('{message}');";
        ClientScript.RegisterStartupScript(this.GetType(), "ShowMessage", script, true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadNV();
    }
    private void LoadNV()
    {
   
            // Khởi tạo danh sách nhân viên
            List<NhanVienDTO> nhanVienDTOs = new List<NhanVienDTO>();

            try
            {
                // Tạo đối tượng của lớp NhanVienDAL để gọi phương thức GetNhanVienList và lấy danh sách nhân viên
                NhanVienDAL nhanVienDAL = new NhanVienDAL();
                nhanVienDTOs = new List<NhanVienDTO>(nhanVienDAL.GetNhanVienList());

                // Gán danh sách nhân viên vào DataSource của DataGridView
                DGVNhanVien.DataSource = nhanVienDTOs;
                DGVNhanVien.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ShowClientMessage("Lỗi khi tải danh sách nhân viên: " + ex.Message);
            }
        
    }

    protected void DGVNhanVien_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Lấy chỉ số của dòng được chọn
        int selectedIndex = DGVNhanVien.SelectedIndex;

        if (selectedIndex >= 0)
        {
            // Lấy hàng được chọn
            GridViewRow selectedRow = DGVNhanVien.SelectedRow;
            User = selectedRow.Cells[2].Text;

            /*    ShowClientMessage(User+" "+MaNhanVien+" "+" "+TenNhanVien+" "+NgaySinh+" "+GioiTinh+" "+Email+" "+DiaChi+" "+DangVien+" " + " " + HocVan + " "+CMND+ " " +TenChucDanh+ " " + HopDong + " " +MaTienLuong+ " "+TenCongTac
                    + " " + BatDau+ " "+KetThuc +" "+ DuongDan+" "+IdHopDong);*/
            // Kiểm tra và hiển thị ảnh
            /* if (!string.IsNullOrEmpty(DuongDan))
             {
                 SelectedImage.ImageUrl = DuongDan;
                 SelectedImage.Visible = true;
             }
             else
             {
                 // Ẩn ảnh nếu không có đường dẫn
                 SelectedImage.Visible = false;
             }*/
        }
        else
        {
            ShowClientMessage("Lỗi khi indexchange");
        }
        /*        ShowClientMessage(BatDau);
        */          // Chuyển hướng đến trang sửa với các tham số QueryString
        Response.Redirect($"FormNhanVienSua?IdUser={User}");
    }

    protected void DGVNhanVien_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteUser")
        {
            // Lấy chỉ số của dòng hiện tại
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            // Lấy dòng hiện tại từ GridView
            GridViewRow row = DGVNhanVien.Rows[rowIndex];

            // Lấy giá trị IdUser từ BoundField (cột đầu tiên)
            string idUser = row.Cells[2].Text;

            /*            ShowClientMessage(idUser);
            */            // Thực hiện hành động xóa với IdUser
            NhanVienDAL nhanVienDAL = new NhanVienDAL();
            nhanVienDAL.XoaNV(idUser);
            LoadNhanVien();
        }
    }
    private void LoadNhanVien()
    {

        // Khởi tạo danh sách nhân viên
        List<NhanVienDTO> nhanVienDTOs = new List<NhanVienDTO>();

        try
        {
            // Tạo đối tượng của lớp NhanVienDAL để gọi phương thức GetNhanVienList và lấy danh sách nhân viên
            NhanVienDAL nhanVienDAL = new NhanVienDAL();
            nhanVienDTOs = new List<NhanVienDTO>(nhanVienDAL.GetNhanVienList());

            // Gán danh sách nhân viên vào DataSource của DataGridView
            DGVNhanVien.DataSource = nhanVienDTOs;
            DGVNhanVien.DataBind();
            BindPager();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            ShowClientMessage("Lỗi khi tải danh sách nhân viên: " + ex.Message);
        }

    }

    protected void txtTenNhanVien_TextChanged(object sender, EventArgs e)
    {
        // Khởi tạo một đối tượng BindingList để lưu trữ danh sách nhân viên
        List<NhanVienDTO> nhanVienDTOs = new List<NhanVienDTO>();

        try
        {
            // Tạo một đối tượng của lớp NhanVienDAL để gọi phương thức GetNhanVienList() và lấy danh sách nhân viên
            NhanVienDAL nhanVienDAL = new NhanVienDAL();
            nhanVienDTOs = new List<NhanVienDTO>(nhanVienDAL.SearchTenNhanVienList(txtTenNhanVien.Text));

            // Gán danh sách nhân viên vào DataSource của DataGridView
            DGVNhanVien.DataSource = nhanVienDTOs;
            DGVNhanVien.DataBind();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khi đọc dữ liệu từ cơ sở dữ liệu: " + ex.Message);
            throw new Exception("Error in SerchTenNhanVien: " + ex.Message, ex);
        }
    }
    protected void txtMaNhanVien_TextChanged(object sender, EventArgs e)
    {
        // Khởi tạo một đối tượng BindingList để lưu trữ danh sách nhân viên
        List<NhanVienDTO> nhanVienDTOs = new List<NhanVienDTO>();

        try
        {
            // Tạo một đối tượng của lớp NhanVienDAL để gọi phương thức GetNhanVienList() và lấy danh sách nhân viên
            NhanVienDAL nhanVienDAL = new NhanVienDAL();
            nhanVienDTOs = new List<NhanVienDTO>(nhanVienDAL.SearchNhanVienList(txtMaNhanVien.Text));

            // Gán danh sách nhân viên vào DataSource của DataGridView
            DGVNhanVien.DataSource = nhanVienDTOs;
            DGVNhanVien.DataBind();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khi đọc dữ liệu từ cơ sở dữ liệu: " + ex.Message);
            throw new Exception("Search: " + ex.Message, ex);
        }

    }
    protected void DGVNhanVien_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DGVNhanVien.PageIndex = e.NewPageIndex;
        LoadNhanVien();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "scrollToTop", "scrollToTop();", true);
    }
    private void BindPager()
    {
        Repeater rptPager = (Repeater)DGVNhanVien.BottomPagerRow.FindControl("rptPager");
        if (rptPager != null)
        {
            int totalPages = DGVNhanVien.PageCount;
            int currentPage = DGVNhanVien.PageIndex + 1;

            var pages = new List<int>();
            for (int i = 1; i <= totalPages; i++)
            {
                pages.Add(i);
            }

            rptPager.DataSource = pages;
            rptPager.DataBind();
        }
    }

    protected void btnThem_Click(object sender, EventArgs e)
    {
        Response.Redirect("FormThemNhanVien.aspx");
    }

    private DataTable GetDataFromDatabase()
    {
        DataTable dt = new DataTable();
        string query =
                    "SELECT Users.Id AS IdUser, CongTac.Id AS IdCongTac, ChucDanh.Id AS IdChucDanh, Users.HoTen, Users.NgaySinh, " +
                    "Users.Email, Users.GioiTinh, Users.DiaChi, Users.DangVien, Users.HocVan, Users.CMND, Users.DuongDan, " +
                    "ChucDanh.TenChucDanh, CongTac.TenCongTac, HopDong.LoaiHopDong, HopDong.NgayBatDau, HopDong.NgayKetThuc, HopDong.Id AS IdHopDong, " +
                    "TienLuong.Id AS IdTienLuong, NhanVien.MaNhanVien " +
                    "FROM Users " +
                    "JOIN NhanVien ON NhanVien.IdUser = Users.Id " +
                    "JOIN ChucDanh ON ChucDanh.Id = NhanVien.IdChucDanh " +
                    "JOIN TienLuong ON NhanVien.IdTienLuong = TienLuong.Id " +
                    "JOIN HopDong ON HopDong.Id = NhanVien.IdHopDong " +
                    "JOIN CongTac ON CongTac.Id = NhanVien.IdCongTac " +
                    "WHERE NhanVien.Status = 1;";

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
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Danh sách nhân vien");
            ws.Cells["A1"].LoadFromDataTable(dt, true);

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=DSNhanvien.xlsx");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
        }
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        DataTable dt = GetDataFromDatabase();
        ExportToExcel(dt);
    }
}