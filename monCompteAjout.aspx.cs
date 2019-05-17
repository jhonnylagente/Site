using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class pages_monCompteAjout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		((Label)Page.Master.FindControl("titrebandeau")).Text = "Mon espace";

        if (Session["logged"].Equals(true))
        {
            // permet le "Bonjour Mr X"
            Membre member = (Membre)Session["Membre"];
            LabelPrenom.Text = member.CIVILITE;
            LabelNom.Text = member.NOM;
        }
        else
        {
            Response.Redirect("./recherche.aspx");
        }
    }



    

   


}
