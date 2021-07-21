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
    public partial class frm_DanhSachNhanVien : Form
    {
        XuLy dt = new XuLy();
        public frm_DanhSachNhanVien()
        {
            InitializeComponent();
        }

        private void frm_DanhSachNhanVien_Load(object sender, EventArgs e)
        {
            dataNhanVien.DataSource = dt.Load_NhanVien();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dt.luuNV())
            {
                MessageBox.Show("Lưu thành công");
            }
            else
            {
                MessageBox.Show("Lưu thất bại");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMNV.Text == null)
                {
                    MessageBox.Show("vui long nhap ma Nhân Viên", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    if (dt.Them_NhanVien(txtMNV.Text,txtTenNV.Text,txtNgay.Text,txtGT.Text,txtLuong.Text,txtSDT.Text,txtTaiKhoan.Text,txtMatKhau.Text))
                    {
                        MessageBox.Show("them thanh cong");
                    }
                    else
                    {
                        MessageBox.Show("them that bai");
                    }
                }
            }
            catch
            {
                MessageBox.Show("that bai", "thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dt.XoaNV(txtMNV.Text))
            {
                MessageBox.Show("Xoa thanh cong");
            }
            else
            {
                MessageBox.Show("Xoa that bai");
            }
        }

        private void dataNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dataNhanVien.CurrentRow != null)
            {
                txtMNV.Text = dataNhanVien.CurrentRow.Cells[0].Value.ToString();
                txtTenNV.Text = dataNhanVien.CurrentRow.Cells[1].Value.ToString();
                txtNgay.Text = dataNhanVien.CurrentRow.Cells[2].Value.ToString();
                txtGT.Text = dataNhanVien.CurrentRow.Cells[3].Value.ToString();
                txtLuong.Text = dataNhanVien.CurrentRow.Cells[4].Value.ToString();
                txtSDT.Text = dataNhanVien.CurrentRow.Cells[5].Value.ToString();
                txtTaiKhoan.Text = dataNhanVien.CurrentRow.Cells[6].Value.ToString();
                txtMatKhau.Text = dataNhanVien.CurrentRow.Cells[7].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMNV.Text == null)
                {
                    MessageBox.Show("vui long nhap ma sach", "thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                }
                else
                {
                    if (dt.SuaNV(txtMNV.Text,txtTenNV.Text,txtNgay.Text,txtGT.Text,txtLuong.Text,txtSDT.Text,txtTaiKhoan.Text,txtMatKhau.Text))
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
