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
    public partial class mainFrm : Form
    {
        public mainFrm(int loai)
        {
            InitializeComponent();
            if (loai == 0)
            {
                quảnLýToolStripMenuItem.Enabled = false;
                báoCáoToolStripMenuItem.Enabled = false;
            }
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_HoaDon hoadon = new frm_HoaDon();
            hoadon.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_DanhSachNhanVien danhsachnhanvien = new frm_DanhSachNhanVien();
            danhsachnhanvien.Show();
        }




        private void thôngTinVàTìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Sach thongtinsach = new frm_Sach();
            thongtinsach.Show();
        }

    
     

        private void mainFrm_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            //label1.BackColor = Color.FromArgb(100, 0, 0, 0);

        }

        private void thôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_DanhSachKhachHang danhsachkhachhang = new frm_DanhSachKhachHang();
            danhsachkhachhang.Show();
        }

        private void thôngTinSáchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
      
        }


        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Report_HoaDon rp = new frm_Report_HoaDon(); //doanh thu
            rp.Show();
        }

        private void testHoaDonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_HoaDon hd = new frm_HoaDon();
            hd.Show();
        }

        private void hóaĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }



     
    }
}
