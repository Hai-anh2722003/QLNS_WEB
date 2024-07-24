using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using QLNS2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using static QLNS2.ConnectDB;

public partial class FormBaoCaoThongKe : System.Web.UI.Page
{
    SqlConnection connection = null;
    SqlDataReader reader = null;
    SqlCommand cmd = null;
    SqlDataAdapter adapter = null;
    ConnectDB.KetNoi kn = new ConnectDB.KetNoi();
    private KetNoi ketNoi = new KetNoi();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TongNhanVien();
            NVthuviec();
            NVSinhnhat();
            NVnghihuu();
            var columnData = HienThiBieuDoColumn();
            var pieData = HienThiBieuDoPie();
            var json = new JavaScriptSerializer();

            ClientScript.RegisterStartupScript(this.GetType(), "renderCharts",
                $"renderCharts({json.Serialize(columnData)}, {json.Serialize(pieData)});", true);
        }
    }

    private void MessageBox(string message)
    {
        string script = $"alert('{message}')";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "MessageBox", script, true);
    }
    private void TongNhanVien()
    {
        try
        {
            using (SqlConnection connection = ketNoi.OpenConnection())
            {
                string sqlQuery = "SELECT COUNT(*) AS TongNV FROM NhanVien WHERE NhanVien.Status = 1;";


                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {

                    // Thực thi truy vấn và đọc dữ liệu
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Đọc dữ liệu từ các cột

                        lbltongnhanvien.Text = reader["TongNV"].ToString();

                    }
                    else
                    {
                        MessageBox("Không tìm thấy thông tin nhân viên!");
                    }

                    // Đóng reader sau khi sử dụng
                    reader.Close();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox(ex.Message);
        }
    }
    private void NVthuviec()
    {
        try
        {
            using (SqlConnection connection = ketNoi.OpenConnection())
            {
                string sqlQuery = "SELECT COUNT(*) AS thuviec " +
                                  "FROM NhanVien INNER JOIN HopDong ON NhanVien.IdHopDong = HopDong.Id " +
                                  "Where LoaiHopDong = N'Hợp đồng thử việc';";


                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {

                    // Thực thi truy vấn và đọc dữ liệu
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Đọc dữ liệu từ các cột

                        lblThuViec.Text = reader["thuviec"].ToString();

                    }
                    else
                    {
                        MessageBox("Không tìm thấy thông tin nhân viên!");
                    }

                    // Đóng reader sau khi sử dụng
                    reader.Close();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox(ex.Message);
        }
    }
    private void NVSinhnhat()
    {
        try
        {
            using (SqlConnection connection = ketNoi.OpenConnection())
            {
                string sqlQuery = "SELECT COUNT(*) AS sinhnhat FROM Users JOIN NhanVien ON NhanVien.IdUser = Users.Id WHERE NhanVien.Status = 1 AND DATEPART(MONTH, Users.NgaySinh) = DATEPART(MONTH, GETDATE());";


                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {

                    // Thực thi truy vấn và đọc dữ liệu
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Đọc dữ liệu từ các cột

                        lblSinhNhat.Text = reader["sinhnhat"].ToString();

                    }
                    else
                    {
                        MessageBox("Không tìm thấy thông tin nhân viên!");
                    }

                    // Đóng reader sau khi sử dụng
                    reader.Close();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox(ex.Message);
        }
    }
    private void NVnghihuu()
    {
        try
        {
            using (SqlConnection connection = ketNoi.OpenConnection())
            {
                string sqlQuery = "SELECT COUNT(*) AS nghihuu " +
                                "FROM Users JOIN NhanVien ON NhanVien.IdUser = Users.Id " +
                                "WHERE Users.NgaySinh <= DATEADD(YEAR, -40, GETDATE());";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    // Thực thi truy vấn và đọc dữ liệu
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Đọc dữ liệu từ các cột và gán giá trị cho Label
                        lblNghiHuu.Text = reader["nghihuu"].ToString();
                    }
                    else
                    {
                        MessageBox("Không tìm thấy thông tin nhân viên!");
                    }

                    // Đóng reader sau khi sử dụng
                    reader.Close();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox(ex.Message);
        }
    }
    private int[] HienThiBieuDoColumn()
    {
        int[] data = new int[3];
        try
        {
            using (SqlConnection connection = ketNoi.OpenConnection())
            {
                string query = "SELECT " +
                               "(SELECT COUNT(*) FROM NhanVien JOIN HopDong ON NhanVien.IdHopDong = HopDong.Id WHERE LoaiHopDong= N'Hợp đồng thử việc') AS NVHopDong," +
                               "(SELECT COUNT(*) FROM NhanVien JOIN HopDong ON NhanVien.IdHopDong = HopDong.Id WHERE LoaiHopDong= N'Hợp đồng có thời hạn') AS NV," +
                               "(SELECT COUNT(*) FROM NhanVien JOIN HopDong ON NhanVien.IdHopDong = HopDong.Id WHERE LoaiHopDong= N'Hợp đồng không có thời hạn') AS NVNghiViec;";
                using (cmd = new SqlCommand(query, connection))
                {
                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        data[0] = reader.GetInt32(reader.GetOrdinal("NVHopDong"));
                        data[1] = reader.GetInt32(reader.GetOrdinal("NV"));
                        data[2] = reader.GetInt32(reader.GetOrdinal("NVNghiViec"));
                    }
                    reader.Close();
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exception (e.g., log it and display a message to the user)
        }
        return data;
    }

    private int[] HienThiBieuDoPie()
    {
        int[] data = new int[5];
        try
        {
            using (SqlConnection connection = ketNoi.OpenConnection())
            {
                string query = "SELECT " +
                               "(SELECT COUNT(*) FROM NhanVien JOIN CongTac ON NhanVien.IdCongTac = CongTac.Id WHERE CongTac.TenCongTac LIKE '%Marketing%') AS Marketing," +
                               "(SELECT COUNT(*) FROM NhanVien JOIN CongTac ON NhanVien.IdCongTac = CongTac.Id WHERE CongTac.TenCongTac LIKE '%IT%') AS IT," +
                               "(SELECT COUNT(*) FROM NhanVien JOIN CongTac ON NhanVien.IdCongTac = CongTac.Id WHERE CongTac.TenCongTac=N'Kế toán') AS Ketoan," +
                               "(SELECT COUNT(*) FROM NhanVien JOIN CongTac ON NhanVien.IdCongTac = CongTac.Id WHERE CongTac.TenCongTac= N'Nhân sự') AS NS," +
                               "(SELECT COUNT(*) FROM NhanVien JOIN CongTac ON NhanVien.IdCongTac = CongTac.Id WHERE CongTac.TenCongTac= N'Sales') AS Sales;";
                using (cmd = new SqlCommand(query, connection))
                {
                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        data[0] = reader.GetInt32(reader.GetOrdinal("Marketing"));
                        data[1] = reader.GetInt32(reader.GetOrdinal("IT"));
                        data[2] = reader.GetInt32(reader.GetOrdinal("Ketoan"));
                        data[3] = reader.GetInt32(reader.GetOrdinal("NS"));
                        data[4] = reader.GetInt32(reader.GetOrdinal("Sales"));
                    }
                    reader.Close();
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exception (e.g., log it and display a message to the user)
        }
        return data;
    }
}
