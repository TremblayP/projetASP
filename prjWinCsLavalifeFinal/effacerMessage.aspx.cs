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
    public partial class effacerMessage : System.Web.UI.Page
    {
        static DataSet mySet;
        static DataTable tabUser, tabSpecifications, tabMessages;
        static SqlDataAdapter adpUser, adpSpecifications, adpMessages;
        static SqlConnection myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bdd_lavalife;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                /*Int32 refM = Convert.ToInt32(Request.QueryString["refm"]);
                string sql = "DELETE FROM Messages WHERE refM =" + refM;
                myCon.Open();
                SqlCommand mycmd = new SqlCommand(sql, myCon);
                mycmd.ExecuteNonQuery();
                myCon.Close();
                */
                Int32 refM = Convert.ToInt32(Request.QueryString["refm"]);
                mySet = getDataSet();
                tabUser = mySet.Tables["Users"];
                tabSpecifications = mySet.Tables["Specifications"];
                tabMessages = mySet.Tables["Messages"];
                myCon.Open();
                DataRow tmp = tabMessages.NewRow();
                int indice = 0;
                bool indiceTrouve = false;
                foreach(DataRow dr in tabMessages.Rows)
                {
                    if(dr["refM"].ToString() == refM.ToString())
                    {
                        tmp = dr;
                        indiceTrouve = true;
                    }
                    if (indiceTrouve)
                    {
                        break;
                    }
                    else
                    {
                        indice++;
                    }
                }
                tabMessages.Rows[indice].Delete();
                //synchro
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(adpMessages);
                adpMessages.Update(mySet, "Messages");
                //refill dataset
                tabMessages = mySet.Tables["Messages"];
                mySet.Tables.Remove(tabMessages);
                adpMessages.Fill(mySet, "Messages");
                tabMessages = mySet.Tables["Messages"];

                myCon.Close();
                Server.Transfer("reception.aspx");
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
    }
}