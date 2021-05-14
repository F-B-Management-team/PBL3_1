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
        public Table()
        {
            InitializeComponent();
            
        }

        private void btnMangve_Click(object sender, EventArgs e)
        {
            order1.Visible = true;
            order1.BringToFront();
        }
    }
}
