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
    public partial class lireMessage : System.Web.UI.Page
    {
        static SqlConnection myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bdd_lavalife;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 refM = Convert.ToInt32(Request.QueryString["refm"]);
            String nom = Request.QueryString["nom"];
            string sql = "SELECT * FROM Messages WHERE refM =" + refM;
            myCon.Open();
            SqlCommand mycmd = new SqlCommand(sql, myCon);
            SqlDataReader myReader = mycmd.ExecuteReader();
            if (myReader.Read())
            {
                cellContenuTitre.Text = myReader["titre"].ToString();
                cellContenuDate.Text = myReader["dateCreation"].ToString();
                cellContenuEnvoyeur.Text = nom;
                cellContenuMessage.Text = myReader["message"].ToString();

            }
            myReader.Close();
            // Requete de modification du champ nouveau message
            bool nouv = false;
            string sqlC = "UPDATE Messages SET nouveau = 'False' WHERE refM =" + refM;
            SqlCommand mycmd2 = new SqlCommand(sqlC, myCon);
            mycmd2.ExecuteNonQuery();

            myReader.Close();
            myCon.Close();

            HyperLink1.NavigateUrl = "reception.aspx";
        }
    }
}