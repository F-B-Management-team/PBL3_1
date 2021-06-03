using PBL3.BLL;
using PBL3.DAL;
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
        public delegate void setting_Del(string IDNguoiDung);
        public setting_Del d { get; set; }
        public setting()
        {
            InitializeComponent();
            /*loadFood();
            loadDrink();
            loadStaff();*/
            indicator.Left = bunifuLabel2.Left;
            indicator.Width = bunifuLabel2.Width;
            SetCBB();
            cbbCV.SelectedIndex = 0;
            SetCBBSort();
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

            /*List<HoaDon> listhd = BLL.BLL_Setting.Instance.GetListHoaDon();
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
            }*/
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
            BLL.BLL_Order.Instance.LoadMenuDrink();
            BLL.BLL_Order.Instance.LoadMenuFood();

            /*List<HoaDon> listhd = BLL.BLL_Setting.Instance.GetListHoaDon();
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
            }*/
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
        public void SetCBB()
        {
            string[] cbb = new string[] { "All", "staff", "admin", "manage" };
            cbbCV.Items.AddRange(cbb);
        }
        public void SetCBBSort()
        {
            string[] cbbs = new string[] { "TenNguoiDung", "TenDangNhap" };
            cbbSort.Items.AddRange(cbbs);
        }
        public void Tim(string name)
        {
            dataStaff.DataSource = BLL_Setting.Instance.TimNV_BLL(name);
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            switch (cbbCV.Text)
            {
                case "All":
                    dataStaff.DataSource = BLL_Setting.Instance.Loadtt(cbbCV.Text);
                    break;
                case "staff":
                    dataStaff.DataSource = BLL_Setting.Instance.Loadtt(cbbCV.Text);
                    break;
                case "manage":
                    dataStaff.DataSource = BLL_Setting.Instance.Loadtt(cbbCV.Text);
                    break;
                case "admin":
                    dataStaff.DataSource = BLL_Setting.Instance.Loadtt(cbbCV.Text);
                    break;
            }
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            Tim(txtTim.Text);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = dataStaff.CurrentRow.Cells["IDNguoiDung"].Value.ToString();
            ThongTinNguoiDung nd = BLL_Setting.Instance.TimNguoiDung(id);
            TaiKhoan tk = BLL_Setting.Instance.TimTaiKhoan(id);
            BLL_Setting.Instance.timid(id);
            BLL_Setting.Instance.Xoa_BLL(nd, tk);
            btnShow_Click(sender, e);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            addStaff1.BringToFront();
            d = new setting_Del(addStaff1.setid);
            d("");
            btnShow_Click(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection data = dataStaff.SelectedRows;
            if (data.Count == 1)
            {
                string NguoiDung = data[0].Cells["IDNguoiDung"].Value.ToString();
                d = new setting_Del(addStaff1.loadEditStaff);
                addStaff1.BringToFront();
                d(NguoiDung);
            }
        }

        private void btnSX_Click(object sender, EventArgs e)
        {
            List<joinTK> joins = new List<joinTK>();
            switch (cbbSort.Text)
            {

                case "TenNguoiDung":
                    switch (cbbCV.Text)
                    {
                        case "All":
                            dataStaff.DataSource = dataStaff.DataSource = BLL.BLL_Setting.Instance.SortName(cbbCV.Text);
                            break;
                        case "staff":
                            dataStaff.DataSource = dataStaff.DataSource = BLL.BLL_Setting.Instance.SortName(cbbCV.Text);
                            break;
                        case "manage":
                            dataStaff.DataSource = dataStaff.DataSource = BLL.BLL_Setting.Instance.SortName(cbbCV.Text);
                            break;
                        case "admin":
                            dataStaff.DataSource = dataStaff.DataSource = BLL.BLL_Setting.Instance.SortName(cbbCV.Text);
                            break;
                    }
                    break;
                case "TenDangNhap":
                    switch (cbbCV.Text)
                    {
                        case "All":
                            dataStaff.DataSource = dataStaff.DataSource = BLL.BLL_Setting.Instance.SortNameLogin(cbbCV.Text);
                            break;
                        case "staff":
                            dataStaff.DataSource = dataStaff.DataSource = BLL.BLL_Setting.Instance.SortNameLogin(cbbCV.Text);
                            break;
                        case "manage":
                            dataStaff.DataSource = dataStaff.DataSource = BLL.BLL_Setting.Instance.SortNameLogin(cbbCV.Text);
                            break;
                        case "admin":
                            dataStaff.DataSource = dataStaff.DataSource = BLL.BLL_Setting.Instance.SortNameLogin(cbbCV.Text);
                            break;
                    }
                    break;
            }
            //dataStaff.DataSource = BLL_Setting.Instance.loadttsx(cbbCV.Text);
        }
        public void TimCus(string namecs)
        {
            dataCus.DataSource = BLL_Setting.Instance.TimCus_BLL(namecs);
        }
        private void btnTimCus_Click(object sender, EventArgs e)
        {
            TimCus(txtTenCus.Text);
        }

        private void btnXemCus_Click(object sender, EventArgs e)
        {
            dataCus.DataSource = BLL_Setting.Instance.LoadCus();
            dataCus.Columns["HoaDons"].Visible = false;
        }
    }
}
