using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class afficher_acquereur : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String s = Request.QueryString["ref"];
        string sql = "SELECT Acquereurs.*  FROM Acquereurs  WHERE id_acq=" + s;
        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();
        System.Data.DataSet ds = c.exeRequette(sql);
        c.Close();
        ///Champ Civilité
        if ((String)ds.Tables[0].Rows[0]["civilite"] == "Mr")
        {
            RadioButtonMr.Checked = true;
        }
        else if ((String)ds.Tables[0].Rows[0]["civilite"] == "Mlle")
        {
            RadioButtonMlle.Checked = true;
        }
        else if ((String)ds.Tables[0].Rows[0]["civilite"] == "Mme")
        {
            RadioButtonMme.Checked = true;
        }
        //Champ NOM 
        try
        {
            TextBoxNom.Text = (String)ds.Tables[0].Rows[0]["nom"];
        }
        catch
        {
            TextBoxNom.Text = "";
        }
        //Champ prénom
        try
        {
            TextBoxPrenom.Text = (String)ds.Tables[0].Rows[0]["prenom"];
        }
        catch
        {
            TextBoxPrenom.Text = "";
        }

        
        //Champ Adresse
           try
           {
               TextBoxAdresse.Text = (String)ds.Tables[0].Rows[0]["adresse"];
           }
           catch
           {
               TextBoxAdresse.Text = "";
           }
      
            //Champ VILLE
           try
           {
               TextBoxVille.Text = (String)ds.Tables[0].Rows[0]["ville"];
           }
           catch
           {
               TextBoxVille.Text = "";
           }
           //Champ CODE POSTAL
           try
           {
               TextBoxCodePostal.Text = (String)ds.Tables[0].Rows[0]["code_postal"];
           }
           catch
           {
               TextBoxCodePostal.Text = "";
           }
           //Champ PAYS
           try
           {
               TextBoxPays.Text = (String)ds.Tables[0].Rows[0]["pays"];
           }
           catch
           {
               TextBoxPays.Text = "";
           }
           //Champ TELEPHONE
           try
           {
               TextBoxTel.Text = (String)ds.Tables[0].Rows[0]["tel"];
           }
           catch
           {
               TextBoxTel.Text = "";
           }
           //Champ EMAIL
           try
           {
               TextBoxMail.Text = (String)ds.Tables[0].Rows[0]["mail"];
               
           }
           catch
           {
               TextBoxMail.Text = "";
           }
           //Champ PORTABLE
           try
           {
               TextBoxPortable.Text = (String)ds.Tables[0].Rows[0]["portable"];

           }
           catch
           {
               TextBoxPortable.Text = "";
           }
           //Champ APPARTEMENT
           if ((bool)ds.Tables[0].Rows[0]["appartement"] == true)
           {

               CheckBoxAppartement.Checked = true;
           }
           //Champ APPARTEMENT
           if ((bool)ds.Tables[0].Rows[0]["maison"] == true)
           {

               CheckBoxMaison.Checked = true;
           }
           //Champ TERRAIN
           if ((bool)ds.Tables[0].Rows[0]["terrain"] == true)
           {

               CheckBoxTerrain.Checked = true;
           }
           
           //Champ AUTRE
           if ((bool)ds.Tables[0].Rows[0]["autre"] == true)
           {

               CheckBoxAutre.Checked = true;
           }

           //Champ ACHETEUR
           try
           {
               TextBoxType_acquereur.Text = (String)ds.Tables[0].Rows[0]["type_acquereur"];

           }
           catch
           {
               TextBoxType_acquereur.Text = "";
           }
        
            
           //Champ ACHETEUR
           try
           {
               TextBoxRecherche.Text = (String)ds.Tables[0].Rows[0]["categorie"];

           }
           catch
           {
               TextBoxRecherche.Text = "";
           }

        
             //Champ TERRAIN
           if ((bool)ds.Tables[0].Rows[0]["vendeur"] == true)
           {

               CheckBoxVendeur.Checked = true;
           }

        
            //Champ etat d'avancement 
            try
           {
               TextBoxEtatAvancement.Text = (String)ds.Tables[0].Rows[0]["etat_avancement"];

           }
           catch
           {
               TextBoxEtatAvancement.Text = "";
           }

        
          //Champ prix_min 
            try
           {
               TextBoxPrixMin.Text = ds.Tables[0].Rows[0]["prix_min"].ToString();

           }
           catch
           {
               TextBoxPrixMin.Text = "";
           }
            //Champ prix_mmax
            try
            {
                TextBoxPrixMax.Text = ds.Tables[0].Rows[0]["prix_max"].ToString();

            }
            catch
            {
                TextBoxPrixMax.Text = "";
            }


            //Champ nombre_de_pieces_min
            try
            {
                TextBoxPiecesMin.Text = ds.Tables[0].Rows[0]["nombre_de_pieces_min"].ToString();

            }
            catch
            {
                TextBoxPiecesMin.Text = "";
            }
            //Champ nombre_de_pieces_max
            try
            {
                TextBoxPiecesMax.Text = ds.Tables[0].Rows[0]["nombre_de_pieces_max"].ToString();

            }
            catch
            {
                TextBoxPiecesMax.Text = "";
            }


            //Champ nombre_de_chambres_min
            try
            {
                TextBoxChambresMin.Text = ds.Tables[0].Rows[0]["nombre_de_chambres_min"].ToString();

            }
            catch
            {
                TextBoxChambresMin.Text = "";
            }
            //Champ nombre_de_chambres_max
            try
            {
                TextBoxChambresMax.Text = ds.Tables[0].Rows[0]["nombre_de_chambres_max"].ToString();

            }
            catch
            {
                TextBoxChambresMax.Text = "";
            }
            //Champ surface_habitable_min
            try
            {
                TextBoxSurfaceHabitableMin.Text = ds.Tables[0].Rows[0]["surface_habitable_min"].ToString();

            }
            catch
            {
                TextBoxSurfaceHabitableMin.Text = "";
            }
            //Champ surface_habitable_max
            try
            {
                TextBoxSurfaceHabitableMax.Text = ds.Tables[0].Rows[0]["surface_habitable_max"].ToString();

            }
            catch
            {
                TextBoxSurfaceHabitableMax.Text = "";
            }
        
            //Champ surface_sejour_min
            try
            {
                TextBoxSurfaceSejourMin.Text = ds.Tables[0].Rows[0]["surface_sejour_min"].ToString();

            }
            catch
            {
                TextBoxSurfaceSejourMin.Text = "";
            }

            //Champ surface_sejour_max
            try
            {
                TextBoxSurfaceSejourMax.Text = ds.Tables[0].Rows[0]["surface_sejour_max"].ToString();

            }
            catch
            {
                TextBoxSurfaceSejourMax.Text = "";
            }
       
            //Champ facade
            try
            {
                TextBoxFacade.Text = ds.Tables[0].Rows[0]["facade"].ToString();

            }
            catch
            {
                TextBoxFacade.Text = "";
            }
        
            //Champ Profondeur
            try
            {
                TextBoxProfondeur.Text = ds.Tables[0].Rows[0]["facade"].ToString();

            }
            catch
            {
                TextBoxProfondeur.Text = "";
            }


            //Champ SurfaceTerrainMax
            try
            {
                TextBoxSurfaceTerrainMax.Text = ds.Tables[0].Rows[0]["surface_terrain_max"].ToString();

            }
            catch
            {
                TextBoxSurfaceTerrainMax.Text = "";
            }

            //Champ SurfaceTerrainMin
            try
            {
                TextBoxSurfaceTerrainMin.Text = ds.Tables[0].Rows[0]["surface_terrain_min"].ToString();

            }
            catch
            {
                TextBoxSurfaceTerrainMin.Text = "";
            }



            //Champ CheckBoxAscenseur
           if (ds.Tables[0].Rows[0]["ascenseur"].ToString() !="NON")
           {

               CheckBoxAscenseur.Checked = true;
           }
           //Champ parking/box
           if (ds.Tables[0].Rows[0]["parking/box"].ToString() != "NON")
           {

               CheckBoxParking.Checked = true;
           }
           //Champ sous-sol
           if (ds.Tables[0].Rows[0]["sous-sol"].ToString() != "NON")
           {

               CheckBoxSousSol.Checked = true;
           }
    }
}