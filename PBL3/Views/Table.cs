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
            PictureBox[] prr = new PictureBox[16];
            prr[0] = pictureBox16;
            prr[1] = pictureBox1;
            prr[2] = pictureBox10;
            prr[3] = pictureBox11;
            prr[4] = pictureBox12;
            prr[5] = pictureBox13;
            prr[6] = pictureBox14;
            prr[7] = pictureBox15;
            prr[8] = pictureBox2;
            prr[9] = pictureBox3;
            prr[10] = pictureBox4;
            prr[11] = pictureBox5;
            prr[12] = pictureBox6;
            prr[13] = pictureBox7;
            prr[14] = pictureBox8;
            prr[15] = pictureBox9;
            List<PictureBox> picturebox = new List<PictureBox>();
            picturebox.AddRange(prr);
            dataTable.DataSource = BLL.BLL_Table.Instance.GetBan();
            for(int i = 1; i < dataTable.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataTable.Rows[i].Cells["TrangThai"].Value) == true)
                {
                    if (dataTable.Rows[i].Cells["IDBan"].Value.ToString() == btnTable[i].Text.Substring(6))
                    {
                        /*btnTable[i].IdleFillColor = Color.Firebrick;
                        btnTable[i].IdleBorderColor = Color.Firebrick;
                        btnTable[i].BackColor = Color.Firebrick;
                        btnTable[i].BackColor1 = Color.Firebrick;*/
                        picturebox[i].Image = global::PBL3.Properties.Resources.table;
                        picturebox[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        //statusTable = false;
                    }
                }
                else
                {
                    if(dataTable.Rows[i].Cells["IDBan"].Value.ToString() == btnTable[i].Text.Substring(6))
                    {
                        /*btnTable[i].IdleFillColor = Color.Yellow;
                        btnTable[i].IdleBorderColor = Color.Yellow;
                        btnTable[i].BackColor = Color.Yellow;*/
                        picturebox[i].Image = global::PBL3.Properties.Resources.yellow;
                        picturebox[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
                        //statusTable = false;
                    }
                }
            }
        }
        public void LoadStatusTable(string idban, bool status)
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
            PictureBox[] prr = new PictureBox[16];
            prr[0] = pictureBox16;
            prr[1] = pictureBox1;
            prr[2] = pictureBox10;
            prr[3] = pictureBox11;
            prr[4] = pictureBox12;
            prr[5] = pictureBox13;
            prr[6] = pictureBox14;
            prr[7] = pictureBox15;
            prr[8] = pictureBox2;
            prr[9] = pictureBox3;
            prr[10] = pictureBox4;
            prr[11] = pictureBox5;
            prr[12] = pictureBox6;
            prr[13] = pictureBox7;
            prr[14] = pictureBox8;
            prr[15] = pictureBox9;
            List<PictureBox> picturebox = new List<PictureBox>();
            picturebox.AddRange(prr);
            //dataTable.DataSource = BLL.BLL_Table.Instance.GetBan();
            for (int i = 1; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i].Cells["IDBan"].Value.ToString() == idban)
                {
                    dataTable.Rows[i].Cells["TrangThai"].Value = status;
                }
            }
            for (int i = 1; i < dataTable.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataTable.Rows[i].Cells["TrangThai"].Value) == true)
                {
                    if (dataTable.Rows[i].Cells["IDBan"].Value.ToString() == btnTable[i].Text.Substring(6))
                    {
                        /*btnTable[i].IdleFillColor = Color.Firebrick;
                        btnTable[i].IdleBorderColor = Color.Firebrick;
                        btnTable[i].BackColor = Color.Firebrick;
                        btnTable[i].BackColor1 = Color.Firebrick;*/
                        picturebox[i].Image = global::PBL3.Properties.Resources.table;
                        picturebox[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        //statusTable = false;
                    }
                }
                else
                {
                    if (dataTable.Rows[i].Cells["IDBan"].Value.ToString() == btnTable[i].Text.Substring(6))
                    {
                        /*btnTable[i].IdleFillColor = Color.Yellow;
                        btnTable[i].IdleBorderColor = Color.Yellow;
                        btnTable[i].BackColor = Color.Yellow;*/
                        picturebox[i].Image = global::PBL3.Properties.Resources.yellow;
                        picturebox[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
                        //statusTable = false;
                    }
                }
            }
            //LoadStatusBan();
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
            for(int i = 1; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i].Cells["IDBan"].Value.ToString() == ((Bunifu.UI.WinForms.BunifuButton.BunifuButton)sender).Text.Substring(6))
                {
                    if(Convert.ToBoolean(dataTable.Rows[i].Cells["TrangThai"].Value) == true)
                    {
                        statusTable = true;
                    }
                    else
                    {
                        statusTable = false;
                    }
                }
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
