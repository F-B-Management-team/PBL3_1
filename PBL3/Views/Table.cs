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

        private void btnMangve_Click(object sender, EventArgs e)
        {
            order2.Visible = true;
            order2.BringToFront();
            t = new Table.Table_del(order2.statusOder);
            t(((Bunifu.UI.WinForms.BunifuButton.BunifuButton)sender).Text);
        }

        private void BthTable1_Click(object sender, EventArgs e)
        {
            order2.Visible = true;
            order2.BringToFront();
            t = new Table.Table_del(order2.statusOder);
            t(((Bunifu.UI.WinForms.BunifuButton.BunifuButton)sender).Text);
        }
    }
}
