using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace GoceryStoreManagement.Models
{
    public class Functions
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
       private string constring;

        public Functions()
        {
            constring = "Data Source=.;Initial Catalog=Store_DB;Integrated Security=True";
            con = new SqlConnection(constring);
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        public DataTable getData(string query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(query, constring);
            sda.Fill(dt);
            return dt;

        }

        public int SetData(string query)
        {
            int cnt = 0;
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.CommandText = query;
            cnt = cmd.ExecuteNonQuery();
            con.Close();
            return cnt;
        }
    }
}