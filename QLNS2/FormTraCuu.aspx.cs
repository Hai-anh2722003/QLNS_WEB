using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static QLNS2.ConnectDB;
using System.Data;

public partial class FormTraCuu : System.Web.UI.Page
{
    KetNoi ketNoi = new KetNoi();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (SqlConnection connection = ketNoi.OpenConnection())
            {

                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM CongTac where Congtac.Status = '1' ", connection))
                {
                    DataTable ct = new DataTable();
                    adapter.Fill(ct);
                    drlPB.DataSource = ct;
                    drlPB.DataBind();
                }

                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM ChucDanh where Chucdanh.Status = '1'", connection))
                {
                    DataTable cd = new DataTable();
                    adapter.Fill(cd);
                    drlCV.DataSource = cd;
                    drlCV.DataBind();
                }


                drlPB.DataTextField = "TenCongTac";
                drlPB.DataValueField = "Id";
                drlPB.DataBind();

                drlCV.DataTextField = "TenChucDanh";
                drlCV.DataValueField = "Id";
                drlCV.DataBind();


            }

        }

    }

    protected void btnTim_Click(object sender, EventArgs e)
    {
        using (SqlConnection connection = ketNoi.OpenConnection())
        {
            string tenNhanVien = txtTenNhanVien.Text.ToLower();
            string sql = @"SELECT NhanVien.MaNhanVien, Users.HoTen, Users.NgaySinh, Users.Email, Users.CMND, CongTac.TenCongTac, ChucDanh.TenChucDanh
                  FROM     Users INNER JOIN
                  NhanVien ON Users.Id = NhanVien.IdUser INNER JOIN
                  CongTac ON NhanVien.IdCongTac = CongTac.Id INNER JOIN
                  ChucDanh ON NhanVien.IdChucDanh = ChucDanh.Id";
            string st = " and NhanVien.Status='1'";
            string dk = "1=1";
            sql = string.Format(sql, tenNhanVien);
            if (txtTenNhanVien.Text.Trim() != "")
            {
                dk = dk + string.Format("and LOWER(REPLACE(HoTen, N' ', '')) like '%{0}%'", txtTenNhanVien.Text);
            }

            if (txtMaNhanVien.Text.Trim() != "")
            {
                dk = dk + string.Format("and MaNhanVien like '%{0}%'", txtMaNhanVien.Text);
            }

            if (txtCCCD.Text.Trim() != "")
            {
                dk = dk + string.Format("and CMND='{0}'", txtCCCD.Text);
            }

            if (drlCV.SelectedIndex >= 0)
            {
                dk = dk + string.Format("and ChucDanh.Id='{0}'", drlCV.SelectedValue);
            }
            if (drlPB.SelectedIndex >= 0)
            {
                dk = dk + string.Format("and CongTac.Id='{0}'", drlPB.SelectedValue);
            }

            sql = sql + " where " + dk + st;

            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connection))
            {

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                GV_TraCuu.AutoGenerateColumns = false;
                GV_TraCuu.DataSource = dt;
                GV_TraCuu.DataBind();
            }




        }

    }

    protected void btnLamMoi_Click(object sender, EventArgs e)
    {
        foreach (Control control in Page.Controls)
        {
            ClearTextBoxes(control);
        }

    }
    private void ClearTextBoxes(Control control)
    {
        foreach (Control c in control.Controls)
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

}