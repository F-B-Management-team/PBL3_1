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
    }
}
