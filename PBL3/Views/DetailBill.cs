using PBL3.Data;
using PBL3.Properties;
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
    public partial class DetailBill : UserControl
    {
        public DetailBill()
        {
            InitializeComponent();
            
        }
        public void ColumnDataOrder()
        {
            DataDetail.ColumnCount = 3;
            DataDetail.Columns[0].Name = "TenMon";
            DataDetail.Columns[1].Name = "SoLuong";
            DataDetail.Columns[2].Name = "Gia";


            DataDetail.Rows.Clear();
            bunifuPanel1.Visible = false;
        }
        public void LoadDetail(string IDHoaDon, double TienThanhToan)
        {
            
            DataDetail.Rows.Clear();
            ColumnDataOrder();

            if (BLL.BLL_ManageBill.Instance.GetIDNguoiDUng_IDHoaDon(IDHoaDon) != null)
            {
                textboxCus.Text = BLL.BLL_ManageBill.Instance.GetIDNguoiDUng_IDHoaDon(IDHoaDon);
            }
            else
            {
                textboxCus.Text = "Trống";
            }

            ////List<string> IDMon = BLL.BLL_Order.Instance.GetMonAn_IDHoaDon(IDHoaDon);
            ////List<DatMon> datmon = BLL.BLL_Order.Instance.GetDatMon_IDHoaDon(IDHoaDon);
            ////MonAn monan = new MonAn();
            ////for (int i = 0; i < datmon.Count; i++)
            ////{
            ////    DatMon d = datmon[i];
            ////    monan = BLL.BLL_Order.Instance.GetMonAn_IDMon(IDMon[i]);

            ////    //new row
            ////    DataGridViewRow row = (DataGridViewRow)DataDetail.Rows[0].Clone();
            ////    row = (DataGridViewRow)DataDetail.Rows[0].Clone();
            ////    row.Cells[0].Value = monan.IDMon;
            ////    row.Cells[1].Value = monan.IDDanhMuc;
            ////    row.Cells[2].Value = monan.TenMon;
            ////    row.Cells[3].Value = d.SoLuong;
            ////    row.Cells[4].Value = monan.Gia;
            ////    DataDetail.Rows.Add(row);

            //}

            List<ThongTinHoaDon> listtthd = BLL.BLL_ManageBill.Instance.GetThongTinHoaDon_IDHoaDon(IDHoaDon);
            for (int j = 0; j < listtthd.Count; j++)
            {
                double total = 0;
                total = Convert.ToDouble(total + listtthd[j].GiaMon * listtthd[j].SoLuong);

                DataGridViewRow row = (DataGridViewRow)DataDetail.Rows[0].Clone();
                row = (DataGridViewRow)DataDetail.Rows[0].Clone();
                row.Cells[0].Value = listtthd[j].TenMon;
                row.Cells[1].Value = listtthd[j].SoLuong;
                row.Cells[2].Value = total;
                DataDetail.Rows.Add(row);
            }
            ThongTinHoaDon TTHD = BLL.BLL_ManageBill.Instance.GetThongTinHoaDonz_IDHoaDon(IDHoaDon);
            double Tongtien = 0;
            for (int i = 0; i < DataDetail.Rows.Count; i++)
            {
                Tongtien = Tongtien + Convert.ToDouble(DataDetail.Rows[i].Cells["Gia"].Value);
            }
            txtTotal.Text = Tongtien.ToString() + "VND";
            txtToTalpayment.Text = TienThanhToan.ToString() + "VND";
            if (Tongtien > TienThanhToan)
            {
                txtDiscount.Text = (Tongtien - TienThanhToan).ToString() + "VND";
            }
            else
            {
                txtDiscount.Text = "0VND";
            }
            textboxBan.Text = TTHD.LoaiBan.ToString();
            textboxIDBILL.Text = TTHD.IDHoaDon.ToString();
            bunifuDatePicker1.Value = Convert.ToDateTime(TTHD.NgayXuat);
            if (TTHD.Note != null)
                textboxNote.Text = TTHD.Note.ToString();
        }

        private void btnBackdetail_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            
            textboxIDBILL.ResetText();
            textboxBan.ResetText();
            bunifuDatePicker1.ResetText();
            txtDiscount.ResetText();
            txtToTalpayment.ResetText();
            txtTotal.ResetText();
            txtDiscount.ResetText();
            textboxCus.ResetText();
            textboxNote.ResetText();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            textboxNote.Visible = true;
            if (textboxNote.Text.Length == 0)
            {
                BLL.BLL_Update.Instance.AddNote_HoaDon("", textboxIDBILL.Text.ToString());
            }
            else
            {
                BLL.BLL_Update.Instance.AddNote_HoaDon(textboxNote.Text.ToString(), textboxIDBILL.Text.ToString());
            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {

            bunifuPanel1.Visible = true;
            bunifuPanel1.BringToFront();
            textboxNote.Text = BLL.BLL_ManageBill.Instance.GetNote_IDHoaDon(textboxIDBILL.Text);
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            bunifuPanel1.Visible = false;
            bunifuPanel1.SendToBack();
        }
        public void GenerateReport()
        {
            bunifuReports1.Clear();

            bunifuReports1.AddLineBreak();

            bunifuReports1.AddImage(Image.FromFile("C:\\PBL3\\PBL3_1\\PBL3\\Resources\\180478677_479136336763688_337598169216810801_n1.jpg"), "width=200px");

            bunifuReports1.AddLineBreak();
            bunifuReports1.AddString("Số Hóa Đơn:  " + textboxIDBILL.Text);

            bunifuReports1.AddLineBreak();
            bunifuReports1.AddLineBreak();
            bunifuReports1.AddHorizontalRule();
            bunifuReports1.AddLineBreak();

            DataTable header = new DataTable();

            header.Columns.Add("Ngày Xuất");
            header.Columns.Add("Bàn Ăn");
            header.Columns.Add("Nhân Viên");

            header.Rows.Add(new object[] { bunifuDatePicker1.Text, textboxBan.Text, textboxCus.Text });

            bunifuReports1.AddDataTable(header, "width=480px border=2");
            bunifuReports1.AddHorizontalRule();
            bunifuReports1.AddDatagridView(DataDetail, "width=100% border=2");
            bunifuReports1.AddLineBreak();

            DataTable sumary = new DataTable();
            sumary.Columns.Add("Tiền Bàn");
            sumary.Columns.Add(txtTotal.Text);

            sumary.Rows.Add(new object[] { "Giảm Giá", txtDiscount.Text });
            sumary.Rows.Add(new object[] { "VAT", 0 });
            sumary.Rows.Add(new object[] { "Thành Tiền", txtToTalpayment.Text });



            bunifuReports1.AddDataTable(sumary, "width=480px border=2");

            bunifuReports1.ShowPrintPreviewDialog();
        }
        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }
        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            GenerateReport();
            bunifuReports1.SavePDF(saveFileDialog1.FileName);
            this.Cursor = Cursors.Default;
            MessageBox.Show("PDF successfully Generated");
        }

    }
}
