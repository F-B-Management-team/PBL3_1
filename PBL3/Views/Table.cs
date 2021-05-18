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
        }
        public void LoadStatusBan()
        {
            dataTable.DataSource = BLL.BLL_Table.Instance.GetBan();
            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataTable.Rows[i].Cells["TrangThai"].Value) == true)
                {
                    break;
                }
                else
                {
                    bthTable1.IdleBorderColor = Color.Yellow;
                    bthTable1.IdleFillColor = Color.Yellow;
                }
                break;
            }
        }
        
        private void btnMangve_Click(object sender, EventArgs e)
        {
            order1.Visible = true;
            this.SendToBack();
            order1.BringToFront();
            order1.loadFood();
            order1.loadDrink();
            t = new Table.Table_del(order1.statusOder);
            t(((Bunifu.UI.WinForms.BunifuButton.BunifuButton)sender).Text);
        }

        private void BthTable1_Click(object sender, EventArgs e)
        {
            order1.Visible = true;
            this.SendToBack();
            order1.BringToFront();
            order1.loadFood();
            order1.loadDrink();
            t = new Table.Table_del(order1.statusOder);
            t(((Bunifu.UI.WinForms.BunifuButton.BunifuButton)sender).Text);
        }
    }
}
