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
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Globalization;
using System.Collections.Generic;

public partial class pages_rapprochementbien : System.Web.UI.Page
{
    
    protected String idAcq;
    protected String requette;
    protected string ordre = "Biens.[code postal du bien], Biens.etat";
    protected int nombreoffres = 0;

    protected string typebien = "";
    protected string nbpieces = "";
    protected string nbchambres = "";
    protected string depCP = "";
    protected string surfacehab = "";
    protected string surfacesej = "";
    protected string surfaceter = "";
    protected string ascenceur = "";
    protected string facade = "";
    protected string profondeur = "";
    protected string ville = "";
    protected string prix = "";
    protected string achatloc = "";

    private Bien bien;

    List<AcqRraprochement> listeRaprochement = new List<AcqRraprochement>();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Page.Master.FindControl("titrebandeau")).Text = "Mon compte";

        Membre member=null;
        if (Session["Membre"] != null)
        {
            member = (Membre)Session["Membre"];
            LabelNom.Text = member.NOM;
            LabelStatut.Text = member.STATUT;
            LabelNego.Text = " AND Biens.[negociateur] = '" + member.NOM + "'";
        }
        if (member == null || member.STATUT != "ultranego")
        {
            Response.Redirect("./recherche.aspx");
            Response.End();
        }

        

        //requette pour remplir tableauAcquereur
       idAcq = Request.QueryString["idAcq"];
       remplirTableauBien();// recupere les infos du bien, les stocke en mémoire et les affiche
       construireRequette();// crée la requète qui trouve les acquéreurs
       remplirTableauAcquereur();// affiche les acquéreurs
	}

    protected void remplirTableauBien()
    {
        String requeteBien = "SELECT * FROM Biens INNER JOIN optionsBiens ON Biens.ref = optionsBiens.refOptions WHERE Biens.[ref]='" + idAcq + "'";

        System.Data.DataSet dst = null;
        Connexion c = null;
        c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();
        dst = c.exeRequette(requeteBien);
        c.Close();
        c = null;
        System.Data.DataRowCollection dsr = dst.Tables[0].Rows;

        bien = new Bien();
		
        foreach (System.Data.DataRow ligne2 in dsr)
        {
            bien.REFERENCE = ligne2["ref"].ToString();
            bien.ETAT = ligne2["etat"].ToString();
            bien.TYPE_BIEN = ligne2["type de bien"].ToString();
            bien.S_HABITABLE = (int)ligne2["surface habitable"];
            bien.S_SEJOUR = (int)ligne2["surface séjour"];
            bien.S_TERRAIN = (int)ligne2["surface terrain"];
            bien.NBRE_PIECE = (int)ligne2["nombre de pieces"];
            bien.NBRE_CHAMBRE = (int)ligne2["nombre de chambres"];
            bien.CODE_POSTAL_BIEN = ligne2["code postal du bien"].ToString();
            bien.VILLE_BIEN = ligne2["ville du bien"].ToString();
            bien.NEGOCIATEUR = ligne2["negociateur"].ToString();
            bien.LOYER_CC = (int)ligne2["loyer_cc"];
            bien.PRIX_VENTE = (int)ligne2["prix de vente"];
			bien.PAYS = ligne2["PaysBien"].ToString().ToUpper();

            Label11.Text = ligne2["nom vendeur"].ToString() + ligne2["prenom vendeur"].ToString();
            Label13.Text = ligne2["adresse vendeur"].ToString() + " , " + ligne2["ville vendeur"].ToString() + " (" + ligne2["code postal vendeur"].ToString() + "), " + ligne2["pays vendeur"].ToString();

            if (ligne2["tel domicile vendeur"].ToString() == "") Label14.Text = "";
            else Label14.Text = ligne2["tel domicile vendeur"].ToString();

            if (ligne2["tel domicile vendeur"].ToString() != "" && ligne2["tel bureau vendeur"].ToString() != "") Label14.Text += " , ";

            if (ligne2["tel bureau vendeur"].ToString() == "") Label14.Text += "";
            else Label14.Text += ligne2["tel bureau vendeur"].ToString();

            if (ligne2["adresse mail vendeur"].ToString() == "") Label15.Text = "<br/>";
            else Label15.Text = "<br/>Email : " + ligne2["adresse mail vendeur"].ToString() + "<br/>";


        }
		    
		String Image = "..\\images\\" + bien.REFERENCE + "A.jpg";
		if (System.IO.File.Exists(MapPath(Image)) == true)
           LabelImage.Text = "<img style='display: block; max-width:150px;max-height:90px;width: auto;height: auto;margin:auto;' src='../images/" + bien.REFERENCE +"A.jpg' alt='photo'>"
							+ "<div class='tooltip'><span><img style='display: block; max-width:320px;max-height:320px;width: auto;height: auto;' src='../images/" + bien.REFERENCE +"A.jpg' alt='photo'></span></div>";
        Label0.Text = bien.REFERENCE;
        Label1.Text = bien.ETAT;
        Label12.Text = "<a href=\"./fichedetail1.aspx?ref=" + bien.REFERENCE + "\"target=\"_blank\">Voir Fiche</a>";
        switch (bien.TYPE_BIEN)
        {
            case "A":
                Label2.Text = "Appartement";
                break;
            case "M":
                Label2.Text = "Maison";
                break;
            case "I":
                Label2.Text = "Immeuble";
                break;
            case "L":
                Label2.Text = "Local";
                break;
            case "T":
                Label2.Text = "Terrain";
                break;
        }

        Label3.Text = bien.S_HABITABLE.ToString();
        Label3bis.Text = bien.S_SEJOUR.ToString();
        Label4.Text = bien.S_TERRAIN.ToString();
        Label5.Text = bien.NBRE_PIECE.ToString();
        Label6.Text = bien.CODE_POSTAL_BIEN;
        Label7.Text = bien.VILLE_BIEN;
        Label10.Text = bien.NEGOCIATEUR;

        if (bien.LOYER_CC == 0)
        {
            Label9.Text = bien.PRIX_VENTE.ToString();
        }
        else
        {
            Label9.Text = bien.LOYER_CC.ToString();
        }
		
		string temp = Label9.Text;
		string prix = "";
		int k = 0;
		
		while((k+1)*3 < temp.Length)
		{
			prix = temp.Substring((temp.Length -(k+1)*3), 3) + " " +prix;
			k++;
		}
		prix = temp.Substring(0, temp.Length - k*3) + " " +prix;
		
		Label9.Text = prix;
    }

    protected string construireRequette()
    {
        Membre member = (Membre)Session["Membre"];
        requette = "SELECT * FROM Acquereurs where Acquereurs.[idclient] =" + member.IDCLIENT;
        requette += " AND actif = 'actif' ";

        if (Label0.Text.Contains("V")) requette += "AND type_acquereur = 'Acheteur' ";
        if (Label0.Text.Contains("L")) requette += "AND type_acquereur = 'Loueur' ";
        if (bien.TYPE_BIEN == "A") requette += "AND appartement = TRUE ";
        if (bien.TYPE_BIEN == "M") requette += "AND maison = TRUE ";
        if (bien.TYPE_BIEN == "T") requette += "AND terrain = TRUE ";
        if (bien.TYPE_BIEN == "X") requette += "AND autre = TRUE ";

        if (bien.S_HABITABLE != 0) requette += "AND ( (surface_habitable_min <= " + bien.S_HABITABLE + " AND surface_habitable_max >= " + bien.S_HABITABLE + ") OR surface_habitable_max = 0 OR surface_habitable_min is null ) ";
        if (bien.S_SEJOUR != 0) requette += "AND ( (surface_sejour_min <= " + bien.S_SEJOUR + " AND surface_sejour_max >= " + bien.S_SEJOUR + ") OR surface_sejour_max = 0 OR surface_sejour_min is null) ";
        if (bien.PRIX_VENTE != 0) requette += "AND ( (prix_max >= " + bien.PRIX_VENTE + " AND prix_min <= " + bien.PRIX_VENTE + ") OR prix_max = 0 OR prix_max is null) ";

        /*if (Label7.Text != "" || Label6.Text != "")
        {
            requette += " AND ( 0 ";
            if (Label7.Text != "")
            {
                requette += " OR cible like '%[%]nom:" + Label7.Text + "[%]%' ";
            }
            if (Label6.Text != "")
            {
                //ville dans le departement de recherche
                requette += " OR cible like '%[%]type:dep[%][%]code:" + Label6.Text.Substring(0, 2) + "[%]%' ";
                //ville dans les villes de recherche dans le cas: celles ci n'ont pas d'arondissements
                requette += " OR cible like '%[%]CP:" + Label6.Text + "[%]|%' ";
                //ville dans les villes de recherche dans le cas: celles ci ont des arrondissements
                requette += " OR cible like '%[%]arr:%" + Label6.Text + "%' ";
            }
            requette += " ) ";
        }*/
        requette += "ORDER by prix_max desc ;";
		
        return requette;
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
			
			if(hashMap["type"] == "pays")
				newCibleComplet = hashMap["nom"] + "<br/>";
			else
				newCibleComplet = hashMap["nom"] + " (" + hashMap["code"] + ")<br/>";
			newCible = hashMap["nom"]+"<br/>";
				
			if(i<2) champCible[0] += newCible;	//limite a 2 lignes, utilise pour l'affichage
			champCible[1] += newCibleComplet;			//tous les criteres de localisation, utilise pour le span
				
			i++;
		}
		
		champCible[0] = champCible[0].Substring(0, champCible[0].Length - 5);
		if(i>2) champCible[0] += " <br/>[...]";
		champCible[1] = champCible[1].Substring(0, champCible[1].Length - 5);
		
		return champCible[0] + "<div class = 'tooltip'><span>" + champCible[1] +"</span></div>";
	}
	
	protected string espaceTel(string tel)
	{
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
	
	
    
    protected void remplirTableauAcquereur()
    {
        //recuperation donnée
        System.Data.DataSet ds = null;
        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();
        ds = c.exeRequette(requette);
        c.Close();
        c = null;

        System.Data.DataRowCollection dr = ds.Tables[0].Rows;
        int count = dr.Count;
        Regex testSurCibleArrondissement = new Regex(@"%arr:[0-9\-]*"+Label6.Text+@"[0-9\-]*%");
        Regex testSurCibleCP = new Regex(@"%CP:"+Label6.Text+"%");
		Regex testDep = new Regex(@"%CP:"+Label6.Text.Substring(0,2)+"%");
		Regex testPays = new Regex(@"%nom:"+bien.PAYS+"%");
		
		bool enFrance = (bien.PAYS == "FRANCE");
		
		//TODO
		//FIXME
		//La rapprochement bien -> acquereurs ignore le code postal s'il s'agit d'un bien a l'etranger

		for (int i = 0; i < count; i++)
		{
			bool TestArrondissement = testSurCibleArrondissement.IsMatch(dr[i]["cible"].ToString());
			bool TestCP = (enFrance)
						?testSurCibleCP.IsMatch(dr[i]["cible"].ToString())
						:false;
						
			bool TestDep = (enFrance)
						?testDep.IsMatch(dr[i]["cible"].ToString())
						:false;
			
			bool TestPays = testPays.IsMatch(dr[i]["cible"].ToString());
			
			if (!TestPays && !TestDep && !TestArrondissement && !TestCP && dr[i]["cible"].ToString() != "")
			{
				dr.RemoveAt(i);
				i--;
				count--;
			}
		}

        foreach (System.Data.DataRow ligne in dr)
        {
            AcqRraprochement acquereur = new AcqRraprochement(ligne["id_acq"].ToString(), ligne["mail"].ToString());
            listeRaprochement.Add(acquereur);
            TableRow ligneAcquereur = new TableRow();
            ligneAcquereur.Attributes["class"] = "moncompteacq4";
            string contenuCellule;
			
			TableCell celluleDate = new TableCell();
            celluleDate.Text = ligne["date_ajout"].ToString().Substring(0,10);
            celluleDate.Text = celluleDate.Text + "<div class = 'tooltip'><span>" + celluleDate.Text +"</span></div>";

            contenuCellule = ligne["nom"].ToString() + "  " + ligne["prenom"].ToString();
            contenuCellule =  contenuCellule + "<div class = 'tooltip'><span>" + contenuCellule +"</span></div>";
            TableCell celluleNom = new TableCell();
            celluleNom.Text = contenuCellule;

			contenuCellule = "";
			bool hasTel = false;
            if (ligne["tel"].ToString() != "")
            {
				hasTel = true;
                //contenuCellule = espaceTel(ligne["tel"].ToString()); Necessaire car certains tel on ete enregistre sous la forme x.x.x ou x x x dans la base de donne
                contenuCellule = espaceTel(ligne["tel"].ToString().Replace(".","").Replace(" ",""));
            }
			contenuCellule += hasTel?"<br/>":"";
            contenuCellule += espaceTel(ligne["portable"].ToString());
			contenuCellule += "<div class = 'tooltip'><span>" + contenuCellule +"</span></div>";
            TableCell celluleTel = new TableCell();
            celluleTel.Text = contenuCellule;
	
			
			if(ligne["cible"].ToString() != "")
				contenuCellule = parserCible(ligne["cible"].ToString());
			else
				contenuCellule = "";
			
            TableCell celluleCP = new TableCell();
            celluleCP.Text = contenuCellule;

            contenuCellule = ligne["nombre_de_pieces_min"].ToString();
			contenuCellule += "<div class = 'tooltip'><span>" + contenuCellule +"</span></div>";
            TableCell celluleNbPiece = new TableCell();
            celluleNbPiece.Text = contenuCellule;
			
			contenuCellule = ligne["nombre_de_pieces_max"].ToString();
			contenuCellule += "<div class = 'tooltip'><span>" + contenuCellule +"</span></div>";
            TableCell celluleNbPieceMax = new TableCell();
            celluleNbPieceMax.Text = contenuCellule;

            contenuCellule= ligne["surface_habitable_min"].ToString();
			contenuCellule += "<div class = 'tooltip'><span>" + contenuCellule +"</span></div>";
            TableCell celluleSurfHab = new TableCell();
            celluleSurfHab.Text = contenuCellule;
			
			contenuCellule= ligne["surface_habitable_Max"].ToString();
			contenuCellule += "<div class = 'tooltip'><span>" + contenuCellule +"</span></div>";
            TableCell celluleSurfHabMax = new TableCell();
            celluleSurfHabMax.Text = contenuCellule;
			
			//Permet de mettre un espace tous les 3 chiffres dans le prix
			string temp = ligne["prix_min"].ToString();
			string prix = "";
			int k = 0;
			while((k+1)*3 < temp.Length)
			{
				prix = temp.Substring((temp.Length -(k+1)*3), 3) + " " +prix;
				k++;
			}
			prix = temp.Substring(0, temp.Length - k*3) + " " +prix;
			
            contenuCellule= prix + " &#8364;";
			contenuCellule += "<div class = 'tooltip'><span>" + contenuCellule +"</span></div>";
            TableCell cellulePrixMin = new TableCell();
            cellulePrixMin.Text = contenuCellule;
			
			
			
			temp = ligne["prix_max"].ToString();
			prix = "";
			k = 0;
			while((k+1)*3 < temp.Length)
			{
				prix = temp.Substring((temp.Length -(k+1)*3), 3) + " " +prix;
				k++;
			}
			prix = temp.Substring(0, temp.Length - k*3) + " " +prix;

            contenuCellule= prix + " &#8364;";
			contenuCellule += "<div class = 'tooltip'><span>" + contenuCellule +"</span></div>";
            TableCell cellulePrixMax = new TableCell();
            cellulePrixMax.Text = contenuCellule;
			
            TableCell celluleModif = new TableCell();
            celluleModif.Text = "<a href='modifier_acquereur.aspx?reference="
								+ ligne["id_acq"]
								+ "&refBien="+ Request.QueryString["idAcq"] +"'target=\"_blank\"><img class='croix_rouge' src='../img_site/calepin3.gif'></a>"
								+ "<div class='tooltip'><span>Modifier l'acquéreur</span></div>";
			
            TableCell celluleContact = new TableCell();
            Label labelContact = new Label();
            labelContact.Text = "";
            if (ligne["mail"].ToString() != null && ligne["mail"].ToString() != "")
            {
                celluleContact.Controls.Add(acquereur.selection);
				labelContact.Text += "<a href='mailto:" + ligne["mail"].ToString() + "'>" + "Envoyer mail</a>";
				labelContact.Text +=  "<div class = 'tooltip'><span class='marqueurMail'>" + ligne["mail"].ToString() +"</span></div>";
            }
            else
            {
                labelContact.Text += "<img src='../img_site/noEmail.png'>" + "<div class='tooltip'><span>Aucun mail</span></div>"; 
            }
            
            celluleContact.Controls.Add(labelContact);
			
			contenuCellule = "<a href='../pages/rapprochement.aspx?idAcq=" + ligne["id_acq"] + "'>"
							 +"<img id='imgphoto' src='../img_site/rapprochement.png' alt='fleche' style='width: 25px' /></a>"
							 + "<div class='tooltip'><span>Rapprochement</span></div>";
			TableCell celluleRapprochement = new TableCell();
            celluleRapprochement.Text = contenuCellule;
			
            //former la ligne
            ligneAcquereur.Cells.Add(celluleDate);
            ligneAcquereur.Cells.Add(celluleNom);
            ligneAcquereur.Cells.Add(celluleTel);
            ligneAcquereur.Cells.Add(celluleCP);
            ligneAcquereur.Cells.Add(celluleNbPiece);
			ligneAcquereur.Cells.Add(celluleNbPieceMax);
            ligneAcquereur.Cells.Add(celluleSurfHab);
			ligneAcquereur.Cells.Add(celluleSurfHabMax);
            ligneAcquereur.Cells.Add(cellulePrixMin);
            ligneAcquereur.Cells.Add(cellulePrixMax);
            ligneAcquereur.Cells.Add(celluleModif);
            ligneAcquereur.Cells.Add(celluleRapprochement);
            ligneAcquereur.Cells.Add(celluleContact);
			
            switch (ligne["categorie"].ToString())
            {
                case "large":
                    ligneAcquereur.BackColor = System.Drawing.Color.PaleGreen;
                    break;
                case "precis":
                    ligneAcquereur.BackColor = System.Drawing.Color.YellowGreen;
                    break;
                case "investisseur ancien":
                    ligneAcquereur.BackColor = System.Drawing.Color.BurlyWood;
                    break;
                case "investisseur neuf":
                    ligneAcquereur.BackColor = System.Drawing.Color.Khaki;
                    break;
            }


            foreach (TableCell cell in ligneAcquereur.Cells)
            {
                cell.Attributes["class"] = "moncompteacq3";
            }
			
			celluleNbPiece.Attributes["class"] = "moncompteacqnosize sizedemi";
			celluleNbPieceMax.Attributes["class"] = "moncompteacqnosize sizedemi";
            celluleSurfHab.Attributes["class"] = "moncompteacqnosize sizedemi";
			celluleSurfHabMax.Attributes["class"] = "moncompteacqnosize sizedemi";
			celluleModif.Attributes["class"] = "moncompteacqnosize sizeicon";
			celluleRapprochement.Attributes["class"] = "moncompteacqnosize sizeicon";

            //placer la ligne
            TableAcquereur.Rows.Add(ligneAcquereur);
        }
    }

    //Fonction contacter tout les acquereur selectionnés
    protected void Button1_Click(object sender, EventArgs e)
    {
        GestionSMTP mail = new GestionSMTP();
        List<String> listeBien = new List<String> { idAcq };
		int i = 0;
        foreach (AcqRraprochement acquereur in listeRaprochement)
        {
            if (acquereur.selection.Checked == true)
            {
				i++;
                string titre = "PATRIMO: Logement trouvé";
                string corp= construireMailRaprochement();
                string destinataire=acquereur.mail;
                mail.envoyerMail(titre, corp, destinataire, "raprochement", listeBien);
            }
        }
		Confirm.Text = i + " mail(s) ont été envoyés.<br/><br/>";
    }

    protected string construireMailRaprochement()
    {
        ASP.pages_mailraprochement_ascx onglet_mail;

        StringBuilder sb = new StringBuilder();
        StringWriter tw = new StringWriter(sb);
        HtmlTextWriter hw = new HtmlTextWriter(tw);
        onglet_mail = (ASP.pages_mailraprochement_ascx)LoadControl("MailRaprochement.ascx");
        Page.Controls.Add(onglet_mail);
        onglet_mail.Visible = true;
        onglet_mail.RenderControl(hw);
        onglet_mail.Visible = false;
        onglet_mail.Dispose();
        onglet_mail = null;
        return sb.ToString();
    }


    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        foreach (AcqRraprochement acqu in listeRaprochement)
        {
            if (acqu.mail != null && acqu.mail != "")
            {
                if (CheckBox1.Checked == true)
                {
                    acqu.selection.Checked = true;
                }
                else
                {
                    acqu.selection.Checked = false;
                }
            }
        }
    }
}

public class AcqRraprochement
{
    public string id;
    public CheckBox selection;
    public string mail;
    public AcqRraprochement(string id, string mail)
    {
        this.id = id;
        this.mail = mail;
        selection = new CheckBox();
    }
}