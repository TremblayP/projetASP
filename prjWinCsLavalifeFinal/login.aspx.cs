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
        static DataSet mySet;
        static DataTable tabUser, tabSpecifications, tabMessages;
        static SqlDataAdapter adpUser, adpSpecifications, adpMessages;
        static SqlConnection myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bdd_lavalife;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                mySet = getDataSet();
                tabUser = mySet.Tables["Users"];
                tabSpecifications = mySet.Tables["Specifications"];
                tabMessages = mySet.Tables["Messages"];
            }
        }

        protected DataSet getDataSet()
        {
            myCon.Open();
            DataSet myset = new DataSet();

            //remplir dataset avec les tables de la db
            adpUser = new SqlDataAdapter("SELECT * FROM users", myCon);
            adpSpecifications = new SqlDataAdapter("SELECT * FROM specifications", myCon);
            adpMessages = new SqlDataAdapter("SELECT * FROM Messages", myCon);

            adpUser.Fill(myset, "Users");
            adpSpecifications.Fill(myset, "Specifications");
            adpMessages.Fill(myset, "Messages");

            //relations
            DataRelation myrel = new DataRelation("user_specification",
                        myset.Tables["Users"].Columns["Id"],
                        myset.Tables["Specifications"].Columns["userId"]);

            DataRelation myrel2 = new DataRelation("user_messageenvoyeur",
                        myset.Tables["Users"].Columns["Id"],
                        myset.Tables["Messages"].Columns["envoyeur"]);

            DataRelation myrel3 = new DataRelation("user_messagereceveur",
                        myset.Tables["Users"].Columns["Id"],
                        myset.Tables["Messages"].Columns["receveur"]);



            myCon.Close();
            return myset;
        }

        bool AreAllColumnsEmpty(DataRow dr)
        {
            if (dr == null)
            {
                return true;
            }
            else
            {
                foreach (var value in dr.ItemArray)
                {
                    if (value != null)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        protected void btnConnecter_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string sql = "SELECT * FROM users WHERE email = @email AND password = @password";
            myCon.Open();
            //version sans dataset
            /*
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
            }*/
            //version avec dataset
            //LINQ
            var leUser = from DataRow dr in tabUser.Rows
                         where dr.Field<string>("email").ToString() == email
                         && dr.Field<string>("password") == password
                         select dr;
            DataRow tmp = leUser.ElementAt<DataRow>(0);
            if (!AreAllColumnsEmpty(tmp))
            {
                if (tmp["status"].ToString() == "false")
                {
                    Session["userId"] = tmp["Id"];
                    myCon.Close();
                    Response.Redirect("accueil.aspx");
                }
                else
                {
                    Session["userId"] = tmp["Id"];
                    myCon.Close();
                    Response.Redirect("accueilMembre.aspx");
                }
            }
            else
            {
                lblResultat.Text = "Email or password incorrect";
                myCon.Close();
            }


        }
    }
}

