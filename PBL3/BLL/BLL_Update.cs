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
    }
}
