using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data.Odbc;
using GestionEmplacement;
using System.Data;

public partial class controlAjoutAcquereur : System.Web.UI.UserControl
{

    bool toutVirer = false;
    //liste affiché sur le navigateur
    public ListeEmplacement emplacementAffiche = new ListeEmplacement();
    //liste generer a partir de emplacementAffiché a qui on retire les elements de la liste noire
    //cette liste affiché dans option avancé
    //permet de generer string a mettre dans les filtres de la base de donnée
    //peut etre importée a partir d un fichier(contenant la dite string)
    public ListeEmplacementRecherche listeVilleRecherche = new ListeEmplacementRecherche();
    public ListeEmplacementRecherche listeNoire = new ListeEmplacementRecherche();
    public List<Arrondissement> listeArrondissementNoire = new List<Arrondissement>();
    DataRowCollection drcAideDep;
    DataRowCollection drcAideVilles;
    DataRowCollection drcAidePays;
    DataRowCollection drcArrondissements;
    string textBoxCibleAvant;
	
	public void supprimerContinent(string continent)
	{
		List<Emplacement> copie = new List<Emplacement>(emplacementAffiche);
        foreach (Emplacement ville in copie)
        {
            if (ville.Nom == continent.ToUpper()) 
			{
				emplacementAffiche.Remove(ville);
			}
        }
        rafraichirEmplacementAffiche();
	}
	
	public void ajouterContinent(string continent)
	{
	
		string codeContinent = "";
		
		switch(continent)
		{
			case "Europe" : codeContinent = "eu"; break;
			case "Afrique" : codeContinent = "af"; break;
			case "Asie" : codeContinent = "as"; break;
			case "AmériqueN" : codeContinent = "na"; break;
			case "AmériqueS" : codeContinent = "sa"; break;
			case "Océanie" : codeContinent = "oc"; break;
		}
		
        Connexion c = new Connexion();
        OdbcCommand commande = new OdbcCommand();
        commande.CommandText = "SELECT DISTINCT Continent FROM Pays WHERE Continent = ?";
        OdbcParameter paramContinent = new OdbcParameter("", DbType.String);
        paramContinent.Value = continent;
        commande.Parameters.Add(paramContinent);
		
        DataRow dr = c.exeRequetteParametree(commande).Tables[0].Rows[0];

        Emplacement cont = new Emplacement(false, dr["Continent"].ToString().ToUpper(), false, false, codeContinent, new ListeEmplacementRecherche());
		cont.IsContinent = true;
		
        emplacementAffiche.Add(cont);

        rafraichirEmplacementAffiche();
	}
	
	public void ajouterPays(string pays)
	{		
		pays = "'" + pays.Replace("'","''") + "'";
        Connexion c = new Connexion();
        OdbcCommand commande = new OdbcCommand();
        commande.CommandText = "SELECT * FROM Pays WHERE Titre_Pays like " + pays;
        //OdbcParameter paramContinent = new OdbcParameter("", DbType.String);
        //paramContinent.Value = pays;
        //commande.Parameters.Add(paramContinent);
		
        DataRow dr = c.exeRequetteParametree(commande).Tables[0].Rows[0];

        Emplacement cont = new Emplacement(false, dr["Titre_Pays"].ToString().ToUpper(), false, false, dr["Id_Pays"].ToString(), new ListeEmplacementRecherche());
		cont.IsPays = true;
		
        emplacementAffiche.Add(cont);

        rafraichirEmplacementAffiche();
	}

    public void ajouterDepartement(string codeDep)
    {
        String codeDepartement;
        if (codeDep.Length == 1) codeDepartement = "0" + codeDep;
        else codeDepartement = codeDep;
        Connexion c = new Connexion();
        OdbcCommand commande = new OdbcCommand();
        commande.CommandText = "select * from departement where departement_code = ?";
        OdbcParameter paramCodeDep = new OdbcParameter("", DbType.String);
        paramCodeDep.Value = codeDepartement;
        commande.Parameters.Add(paramCodeDep);
        DataRow dr = c.exeRequetteParametree(commande).Tables[0].Rows[0];

        Emplacement dep = new Emplacement(true, dr["departement_nom"].ToString(), false, false, codeDep, new ListeEmplacementRecherche());
        emplacementAffiche.Add(dep);

        rafraichirEmplacementAffiche();
    }

	public void clear2(object sender, EventArgs e) {clear2();}
	
    public void clear2()
	{
		//Absurdite necessaire pour que la liste de lieu se raffraichisse sans avoir a rafraichir la page
		List<Emplacement> copie = new List<Emplacement>(emplacementAffiche);
        foreach (Emplacement ville in copie)
        {
			emplacementAffiche.Remove(ville);
        }
        rafraichirEmplacementAffiche();
	}
	
	//Ne semble pas raffraichir la liste de recherche, vu que la variable emplacementAffiche est passe a null
    public void clear()
    {
        Session["emplacementAffiche"] = null;
        Session["drcArrondissements"] = null;
        Session["drcAideVilles"] = null;
        Session["drcAidePays"] = null;
        Session["drcAideDep"] = null;
        Session["listeNoire"] = null;
        Session["listeArrondissementNoire"] = null;
        listeNoire = null;
        emplacementAffiche = null;
        listeArrondissementNoire = null;
        listeVilleRecherche = null;
        rafraichirEmplacementAffiche();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        TextBoxCible.Attributes.Add("onkeyup", "rechercheDiffereeTicket()");
        if (!IsPostBack && Request.Url.PathAndQuery.IndexOf("/ajout_acquereur.aspx") != -1 && Session["ajout_acquereur"] == "false")
        {
            Update_modifierAcquereur(sender, e);
        }
    }

    protected void Page_PreRender()
    {
        if (toutVirer == true)
        {
            //Page.ClientScript.RegisterStartupScript(GetType(), "viderTableAide", "viderTableAide();", true);
            TableAideRecherche.Visible = false;
            Session["TableAideRechercheVisible"] = false;
            //TableAideRecherche.Rows.Clear();
        }
        if (emplacementAffiche != null) Session["emplacementAffiche"] = emplacementAffiche;
        if (listeNoire != null) Session["listeNoire"] = listeNoire;
        Session["drcAideDep"] = drcAideDep;
        Session["drcAideVilles"] = drcAideVilles;
        Session["drcAidePays"] = drcAidePays;
        Session["drcArrondissements"] = drcArrondissements;
        if (TextBoxCible.Text != null) textBoxCibleAvant = TextBoxCible.Text;
        else textBoxCibleAvant = "";
        if (listeArrondissementNoire != null) Session["listeArrondissementNoire"] = listeArrondissementNoire;
		
		
		//Initialise les continents selectiones sur la carte
		bool initContinent = false;
		string jsCore = "";
		foreach (Emplacement ville in emplacementAffiche)
		{
			if(ville.IsContinent)
			{
				initContinent = true;
				jsCore += "WM_setSelected('" + ville.CodeINSEE + "');";
			}
		}
		
		if(initContinent == true)
		{
			string jsInit = "$(document).ready(function(){"
						+ jsCore
						+"});";
			ScriptManager.RegisterStartupScript(this, typeof(Page), "initContinent", jsInit, true);
			
		}
    }

    protected void Page_Init(object sender, EventArgs e)
    {
	
		//Permet de reinitialiser les criteres de recherche lorsque la page charge est ajout_acquereur.aspx
		//Mais de les conserver lorsqu'il s'agit de la page recherche
		if(!IsPostBack && (Session["bugfix_reset"] != null || Session["bugfix_reset2"] != null))
		{	
			Session["emplacementAffiche"] = null;
			Session["drcArrondissements"] = null;
			Session["drcAideVilles"] = null;
			Session["drcAidePays"] = null;
			Session["drcAideDep"] = null;
			Session["listeNoire"] = null;
			Session["listeArrondissementNoire"] = null;
			
			if(Session["bugfix_reset"] != null) Session["bugfix_reset2"] = true;
			else if (Session["bugfix_reset2"] != null) Session["bugfix_reset2"] = null;
			
			Session["bugfix_reset"] = null;
		}
		
        //ce qui est en commentaire permet d eviter que le controleur conserve ses valeurs d une page a l autre, fonction desactivée sur demande
        //if (!IsPostBack) Session["emplacementAffiche"] = null;// ici
        if (Session["emplacementAffiche"] != null) emplacementAffiche = (ListeEmplacement)Session["emplacementAffiche"];
        if (textBoxCibleAvant == null) textBoxCibleAvant = "";
        /*if (!IsPostBack) Session["drcArrondissements"] = null;// ici
        if (!IsPostBack) Session["drcAideVilles"] = null;// ici
        if (!IsPostBack) Session["drcAidePays"] = null;// ici
        if (!IsPostBack) Session["drcAideDep"] = null;// ici 
        if (!IsPostBack) Session["listeNoire"] = null;// ici*/
        if (Session["listeNoire"] != null) listeNoire = (ListeEmplacementRecherche)Session["listeNoire"];
        //if (!IsPostBack) Session["listeArrondissementNoire"] = null;// et ici
        if (Session["listeArrondissementNoire"] != null) listeArrondissementNoire = (List<Arrondissement>)Session["listeArrondissementNoire"];

    }
   
    //Remplie les criteres de localisation avec celles de la recherche precedente
    public void UpdatePanel1_Init(object sender, EventArgs e)
    {
        string eventTarget = this.Request.Params.Get("__EVENTTARGET");
        string eventArgument = this.Request.Params.Get("__EVENTARGUMENT");
        //jsp
        TableAideRecherche.Rows.Clear();
        if (eventTarget == TextBoxCible.UniqueID)
        {
            if (eventArgument != textBoxCibleAvant && eventArgument != null)
            {
                Session["TableAideRechercheVisible"] = true;
				if (Session["drcAideContinent"] != null) Session["drcAideContinent"] = null;
                if (Session["drcAideVilles"] != null) Session["drcAideVilles"] = null;
                if (Session["drcAidePays"] != null) Session["drcAidePays"] = null;
                if (Session["drcAideDep"] != null) Session["drcAideDep"] = null;
                if (Session["drcArrondissements"] != null) Session["drcArrondissements"] = null;

                string text = eventArgument;

                recupererVilleOuDep(text);
            }
        }

        remplirTableAide();
        
    }

    protected void Update_modifierAcquereur(object sender, EventArgs e)
    {
        //id acquereur
        string idAcq = (string)Session["ajout_acquereur_id"];
        string requete = "SELECT cible FROM Acquereurs WHERE `id_acq`=" + idAcq + "";

        System.Data.DataSet ds = null;
        Connexion c = null;

        c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();
        ds = c.exeRequette(requete);
        c.Close();
        c = null;
        System.Data.DataRowCollection dr = ds.Tables[0].Rows;

		Regex regexPays = new Regex("%type:pays%");
        Regex regexVille = new Regex("%type:vil%");
        Regex regexDep = new Regex("%type:dep%");
        Regex regexArr = new Regex("%arr:");

        String cibles = "";
        foreach (System.Data.DataRow ligne in dr)
        {
            cibles = ligne["cible"].ToString();
        }
        string[] cible = cibles.Split('|');
        int k;
        ClickableTableCell cell = new ClickableTableCell();
        for (int i = 0; i < cible.Length-1; i++)                          // i = boucle des villes ou département d'un acquereur
        {
			string currentCible = cible[i];
            cible[i].Trim();
            cible[i] = cible[i].Replace("type:pays", "");
            cible[i] = cible[i].Replace("type:dep", "");
            cible[i] = cible[i].Replace("type:vil", "");

            string[] temp = cible[i].Split('%');
            string[] cibleInfo = new string[4];
            k = 0;
            for (int j = 0; j < temp.Length; j++)                          // j = boucle des données de la ville i de l'acquereur
            {
                if (temp[j] != "")
                {
                    cibleInfo[k] = temp[j];
                    k++;
                }
            }
            string cibleCode = cibleInfo[0].Split(':')[1];                          // code de la ville ou du département i de l'acquereur
            string cibleNom = cibleInfo[1].Split(':')[1];                          // nom de la ville ou du département i de l'acquereur
            string cibleCP = "";
			if(cibleInfo[2] != null) cibleCP = cibleInfo[2].Split(':')[1];                            // CP de la ville ou du département i de l'acquereur
            string cibleArr = "";
            if(cibleInfo[3] != null) cibleArr = cibleInfo[3].Split(':')[1];         // Arrondissement de la ville i de l'acquereur

			if(regexPays.IsMatch(currentCible))
            {
                List<Arrondissement> listeArrondissement = null;
                ListeEmplacementRecherche listeVille = new ListeEmplacementRecherche();
                Emplacement toto = new Emplacement(false, cibleNom, false, false, cibleCode, listeVille, cibleCP, 0, listeArrondissement);
				toto.IsPays = true;
                emplacementAffiche.Add(toto);
            }
            if(regexVille.IsMatch(currentCible) && !regexArr.IsMatch(currentCible))
            {
                List<Arrondissement> listeArrondissement = null;
                ListeEmplacementRecherche listeVille = new ListeEmplacementRecherche();
                Emplacement toto = new Emplacement(false, cibleNom, false, false, cibleCode, listeVille, cibleCP, 0, listeArrondissement);
                emplacementAffiche.Add(toto);
            }
            else if (regexDep.IsMatch(currentCible))
            {
                List<Arrondissement> listeArrondissement = null;
                ListeEmplacementRecherche listeVille = new ListeEmplacementRecherche();
                Emplacement toto = new Emplacement(true, cibleNom, false, false, cibleCode, listeVille, cibleCP, 0, listeArrondissement);
                emplacementAffiche.Add(toto);
            }
            else if (regexArr.IsMatch(currentCible))
            {
                List<Arrondissement> listeArrondissement = new List<Arrondissement>();
                listeArrondissement = construireListeArrond(cibleCode);
                ListeEmplacementRecherche listeVille = new ListeEmplacementRecherche();
                Emplacement toto = new Emplacement(false, cibleNom, false, true, cibleCode, listeVille, cibleCP, 0, listeArrondissement);
                toto.HasArrondissement = true;
                emplacementAffiche.Add(toto);
            }
        }
        rafraichirEmplacementAffiche();

    }
	
	//liste deroulante
    protected void UpdatePanel1_Load(object sender, EventArgs e)
    {
        if (Session["TableAideRechercheVisible"] != null) TableAideRecherche.Visible = (bool)Session["TableAideRechercheVisible"];
        int numLigne = 0;
        if (Session["drcAideDep"] != null || drcAideDep != null)
        {
            if (drcAideDep == null) drcAideDep = (DataRowCollection)Session["drcAideDep"];
            foreach (DataRow dr in drcAideDep)
            {
                ClickableTableCell cell = (ClickableTableCell)TableAideRecherche.Rows[numLigne].Cells[0];


                cell.type = "dep";
                cell.nom = dr["departement_nom"].ToString();
                cell.codeVille = dr["departement_code"].ToString();
                cell.Text = dr["departement_nom"] + " (" + dr["departement_code"] + ")";
                cell.Click += new EventHandler(remplirListeEmplacement);
                cell.Attributes.Add("runat", "server");
                numLigne++;
            }
        }
		if (Session["drcAidePays"] != null || drcAidePays != null)
        {
            if (drcAidePays == null) drcAidePays = (DataRowCollection)Session["drcAidePays"];
            foreach (DataRow dr in drcAidePays)
            {
                ClickableTableCell cell = (ClickableTableCell)TableAideRecherche.Rows[numLigne].Cells[0];

                cell.type = "pays";
				cell.nom = dr["Titre_Pays"].ToString().ToUpper();
                cell.codeVille = dr[0].ToString();
                cell.Text =  cell.nom.ToUpper();
                cell.Click += new EventHandler(remplirListeEmplacement);
                cell.Attributes.Add("runat", "server");
                numLigne++;
            }
        }
        if (Session["drcAideVilles"] != null || drcAideVilles != null)
        {
            if (drcAideVilles == null) drcAideVilles = (DataRowCollection)Session["drcAideVilles"];
            foreach (DataRow dr in drcAideVilles)
            {
                ClickableTableCell cell = (ClickableTableCell)TableAideRecherche.Rows[numLigne].Cells[0];
                cell.nom = dr["Nom"].ToString();
                cell.CP = dr["Code Postal"].ToString();
                cell.type = "ville";
                cell.codeVille = dr["Code INSEE"].ToString();
                cell.Text =(dr["Code Postal"].ToString().Length > 5)
                    ? (dr["Nom"] + " (Tous codes postaux)")
                    : (dr["Nom"] + " (" + dr["Code Postal"] + ")");
                cell.Click += new EventHandler(remplirListeEmplacement);
                cell.Attributes.Add("runat", "server");
                numLigne++;
            }
        }
        if (Session["drcArrondissements"] != null || drcArrondissements != null)
        {
            if (drcArrondissements == null) drcArrondissements = (DataRowCollection)Session["drcArrondissements"];
            foreach (DataRow dr in drcArrondissements)
            {
                ClickableTableCell cell = (ClickableTableCell)TableAideRecherche.Rows[numLigne].Cells[0];

                cell.nom = dr["Nom"].ToString();
                cell.CP = dr["Code Postal"].ToString();
                cell.type = "arrondissement";
                cell.codeVille = dr["VilleINSEE"].ToString();
                cell.Text = dr["Nom"] + " (" + dr["Code Postal"] + ")";
                cell.Click += new EventHandler(remplirListeEmplacement);
                cell.Attributes.Add("runat", "server");
                numLigne++;
            }
        }
        rafraichirEmplacementAffiche();
    }

	//Requete SQL pour afficher la liste des villes/dep/pays correspondant a la saisie dans le champ cible
    protected void recupererVilleOuDep(string text)
    {
        int num;
        //si on cherche par ville/CP et distance
        if (text != "")
        {
            OdbcCommand rechercherDep = new OdbcCommand();
            OdbcCommand rechercherVille = new OdbcCommand();
			OdbcCommand rechercherPays = new OdbcCommand();
            OdbcCommand rechercheArrondissement = new OdbcCommand();
			
            rechercherDep.CommandText = "";
            rechercherVille.CommandText = "";
            rechercherPays.CommandText = "";
            rechercheArrondissement.CommandText = "";
            
			if (Int32.TryParse(text, out num))
            {
                //le champ cible est un nombre
                if (text.Trim().Length <= 2)//si departement
                {
                    rechercherDep.CommandText = "select * from departement where [departement_code] like ?";
                    OdbcParameter paramDep = new OdbcParameter("", DbType.String);
                    paramDep.Value = text + "%";
                    rechercherDep.Parameters.Add(paramDep);
                }
                if (text.Trim().Length <= 5)//si code postal
                {
                    rechercheArrondissement.CommandText = "select * from Arrondissement where [Code Postal] like ?";
                    OdbcParameter paramCPArr = new OdbcParameter("", DbType.String);
                    paramCPArr.Value = text + "%";
                    rechercheArrondissement.Parameters.Add(paramCPArr);

                }
                rechercherVille.CommandText = "select * from Ville where [Code Postal] like ? order by Nom";
                OdbcParameter paramCP = new OdbcParameter("", DbType.String);

                if (text.Trim().Length == 5) paramCP.Value = "%" + text + "%";
                else paramCP.Value = text + "%";

                rechercherVille.Parameters.Add(paramCP);

            }
            else//le champ cible est une string
            {


				//Recherche Pays
				rechercherPays.CommandText = "select * from Pays where UCase(Titre_Pays) like ? order by Titre_Pays";
                OdbcParameter paramPays = new OdbcParameter("", DbType.String);
                paramPays.Value = "%" + text.ToUpper() + "%";
                rechercherPays.Parameters.Add(paramPays);

                //Recherche ville
				rechercherVille.CommandText = "select * from Ville where UCase(NOM) like ? OR MAJ like ? order by Nom";
                OdbcParameter paramNom = new OdbcParameter("", DbType.String);
                paramNom.Value = "%" + text.ToUpper() + "%";
                OdbcParameter paramNomBis = new OdbcParameter("", DbType.String);
                paramNomBis.Value = "%" + text.ToUpper() + "%";
                rechercherVille.Parameters.Add(paramNom);
                rechercherVille.Parameters.Add(paramNomBis);
                
                //Recheche Arrondissement
                rechercheArrondissement.CommandText = "select * from Arrondissement where UCase(Nom) like ?  order by Nom";
                OdbcParameter paramCPArr = new OdbcParameter("", DbType.String);
                paramCPArr.Value = "%" + text.ToUpper() + "%";
                rechercheArrondissement.Parameters.Add(paramCPArr);
                
                //Recherche departement
                rechercherDep.CommandText = "select * from departement where departement_nom_uppercase like ? order by departement_nom";
                OdbcParameter paramDep = new OdbcParameter("", DbType.String);
                paramDep.Value = "%" + text + "%";
                rechercherDep.Parameters.Add(paramDep);
                

            }

            Connexion c = new Connexion();

            //cas ou la recherche se fait par arrondissement
            if (rechercheArrondissement.CommandText != "") drcArrondissements = c.exeRequetteParametree(rechercheArrondissement).Tables[0].Rows;

            //cas ou la recherche se fait par ville
            if (rechercherVille.CommandText != "") drcAideVilles = c.exeRequetteParametree(rechercherVille).Tables[0].Rows;
			
            if (rechercherPays.CommandText != "") drcAidePays = c.exeRequetteParametree(rechercherPays).Tables[0].Rows;

            //cas ou la recherche se fait par departement
            if (rechercherDep.CommandText != "") drcAideDep = c.exeRequetteParametree(rechercherDep).Tables[0].Rows;
            c.Close();
        }
    }


    //
    protected void remplirTableAide()
    {
        if (Session["drcAideDep"] != null || drcAideDep != null)
        {
            if (drcAideDep == null) drcAideDep = (DataRowCollection)Session["drcAideDep"];
            foreach (DataRow dr in drcAideDep)
            {
                ClickableTableCell cell = new ClickableTableCell();
                cell.CssClass = "ajouterAcquereur_ClickableCell bold";
                TableRow tr = new TableRow();
                tr.Cells.Add(cell);
                TableAideRecherche.Rows.Add(tr);

                UpdatePanelControlTrigger trigger = new AsyncPostBackTrigger();
                trigger.ControlID = cell.UniqueID;
                UpdatePanel1.Triggers.Add(trigger);

            }
        }
        		if (Session["drcAidePays"] != null || drcAidePays != null)
        {
            if (drcAidePays == null) drcAidePays = (DataRowCollection)Session["drcAidePays"];
            foreach (DataRow dr in drcAidePays)
            {
                ClickableTableCell cell = new ClickableTableCell();
                cell.CssClass = "ajouterAcquereur_ClickableCell bold";
                TableRow tr = new TableRow();
                tr.Cells.Add(cell);
                TableAideRecherche.Rows.Add(tr);

                UpdatePanelControlTrigger trigger = new AsyncPostBackTrigger();
                trigger.ControlID = cell.UniqueID;
                UpdatePanel1.Triggers.Add(trigger);

            }
        }
        if (Session["drcAideVilles"] != null || drcAideVilles != null)
        {
            if (drcAideVilles == null) drcAideVilles = (DataRowCollection)Session["drcAideVilles"];
            foreach (DataRow dr in drcAideVilles)
            {
                ClickableTableCell cell = new ClickableTableCell();
                cell.CssClass = "ajouterAcquereur_ClickableCell";
                TableRow tr = new TableRow();
                tr.Cells.Add(cell);
                TableAideRecherche.Rows.Add(tr);

                UpdatePanelControlTrigger trigger = new AsyncPostBackTrigger();
                trigger.ControlID = cell.UniqueID;
                UpdatePanel1.Triggers.Add(trigger);

            }
        }
        if (Session["drcArrondissements"] != null || drcArrondissements != null)
        {
            if (drcArrondissements == null) drcArrondissements = (DataRowCollection)Session["drcArrondissements"];
            foreach (DataRow dr in drcArrondissements)
            {
                ClickableTableCell cell = new ClickableTableCell();
                cell.CssClass = "ajouterAcquereur_ClickableCell";
                TableRow tr = new TableRow();
                tr.Cells.Add(cell);
                TableAideRecherche.Rows.Add(tr);

                UpdatePanelControlTrigger trigger = new AsyncPostBackTrigger();
                trigger.ControlID = cell.UniqueID;
                UpdatePanel1.Triggers.Add(trigger);

            }
        }
    }

    //fonction que la cellule execute lors d un clic
    protected void remplirListeEmplacement(object sender, EventArgs e)
    {
        ClickableTableCell cell = (ClickableTableCell)sender;
        if (cell.type == "ville")
        {
            bool hasdistance = false;
            if (Convert.ToInt32(HiddenField2.Text) != 0)
            {
                hasdistance = true;
            }
            string codeINSEE = cell.codeVille;
            Emplacement ville;

            bool hasArrondissement = false;
            List<Arrondissement> listeArrond = null;
            if (cell.CP.Length > 5)
            {
                hasArrondissement = true;
                listeArrond = construireListeArrond(cell.codeVille);
            }

            List<Ville> listeINSEE = PATRIMO.Outils.OutilsDistance.villeINSEEListeDistance(cell.codeVille, Convert.ToInt32(HiddenField2.Text));
            ListeEmplacementRecherche listeER = convertListeVilleToListeEmplacement(listeINSEE);
            ville = new Emplacement(false, cell.nom, hasdistance, hasArrondissement, cell.codeVille, listeER, cell.CP, Convert.ToInt32(HiddenField2.Text), listeArrond);


            emplacementAffiche.Add(ville);

            rechargerListeERDansEmplacement(ville.CodeINSEE);	

        }
		else if (cell.type == "pays")
		{
			string codePays = cell.codeVille;
			Emplacement pays = new Emplacement(false, cell.nom, false, false, codePays, new ListeEmplacementRecherche());
			pays.IsPays = true;
			emplacementAffiche.Add(pays);
		}
        else if (cell.type == "dep")
        {
            string codeDep = cell.codeVille;
            Emplacement dep = new Emplacement(true, cell.nom, false, false, codeDep, new ListeEmplacementRecherche());
            emplacementAffiche.Add(dep);

        }
        else if (cell.type == "arrondissement")
        {
            //si ville pas deja recherché: ajouter ville et bannnir tout les arrondissement sauf celui la
            //si ville existe deja, retirer arrondissement de la liste noir et recharger
            bool villeExiste = false;
            foreach (Emplacement empl in emplacementAffiche)
            {
                if (empl.CodeINSEE == cell.codeVille)
                {
                    villeExiste = true;
                    break;
                }
            }
            if (villeExiste)
            {
                foreach (Arrondissement arr in listeArrondissementNoire)
                {
                    if (arr.CP == cell.CP)
                    {
                        listeArrondissementNoire.Remove(arr);
                        break;
                    }
                }
                rafraichirArrondissement();
            }
            else
            {
                // la ville n est pas deja enrengsitrée

                bool hasdistance = false;
                if (Convert.ToInt32(HiddenField2.Text) != 0)
                {
                    hasdistance = true;
                }
                string codeINSEE = cell.codeVille;
                Emplacement ville;

                List<Arrondissement> listeArrond = null;

                bool hasArrondissement = true;
                listeArrond = construireListeArrond(cell.codeVille);

                foreach (Arrondissement arr in listeArrond)
                {
                    if (arr.CP == cell.CP)
                    {
                        listeArrond.Remove(arr);
                        break;
                    }
                }

                foreach (Arrondissement arr in listeArrond)
                {
                    listeArrondissementNoire.Add(arr);
                }
                listeArrond = construireListeArrond(cell.codeVille);

                string[] nomSplit = cell.nom.Split(' ');
                string nom = "";
                for (int i = 0; i < nomSplit.Length - 1; i++)
                {
                    nom += nomSplit[i];
                }

                List<Ville> listeINSEE = PATRIMO.Outils.OutilsDistance.villeINSEEListeDistance(cell.codeVille, Convert.ToInt32(HiddenField2.Text));
                ListeEmplacementRecherche listeER = convertListeVilleToListeEmplacement(listeINSEE);
                ville = new Emplacement(false, nom, hasdistance, hasArrondissement, cell.codeVille, listeER, cell.CP, Convert.ToInt32(HiddenField2.Text), listeArrond);


                emplacementAffiche.Add(ville);
            }

            rechargerListeERDansEmplacement(cell.codeVille);
        }

        rafraichirEmplacementAffiche();
        toutVirer = true;
    }

    protected void supprimerVille(object sender, EventArgs e)
    {
        string code = ((MemoryButton)sender).code;
        List<Emplacement> copie = new List<Emplacement>(emplacementAffiche);
        foreach (Emplacement ville in copie)
        {
            if (ville.CodeINSEE == code) 
			{
				emplacementAffiche.Remove(ville);
			}
        }
        //rettirer les arrondissement correspondant de la liste noire
        Connexion c = new Connexion();
        OdbcCommand selectArrond = new OdbcCommand();
        selectArrond.CommandText = "select * from arrondissement where VilleINSEE = ?";
        OdbcParameter paramINSEE = new OdbcParameter("", OdbcType.VarChar);
        paramINSEE.Value = code;
        selectArrond.Parameters.Add(paramINSEE);
        DataRowCollection drc = c.exeRequetteParametree(selectArrond).Tables[0].Rows;
        foreach (DataRow dr in drc)
        {
            foreach (Arrondissement arrNoir in listeArrondissementNoire)
            {
                if (arrNoir.CP == dr["Code Postal"].ToString())
                {
                    listeArrondissementNoire.Remove(arrNoir);
                    break;
                }
            }
        }

        rafraichirEmplacementAffiche();
    }

	//S'occupe de l'affichage des villes/departements selectionnes
    protected void rafraichirEmplacementAffiche()
    {
        TableSelectionSimple.Rows.Clear();
        int index = 0;
        if (emplacementAffiche != null)
        {
           foreach (Emplacement ville in emplacementAffiche)
           {
				
				
                TableRow row = new TableRow();
                TableSelectionSimple.Rows.Add(row);
                TableCell cellPrincipale = new TableCell();
                row.Controls.Add(cellPrincipale);

                Table tableVisible = new Table();
                cellPrincipale.Controls.Add(tableVisible);
                TableRow rowUniqueVisible = new TableRow();
                tableVisible.Controls.Add(rowUniqueVisible);

                TableCell cell1 = new TableCell();
                rowUniqueVisible.Cells.Add(cell1);
                TableCell cell2 = new TableCell();
                rowUniqueVisible.Cells.Add(cell2);
                TableCell cell3 = new TableCell();
                rowUniqueVisible.Cells.Add(cell3);

                if (ville.ListeVille.Count > 1)
                {
                    ImageButton bouttonAfficherDetail = new ImageButton();
                    bouttonAfficherDetail.ImageUrl = @"~\img_site\fleche_tri_bas.png";
                    bouttonAfficherDetail.ID = index + "bouttonaffichageDetail" + ville.CodeINSEE;
                    cell1.Controls.Add(bouttonAfficherDetail);
                    bouttonAfficherDetail.OnClientClick = "derouleDetaille(this); return false;";
                    ImageButton bouttonEffacerDetail = new ImageButton();
                    bouttonEffacerDetail.CssClass = "invisible";
                    bouttonEffacerDetail.ImageUrl = @"~\img_site\fleche_tri_haut.png";
                    bouttonEffacerDetail.ID = index + "bouttonEffacerDetail" + ville.CodeINSEE;
                    cell1.Controls.Add(bouttonEffacerDetail);
                    bouttonEffacerDetail.OnClientClick = "EnrouleDetaille(this); return false;";
                }

                MemoryButton boutonSuppr = new MemoryButton();
                cell1.Controls.Add(boutonSuppr);
                boutonSuppr.code = ville.CodeINSEE;
				if(ville.IsContinent)
					boutonSuppr.OnClientClick = "WM_setUnselected('" + ville.CodeINSEE + "')";	//fonction javascript
                boutonSuppr.Click += new ImageClickEventHandler(supprimerVille);
                boutonSuppr.ID = index + "bouttonSuppr" + boutonSuppr.code;
                UpdatePanelControlTrigger trigger = new AsyncPostBackTrigger();
                trigger.ControlID = boutonSuppr.ID;
                UpdatePanel1.Triggers.Add(trigger);

                boutonSuppr.AlternateText = "suppr ";
                boutonSuppr.ImageUrl = @"~\img_site\boutton_Supprimer.png";
                //gestion affichage de l emplacement
                //nom
                Label labelNom = new Label();
                labelNom.Text = ville.Nom;
                cell2.Controls.Add(labelNom);
                //CP(s)
                if (ville.HasArrondissement)
                {
                    cell3.Controls.Add(new LiteralControl("<div class='contientCelluleArrondissement'>"));
                    cell3.Controls.Add(new LiteralControl("<div class=\"celuleArrondissement\">"));
                    foreach (Arrondissement arr in ville.ListeArrondissement)
                    {
                        cell3.Controls.Add(new LiteralControl("<div class=\"AjoutacquereurCellulleListeVille\">"));
                        //le boutton supprimer
                        MemoryButton buttonsupprArrond = new MemoryButton();
                        cell3.Controls.Add(buttonsupprArrond);
                        buttonsupprArrond.code = arr.CP;
                        buttonsupprArrond.Click += new ImageClickEventHandler(ajouterArrondissementALaListeNoire);
                        buttonsupprArrond.ID = index + "buttonsupprArrond" + buttonsupprArrond.code;
                        UpdatePanelControlTrigger trigg = new AsyncPostBackTrigger();
                        trigg.ControlID = buttonsupprArrond.ID;
                        UpdatePanel1.Triggers.Add(trigg);
                        buttonsupprArrond.AlternateText = "suppr ";
                        buttonsupprArrond.ImageUrl = @"~\img_site\boutton_Supprimer.png";

                        //le cp
                        Label labelCP = new Label();
                        labelCP.Text = arr.CP + "  ";
                        cell3.Controls.Add(labelCP);
                        cell3.Controls.Add(new LiteralControl("</div>"));
                    }
                    cell3.Controls.Add(new LiteralControl("<div style='clear:both'></div>"));
                    cell3.Controls.Add(new LiteralControl("</div>"));
                    cell3.Controls.Add(new LiteralControl("</div>"));
                }
                else if(ville.IsPays == false && ville.IsContinent == false)
                {
                    Label labelCP = new Label();
					labelCP.Text = "  " + ville.CP;
                    cell3.Controls.Add(labelCP);
                }
                //distance
                if (ville.HasDistance)
                {
                    Label labelDistance = new Label();
                    labelDistance.Text = " (~ " + ville.Distance + " km)";
                    LiteralControl br = new LiteralControl("<br/>");
                    cell2.Controls.Add(br);
                    cell2.Controls.Add(labelDistance);
                }
                
                index++;

                //liste detaillé pour cet emplacement
                Panel divListeInvisible = new Panel();
                divListeInvisible.CssClass = "invisible AjoutacquereurScrollCellPetit teuteu";
                divListeInvisible.ID = "teuteuInvisible" + ville.CodeINSEE;
                cellPrincipale.Controls.Add(divListeInvisible);

                Table tableSelectionIntermediaire = new Table();
                divListeInvisible.Controls.Add(tableSelectionIntermediaire);

                //panneau detaillé caché par defaut
                foreach (EmplacementRecherche ER in ville.ListeVille)
                {
                    TableRow ligne = new TableRow();
                    tableSelectionIntermediaire.Rows.Add(ligne);
                    TableCell cellIntermediaire1 = new TableCell();
                    ligne.Cells.Add(cellIntermediaire1);
                    TableCell cellIntermediaire2 = new TableCell();
                    ligne.Cells.Add(cellIntermediaire2);
                    TableCell cellIntermediaire3 = new TableCell();
                    ligne.Cells.Add(cellIntermediaire3);

                    MemoryButton buttonsuppr = new MemoryButton();
                    buttonsuppr.AlternateText = "suppr ";
                    buttonsuppr.ImageUrl = @"~\img_site\boutton_Supprimer.png";
                    buttonsuppr.code = ER.CodeINSEE;
                    cellIntermediaire1.Controls.Add(buttonsuppr);
                    buttonsuppr.ID = ville.CodeINSEE + "btnsupprLI" + buttonsuppr.code;

                    UpdatePanelControlTrigger triggerInter = new AsyncPostBackTrigger();
                    triggerInter.ControlID = buttonsuppr.ID;
                    UpdatePanel1.Triggers.Add(triggerInter);
                    buttonsuppr.Click += new ImageClickEventHandler(AjouterALaListeNoire);

                    Label labelNomInter = new Label();
                    labelNomInter.Text = ER.Nom;
                    cellIntermediaire2.Controls.Add(labelNomInter);

                    if (ER.HasArrondissement)
                    {
                        cellIntermediaire3.Controls.Add(new LiteralControl("<div class='contientCelluleArrondissement'>"));
                        cellIntermediaire3.Controls.Add(new LiteralControl("<div class=\"celuleArrondissement\">"));
                        foreach (Arrondissement arr in ER.ListeArrondissement)
                        {
                            cellIntermediaire3.Controls.Add(new LiteralControl("<div class=\"AjoutacquereurCellulleListeVille\">"));
                            //le boutton supprimer
                            MemoryButton buttonsupprArrond = new MemoryButton();
                            cellIntermediaire3.Controls.Add(buttonsupprArrond);
                            buttonsupprArrond.code = arr.CP;
                            buttonsupprArrond.Click += new ImageClickEventHandler(ajouterArrondissementALaListeNoire);
                            buttonsupprArrond.ID = ville.CodeINSEE + "et" + ER.CodeINSEE + "buttonsupprArrondIntermediaire" + buttonsupprArrond.code;
                            UpdatePanelControlTrigger trigg = new AsyncPostBackTrigger();
                            trigg.ControlID = buttonsupprArrond.ID;
                            UpdatePanel1.Triggers.Add(trigg);
                            buttonsupprArrond.AlternateText = "suppr ";
                            buttonsupprArrond.ImageUrl = @"~\img_site\boutton_Supprimer.png";

                            //le cp
                            Label labelCP = new Label();
                            labelCP.Text = arr.CP;
                            cellIntermediaire3.Controls.Add(labelCP);
                            cellIntermediaire3.Controls.Add(new LiteralControl("</div>"));
                        }
                        cellIntermediaire3.Controls.Add(new LiteralControl("</div>"));
                        cellIntermediaire3.Controls.Add(new LiteralControl("</div>"));
                    }
                    else
                    {
                        Label labelCP = new Label();
                        labelCP.Text = ER.CP;
                        cellIntermediaire3.Controls.Add(labelCP);
                    }

                }

            }
        }
        rafraichirListeEmplacementRecherche();
    }

    protected void rafraichirListeEmplacementRecherche()
    {
        Connexion c = new Connexion();
        if (listeVilleRecherche != null) listeVilleRecherche.Clear();
        if (emplacementAffiche != null)
        {
            foreach (Emplacement lieu in emplacementAffiche)
            {
                if (lieu.Dep == false && lieu.IsPays == false && lieu.IsContinent == false)
                {
                    List<Ville> listeINSEE = PATRIMO.Outils.OutilsDistance.villeINSEEListeDistance(lieu.CodeINSEE, lieu.Distance);
                    foreach (Ville ville in listeINSEE)
                    {
                        bool noir = false;
                        foreach (EmplacementRecherche ER in listeNoire)
                        {
                            if (ER.CodeINSEE == ville.insee) noir = true;
                        }
                        if (noir == false)
                        {
                            bool hasArrondissement = false;
                            List<Arrondissement> listeArrond = null;
                            if (ville.cp.Length > 5)
                            {
                                hasArrondissement = true;
                                listeArrond = construireListeArrond(ville.insee);
                            }
                            EmplacementRecherche newER = new EmplacementRecherche(false, hasArrondissement, ville.insee, ville.nom, ville.cp, listeArrond);
                            listeVilleRecherche.Add(newER);
                        }
                    }
                }
				else if(lieu.IsPays == true)
				{
					EmplacementRecherche newER = new EmplacementRecherche(true, false, lieu.CodeINSEE, lieu.Nom);
					newER.IsPays = true;	
					listeVilleRecherche.Add(newER);
				}
				else if(lieu.IsContinent == true)
				{
					EmplacementRecherche newER = new EmplacementRecherche(true, false, lieu.CodeINSEE, lieu.Nom);
					newER.IsContinent = true;	
					listeVilleRecherche.Add(newER);
				}
                else
                {
                    EmplacementRecherche newER = new EmplacementRecherche(true, false, lieu.CodeINSEE, lieu.Nom);
                    listeVilleRecherche.Add(newER);
                }
            }
        }
        rafraichirAffichageAvance();
    }

    protected void rafraichirAffichageAvance()
    {
        //affichage listeRecherche
        TableSelectionAvance.Rows.Clear();
        TableListeNoire.Rows.Clear();
        if (listeVilleRecherche != null)
        {
            foreach (EmplacementRecherche ER in listeVilleRecherche)
            {
                TableRow ligne = new TableRow();
                TableSelectionAvance.Rows.Add(ligne);
                TableCell cell1 = new TableCell();
                ligne.Cells.Add(cell1);
                TableCell cell2 = new TableCell();
                ligne.Cells.Add(cell2);
                TableCell cell3 = new TableCell();
                ligne.Cells.Add(cell3);

                MemoryButton buttonsuppr = new MemoryButton();
                buttonsuppr.AlternateText = "suppr ";
                buttonsuppr.ImageUrl = @"~\img_site\boutton_Supprimer.png";
                buttonsuppr.code = ER.CodeINSEE;
                cell1.Controls.Add(buttonsuppr);
                buttonsuppr.ID = "btnsupprLA" + buttonsuppr.code;

                UpdatePanelControlTrigger trigger = new AsyncPostBackTrigger();
                trigger.ControlID = buttonsuppr.ID;
                UpdatePanel1.Triggers.Add(trigger);
                buttonsuppr.Click += new ImageClickEventHandler(AjouterALaListeNoire);

                Label labelNom = new Label();
                labelNom.Text = ER.Nom;
                cell2.Controls.Add(labelNom);

                if (ER.HasArrondissement)
                {
                    foreach (Arrondissement arr in ER.ListeArrondissement)
                    {
                        cell3.Controls.Add(new LiteralControl("<div class=\"AjoutacquereurCellulleListeVille\">"));
                        //le boutton supprimer
                        MemoryButton buttonsupprArrond = new MemoryButton();
                        cell3.Controls.Add(buttonsupprArrond);
                        buttonsupprArrond.code = arr.CP;
                        buttonsupprArrond.Click += new ImageClickEventHandler(ajouterArrondissementALaListeNoire);
                        buttonsupprArrond.ID = ER.CodeINSEE + "buttonsupprArrond" + buttonsupprArrond.code;
                        UpdatePanelControlTrigger trigg = new AsyncPostBackTrigger();
                        trigg.ControlID = buttonsupprArrond.ID;
                        UpdatePanel1.Triggers.Add(trigg);
                        buttonsupprArrond.AlternateText = "suppr ";
                        buttonsupprArrond.ImageUrl = @"~\img_site\boutton_Supprimer.png";

                        //le cp
                        Label labelCP = new Label();
                        labelCP.Text = arr.CP;
                        cell3.Controls.Add(labelCP);
                        cell3.Controls.Add(new LiteralControl("</div>"));
                    }
                }
                else
                {
                    Label labelCP = new Label();
                    labelCP.Text = ER.CP;
                    cell3.Controls.Add(labelCP);
                }

            }
        }

        if (listeNoire != null)
        {
            //affichage liste noire
            foreach (EmplacementRecherche ER in listeNoire)
            {
                TableRow ligne = new TableRow();
                TableListeNoire.Rows.Add(ligne);
                TableCell cell1 = new TableCell();
                ligne.Cells.Add(cell1);
                TableCell cell2 = new TableCell();
                ligne.Cells.Add(cell2);

                MemoryButton buttonsuppr = new MemoryButton();
                buttonsuppr.AlternateText = "suppr ";
                buttonsuppr.ImageUrl = @"~\img_site\boutton_Supprimer.png";
                buttonsuppr.code = ER.CodeINSEE;
                cell1.Controls.Add(buttonsuppr);
                buttonsuppr.ID = "btnsupprLN" + buttonsuppr.code;

                UpdatePanelControlTrigger trigger = new AsyncPostBackTrigger();
                trigger.ControlID = buttonsuppr.ID;
                UpdatePanel1.Triggers.Add(trigger);
                buttonsuppr.Click += new ImageClickEventHandler(RetirerDeLaListeNoire);

                Label label = new Label();
                label.Text = ER.Nom + " | " + ER.CP;
                cell2.Controls.Add(label);

            }
        }
    }

    protected void AjouterALaListeNoire(object sender, EventArgs e)
    {
        string code = ((MemoryButton)sender).code;
        EmplacementRecherche ERtrouve = null;

        foreach (Emplacement empl in emplacementAffiche)
        {
            foreach (EmplacementRecherche emplER in empl.ListeVille)
            {
                if (emplER.CodeINSEE == code)
                {
                    empl.ListeVille.Remove(emplER);
                    break;//unique
                }
            }
        }
        foreach (EmplacementRecherche ER in listeVilleRecherche)
        {
            if (ER.CodeINSEE == code)
            {
                ERtrouve = ER;
                break;//unique
            }
        }
        listeNoire.Add(ERtrouve);
        listeVilleRecherche.Remove(ERtrouve);
        rafraichirAffichageAvance();
        rafraichirEmplacementAffiche();
    }

    protected void RetirerDeLaListeNoire(Object sender, EventArgs e)
    {
        string code = ((MemoryButton)sender).code;
        EmplacementRecherche ERtrouve = null;

        rechargerListeERDansEmplacement();

        foreach (EmplacementRecherche ER in listeNoire)
        {
            if (ER.CodeINSEE == code)
            {
                ERtrouve = ER;
            }
        }
        listeVilleRecherche.Add(ERtrouve);
        listeNoire.Remove(ERtrouve);
        rafraichirAffichageAvance();
        rafraichirEmplacementAffiche();
    }

    protected List<Arrondissement> construireListeArrond(string INSEE)
    {
        Connexion c = new Connexion();
        OdbcCommand commande = new OdbcCommand();
        commande.CommandText = "select * from Arrondissement where VilleINSEE = ? ";
        OdbcParameter paramINSEE = new OdbcParameter("", DbType.String);
        paramINSEE.Value = INSEE;
        commande.Parameters.Add(paramINSEE);
        foreach (Arrondissement arrond in listeArrondissementNoire)
        {
            commande.CommandText += " AND [Code Postal] <> ? ";
            OdbcParameter paramCP = new OdbcParameter("", DbType.String);
            paramCP.Value = arrond.CP;
            commande.Parameters.Add(paramCP);
        }
        DataRowCollection drc = c.exeRequetteParametree(commande).Tables[0].Rows;
        List<Arrondissement> liste = new List<Arrondissement>();
        foreach (DataRow result in drc)
        {
            Arrondissement arr = new Arrondissement(result["Code Postal"].ToString());
            liste.Add(arr);
        }
        return liste;
    }

    protected void ajouterArrondissementALaListeNoire(object sender, EventArgs e)
    {
        //on difinie l arrondissement a retirer
        string CParrond = ((MemoryButton)sender).code;
        Arrondissement arr = new Arrondissement(CParrond);
        //on ajoute l arrondissement a la liste noire
        listeArrondissementNoire.Add(arr);
        //on retire l arrondissement dans les objet qui ne se rafraichissent pas au chargement
        foreach (Emplacement empl in emplacementAffiche)
        {
            foreach (EmplacementRecherche ER in empl.ListeVille)
            {
                if (empl.HasArrondissement)
                {
                    foreach (Arrondissement arrondissementDeEmplacement in ER.ListeArrondissement)
                    {
                        if (arrondissementDeEmplacement.CP == arr.CP)
                        {
                            empl.ListeArrondissement.Remove(arrondissementDeEmplacement);
                            break;
                        }
                    }
                }
            }
        }

        //on rafraichit
        rafraichirArrondissement();
    }

    protected void retirerArrondissementDelaListeNoire(Object sender, EventArgs e)
    {
        string CParrond = ((MemoryButton)sender).code;
        Arrondissement trouve = null;

        foreach (Arrondissement arr in listeArrondissementNoire)
        {
            if (arr.CP == CParrond)
            {
                trouve = arr;
                break;
            }
        }
        listeArrondissementNoire.Remove(trouve);
        rechargerListeERDansEmplacement();
        rafraichirArrondissement();
    }

    protected void rafraichirArrondissement()
    {
        foreach (Emplacement empl in emplacementAffiche)
        {
            if (empl.HasArrondissement)
            {
                empl.ListeArrondissement = construireListeArrond(empl.CodeINSEE);
            }

            foreach (EmplacementRecherche er in empl.ListeVille)
            {
                if (er.HasArrondissement)
                {
                    er.ListeArrondissement = construireListeArrond(er.CodeINSEE);
                }
            }

        }
        rafraichirEmplacementAffiche();
    }

    protected ListeEmplacementRecherche convertListeVilleToListeEmplacement(List<Ville> listeVille)
    {
        ListeEmplacementRecherche listeER = new ListeEmplacementRecherche();

        foreach (Ville ville in listeVille)
        {
            bool hasArrondissement = false;
            List<Arrondissement> listeArrond = null;
            if (ville.cp.Length > 5)
            {
                hasArrondissement = true;
                listeArrond = construireListeArrond(ville.insee);
            }
            EmplacementRecherche ER = new EmplacementRecherche(false, hasArrondissement, ville.insee, ville.nom, ville.cp, listeArrond);

            Boolean nePasMettre = false;
            foreach (EmplacementRecherche ERnoir in listeNoire)
            {
                if (ER.CodeINSEE == ERnoir.CodeINSEE)
                {
                    nePasMettre = true;
                    break;
                }
            }
            if (!nePasMettre) listeER.Add(ER);
        }

        return listeER;
    }

    protected void rechargerListeERDansEmplacement(string insee = null)
    {
        if (insee == null)
        {
            foreach (Emplacement empl in emplacementAffiche)
            {
                List<Ville> listeINSEE = PATRIMO.Outils.OutilsDistance.villeINSEEListeDistance(empl.CodeINSEE, empl.Distance);
                ListeEmplacementRecherche listeER = convertListeVilleToListeEmplacement(listeINSEE);
                empl.ListeVille = listeER;
            }
        }
        else
        {
            foreach (Emplacement empl in emplacementAffiche)
            {
                if (empl.CodeINSEE == insee)
                {
                    List<Ville> listeINSEE = PATRIMO.Outils.OutilsDistance.villeINSEEListeDistance(empl.CodeINSEE, empl.Distance);
                    ListeEmplacementRecherche listeER = convertListeVilleToListeEmplacement(listeINSEE);
                    empl.ListeVille = listeER;
                    break;
                }
            }
        }
    }

}