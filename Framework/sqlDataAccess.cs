using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Framework
{
    public class sqlDataAccess
    {
        const string ConnectiosnString = "Data Source=DESKTOP-5S1M8IH\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True";

        public SqlCommand GetCommand(String query)
        {
            var connection = new SqlConnection(ConnectiosnString);

            SqlCommand cmd = new SqlCommand(query);
            cmd.Connection = connection;
            return cmd;
        }
    }
}
