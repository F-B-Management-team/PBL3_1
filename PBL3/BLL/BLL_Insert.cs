using PBL3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.BLL
{
    class BLL_Insert
    {
        MVH_08Entities db = new MVH_08Entities();

        private static BLL_Insert _Instance;
        public static BLL_Insert Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_Insert();
                }
                return _Instance;
            }
            private set { }
        }
        private BLL_Insert()
        {

        }
        public void AddHoaDon(HoaDon s)
        {
            db.HoaDons.Add(s);
            db.SaveChanges();
        }
        public void AddCustomer(Customer s)
        {
            db.Customers.Add(s);
            db.SaveChanges();
        }
        public void AddMonAn(MonAn s)
        {
            db.MonAns.Add(s);
            db.SaveChanges();
        }
        public void AddDatMon(DatMon s)
        {
            db.DatMons.Add(s);
            db.SaveChanges();   
        }
    }
}
