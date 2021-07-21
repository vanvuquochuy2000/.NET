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
    public partial class frm_Report_HoaDon : Form
    {
        public frm_Report_HoaDon()
        {
            InitializeComponent();
            
            CrystalReport1 rpt = new CrystalReport1();
            crystalReportViewer1.ReportSource = rpt;

            rpt.SetDatabaseLogon("sa", "sa2012", "A102PC08", "QLSACH_BANSACH");
            crystalReportViewer1.DisplayStatusBar = false;
            crystalReportViewer1.DisplayToolbar = true;
            crystalReportViewer1.Refresh();
        }
    }
}
