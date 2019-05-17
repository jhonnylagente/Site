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

public partial class pages_monCompte : System.Web.UI.Page
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

    protected int CheckNombrePhotos(string reference)
    {
        int i = 0;

        // Récupère le chemin racine du site
        Connexion cI = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        cI.Open();
        System.Data.DataSet dsI = cI.exeRequette("Select * from Environnement");
        cI.Close();
        String racine_site = (String)dsI.Tables[0].Rows[0]["Chemin_racine_site"];

        String ImageA = racine_site + "images\\" + reference + "A.jpg";
        String ImageB = racine_site + "images\\" + reference + "B.jpg";
        String ImageC = racine_site + "images\\" + reference + "C.jpg";
        String ImageD = racine_site + "images\\" + reference + "D.jpg";
        String ImageE = racine_site + "images\\" + reference + "E.jpg";
        String ImageF = racine_site + "images\\" + reference + "F.jpg";
        String ImageG = racine_site + "images\\" + reference + "G.jpg";
        String ImageH = racine_site + "images\\" + reference + "H.jpg";

        if (System.IO.File.Exists(ImageA) == true)
            i++;
        if (System.IO.File.Exists(ImageB) == true)
            i++;
        if (System.IO.File.Exists(ImageC) == true)
            i++;
        if (System.IO.File.Exists(ImageD) == true)
            i++;
        if (System.IO.File.Exists(ImageE) == true)
            i++;
        if (System.IO.File.Exists(ImageF) == true)
            i++;
        if (System.IO.File.Exists(ImageG) == true)
            i++;
        if (System.IO.File.Exists(ImageH) == true)
            i++;

        return i;
    }
}
