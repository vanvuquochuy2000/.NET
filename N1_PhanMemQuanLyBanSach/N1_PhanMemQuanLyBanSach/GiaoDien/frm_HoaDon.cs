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
    public partial class frm_HoaDon : Form
    {
        XuLy n = new XuLy();
        public frm_HoaDon()
        {
            InitializeComponent();

            
        }

        private void btnbsct_Click(object sender, EventArgs e)
        {

        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_HoaDon_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = n.Load_KH();
            comboBox1.ValueMember = "TENKH";
            comboBox1.DisplayMember = "MAKH";

            dataGridView1.DataSource = n.load_CTHD();
            dataGridView2.DataSource = n.Load_Sach();
            txtGiaBan.Enabled = false;
            txtSoluong.Enabled = false;
            txtTongTien.Enabled = false;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2 != null)
            {
                txtMaSach.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                txtTenSach.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                txtTacGia.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                txtNXB.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                txtTheLoai.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                txtGiaBan.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                txtSoluong.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            }
        }

        private void btnDatHang_Click(object sender, EventArgs e)
        {
            try
            {
                if (n.Them_HoaDon(txtMaSach.Text, comboBox1.Text, txtNgayHD.Text, txtSoLuongMua.Text, txtGiaBan.Text, txtTongTien.Text))
                {
                    MessageBox.Show("Thêm hoá đơn thành công");

                    dataGridView1.DataSource = n.load_CTHD();
                    dataGridView2.DataSource = n.Load_Sach();
                }
            }
            catch
            {
                MessageBox.Show("Thêm hoá đơn thất bại");
            }
        }

        private void txtSoLuongMua_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            string strTinhTien = "";
            int tinhtongtien = Convert.ToInt32(txtGiaBan.Text) * Convert.ToInt32(txtSoLuongMua.Text);
            strTinhTien += tinhtongtien.ToString();
            txtTongTien.Text = strTinhTien;


            string strTonSach = "";
            int update_sach = Convert.ToInt32(txtSoluong.Text) - Convert.ToInt32(txtSoLuongMua.Text);
            strTonSach += update_sach.ToString();
            txtSoluong.Text = strTonSach;

            try
            {
                if (txtMaSach.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập mã sách");
                }
                if (n.update_SLSach(txtMaSach.Text, txtTenSach.Text, txtTacGia.Text, txtNXB.Text, txtTheLoai.Text, txtGiaBan.Text, txtSoluong.Text))
                {
                    MessageBox.Show("Thanh toán thành công");
                }
            }
            catch
            {
                MessageBox.Show("Thanh toán thất bại");
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenKH.Text = comboBox1.SelectedValue.ToString();
        }

    }
}
