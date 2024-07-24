using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TienLuongDTO
/// </summary>
namespace QLNS2.DTO
{
    public class TienLuongDTO
    {
        public int Id { get; set; }
        public int BacLuong { get; set; }
        public int HeSo { get; set; }
        public int PhuCap { get; set; }
        public int LuongCong { get; set; }
        public string GhiChu { get; set; }
    }
}
