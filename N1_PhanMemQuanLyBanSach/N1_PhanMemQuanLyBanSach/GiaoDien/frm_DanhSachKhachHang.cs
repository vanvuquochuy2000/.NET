using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace N1_PhanMemQuanLyBanSach
{
    public partial class frm_DanhSachKhachHang : Form
    {
        XuLy dt = new XuLy();
        public frm_DanhSachKhachHang()
        {
            InitializeComponent();
        }

        private void frm_DanhSachKhachHang_Load(object sender, EventArgs e)
        {
            grdKhachHang.DataSource = dt.Load_KH();
            
        }



        private void btnTim_Click(object sender, EventArgs e)
        {
            if (dt.TimKH(txtTimKiem.Text))
            {
                MessageBox.Show("Khach Hang da co");
            }
            else
            {               
                MessageBox.Show("chua co khach hang nay");
            }
        }

        private void grdKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (grdKhachHang.CurrentRow != null)
            {
                txtMaKH.Text = grdKhachHang.CurrentRow.Cells[0].Value.ToString();
                txtTenKH.Text = grdKhachHang.CurrentRow.Cells[1].Value.ToString();
                txtNgaySinh.Text = grdKhachHang.CurrentRow.Cells[2].Value.ToString();
                txtGT.Text = grdKhachHang.CurrentRow.Cells[3].Value.ToString();
                txtSDT.Text = grdKhachHang.CurrentRow.Cells[4].Value.ToString();
                txtTaiKhoan.Text = grdKhachHang.CurrentRow.Cells[5].Value.ToString();
                txtMatKhau.Text = grdKhachHang.CurrentRow.Cells[6].Value.ToString();
                txtDiachi.Text = grdKhachHang.CurrentRow.Cells[7].Value.ToString();
            }
        }

        private void tbnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaKH.Text == null)
                {
                    MessageBox.Show("vui long nhap ma sach", "thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                }
                else
                {
                    if (dt.SuaKhachHang(txtMaKH.Text,txtTenKH.Text,txtGT.Text,txtGT.Text,txtSDT.Text,txtTaiKhoan.Text,txtMatKhau.Text,txtDiachi.Text))
                    {
                        MessageBox.Show("Sua thanh cong");
                    }
                }
            }
            catch
            {
                MessageBox.Show("that bai");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dt.XoaKhachHang(txtMaKH.Text))
            {
                MessageBox.Show("Xoa thanh cong");
            }
            else
            {
                MessageBox.Show("Xoa that bai");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dt.luuKhachHang())
            {
                MessageBox.Show("Lưu thành công");
            }
            else
            {
                MessageBox.Show("Lưu thất bại");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

      

    

      
    }
}
