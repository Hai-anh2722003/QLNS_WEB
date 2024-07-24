using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NhanVienDTO
/// </summary>
public class NhanVienDTO
{

    public int IdUser { get; set; }
    public string HoTen { get; set; }
    public DateTime NgaySinh { get; set; }
    public string Email { get; set; }
    public string GioiTinh { get; set; }
    public string CMND { get; set; }
    public string DiaChi { get; set; }
    public string DangVien { get; set; }
    public string HocVan { get; set; }
    public int IdTienLuong { get; set; }
    public int IdChucDanh { get; set; }
    public int IdCongTac { get; set; }
    public string TenCongTac { get; set; }
    public string TenChucDanh { get; set; }
    public string LoaiHopDong { get; set; }
    public DateTime NgayBatDau { get; set; }
    public DateTime NgayKetThuc { get; set; }
    public string MaNhanVien { get; set; }

    public int IdNhanVien { get; set; }
    public string DuongDan { get; set; }
    public int IdHopDong { get; set; }

}
