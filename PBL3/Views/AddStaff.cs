using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3.BLL;
using PBL3.DAL;
using PBL3.Data;

namespace PBL3.Views
{
    public partial class AddStaff : UserControl
    {
        string ID { get; set; }
        public delegate void Mydel(string IDNguoiDung);
        public Mydel d { get; set; }
        MVH_08Entities db = new MVH_08Entities();
        //private string IDNguoiDung;
        public AddStaff()
        {
            InitializeComponent();
            SetCBBAdd();
            //if (ID != null)
            //    txtIDNguoiDung.Enabled = true;

        }
        public void SetCBBAdd()
        {
            string[] cbb = new string[] { "staff", "manage" };
            cbbCVadd.Items.AddRange(cbb);
        }
        public void setid(string a)
        {
            txtIDNguoiDung.Enabled = true;
            this.ID = a;
        }
        public void loadEditStaff(string IDNguoiDung)
        {
            txtIDNguoiDung.Enabled = false;
            txtIDNguoiDung.Text = IDNguoiDung;
            this.ID = IDNguoiDung;
            ThongTinNguoiDung nd = BLL_Setting.Instance.TimNguoiDung(IDNguoiDung);
            txtTenND.Text = nd.TenNguoiDung;
            txtPhone.Text = nd.PhoneNumber;
            dateTimePicker1.Value = Convert.ToDateTime(nd.NgaySinh);
            if (nd.GioiTinh == true)
            {
                radioButtonMale.Checked = true;
            }
            else
            {
                radioButtonFemale.Checked = true;
            }
            TaiKhoan tk = BLL_Setting.Instance.TimTaiKhoan(IDNguoiDung);
            txtTenDN.Text = tk.TenDangNhap;
            txtMK.Text = tk.MatKhau;
            cbbCVadd.Text = tk.Chucvu;
            //SetCBBAdd();
        }
        public void Them()
        {
            joinTK a = new joinTK
            {
                IDNguoiDung = txtIDNguoiDung.Text,
                Chucvu = cbbCVadd.Text,
                GioiTinh = radioButtonMale.Checked,
                MatKhau = txtMK.Text,
                NgaySinh = Convert.ToDateTime(dateTimePicker1.Value),
                PhoneNumber = txtPhone.Text,
                TenDangNhap = txtTenDN.Text,
                TenNguoiDung = txtTenND.Text,
            };
            ThongTinNguoiDung nd = new ThongTinNguoiDung
            {
                IDNguoiDung = a.IDNguoiDung,
                TenNguoiDung = a.TenNguoiDung,
                GioiTinh = a.GioiTinh,
                NgaySinh = a.NgaySinh,
                PhoneNumber = a.PhoneNumber,
            };
            TaiKhoan tk = new TaiKhoan
            {
                IDNguoiDung = a.IDNguoiDung,
                TenDangNhap = a.TenDangNhap,
                MatKhau = a.MatKhau,
                Chucvu = a.Chucvu,
            };
            BLL_Setting.Instance.addStaff_BLL(nd, tk);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtIDNguoiDung.Clear();
            txtMK.Clear();
            txtPhone.Clear();
            txtTenDN.Clear();
            txtTenND.Clear();

            radioButtonFemale.Checked = false;
            radioButtonMale.Checked = false;
            this.SendToBack();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ID == "")
            {
                if (txtIDNguoiDung.Text == "" || ((BLL_Setting.Instance.sosanhIDtt(txtIDNguoiDung.Text)) != false) || txtTenDN.Text == "" || txtTenND.Text == "" || txtMK.Text == "" || cbbCVadd.Text == "" || (radioButtonMale.Checked == false && radioButtonFemale.Checked == false))
                {
                    string message = "Loi";
                    string title = "Loi";
                    MessageBox.Show(message, title);
                }
                else
                {
                    Them();
                    txtIDNguoiDung.Clear();
                    txtMK.Clear();
                    txtPhone.Clear();
                    txtTenDN.Clear();
                    txtTenND.Clear();
                    cbbCVadd.ResetText();
                    radioButtonFemale.Checked = false;
                    radioButtonMale.Checked = false;
                    this.SendToBack();
                }
            }
            else
            {
                BLL_Setting.Instance.update_BLL(txtIDNguoiDung.Text, txtTenDN.Text, radioButtonMale.Checked, Convert.ToDateTime(dateTimePicker1.Value), txtTenDN.Text, txtMK.Text, cbbCVadd.Text);
                txtIDNguoiDung.Clear();
                txtMK.Clear();
                txtPhone.Clear();
                txtTenDN.Clear();
                txtTenND.Clear();
                cbbCVadd.Items.Clear();
                radioButtonFemale.Checked = false;
                radioButtonMale.Checked = false;
                this.SendToBack();
                this.ResetText();

            }

        }
    }
}
