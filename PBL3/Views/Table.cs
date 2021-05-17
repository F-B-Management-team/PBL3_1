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
        public delegate void Table_del(string t);
        public Table_del t { get; set; }
        public Table()
        {
            InitializeComponent();
            LoadStatusBan();
        }
        public void LoadStatusBan()
        {
            dataTable.DataSource = BLL.BLL_Table.Instance.GetBan();
            dataTable.Show();
            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                switch (Convert.ToInt32(dataTable.Rows[i].Cells["IDBan"].Value))
                {
                    case 1:
                        Console.WriteLine(dataTable.Rows[i].Cells["IDBan"].Value + "HI");
                        if(Convert.ToBoolean(dataTable.Rows[i].Cells["TrangThai"].Value) == true)
                        {
                            break;
                        }
                        else 
                        {
                            bthTable1.IdleBorderColor = Color.Yellow;
                            bthTable1.IdleFillColor = Color.Yellow;
                        }
                        break;
                    case 2:

                        break;
                }
            }
        }
        private void btnMangve_Click(object sender, EventArgs e)
        {
            //order2.Visible = true;
            this.SendToBack();
            //order2.BringToFront();
            //t = new Table.Table_del(order2.statusOder);
            t(((Bunifu.UI.WinForms.BunifuButton.BunifuButton)sender).Text);
        }

        private void BthTable1_Click(object sender, EventArgs e)
        {
            //order2.Visible = true;
            this.SendToBack();
            //order2.BringToFront();
            //t = new Table.Table_del(order2.statusOder);
            t(((Bunifu.UI.WinForms.BunifuButton.BunifuButton)sender).Text);
        }

        private void bthTable1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
