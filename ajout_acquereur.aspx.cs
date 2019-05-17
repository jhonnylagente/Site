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
using System.Data.Odbc;
using System.Collections.Generic;
using GestionEmplacement;

public partial class pages_ajout_acquereur : System.Web.UI.Page
{
	
	protected void Page_PreInit(object sender, EventArgs e)
	{
		Session["bugfix_reset"] = true;
	}

    protected void Page_Load(object sender, EventArgs e)
    {	
		if(Request.QueryString["new"] == "1")
			Session["ajout_acquereur"] = "true";
        ((Label)Page.Master.FindControl("titrebandeau")).Text = "Mon espace";

        

        string requete = "SELECT TITRE_PAYS FROM PAYS";
        System.Data.DataSet ds2 = null;
        Connexion c2 = null;

        c2 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c2.Open();
        ds2 = c2.exeRequette(requete);
        c2.Close();
        c2 = null;

        DropDownListPays.DataSource = ds2;
        DropDownListPays.DataTextField = "TITRE_PAYS";
        DropDownListPays.DataValueField = "TITRE_PAYS";
        DropDownListPays.DataBind();
        DropDownListPays.SelectedIndex = 68;

        if(Request.QueryString["reference"] != null)
        {

            //ucAjoutAcquereur.UpdatePanel1_Init(sender, e);
            //ucAjoutAcquereur.UpdatePanel1_Init(sender, e);
            

            if (!Page.IsPostBack)
            {
                #region pré-remplissage
            // On remplit tous les champs du formulaire avec les données dans la table bien

            String idAcq;
            idAcq = Request.QueryString["reference"];

            String requette = "Select * From Acquereurs where `id_acq`=" + idAcq + "";
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
                // Général
				if (ligne["civilite"].ToString() == "Mr")
					RadioButtonMr.Checked = true;
				else if (ligne["civilite"].ToString() == "Mlle")
					RadioButtonMlle.Checked = true;
				else if (ligne["civilite"].ToString() == "Mme")
					RadioButtonMme.Checked = true;
                TextBoxNom.Text = ligne["nom"].ToString();
                TextBoxPrenom.Text = ligne["prenom"].ToString();
                TextBoxAdresse.Text = ligne["adresse"].ToString();
                TextBoxCodePostal.Text = ligne["code_postal"].ToString();
                TextBoxVille.Text = ligne["ville"].ToString();
                DropDownListPays.Text = ligne["pays"].ToString();
                TextBoxTel.Text = ligne["tel"].ToString();
                TextBoxPortable.Text = ligne["portable"].ToString();
                TextBoxMail.Text = ligne["mail"].ToString();
                DropDownListTypeAcq.SelectedValue = ligne["type_acquereur"].ToString();
                DDLCategorieAcquereur.SelectedValue = ligne["categorie"].ToString();

                //Caractéristiques principales
                if (ligne["appartement"].ToString() == "True")
                    CheckBoxAppartement.Checked = true;
                if (ligne["maison"].ToString() == "True")
                    CheckBoxMaison.Checked = true;
                if (ligne["terrain"].ToString() == "True")
                    CheckBoxTerrain.Checked = true;
                if (ligne["autre"].ToString() == "True")
                    CheckBoxAutre.Checked = true;
                DropDownListEtatAvancement.SelectedValue = ligne["etat_avancement"].ToString();
                TextBoxPrixMin.Text = ligne["prix_min"].ToString();
                TextBoxPrixMax.Text = ligne["prix_max"].ToString();

                //Caractéristiques complémentaires
                TextBoxPiecesMin.Text = ligne["nombre_de_pieces_min"].ToString();
                TextBoxPiecesMax.Text = ligne["nombre_de_pieces_max"].ToString();
                TextBoxChambresMin.Text = ligne["nombre_de_chambres_min"].ToString();
                TextBoxChambresMax.Text = ligne["nombre_de_chambres_max"].ToString();
                TextBoxSurfaceHabitableMin.Text = ligne["surface_habitable_min"].ToString();
                TextBoxSurfaceHabitableMax.Text = ligne["surface_habitable_max"].ToString();
                TextBoxSurfaceSejourMin.Text = ligne["surface_sejour_min"].ToString();
                TextBoxSurfaceSejourMax.Text = ligne["surface_sejour_max"].ToString();
                TextBoxFacade.Text = ligne["facade"].ToString();
                TextBoxProfondeur.Text = ligne["profondeur"].ToString();
                TextBoxSurfaceTerrainMin.Text = ligne["surface_terrain_min"].ToString();
                TextBoxSurfaceTerrainMax.Text = ligne["surface_terrain_max"].ToString();
                if ((string)ligne["ascenseur"] == "OUI")
                    CheckBoxAscenseur.Checked = true;
                if ((string)ligne["sous-sol"] == "OUI")
                    CheckBoxSousSol.Checked = true;
                if ((string)ligne["parking/box"] == "OUI")
                    CheckBoxParking.Checked = true;
                TextBoxTexteComplementaire.Text = ligne["texte_complementaire"].ToString();

                //acquereur.Cible = ucAjoutAcquereur.listeVilleRecherche.createString();
            }
            #endregion
            }
       } 
    }
    
    private Boolean checkField(Acquereur acquereur)
    {
        #region attributs

        Regex regEmail = new Regex(@"^([\w\-.]+)@([a-zA-Z0-9\-.]+)$");
        Regex numReg = new Regex("^[0-9]+(,[0-9]+)?$");
        Regex alphaNumReg = new Regex("^[-0-9 a-zA-Zéèçàâù . , ' \\r \\n ' \" ?  ]+$|^()+$");
        Regex alphaReg = new Regex("^[-a-zA-Zéèçàâù ]+$");
        Regex regexVilleTestDep = new Regex("^([0-9]{2} )*([0-9]{2})$");
        Regex regexVilleExtractDep = new Regex("([0-9]{2})");
        Regex regexVilleTestCP = new Regex("^([0-9]{5} )*([0-9]{5})$");
        Regex regexVilleExtractCP = new Regex("[0-9]{5}");
        Regex regexVilleVille = new Regex("(\"[ ]*([A-zÀ-ÿ']+[ ]*)*\")|[A-zÀ-ÿ']*");

        //Général
        Boolean boolCivilite = true;
        Boolean boolNom = false;
        Boolean boolPrenom = false;
        Boolean boolAdresse = false;
        Boolean boolVille = false;
        Boolean boolCodePostal = false;
        Boolean boolPays = false;
        Boolean boolTel = false;
        Boolean boolPortable = false;
        Boolean boolMail = false;
        Boolean boolTypeAcq = false;

        //Caractéristiques principales
        Boolean boolEtatAvancement = false;
        Boolean boolPrixMin = false;
        Boolean boolPrixMax = false;
        Boolean boolSurfaceTerrainMin = false;
        Boolean boolSurfaceTerrainMax = false;

        //Caractéristiques complémentaires
        Boolean boolNombrePiecesMin = false;
        Boolean boolNombrePiecesMax = false;
        Boolean boolNombreChambresMin = false;
        Boolean boolNombreChambresMax = false;
        Boolean boolSurfaceHabitableMin = false;
        Boolean boolSurfaceHabitableMax = false;
        Boolean boolSurfaceSejourMin = false;
        Boolean boolSurfaceSejourMax = false;
        Boolean boolFacade = false;
        Boolean boolProfondeur = false;
        Boolean boolTexteComplementaire = false;
        
        #endregion

        #region Bool à vrai si Regex vérifiée
        // Permet de verifier si tous les champs respectent les regex
        // Met les booléens à vrai si les regex sont respectées

        //Général
        boolNom = TextBoxNom.Text.Trim() != "" && alphaReg.IsMatch(TextBoxNom.Text.Trim());
        boolPrenom= TextBoxPrenom.Text.Trim() == "" || alphaReg.IsMatch(TextBoxPrenom.Text.Trim());
        boolAdresse = TextBoxAdresse.Text.Trim() == "" || alphaNumReg.IsMatch(TextBoxAdresse.Text.Trim());
        boolVille = TextBoxVille.Text.Trim() == "" || alphaReg.IsMatch(TextBoxVille.Text.Trim());
        boolCodePostal = TextBoxCodePostal.Text.Trim() == "" || numReg.IsMatch(TextBoxCodePostal.Text.Trim());
        boolPays = true; /*TextBoxPays.Text.Trim() == "" || alphaReg.IsMatch(TextBoxPays.Text.Trim());*/
        boolTel = TextBoxTel.Text.Trim() != "" && alphaNumReg.IsMatch(TextBoxTel.Text.Trim());
        boolPortable = TextBoxPortable.Text.Trim() == "" || alphaNumReg.IsMatch(TextBoxPortable.Text.Trim());
        boolMail = TextBoxMail.Text.Trim() == "" || regEmail.IsMatch(TextBoxMail.Text.Trim());
        boolTypeAcq = alphaReg.IsMatch(DropDownListTypeAcq.SelectedValue);

        //Caractéristiques principales
        boolEtatAvancement = alphaReg.IsMatch(DropDownListEtatAvancement.SelectedValue);
        boolPrixMin = TextBoxPrixMin.Text.Trim() != "" && numReg.IsMatch(TextBoxPrixMin.Text.Trim());
        boolPrixMax = TextBoxPrixMax.Text.Trim() != "" && numReg.IsMatch(TextBoxPrixMax.Text.Trim());
        boolSurfaceTerrainMin = TextBoxSurfaceTerrainMin.Text.Trim() == "" || numReg.IsMatch(TextBoxSurfaceTerrainMin.Text.Trim());
        boolSurfaceTerrainMax = TextBoxSurfaceTerrainMax.Text.Trim() == "" || numReg.IsMatch(TextBoxSurfaceTerrainMax.Text.Trim());

        //Caractèristiques complémentaires
        boolNombrePiecesMin = TextBoxPiecesMin.Text.Trim() == "" || numReg.IsMatch(TextBoxPiecesMin.Text.Trim());
        boolNombrePiecesMax = TextBoxPiecesMax.Text.Trim() == "" || numReg.IsMatch(TextBoxPiecesMax.Text.Trim());
        boolNombreChambresMin = TextBoxChambresMin.Text.Trim() == "" || numReg.IsMatch(TextBoxChambresMin.Text.Trim());
        boolNombreChambresMax = TextBoxChambresMax.Text.Trim() == "" || numReg.IsMatch(TextBoxChambresMax.Text.Trim());
        boolSurfaceHabitableMin = TextBoxSurfaceHabitableMin.Text.Trim() == "" || numReg.IsMatch(TextBoxSurfaceHabitableMin.Text.Trim());
        boolSurfaceHabitableMax = TextBoxSurfaceHabitableMax.Text.Trim() == "" || numReg.IsMatch(TextBoxSurfaceHabitableMax.Text.Trim());
        boolSurfaceSejourMin = TextBoxSurfaceSejourMin.Text.Trim() == "" || numReg.IsMatch(TextBoxSurfaceSejourMin.Text.Trim());
        boolSurfaceSejourMax = TextBoxSurfaceSejourMax.Text.Trim() == "" || numReg.IsMatch(TextBoxSurfaceSejourMax.Text.Trim());
        boolFacade = TextBoxFacade.Text.Trim() == "" || alphaNumReg.IsMatch(TextBoxFacade.Text.Trim());
        boolProfondeur = TextBoxProfondeur.Text.Trim() == "" || alphaNumReg.IsMatch(TextBoxProfondeur.Text.Trim());
        boolTexteComplementaire = TextBoxTexteComplementaire.Text.Trim() == "" || alphaNumReg.IsMatch(TextBoxTexteComplementaire.Text.Trim());

        #endregion

        #region try...catch
        //Général
        try
        {
            if (RadioButtonMr.Checked) acquereur.CIVILITE = "Mr";
            if (RadioButtonMme.Checked) acquereur.CIVILITE = "Mme";
            if (RadioButtonMlle.Checked) acquereur.CIVILITE = "Mlle";
        }
        catch { acquereur.CIVILITE = "erreur"; }

        try { acquereur.NOM = TextBoxNom.Text.Trim(); }
        catch { acquereur.NOM = ""; }

        try { acquereur.Categorie = DDLCategorieAcquereur.SelectedValue; }
        catch { acquereur.Categorie = "large"; }

        try { acquereur.PRENOM = TextBoxPrenom.Text.Trim(); }
        catch { acquereur.PRENOM = ""; }

        try { acquereur.ADRESSE = TextBoxAdresse.Text.Trim().Replace("'","''"); }
        catch { acquereur.ADRESSE = ""; }

        try { acquereur.VILLE = TextBoxVille.Text.Trim(); }
        catch { acquereur.VILLE = ""; }
        
        try { acquereur.CODE_POSTAL = TextBoxCodePostal.Text.Trim(); }
        catch { acquereur.CODE_POSTAL = ""; }

        try { acquereur.PAYS = DropDownListPays.Text.Trim(); }
        catch { acquereur.PAYS = ""; }

        try { acquereur.TEL = TextBoxTel.Text.Trim(); }
        catch { acquereur.TEL = ""; }

        try { acquereur.PORTABLE = TextBoxPortable.Text.Trim(); }
        catch { acquereur.PORTABLE = ""; }

        try { acquereur.MAIL = TextBoxMail.Text.Trim(); }
        catch { acquereur.MAIL = ""; }
        
        try { acquereur.TYPE_ACQUEREUR = DropDownListTypeAcq.SelectedValue; }
        catch { acquereur.TYPE_ACQUEREUR = ""; }

       //Caractéristiques principales

        if (CheckBoxAppartement.Checked) { acquereur.APPARTEMENT = "True"; }

        if (CheckBoxMaison.Checked) { acquereur.MAISON = "True"; }

        if (CheckBoxTerrain.Checked) { acquereur.TERRAIN = "True"; }

        if (CheckBoxAutre.Checked) { acquereur.AUTRE = "True"; }

        if (CheckBoxVendeur.Checked) { acquereur.VENDEUR = "True"; }

        try { acquereur.ETAT_AVANCEMENT = DropDownListEtatAvancement.SelectedValue; }
        catch { acquereur.ETAT_AVANCEMENT = ""; }

        try { acquereur.PRIX_MIN = int.Parse(TextBoxPrixMin.Text.Replace(" ","")); }
        catch { acquereur.PRIX_MIN = 0; }

        try { acquereur.PRIX_MAX = int.Parse(TextBoxPrixMax.Text.Replace(" ","")); }
        catch { acquereur.PRIX_MAX = 0; }

        try { acquereur.SURFACE_TERRAIN_MIN = int.Parse(TextBoxSurfaceTerrainMin.Text.Replace(" ","")); }
        catch { acquereur.SURFACE_TERRAIN_MIN = 0; }

        try { acquereur.SURFACE_TERRAIN_MAX = int.Parse(TextBoxSurfaceTerrainMax.Text.Replace(" ","")); }
        catch { acquereur.SURFACE_TERRAIN_MAX = 0; }

        try { acquereur.Cible = ucAjoutAcquereur.listeVilleRecherche.createString(); }
        catch { acquereur.Cible = ""; }

        //Caractéristiques complémentaires

        try { acquereur.NOMBRE_PIECES_MIN = int.Parse(TextBoxPiecesMin.Text.Replace(" ", "")); }
        catch { acquereur.NOMBRE_PIECES_MIN = 0; }

        try { acquereur.NOMBRE_PIECES_MAX = int.Parse(TextBoxPiecesMax.Text.Replace(" ", "")); }
        catch { acquereur.NOMBRE_PIECES_MAX = 0; }

        try { acquereur.NOMBRE_CHAMBRES_MIN = int.Parse(TextBoxChambresMin.Text.Replace(" ", "")); }
        catch { acquereur.NOMBRE_CHAMBRES_MIN = 0; }

        try { acquereur.NOMBRE_CHAMBRES_MAX = int.Parse(TextBoxChambresMax.Text.Replace(" ", "")); }
        catch { acquereur.NOMBRE_CHAMBRES_MAX = 0; }

        try { acquereur.SURFACE_HABITABLE_MIN = int.Parse(TextBoxSurfaceHabitableMin.Text.Replace(" ", "")); }
        catch { acquereur.SURFACE_HABITABLE_MIN = 0; }

        try { acquereur.SURFACE_HABITABLE_MAX = int.Parse(TextBoxSurfaceHabitableMax.Text.Replace(" ", "")); }
        catch { acquereur.SURFACE_HABITABLE_MAX = 0; }

        try { acquereur.SURFACE_SEJOUR_MIN = int.Parse(TextBoxSurfaceSejourMin.Text.Replace(" ", "")); }
        catch { acquereur.SURFACE_SEJOUR_MIN = 0; }

        try { acquereur.SURFACE_SEJOUR_MAX = int.Parse(TextBoxSurfaceSejourMax.Text.Replace(" ", "")); }
        catch { acquereur.SURFACE_SEJOUR_MAX = 0; }

        try { acquereur.FACADE = int.Parse(TextBoxFacade.Text.Replace(" ", "")); }
        catch { acquereur.FACADE = 0; }

        try { acquereur.PROFONDEUR = int.Parse(TextBoxProfondeur.Text.Replace(" ", "")); }
        catch { acquereur.PROFONDEUR = 0; }

        if ( CheckBoxAscenseur.Checked) { acquereur.ASCENSEUR = "OUI"; }

        if ( CheckBoxSousSol.Checked) { acquereur.SOUS_SOL = "OUI"; }

        if (CheckBoxParking.Checked) { acquereur.PARKING = "OUI"; }

        try { acquereur.TEXTE_COMPLEMENTAIRE = TextBoxTexteComplementaire.Text.Trim().Replace("'","''"); }
        catch { acquereur.TEXTE_COMPLEMENTAIRE = ""; }
        #endregion

        // Si tous les booléens sont à vrai, on accepte le formulaire
        #region Vérification si tous les bool sont à vrai

        if (
            //Général
            boolCivilite &&
            boolNom &&
            boolPrenom &&
            boolAdresse &&
            boolVille &&
            boolCodePostal &&
            boolPays &&
            boolTel &&
            boolPortable &&
            boolMail &&
            boolTypeAcq &&
            
            //Caractéristiques principales
            boolEtatAvancement &&
            boolPrixMin &&
            boolPrixMax &&
            boolSurfaceTerrainMin &&
            boolSurfaceTerrainMax &&

            //Caractèristiques complémentaires
            boolNombrePiecesMin &&
            boolNombrePiecesMax &&
            boolNombreChambresMin &&
            boolNombreChambresMax &&
            boolSurfaceHabitableMin &&
            boolSurfaceHabitableMax &&
            boolSurfaceSejourMin &&
            boolSurfaceSejourMax &&
            boolFacade &&
            boolProfondeur &&
            boolTexteComplementaire

        ) return true;

        #endregion

        // On affiche les champs où les regex ne sont pas vérifiés
        #region message d'erreur

         
        {
            LabelErrorLogin.Visible = true;

            LabelErrorLogin.Text = "Erreur de saisie pour les champs suivants : <br />";

            //Général
            if (boolCivilite == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Civilité <br />";
            if (boolNom == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Nom <br />";
            if (boolPrenom == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Prenom <br />";
            if (boolAdresse == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Adresse <br />";
            if (boolVille == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Ville <br />";
            if (boolCodePostal == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Code Postal <br />";
            if (boolPays == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Pays <br />";
            if (boolTel == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Tel <br />";
            if (boolPortable == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Portable <br />";
            if (boolMail == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Mail <br />";
            if (boolTypeAcq == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Type d'acquereur <br />";
            
            //Caractéristiques principales
            if (boolEtatAvancement == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Etat Avancement <br />";
            if (boolPrixMin == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Prix min <br />";
            if (boolPrixMax == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Prix max <br />";
            if (boolSurfaceTerrainMin == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Surface terrain min <br />";
            if (boolSurfaceTerrainMax == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Surface terrain max <br />";

            //Caractéristiques complémentaires
            if (boolNombrePiecesMin == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Nombre pièces min <br />";
            if (boolNombrePiecesMax == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Nombre pièces max <br />";
            if (boolNombreChambresMin == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Nombre chambres min <br />";
            if (boolNombreChambresMax == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Nombre chambres max <br />";
            if (boolSurfaceHabitableMin == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Surface habitable min <br />";
            if (boolSurfaceHabitableMax == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Surface habitable max <br />";
            if (boolSurfaceSejourMin == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Surface séjour min <br />";
            if (boolSurfaceSejourMax == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Surface séjour max <br />";
            if (boolFacade == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Façade <br />";
            if (boolProfondeur == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Profondeur <br />";
            if (boolTexteComplementaire == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Texte Complémentaire<br />";

            return false;
        }
        #endregion
    }

    protected void ButtonAddAcquereur_Click(object sender, EventArgs e)
    {
        Acquereur acquereur = new Acquereur();
        if (checkField(acquereur))
        {
            Membre member = new Membre();
            member = (Membre)Session["Membre"];
            AcquereurDAO.addAcquereur(acquereur, member.IDCLIENT, member.NOM);
			if(Request.QueryString["refBien"] == null)
				Response.Redirect("./liste_acquereur.aspx");
			else
				Response.Redirect("./rapprochementbien.aspx?idAcq=" + Request.QueryString["refBien"]);
        }

    }

    protected void ButtonModifierAcquereur_Click(object sender, EventArgs e)
    {
        String Id_Acq;
        Id_Acq = Request.QueryString["reference"];

        // Ajoute le bien à la table
        Acquereur acquereur = new Acquereur();
        if (checkField(acquereur))
        {
            AcquereurDAO.updateAcquereur(acquereur, Id_Acq);
			if(Request.QueryString["refBien"] != null)
				Response.Redirect("./rapprochementbien.aspx?idAcq=" + Request.QueryString["refBien"]);
			else if(Request.QueryString["redirect"] == "rapprochement")
				Response.Redirect("./rapprochement.aspx?idAcq=" + Request.QueryString["reference"]);
			else
				Response.Redirect("./liste_acquereur.aspx");
        }
    }

}