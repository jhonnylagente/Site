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
using System.Text.RegularExpressions;
using System.IO;
using System.Data.Odbc;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using GestionEmplacement;



public partial class recherche : System.Web.UI.Page
{
    string txtBx;
    protected string img_bg;
    protected TextBox HiddenField2 = new TextBox();
    OdbcConnection c2;

    public void Page_Load(object sender, EventArgs e)
    {
        c2 = new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        Membre member = (Membre)Session["Membre"];
       
        #region new_Search
        TB_Texte_prix_max.Attributes.Add("readonly", "readonly");
        TB_Texte_prix_min.Attributes.Add("readonly", "readonly");
        TB_Texte_Surf_min.Attributes.Add("readonly", "readonly");
        TB_Texte_Surf_max.Attributes.Add("readonly", "readonly");

        set_bg_img();
        get_nombre_annonces();
        get_Exclu();

        TB_TypeBien.Text = "";
        if ((Session["checkBoxAppart"] != null) && ((bool)Session["checkBoxAppart"])) TB_TypeBien.Text += "Maisons, ";
        if ((Session["checkBoxMaison"] != null) && ((bool)Session["checkBoxMaison"])) TB_TypeBien.Text += "Appartements, ";
        if ((Session["checkBoxTerrain"] != null) && ((bool)Session["checkBoxTerrain"])) TB_TypeBien.Text += "Terrains, ";
        if ((Session["checkBoxAutre"] != null) && ((bool)Session["checkBoxAutre"])) TB_TypeBien.Text += "Autres, ";
        if (TB_TypeBien.Text.Length > 2) TB_TypeBien.Text = TB_TypeBien.Text.Substring(0, TB_TypeBien.Text.Length - 2);

        TB_nbre_pieces.Text="";
        if ((Session["checkBoxPiece1"] != null) && ((bool)Session["checkBoxPiece1"])) TB_nbre_pieces.Text += "1, ";
        if ((Session["checkBoxPiece2"] != null) && ((bool)Session["checkBoxPiece2"])) TB_nbre_pieces.Text += "2, ";
        if ((Session["checkBoxPiece3"] != null) && ((bool)Session["checkBoxPiece3"])) TB_nbre_pieces.Text += "3, ";
        if ((Session["checkBoxPiece4"] != null) && ((bool)Session["checkBoxPiece4"])) TB_nbre_pieces.Text += "4, ";
        if ((Session["checkBoxPiece5"] != null) && ((bool)Session["checkBoxPiece5"])) TB_nbre_pieces.Text += "5, ";
        if (TB_nbre_pieces.Text.Length > 2) TB_nbre_pieces.Text = TB_nbre_pieces.Text.Substring(0, TB_nbre_pieces.Text.Length - 2); 
        if (TB_nbre_pieces.Text == "1") TB_nbre_pieces.Text += " pièce";
        else TB_nbre_pieces.Text += " pièces";
        if ((Session["checkBoxPiece5"] != null) && ((bool)Session["checkBoxPiece5"])) TB_nbre_pieces.Text += " ou +";

        if (ucCible.FindControl("HiddenField2") != null) HiddenField2 = (TextBox)ucCible.FindControl("HiddenField2");

        #endregion

        #region autre
        /*
        try
        {
            LabelErrorLogin.Visible = false;
            if (Request.Params["typebien"].ToString() == "vente")
            {
                Session["checkBoxMaisonR"] = true;
                Session["checkBoxAppartR"] = true;
                Session["checkBoxTerrainR"] = true;
                Session["checkBoxAutreR"] = true;
                Session["radioButtonAchatR"] = true;
                Session["TextBoxBudgetMinR"] = "";
            }
            if (Request.Params["typebien"].ToString() == "ventemaison")
            {
                Session["checkBoxMaisonR"] = true;
                Session["checkBoxAppartR"] = false;
                Session["checkBoxTerrainR"] = false;
                Session["checkBoxAutreR"] = false;
                Session["radioButtonAchatR"] = true;
                Session["TextBoxBudgetMinR"] = "";
            }
            if (Request.Params["typebien"].ToString() == "venteappart")
            {
                Session["checkBoxMaisonR"] = false;
                Session["checkBoxAppartR"] = true;
                Session["checkBoxTerrainR"] = false;
                Session["checkBoxAutreR"] = false;
                Session["radioButtonAchatR"] = true;
                Session["TextBoxBudgetMinR"] = "";
            }
            if (Request.Params["typebien"].ToString() == "venteterrain")
            {
                Session["checkBoxMaisonR"] = false;
                Session["checkBoxAppartR"] = false;
                Session["checkBoxTerrainR"] = true;
                Session["checkBoxAutreR"] = false;
                Session["radioButtonAchatR"] = true;
                Session["TextBoxBudgetMinR"] = "";
            }
            if (Request.Params["typebien"].ToString() == "venteautres")
            {
                Session["checkBoxMaisonR"] = false;
                Session["checkBoxAppartR"] = false;
                Session["checkBoxTerrainR"] = false;
                Session["checkBoxAutreR"] = true;
                Session["radioButtonAchatR"] = true;
                Session["TextBoxBudgetMinR"] = "";
            }
            if (Request.Params["typebien"].ToString() == "location")
            {
                Session["checkBoxAppartR"] = true;
                Session["checkBoxMaisonR"] = true;
                Session["checkBoxTerrainR"] = true;
                Session["checkBoxAutreR"] = true;
                Session["TextBoxBudgetMinR"] = "";
                Session["radioButtonAchatR"] = false;
                radioButtonLocation.Checked = true;
            }
            if (Request.Params["typebien"].ToString() == "demeure")
            {
                Session["checkBoxMaisonR"] = true;
                Session["checkBoxAppartR"] = true;
                TextBoxBudgetMin.Text = "500000";
                TextBoxBudgetMin.ReadOnly = true;
                Session["TextBoxBudgetMinR"] = "500000";
                Session["checkBoxTerrainR"] = false;
                Session["checkBoxAutreR"] = false;
                Session["radioButtonAchatR"] = true;
            }
        }
        catch
        {
        }*/

        if (!IsPostBack)
        {
            if (Session["Transaction"] == "achat" || Session["Transaction"] == "")
            {
                radioButtonAchat.Checked = true;
                BTN_V.Text = "V";
            }
            else
            {
                radioButtonLocation.Checked = true;
                 BTN_V.Text = "L";
            }

            checkBoxMaison.Checked = (bool)Session["checkBoxMaison"];
            checkBoxAppart.Checked = (bool)Session["checkBoxAppart"];
            checkBoxTerrain.Checked = (bool)Session["checkBoxTerrain"];
            checkBoxAutre.Checked = (bool)Session["checkBoxAutre"];

            txtBx = (String)Session["Localisation"];

            TB_MotCle1.Text = (String)Session["textBoxMotCle1"];
            TB_MotCle2.Text = (String)Session["textBoxMotCle2"];
            TB_MotCle3.Text = (String)Session["textBoxMotCle3"];
            TB_MotCle4.Text = (String)Session["textBoxMotCle4"];

            TB_Texte_prix_min.Text = (String)Session["TextBoxBudgetMin"];
            TB_Texte_prix_max.Text = (String)Session["TextBoxBudgetMax"];
            if ((String)Session["TextBoxBudgetMax"] != "") TB_Budget_Max.Text = (String)Session["TextBoxBudgetMax"] + " €";

            TB_Texte_Surf_min.Text = (String)Session["textBoxSurfaceMin"];
            TB_Texte_Surf_max.Text = (String)Session["textBoxSurfaceMax"];
            if ((String)Session["textBoxSurfaceMin"] != "" && (String)Session["textBoxSurfaceMin"] != "0") TB_Surface_Min.Text = (String)Session["textBoxSurfaceMin"] + " m²";

            checkBoxPiece1.Checked = (bool)Session["checkBoxPiece1"];
            checkBoxPiece2.Checked = (bool)Session["checkBoxPiece2"];
            checkBoxPiece3.Checked = (bool)Session["checkBoxPiece3"];
            checkBoxPiece4.Checked = (bool)Session["checkBoxPiece4"];
            checkBoxPiece5.Checked = (bool)Session["checkBoxPiece5"];

            if (Session["chckBxCdC"] != null) chckBxCdC.Checked = (bool)Session["chckBxCdC"];
            else chckBxCdC.Checked = false;
            if (Session["chckBxPrestige"] != null) chckBxPrestige.Checked = (bool)Session["chckBxPrestige"];
            else chckBxPrestige.Checked = false;
            if (Session["chckBxMer"] != null) chckBxMer.Checked = (bool)Session["chckBxMer"];
            else chckBxMer.Checked = false;
            if (Session["chckBxMontagne"] != null) chckBxMontagne.Checked = (bool)Session["chckBxMontagne"];
            else chckBxMontagne.Checked = false;

            if (Session["ListeNeuf"] != null)
            {
                int idx = 2;
                Int32.TryParse(Session["ListeNeuf"].ToString(), out idx);
                DDL_Neuf.SelectedValue = idx.ToString();
            } 
        }

        #endregion
    }

    private Boolean verifChampSaisi(RequeteBien maRecher)
    {
        Boolean rech_ok = true;
        Regex numReg = new Regex("^[0-9 ]+$");

        //Un peu inutile vu que c'est déjà blindé coté client, mais bon ça coute rien.
        if (TB_Texte_prix_min.Text != "" && !numReg.IsMatch(TB_Texte_prix_min.Text)) rech_ok = false;
        if (TB_Texte_prix_max.Text != "" && !numReg.IsMatch(TB_Texte_prix_max.Text)) rech_ok = false;
        if (TB_Texte_Surf_min.Text != "" && !numReg.IsMatch(TB_Texte_Surf_min.Text)) rech_ok = false;
        if (TB_Texte_Surf_max.Text != "" && !numReg.IsMatch(TB_Texte_Surf_max.Text)) rech_ok = false;

        if (maRecher.PRIXMAX < maRecher.PRIXMIN) rech_ok = false;
        if (maRecher.SURFACEMAX < maRecher.SURFACEMIN) rech_ok = false;

        maRecher.RECHERCHE_OK = rech_ok;
        if(!rech_ok)
        {
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "Erreur de saisie, veuillez resaisir les critères de votre recherche";
        }

        return rech_ok;
    }

    private string getVilleFromDep(string txt)
    {
        List<string> Villes = new List<string>();
        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        Regex regCP = new Regex(@"^([0-9]{4}[0-9]?)+$");
        Regex regDep = new Regex(@"^([0-9][0-9]?)+$");
        int i = 0;
        bool test = true, test2;
        string tmp;

        tmp = "";
        while (test == true)
        {
            test2 = true;
            while (test2 == true)
            {
                tmp += txt[i];
                i++;
                if (i == txt.Length)
                {
                    test2 = false;
                }
                else if (txt[i] == ' ')
                {
                    test2 = false;
                }
            }
            if (regCP.IsMatch(tmp))
            {
                Villes.Add(tmp);
            }
            else if (regDep.IsMatch(tmp))
            {
                if (tmp.Length == 1)
                {
                    tmp = "SELECT [Code Postal] FROM Ville WHERE [Code Postal] LIKE '0" + tmp + "%' ORDER BY [Code Postal];";
                }
                else
                {
                    tmp = "SELECT [Code Postal] FROM Ville WHERE [Code Postal] LIKE '" + tmp + "%' ORDER BY [Code Postal];";
                }
                c.Open();
                DataSet oDs = c.exeRequette(tmp);
                c.Close();
                for (int j = 0; j < oDs.Tables[tmp].Rows.Count; j++)
                {
                    if (Convert.ToString(oDs.Tables[tmp].Rows[j][0]).Length == 5)
                    {
                        Villes.Add(Convert.ToString(oDs.Tables[tmp].Rows[j][0]));
                    }
                }
            }
            tmp = "";
            i++;
            if (i >= txt.Length)
            {
                test = false;
            }
        }

        txt = Villes[0];
        for (int j = 1; j < Villes.Count; j++)
        {
            txt += " " + Villes[j];
        }

        return txt;
    }

   protected void Button1_Click(object sender, EventArgs e)
   {
       string listePays = "";
       string listeContinent = "";
		
       RequeteBien recherche = new RequeteBien();
       Regex verifMail = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$", RegexOptions.IgnoreCase);

       if (TB_Texte_prix_min.Text == "") recherche.PRIXMIN = 0;
       if (TB_Texte_prix_max.Text == "") recherche.PRIXMAX = 1000000000;
       if (TB_Texte_Surf_min.Text == "") recherche.SURFACEMIN = 0;
       if (TB_Texte_Surf_max.Text == "") recherche.SURFACEMAX = 9999999;


       if (verifChampSaisi(recherche))
       {
           if (TB_Texte_Surf_min.Text != "") recherche.SURFACEMIN = Int64.Parse(TB_Texte_Surf_min.Text.Trim());
           if (TB_Texte_Surf_max.Text != "") recherche.SURFACEMAX = Int64.Parse(TB_Texte_Surf_max.Text.Trim());

           recherche.MOTCLE1 = TB_MotCle1.Text.Trim();
           recherche.MOTCLE2 = TB_MotCle2.Text.Trim();
           recherche.MOTCLE3 = TB_MotCle3.Text.Trim();
           recherche.MOTCLE4 = TB_MotCle4.Text.Trim();

           recherche.PIECE1 = checkBoxPiece1.Checked;
           recherche.PIECE2 = checkBoxPiece2.Checked;
           recherche.PIECE3 = checkBoxPiece3.Checked;
           recherche.PIECE4 = checkBoxPiece4.Checked;
           recherche.PIECE5 = checkBoxPiece5.Checked;

           recherche.COUP_DE_COEUR = chckBxCdC.Checked;
           recherche.PRESTIGE = chckBxPrestige.Checked;
           recherche.MER = chckBxMer.Checked;
           recherche.MONTAGNE = chckBxMontagne.Checked;

           switch (DDL_Neuf.SelectedValue)
           {
               case "0": recherche.NeufOuPas = false; recherche.NEUF = false; break;
               case "1": recherche.NeufOuPas = false; recherche.NEUF = true; break;
               case "2": recherche.NeufOuPas = true; break;
               default: recherche.NeufOuPas = true; break;
           }

           recherche.MANDAT_EXCLUSIF = true;
           recherche.MANDAT_SEMI_EXCLUSIF = true;
           recherche.MANDAT_SIMPLE = true;

           recherche.Cible = ucCible.listeVilleRecherche.createString();
           LabelErrorLogin.Text = recherche.Cible;

           Session["VilleRechercheRech"] = "";
           Session["PaysRechercheRech"] = "";
           Session["DepRechercheRech"] = "";
			
			
           if(ucCible.listeVilleRecherche.Count != 0)
           {
               foreach (EmplacementRecherche ER in ucCible.listeVilleRecherche)
               {
                   if(ER.IsPays == true)
                   {
                       listePays += "'"+ER.Nom + "',";
                       Session["PaysRechercheRech"] += ER.Nom + ",";
                   }
                   else if(ER.IsContinent == true)
                       listeContinent += "'" + ER.Nom + "',";
                   else if(ER.Dep == true)
                       Session["DepRechercheRech"] += ER.CP + "|" + ER.Nom + ",";
                   else
                       Session["VilleRechercheRech"] += ER.CP + "|" + ER.Nom + ",";
						
					
					
               }
               if(listePays != "")
               {
                   listePays = listePays.Substring(0, listePays.Length - 1);
                   recherche.Listepays = listePays;
               }
				
               if(listeContinent != "")
               {
                   listeContinent = listeContinent.Substring(0, listeContinent.Length - 1);
                   recherche.ListeContinent = listeContinent;
               }
           }
			

           if (!checkBoxAppart.Checked  && !checkBoxTerrain.Checked  && !checkBoxMaison.Checked  && !checkBoxAutre.Checked)
           {
               recherche.TYPEBIEN = "AMTX";
           }
           else
           {
               if (checkBoxAppart.Checked) recherche.TYPEBIEN += "A";
               if (checkBoxMaison.Checked) recherche.TYPEBIEN += "M";
               if (checkBoxTerrain.Checked) recherche.TYPEBIEN += "T";
               if (checkBoxAutre.Checked) recherche.TYPEBIEN += "X";
           }

           if (radioButtonAchat.Checked)
           {
               recherche.TYPEVENTE = "V";
               if (TB_Texte_prix_min.Text != "") recherche.PRIXMIN = Int64.Parse(TB_Texte_prix_min.Text.Trim());
               if (TB_Texte_prix_max.Text != "") recherche.PRIXMAX = Int64.Parse(TB_Texte_prix_max.Text.Trim());
           }
           else
           {
               recherche.TYPEVENTE = "L";
               if (TB_Texte_prix_min.Text != "") recherche.LOYERMIN = Int64.Parse(TB_Texte_prix_min.Text.Trim());
               if (TB_Texte_prix_max.Text != "") recherche.LOYERMAX = Int64.Parse(TB_Texte_prix_max.Text.Trim());
           }

           //sauvegarde l'objet recherche dans la session

           Session["requete"] = recherche;

           if (radioButtonAchat.Checked == true) Session["Transaction"] = "achat";
           else Session["Transaction"] = "location";


           Session["Smin"] = TB_Texte_Surf_min.Text;
           Session["Smax"] = TB_Texte_Surf_max.Text;
           Session["Localisation"] = txtBx;
           Session["cible"] = ucCible.listeVilleRecherche;

           Session["radioButtonAchat"] = radioButtonAchat.Checked;
           Session["checkBoxPiece1"] = checkBoxPiece1.Checked;
           Session["checkBoxPiece2"] = checkBoxPiece2.Checked;
           Session["checkBoxPiece3"] = checkBoxPiece3.Checked;
           Session["checkBoxPiece4"] = checkBoxPiece4.Checked;
           Session["checkBoxPiece5"] = checkBoxPiece5.Checked;

           Session["checkBoxMaison"] = checkBoxMaison.Checked;
           Session["checkBoxAppart"] = checkBoxAppart.Checked;
           Session["checkBoxTerrain"] = checkBoxTerrain.Checked;
           Session["checkBoxAutre"] = checkBoxAutre.Checked;

           Session["textBoxMotCle1"] = TB_MotCle1.Text;
           Session["textBoxMotCle2"] = TB_MotCle2.Text;
           Session["textBoxMotCle3"] = TB_MotCle3.Text;
           Session["textBoxMotCle4"] = TB_MotCle4.Text;

           Session["TextBoxBudgetMax"] = TB_Texte_prix_max.Text;
           Session["TextBoxBudgetMin"] = TB_Texte_prix_min.Text;

           Session["chckBxMandatEcxlusif"] = true;
           Session["chckBxMandatSemExc"] = true;
           Session["chckBxMandatSimple"] = true;
           Session["chckBxCdC"] = chckBxCdC.Checked;
           Session["chckBxPrestige"] = chckBxPrestige.Checked;
           Session["ListeNeuf"] = DDL_Neuf.SelectedIndex;
           Session["chckBxMer"] = chckBxMer.Checked;
           Session["chckBxMontagne"] = chckBxMontagne.Checked;

           // créer l'alerte e-mail
           if (TextBoxMail.Text.Trim() == "")
           {
               Session["mail"] = "false";
               Response.Redirect("./affichagerecherche.aspx?Numpage=" + 1 + "&Tri=" + Session["Tri"] + "&Ordre=" + Session["Ordre"] + "&nbannonces=" + Session["annoncesPage"]);
           }
           else if (verifMail.IsMatch(TextBoxMail.Text.Trim()))
           {
               generate_Alerte(listePays,listeContinent);
           }
           else
           {
               LabelErrorLogin.Visible = true;
               LabelErrorLogin.Text = "erreur de saisie, adresse e-mail invalide";
           }
       }
       else
       {
           LabelErrorLogin.Visible = true;
           LabelErrorLogin.Text = "erreur de saisie, champs invalides";
       }
   }
   
    protected void clear2(object sender, EventArgs e)
    {
        ucCible.clear2();
    }
	
	protected void ajouterDepartement(object sender, EventArgs e)
    {
        ucCible.ajouterDepartement(TBAjaxMap.Text);
    }
	
	protected void supprimerContinent(object sender, EventArgs e)
    {
        ucCible.supprimerContinent(TBAjaxWorldMap2.Text);
    }
	
	protected void ajouterContinent(object sender, EventArgs e)
    {
        ucCible.ajouterContinent(TBAjaxWorldMap.Text);
    }

	protected void ajouterPays(object sender, EventArgs e)
	{
		ucCible.ajouterPays(TBAjaxEuropeMap.Text);
	}


    // show textbox
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]

    protected void generate_Alerte(string listePays,string listeContinent)
    {
        RequeteBien alerte = null;

        try
        {
            // recupère l'alerte mail dans la session
            // si ça plante c'est qu'il n'y a pas d'alerte mail dans la session alors 
            // on créer une instance dans le bloque catch
            alerte = (RequeteBien)Session["alerte"];
        }
        catch
        {
            alerte = new RequeteBien();
        }

        alerte.ListeContinent = listeContinent;
        alerte.Listepays = listePays;
        //enregister les champs saisie
        alerte.ID_CLIENT = TextBoxMail.Text;

        if (TB_Texte_prix_min.Text == "") alerte.PRIXMIN = 0;
        else alerte.PRIXMIN = Int64.Parse(TB_Texte_prix_min.Text.Trim());

        if (TB_Texte_prix_max.Text == "") alerte.PRIXMAX = 1000000000;
        else alerte.PRIXMAX = Int64.Parse(TB_Texte_prix_max.Text.Trim());

        if (TB_Texte_Surf_min.Text == "") alerte.SURFACEMIN = 0;
        else alerte.SURFACEMIN = Int64.Parse(TB_Texte_Surf_min.Text.Trim());

        if (TB_Texte_Surf_max.Text == "") alerte.SURFACEMAX = 9999999;
        else alerte.SURFACEMAX = Int64.Parse(TB_Texte_Surf_max.Text.Trim());

        alerte.PIECE1 = checkBoxPiece1.Checked;
        alerte.PIECE2 = checkBoxPiece2.Checked;
        alerte.PIECE3 = checkBoxPiece3.Checked;
        alerte.PIECE4 = checkBoxPiece4.Checked;
        alerte.PIECE5 = checkBoxPiece5.Checked;

        alerte.MOTCLE1 = TB_MotCle1.Text.Trim();
        alerte.MOTCLE2 = TB_MotCle2.Text.Trim();
        alerte.MOTCLE3 = TB_MotCle3.Text.Trim();
        alerte.MOTCLE4 = TB_MotCle4.Text.Trim();

        if (checkBoxAppart.Checked == false && checkBoxTerrain.Checked == false && checkBoxMaison.Checked == false && checkBoxAutre.Checked == false)
        {
            alerte.TYPEBIEN = "AMTX";
        }
        else
        {
            alerte.TYPEBIEN = "";// permet de réinitialisé le champ
            if (checkBoxAppart.Checked) alerte.TYPEBIEN += "A";
            if (checkBoxMaison.Checked) alerte.TYPEBIEN += "M";
            if (checkBoxTerrain.Checked) alerte.TYPEBIEN += "T";
            if (checkBoxAutre.Checked) alerte.TYPEBIEN += "X";
        }

        alerte.Cible = ucCible.listeVilleRecherche.createString();

        if (radioButtonAchat.Checked) alerte.TYPEVENTE = "V";
        else if (radioButtonLocation.Checked) alerte.TYPEVENTE = "L";

        switch (DDL_Neuf.SelectedValue)
        {
            case "0": alerte.NeufOuPas = false; alerte.NEUF = false; break;
            case "1": alerte.NeufOuPas = false; alerte.NEUF = true; break;
            case "2": alerte.NeufOuPas = true; break;
            default: alerte.NeufOuPas = true; break;
        }

        alerte.PRESTIGE = chckBxPrestige.Checked;
        alerte.COUP_DE_COEUR = chckBxCdC.Checked;
        alerte.MER = chckBxMer.Checked;
        alerte.MONTAGNE = chckBxMontagne.Checked;

        Session["NumPage"] = 1;
        Session["Tri"] = "prix";
        Session["alerte"] = alerte;
        Session["mail"] = "true";

        Response.Redirect("./affichagerecherche.aspx?Numpage=" + 1 + "&Tri=" + Session["Tri"] + "&Ordre=" + Session["Ordre"] + "&nbannonces=" + Session["annoncesPage"]);


    }

    protected void get_Exclu()
    {
        
        OdbcCommand commande = new OdbcCommand("SELECT TOP 3 * FROM Biens, optionsBiens, Pays  WHERE Biens.ref=optionsBiens.refOptions AND Pays.Titre_Pays=optionsBiens.PaysBien AND (Biens.etat='Libre' OR Biens.etat='Disponible' OR (Biens.etat='Estimation' AND optionsBiens.PubLocale=TRUE)) AND actif='actif' AND ( [type mandat]='Exclusif' OR [type mandat]='SemiExclusif' ) ORDER BY Biens.[date modification] DESC ", c2);
        if(c2.State == ConnectionState.Closed) c2.Open();
        OdbcDataReader reader = commande.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                //Design de la fiche
                String ficheBien = "", type_trans = ""; ;
                ficheBien += "<a href='./fichedetail1.aspx?ref=" + reader["ref"] + "&orig=nego' style='decoration:none'><div class='bloc_bien_agent_main_page'>";

                ficheBien += "<div class='new_span' style='float:left; margin-right:5px;'><img  src='../img_site/drapeau/" + reader["codeiso"].ToString() + ".png'/><span>" + reader["PaysBien"].ToString().ToUpper() + "</span></div>";

                if (reader["ref"].ToString().Substring(0, 1) == "V") type_trans = "ACH";
                else type_trans = "LOC";

                switch (reader["type de bien"].ToString())
                {
                    case "A": ficheBien += " APPARTEMENT - "; break;
                    case "M": ficheBien += " MAISON - "; break;
                    case "L": ficheBien += " LOCAL - "; break;
                    case "T": ficheBien += " TERRAIN - "; break;
                    case "I": ficheBien += " IMMEUBLE - "; break;
                    default: ficheBien += ""; break;
                }

                if (reader["ville du bien"].ToString() != "") ficheBien += reader["ville du bien"].ToString().ToUpper();
                if (reader["code postal du bien"].ToString().Length >= 2) ficheBien += " (" + reader["code postal du bien"].ToString().Substring(0, 2) + ") - ";
                if (reader["nombre de pieces"].ToString() != "0") ficheBien += reader["nombre de pieces"] + " piece(s) - ";
                if (reader["surface habitable"].ToString() != "0") ficheBien += reader["surface habitable"] + " m² - ";              
                if (type_trans == "ACH") if (reader["prix de vente"].ToString() != "0") ficheBien += reader["prix de vente"] + " &#8364;";
                if (type_trans == "LOC") if (reader["loyer_cc"].ToString() != "0") ficheBien += reader["loyer_cc"] + " &#8364;";

                ficheBien += "<br/><hr/>";

                //Image du bien
                String image = "";
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
                    case "Exclusif": image += "<img id='bandeau2_bien_agent' alt='photo' src= '" + sourceJpgExcl + "' width='240' height='240' style='left:0px;' />"; break;
                    case "SemiExclusif": image += "<img id=\"bandeau2_bien_agent\" alt=\"photo\" src= \"" + sourceJpgSemExcl + "\" />"; break;
                    default: if (date_modif >= todayMoinsJourNv) image += "<img id=\"bandeau2_bien_agent\" alt=\"photo\" src= \"" + sourceJpgNouveaute + "\" width=\"240\" height=\"240\" />"; break;
                }

                if (System.IO.File.Exists(MapPath("~/images/" + reader["ref"].ToString() + "A.JPG")))
                {
                    image += "<img style='vertical-align:top'; width='100%'; height='80%' src='../images/" + reader["ref"].ToString() + "A.JPG' />";
                }
                else image += "<img style='vertical-align:top;' width='100%' src='../img_site/images_par_defaut/A.jpg' />";

                ficheBien += image;


                ficheBien += "</div></a>";

                LBL_Exclu.Text += ficheBien;


            }

        }
        reader.Close();
        c2.Close();
    }

    protected void get_nombre_annonces()
    {
        int nbre_annonces=0;

        OdbcCommand commande = new OdbcCommand("SELECT Biens.ref, Biens.actif, Biens.etat, optionsBiens.PubLocale FROM optionsBiens INNER JOIN Biens ON optionsBiens.refOptions = Biens.ref WHERE (((Biens.ref) Like 'l%') AND ((Biens.actif)='actif') AND ((Biens.etat)='libre')) OR (((Biens.ref) Like 'v%') AND  ((Biens.actif)='actif') AND ((Biens.etat)='disponible')) OR (((Biens.ref) Like 'v%') AND ((Biens.actif)='actif') AND ((Biens.etat)='estimation') AND ((optionsBiens.PubLocale)=True))", c2);
        c2.Open();
        OdbcDataReader reader = commande.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read()) nbre_annonces++;
        }
        LBL_nbre_bien.Text="Trouvez votre bien parmi les <strong>"+nbre_annonces.ToString()+"</strong> disponibles !";
     }

    protected String nl2br(string s)
    {
        Regex rgx = new Regex("\r\n|\r|\n");
        return rgx.Replace(s, "<br/>");
    }

    protected void set_bg_img()
    {
        Random rnd = new Random();
        string[] liste_images = Directory.GetFiles(@"c:/PATRIMO/PATRIMO/Img_accueil/");
        img_bg = "../" + liste_images[rnd.Next(0, liste_images.Count() - 1)].Split(new string[] { "/PATRIMO/PATRIMO/" }, StringSplitOptions.None)[1];
    }

}