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
    public partial class inscription : System.Web.UI.Page
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
        protected void btnInscription_Click(object sender, EventArgs e)
        {
            string fname = txtFirstName.Text;
            string lname = txtLastName.Text;
            string gender = cboSexeI.SelectedValue;
            string birth = txtBirth.Text.ToString();
            string email = txtEmailI.Text;
            string passwd = txtPasswordI.Text;
            myCon.Open();
            string sql = "INSERT INTO users(fname,lname,gender,birthday,email,password,status) VALUES" +
                "(@fname,@lname,@gender,@birthday,@email,@password,'false');";





            //version sans dataset
            /*SqlCommand myCmd = new SqlCommand(sql, myCon);
            myCmd.Parameters.AddWithValue("fname", UppercaseFirst(fname));
            myCmd.Parameters.AddWithValue("lname", UppercaseFirst(lname));
            myCmd.Parameters.AddWithValue("gender", gender);
            myCmd.Parameters.AddWithValue("birthday", birth);
            myCmd.Parameters.AddWithValue("email", email);
            myCmd.Parameters.AddWithValue("password", passwd);
            myCmd.ExecuteNonQuery();
            */
            //version avec dataset
            DataRow myrow;
            myrow = tabUser.NewRow();
            myrow["fname"] = fname;
            myrow["lname"] = lname;
            myrow["gender"] = gender;
            myrow["birthday"] = birth;
            myrow["email"] = email;
            myrow["password"] = passwd;
            myrow["status"] = "false";
            //ajout dans le dataset
            tabUser.Rows.Add(myrow);

            //synchro
            SqlCommandBuilder myBuilder = new SqlCommandBuilder(adpUser);
            adpUser.Update(mySet, "Users");
            //refill dataset
            tabUser = mySet.Tables["Users"];
            mySet.Tables.Remove(tabUser);
            adpUser.Fill(mySet, "Users");
            tabUser = mySet.Tables["Users"];


            myCon.Close();
            //----------------------------------mettre l'id dans la session
            myCon.Open();
            sql = "SELECT MAX(Id) FROM users;";
            SqlCommand myCmd2 = new SqlCommand(sql, myCon);
            int maxId = Convert.ToInt32(myCmd2.ExecuteScalar());

            Session["userId"] =maxId;


            myCon.Close();
            Response.Redirect("accueil.aspx");
        }

        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}