using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLNS2;
using static QLNS2.ConnectDB;

public partial class FormKT_KL : System.Web.UI.Page
{
    KetNoi ketNoi = new KetNoi();
    protected void Page_Load(object sender, EventArgs e)
    {
        using (SqlConnection connection = ketNoi.OpenConnection())
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * From KhenThuong", connection))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                bangkt.DataSource = dt;
                bangkt.DataBind();
            }
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * From KiLuat", connection))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                bangkl.DataSource = dt;
                bangkl.DataBind();
            }
        }
    }

    protected void themkt_Click(object sender, EventArgs e)
    {
        using (SqlConnection connection = ketNoi.OpenConnection())
        {

            using (SqlCommand command = new SqlCommand("INSERT INTO KhenThuong (KhenThuong, Tien) VALUES (@LiDo, @Tien )", connection))
            {

                command.Parameters.AddWithValue("@Tien", tienkt.Text);
                command.Parameters.AddWithValue("@LiDo", lidokt.Text);
                command.ExecuteNonQuery();
            }
        }
        Page_Load(sender, e);
    }

    protected void xoakt_Click(object sender, EventArgs e)
    {
        using (SqlConnection connection = ketNoi.OpenConnection())
        {

            using (SqlCommand command = new SqlCommand("DELETE FROM KhenThuong WHERE Id = @MaKhenThuong", connection))
            {
                command.Parameters.AddWithValue("@MaKhenThuong", makt.Text);
                command.ExecuteNonQuery();
            }
        }
        Page_Load(sender, e);
    }

    protected void suakt_Click(object sender, EventArgs e)
    {
        using (SqlConnection connection = ketNoi.OpenConnection())
        {

            using (SqlCommand command = new SqlCommand("UPDATE KhenThuong SET Tien = @Tien, KhenThuong = @LiDo WHERE Id = @MaKhenThuong", connection))
            {
                command.Parameters.AddWithValue("@MaKhenThuong", makt.Text);
                command.Parameters.AddWithValue("@Tien", tienkt.Text);
                command.Parameters.AddWithValue("@LiDo", lidokt.Text);
                command.ExecuteNonQuery();
            }
        }
        Page_Load(sender, e);
    }

    protected void bangkt_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Lấy chỉ số của hàng được chọn
        int selectedRowIndex = bangkt.SelectedRow.RowIndex;
        // Lấy hàng được chọn
        GridViewRow selectedRow = bangkt.Rows[selectedRowIndex];

        // Lấy dữ liệu từ các ô trong hàng được chọn
        string idkt = Server.HtmlDecode(selectedRow.Cells[1].Text); // Giả sử cột Id ở vị trí đầu tiên
        string tienktt = Server.HtmlDecode(selectedRow.Cells[2].Text);
        string lidoktt = Server.HtmlDecode(selectedRow.Cells[3].Text);

        makt.Text = idkt;
        tienkt.Text = tienktt;
        lidokt.Text = lidoktt;
    }

    protected void themkl_Click(object sender, EventArgs e)
    {
        using (SqlConnection connection = ketNoi.OpenConnection())
        {

            using (SqlCommand command = new SqlCommand("INSERT INTO KiLuat (KiLuat, Tien) VALUES (@LiDo, @Tien )", connection))
            {

                command.Parameters.AddWithValue("@Tien", tienkl.Text);
                command.Parameters.AddWithValue("@LiDo", lidokl.Text);

                command.ExecuteNonQuery();
            }
        }
        Page_Load(sender, e);
    }

    protected void suakl_Click(object sender, EventArgs e)
    {
        using (SqlConnection connection = ketNoi.OpenConnection())
        {

            using (SqlCommand command = new SqlCommand("UPDATE KiLuat SET Tien = @Tien, KiLuat = @LiDo WHERE Id = @MaKiLuat", connection))
            {
                command.Parameters.AddWithValue("@MaKiLuat", makl.Text);
                command.Parameters.AddWithValue("@Tien", tienkl.Text);
                command.Parameters.AddWithValue("@LiDo", lidokl.Text);
                command.ExecuteNonQuery();
            }
            Page_Load(sender, e);
        }
    }

    protected void xoakl_Click(object sender, EventArgs e)
    {
        using (SqlConnection connection = ketNoi.OpenConnection())
        {

            using (SqlCommand command = new SqlCommand("DELETE FROM KiLuat WHERE Id = @MaKiLuat", connection))
            {
                command.Parameters.AddWithValue("@MaKiLuat", makl.Text);
                command.ExecuteNonQuery();
            }
            Page_Load(sender, e);
        }
    }

    protected void bangkl_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Lấy chỉ số của hàng được chọn
        int selectedRowIndex = bangkl.SelectedRow.RowIndex;
        // Lấy hàng được chọn
        GridViewRow selectedRow = bangkl.Rows[selectedRowIndex];

        // Lấy dữ liệu từ các ô trong hàng được chọn
        string idkl = Server.HtmlDecode(selectedRow.Cells[1].Text); // Giả sử cột Id ở vị trí đầu tiên
        string tienkll = Server.HtmlDecode(selectedRow.Cells[2].Text);
        string lidokll = Server.HtmlDecode(selectedRow.Cells[3].Text);

        makl.Text = idkl;
        tienkl.Text = tienkll;
        lidokl.Text = lidokll;
    }
}