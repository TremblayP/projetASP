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
        static SqlConnection myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bdd_lavalife;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

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
            SqlCommand myCmd = new SqlCommand(sql, myCon);
            myCmd.Parameters.AddWithValue("fname", UppercaseFirst(fname));
            myCmd.Parameters.AddWithValue("lname", UppercaseFirst(lname));
            myCmd.Parameters.AddWithValue("gender", gender);
            myCmd.Parameters.AddWithValue("birthday", birth);
            myCmd.Parameters.AddWithValue("email", email);
            myCmd.Parameters.AddWithValue("password", passwd);
            myCmd.ExecuteNonQuery();
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