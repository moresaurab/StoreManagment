using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace GoceryStoreManagement.View.Admin
{
    public partial class Categories : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Store_DB;Integrated Security=True");
        SqlDataAdapter sda;
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCategoryGrid();
        }

        public void LoadCategoryGrid()
        {
            string query = "select * from CategoryTbl";
            sda = new SqlDataAdapter(query, con);
            DataSet dt = new DataSet();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();


        }
        public void cleardata()
        {
            CatNameTb.Value = "";
            CatRemarkTb.Value = "";
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatNameTb.Value == "" || CatRemarkTb.Value == "")
                {
                    ErrMsg.InnerText = "Missing Some Fields!!";
                  
                }
                else
                {
                    cmd.CommandText = "insert into CategoryTbl values('" + CatNameTb.Value + "','" + CatRemarkTb.Value+ "')";
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ErrMsg.InnerText = "Categoty Added !!";
                    LoadCategoryGrid();
                    cleardata();

                }

            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = "Category Not Save!!";
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatNameTb.Value == "")
                {
                    ErrMsg.InnerText = "Missing Some Fields";
                }
                else
                {
                    cmd.CommandText = "delete from CategoryTbl where CatId = " + GridView1.SelectedRow.Cells[1].Text;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ErrMsg.InnerText = "Data Deleted!!";

                    LoadCategoryGrid();
                    cleardata();

                }

            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = "Missing Some Fields"; 
            }
        }
        int key = 0;
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CatNameTb.Value= GridView1.SelectedRow.Cells[2].Text;
            CatRemarkTb.Value= GridView1.SelectedRow.Cells[3].Text;
           
            if (CatNameTb.Value== "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if(CatNameTb.Value == "" || CatRemarkTb.Value == "")
                {
                    ErrMsg.InnerText = "Misssing Some Fields!!";
                }
                else
                {
                    cmd.CommandText = "update CategoryTbl set CatName = '" +CatNameTb.Value+ "',CatDescription = '" + CatRemarkTb.Value + "'where CatId = " + GridView1.SelectedRow.Cells[1].Text;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ErrMsg.InnerText = "Data Updated!!";
                     LoadCategoryGrid();
                    cleardata();

                }

            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = "Data Not Update";
            }
        }
    }
}