using QLNS2;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HopDongDAL
/// </summary>
public class HopDongDAL
{

    ConnectDB.KetNoi kn = new ConnectDB.KetNoi();
    SqlConnection connection = null;
    SqlDataReader reader = null;
    SqlCommand cmd = null;
    SqlDataAdapter adapter = null;
    public int AddHopDong(string LoaiHopDong, string NgayBatDau, string NgayKetThuc)
    {
        int IdHopDong;
        try
        {
            using (connection = kn.OpenConnection())
            {
                string query = "INSERT INTO HopDong(LoaiHopDong ,NgayBatDau ,NgayKetThuc)"
                              + "VALUES (@LoaiHopDong,@NgayBatDau ,@NgayKetThuc)"
                              + "SELECT SCOPE_IDENTITY() AS IdHopDonh";
                using (cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@LoaiHopDong", LoaiHopDong);
                    cmd.Parameters.AddWithValue("@NgayBatDau", NgayBatDau);
                    cmd.Parameters.AddWithValue("@NgayKetThuc", NgayKetThuc);
                    IdHopDong = Convert.ToInt32(cmd.ExecuteScalar());
                    return IdHopDong;
                }
            }

        }
        catch (Exception e)
        {
            /*            MessageBox.Show(e.Message);
            */
            return -1;
        }

    }

    //Sua hop dong
    public void SuaHopDong(string LoaiHopDong, string NgayBatDau, string NgayKetThuc, string IdHopDong)
    {
        try
        {
            using (connection = kn.OpenConnection())
            {
                string query = "UPDATE HopDong SET NgayBatDau = @NgayBatDau ,NgayKetThuc=@NgayKetThuc ,LoaiHopDong=@LoaiHopDong WHERE HopDong.Id=@IdHopDong ";
                using (cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@LoaiHopDong", LoaiHopDong);
                    cmd.Parameters.AddWithValue("@NgayBatDau", NgayBatDau);
                    cmd.Parameters.AddWithValue("@NgayKetThuc", NgayKetThuc);
                    cmd.Parameters.AddWithValue("@IdHopDong", IdHopDong);

                    cmd.ExecuteNonQuery();

                }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khi SuaHopDong: " + ex.Message);
            throw new Exception("Error in SuaHopDong: " + ex.Message, ex);
        }

    }
}
