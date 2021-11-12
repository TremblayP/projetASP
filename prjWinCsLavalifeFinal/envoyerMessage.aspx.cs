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
    public partial class envoyerMessage : System.Web.UI.Page
    {
        static DataSet mySet;
        static DataTable tabUser, tabSpecifications, tabMessages;
        static SqlDataAdapter adpUser, adpSpecifications, adpMessages;
        static SqlConnection myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bdd_lavalife;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            myCon.Open();
            if (Session["idPourM"] != null) {
                string id = Session["idPourM"].ToString();

                SqlCommand myCmd = new SqlCommand("SELECT * FROM users WHERE Id = @id", myCon);
                myCmd.Parameters.AddWithValue("id", id);
                SqlDataReader myRd = myCmd.ExecuteReader();
                if (myRd.Read())
                {
                    lblClient.Text = myRd["fname"] + " " + myRd["fname"];

                }
            }
    
            else
            {
                lblClient.Visible = false;
                cboClients.Visible = true;
                string id = Session["userId"].ToString();
                SqlCommand myCmd = new SqlCommand("SELECT * FROM users WHERE Id != @id", myCon);
                myCmd.Parameters.AddWithValue("id", id);
                SqlDataReader myRd = myCmd.ExecuteReader();
                while (myRd.Read())
                {
                    ListItem dest = new ListItem();
                    dest.Text = myRd["fname"].ToString() + " " + myRd["lname"].ToString() ;
                    dest.Value = myRd["Id"].ToString();
                    cboClients.Items.Add(dest);
 
                }

            }
            myCon.Close();

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
        protected void btnEffacer_Click(object sender, EventArgs e)
        {
            txtTitre.Text = txtMessage.Text = "";
            
        }

        protected void btnEnvoyer_Click(object sender, EventArgs e)
        {
            int refDestin;
            if(Session["idPourM"] != null)
            {
                refDestin = Convert.ToInt32(Session["idPourM"]);
            }
            else
            {
                refDestin = Convert.ToInt32(cboClients.SelectedValue);
            }

            String Titre = txtTitre.Text.Trim();
            String Mess = txtMessage.Text.Trim();


            string sql = "INSERT INTO Messages(titre, message, envoyeur, receveur, dateCreation, nouveau)VALUES(@titre, @mess, @env, @rec, @date, 'true')";
            myCon.Open();
            SqlCommand mycmd = new SqlCommand(sql, myCon);
            mycmd.Parameters.AddWithValue("titre", Titre);
            mycmd.Parameters.AddWithValue("mess", Mess);
            mycmd.Parameters.AddWithValue("env", Session["userId"]);
            mycmd.Parameters.AddWithValue("rec", refDestin);
            mycmd.Parameters.AddWithValue("date", DateTime.Today);


            mycmd.ExecuteNonQuery();
            myCon.Close();
            Response.Redirect("accueilMembre.aspx");
        }
    }
}