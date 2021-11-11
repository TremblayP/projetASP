using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace prjWinCsLavalifeFinal
{
    public partial class result : System.Web.UI.Page
    {
        static SqlConnection myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bdd_lavalife;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               /* try
                {*/
                    myCon.Open();
                    string sql = "SELECT * FROM users INNER JOIN specifications ON users.Id = specifications.userId" +
                        "         WHERE users.gender = @genderresearched";
                    sql += (Session["nationality"] != "") ? " AND specifications.nationality = @nationality" : "";
                    sql += (Session["hair"] != "") ? " AND specifications.hair = @hair" : "";
                    sql += (Session["minHeight"] != "") ? " AND specifications.height >= @minH" : "";
                    sql += (Session["maxHeight"] != "") ? " AND specifications.height <= @maxH" : "";
                    sql += (Session["eyes"] != "") ? " AND specifications.eyes = @eyes" : "";
                    sql += " AND users.status = 'true' AND users.Id != @sesID";
                    
                    SqlCommand myCmd = new SqlCommand(sql, myCon);
                    myCmd.Parameters.AddWithValue("genderresearched", Session["gender"]);
                    myCmd.Parameters.AddWithValue("sesID", Session["userId"].ToString());
                    if (Session["nationality"] != "")
                    {
                        myCmd.Parameters.AddWithValue("nationality", Session["nationality"].ToString());
                    }
                    if (Session["hair"] != "")
                    {
                        myCmd.Parameters.AddWithValue("hair", Session["hair"].ToString());
                    }
                    if (Session["minHeight"] != "")
                    {
                        myCmd.Parameters.AddWithValue("minH", Session["minHeight"].ToString());
                    }
                    if (Session["maxHeight"] != "")
                    {
                        myCmd.Parameters.AddWithValue("maxH", Session["maxHeight"].ToString());
                    }
                    if (Session["eyes"] != "")
                    {
                        myCmd.Parameters.AddWithValue("eyes", Session["eyes"].ToString());
                    }
                SqlDataReader myRd = myCmd.ExecuteReader();
                        lstUsers.Items.Clear();
                    while (myRd.Read())
                    {
                        lstUsers.Items.Add(new ListItem(myRd["fname"].ToString() + " " + myRd["lname"].ToString(), myRd["Id"].ToString()));
                    }
                    myRd.Close();
                    myCon.Close();
                /*}catch(Exception ex)
                {
                    Response.Write("<script>alert('erreur')</script>");
                }*/
            }
        }


        protected void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lstUsers.SelectedValue);
            myCon.Open();
            SqlCommand myCmd = new SqlCommand("SELECT * FROM users WHERE Id = @id", myCon);
            myCmd.Parameters.AddWithValue("id", id);
            SqlDataReader myRd = myCmd.ExecuteReader();
            litResult.Text = "";
            DateTime aujd = DateTime.Today;
            while (myRd.Read())
            {
                litResult.Text += myRd["fname"] + " " + myRd["lname"] + "<br>";
                litResult.Text += (aujd-Convert.ToDateTime(myRd["birthday"])).ToString() + " ans<br>";
                Session["idPourM"] = id;
            }
            btnMess.Visible = true;
            myCon.Close();
        }

        protected void btnMess_Click(object sender, EventArgs e)
        {
            Response.Redirect("envoyerMessage.aspx");
        }

        /*protected void btnMess_Click(object sender, EventArgs e)
        {
            Response.Redirect("envoyerMessage.aspx");
        }*/
    }
}