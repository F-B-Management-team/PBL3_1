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
using static PBL3.Views.DetailBill;

namespace PBL3.Views
{
    public partial class ManageBill : UserControl
    {
        public delegate void ManageBill_del(string IDHoaDon, double TienThanhToan);
        public ManageBill_del MB { get; set; }
        public ManageBill()
        {
            InitializeComponent();
            
        }
        public void loaddata()
        {
            DataBill.ColumnCount = 6;
            DataBill.Columns[0].Name = "ID Hóa Đơn";
            DataBill.Columns[1].Name = "Tên Bàn";
            DataBill.Columns[2].Name = "Ngày Xuất";
            DataBill.Columns[3].Name = "Tổng Tiền";
            DataBill.Columns[4].Name = "ID Nhân Viên";
            DataBill.Columns[5].Name = "ID Khách Hàng";
            DataBill.Rows.Clear();
        }
        private void bunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if ((bunifuDropdown1.Items[bunifuDropdown1.SelectedIndex]).ToString() == "ALL")
            {
                LoadHoaDon();
            }
            else
            {
                LoadHoaDon_IDBan(((CBB_ManageBill)bunifuDropdown1.Items[bunifuDropdown1.SelectedIndex]).Value.ToString());
            }
        }

        public void LoadHoaDon()
        {
            DataBill.Rows.Clear();
            loaddata();
            List<HoaDon> listhd = BLL.BLL_ManageBill.Instance.GetHoaDon();

            for (int i = 0; i < listhd.Count; i++)
            {
                if ((bool)(listhd[i].TrangThai == true))
                {
                    //double total = 0;
                    ThongTinHoaDon listtthd = BLL.BLL_ManageBill.Instance.GetThongTinHoaDonz_IDHoaDon(listhd[i].IDHoaDon);
                    
                        //    total = Convert.ToDouble(total + listtthd[j].GiaMon * listtthd[j].SoLuong);
                        //}
                        DataGridViewRow row = (DataGridViewRow)DataBill.Rows[0].Clone();
                        row = (DataGridViewRow)DataBill.Rows[0].Clone();
                        row.Cells[0].Value = listhd[i].IDHoaDon;
                        row.Cells[1].Value = listhd[i].IDBan;
                        row.Cells[2].Value = Convert.ToDateTime(listhd[i].NgayXuat).ToString("dd / MM / yyyy");
                        row.Cells[3].Value = listhd[i].TongTien;
                        row.Cells[4].Value = listtthd.IDNguoiDung;
                        row.Cells[5].Value = listhd[i].IDCustommer;
                        DataBill.Rows.Add(row);
                    }
                }
            

        }
        public void LoadHoaDon_IDBan(string IDBan)
        {
            DataBill.Rows.Clear();
            loaddata();
            List<HoaDon> listhd = BLL.BLL_ManageBill.Instance.GetHoaDon_IDBan(IDBan);

            for (int i = 0; i < listhd.Count; i++)
            {
                if ((bool)(listhd[i].TrangThai == true))
                {
                    //double total = 0;
                    ThongTinHoaDon listtthd = BLL.BLL_ManageBill.Instance.GetThongTinHoaDonz_IDHoaDon(listhd[i].IDHoaDon);
                    
                        //    total = Convert.ToDouble(total + listtthd[j].GiaMon * listtthd[j].SoLuong);
                        //}
                        DataGridViewRow row = (DataGridViewRow)DataBill.Rows[0].Clone();
                        row = (DataGridViewRow)DataBill.Rows[0].Clone();
                        row.Cells[0].Value = listhd[i].IDHoaDon;
                        row.Cells[1].Value = listhd[i].IDBan;
                        row.Cells[2].Value = Convert.ToDateTime(listhd[i].NgayXuat).ToString("dd / MM / yyyy");
                        row.Cells[3].Value = listhd[i].TongTien;
                        row.Cells[4].Value = listtthd.IDNguoiDung;
                        row.Cells[5].Value = listhd[i].IDCustommer;
                        DataBill.Rows.Add(row);
                    
                }
            }
        }
        public void Setcbb()
        {
            detailBill1.Visible = false;
            foreach (Ban i in BLL.BLL_ManageBill.Instance.GetBan())
            {
                bunifuDropdown1.Items.Add(new CBB_ManageBill()
                {
                    Value = i.IDBan,
                    Text = i.LoaiBan
                });
                bunifuDropdown1.SelectedIndex = 0;
            }
        }
        private void DataBill_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewSelectedRowCollection data = DataBill.SelectedRows;
            if (data.Count == 1)
            {
                string Bill = data[0].Cells["ID Hóa Đơn"].Value.ToString();
                double TienThanhToan = Convert.ToDouble(data[0].Cells["Tổng Tiền"].Value);
                MB += new ManageBill.ManageBill_del(detailBill1.LoadDetail);
                detailBill1.BringToFront();
                MB(Bill, TienThanhToan);

            }
            //DataBill.Visible = false;
            detailBill1.Visible = true;
            bunifuPanel1.SendToBack();
            detailBill1.BringToFront();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection data = DataBill.SelectedRows;
            foreach (DataGridViewRow i in data)
            {

                string bill = i.Cells["ID Hóa Đơn"].Value.ToString();
                List<DatMon> before_datmon = BLL.BLL_ManageBill.Instance.GetDatMon_IDHoaDon(bill);
                for (int j = 0; j < before_datmon.Count; j++)
                {
                    BLL.BLL_ManageBill.Instance.Delete_DatMon_IDDatMon(before_datmon[j].IDDatMon);
                }
                BLL.BLL_ManageBill.Instance.Del_ThongTinHoaDon(bill);
                BLL.BLL_ManageBill.Instance.Del_HoaDon(bill);
            }
            LoadHoaDon();
        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(1);
            revenue1.LoadTong();
            revenue1.render_column();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(0);
        }


    }
}
