using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_ficheNegociateur : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /* Membre member3 = new Membre();
         member3 = (Membre)Session["Membre"];
         String req = "select `num_agence` from Clients where `idclient`=" + member3.IDCLIENT;
         System.Data.DataSet ds2 = null;
         Connexion c2 = null;

         c2 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
         c2.Open();
         ds2 = c2.exeRequette(req);
         c2.Close();
         c2 = null;

         System.Data.DataRowCollection dr2 = ds2.Tables[0].Rows;

         string num_agence = "";
         foreach (System.Data.DataRow ligne2 in dr2)
             num_agence = ligne2["num_agence"].ToString();

         if (num_agence == "999")
         {
             num_agence = "001";
         }

         String req2 = "Select * from Agences where `num_agence`='" + num_agence + "'";

         c2 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
         c2.Open();
         ds2 = c2.exeRequette(req2);
         System.Data.DataSet dsracine = c2.exeRequette("Select * from Environnement");
         c2.Close();
         c2 = null;

         dr2 = ds2.Tables[0].Rows;
         String racine_site = (String)dsracine.Tables[0].Rows[0]["Chemin_racine_site"];
         foreach (System.Data.DataRow ligne2 in dr2)
         {
             Label31.Text = "<strong>PATRIMO</strong><br />";
             Label32.Text = ligne2["adresse_agence"].ToString() + "<br />";
             Label33.Text = ligne2["code_postal_agence"].ToString() + " " + ligne2["ville_agence"].ToString() + "<br />";
             Label34.Text = "Tél : " + ligne2["telephone_agence"].ToString() + "<br />" + "Fax : " + ligne2["telecopie_agence"].ToString() + "<br />";
         }*/
        Label31.Text = "<strong>PATRIMO</strong><br />";
        Label32.Text = Session["adresse_agence"].ToString() + "<br />";
        Label33.Text = Session["code_postal_agence"].ToString() + " " + Session["ville_agence"].ToString() + "<br />";
        Label34.Text = "Tél : " + Session["telephone_agence"].ToString() + "<br />";

        string racine_site = Session["racine_site"].ToString();
        string refse = Request.QueryString["refse"];
        String requette = "select * from Biens where ref='" + refse + "'";

		string pathA = "../images/" + refse + "A.JPG";
        string pathB = "../images/" + refse + "B.JPG";
        string pathC = "../images/" + refse + "C.JPG";
        string pathD = "../images/" + refse + "D.JPG";
        string ImageA = racine_site + "images\\" + refse + "A.JPG";
        string ImageB = racine_site + "images\\" + refse + "B.JPG";
        string ImageC = racine_site + "images\\" + refse + "C.JPG";
        string ImageD = racine_site + "images\\" + refse + "D.JPG";
		
        System.Data.DataSet dsN = null;
        Connexion cN = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        cN.Open();
        dsN = cN.exeRequette(requette);
       
        cN.Close();
        System.Data.DataRowCollection drN = dsN.Tables[0].Rows;
       
        foreach (System.Data.DataRow ligne in drN)
        {
            Ndossier.Text = refse;
            NMandat.Text = ligne["num_mandat"].ToString();
            Datemandat.Text = "";
            Négociateur.Text = ligne["negociateur"].ToString();
            Vendeur.Text = ligne["nom vendeur"].ToString();
            Addresse.Text = ligne["adresse du bien"].ToString();
            Label1.Text = ligne["type mandat"].ToString();
            cp.Text = ligne["code postal du bien"].ToString();
            ville.Text = ligne["ville du bien"].ToString();
            teledomicile.Text = ligne["tel domicile vendeur"].ToString();
            telebureau.Text = ligne["tel bureau vendeur"].ToString();
            mail.Text = ligne["adresse mail vendeur"].ToString();
            if (ligne["ref"].ToString().Substring(0, 1) == "V") prixdevente.Text = ligne["prix de vente"].ToString();
            else prixdevente.Text = ligne["loyer_cc"].ToString();
            double nombre = Convert.ToDouble(prixdevente.Text);
            prixdevente.Text = string.Format("{0:N}", nombre);
            Netvendeur.Text = ligne["net vendeur"].ToString();
            Charges.Text = ligne["charges"].ToString();
            Honoraires.Text = ligne["honoraires"].ToString();
            Travaux.Text = ligne["travaux"].ToString();
            Taxefonc.Text = ligne["taxe fonciere"].ToString();
            prixestime.Text = ligne["prix estimé"].ToString();
            Taxehab.Text = ligne["taxe habitation"].ToString();
            nclès.Text = "";
            SurfCarrez.Text = ligne["surface carrez"].ToString();
            Pièce.Text = ligne["nombre de pieces"].ToString();
            Chambre.Text = ligne["nombre de chambres"].ToString();
            SurfaceHab.Text = ligne["surface habitable"].ToString();
            wc.Text = ligne["nombre wc"].ToString();
            Surfaceséjour.Text = ligne["surface séjour"].ToString();
            Salledebains.Text = ligne["nombre salles de bain"].ToString();
            EXPOséjour.Text = ligne["exposition sejour"].ToString();
            Salledeau.Text = ligne["nombre salles eau"].ToString();
            Jardin.Text ="";
            Parkingintérieur.Text = ligne["nombre parkings interieurs"].ToString();
            Etage.Text = ligne["etage"].ToString();
            Parkingextérieur.Text = ligne["nombre parkings exterieurs"].ToString();
            Nbétages.Text = ligne["nombre etages"].ToString();
            Box.Text = "";
            Codeétages.Text = ligne["code etage"].ToString();
            Annéeconst.Text = ligne["annee construction"].ToString();
            Cave.Text = ligne["nombre de caves"].ToString();
            Cuisine.Text = ligne["type cuisine"].ToString();
            Ascenseur.Text = ligne["ascenceur"].ToString();
            Typechauff.Text = ligne["type chauffage"].ToString();
            Balcon.Text = ligne["balcon"].ToString();
            Naturechauff.Text = ligne["nature chauffage"].ToString();
            Terrasse.Text = ligne["terrasse"].ToString();
            Label2.Text = ligne["surface terrain"].ToString();
			textarea.Text = ligne["texte commentaires"].ToString();
      
            if (System.IO.File.Exists(ImageA))
            {
                Label35.Text = "<img style=\"width:100%;\" src=" + pathA + "/>";
            }
            else if (System.IO.File.Exists(ImageB))
            {
                Label35.Text = "<img src=" + pathB + "/>";
            }
            else if (System.IO.File.Exists(ImageC))
            {
                Label35.Text = "<img src=" + pathC + "/>";
            }
            else if (System.IO.File.Exists(ImageD))
            {
                Label35.Text = "<img src=" + pathD + "/>";
            }
            else
            {
                Label35.Text = "";
            }
			
			if (System.IO.File.Exists(ImageA)){
               ImageBatiment.ImageUrl=pathA;
			   ImageBatiment.Height = 400;
                ImageBatiment.Width = 505;
            }
			else{
                ImageBatiment.ImageUrl="";
            }
			
            if (System.IO.File.Exists(ImageB)){
               ImageBatiment2.ImageUrl=pathB;
			   ImageBatiment2.Width = 250;
			   ImageBatiment2.Height = 250;
            }
			else{
                ImageBatiment2.ImageUrl="";
            }
			
            if (System.IO.File.Exists(ImageC)){
               ImageBatiment3.ImageUrl=pathC;
			   ImageBatiment3.Width = 250;
			   ImageBatiment3.Height = 250;
            }
			else{
                ImageBatiment3.ImageUrl="";
            }
			
            if (System.IO.File.Exists(ImageD)){
               ImageBatiment4.ImageUrl=pathD;
			   ImageBatiment4.Width = 250;
			   ImageBatiment4.Height = 250;
            }
			else{
                ImageBatiment4.ImageUrl="";
            }
			
            Label37.Text = ligne["idclient"].ToString();
        }
        string nego = Négociateur.Text;
        int negoid;
        int.TryParse(Label37.Text, out negoid);
        string requet = "select * from Clients where idclient=" + negoid + "";
        Connexion c4 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c4.Open();
        System.Data.DataSet ds4 = c4.exeRequette(requet);
        c4.Close();
        System.Data.DataRowCollection dr4 = ds4.Tables[0].Rows;
        foreach (System.Data.DataRow ligne in dr4)
        {
            Label36.Text = nego + "<br />" + "Email: " + ligne["id_client"].ToString() + "<br />" + "Tél: " + ligne["tel_client"].ToString();
        }
    }
}