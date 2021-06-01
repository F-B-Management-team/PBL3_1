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
            //MVH_08Entities db = new MVH_08Entities();
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
        public string GetIDHoaDon_TO()
        {
            if(GetListIDHoaDon_TO().Count == 0)
            {
                return "00000";
            }
            else
            {
                List<string> l = GetListIDHoaDon_TO();
                return l[l.Count - 1];
            }
        }
        public List<string> GetListIDHoaDon_TI()
        {
            List<string> result;
            result = db.HoaDons.Where(p => p.IDHoaDon.StartsWith("TI")).OrderBy(p=> p.IDHoaDon).Select(p => p.IDHoaDon).ToList();
            return result;
        }
        public string GetIDHoaDon_TI()
        {
            if (GetListIDHoaDon_TI().Count == 0)
            {
                return "00000";
            }
            else
            {
                List<string> l = GetListIDHoaDon_TI();
                return l[l.Count - 1];
            }
        }
        public List<string> GetIDDatMon()
        {
            List<string> result;
            result = db.DatMons.OrderBy(p =>p.IDDatMon).Select(p => p.IDDatMon).ToList();
            return result;
        }
        public string GetIDDatMon_Last()
        {
            if (GetIDDatMon().Count == 0)
            {
                return "00000";
            }
            else
            {
                List<string> l = GetIDDatMon();
                return l[l.Count - 1];
            }
        }
        public string GetIDHoaDon_IDTable(string IDTable)
        {
            string result;
            List<string> ListIDHoaDon = db.HoaDons.Where(p => p.IDBan == IDTable).OrderBy(p => p.IDHoaDon).Select(p => p.IDHoaDon).ToList();

            result = ListIDHoaDon[ListIDHoaDon.Count - 1];
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
            result = db.DatMons.Where(p => p.IDHoaDon == IDHoaDon).ToList();
            return result;
        }
        public MonAn GetMonAn_IDMon(string IDMon)
        {
            MonAn result = new MonAn();
            result = db.MonAns.Where(p => p.IDMon == IDMon).Select(p => p).FirstOrDefault();
            return result;
        }
        public Customer GetCustomer_IDHoaDon(string IDHoaDon)
        {
            Customer result = new Customer();
            string d;
            d = db.HoaDons.Where(p => p.IDHoaDon == IDHoaDon).Select(p => p.IDCustommer).FirstOrDefault();
            result = db.Customers.Where(p => p.IDCustomer == d).FirstOrDefault();
            return result;
        }
        public Customer GetCustomer_IDCustomer(string IDCustomer)
        {
            var result = db.Customers.Where(p => p.IDCustomer == IDCustomer).FirstOrDefault();
            return result;
        }
        public bool GetIDCustomer(string ID)
        {
            var result = db.Customers.Find(ID);
            if (result != null) return true;
            else return false;
        }
        public Ban GetBan(string IDBan)
        {
            var result = db.Bans.Where(p => p.IDBan == IDBan).FirstOrDefault();
            return result;
        }
        public HoaDon GetHoaDon(string iDHoaDon)
        {
            var result = db.HoaDons.Where(p => p.IDHoaDon == iDHoaDon).FirstOrDefault();
            return result;
        }
        public ThongTinHoaDon GetThongTinTHoaDon(string iDHoaDon)
        {
            var result = db.ThongTinHoaDons.Where(p => p.IDHoaDon == iDHoaDon).FirstOrDefault();
            return result;
        }
        public List<Customer> GetCustomers()
        {
            var result = db.Customers.Select(p => p).ToList();
            return result;
        }
        public List<string> GetIDThongTinHoaDon()
        {
            List<string> result;
            result = db.ThongTinHoaDons.OrderBy(p => p.IDThongTin).Select(p => p.IDThongTin).ToList();
            return result;
        }
        public string GetIDThongTinHoaDon_Last()
        {
            if (GetIDThongTinHoaDon().Count == 0)
            {
                return "00000";
            }
            else
            {
                List<string> l = GetIDThongTinHoaDon();
                return l[l.Count - 1];
            }
        }
    }
}
