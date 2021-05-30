using PBL3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.BLL
{
    class BLL_Revenue
    {
        MVH_08Entities db = new MVH_08Entities();

        private static BLL_Revenue _Instance;
        public static BLL_Revenue Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_Revenue();
                }
                return _Instance;
            }
            private set { }
        }
        private BLL_Revenue()
        {

        }
        public double? GetTongDoanhThu_NgayXuat(DateTime NgayXuat)
        {
            double? total = 0;
            //if (NgayXuat == db.HoaDons.Where(p => p.NgayXuat == NgayXuat).Select(p => p.NgayXuat).FirstOrDefault())
            {
                List<double?> result = new List<double?>();
                result = db.HoaDons.Where(p => p.NgayXuat == NgayXuat).Select(p => p.TongTien).ToList();

                for (int i = 0; i <= result.Count - 1; i++)
                {
                    if (result.Count == 0)
                    {
                        continue;
                    }
                    else
                    {
                        total = total + Convert.ToDouble(result[i]);
                    }
                }
            }
            return total;
        }
        public int GetTongHoaDon_NgayXuat(DateTime NgayXuat)
        {
            List<string> result = new List<string>();
            result = db.HoaDons.Where(p => p.NgayXuat == NgayXuat).Select(p => p.IDHoaDon).ToList();
            int total = result.Count;
            return total;
        }
        public double? GetTongDoanhThuThang_NgayXuat(DateTime? NgayXuat)
        {
            double? total = 0;
            //if (NgayXuat == db.HoaDons.Where(p => p.NgayXuat == NgayXuat).Select(p => p.NgayXuat).FirstOrDefault())
            {
                List<double?> result = new List<double?>();
                result = db.HoaDons.Where(p => p.NgayXuat == NgayXuat).Select(p => p.TongTien).ToList();

                for (int i = 0; i <= result.Count - 1; i++)
                {
                    if (result.Count == 0)
                    {
                        continue;
                    }
                    else
                    {
                        total = total + Convert.ToDouble(result[i]);
                    }
                }
            }
            return total;
        }
        public List<DateTime?> GetNgayXuat()
        {
            List<DateTime?> result = new List<DateTime?>();
            result = db.HoaDons.Select(p => p.NgayXuat).ToList();
            return result;
        }
    }

}
