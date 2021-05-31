using PBL3.DAL;
using PBL3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.BLL
{
    class BLL_Setting
    {
        MVH_08Entities db = new MVH_08Entities();

        private static BLL_Setting _Instance;
        public static BLL_Setting Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_Setting();
                }
                return _Instance;
            }
            private set { }
        }
        private BLL_Setting()
        {

        }
        public List<MonAn> LoadMenuFood()
        {
            List<MonAn> result = new List<MonAn>();
            result = db.MonAns.Where(p => p.IDDanhMuc == "doan").ToList();
            return result;
        }
        public List<MonAn> LoadMenuDrink()
        {
            List<MonAn> result = new List<MonAn>();
            result = db.MonAns.Where(p => p.IDDanhMuc == "douong").ToList();
            return result;
        }
        public MonAn GetMonAn_IDMon(string IDMon)
        {
            MonAn result = new MonAn();
            result = db.MonAns.Where(p => p.IDMon == IDMon).FirstOrDefault();
            return result;
        }
        public List<DatMon> GetDatMon_IDMon(string IDMon)
        {
            List<DatMon> result = new List<DatMon>();
            result = db.DatMons.Where(p => p.IDMon == IDMon).ToList();
            return result;
        }
        public List<DatMon> GetDatMon_IDHoaDon(string IDHoaDon)
        {
            List<DatMon> result = new List<DatMon>();
            result = db.DatMons.Where(p => p.IDHoaDon == IDHoaDon).ToList();
            return result;
        }
        public List<HoaDon> GetListHoaDon()
        {
            List<HoaDon> result = db.HoaDons.Select(p => p).ToList();
            return result;
        }
        public void Delete_DatMon_IDDatMon(string IDDatMon)
        {
            var datmon = db.DatMons.Where(p => p.IDDatMon == IDDatMon).FirstOrDefault();
            var result = db.DatMons.Remove(datmon);
            db.SaveChanges();
        }
        public int maxIdDA(List<MonAn> listMonAn)
        {
            int max = 0;
            foreach (MonAn mon in listMonAn)
            {
                int indexMon = Convert.ToInt32(mon.IDMon.Substring(4));
                if (max < indexMon) max = indexMon;
            }

            return max;
        }
        public int maxIdDU(List<MonAn> listMonAn)
        {
            int max = 0;
            foreach (MonAn mon in listMonAn)
            {
                int indexMon = Convert.ToInt32(mon.IDMon.Substring(6));
                if (max < indexMon) max = indexMon;
            }

            return max;
        }
        public List<MonAn> AddMenuFoodWithEmptyRow()
        {
            List<MonAn> listMonAn = db.MonAns.Where(p => p.IDMon.Contains("doan")).OrderBy(p => p.IDMon).ToList();
            string newRowIdMon = "doan" + (maxIdDA(listMonAn) + 1);
            listMonAn.Add(
                new MonAn()
                {
                    IDMon = newRowIdMon,
                    IDDanhMuc = "doan",
                    TenMon = "",
                    Gia = null,
                    DanhMuc = null,
                    DatMons = null
                });
            return listMonAn;
        }
        public List<MonAn> AddMenuDrinkWithEmptyRow()
        {
            List<MonAn> listDouong = (db.MonAns.Where(p => p.IDMon.Contains("douong")).ToList());
            string lastIdMon = listDouong.ToArray()[listDouong.Count - 1].IDMon;
            string newRowIdMon = "douong" + (maxIdDU(listDouong) + 1);
            listDouong.Add(
                new MonAn()
                {
                    IDMon = newRowIdMon,
                    IDDanhMuc = "douong",
                    TenMon = "",
                    Gia = null,
                    DanhMuc = null,
                    DatMons = null
                });
            return listDouong;
        }
        public List<joinTK> Loadtt(string cbb)
        {
            List<joinTK> list = new List<joinTK>();
            var result = (from tt in db.ThongTinNguoiDungs
                          join tk in db.TaiKhoans on tt.IDNguoiDung equals tk.IDNguoiDung
                          select new
                          {
                              tt.IDNguoiDung,
                              tt.TenNguoiDung,
                              tt.GioiTinh,
                              tt.NgaySinh,
                              tt.PhoneNumber,
                              tk.TenDangNhap,
                              tk.MatKhau,
                              tk.Chucvu,
                          }).ToList();
            if (cbb == "All")
            {
                foreach (var i in result)
                {
                    joinTK j = new joinTK();
                    //if (i.Chucvu == cbb)
                    {
                        j.IDNguoiDung = i.IDNguoiDung;
                        j.TenNguoiDung = i.TenNguoiDung;
                        j.GioiTinh = i.GioiTinh;
                        j.NgaySinh = (DateTime)i.NgaySinh;
                        j.PhoneNumber = i.PhoneNumber;
                        j.TenDangNhap = i.TenDangNhap;
                        j.MatKhau = i.MatKhau;
                        j.Chucvu = i.Chucvu;
                        list.Add(j);
                    }
                }
            }
            else
            {
                foreach (var i in result)
                {
                    joinTK j = new joinTK();
                    if (i.Chucvu == cbb)
                    {
                        j.IDNguoiDung = i.IDNguoiDung;
                        j.TenNguoiDung = i.TenNguoiDung;
                        j.GioiTinh = i.GioiTinh;
                        j.NgaySinh = (DateTime)i.NgaySinh;
                        j.PhoneNumber = i.PhoneNumber;
                        j.TenDangNhap = i.TenDangNhap;
                        j.MatKhau = i.MatKhau;
                        j.Chucvu = i.Chucvu;
                        list.Add(j);
                    }
                }
            }
            return list;
        }
        public bool checkID(string id)
        {
            List<ThongTinNguoiDung> list = new List<ThongTinNguoiDung>();
            list = load();
            foreach (ThongTinNguoiDung i in list)
            {
                if (i.IDNguoiDung == id)
                    return false;
            }
            return true;

        }
        public bool ktsdtt(string sdt)
        {
            if (sdt.Length == 10)
            {
                return true;
            }
            else return false;
        }
        public bool ktsdt(string sdt)
        {
            foreach (Char c in sdt)
            {
                if (!Char.IsDigit(c))
                    return true;
            }
            return false;
        }
        public List<ThongTinNguoiDung> load()
        {
            List<ThongTinNguoiDung> litt = new List<ThongTinNguoiDung>();
            List<ThongTinNguoiDung> thongTins = db.ThongTinNguoiDungs.Select(p => p).ToList();
            litt = thongTins;
            return litt;
        }
        public List<joinTK> TimNV_BLL(string nv)
        {
            var result = (from tt in db.ThongTinNguoiDungs
                          join tk in db.TaiKhoans on tt.IDNguoiDung equals tk.IDNguoiDung
                          where (tt.TenNguoiDung.Contains(nv))
                          select new joinTK
                          {
                              IDNguoiDung = tt.IDNguoiDung,
                              TenNguoiDung = tt.TenNguoiDung,
                              GioiTinh = tt.GioiTinh,
                              NgaySinh = (DateTime)tt.NgaySinh,
                              PhoneNumber = tt.PhoneNumber,
                              TenDangNhap = tk.TenDangNhap,
                              MatKhau = tk.MatKhau,
                              Chucvu = tk.Chucvu,
                          });
            return result.ToList();
        }
        public ThongTinNguoiDung TimNguoiDung(string ID)
        {
            foreach (ThongTinNguoiDung i in db.ThongTinNguoiDungs.ToList())
            {
                if (i.IDNguoiDung == ID)
                    return i;
            }
            return null;
        }
        public HoaDon timid(string id)
        {
            foreach (HoaDon i in db.HoaDons.ToList())
            {
                if (i.IDNguoiDung == id)
                {
                    i.IDNguoiDung = null;
                    //return i;
                }
            }
            return null;
            db.SaveChanges();
        }
        public void Xoa_BLL(ThongTinNguoiDung nd, TaiKhoan tk)
        {
            db.TaiKhoans.Remove(tk);
            db.SaveChanges();
            db.ThongTinNguoiDungs.Remove(nd);
            db.SaveChanges();
        }
        public TaiKhoan TimTaiKhoan(string ID)
        {
            foreach (TaiKhoan i in db.TaiKhoans.ToList())
            {
                if (i.IDNguoiDung == ID)
                    return i;
            }
            return null;
        }
        public ThongTinNguoiDung GetThongTinNguoiDung_IDNguoiDung(string IDNguoiDung)
        {
            ThongTinNguoiDung ttnd = db.ThongTinNguoiDungs.Where(p => p.IDNguoiDung == IDNguoiDung).FirstOrDefault();
            return ttnd;
        }
        public TaiKhoan GetTaiKhoan_IDNguoiDung(string IDNguoiDung)
        {
            TaiKhoan tk = db.TaiKhoans.Where(p => p.IDNguoiDung == IDNguoiDung).FirstOrDefault();
            return tk;
        }
        public void addStaff_BLL(ThongTinNguoiDung nd, TaiKhoan tk)
        {
            db.ThongTinNguoiDungs.Add(nd);
            //db.SaveChanges();
            db.TaiKhoans.Add(tk);
            db.SaveChanges();
        }
        public void update_BLL(string IDNguoiDung, string TenNguoiDung, bool GioiTinh, DateTime NgaySinh, string TenDangNhap, string MatKHau, string ChucVu)
        {
            var resultnd = db.ThongTinNguoiDungs.Where(p => p.IDNguoiDung == IDNguoiDung).FirstOrDefault();
            var resulttk = db.TaiKhoans.Where(p => p.IDNguoiDung == IDNguoiDung).FirstOrDefault();

            resultnd.TenNguoiDung = TenNguoiDung;
            resultnd.GioiTinh = GioiTinh;
            resultnd.NgaySinh = NgaySinh;

            resulttk.TenDangNhap = TenDangNhap;
            resulttk.MatKhau = MatKHau;
            resulttk.Chucvu = ChucVu;
            db.SaveChanges();


        }
        public List<joinTK> SortName(string cbb)
        {
            {
                List<joinTK> list = new List<joinTK>();
                var result = (from tt in db.ThongTinNguoiDungs
                              join tk in db.TaiKhoans on tt.IDNguoiDung equals tk.IDNguoiDung
                              orderby tt.TenNguoiDung ascending
                              select new
                              {
                                  tt.IDNguoiDung,
                                  tt.TenNguoiDung,
                                  tt.GioiTinh,
                                  tt.NgaySinh,
                                  tt.PhoneNumber,
                                  tk.TenDangNhap,
                                  tk.MatKhau,
                                  tk.Chucvu,
                              }).ToList();
                if (cbb == "All")
                {
                    foreach (var i in result)
                    {
                        joinTK j = new joinTK();
                        //if (i.Chucvu == cbb)
                        {
                            j.IDNguoiDung = i.IDNguoiDung;
                            j.TenNguoiDung = i.TenNguoiDung;
                            j.GioiTinh = i.GioiTinh;
                            j.NgaySinh = (DateTime)i.NgaySinh;
                            j.PhoneNumber = i.PhoneNumber;
                            j.TenDangNhap = i.TenDangNhap;
                            j.MatKhau = i.MatKhau;
                            j.Chucvu = i.Chucvu;
                            list.Add(j);
                        }
                    }
                }
                else
                {
                    foreach (var i in result)
                    {
                        joinTK j = new joinTK();
                        if (i.Chucvu == cbb)
                        {
                            j.IDNguoiDung = i.IDNguoiDung;
                            j.TenNguoiDung = i.TenNguoiDung;
                            j.GioiTinh = i.GioiTinh;
                            j.NgaySinh = (DateTime)i.NgaySinh;
                            j.PhoneNumber = i.PhoneNumber;
                            j.TenDangNhap = i.TenDangNhap;
                            j.MatKhau = i.MatKhau;
                            j.Chucvu = i.Chucvu;
                            list.Add(j);
                        }
                    }
                }
                return list;
            }
        }
        public bool sosanhIDtt(string idtt)
        {
            List<string> list;
            list = db.ThongTinNguoiDungs.Select(p => p.IDNguoiDung).ToList();
            foreach (string i in list)
            {
                if (i == idtt)
                    return true;
            }
            return false;

        }
        public bool sosanhIDtk(string idtk)
        {
            List<string> list;
            list = db.TaiKhoans.Select(p => p.IDNguoiDung).ToList();
            foreach (string i in list)
            {
                if (i == idtk)
                    return false;
            }
            return true;
        }
        public List<joinTK> SortNameLogin(string cbb)
        {
            {
                List<joinTK> list = new List<joinTK>();
                var result = (from tt in db.ThongTinNguoiDungs
                              join tk in db.TaiKhoans on tt.IDNguoiDung equals tk.IDNguoiDung
                              orderby tk.TenDangNhap ascending
                              select new
                              {
                                  tt.IDNguoiDung,
                                  tt.TenNguoiDung,
                                  tt.GioiTinh,
                                  tt.NgaySinh,
                                  tt.PhoneNumber,
                                  tk.TenDangNhap,
                                  tk.MatKhau,
                                  tk.Chucvu,
                              }).ToList();
                if (cbb == "All")
                {
                    foreach (var i in result)
                    {
                        joinTK j = new joinTK();
                        //if (i.Chucvu == cbb)
                        {
                            j.IDNguoiDung = i.IDNguoiDung;
                            j.TenNguoiDung = i.TenNguoiDung;
                            j.GioiTinh = i.GioiTinh;
                            j.NgaySinh = (DateTime)i.NgaySinh;
                            j.PhoneNumber = i.PhoneNumber;
                            j.TenDangNhap = i.TenDangNhap;
                            j.MatKhau = i.MatKhau;
                            j.Chucvu = i.Chucvu;
                            list.Add(j);
                        }
                    }
                }
                else
                {
                    foreach (var i in result)
                    {
                        joinTK j = new joinTK();
                        if (i.Chucvu == cbb)
                        {
                            j.IDNguoiDung = i.IDNguoiDung;
                            j.TenNguoiDung = i.TenNguoiDung;
                            j.GioiTinh = i.GioiTinh;
                            j.NgaySinh = (DateTime)i.NgaySinh;
                            j.PhoneNumber = i.PhoneNumber;
                            j.TenDangNhap = i.TenDangNhap;
                            j.MatKhau = i.MatKhau;
                            j.Chucvu = i.Chucvu;
                            list.Add(j);
                        }
                    }
                }
                return list;
            }
        }
    }
}
