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

public partial class pages_reactivervente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Page.Master.FindControl("titrebandeau")).Text = "Mon espace";
    }

    protected void verstableaudebord(object sender, EventArgs e)
    {
        Response.Redirect("./moncomptetableaudebord_bis.aspx");
    }

    protected void ButtonReactiverBien(object sender, EventArgs e)
    {
        // on récupère le bien à supprimer qui est dans l'url
        String reference;
        reference = Request.QueryString["reference"];
        Response.Write(reference);


        // on met le bien en archive
        String requette = "UPDATE Biens SET `actif`='actif' WHERE `ref`='" + reference + "'";


        // on le supprime en requete SQL
        // String requette = "DELETE * From Biens where `ref`='" + reference + "'";

        System.Data.DataSet ds2 = null;
        Connexion c2 = null;

        c2 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c2.Open();
        ds2 = c2.exeRequette(requette);
        c2.Close();
        c2 = null;

        Response.Redirect("./moncomptetableaudebord_bis.aspx");
    }
}