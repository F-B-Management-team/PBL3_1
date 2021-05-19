using PBL3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.BLL
{
    class BLL_Order
    {
        MVH_08Entities db = new MVH_08Entities();

        private static BLL_Order _Instance;
        public static BLL_Order Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_Order();
                }
                return _Instance;
            }
            private set { }
        }
        private BLL_Order()
        {

        }
        public List<MonAn> LoadMenuFood()
        {
            List<MonAn> result = new List<MonAn>();
            result = (db.MonAns.Where(p => p.IDDanhMuc == "doan").ToList());
            return result;
        }
        public List<MonAn> LoadMenuDrink()
        {
            List<MonAn> result = new List<MonAn>();
            List<MonAn> monAns = db.MonAns.Where(p => p.IDDanhMuc == "douong").ToList();
            result = monAns;
            return result;
        }
        public List<string> GetListIDHoaDon_TO()
        {
            List<string> result;
            result = db.HoaDons.Where(p => p.IDHoaDon.StartsWith("TO")).OrderBy(p => p.IDHoaDon).Select(g => g.IDHoaDon).ToList();
            return result;
        }
        public List<string> GetListIDHoaDon_TI()
        {
            List<string> result;
            result = db.HoaDons.Where(p => p.IDHoaDon.StartsWith("TI")).OrderBy(p=> p.IDHoaDon).Select(p => p.IDHoaDon).ToList();
            return result;
        }
        public List<string> GetIDDatMon()
        {
            List<string> result;
            result = db.DatMons.OrderBy(p =>p.IDDatMon).Select(p => p.IDDatMon).ToList();
            return result;
        }
        public string GetIDHoaDon_IDTable(string IDTable)
        {
            string result;
            result = db.HoaDons.Where(p => p.IDBan == IDTable).Select(p => p.IDHoaDon).FirstOrDefault();
            return result;
        }
        public List<string> GetMonAn_IDHoaDon(string IDHoaDon)
        {
            List<string> result = new List<string>();
            result = db.DatMons.Where(p => p.IDHoaDon == IDHoaDon).Select(p => p.IDMon).ToList();
            return result;
        }
        public List<DatMon> GetDatMon_IDHoaDon(string IDHoaDon)
        {
            List<DatMon> result = new List<DatMon>();
            result = db.DatMons.Where(p => p.IDHoaDon == IDHoaDon).Select(p => p).ToList();
            return result;
        }
        public MonAn GetMonAn_IDMon(string IDMon)
        {
            MonAn result = new MonAn();
            result = db.MonAns.Where(p => p.IDMon == IDMon).Select(p => p).FirstOrDefault();
            return result;
        }
    }
}
