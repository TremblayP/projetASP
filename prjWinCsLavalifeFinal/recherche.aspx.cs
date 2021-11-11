using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjWinCsLavalifeFinal
{
    public partial class recherche : System.Web.UI.Page

    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["searchAgain"] == "true")
            {
                if (Page.IsPostBack)
                {
                    
                }
                cboGenderR.SelectedValue = Session["gender"].ToString();
                txtNationalityR.Text = Session["nationality"].ToString();
                txtHairR.Text = Session["hair"].ToString();
                string min = Session["minHeight"].ToString();
                string max = Session["maxHeight"].ToString();
                txtMinHeight.Text = min;
                txtMaxHeight.Text = max;
                txtEyesR.Text = Session["eyes"].ToString();

            }
        }

        protected void btnRecherche_Click(object sender, EventArgs e)
        {
            Session["gender"] = cboGenderR.SelectedValue;
            Session["nationality"] = UppercaseFirst(txtNationalityR.Text.ToString());
            Session["hair"] = UppercaseFirst(txtHairR.Text.ToString()) ;
            Session["minHeight"] = (txtMinHeight.Text.ToString());
            Session["maxHeight"] =(txtMaxHeight.Text.ToString());
            Session["eyes"] = UppercaseFirst(txtEyesR.Text.ToString());
            Session["searchAgain"] = "false";
            Response.Redirect("result.aspx");
           
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

        protected void cboGenderR_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["gender"] = cboGenderR.SelectedValue;
        }
    }
}