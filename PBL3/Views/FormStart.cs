using PBL3.Views;
using System;
using System.Drawing;
using System.Windows.Forms;
using PBL3.Data;

namespace PBL3
{
    public partial class FormStart : Form
    {
        public delegate void User_del(string TenNguoiDung);
        public User_del d { get; set; }
        public string user { get; set; }
        public bool check_login { get; set; }
        public FormStart(string username)
        {
            user = username;
            InitializeComponent();
            Check_Login(false);
            
        }
        public void Check_Login(bool check)
        {
            if(check == false)
            {
                bunifuPages1.SetPage(0);
                btnLogin.BringToFront();
                btnLogout.SendToBack();
                btnOrder.Enabled = false;
                btnBill.Enabled = false;
                btnSetting.Enabled = false;
            }
            if(check == true)
            {
                bunifuPages1.SetPage(0);
                btnLogin.SendToBack();
                btnLogout.BringToFront();
                btnOrder.Enabled = true;
                btnBill.Enabled = true;
                btnSetting.Enabled = true;
            }    
        }
        public void Login(string username, bool check)
        {
            User.Text = BLL.BLL_Login.Instance.GetTenNguoiDung(BLL.BLL_Login.Instance.GetIDNguoiDung_tdn(username));
            check_login = check;
            Check_Login(check_login);
        }
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.d = new FormLogin.Login_del(Login);
            login.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(0);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(1);
            table1.LoadStatusBan();
            d = new User_del(table1.order1.SetNguoiDung);
            d(User.Text); 
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FormLogout logout = new FormLogout();
            logout.d = new FormLogout.Logout_del(Login);
            logout.ShowDialog();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(2);

            manageBill1.Setcbb();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(3);
        }
    }
}
