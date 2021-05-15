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
    public partial class Order : UserControl
    {
        MVH_08Entities db = new MVH_08Entities();

        public Order()
        {
            InitializeComponent();
            ColumnDataOrder();
            loadDrink();
            loadFood();
        }
        public void statusOder(string m)
        {
            numberTable.Text = m;
        }
        public void ColumnDataOrder()
        {
            dataOder.ColumnCount = 3;
            dataOder.Columns[0].Name = "TenMon";
            dataOder.Columns[1].Name = "SoLuong";
            dataOder.Columns[2].Name = "Gia";
            dataOder.Rows.Clear();
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
            for (int i= 0; i < dataOder.Rows.Count ; i++)
            {
                if (dataOder.Rows[i].Cells["TenMon"].Value == dataFood.Rows[e.RowIndex].Cells["TenMon"].Value)
                {
                    k = true;
                    dataOder.Rows[i].Cells[1].Value = Convert.ToInt32(dataOder.Rows[i].Cells[1].Value) + 1;
                    dataOder.Rows[i].Cells[2].Value = Convert.ToInt32(dataFood.Rows[i].Cells[1].Value) * Convert.ToInt32(dataOder.Rows[i].Cells[1].Value);
                    break;
                }
                else
                {
                    k = false;
                }    
            }
            if(!k)
            {
                DataGridViewRow row = new DataGridViewRow();
                row = (DataGridViewRow)dataOder.Rows[0].Clone();
                row.Cells[0].Value = dataFood.Rows[e.RowIndex].Cells["TenMon"].Value;
                row.Cells[1].Value = 1;
                row.Cells[2].Value = dataFood.Rows[e.RowIndex].Cells["Gia"].Value;
                dataOder.Rows.Add(row);
            }    
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
                    dataOder.Rows[i].Cells[1].Value = Convert.ToInt32(dataOder.Rows[i].Cells[1].Value) + 1;
                    dataOder.Rows[i].Cells[2].Value = Convert.ToInt32(dataDrink.Rows[i].Cells[1].Value) * Convert.ToInt32(dataOder.Rows[i].Cells[1].Value);
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
                row.Cells[0].Value = dataDrink.Rows[e.RowIndex].Cells["TenMon"].Value;
                row.Cells[1].Value = 1;
                row.Cells[2].Value = dataDrink.Rows[e.RowIndex].Cells["Gia"].Value;
                dataOder.Rows.Add(row);
            }
        }
    }
}