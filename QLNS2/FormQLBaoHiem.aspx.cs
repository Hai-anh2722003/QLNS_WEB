using QLNS2;
using QLNS2.DAL;
using QLNS2.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FormQLBaoHiem : System.Web.UI.Page
{
    ConnectDB.KetNoi Kn = new ConnectDB.KetNoi();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadNhanVien();
            HienThiDanhSachBaoHiem();
        }

    }
    private void HienThiDanhSachBaoHiem()
    {
        BaoHiemDAL baoHiemDAL = new BaoHiemDAL();
        List<BaoHiemDTO> DsBaoHiem = baoHiemDAL.LayBaoHiem();
        GV_BaoHiem.DataSource = DsBaoHiem;
        GV_BaoHiem.DataBind();
    }

    protected void GV_BaoHiem_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedRowIndex = GV_BaoHiem.SelectedRow.RowIndex;
        GridViewRow selectedRow = GV_BaoHiem.Rows[selectedRowIndex];
        // Lấy giá trị từ các ô trong dòng được chọn
        string TienBaoHiem = selectedRow.Cells[2].Text;
        string NgayCap = selectedRow.Cells[3].Text;
        string NoiCap = selectedRow.Cells[4].Text;
        string GhiChu = selectedRow.Cells[6].Text;
        string Id = selectedRow.Cells[1].Text;
        string IdNhanVien = selectedRow.Cells[5].Text;

        // Gán giá trị cho các TextBox
        DateNgayCap.Text = NgayCap;
        txtTienBaoHiem.Text = TienBaoHiem;
        txtNoiCap.Text = HttpUtility.HtmlDecode(NoiCap);
        txtGhiChu.Text = HttpUtility.HtmlDecode(GhiChu);
        cboMaNhanVien.Text = IdNhanVien;
        cboMaBH.Text = Id;
    }

    private void LoadNhanVien()
    {
        try
        {
            using (SqlConnection ketnoi = Kn.OpenConnection())
            {
                // Define the query to select data from the NhanVien table
                string query = "SELECT Id FROM NhanVien";

                // Create the SqlCommand object
                using (SqlCommand command = new SqlCommand(query, ketnoi))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    cboMaNhanVien.DataSource = reader;
                    cboMaNhanVien.DataTextField = "Id";
                    cboMaNhanVien.DataValueField = "Id";
                    cboMaNhanVien.DataBind();

                }
            }
        }
        catch (Exception ex)
        {
            // Handle any exceptions that occur
            Response.Write("Lỗi khi tải dữ liệu nhân viên: " + ex.Message);
        }
    }

    private void ShowMessage(string message, bool isSuccess)
    {
        if (isSuccess)
        {
            MessageBox(message);
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

    private void ResetForm()
    {
        txtTienBaoHiem.Text = string.Empty;
        txtGhiChu.Text = string.Empty;
        txtNoiCap.Text = string.Empty;
        DateNgayCap.Text = string.Empty;
    }

    private void HideAddPositionForm()
    {
        string script = "document.getElementById('addPositionForm').style.display = 'none';";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "HideForm", script, true);
    }

    protected void cboMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (cboMaNhanVien.SelectedValue != null && cboMaNhanVien.SelectedValue != "0")
            {
                using (SqlConnection ketnoi = Kn.OpenConnection())
                {
                    string query = "SELECT * FROM Users INNER JOIN NhanVien ON NhanVien.IdUser = Users.Id WHERE NhanVien.Id = @Id";
                    string selectedMaNhanVien = cboMaNhanVien.SelectedValue;

                    using (SqlCommand command = new SqlCommand(query, ketnoi))
                    {
                        command.Parameters.AddWithValue("@Id", selectedMaNhanVien);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            txtTennhanvien.Text = reader["HoTen"].ToString();
                        }
                        else
                        {
                            txtTennhanvien.Text = string.Empty;
                            Response.Write("Không tìm thấy dữ liệu nhân viên.");
                        }
                    }
                }
            }
            else
            {
                Response.Write("Vui lòng chọn một mã nhân viên hợp lệ.");
            }
        }
        catch (Exception ex)
        {
            Response.Write("Lỗi: " + ex.Message);
        }
    }

    protected void btnThem_Click(object sender, EventArgs e)
    {
        try
        {
            // Kiểm tra xem ComboBox đã chọn một mục nào chưa
            if (cboMaNhanVien.SelectedValue != null && cboMaNhanVien.SelectedValue != "0")
            {
                // Chuyển đổi giá trị ngày từ DateTimePicker sang chuỗi đúng định dạng
                string ngayCap = DateNgayCap.Text; // Adjust if needed based on your DateNgayCap control

                // Lấy các giá trị từ các điều khiển trên giao diện
                string ghiChu = txtGhiChu.Text;
                int tienBaoHiem = Convert.ToInt32(txtTienBaoHiem.Text);
                int idNhanVien = Convert.ToInt32(cboMaNhanVien.SelectedValue);
                string noiCap = txtNoiCap.Text;

                // Gọi phương thức để thêm bảo hiểm
                BaoHiemDAL baoHiemDAL = new BaoHiemDAL();
                string message;
                bool success = baoHiemDAL.ThemBaoHiem(ngayCap, noiCap, ghiChu, tienBaoHiem, idNhanVien, out message);

                if (success)
                {
                    // Optional: Show success message
                    HienThiDanhSachBaoHiem();
                    Response.Write("<script>alert('Thêm bảo hiểm thành công.');</script>");
                }
                else
                {
                    // Optional: Show failure message
                    Response.Write("<script>alert('" + message + "');</script>");
                }
            }
            else
            {
                // Hiển thị thông báo lỗi nếu không chọn nhân viên
                Response.Write("<script>alert('Vui lòng chọn nhân viên.');</script>");
            }
        }
        catch (Exception ex)
        {
            // Xử lý lỗi và hiển thị thông báo
            Response.Write("<script>alert('Lỗi: " + ex.Message + "');</script>");
        }
    }

    protected void btnSua_Click(object sender, EventArgs e)
    {
        try
        {

            // Chuyển đổi giá trị ngày từ DateTimePicker sang chuỗi đúng định dạng
            string ngayCap = DateNgayCap.Text; // Có thể cần điều chỉnh dựa vào điều khiển DateNgayCap của bạn

            // Lấy các giá trị từ các điều khiển trên giao diện
            string ghiChu = txtGhiChu.Text;
            int tienBaoHiem = Convert.ToInt32(txtTienBaoHiem.Text);
            int idNhanVien = Convert.ToInt32(cboMaNhanVien.SelectedValue);
            string noiCap = txtNoiCap.Text;
            int idBaoHiem = Convert.ToInt32(cboMaBH.Text); // Lấy IdBaoHiem từ cboMaBH hoặc txtMaBaoHiem tùy theo thiết kế của bạn

            // Gọi phương thức để sửa bảo hiểm
            BaoHiemDAL baoHiemDAL = new BaoHiemDAL();
            string message;
            bool success = baoHiemDAL.SuaBaoHiem(idBaoHiem, ngayCap, noiCap, ghiChu, tienBaoHiem, idNhanVien, out message);

            if (success)
            {
                // Optional: Show success message
                Response.Write("<script>alert('Sửa bảo hiểm thành công.');</script>");
                // Sau khi sửa thành công, bạn có thể làm mới danh sách hoặc làm gì đó khác tại đây
                HienThiDanhSachBaoHiem(); // Gọi lại phương thức để hiển thị lại danh sách bảo hiểm sau khi sửa
            }
            else
            {
                // Hiển thị thông báo lỗi nếu không chọn bảo hiểm để sửa
                Response.Write("<script>alert('Vui lòng chọn bảo hiểm cần sửa.');</script>");
            }
        }
        catch (Exception ex)
        {
            // Xử lý lỗi và hiển thị thông báo
            Response.Write("<script>alert('Lỗi: " + ex.Message + "');</script>");
        }
    }

    protected void btnXoa_Click(object sender, EventArgs e)
    {
        try
        {

            int idBaoHiem = Convert.ToInt32(cboMaBH.Text); // Lấy IdBaoHiem từ cboMaBH hoặc txtMaBaoHiem tùy theo thiết kế của bạn

            // Gọi phương thức để xóa bảo hiểm
            BaoHiemDAL baoHiemDAL = new BaoHiemDAL();
            string message;
            bool success = baoHiemDAL.XoaBaoHiem(idBaoHiem, out message);

            if (success)
            {
                // Optional: Show success message
                Response.Write("<script>alert('Xóa bảo hiểm thành công.');</script>");
                // Sau khi xóa thành công, bạn có thể làm mới danh sách hoặc làm gì đó khác tại đây
                HienThiDanhSachBaoHiem(); // Gọi lại phương thức để hiển thị lại danh sách bảo hiểm sau khi xóa
            }
            else
            {
                // Optional: Show failure message
                Response.Write("<script>alert('" + message + "');</script>");
            }


        }
        catch (Exception ex)
        {
            // Xử lý lỗi và hiển thị thông báo
            Response.Write("<script>alert('Lỗi: " + ex.Message + "');</script>");
        }
    }

    protected void btnLM_Click(object sender, EventArgs e)
    {
        HienThiDanhSachBaoHiem();
    }
}