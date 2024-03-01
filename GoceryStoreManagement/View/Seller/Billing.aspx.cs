using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Reflection.Metadata;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace GoceryStoreManagement.View.Seller
{
    public partial class Billing : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Store_DB;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter sda;
        SqlDataReader sdr;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGridData();
            if(!this.IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5] {
                    new DataColumn("ID"),
                    new DataColumn("Product"),
                    new DataColumn("Price"),
                    new DataColumn("Quantity"),
                    new DataColumn("Total")
                    
                });
                ViewState["Bill"] = dt;
                this.BindGrid();
            }
        }

        protected void BindGrid()
        {
            BillGV.DataSource = (DataTable)ViewState["Bill"];
            BillGV.DataBind();
        }

        public void ShowProduct()
        {
            string query = "select ID as ID, PrName as Name, PrCategory as Category, Prprice as Price, PrQuantity as Quantity from ProductTbl";
            sda = new SqlDataAdapter(query, con);
            DataSet dt = new DataSet();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        public void LoadGridData()
        {
            string query = "Select * from ProductTbl";
            sda = new SqlDataAdapter(query, con);
            DataSet dt = new DataSet();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
        int key = 0;
        int stock;

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProName.Value = GridView1.SelectedRow.Cells[2].Text;
            ProPice.Value = GridView1.SelectedRow.Cells[4].Text;
            stock = Convert.ToInt32(GridView1.SelectedRow.Cells[5].Text);
          //  ErrMsg.InnerText = "" + stock;
            if(ProName.Value == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            }
        }
        int grandTotal = 0;
        protected void AddToBill_Click(object sender, EventArgs e)
        {
            int total = Convert.ToInt32(ProQuantity.Value) * Convert.ToInt32(ProPice.Value);
            DataTable dt = (DataTable)ViewState["Bill"];
            dt.Rows.Add(BillGV.Rows.Count + 1,
            ProName.Value.Trim(),
            ProPice.Value.Trim(),
            ProQuantity.Value.Trim(),
             total
            );

            ViewState["Bill"] = dt;
            this.BindGrid();
            UpdateStock();
            grandTotal = grandTotal + (Convert.ToInt32(ProQuantity.Value) * Convert.ToInt32(ProPice.Value));
            GrdToTb.InnerText = "Rs " + grandTotal;
            ProName.Value = string.Empty;
            ProPice.Value = string.Empty;
            ProQuantity.Value = string.Empty;
        }

        private void UpdateStock()
        {
            int newQuantity;
            newQuantity = Convert.ToInt32(GridView1.SelectedRow.Cells[5].Text) - Convert.ToInt32(ProQuantity.Value);
            string query = "update ProductTbl set PrQuantity = '{0}' where ID = {1}";
            query = string.Format(query, newQuantity, GridView1.SelectedRow.Cells[1].Text);
            cmd = new SqlCommand(query, con);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ShowProduct();
            ErrMsg.InnerText = "Quantity Updated!!";

        }

        protected void PrintBtn_Click(object sender, EventArgs e)
        {

        }

		protected void PrintBtn_Click1(object sender, EventArgs e)
		{
            Response.ContentType = "Application/pdf";
            Response.AddHeader("Content-Disposition", "attachement; filename=YourFileName.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            BillGV.RenderControl(hw);
			iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4, 50f, 50f, 30f, 30f);
            HTMLWorker htw = new HTMLWorker(doc);
            PdfWriter.GetInstance(doc, Response.OutputStream);
            doc.Open();
            StringReader sr = new StringReader(sw.ToString());
            htw.Parse(sr);
            doc.Close();
            Response.Write(doc);
            Response.End();
		}
	}
}