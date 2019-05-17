using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
/// <summary>
/// Description résumée de Class1
/// </summary>
public partial class pages_ajout_nego : System.Web.UI.Page
{
    protected System.Web.UI.WebControls.TextBox TextBoxNomVendeur;
    protected System.Web.UI.WebControls.TextBox TextBoxPrenomVendeur;
    protected System.Web.UI.WebControls.TextBox TextBoxAdresseVendeur;
    protected System.Web.UI.WebControls.TextBox TextBoxCodePostalVendeur;
    protected System.Web.UI.WebControls.TextBox TextBoxVilleVendeur;
    protected System.Web.UI.WebControls.TextBox TextBoxPaysVendeur;
    protected System.Web.UI.WebControls.TextBox TextBoxAdresseMailVendeur;
    protected System.Web.UI.WebControls.TextBox TextBoxPrixVente;
    protected System.Web.UI.WebControls.TextBox TextBoxNetVendeur;
    protected System.Web.UI.WebControls.TextBox TextBoxHonoraires;
    protected System.Web.UI.WebControls.TextBox TextBoxPourcentageVendeur;
    protected System.Web.UI.WebControls.TextBox TextBoxPrixEstime;
    protected System.Web.UI.WebControls.TextBox TextBoxTelDomicileVendeur;
    protected System.Web.UI.WebControls.TextBox TextBoxTelBureauVendeur;
    protected System.Web.UI.WebControls.TextBox TextBoxPrixTravaux;
    protected System.Web.UI.WebControls.TextBox TextBoxTaxeFonciere;
    protected System.Web.UI.WebControls.TextBox TextBoxTaxeHabitation;
    protected System.Web.UI.WebControls.TextBox TextBoxCharges;
    protected System.Web.UI.WebControls.RadioButton RadioButtonMr;
    protected System.Web.UI.WebControls.RadioButton RadioButtonMme;
    protected System.Web.UI.WebControls.RadioButton RadioButtonMlle;
    protected String racine_site = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        
		((System.Web.UI.WebControls.Label)Page.Master.FindControl("titrebandeau")).Text = "Mon compte";
        TextBoxNomVendeur = onglet_VendeurPrix.FindControl("TextBoxNomVendeur") as System.Web.UI.WebControls.TextBox;
        TextBoxPrenomVendeur = onglet_VendeurPrix.FindControl("TextBoxPrenomVendeur") as System.Web.UI.WebControls.TextBox;
        TextBoxAdresseVendeur = onglet_VendeurPrix.FindControl("TextBoxAdresseVendeur") as System.Web.UI.WebControls.TextBox;
        TextBoxCodePostalVendeur = onglet_VendeurPrix.FindControl("TextBoxCodePostalVendeur") as System.Web.UI.WebControls.TextBox;
        TextBoxVilleVendeur = onglet_VendeurPrix.FindControl("TextBoxVilleVendeur") as System.Web.UI.WebControls.TextBox;
        TextBoxPaysVendeur = onglet_VendeurPrix.FindControl("TextBoxPaysVendeur") as System.Web.UI.WebControls.TextBox;
        TextBoxAdresseMailVendeur = onglet_VendeurPrix.FindControl("TextBoxAdresseMailVendeur") as System.Web.UI.WebControls.TextBox;
        TextBoxPrixVente = onglet_VendeurPrix.FindControl("TextBoxPrixVente") as System.Web.UI.WebControls.TextBox;
        TextBoxNetVendeur = onglet_VendeurPrix.FindControl("TextBoxNetVendeur") as System.Web.UI.WebControls.TextBox;
        TextBoxHonoraires = onglet_VendeurPrix.FindControl("TextBoxHonoraires") as System.Web.UI.WebControls.TextBox;
		TextBoxPourcentageVendeur = onglet_VendeurPrix.FindControl("TextBoxPourcentageVendeur") as System.Web.UI.WebControls.TextBox;
        TextBoxPrixEstime = onglet_VendeurPrix.FindControl("TextBoxPrixEstime") as System.Web.UI.WebControls.TextBox;
        TextBoxTelDomicileVendeur = onglet_VendeurPrix.FindControl("TextBoxTelDomicileVendeur") as System.Web.UI.WebControls.TextBox;
        TextBoxTelBureauVendeur = onglet_VendeurPrix.FindControl("TextBoxTelBureauVendeur") as System.Web.UI.WebControls.TextBox;
        TextBoxPrixTravaux = onglet_VendeurPrix.FindControl("TextBoxPrixTravaux") as System.Web.UI.WebControls.TextBox;
        TextBoxTaxeFonciere = onglet_VendeurPrix.FindControl("TextBoxTaxeFonciere") as System.Web.UI.WebControls.TextBox;
        TextBoxTaxeHabitation = onglet_VendeurPrix.FindControl("TextBoxTaxeHabitation") as System.Web.UI.WebControls.TextBox;
        TextBoxCharges = onglet_VendeurPrix.FindControl("TextBoxCharges") as System.Web.UI.WebControls.TextBox;
        RadioButtonMr = onglet_VendeurPrix.FindControl("RadioButtonMr") as System.Web.UI.WebControls.RadioButton;
        RadioButtonMme = onglet_VendeurPrix.FindControl("RadioButtonMme") as System.Web.UI.WebControls.RadioButton;
        RadioButtonMlle = onglet_VendeurPrix.FindControl("RadioButtonMlle") as System.Web.UI.WebControls.RadioButton;
	
        string Type_bien_tmp = "";


        Connexion cI = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        cI.Open();
        System.Data.DataSet dsI = cI.exeRequette("Select * from Environnement");
        cI.Close();
        racine_site = (String)dsI.Tables[0].Rows[0]["Chemin_racine_site"];
		
        //Cette condition permet de ne pas réinitialiser la valeur selectionnée dans une DropDownList lorsque la page est rechargée.
        //Ceci est particulièrement utile lorsque l'utilisateur n'a pas correctement rempli le formulaire et que nous le redirigeons vers ce dernier.
        if (!Page.IsPostBack)
        {

            #region Peuplement

            //Peuplement des DropdownList à partir de la table table_types
            String requette = "select * from table_types";
            System.Data.DataSet ds = null;
            Connexion c = null;

            c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c.Open();
            ds = c.exeRequette(requette);
            c.Close();
            c = null;

            System.Data.DataRowCollection dr = ds.Tables[0].Rows;
            foreach (System.Data.DataRow ligne in dr)
            {
                if (ligne["etat"].ToString() != "null")
                {
                    DropDownListEtat.Items.Add(new ListItem(ligne["etat"].ToString(), ligne["etat"].ToString()));
                }
                if (ligne["type_mandat"].ToString() != "null")
                {
                    DropDownListTypeMandat.Items.Add(new ListItem(ligne["type_mandat"].ToString(), ligne["type_mandat"].ToString()));
                }

                if (ligne["type_cuisine"].ToString() != "null")
                {
                    DropDownListTypeCuisine.Items.Add(new ListItem(ligne["type_cuisine"].ToString(), ligne["type_cuisine"].ToString()));
                }

                if (ligne["type_sous_sol"].ToString() != "null")
                {
                    DropDownListTypeSousSol.Items.Add(new ListItem(ligne["type_sous_sol"].ToString(), ligne["type_sous_sol"].ToString()));
                }

                if (ligne["type_chauffage"].ToString() != "null")
                {
                    DropDownListTypeChauffage.Items.Add(new ListItem(ligne["type_chauffage"].ToString(), ligne["type_chauffage"].ToString()));
                }

                if (ligne["nature_chauffage"].ToString() != "null")
                {
                    DropDownListNatureChauffage.Items.Add(new ListItem(ligne["nature_chauffage"].ToString(), ligne["nature_chauffage"].ToString()));
                }

                if (ligne["proximite"].ToString() != "null")
                {
                    DropDownListProximite.Items.Add(new ListItem(ligne["proximite"].ToString(), ligne["proximite"].ToString()));
                }

                if (ligne["transport"].ToString() != "null")
                {
                    DropDownListTransport.Items.Add(new ListItem(ligne["transport"].ToString(), ligne["transport"].ToString()));
                }
            }
            #endregion

            #region pré-remplissage
            // On remplit tous les champs du formulaire avec les données dans la table bien

            String reference;
            reference = Request.QueryString["reference"];

            String requette2 = "Select * From Biens INNER JOIN optionsBiens ON Biens.ref = optionsBiens.refOptions where Biens.ref ='" + reference + "'";
            System.Data.DataSet ds2 = null;
            Connexion c2 = null;

            c2 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c2.Open();
            ds2 = c2.exeRequette(requette2);
            c2.Close();
            c2 = null;

            System.Data.DataRowCollection dr2 = ds2.Tables[0].Rows;

            foreach (System.Data.DataRow ligne in dr2)
            {
                // Mandat
                if ((string)ligne["type de bien"] == "A")
                {
                    DropDownListTypeBien.SelectedValue = "Appartement";
                    CheckBoxMeuble.Visible = false; 
                }
                if ((string)ligne["type de bien"] == "M")
                    DropDownListTypeBien.SelectedValue = "Maison";
                if ((string)ligne["type de bien"] == "T")
                    DropDownListTypeBien.SelectedValue = "Terrain";
                if ((string)ligne["type de bien"] == "L")
                    DropDownListTypeBien.SelectedValue = "Local";
                if ((string)ligne["type de bien"] == "I")
                    DropDownListTypeBien.SelectedValue = "Immeuble";

                if (ligne["etat"].ToString() == "Estimation")
                    spanPub.Attributes["class"] = "notInvisible";

                DropDownListEtat.SelectedValue = ligne["etat"].ToString();
                TextBoxCodePostalBien.Text = ligne["code postal du bien"].ToString();
                TextBoxAdresseBien.Text = ligne["adresse du bien"].ToString();
                TextBoxVilleBien.Text = ligne["ville du bien"].ToString();
                TextBoxPaysBien.Text = ligne["PaysBien"].ToString();
                TextBoxLocalisationBien.Text = ligne["localisation du bien"].ToString();
                DropDownListTypeMandat.SelectedValue = ligne["type mandat"].ToString();

                coupDeCoeur.Checked = (bool)ligne["CoupDeCoeur"];
                prestige.Checked = (bool)ligne["Prestige"];
                cb_Mer.Checked = (bool)ligne["Mer"];
                cb_Montagne.Checked = (bool)ligne["Montagne"];
                neuf.Checked = (bool)ligne["Neuf"];
                chckBxPub.Checked = (bool)ligne["PubLocale"];

                TextBoxDisponibilite.Text = ligne["disponibilité"].ToString();
            
                TextBoxMontantLoyer.Text = ligne["montant loyer"].ToString();

                // Vendeur et prix

                if (ligne["etat civil vendeur"].ToString().Equals("Mlle"))
                    RadioButtonMlle.Checked = true;

                if (ligne["etat civil vendeur"].ToString().Equals("Mr"))
                    RadioButtonMr.Checked = true;

                if (ligne["etat civil vendeur"].ToString().Equals("Mme"))
                    RadioButtonMme.Checked = true;

                TextBoxNomVendeur.Text = ligne["nom vendeur"].ToString();
                TextBoxPrenomVendeur.Text = ligne["prenom vendeur"].ToString();
                TextBoxAdresseVendeur.Text = ligne["adresse vendeur"].ToString();
                TextBoxCodePostalVendeur.Text = ligne["code postal vendeur"].ToString();
                TextBoxVilleVendeur.Text = ligne["ville vendeur"].ToString();
				
                TextBoxPaysVendeur.Text = ligne["pays vendeur"].ToString();
                TextBoxAdresseMailVendeur.Text = ligne["adresse mail vendeur"].ToString();

                TextBoxPrixVente.Text = ligne["prix de vente"].ToString();
                Session["tmpPrix"] = TextBoxPrixVente.Text;

                TextBoxHonoraires.Text = ligne["honoraires"].ToString();
				if(int.Parse(TextBoxPrixVente.Text) != 0)
					TextBoxPourcentageVendeur.Text = (100 * int.Parse(TextBoxHonoraires.Text) / int.Parse(TextBoxPrixVente.Text)).ToString();
                TextBoxNetVendeur.Text = ligne["net vendeur"].ToString();
                TextBoxPrixEstime.Text = ligne["prix estimé"].ToString();
                TextBoxTelDomicileVendeur.Text = ligne["tel domicile vendeur"].ToString();
                TextBoxTelBureauVendeur.Text = ligne["tel bureau vendeur"].ToString();
                TextBoxPrixTravaux.Text = ligne["travaux"].ToString();
                TextBoxTaxeFonciere.Text = ligne["taxe fonciere"].ToString();
                TextBoxTaxeHabitation.Text = ligne["taxe habitation"].ToString();
                TextBoxCharges.Text = ligne["charges"].ToString();

                // Juridique
                TextBoxNomSyndic.Text = ligne["nom_syndic"].ToString();
                TextBoxVilleSyndic.Text = ligne["ville_syndic"].ToString();
                TextBoxTelSyndic.Text = ligne["tel_syndic"].ToString();
                TextBoxFaxSyndic.Text = ligne["fax_syndic"].ToString();
                TextBoxMailSyndic.Text = ligne["mail_syndic"].ToString();
                TextBoxNumeroCles.Text = ligne["numero_cles"].ToString();
                TextBoxTexteSyndic.Text = ligne["texte_syndic"].ToString();
                Type_bien_tmp = ligne["categorie"].ToString();

                // Descriptif technique
                TextBoxNombrePieces.Text = ligne["nombre de pieces"].ToString();
                TextBoxNombreChambre.Text = ligne["nombre de chambres"].ToString();
                TextBoxNombreMursMitoyens.Text = ligne["nombre de murs mitoyens"].ToString();
                TextBoxSurfaceHabitable.Text = ligne["surface habitable"].ToString();
                TextBoxSurfaceCarrez.Text = ligne["surface carrez"].ToString();
                TextBoxSurfaceSejour.Text = ligne["surface séjour"].ToString();
                TextBoxExpositionSejour.Text = ligne["exposition sejour"].ToString();
                TextBoxSurfaceTerrain.Text = ligne["surface terrain"].ToString();
                TextBoxEtage.Text = ligne["etage"].ToString();
                TextBoxNombreEtage.Text = ligne["nombre etages"].ToString();
                TextBoxCodeEtage.Text = ligne["code etage"].ToString();
                TextBoxFacadeTerrain.Text = ligne["facade terrain"].ToString();
                TextBoxProfondeurTerrain.Text = ligne["profondeur terrain"].ToString();
                TextBoxCosTerrain.Text = ligne["cos terrain"].ToString();
                TextBoxShonTerrain.Text = ligne["shon terrain"].ToString();
                TextBoxAnneeConstruction.Text = ligne["annee construction"].ToString();

                if (ligne["meuble"].ToString().Equals("OUI"))
                    CheckBoxMeuble.Checked = true;

                DropDownListTypeCuisine.SelectedValue = ligne["type cuisine"].ToString();
                DropDownListTypeChauffage.SelectedValue = ligne["type chauffage"].ToString();
                DropDownListNatureChauffage.SelectedValue = ligne["nature chauffage"].ToString();
                DropDownListTypeSousSol.SelectedValue = ligne["type sous-sol"].ToString();

                if (ligne["ascenceur"].ToString().Equals("OUI"))
                    CheckBoxAscenseur.Checked = true;

                if (ligne["balcon"].ToString().Equals("OUI"))
                    CheckBoxBalcon.Checked = true;

                if (ligne["terrasse"].ToString().Equals("OUI"))
                    CheckBoxTerrasse.Checked = true;


                TextBoxNombreWc.Text = ligne["nombre wc"].ToString();
                TextBoxNombreSallesBain.Text = ligne["nombre salles de bain"].ToString();
                TextBoxNombreSallesEau.Text = ligne["nombre salles eau"].ToString();
                TextBoxNombreParkingInterieurs.Text = ligne["nombre parkings interieurs"].ToString();
                TextBoxNombreParkingExterieurs.Text = ligne["nombre parkings exterieurs"].ToString();
                TextBoxNombreGarages.Text = ligne["nombre garages"].ToString();
                TextBoxNombreCaves.Text = ligne["nombre de caves"].ToString();
                //               <td id="eau"><asp:CheckBox ID="CheckBoxEau" runat="server"  Text="Eau" Checked="True" /></td>
                //             <td id="gaz"><asp:CheckBox ID="CheckBoxGaz" runat="server"  Text="Gaz" Checked="True" /></td>
                //          <td><asp:CheckBox ID="CheckBoxElectricite" runat="server" Text="Electricite" Checked="True" /></td>
                //         <td><asp:CheckBox ID="CheckBoxToutaLegout" runat="server" Text="Tout à l'égout" Checked="True" /></td>
                //         <td><asp:CheckBox ID="CheckBoxLotissement" runat="server" Text="Lotissement" /></td>
                TextBoxNumeroLotissement.Text = ligne["num_lotissement"].ToString();
                //       <asp:CheckBox ID="CheckBoxAlignement" runat="server" Text="Alignement" /></td>                        
                DropDownListLettreConso.SelectedValue = ligne["lettre_conso"].ToString();
                TextBoxNombreConso.Text = ligne["nombre_conso"].ToString();
                DropDownListLettreEnergie.SelectedValue = ligne["lettre_energie"].ToString();
                TextBoxNombreEnergie.Text = ligne["nombre_energie"].ToString();
                tbCommentaires.Text = ligne["texte commentaires"].ToString();
                TextBoxTexteInternet.Text = ligne["texte internet"].ToString();
				
				TextBoxUrlVideo.Text = ligne["urlVideo"].ToString();
            }


            #endregion

            #region preselection
            //Pour ajouter à la liste catégorie les champs concernant le type de bien sauvegardé dans Type_bien_tmp.
            //Si Type_bien_tmp contient "Maison" on affiche Villa, ... mais pas Duplex, ... (qui est une catégorie d'appartement).

            String requette3 = "select * from table_types";
            System.Data.DataSet ds3 = null;
            Connexion c3 = null;

            c3 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c3.Open();
            ds3 = c3.exeRequette(requette3);
            c3.Close();
            c3 = null;

            System.Data.DataRowCollection dr3 = ds3.Tables[0].Rows;
            foreach (System.Data.DataRow ligne in dr3)
            {

                if (DropDownListTypeBien.SelectedValue == "Appartement")
                {
                    if (ligne["categorie_appartement"].ToString() != "null")
                    {
                        DropDownListCategorie.Items.Add(new ListItem(ligne["categorie_appartement"].ToString()));
                        
                    }
                }
                if (DropDownListTypeBien.SelectedValue == "Maison")
                {
                    if (ligne["categorie_maison"].ToString() != "null")
                    {
                        DropDownListCategorie.Items.Add(new ListItem(ligne["categorie_maison"].ToString(), ligne["categorie_maison"].ToString()));
                    }
                }
                if (DropDownListTypeBien.SelectedValue == "Immeuble")
                {
                    if (ligne["categorie_immeuble"].ToString() != "null")
                    {
                        DropDownListCategorie.Items.Add(new ListItem(ligne["categorie_immeuble"].ToString(), ligne["categorie_immeuble"].ToString()));
                    }
                }
                if (DropDownListTypeBien.SelectedValue == "Local")
                {
                    if (ligne["categorie_local"].ToString() != "null")
                    {
                        DropDownListCategorie.Items.Add(new ListItem(ligne["categorie_local"].ToString(), ligne["categorie_local"].ToString()));
                    }
                }
                if (DropDownListTypeBien.SelectedValue == "Terrain")
                {
                    if (ligne["categorie_terrain"].ToString() != "null")
                    {
                        DropDownListCategorie.Items.Add(new ListItem(ligne["categorie_terrain"].ToString(), ligne["categorie_terrain"].ToString()));
                    }
                }

            }


            DropDownListCategorie.SelectedValue = Type_bien_tmp;

            #endregion

        }
    }

    protected bool TestMandat(string refe)
    {
        // Récupère le chemin racine du site
        Connexion cI = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        cI.Open();
        System.Data.DataSet dsI = cI.exeRequette("Select * from Environnement");
        cI.Close();

        String racine_site = (String)dsI.Tables[0].Rows[0]["Chemin_racine_site"];

        String Mandat = racine_site + "Mandats\\" + refe + ".PDF";

        // on teste si elles existent
        if (System.IO.File.Exists(Mandat) == true)
            return true;
        else
            return false;
    }

    public bool TestImage(string idphoto)
    {
        bool exists = false;

        // On retrouve l'adresse de l'image : ref url + racine site
        String refe;
        refe = Request.QueryString["reference"];

        String path = racine_site + "images\\" + refe + idphoto;

        List<String> extensions = new List<String> { ".jpg", ".jpeg", ".JPG", ".JPEG" };
        foreach (String s in extensions) if (System.IO.File.Exists(path + s)) exists = true ;

        // on teste si elles existent
        return exists;
    }

    public String get_extension(String reference, String idphoto)
    {
        String path = racine_site + "images\\" + reference + idphoto;

        String ext = ".jpg";
        List<String> extensions = new List<String> { ".jpg", ".jpeg", ".JPG", ".JPEG" };
        foreach (String s in extensions) if (System.IO.File.Exists(path + s)) ext = s;

        return ext;
    }

    protected void SupprMandat(object sender, CommandEventArgs e)
    {
        Response.Write(e.CommandArgument);

        // On trouve le chemin des images : ref dans l'url + argument donné par le bouton
        String refe;
        refe = Request.QueryString["reference"];

        String Mandat = racine_site + "Mandats\\" + refe + ".pdf";

        // On supprime
        System.IO.File.Delete(Mandat);

        Response.Redirect("modifier_nego.aspx?reference=" + refe);

    }

    protected void SupprimerPhoto(object sender, CommandEventArgs e)
    {
        Response.Write(e.CommandArgument);

        // On trouve le chemin des images : ref dans l'url + argument donné par le bouton
        String refe;
        refe = Request.QueryString["reference"];

        String path = racine_site + "images\\" + refe + e.CommandArgument;

        // On supprime
        List<String> extensions = new List<String> { ".jpg", ".jpeg", ".JPG", ".JPEG" };
        foreach (String s in extensions) if (System.IO.File.Exists(path + s)) System.IO.File.Delete(path + s);

        Response.Redirect("modifier_nego.aspx?reference=" + refe + "&onglet=photos");

    }


    protected void ForcePhotoA(String reference)
    {
        //Remet toutes les photos dans l'ordre
        List<String> idPhoto = new List<String>(new String[] { "A", "B", "C", "D", "E", "F", "G", "H" });
        bool ok = true;
        String ext = ".jpg";

        foreach (String id in idPhoto)
        {
            ok = true;
            if (!System.IO.File.Exists(racine_site + "images\\" + reference + id + get_extension(reference, id)))
            {
                for (int i = idPhoto.IndexOf(id) + 1; i < idPhoto.Count; i++)
                {
                    ext = get_extension(reference, idPhoto[i]);
                    if (ok && System.IO.File.Exists(racine_site + "images\\" + reference + idPhoto[i] + ext))
                    {
                        FileInfo f = new FileInfo(racine_site + "images\\" + reference + idPhoto[i] + ext);
                        f.CopyTo(racine_site + "images\\" + reference + id + ".jpg");
                        System.IO.File.Delete(racine_site + "images\\" + reference + idPhoto[i] + ext);
                        ok = false;
                    }
                }
            }
        }
    }

    protected void TypeMandatChange(object sender, EventArgs e)
    {
        if (TestMandat(Request.QueryString["reference"]))
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "key", "launchModal();", true);
        }
    }

    protected void mandatChangeNonConfirme(object sender, EventArgs e)
    {
        String refe;
        refe = Request.QueryString["reference"];
        Response.Redirect("modifier_nego.aspx?reference=" + refe);
    }

    protected void mandatChangeConfirme(object sender, EventArgs e)
    {

            // On trouve le chemin des images : ref dans l'url + argument donné par le bouton
            String refe;
            refe = Request.QueryString["reference"];
            String Mandat = racine_site + "Mandats\\" + refe + ".pdf";

            // On supprime
            System.IO.File.Delete(Mandat);
            String requette3 = "UPDATE Biens SET `type mandat`='" + DropDownListTypeMandat.SelectedValue + "' where `ref`='" + refe + "'";
            Connexion c3 = null;

            c3 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c3.Open();
            c3.exeRequette(requette3);
            c3.Close();
            c3 = null;
            Response.Redirect("modifier_nego.aspx?reference=" + refe);
    }

    // Cette fonction est appelée lorsque un autre type de bien est selectionné. Ainsi est générée la liste catégorie correspondante au type de bien.
    protected void ItemChange(object sender, EventArgs e)
    {
       
        String requette = "select * from table_types";
        System.Data.DataSet ds = null;
        Connexion c = null;

        c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();
        ds = c.exeRequette(requette);
        c.Close();
        c = null;
        
        
        System.Data.DataRowCollection dr = ds.Tables[0].Rows;
        DropDownListCategorie.Items.Clear();


        foreach (System.Data.DataRow ligne in dr)
        {
            if ((((DropDownList)sender).SelectedValue).ToString() == "Appartement")
            {
                if (ligne["categorie_appartement"].ToString() != "null")
                {
                    DropDownListCategorie.Items.Add(new ListItem(ligne["categorie_appartement"].ToString()));
                }

                
                
            }
            if ((((DropDownList)sender).SelectedValue).ToString() == "Maison")
            {
                if (ligne["categorie_maison"].ToString() != "null")
                {
                    DropDownListCategorie.Items.Add(new ListItem(ligne["categorie_maison"].ToString(), ligne["categorie_maison"].ToString()));
                }
            }

            if ((((DropDownList)sender).SelectedValue).ToString() == "Immeuble")
            {
                if (ligne["categorie_immeuble"].ToString() != "null")
                {
                    DropDownListCategorie.Items.Add(new ListItem(ligne["categorie_immeuble"].ToString(), ligne["categorie_immeuble"].ToString()));
                }
            }

            if ((((DropDownList)sender).SelectedValue).ToString() == "Local")
            {
                if (ligne["categorie_local"].ToString() != "null")
                {
                    DropDownListCategorie.Items.Add(new ListItem(ligne["categorie_local"].ToString(), ligne["categorie_local"].ToString()));
                }
            }

            if ((((DropDownList)sender).SelectedValue).ToString() == "Terrain")
            {
                if (ligne["categorie_terrain"].ToString() != "null")
                {
                    DropDownListCategorie.Items.Add(new ListItem(ligne["categorie_terrain"].ToString(), ligne["categorie_terrain"].ToString()));
                }
            }
        }

       
    }


    // Constitue la vérification des champs côté serveur.
    private Boolean checkField(Bien bien)
    {
        #region attributs

        Regex regEmail = new Regex(@"^([\w\-.]+)@([\w]+)\.([\w]+)$");
        Regex numReg = new Regex("^[0-9]+(.[0-9]+)?$");
        Regex alphaNumReg = new Regex("^[-0-9 a-zA-Zéèçàâù . , ' ]+$|^()+$");
        Regex alphaReg = new Regex("^[-a-zA-Zéèçàâù ]+$");
		Regex alphaReg2 = new Regex("^[-a-zA-Zéèçàâù.,' ]+$");
        Regex numRegHonoraire = new Regex("^[0-9]+?$");
		
        var test = DropDownListTypeBien.SelectedValue.ToString();

        
        // MANDAT
        Boolean boolTypeBien = false;
        Boolean boolEtatBien = false;
        // Adresse du bien
        Boolean boolAdresseBien = false;
        Boolean boolCodePostalBien = false;
        Boolean boolVilleBien = false;
        Boolean boolPaysBien = false;
        Boolean boolLocalisationBien = false;

        // Info Mandat
        Boolean boolFileUpload9 = false;
        Boolean boolTypeMandat = false;
        Boolean boolDisponibilite = false;
        Boolean boolDateLiberation = true;
        Boolean boolMontantLoyer = false;
        Boolean boolDateEcheance = true;

        // VENDEURS ET PRIX
        // Coordonnées vendeur
        Boolean boolCiviliteVendeur = true;
        Boolean boolNomVendeur = false;
        Boolean boolPrenomVendeur = false;
        Boolean boolAdresseVendeur = false;
        Boolean boolCodePostalVendeur = false;
        Boolean boolVilleVendeur = false;
        Boolean boolPaysVendeur = false;
        Boolean boolAdresseMailVendeur = false;

        // Renseignement Financiers
        Boolean boolPrixVente = false;
        Boolean boolNetVendeur = false;
        Boolean boolHonoraies = false;
        Boolean boolPrixEstime = false;

        // Origine vendeur
        Boolean boolTelDomicileVendeur = false;
        Boolean boolTelBureauVendeur = false;
        Boolean boolPrixTravaux = false;
        Boolean boolTaxeFonciere = false;
        Boolean boolTaxeHabitation = false;
        Boolean boolCharges = false;

        // DESCRIPTIF TECHNIQUE
        // Caractéristiques principales
        Boolean boolCategorie = false;
        Boolean boolNombrePieces = false;
        Boolean boolNombreChambre = false;
        Boolean boolNombreMursMitoyens = false;
        Boolean boolSurfaceHabitable = false;
        Boolean boolSurfaceCarrez = false;
        Boolean boolSurfaceSejour = false;
        Boolean boolExpositionSejour = false;
        Boolean boolSurfaceTerrain = false;
        Boolean boolEtage = false;
        Boolean boolNombreEtage = false;
        Boolean boolCodeEtage = false;
        Boolean boolFacadeTerrain = false;
        Boolean boolProfondeurTerrain = false;
        Boolean boolCosTerrain = false;
        Boolean boolShonTerrain = false;

        // Informations complémentaires
        Boolean boolAnneeConstruction = false;
        Boolean boolTypeCuisine = false;
        Boolean boolTypeChauffage = false;
        Boolean boolNatureChauffage = false;
        Boolean boolTypeSousSol = false;

        // Disposition intérieure
        Boolean boolNombreWc = false;
        Boolean boolNombreSallesEau = false;
        Boolean boolNombreSallesBain = false;
        Boolean boolNombreParkingInterieurs = false;
        Boolean boolNombreParkingExterieurs = false;
        Boolean boolNombreGarages = false;
        Boolean boolNombreCaves = false;
        Boolean boolNumeroLotissement = false;

        // Diagnostique de performance
        Boolean boolLettreConso = false;
        Boolean boolLettreEnergie = false;
        Boolean boolNombreConso = false;
        Boolean boolNombreEnergie = false;

		
        // Texte Internet
        Boolean boolTexteInternet = false;
        Boolean booltbCommentaires = false;
        Boolean boolTextePublicite = false;
        Boolean boolTexteMailing = false;
		
		//ONGLET JURIDIQUE
		bool boolMailSyndic = false;
		bool boolTelSyndic = false;
		bool boolFaxSyndic = false;


        #endregion

        #region Bool à vrai si Regex vérifié

        // MANDAT

        boolTypeBien = alphaReg.IsMatch(DropDownListTypeBien.SelectedValue);
        boolEtatBien = alphaReg.IsMatch(DropDownListEtat.SelectedValue);
        // Adresse du bien
        boolAdresseBien = TextBoxAdresseBien.Text.Trim() == "" || alphaNumReg.IsMatch(TextBoxAdresseBien.Text.Trim());// <-------------------------------------------
        boolCodePostalBien = numReg.IsMatch(TextBoxCodePostalBien.Text.Trim());// <----------------------------------------------------------------------------------
        boolVilleBien = alphaReg2.IsMatch(TextBoxVilleBien.Text.Trim());
        boolPaysBien = alphaReg.IsMatch(TextBoxPaysBien.Text.Trim());
        boolLocalisationBien = TextBoxLocalisationBien.Text.Trim() == "" || alphaNumReg.IsMatch(TextBoxAdresseBien.Text.Trim());

        // Info Mandat
        string fileExt9 = "";
        fileExt9 = System.IO.Path.GetExtension(FileUpload9.FileName);
        if (DropDownListEtat.SelectedValue == "Disponible")
        {
            if (TestMandat(Request.QueryString["reference"]))
            {
                boolFileUpload9 = true;
            }
            else if (FileUpload9.HasFile)
            {
                if (fileExt9 != ".pdf" && fileExt9 != ".PDF")
                {
                    boolFileUpload9 = false;
                }
                else
                {
                    boolFileUpload9 = true;
                }
            }
            else
            {
                boolFileUpload9 = false;
            }
        }
        else
        {
            if (TestMandat(Request.QueryString["reference"]))
            {
                boolFileUpload9 = true;
            }
            else if (FileUpload9.HasFile)
            {
                if (fileExt9 != ".pdf" && fileExt9 != ".PDF")
                {
                    boolFileUpload9 = false;
                }
                else
                {
                    boolFileUpload9 = true;
                }
            }
            else
            {
                boolFileUpload9 = true;
            }
        }
        

        boolTypeMandat = DropDownListTypeMandat.SelectedValue == "" || alphaReg.IsMatch(DropDownListTypeMandat.SelectedValue);
        boolDisponibilite = TextBoxDisponibilite.Text.Trim() == "" || alphaNumReg.IsMatch(TextBoxDisponibilite.Text.Trim());
        boolMontantLoyer = TextBoxMontantLoyer.Text.Trim() == "" || numReg.IsMatch(TextBoxMontantLoyer.Text.Trim());
        boolDateEcheance = true;
        boolDateLiberation = true;

        // VENDEURS ET PRIX
        // Coordonnées vendeur
        //boolCiviliteVendeur = RadioButtonMr.Checked || RadioButtonMme.Checked || RadioButtonMlle.Checked || RadioButtonMr.;
        boolNomVendeur = TextBoxNomVendeur.Text.Trim() == "" || alphaReg.IsMatch(TextBoxNomVendeur.Text.Trim());
        boolPrenomVendeur = TextBoxPrenomVendeur.Text.Trim() == "" || alphaReg.IsMatch(TextBoxPrenomVendeur.Text.Trim());
        boolAdresseVendeur = TextBoxAdresseVendeur.Text.Trim() == "" || alphaNumReg.IsMatch(TextBoxAdresseVendeur.Text.Trim());
        boolCodePostalVendeur = TextBoxCodePostalVendeur.Text.Trim() == "" || numReg.IsMatch(TextBoxCodePostalVendeur.Text.Trim());
        boolVilleVendeur = TextBoxVilleVendeur.Text.Trim() == "" || alphaReg.IsMatch(TextBoxVilleVendeur.Text.Trim());
        boolPaysVendeur = TextBoxPaysVendeur.Text.Trim() == "" || alphaReg.IsMatch(TextBoxPaysVendeur.Text.Trim());
        boolAdresseMailVendeur = TextBoxAdresseMailVendeur.Text.Trim() == "" || regEmail.IsMatch(TextBoxAdresseMailVendeur.Text.Trim());

        // Renseignement Financiers
        boolPrixVente = numReg.IsMatch(TextBoxPrixVente.Text.Trim());
        boolNetVendeur = TextBoxNetVendeur.Text.Trim() == "" || numReg.IsMatch(TextBoxNetVendeur.Text.Trim());
        boolHonoraies = TextBoxHonoraires.Text.Trim() == "" || numReg.IsMatch(TextBoxHonoraires.Text.Trim());
        boolPrixEstime = TextBoxPrixEstime.Text.Trim() == "" || numReg.IsMatch(TextBoxPrixEstime.Text.Trim());

        // Origine vendeur
        boolTelDomicileVendeur = TextBoxTelDomicileVendeur.Text.Trim() == "" || alphaNumReg.IsMatch(TextBoxTelDomicileVendeur.Text.Trim());
        boolTelBureauVendeur = TextBoxTelBureauVendeur.Text.Trim() == "" || alphaNumReg.IsMatch(TextBoxTelBureauVendeur.Text.Trim());
        boolPrixTravaux = TextBoxPrixTravaux.Text.Trim() == "" || numReg.IsMatch(TextBoxPrixTravaux.Text.Trim());
        boolTaxeFonciere = TextBoxTaxeFonciere.Text.Trim() == "" || numReg.IsMatch(TextBoxTaxeFonciere.Text.Trim());
        boolTaxeHabitation = TextBoxTaxeHabitation.Text.Trim() == "" || numReg.IsMatch(TextBoxTaxeHabitation.Text.Trim());
        boolCharges = TextBoxCharges.Text.Trim() == "" || numReg.IsMatch(TextBoxCharges.Text.Trim());

		// DESCRIPTIF TECHNIQUE
        // Caractéristiques principales
        boolCategorie = DropDownListCategorie.SelectedValue == "" || alphaReg.IsMatch(DropDownListCategorie.SelectedValue);
        boolNombrePieces = TextBoxNombrePieces.Text.Trim() == "" || numReg.IsMatch(TextBoxNombrePieces.Text.Trim());
        boolNombreChambre = TextBoxNombreChambre.Text.Trim() == "" || numReg.IsMatch(TextBoxNombreChambre.Text.Trim());
        boolNombreMursMitoyens = TextBoxNombreMursMitoyens.Text.Trim() == "" || numReg.IsMatch(TextBoxNombreMursMitoyens.Text.Trim());
        if (DropDownListTypeBien.SelectedValue == "Appartement" || DropDownListTypeBien.SelectedValue == "Maison")
            boolSurfaceHabitable = numReg.IsMatch(TextBoxSurfaceHabitable.Text.Trim());
        else boolSurfaceHabitable = boolSurfaceCarrez = TextBoxSurfaceCarrez.Text.Trim() == "" || numReg.IsMatch(TextBoxSurfaceHabitable.Text.Trim());
        boolSurfaceCarrez = TextBoxSurfaceCarrez.Text.Trim() == "" || numReg.IsMatch(TextBoxSurfaceCarrez.Text.Trim());
        boolSurfaceSejour = TextBoxSurfaceSejour.Text.Trim() == "" || numReg.IsMatch(TextBoxSurfaceSejour.Text.Trim());
        boolExpositionSejour = TextBoxExpositionSejour.Text.Trim() == "" || alphaReg.IsMatch(TextBoxExpositionSejour.Text.Trim());
        boolSurfaceTerrain = TextBoxSurfaceTerrain.Text.Trim() == "" || numReg.IsMatch(TextBoxSurfaceTerrain.Text.Trim());
        boolEtage = TextBoxEtage.Text.Trim() == "" || numReg.IsMatch(TextBoxEtage.Text.Trim());
        boolNombreEtage = TextBoxNombreEtage.Text.Trim() == "" || numReg.IsMatch(TextBoxNombreEtage.Text.Trim());
        boolCodeEtage = TextBoxCodeEtage.Text.Trim() == "" || alphaNumReg.IsMatch(TextBoxCodeEtage.Text.Trim());
        boolFacadeTerrain = TextBoxFacadeTerrain.Text.Trim() == "" || alphaNumReg.IsMatch(TextBoxFacadeTerrain.Text.Trim());
        boolProfondeurTerrain = TextBoxProfondeurTerrain.Text.Trim() == "" || alphaNumReg.IsMatch(TextBoxProfondeurTerrain.Text.Trim());
        boolCosTerrain = TextBoxCosTerrain.Text.Trim() == "" || alphaNumReg.IsMatch(TextBoxCosTerrain.Text.Trim());
        boolShonTerrain = TextBoxShonTerrain.Text.Trim() == "" || alphaNumReg.IsMatch(TextBoxShonTerrain.Text.Trim());
        boolNumeroLotissement = TextBoxNumeroLotissement.Text.Trim() == "" || alphaNumReg.IsMatch(TextBoxNumeroLotissement.Text.Trim());

        // Informations complémentaires
        boolAnneeConstruction = TextBoxAnneeConstruction.Text.Trim() == "" || numReg.IsMatch(TextBoxAnneeConstruction.Text.Trim());
        boolTypeCuisine = DropDownListTypeCuisine.SelectedValue == "" || alphaReg.IsMatch(DropDownListTypeCuisine.SelectedValue);
        boolTypeChauffage = DropDownListTypeChauffage.SelectedValue == "" || alphaReg.IsMatch(DropDownListTypeChauffage.SelectedValue);
        boolNatureChauffage = DropDownListNatureChauffage.SelectedValue == "" || alphaReg.IsMatch(DropDownListNatureChauffage.SelectedValue);
        boolTypeSousSol = DropDownListTypeSousSol.SelectedValue == "" || alphaReg.IsMatch(DropDownListTypeSousSol.SelectedValue);

        // Disposition intérieure
        boolNombreWc = TextBoxNombreWc.Text.Trim() == "" || numReg.IsMatch(TextBoxNombreWc.Text.Trim());
        boolNombreSallesBain = TextBoxNombreSallesBain.Text.Trim() == "" || numReg.IsMatch(TextBoxNombreSallesBain.Text.Trim());
        boolNombreSallesEau = TextBoxNombreSallesEau.Text.Trim() == "" || numReg.IsMatch(TextBoxNombreSallesEau.Text.Trim());
        boolNombreParkingInterieurs = TextBoxNombreParkingInterieurs.Text.Trim() == "" || numReg.IsMatch(TextBoxNombreParkingInterieurs.Text.Trim());
        boolNombreParkingExterieurs = TextBoxNombreParkingExterieurs.Text.Trim() == "" || numReg.IsMatch(TextBoxNombreParkingExterieurs.Text.Trim());
        boolNombreGarages = TextBoxNombreGarages.Text.Trim() == "" || numReg.IsMatch(TextBoxNombreGarages.Text.Trim());
        boolNombreCaves = TextBoxNombreCaves.Text.Trim() == "" || numReg.IsMatch(TextBoxNombreCaves.Text.Trim());

        // Diagnostique de performance
        boolLettreEnergie = DropDownListLettreEnergie.SelectedValue == "" || alphaReg.IsMatch(DropDownListLettreEnergie.SelectedValue);
        boolNombreEnergie = TextBoxNombreEnergie.Text.Trim() == "" || numReg.IsMatch(TextBoxNombreEnergie.Text.Trim());
        boolLettreConso = DropDownListLettreConso.SelectedValue == "" || alphaReg.IsMatch(DropDownListLettreConso.SelectedValue);
        boolNombreConso = TextBoxNombreConso.Text.Trim() == "" || numReg.IsMatch(TextBoxNombreConso.Text.Trim());

        // Textes Mailing
        //boolTexteInternet = TextBoxTexteInternet.Text.Trim() == "" || alphaNumReg.IsMatch(TextBoxTexteInternet.Text.Trim());
       // booltbCommentaires = tbCommentaires.Text.Trim() == "" || alphaNumReg.IsMatch(tbCommentaires.Text.Trim());
        boolTexteInternet = TextBoxTexteInternet.Text.Trim() != null;
        booltbCommentaires = tbCommentaires.Text.Trim() != null;
        boolTextePublicite = TextBoxTextePublicite.Text.Trim() == "" || alphaNumReg.IsMatch(TextBoxTextePublicite.Text.Trim());
        boolTexteMailing = TextBoxTexteMailing.Text.Trim() == "" || alphaNumReg.IsMatch(TextBoxTexteMailing.Text.Trim());
		
				 //Syndic
		 boolMailSyndic = (TextBoxMailSyndic.Text.Trim() == "" || regEmail.IsMatch(TextBoxMailSyndic.Text.Trim()));
		 boolTelSyndic = (TextBoxTelSyndic.Text.Trim() == "" || numRegHonoraire.IsMatch(TextBoxTelSyndic.Text.Trim()));
		 boolFaxSyndic = (TextBoxFaxSyndic.Text.Trim() == "" || numRegHonoraire.IsMatch(TextBoxFaxSyndic.Text.Trim()));
		
		

        #endregion

        #region try...catch

        /************** MANDAT ************/
        /************** Références************/
        try
        {
			Membre member = (Membre)Session["Membre"];
			String reference;
			reference = Request.QueryString["reference"];
			String requet = "SELECT Biens.negociateur, Biens.ref FROM Biens WHERE ((Biens.ref)='" + reference + "')";
			System.Data.DataSet ds = null;
			Connexion c = null;				
			c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
			c.Open();
			ds = c.exeRequette(requet);
			c.Close();
			c = null;
			System.Data.DataRowCollection dr = ds.Tables[0].Rows;
			foreach (System.Data.DataRow ligne in dr)
			{
				bien.NEGOCIATEUR = ligne["negociateur"].ToString();
			}
        }
        catch { bien.NEGOCIATEUR = ""; }

        try
        {
            if (DropDownListTypeBien.SelectedValue == "Appartement") { bien.TYPE_BIEN = "A"; }
            if (DropDownListTypeBien.SelectedValue == "Maison") { bien.TYPE_BIEN = "M"; }
            if (DropDownListTypeBien.SelectedValue == "Immeuble") { bien.TYPE_BIEN = "I"; }
            if (DropDownListTypeBien.SelectedValue == "Local") { bien.TYPE_BIEN = "L"; }
            if (DropDownListTypeBien.SelectedValue == "Terrain") { bien.TYPE_BIEN = "T"; }
        }
        catch { bien.TYPE_BIEN = ""; }


        try { bien.ETAT = DropDownListEtat.SelectedValue; }
        catch { bien.ETAT = ""; }

        try
        {
            bien.PUB_LOCALE = chckBxPub.Checked;
            if (bien.PUB_LOCALE)
            {
                if (bien.ETAT != "Estimation")
                {
                    bien.PUB_LOCALE = false;
                }
            }
        }
        catch { bien.TYPE_MANDAT = "Error Pub Locale"; }


        /************** Adresse du bien ************/
		string texte=null;
		try { 
		 texte = TextBoxAdresseBien.Text;
		 texte=texte.Replace("'","''");
		 bien.ADRESSE_BIEN = texte.Trim(); }
         catch { bien.ADRESSE_BIEN = ""; }

        try { bien.CODE_POSTAL_BIEN = TextBoxCodePostalBien.Text.Trim(); }
        catch { bien.CODE_POSTAL_BIEN = ""; }

        try { bien.VILLE_BIEN = TextBoxVilleBien.Text.Trim().Replace("'","''"); }
        catch { bien.VILLE_BIEN = ""; }

        try { bien.PAYS = TextBoxPaysBien.Text.Trim(); }
        catch { bien.PAYS = ""; }
		 
        try { bien.LOCALISATION = TextBoxLocalisationBien.Text.Trim(); }
        catch { bien.LOCALISATION = ""; }


        bien.DATE_ECHEANCE = "00:00:0000";
        bien.DATE_LIBERATION = "00:00:0000";


        /************** Info mandat ************/
        try { bien.TYPE_MANDAT = DropDownListTypeMandat.SelectedValue; }
        catch { bien.TYPE_MANDAT = "tutu"; }


        try { bien.COUP_DE_COEUR = coupDeCoeur.Checked; }
        catch { bien.TYPE_MANDAT = "Error Coup de coeur"; }

        try { bien.PRESTIGE = prestige.Checked; }
        catch { bien.TYPE_MANDAT = "Error Prestige"; }

        try { bien.MER = cb_Mer.Checked; }
        catch { bien.TYPE_MANDAT = "Error Mer"; }

        try { bien.MONTAGNE = cb_Montagne.Checked; }
        catch { bien.TYPE_MANDAT = "Error Montagne"; }

        try 
        { bien.NEUF = neuf.Checked; }
        catch { bien.TYPE_MANDAT = "Error Neuf"; }

        try { bien.DISPONIBILITE = TextBoxDisponibilite.Text.Trim(); }
        catch { bien.DISPONIBILITE = ""; }


        try { bien.MONTANT_LOYER = int.Parse(TextBoxMontantLoyer.Text.Replace(" ","")); }
        catch { bien.MONTANT_LOYER = 0; }



        /************** VENDEURS ET PRIX ************/
        /************** Coordonnées vendeurs ************/

        try
        {
            if (RadioButtonMr.Checked) bien.CIVILITE_VENDEUR = "Mr";
            if (RadioButtonMme.Checked) bien.CIVILITE_VENDEUR = "Mme";
            if (RadioButtonMlle.Checked) bien.CIVILITE_VENDEUR = "Mlle";
        }
        catch { bien.CIVILITE_VENDEUR = "erreur"; }

        try { bien.NOM_VENDEUR = TextBoxNomVendeur.Text.Trim(); }
        catch { bien.NOM_VENDEUR = ""; }

        try { bien.PRENOM_VENDEUR = TextBoxPrenomVendeur.Text.Trim(); }
        catch { bien.PRENOM_VENDEUR = ""; }

		try { 
		 texte = TextBoxAdresseVendeur.Text;
		 texte=texte.Replace("'","''");
		 bien.ADRESSE_VENDEUR = texte.Trim(); }
         catch { bien.ADRESSE_VENDEUR = ""; }

        try { bien.CODE_POSTAL_VENDEUR = TextBoxCodePostalVendeur.Text.Replace(" ",""); }
        catch { bien.CODE_POSTAL_VENDEUR = ""; }

        try { bien.VILLE_VENDEUR = TextBoxVilleVendeur.Text.Trim(); }
        catch { bien.VILLE_VENDEUR = ""; }

        try { bien.PAYS_VENDEUR = TextBoxPaysVendeur.Text.Trim(); }
        catch { bien.PAYS_VENDEUR = ""; }

        try { bien.ADRESSE_MAIL_VENDEUR = TextBoxAdresseMailVendeur.Text.Trim(); }
        catch { bien.ADRESSE_MAIL_VENDEUR = ""; }


        /************** Renseignements Financiers ************/

        try { bien.PRIX_VENTE = int.Parse(TextBoxPrixVente.Text.Replace(" ", "")); }
        catch { bien.PRIX_VENTE = 0; }

        try {
            bien.ANCIEN_PRIX = Convert.ToInt32(Session["tmpPrix"]);
        }
        catch { 
            bien.ANCIEN_PRIX = 0; }

        try { bien.NET_VENDEUR = int.Parse(TextBoxNetVendeur.Text.Replace(" ","")); }
        catch { bien.NET_VENDEUR = 0; }

        try { bien.HONORAIRES = int.Parse(TextBoxHonoraires.Text.Replace(" ","")); }
        catch { bien.HONORAIRES = 0; }

        try { bien.PRIX_ESTIME = int.Parse(TextBoxPrixEstime.Text.Replace(" ","")); }
        catch { bien.PRIX_ESTIME = 0; }

        /************** Origine vendeur ************/
        /************** Téléphones et Notes ************/
        try { bien.TEL_DOMICILE_VENDEUR = TextBoxTelDomicileVendeur.Text.Trim(); }
        catch { bien.TEL_DOMICILE_VENDEUR = ""; }

        try { bien.TEL_BUREAU_VENDEUR = TextBoxTelBureauVendeur.Text.Trim(); }
        catch { bien.TEL_BUREAU_VENDEUR = ""; }

        /************** Impôts et Charges ************/
        try { bien.TRAVAUX = int.Parse(TextBoxPrixTravaux.Text.Replace(" ","")); }
        catch { bien.TRAVAUX = 0; }

        try { bien.TAXE_FONCIERE = TextBoxTaxeFonciere.Text.Trim(); }
        catch { bien.TAXE_FONCIERE = ""; }

        try { bien.TAXE_HABITATION = TextBoxTaxeHabitation.Text.Trim(); }
        catch { bien.TAXE_HABITATION = ""; }

        try { bien.CHARGES = TextBoxCharges.Text.Trim(); }
        catch { bien.CHARGES = ""; }


        /************** LOCALISATION ET FINANCE ************/
        /************** Environnement ************/
        try { bien.REFERENCE_PROPRIETAIRE = TextBoxReferenceProprietaire.Text.Trim(); }
        catch { bien.REFERENCE_PROPRIETAIRE = ""; }

        try { bien.RESIDENCE = TextBoxResidence.Text.Trim(); }
        catch { bien.RESIDENCE = ""; }

        try { bien.PROXIMITE = DropDownListProximite.SelectedValue; }
        catch { bien.PROXIMITE = ""; }

        try { bien.QUARTIER = TextBoxQuartier.Text.Trim(); }
        catch { bien.QUARTIER = ""; }

        try { bien.TRANSPORT = DropDownListTransport.SelectedValue; }
        catch { bien.TRANSPORT = ""; }

        try { bien.LOYER_HC = int.Parse(TextBoxLoyerHc.Text.Replace(" ","")); }
        catch { bien.LOYER_HC = 0; }

        try { bien.LOYER_CC = int.Parse(TextBoxLoyerCc.Text.Replace(" ","")); }
        catch { bien.LOYER_CC = 0; }

        try { bien.DEPOT_GARANTIE = int.Parse(TextBoxDepotGarantie.Text.Replace(" ","")); }
        catch { bien.DEPOT_GARANTIE = 0; }

        if (CheckBoxMeuble.Checked) { bien.MEUBLE = "OUI"; }




        /************** JURIDIQUE ************/
        /************** Coord syndic ************/
        try { bien.NOM_SYNDIC = TextBoxNomSyndic.Text.Trim(); }
        catch { bien.NOM_SYNDIC = ""; }

        try { bien.VILLE_SYNDIC = TextBoxVilleSyndic.Text.Trim(); }
        catch { bien.VILLE_SYNDIC = ""; }

        try { bien.TEL_SYNDIC = TextBoxTelSyndic.Text.Trim(); }
        catch { bien.TEL_SYNDIC = ""; }

        try { bien.FAX_SYNDIC = TextBoxFaxSyndic.Text.Trim(); }
        catch { bien.FAX_SYNDIC = ""; }
		
		try { bien.MAIL_SYNDIC = TextBoxMailSyndic.Text.Trim(); }
        catch { bien.MAIL_SYNDIC = ""; }

        /************** Consignes de visite ************/
        try { bien.NUMERO_CLES = int.Parse(TextBoxNumeroCles.Text.Replace(" ","")); }
        catch { bien.NUMERO_CLES = 0; }

        try { bien.TEXTE_SYNDIC = TextBoxTexteSyndic.Text.Trim(); }
        catch { bien.TEXTE_SYNDIC = ""; }




        /************** DESCRIPTIF TECHNIQUE ************/
        /************** Caractéristique principales ************/
        try { bien.CATEGORIE = DropDownListCategorie.SelectedValue; }
        catch { bien.CATEGORIE = ""; }

        try { bien.NBRE_PIECE = int.Parse(TextBoxNombrePieces.Text.Replace(" ","")); }
        catch { bien.NBRE_PIECE = 0; }

        try { bien.NBRE_CHAMBRE = int.Parse(TextBoxNombreChambre.Text.Replace(" ", "")); }
        catch { bien.NBRE_CHAMBRE = 0; }

        try { bien.S_HABITABLE = int.Parse(TextBoxSurfaceHabitable.Text.Replace(" ", "")); }
        catch { bien.S_HABITABLE = 0; }

        try { bien.S_CARREZ = int.Parse(TextBoxSurfaceCarrez.Text.Replace(" ","")); }
        catch { bien.S_CARREZ = 0; }

        try { bien.S_SEJOUR = int.Parse(TextBoxSurfaceSejour.Text.Replace(" ","")); }
        catch { bien.S_SEJOUR = 0; }

        try { bien.EXPOSITION_SEJOUR = TextBoxExpositionSejour.Text.Trim(); }
        catch { bien.EXPOSITION_SEJOUR = ""; }

        try { bien.S_TERRAIN = int.Parse(TextBoxSurfaceTerrain.Text.Replace(" ","")); }
        catch { bien.S_TERRAIN = 0; }

        try { bien.ETAGE = int.Parse(TextBoxEtage.Text.Replace(" ","")); }
        catch { bien.ETAGE = 0; }

        try { bien.NBRE_ETAGE = int.Parse(TextBoxNombreEtage.Text.Replace(" ","")); }
        catch { bien.NBRE_ETAGE = 0; }

        try { bien.CODE_ETAGE = int.Parse(TextBoxCodeEtage.Text.Replace(" ","")); }
        catch { bien.CODE_ETAGE = 0; }

        /************** Informations complémentaires ************/

        try { bien.A_CONSTRUCTION = TextBoxAnneeConstruction.Text.Trim(); }
        catch { bien.A_CONSTRUCTION = ""; }

        try { bien.T_CUISINE = DropDownListTypeCuisine.Text.Trim(); }
        catch { bien.T_CUISINE = ""; }

        try { bien.TYPE_CHAUFFAGE = DropDownListTypeChauffage.Text.Trim(); }
        catch { bien.TYPE_CHAUFFAGE = ""; }

        try { bien.NATURE_CHAUFFAGE = DropDownListNatureChauffage.Text.Trim(); }
        catch { bien.NATURE_CHAUFFAGE = ""; }

        try { bien.TYPE_SOUS_SOL = DropDownListTypeSousSol.Text.Trim(); }
        catch { bien.TYPE_SOUS_SOL = ""; }

        /************** Dispostion intérieure ************/
        /*VerificationAttribute checkbox */
        if (CheckBoxTerrasse.Checked) { bien.TERRASSE = "OUI"; }
        if (CheckBoxBalcon.Checked) { bien.BALCON = "OUI"; }
        if (CheckBoxAscenseur.Checked) { bien.ASCENSEUR = "OUI"; }


        try { bien.NBRE_WC = TextBoxNombreWc.Text.Trim(); }
        catch { bien.NBRE_WC = ""; }

        try { bien.NBRE_SALLE_BAIN = TextBoxNombreSallesBain.Text.Trim(); }
        catch { bien.NBRE_SALLE_BAIN = ""; }

        try { bien.NBRE_SALLE_EAU = TextBoxNombreSallesEau.Text.Trim(); }
        catch { bien.NBRE_SALLE_EAU = ""; }

        try { bien.NBRE_PARKING_INT = TextBoxNombreParkingInterieurs.Text.Trim(); }
        catch { bien.NBRE_PARKING_INT = ""; }

        try { bien.NBRE_PARKING_EXT = TextBoxNombreParkingExterieurs.Text.Trim(); }
        catch { bien.NBRE_PARKING_EXT = ""; }

        try { bien.NBRE_GARAGE = TextBoxNombreGarages.Text.Trim(); }
        catch { bien.NBRE_GARAGE = ""; }

        try { bien.NBRE_CAVE = TextBoxNombreCaves.Text.Trim(); }
        catch { bien.NBRE_CAVE = ""; }


        if (CheckBoxEau.Checked) { bien.EAU = "OUI"; }
        if (CheckBoxGaz.Checked) { bien.GAZ = "OUI"; }
        if (CheckBoxElectricite.Checked) { bien.ELECTRICITE = "OUI"; }
        if (CheckBoxToutaLegout.Checked) { bien.TOUT_A_LEGOUT = "OUI"; }
        if (CheckBoxLotissement.Checked) { bien.LOTISSEMENT = "OUI"; }
        if (CheckBoxAlignement.Checked) { bien.ALIGNEMENT = "OUI"; }

        try { bien.NUMERO_LOTISSEMENT = TextBoxNumeroLotissement.Text.Trim(); }
        catch { bien.NUMERO_LOTISSEMENT = ""; }




        try { bien.MURS_MITOYENS = TextBoxNombreMursMitoyens.Text.Trim(); }
        catch { bien.MURS_MITOYENS = ""; }

        try { bien.FACADE_TERRAIN = TextBoxFacadeTerrain.Text.Trim(); }
        catch { bien.FACADE_TERRAIN = ""; }

        try { bien.PROFONDEUR_TERRAIN = TextBoxProfondeurTerrain.Text.Trim(); }
        catch { bien.PROFONDEUR_TERRAIN = ""; }

        try { bien.COS_TERRAIN = TextBoxCosTerrain.Text.Trim(); }
        catch { bien.COS_TERRAIN = ""; }

        try { bien.SHON_TERRAIN = TextBoxShonTerrain.Text.Trim(); }
        catch { bien.SHON_TERRAIN = ""; }






        /************** Diagnostic de performance énergétique *************/
        try { bien.LETTRE_CONSO = DropDownListLettreConso.Text.Trim(); }
        catch { bien.LETTRE_CONSO = ""; }

        try { bien.NOMBRE_CONSO = int.Parse(TextBoxNombreConso.Text.Replace(" ","")); }
        catch { bien.NOMBRE_CONSO = 0; }

        try { bien.LETTRE_ENERGIE = DropDownListLettreEnergie.Text.Trim(); }
        catch { bien.LETTRE_ENERGIE = ""; }

        try { bien.NOMBRE_ENERGIE = int.Parse(TextBoxNombreEnergie.Text.Replace(" ","")); }
        catch { bien.NOMBRE_ENERGIE = 0; }


        /************** TEXTES PUBLICITAIRES ************/
        /************** Texte Internet************/
		
        try { 
		texte = TextBoxTexteInternet.Text;
		texte=texte.Replace("'","''");
		bien.TEXTE_INTERNET = texte.Trim(); }
        catch { bien.TEXTE_INTERNET = ""; }

        try {
        texte = tbCommentaires.Text;
        texte = texte.Replace("'", "''");
        bien.TEXTE_COMMENTAIRES = texte.Trim(); }
        catch { bien.TEXTE_COMMENTAIRES = ""; }

        try {
		texte = TextBoxTexteInternet.Text;
		texte=texte.Replace("'","''");
		bien.TEXTE_PUBLICITE = texte.Trim(); }
        catch { bien.TEXTE_PUBLICITE = ""; }

        try {
		texte = TextBoxTexteInternet.Text;
		texte=texte.Replace("'","''");
		bien.TEXTE_MAILING = texte.Trim(); }
        catch { bien.TEXTE_MAILING = ""; }

		try {bien.URLVIDEO = TextBoxUrlVideo.Text;}
		catch{bien.URLVIDEO = "";}



        // return true;
        #endregion
        /*
        if (boolAdresseBien && boolCodePostalBien && boolVilleBien) return true;
        else return false;
        */
        if (test == "Local")// pas d'affichage surface habitable pour Local, néanmoins il y avait toujours le demande du champs. Donc on force le bool à vrai.
        {
            boolSurfaceHabitable = true;
        }

        #region Vérification si tous les bool sont à vrai

        if (     // MANDAT
         boolTypeBien &&
         boolEtatBien &&
            // Adresse du bien
         boolAdresseBien &&
         boolCodePostalBien &&
         boolVilleBien &&
         boolPaysBien &&
         boolLocalisationBien &&

            // Info Mandat
         boolFileUpload9 &&
         boolTypeMandat &&
         boolDisponibilite &&
         boolDateLiberation &&
         boolMontantLoyer &&
         boolDateEcheance &&

        // VENDEURS ET PRIX
            // Coordonnées vendeur
         boolCiviliteVendeur &&
         boolNomVendeur &&
         boolPrenomVendeur &&
         boolAdresseVendeur &&
         boolCodePostalVendeur &&
         boolVilleVendeur &&
         boolPaysVendeur &&
         boolAdresseMailVendeur &&

            // Renseignement Financiers
         boolPrixVente &&
         boolNetVendeur &&
         boolHonoraies &&
         boolPrixEstime &&

            // Origine vendeur
         boolTelDomicileVendeur &&
         boolTelBureauVendeur &&
         boolPrixTravaux &&
         boolTaxeFonciere &&
         boolTaxeHabitation &&
         boolCharges &&

        // DESCRIPTIF TECHNIQUE
            // Caractéristiques principales
         boolCategorie &&
         boolNombrePieces &&
         boolNombreChambre &&
         boolNombreMursMitoyens &&
         boolSurfaceHabitable &&
         boolSurfaceCarrez &&
         boolSurfaceSejour &&
         boolExpositionSejour &&
         boolSurfaceTerrain &&
         boolEtage &&
         boolNombreEtage &&
         boolCodeEtage &&
         boolFacadeTerrain &&
         boolProfondeurTerrain &&
         boolCosTerrain &&
         boolShonTerrain &&

            // Informations complémentaires
         boolAnneeConstruction &&
         boolTypeCuisine &&
         boolTypeChauffage &&
         boolNatureChauffage &&
         boolTypeSousSol &&

            // Disposition intérieure
         boolNombreWc &&
         boolNombreSallesEau &&
         boolNombreSallesBain &&
         boolNombreParkingInterieurs &&
         boolNombreParkingExterieurs &&
         boolNombreGarages &&
         boolNombreCaves &&
         boolNumeroLotissement &&

            // Diagnostique de performance
         boolLettreConso &&
         boolLettreEnergie &&
         boolNombreConso &&
         boolNombreEnergie &&

            // Texte Internet
         boolTexteInternet &&
         booltbCommentaires &&
         boolTextePublicite &&
         boolTexteMailing &&
		 
		 		 //Syndic
		 boolMailSyndic &&
		 boolTelSyndic &&
		 boolFaxSyndic 

        )
        {
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "Le bien a correctement été modifié";
            return true;
        }

        #endregion

        else
        {
            LabelErrorLogin.Visible = true;

            LabelErrorLogin.Text = "Erreur de saisie pour les champs suivants : <br />";

            // MANDAT
            if (boolTypeBien == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Type de bien <br />";
            if (boolEtatBien == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Etat du bien <br />";
            // Adresse du bien
            if (boolAdresseBien == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Adresse du bien <br />";
            if (boolCodePostalBien == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Code Postal du bien <br />";
            if (boolVilleBien == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Ville du bien <br />";
            if (boolPaysBien == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Pays du bien <br />";
            if (boolLocalisationBien == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Localisation du bien <br />";

            // Info Mandat
            if (boolFileUpload9 == false && DropDownListEtat.SelectedValue == "Disponible") LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Il faut télécharger un mandat en format pdf pour un bien disponible <br />";
            if (boolFileUpload9 == false && DropDownListEtat.SelectedValue != "Disponible") LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Le mandat doit être en format pdf <br />";
            if (boolTypeMandat == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Type de mandat <br />";
            if (boolDisponibilite == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Disponibilité<br />";
            if (boolMontantLoyer == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Montant du loyer <br />";
            if (boolDateEcheance == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Date Echeance <br />";
            if (boolDateLiberation == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Date Liberation <br />";

            // VENDEURS ET PRIX
            // Coordonnées vendeur
            if (boolCiviliteVendeur == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Civilité vendeur <br />";
            if (boolNomVendeur == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Nom du vendeur <br />";
            if (boolPrenomVendeur == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Prenom du vendeur <br />";
            if (boolAdresseVendeur == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Adresse du vendeur <br />";
            if (boolCodePostalVendeur == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Code postal du vendeur<br />";
            if (boolVilleVendeur == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Ville du vendeur <br />";
            if (boolPaysVendeur == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Pays du vendeur <br />";
            if (boolAdresseMailVendeur == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Mail du vendeur <br />";

            // Renseignement Financiers
            if (boolPrixVente == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Prix de vente<br />";
            if (boolNetVendeur == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Net du vendeur<br />";
            if (boolHonoraies == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Honoraires<br />";
            if (boolPrixEstime == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Prix Estimé<br />";

            // Origine vendeur
            if (boolTelDomicileVendeur == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Tél domicile du vendeur<br />";
            if (boolTelBureauVendeur == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Tél bureau du vendeur<br />";
            if (boolPrixTravaux == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Prix des travaux<br />";
            if (boolTaxeFonciere == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Taxe Foncière<br />";
            if (boolTaxeHabitation == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Taxe Habitation<br />";
            if (boolCharges == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Charges<br />";

            // DESCRIPTIF TECHNIQUE
            // Caractéristiques principales
            if (boolCategorie == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Catégorie du bien<br />";
            if (boolNombrePieces == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Nombre de pièces<br />";
            if (boolNombreChambre == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Nombre de chambres<br />";
            if (boolNombreMursMitoyens == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Nombre de murs mitoyens<br />";
            if (boolSurfaceHabitable == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Surface Habitable<br />";
            if (boolSurfaceCarrez == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Surface Carrez<br />";
            if (boolSurfaceSejour == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Surface du séjour<br />";
            if (boolExpositionSejour == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Exposition du séjour<br />";
            if (boolSurfaceTerrain == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Surface du terrain<br />";
            if (boolEtage == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Etage<br />";
            if (boolNombreEtage == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Nombre Etage<br />";
            if (boolCodeEtage == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Code Etage<br />";
            if (boolFacadeTerrain == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Facade Terrain<br />";
            if (boolProfondeurTerrain == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Profondeur Terrain<br />";
            if (boolCosTerrain == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Cos Terrain<br />";
            if (boolShonTerrain == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Shon Terrain<br />";
            if (boolNumeroLotissement == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Numéro lotissement<br />";

            // Informations complémentaires
            if (boolAnneeConstruction == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Année de construction<br />";
            if (boolTypeCuisine == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Type de cuisine<br />";
            if (boolTypeChauffage == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Type de chauffage<br />";
            if (boolNatureChauffage == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Nature du chauffage<br />";
            if (boolTypeSousSol == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Type Sous Sol<br />";

            // Disposition intérieure
            if (boolNombreWc == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Nombre de WC<br />";
            if (boolNombreSallesEau == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Nombre de Salle d'eau<br />";
            if (boolNombreSallesBain == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Nombre de Salle de bain<br />";
            if (boolNombreParkingInterieurs == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Nombre de parkings int. <br />";
            if (boolNombreParkingExterieurs == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Nombre de parking ext. <br />";
            if (boolNombreGarages == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Nombre de garages <br />";
            if (boolNombreCaves == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Nombre de caves <br />";


            // Diagnostique energie
            if (boolLettreEnergie == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Lettre Energie<br />";
            if (boolNombreEnergie == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Nombre Energie<br />";
            if (boolLettreConso == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Lettre Conso<br />";
            if (boolNombreConso == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Nombre Conso<br />";


            // textes Mailing
            if (boolTexteInternet == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Texte Internet<br />";
            if (booltbCommentaires == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Texte Commentaires<br />";
            if (boolTextePublicite == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> <br />";
            if (boolTexteMailing == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> <br />";
			
			//Syndic
			if( boolMailSyndic == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Mail Syndic<br />";
			if( boolTelSyndic == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Tél. Syndic<br />";
			if( boolFaxSyndic == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Fax Syndic<br />";
			
            return false;
        }
    }


    //Est appelée lorsque l'utilisateur valide le formulaire. Les champs sont vérifiés. S'il n'y pas d'erreur une entrée est ajoutée à la base.
    protected void ButtonModifierBien_Click1(object sender, EventArgs e)
    {
        String reference;
        reference = Request.QueryString["reference"];

		
        // Ajoute le bien à la table
        Bien bien = new Bien();

        if (checkField(bien))
        {
            if (FileUpload(sender, e))
            {
                MandatUpload(sender, e);
                ForcePhotoA(reference);
                if (Session["tmpPrix"] != TextBoxPrixVente.Text)
                {
                    BienDAO.ModifierBien(bien, reference, true);
                }
                else
                {
                    BienDAO.ModifierBien(bien, reference, false);
                }
                Session["radioButtonAchat"] = true;
                Session["radioButtonLocation"] = false;
                Response.Redirect("./moncomptetableaudebord_bis.aspx");
            }
            else LabelErrorLogin.Text = " Erreur lors du chargement des photos <br />";
        }
    }

    //Bouton de debug pour forcer l'entrée dans la bdd.
    protected void ButtonAddBien_Click2(object sender, EventArgs e)
    {
        Membre member = new Membre();
        member = (Membre)Session["Membre"];
        Bien bien = new Bien();
        MandatUpload(sender, e);
        checkField(bien);
        BienDAO.addBien(bien, false, member.STATUT);
    }

    // Redirection vers le tableau de bord
    protected void verstableaudebord(object sender, EventArgs e)
    {
        Session["radioButtonAchat"] = true;
        Session["radioButtonLocation"] = false;
        Response.Redirect("./moncomptetableaudebord_bis.aspx");
    }

        protected void versFicheNego(object sender, EventArgs e)
    {
        Response.Write("<script>");
        Response.Write("window.open('./ficheNegociateur.aspx?refse="+ Request.QueryString["reference"]+"','_blank')");
        Response.Write("</script>");
    }

    



    public void ResizeFromStream(string ImageSavePath, int MaxSideSize, Stream Buffer)
    {
        int intNewWidth;
        int intNewHeight;
        System.Drawing.Image imgInput = System.Drawing.Image.FromStream(Buffer);

        //determiner le format d’image
        ImageFormat fmtImageFormat = imgInput.RawFormat;

        //prendre la hauteur et largeur de l’image
        int intOldWidth = imgInput.Width;
        int intOldHeight = imgInput.Height;

        //determiner si paysage ou portrait
        int intMaxSide;

        if (intOldWidth >= intOldHeight)
        {
            intMaxSide = intOldWidth;
        }
        else
        {
            intMaxSide = intOldHeight;
        }

        if (intMaxSide > MaxSideSize)
        {
            //determiner la nouvelle hauteur et largeur
            double dblCoef = MaxSideSize / (double)intMaxSide;
            intNewWidth = Convert.ToInt32(dblCoef * intOldWidth);
            intNewHeight = Convert.ToInt32(dblCoef * intOldHeight);
        }
        else
        {
            intNewWidth = intOldWidth;
            intNewHeight = intOldHeight;
        }
        //creer la nouvelle image
        Bitmap bmpResized = new Bitmap(imgInput, intNewWidth, intNewHeight);

        //enregistrer l’image sur le disque
        bmpResized.Save(ImageSavePath, fmtImageFormat);

        //liberer les ressources 
        imgInput.Dispose();
        bmpResized.Dispose();
        Buffer.Close();
    }

	
	
    protected Boolean MandatUpload(object sender, EventArgs e)
    {

        // reference dans l'url
        String refe;
        refe = Request.QueryString["reference"];

        string fileExt9 = "";
        fileExt9 = System.IO.Path.GetExtension(FileUpload9.FileName);
        if (FileUpload9.HasFile)
        {
            try { FileUpload9.SaveAs(racine_site + "Mandats\\" + refe + fileExt9); }
            catch (Exception ex) { Label1.Text = "ERROR: " + ex.Message.ToString(); }
        }
        return true;
    }

    //Gère l'upload des photos jpeg, jpg (renommage compris).
    protected Boolean FileUpload(object sender, EventArgs e)
    {
        Boolean boolFileUpload1 = true;
        Boolean boolFileUpload2 = true;
        Boolean boolFileUpload3 = true;
        Boolean boolFileUpload4 = true;
        Boolean boolFileUpload5 = true;
        Boolean boolFileUpload6 = true;
        Boolean boolFileUpload7 = true;
        Boolean boolFileUpload8 = true;


        // reference dans l'url
        String refe;
        refe = Request.QueryString["reference"];

        string fileExt1 = "";
        int file1 = 0;
        string fileExt2 = "";
        int file2 = 0;
        string fileExt3 = "";
        int file3 = 0;
        string fileExt4 = "";
        int file4 = 0;
        string fileExt5 = "";
        int file5 = 0;
        string fileExt6 = "";
        int file6 = 0;
        string fileExt7 = "";
        int file7 = 0;
        string fileExt8 = "";
        int file8 = 0;

        #region FileUpload1
        if (FileUpload1.HasFile)
        {
            fileExt1 = System.IO.Path.GetExtension(FileUpload1.FileName);
            if (fileExt1 != ".jpg" && fileExt1 != ".jpeg" && fileExt1 != ".JPG" && fileExt1 != ".JPEG")
            {
                boolFileUpload1 = false;
                Label1.Text = "seuls les fichiers .jpg sont autorisés!";
            }
            else if (FileUpload1.PostedFile.ContentLength >= 2097152)
            {
                boolFileUpload1 = false;
                Label1.Text = "Votre photo est trop grande!";
            }
            else
            {
                file1 = 1;
            }
        }
        #endregion

        #region FileUpload2
        if (FileUpload2.HasFile)
        {
            fileExt2 = System.IO.Path.GetExtension(FileUpload2.FileName);
            if (fileExt2 != ".jpg" && fileExt2 != ".jpeg" && fileExt2 != ".JPG" && fileExt2 != ".JPEG")
            {
                boolFileUpload2 = false;
                Label1.Text = "seuls les fichiers .jpg sont autorisés!";
            }
            else if (FileUpload2.PostedFile.ContentLength >= 2097152)
            {
                boolFileUpload2 = false;
                Label1.Text = "Votre photo est trop grande!";
            }
            else
            {
                file2 = 1;
            }
        }
        #endregion

        #region FileUpload3
        if (FileUpload3.HasFile)
        {
            fileExt3 = System.IO.Path.GetExtension(FileUpload3.FileName);
            if (fileExt3 != ".jpg" && fileExt3 != ".jpeg" && fileExt3 != ".JPG" && fileExt3 != ".JPEG")
            {
                boolFileUpload3 = false;
                Label1.Text = "seuls les fichiers .jpg sont autorisés!";
            }
            else if (FileUpload3.PostedFile.ContentLength >= 2097152)
            {
                boolFileUpload3 = false;
                Label1.Text = "Votre photo est trop grande!";
            }
            else
            {
                file3 = 1;
            }
        }
        #endregion

        #region FileUpload4

        if (FileUpload4.HasFile)
        {
            fileExt4 = System.IO.Path.GetExtension(FileUpload4.FileName);
            if (fileExt4 != ".jpg" && fileExt4 != ".jpeg" && fileExt4 != ".JPG" && fileExt4 != ".JPEG")
            {
                boolFileUpload4 = false;
                Label1.Text = "seuls les fichiers .jpg sont autorisés!";
            }
            else if (FileUpload4.PostedFile.ContentLength >= 2097152)
            {
                boolFileUpload4 = false;
                Label1.Text = "Votre photo est trop grande!";
            }
            else
            {
                file4 = 1;
            }
        }
        #endregion

        #region FileUpload5
        if (FileUpload5.HasFile)
        {
            fileExt5 = System.IO.Path.GetExtension(FileUpload5.FileName);
            if (fileExt5 != ".jpg" && fileExt5 != ".jpeg" && fileExt5 != ".JPG" && fileExt5 != ".JPEG")
            {
                boolFileUpload5 = false;
                Label1.Text = "seuls les fichiers .jpg sont autorisés!";
            }
            else if (FileUpload5.PostedFile.ContentLength >= 2097152)
            {
                boolFileUpload5 = false;
                Label1.Text = "Votre photo est trop grande!";
            }
            else
            {
                file5 = 1;
            }
        }
        #endregion

        #region FileUpload6
        if (FileUpload6.HasFile)
        {
            fileExt6 = System.IO.Path.GetExtension(FileUpload6.FileName);
            if (fileExt6 != ".jpg" && fileExt6 != ".jpeg" && fileExt6 != ".JPG" && fileExt6 != ".JPEG")
            {
                boolFileUpload6 = false;
                Label1.Text = "seuls les fichiers .jpg sont autorisés!";
            }
            else if (FileUpload6.PostedFile.ContentLength >= 2097152)
            {
                boolFileUpload6 = false;
                Label1.Text = "Votre photo est trop grande!";
            }
            else
            {
                file6 = 1;
            }
        }
        #endregion

        #region FileUpload7
        if (FileUpload7.HasFile)
        {
            fileExt7 = System.IO.Path.GetExtension(FileUpload7.FileName);
            if (fileExt7 != ".jpg" && fileExt7 != ".jpeg" && fileExt7 != ".JPG" && fileExt7 != ".JPEG")
            {
                boolFileUpload7 = false;
                Label1.Text = "seuls les fichiers .jpg sont autorisés!";
            }
            else if (FileUpload7.PostedFile.ContentLength >= 2097152)
            {
                boolFileUpload7 = false;
                Label1.Text = "Votre photo est trop grande!";
            }
            else
            {
                file7 = 1;
            }
        }
        #endregion

        #region FileUpload8
        if (FileUpload8.HasFile)
        {
            fileExt8 = System.IO.Path.GetExtension(FileUpload8.FileName);
            if (fileExt8 != ".jpg" && fileExt8 != ".jpeg" && fileExt8 != ".JPG" && fileExt8 != ".JPEG")
            {
                boolFileUpload8 = false;
                Label1.Text = "seuls les fichiers .jpg sont autorisés!";
            }
            else if (FileUpload8.PostedFile.ContentLength >= 2097152)
            {
                boolFileUpload8 = false;
                Label1.Text = "Votre photo est trop grande!";
            }
            else
            {
                file8 = 1;
            }
        }
        #endregion


        if (boolFileUpload1 && boolFileUpload2  && boolFileUpload3 && boolFileUpload4  && boolFileUpload5  && boolFileUpload6  && boolFileUpload7  && boolFileUpload8)
        {
            if (file1 == 1)
            {
                string chemin = racine_site + "images\\" + refe + "A" + fileExt1;
				Session["photoA"] = chemin;
                int dimension = 580;
                try { ResizeFromStream(chemin, dimension, FileUpload1.PostedFile.InputStream); }
                //try { FileUpload1.SaveAs(racine_site + "images\\" + refe + "A" + fileExt1); }
                catch (Exception ex) { Label1.Text = "ERROR: " + ex.Message.ToString(); }
            }

            if (file2 == 1)
            {
                string chemin = racine_site + "images\\" + refe + "B" + fileExt2;
				Session["photoB"] = chemin;
                int dimension = 580;
                try { ResizeFromStream(chemin, dimension, FileUpload2.PostedFile.InputStream); }
                //try { FileUpload2.SaveAs(racine_site + "images\\" + refe + "B" + fileExt2); }
                catch (Exception ex) { Label1.Text = "ERROR: " + ex.Message.ToString(); }
            }

            if (file3 == 1)
            {
                string chemin = racine_site + "images\\" + refe + "C" + fileExt3;
				Session["photoC"] = chemin;
                int dimension = 580;
                try { ResizeFromStream(chemin, dimension, FileUpload3.PostedFile.InputStream); }
                //try { FileUpload3.SaveAs(racine_site + "images\\" + refe + "C" + fileExt3); }
                catch (Exception ex) { Label1.Text = "ERROR: " + ex.Message.ToString(); }
            }

            if (file4 == 1)
            {
                string chemin = racine_site + "images\\" + refe + "D" + fileExt4;
				Session["photoD"] = chemin;
                int dimension = 580;
                try { ResizeFromStream(chemin, dimension, FileUpload4.PostedFile.InputStream); }
                //try { FileUpload4.SaveAs(racine_site + "images\\" + refe + "D" + fileExt4); }
                catch (Exception ex) { Label1.Text = "ERROR: " + ex.Message.ToString(); }
            }

            if (file5 == 1)
            {
                string chemin = racine_site + "images\\" + refe + "E" + fileExt5;
				Session["photoE"] = chemin;
                int dimension = 580;
                try { ResizeFromStream(chemin, dimension, FileUpload5.PostedFile.InputStream); }
                //try { FileUpload5.SaveAs(racine_site + "images\\" + refe + "E" + fileExt5); }
                catch (Exception ex) { Label1.Text = "ERROR: " + ex.Message.ToString(); }
            }

            if (file6 == 1)
            {
                string chemin = racine_site + "images\\" + refe + "F" + fileExt6;
				Session["photoF"] = chemin;
                int dimension = 580;
                try { ResizeFromStream(chemin, dimension, FileUpload6.PostedFile.InputStream); }
                //try { FileUpload6.SaveAs(racine_site + "images\\" + refe + "F" + fileExt6); }
                catch (Exception ex) { Label1.Text = "ERROR: " + ex.Message.ToString(); }
            }

            if (file7 == 1)
            {
                string chemin = racine_site + "images\\" + refe + "G" + fileExt7;
				Session["photoG"] = chemin;
                int dimension = 580;
                try { ResizeFromStream(chemin, dimension, FileUpload7.PostedFile.InputStream); }
                //try { FileUpload7.SaveAs(racine_site + "images\\" + refe + "G" + fileExt7); }
                catch (Exception ex) { Label1.Text = "ERROR: " + ex.Message.ToString(); }
            }

            if (file8 == 1)
            {
                string chemin = racine_site + "images\\" + refe + "H" + fileExt8;
				Session["photoH"] = chemin;
                int dimension = 580;
                try { ResizeFromStream(chemin, dimension, FileUpload8.PostedFile.InputStream); }
                //try { FileUpload8.SaveAs(racine_site + "images\\" + refe + "H" + fileExt8); }
                catch (Exception ex) { Label1.Text = "ERROR: " + ex.Message.ToString(); }
            }

            return true;
        }
        else
            return false;
    }




}