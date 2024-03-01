using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoceryStoreManagement.View;
using System.Data.SqlClient;
namespace GoceryStoreManagement.View
{ 
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Store_DB;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
     
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (RadioButton1.Checked)
            {
                if (EmailId.Text == "Admin@gmail.com" && UserPassword.Text == "Admin")
                {
                    Response.Redirect("Admin/Seller.aspx");
                }
                else
                {
                    InfoMsg.Text = "Invalid Admin!!";
                }
            }
            else
            {
                cmd.Connection = con;
                con.Open();

                cmd.CommandText = "select * from SellerTbl where SelEmail = '" + EmailId.Text + "' and SelPassword = '" + UserPassword.Text + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {

                    Response.Redirect("Seller/Billing.aspx");

                }
                else
                {
                    InfoMsg.Text = "Invalid User!!";
                }
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
    }
}