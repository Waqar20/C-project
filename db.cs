using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_of_mart_system
{
    class db
    {
        public static SqlConnection con;

        public static SqlCommand cmd;

        public static SqlDataReader dr;



        public static SqlDataReader connect_select(string query)
        {
            con = new SqlConnection("Data Source=WAQAR_KHAN;Initial Catalog=mart_system;User ID=sa;Password=sa9");

            con.Open();

            cmd = new SqlCommand(query, con);

            dr = cmd.ExecuteReader();



            return dr;
        }

        public static int connect_IUD(string query)
        {
            con = new SqlConnection("Data Source=WAQAR_KHAN;Initial Catalog=mart_system;User ID=sa;Password=sa9");

            con.Open();

            cmd = new SqlCommand(query, con);

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return res;
        }

        public static DataTable connect_sel_table(string query)
        {
            con = new SqlConnection("Data Source=WAQAR_KHAN;Initial Catalog=mart_system;User ID=sa;Password=sa9");

            con.Open();

            cmd = new SqlCommand(query, con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            con.Close();

            return dt;
        } 



    }
}
