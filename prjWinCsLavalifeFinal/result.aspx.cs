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
                /* try
                 {*//*
                     // version sans dataset
                     myCon.Open();
                     string sql = "SELECT * FROM users INNER JOIN specifications ON users.Id = specifications.userId" +
                         "         WHERE users.gender = @genderresearched";
                     sql += (Session["nationality"].ToString() != "") ? " AND specifications.nationality = @nationality" : "";
                     sql += (Session["hair"].ToString() != "") ? " AND specifications.hair = @hair" : "";
                     sql += (Session["minHeight"].ToString() != "") ? " AND specifications.height >= @minH" : "";
                     sql += (Session["maxHeight"].ToString() != "") ? " AND specifications.height <= @maxH" : "";
                     sql += (Session["eyes"].ToString() != "") ? " AND specifications.eyes = @eyes" : "";
                     sql += " AND users.status = 'true' AND users.Id != @sesID";

                     SqlCommand myCmd = new SqlCommand(sql, myCon);
                     myCmd.Parameters.AddWithValue("genderresearched", Session["gender"]);
                     myCmd.Parameters.AddWithValue("sesID", Session["userId"].ToString());
                     if (Session["nationality"].ToString() != "")
                     {
                         myCmd.Parameters.AddWithValue("nationality", Session["nationality"].ToString());
                     }
                     if (Session["hair"].ToString() != "")
                     {
                         myCmd.Parameters.AddWithValue("hair", Session["hair"].ToString());
                     }
                     if (Session["minHeight"].ToString() != "")
                     {
                         myCmd.Parameters.AddWithValue("minH", Session["minHeight"].ToString());
                     }
                     if (Session["maxHeight"].ToString() != "")
                     {
                         myCmd.Parameters.AddWithValue("maxH", Session["maxHeight"].ToString());
                     }
                     if (Session["eyes"].ToString() != "")
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
                     myCon.Close();*/
                //version avec dataset
                myCon.Open();
                var userSearch = from DataRow drU in tabUser.Rows
                                 join DataRow drS in tabSpecifications.Rows
                                 on drU.Field<int>("Id")
                                 equals drS.Field<int>("userId")
                                 where drU.Field<string>("gender") == Session["gender"].ToString()
                                     && drU.Field<int>("Id").ToString() != Session["userId"].ToString()
                                 let p = new 
                                 {

                                     id = drU.Field<int>("Id").ToString(),
                                     fname = drU.Field<string>("fname").ToString(),
                                     lname = drU.Field<string>("lname").ToString(),
                                     gender = drU.Field<string>("gender").ToString(),
                                     birthday = drU.Field<DateTime>("birthday").ToString(),
                                     nationality = drS.Field<string>("nationality").ToString(),
                                     want = drS.Field<string>("want").ToString(),
                                     hair = drS.Field<string>("hair").ToString(),
                                     height = drS.Field<int>("height").ToString(),
                                     eyes = drS.Field<string>("eyes").ToString()
                                 }
                                 select p;
                                 if (Session["nationality"].ToString() != "")
                                    userSearch = userSearch.Where(p => p.nationality == Session["nationality"].ToString());
                                 if (Session["hair"].ToString() != "")
                                    userSearch = userSearch.Where(p => p.hair == Session["hair"].ToString());
                                 if (Session["minHeight"].ToString() != "")
                                    userSearch = userSearch.Where(p => Convert.ToInt32(p.height) >= Convert.ToInt32(Session["minHeight"].ToString()) &&
                                    Convert.ToInt32(p.height) >= Convert.ToInt32(Session["maxHeight"].ToString()));
                                 if (Session["eyes"].ToString() != "")
                                    userSearch = userSearch.Where(p => p.eyes == Session["eyes"].ToString());
                                    



                foreach (var drForList in userSearch)
                {
                    lstUsers.Items.Add(new ListItem(drForList.fname.ToString() + " " + drForList.lname.ToString(), drForList.id.ToString()));
                }
                myCon.Close();
            }




                /*}catch(Exception ex)
                {
                    Response.Write("<script>alert('erreur')</script>");
                }*/
            }


    

        protected DataTable resultTable()
        {
            DataTable mytab = new DataTable("Results");
            //creation de la colonne id
            DataColumn mycol = new DataColumn("id", Type.GetType("System.String"));
            mytab.Columns.Add(mycol);
            //creation de la colonne fname
            mycol = new DataColumn("fname", Type.GetType("System.String"));
            mycol.MaxLength = 50;
            mytab.Columns.Add(mycol);
            //creation de la colonne lname
            mycol = new DataColumn("lname", Type.GetType("System.String"));
            mycol.MaxLength = 50;
            mytab.Columns.Add(mycol);
            //creation de la colonne gender
            mycol = new DataColumn("gender", Type.GetType("System.String"));
            mycol.MaxLength = 50;
            mytab.Columns.Add(mycol);
            //creation de la colonne birthday
            mycol = new DataColumn("birthday", Type.GetType("System.DateTime"));
            mytab.Columns.Add(mycol);
            //creation de la colonne nationality
            mycol = new DataColumn("nationality", Type.GetType("System.String"));
            mycol.MaxLength = 50;
            mytab.Columns.Add(mycol);
            //creation de la colonne want
            mycol = new DataColumn("want", Type.GetType("System.String"));
            mycol.MaxLength = 50;
            mytab.Columns.Add(mycol);
            //creation de la colonne hair
            mycol = new DataColumn("hair", Type.GetType("System.String"));
            mycol.MaxLength = 50;
            mytab.Columns.Add(mycol);
            //creation de la colonne height
            mycol = new DataColumn("height", Type.GetType("System.String"));
            mycol.MaxLength = 50;
            mytab.Columns.Add(mycol);
            //creation de la colonne fname
            mycol = new DataColumn("eyes", Type.GetType("System.String"));
            mycol.MaxLength = 50;
            mytab.Columns.Add(mycol);

            return mytab;
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