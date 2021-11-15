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
        static DataSet mySet;
        static DataTable tabUser, tabSpecifications, tabMessagesdt;
        static SqlDataAdapter adpUser, adpSpecifications, adpMessages;
        static SqlConnection myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bdd_lavalife;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 refU = Convert.ToInt32(Session["userId"]);
            //version avec dataset

            
            if (!Page.IsPostBack)
            {

                mySet = getDataSet();
                tabUser = mySet.Tables["Users"];
                tabSpecifications = mySet.Tables["Specifications"];
                tabMessagesdt = mySet.Tables["Messages"];
                myCon.Open();
                var lesmessages = from DataRow drM in tabMessagesdt.Rows
                               join DataRow drU in tabUser.Rows
                               on drM.Field<int>("receveur")
                               equals drU.Field<int>("Id")
                               where drM.Field<int>("receveur") == refU
                               let m = new
                               {
                                   refM = drM.Field<int>("refM"),
                                   titre = drM.Field<string>("titre"),
                                   envoyeur = drM.Field<int>("envoyeur"),
                                   receveur = drM.Field<int>("receveur"),
                                   nouveau = drM.Field<string>("nouveau"),
                                   fname = drU.Field<string>("fname"),
                                   lname = drU.Field<string>("lname")
                               }
                               select m;
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
                

                    foreach(var dr in lesmessages)
                    {
                    maLigne = new TableRow();
                        if(dr.nouveau == "true")
                        {
                            maLigne.BackColor = Color.LightYellow;
                        }
                        maCell = new TableCell();
                        maCell.Text = dr.titre.ToString();
                        maLigne.Cells.Add(maCell);

                    maCell = new TableCell();
                    var envoyeur = from DataRow drenv in tabUser.Rows
                                   where drenv.Field<int>("Id") == dr.envoyeur
                                   select drenv;
                    string fnameE = "";
                    string lnameE = "";
                    DataRow resultEnv = envoyeur.ElementAt<DataRow>(0);
                    foreach(DataRow elem in envoyeur)
                    {
                        fnameE = elem["fname"].ToString();
                        lnameE = elem["lname"].ToString();
                    }
                    maCell.Text = fnameE + " " + lnameE ;
                        maLigne.Cells.Add(maCell);

                        maCell = new TableCell();

                        int refmsg = Convert.ToInt32(dr.refM);
                        String nom = fnameE + " " + lnameE;
                        maCell.Text = "<a href='lireMessage.aspx?refm=" + refmsg + "&nom=" + nom + "'>Lire</a> - <a href='effacerMessage.aspx?refm=" + refmsg + "'>Effacer</a>";
                        maLigne.Cells.Add(maCell);

                        tabMessages.Rows.Add(maLigne);
                    }
                
            }
            /*
             *             while (rdMsg.Read())
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
            //version sans dataset
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


            rdMsg.Close();

            */


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
    }
}