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
        static SqlConnection myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bdd_lavalife;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 refM = Convert.ToInt32(Request.QueryString["refm"]);
            string sql = "DELETE FROM Messages WHERE refM =" + refM;
            myCon.Open();
            SqlCommand mycmd = new SqlCommand(sql, myCon);
            mycmd.ExecuteNonQuery();
            myCon.Close();
            Server.Transfer("reception.aspx");
        }
    }
}