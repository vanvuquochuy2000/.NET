using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace N1_PhanMemQuanLyBanSach
{
    public class KN_DATA
    {
        private DataSet _dsQLSach;

        public DataSet dsQLSach
        {
            get { return _dsQLSach; }
            set { _dsQLSach = value; }
        }


        private SqlConnection _cnn;

        public SqlConnection cnn
        {
            get { return _cnn; }
            set { _cnn = value; }
        }

      
        private string _strConnect, _strServerName, _strDBName, _strUserName, _strPass;

        public string StrPass
        {
            get { return _strPass; }
            set { _strPass = value; }
        }

        public string StrUserName
        {
            get { return _strUserName; }
            set { _strUserName = value; }
        }

        public string StrDBName
        {
            get { return _strDBName; }
            set { _strDBName = value; }
        }

        public string StrServerName
        {
            get { return _strServerName; }
            set { _strServerName = value; }
        }

        public string StrConnect
        {
            get { return _strConnect; }
            set { _strConnect = value; }
        }

        public KN_DATA()
        {
            StrServerName = "QUOCHUY";
            StrDBName = "QLSACH_BANSACH";
            StrUserName = "sa";
            StrPass = "27072000";
            StrConnect = "Data Source=" + StrServerName + ";Initial Catalog=" + StrDBName + ";User ID=" + StrUserName + ";Password=" + StrPass + "";
            cnn = new SqlConnection();
            dsQLSach = new DataSet();
        }

        public KN_DATA(string pServerName, string pDBName, string pUser, string pPass)
        {
            StrServerName = pServerName;
            StrDBName = pDBName;
            StrUserName = pUser;
            StrPass = pPass;
            StrConnect = "Data Source=" + StrServerName + ";Initial Catalog=" + StrDBName + ";User ID=" + StrUserName + ";Password=" + StrPass + "";
            cnn = new SqlConnection();
            dsQLSach = new DataSet();
        }

    }
}
