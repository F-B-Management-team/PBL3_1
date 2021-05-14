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
    public partial class FormLogout : Form
    {
        public delegate void Logout_del(string username, bool check);
        public Logout_del d { get; set; }
        public FormLogout()
        {
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            d(" ", false);
            this.Close();
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
