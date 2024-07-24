using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office.Word;
using QLNS2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FormHeThong : System.Web.UI.Page
{
    ConnectDB.KetNoi kn = new ConnectDB.KetNoi();
    SqlConnection connection = null;
    SqlDataReader reader = null;
    SqlCommand cmd = null;
    SqlDataAdapter adapter = null;

    string _MNV;
    string _HoTen;
    string _IdUser=" ";
    string _IdUserRole=" ";
    protected void Page_Load(object sender, EventArgs e)
    {
        loadPage();
    }
    private void loadPage()
    {
        if (!IsPostBack)
        {
            loadTKList();
            loadQuyen();

        }
       

    }
    protected void GV_TraCuu_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    private void loadTKList()
    {
        // Khởi tạo một đối tượng BindingList để lưu trữ danh sách nhân viên
        List<TaiKhoanDTO> TkList = new List<TaiKhoanDTO>();

        try
        {
            // Tạo một đối tượng của lớp NhanVienDAL để gọi phương thức GetNhanVienList() và lấy danh sách nhân viên
            TaiKhoanDAL TKDAL = new TaiKhoanDAL();
            TkList = new List<TaiKhoanDTO>(TKDAL.GetTkList());

            // Gán danh sách nhân viên vào DataSource của DataGridView
            DGVHeThong.DataSource = TkList;
            DGVHeThong.DataBind();

        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khi đọc dữ liệu từ cơ sở dữ liệu: " + ex.Message);
            throw new Exception("Error in load Tklist: " + ex.Message, ex);
        }
    }
    //load  role
    private void loadQuyen()
    {
        //Load Quyen
        try
        {
            using (connection = kn.OpenConnection())
            {
                string query = "SELECT * FROM Role";
                cmd = new SqlCommand(query, connection);
                adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                CbQuyen.DataSource = dataTable;
                CbQuyen.DataTextField = "Role";
                CbQuyen.DataValueField = "Id";
                CbQuyen.DataBind();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khi đọc dữ liệu từ cơ sở dữ liệu: " + ex.Message);
            throw new Exception("Error in load quyen: " + ex.Message, ex);
        }

    }

    protected void DGVHeThong_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = DGVHeThong.Rows[rowIndex];

            if (e.CommandName == "UpdateTK")
            {
                txtIdUser.Text= row.Cells[3].Text;
                txtIdUserRole.Text = row.Cells[2].Text;

                txtHoTen.Text = HttpUtility.HtmlDecode(row.Cells[5].Text);
                txtMaNhanVien.Text = row.Cells[6].Text;
            }
            else if (e.CommandName == "DeleteTK")
            {
                _IdUserRole = row.Cells[2].Text;

                TaiKhoanDAL taiKhoanDAL = new TaiKhoanDAL();
                taiKhoanDAL.XoaTK(_IdUserRole);
                ShowClientMessage("Xóa thành công");
                loadTKList();
                loadQuyen();
            }
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            ShowClientMessage("Lỗi: Dữ liệu không hợp lệ.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            ShowClientMessage("Lỗi: Có lỗi xảy ra.");
        }
    }

    protected void btnThem_Click(object sender, EventArgs e)
    {
        bool MatKhauHopLe = string.Equals(txtMk.Text, txtXacNhanMK.Text);
        if (MatKhauHopLe)
        {
            pass maHoaMK = new pass();
            string MatKhauMaHoa = maHoaMK.HashPassword(txtMk.Text);
            // Thêm tài khoản với mật khẩu đã mã hóa vào cơ sở dữ liệu
            TaiKhoanDAL taiKhoanDAL = new TaiKhoanDAL();
            taiKhoanDAL.ThemTaiKhoan(txtMaNhanVien.Text, MatKhauMaHoa, CbQuyen.SelectedValue.ToString());
            ShowClientMessage("Thêm tài khoản thành công!");

        }
        else
        {
            ShowClientMessage("Lỗi thêm tài khoản");
        }
        loadTKList();
        loadQuyen();
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        try
        {
            pass maHoaMK = new pass();
            string MatKhauMaHoa = maHoaMK.HashPassword(txtMk.Text);
            TaiKhoanDAL taiKhoanDAL = new TaiKhoanDAL();
            taiKhoanDAL.SuaTK(txtIdUser.Text, MatKhauMaHoa, txtIdUserRole.Text, CbQuyen.SelectedValue.ToString());
            ShowClientMessage("Sửa quyền nhân viên thành công!");
        }
        catch (Exception ex)
        {
            ShowClientMessage(ex.Message);
        }
     
            loadTKList();
            loadQuyen();

        


    }
    private void ShowClientMessage(string message)
    {
        string script = $"alert('{message}');";
        ClientScript.RegisterStartupScript(this.GetType(), "ShowMessage", script, true);
    }

    protected void DGVHeThong_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {

    }

    protected void btnLamoi_Click(object sender, EventArgs e)
    {

    }
}