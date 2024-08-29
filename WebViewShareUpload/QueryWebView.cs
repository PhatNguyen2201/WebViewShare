using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebViewShareUpload
{
    public class QueryWebView
    {
        //table ExocadWebviewShare: ID,DateUploaded,projectDIR,HTMLfilename
        private static QueryWebView instance;
        public static QueryWebView Instance
        {
            get
            {
                if (instance == null) Instance = new QueryWebView();
                return instance;
            }
            set { instance = value; }
        }

        public DataTable GetListHTMLShared()
        {
            string query = "select * from ExocadWebviewShare";
            return MicrosoftSQLFunctions.Instance.ExQuery(query);
        }

        public int GetURL(string projectDIR)
        {
            string query = "select id, HTMLfilename from ExocadWebviewShare where projectDIR  = '" + projectDIR + "'";
            DataTable data = MicrosoftSQLFunctions.Instance.ExQuery(query);
            if (data.Rows.Count > 0)
            {
                return Convert.ToInt32(data.Rows[0][0]);
            }
            return -1;
        }
        public int GetIDFromDIR(string projectDIR)
        {
            string query = "select ID, HTMLfilename from ExocadWebviewShare where projectDIR  = '" + projectDIR + "'";
            DataTable data = MicrosoftSQLFunctions.Instance.ExQuery(query);
            return Convert.ToInt32(data.Rows[0][0]);
        }

        public int CheckDIRDuplicated(string projectDIR)
        {
            string query = "select ID, projectDIR from ExocadWebviewShare where projectDIR  = '" + projectDIR + "'";
            DataTable data = MicrosoftSQLFunctions.Instance.ExQuery(query);
            if (data.Rows.Count == 1)
            {
                return Convert.ToInt32(data.Rows[0][0]);
            }
            return -1;
        }

        public bool AddFileName(string datenow, string projectDIR, string filename, out string ex)
        {
            string query = "insert into ExocadWebviewShare (DateUploaded, projectDIR, HTMLfilename) values ('" + datenow + "','" + projectDIR + "','" + filename + "')" +
                "";
            try
            {
                MicrosoftSQLFunctions.Instance.ExNonQuery(query);
                ex = "";
                return true;
            }
            catch (Exception error)
            {
                ex = error.Message;
                File.WriteAllText(@"C:\Users\Public\logerrorAddFileName.txt", "AddFileName Error - " + ex);
                return false;
            }
        }

        public bool UpdateWebView(int ID, string datenow, string filename, out string ex)
        {
            string query = "update ExocadWebviewShare set DateUploaded = '" + datenow + "', HTMLfilename = '" + filename + "' where ID = " + ID;
            try
            {
                MicrosoftSQLFunctions.Instance.ExNonQuery(query);
                ex = "";
                return true;
            }
            catch (Exception error)
            {
                ex = error.Message;
                File.WriteAllText(@"C:\Users\Public\logerrorUpdateWebView.txt", "UpdateWebView Error - " + ex);
                return false;
            }
        }

        public bool DeleteWebViewItem(int ID, out string exeption)
        {
            try
            {
                string queryGetData = "select id, HTMLfilename from ExocadWebviewShare where id = " + ID;
                DataRow thisHTML = MicrosoftSQLFunctions.Instance.ExQuery(queryGetData).Rows[0];
                string filenameHTML = thisHTML["HTMLfilename"].ToString();
                string fileDIR = SettingsApplication.wwwrootDIR + filenameHTML;
                if (File.Exists(fileDIR))
                {
                    File.Delete(fileDIR);
                }
                string queryDelete = "delete from ExocadWebviewShare where id = " + ID;
                MicrosoftSQLFunctions.Instance.ExNonQuery(queryDelete);
                exeption = "";
                return true;
            }
            catch (Exception ex)
            {
                exeption = ex.Message;
                return false;
            }
        }
    }
}
