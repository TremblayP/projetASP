using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
/*using System.Web.UI.ClientScriptManager.EnsureJqueryRegistered() + 3001316;
using System.Web.UI.WebControls.BaseValidator.RegisterUnobtrusiveScript() + 12;
using System.Web.UI.WebControls.BaseValidator.OnPreRender(EventArgs e) +9805683;
using System.Web.UI.Control.PreRenderRecursiveInternal() + 90;
using System.Web.UI.Control.PreRenderRecursiveInternal() + 163;
using System.Web.UI.Control.PreRenderRecursiveInternal() + 163;
using System.Web.UI.Page.ProcessRequestMain(Boolean includeStagesBeforeAsyncPoint, Boolean includeStagesAfterAsyncPoint) + 906;
*/
//test comment pour git wjabobwi
namespace prjWinCsLavalifeFinal
{

    public partial class login : System.Web.UI.Page
    {
        static SqlConnection myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bdd_lavalife;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConnecter_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string sql = "SELECT * FROM users WHERE email = @email AND password = @password";
            myCon.Open();
            SqlCommand myCmd = new SqlCommand(sql, myCon);
            myCmd.Parameters.AddWithValue("email", email);
            myCmd.Parameters.AddWithValue("password", password);

            SqlDataReader myRd = myCmd.ExecuteReader();
            if (myRd.Read())
            {
                if(myRd["status"].ToString() == "false")
                {
                    Session["userId"] = myRd["Id"];
                    myRd.Close();
                    myCon.Close();
                    Response.Redirect("accueil.aspx");
                }
                else
                {
                    Session["userId"] = myRd["Id"];
                    myRd.Close();
                    myCon.Close();
                    Response.Redirect("accueilMembre.aspx");
                }

                
            }
            else
            {
                lblResultat.Text = "Email or password incorrect";
                myRd.Close();
                myCon.Close();
            }

        }
    }
}

