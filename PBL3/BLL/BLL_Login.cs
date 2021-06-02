using PBL3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.BLL
{
    class BLL_Login
    {
            MVH_08Entities db = new MVH_08Entities();

            private static BLL_Login _Instance;
            public static BLL_Login Instance
            {
                get
                {
                    if (_Instance == null)
                    {
                        _Instance = new BLL_Login();
                    }
                    return _Instance;
                }
                private set { }
            }
            private BLL_Login()
            {

            }
            public bool Check_account(string user, string pass)
            {
                TaiKhoan x = new TaiKhoan();
                x = db.TaiKhoans.Where(p => p.TenDangNhap == user && p.MatKhau == pass).FirstOrDefault();
                if (x == null)
                {
                    return false;
                }
                {
                    return true;
                }
            }
            public string Role(string user)
            {
                var x = db.TaiKhoans.Where(p => p.TenDangNhap == user).Select(p => p.Chucvu).ToString();
                return x;
            }
        public string GetIDNguoiDung_tdn(string tendangnhap)
        {
            var result = db.TaiKhoans.Where(p => p.TenDangNhap == tendangnhap).Select(p => p.IDNguoiDung).FirstOrDefault();
            return result;
        }
        public string GetTenNguoiDung(string IDNguoiDung)
        {
            var result = db.ThongTinNguoiDungs.Where(p => p.IDNguoiDung == IDNguoiDung).Select(p => p.TenNguoiDung).FirstOrDefault();
            return result;
        }
        public string GetIDNguoiDung_tnd(string TenNguoiDung)
        {
            var result = db.ThongTinNguoiDungs.Where(p => p.TenNguoiDung == TenNguoiDung).Select(p => p.IDNguoiDung).FirstOrDefault();
            return result;
        }
        public string GetChucVu_IDNguoiDung(string IDNguoiDung)
        {
            var result = db.TaiKhoans.Where(p => p.IDNguoiDung == IDNguoiDung).Select(p => p.Chucvu).FirstOrDefault();
            return result;
        }
    }
}
