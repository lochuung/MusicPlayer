using System.Data;
using System.Data.SqlClient;
using MusicPlayer.Properties;

namespace MusicPlayer.Database
{
    internal class DBConnection
    {
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private SqlCommand command;
        private SqlConnection connection = new SqlConnection(Settings.Default.connStr);
        private string currentUser = "";
        private DataTable table = new DataTable();
    }
}