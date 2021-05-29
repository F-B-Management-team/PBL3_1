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
            dataFood.DataSource = BLL.BLL_Setting.Instance.LoadMenuFood();
            dataFood.Columns[4].Visible = false;
            dataFood.Columns[5].Visible = false;
            dataDrink.DataSource = BLL.BLL_Setting.Instance.LoadMenuDrink();
            dataDrink.Columns[4].Visible = false;
            dataDrink.Columns[5].Visible = false;
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

        private void AddFood_Click(object sender, EventArgs e)
        {
            dataFood.DataSource = BLL.BLL_Setting.Instance.AddMenuFoodWithEmptyRow();
        }

        private void AddDrink_Click(object sender, EventArgs e)
        {
            dataDrink.DataSource = BLL.BLL_Setting.Instance.AddMenuDrinkWithEmptyRow();
        }

        private void enterKeyboard_Press(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                // Enter key pressed
                // Get data from new row
                Console.WriteLine(dataDrink.Rows.Count);
                Console.WriteLine(BLL.BLL_Setting.Instance.LoadMenuDrink().Count);
                if (dataFood.Rows.Count != BLL.BLL_Setting.Instance.LoadMenuFood().Count)
                {
                    MonAn ma = new MonAn();
                    int lastrowfood = (dataFood.Rows.Count) - 1;
                    ma.IDMon = Convert.ToString(dataFood.Rows[lastrowfood].Cells["IDMon"].Value);
                    ma.IDDanhMuc = Convert.ToString(dataFood.Rows[lastrowfood].Cells["IDDanhMuc"].Value);
                    ma.TenMon = Convert.ToString(dataFood.Rows[lastrowfood].Cells["TenMon"].Value);
                    ma.Gia = Convert.ToDouble(dataFood.Rows[lastrowfood].Cells["Gia"].Value);
                    ma.DanhMuc = null;
                    ma.DatMons = null;
                    BLL.BLL_Insert.Instance.AddMonAn(ma);
                }
                if (dataDrink.Rows.Count != BLL.BLL_Setting.Instance.LoadMenuDrink().Count)
                //if (e.KeyChar == (char)9)
                {
                    MonAn du = new MonAn();
                    int lastrowdrink = (dataDrink.Rows.Count) - 1;
                    du.IDMon = Convert.ToString(dataDrink.Rows[lastrowdrink].Cells["IDMon"].Value);
                    du.IDDanhMuc = Convert.ToString(dataDrink.Rows[lastrowdrink].Cells["IDDanhMuc"].Value);
                    du.TenMon = Convert.ToString(dataDrink.Rows[lastrowdrink].Cells["TenMon"].Value);
                    du.Gia = Convert.ToDouble(dataDrink.Rows[lastrowdrink].Cells["Gia"].Value);
                    du.DanhMuc = null;
                    du.DatMons = null;
                    BLL.BLL_Insert.Instance.AddMonAn(du);
                }

            }
        }

        private void DeleteFood_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dtf = dataFood.SelectedRows;

            foreach (DataGridViewRow i in dtf)
            {
                string ma = i.Cells["IDMon"].Value.ToString();
                List<DatMon> listMA = BLL.BLL_Setting.Instance.GetDatMon_IDMon(ma);
                for (int m = 0; m < listMA.Count; m++)
                {
                    BLL.BLL_Setting.Instance.Delete_DatMon_IDDatMon(listMA[m].IDDatMon);
                }
                //List<MonAn> listMA = BLL.BLL_Setting.Instance.GetIDMon(ma);
                //List<MonAn> listDU = BLL.BLL_Setting.Instance.GetIDMon(du);
                BLL.BLL_Update.Instance.Delete_MonAn_IDMonAn(ma);
            }
            dataFood.DataSource = BLL.BLL_Setting.Instance.LoadMenuFood();


            DataGridViewSelectedRowCollection dtd = dataDrink.SelectedRows;
            foreach (DataGridViewRow j in dtd)
            {
                string du = j.Cells["IDMon"].Value.ToString();
                List<DatMon> listDU = BLL.BLL_Setting.Instance.GetDatMon_IDMon(du);
                for (int n = 0; n < listDU.Count; n++)
                {
                    BLL.BLL_Setting.Instance.Delete_DatMon_IDDatMon(listDU[n].IDDatMon);
                }
                BLL.BLL_Update.Instance.Delete_MonAn_IDMonAn(du);
            }

            dataDrink.DataSource = BLL.BLL_Setting.Instance.LoadMenuDrink();

            //

            List<HoaDon> listhd = BLL.BLL_Setting.Instance.GetListHoaDon();
            for (int i = 0; i < listhd.Count; i++)
            {
                if (listhd[i].TrangThai == false)
                {
                    double total = 0;
                    List<DatMon> listdm = BLL.BLL_Setting.Instance.GetDatMon_IDHoaDon(listhd[i].IDHoaDon);
                    for (int j = 0; j < listdm.Count; j++)
                    {
                        total = Convert.ToDouble(total + listdm[j].MonAn.Gia * listdm[j].SoLuong);
                        Console.WriteLine(total);
                    }
                    BLL.BLL_Update.Instance.Update_HoaDon_Settings(listhd[i].IDHoaDon, total);
                }
                else
                {
                    //silence
                }
            }
        }

        private void EditFood_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dtf = dataFood.SelectedRows;
            foreach (DataGridViewRow i in dtf)
            {
                string ma = i.Cells["IDMon"].Value.ToString();
                MonAn MA = BLL.BLL_Setting.Instance.GetMonAn_IDMon(ma);
                MA.TenMon = Convert.ToString(i.Cells["TenMon"].Value);
                MA.Gia = Convert.ToDouble(i.Cells["Gia"].Value);
                BLL.BLL_Update.Instance.Update_MonAn(ma, MA.TenMon, MA.Gia);
            }
            dataFood.DataSource = BLL.BLL_Setting.Instance.LoadMenuFood();



            DataGridViewSelectedRowCollection dtd = dataDrink.SelectedRows;
            foreach (DataGridViewRow j in dtd)
            {
                string du = j.Cells["IDMon"].Value.ToString();
                MonAn DU = BLL.BLL_Setting.Instance.GetMonAn_IDMon(du);
                DU.TenMon = Convert.ToString(j.Cells["TenMon"].Value);
                DU.Gia = Convert.ToDouble(j.Cells["Gia"].Value);
                BLL.BLL_Update.Instance.Update_MonAn(du, DU.TenMon, DU.Gia);
            }
            dataDrink.DataSource = BLL.BLL_Setting.Instance.LoadMenuDrink();


            List<HoaDon> listhd = BLL.BLL_Setting.Instance.GetListHoaDon();
            for (int i = 0; i < listhd.Count; i++)
            {
                if (listhd[i].TrangThai == false)
                {
                    double total = 0;
                    List<DatMon> listdm = BLL.BLL_Setting.Instance.GetDatMon_IDHoaDon(listhd[i].IDHoaDon);
                    for (int j = 0; j < listdm.Count; j++)
                    {
                        total = Convert.ToDouble(total + listdm[j].MonAn.Gia * listdm[j].SoLuong);
                        Console.WriteLine(total);
                    }
                    BLL.BLL_Update.Instance.Update_HoaDon_Settings(listhd[i].IDHoaDon, total);
                }
                else
                {
                    //silence
                }
            }
            //list<hoadon> listhd = bll.bll_setting.instance.getlisthoadon();
            //foreach(hoadon i in listhd)
            //{
            //    list<datmon> listdm = bll.bll_setting.instance.getdatmon_idhoadon(i.idhoadon);
            //    foreach(datmon j in listdm)
            //    {
            //        total = convert.todouble(total + j.monan.gia * j.soluong);
            //        console.writeline(j.monan.gia);
            //    }
            //    bll.bll_update.instance.update_hoadon_settings(i.idhoadon, total);
            //}    
        }

    }
}
