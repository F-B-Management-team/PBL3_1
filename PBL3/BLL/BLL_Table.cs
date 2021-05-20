using PBL3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.BLL
{
    class BLL_Table
    {
        MVH_08Entities db = new MVH_08Entities();

        private static BLL_Table _Instance;
        public static BLL_Table Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_Table();
                }
                return _Instance;
            }
            private set { }
        }
        private BLL_Table()
        {

        }
        public List<Ban> GetBan()
        {
            List<Ban> result = new List<Ban>();
            result = db.Bans.Select(p => p).OrderBy(p => p.IDBan).ToList();
            return result;
        }
    }
}
