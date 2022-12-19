using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data;
using System.Configuration;


namespace _111_1HW4
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection o_conn = new SqlConnection( 
            ConfigurationManager.ConnectionStrings["SQL"].ConnectionString);
            try
            {
                o_conn.Open();
                SqlDataAdapter o_a = new SqlDataAdapter("SELECT * FROM Users", o_conn);
                DataSet o_set = new DataSet();
                o_a.Fill(o_set, "123");
                gd_View.DataSource = o_set;
                gd_View.DataBind();
                o_conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btn_Insert_Click(object sender, EventArgs e)
        {
            SqlConnection o_conn = new SqlConnection(
            ConfigurationManager.ConnectionStrings["SQL"].ConnectionString);
            try
            {
                o_conn.Open();
                SqlCommand scom = new SqlCommand("INSERT INTO Users (Name, Birthday)" + " VALUES(N'阿貓阿狗', '2000/10/10');", o_conn);
                scom.ExecuteNonQuery();
                o_conn.Close();
            }
            catch (SqlException ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}