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
    public partial class frm_DangKyNV : Form
    {
        XuLy n = new XuLy();
        public frm_DangKyNV()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNV.Text != "")
                {
                    if(!n.KTKC_NhanVien(txtMaNV.Text))
                    {
                        MessageBox.Show("Mã nhân viên: " +txtMaNV.Text.Trim()+" đã tồn tại, vui lòng nhập mã khác.");
                        txtMaNV.Clear();
                        txtMaNV.Focus();
                        return;
                    }
                    if(n.DangKyNV(txtMaNV.Text,txtTenNV.Text,txtNgaySinh.Text,txtGioiTinh.Text,txtLuong.Text,txtSDT.Text,txtTaiKhoan.Text,txtMatKhau.Text));
                    {
                        MessageBox.Show("Thêm nhân viên thành công.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập mã nhân viên.");
                }

            }
            catch
            {
                MessageBox.Show("Thêm nhân viên thất bại !!!");
            }
        }


    }
}
