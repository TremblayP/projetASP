using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace prjWinCsLavalifeFinal
{
    public partial class reception : System.Web.UI.Page
    {
        static SqlConnection myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bdd_lavalife;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 refM = Convert.ToInt32(Session["userId"]);

            myCon.Open();
            string sqlMsg = "SELECT Messages.refM , Messages.titre , Messages.envoyeur , Messages.nouveau , users.fname , users.lname FROM users" +
                " JOIN Messages ON users.Id = Messages.envoyeur   WHERE Messages.receveur = " + refM;
            SqlCommand mycmdMsg = new SqlCommand(sqlMsg, myCon);
            SqlDataReader rdMsg = mycmdMsg.ExecuteReader();

            //Création de la ligne des titres des colonnes du tableau
            TableRow maLigne = new TableRow();
            maLigne.BackColor = Color.LightSlateGray;

            TableCell maCell = new TableCell();
            maCell.Text = "Titre :";
            maLigne.Cells.Add(maCell);

            maCell = new TableCell();
            maCell.Text = "De provenance :";
            maLigne.Cells.Add(maCell);

            maCell = new TableCell();
            maCell.Text = "Action :";
            maLigne.Cells.Add(maCell);

            tabMessages.Rows.Add(maLigne);

            // Creation des lignes selon le nombre d'éléments du datareader
            while (rdMsg.Read())
            {

                maLigne = new TableRow();
                if (rdMsg["nouveau"].ToString() == "true")
                {
                    maLigne.BackColor = Color.LightYellow;
                }

                maCell = new TableCell();
                maCell.Text = rdMsg["titre"].ToString();
                maLigne.Cells.Add(maCell);

                maCell = new TableCell();
                maCell.Text = rdMsg["fname"].ToString() + " " + rdMsg["lname"];
                maLigne.Cells.Add(maCell);

                maCell = new TableCell();

                int refmsg = Convert.ToInt32(rdMsg["refM"]);
                String nom = rdMsg["fname"].ToString() + " " + rdMsg["lname"].ToString();
                maCell.Text = "<a href='lireMessage.aspx?refm=" + refmsg + "&nom=" + nom + "'>Lire</a> - <a href='effacerMessage.aspx?refm=" + refmsg + "'>Effacer</a>";
                maLigne.Cells.Add(maCell);

                tabMessages.Rows.Add(maLigne);
            }

            rdMsg.Close();
            myCon.Close();
        }
    }
}