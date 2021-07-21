using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N1_PhanMemQuanLyBanSach
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public static frm_DangNhap frmDN = null;
        public static mainFrm main = null;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmDN = new frm_DangNhap();
            Application.Run(frmDN);


        }
    }
}
