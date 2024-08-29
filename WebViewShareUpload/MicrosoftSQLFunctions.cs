using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebViewShareUpload
{
    internal class MicrosoftSQLFunctions
    {
        private static MicrosoftSQLFunctions instance;
        public static MicrosoftSQLFunctions Instance { get { if (instance == null) Instance = new MicrosoftSQLFunctions(); return instance; } set => instance = value; }

        private static readonly string DBSERVER = "192.168.1.2, 1433";
        private static readonly string DBName = "ExocadDB";
        private static readonly string UserName = "IPSUser";
        private static readonly string Password = "646288@IPS";

        private SqlConnection ConnectDB()
        {
            return new SqlConnection("Data Source=" + DBSERVER + ";Initial Catalog=" + DBName + ";User Id=" + UserName + ";Password=" + Password + ";");
        }

        public bool CheckDatabase(out string er)
        {
            try
            {
                SqlConnection connection = ConnectDB();
                connection.Open();
                connection.Close();
                er = "";
                return true;
            }
            catch (Exception error)
            {
                er = error.Message;
                return false;
            }
        }

        public DataTable ExQuery(string query)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = ConnectDB())
            {
                connection.Open();
                SqlCommand command = new(query, connection);
                SqlDataReader dataReader = command.ExecuteReader();
                data.Load(dataReader);
                dataReader.Dispose();
                connection.Close();
            }
            return data;
        }

        public void ExNonQuery(string query)
        {
            using SqlConnection connection = ConnectDB();
            connection.Open();
            SqlCommand command = new(query, connection);
            _ = command.ExecuteNonQuery();
            connection.Close();
            command.Dispose();
        }
    }
}
