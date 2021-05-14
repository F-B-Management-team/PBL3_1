using PBL3.BLL;
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
    public partial class FormLogin : Form
    {
        public delegate void Login_del(string username, bool check);
        public Login_del d { get; set; }
        bool Check = true;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;
            if (BLL_Login.Instance.Check_account(username, password) == true)
            {
                Check = true;
                d(username, Check);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("?");
                Check = false;
            }
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
