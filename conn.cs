using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_of_mart_system
{
    class conn
    {
        public static void con(){
        SqlConnection con = new SqlConnection("Data Source=WAQAR_KHAN;Initial Catalog=mart_system;User ID=sa;Password=aptechorg");
        con.Open();
       
        }
    }
}
