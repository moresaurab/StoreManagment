using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoceryStoreManagement.View.Admin
{
    public partial class Seller : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Store_DB;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter sda;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (SellerName.Text == "" || SellerEmail.Text == "" || SellerPassword.Text == "" || SellerPhone.Text == "" || SellerAddress.Text == "")
                {
                    Label6.Text = "Misssing Some Fields!!";
                }
                else
                {
                    cmd.CommandText = "insert into SellerTbl values('" + SellerName.Text + "','" + SellerEmail.Text + "','" + SellerPassword.Text + "','" + SellerPhone.Text + "','" + SellerAddress.Text + "')";
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Label6.Text = "Data Added!!!";
                    LoadGrid();
                    Cleardata();

                }

            }
            catch (Exception ex)
            {
                Label6.Text = "Data Not Save"; _ = ex.Message;
            }

        }
        public void LoadGrid()
        {
            string query = "select * from SellerTbl";
            sda = new SqlDataAdapter(query, con);
            DataSet dt = new DataSet();
            sda.Fill(dt);
            GridView1.DataSource = dt ;
            GridView1.DataBind();

            
        }
        public void Cleardata()
        {
            SellerName.Text = "";
            SellerEmail.Text = "";
            SellerPassword.Text = "";
            SellerPhone.Text = "";
            SellerAddress.Text = "";
        }
        int Key = 0;

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SellerName.Text = GridView1.SelectedRow.Cells[2].Text;
            SellerEmail.Text = GridView1.SelectedRow.Cells[3].Text;
            SellerPassword.Text = GridView1.SelectedRow.Cells[4].Text;
            SellerPhone.Text = GridView1.SelectedRow.Cells[5].Text;
            SellerAddress.Text = GridView1.SelectedRow.Cells[6].Text;
            if(SellerName.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            }
        }

        protected void Editbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (SellerName.Text == "" || SellerEmail.Text == "" || SellerPassword.Text == "" || SellerPhone.Text == "" || SellerAddress.Text == "")
                {
                    Label6.Text = "Misssing Some Fields!!";
                }
                else
                {
                    cmd.CommandText = "update SellerTbl set SelName = '" + SellerName.Text + "',SelEmail = '" + SellerEmail.Text + "',SelPassword = '" + SellerPassword.Text + "',SelMobile = '" + SellerPhone.Text + "',SelAddress = '" + SellerAddress.Text + "'where SelID = " + GridView1.SelectedRow.Cells[1].Text;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Label6.Text = "Data Udpate!!";
                    LoadGrid();
                    Cleardata();

                }

            }
            catch (Exception ex)
            {
                Label6.Text = "Data Not Save"; _ = ex.Message;
            }
        }

        protected void Deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (SellerPassword.Text == "" )
                {
                    Label6.Text = "Misssing Some Fields!!";
                }
                else
                {
                    cmd.CommandText = "delete from SellerTbl where SelID = " + GridView1.SelectedRow.Cells[1].Text;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Label6.Text = "Seller Deleted!!";
                    
                    LoadGrid();
                    Cleardata();

                }

            }
            catch (Exception ex)
            {
                Label6.Text = "Data Not Save"; _ = ex.Message;
            }
        }
    }
    
    
}