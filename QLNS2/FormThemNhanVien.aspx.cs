using QLNS2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FormThemNhanVien : System.Web.UI.Page
{
    ConnectDB.KetNoi kn = new ConnectDB.KetNoi();
    SqlConnection connection = null;
    SqlDataReader reader = null;
    SqlCommand cmd = null;
    SqlDataAdapter adapter = null;
    int IdHopDong;
    private string ChuoiNgauNhien()
    {
        DateTime ThoiGian = DateTime.Now;
        string formatTime = ThoiGian.ToString("yyyyMMddHHmmss");
        return formatTime;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            LoadMaNhanVien();
            LoadChucDanh();
            LoadCongTac();
            LoadHopDong();
            LoadTienLuong();
        }
    }

    private void ShowClientMessage(string message)
    {
        string script = $"alert('{message}');";
        ClientScript.RegisterStartupScript(this.GetType(), "ShowMessage", script, true);
    }
    private void LoadChucDanh()
    {
        //load chuc danh
        try
        {
            using (SqlConnection connection = kn.OpenConnection())
            {
                string query = "SELECT Id, TenChucDanh FROM ChucDanh WHERE Status = 1";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);

                // Gán dữ liệu vào DropDownList
                CbChucDanh.DataSource = datatable;
                CbChucDanh.DataTextField = "TenChucDanh";
                CbChucDanh.DataValueField = "Id";
                CbChucDanh.DataBind();

                // Thêm một item mặc định
                CbChucDanh.Items.Insert(0, new ListItem("--Chọn Chức Danh--", "0"));
            }
        }
        catch (Exception ex)
        {
            // Hiển thị thông báo lỗi
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('{ex.Message.Replace("'", "\\'")}');", true);
        }


    }
    private void LoadCongTac()
    {

        //load CongTac
        try
        {
            using (SqlConnection connection = kn.OpenConnection())
            {
                string query = "SELECT Id, TenCongTac FROM CongTac WHERE Status = 1";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Thiết lập dữ liệu cho DropDownList
                        CbCongTac.DataSource = dataTable;
                        CbCongTac.DataTextField = "TenCongTac";
                        CbCongTac.DataValueField = "Id";
                        CbCongTac.DataBind();


                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Hiển thị thông báo lỗi
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('{ex.Message.Replace("'", "\\'")}');", true);
        }



    }
    private void LoadHopDong()
    {
        //Load Hop Dong
        try
        {
            using (connection = kn.OpenConnection())
            {
                string query = "SELECT HopDong.LoaiHopDong FROM HopDong";
                cmd = new SqlCommand(query, connection);
                adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                CbLoaiHopDong.DataTextField = "LoaiHopDong";
                CbLoaiHopDong.DataBind();

            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "\\'") + "');", true);
        }

    }
    private void LoadTienLuong()
    {

        //Load tien luong
        try
        {
            using (connection = kn.OpenConnection())
            {
                string query = "SELECT * FROM TienLuong where TienLuong.Status = '1'";
                cmd = new SqlCommand(query, connection);
                adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                CbMaLuong.DataSource = dataTable;
                CbMaLuong.DataTextField = "Id";
                CbMaLuong.DataBind();

            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ex.Message.Replace("'", "\\'") + "');", true);
        }
    }
    private void LoadMaNhanVien()
    {
        //lay thoi gian hien tai
        DateTime ThoiGian = DateTime.Now;
        string formatTime = ThoiGian.ToString("yyyyMMddHHmmss");
        txtMaNhanVien.Text = formatTime.ToString();
    }


    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string DuongDanAnh = null;
        HopDongDAL hopDongDAL = new HopDongDAL();
        IdHopDong = hopDongDAL.AddHopDong(CbLoaiHopDong.Text, txtNgayBatDau.Text, txtNgayKetThuc.Text);
        ShowClientMessage("Id hợp đồng được tạo: " + IdHopDong);

        if (FileUpload1.HasFile)
        {
            try
            {
                // Tạo chuỗi ngẫu nhiên để tránh tên file trùng lặp
                string randomString = Guid.NewGuid().ToString();
                string filename = Path.GetFileNameWithoutExtension(FileUpload1.FileName);
                string extension = Path.GetExtension(FileUpload1.FileName);
                string newFilename = $"{filename}_{randomString}{extension}";
                string folderPath = Server.MapPath("~/Content/images");
                string fullFilePath = Path.Combine(folderPath, newFilename); // Đường dẫn đầy đủ của file

                // Kiểm tra xem thư mục có tồn tại hay không, nếu không thì tạo mới
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Lưu tệp vào thư mục trên server
                FileUpload1.SaveAs(fullFilePath);

                // Trả về đường dẫn chi tiết của ảnh đã tải lên
                string relativeFilePath = $"~/Content/images/{newFilename}";
                lblMessage.Text = $"Ảnh đã được tải lên thành công! Đường dẫn: {relativeFilePath}";

                // Hiển thị ảnh trong Image control
                imgPreview.ImageUrl = relativeFilePath;
                imgPreview.Visible = true;

                // Nếu cần lưu đường dẫn này vào biến để sử dụng sau này
                DuongDanAnh = relativeFilePath;
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Lỗi khi tải ảnh: " + ex.Message;
            }
        }
        else
        {
            lblMessage.Text = "Vui lòng chọn một ảnh để tải lên.";
        }

        //tHEM uSER
        int IdUser = -1;
        NhanVienDAL nhanVienDAL = new NhanVienDAL();
        try
        {
            IdUser = nhanVienDAL.AddNV(txtHoTen.Text, txtEmail.Text, txtNgaySinh.Text, CbGioiTinh.Text, txtCMND.Text, txtDiaChi.Text, CbDangVien.Text, CbHocVan.Text, DuongDanAnh);
            ShowClientMessage("Id User là: " + IdUser);
        }
        catch (Exception ex)
        {
            ShowClientMessage("Lỗi addnv: " + ex.Message);

        }

        //Them nhan Vien
        NhanVienDAL nhanvien = new NhanVienDAL();
        nhanvien.AddNV2(IdUser, txtMaNhanVien.Text, CbChucDanh.SelectedValue.ToString(), CbMaLuong.Text, IdHopDong.ToString(), CbCongTac.SelectedValue.ToString());
        ShowClientMessage("Thêm NV2 thành công");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }

    protected void CbChucDanh_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}