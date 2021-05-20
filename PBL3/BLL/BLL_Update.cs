using PBL3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.BLL
{
    class BLL_Update
    {
        MVH_08Entities db = new MVH_08Entities();

        private static BLL_Update _Instance;
        public static BLL_Update Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_Update();
                }
                return _Instance;
            }
            private set { }
        }
        private BLL_Update()
        {

        }
        public void Status_Table(string IDTable,bool m)
        {
            var result = db.Bans.Where(p => p.IDBan == IDTable).FirstOrDefault();
            result.TrangThai = m;
            db.SaveChanges();
        }
        public void Update_HoaDon(string IDHoaDon, bool staus, DateTime NgayXuat, float Total, string IDNguoiDung, string IDCustomer)
        {
            var result = db.HoaDons.Where(p => p.IDHoaDon == IDHoaDon).FirstOrDefault();
            result.NgayXuat = NgayXuat;
            result.TrangThai = staus;
            result.TongTien = Total;
            result.IDNguoiDung = IDNguoiDung;
            result.IDCustommer = IDCustomer;
            db.SaveChanges();
        }
        public void SoLuong_DatMon(string IDDatMon, int SoLuong)
        {
            var result = db.DatMons.Where(p => p.IDDatMon == IDDatMon).FirstOrDefault();
            result.SoLuong = SoLuong;
            db.SaveChanges();
        }
        public void Delete_DatMon_IDDatMon(string IDDatMon)
        {
            var datmon = db.DatMons.Where(p => p.IDDatMon == IDDatMon).FirstOrDefault();
            var result = db.DatMons.Remove(datmon);
        }
        public void Update_Customer(string IDCustomer, string NameCustomer)
        {
            var result = db.Customers.Where(p => p.IDCustomer == IDCustomer).FirstOrDefault();
            result.IDCustomer = IDCustomer;
            result.NameCustomer = NameCustomer;
            result.Phone = IDCustomer;
        }
    }
}
