using System;
using System.Data;
using System.Data.Odbc;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;

public partial class pages_fichedetail1 : System.Web.UI.Page
{
    protected Membre member = null;
    string reference = null;
    protected Bien b;
    protected String mail_nego="";
    Connexion c;

    string _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {

        //AlerteMailDAO.addAlerteMailBien("aa","aaaaaa");
        if ((Membre)Session["Membre"] != null) member = (Membre)Session["Membre"];

        if ((Request.QueryString["ref"] != null) && (Request.QueryString["ref"] != ""))
        {
            reference = Request.QueryString["ref"];
            Session["ref"] = Request.Params["ref"];
            ficheDetail_Panel.Visible = true;
        }
        else Response.Redirect("recherche.aspx");

        String page = "-1";
        if (Request.Params["page"] != null) page = Request.Params["page"].ToString();


        b = BienDAO.getBien(reference);

        int nbJour = 30; //les X derniers jours pris en compte pour le compteur de visite
        update_counter(nbJour);


        //récupération de la racine du site web pour la vérificaton de la présence des images :
        c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();
        System.Data.DataSet ds = c.exeRequette("Select * from Environnement");
        c.Close();
        String racine_site = (String)ds.Tables[0].Rows[0]["Chemin_racine_site"];

        String path = b.REFERENCE.ToString();
        string relativePath = "../images/";
        string absolutePath = "~/images/";
        String JpgA = relativePath + path + "A.JPG";
        String JpgB = relativePath + path + "B.JPG";
        String JpgC = relativePath + path + "C.JPG";
        String JpgD = relativePath + path + "D.JPG";
        String JpgE = relativePath + path + "E.JPG";
        String JpgF = relativePath + path + "F.JPG";
        String JpgG = relativePath + path + "G.JPG";
        String JpgH = relativePath + path + "H.JPG";
        
        if (b.REFERENCE.ToString().Length > 0)
        {
            if (b.REFERENCE.ToString().Substring(0, 1) == "V") Session["Transaction"] = "achat";
            else Session["Transaction"] = "location";
        }
        else Session["Transaction"] = "";

        tabpartage.Text = Request.Url.ToString();


        //Navigation entre les annonces

        if (Session["tabref"] !=null)
        {
            if (!((Request.Params["orig"] != null) && (Request.Params["orig"].ToString() == "nego")))
            {
                ArrayList al = Session["tabref"] as ArrayList;
                int indexOfRef = al.IndexOf(reference);
                LBLNav.Text = "";
                if (indexOfRef > 0) LBLNav.Text += "<a href=\"fichedetail1.aspx?ref=" + al[indexOfRef - 1] + "&page=" + page + "#bas\">    << </a>";
                LBLNav.Text += "Annonce " + (indexOfRef + 1) + " sur " + al.Count.ToString();
                if (indexOfRef < al.Count - 1) LBLNav.Text += "<a href=\"fichedetail1.aspx?ref=" + al[indexOfRef + 1] + "&page=" + page + "#bas\"> >></a>";

                LBLNav2.Text = LBLNav.Text;
            }
        }


        //TITRE
        LBLTitre.Text = "";

        if (b.CATEGORIE != "") LBLTitre.Text += b.CATEGORIE + " ";
        else
        {
          switch (b.TYPE_BIEN)
            {
                case "A": LBLTitre.Text += "Appartement "; break;
                case "M": LBLTitre.Text += "Maison "; break;
                case "L": LBLTitre.Text += "Local "; break;
                case "T": LBLTitre.Text += "Terrain "; break;
                case "I": LBLTitre.Text += "Immeuble "; break;
                default: LBLTitre.Text += "Bien "; break;
            }
        }

        LBLTitre.Text += " à "+ b.VILLE_BIEN+" ("+b.CODE_POSTAL_BIEN+")";
        LBLTitre.Text = LBLTitre.Text.ToUpper();



        //On recupere le loyer et la surface carrez en (très) bourrin #I<3AncienStagiaires
        //String requette2 = "SELECT * FROM Biens WHERE (((Biens.ref)='" + b.REFERENCE.ToString() + "'));";
        String requette2 = "SELECT * FROM Biens, optionsBiens WHERE Biens.ref=optionsBiens.refOptions AND (((Biens.ref)='" + b.REFERENCE.ToString() + "'));";
        System.Data.DataSet ds1 = null;
        Connexion c1 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c1.Open();
        ds1 = c1.exeRequette(requette2);
        c1.Close();
        System.Data.DataRowCollection dr1 = ds1.Tables[0].Rows;

        //PANNEAU ADMIN
        string refer = b.REFERENCE;

        if (member != null && (member.STATUT == "ultranego" || (member.STATUT == "nego" && b.NEGOCIATEUR == member.PRENOM + " " + member.NOM)))
        {
            
            Admin_Panel.Visible = true;

            if (refer.Contains("L")) LBLModifBien.Text = "<a href=\"./modifier_nego_loc.aspx?reference=" + refer + "\"style='color:Gray'><img src='../img_site/flat_round/modifier.png' style='padding-left:15px' border='0' width='17px' > <strong>Modifier le bien</strong></a><br /><br />";
            if (refer.Contains("V")) LBLModifBien.Text = "<a href=\"./modifier_nego.aspx?reference=" + refer + "\"style='color:Gray'><img src='../img_site/flat_round/modifier.png' style='padding-left:15px' border='0' width='17px' ><strong> Modifier le bien</strong></a><br /><br />";

            LBL_Envois.Text = "";

            LBL_Envois.Text += get_Envois_sites(dr1);

            lbl_dates.Text = Get_dates();
            
        }

        //INFOS IMPORTANTES

        //Prix
        if (refer.Contains("V")) LBLPrix.Text = "<strong>" + espaceNombre(b.PRIX_VENTE.ToString()) + " &#8364;</strong>";
        if (refer.Contains("L"))
        {
            String Loyer = dr1[0]["loyer_cc"].ToString();
            LBLPrix.Text = "<strong>" + espaceNombre(Loyer) + "&#8364;</strong>";
        }

        LBLSurface.Text = "<strong>" + espaceNombre(b.S_HABITABLE.ToString()) + " m² </strong>";
        if (b.TYPE_BIEN == "T") LBLSurface.Text = "<strong>" + espaceNombre(b.S_TERRAIN.ToString()) + "</strong> m² ";
        else if (b.S_HABITABLE == 0)
            {
                String S_CARREZ = dr1[0]["surface carrez"].ToString();
                LBLSurface.Text = "<strong>" + espaceNombre(S_CARREZ) + "</strong> m² ";
            }


        //Zone surface/Pieces
        LBLPieces.Text="";
        if (b.NBRE_PIECE!=0) LBLPieces.Text += "<td style='width:50%;border-bottom: 1px solid lightgrey ; border-left: 1px solid lightgrey;'>"
                                                                        + "<center><div style='font-size: 25px;text-align:left;margin-left:15px'><strong>" + b.NBRE_PIECE + "</strong> pièce(s) </div> "
                                                                        + "</center></td>";
        else LBLPieces.Text += "<td style='width:30%;border-bottom: 1px solid lightgrey ;'></td>";


        //Prix par metre carre
        LBLPrixMetre.Text = "";
        if (refer.Contains("V") && b.TYPE_BIEN != "T")
        {
            LBLPrixMetre.Text += "<tr><td style='border-bottom: 1px solid lightgrey ;' colspan='2'><div style='font-size: 25px;text-align:center;margin-left:15px'><strong>";
            if (b.PRIX_VENTE < b.S_HABITABLE) LBLPrixMetre.Text += "<br/>< 1 &#8364;/m²<br/>";
            else
            {
                if (b.S_HABITABLE != 0) LBLPrixMetre.Text += (b.PRIX_VENTE / b.S_HABITABLE).ToString() + " &#8364;/m²";
                else if (b.S_CARREZ != 0) LBLPrixMetre.Text += (b.PRIX_VENTE / b.S_CARREZ).ToString() + " &#8364;/m²";
            }
            LBLPrixMetre.Text += "</td></tr>";

        }

        //Icones
        String texte_internet = b.TEXTE_INTERNET.ToLower();
        LBLIcone.Text = "";
        LBLIcone.Text += "<tr><td colspan='2'><center>";

        List<String> icones = setIcones(texte_internet, dr1[0]["Mer"].ToString(), dr1[0]["Montagne"].ToString());
        int k = 0; //On ne veux pas trop d'icones sur une même ligne (sinon pb avec le zoom)
        foreach (String s in icones)
        {
            LBLIcone.Text += "<div class='new_span' style='display:inline-block'><div class='zoom_simple' style='display:inline-block'><img height=32px src='../img_site/flat_round/" + s + ".png' alt='" + s + "'/></div>"
                       + "<span style='margin-left:-60px;margin-top:45px;'>" + get_icon_text(s) + "</span> </div>";
            k++;
            if (k % 7 == 0) LBLIcone.Text += "<br/>";
        }
        if (icones.Count == 0) LBLIcone.Text = "";
        LBLIcone.Text += "</center></td></tr>";

        //PANNEAU LOCALISATION
        string localisation = b.VILLE_BIEN;
        adresse.Value = localisation;


        //PANNEAU NEGO
        LBLNego.Text = "";
        if (b.NEGOCIATEUR != "")
        {
            BtnSiteNego.Visible = true;
            //Si l'annonce a été envoyée par un nego, on récupère dans la table Clients les coordonnées de ce nego.   
            String PrenomNomNego = b.NEGOCIATEUR;

            String requette = "SELECT id_client, tel_client, adresse_client, ville_client FROM Clients WHERE `idclient`=" + b.IDCLIENT;

            Connexion c2 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c2.Open();
            System.Data.DataSet ds2 = c2.exeRequette(requette);
            c2.Close();
            c2 = null;
            System.Data.DataRowCollection dr2 = ds2.Tables[0].Rows;


            LBLNego.Text += CheckPhotoProfil(b.IDCLIENT) + "<br/>";
            foreach (System.Data.DataRow ligne in dr2)
            {
                mail_nego = ligne["id_client"].ToString();

                LBLNego.Text += "<strong>" + PrenomNomNego + "</strong><br/>"
                + "Tel: " + ligne["tel_client"].ToString() + "<br/>";

                if(mail_nego.Length>24) LBLNego.Text += "<a href='mailto:"+mail_nego+"' > " + mail_nego.Substring(0,20)+ "... </a><br/><br/>";
                else LBLNego.Text += "<a href='mailto:" + mail_nego + "' > " + mail_nego + "</a><br/><br/>";
            }

        }
        else if (b.NOM_AGENCE != "")
        {
            LBLNego.Text += "<STRONG>Reférence : </STRONG>" + b.REFERENCE + " - tel: " + b.TEL_AGENCE + "<br />"
             + "<STRONG>Contact : </STRONG>"
             + b.NOM_AGENCE + " - " + b.ADRESSE_AGENCE
            + " - " + b.CODE_POSTALE_AGENCE + "  " + b.VILLE_AGENCE;
        }


        //MENU BOUTONS
        LBLMenuBoutons.Text = "<br/><a href=\"./contact3.aspx?ref_bien="+ refer +"&appelcontact='menu'\"style='color:Gray'><img src='../img_site/flat_round/phone.png' style='margin-bottom:-10px;margin-left:5px;margin-right:5px' width='24px'><strong> Contacter l'agence </strong></a><br /><br />";
        //LBLMenuBoutons.Text += "<a href='#' style='color:Gray'><img src='../img_site/flat_round/alerte.png' style='margin-bottom:-10px;margin-left:5px;margin-right:5px' width='24px'><strong> Alerte sur ce bien </strong></a><br /><br />";
                            
        
        LBLMenuBoutons.Text += "<a href=\"javascript:popUp('sendToFriend.aspx?ref=" + refer + "')\"style='color:Gray'><img src='../img_site/flat_round/courrier.png' style='margin-bottom:-10px;margin-left:5px;margin-right:5px;margin-top:5px' width='24px'><strong> Envoyer à un ami </strong></a><br /><br />";
        LBLMenuBoutons.Text += "<a href=\"./ajoutSelection.aspx?ref=" + refer + "\"style='color:Gray'><img src='../img_site/flat_round/ajouter.png' style='margin-bottom:-10px;margin-left:5px;margin-right:5px;margin-top:5px' width='24px'><strong> Ajouter à ma selection</strong></a><br /><br />";


        LBLMenuBoutons.Text += "<span  id='bouton_texte' style='color:Gray; cursor:pointer ' onclick=\"javascript:afficher_cacher('texte');\" onmouseover=><img src='../img_site/flat_round/partager.png' style='margin-bottom:-10px;margin-left:5px;margin-right:5px;margin-top:5px' width='24px'><strong> Partager lien</strong></span>";



        //PHOTOS
        LBLPhotos.Text = "";

        string sourceJpgExcl = "../img_site/bandeau_exclusivite.png";
        string sourceJpgSemExcl = "../img_site/bandeau_semiExclusif.png";
        string sourceJpgNouveaute = "../img_site/bandeau_nouveaute.png";

        int nbJourNv = -15;
        DateTime today = DateTime.Now;

        DateTime todayMoinsJourNv = today.AddDays(nbJourNv);

        switch (b.TYPE_MANDAT)
        {
            case "Exclusif": LBLPhotos.Text += "<img id=\"bandeau2\" alt=\"photo\" src= \"" + sourceJpgExcl + "\" width=\"240\" height=\"240\" />"; break;
            case "SemiExclusif": LBLPhotos.Text += "<img id=\"bandeau2\" alt=\"photo\" src= \"" + sourceJpgSemExcl + "\" />"; break;
            default : if (b.DATE_MODIFICATION >= todayMoinsJourNv) LBLPhotos.Text += "<img id=\"bandeau2\" alt=\"photo\" src= \"" + sourceJpgNouveaute + "\" width=\"240\" height=\"240\" />";
            break;
        }

        if (!testFile(absolutePath + JpgA)) JpgA = "../img_site/images_par_defaut/" + b.TYPE_BIEN + ".jpg";
        JpgA = relativePath + JpgA;
        LBLPhotos.Text += "<img id='grosseImage' style='vertical-align:top' src=" + JpgA + " />";

        LBLPhotos.Text += "<br/><br/>";
        LBLPhotos.Text +="<span id='videoAnnonce' style='margin-left:100px;'>"+b.URLVIDEO+"</span>";
        
        LBLPhotos.Text += "<div class='fichePhotoDroite'><table><tr>";
        if (testFile(absolutePath + JpgA)) LBLPhotos.Text += "<td><img alt=\"Cliquez pour agrandir\" src=" + relativePath + JpgA + " onclick=\"metGrosseImage(this.src)\" style='width:100px;height:80px;margin-left:-5px' /></td>";
        if (testFile(absolutePath + JpgB)) LBLPhotos.Text += "<td><img alt=\"Cliquez pour agrandir\" src=" + relativePath + JpgB + " onclick=\"metGrosseImage(this.src)\" style='width:100px;height:80px;margin-left:15px' /></td>";
        if (testFile(absolutePath + JpgC)) LBLPhotos.Text += "<td><img alt=\"Cliquez pour agrandir\" src=" + relativePath + JpgC + " onclick=\"metGrosseImage(this.src)\" style='width:100px;height:80px;margin-left:15px' /></td>";
        if (testFile(absolutePath + JpgD)) LBLPhotos.Text += "<td><img alt=\"Cliquez pour agrandir\" src=" + relativePath + JpgD + " onclick=\"metGrosseImage(this.src)\" style='width:100px;height:80px;margin-left:15px' /></td>";
        LBLPhotos.Text += "</tr><tr>";
        if (testFile(absolutePath + JpgE)) LBLPhotos.Text += "<td><img alt=\"Cliquez pour agrandir\" src=" + relativePath + JpgE + " onclick=\"metGrosseImage(this.src)\" style='width:100px;height:80px;margin-left:-5px' /></td>";
        if (testFile(absolutePath + JpgF)) LBLPhotos.Text += "<td><img alt=\"Cliquez pour agrandir\" src=" + relativePath + JpgF + " onclick=\"metGrosseImage(this.src)\" style='width:100px;height:80px;margin-left:15px' /></td>";
        if (testFile(absolutePath + JpgG)) LBLPhotos.Text += "<td><img alt=\"Cliquez pour agrandir\" src=" + relativePath + JpgG + " onclick=\"metGrosseImage(this.src)\" style='width:100px;height:80px;margin-left:15px' /></td>";
        if (testFile(absolutePath + JpgH)) LBLPhotos.Text += "<td><img alt=\"Cliquez pour agrandir\" src=" + relativePath + JpgH + " onclick=\"metGrosseImage(this.src)\" style='width:100px;height:80px;margin-left:15px' /></td>";
        LBLPhotos.Text += "</tr></table></div><br/>";


        //TEXTE INTERNET
        if (b.TEXTE_INTERNET == "") Texte_Panel.Visible = false;
        LBLTexteInternet.Text = "<strong>DESCRIPTION DU BIEN: </strong><br/><br/>";
        LBLTexteInternet.Text += nl2br(b.TEXTE_INTERNET);

        LBLTexteInternet.Text += "<br/><br/>";


        //INFOS COMPLEMENTAIRES

        LBLInfoCompl.Text = "";
        string imgSource;
        if (b.COUP_DE_COEUR && b.PRESTIGE)
        {
            imgSource = "../img_site/band_CdC_Lux/Trigl_cdcPrestige.png";
            LBLInfoCompl.Text += "<img id=\"imgcdcPrestige_fichedetail\" src=\"" + imgSource + "\" alt=\"Coup de coeur et Prestige\"/>";
        }
        else if (b.COUP_DE_COEUR)
        {
            imgSource = "../img_site/band_CdC_Lux/Trigl_coupDeCoeur.png";
            LBLInfoCompl.Text +="<img id=\"imgcdcPrestige_fichedetail\" src=\"" + imgSource + "\" alt=\"Coup de coeur\"/>";
        }
        else if (b.PRESTIGE)
        {
            imgSource = "../img_site/band_CdC_Lux/Trigl_prestige.png";
            LBLInfoCompl.Text += "<img id=\"imgcdcPrestige_fichedetail\" src=\"" + imgSource + "\" alt=\"Prestige\"/>";
        }

            LBLInfoCompl.Text +=  "<table class='fdetail1' style='font-size: 10pt; color: black; width:92%'>"
             + "<tr class='fdetail2' style='vertical-align:top'><td>";
         if (b.TYPE_BIEN == "M") LBLInfoCompl.Text +="<strong>La maison</strong> <br />";
         if (b.TYPE_BIEN == "A") LBLInfoCompl.Text +="<strong>L'appartement</strong> <br />";
         if (b.S_HABITABLE != 0) LBLInfoCompl.Text +="Surface habitable : " + b.S_HABITABLE.ToString() + " m²<br />";
         if (b.S_TERRAIN != 0) LBLInfoCompl.Text +="Surface terrain : " + b.S_TERRAIN + " m²<br />";
         if (b.S_SEJOUR != 0) LBLInfoCompl.Text +="Surface séjour : "+b.S_SEJOUR+" m²<br />";
         if (b.A_CONSTRUCTION!="0" && b.A_CONSTRUCTION!="") LBLInfoCompl.Text +="Année de construction : " + b.A_CONSTRUCTION + "<br />";
         if (b.ASCENSEUR == "OUI") LBLInfoCompl.Text += "Ascenceur : oui <br />";
             LBLInfoCompl.Text += "</td><td><strong>Equipement</strong> <br />";
         if(b.T_CUISINE!="") LBLInfoCompl.Text +="Type de cuisine : " + b.T_CUISINE + "<br />";
         if(b.NBRE_SALLE_BAIN !="0" && b.NBRE_SALLE_BAIN !="") LBLInfoCompl.Text +="SDB avec baignoire : "+ b.NBRE_SALLE_BAIN+ "<br /> ";
         if(b.TYPE_CHAUFFAGE!="") LBLInfoCompl.Text +="Type de chauffage : " + b.TYPE_CHAUFFAGE + "<br />";
         if(b.NATURE_CHAUFFAGE!="") LBLInfoCompl.Text +="Nature du chaffage : "+b.NATURE_CHAUFFAGE+"<br />";
         if(b.BALCON == "OUI") LBLInfoCompl.Text +="Balcon : oui <br />";
         if (b.TERRASSE == "OUI") LBLInfoCompl.Text += "Terrasse  : oui <br />";
            LBLInfoCompl.Text += "</td><td>";
         if (b.ANCIEN_PRIX > b.PRIX_VENTE && b.ANCIEN_PRIX != 0) LBLInfoCompl.Text +="<img class=\"gifPrixEnBaisse\" src=\"../img_site/prixEnBaisse.gif\" alt=\"PRIX EN BAISSE\"/><br/>";
         if (b.NEUF) LBLInfoCompl.Text +="<img class=\"gifNeuf\" src=\"../img_site/Neuf.gif\" alt=\"PRIX EN BAISSE\"/><br/>";
         if (b.LOCALISATION != "") LBLInfoCompl.Text +="<strong>Localisation</strong>";
         if (b.LOCALISATION != "") LBLInfoCompl.Text +="Localisation du bien : " + b.LOCALISATION + "<br />" + "<br />";
         if (b.TAXE_FONCIERE != "0" || b.TAXE_HABITATION != "0" || b.CHARGES != "0") LBLInfoCompl.Text +="<strong>Autre:</strong> <br />";
         if (b.TAXE_FONCIERE!="0") LBLInfoCompl.Text +="Taxe foncière : " + b.TAXE_FONCIERE + " &#8364;<br />"; 
         if (b.TAXE_HABITATION!="0") LBLInfoCompl.Text +="Taxe d'habitation : " + b.TAXE_HABITATION + " &#8364;<br />";
         if (b.CHARGES != "0") LBLInfoCompl.Text += "Charges : " + b.CHARGES + "&#8364; <br />";
            LBLInfoCompl.Text += "</td></tr></table>";

        //CONSOMMATION

        LBLConso.Text="";
        if (b.LETTRE_CONSO == "" && b.LETTRE_ENERGIE == "") Conso_Panel.Visible=false;
        else
        {
            if (b.LETTRE_CONSO != "") LBLConso.Text += "<td><center><img src=\"../img_dpe/high_quality/dpe/dpe_" + b.LETTRE_CONSO.ToLower() + ".gif\"/HEIGHT=299 WIDTH=298></center></td>";
            if (b.LETTRE_ENERGIE != "") LBLConso.Text += "<td><center><img src=\"../img_dpe/high_quality/ges/ges_"+b.LETTRE_ENERGIE.ToLower() +".gif\"/HEIGHT=299 WIDTH=298></center></td>";
        }

    }


    protected String CheckPhotoProfil(int idClientNego)
    {

        // Récupère le chemin racine du site
        string racine_site = MapPath("~/");
        String Image = racine_site + "img_nego\\" + idClientNego + "_PHOTO.jpg";

        // On regarde si l'image en question existe
        if (System.IO.File.Exists(Image) == true)
            return "<img src='../img_nego/" + idClientNego + "_PHOTO.jpg" + "' style=' float:left;margin-left:15px;height:140px;max-width:110px' class='shadow'  />";

        else
            return "<img src='../img_site/001.png" + "' style='margin-left:15px;float:left; height:140px;width:110px' class='shadow'  />";
    }

    protected bool testFile(string file)
    {
        return (System.IO.File.Exists(MapPath(file)));
    }

    protected void VoirSiteNego(object sender, EventArgs e)
    {
        string page = "-1";
        if (Request.Params["page"] != null) page = Request.Params["page"].ToString();

        Response.Redirect("./agent.aspx?id_client=" + mail_nego+ "&orig="+b.REFERENCE+"&page="+page);
    }

    protected void VoirBiensNego(object sender, EventArgs e)
    {
        Response.Redirect("./affichagerecherche.aspx?field1=" + b.IDCLIENT);
    }

    

    protected List<String> setIcones(String texte_internet, String Mer, String Montagne)
    {
        List<String> icones = new List<String>();
        List<String> criteres;
        List<String> not_criteres;

        criteres = new List<String> { "parking", "boxe", "garage" };
        if (criteres.Any(s => texte_internet.Contains(s))) if (!icones.Contains("parking")) icones.Add("parking"); //C'est du linq.

        criteres = new List<String> { "parc " };
        if (criteres.Any(s => texte_internet.Contains(s))) if (!icones.Contains("jardin")) icones.Add("jardin");

        criteres = new List<String> { "terrasse", "balcon" };
        if (criteres.Any(s => texte_internet.Contains(s))) if (!icones.Contains("terrasse")) icones.Add("terrasse");

        criteres = new List<String> { "patio", "jardin", "paysage", "paysagé" };
        if (criteres.Any(s => texte_internet.Contains(s))) if (!icones.Contains("jardin")) icones.Add("jardin");

        criteres = new List<String> { "piscine" };
        if (criteres.Any(s => texte_internet.Contains(s))) if (!icones.Contains("piscine")) icones.Add("piscine");

        criteres = new List<String> { "handicap", "handicapé" };
        if (criteres.Any(s => texte_internet.Contains(s))) if (!icones.Contains("handicap")) icones.Add("handicap");

        criteres = new List<String> { "montagne", " ski " };
        if (criteres.Any(s => texte_internet.Contains(s))) if (!icones.Contains("montagne")) icones.Add("montagne");

        criteres = new List<String> { " mer ", "plage" };
        if (criteres.Any(s => texte_internet.Contains(s))) if (!icones.Contains("mer")) icones.Add("mer");

        criteres = new List<String> { "investissement", "investisseur", "rentable", "rapport" };
        if (criteres.Any(s => texte_internet.Contains(s))) if (!icones.Contains("invest")) icones.Add("invest");

        criteres = new List<String> { "ascenseur" };
        not_criteres = new List<String> { "sans ascenseur" };
        if (criteres.Any(s => texte_internet.Contains(s)) && !not_criteres.Any(s => texte_internet.Contains(s))) if (!icones.Contains("ascenseur")) icones.Add("ascenseur");

        criteres = new List<String> { "terrain", "hectare", "verger" };
        if (criteres.Any(s => texte_internet.Contains(s))) if (!icones.Contains("terrain")) icones.Add("terrain");


        //Mer Montagne
        if (Mer == "True") if (!icones.Contains("mer")) icones.Add("mer");
        if (Montagne == "True")  if (!icones.Contains("montagne")) icones.Add("montagne");

        return icones;

    }

    protected void BackToList(object sender, EventArgs e)
    {

            String numpage = "1";
            String page = "5";
            String ordre = Session["Ordre"].ToString();

            if (Session["NumPage"] != null) numpage = Session["NumPage"].ToString();
            if (Request.Params["page"] != null) page = Request.Params["page"].ToString();

            switch (page)
            {
                case "2": Response.Redirect("./affichagerecherche.aspx?Numpage=" + Session["NumPage"] + "&Tri=" + Session["Tri"] + "&Ordre=" + Session["Ordre"] + "&nbannonces=" + Session["annoncesPage"]); break;
                case "3": Response.Redirect("./monCompteAnnonces.aspx"); break;
                default: Response.Redirect("./recherche.aspx"); break;
            }
    }

    protected void update_counter(int nbJour)
    {
        DateTime today = DateTime.Now;
        string now = today.Month + "/" + today.Day + "/" + today.Year;

        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();
        b.VISITEFICHED = (int)c.exeRequette("SELECT Count(*) AS TotalVisite FROM (SELECT ID FROM log_visite_page_bien WHERE ref='" + reference + "' AND ficheDetaillee = true AND Time > #" + now + "# - " + nbJour + ")").Tables[0].Rows[0]["TotalVisite"];
        b.NBRESULTRECHERCHE = (int)c.exeRequette("SELECT Count(*) AS TotalVisite FROM (SELECT ID FROM log_visite_page_bien WHERE ref='" + reference + "' AND ficheDetaillee = false AND Time > #" + now + "# - " + nbJour + ")").Tables[0].Rows[0]["TotalVisite"];
        c.Close();

        if (Request.Params["ref"] != null
            && Request.Params["ref"].CompareTo("") != 0
            && (member == null || member.STATUT != "ultranego" || b.NEGOCIATEUR != member.PRENOM + " " + member.NOM)
            )
        {
            BienDAO.increaseCounterFicheDetail(reference);
        }
    }

    protected String nl2br(string s)
    {
        Regex rgx = new Regex("\r\n|\r|\n");
        return rgx.Replace(s, "<br/>");
    }

    protected String get_Envois_sites(System.Data.DataRowCollection dr1)
    {
        String Envois_sites = "";
        String freq = "";
        if (dr1[0]["date_envoi_logic"].ToString() != "")
        {
            freq = get_Freq_envoi("logicimmo");
            Envois_sites += "<strong>LogicImmo:</strong><br/> Envoyé le " + dr1[0]["date_envoi_logic"].ToString().Substring(0, 10);
            if (dr1[0]["Time_envoi_logic"].ToString() != "") Envois_sites += " " + dr1[0]["Time_envoi_logic"].ToString().Substring(11, 5);
            if (freq != "0") Envois_sites += "<br/> Publié toutes les " + freq + " heures.";
            Envois_sites += "<br/>";
        }

        if (dr1[0]["date_envoi_etreproprio"].ToString() != "")
        {
            freq = get_Freq_envoi("etreproprio");
             Envois_sites += "<strong>EtreProprio:</strong><br/> Envoyé le " + dr1[0]["date_envoi_etreproprio"].ToString().Substring(0, 16);
             if (freq != "0") Envois_sites += "<br/> Publié toutes les " + freq + " heures.";
             Envois_sites += "<br/>";
        }
        if (dr1[0]["date_envoi_annoncesjaunes"].ToString() != "")
        {
            freq = get_Freq_envoi("annoncesjaunes");
             Envois_sites += "<strong>Annonces Jaunes/A Vendre A Louer:</strong><br/> Envoyé le " + dr1[0]["date_envoi_annoncesjaunes"].ToString().Substring(0, 16);
             if (freq != "0") Envois_sites += "<br/> Publié toutes les " + freq + " heures.";
             Envois_sites += "<br/>";
        }
        if (dr1[0]["date_envoi_repimmo"].ToString() != "")
        {
            freq = get_Freq_envoi("repimmo");
             Envois_sites += "<strong>RepImmo:</strong><br/> Envoyé le " + dr1[0]["date_envoi_repimmo"].ToString().Substring(0, 16);
             if (freq != "0") Envois_sites += "<br/> Publié toutes les " + freq + " heures.";
             Envois_sites += "<br/>";
        }
        if (dr1[0]["date_envoi_seloger"].ToString() != "")
        {
            freq = get_Freq_envoi("seloger");
             Envois_sites += "<strong>SeLoger:</strong><br/> Envoyé le " + dr1[0]["date_envoi_seloger"].ToString().Substring(0, 16);
             if (freq != "0") Envois_sites += "<br/> Publié toutes les " + freq + " heures.";
             Envois_sites += "<br/>";
        }
        /*if (dr1[0]["date_envoi_essentielleimmo"].ToString() != "")
        {
            freq = "0";
             Envois_sites += "<strong>EssentielleImmo:</strong><br/> Envoyé le " + dr1[0]["date_envoi_essentielleimmo"].ToString().Substring(0, 10);
            if (freq != "0")  Envois_sites += "<br/> Publié  toutes les " + freq + " heures.";
             Envois_sites += "<br/>";
        }*/
        if (dr1[0]["date_envoi_trouv1toit"].ToString() != "")
        {
            freq = "0";
             Envois_sites += "<strong>Trouv1Toit:</strong><br/> Envoyé le " + dr1[0]["date_envoi_trouv1toit"].ToString().Substring(0, 16);
             if (freq != "0") Envois_sites += "<br/> Publié toutes les " + freq + " heures.";
             Envois_sites += "<br/>";
        }
        if (dr1[0]["date_envoi_superimmo"].ToString() != "")
        {
            freq = get_Freq_envoi("superimmo");
            Envois_sites += "<strong>SuperImmo:</strong><br/> Envoyé le " + dr1[0]["date_envoi_superimmo"].ToString().Substring(0, 16);
            if (freq != "0") Envois_sites += "<br/> Publié toutes les " + freq + " heures.";
            Envois_sites += "<br/>";
        }

        return Envois_sites;

    }

    protected String get_Freq_envoi(String Site)
    {
        String frequence = "0";

        c.Open();
        System.Data.DataSet ds = c.exeRequette("SELECT * FROM passerelle WHERE Site = '"+Site+"'");
        c.Close();
        System.Data.DataRowCollection dr = ds.Tables[0].Rows;

        if (dr[0]["Frequence"] != null) frequence = dr[0]["Frequence"].ToString();

        if (frequence == "0.5") frequence = "demi";
        if (frequence == "0.25") frequence = "quart d'";

        return frequence;
    }

    protected String  get_icon_text(String s) 
    {
        String text = s;
        if (text=="invest") text="Investissement";
        text = text.Substring(0, 1).ToUpper() + text.Substring(1, text.Length - 1);

        return text;
    }

    protected String Get_dates()
    {
        String dates = "";
        if (b.DATE_DOSSIER != "")
        {
            dates += "Créé le : " + b.DATE_DOSSIER.ToString() + "<br/>";
            if (b.DATE_MODIFICATION.ToString() != "") dates += "Derniere modif le : " + b.DATE_MODIFICATION;
        }
        else if (b.DATE_MODIFICATION.ToString() != "") dates += "Créé le : " + b.DATE_MODIFICATION;

        return dates;
    }

    // #I<3AncienStagiaires
    protected string espaceNombre(string nombre)
    {
        string prixFormat = "";
        int k = 0;
        if (nombre.Length > 3)
        {
            while ((k + 1) * 3 < nombre.Length)
            {
                prixFormat = nombre.Substring((nombre.Length - (k + 1) * 3), 3) + " " + prixFormat;
                k++;
            }
            prixFormat = nombre.Substring(0, nombre.Length - k * 3) + " " + prixFormat;
        }
        else prixFormat = nombre;

        return prixFormat;
    }


}