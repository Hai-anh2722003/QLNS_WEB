using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using OfficeOpenXml;
using System.Web.UI.WebControls;
using static QLNS2.ConnectDB;

public partial class FormChamCong : System.Web.UI.Page
{
    KetNoi ketNoi = new KetNoi();
    int idKhenThuong, idNhanVien, idKiLuat;

    protected void Page_Load(object sender, EventArgs e)
    {
        using (SqlConnection connection = ketNoi.OpenConnection())
        {

            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT NhanVien.MaNhanVien, NhanVien.IdCongTac, NhanVien.IdTienLuong, Users.HoTen, Users.CMND, CongTac.TenCongTac FROM   NhanVien INNER JOIN Users ON NhanVien.IdUser = Users.Id INNER JOIN CongTac ON NhanVien.IdCongTac = CongTac.Id", connection))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dsnv1.DataSource = dt;
                dsnv1.DataBind();
            }
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT Id, Tien, KhenThuong FROM KhenThuong", connection))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dskt1.DataSource = dt;
                dskt1.DataBind();
            }
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT Id, Tien, KiLuat FROM KiLuat", connection))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dskl1.DataSource = dt;
                dskl1.DataBind();
            }

            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT LuongThang.MaNhanVien, Users.HoTen, LuongThang.TongLuong, LuongThang.Thang, LuongThang.Nam FROM LuongThang INNER JOIN NhanVien ON LuongThang.MaNhanVien = NhanVien.MaNhanVien INNER JOIN Users ON NhanVien.IdUser = Users.Id", connection))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }

    protected void dsnv_Click(object sender, EventArgs e) { }

    protected void dskt_Click(object sender, EventArgs e) { }

    protected void dskl_Click(object sender, EventArgs e) { }

    protected void dsnv1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Lấy chỉ số của hàng được chọn
        int selectedRowIndex = dsnv1.SelectedRow.RowIndex;
        // Lấy hàng được chọn
        GridViewRow selectedRow = dsnv1.Rows[selectedRowIndex];

        // Lấy dữ liệu từ các ô trong hàng được chọn
        string idnv = Server.HtmlDecode(selectedRow.Cells[1].Text); // Giả sử cột Id ở vị trí đầu tiên
        string mp = Server.HtmlDecode(selectedRow.Cells[2].Text);
        string ml1 = Server.HtmlDecode(selectedRow.Cells[3].Text);
        string ht = Server.HtmlDecode(selectedRow.Cells[4].Text);


        manv1.Text = idnv;
        hoten1.Text = ht;

        using (SqlConnection connection = ketNoi.OpenConnection())
        {

            using (SqlCommand command = new SqlCommand("SELECT TenCongTac FROM CongTac WHERE Id = @mp", connection))
            {
                command.Parameters.AddWithValue("@mp", mp);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    phong1.Text = Convert.ToString(result);
                }
            }
            using (SqlCommand command = new SqlCommand("SELECT Users.CMND FROM Users WHERE HoTen = @ht ", connection))
            {
                command.Parameters.AddWithValue("@ht", ht);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    cccd1.Text = Convert.ToString(result);
                }
            }
            ModalPopupExtender1.Show();
        }
    }

    protected void chonnv_Click(object sender, EventArgs e)
    {
        manv.Text = manv1.Text;
        using (SqlConnection connection = ketNoi.OpenConnection())
        {
            //hiển thị thông số lương
            using (SqlCommand command = new SqlCommand("SELECT  NhanVien.IdTienLuong, TienLuong.HeSo, TienLuong.PhuCap FROM  NhanVien INNER JOIN TienLuong ON NhanVien.IdTienLuong = TienLuong.Id where NhanVien.MaNhanVien = @idnv", connection))
            {
                command.Parameters.AddWithValue("@idnv", manv.Text);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ml.Text = Convert.ToString(reader["IdTienLuong"]);
                        hsl.Text = Convert.ToString(reader["HeSo"]);
                        pccv.Text = Convert.ToString(reader["PhuCap"]);

                    }
                }
            }
            //hiển thị tiền khen thưởng và kỉ luật
            using (SqlCommand command = new SqlCommand($"SELECT SUM(KhenThuong.Tien) as TienKhenThuong FROM KhenThuong_NhanVien JOIN KhenThuong ON KhenThuong_NhanVien.IdKhenThuong = KhenThuong.Id JOIN NhanVien ON KhenThuong_NhanVien.IdNhanVien = NhanVien.Id WHERE NhanVien.MaNhanVien =  @MaNhanVien", connection))
            {
                command.Parameters.AddWithValue("@MaNhanVien", manv.Text);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        kt.Text = Convert.ToString(reader["TienKhenThuong"]);

                    }
                }
            }
            using (SqlCommand command = new SqlCommand($"SELECT SUM(KiLuat.Tien) as TienKiLuat FROM KiLuat_NhanVien JOIN KiLuat ON KiLuat_NhanVien.IdKiLuat = KiLuat.Id JOIN NhanVien ON KiLuat_NhanVien.IdNhanVien = NhanVien.Id WHERE NhanVien.MaNhanVien =  @MaNhanVien", connection))
            {
                command.Parameters.AddWithValue("@MaNhanVien", manv.Text);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        kl.Text = Convert.ToString(reader["TienKiLuat"]);

                    }
                }
            }
        }
    }

    protected void ht_Click(object sender, EventArgs e)
    {
        using (SqlConnection connection = ketNoi.OpenConnection())
        {

            using (SqlCommand command = new SqlCommand(@"
            SELECT 
                NV.Id,
                COUNT(DISTINCT NC.CongNgay) AS SoNgayCong,
                SUM(NC.GioLamThem) AS SoGioLamThem
            FROM 
                NhanVien NV
            LEFT JOIN 
                NgayCong NC ON NV.Id = NC.IdNhanVien
            WHERE 
                NV.MaNhanVien = @MaNhanVien AND
                MONTH(NC.CongNgay) = @Thang AND YEAR(NC.CongNgay) = @Nam
            GROUP BY 
                NV.Id", connection))
            {
                command.Parameters.AddWithValue("@MaNhanVien", manv.Text);
                command.Parameters.AddWithValue("@Thang", thang.SelectedItem.Text);
                command.Parameters.AddWithValue("@Nam", nam.Text);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int idNhanVien = reader.GetInt32(0);
                        int soNgayCong = reader.GetInt32(1);
                        int soGioLamThem = reader.GetInt32(2);


                        cong.Text = soNgayCong.ToString();
                        them.Text = soGioLamThem.ToString();
                    }
                }
            }


        }



        using (SqlConnection connection = ketNoi.OpenConnection())
        {

            using (SqlCommand command = new SqlCommand(@"
            SELECT 
                NV.Id,
                COUNT(DISTINCT NC.NgayNghi) AS SoNgayNghi
            FROM 
                NhanVien NV
            LEFT JOIN 
                NgayCong NC ON NV.Id = NC.IdNhanVien
            WHERE 
                NV.MaNhanVien = @MaNhanVien AND
                MONTH(NC.NgayNghi) = @Thang AND YEAR(NC.NgayNghi) = @Nam
            GROUP BY 
                NV.Id", connection))
            {
                command.Parameters.AddWithValue("@MaNhanVien", manv.Text);
                command.Parameters.AddWithValue("@Thang", thang.SelectedItem.Text);
                command.Parameters.AddWithValue("@Nam", nam.Text);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int idNhanVien = reader.GetInt32(0);
                        int soNgayNghi = reader.GetInt32(1);


                        nghi.Text = soNgayNghi.ToString();
                    }
                }
            }


        }
    }

    protected void tinhluong_Click(object sender, EventArgs e)
    {
        using (SqlConnection connection = ketNoi.OpenConnection())
        {


            using (SqlCommand command = new SqlCommand(@"
                    SELECT TL.LuongCong, TL.PhuCap, BH.TienBaoHiem
                    FROM NhanVien NV
                    JOIN TienLuong TL ON NV.IdTienLuong = TL.Id
                    LEFT JOIN BaoHiem BH ON NV.Id = BH.IdNhanVien
                    WHERE NV.MaNhanVien = @MaNhanVien", connection))
            {
                command.Parameters.AddWithValue("@MaNhanVien", manv.Text);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        decimal luongCong = 0;
                        decimal phuCap = 0;
                        decimal baoHiem = 0;

                        int luongCongIndex = reader.GetOrdinal("LuongCong");
                        if (!reader.IsDBNull(luongCongIndex))
                        {
                            luongCong = Convert.ToDecimal(reader[luongCongIndex]);
                        }

                        int phuCapIndex = reader.GetOrdinal("PhuCap");
                        if (!reader.IsDBNull(phuCapIndex))
                        {
                            phuCap = Convert.ToDecimal(reader[phuCapIndex]);
                        }

                        int baoHiemIndex = reader.GetOrdinal("TienBaoHiem");
                        if (!reader.IsDBNull(baoHiemIndex))
                        {
                            baoHiem = Convert.ToDecimal(reader[baoHiemIndex]);
                        }

                        // Other variables you need for calculation
                        int soNgayCong = int.Parse(cong.Text);
                        decimal khenThuong = decimal.Parse(kt.Text);
                        decimal kiLuat = decimal.Parse(kl.Text);
                        decimal gioThem = decimal.Parse(them.Text);
                        // Your existing code to calculate the salary
                        decimal salary = (luongCong * soNgayCong) + phuCap + khenThuong - kiLuat - baoHiem + gioThem * (100000);

                        // Display the result in textBox11
                        tong.Text = salary.ToString();
                    }
                }
            }
        }
    }

    protected void dskt1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedRowIndex = dskt1.SelectedRow.RowIndex;
        GridViewRow selectedRow = dskt1.Rows[selectedRowIndex];
        string stkt1 = Server.HtmlDecode(selectedRow.Cells[2].Text);
        stkt.Text = stkt1;
        ModalPopupExtender2.Show();
    }

    protected void dskl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedRowIndex = dskl1.SelectedRow.RowIndex;
        GridViewRow selectedRow = dskl1.Rows[selectedRowIndex];
        string stkl1 = Server.HtmlDecode(selectedRow.Cells[2].Text);
        stkl.Text = stkl1;
        ModalPopupExtender3.Show();
    }

    protected void stkt_TextChanged(object sender, EventArgs e) { }

    protected void slkt_TextChanged(object sender, EventArgs e)
    {
        int soLan;
        decimal soTien, tongTien;

        if (decimal.TryParse(stkt.Text, out soTien) && int.TryParse(slkt.Text, out soLan))
        {
            tongTien = soTien * soLan;
            tkt.Text = tongTien.ToString();
        }
        else
        {
            tkt.Text = "Dữ liệu không hợp lệ";
        }
        ModalPopupExtender2.Show();
    }

    protected void tbkt_Click(object sender, EventArgs e)
    {
        using (SqlConnection connection = ketNoi.OpenConnection())
        {
            using (SqlCommand command = new SqlCommand("SELECT Id FROM KhenThuong WHERE Tien = @Tien", connection))
            {
                command.Parameters.AddWithValue("@Tien", stkt.Text);
                var result = command.ExecuteScalar();
                if (result != null)
                {
                    idKhenThuong = Convert.ToInt32(result);
                }
            }
            using (SqlCommand command = new SqlCommand("SELECT Id FROM NhanVien WHERE MaNhanVien = @mnv", connection))
            {
                command.Parameters.AddWithValue("@mnv", manv.Text);
                var result = command.ExecuteScalar();
                if (result != null)
                {
                    idNhanVien = Convert.ToInt32(result);
                }
            }
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM KhenThuong_NhanVien WHERE IdKhenThuong = @idKhenThuong AND IdNhanVien = @idNhanVien", connection))
            {
                cmd.Parameters.AddWithValue("@idKhenThuong", idKhenThuong);
                cmd.Parameters.AddWithValue("@idNhanVien", idNhanVien);

                int count = (int)cmd.ExecuteScalar();

                if (count > Convert.ToInt32(slkt.Text))
                {
                    count = Convert.ToInt32(slkt.Text);
                }

                cmd.CommandText = "DELETE TOP (@count) FROM KhenThuong_NhanVien WHERE IdKhenThuong = @idKhenThuong AND IdNhanVien = @idNhanVien";
                cmd.Parameters.AddWithValue("@count", count);

                cmd.ExecuteNonQuery();
            }
        }
        decimal tiensanco = 0, tientrubot = 0;
        if (!decimal.TryParse(tsckt.Text, out tiensanco))
        {
            tiensanco = 0;
        }
        if (!decimal.TryParse(tkt.Text, out tientrubot))
        {
            tientrubot = 0;
        }
        kt.Text = (tiensanco - tientrubot).ToString();
    }

    protected void slkl_TextChanged(object sender, EventArgs e)
    {
        int soLan;
        decimal soTien, tongTien;

        if (decimal.TryParse(stkl.Text, out soTien) && int.TryParse(slkl.Text, out soLan))
        {
            tongTien = soTien * soLan;
            tkl.Text = tongTien.ToString();
        }
        else
        {
            tkl.Text = "Dữ liệu không hợp lệ";
        }
        ModalPopupExtender3.Show();
    }

    protected void tbkl_Click(object sender, EventArgs e)
    {
        using (SqlConnection connection = ketNoi.OpenConnection())
        {
            using (SqlCommand command = new SqlCommand("SELECT Id FROM KiLuat WHERE Tien = @Tien", connection))
            {
                command.Parameters.AddWithValue("@Tien", stkl.Text);
                var result = command.ExecuteScalar();
                if (result != null)
                {
                    idKiLuat = Convert.ToInt32(result);
                }
            }
            using (SqlCommand command = new SqlCommand("SELECT Id FROM NhanVien WHERE MaNhanVien = @mnv", connection))
            {
                command.Parameters.AddWithValue("@mnv", manv.Text);
                var result = command.ExecuteScalar();
                if (result != null)
                {
                    idNhanVien = Convert.ToInt32(result);
                }
            }
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM KiLuat_NhanVien WHERE IdKiLuat = @idKiLuat AND IdNhanVien = @idNhanVien", connection))
            {
                cmd.Parameters.AddWithValue("@idKiLuat", idKiLuat);
                cmd.Parameters.AddWithValue("@idNhanVien", idNhanVien);

                int count = (int)cmd.ExecuteScalar();

                if (count > Convert.ToInt32(slkl.Text))
                {
                    count = Convert.ToInt32(slkl.Text);
                }

                cmd.CommandText = "DELETE TOP (@count) FROM KiLuat_NhanVien WHERE IdKiLuat = @idKiLuat AND IdNhanVien = @idNhanVien";
                cmd.Parameters.AddWithValue("@count", count);

                cmd.ExecuteNonQuery();
            }


        }
        decimal tiensanco = 0, tientrubot = 0;
        if (!decimal.TryParse(tsckl.Text, out tiensanco))
        {
            tiensanco = 0;
        }
        if (!decimal.TryParse(tkl.Text, out tientrubot))
        {
            tientrubot = 0;
        }
        kl.Text = (tiensanco - tientrubot).ToString();
    }

    protected void themluong_Click(object sender, EventArgs e)
    {
        using (SqlConnection connection = ketNoi.OpenConnection())
        {
            using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM LuongThang WHERE Thang = @T AND Nam = @N AND MaNhanVien = @MaNV", connection))
            {
                command.Parameters.AddWithValue("@T", thang.SelectedItem.ToString());
                command.Parameters.AddWithValue("@N", nam.Text);
                command.Parameters.AddWithValue("@MaNV", manv.Text);


                int existingRowCount = (int)command.ExecuteScalar();

                if (existingRowCount > 0)
                {
                    // Dữ liệu đã tồn tại, thực hiện cập nhật
                    using (SqlCommand updateCommand = new SqlCommand("UPDATE LuongThang SET  TongLuong = @TL WHERE Thang = @T AND Nam = @N AND MaNhanVien = @MaNV", connection))
                    {
                        updateCommand.Parameters.AddWithValue("@MaNV", manv.Text);

                        updateCommand.Parameters.AddWithValue("@TL", tong.Text);
                        updateCommand.Parameters.AddWithValue("@T", thang.SelectedItem.ToString());
                        updateCommand.Parameters.AddWithValue("@N", nam.Text);

                        updateCommand.ExecuteNonQuery();
                    }
                }
                else
                {
                    // Dữ liệu chưa tồn tại, thực hiện thêm mới
                    using (SqlCommand insertCommand = new SqlCommand("INSERT INTO LuongThang (MaNhanVien, TongLuong, Thang, Nam) VALUES (@MaNV, @TL, @T, @N)", connection))
                    {
                        insertCommand.Parameters.AddWithValue("@MaNV", manv.Text);
                        insertCommand.Parameters.AddWithValue("@TL", tong.Text);
                        insertCommand.Parameters.AddWithValue("@T", thang.SelectedItem.ToString());
                        insertCommand.Parameters.AddWithValue("@N", nam.Text);

                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
        }
        Page_Load(sender, e);
    }

    protected void moi_Click(object sender, EventArgs e)
    {
        foreach (System.Web.UI.Control control in Page.Controls)
        {
            ClearTextBoxes(control);
        }
    }

    private void ClearTextBoxes(System.Web.UI.Control control)
    {
        foreach (System.Web.UI.Control c in control.Controls)
        {
            if (c is TextBox)
            {
                ((TextBox)c).Text = string.Empty;
            }
            else
            {
                ClearTextBoxes(c);
            }
        }
    }
    private DataTable GetDataFromDatabase()
    {
        DataTable dt = new DataTable();
        string query = "SELECT LuongThang.MaNhanVien, Users.HoTen, LuongThang.TongLuong, LuongThang.Thang, LuongThang.Nam " +
                       "FROM LuongThang " +
                       "INNER JOIN NhanVien ON LuongThang.MaNhanVien = NhanVien.MaNhanVien " +
                       "INNER JOIN Users ON NhanVien.IdUser = Users.Id";

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

    protected void excel_Click(object sender, EventArgs e)
    {
        DataTable dt = GetDataFromDatabase();
        ExportToExcel(dt);
    }



    protected void ctkl_Click(object sender, EventArgs e)
    {
        using (SqlConnection connection = ketNoi.OpenConnection())
        {
            using (SqlCommand command = new SqlCommand("SELECT Id FROM KiLuat WHERE Tien = @Tien", connection))
            {
                command.Parameters.AddWithValue("@Tien", stkl.Text);
                var result = command.ExecuteScalar();
                if (result != null)
                {
                    idKiLuat = Convert.ToInt32(result);
                }
            }
            using (SqlCommand command = new SqlCommand("SELECT Id FROM NhanVien WHERE MaNhanVien = @mnv", connection))
            {
                command.Parameters.AddWithValue("@mnv", manv.Text);
                var result = command.ExecuteScalar();
                if (result != null)
                {
                    idNhanVien = Convert.ToInt32(result);
                }
            }
            using (SqlCommand cmd = new SqlCommand("INSERT INTO KiLuat_NhanVien (IdKiLuat, IdNhanVien) VALUES (@idKiLuat, @idNhanVien)", connection))
            {
                cmd.Parameters.AddWithValue("@idKiLuat", idKiLuat);
                cmd.Parameters.AddWithValue("@idNhanVien", idNhanVien);

                for (int i = 0; i < Convert.ToInt32(slkl.Text); i++)
                {
                    cmd.ExecuteNonQuery();
                }
            }

        }
        decimal tiensanco = 0, tiencongthem = 0;
        if (!decimal.TryParse(tsckl.Text, out tiensanco))
        {
            tiensanco = 0;
        }
        if (!decimal.TryParse(tkl.Text, out tiencongthem))
        {
            tiencongthem = 0;
        }
        kl.Text = (tiensanco + tiencongthem).ToString();
    }

    protected void ctkt_Click(object sender, EventArgs e)
    {
        using (SqlConnection connection = ketNoi.OpenConnection())
        {
            using (SqlCommand command = new SqlCommand("SELECT Id FROM KhenThuong WHERE Tien = @Tien", connection))
            {
                command.Parameters.AddWithValue("@Tien", stkt.Text);
                var result = command.ExecuteScalar();
                if (result != null)
                {
                    idKhenThuong = Convert.ToInt32(result);
                }
            }
            using (SqlCommand command = new SqlCommand("SELECT Id FROM NhanVien WHERE MaNhanVien = @mnv", connection))
            {
                command.Parameters.AddWithValue("@mnv", manv.Text);
                var result = command.ExecuteScalar();
                if (result != null)
                {
                    idNhanVien = Convert.ToInt32(result);
                }
            }
            using (SqlCommand cmd = new SqlCommand("INSERT INTO KhenThuong_NhanVien (IdKhenThuong, IdNhanVien) VALUES (@idKhenThuong, @idNhanVien)", connection))
            {
                cmd.Parameters.AddWithValue("@idKhenThuong", idKhenThuong);
                cmd.Parameters.AddWithValue("@idNhanVien", idNhanVien);

                for (int i = 0; i < Convert.ToInt32(slkt.Text); i++)
                {
                    cmd.ExecuteNonQuery();
                }
            }

        }
        decimal tiensanco = 0, tiencongthem = 0;
        if (!decimal.TryParse(tsckt.Text, out tiensanco))
        {
            tiensanco = 0;
        }
        if (!decimal.TryParse(tkt.Text, out tiencongthem))
        {
            tiencongthem = 0;
        }
        kt.Text = (tiensanco + tiencongthem).ToString();
    }
}