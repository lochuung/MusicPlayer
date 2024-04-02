using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace MusicPlayer.Database
{
    class DBConnection
    {
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.connStr);
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        String currentUser = "";
    }
}
