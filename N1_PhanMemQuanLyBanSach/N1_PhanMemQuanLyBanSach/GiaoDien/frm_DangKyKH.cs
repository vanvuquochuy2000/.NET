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
    public partial class frm_DangKyKH : Form
    {
        XuLy n = new XuLy();
        public frm_DangKyKH()
        {
            InitializeComponent();
            
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaKH.Text != "")
                {
                    if(n.KTKC_KhachHang(txtMaKH.Text.Trim()) == false)
                    {
                        MessageBox.Show("Mã: " + txtMaKH.Text + " đã tồn tại, vui lòng nhập mã khác.");
                        //txtMaKH.Clear();
                        //txtMaKH.Focus();
                    }
                    if(n.DangKyKH(txtMaKH.Text, txtTenKH.Text, txtNgaySinh.Text, txtGioiTinh.Text, txtDT.Text, txtTaiKhoan.Text, txtMatKhau.Text, txtDC.Text))
                    {
                        MessageBox.Show("Đăng ký thành công.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập mã khách hàng !!!");
                }
            }
            catch
            {
                MessageBox.Show("Đăng ký thất bại.");
            }
        }



    }
}
