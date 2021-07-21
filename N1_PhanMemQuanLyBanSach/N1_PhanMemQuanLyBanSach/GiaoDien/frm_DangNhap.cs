using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N1_PhanMemQuanLyBanSach
{
    public partial class frm_DangNhap : Form
    {
        XuLy dt = new XuLy();
        public frm_DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            frm_DangKyKH dangkykh = new frm_DangKyKH();
            dangkykh.Show();

        }

        private void btnDangKyNV_Click(object sender, EventArgs e)
        {
            frm_DangKyNV dangkynv = new frm_DangKyNV();
            dangkynv.Show();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (dt.DangNhapNV(txtTaiKhoan.Text.Trim(), txtMatKhau.Text.Trim()) == false)
                {
                    MessageBox.Show("Tên ĐN hoặc MK không đúng !!!");
                    return;
                }
                else
                {
                    int loai = 1;
                    Program.main = new mainFrm(loai);
                    Program.main.Show();
                    this.Hide();
                    //    //frm_DangNhap DN = new frm_DangNhap();
                    //    //DN.Close();
                }
            }
            if (radioButton2.Checked)
            {
                if (dt.DangNhapKH(txtTaiKhoan.Text.Trim(), txtMatKhau.Text.Trim()) == false)
                {
                    MessageBox.Show("Tên ĐN hoặc MK không đúng !!!");
                    return;
                }
                else
                {
                    int loai = 0;
                    Program.main = new mainFrm(loai);
                    Program.main.Show();
                    this.Hide();
                    //    //frm_DangNhap DN = new frm_DangNhap();
                    //    //DN.Close();
                }
            }
        }


    }
}
