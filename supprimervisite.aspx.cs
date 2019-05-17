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

public partial class pages_supprimer_visite : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		((Label)Page.Master.FindControl("titrebandeau")).Text = "Mon espace";
    }

    protected void versHistoriqueVisite(object sender, EventArgs e)
    {    
        Response.Redirect("./historique_visite.aspx");
    }

    protected void ButtonSupprimerVisite(object sender, EventArgs e)
    {
        // on récupère le bien à supprimer qui est dans l'url
        String reference;
        reference = Request.QueryString["reference"];
        Response.Write(reference);


        // on met la visite en archive
        String requette = "UPDATE visite SET `actif`='archive' WHERE `id_bien`='" + reference + "'";

        // on le supprime en requete SQL
        //String requette = "DELETE * From visite where `id_bien`='" + reference + "'";

        System.Data.DataSet ds2 = null;
        Connexion c2 = null;

        c2 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c2.Open();
        ds2 = c2.exeRequette(requette);
        c2.Close();
        c2 = null;


        Response.Redirect("./historique_visite.aspx");         
    }

}
