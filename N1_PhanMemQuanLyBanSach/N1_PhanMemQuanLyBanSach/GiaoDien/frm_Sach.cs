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
    public partial class frm_Sach : Form 
    {
        SqlConnection cnn = new SqlConnection("Data Source=QUOCHUY;Initial Catalog=QLSACH_BANSACHh;User ID=sa;Password=27072000");
        XuLy dt = new XuLy();
        

        public frm_Sach()
        {
            InitializeComponent();
          
        }


        private void frm_Sach_Load(object sender, EventArgs e)
        {
            cboTL.DataSource = dt.Load_Sach();
            cboTL.DisplayMember = "THELOAI";
            cboTL.ValueMember = "THELOAI";

            grdSach.DataSource = dt.Load_Sach();

            cboTimkiem.DataSource = dt.Load_Sach();
            cboTimkiem.DisplayMember = "TENSACH";
            cboTimkiem.ValueMember = "TENSACH";

            txtSoLuong.Enabled = false;
        }

        private void grdSach_SelectionChanged(object sender, EventArgs e)
        {
            if (grdSach.CurrentRow != null)
            {
                txtMaSach.Text = grdSach.CurrentRow.Cells[0].Value.ToString();
                txtTenSach.Text = grdSach.CurrentRow.Cells[1].Value.ToString();
                txtTacGia.Text = grdSach.CurrentRow.Cells[2].Value.ToString();
                txtNXB.Text = grdSach.CurrentRow.Cells[3].Value.ToString();
                cboTL.Text = grdSach.CurrentRow.Cells[4].Value.ToString();
                txtGiaBan.Text = grdSach.CurrentRow.Cells[5].Value.ToString();
                txtSoLuong.Text = grdSach.CurrentRow.Cells[6].Value.ToString();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (cnn.State == System.Data.ConnectionState.Closed)
            {
                cnn.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter("select * from SACH where TENSACH = N'" + cboTimkiem.SelectedValue + "'", cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "SACH");
            if (ds.Tables["SACH"].Rows.Count > 0)
            {
                grdSach.DataSource = ds.Tables["SACH"];
            }
            else
            {
                MessageBox.Show("Không tìm thấy sách nào có mã số này!");
                //txtMaSach.Text = "";
            }
            if (cnn.State == System.Data.ConnectionState.Open)
            {
                cnn.Close();
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaSach.Text == null)
                {
                    MessageBox.Show("Vui lòng nhập mã sách", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //cboTL.SelectedValue.ToString()
                    if (dt.ThemSach(txtMaSach.Text, txtTenSach.Text, txtTacGia.Text, txtNXB.Text, textBox1.Text, txtGiaBan.Text, txtSoLuongThem.Text))
                    {
                        MessageBox.Show("Thêm sách thành công");
                    }
                    else
                    {
                        MessageBox.Show("Thêm sách thất bại");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Thất bại", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dt.Xoa(txtMaSach.Text))
            {
                MessageBox.Show("Xoá thành công");
            }
            else
            {
                MessageBox.Show("Xoá thất bại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaSach.Text == null)
                {
                    MessageBox.Show("Vui lòng nhập mã sách", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                }
                else
                {
                    string strSoLuongThem = "";
                    int congthem = Convert.ToInt32(txtSoLuongThem.Text) + Convert.ToInt32(txtSoLuong.Text);

                    strSoLuongThem += congthem.ToString();
                    txtSoLuong.Text = strSoLuongThem;
                    txtSoLuongThem.Clear();
                    if (dt.Sua(txtMaSach.Text, txtTenSach.Text, txtTacGia.Text, txtNXB.Text, cboTL.SelectedValue.ToString(), txtGiaBan.Text, txtSoLuong.Text))
                    {
                        MessageBox.Show("Sửa thành công");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            if (dt.luu())
            {
                MessageBox.Show("Lưu thành công");
                grdSach.DataSource = dt.Load_Sach();
            }
            else
            {
                MessageBox.Show("Lưu thất bại");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grdSach.DataSource = dt.Load_Sach();
        }

    }
}














