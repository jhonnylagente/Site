using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data.Odbc;
using System.Data;

public partial class pages_afficherprofil : System.Web.UI.Page
{
    string idclients = "";
     
    protected void Page_Load(object sender, EventArgs e)
    {

        //le variable pour recuperer les pages Web 
           String s = Request.QueryString["field1"];
           string sql = "SELECT * FROM Clients WHERE idclient="+s;
           Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
           c.Open();
           System.Data.DataSet ds = c.exeRequette(sql);
           c.Close();

        ///clients
         

           Connexion c1 = new Connexion();
           OdbcCommand selectAllNego = new OdbcCommand("select * from Clients where statut ='ultranego' or statut = 'nego' order by nom_client");
           c1.Open();
           DataRowCollection reader = c1.exeRequetteParametree(selectAllNego).Tables[0].Rows;
           c1.Close();
       
           foreach (DataRow nego in reader)
           {
               ListItem unNegociateur = new ListItem(nego["nom_client"].ToString() + "  " + nego["prenom_client"].ToString(), nego["idclient"].ToString());
             
               if (unNegociateur.Value == "5") unNegociateur.Selected = true;
           }

           try
           {
               lblcivilite.Text = (String)ds.Tables[0].Rows[0]["civilite"];
           }
           catch 
           {

               lblcivilite.Text = " ";

           }

         
        // pour coloquer l'image
        ////////////////////
           //récupération de la racine du site web pour la vérificaton de la présence des images :
           Connexion c3 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
           c3.Open();
           System.Data.DataSet ds3 = c.exeRequette("Select * from Environnement");
           c3.Close();

           String racine_site = (String)ds3.Tables[0].Rows[0]["Chemin_racine_site"];
        
           string srcJpg = racine_site + "img_nego/" + (String)ds.Tables[0].Rows[0]["idclient"].ToString() + "_PHOTO.jpg";
           string sourceJpg = "../img_nego/" + (String)ds.Tables[0].Rows[0]["idclient"].ToString() + "_PHOTO.JPG";
      
        /////////////////////
           if (System.IO.File.Exists(srcJpg) == false) 
           {
               if ((String)ds.Tables[0].Rows[0]["civilite"] == "Mr")
               {
                   sourceJpg = "../img_site/img_homme.jpg";
               }
               else 
               {
                   sourceJpg = "../img_site/img_homme.jpg";
               }
           }
        //  TextBoxEmail.Text = s;
           Image1.ImageUrl = sourceJpg;
          //String racine_site = (String)ds.Tables[0].Rows[0]["Chemin_racine_site"];
           try
           {
               lblnom.Text = (String)ds.Tables[0].Rows[0]["nom_client"];
           }
           catch 
           {
                lblnom.Text = "";
           }
           try 
           {
               lblprenom.Text = (String)ds.Tables[0].Rows[0]["prenom_client"];
           }
           catch
           {
               lblprenom.Text = "";
           }
           try
           {
               lblemail.Text = (String)ds.Tables[0].Rows[0]["id_client"];
           }
           catch
           {
               lblemail.Text = "";
           }
           
           
           try
           {
               lbladd.Text = (String)ds.Tables[0].Rows[0]["adresse_client"];
           }
           catch
           {
               lbladd.Text = "";
           }
           try
           {
               lblcp.Text = (String)ds.Tables[0].Rows[0]["postal_client"];
           }
           catch
           {
               lblcp.Text = "";
           }
           try
           {
               lblville.Text = (String)ds.Tables[0].Rows[0]["ville_client"];
           }
           catch
           {
               lblville.Text = "";
           }
           try
           {
               lblpays.Text = (String)ds.Tables[0].Rows[0]["pays_client"];
           }
           catch
           {
               lblpays.Text = "";
           }
           try
           {
               lbltel.Text = (String)ds.Tables[0].Rows[0]["tel_client"];
           }
           catch
           {
               lbltel.Text = "";
           }
           try
           {
               lblfax.Text = (String)ds.Tables[0].Rows[0]["fax_client"];
              
           }
           catch
           {
               lblfax.Text = "";
           }
           try
           {
               lblsocie.Text = (String)ds.Tables[0].Rows[0]["société_client"];
           }
           catch
           {
               lblsocie.Text  = "";
           }


           try
           {
               lblstatus.Text = (String)ds.Tables[0].Rows[0]["statut"];



           }
           catch 
           {
               lblstatus.Text = "";
           }

          
    }

    

    protected void ButtonEnregistrer_Click1(object sender, EventArgs e)
    {
        
    }
    protected void TextBoxNom_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBoxPrenom_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBoxEmail_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBoxPassword_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBoxAdresse_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBoxCodePostal_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBoxVille_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBoxTel_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBoxFax_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBoxSociete_TextChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownListParain_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownListStatut_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("./parrains.aspx");
    }
}