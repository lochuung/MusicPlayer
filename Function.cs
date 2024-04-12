using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ManagerMusic
{
    public class Function
    {
        protected SqlConnection getConnection()
        {
            var con = new SqlConnection();
            con.ConnectionString =
                "data source = Data Source=LAPTOP-3N644IDG;Initial Catalog=UsersMusicManagement;Integrated Security=True ";
            return con;
        }

        public DataSet getData(string query)
        {
            var con = new SqlConnection();
            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            var da = new SqlDataAdapter(cmd);
            var ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void setData(string query, string msg)
        {
            var con = getConnection();
            var cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}