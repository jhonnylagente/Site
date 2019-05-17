using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.IO;

public partial class pages_agent : System.Web.UI.Page
{
    protected Membre member = null;
    protected String idClient = "";
    protected Boolean contractuel = false;
    OdbcConnection c3;
    protected String[] total = new String[6] {"", "", "", "", "", "" };
    protected double[,] totalCAF = new double[4, 7] { { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 } };
    protected double[,] ventesCAF = new double[4, 7] { { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 } };
    protected double[,] locationsCAF = new double[4, 7] { { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 } };

    string _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        String id_client = "";
        String pass_Client = "";

        if ((Membre)Session["Membre"] != null) member = (Membre)Session["Membre"];

        if (Request.QueryString["id_client"] != null) id_client = Request.QueryString["id_client"];

        //Bouton de retour
        if (Request.QueryString["orig"] != null) BtnBackToList.Text = "Retour au bien";


        //Récuperation du negociateur
        c3 = new OdbcConnection(_ConnectionString);
        OdbcDataReader reader;
        OdbcCommand commande = new OdbcCommand("SELECT * FROM Clients WHERE id_client = ? AND (statut = 'nego' OR statut = 'ultranego') ", c3);
        OdbcParameter paramID = new OdbcParameter("", DbType.String);
        paramID.Value = id_client;
        commande.Parameters.Add(paramID);
        c3.Open();
        reader = commande.ExecuteReader();

        if (reader.HasRows)
        {
            idClient = reader["idclient"].ToString();
            pass_Client = reader["pass_client"].ToString();
            site_nego_Panel.Visible = true;
            LBLerreur.Visible = false;
            String ficheBien = "";
            String image = "";


            //Remplissage de la page
            reader.Read();

            String sourceJpg = getImageProfil(idClient, reader["civilite"].ToString());
            LBLVentes.Text = "Base";
            //Nom de l'agent
            LBLNom_nego.Text = "<br/><center><div style='font-weight: bold; font-size:20px'>" + reader["civilite"].ToString() + " " + reader["nom_client"].ToString().ToUpper() + " " + reader["prenom_client"].ToString() + "<div></center>";

            //Photo de l'agent
            LBLNom_nego.Text += "<br/><img src='" + sourceJpg + "' class='bloc_photo_agent'/>";

            // Informations de l'agent
            LBLNom_nego.Text += "<div>";

            LBLNom_nego.Text += "<div style='float:left;margin-left: 50px'>Votre conseiller à " + reader["ville_client"].ToString();
            if (reader["postal_client"].ToString().Length >= 2) LBLNom_nego.Text += " (" + reader["postal_client"].ToString().Substring(0, 2) + ") ";
            LBLNom_nego.Text += "et ses environs.</div><br/><br/>";

            LBLNom_nego.Text += "<div style='float:left;margin-left: 50px'>";
            LBLNom_nego.Text += "<img src='../img_site/tel_round_dark.png' height='90px'/><br/>";
            LBLNom_nego.Text += "<img src='../img_site/mail_round_dark.png' height='50px' style='margin-left:18px'/>";
            LBLNom_nego.Text += "</div>";

            LBLNom_nego.Text += "<div style='float:left;margin-left: 40px'>";
            LBLNom_nego.Text += "<div style='float:left; margin-top:5px; margin-left:20px; font-weight: bold; color:#31536C; font-size:55px'>" + reader["tel_client"].ToString() + "</div><br/>";
            LBLNom_nego.Text += "<div align='center' style='float:right;margin-top:10px; color:darkgrey; font-size:40px'>";
            String shortmail = reader["id_client"].ToString();
            if (shortmail.Length >= 28) shortmail = shortmail.Substring(0, 23) + "[...]";
            LBLNom_nego.Text += shortmail + "</div><br/><br/>";
            LBLNom_nego.Text += "</div>";

            LBLNom_nego.Text += "</div>";


            String quote_agent;
            if (reader["quote"].ToString() == "")
                quote_agent = "<br/><br/>L'immobilier est un vrai métier qui requiert connaissance du marché, savoir-faire commercial et rigueur professionnelle. La promotion et la vente de votre bien sont l'affaire d'un professionnel."
                                + "<br/><br/>Je suis votre interlocuteur PRIVILÉGIÉ et à votre écoute pour vous guider dans vos démarches avec sérieux, vous accompagner dans toutes les étapes de votre projet, trouver des solutions adaptées à vos besoins, assurer le suivi du processus jusqu’à la signature en toute sécurité devant notaire, réaliser vos rêves avec le sourire."
                    //+ "<br/><br/>Je mettrai en oeuvre pour la réussite et la concrétisation de votre projet:  Réactivité, Rigueur, Anticipation, Sincérité et Disponibilité ."
                                + "<br/><br/>Je suis à votre disposition pour un entretien, un renseignement ou tout simplement une question.";
            else quote_agent = reader["quote"].ToString() + reader["quote2"].ToString() + reader["quote3"].ToString();

            //Quote de l'agent
            LBLCitation.Text = "<center><img style='float:left;margin-left:50px' height='40px' src='../img_site/quote1.jpg'/>";
            LBLCitation.Text += "<div class='quote_agent'>";
            LBLCitation.Text += nl2br(quote_agent);
            LBLCitation.Text += "</div>";
            LBLCitation.Text += "<img style='float:right;margin-right:50px' height='40px' src='../img_site/quote2.png'/>";
            LBLCitation.Text += "</center>";


            //PANNEAU ADMIN
            if ((Membre)Session["Membre"] != null)
                if (member != null && member.STATUT == "ultranego")
                {
                    admin_Panel.Visible = true;
                }
            LBLAdmin.Text = "<div style='margin-left:15px;'>";

            if (reader["contractuel"].ToString() == "True") LBLAdmin.Text += "Ce conseiller est <b>Contractuel.</b><br/><br/>";
            else LBLAdmin.Text += "Ce conseiller <b>n'est pas Contractuel.</b><br/><br/>";

            if (IsPostBack)
            {
                LBLInfoText.Text += "!";
                LBLInfoDispo.Text += "!";
            }

            //Suivi
            if (!IsPostBack)
            {
                TBSuivi.Text = reader["suivi"].ToString();
                TBDispo.Text = reader["disponibilités"].ToString();
            }

            reader.Close();

            //Pour la suite, il y a probablement plus simple ...
            OdbcCommand commande2 = new OdbcCommand("SELECT COUNT(*) FROM Biens WHERE idclient = ? AND etat= 'Libre' ", c3);
            OdbcParameter paramIdClient = new OdbcParameter("", DbType.String);
            paramIdClient.Value = idClient;
            commande2.Parameters.Add(paramIdClient);
            reader = commande2.ExecuteReader();
            reader.Read();
            LBLAdmin.Text += "<b><a href='#" + LBLLocs.ClientID + "'>Location :</a></b> " + reader.GetString(0) + " Libre(s)<br />";
            reader.Close();

            OdbcCommand commande3 = new OdbcCommand("SELECT COUNT(*) FROM Biens WHERE idclient = ? AND etat= 'Estimation' AND actif='actif'  ", c3);
            OdbcParameter paramIdClient3 = new OdbcParameter("", DbType.String);
            paramIdClient3.Value = idClient;
            commande3.Parameters.Add(paramIdClient3);
            reader = commande3.ExecuteReader();
            reader.Read();
            LBLAdmin.Text += "<b><a href='#" + LBLVentes.ClientID + "'>Vente :</a></b> " + reader.GetString(0) + " Estimation(s) , ";
            reader.Close();

            OdbcCommand commande4 = new OdbcCommand("SELECT COUNT(*) FROM Biens WHERE idclient = ? AND etat= 'Disponible' AND actif='actif'  ", c3);
            OdbcParameter paramIdClient4 = new OdbcParameter("", DbType.String);
            paramIdClient4.Value = idClient;
            commande4.Parameters.Add(paramIdClient4);
            reader = commande4.ExecuteReader();
            reader.Read();
            LBLAdmin.Text += reader.GetString(0) + " Disponible(s) <br /><br />";

            LBLAdmin.Text += "<b>Mot de passe : </b><div class='show_on_hover' >" + pass_Client + "</div>";
            LBLAdmin.Text += "</div>";


            //Gerer le contrat
            if (ContractExists(idClient))
            {
                LBLContract.Text = "<strong>Modifier le Contrat :</strong><br/><br/>";
                Show_Contract.Visible = true;
            }
            else
            {
                LBLContract.Text = "<strong>Ajouter un Contrat :</strong><br/><br/>";
                Show_Contract.Visible = false;
            }

            reader.Close();


            //OFFRES DU CONSEILLER
            OdbcCommand commande5 = new OdbcCommand("SELECT * FROM Biens, optionsBiens, Pays  WHERE Biens.ref=optionsBiens.refOptions AND Pays.Titre_Pays=optionsBiens.PaysBien AND (Biens.etat='Libre' OR Biens.etat='Disponible' OR (Biens.etat='Estimation' AND optionsBiens.PubLocale=TRUE)) AND actif='actif' AND idclient = ? ORDER BY Biens.[date modification] DESC ", c3);
            OdbcParameter paramIdClient2 = new OdbcParameter("", DbType.String);
            paramIdClient2.Value = idClient;
            commande5.Parameters.Add(paramIdClient2);
            reader = commande5.ExecuteReader();

            if (reader.HasRows)
            {
                int nbLoc = 0, nbVente = 0;
                String type_trans = "ACH";

                LBLVentes.Text = "<div style='text-align:center;font-size:18px;font-weight: bold;'>SES VENTES</div>";
                LBLVentes.Text += "<br />";

                LBLLocs.Text = "<hr /><br /><div style='text-align:center;font-size:18px;font-weight: bold;'>SES LOCATIONS</div>";
                LBLLocs.Text += "<br />";

                while (reader.Read())
                {

                    //Design de la fiche
                    ficheBien = "";
                    ficheBien += "<a href='./fichedetail1.aspx?ref=" + reader["ref"] + "&orig=nego' style='decoration:none'><div class='bloc_bien_agent'>";

                    ficheBien += "<div class='new_span' style='float:left;margin-right:5px;'><img  src='../img_site/drapeau/" + reader["codeiso"].ToString() + ".png'/><span>" + reader["PaysBien"].ToString() + "</span></div>";

                    if (reader["ref"].ToString().Substring(0, 1) == "V") type_trans = "ACH";
                    else type_trans = "LOC";


                    switch (reader["type de bien"].ToString())
                    {
                        case "A": ficheBien += " Appartement - "; break;
                        case "M": ficheBien += " Maison - "; break;
                        case "L": ficheBien += " Local - "; break;
                        case "T": ficheBien += " Terrain - "; break;
                        case "I": ficheBien += " Immeuble - "; break;
                        default: ficheBien += ""; break;
                    }

                    if (reader["nombre de pieces"].ToString() != "0") ficheBien += reader["nombre de pieces"] + " piece(s) - ";
                    if (reader["surface habitable"].ToString() != "0") ficheBien += reader["surface habitable"] + " m² - ";
                    if (reader["ville du bien"].ToString() != "") ficheBien += reader["ville du bien"];
                    if (reader["code postal du bien"].ToString().Length >= 2) ficheBien += " (" + reader["code postal du bien"].ToString().Substring(0, 2) + ") - ";
                    if (type_trans == "ACH") if (reader["prix de vente"].ToString() != "0") ficheBien += reader["prix de vente"] + " &#8364;";
                    if (type_trans == "LOC") if (reader["loyer_cc"].ToString() != "0") ficheBien += reader["loyer_cc"] + " &#8364;";

                    ficheBien += "<br/><hr/>";

                    //Image du bien
                    image = "";
                    string sourceJpgExcl = "../img_site/bandeau_exclusivite.png";
                    string sourceJpgSemExcl = "../img_site/bandeau_semiExclusif.png";
                    string sourceJpgNouveaute = "../img_site/bandeau_nouveaute.png";
                    int nbJourNv = -15;
                    DateTime today = DateTime.Now;
                    DateTime date_modif;
                    DateTime todayMoinsJourNv = today.AddDays(nbJourNv);
                    DateTime.TryParse(reader["date modification"].ToString(), out date_modif);

                    String texte_internet = nl2br(reader["texte internet"].ToString());
                    if (texte_internet.Length > 320) texte_internet = texte_internet.Substring(0, 320) + "[...]";
                    texte_internet += "<br/> <br/> <b>Cliquez pour plus d'infos      </b>";
                    image += "<span style='margin-top:0px;opacity:0.8;min-width:20%'>" + texte_internet + "</span>";


                    switch (reader["type mandat"].ToString())
                    {
                        case "Exclusif": image += "<img id=\"bandeau2_bien_agent\" alt=\"photo\" src= \"" + sourceJpgExcl + "\" width=\"240\" height=\"240\" />"; break;
                        case "SemiExclusif": image += "<img id=\"bandeau2_bien_agent\" alt=\"photo\" src= \"" + sourceJpgSemExcl + "\" />"; break;
                        default: if (date_modif >= todayMoinsJourNv) image += "<img id=\"bandeau2_bien_agent\" alt=\"photo\" src= \"" + sourceJpgNouveaute + "\" width=\"240\" height=\"240\" />";
                            break;
                    }

                    if (System.IO.File.Exists(MapPath("~/images/" + reader["ref"].ToString() + "A.JPG")))
                    {
                        image += "<img style='vertical-align:top'; width='100%'; height='80%' src='../images/" + reader["ref"].ToString() + "A.JPG' />";
                    }
                    else image += "<img style='vertical-align:top;' width='100%' src='../img_site/images_par_defaut/A.jpg' />";

                    ficheBien += image;


                    ficheBien += "</div></a>";


                    //Enregistrement dans les locs ou la vente
                    if (type_trans == "ACH")
                    {
                        if (nbVente < 6)
                        {
                            LBLVentes.Text += ficheBien;
                            nbVente++;
                        }
                        else BtnVoirVentes.Visible = true;

                    }
                    else
                    {
                        if (nbLoc < 6)
                        {
                            LBLLocs.Text += ficheBien;
                            nbLoc++;
                        }
                        else BtnVoirLocs.Visible = true;
                    }

                }
                LBLLocs.Text += "<br /><br />";
                LBLVentes.Text += "<br />";


                if (nbLoc == 0) LBLLocs.Text = "";
                if (nbVente == 0) LBLVentes.Text = "";

            }
            else
            {
                LBLVentes.Text = "<center><strong>Aucune ventes ni location pour l'instant.<br/> Proposez nous votre bien ! </strong></center>";
                LBLLocs.Text = "";

            }
        }
        else
        {
            LBLerreur.Visible = true;
            LBLerreur.Text = "Vous n'avez pas selectionné un agent valide !";
        }
        c3.Close();

        double caTot = 0D, ca30j = 0D, ca12m = 0D, ca3m = 0D, caTotF = 0D, ca30jF = 0D, ca12mF = 0D, ca3mF = 0D, caSomme = 0D;
        double caVentesTot = 0D, caVentes30j = 0D, caVentes12m = 0D, caVentes3m = 0D, caLocations30j = 0D, caLocationsTot = 0D, caLocations12m = 0D, caLocations3m = 0D;
        double caVentesTotF = 0D, caVentes30jF = 0D, caVentes12mF = 0D, caVentes3mF = 0D, caLocations30jF = 0D, caLocationsTotF = 0D, caLocations12mF = 0D, caLocations3mF = 0D;
        int ventes30j = 0, ventes3m = 0, ventes12m = 0, ventesTot = 0, locations30j = 0, locations3m = 0, locations12m = 0, locationsTot = 0;
        DateTime dtnow, dtsignature;
        Connexion c4 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataSet ds;
        DataRowCollection dr;
        c4.Open();

        ds = c4.exeRequette("SELECT [commission]*[taux_mandat] AS ca, Ventes.date_signature, Ventes.ref_bien FROM Clients INNER JOIN Ventes ON Clients.idclient = Ventes.id_nego WHERE id_client = '" + id_client + "' AND valider_paiement = true");
        dr = ds.Tables[0].Rows;

        dtnow = DateTime.Now;
        int trimestre = 0;

        if (dtnow.Month < 4) trimestre = 3;
        else if (dtnow.Month < 7) trimestre = 6;
        else if (dtnow.Month < 10) trimestre = 9;
        else trimestre = 12;

        foreach (DataRow ligne in dr)
        {
            dtsignature = DateTime.Parse(ligne["date_signature"].ToString());
            if (dtsignature.Year == dtnow.Year)
            {
                ca12m += double.Parse(ligne["ca"].ToString());
                if (ligne["ref_bien"].ToString().Contains('V')) caVentes12m += double.Parse(ligne["ca"].ToString());
                else caLocations12m += double.Parse(ligne["ca"].ToString());
                if (trimestre >= dtsignature.Month && dtsignature.Month >= trimestre - 2)
                {
                    if (ligne["ref_bien"].ToString().Contains('V')) caVentes3m += double.Parse(ligne["ca"].ToString());
                    else caLocations3m += double.Parse(ligne["ca"].ToString());
                    ca3m += double.Parse(ligne["ca"].ToString());
                    if (dtsignature.Month == dtnow.Month)
                    {
                        ca30j += double.Parse(ligne["ca"].ToString());
                        if (ligne["ref_bien"].ToString().Contains('V')) caVentes30j += double.Parse(ligne["ca"].ToString());
                        else caLocations30j += double.Parse(ligne["ca"].ToString());
                    }
                }
            }
            if (ligne["ref_bien"].ToString().Contains('V')) caVentesTot += double.Parse(ligne["ca"].ToString());
            else caLocationsTot += double.Parse(ligne["ca"].ToString());
            caTot += double.Parse(ligne["ca"].ToString());
            caSomme += double.Parse(ligne["ca"].ToString());
        }

        ds = c4.exeRequette("SELECT [commission]*[taux_vente] AS ca, Ventes.date_signature, Ventes.ref_bien FROM (Ventes INNER JOIN Acquereurs ON Ventes.id_acquereur = Acquereurs.id_acq) INNER JOIN Clients ON Acquereurs.idclient = Clients.idclient WHERE Clients.id_client = '" + id_client + "' AND valider_paiement= true");
        dr = ds.Tables[0].Rows;

        foreach (DataRow ligne in dr)
        {
            dtsignature = DateTime.Parse(ligne["date_signature"].ToString());
            if (dtsignature.Year == dtnow.Year)
            {
                ca12m += double.Parse(ligne["ca"].ToString());
                if (ligne["ref_bien"].ToString().Contains('V')) caVentes12m += double.Parse(ligne["ca"].ToString());
                else caLocations12m += double.Parse(ligne["ca"].ToString());
                if (trimestre >= dtsignature.Month && dtsignature.Month >= trimestre - 2)
                {
                    if (ligne["ref_bien"].ToString().Contains('V')) caVentes3m += double.Parse(ligne["ca"].ToString());
                    else caLocations3m += double.Parse(ligne["ca"].ToString());
                    ca3m += double.Parse(ligne["ca"].ToString());
                    if (dtsignature.Month == dtnow.Month)
                    {
                        ca30j += double.Parse(ligne["ca"].ToString());
                        if (ligne["ref_bien"].ToString().Contains('V')) caVentes30j += double.Parse(ligne["ca"].ToString());
                        else caLocations30j += double.Parse(ligne["ca"].ToString());
                    }
                }
            }
            if (ligne["ref_bien"].ToString().Contains('V')) caVentesTot += double.Parse(ligne["ca"].ToString());
            else caLocationsTot += double.Parse(ligne["ca"].ToString());
            caTot += double.Parse(ligne["ca"].ToString());
            caSomme += double.Parse(ligne["ca"].ToString());
        }

        c4.Close();

        double[,] CAF = exeRequeteCAFilleul(id_client);
        for (int k = 0; k < 7; k++)
        {
            caTotF += Math.Round(CAF[0, k], 2);
            ca30jF += Math.Round(CAF[3, k], 2);
            ca3mF += Math.Round(CAF[2, k], 2);
            ca12mF += Math.Round(CAF[1, k], 2);
            caSomme += Math.Round(CAF[0, k], 2);
        }

        for (int k = 0; k < 7; k++)
        {
            caVentesTotF += Math.Round(ventesCAF[0,k], 2);
            caVentes30jF += Math.Round(ventesCAF[3, k], 2);
            caVentes3mF += Math.Round(ventesCAF[2, k], 2);
            caVentes12mF += Math.Round(ventesCAF[1, k], 2);
        }

        for (int k = 0; k < 7; k++)
        {
            caLocationsTotF += Math.Round(locationsCAF[0, k], 2);
            caLocations30jF += Math.Round(locationsCAF[3, k], 2);
            caLocations3mF += Math.Round(locationsCAF[2, k], 2);
            caLocations12mF += Math.Round(locationsCAF[1, k], 2);
        }

        String[] decimale = new String[8] { "", "", "", "", "", "", "", "" };
        String decimaleSomme = "";
        String decimalCATot = "";
        String decimalCATotF = "";
        String[] decimaleF = new String[8] { "", "", "", "", "", "", "", "" };
        if (caVentesTot.ToString().Split(',').Length == 2) decimale[0] = caVentesTot.ToString().Split(',')[1];
        if (caVentes30j.ToString().Split(',').Length == 2) decimale[3] = caVentes30j.ToString().Split(',')[1];
        if (caVentes3m.ToString().Split(',').Length == 2) decimale[2] = caVentes3m.ToString().Split(',')[1];
        if (caVentes12m.ToString().Split(',').Length == 2) decimale[1] = caVentes12m.ToString().Split(',')[1];
        if (caVentesTotF.ToString().Split(',').Length == 2) decimale[4] = caVentesTotF.ToString().Split(',')[1];
        if (caVentes30jF.ToString().Split(',').Length == 2) decimale[7] = caVentes30jF.ToString().Split(',')[1];
        if (caVentes3mF.ToString().Split(',').Length == 2) decimale[6] = caVentes3mF.ToString().Split(',')[1];
        if (caVentes12mF.ToString().Split(',').Length == 2) decimale[5] = caVentes12mF.ToString().Split(',')[1];

        if (caSomme.ToString().Split(',').Length == 2) decimaleSomme = caSomme.ToString().Split(',')[1];
        if (caTot.ToString().Split(',').Length == 2) decimalCATot = caTot.ToString().Split(',')[1];
        if (caTotF.ToString().Split(',').Length == 2) decimalCATotF = caTotF.ToString().Split(',')[1];

        if (caLocationsTot.ToString().Split(',').Length == 2) decimaleF[0] = caLocationsTot.ToString().Split(',')[1];
        if (caLocations30j.ToString().Split(',').Length == 2) decimaleF[3] = caLocations30j.ToString().Split(',')[1];
        if (caLocations3m.ToString().Split(',').Length == 2) decimaleF[2] = caLocations3m.ToString().Split(',')[1];
        if (caLocations12m.ToString().Split(',').Length == 2) decimaleF[1] = caLocations12m.ToString().Split(',')[1];
        if (caLocationsTotF.ToString().Split(',').Length == 2) decimaleF[4] = caLocationsTotF.ToString().Split(',')[1];
        if (caLocations30jF.ToString().Split(',').Length == 2) decimaleF[7] = caLocations30jF.ToString().Split(',')[1];
        if (caLocations3mF.ToString().Split(',').Length == 2) decimaleF[6] = caLocations3mF.ToString().Split(',')[1];
        if (caLocations12mF.ToString().Split(',').Length == 2) decimaleF[5] = caLocations12mF.ToString().Split(',')[1];

        if (decimale[0] != "") caVentesTotal.Text = formatCA(caVentesTot.ToString()) + "," + decimale[0] + " €";
        else caVentesTotal.Text = formatCA(caVentesTot.ToString()) + " €";
        if (decimale[1] != "") caAnnuelVentes.Text = formatCA(caVentes12m.ToString()) + "," + decimale[1] + " €";
        else caAnnuelVentes.Text = formatCA(caVentes12m.ToString()) + " €";
        if (decimale[2] != "") caTrimestrielVentes.Text = formatCA(caVentes3m.ToString()) + "," + decimale[2] + " €";
        else caTrimestrielVentes.Text = formatCA(caVentes3m.ToString()) + " €";
        if (decimale[3] != "") caMensuelVentes.Text = formatCA(caVentes30j.ToString()) + "," + decimale[3] + " €";
        else caMensuelVentes.Text = formatCA(caVentes30j.ToString()) + " €";

        if (decimaleF[0] != "") caLocationsTotal.Text = formatCA(caLocationsTot.ToString()) + "," + decimaleF[0] + " €";
        else caLocationsTotal.Text = formatCA(caLocationsTot.ToString()) + " €";
        if (decimaleF[1] != "") caAnnuelLocations.Text = formatCA(caLocations12m.ToString()) + "," + decimaleF[1] + " €";
        else caAnnuelLocations.Text = formatCA(caLocations12m.ToString()) + " €";
        if (decimaleF[2] != "") caTrimestrielLocations.Text = formatCA(caLocations3m.ToString()) + "," + decimaleF[2] + " €";
        else caTrimestrielLocations.Text = formatCA(caLocations3m.ToString()) + " €";
        if (decimaleF[3] != "") caMensuelLocations.Text = formatCA(caLocations30j.ToString()) + "," + decimaleF[3] + " €";
        else caMensuelLocations.Text = formatCA(caLocations30j.ToString()) + " €";

        if (decimale[4] != "") caVentesTotalF.Text = formatCA(caVentesTotF.ToString()) + "," + decimale[4] + " €";
        else caVentesTotalF.Text = formatCA(caVentesTotF.ToString()) + " €";
        if (decimale[5] != "") caAnnuelVentesF.Text = formatCA(caVentes12mF.ToString()) + "," + decimale[5] + " €";
        else caAnnuelVentesF.Text = formatCA(caVentes12mF.ToString()) + " €";
        if (decimale[6] != "") caTrimestrielVentesF.Text = formatCA(caVentes3mF.ToString()) + "," + decimale[6] + " €";
        else caTrimestrielVentesF.Text = formatCA(caVentes3mF.ToString()) + " €";
        if (decimale[7] != "") caMensuelVentesF.Text = formatCA(caVentes30jF.ToString()) + "," + decimale[7] + " €";
        else caMensuelVentesF.Text = formatCA(caVentes30jF.ToString()) + " €";

        if (decimaleF[4] != "") caLocationsTotalF.Text = formatCA(caLocationsTotF.ToString()) + "," + decimaleF[4] + " €";
        else caLocationsTotalF.Text = formatCA(caLocationsTotF.ToString()) + " €";
        if (decimaleF[5] != "") caAnnuelLocationsF.Text = formatCA(caLocations12mF.ToString()) + "," + decimaleF[5] + " €";
        else caAnnuelLocationsF.Text = formatCA(caLocations12mF.ToString()) + " €";
        if (decimaleF[6] != "") caTrimestrielLocationsF.Text = formatCA(caLocations3mF.ToString()) + "," + decimaleF[6] + " €";
        else caTrimestrielLocationsF.Text = formatCA(caLocations3mF.ToString()) + " €";
        if (decimaleF[7] != "") caMensuelLocationsF.Text = formatCA(caLocations30jF.ToString()) + "," + decimaleF[7] + " €";
        else caMensuelLocationsF.Text = formatCA(caLocations30jF.ToString()) + " €";

        if (decimalCATot != "") caTotA.Text = formatCA(caTot.ToString()) + "," + decimalCATot + " €";
        else caTotA.Text = formatCA(caTot.ToString()) + " €";
        if (decimalCATotF != "") caTotAF.Text = formatCA(caTotF.ToString()) + "," + decimalCATotF + " €";
        else caTotAF.Text = formatCA(caTotF.ToString()) + " €";

        Connexion c5 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataSet ds5;
        DataRowCollection dr5;
        c5.Open();

        if (id_client != "")
        {
            ds5 = c5.exeRequette("SELECT civilite, nom_client, prenom_client FROM Clients WHERE id_client ='" + id_client + "'");
            dr5 = ds5.Tables[0].Rows;

            caTotal.Text = dr5[0]["civilite"].ToString() + " " + dr5[0]["nom_client"].ToString() + " " + dr5[0]["prenom_client"].ToString() + " a réalisé un chiffre d'affaire total de ";
            if (decimaleSomme != "") caTotal.Text += formatCA(caSomme.ToString()) + "," + decimaleSomme + " € sur toute son activité.";
            else caTotal.Text += formatCA(caSomme.ToString()) + " € sur toute son activité.";
            nbVentes.Text = dr5[0]["civilite"].ToString() + " " + dr5[0]["nom_client"].ToString() + " " + dr5[0]["prenom_client"].ToString() + " a participé à ";

            ds5 = c5.exeRequette("SELECT date_signature, Ventes.ref_bien FROM Clients AS Clients_1 INNER JOIN ((Clients INNER JOIN Ventes ON Clients.idclient = Ventes.id_nego) INNER JOIN Acquereurs ON Ventes.id_acquereur = Acquereurs.id_acq) ON Clients_1.idclient = Acquereurs.idclient WHERE (Clients.id_client = '" + id_client + "' OR Clients_1.id_client = '" + id_client + "') AND valider_signature = true");
            dr5 = ds5.Tables[0].Rows;

            foreach (DataRow ligne in dr5)
            {
                dtsignature = DateTime.Parse(ligne["date_signature"].ToString());
                if (dtsignature.Year == dtnow.Year)
                {
                    if (ligne["ref_bien"].ToString().Contains('V')) ventes12m++;
                    else locations12m++;
                    if (trimestre >= dtsignature.Month && dtsignature.Month >= trimestre - 2)
                    {
                        if (ligne["ref_bien"].ToString().Contains('V')) ventes3m++;
                        else locations3m++;
                        if (dtsignature.Month == dtnow.Month)
                        {
                            if (ligne["ref_bien"].ToString().Contains('V')) ventes30j++;
                            else locations30j++;
                        }
                    }
                }
                if (ligne["ref_bien"].ToString().Contains('V')) ventesTot++;
                else locationsTot++;
            }

            nbVentes.Text += ventesTot + " ventes et " + locationsTot + " locations.";
            ventesMensuel.Text += ventes30j.ToString();
            ventesTrimestriel.Text += ventes3m.ToString();
            ventesAnnuel.Text += ventes12m.ToString();
            locationsMensuel.Text += locations30j.ToString();
            locationsTrimestriel.Text += locations3m.ToString();
            locationsAnnuel.Text += locations12m.ToString();
        }
        if ((Membre)Session["Membre"] != null)
        {
            if (id_client == ((Membre)Session["Membre"]).ID_CLIENT || ((Membre)Session["Membre"]).STATUT == "ultranego")
            {
                PanelBilan.Style.Add("display", "");
            }
            else
            {
                Membre nego = (Membre)Session["Membre"];
                Connexion c6 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                DataSet ds6;
                DataRowCollection dr6;

                c6.Open();
                String[] requeteFilleul = new String[7] { "", "", "", "", "", "", "" };
                requeteFilleul[0] = "SELECT Clients_1.id_client FROM Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain WHERE (((Clients.id_client)='" + nego.ID_CLIENT + "'))";
                requeteFilleul[1] = "SELECT Clients_2.id_client FROM (Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain) INNER JOIN Clients AS Clients_2 ON Clients_1.idclient = Clients_2.idparrain WHERE (((Clients.id_client)='" + nego.ID_CLIENT + "'))";
                requeteFilleul[2] = "SELECT Clients_3.id_client FROM ((Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain) INNER JOIN Clients AS Clients_2 ON Clients_1.idclient = Clients_2.idparrain) INNER JOIN Clients AS Clients_3 ON Clients_2.idclient = Clients_3.idparrain WHERE (((Clients.id_client)='" + nego.ID_CLIENT + "'))";
                requeteFilleul[3] = "SELECT Clients_4.id_client FROM (((Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain) INNER JOIN Clients AS Clients_2 ON Clients_1.idclient = Clients_2.idparrain) INNER JOIN Clients AS Clients_3 ON Clients_2.idclient = Clients_3.idparrain) INNER JOIN Clients AS Clients_4 ON Clients_3.idclient = Clients_4.idparrain WHERE (((Clients.id_client)='" + nego.ID_CLIENT + "'))";
                requeteFilleul[4] = "SELECT Clients_5.id_client FROM (((((Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain) INNER JOIN Clients AS Clients_2 ON Clients_1.idclient = Clients_2.idparrain) INNER JOIN Clients AS Clients_3 ON Clients_2.idclient = Clients_3.idparrain) INNER JOIN Clients AS Clients_4 ON Clients_3.idclient = Clients_4.idparrain) INNER JOIN Clients AS Clients_5 ON Clients_4.idclient = Clients_5.idparrain) WHERE (((Clients.id_client)='" + nego.ID_CLIENT + "'))";
                requeteFilleul[5] = "SELECT Clients_6.id_client FROM (((((Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain) INNER JOIN Clients AS Clients_2 ON Clients_1.idclient = Clients_2.idparrain) INNER JOIN Clients AS Clients_3 ON Clients_2.idclient = Clients_3.idparrain) INNER JOIN Clients AS Clients_4 ON Clients_3.idclient = Clients_4.idparrain) INNER JOIN Clients AS Clients_5 ON Clients_4.idclient = Clients_5.idparrain) INNER JOIN Clients AS Clients_6 ON Clients_5.idclient = Clients_6.idparrain WHERE (((Clients.id_client)='" + nego.ID_CLIENT + "'))";
                requeteFilleul[6] = "SELECT Clients_7.id_client FROM ((((((Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain) INNER JOIN Clients AS Clients_2 ON Clients_1.idclient = Clients_2.idparrain) INNER JOIN Clients AS Clients_3 ON Clients_2.idclient = Clients_3.idparrain) INNER JOIN Clients AS Clients_4 ON Clients_3.idclient = Clients_4.idparrain) INNER JOIN Clients AS Clients_5 ON Clients_4.idclient = Clients_5.idparrain) INNER JOIN Clients AS Clients_6 ON Clients_5.idclient = Clients_6.idparrain) INNER JOIN Clients AS Clients_7 ON Clients_6.idclient = Clients_7.idparrain WHERE (((Clients.id_client)='" + nego.ID_CLIENT + "'))";

                for (int i = 0; i < 7; i++)
                {
                    ds6 = c6.exeRequette(requeteFilleul[i]);
                    dr6 = ds6.Tables[0].Rows;

                    foreach (DataRow ligne in dr6)
                    {
                        if (ligne["id_client"].ToString() == id_client) PanelBilan.Style.Add("display", "");
                    }
                }
            }
        }
    }

    public double[,] exeRequeteCAFilleul(String mail_client)
    {
        String[] requeteCAF = new String[7]{ "", "", "", "", "", "", "" };
        String requeteCARecu = "";
        DateTime datesignatureF, datenowF;
        datenowF = DateTime.Now; 
        int trimestre = 0;

        if (datenowF.Month < 4) trimestre = 3;
        else if (datenowF.Month < 7) trimestre = 6;
        else if (datenowF.Month < 10) trimestre = 9;
        else trimestre = 12;
        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataSet ds, ds1;
        DataRowCollection dr, dr1;

        c.Open();
        requeteCAF[0] = "SELECT Clients_1.idclient FROM Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain WHERE (((Clients.id_client)='" + mail_client + "'))";
        requeteCAF[1] = "SELECT Clients_2.idclient FROM (Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain) INNER JOIN Clients AS Clients_2 ON Clients_1.idclient = Clients_2.idparrain WHERE (((Clients.id_client)='" + mail_client + "'))";
        requeteCAF[2] = "SELECT Clients_3.idclient FROM ((Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain) INNER JOIN Clients AS Clients_2 ON Clients_1.idclient = Clients_2.idparrain) INNER JOIN Clients AS Clients_3 ON Clients_2.idclient = Clients_3.idparrain WHERE (((Clients.id_client)='" + mail_client + "'))";
        requeteCAF[3] = "SELECT Clients_4.idclient FROM (((Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain) INNER JOIN Clients AS Clients_2 ON Clients_1.idclient = Clients_2.idparrain) INNER JOIN Clients AS Clients_3 ON Clients_2.idclient = Clients_3.idparrain) INNER JOIN Clients AS Clients_4 ON Clients_3.idclient = Clients_4.idparrain WHERE (((Clients.id_client)='" + mail_client + "'))";
        requeteCAF[4] = "SELECT Clients_5.idclient FROM (((((Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain) INNER JOIN Clients AS Clients_2 ON Clients_1.idclient = Clients_2.idparrain) INNER JOIN Clients AS Clients_3 ON Clients_2.idclient = Clients_3.idparrain) INNER JOIN Clients AS Clients_4 ON Clients_3.idclient = Clients_4.idparrain) INNER JOIN Clients AS Clients_5 ON Clients_4.idclient = Clients_5.idparrain) WHERE (((Clients.id_client)='" + mail_client + "'))";
        requeteCAF[5] = "SELECT Clients_6.idclient FROM (((((Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain) INNER JOIN Clients AS Clients_2 ON Clients_1.idclient = Clients_2.idparrain) INNER JOIN Clients AS Clients_3 ON Clients_2.idclient = Clients_3.idparrain) INNER JOIN Clients AS Clients_4 ON Clients_3.idclient = Clients_4.idparrain) INNER JOIN Clients AS Clients_5 ON Clients_4.idclient = Clients_5.idparrain) INNER JOIN Clients AS Clients_6 ON Clients_5.idclient = Clients_6.idparrain WHERE (((Clients.id_client)='" + mail_client + "'))";
        requeteCAF[6] = "SELECT Clients_7.idclient FROM ((((((Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain) INNER JOIN Clients AS Clients_2 ON Clients_1.idclient = Clients_2.idparrain) INNER JOIN Clients AS Clients_3 ON Clients_2.idclient = Clients_3.idparrain) INNER JOIN Clients AS Clients_4 ON Clients_3.idclient = Clients_4.idparrain) INNER JOIN Clients AS Clients_5 ON Clients_4.idclient = Clients_5.idparrain) INNER JOIN Clients AS Clients_6 ON Clients_5.idclient = Clients_6.idparrain) INNER JOIN Clients AS Clients_7 ON Clients_6.idclient = Clients_7.idparrain WHERE (((Clients.id_client)='" + mail_client + "'))";

        double pourcentage = 0D;
        for (int i = 0; i < 7; i++)
        { 
            if (i == 0) pourcentage = 0.05;
            if (i == 1) pourcentage = 0.04;
            if (i == 2) pourcentage = 0.03;
            if (i == 3) pourcentage = 0.02;
            if (i == 4) pourcentage = 0.01;
            if (i == 5) pourcentage = 0.005;
            if (i == 6) pourcentage = 0.0025;
            
            ds = c.exeRequette(requeteCAF[i]);
            dr = ds.Tables[0].Rows;
                  
            foreach (DataRow ligne in dr)
            {
                requeteCARecu = "SELECT [commission]*[taux_vente] AS ca, Ventes.date_signature, Ventes.ref_bien FROM (Ventes INNER JOIN Acquereurs ON Ventes.id_acquereur = Acquereurs.id_acq) INNER JOIN Clients ON Acquereurs.idclient = Clients.idclient WHERE Clients.idclient = " + ligne["idclient"] + " AND valider_paiement= true";
            
                ds1 = c.exeRequette(requeteCARecu);
                dr1 = ds1.Tables[0].Rows;

                foreach (DataRow ligne1 in dr1)
                {
                    datesignatureF = DateTime.Parse(ligne1["date_signature"].ToString());
                    if (datesignatureF.Year == datenowF.Year)
                    {
                        totalCAF[1, i] += double.Parse(ligne1["ca"].ToString()) * pourcentage;
                        if (ligne1["ref_bien"].ToString().Contains('V')) ventesCAF[1,i] += double.Parse(ligne1["ca"].ToString()) * pourcentage;
                        else locationsCAF[1, i] += double.Parse(ligne1["ca"].ToString()) * pourcentage;
                        if (trimestre >= datesignatureF.Month && datesignatureF.Month >= trimestre - 2)
                        {
                            totalCAF[2, i] += double.Parse(ligne1["ca"].ToString()) * pourcentage;
                            if (ligne1["ref_bien"].ToString().Contains('V')) ventesCAF[2, i] += double.Parse(ligne1["ca"].ToString()) * pourcentage;
                            else locationsCAF[2, i] += double.Parse(ligne1["ca"].ToString()) * pourcentage;
                            if (datesignatureF.Month == datenowF.Month)
                            {
                                totalCAF[3, i] += double.Parse(ligne1["ca"].ToString()) * pourcentage;
                                if (ligne1["ref_bien"].ToString().Contains('V')) ventesCAF[3, i] += double.Parse(ligne1["ca"].ToString()) * pourcentage;
                                else locationsCAF[3, i] += double.Parse(ligne1["ca"].ToString()) * pourcentage;
                            }
                        }
                    }
                    totalCAF[0, i] += double.Parse(ligne1["ca"].ToString()) * pourcentage;
                    if (ligne1["ref_bien"].ToString().Contains('V')) ventesCAF[0, i] += double.Parse(ligne1["ca"].ToString()) * pourcentage;
                    else locationsCAF[0, i] += double.Parse(ligne1["ca"].ToString()) * pourcentage;
                }

                requeteCARecu = "SELECT [commission]*[taux_mandat] AS ca, Ventes.date_signature, Ventes.ref_bien FROM Clients INNER JOIN Ventes ON Clients.idclient = Ventes.id_nego WHERE idclient = " + ligne["idclient"] + " AND valider_paiement = true";

                ds1 = c.exeRequette(requeteCARecu);
                dr1 = ds1.Tables[0].Rows;

                foreach (DataRow ligne1 in dr1)
                {
                    datesignatureF = DateTime.Parse(ligne1["date_signature"].ToString());
                    if (datesignatureF.Year == datenowF.Year)
                    {
                        totalCAF[1, i] += double.Parse(ligne1["ca"].ToString()) * pourcentage;
                        if (ligne1["ref_bien"].ToString().Contains('V')) ventesCAF[1, i] += double.Parse(ligne1["ca"].ToString()) * pourcentage;
                        else locationsCAF[1, i] += double.Parse(ligne1["ca"].ToString()) * pourcentage;
                        if (trimestre >= datesignatureF.Month && datesignatureF.Month >= trimestre - 2)
                        {
                            totalCAF[2, i] += double.Parse(ligne1["ca"].ToString()) * pourcentage;
                            if (ligne1["ref_bien"].ToString().Contains('V')) ventesCAF[2, i] += double.Parse(ligne1["ca"].ToString()) * pourcentage;
                            else locationsCAF[2, i] += double.Parse(ligne1["ca"].ToString()) * pourcentage;
                            if (datesignatureF.Month == datenowF.Month)
                            {
                                totalCAF[3, i] += double.Parse(ligne1["ca"].ToString()) * pourcentage;
                                if (ligne1["ref_bien"].ToString().Contains('V')) ventesCAF[3, i] += double.Parse(ligne1["ca"].ToString()) * pourcentage;
                                else locationsCAF[3, i] += double.Parse(ligne1["ca"].ToString()) * pourcentage;
                            }
                        }
                    }
                    totalCAF[0, i] += double.Parse(ligne1["ca"].ToString()) * pourcentage;
                    if (ligne1["ref_bien"].ToString().Contains('V')) ventesCAF[0, i] += double.Parse(ligne1["ca"].ToString()) * pourcentage;
                    else locationsCAF[0, i] += double.Parse(ligne1["ca"].ToString()) * pourcentage;
                }
            }
        }
        
        c.Close();

        return totalCAF;
    }

    public String formatCA(String CA)
    {
        String tot = "";
        int x = CA.Split(',')[0].Length;
        for (int i = 1; i < 6; i++)
        {
            total[i] = "";
            if (x - 3 * i >= 0)
            {
                total[i] += " ";
                total[i] += CA.Substring(x - 3 * i, 3);
            }
            else
            {
                if (x - 3 * i == -1) total[i] += CA.Substring(0, 2);
                if (x - 3 * i == -2) total[i] += CA.Substring(0, 1);
            }
        }
        for (int j = 1; j < 6; j++)
        {
            tot += total[6 - j];
        }

        return tot;
    }

    protected String getImageProfil(String idClient, String ClientCivilite)
    {
        //Recuperation de l'image
        string sourceJpg = "../img_nego/" + idClient + "_PHOTO.JPG";

        if (System.IO.File.Exists(MapPath("~/img_nego/" + idClient + "_PHOTO.jpg")) == false)
        {
            if (ClientCivilite == "Mr") sourceJpg = "../img_site/man.png";
            else sourceJpg = "../img_site/woman.png";
        }

        return sourceJpg;
    }

    protected void BackToList(object sender, EventArgs e)
    {

        if (Request.QueryString["orig"] != null)
        {
            String page = "-1";
            if (Request.Params["page"] != null) page = Request.Params["page"].ToString(); 
            Response.Redirect("./fichedetail1.aspx?ref=" + Request.QueryString["orig"]+"&page="+page);

        }
        else Response.Redirect("./Recherche_agent.aspx");
    }

    protected void VoirLocs(object sender, EventArgs e)
    {
        Session["Transaction"] = "location2";
        Session["IDCLIENT"] = idClient;
        Response.Redirect("./affichagerecherche.aspx?field1=" + Session["IDCLIENT"]);
    }

    protected void VoirVentes(object sender, EventArgs e)
    {
        Session["Transaction"] = "achat2";
        Session["IDCLIENT"] = idClient;
        Response.Redirect("./affichagerecherche.aspx?field1=" + Session["IDCLIENT"]);
    }

    protected void Modifier(object sender, EventArgs e)
    {
        Response.Redirect("./afficherCompte.aspx?field1=" + idClient);
    }

    protected void EnvoiMail(object sender, EventArgs e)
    {

        if ((TBContent.Text == "") || (TBMail.Text == "") || (TBNom.Text == "") || (TBPrenom.Text == "") || (TBTel.Text == ""))
        {
            LBLInfoMail.Text = "Un des champs obligatoire est vide !";
            LBLInfoMail.ForeColor = System.Drawing.Color.Red;
            LBLInfoMail.Visible = true;
        }
        else
        {
            LBLInfoMail.Text = "Votre email a bien été envoyé !";
            LBLInfoMail.ForeColor = System.Drawing.Color.Green;
            LBLInfoMail.Visible = true;
            SmtpClient smtp = new SmtpClient();
            MailMessage message1 = new MailMessage();
            MailMessage message2 = new MailMessage();
            String ip = Request.UserHostAddress.ToString();
            String date = DateTime.Now.ToString();

            String corps;

            Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c.Open();
            System.Data.DataSet ds = c.exeRequette("Select * from Environnement");
            c.Close();
            String strhost = (String)ds.Tables[0].Rows[0]["HostSMTP"];
            string stremail = (string)ds.Tables[0].Rows[0]["email_commande"];
            smtp.Host = strhost;
            smtp.Port = 25;


            corps = "Vous avez recu un message de la part de " + TBNom.Text.ToUpper() + " " + TBPrenom.Text + "<br/><br/>"
                + "Email : " + TBMail.Text + "<br/>"
                + "Telephone :" + TBTel.Text + "<br/>";
            if (TBAdresse.Text != "") corps += "Habite: " + TBAdresse.Text + "<br/>";
            corps += "<br/><br/>Son message:<br/>" + TBContent.Text + "<br/><br/>"
                 + "Cliquez <a href='http://patrimo.net'>ICI</a> pour vous rendre sur le site de Patrimo.";

            //Message pour le negociateur
            message1.From = new MailAddress(stremail, "Patrimo");
            message1.Subject = "Vous avez reçu un message provenant de votre page Patrimo !";
            message1.To.Add(idClient);
            message1.IsBodyHtml = true;
            message1.Body = corps;


            //Message pour patrimo

            message2.From = new MailAddress(stremail, "Patrimo");
            message2.Subject = "Un negociateur a recu un message provenant de sa page Patrimo !";
            message2.To.Add("info@patrimo.net");
            message2.IsBodyHtml = true;
            message2.Body = "<strong>Voici le corps du message envoyé a " + idClient + " :</strong><br/><br/>" + corps;


            //Envoi des messages
            smtp.Send(message1);
            smtp.Send(message2);

        }

    }

    protected void Modifier_suivi(object sender, EventArgs e)
    {
        OdbcConnection c3 = new OdbcConnection(_ConnectionString);
        OdbcCommand commande = new OdbcCommand("UPDATE Clients SET suivi= ? WHERE idclient= ?", c3);

        OdbcParameter paramIdSuivi = new OdbcParameter("", DbType.String);
        paramIdSuivi.Value = TBSuivi.Text;
        commande.Parameters.Add(paramIdSuivi);
        OdbcParameter paramIdClient = new OdbcParameter("", DbType.String);
        paramIdClient.Value = idClient;
        commande.Parameters.Add(paramIdClient);

        c3.Open();
        commande.ExecuteNonQuery();
        c3.Close();

        LBLInfoText.Visible = true;
    }

    protected void Add_Contract(object sender, EventArgs e)
    {
        if (file_upload.HasFile)
        {
            try
            {
                //Upload du fichier
                string filename = Path.GetFileName(file_upload.FileName);
                file_upload.SaveAs(MapPath("~/Contrats/Contrat_" + idClient + ".pdf"));
            }
            catch
            {
            }
        }

    }

    protected Boolean ContractExists(String idClient)
    {
        return System.IO.File.Exists(MapPath("~/Contrats/Contrat_" + idClient + ".pdf"));
    }

    protected void Modifier_dispo(object sender, EventArgs e)
    {
        OdbcConnection c3 = new OdbcConnection(_ConnectionString);
        OdbcCommand commande = new OdbcCommand("UPDATE Clients SET disponibilités= ? WHERE idclient= ?", c3);

        OdbcParameter paramIdSuivi = new OdbcParameter("", DbType.String);
        paramIdSuivi.Value = TBDispo.Text;
        commande.Parameters.Add(paramIdSuivi);
        OdbcParameter paramIdClient = new OdbcParameter("", DbType.String);
        paramIdClient.Value = idClient;
        commande.Parameters.Add(paramIdClient);

        c3.Open();
        commande.ExecuteNonQuery();
        c3.Close();

        LBLInfoDispo.Visible = true;
    }

    protected String nl2br(string s)
    {
        Regex rgx = new Regex("\r\n|\r|\n");
        return rgx.Replace(s, "<br/>");
    }

    protected void btnCADetails(object sender, EventArgs e)
    {
        Response.Redirect("./detailsCA.aspx?id_client=" + Request.QueryString["id_client"]);
    }
}