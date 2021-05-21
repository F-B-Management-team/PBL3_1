using PBL3.Data;
using System;
using System.Collections.Generic;
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
            //loadDrink();
            //loadFood();
        }
        public void statusOder(string m, bool status)
        {
            numberTable.Text = m;
            statusorder = status;
            if(m == "Take out")
            {
                btnDone.Visible = false;
            }
            else
            {
                btnDone.Visible = true;
            }
        }
        public void SetDataOrder_statusFalse()
        {
            if(statusorder == false)
            {
                string IDBan = numberTable.Text.Substring(6);
                string IDHoaDon = BLL.BLL_Order.Instance.GetIDHoaDon_IDTable(IDBan);
                Customer customer = BLL.BLL_Order.Instance.GetCustomer_IDHoaDon(IDHoaDon);
                if(customer != null)
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
                MonAn monan = new MonAn();
                for(int i = 0; i < datmon.Count; i++)
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
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            dataOder.Rows.Clear();
            txtTotal.ResetText();
        }
        private void bunifuButton1_Click(object sender, EventArgs e)
        {

                bunifuPanel1.SendToBack();
                bunifuPanel3.SendToBack();
                //bunifuPanel2.Visible = false;
                bunifuPanel2.BringToFront();
                bunifuTransition1.ShowSync(bunifuPanel2);
                //loadFood();
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
                bunifuPanel1.SendToBack();
                bunifuPanel2.SendToBack();
                //bunifuPanel3.Visible = false;
                bunifuPanel3.BringToFront();
                bunifuTransition1.ShowSync(bunifuPanel3);
                //loadDrink();
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
            bool k = false ;
            for (int i= 0; i < dataOder.Rows.Count; i++)
            {
                if (dataOder.Rows[i].Cells["TenMon"].Value == dataFood.Rows[e.RowIndex].Cells["TenMon"].Value)
                {
                    k = true;
                    dataOder.Rows[i].Cells["SoLuong"].Value = Convert.ToInt32(dataOder.Rows[i].Cells["SoLuong"].Value) + 1;
                    dataOder.Rows[i].Cells["Gia"].Value = (Convert.ToInt32(dataOder.Rows[i].Cells["Gia"].Value)
                                                       / (Convert.ToInt32(dataOder.Rows[i].Cells["SoLuong"].Value)-1))
                                                        *Convert.ToInt32(dataOder.Rows[i].Cells["SoLuong"].Value);
                    break;
                }
                else
                {
                    k = false;
                }    
            }
            if(!k)
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
                                                       / (Convert.ToInt32(dataOder.Rows[i].Cells["SoLuong"].Value)-1))
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
            for(int i=0; i< dataOder.Rows.Count ; i++)
            {
                total = total + Convert.ToDouble(dataOder.Rows[i].Cells["Gia"].Value);
            }
            txtTotal.Text = (total).ToString();
        }
        public bool TextChange(string before, string after)
        {
            if (before == after)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnPay_Click(object sender, EventArgs e)
        { 
            //// TRUE
            try
            {
                if (statusorder == true)
                {
                    // Customer
                    if (PhoneCustomer.Text != "" || NameCustomer.Text != "")
                    {
                        Customer customer = new Customer();
                        customer.IDCustomer = NameCustomer.Text + PhoneCustomer.Text.Substring(7);
                        customer.NameCustomer = NameCustomer.Text;
                        customer.Phone = PhoneCustomer.Text;
                        BLL.BLL_Insert.Instance.AddCustomer(customer);
                    }

                    // HoaDon
                    List<string> l = new List<string>();
                    HoaDon s = new HoaDon();
                    if (numberTable.Text == "Take out")
                    {
                        l = BLL.BLL_Order.Instance.GetListIDHoaDon_TO();
                        //l.Sort();
                        int idhoadon = 0;
                        idhoadon = Convert.ToInt32(l[l.Count - 1].Substring(2, 3)) + 1;
                        s.IDHoaDon = "TO" + idhoadon.ToString("000");
                        s.IDBan = "0";
                    }
                    else
                    {
                        l = BLL.BLL_Order.Instance.GetListIDHoaDon_TI();
                        int idhoadon = 0;
                        idhoadon = Convert.ToInt32(l[l.Count - 1].Substring(2, 3)) + 1;
                        s.IDHoaDon = "TI" + idhoadon.ToString("000");
                        s.IDBan = numberTable.Text.Substring(6);
                    }
                    s.NgayXuat = DateTime.Today;
                    s.TrangThai = true;
                    float t = float.Parse(txtTotal.Text);
                    s.TongTien = t;
                    s.IDNguoiDung = BLL.BLL_Login.Instance.GetIDNguoiDung_tnd(txtTenNguoiDung.Text);              ///// Truyền delegate
                    s.IDCustommer = PhoneCustomer.Text;
                    BLL.BLL_Insert.Instance.AddHoaDon(s);


                    // DatMon
                    for (int i = 0; i < dataOder.Rows.Count - 1; i++)
                    {
                        List<string> d = new List<string>();
                        DatMon datmon = new DatMon();
                        d = BLL.BLL_Order.Instance.GetIDDatMon();
                        //d.Sort();
                        int iddatmon = 0;
                        iddatmon = Convert.ToInt32(d[d.Count - 1].Substring(0, 5)) + 1;
                        datmon.IDDatMon = iddatmon.ToString("00000");
                        datmon.IDMon = Convert.ToString(dataOder.Rows[i].Cells["IDMon"].Value);
                        datmon.IDHoaDon = s.IDHoaDon;
                        datmon.SoLuong = Convert.ToInt32(dataOder.Rows[i].Cells["SoLuong"].Value);
                        BLL.BLL_Insert.Instance.AddDatMon(datmon);

                    }
                    NameCustomer.Clear();
                    PhoneCustomer.Clear();
                    bunifuPanel1.BringToFront();
                    txtTotal.ResetText();
                    dataOder.Rows.Clear();
                    this.Visible = false;
                }
                else
                {
                    //customer
                    string IDBan = numberTable.Text.Substring(6);
                    string IDHoaDon = BLL.BLL_Order.Instance.GetIDHoaDon_IDTable(IDBan);
                    Customer customer = BLL.BLL_Order.Instance.GetCustomer_IDHoaDon(IDHoaDon);
                    if (NameCustomer.Text == "" && PhoneCustomer.Text == "")
                    {
                        BLL.BLL_Update.Instance.Update_HoaDon(IDHoaDon, true, DateTime.Today, float.Parse(txtTotal.Text), BLL.BLL_Login.Instance.GetIDNguoiDung_tnd(txtTenNguoiDung.Text));
                    }
                    else
                    {
                        if (BLL.BLL_Order.Instance.GetIDCustomer(NameCustomer.Text + PhoneCustomer.Text.Substring(7)) == true)
                        {
                            BLL.BLL_Update.Instance.Update_HoaDon(IDHoaDon, true, DateTime.Today, float.Parse(txtTotal.Text), BLL.BLL_Login.Instance.GetIDNguoiDung_tnd(txtTenNguoiDung.Text));
                        }
                        else
                        {
                            customer.IDCustomer = NameCustomer.Text + PhoneCustomer.Text.Substring(7);
                            customer.NameCustomer = NameCustomer.Text;
                            customer.Phone = PhoneCustomer.Text;
                            BLL.BLL_Insert.Instance.AddCustomer(customer);

                            BLL.BLL_Update.Instance.Update_HoaDon(IDHoaDon, true, DateTime.Today, float.Parse(txtTotal.Text), BLL.BLL_Login.Instance.GetIDNguoiDung_tnd(txtTenNguoiDung.Text), customer.IDCustomer);
                        }
                    }
                    //HoaDon
                    //BLL.BLL_Update.Instance.Update_HoaDon(IDHoaDon, true, DateTime.Today, float.Parse(txtTotal.Text), BLL.BLL_Login.Instance.GetIDNguoiDung_tnd(txtTenNguoiDung.Text), customer.IDCustomer);

                    //statusTable
                    BLL.BLL_Update.Instance.Status_Table(IDBan, true);

                    //Datmon
                    List<DatMon> before_datmon = BLL.BLL_Order.Instance.GetDatMon_IDHoaDon(IDHoaDon);
                    for (int i = 0; i < before_datmon.Count; i++)
                    {
                        BLL.BLL_Update.Instance.Delete_DatMon_IDDatMon(before_datmon[i].IDDatMon);
                    }
                    for (int i = 0; i < dataOder.Rows.Count - 1; i++)
                    {
                        List<string> d = new List<string>();
                        DatMon datmon = new DatMon();
                        d = BLL.BLL_Order.Instance.GetIDDatMon();
                        //d.Sort();
                        int iddatmon = 0;
                        iddatmon = Convert.ToInt32(d[d.Count - 1].Substring(0, 5)) + 1;
                        datmon.IDDatMon = iddatmon.ToString("00000");
                        datmon.IDMon = Convert.ToString(dataOder.Rows[i].Cells["IDMon"].Value);
                        datmon.IDHoaDon = IDHoaDon;
                        datmon.SoLuong = Convert.ToInt32(dataOder.Rows[i].Cells["SoLuong"].Value);
                        BLL.BLL_Insert.Instance.AddDatMon(datmon);
                    }
                        Table t = new Table();
                        s = new Status_del(t.LoadStatusTable);
                        s(numberTable.Text.Substring(6), true);
                    NameCustomer.Clear();
                    PhoneCustomer.Clear();
                    bunifuPanel1.BringToFront();
                    txtTotal.ResetText();
                    dataOder.Rows.Clear();
                    this.Visible = false;
                }
            }
            catch(Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }
            
        private void btnDone_Click(object sender, EventArgs e)
        {
            if(statusorder == true)
            {
                // Customer
                if (PhoneCustomer.Text != "" || NameCustomer.Text != "")
                {
                    Customer customer = new Customer();
                    customer.IDCustomer = NameCustomer.Text + PhoneCustomer.Text.Substring(7);
                    customer.NameCustomer = NameCustomer.Text;
                    customer.Phone = PhoneCustomer.Text;
                    BLL.BLL_Insert.Instance.AddCustomer(customer);
                }

                // HoaDon
                List<string> l = new List<string>();
                HoaDon h = new HoaDon();
                l = BLL.BLL_Order.Instance.GetListIDHoaDon_TI();
                int idhoadon = 0;
                idhoadon = Convert.ToInt32(l[l.Count - 1].Substring(2, 3)) + 1;
                h.IDHoaDon = "TI" + idhoadon.ToString("000");
                h.IDBan = numberTable.Text.Substring(6);
                h.NgayXuat = DateTime.Today;
                h.TrangThai = false;
                float total = float.Parse(txtTotal.Text);
                h.TongTien = total;
                h.IDNguoiDung = BLL.BLL_Login.Instance.GetIDNguoiDung_tnd(txtTenNguoiDung.Text);              ///// Truyền delegate
                h.IDCustommer = PhoneCustomer.Text;
                BLL.BLL_Insert.Instance.AddHoaDon(h);

                //statusTable
                BLL.BLL_Update.Instance.Status_Table(numberTable.Text.Substring(6), false);

                // DatMon
                for (int i = 0; i < dataOder.Rows.Count - 1; i++)
                {
                    List<string> d = new List<string>();
                    DatMon datmon = new DatMon();
                    d = BLL.BLL_Order.Instance.GetIDDatMon();
                    //d.Sort();
                    int iddatmon = 0;
                    iddatmon = Convert.ToInt32(d[d.Count - 1].Substring(0, 5)) + 1;
                    datmon.IDDatMon = iddatmon.ToString("00000");
                    datmon.IDMon = Convert.ToString(dataOder.Rows[i].Cells["IDMon"].Value);
                    datmon.IDHoaDon = "TI" + idhoadon.ToString("000");
                    datmon.SoLuong = Convert.ToInt32(dataOder.Rows[i].Cells["SoLuong"].Value);
                    BLL.BLL_Insert.Instance.AddDatMon(datmon);
                }
                    Table t = new Table();
                    s = new Status_del(t.LoadStatusTable);
                    s(numberTable.Text.Substring(6), false);
                NameCustomer.Clear();
                PhoneCustomer.Clear();
                bunifuPanel1.BringToFront();
                txtTotal.ResetText();
                dataOder.Rows.Clear();
                this.Visible = false;
            }
            else
            {
                string IDBan = numberTable.Text.Substring(6);
                string IDHoaDon = BLL.BLL_Order.Instance.GetIDHoaDon_IDTable(IDBan);
                Customer customer = BLL.BLL_Order.Instance.GetCustomer_IDHoaDon(IDHoaDon);
                if (NameCustomer.Text == "" && PhoneCustomer.Text == "")
                {
                    BLL.BLL_Update.Instance.Update_HoaDon(IDHoaDon, false, DateTime.Today, float.Parse(txtTotal.Text), BLL.BLL_Login.Instance.GetIDNguoiDung_tnd(txtTenNguoiDung.Text));
                }
                else
                {
                    if (BLL.BLL_Order.Instance.GetIDCustomer(NameCustomer.Text + PhoneCustomer.Text.Substring(7)) == true)
                    {
                        BLL.BLL_Update.Instance.Update_HoaDon(IDHoaDon, false, DateTime.Today, float.Parse(txtTotal.Text), BLL.BLL_Login.Instance.GetIDNguoiDung_tnd(txtTenNguoiDung.Text));
                    }
                    else
                    {
                        customer.IDCustomer = NameCustomer.Text + PhoneCustomer.Text.Substring(7);
                        customer.NameCustomer = NameCustomer.Text;
                        customer.Phone = PhoneCustomer.Text;
                        BLL.BLL_Insert.Instance.AddCustomer(customer);

                        BLL.BLL_Update.Instance.Update_HoaDon(IDHoaDon, false, DateTime.Today, float.Parse(txtTotal.Text), BLL.BLL_Login.Instance.GetIDNguoiDung_tnd(txtTenNguoiDung.Text), customer.IDCustomer);
                    }
                }
                //HoaDon
                //BLL.BLL_Update.Instance.Update_HoaDon(IDHoaDon, false, DateTime.Today, float.Parse(txtTotal.Text), BLL.BLL_Login.Instance.GetIDNguoiDung_tnd(txtTenNguoiDung.Text), customer.IDCustomer);

                //statusTable
                BLL.BLL_Update.Instance.Status_Table(IDBan, false);

                //dat mon
                List<DatMon> before_datmon = BLL.BLL_Order.Instance.GetDatMon_IDHoaDon(IDHoaDon);
                for (int i = 0; i < before_datmon.Count; i++)
                {
                    Console.WriteLine(before_datmon[i].IDDatMon);
                    BLL.BLL_Update.Instance.Delete_DatMon_IDDatMon(before_datmon[i].IDDatMon);
                }
                for (int i = 0; i < dataOder.Rows.Count - 1; i++)
                {
                    List<string> d = new List<string>();
                    DatMon datmon = new DatMon();
                    d = BLL.BLL_Order.Instance.GetIDDatMon();
                    int iddatmon = 0;
                    iddatmon = Convert.ToInt32(d[d.Count - 1].Substring(0)) + 1 ;
                    datmon.IDDatMon = iddatmon.ToString("00000");
                    datmon.IDMon = Convert.ToString(dataOder.Rows[i].Cells["IDMon"].Value);
                    datmon.IDHoaDon = IDHoaDon;
                    datmon.SoLuong = Convert.ToInt32(dataOder.Rows[i].Cells["SoLuong"].Value);
                    BLL.BLL_Insert.Instance.AddDatMon(datmon);
                }
                    Table t = new Table();
                    s = new Status_del(t.LoadStatusTable);
                    s(numberTable.Text.Substring(6), false);
                NameCustomer.Clear();
                PhoneCustomer.Clear();
                bunifuPanel1.BringToFront();
                txtTotal.ResetText();
                dataOder.Rows.Clear();
                this.Visible = false;
            }
        }
    }
}