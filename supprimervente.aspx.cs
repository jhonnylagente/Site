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

public partial class pages_supprimer_vente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		((Label)Page.Master.FindControl("titrebandeau")).Text = "Mon espace";
    }

    protected void verstableaudebord(object sender, EventArgs e)
    {    
        Response.Redirect("./moncomptetableaudebord_bis.aspx");
    }

    protected void ButtonSupprimerBien(object sender, EventArgs e)
    {
        // on récupère le bien à supprimer qui est dans l'url
        String reference;
        reference = Request.QueryString["reference"];
        Response.Write(reference);


        // on met le bien en archive
        String requette = "UPDATE Biens SET `actif`='archive' WHERE `ref`='" + reference +"'"; 

    
        // on le supprime en requete SQL
            // String requette = "DELETE * From Biens where `ref`='" + reference + "'";

        System.Data.DataSet ds2 = null;
        Connexion c2 = null;

        c2 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c2.Open();
        ds2 = c2.exeRequette(requette);
        c2.Close();
        c2 = null;
        


        // on supprime les photos
            // on récupère l'adresse des images
        /*Connexion cI = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
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

            // on teste si les images existent, on les supprime si elles existent
        if (System.IO.File.Exists(ImageA) == true)
            System.IO.File.Delete(ImageA);

        if (System.IO.File.Exists(ImageB) == true)
            System.IO.File.Delete(ImageB);

        if (System.IO.File.Exists(ImageC) == true)
            System.IO.File.Delete(ImageC);

        if (System.IO.File.Exists(ImageD) == true)
            System.IO.File.Delete(ImageD);

        if (System.IO.File.Exists(ImageE) == true)
            System.IO.File.Delete(ImageE);

        if (System.IO.File.Exists(ImageF) == true)
            System.IO.File.Delete(ImageF);

        if (System.IO.File.Exists(ImageG) == true)
            System.IO.File.Delete(ImageG);

        if (System.IO.File.Exists(ImageH) == true)
            System.IO.File.Delete(ImageH);*/

        Response.Redirect("./moncomptetableaudebord_bis.aspx");         
    }

}
