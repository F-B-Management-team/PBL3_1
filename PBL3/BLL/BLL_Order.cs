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
            result = (db.MonAns.Where(p => p.IDDanhMuc == "douong").ToList());
            return result;
        }
    }
}
