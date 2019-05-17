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

public partial class pages_supprimer_acquereur : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		((Label)Page.Master.FindControl("titrebandeau")).Text = "Mon espace";
    }

    protected void versListeAcquereur(object sender, EventArgs e)
    {    
        Response.Redirect("./liste_acquereur.aspx");
    }

    protected void ButtonSupprimerAcquereur(object sender, EventArgs e)
    {
        // on récupère le bien à supprimer qui est dans l'url
        String id_acq;
        id_acq = Request.QueryString["idacq"];

        // on met en archive l'acquereur
        String requette = "UPDATE Acquereurs SET `actif`='archive' WHERE `id_acq`=" + id_acq;

        System.Data.DataSet ds2 = null;
        Connexion c2 = null;

        c2 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c2.Open();
        ds2 = c2.exeRequette(requette);
        c2.Close();
        c2 = null;

        

        Response.Redirect("./liste_acquereur.aspx");         
    }

}
