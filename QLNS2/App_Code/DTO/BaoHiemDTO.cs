using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS2.DTO
{
    public class BaoHiemDTO
    {
        public int Id { get; set; }
        public DateTime NgayCap { get; set; }
        public string NoiCap { get; set; }
        public string GhiChu { get; set; }
        public int TienBaoHiem { get; set; }
        public int IdNhanVien { get; set; }
    }
}
