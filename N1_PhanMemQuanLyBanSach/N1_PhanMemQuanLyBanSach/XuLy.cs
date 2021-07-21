using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace N1_PhanMemQuanLyBanSach
{
    public class XuLy
    {
        SqlConnection cnn = new SqlConnection("Data Source=QUOCHUY;Initial Catalog=QLSACH_BANSACHh;User ID=sa;Password=27072000");
        DataSet dsQLSach = new DataSet();
        
        SqlDataAdapter da_Sach;
        SqlDataAdapter da_NhanVien;
        SqlDataAdapter da_KhachHang;
        // dang nhap
        public bool KTDN(string pTaiKhoan, string pMatKhau)
        {
            DataRow dr_DN = dsQLSach.Tables["KHACHHANG"].Rows.Find(pTaiKhoan);

            if (dr_DN == null)
            {
                return false; // khong co nguoi dung
            }
            else
            {
                if (dr_DN["MATKHAU"].ToString() != pMatKhau)
                {
                    return false; // sai mk
                }
                else
                {
                    return true; // dn thanh cong
                }
            }
        }
        public bool DangNhapNV(string pTaiKhoan, string pMK)
        {
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                {
                    cnn.Open();
                }
                string caulenh = "select * from NHANVIEN where TAIKHOAN = '" + pTaiKhoan.ToString().Trim() + "' and MATKHAU = '" + pMK.ToString().Trim() + "'";
                SqlCommand cmd = new SqlCommand(caulenh, cnn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable result = new DataTable();
                adapter.Fill(result);
                return result.Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool DangNhapKH(string pTaiKhoan, string pMK)
        {
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                {
                    cnn.Open();
                }
                string caulenh = "select * from KHACHHANG where TAIKHOAN = '" + pTaiKhoan.ToString().Trim() + "' and MATKHAU = '" + pMK.ToString().Trim() + "'";
                SqlCommand cmd = new SqlCommand(caulenh, cnn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable result = new DataTable();
                adapter.Fill(result);
                return result.Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }

        public DataTable Load_TheLoai()
        {
            SqlDataAdapter da_TheLoai = new SqlDataAdapter("select * from SACH", cnn);

            da_TheLoai.Fill(dsQLSach, "SACH");

            return dsQLSach.Tables["SACH"];
        }

        public DataTable Load_Sach()
        {
            da_Sach = new SqlDataAdapter("select * from SACH", cnn);
            da_Sach.Fill(dsQLSach, "SACH");
            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = dsQLSach.Tables["SACH"].Columns[0];

            dsQLSach.Tables["SACH"].PrimaryKey = khoachinh;
            return dsQLSach.Tables["SACH"];
        }

        public DataTable Load_Sach_HoaDon()
        {
            da_Sach = new SqlDataAdapter("select MASACH, TENSACH, GIABAN, SOLUONG from SACH", cnn);

            da_Sach.Fill(dsQLSach, "SACH");

            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = dsQLSach.Tables["SACH"].Columns[0];

            dsQLSach.Tables["SACH"].PrimaryKey = khoachinh;

            return dsQLSach.Tables["SACH"];
        }

        public bool ThemSach(string pMaSach, string pTenSach, string pTacGia, string pNXB, string pTheLoai, string pGiaBan, string pSoLuongTon)
        {
            try
            {

                DataRow dr_Them = dsQLSach.Tables["SACH"].NewRow();

                dr_Them["MASACH"] = pMaSach;
                dr_Them["TENSACH"] = pTenSach;
                dr_Them["TACGIA"] = pTacGia;
                dr_Them["NXB"] = pNXB;
                dr_Them["THELOAI"] = pTheLoai;
                dr_Them["GIABAN"] = pGiaBan;
                dr_Them["SOLUONG"] = pSoLuongTon;

                dsQLSach.Tables["SACH"].Rows.Add(dr_Them);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool luu()
        {
            // giai quyet them nhieu cai khogn phai ket noi nhieu lan.
            try
            {
                //bước 4.
                SqlCommandBuilder build = new SqlCommandBuilder(da_Sach);

                //bước 5.
                da_Sach.Update(dsQLSach, "SACH");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Xoa(string pMaSach)
        {
            try
            {
                DataRow dr_Xoa = dsQLSach.Tables["SACH"].Rows.Find(pMaSach);

                if (dr_Xoa != null)
                {
                    dr_Xoa.Delete();
                }
                //SqlCommandBuilder build = new SqlCommandBuilder(da_Sach);
                //da_Sach.Update(dsQLSach, "SACH");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Sua(string pMaSach, string pTenSach, string pTacGia, string pNXB, string pTheLoai, string pGiaBan, string pSoLuongTon)
        {
            try
            {
                //b1
                DataRow dr_sua = dsQLSach.Tables["SACH"].Rows.Find(pMaSach);
                //b2
                dr_sua["MASACH"] = pMaSach;
                dr_sua["TENSACH"] = pTenSach;
                dr_sua["TACGIA"] = pTacGia;
                dr_sua["NXB"] = pNXB;
                dr_sua["THELOAI"] = pTheLoai;
                dr_sua["GIABAN"] = pGiaBan;
                dr_sua["SOLUONG"] = pSoLuongTon;
                //b3
                dsQLSach.Tables["SACH"].Rows.Add(dr_sua);
                return true;

            }
            catch
            {
                return false;
            }
        }


        // load KH
        public DataTable Load_KH()
        {
            SqlDataAdapter loadKH = new SqlDataAdapter("select * from KHACHHANG", cnn);

            loadKH.Fill(dsQLSach, "KHACHHANG");

            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = dsQLSach.Tables["KHACHHANG"].Columns[0];

            dsQLSach.Tables["KHACHHANG"].PrimaryKey = khoachinh;

            return dsQLSach.Tables["KHACHHANG"];
        }

        public bool TimKH(string pSDT)
        {
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                {
                    cnn.Open();
                }
                string caulenh = "select * from KHACHHANG where DT = '" + pSDT + "'";
                SqlCommand cmd = new SqlCommand(caulenh, cnn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool TimSach(string pMa)
        {
            //try
            //{
            //    if (cnn.State == System.Data.ConnectionState.Closed)
            //    {
            //        cnn.Open();
            //    }
            //    string caulenh = "select * from SACH where MASACH = '" + pMa + "'";
            //    SqlCommand cmd = new SqlCommand(caulenh, cnn);
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    if (cnn.State == System.Data.ConnectionState.Open)
            //    {
            //        cnn.Close();
            //    }
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}

            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM SACH WHERE MASACH  = '" + pMa + "'", cnn);
                DataSet ds = new DataSet();
                da.Fill(ds, "SACH");
                if (cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool KTKC_KhachHang(string pMa)
        {
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                {
                    cnn.Open();
                }
                string caulenh = "select count(*) from KHACHHANG where MAKH ='" + pMa + "')";
                SqlCommand cmd = new SqlCommand(caulenh, cnn);
                int kq = int.Parse(cmd.ExecuteScalar().ToString());
                if (cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                }
                if (kq > 0)
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DangKyKH(string pMa, string pTen, string pNgaySinh, string pGioTinh, string pSDT, string pTaiKhoan, string pMatKhau, string pDiaChi)
        {
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                {
                    cnn.Open();
                }
                string caulenh = "INSERT INTO KHACHHANG VALUES('" + pMa + "',N'" + pTen + "','" + pNgaySinh + "',N'" + pGioTinh + "','" + pSDT + "','" + pTaiKhoan + "','" + pMatKhau + "',N'" + pDiaChi + "')";
                SqlCommand cmd = new SqlCommand(caulenh, cnn);
                cmd.ExecuteNonQuery();
                if (cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool KTKC_NhanVien(string pMa)
        {
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                string caulenh = "select count(*) from NHANVIEN where MANV = '" + pMa + "'";
                SqlCommand cmd = new SqlCommand(caulenh, cnn);
                int kq = int.Parse(cmd.ExecuteScalar().ToString());
                if (cnn.State == System.Data.ConnectionState.Open)
                    cnn.Close();
                if (kq > 0)
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DangKyNV(string pMa, string pTen, string pNgaySinh, string pGioiTinh, string pLuong, string pSDT, string pTaiKhoan, string pMatKhau)
        {
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                string caulenh = "INSERT INTO NHANVIEN VALUES('" + pMa + "',N'" + pTen + "','" + pNgaySinh + "',N'" + pGioiTinh + "'," + pLuong + ",'" + pSDT + "','" + pTaiKhoan + "','" + pMatKhau + "')";
                SqlCommand cmd = new SqlCommand(caulenh, cnn);
                cmd.ExecuteNonQuery();
                if (cnn.State == System.Data.ConnectionState.Open)
                    cnn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable Load_BanSach()
        {
            da_Sach = new SqlDataAdapter("select TENSACH, GIABAN, SOLUONG from SACH", cnn);
            //da_Sach = new SqlDataAdapter("select s.TENSACH from TACGIA tg, SACH s where tg.MATG = s.TACGIA and s.TACGIA = 'TG1'", cnn); //Lay Ten Tac Gia

            da_Sach.Fill(dsQLSach, "SACH");
            return dsQLSach.Tables["SACH"];
        }

        public bool MuaSach(string pTenSach, string pTenkh, string pSoluong, string pGiaBan)
        {
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                {
                    cnn.Open();
                }
                string caulenh = "INSERT INTO BANSACH VALUES(DBO.AUTO_IDHD(),N'" + pTenSach + "',N'" + pTenkh + "','" + pSoluong + "','" + pGiaBan + "')";
                SqlCommand cmd = new SqlCommand(caulenh, cnn);
                cmd.ExecuteNonQuery();
                if (cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable LayMaHD()
        {
            //try
            //{
            //    if (cnn.State == System.Data.ConnectionState.Closed)
            //        cnn.Open();
            //    string caulenh = "select MAHD from BANSACH where MAHD = '" + pMa + "'";
            //    SqlCommand cmd = new SqlCommand(caulenh, cnn);
            //    if (cnn.State == System.Data.ConnectionState.Open)
            //        cnn.Close();
            //    return false;
            //}
            //catch
            //{
            //    return false;
            //}

            SqlDataAdapter loadMAHD = new SqlDataAdapter("select MAHOADON from BANSACH", cnn);

            loadMAHD.Fill(dsQLSach, "BANSACH");

            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = dsQLSach.Tables["BANSACH"].Columns[0];

            dsQLSach.Tables["BANSACH"].PrimaryKey = khoachinh;

            return dsQLSach.Tables["BANSACH"];
        }
       
        public DataTable Load_NhanVien()
        {
            da_NhanVien = new SqlDataAdapter("select * from NHANVIEN", cnn);

            da_NhanVien.Fill(dsQLSach, "NHANVIEN");

            DataColumn[] khoachinh = new DataColumn[1];
            khoachinh[0] = dsQLSach.Tables["NHANVIEN"].Columns[0];

            dsQLSach.Tables["NHANVIEN"].PrimaryKey = khoachinh;

            return dsQLSach.Tables["NHANVIEN"];
        }
        public bool Them_NhanVien(string pMaNV, string pTenNV, string pNgaySinh, string pGIOITINH, string pLUONG, string pSDT, string pTaiKhoan, string pMatKhau)
        {
            try
            {
                DataRow dr_Them = dsQLSach.Tables["NHANVIEN"].NewRow();

                dr_Them["MANV"] = pMaNV;
                dr_Them["HOTEN"] = pTenNV;
                dr_Them["NGAYSINH"] = pNgaySinh;
                dr_Them["GIOITINH"] = pGIOITINH;
                dr_Them["LUONG"] = pLUONG;
                dr_Them["SDT"] = pSDT;
                dr_Them["TAIKHOAN"] = pTaiKhoan;
                dr_Them["MATKHAU"] = pMatKhau;

                dsQLSach.Tables["NHANVIEN"].Rows.Add(dr_Them);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool luuNV()
        {
            // giai quyet them nhieu cai khogn phai ket noi nhieu lan.
            try
            {
                //bước 4.
                SqlCommandBuilder build = new SqlCommandBuilder(da_NhanVien);

                //bước 5.
                da_NhanVien.Update(dsQLSach, "NHANVIEN");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool XoaNV(string pMaNV)
        {
            try
            {
                DataRow dr_Xoa = dsQLSach.Tables["NHANVIEN"].Rows.Find(pMaNV);

                if (dr_Xoa != null)
                {
                    dr_Xoa.Delete();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SuaNV(string pMaNV, string pTenNV, string pNgaySinh, string pGIOITINH, string pLUONG, string pSDT, string pTaiKhoan, string pMatKhau)
        {
            try
            {
                //b1
                DataRow dr_sua = dsQLSach.Tables["NHANVIEN"].Rows.Find(pMaNV);
                //b2
                dr_sua["MANV"] = pMaNV;
                dr_sua["HOTEN"] = pTenNV;
                dr_sua["NGAYSINH"] = pNgaySinh;
                dr_sua["GIOITINH"] = pGIOITINH;
                dr_sua["LUONG"] = pLUONG;
                dr_sua["SDT"] = pSDT;
                dr_sua["TAIKHOAN"] = pTaiKhoan;
                dr_sua["MATKHAU"] = pMatKhau;

                //b3
                dsQLSach.Tables["NHANVIEN"].Rows.Add(dr_sua);



                return true;

            }
            catch
            {
                return false;
            }
        }

        //public DataTable Load_KhachHang()
        //{
        //    da_KhachHang = new SqlDataAdapter("select * from KHACHHANG", cnn);

        //    da_KhachHang.Fill(dsQLSach, "KHACHHANG");

        //    DataColumn[] khoachinh = new DataColumn[1];
        //    khoachinh[0] = dsQLSach.Tables["KHACHHANG"].Columns[0];

        //    dsQLSach.Tables["KHACHHANG"].PrimaryKey = khoachinh;

        //    return dsQLSach.Tables["KHACHHANG"];
        //}
        public bool luuKhachHang()
        {
            // giai quyet them nhieu cai khogn phai ket noi nhieu lan.
            try
            {
                //bước 4.
                
                SqlCommandBuilder build = new SqlCommandBuilder(da_KhachHang);

                //bước 5.
                da_KhachHang.Update(dsQLSach, "KHACHHANG");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool XoaKhachHang(string pMaKH)
        {
            try
            {
                DataRow dr_Xoa = dsQLSach.Tables["KHACHHANG"].Rows.Find(pMaKH);

                if (dr_Xoa != null)
                {
                    dr_Xoa.Delete();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SuaKhachHang(string pMa, string pTen, string pNgaySinh, string pGioTinh, string pSDT, string pTaiKhoan, string pMatKhau, string pDiaChi)
        {
            try
            {
                //b1
                DataRow dr_sua = dsQLSach.Tables["KHACHHANG"].Rows.Find(pMa);
                //b2
                dr_sua["MAKH"] = pMa;
                dr_sua["TENKH"] = pTen;
                dr_sua["NGAYSINH"] = pNgaySinh;
                dr_sua["GIOITINH"] = pGioTinh;
                dr_sua["SDT"] = pSDT;
                dr_sua["TAIKHOAN"] = pTaiKhoan;
                dr_sua["MATKHAU"] = pMatKhau;
                dr_sua["DIACHI"] = pDiaChi;
                //b3
                dsQLSach.Tables["KHACHHANG"].Rows.Add(dr_sua);
                return true;

            }
            catch
            {
                return false;
            }
        }


        public DataTable load_CTHD()
        {
            SqlDataAdapter load = new SqlDataAdapter("select * from HOADON", cnn);
            load.Fill(dsQLSach, "HOADON");
            return dsQLSach.Tables["HOADON"];
        }

        public bool LaySachTheoMa(string pMaHD)
        {
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                {
                    cnn.Open();
                }
                string cau_lenh = "select SACH.TENSACH from SACH, CHITIETHD, HOADON where SACH.MASACH = CHITIETHD.MASH and HOADON.MAHD = CHITIETHD.MAHD and CHITIETHD.MAHD = '" + pMaHD + "'";
                SqlCommand cmd = new SqlCommand(cau_lenh, cnn);
                cmd.ExecuteNonQuery();
                if (cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Them_HoaDon( string pMaSH, string pMaKH, string pNgayHD, string pSoLuong, string pGiaBan, string pThanhTien)
        {
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                {
                    cnn.Open();
                }
                string cau_lenh = "insert into HOADON values (DBO.AUTO_IDHDChinh(),'" + pMaSH + "','" + pMaKH + "'," + pNgayHD + "," + pSoLuong + "," + pGiaBan + "," + pThanhTien + ")";
                SqlCommand cmd = new SqlCommand(cau_lenh, cnn);
                cmd.ExecuteNonQuery();
                if (cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool update_SLSach(string pMa, string pTen, string pTacGia, string pNhaXuatBan, string pTheLoai, string pGiaBan, string pSoLuong)
        {
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                {
                    cnn.Open();
                }
                string cau_lenh = "update SACH set  TENSACH = '"+pTen+"', TACGIA = '"+pTacGia+"', NXB = '"+pNhaXuatBan+"', THELOAI = '"+pTheLoai+"',GIABAN ='"+pGiaBan+"',SOLUONG ='"+pSoLuong+"' where MASACH = '"+pMa+"'";
                SqlCommand cmd = new SqlCommand(cau_lenh, cnn);
                cmd.ExecuteNonQuery();
                if (cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
