using System.Data;
using System.Data.SqlClient;

namespace MusicPlayer.Database
{
    internal class DBConnection
    {
        private static readonly string saPassword = "123456";

        private static readonly string connectString =
            $"Data Source=HUULOCCODER\\SQLEXPRESS;Initial Catalog=FineMusic;User ID=sa;Password=${saPassword};" +
            "Encrypt=True;";

        private static DBConnection instance;

        private readonly SqlConnection sqlConn;
        private SqlDataAdapter da;
        private DataSet ds;

        private DBConnection()
        {
            sqlConn = new SqlConnection(connectString);
        }

        public static DBConnection GetInstance()
        {
            if (instance == null) instance = new DBConnection();

            return instance;
        }

        public DataTable Execute(string sqlStr)
        {
            sqlConn.Open();
            da = new SqlDataAdapter(sqlStr, sqlConn);
            ds = new DataSet();
            da.Fill(ds);
            sqlConn.Close();
            return ds.Tables[0];
        }

        public void ExecuteNonQuery(string strSQL)
        {
            sqlConn.Open();
            var sqlcmd = new SqlCommand(strSQL, sqlConn);
            sqlcmd.ExecuteNonQuery();
            sqlConn.Close();
        }
    }
}