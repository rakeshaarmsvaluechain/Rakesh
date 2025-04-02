using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        try
        {            
            
            con.Open();
            string Query = "SELECT ID,Email FROM tbl_user";
            SqlDataAdapter adpt = new SqlDataAdapter(Query, con);
            //DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            //adpt.Fill(dt);
            //DropDownList1.DataSource = dt;
            //DropDownList1.DataBind();
            //DropDownList1.DataTextField = "Email";
            //DropDownList1.DataValueField = "ID";
            //DropDownList1.DataBind();

            string str = ds.Tables[0].Rows[0]["Email"].ToString();

            string sMyData = string.Empty;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                sMyData = sMyData + dr["Email"].ToString() + ",";
            }


            //var emailss = string.Join(",", sMyData);
            var emailss = sMyData.TrimEnd(',');
            TextBox1.Text = emailss;

        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }

    }
}