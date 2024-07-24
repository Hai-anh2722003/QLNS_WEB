﻿using QLNS2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FormNhanVienSua : System.Web.UI.Page
{
    ConnectDB.KetNoi kn = new ConnectDB.KetNoi();
    SqlConnection connection = null;
    SqlDataReader reader = null;
    SqlCommand cmd = null;
    SqlDataAdapter adapter = null;
    string _IdUser;
    private void ShowClientMessage(string message)
    {
        string script = $"alert('{message}');";
        ClientScript.RegisterStartupScript(this.GetType(), "ShowMessage", script, true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //Load posstback
        if (!IsPostBack)
        {
            //Nhaan cac tham so tu sua nhan vien
            _IdUser = Request.QueryString["IdUser"];
            try
            {
                // Tạo đối tượng NhanVienDAL
                NhanVienDAL nhanVienDAL = new NhanVienDAL();

                // Lấy danh sách NhanVienDTO dựa trên IdUser
                List<NhanVienDTO> nhanVienList = nhanVienDAL.LoadUserInform(_IdUser);

                if (nhanVienList.Count > 0)
                {
                    // Lấy đối tượng NhanVienDTO đầu tiên trong danh sách
                    NhanVienDTO nhanVien = nhanVienList[0];

                    // Hiển thị thông tin lên các điều khiển TextBox
                    txtIdUser.Text = nhanVien.IdUser.ToString();
                    txtHoTen.Text = nhanVien.HoTen;
                    txtNgaySinh.Text = nhanVien.NgaySinh.ToString("yyyy-MM-dd");
                    txtEmail.Text = nhanVien.Email;
                    CbGioiTinh.Text = nhanVien.GioiTinh;
                    txtCMND.Text = nhanVien.CMND;
                    txtDiaChi.Text = nhanVien.DiaChi;
                    CbDangVien.Text = nhanVien.DangVien;
                    CbHocVan.Text = nhanVien.HocVan;
                    /*                    txtTenCongTac.Text = nhanVien.TenCongTac;
                    *//*                    txtTenChucDanh.Text = nhanVien.TenChucDanh;
                    */
                    CbLoaiHopDong.Text = nhanVien.LoaiHopDong;
                    txtNgayBatDau.Text = nhanVien.NgayBatDau.ToString("yyyy-MM-dd");
                    txtNgayKetThuc.Text = nhanVien.NgayKetThuc.ToString("yyyy-MM-dd");
                    CbMaLuong.Text = nhanVien.IdTienLuong.ToString();
                    txtDuongDan.Text = nhanVien.DuongDan;
                    txtMaNhanVien.Text = nhanVien.MaNhanVien;
                    txtIdHopDong.Text = nhanVien.IdHopDong.ToString();
                    /*             txtIdCongTac.Text = nhanVien.IdCongTac.ToString();
                                 txtIdChucDanh.Text = nhanVien.IdChucDanh.ToString();*/
                }
                else
                {
                    // Hiển thị thông báo khi không tìm thấy thông tin nhân viên
                    lblMessage.Text = "Không tìm thấy thông tin nhân viên.";
                }
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi nếu có
                lblMessage.Text = "Lỗi khi tải thông tin nhân viên: " + ex.Message;
            }
            LoadChucDanh();
            LoadCongTac();
            LoadHopDong();
            LoadTienLuong();
        }
    }

    protected void txtHoTen_TextChanged(object sender, EventArgs e)
    {

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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string DuongDanAnh = null;
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


        //sua hop dong
        HopDongDAL hopDongDAL = new HopDongDAL();
        try
        {
            hopDongDAL.SuaHopDong(CbLoaiHopDong.SelectedItem.Text, txtNgayBatDau.Text, txtNgayKetThuc.Text, txtIdHopDong.Text);

        }
        catch (Exception ex)
        {
            ShowClientMessage(ex.Message);
        }


        //Sua nhan vien
        NhanVienDAL nhanVienDAL = new NhanVienDAL();
        nhanVienDAL.SuaNhanVien(txtIdUser.Text, CbChucDanh.SelectedValue.ToString(), CbMaLuong.Text, txtIdHopDong.Text, CbCongTac.SelectedValue.ToString());

        //Sua User
        NhanVienDAL nhanVienDAL1 = new NhanVienDAL();
        nhanVienDAL1.SuaUser(txtIdUser.Text, txtHoTen.Text, txtNgaySinh.Text, txtEmail.Text, CbGioiTinh.Text, txtCMND.Text, txtDiaChi.Text, CbDangVien.Text, CbHocVan.Text, DuongDanAnh);
        ShowClientMessage("Sua thanh cong ");
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}