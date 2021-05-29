using PBL3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.BLL
{
    class BLL_ManageBill
    {
        MVH_08Entities db = new MVH_08Entities();

        private static BLL_ManageBill _Instance;
        public static BLL_ManageBill Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_ManageBill();
                }
                return _Instance;
            }
            private set { }
        }
        private BLL_ManageBill()
        {
        }
        public List<string> GetListIDBan()
        {
            List<string> result;
            result = db.Bans.Select(p => p.IDBan).ToList();
            return result;
        }
        public List<HoaDon> LoadHoaDon()
        {
            List<HoaDon> result = new List<HoaDon>();
            result = db.HoaDons.Where(p => p.TrangThai == true).Select(p => p).ToList();
            return result;
        }
        public List<HoaDon> LoadHoaDon_IDBan(string IDBan)
        {
            List<HoaDon> result = new List<HoaDon>();
            result = (db.HoaDons.Where(p => p.IDBan == IDBan).ToList());
            return result;
        }
        public List<DatMon> GetDatMon_IDHoaDon(string IDHoaDon)
        {
            List<DatMon> result = new List<DatMon>();
            result = db.DatMons.Where(p => p.IDHoaDon == IDHoaDon).ToList();
            return result;
        }
        public void Delete_DatMon_IDDatMon(string IDDatMon)
        {
            var datmon = db.DatMons.Where(p => p.IDDatMon == IDDatMon).FirstOrDefault();
            var result = db.DatMons.Remove(datmon);
            db.SaveChanges();
        }
        public void Del_HoaDon(string IDHoaDon)
        {
            var result = db.HoaDons.Where(p => p.IDHoaDon == IDHoaDon).FirstOrDefault();
            var hoadon = db.HoaDons.Remove(result);
            db.SaveChanges();
        }
        public void Del_ThongTinHoaDon(string IDHoaDon)
        {
            List<ThongTinHoaDon> result = new List<ThongTinHoaDon>();
            result = db.ThongTinHoaDons.Where(p => p.IDHoaDon == IDHoaDon).ToList();
            var hoadon = db.ThongTinHoaDons.RemoveRange(result);
            db.SaveChanges();
        }
        public List<string> GetMonAn_IDHoaDon(string IDHoaDon)
        {
            List<string> result = new List<string>();
            result = db.DatMons.Where(p => p.IDHoaDon == IDHoaDon).Select(p => p.IDMon).ToList();
            return result;
        }
        public MonAn GetMonAn_IDMon(string IDMon)
        {
            MonAn result = new MonAn();
            result = db.MonAns.Where(p => p.IDMon == IDMon).Select(p => p).FirstOrDefault();
            return result;
        }
        public ThongTinNguoiDung GetThongTinNguoiDung_IDHoaDon(string IDHoaDon)
        {
            ThongTinNguoiDung result = new ThongTinNguoiDung();
            string d;
            d = db.HoaDons.Where(p => p.IDHoaDon == IDHoaDon).Select(p => p.IDNguoiDung).FirstOrDefault();
            result = db.ThongTinNguoiDungs.Where(p => p.IDNguoiDung == d).FirstOrDefault();
            return result;
        }
        public string GetIDNguoiDUng_IDHoaDon(string IDHoaDon)
        {
            string d;
            d = db.ThongTinHoaDons.Where(p => p.IDHoaDon == IDHoaDon).Select(p => p.IDNguoiDung).FirstOrDefault();
            return d;
        }
        public HoaDon GetHoaDon_IdHoaDon(string IDHoaDon)
        {
            HoaDon result = new HoaDon();
            result = db.HoaDons.Where(p => p.IDHoaDon == IDHoaDon).FirstOrDefault();
            return result;
        }
        public List<Ban> GetBan()
        {
            List<Ban> result;
            result = db.Bans.Select(p => p).ToList();
            return result;
        }
        public List<ThongTinHoaDon> GetThongTinHoaDon()
        {
            List<ThongTinHoaDon> result = new List<ThongTinHoaDon>();
            result = db.ThongTinHoaDons.Select(p => p).ToList();
            return result;
        }
        public List<ThongTinHoaDon> GetThongTinHoaDon_IDHoaDon(string IDHoaDon)
        {
            List<ThongTinHoaDon> result = db.ThongTinHoaDons.Where(p => p.IDHoaDon == IDHoaDon).ToList();
            return result;
        }
        public ThongTinHoaDon GetThongTinHoaDonz_IDHoaDon(string IDHoaDon)
        {
            ThongTinHoaDon result = db.ThongTinHoaDons.Where(p => p.IDHoaDon == IDHoaDon).FirstOrDefault();
            return result;
        }
        public List<HoaDon> GetHoaDon()
        {
            List<HoaDon> result;
            result = db.HoaDons.Select(p => p).ToList();
            return result;
        }
        public List<HoaDon> GetHoaDon_IDBan(string IDBan)
        {
            List<HoaDon> result;
            result = db.HoaDons.Where(p => p.IDBan == IDBan).ToList();
            return result;
        }
    }
}