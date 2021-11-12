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
    public partial class accueil : System.Web.UI.Page
    {
        static DataSet mySet;
        static DataTable tabUser, tabSpecifications, tabMessages;
        static SqlDataAdapter adpUser, adpSpecifications, adpMessages;
        static SqlConnection myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bdd_lavalife;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //version sans dataset
                /*string sql = "SELECT * FROM users WHERE Id = @userid";
                myCon.Open();
                SqlCommand myCmd = new SqlCommand(sql, myCon);
                myCmd.Parameters.AddWithValue("userid", Session["userId"]);


                SqlDataReader myRd = myCmd.ExecuteReader();
                if (myRd.Read())
                {
                    litWelcome.Text = "Welcome " + myRd["fname"] + "<br></h2><hr><h5 style=margin-left:5px>Please enter specifications to confirm your account</h5><h2>";
                }
                myCon.Close();
                myRd.Close();*/
                mySet = getDataSet();
                tabUser = mySet.Tables["Users"];
                tabSpecifications = mySet.Tables["Specifications"];
                tabMessages = mySet.Tables["Messages"];
                if (verifyCurrentUser(Session["userId"].ToString()))
                {
                    DataRow cur = selectUser(Session["userId"].ToString());
                    litWelcome.Text = "Welcome " + cur["fname"].ToString() + "<br></h2><hr><h5 style=margin-left:5px>Please enter specifications to confirm your account</h5><h2>";
                }







            }
        }
        protected bool verifyCurrentUser(string s)
        {
            myCon.Open();
            var currentUser = from DataRow dr in tabUser.Rows
                              where dr.Field<int>("Id").ToString() == s
                              select dr;
            if (currentUser.Any())
            {
                return true;
            }
            else
            {
                myCon.Close();
                return false;
            }
  

        }

        protected DataRow selectUser(string s)
        {
            var currentUser = from DataRow dr in tabUser.Rows
                              where dr.Field<int>("Id").ToString() == s
                              select dr;
            DataRow tmp = currentUser.ElementAt<DataRow>(0);
            myCon.Close();
            return tmp;

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
        protected void btnConfirmer_Click(object sender, EventArgs e)
        {
            string natio = txtNationality.Text;
            string wan = cboSexes.SelectedValue;
            string hai = txtHair.Text;
            string heig = txtHeight.Text;
            string eye = txtEyes.Text;
            if(natio != "" && hai != "" && heig != "" && eye != "")
            {
                myCon.Open();
                /*version sans dataset
                string sql = "UPDATE users SET status = 'true' WHERE Id = @id";
                SqlCommand myCmd = new SqlCommand(sql, myCon);
                myCmd.Parameters.AddWithValue("id", Session["userId"]);
                myCmd.ExecuteNonQuery();
                myCon.Close();

                myCon.Open();

                sql = "INSERT INTO specifications(userId,nationality,want,hair,height,eyes) VALUES" +
                    "(@userId,@nationality,@want,@hair,@height,@eyes)";
                SqlCommand myCmd2 = new SqlCommand(sql, myCon);
                myCmd2.Parameters.AddWithValue("userId", Session["userId"]);
                myCmd2.Parameters.AddWithValue("nationality", natio);
                myCmd2.Parameters.AddWithValue("want", wan);
                myCmd2.Parameters.AddWithValue("hair", hai);
                myCmd2.Parameters.AddWithValue("height", heig.ToString());
                myCmd2.Parameters.AddWithValue("eyes", eye);
                myCmd2.ExecuteNonQuery();
                */
                //version avec dataset
                //update users
                DataRow myrow;
                foreach(DataRow dr in tabUser.Rows)
                {
                    if (dr["Id"].ToString() == Session["userId"].ToString())
                    {
                        myrow = dr;
                        dr["status"] = "true";
                        
                    }
                }
                //synchro
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(adpUser);
                adpUser.Update(mySet, "Users");
                //refill dataset
                tabUser = mySet.Tables["Users"];
                mySet.Tables.Remove(tabUser);
                adpUser.Fill(mySet, "Users");
                tabUser = mySet.Tables["Users"];

                //add specs
                myrow = tabSpecifications.NewRow();
                myrow["userId"] = Convert.ToInt32(Session["userId"]);
                myrow["nationality"] = natio;
                myrow["want"] = wan;
                myrow["hair"] = hai;
                myrow["height"] = heig;
                myrow["eyes"] = eye;

                //ajout dans le dataset
                tabSpecifications.Rows.Add(myrow);

                //synchro
                SqlCommandBuilder myBuilder2 = new SqlCommandBuilder(adpSpecifications);
                adpSpecifications.Update(mySet, "Specifications");
                //refill dataset
                tabSpecifications = mySet.Tables["Specifications"];
                mySet.Tables.Remove(tabUser);
                adpSpecifications.Fill(mySet, "Specification");
                tabSpecifications = mySet.Tables["Specifications"];


                myCon.Close();

                Response.Redirect("accueilMembre.aspx");
            }








        }
    }
}