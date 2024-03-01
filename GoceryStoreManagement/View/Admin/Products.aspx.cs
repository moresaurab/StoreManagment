using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using GoceryStoreManagement.View;

namespace GoceryStoreManagement.View.Admin
{
    public partial class Products : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Store_DB;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter sda;
        SqlDataReader sdr;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            LoadGridData();
            GetCategory();
        }
       
        public void GetCategory()
        {
            if (!Page.IsPostBack)
            {
                cmd.CommandText = "select * from CategoryTbl";
                cmd.Connection = con;
                con.Open();
                sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    DropDownList1.Items.Add(sdr[1].ToString());

                }

                con.Close();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                try
                {
                    if (PNameTb.Value == "" || ProPrice.Value == "" || Pquantity.Value == "" || ExpDate.Value == "")
                    {
                        ErrMsg.InnerText = "Misssing Some Fields!!";
                    }
                    else
                    {
                        cmd.CommandText = "insert into ProductTbl values ('" + PNameTb.Value + "','" + DropDownList1.SelectedValue + "'," + ProPrice.Value + "," + Pquantity.Value + ",'" + ExpDate.Value + "')";
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        ErrMsg.InnerText = "Product Added!!!";
                        LoadGridData();

                        Cleardata();
                       // GetCategory()

                    }

                }

                catch (Exception ex)
                {
                    ErrMsg.InnerText = "Product Not Save!!";
                }
            }
        }

        public void LoadGridData()
        {
            string query = "select * from ProductTbl";
            sda = new SqlDataAdapter(query, con);
            DataSet dt = new DataSet();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        int Key = 0;
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PNameTb.Value = GridView1.SelectedRow.Cells[2].Text;
            DropDownList1.SelectedValue = GridView1.SelectedRow.Cells[3].Text;
            ProPrice.Value = GridView1.SelectedRow.Cells[4].Text;
            Pquantity.Value = GridView1.SelectedRow.Cells[5].Text;
            ExpDate.Value = GridView1.SelectedRow.Cells[6].Text;
            if (PNameTb.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (PNameTb.Value == "" || ProPrice.Value == "" || Pquantity.Value == "" || ExpDate.Value == "")
                {
                    ErrMsg.InnerText = "Misssing Some Fields!!";
                }
                else
                {
                    cmd.CommandText = "update ProductTbl set PrName = '" + PNameTb.Value + "',PrCategory = '" + DropDownList1.SelectedValue + "',PrPrice = '" + ProPrice.Value + "',PrQuantity = '" + Pquantity.Value + "',PrExpiryDate = '" + ExpDate.Value + "'where ID = " + GridView1.SelectedRow.Cells[1].Text;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ErrMsg.InnerText = "Product Data Udpate!!";
                    LoadGridData();
                    Cleardata();
                    

                }

            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = "Product not Updated!!";
            }
        }

        public void Cleardata()
        {
            PNameTb.Value = "";
          //  DropDownList1.Items.Clear();
            ProPrice.Value = "";
            Pquantity.Value = "";
            ExpDate.Value = "";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (PNameTb.Value == ""|| ProPrice.Value == "" || Pquantity.Value == "" ||ExpDate.Value == "")
                {
                    ErrMsg.InnerText = "Missing Some Fields";
                }
                else
                {
                    cmd.CommandText = "delete from ProductTbl where Id = " + GridView1.SelectedRow.Cells[1].Text;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ErrMsg.InnerText = "Data Deleted!!";

                    LoadGridData();
                    Cleardata();

                }

            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = "Missing Some Fields";
            }
        }
    }
}