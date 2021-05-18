using PBL3.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.Views
{
    public partial class setting : UserControl
    {
        MVH_08Entities db = new MVH_08Entities();
        public setting()
        {
            InitializeComponent();
            /*loadFood();
            loadDrink();
            loadStaff();*/
            indicator.Left = bunifuLabel2.Left;
            indicator.Width = bunifuLabel2.Width;

        }

        void loadStaff()
        {
            var result = from p in db.ThongTinNguoiDungs select new { p.IDNguoiDung, p.TenNguoiDung, p.GioiTinh, p.NgaySinh, p.PhoneNumber };
            dataStaff.DataSource = result.ToList();
        }
        void loadFood()
        {
            var result = from c in db.MonAns where c.IDDanhMuc == "doan" select new { TenMon = c.TenMon, Gia = c.Gia };
            dataFood.DataSource = result.ToList();

        }
        void loadDrink()
        {
            var result = from c in db.MonAns where c.IDDanhMuc == "douong" select new { TenMon = c.TenMon, Gia = c.Gia };
            dataDrink.DataSource = result.ToList();
        }
        private void bunifuLabel2_Click(object sender, EventArgs e)
        {
            indicator.Left = bunifuLabel2.Left;
            indicator.Width = bunifuLabel2.Width;
            bunifuPages1.SetPage(0);
        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {
            indicator.Left = bunifuLabel3.Left;
            indicator.Width = bunifuLabel3.Width;
            bunifuPages1.SetPage(1);
        }

        private void bunifuLabel10_Click(object sender, EventArgs e)
        {
            indicator.Left = bunifuLabel10.Left;
            indicator.Width = bunifuLabel10.Width;
            bunifuPages1.SetPage(3);
        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {
            indicator.Left = bunifuLabel4.Left;
            indicator.Width = bunifuLabel4.Width;
            bunifuPages1.SetPage(2);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }
       
    }
}
