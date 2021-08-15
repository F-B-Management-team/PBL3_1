using PBL3.BLL;
using PBL3.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PBL3.Views
{
    public partial class Order : UserControl
    {
        public delegate void Status_del(string idban, bool status);
        public Status_del s { get; set; }
        bool statusorder = true;
        public Order()
        {
            InitializeComponent();
            ColumnDataOrder();
        }
        public void statusOder(string m, bool status)
        {
            numberTable.Text = m;
            statusorder = status;
            txtTotal.Text = "0";
            if (m == "Take out")
            {
                btnDone.Visible = false;
            }
            else
            {
                btnDone.Visible = true;
            }
        }
        public void FormOrderStart()
        {
            bunifuPanel1.BringToFront();
            bunifuPanel2.SendToBack();
            bunifuPanel3.SendToBack();
            dataFood.DataSource = "";
            dataDrink.DataSource = "";
        }
        public void SetDataOrder_statusFalse()
        {
            if (statusorder == false)
            {
                string IDBan = numberTable.Text.Substring(6);
                string IDHoaDon = BLL.BLL_Order.Instance.GetIDHoaDon_IDTable(IDBan);
                Customer customer = BLL.BLL_Order.Instance.GetCustomer_IDHoaDon(IDHoaDon);
                if (customer != null)
                {
                    NameCustomer.Text = customer.NameCustomer;
                    PhoneCustomer.Text = customer.Phone;
                }
                else
                {
                    NameCustomer.Text = "";
                    PhoneCustomer.Text = "";
                }
                List<string> IDMon = BLL.BLL_Order.Instance.GetMonAn_IDHoaDon(IDHoaDon);
                List<DatMon> datmon = BLL.BLL_Order.Instance.GetDatMon_IDHoaDon(IDHoaDon);
                txtNote.Text = BLL.BLL_Order.Instance.GetHoaDon(IDHoaDon).Note;
                MonAn monan = new MonAn();
                for (int i = 0; i < datmon.Count; i++)
                {
                    DatMon d = datmon[i];
                    monan = BLL.BLL_Order.Instance.GetMonAn_IDMon(IDMon[i]);

                    //new row
                    DataGridViewRow row = (DataGridViewRow)dataOder.Rows[0].Clone();
                    row = (DataGridViewRow)dataOder.Rows[0].Clone();
                    row.Cells[0].Value = monan.IDMon;
                    row.Cells[1].Value = monan.IDDanhMuc;
                    row.Cells[2].Value = monan.TenMon;
                    row.Cells[3].Value = d.SoLuong;
                    row.Cells[4].Value = d.SoLuong * monan.Gia;
                    dataOder.Rows.Add(row);

                    Total();
                }
            }
        }
        public void SetNguoiDung(string m)
        {
            txtTenNguoiDung.Text = m;
        }
        public void ColumnDataOrder()
        {
            dataOder.ColumnCount = 7;
            dataOder.Columns[0].Name = "IDMon";
            dataOder.Columns[1].Name = "IDDanhMuc";
            dataOder.Columns[2].Name = "TenMon";
            dataOder.Columns[3].Name = "SoLuong";
            dataOder.Columns[4].Name = "Gia";
            dataOder.Columns[5].Name = "DanhMuc";
            dataOder.Columns[6].Name = "DatMons";

            dataOder.Columns[0].Visible = true;
            dataOder.Columns[1].Visible = false;
            dataOder.Columns[5].Visible = false;
            dataOder.Columns[6].Visible = false;

            dataOder.Rows.Clear();
        }
        public void loadFood()
        {
            //var result = from c in db.MonAns where c.IDDanhMuc == "doan" select new { TenMon = c.TenMon, Gia = c.Gia };
            //var result = db.MonAns.Where(p => p.IDDanhMuc == "doan").Select(p => new { p.TenMon, p.Gia });
            dataFood.DataSource = BLL.BLL_Order.Instance.LoadMenuFood();
            dataFood.Columns[0].Visible = false;
            dataFood.Columns[1].Visible = false;
            dataFood.Columns[4].Visible = false;
            dataFood.Columns[5].Visible = false;
        }
        public void loadDrink()
        {
            //var result = from c in db.MonAns where c.IDDanhMuc == "douong" select new { TenMon = c.TenMon, Gia = c.Gia };
            //dataDrink.DataSource = result.ToList();
            dataDrink.DataSource = BLL.BLL_Order.Instance.LoadMenuDrink();
            dataDrink.Columns[0].Visible = false;
            dataDrink.Columns[1].Visible = false;
            dataDrink.Columns[4].Visible = false;
            dataDrink.Columns[5].Visible = false;
        }
        public void loadCustomer()
        {
            dataCustomer.DataSource = BLL.BLL_Order.Instance.GetCustomers();
        }
        public void loadCustomer(string idcustom, int discount)
        {
            for (int i = 1; i < dataCustomer.Rows.Count; i++)
            {
                if (dataCustomer.Rows[i].Cells["IDCustomer"].Value.ToString() == idcustom)
                {
                    dataCustomer.Rows[i].Cells["Discount"].Value = discount;
                }
            }
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            txtNote.Clear();
            NameCustomer.Clear();
            PhoneCustomer.Clear();
            dataOder.Rows.Clear();
            txtTotal.ResetText();
            bunifuPanel1.BringToFront();
            bunifuPanel2.SendToBack();
            bunifuPanel3.SendToBack();
        }
        private void bunifuButton1_Click(object sender, EventArgs e)
        {

            bunifuPanel1.SendToBack();
            bunifuPanel3.SendToBack();
            //bunifuPanel2.Visible = false;
            bunifuPanel2.BringToFront();
            bunifuTransition1.ShowSync(bunifuPanel2);
            loadFood();
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            bunifuPanel1.SendToBack();
            bunifuPanel2.SendToBack();
            //bunifuPanel3.Visible = false;
            bunifuPanel3.BringToFront();
            bunifuTransition1.ShowSync(bunifuPanel3);
            loadDrink();
        }

        private void MenuFood_Click(object sender, EventArgs e)
        {
            bunifuPanel2.Hide();
            bunifuPanel1.Hide();
            bunifuTransition3.ShowSync(bunifuPanel1);
        }

        private void MenuDrink_Click(object sender, EventArgs e)
        {
            bunifuPanel3.Hide();
            bunifuPanel1.Hide();
            bunifuTransition3.ShowSync(bunifuPanel1);
        }

        private void dataFood_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool k = false;
            for (int i = 0; i < dataOder.Rows.Count; i++)
            {
                if (dataOder.Rows[i].Cells["TenMon"].Value == dataFood.Rows[e.RowIndex].Cells["TenMon"].Value)
                {
                    k = true;
                    dataOder.Rows[i].Cells["SoLuong"].Value = Convert.ToInt32(dataOder.Rows[i].Cells["SoLuong"].Value) + 1;
                    dataOder.Rows[i].Cells["Gia"].Value = (Convert.ToInt32(dataOder.Rows[i].Cells["Gia"].Value)
                                                       / (Convert.ToInt32(dataOder.Rows[i].Cells["SoLuong"].Value) - 1))
                                                        * Convert.ToInt32(dataOder.Rows[i].Cells["SoLuong"].Value);
                    break;
                }
                else
                {
                    k = false;
                }
            }
            if (!k)
            {
                DataGridViewRow row = (DataGridViewRow)dataOder.Rows[0].Clone();
                row = (DataGridViewRow)dataOder.Rows[0].Clone();
                row.Cells[0].Value = dataFood.Rows[e.RowIndex].Cells["IDMon"].Value;
                row.Cells[1].Value = dataFood.Rows[e.RowIndex].Cells["IDDanhMuc"].Value;
                row.Cells[2].Value = dataFood.Rows[e.RowIndex].Cells["TenMon"].Value;
                row.Cells[3].Value = 1;
                row.Cells[4].Value = dataFood.Rows[e.RowIndex].Cells["Gia"].Value;
                dataOder.Rows.Add(row);
            }
            Total();
            /*DataGridViewRow row = new DataGridViewRow();
            row = (DataGridViewRow)dataOder.Rows[0].Clone();
            row.Cells[0].Value = dataFood.Rows[e.RowIndex].Cells["TenMon"].Value;
            row.Cells[1].Value = 1;
            row.Cells[2].Value = dataFood.Rows[e.RowIndex].Cells["Gia"].Value;
            dataOder.Rows.Add(row);*/
        }

        private void dataDrink_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool k = false;
            for (int i = 0; i < dataOder.Rows.Count; i++)
            {
                if (dataOder.Rows[i].Cells["TenMon"].Value == dataDrink.Rows[e.RowIndex].Cells["TenMon"].Value)
                {
                    k = true;
                    dataOder.Rows[i].Cells["SoLuong"].Value = Convert.ToInt32(dataOder.Rows[i].Cells["SoLuong"].Value) + 1;
                    dataOder.Rows[i].Cells["Gia"].Value = (Convert.ToInt32(dataOder.Rows[i].Cells["Gia"].Value)
                                                       / (Convert.ToInt32(dataOder.Rows[i].Cells["SoLuong"].Value) - 1))
                                                        * Convert.ToInt32(dataOder.Rows[i].Cells["SoLuong"].Value);
                    break;
                }
                else
                {
                    k = false;
                }
            }
            if (!k)
            {
                DataGridViewRow row = new DataGridViewRow();
                row = (DataGridViewRow)dataOder.Rows[0].Clone();
                row.Cells[0].Value = dataDrink.Rows[e.RowIndex].Cells["IDMon"].Value;
                row.Cells[1].Value = dataDrink.Rows[e.RowIndex].Cells["IDDanhMuc"].Value;
                row.Cells[2].Value = dataDrink.Rows[e.RowIndex].Cells["TenMon"].Value;
                row.Cells[3].Value = 1;
                row.Cells[4].Value = dataDrink.Rows[e.RowIndex].Cells["Gia"].Value;
                dataOder.Rows.Add(row);
            }
            Total();
        }

        private void dataOder_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataOder.Rows[e.RowIndex].Cells["SoLuong"].Value = Convert.ToInt32(dataOder.Rows[e.RowIndex].Cells["SoLuong"].Value) - 1;
            dataOder.Rows[e.RowIndex].Cells["Gia"].Value = Convert.ToInt32(dataOder.Rows[e.RowIndex].Cells["Gia"].Value)
                                                            / (Convert.ToInt32(dataOder.Rows[e.RowIndex].Cells["SoLuong"].Value) + 1)
                                                            * Convert.ToInt32(dataOder.Rows[e.RowIndex].Cells["SoLuong"].Value);
            if (Convert.ToInt32(dataOder.Rows[e.RowIndex].Cells["SoLuong"].Value) == 0)
            {
                dataOder.Rows.RemoveAt(e.RowIndex);
            }
            Total();
        }
        public void Total()
        {
            double total = 0;
            for (int i = 0; i < dataOder.Rows.Count; i++)
            {
                total = total + Convert.ToDouble(dataOder.Rows[i].Cells["Gia"].Value);
            }
            txtTotal.Text = (total).ToString();
        }
        public string ToTalBill()
        {
            double total = 0;
            for (int i = 0; i < dataOder.Rows.Count; i++)
            {
                total = total + Convert.ToDouble(dataOder.Rows[i].Cells["Gia"].Value);
            }
            return total.ToString();
        }
        private void btnPay_Click(object sender, EventArgs e)
        {
            //// TRUE
            //try
            //{
            if (statusorder == true)
            {
                if (dataOder.Rows.Count - 1 == 0)
                {
                    MessageBox.Show("You must Order before Pay!!");
                }
                else
                {
                    HoaDon s = new HoaDon();
                    // Customer
                    if (PhoneCustomer.Text != "" && NameCustomer.Text != "")
                    {
                        if (BLL.BLL_Setting.Instance.ktsdtt(PhoneCustomer.Text) == false)
                        {
                            MessageBox.Show("Phone Number not true!!");
                            return;
                        }
                        Customer customer = new Customer();
                        customer.IDCustomer = NameCustomer.Text + PhoneCustomer.Text.Substring(7);
                        customer.NameCustomer = NameCustomer.Text;
                        customer.Phone = PhoneCustomer.Text;
                        if (BLL.BLL_Order.Instance.GetIDCustomer(customer.IDCustomer) == true)
                        {
                            /*int discount = (int)BLL.BLL_Order.Instance.GetCustomer_IDCustomer(customer.IDCustomer).Discount ;
                            BLL.BLL_Update.Instance.Update_Customer(customer.IDCustomer, discount + 1);
                            Console.WriteLine(BLL.BLL_Order.Instance.GetCustomer_IDCustomer(customer.IDCustomer).Discount);*/
                            for (int i = 0; i < dataCustomer.Rows.Count; i++)
                            {
                                if (dataCustomer.Rows[i].Cells["IDCustomer"].Value.ToString() == customer.IDCustomer)
                                {
                                    dataCustomer.Rows[i].Cells["Discount"].Value = Convert.ToInt32(dataCustomer.Rows[i].Cells["Discount"].Value) + 1;
                                    BLL.BLL_Update.Instance.Update_Customer(customer.IDCustomer, Convert.ToInt32(dataCustomer.Rows[i].Cells["Discount"].Value));
                                }
                            }
                        }
                        else
                        {
                            BLL.BLL_Insert.Instance.AddCustomer(customer);
                            //int discount = (int)BLL.BLL_Order.Instance.GetCustomer_IDCustomer(customer.IDCustomer).Discount;
                            if(BLL.BLL_Order.Instance.GetCustomer_IDCustomer(customer.IDCustomer).Discount == null )
                            {
                                int discount = 0;
                                BLL.BLL_Update.Instance.Update_Customer(customer.IDCustomer, discount + 1);
                            }
                            else
                            {
                                int discount = (int)BLL.BLL_Order.Instance.GetCustomer_IDCustomer(customer.IDCustomer).Discount;
                                BLL.BLL_Update.Instance.Update_Customer(customer.IDCustomer, discount + 1);
                            }
                            //BLL.BLL_Update.Instance.Update_Customer(customer.IDCustomer, discount + 1);
                            Console.WriteLine(BLL.BLL_Order.Instance.GetCustomer_IDCustomer(customer.IDCustomer).Discount);
                        }

                        // HoaDon
                        if (numberTable.Text == "Take out")
                        {
                            int idhoadon = 0;
                            string l = BLL_Order.Instance.GetIDHoaDon_TO();
                            idhoadon = Convert.ToInt32(l.Substring(2, 3)) + 1;
                            //idhoadon = Convert.ToInt32(l[l.Count - 1].Substring(2, 3)) + 1;
                            s.IDHoaDon = "TO" + idhoadon.ToString("000");
                            s.IDBan = "0";
                        }
                        else
                        {
                            int idhoadon = 0;
                            string l = BLL_Order.Instance.GetIDHoaDon_TI();
                            idhoadon = Convert.ToInt32(l.Substring(2, 3)) + 1;
                            //idhoadon = Convert.ToInt32(l[l.Count - 1].Substring(2, 3)) + 1;
                            s.IDHoaDon = "TI" + idhoadon.ToString("000");
                            s.IDBan = numberTable.Text.Substring(6);
                        }
                        s.NgayXuat = DateTime.Today;
                        s.TrangThai = true;
                        float t = float.Parse(txtTotal.Text);
                        if (txtDiscount.Text == "10%")
                        {
                            // Nếu đạt chỉ tiêu discount => Tính tiền và reset Discount của khách hàng
                            for (int i = 0; i < dataCustomer.Rows.Count; i++)
                            {
                                if (dataCustomer.Rows[i].Cells["IDCustomer"].Value.ToString() == customer.IDCustomer)
                                {
                                    dataCustomer.Rows[i].Cells["Discount"].Value = Convert.ToInt32(dataCustomer.Rows[i].Cells["Discount"].Value) - 10;
                                    BLL.BLL_Update.Instance.Update_Customer(customer.IDCustomer, Convert.ToInt32(dataCustomer.Rows[i].Cells["Discount"].Value));
                                }
                            }
                        }
                        s.TongTien = t;
                        s.IDNguoiDung = BLL.BLL_Login.Instance.GetIDNguoiDung_tnd(txtTenNguoiDung.Text);              ///// Truyền delegate
                        s.IDCustommer = customer.IDCustomer;
                        s.Note = txtNote.Text;
                        BLL.BLL_Insert.Instance.AddHoaDon(s);
                    }
                    else
                    {
                        // HoaDon
                        //List<string> l = new List<string>();
                        if (numberTable.Text == "Take out")
                        {
                            // l = BLL.BLL_Order.Instance.GetListIDHoaDon_TO();
                            int idhoadon = 0;
                            string l = BLL_Order.Instance.GetIDHoaDon_TO();
                            idhoadon = Convert.ToInt32(l.Substring(2, 3)) + 1;
                            //idhoadon = Convert.ToInt32(l[l.Count - 1].Substring(2, 3)) + 1;
                            s.IDHoaDon = "TO" + idhoadon.ToString("000");
                            s.IDBan = "0";
                        }
                        else
                        {
                            //l = BLL.BLL_Order.Instance.GetListIDHoaDon_TI();
                            int idhoadon = 0;
                            string l = BLL_Order.Instance.GetIDHoaDon_TI();
                            idhoadon = Convert.ToInt32(l.Substring(2, 3)) + 1;
                            //idhoadon = Convert.ToInt32(l[l.Count - 1].Substring(2, 3)) + 1;
                            s.IDHoaDon = "TI" + idhoadon.ToString("000");
                            s.IDBan = numberTable.Text.Substring(6);
                        }
                        s.NgayXuat = DateTime.Today;
                        s.TrangThai = true;
                        float t = float.Parse(txtTotal.Text);
                        s.TongTien = t;
                        s.IDNguoiDung = BLL.BLL_Login.Instance.GetIDNguoiDung_tnd(txtTenNguoiDung.Text);              ///// Truyền delegate
                        s.Note = txtNote.Text;
                        BLL.BLL_Insert.Instance.AddHoaDon(s);
                    }


                    // DatMon
                    string tt = BLL.BLL_Order.Instance.GetIDThongTinHoaDon_Last();
                    for (int i = 0; i < dataOder.Rows.Count - 1; i++)
                    {
                        //List<string> d = new List<string>();
                        DatMon datmon = new DatMon();
                        string d = BLL.BLL_Order.Instance.GetIDDatMon_Last();
                        //d.Sort();
                        int iddatmon = 0;
                        iddatmon = Convert.ToInt32(d.Substring(0)) + 1;
                        datmon.IDDatMon = iddatmon.ToString("00000");
                        datmon.IDMon = Convert.ToString(dataOder.Rows[i].Cells["IDMon"].Value);
                        datmon.IDHoaDon = s.IDHoaDon;
                        datmon.SoLuong = Convert.ToInt32(dataOder.Rows[i].Cells["SoLuong"].Value);
                        BLL.BLL_Insert.Instance.AddDatMon(datmon);


                        ThongTinHoaDon thongTinHoaDon = new ThongTinHoaDon();
                        int idThongTin = 0;
                        idThongTin = Convert.ToInt32(tt.Substring(0)) + 1 + i;
                        thongTinHoaDon.IDThongTin = idThongTin.ToString("00000");
                        thongTinHoaDon.IDHoaDon = s.IDHoaDon;
                        thongTinHoaDon.LoaiBan = BLL.BLL_Order.Instance.GetBan(s.IDBan).LoaiBan;
                        thongTinHoaDon.NgayXuat = DateTime.Today;
                        thongTinHoaDon.IDDatMon = datmon.IDDatMon;
                        thongTinHoaDon.TenMon = BLL.BLL_Order.Instance.GetMonAn_IDMon(datmon.IDMon).TenMon;
                        thongTinHoaDon.SoLuong = datmon.SoLuong;
                        thongTinHoaDon.GiaMon = BLL.BLL_Order.Instance.GetMonAn_IDMon(datmon.IDMon).Gia;
                        thongTinHoaDon.IDNguoiDung = BLL.BLL_Login.Instance.GetIDNguoiDung_tnd(txtTenNguoiDung.Text);
                        thongTinHoaDon.IDCustommer = BLL.BLL_Order.Instance.GetHoaDon(s.IDHoaDon).IDCustommer;
                        thongTinHoaDon.Note = txtNote.Text;
                        BLL.BLL_Insert.Instance.AddThongTinHoaDon(thongTinHoaDon);
                    }
                    string message = "Thông Báo";
                    string title = "Bạn có muốn in hóa đơn ?";
                    MessageBoxButtons button = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(title, message, button);
                    if (result == DialogResult.Yes)
                    {
                        if (txtDiscount.Text == "" || txtDiscount.Text == "0%")
                        {
                            GenerateReport((s.IDHoaDon).ToString(), DateTime.Now, (BLL.BLL_Order.Instance.GetBan(s.IDBan).LoaiBan).ToString(), (BLL.BLL_Login.Instance.GetIDNguoiDung_tnd(txtTenNguoiDung.Text)).ToString(), "0", ToTalBill());
                        }
                        else
                        {
                            GenerateReport((s.IDHoaDon).ToString(), DateTime.Now, (BLL.BLL_Order.Instance.GetBan(s.IDBan).LoaiBan).ToString(), (BLL.BLL_Login.Instance.GetIDNguoiDung_tnd(txtTenNguoiDung.Text)).ToString(), BLL_Order.Instance.Discount(ToTalBill()), ToTalBill());
                        }
                    }
                    else
                    {

                    }

                    this.loadCustomer();
                    txtDiscount.ResetText();
                    txtNote.ResetText();
                    NameCustomer.Clear();
                    PhoneCustomer.Clear();
                    bunifuPanel1.BringToFront();
                    bunifuPanel2.SendToBack();
                    bunifuPanel3.SendToBack();
                    txtTotal.ResetText();
                    dataOder.Rows.Clear();
                    this.Visible = false;
                }
            }
            else
            {
                if (dataOder.Rows.Count - 1 == 0)
                {
                    MessageBox.Show("You must Order before Pay!!");
                }
                else
                {
                    //customer
                    string IDBan = numberTable.Text.Substring(6);
                    string IDHoaDon = BLL.BLL_Order.Instance.GetIDHoaDon_IDTable(IDBan);
                    //Customer customer = BLL.BLL_Order.Instance.GetCustomer_IDHoaDon(IDHoaDon);
                    Customer customer = new Customer();

                    if (NameCustomer.Text == "" && PhoneCustomer.Text == "")
                    {
                        BLL.BLL_Update.Instance.Update_HoaDon(IDHoaDon, true, DateTime.Today, float.Parse(txtTotal.Text), BLL.BLL_Login.Instance.GetIDNguoiDung_tnd(txtTenNguoiDung.Text), txtNote.Text);
                    }
                    else
                    {
                        if (BLL.BLL_Setting.Instance.ktsdtt(PhoneCustomer.Text) == false)
                        {
                            MessageBox.Show("Phone Number not true!!");
                            return;
                        }
                        customer.IDCustomer = NameCustomer.Text + PhoneCustomer.Text.Substring(7);
                        customer.NameCustomer = NameCustomer.Text;
                        customer.Phone = PhoneCustomer.Text;
                        if (BLL.BLL_Order.Instance.GetIDCustomer(customer.IDCustomer) == true)
                        {

                            /*int discount = (int)BLL.BLL_Order.Instance.GetCustomer_IDCustomer(customer.IDCustomer).Discount;
                            BLL.BLL_Update.Instance.Update_Customer(customer.IDCustomer, discount + 1);*/
                            for (int i = 0; i < dataCustomer.Rows.Count; i++)
                            {
                                if (dataCustomer.Rows[i].Cells["IDCustomer"].Value.ToString() == customer.IDCustomer)
                                {
                                    dataCustomer.Rows[i].Cells["Discount"].Value = Convert.ToInt32(dataCustomer.Rows[i].Cells["Discount"].Value) + 1;
                                    BLL.BLL_Update.Instance.Update_Customer(customer.IDCustomer, Convert.ToInt32(dataCustomer.Rows[i].Cells["Discount"].Value));
                                }
                            }
                            float total = float.Parse(txtTotal.Text);
                            if (txtDiscount.Text == "10%")
                            {    // Nếu đạt chỉ tiêu discount => Tính tiền và reset Discount của khách hàng
                                for (int i = 0; i < dataCustomer.Rows.Count; i++)
                                {
                                    if (dataCustomer.Rows[i].Cells["IDCustomer"].Value.ToString() == customer.IDCustomer)
                                    {
                                        dataCustomer.Rows[i].Cells["Discount"].Value = Convert.ToInt32(dataCustomer.Rows[i].Cells["Discount"].Value) - 10;
                                        BLL.BLL_Update.Instance.Update_Customer(customer.IDCustomer, Convert.ToInt32(dataCustomer.Rows[i].Cells["Discount"].Value));
                                    }
                                }
                            }
                            BLL.BLL_Update.Instance.Update_HoaDon(IDHoaDon, true, DateTime.Today, total, BLL.BLL_Login.Instance.GetIDNguoiDung_tnd(txtTenNguoiDung.Text), customer.IDCustomer, txtNote.Text);
                        }
                        else
                        {
                            BLL.BLL_Insert.Instance.AddCustomer(customer);
                            if(BLL.BLL_Order.Instance.GetCustomer_IDCustomer(customer.IDCustomer).Discount == null)
                            {
                                int discount = 0;
                                BLL.BLL_Update.Instance.Update_Customer(customer.IDCustomer, discount + 1);
                            }
                            else
                            {
                                int discount = (int)BLL.BLL_Order.Instance.GetCustomer_IDCustomer(customer.IDCustomer).Discount;
                                BLL.BLL_Update.Instance.Update_Customer(customer.IDCustomer, discount + 1);
                            }
                            float total = float.Parse(txtTotal.Text);
                            BLL.BLL_Update.Instance.Update_HoaDon(IDHoaDon, true, DateTime.Today, float.Parse(txtTotal.Text), BLL.BLL_Login.Instance.GetIDNguoiDung_tnd(txtTenNguoiDung.Text), customer.IDCustomer, txtNote.Text);
                        }
                    }
                    //HoaDon
                    //BLL.BLL_Update.Instance.Update_HoaDon(IDHoaDon, true, DateTime.Today, float.Parse(txtTotal.Text), BLL.BLL_Login.Instance.GetIDNguoiDung_tnd(txtTenNguoiDung.Text), customer.IDCustomer);

                    //statusTable
                    BLL.BLL_Update.Instance.Status_Table(IDBan, true);

                    //Datmon
                    //List<string> d = new List<string>();
                    string d = BLL.BLL_Order.Instance.GetIDDatMon_Last();
                    string t = BLL.BLL_Order.Instance.GetIDThongTinHoaDon_Last();
                    List<DatMon> before_datmon = BLL.BLL_Order.Instance.GetDatMon_IDHoaDon(IDHoaDon);
                    for (int i = 0; i < before_datmon.Count; i++)
                    {
                        BLL.BLL_Update.Instance.Delete_DatMon_IDDatMon(before_datmon[i].IDDatMon);
                    }
                    for (int i = 0; i < dataOder.Rows.Count - 1; i++)
                    {
                        //List<string> d = new List<string>();
                        DatMon datmon = new DatMon();
                        //d = BLL.BLL_Order.Instance.GetIDDatMon();
                        int iddatmon = 0;
                        iddatmon = Convert.ToInt32(d.Substring(0)) + 1 + i;
                        datmon.IDDatMon = iddatmon.ToString("00000");
                        Console.WriteLine(datmon.IDDatMon);
                        datmon.IDMon = Convert.ToString(dataOder.Rows[i].Cells["IDMon"].Value);
                        datmon.IDHoaDon = IDHoaDon;
                        datmon.SoLuong = Convert.ToInt32(dataOder.Rows[i].Cells["SoLuong"].Value);
                        BLL.BLL_Insert.Instance.AddDatMon(datmon);

                        //ThongTinOrder
                        ThongTinHoaDon thongTinHoaDon = new ThongTinHoaDon();
                        int idThongTin = 0;
                        idThongTin = Convert.ToInt32(t.Substring(0)) + 1 + i;
                        thongTinHoaDon.IDThongTin = idThongTin.ToString("00000");
                        thongTinHoaDon.IDHoaDon = IDHoaDon;
                        thongTinHoaDon.LoaiBan = BLL.BLL_Order.Instance.GetBan(IDBan).LoaiBan;
                        thongTinHoaDon.NgayXuat = DateTime.Today;
                        thongTinHoaDon.IDDatMon = datmon.IDDatMon;
                        thongTinHoaDon.TenMon = BLL.BLL_Order.Instance.GetMonAn_IDMon(datmon.IDMon).TenMon;
                        thongTinHoaDon.SoLuong = datmon.SoLuong;
                        thongTinHoaDon.GiaMon = BLL.BLL_Order.Instance.GetMonAn_IDMon(datmon.IDMon).Gia;
                        thongTinHoaDon.IDNguoiDung = BLL.BLL_Login.Instance.GetIDNguoiDung_tnd(txtTenNguoiDung.Text);
                        thongTinHoaDon.IDCustommer = BLL.BLL_Order.Instance.GetHoaDon(IDHoaDon).IDCustommer;
                        thongTinHoaDon.Note = txtNote.Text;
                        BLL.BLL_Insert.Instance.AddThongTinHoaDon(thongTinHoaDon);

                    }
                    string message = "Thông Báo";
                    string title = "Bạn có muốn in hóa đơn ?";
                    MessageBoxButtons button = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(title, message, button);
                    if (result == DialogResult.Yes)
                    {
                        if (txtDiscount.Text == "" || txtDiscount.Text == "0%")
                        {
                            GenerateReport(IDHoaDon.ToString(), DateTime.Now, (BLL.BLL_Order.Instance.GetBan(IDBan).LoaiBan).ToString(), txtTenNguoiDung.Text.ToString(), "0", ToTalBill());
                        }
                        else
                        {
                            GenerateReport(IDHoaDon.ToString(), DateTime.Now, (BLL.BLL_Order.Instance.GetBan(IDBan).LoaiBan).ToString(), txtTenNguoiDung.Text.ToString(), BLL_Order.Instance.Discount(ToTalBill()), ToTalBill());
                        }
                    }
                    else
                    {

                    }
                    //GenerateReport(IDHoaDon.ToString(), DateTime.Now, (BLL.BLL_Order.Instance.GetBan(IDBan).LoaiBan).ToString(), BLL.BLL_Login.Instance.GetIDNguoiDung_tnd(txtTenNguoiDung.Text), (Convert.ToDouble(txtDiscount.Text) * Convert.ToDouble(txtTotal.Text)).ToString(), Convert.ToDouble(txtTotal.Text).ToString());
                    s(numberTable.Text.Substring(6), true);
                        txtDiscount.ResetText();
                        txtNote.ResetText();
                        NameCustomer.Clear();
                        PhoneCustomer.Clear();
                        bunifuPanel1.BringToFront();
                        bunifuPanel2.SendToBack();
                        bunifuPanel3.SendToBack();
                        txtTotal.ResetText();
                        dataOder.Rows.Clear();
                        this.Visible = false;
                    
                }
            }
            //catch(Exception m)
            //{
            //MessageBox.Show(m.Message);
            //}

        }
            
        private void btnDone_Click(object sender, EventArgs e)
        {
            if(statusorder == true)
            {               
                HoaDon h = new HoaDon();
                // Customer
                if (PhoneCustomer.Text != "" && NameCustomer.Text != "" )
                {
                    if(BLL.BLL_Setting.Instance.ktsdtt(PhoneCustomer.Text) == false)
                    {
                        MessageBox.Show("Phone Number not true!!");
                        return;
                    }
                    Customer customer = new Customer();
                    customer.IDCustomer = NameCustomer.Text + PhoneCustomer.Text.Substring(7);
                    customer.NameCustomer = NameCustomer.Text;
                    customer.Phone = PhoneCustomer.Text;
                    if(BLL.BLL_Order.Instance.GetIDCustomer(customer.IDCustomer) == true)
                    {

                    }
                    else
                    {
                        BLL.BLL_Insert.Instance.AddCustomer(customer);
                    }

                    // HoaDon
                    int idhoadon = 0;
                    string l = BLL_Order.Instance.GetIDHoaDon_TI();
                    idhoadon = Convert.ToInt32(l.Substring(2, 3)) + 1;
                    //idhoadon = Convert.ToInt32(l[l.Count - 1].Substring(2, 3)) + 1;
                    h.IDHoaDon = "TI" + idhoadon.ToString("000");
                    h.IDBan = numberTable.Text.Substring(6);
                    h.NgayXuat = DateTime.Today;
                    h.TrangThai = false;
                    float total = float.Parse(txtTotal.Text);
                    h.TongTien = total;
                    h.IDNguoiDung = BLL.BLL_Login.Instance.GetIDNguoiDung_tnd(txtTenNguoiDung.Text);              ///// Truyền delegate
                    h.IDCustommer = customer.IDCustomer;
                    h.Note = txtNote.Text;
                    Console.WriteLine(h.IDHoaDon);
                    BLL.BLL_Insert.Instance.AddHoaDon(h);
                }
                else
                {
                    // HoaDon
                    int idhoadon = 0;
                    string l = BLL_Order.Instance.GetIDHoaDon_TI();
                    idhoadon = Convert.ToInt32(l.Substring(2, 3)) + 1;
                    //idhoadon = Convert.ToInt32(l[l.Count - 1].Substring(2, 3)) + 1;
                    h.IDHoaDon = "TI" + idhoadon.ToString("000");
                    h.IDBan = numberTable.Text.Substring(6);
                    h.NgayXuat = DateTime.Today;
                    h.TrangThai = false;
                    float total = float.Parse(txtTotal.Text);
                    h.TongTien = total;
                    h.IDNguoiDung = BLL.BLL_Login.Instance.GetIDNguoiDung_tnd(txtTenNguoiDung.Text);              ///// Truyền delegate
                    h.Note = txtNote.Text;
                    BLL.BLL_Insert.Instance.AddHoaDon(h);
                    Console.WriteLine(h.IDHoaDon);
                }

                //Console.WriteLine(h.IDHoaDon);
                //statusTable
                BLL.BLL_Update.Instance.Status_Table(numberTable.Text.Substring(6), false);

                // DatMon
                for (int i = 0; i < dataOder.Rows.Count - 1; i++)
                {
                    //List<string> d = new List<string>();
                    DatMon datmon = new DatMon();
                    string d = BLL.BLL_Order.Instance.GetIDDatMon_Last();
                    //d.Sort();
                    int iddatmon = 0;
                    iddatmon = Convert.ToInt32(d.Substring(0)) + 1;
                    datmon.IDDatMon = iddatmon.ToString("00000");
                    datmon.IDMon = Convert.ToString(dataOder.Rows[i].Cells["IDMon"].Value);
                    Console.WriteLine(h.IDHoaDon);
                    datmon.IDHoaDon = h.IDHoaDon;
                    datmon.SoLuong = Convert.ToInt32(dataOder.Rows[i].Cells["SoLuong"].Value);
                    BLL.BLL_Insert.Instance.AddDatMon(datmon);
                }
                    /*Table t = new Table();
                    s = new Status_del(t.LoadStatusTable);*/
                    s(numberTable.Text.Substring(6), false);
                txtDiscount.ResetText();
                txtNote.ResetText();
                NameCustomer.Clear();
                PhoneCustomer.Clear();
                bunifuPanel1.BringToFront();
                bunifuPanel2.SendToBack();
                bunifuPanel3.SendToBack();
                txtTotal.ResetText();
                dataOder.Rows.Clear();
                this.Visible = false;
            }
            else
            {
                string IDBan = numberTable.Text.Substring(6);
                string IDHoaDon = BLL.BLL_Order.Instance.GetIDHoaDon_IDTable(IDBan);
                //Customer customer = BLL.BLL_Order.Instance.GetCustomer_IDHoaDon(IDHoaDon);
                Customer customer = new Customer();

                if (NameCustomer.Text == "" && PhoneCustomer.Text == "")
                {
                    BLL.BLL_Update.Instance.Update_HoaDon(IDHoaDon, false, DateTime.Today, float.Parse(txtTotal.Text), BLL.BLL_Login.Instance.GetIDNguoiDung_tnd(txtTenNguoiDung.Text), txtNote.Text);
                }
                else
                {
                    if (BLL.BLL_Setting.Instance.ktsdtt(PhoneCustomer.Text) == true)
                    {
                        customer.IDCustomer = NameCustomer.Text + PhoneCustomer.Text.Substring(7);
                        customer.NameCustomer = NameCustomer.Text;
                        customer.Phone = PhoneCustomer.Text;
                        if (BLL.BLL_Order.Instance.GetIDCustomer(customer.IDCustomer) == true)
                        {
                            BLL.BLL_Update.Instance.Update_HoaDon(IDHoaDon, false, DateTime.Today, float.Parse(txtTotal.Text), BLL.BLL_Login.Instance.GetIDNguoiDung_tnd(txtTenNguoiDung.Text), customer.IDCustomer, txtNote.Text);
                        }
                        else
                        {
                            BLL.BLL_Insert.Instance.AddCustomer(customer);

                            BLL.BLL_Update.Instance.Update_HoaDon(IDHoaDon, false, DateTime.Today, float.Parse(txtTotal.Text), BLL.BLL_Login.Instance.GetIDNguoiDung_tnd(txtTenNguoiDung.Text), customer.IDCustomer, txtNote.Text);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Phone Number not true!!");
                        return;
                    }
                }
                //HoaDon
                //BLL.BLL_Update.Instance.Update_HoaDon(IDHoaDon, false, DateTime.Today, float.Parse(txtTotal.Text), BLL.BLL_Login.Instance.GetIDNguoiDung_tnd(txtTenNguoiDung.Text), customer.IDCustomer);

                //statusTable
                BLL.BLL_Update.Instance.Status_Table(IDBan, false);

                //dat mon
                //List<string> d = new List<string>();
                string d = BLL.BLL_Order.Instance.GetIDDatMon_Last();
                List<DatMon> before_datmon = BLL.BLL_Order.Instance.GetDatMon_IDHoaDon(IDHoaDon);
                for (int i = 0; i < before_datmon.Count; i++)
                {
                    BLL.BLL_Update.Instance.Delete_DatMon_IDDatMon(before_datmon[i].IDDatMon);
                }
                for (int i = 0; i < dataOder.Rows.Count - 1; i++)
                {
                    //List<string> d = new List<string>();
                    DatMon datmon = new DatMon();
                    //d = BLL.BLL_Order.Instance.GetIDDatMon();
                    int iddatmon = 0;
                    iddatmon = Convert.ToInt32(d.Substring(0)) + 1 +i;
                    datmon.IDDatMon = iddatmon.ToString("00000");
                    datmon.IDMon = Convert.ToString(dataOder.Rows[i].Cells["IDMon"].Value);
                    datmon.IDHoaDon = IDHoaDon;
                    datmon.SoLuong = Convert.ToInt32(dataOder.Rows[i].Cells["SoLuong"].Value);
                    BLL.BLL_Insert.Instance.AddDatMon(datmon);
                }

                    s(numberTable.Text.Substring(6), false);
                txtDiscount.ResetText();
                txtNote.ResetText();
                NameCustomer.Clear();
                PhoneCustomer.Clear();
                bunifuPanel1.BringToFront();
                bunifuPanel2.SendToBack();
                bunifuPanel3.SendToBack();
                txtTotal.ResetText();
                dataOder.Rows.Clear();
                this.Visible = false;
            }

        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            if (PhoneCustomer.Text != "" || NameCustomer.Text != "")
            {
                Customer customer = new Customer();
                customer.IDCustomer = NameCustomer.Text + PhoneCustomer.Text.Substring(7);
                customer.NameCustomer = NameCustomer.Text;
                customer.Phone = PhoneCustomer.Text;
                if (BLL.BLL_Order.Instance.GetIDCustomer(customer.IDCustomer) == true)
                {
                    /*int discount = (int)BLL.BLL_Order.Instance.GetCustomer_IDCustomer(customer.IDCustomer).Discount ;
                    BLL.BLL_Update.Instance.Update_Customer(customer.IDCustomer, discount + 1);
                    Console.WriteLine(BLL.BLL_Order.Instance.GetCustomer_IDCustomer(customer.IDCustomer).Discount);*/
                    for (int i = 0; i < dataCustomer.Rows.Count; i++)
                    {
                        if (dataCustomer.Rows[i].Cells["IDCustomer"].Value.ToString() == customer.IDCustomer)
                        {
                            if (BLL.BLL_Order.Instance.GetCustomer_IDCustomer(customer.IDCustomer).Discount == null)
                            {
                                customer.Discount = 0;
                            }
                            else if ((int)dataCustomer.Rows[i].Cells["Discount"].Value >= 9)
                            {
                                txtDiscount.Text = "10%";
                                string t = Convert.ToString(float.Parse(txtTotal.Text) * (1 - 0.1));
                                txtTotal.Text = t;
                            }
                            else if((int)dataCustomer.Rows[i].Cells["Discount"].Value < 9)
                            {
                                txtDiscount.Text = "0%";
                            }
                        }
                    }
                }
                else
                {
                    
                    BLL.BLL_Insert.Instance.AddCustomer(customer);
                }
            }
            else
            {

            }
        }
        public void GenerateReport(string ID , DateTime Ngayxuat,string Ban,string Nhanvien,string discount,string Tongtien)
        {
            bunifuReports1.Clear();

            bunifuReports1.AddLineBreak();

            //bunifuReports1.AddImage(Image.FromFile("C:\\PBL3_1\\PBL3\\Resources\\180478677_479136336763688_337598169216810801_n1.jpg"), "width=200px");

            bunifuReports1.AddLineBreak();
            
            bunifuReports1.AddString("Số Hóa Đơn:  " + ID);

            bunifuReports1.AddLineBreak();
            bunifuReports1.AddLineBreak();
            bunifuReports1.AddHorizontalRule();
            bunifuReports1.AddLineBreak();

            DataTable header = new DataTable();

            header.Columns.Add("Ngày Xuất");
            header.Columns.Add("Bàn Ăn");
            header.Columns.Add("Nhân Viên");

            header.Rows.Add(new object[] { Convert.ToString(Ngayxuat), Ban, Nhanvien });

            bunifuReports1.AddDataTable(header, "width=480px border=2");
            bunifuReports1.AddHorizontalRule();
            bunifuReports1.AddDatagridView(dataOder, "width=100% border=2");
            bunifuReports1.AddLineBreak();

            DataTable sumary = new DataTable();
            sumary.Columns.Add("Tiền Bàn");
            sumary.Columns.Add(Tongtien);

            sumary.Rows.Add(new object[] { "Giảm Giá", discount });
            sumary.Rows.Add(new object[] { "VAT", 0 });
            sumary.Rows.Add(new object[] { "Thành Tiền", txtTotal.Text });



            bunifuReports1.AddDataTable(sumary, "width=480px border=2");

            bunifuReports1.ShowPrintPreviewDialog();
        }
        private void PhoneCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}