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

    protected bool CheckPhotoProfil(int idclient)
    {

        // Récupère le chemin racine du site
        Connexion cI = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        cI.Open();
        System.Data.DataSet dsI = cI.exeRequette("Select * from Environnement");
        cI.Close();
        String racine_site = (String)dsI.Tables[0].Rows[0]["Chemin_racine_site"];

        String Image = racine_site + "img_nego\\" + idclient + "_PHOTO.jpg";

        // On regarde si l'image en question existe
        if (System.IO.File.Exists(Image) == true)
            return true;

        else
            return false;
    }

    protected Boolean FileUpload(object sender, EventArgs e)
    {
        Boolean boolFileUpload1 = true;


        // Récupère le chemin racine du site
        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();
        System.Data.DataSet ds2 = c.exeRequette("Select * from Environnement");
        c.Close();

        String racine_site = (String)ds2.Tables[0].Rows[0]["Chemin_racine_site"];

        Membre member = (Membre)Session["Membre"];
 
        // chargement de photo

        if (FileUpload1.HasFile)
        {
            string fileExt1 = System.IO.Path.GetExtension(FileUpload1.FileName);
            if (fileExt1 == ".jpg" || fileExt1 == ".jpeg" || fileExt1 == ".JPG" || fileExt1 == ".JPEG")
            {
                try { FileUpload1.SaveAs(racine_site + "img_nego\\" + member.IDCLIENT + "_PHOTO" + fileExt1); }
                catch (Exception ex) { Label1.Text = "ERROR: " + ex.Message.ToString(); }
            }
            else
            {
                Label1.Text = "Only .jpg files allowed!";
                boolFileUpload1 = false;
            }
        }
        
        if (boolFileUpload1)
            return true;
        else
            return false;
    }

    protected void SupprimerProfilPicture(object sender, EventArgs e)
    {       
        // Récupère le chemin racine du site
        Connexion cI = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        cI.Open();
        System.Data.DataSet dsI = cI.exeRequette("Select * from Environnement");
        cI.Close();

        String racine_site = (String)dsI.Tables[0].Rows[0]["Chemin_racine_site"];

        Membre member = (Membre)Session["Membre"];

        String Image = racine_site + "img_nego\\" + member.IDCLIENT + "_PHOTO.jpg";

        // On supprime
        if (System.IO.File.Exists(Image))
            System.IO.File.Delete(Image);

        Response.Redirect("monComptecompleterprofil.aspx");

    }

    protected void ButtonAddProfilPicture(object sender, EventArgs e)
    {
        if (FileUpload(sender, e))
            Response.Redirect("monComptecompleterprofil.aspx");
    }

   


}
