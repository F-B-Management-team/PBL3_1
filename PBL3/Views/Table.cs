using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3.Views;

namespace PBL3.Views
{
    public partial class Table : UserControl
    {
        public delegate void Table_del(string t, bool status);
        public Table_del t { get; set; }
        bool statusTable = true;
        public Table()
        {
            InitializeComponent();
        }
        public void LoadStatusBan()
        {
            Bunifu.UI.WinForms.BunifuButton.BunifuButton[] arr = new Bunifu.UI.WinForms.BunifuButton.BunifuButton[16];
            arr[0] = btnMangve;
            arr[1] = bthTable1;
            arr[2] = bthTable10;
            arr[3] = bthTable11;
            arr[4] = bthTable12;
            arr[5] = bthTable13;
            arr[6] = bthTable14;
            arr[7] = bthTable15;
            arr[8] = bthTable2;
            arr[9] = bthTable3;
            arr[10] = bthTable4;
            arr[11] = bthTable5;
            arr[12] = bthTable6;
            arr[13] = bthTable7;
            arr[14] = bthTable8;
            arr[15] = bthTable9;
            List<Bunifu.UI.WinForms.BunifuButton.BunifuButton> btnTable = new List<Bunifu.UI.WinForms.BunifuButton.BunifuButton>();
            btnTable.AddRange(arr);
            dataTable.DataSource = BLL.BLL_Table.Instance.GetBan();
            for(int i = 1; i < dataTable.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataTable.Rows[i].Cells["TrangThai"].Value) == true)
                {
                    if (dataTable.Rows[i].Cells["IDBan"].Value.ToString() == btnTable[i].Text.Substring(6))
                    {
                        btnTable[i].IdleFillColor = Color.Firebrick;
                        btnTable[i].IdleBorderColor = Color.Firebrick;
                        btnTable[i].BackColor = Color.Firebrick;
                        btnTable[i].BackColor1 = Color.Firebrick;
                        //statusTable = false;
                    }
                }
                else
                {
                    if(dataTable.Rows[i].Cells["IDBan"].Value.ToString() == btnTable[i].Text.Substring(6))
                    {
                        btnTable[i].IdleFillColor = Color.Yellow;
                        btnTable[i].IdleBorderColor = Color.Yellow;
                        btnTable[i].BackColor = Color.Yellow;
                        //statusTable = false;
                    }
                }
            }
        }
        public void LoadStatusTable(string idban, bool status)
        {
            dataTable.DataSource = BLL.BLL_Table.Instance.GetBan();
            for (int i = 1; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i].Cells["IDBan"].Value.ToString() == idban)
                {
                    dataTable.Rows[i].Cells["TrangThai"].Value = status;
                }
            }
            LoadStatusBan();
        }
        private void btnMangve_Click(object sender, EventArgs e)
        {
            order1.Visible = true;
            this.SendToBack();
            order1.BringToFront();
            order1.loadFood();
            order1.loadDrink();
            t = new Table.Table_del(order1.statusOder);
            t(((Bunifu.UI.WinForms.BunifuButton.BunifuButton)sender).Text, statusTable);
        }

        private void BthTable1_Click(object sender, EventArgs e)
        {
            if(((Bunifu.UI.WinForms.BunifuButton.BunifuButton)sender).BackColor == Color.Yellow)
            {
                statusTable = false;
            }
            else
            {
                statusTable = true;
            }
            order1.Visible = true;
            this.SendToBack();
            order1.BringToFront();
            order1.loadFood();
            order1.loadDrink();
            t = new Table.Table_del(order1.statusOder);
            if(statusTable == false)
            {
                t(((Bunifu.UI.WinForms.BunifuButton.BunifuButton)sender).Text, statusTable);
                order1.SetDataOrder_statusFalse();
            }
            else
            {
                t(((Bunifu.UI.WinForms.BunifuButton.BunifuButton)sender).Text, statusTable);
            }
        }
    }
}
