using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_ficheCommerciale : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int negoid=0;
		string negociateur=null;
        Membre member3 = new Membre();
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
            Label34.Text = "Tél : " + ligne2["telephone_agence"].ToString() + "<br />";
        }
        
        string refsepare = Request.QueryString["refsepare"];
        string requette3 = "select * from Biens where ref='" + refsepare + "'";
        
		string pathA = "../images/" + refsepare + "A.JPG";
        string pathB = "../images/" + refsepare + "B.JPG";
        string pathC = "../images/" + refsepare + "C.JPG";
        string pathD = "../images/" + refsepare + "D.JPG";
        string ImageA = racine_site + "images\\" + refsepare + "A.JPG";
        string ImageB = racine_site + "images\\" + refsepare + "B.JPG";
        string ImageC = racine_site + "images\\" + refsepare + "C.JPG";
        string ImageD = racine_site + "images\\" + refsepare + "D.JPG";
		
		
		Connexion c3 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c3.Open();
        System.Data.DataSet ds3 = c3.exeRequette(requette3);
        c3.Close();
        System.Data.DataRowCollection dr3 = ds3.Tables[0].Rows;
        
        foreach (System.Data.DataRow ligne in dr3)
        {
			if (ligne["type de bien"].ToString() != "T") Label1.Text= ligne["nombre de pieces"].ToString() + " pièces";
			else Label1.Text = "";
            Label1.Text = Label1.Text.ToUpper();
			
            if (ligne["ref"].ToString().Substring(0, 1) == "V") Label2.Text = ligne["prix de vente"].ToString() + " ";
            else Label2.Text = ligne["loyer_cc"].ToString() +" ";
            double nombre = Convert.ToDouble(Label2.Text);
            Label2.Text = string.Format("{0:N}", nombre);

            Label3.Text = ligne["ref"].ToString();
            negociateur = ligne["negociateur"].ToString();

            if (ligne["surface terrain"].ToString() == "0")
                surfaceTerrain.Text = null;
            else
                surfaceTerrain.Text = ligne["surface terrain"].ToString() + " m²";         
            Label5.Text = ligne["charges"].ToString();
            Label6.Text = ligne["travaux"].ToString();
            Label7.Text = ligne["taxe habitation"].ToString();
            Label8.Text = ligne["taxe fonciere"].ToString();
            Label9.Text = ligne["nombre de pieces"].ToString();
            Label10.Text = ligne["nombre de chambres"].ToString();
            Label11.Text = ligne["surface habitable"].ToString();
            Label12.Text = ligne["surface carrez"].ToString();
            Label13.Text = ligne["surface séjour"].ToString();
            Label14.Text = ligne["exposition sejour"].ToString();
            Label15.Text = ligne["etage"].ToString();
            Label16.Text = ligne["nombre etages"].ToString();
            Label17.Text = ligne["code etage"].ToString();
            Label18.Text = ligne["annee construction"].ToString();
            Label19.Text = ligne["type cuisine"].ToString();
            Label20.Text = ligne["nombre wc"].ToString();
            Label21.Text = ligne["nombre salles de bain"].ToString();
            Label22.Text = ligne["nombre salles eau"].ToString();
            Label23.Text = ligne["nombre parkings interieurs"].ToString();
            Label24.Text = ligne["nombre parkings exterieurs"].ToString();
            
            Label25.Text = ligne["nombre de caves"].ToString();
            Label26.Text = ligne["type chauffage"].ToString();
            Label27.Text = ligne["nature chauffage"].ToString();
            Label28.Text = ligne["ascenceur"].ToString();
            Label29.Text = ligne["balcon"].ToString();
            Label30.Text = ligne["terrasse"].ToString();
            Label38.Text = ligne["surface terrain"].ToString();
            
			if(ligne["type de bien"].ToString() == "A")
			{
				Labeltype.Text = "APPARTEMENT";
			}
			else if (ligne["type de bien"].ToString() == "T")
            {
				Labeltype.Text = "TERRAIN";
			}
			else if (ligne["type de bien"].ToString() == "M")
            {
				Labeltype.Text = "MAISON";
			}
			else if (ligne["type de bien"].ToString() == "L")
            {
				Labeltype.Text = "LOCAL";
			}
			else if (ligne["type de bien"].ToString() == "I")
            {
				Labeltype.Text = "IMMEUBLE";
			}
			
			
            if (System.IO.File.Exists(ImageA)){
               ImageBatiment.ImageUrl=pathA;
			   ImageBatiment.Height = 400;
                ImageBatiment.Width = 524;
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
            negoid=(int)ligne["idclient"];

        }
        string requet = "select * from Clients where idclient=" + negoid + "";
        Connexion c4 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c4.Open();
        System.Data.DataSet ds4 = c4.exeRequette(requet);
        c4.Close();
        System.Data.DataRowCollection dr4 = ds4.Tables[0].Rows;
        foreach (System.Data.DataRow ligne in dr4) {
            Label36.Text =  negociateur + "<br />" + ligne["id_client"].ToString() + "<br />" + ligne["tel_client"].ToString();
        }
    }

}