using PBL3.Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PBL3.Views
{
    public partial class Order : UserControl
    {
        MVH_08Entities db = new MVH_08Entities();

        public Order()
        {
            InitializeComponent();
            ColumnDataOrder();
            //loadDrink();
            //loadFood();
        }
        public void statusOder(string m)
        {
            numberTable.Text = m;
            if(m == "Take out")
            {
                
                btnDone.Visible = false;
            }
            else
            {
                btnDone.Visible = true;
                
            }
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

            dataOder.Columns[0].Visible = false;
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
                //row = (DataGridViewRow)dataOder.Rows[0].Clone();
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

        private void btnPay_Click(object sender, EventArgs e)
        {
            List<string> l = new List<string>();
            HoaDon s = new HoaDon();
            if(numberTable.Text == "Take out")
            {
                l = BLL.BLL_Order.Instance.GetListIDHoaDon_TO();
                l.Sort();
                s.IDHoaDon= "TO" + (l[l.Count - 1].Substring(2, 3) +1);         //// for chạy xét từng string

                s.IDBan = "0";
            }
            s.NgayXuat = DateTime.Today;
            s.TrangThai = true;
            float t = float.Parse(txtTotal.Text);
            s.TongTien = t;
            s.IDNguoiDung = "giahung";              ///// Truyền delegate
            BLL.BLL_Insert.Instance.AddHoaDon(s);
            this.Visible = false;
        }
    }
}