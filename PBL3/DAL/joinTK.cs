using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.DAL
{
    class joinTK
    {
        public string IDNguoiDung { get; set; }
        public string TenNguoiDung { get; set; }
        public bool? GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string PhoneNumber { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string Chucvu { get; set; }

        public joinTK() { }
    }
}
