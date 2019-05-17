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

public partial class pages_monCompteAlertes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		((Label)Page.Master.FindControl("titrebandeau")).Text = "Alertes";
	
        if (Session["logged"].Equals(true))
        {
            Membre member = (Membre)Session["membre"];
            System.Collections.Generic.IList<RequeteBien> memberAlerte = MembreDAO.getAlerteMembre(member);
            //if (memberAlerte.Count == 0) Response.Redirect("./alerteMail.aspx");
        }
        else
        {
            Response.Redirect("./inscriptionaccueil.aspx");
        }
    }
}
