using System;
using System.Data;
using System.Data.Odbc;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Globalization;
using GestionEmplacement;

public partial class pages_rapprochement : System.Web.UI.Page
{
    public string ordre = "Biens.[code postal du bien], Biens.etat";
    public int nombreoffres = 0;
    public String selectedValue = "";

	//Parametre de la requete SQL, ne pas toucher
    public string typebien = "";
    public string nbpieces = "";
    public string nbchambres = "";
    public string depCP = "";
    public string surfacehab = "";
    public string surfacesej = "";
    public string surfaceter = "";
    public string ascenceur = "";
	public string parking = "";
	public string soussol = "";
    public string facade = "";
    public string profondeur = "";
    public string villes = "";
    public string cp = "";
    public string dep = "";
    public string prix = "";
    public string achatloc = "";
	public string typeAcquereur = "";

	
    public int intnbpiecesmin = 0;
    public int intnbpiecesmax = 999;
    public int intnbchambresmin = 0;
    public int intnbchambresmax = 999;
    public int intsurfhabmin = 0;
    public int intsurfhabmax = 999999;
    public int intsurfsejmin = 0;
    public int intsurfsejmax = 999999;
    public int intsurfmin = 0;
    public int intsurfmax = 999999;
    public int intprixmin = 0;
    public int intprixmax = 99999999;
	public int intprofondeur = 0;
	public int intfacade = 0;
	public string hasParking = "";
	public string hasAscenseur = "";
	public string hasSousSol = "";
	public bool LFAppartement;		//LookingForAppartement
	public bool LFMaison;
	public bool LFAutre;
	public bool LFTerrain;
	
    ListeEmplacementRecherche listeRecherche;
    List<BienRraprochement> listeBien;
    string mailAcquereur;

    protected void Page_Load(object sender, EventArgs e)
    {
		critere.Text = "";
        ((Label)Page.Master.FindControl("titrebandeau")).Text = "Mon compte";
        
        // permet le "Bonjour Mr X"
		Membre member = (Membre)Session["Membre"];
        constuireTableauAcquereur();
        OdbcCommand commandeAcquereur = construireRequeteBien();// crée la requete
        string requette = convertCommandeToString(commandeAcquereur);
        construireTableauBien(commandeAcquereur);// crée le tableau

        if (mailAcquereur == "")
        {
            CBCopieNego.Visible = false;
            LBLCopieNego.Visible = false;
            Button1.Visible = false;
        }

	}
    protected String convertCommandeToString(OdbcCommand commande)
    {
        string requette = "";
        requette = commande.CommandText;
        foreach (OdbcParameter param in commande.Parameters)
        {
            var regex = new Regex(Regex.Escape("?"));
            string remplacement;
            remplacement = "'" + param.Value.ToString().Replace("'","''") + "'";
            requette = regex.Replace(requette, remplacement, 1);
        }

        return requette;
    }
	
	protected string espaceTel(string telephone)
	{
		string tel = telephone.Replace(".","").Replace(" ","");
		string telFormat = "";
		int k = 0;
		while((k+1)*2 < tel.Length)
		{
			telFormat = telFormat + " "  + tel.Substring(k*2, 2);
			k++;
		}
		telFormat = telFormat + " "  +  tel.Substring(k*2, tel.Length - k*2);
		
		return telFormat;
	}
	
	private string espacePrix(string prix)
	{
		string prixFormat = "";
		int k = 0;
		
		while((k+1)*3 < prix.Length)
		{
			prixFormat = prix.Substring((prix.Length -(k+1)*3), 3) + " " +prixFormat;
			k++;
		}
		prixFormat = prix.Substring(0, prix.Length - k*3) + " " +prixFormat;
		
		return prixFormat;
	}
	
	private void ajouterCritere(string name, string valueList, bool IsNote = false)
	{
		string[] value = valueList.Split(new string[] {","}, StringSplitOptions.RemoveEmptyEntries);
		if(critere.Text != "") 
			critere.Text += "<div style='display:inline-block;vertical-align:top;margin-left:30px;font-weight:bold;text-align:left;'>";
		else 
			critere.Text += "<div style='display:inline-block;vertical-align:top;font-weight:bold;'>";
		critere.Text += name;
		critere.Text += "</div>";
		
		if(!IsNote) critere.Text += "<div style='display:inline-block;vertical-align:top;margin-left:10px;text-align:left;'>";
		else 		critere.Text += "<div style='display:inline-block;vertical-align:top;margin-left:10px;text-align:left;width:150px;'>";
		critere.Text += value[0];
		for(int i = 1; i<value.Length; i++)
			critere.Text += "<br/>" + value[i];
		critere.Text += "</div>";
	}
	
	private string parserCible(string cible)
	{
		string[] champCible = new string[]{"",""};
		string[] listeCible = cible.Split(new string[]{"|"},System.StringSplitOptions.RemoveEmptyEntries);
		int i = 0;
		
		foreach(string ligne in listeCible)
		{	
			Dictionary<string,string> hashMap = new Dictionary<string,string>();
			string[] listeValue = ligne.Split(new string[]{"%"},System.StringSplitOptions.RemoveEmptyEntries);
			
			foreach(string value in listeValue)
			{
				string[] param = value.Split(new string[]{":"},System.StringSplitOptions.RemoveEmptyEntries);
				hashMap.Add(param[0],param[1]);
			}
			
			string newCible = "";
			string newCibleComplet = "";
			
			//if(hashMap["type"] == "pays")
				newCibleComplet = hashMap["nom"] + "<br/>";
			//else
			//	newCibleComplet = hashMap["nom"] + " (" + hashMap["code"] + ")<br/>";
			newCible = hashMap["nom"]+"<br/>";
				
			if(i<2) champCible[0] += newCible;	//limite a 2 lignes, utilise pour l'affichage
			champCible[1] += newCibleComplet;			//tous les criteres de localisation, utilise pour le span
				
			i++;
		}
		
		champCible[0] = champCible[0].Substring(0, champCible[0].Length - 5);
		if(i>2) champCible[0] += " <br/>[...]";
		champCible[1] = champCible[1].Substring(0, champCible[1].Length - 5);
		
		return champCible[1];
	}

    protected void construireTableauBien(OdbcCommand commandeAcquereur)
    {
        Connexion c = new Connexion();
        DataSet dst = c.exeRequetteParametree(commandeAcquereur);
		
		if(dst.Tables[0].Rows.Count == 0)
		{
			TableAcquereur.Visible = false;
			Button1.Visible = false;
			legend.Visible = false;
			TryAgain.Text = "<br/><hr/><br/>Aucun bien répondant aux critères n'a été trouvé.";
			TryAgain.Attributes["style"] = "font-style:italic;";
		}
		else
		{
            DataRowCollection dsr = dst.Tables[0].Rows;
            listeBien = new List<BienRraprochement>();

            //Deuxieme connexion pour recupérer l'état publocal
            //C'est lourd mais c'est plus léger qu'en se greffant à la méthode déjà en place
            string connectionString = "Dsn=patrimo";
            OdbcConnection c3 = new OdbcConnection(connectionString);
            OdbcDataReader reader;
            
			
			foreach (System.Data.DataRow ligne2 in dsr)
			{

                OdbcCommand commande = new OdbcCommand("SELECT PubLocale FROM optionsBiens WHERE refOptions= ?", c3);
                OdbcParameter paramRef = new OdbcParameter("@ref", DbType.String);
                paramRef.Value = ligne2["ref"].ToString();
                commande.Parameters.Add(paramRef);
                c3.Open();
                reader = commande.ExecuteReader();
 

				BienRraprochement bienRaproch = new BienRraprochement(ligne2["ref"].ToString());
				listeBien.Add(bienRaproch);

				TableRow row = new TableRow();
				row.Attributes["class"] = "moncompteacq4";
				List<TableCell> ListeCell = new List<TableCell>();

                //Colonne Date Dossier
				ListeCell.Add( new TableCell());
				ListeCell[0].Text = ligne2["date dossier"].ToString().Substring(0,10);

                //Colonne Ref
				ListeCell.Add( new TableCell());
				//ListeCell[1].Text = ligne2["ref"].ToString() + "<br/><a href=\"./fichedetail1.aspx?ref=" + ligne2["ref"].ToString() + "\"target=\"_blank\">Voir Fiche</a>";
                ListeCell[1].Text = "<br/><a href=\"./fichedetail1.aspx?ref=" + ligne2["ref"].ToString() + "\"target=\"_blank\">" + ligne2["ref"].ToString() + "</a>" + "<div class = \"tooltip3 span MySpace\"><span style='white-space:normal;'>" + ligne2["ref"].ToString() + "<br/><br/>" + nl2br(ligne2["texte internet"].ToString()) + "</span></div>"; 

                //Colonne Etat
				ListeCell.Add( new TableCell());
				switch (ligne2["etat"].ToString())// couleur des lignes
				{
					case "Estimation":
                        reader.Read();
                        if (reader["PubLocale"].ToString() == "True")
                        {
                            row.BackColor = System.Drawing.ColorTranslator.FromHtml("#F4A490");
                            ListeCell[2].Text = "Est<div class = \"tooltip\"><span>Estimation Pub Locale</span></div>";
                        }
                        else
                        {
                            row.BackColor = System.Drawing.ColorTranslator.FromHtml("#F4A460");
                            ListeCell[2].Text = "Est<div class = \"tooltip\"><span>Estimation</span></div>";
                        }
                        reader.Close();       	
						break;
					case "Disponible":
						row.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
						ListeCell[2].Text = "Dis<div class = \"tooltip\"><span>Disponible</span></div>";
						break;
					case "Offre":
						row.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFE4C4");
						ListeCell[2].Text = "Off<div class = \"tooltip\"><span>Offre</span></div>";
						break;
					case "Suspendu":
						row.BackColor = System.Drawing.ColorTranslator.FromHtml("#808080");
						ListeCell[2].Text = "Sus<div class = \"tooltip\"><span>Suspendu</span></div>";
						break;
					case "Retirer":
						row.BackColor = System.Drawing.ColorTranslator.FromHtml("#008000");
						ListeCell[2].Text = "Ret<div class = \"tooltip\"><span>Retirer</span></div>";
						break;
					case "Compromis":
						row.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF00");
						ListeCell[2].Text = "Com<div class = \"tooltip\"><span>Compromis</span></div>";
						break;
				}

                //Colonne Type de bien
				ListeCell.Add( new TableCell());
				switch (ligne2["type de bien"].ToString())
				{
					case "A":
						ListeCell[3].Text = "A<div class = \"tooltip\"><span>Appartement</span></div>";
						break;
					case "M":
						ListeCell[3].Text = "M<div class = \"tooltip\"><span>Maison</span></div>";
						break;
					case "I":
						ListeCell[3].Text = "I<div class = \"tooltip\"><span>Immeuble</span></div>";
						break;
					case "L":
						ListeCell[3].Text = "L<div class = \"tooltip\"><span>Local</span></div>";
						break;
					case "T":
						ListeCell[3].Text = "T<div class = \"tooltip\"><span>Terrain</span></div>";
						break;
				}


				ListeCell.Add( new TableCell());
				ListeCell[4].Text = ligne2["surface habitable"].ToString() + "<div class = \"tooltip\"><span>" + ligne2["surface habitable"].ToString() + "</span></div>";

				ListeCell.Add( new TableCell());
				ListeCell[5].Text = ligne2["surface terrain"].ToString() + "<div class = \"tooltip\"><span>" + ligne2["surface terrain"].ToString() + "</span></div>";

				ListeCell.Add( new TableCell());
				ListeCell[6].Text = ligne2["nombre de pieces"].ToString() + "<div class = \"tooltip\"><span>" + ligne2["nombre de pieces"].ToString() + "</span></div>";

                //Colonne Ville
				ListeCell.Add( new TableCell());
                ListeCell[7].Text = ligne2["ville du bien"].ToString() + "<div class = \"tooltip\"><span>" + ligne2["adresse du bien"].ToString() + "<br/>" + ligne2["ville du bien"].ToString()  + " (" + ligne2["code postal du bien"] + ")</span></div>";
				//ListeCell[7].Text = ligne2["ville du bien"].ToString() + "<div class = \"tooltip\"><span>" + ligne2["ville du bien"].ToString() + " (" + ligne2["code postal du bien"] + ")</span></div>";

				ListeCell.Add( new TableCell());
				if(ligne2["negociateur"].ToString().Split(' ').Length == 2)
					ListeCell[8].Text = ligne2["negociateur"].ToString().Split(' ')[1] + "<div class = \"tooltip\"><span>" + ligne2["negociateur"].ToString() + "</span></div>";
				else
					ListeCell[8].Text = ligne2["negociateur"].ToString() + "<div class = \"tooltip\"><span>" + ligne2["negociateur"].ToString() + "</span></div>";

				ListeCell.Add( new TableCell());
				if (ligne2["loyer_cc"].ToString() == "0" || ligne2["loyer_cc"].ToString() == "")
				{
					//Permet de mettre un espace tous les 3 chiffres dans le prix
					string temp = ligne2["prix de vente"].ToString();
					string prix = "";
					int k = 0;
					
					while((k+1)*3 < temp.Length)
					{
						prix = temp.Substring((temp.Length -(k+1)*3), 3) + " " +prix;
						k++;
					}
					prix = temp.Substring(0, temp.Length - k*3) + " " +prix;
					
					ListeCell[9].Text = prix + " &#8364;<div class = \"tooltip\"><span>" + prix + "&#8364;</span></div>";
				}
				else
				{
				
					string temp = ligne2["loyer_cc"].ToString();
					string prix = "";
					int k = 0;
					
					while((k+1)*3 < temp.Length)
					{
						prix = temp.Substring((temp.Length -(k+1)*3), 3) + " " +prix;
						k++;
					}
					prix = temp.Substring(0, temp.Length - k*3) + " " +prix;
					
					ListeCell[9].Text = prix + " &#8364;<div class = \"tooltip\"><span>" + prix + "&#8364;</span></div>";
				}

                //Colonne Photo
                ListeCell.Add(new TableCell());
                ListeCell[10].Text = "<img id=\"imgphoto\" src=\"" + affiche_photo(ligne2["ref"].ToString()) + "\" class=\"icone_photo\" alt=\"\" />" + tooltip_photo(ligne2["ref"].ToString());

                //Colonne Mandat
                ListeCell.Add(new TableCell());
                ListeCell[11].Text = ligne2["type mandat"] + "<div class = \"tooltip\"><span>" + ligne2["type mandat"] +"</span></div>";

                //Colonne Contact vendeur
				ListeCell.Add(new TableCell());
				if (ligne2["tel domicile vendeur"].ToString() != "") ListeCell[12].Text = espaceTel(ligne2["tel domicile vendeur"].ToString());
				else if (ligne2["tel bureau vendeur"].ToString() != "") ListeCell[12].Text = espaceTel(ligne2["tel bureau vendeur"].ToString());
				else if (ligne2["autre tel vendeur"].ToString() != "") ListeCell[12].Text = espaceTel(ligne2["autre tel vendeur"].ToString());
				
				string mail = "";
				string nl = "";
				if(ligne2["adresse mail vendeur"].ToString() != "")
				{
					mail = ligne2["adresse mail vendeur"].ToString();
					
					if(ListeCell[12].Text != "") nl = "<br/>";
					
					if(mail.Length >12)
						ListeCell[12].Text += nl + "<a href='mailto:" + mail +"'>" +mail.Substring(0,12) + "[...]</a>";
					else
						ListeCell[12].Text += nl + "<a href='mailto:" + mail +"'>"  +mail.ToString() + "</a>";
				}
				
				ListeCell[12].Text += "<div class = \"tooltip\"><span class='marqueurMail'>";
				if (ligne2["tel domicile vendeur"].ToString() != "" || ligne2["tel bureau vendeur"].ToString() != "" || ligne2["autre tel vendeur"].ToString() != "")
				{
					if (ligne2["tel domicile vendeur"].ToString() != "") ListeCell[12].Text += "Domicile : " + espaceTel(ligne2["tel domicile vendeur"].ToString());
					if (ligne2["tel bureau vendeur"].ToString() != "") ListeCell[12].Text += "<br />Bureau : " + espaceTel(ligne2["tel bureau vendeur"].ToString());
					if (ligne2["autre tel vendeur"].ToString() != "") ListeCell[12].Text += "<br />Autre : " + espaceTel(ligne2["autre tel vendeur"].ToString());
				}
				else
					ListeCell[12].Text += "aucun tel";
				ListeCell[12].Text += "<br/>" + " Mail : " +"<a href='mailto:" + mail +"'>" + mail + "</a>";
				ListeCell[12].Text += "</span></div>";
                
			   
				//Colonne Modifier le bien
				ListeCell.Add( new TableCell());
				if(ligne2["ref"].ToString().Substring(0,1) == "V")
					ListeCell[13].Text = "<a href='modifier_nego.aspx?reference=" + ligne2["ref"] + "'>";
				else if(ligne2["ref"].ToString().Substring(0,1) == "L")
				ListeCell[13].Text = "<a href='modifier_nego_loc.aspx?reference=" + ligne2["ref"] + "'>";
				
				ListeCell[13].Text = "<a href='modifier_nego.aspx?reference=" + ligne2["ref"] + "'target=\"_blank\">";
				ListeCell[13].Text += "<img class='croix_rouge' src='../img_site/calepin3.gif'></a>"
									+ "<div class='tooltip'><span>Modifier le bien</span></div>";
				
                //Colonne Rapprochement
				ListeCell.Add( new TableCell());
				ListeCell[14].Text = "<a href='../pages/rapprochementbien.aspx?idAcq=" + ligne2["ref"] + "'>"
									+"<img id='imgphoto' src='../img_site/rapprochement.png' alt='fleche' style='width: 25px' /></a>"
									+ "<div class='tooltip'><span>Rapprochement</span></div>";
				

                //Colonne Contact/Envoyer
				Label labelContact = new Label();
				ListeCell.Add( new TableCell());
                if (mailAcquereur != "")
                {
                    ListeCell[15].Controls.Add(bienRaproch.selection);
                    ListeCell[15].Controls.Add(labelContact);
                }
                else
                {
                    //ListeCell[15].Text = "Aucun mail";
                    ListeCell[15].Text = "<img src='../img_site/noEmail.png'>" + "<div class='tooltip'><span>Aucun mail</span></div>";
                }

                //Implementation des cells dans la row
				foreach (TableCell cell in ListeCell)
				{
					cell.Attributes["class"] = "moncompteacq3cell";
					row.Cells.Add(cell);
				}

				TableAcquereur.Rows.Add(row);
                c3.Close();
			}   
		}
    }

    protected int CheckNombrePhotos(string reference)
    {
        int i = 0;

        // Récupère le chemin racine du site
        Connexion cI = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        cI.Open();
        System.Data.DataSet dsI = cI.exeRequette("Select * from Environnement");
        cI.Close();
        String racine_site = (String)dsI.Tables[0].Rows[0]["Chemin_racine_site"];

        String ImageA = racine_site + "images\\" + reference + "A.jpg";
        String ImageB = racine_site + "images\\" + reference + "B.jpg";
        String ImageC = racine_site + "images\\" + reference + "C.jpg";
        String ImageD = racine_site + "images\\" + reference + "D.jpg";
        String ImageE = racine_site + "images\\" + reference + "E.jpg";
        String ImageF = racine_site + "images\\" + reference + "F.jpg";
        String ImageG = racine_site + "images\\" + reference + "G.jpg";
        String ImageH = racine_site + "images\\" + reference + "H.jpg";

        if (System.IO.File.Exists(ImageA) == true)
            i++;
        if (System.IO.File.Exists(ImageB) == true)
            i++;
        if (System.IO.File.Exists(ImageC) == true)
            i++;
        if (System.IO.File.Exists(ImageD) == true)
            i++;
        if (System.IO.File.Exists(ImageE) == true)
            i++;
        if (System.IO.File.Exists(ImageF) == true)
            i++;
        if (System.IO.File.Exists(ImageG) == true)
            i++;
        if (System.IO.File.Exists(ImageH) == true)
            i++;

        return i;
    }
    protected string tooltip_photo(string text)
    {
        string stext = "";
        int sc = CheckNombrePhotos(text);

        if (sc == 0)
            stext = "<div class='tooltip tooltipLeft0'><span>pas de photo";
        else if (sc == 1)
            stext = "<div class='tooltip tooltipLeft1'><span>" + sc + " photo<br/>"
                    + "<img style='width:160px;' src='../images/" + text + "A.jpg' alt='photo'>";
        else
            stext += "<div class='tooltip tooltipLeft'><span>" + sc + " photos<br/>"
                    + "<img style='width:160px;' src='../images/" + text + "A.jpg' alt='photo'>"
                    + "<img style='margin-left:5px;width:160px;' src='../images/" + text + "B.jpg' alt='photo'>";
        stext += "</span></div>";
        return stext;
    }
    protected string affiche_photo(string text)
    {
        string stext = "";
        int sc = CheckNombrePhotos(text);
        switch (sc)
        {
            case 0:
                stext = "";
                break;
            case 1:
                stext = "../img_site/miniature_image.jpg";
                break;
            default:
                stext = "../img_site/miniature_multiples_images.png";
                break;
        }
        return stext;
    }

    protected void constuireTableauAcquereur()
    {
	
        String idAcq = Request.QueryString["idAcq"];
        String requette = "SELECT * FROM Acquereurs WHERE ((Acquereurs.id_acq)=" + idAcq + "); ";
        System.Data.DataSet ds = null;
        Connexion c = null;
        c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();
        ds = c.exeRequette(requette);
        c.Close();
        c = null;
        System.Data.DataRowCollection dr = ds.Tables[0].Rows;
        string cible = "";
        foreach (System.Data.DataRow ligne in dr)
        {

            cible = ligne["cible"].ToString();
            mailAcquereur = ligne["mail"].ToString();

            Label1.Text = "";
            if (ligne["adresse"].ToString() != "") Label1.Text += ligne["adresse"].ToString() + " , ";
            if (ligne["ville"].ToString() != "") Label1.Text += ligne["ville"].ToString();
            if (ligne["code_postal"].ToString() != "") Label1.Text += " (" + ligne["code_postal"].ToString() + "), ";
            if (ligne["pays"].ToString() != "") Label1.Text += ligne["pays"].ToString();
            
            if (ligne["tel"].ToString() == "") Label2.Text = "";
            else Label2.Text = ligne["tel"].ToString();

            if (ligne["portable"].ToString() != "" && ligne["tel"].ToString() != "") Label2.Text += " , ";

            if (ligne["portable"].ToString() == "") Label2.Text += "";
            else Label2.Text += ligne["portable"].ToString();

            if (ligne["mail"].ToString() == "") Label5.Text = "";
            else Label5.Text = "<br/>" + ligne["mail"].ToString();

            Label3.Text = ligne["nom"].ToString();
            Label4.Text = ligne["prenom"].ToString();
			
			LFMaison = (bool)ligne["maison"];
			LFAppartement = (bool)ligne["appartement"];
			LFTerrain = (bool)ligne["terrain"];
			LFAutre = (bool)ligne["autre"];
            intnbpiecesmin = (int)ligne["nombre_de_pieces_min"];
            intnbpiecesmax = (int)ligne["nombre_de_pieces_max"];
            intnbchambresmin = (int)ligne["nombre_de_chambres_min"];
            intnbchambresmax = (int)ligne["nombre_de_chambres_max"];
            intsurfhabmin = (int)ligne["surface_habitable_min"];
            intsurfhabmax = (int)ligne["surface_habitable_max"];
            intsurfsejmin = (int)ligne["surface_sejour_min"];
            intsurfsejmax = (int)ligne["surface_sejour_max"];
            intsurfmin = (int)ligne["surface_terrain_min"];
            intsurfmax = (int)ligne["surface_terrain_max"];
			intprixmin = (int)ligne["prix_min"];
			intfacade = (int)ligne["facade"];
			intprofondeur = (int)ligne["profondeur"];
            if ((int)ligne["prix_max"] != 0 && (int)ligne["prix_max"] >= (int)ligne["prix_min"])
                intprixmax = (int)ligne["prix_max"];
			
			/***************************************************
			 *Affichage des criteres de recherche de l'acquereur
			 ***************************************************/
			

			
			//Prix & Type de bien
			string critereName = "";
			string critere = "";
			
			if(intprixmin !=0)
				critere = "" + espacePrix(intprixmin.ToString()) +"€ à " + espacePrix(intprixmax.ToString()) + "€<br/>";
			else
				critere = "< " + espacePrix(intprixmax.ToString()) + "€<br/>";
				
            if (LFAppartement) critere += ",Appartement";
            if (LFMaison) critere += ",Maison";
            if (LFTerrain) critere += ",Terrain";
            if (LFAutre)critere += ",Autre";
			ajouterCritere("Prix : <br/><br/>Type : ", critere);
			
			if(ligne["cible"].ToString() != "")
				ajouterCritere("Lieu : ", parserCible(ligne["cible"].ToString()));
			
			
			//Critere d'interieur (surface habitable, nombre piece, nombre champbre
			
			critere = "";
			if(intsurfhabmax != 0 && intsurfhabmin != 0 && intsurfhabmin < intsurfhabmax) critere += "" + intsurfhabmin + " m² à " + intsurfhabmax + " m² habitable,";
			else if(intsurfhabmin != 0) critere += "> " + intsurfhabmin + " m² habitable,";
			else if(intsurfhabmax != 0) critere += "< " + intsurfhabmax + " m² habitable,";
			
			if(intnbpiecesmin != 0 && intnbpiecesmax != 0 && intnbpiecesmin<intnbpiecesmax) critere += intnbpiecesmin + " à " + intnbpiecesmax + " pièces,";
			else if(intnbpiecesmin != 0) critere += "> " + intnbpiecesmin + " pièces,";
			else if(intnbpiecesmax != 0) critere += "< " + intnbpiecesmax + " pièces,";
			
			if(intnbchambresmin != 0 && intnbchambresmax != 0 && intnbchambresmin<intnbchambresmax) critere += intnbchambresmin + " à " + intnbchambresmax + " chambres,";
			else if(intnbchambresmin != 0) critere += "> " + intnbchambresmin + " chambres,";
			else if(intnbchambresmax != 0) critere += "< " + intnbchambresmax + " chambres,";
			
			if(intsurfsejmax != 0 && intsurfsejmin != 0 && intsurfsejmin < intsurfsejmax) critere += "" + intsurfsejmin + " m² à " + intsurfsejmax + " m² (séjour),";
			else if(intsurfsejmin != 0) critere += "> " + intsurfsejmin + " m² (séjour),";
			else if(intsurfsejmax != 0) critere += "< " + intsurfsejmax + " m (séjour)²,";
			
 			if(critere != "") ajouterCritere("Intérieur : ", critere);
			
			//Exterieur (surface terrain, facade, profondeur)
			
			critereName="Terrain :";
			critere = "";
			if(intsurfmax != 0 && intsurfmin != 0 && intsurfmin < intsurfmax) critere += "" + intsurfmin + " m² à " + intsurfmax + " m² ,";
			else if(intsurfmin != 0) critere += "> " + intsurfmin + " m²,";
			else if(intsurfmax != 0) critere += "< " + intsurfmax + " m²,";
			if(intfacade != 0) {critere += intfacade + " m²,"; critereName += " <br/> Façade : ";}
			if(intprofondeur != 0) {critere += intprofondeur + " m²,"; critereName += "<br/> Profondeur : ";}
			
			if(critere != "") ajouterCritere(critereName, critere);
			
			critere = "";
			if(ligne["ascenseur"].ToString() == "OUI") critere += "Ascenseur,";
			if(ligne["parking/box"].ToString() == "OUI") critere += "Parking/Box,";
            if(ligne["sous-sol"].ToString() == "OUI") critere += "Sous-sol,";
			if(critere != "") ajouterCritere("Avec : ", critere);
			
			
			if(ligne["texte_complementaire"].ToString() != "")
				ajouterCritere("Notes : ",ligne["texte_complementaire"].ToString(),true);

            hasAscenseur = ligne["ascenseur"].ToString();
            hasParking = ligne["parking/box"].ToString();
            hasSousSol = ligne["sous-sol"].ToString();


			
            typeAcquereur = ligne["type_acquereur"].ToString();
        }

        if (typeAcquereur == "Acheteur")
        {
            Label78.Text = "prix vente";
        }
        else
        {
            Label78.Text = "loyer";
        }


        listeRecherche = new ListeEmplacementRecherche();



        if (cible != "")
        {
        listeRecherche.importerString(cible);
        }

    }

    protected OdbcCommand construireRequeteBien()
    {
		string pays = "";
		bool isNotAppartement = false;
		
        OdbcCommand commande = new OdbcCommand();
        
        if (typeAcquereur == "Loueur") achatloc = " ((Biens.[ref]) LIKE 'L%') ";
        if (typeAcquereur == "Acheteur") achatloc = " ((Biens.[ref]) LIKE 'V%') ";

        typebien += " AND (";
        if (LFAppartement)
        {
            typebien += " ((Biens.[type de bien])='A') ";
            if (LFMaison || LFTerrain || LFAutre) typebien += "OR";
        }
        if (LFMaison)
        {
			isNotAppartement = true;
            typebien += " ((Biens.[type de bien])='M') ";
            if (LFTerrain || LFAutre) typebien += "OR";
        }
        if (LFTerrain)
        {
			isNotAppartement =true;
            typebien += " ((Biens.[type de bien])='T') ";
            if (LFAutre) typebien += "OR";
        }
        if (LFAutre) 
		{
			isNotAppartement = true;
			typebien += " (((Biens.[type de bien])='L') OR ((Biens.[type de bien])='I')) ";
		}
		
        typebien += ")";

        if (intnbpiecesmin != 0)
        {	
            nbpieces += " AND ((Biens.[nombre de pieces])>= ?)";
            OdbcParameter paramPieceMin = new OdbcParameter("@PieceMin", DbType.Int32);
            paramPieceMin.Value = intnbpiecesmin;
            commande.Parameters.Add(paramPieceMin);
		}
		
		if(intnbpiecesmax != 0 && intnbpiecesmax > intnbpiecesmin)
		{
			nbpieces += " AND ((Biens.[nombre de pieces])<= ?)";
            OdbcParameter paramPieceMax = new OdbcParameter("@PieceMax", DbType.Int32);
            paramPieceMax.Value = intnbpiecesmax;
            commande.Parameters.Add(paramPieceMax);
        }
		
        if (intnbchambresmin != 0 || intnbchambresmax != 0)
        {
            nbchambres += " AND ((Biens.[nombre de pieces])>= ? )";
            OdbcParameter paramNbChambreMin = new OdbcParameter("", DbType.Int32);
            paramNbChambreMin.Value = intnbchambresmin;
            commande.Parameters.Add(paramNbChambreMin);
		}	
		
		if (intnbchambresmax != 0)
        {
			nbchambres += " AND ((Biens.[nombre de pieces])<= ? )";
            OdbcParameter paramNbChambreMax = new OdbcParameter("", DbType.Int32);
            paramNbChambreMax.Value = intnbchambresmax;
            commande.Parameters.Add(paramNbChambreMax);
        }
		
        if (intsurfhabmin != 0)
        {
            surfacehab += " AND ((Biens.[surface habitable])>= ? )";
            OdbcParameter paramSurfhabMin = new OdbcParameter("", DbType.Int32);
            paramSurfhabMin.Value = intsurfhabmin;
            commande.Parameters.Add(paramSurfhabMin);
		}
		
		if (intsurfhabmax != 0 && intsurfhabmax > intsurfhabmin)
        {
			surfacehab += " AND ((Biens.[surface habitable])<= ? )";
            OdbcParameter paramSurfhabMax = new OdbcParameter("", DbType.Int32);
            paramSurfhabMax.Value = intsurfhabmax;
            commande.Parameters.Add(paramSurfhabMax);
        }
		
        if (intsurfsejmin != 0)
        {
            surfacesej += " AND (Biens.[surface séjour])>= ?";
            OdbcParameter paramSurfSejMin = new OdbcParameter("", DbType.Int32);
            paramSurfSejMin.Value = intsurfsejmin;
            commande.Parameters.Add(paramSurfSejMin);
		}
		
		if (intsurfsejmax != 0 && intsurfsejmax > intsurfsejmin)
        {
			surfacesej += " AND (Biens.[surface séjour])<= ?";
            OdbcParameter paramSurfSejMax = new OdbcParameter("", DbType.Int32);
            paramSurfSejMax.Value = intsurfsejmax;
            commande.Parameters.Add(paramSurfSejMax);
        }

        
        if (isNotAppartement && intsurfmin != 0) 
        {
            surfaceter += " AND( Biens.[type de bien]<>'L' AND Biens.[type de bien]<>'A' OR Biens.[surface terrain] >= ? ) ";
            OdbcParameter paramSurfMin = new OdbcParameter("", DbType.Int32);
            paramSurfMin.Value = intsurfmin;
            commande.Parameters.Add(paramSurfMin);
        }

        if (isNotAppartement && intsurfmax != 0 && intsurfmax > intsurfmin)
        {
            surfaceter += " AND( Biens.[type de bien]<>'L' AND Biens.[type de bien]<>'A' OR Biens.[surface terrain] <= ? ) ";
            OdbcParameter paramSurfMax = new OdbcParameter("", DbType.Int32);
            paramSurfMax.Value = intsurfmax;
            commande.Parameters.Add(paramSurfMax);
        }

        if (intfacade != 0)
        {
            facade = " AND ((Biens.[facade terrain]) >= ? )";
            OdbcParameter paramFace = new OdbcParameter("", DbType.Int32);
            paramFace.Value = intfacade;
            commande.Parameters.Add(paramFace);
        }

        if (intprofondeur != 0)
        {
            profondeur = " AND ((Biens.[profondeur terrain])>= ?)";
            OdbcParameter paramProfondeur = new OdbcParameter("", DbType.Int32);
            paramProfondeur.Value = intprofondeur;
            commande.Parameters.Add(paramProfondeur);
        }

        if (hasAscenseur == "OUI") ascenceur = " AND ((Biens.ascenceur) = 'OUI' )";
		if (hasParking == "OUI") parking = " AND (Biens.[nombre parkings interieurs] > '0' OR Biens.[nombre parkings exterieurs] > '0' OR Biens.[nombre garages] > '0')";
		if (hasSousSol == "OUI") soussol = " AND Biens.[nombre de caves] >'0'";
		
        //traitement de a cible

        List<OdbcParameter> listeParamCPVilles = new List<OdbcParameter>();
        bool hasSQLVille = false;
        bool hasSQLDep = false;
		bool hasPays = false;
        
        cp = " (";
        dep = " ";
        foreach (EmplacementRecherche ER in listeRecherche)
        {
            if(ER.Dep == true)
            { 				
				hasSQLDep = true;
                string param;
                if (ER.CodeINSEE.ToLower() != "2a" && ER.CodeINSEE.ToLower() != "2b") param = ER.CodeINSEE + "%";
                else param = "20%";

                dep += " OR Biens.[code postal du bien] like '" + param + "' ";
            }
			else if(ER.IsPays == true)
			{
				hasPays = true;
				pays = "'" + ER.Nom + "',";
			}
			else if(ER.IsContinent == true)
			{
				//TODO
				//Continent non ajoute dans la recherche par saisie
			}
			else if (ER.Dep == false && ER.IsPays == false && ER.IsContinent == false)
            {
                hasSQLVille = true;
                if (ER.HasArrondissement == false)
                {
                    cp += "'"+ ER.CP +"',";
                }
                else
                {
                    foreach(Arrondissement arr in ER.ListeArrondissement){
                        cp += "'"+arr.CP+"',";
                    }
                }
            }
			
        }
		if(hasSQLVille)
		{
			cp = cp.Substring(0, cp.Length - 1);
			cp += ") ";
			cp = " OR [code postal du bien] in " + cp;
		}
		
		if(hasPays) pays = " OR [PaysBien] in (" + pays.Substring(0, pays.Length - 1) + ") ";
        
		bool hasLieu = (hasSQLVille || hasSQLDep || hasPays);

        //fin traitement de la cible
               
        if (typeAcquereur != "Acheteur") 
        {
            prix = " AND ((Biens.[loyer_cc])>= ? ) AND ((Biens.[loyer_cc])<= ? )";
            OdbcParameter paramPrixMin = new OdbcParameter("", DbType.Int32);
            paramPrixMin.Value = intprixmin;
            commande.Parameters.Add(paramPrixMin);
            OdbcParameter paramPrixMax = new OdbcParameter("", DbType.Int32);
            paramPrixMax.Value = intprixmax;
            commande.Parameters.Add(paramPrixMax);
        }
        else 
        { 
            prix = " AND ((Biens.[prix de vente])>= ? ) AND ((Biens.[prix de vente])<= ? )";
            OdbcParameter paramPrixMin = new OdbcParameter("", DbType.Int32);
            paramPrixMin.Value = intprixmin;
            commande.Parameters.Add(paramPrixMin);
            OdbcParameter paramPrixMax = new OdbcParameter("", DbType.Int32);
            paramPrixMax.Value = intprixmax;
            commande.Parameters.Add(paramPrixMax);
        }


        String requete = "SELECT TOP 50 Biens.* FROM Biens INNER JOIN optionsBiens ON Biens.ref = optionsBiens.refOptions WHERE ((Biens.[etat]) <> 'Retiré' AND biens.[actif]='actif') AND " + achatloc + typebien + nbpieces + nbchambres + surfacehab + surfacesej + surfaceter + ascenceur + parking + soussol + facade + profondeur 
						+(hasLieu?" AND ( 0 ":" ") + (hasPays?pays:"") + (hasSQLDep?dep:" ") + (hasSQLVille?cp:" ") 
						+(hasLieu?" ) ":" ")
						+ prix + " ORDER BY " + ordre;
        commande.CommandText = requete;
        return commande;
    }
		
	protected void btnSubmit_Click(object sender, System.EventArgs e)
	{
	}

    protected void AllCheck(object sender, EventArgs e)
    {
        foreach (BienRraprochement br in listeBien)
        {
            if (CheckBox1.Checked == true) br.selection.Checked = true;
            else br.selection.Checked = false;
        }
    }

    protected void contacterAcquereur(object sender, EventArgs e)
    {
        GestionSMTP mail = new GestionSMTP();
        string destinataire = mailAcquereur;
        List<string> listeBienValide = new List<string>();
        int nb = 0;
        foreach (BienRraprochement bien in listeBien)
        {
            if (bien.selection.Checked == true)
            {
                listeBienValide.Add(bien.reference);
                nb++;
            }
        }
        Session["ListeBien"] = listeBienValide;

        string body = construireCorpMessage();
        string titre = "Patrimo vous propose des biens";
        LabelMail.Visible = true;
        if (nb == 0) LabelMail.Text = "Aucun bien sélectionné, veuillez sélectionner un ou plusieurs bien pour envoyer un mail à " + Label4.Text + " " + Label3.Text + "<br/>";
        else
        {
            if (nb == 1) LabelMail.Text = "Vous avez proposé " + nb + " bien par mail à " + Label4.Text + " " + Label3.Text + "<br/>";
            else LabelMail.Text = "Vous avez proposé " + nb + " biens par mail à " + Label4.Text + " " + Label3.Text + "<br/>";

            mail.envoyerMail(titre, body, destinataire, "raprochement", listeBienValide);
            if (CBCopieNego.Checked)
            {
                LabelMail.Text += "Vous recevrez une copie du mail<br/>";
                Membre member = (Membre)Session["membre"];
            mail.envoyerMail("Copie - "+titre, body, member.ID_CLIENT.ToString(), "raprochement", listeBienValide);
            }
        }
    }

    /*
    private String generateSearchLink(OdbcDataReader infoAlerte)
    {

        String lienRecherche = "http://" + hote + "/pages/affichagerecherche.aspx?incoming=Alerte&Numpage=1&Tri=date&Ordre=DESC&nbannonces=30";
        if (infoAlerte["type_vente"].ToString() == "V") lienRecherche += "&Transaction=achat";
        else lienRecherche += "&Transaction=loc";

        if (infoAlerte["type_bien"] != null && infoAlerte["type_bien"].ToString() != "")
        {
            if (infoAlerte["type_bien"].ToString().Contains('A')) lienRecherche += "&checkBoxAppart=true";
            else lienRecherche += "&checkBoxAppart=false";
            if (infoAlerte["type_bien"].ToString().Contains('M')) lienRecherche += "&checkBoxMaison=true";
            else lienRecherche += "&checkBoxMaison=false";
            if (infoAlerte["type_bien"].ToString().Contains('T')) lienRecherche += "&checkBoxTerrain=true";
            else lienRecherche += "&checkBoxTerrain=false";
            if (infoAlerte["type_bien"].ToString().Contains('X')) lienRecherche += "&checkBoxAutre=true";
            else lienRecherche += "&checkBoxAutre=true";
        }

        if (Convert.ToInt32(infoAlerte["prix_min"]) != 0 && Convert.ToInt32(infoAlerte["prix_max"]) != 1000000000)
        {
            lienRecherche += "&TextBoxBudgetMin=" + infoAlerte["prix_min"].ToString();
            lienRecherche += "&TextBoxBudgetMax=" + infoAlerte["prix_max"].ToString();
        }

        if (Convert.ToInt32(infoAlerte["surface_min"]) != 0 && Convert.ToInt32(infoAlerte["surface_max"]) != 500000)
        {
            lienRecherche += "&Smin=" + infoAlerte["surface_min"].ToString();
            lienRecherche += "&Smax=" + infoAlerte["surface_max"].ToString();
        }

        lienRecherche += "&checkBoxPiece1=" + Convert.ToBoolean(infoAlerte["piece_1"]);
        lienRecherche += "&checkBoxPiece2=" + Convert.ToBoolean(infoAlerte["piece_2"]);
        lienRecherche += "&checkBoxPiece3=" + Convert.ToBoolean(infoAlerte["piece_3"]);
        lienRecherche += "&checkBoxPiece4=" + Convert.ToBoolean(infoAlerte["piece_4"]);
        lienRecherche += "&checkBoxPiece5=" + Convert.ToBoolean(infoAlerte["piece_5"]);

        if (infoAlerte["cible"] != "") lienRecherche += "&cible=" + infoAlerte["cible"];

        lienRecherche += "&chckBxCdC=" + Convert.ToBoolean(infoAlerte["coupDeCoeur"]);
        lienRecherche += "&chckBxPrestige=" + Convert.ToBoolean(infoAlerte["Prestige"]);
        lienRecherche += "&ListeNeuf=" + Convert.ToBoolean(infoAlerte["Neuf"]);

        return lienRecherche;
    }
    */



    protected string construireCorpMessage()
    {

        ASP.pages_multimailraprochement_ascx onglet_multyiMail;
        
        StringBuilder sb = new StringBuilder();
        StringWriter tw = new StringWriter(sb);
        HtmlTextWriter hw = new HtmlTextWriter(tw);
        onglet_multyiMail = (ASP.pages_multimailraprochement_ascx)LoadControl("MultiMailRaprochement.ascx");
        Page.Controls.Add(onglet_multyiMail);
        onglet_multyiMail.Visible = true;
        onglet_multyiMail.RenderControl(hw);
        onglet_multyiMail.Visible = false;
        onglet_multyiMail.Dispose();
        onglet_multyiMail = null;
        return sb.ToString();
    }


    protected String nl2br(string s)
    {
        Regex rgx = new Regex("\r\n|\r|\n");
        return rgx.Replace(s, "<br/>");
    }

}

class BienRraprochement
{
    public string reference;
    public CheckBox selection;
    public BienRraprochement(string reference)
    {
        this.reference = reference;
        selection = new CheckBox();
    }
}