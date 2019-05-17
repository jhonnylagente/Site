using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.Odbc;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;


public partial class vente : System.Web.UI.Page
{
    protected bool isAdmin = false;
    protected bool edit = true;
    protected DataRow bien;

    protected void Page_Load(object sender, EventArgs e)
    {      
        if (Request.QueryString["ref"] == null)
        {
            Response.Redirect("./moncomptetableaudebord_bis.aspx");
        }
        Membre member = (Membre)Session["Membre"];

        if (member != null && (member.STATUT != "nego" || member.STATUT != "ultranego")) { }
        else
            Response.Redirect("./moncomptetableaudebord_bis.aspx");

        isAdmin = (member.STATUT == "ultranego");

        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();

        try
        {
            bien = c.exeRequetteOpen("SELECT * FROM Biens WHERE ref='" + Request.QueryString["ref"] + "'").Tables[0].Rows[0];
        }
        catch
        {
            Response.Redirect("./moncomptetableaudebord_bis.aspx");
            c.Close();
        }


        if (!IsPostBack)
        {
            int idNego = (int)bien["idclient"];
            int honoraire = (int)bien["honoraires"];
            int prix = (int)bien["prix de vente"];


            ((Label)Page.Master.FindControl("titrebandeau")).Text = "Proposer vente";
            //refBien.Text = Request.QueryString["ref"];
            TextBoxHonoraires.Text = honoraire.ToString();
            TextBoxPrix.Text = prix.ToString();
            TextBoxSequestre.Text = ((int)(int.Parse(TextBoxPrix.Text) * 5 / 100)).ToString();

            string codeiso = Code_iso("negomandat");

            DataRow negoMandat = c.exeRequetteOpen("SELECT Clients.* FROM Clients,Biens WHERE Biens.idclient = Clients.idclient AND Biens.ref = '" + Request.QueryString["ref"] + "'").Tables[0].Rows[0];
            nego.Text = negoMandat["prenom_client"].ToString() + " " + negoMandat["nom_client"].ToString().ToUpper();
            negoadresse.Text = "<img height='20px'  src='../img_site/drapeau/" + codeiso + ".png'/>" + "<div class='tooltip'><span>" + "<img height='50px'  src='../img_site/drapeau/" + codeiso + ".png'/></span></div>" + "&nbsp;" + "<a href='https://www.google.fr/maps/place/" + negoMandat["adresse_client"] + " " + negoMandat["ville_client"].ToString() + "' target='_blank'><img style='cursor:pointer' src='../img_site/flat_round/monde.png' height='20px'/></a>" + " " + negoMandat["adresse_client"].ToString() + "<br/>" + "&nbsp;&nbsp;" + negoMandat["postal_client"].ToString() + ", " + negoMandat["ville_client"].ToString();
            negoTel.Text = negoMandat["tel_client"].ToString();
            negoMail.Text = "<a href='mailto:" + negoMandat["id_client"] + "'>" + negoMandat["id_client"] + "</a>";

            string temp = DropDownListAcq.SelectedValue;
            string temp2 = DropDownListNotaire.SelectedValue;
            string req;
            string req2;

            if (member.STATUT == "ultranego")
            {
                req = "SELECT id_acq,nom,prenom,tel,mail,code_postal,ville,idclient,adresse,pays FROM Acquereurs WHERE actif='actif' ORDER BY Nom ASC";
                req2 = "SELECT id_notaire,nom,prenom,adresse,code_postal,ville,mail,telephone,pays,fax FROM Notaires ORDER BY Nom ASC";
            }
            else
            {
                req = "SELECT id_acq,nom,prenom,tel,mail,code_postal,ville,idclient,adresse,pays FROM Acquereurs WHERE actif='actif' AND idclient = " + member.IDCLIENT + " ORDER BY Nom ASC";
                req2 = "SELECT Notaires.id_notaire,nom,prenom,adresse,code_postal,ville,mail,telephone,pays,fax FROM Notaires INNER JOIN lien_clients_notaires ON lien_clients_notaires.id_notaire=Notaires.id_notaire WHERE lien_clients_notaires.id_client = " + member.IDCLIENT + " ORDER BY Nom ASC";
            }

            DataRowCollection listeAcquereur = c.exeRequetteOpen(req).Tables[0].Rows;
            foreach (DataRow acq in listeAcquereur)
            {
                string nomnegoacq = null, prenomnegoacq = null;

                string idacq = acq["id_acq"].ToString();

                req = "SELECT Clients.nom_client, Clients.prenom_client  FROM Acquereurs INNER JOIN Clients ON Acquereurs.idclient = Clients.idclient WHERE ((Acquereurs.id_acq)=" + idacq + ")";

                OdbcConnection connect = new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                OdbcCommand requet = new OdbcCommand(req, connect);

                connect.Open();

                OdbcDataReader read = requet.ExecuteReader();

                while (read.Read())
                {
                    nomnegoacq = read["nom_client"].ToString().ToUpper();

                    prenomnegoacq = read["prenom_client"].ToString();
                }

                connect.Close();

                ListItem x = new ListItem(acq["nom"].ToString().ToUpper() + " " + acq["prenom"].ToString() + " (" + acq["ville"].ToString() + " - " + acq["code_postal"].ToString() + ") | négo associé: " + nomnegoacq + " " + prenomnegoacq);
                x.Attributes["tel"] = acq["tel"].ToString();
                x.Attributes["mail"] = acq["mail"].ToString();
                x.Attributes["idclient"] = acq["idclient"].ToString();
                x.Attributes["nom"] = acq["nom"].ToString().ToUpper();
                x.Attributes["prenom"] = acq["prenom"].ToString();
                x.Attributes["adresse"] = acq["adresse"].ToString();
                x.Attributes["ville"] = acq["ville"].ToString();
                x.Attributes["code_postal"] = acq["code_postal"].ToString();
                x.Attributes["pays"] = acq["pays"].ToString().ToUpper();
                x.Value = acq["id_acq"].ToString();
                
                req = "SELECT Pays.codeiso FROM Pays WHERE ((Pays.Titre_Pays)='" + acq["pays"].ToString() + "')";

                OdbcConnection connection = new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                OdbcCommand requette = new OdbcCommand(req, connection);

                connection.Open();

                OdbcDataReader reader = requette.ExecuteReader();

                reader.Read();

                x.Attributes["codeiso"] = reader["codeiso"].ToString();

                connection.Close();

                DropDownListAcq.Items.Add(x);
            }
            
            if (Request.QueryString["acq"] != null)
            {
                DropDownListAcq.SelectedValue = Request.QueryString["acq"];
                nomacquereur.Text = DropDownListAcq.SelectedItem.Attributes["nom"] + " " + DropDownListAcq.SelectedItem.Attributes["prenom"];
            }

            InformationNegoAcquereur();

            DataRowCollection listeNotaire = c.exeRequetteOpen(req2).Tables[0].Rows;
            foreach (DataRow not in listeNotaire)
            {
                ListItem y = new ListItem(not["nom"].ToString().ToUpper() + ", " + not["prenom"].ToString() + " (" + not["ville"].ToString() + " - " + not["code_postal"].ToString() + ")", not["id_notaire"].ToString());

                y.Attributes["nom"] = not["nom"].ToString().ToUpper();
                y.Attributes["prenom"] = not["prenom"].ToString();
                y.Attributes["adresse"] = not["adresse"].ToString();
                y.Attributes["code_postal"] = not["code_postal"].ToString();
                y.Attributes["ville"] = not["ville"].ToString();
                y.Attributes["mail"] = not["mail"].ToString();
                y.Attributes["telephone"] = not["telephone"].ToString();
                y.Attributes["pays"] = not["pays"].ToString().ToUpper();
                y.Attributes["fax"] = not["fax"].ToString();
                y.Attributes["id_notaire"] = not["id_notaire"].ToString();

                if (not["pays"].ToString() != "")
                {
                    req = "SELECT Pays.codeiso FROM Pays WHERE ((Pays.Titre_Pays)='" + not["pays"].ToString() + "')";
                    //
                    OdbcConnection connection = new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                    OdbcCommand requette = new OdbcCommand(req, connection);

                    connection.Open();

                    OdbcDataReader reader = requette.ExecuteReader();

                    reader.Read();

                    y.Attributes["codeiso"] = reader["codeiso"].ToString();

                    connection.Close();
                }

                DropDownListNotaire.Items.Add(y);
            }


            DropDownListNotaire.SelectedValue = temp2;


            if (Request.QueryString["id"] != null) //Consultation d'une fiche vente
            {

                System.Data.DataSet ds2 = c.exeRequetteOpen("Select * from Environnement");
                String racine_site = (String)ds2.Tables[0].Rows[0]["Chemin_racine_site"];

                string filePathActe = racine_site + "Ventes\\" + Request.QueryString["id"] + "_acte.pdf";
                string filePathPromesse = racine_site + "Ventes\\" + Request.QueryString["id"] + "_promesse.pdf";

                if (System.IO.File.Exists(filePathPromesse))
                {
                    
                    oldPromesse.Text = "<span id='newPromesse'><a href='../Ventes/" + Request.QueryString["id"] + "_promesse.pdf' target='_blank'>Voir Fichier</a></span>";
                    filePromesse.Attributes["style"] += ";width: 140px;color:white;";
                }

                if (System.IO.File.Exists(filePathActe))
                {
                    oldActe.Text = "<span id='newActe'><a href='../Ventes/" + Request.QueryString["id"] + "_acte.pdf' target='_blank'>Voir Fichier</a></span>";
                    fileActe.Attributes["style"] += ";width: 140px;color:white;";
                }
                string val= "";
                if (Request.QueryString["id"] != null)
                    val = Request.QueryString["id"];
                else
                    if (Request.QueryString["acq"] != null)
                        val = Request.QueryString["acq"];
                DataRow vente = c.exeRequetteOpen("SELECT * FROM Ventes WHERE ID =" + val).Tables[0].Rows[0];
                bool venteValidee = (bool)vente["valider_signature"];
                DropDownListAcq.SelectedValue = vente["id_acquereur"].ToString();

                ratioNegoMandat.Text = ((double)vente["taux_mandat"] * 100).ToString();
                ratioNegoVente.Text = ((double)vente["taux_vente"] * 100).ToString();

                TextBoxPrix.Text = vente["prix_vente"].ToString();
                TextBoxSequestre.Text = vente["sequestre"].ToString();
                TextBoxHonoraires.Text = vente["commission"].ToString();

                // il faudrait plutot recuperer les infos du notaire dans la table  notaire ..
                notaireNom.Text = vente["nom_notaire"].ToString();
                notairePrenom.Text = vente["prenom_notaire"].ToString();
                notaireAdresse.Text = vente["adresse_notaire"].ToString();
                notaireCPetville.Text = vente["cp_notaire"].ToString() + ", " + vente["ville_notaire"].ToString();
                notaireTel.Text = vente["tel_notaire"].ToString();
                notaireMail.Text = vente["mail_notaire"].ToString();
                TextBoxDateCompromis.Text = vente["date_compromis"].ToString().Split(' ')[0];
                TextBoxDateSignature.Text = vente["date_signature"].ToString().Split(' ')[0];


                int idNegoMandataire = (int)vente["id_nego"];
                int idNegoVente = (int)c.exeRequetteOpen("SELECT idclient FROM Acquereurs WHERE id_acq = " + vente["id_acquereur"].ToString()).Tables[0].Rows[0]["idclient"];

                saveVente.Visible = false;

                if ((!venteValidee && member.IDCLIENT == idNegoMandataire) || (!venteValidee && member.IDCLIENT == idNegoVente) || member.STATUT == "ultranego")
                {
                    updateVente.Visible = true;
                }
                else
                {
                    edit = false;
                    if (venteValidee)
                        msg.Text = "Vente validée, aucune modification possible.<br/>";
                }
            }

            c.Close();

            remplirTableauBien(Request.QueryString["ref"]);
        }

    }

    protected void remplirTableauBien(string idAcq)
    {
        //String requeteBien = "SELECT * FROM Biens INNER JOIN optionsBiens ON Biens.ref = optionsBiens.refOptions WHERE Biens.[ref]='" + idAcq + "'";
        String requeteBien = "SELECT * FROM Biens INNER JOIN optionsBiens ON Biens.ref = optionsBiens.refOptions WHERE Biens.[ref]='" + Request.QueryString["ref"]+ "'";

        System.Data.DataSet dst = null;
        Connexion c = null;
        c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();
        dst = c.exeRequette(requeteBien);
        c.Close();
        c = null;
        System.Data.DataRowCollection dsr = dst.Tables[0].Rows;

        Bien bien = new Bien();

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
            bien.VILLE_BIEN = ligne2["ville du bien"].ToString().ToUpper();
            bien.NEGOCIATEUR = ligne2["negociateur"].ToString();
            bien.LOYER_CC = (int)ligne2["loyer_cc"];
            bien.PRIX_VENTE = (int)ligne2["prix de vente"];
            bien.PAYS = ligne2["PaysBien"].ToString().ToUpper();
            bien.ADRESSE_BIEN = ligne2["adresse du bien"].ToString();
            bien.ADRESSE_VENDEUR = ligne2["adresse vendeur"].ToString();
            //bien.CODE_POSTAL_VENDEUR = int.Parse(ligne2["code postal vendeur"].ToString());
            bien.CODE_POSTAL_VENDEUR = ligne2["code postal vendeur"].ToString();
            bien.VILLE_VENDEUR = ligne2["ville vendeur"].ToString();
            bien.PAYS_VENDEUR = ligne2["pays vendeur"].ToString();
            bien.PRENOM_VENDEUR = ligne2["prenom vendeur"].ToString();
            bien.NOM_VENDEUR = ligne2["nom vendeur"].ToString();


        }

        int nbphotos = CheckNombrePhotos(bien.REFERENCE);

        switch (nbphotos)
        {
            case 0:
                LabelImage.Text = "<img style='width:125px;' src='../img_site/images_par_defaut/" + bien.TYPE_BIEN + ".jpg' alt='photo'>"
                                 + "<div class='tooltip'><span>" + "<img style='width:250px' src='../img_site/images_par_defaut/" + bien.TYPE_BIEN + ".jpg' alt='photo'></span></div>";
                break;

            case 1:
                LabelImage.Text = "<img style='width:125px;' src='../images/" + bien.REFERENCE + "A.jpg' alt='photo'>"
                                 + "<div class='tooltip'><span>" + nbphotos + " Photo <br/>" + "<img style='width:250px' src='../images/" + bien.REFERENCE + "A.jpg' alt='photo'></span></div>";
                break;

            default:
                LabelImage.Text = "<img style='width:125px;' src='../images/" + bien.REFERENCE + "A.jpg' alt='photo'>"
                                 + "<div class='tooltip'><span>" + nbphotos + " Photos <br/>" + "<img style='width:250px;' src='../images/" + bien.REFERENCE + "A.jpg' alt='photo'> " + "<img style='margin-left:5px;width:250px;' src='../images/" + bien.REFERENCE + "B.jpg' alt='photo'></span></div>";
                break;
        }

        Label0.Text = ": " + bien.REFERENCE;
        Label12.Text = "<a href=\"./fichedetail1.aspx?ref=" + bien.REFERENCE + "\" target='_blank'>Voir Fiche</a>";

        switch (bien.TYPE_BIEN)
        {
            case "A":
                Label2.Text = ": Appartement";
                break;
            case "M":
                Label2.Text = ": Maison";
                break;
            case "I":
                Label2.Text = ": Immeuble";
                break;
            case "L":
                Label2.Text = ": Local";
                break;
            case "T":
                Label2.Text = ": Terrain";
                break;
        }

        string codeiso = Code_iso("bieniso", bien);

        Label3.Text = ": " + bien.S_HABITABLE.ToString();
        Label3bis.Text = ": " + bien.S_SEJOUR.ToString();
        Label4.Text = ": " + bien.S_TERRAIN.ToString();
        Label5.Text = ": " + bien.NBRE_PIECE.ToString();
        Label6.Text = bien.CODE_POSTAL_BIEN + ", " + bien.VILLE_BIEN;
        Label7.Text = ": " + "<img height='20px'  src='../img_site/drapeau/" + codeiso + ".png'/>" + "<div class='tooltip'><span>" + "<img height='50px'  src='../img_site/drapeau/" + codeiso + ".png'/></span></div>" + "&nbsp;" + "<a href='https://www.google.fr/maps/place/" + bien.ADRESSE_BIEN + " " + bien.VILLE_BIEN + "' target='_blank'><img style='cursor:pointer' src='../img_site/flat_round/monde.png' height='20px'/></a>" + " " + bien.ADRESSE_BIEN;

        if (bien.LOYER_CC == 0)
        {
            Label9.Text = ": " + bien.PRIX_VENTE.ToString();
        }
        else
        {
            Label9.Text = ": " + bien.LOYER_CC.ToString();
        }

        string temp = Label9.Text;
        string prix = "";
        int k = 0;

        while ((k + 1) * 3 < temp.Length)
        {
            prix = temp.Substring((temp.Length - (k + 1) * 3), 3) + " " + prix;
            k++;
        }
        prix = temp.Substring(0, temp.Length - k * 3) + " " + prix;

        Label9.Text = prix;

        codeiso = Code_iso("vendeur", bien, null);

        if (codeiso != "" && bien.ADRESSE_VENDEUR != "" && bien.VILLE_VENDEUR != "")
            adressevendeur.Text = "<img height='20px'  src='../img_site/drapeau/" + codeiso + ".png'/>" + "<div class='tooltip'><span>" + "<img height='50px'  src='../img_site/drapeau/" + codeiso + ".png'/></span></div>" + "&nbsp;" + "<a href='https://www.google.fr/maps/place/" + bien.ADRESSE_VENDEUR + " " + bien.VILLE_VENDEUR + "' target='_blank'><img style='cursor:pointer' src='../img_site/flat_round/monde.png' height='20px'/></a>" + " " + bien.ADRESSE_VENDEUR + "<br/>&nbsp;&nbsp;" + bien.CODE_POSTAL_VENDEUR + ", " + bien.VILLE_VENDEUR;
        else
            if (codeiso =="" || bien.VILLE_VENDEUR == "" || bien.ADRESSE_VENDEUR =="")
                if (bien.ADRESSE_VENDEUR == "" || bien.VILLE_VENDEUR == "")
                    if (codeiso =="")
                        adressevendeur.Text = bien.ADRESSE_VENDEUR + "<br/>&nbsp;&nbsp;" + bien.CODE_POSTAL_VENDEUR + bien.VILLE_VENDEUR;
                    else
                        adressevendeur.Text = "<img height='20px'  src='../img_site/drapeau/" + codeiso + ".png'/>" + "<div class='tooltip'><span>" + "<img height='50px'  src='../img_site/drapeau/" + codeiso + ".png'/></span></div>" + "&nbsp;" + " " + bien.ADRESSE_VENDEUR + "<br/>&nbsp;&nbsp;" + bien.CODE_POSTAL_VENDEUR  + bien.VILLE_VENDEUR;
                else
                    adressevendeur.Text = "<a href='https://www.google.fr/maps/place/" + bien.ADRESSE_VENDEUR + " " + bien.VILLE_VENDEUR + "' target='_blank'><img style='cursor:pointer' src='../img_site/flat_round/monde.png' height='20px'/></a>" + " " + bien.ADRESSE_VENDEUR + "<br/>&nbsp;&nbsp;" + bien.CODE_POSTAL_VENDEUR  + bien.VILLE_VENDEUR;
            
        nomvendeur.Text = bien.NOM_VENDEUR + " " + bien.PRENOM_VENDEUR;
    }

    protected void updateVente_Click(object sender, EventArgs e)
    {
        
        if (TextBoxSequestre.Text == "")
            TextBoxSequestre.Text = "0";

        string[] date = TextBoxDateCompromis.Text.Split('/');
        string[] dateS = TextBoxDateSignature.Text.Split('/');
        string dateComp = ",null";
        string dateSign = ",null";

        if (date.Length == 3)
            dateComp = "', date_compromis = #" + date[1] + "/" + date[0] + "/" + date[2] + "#";


        if (dateS.Length == 3)
            dateSign = ", date_signature = #" + dateS[1] + "/" + dateS[0] + "/" + dateS[2] + "#";


        string req = "UPDATE Ventes SET"
            + " id_acquereur = " + DropDownListAcq.SelectedValue
            + ", prix_vente = " + TextBoxPrix.Text
            + ", commission = " + TextBoxHonoraires.Text
            + ", sequestre = " + TextBoxSequestre.Text
            + ", taux_mandat = " + (double.Parse(ratioNegoMandat.Text) / 100).ToString().Replace(",", ".")
            + ", taux_vente = " + (double.Parse(ratioNegoVente.Text) / 100).ToString().Replace(",", ".")
            + ", nom_notaire = '" + notaireNom.Text
            + "', prenom_notaire = '" + notairePrenom.Text
            + "', adresse_notaire = '" + notaireAdresse.Text
            + "', ville_notaire = '" + notaireCPetville.Text
            + "', cp_notaire = '" + notaireCPetville.Text
            + "', tel_notaire = '" + notaireTel.Text
            + "', mail_notaire = '" + notaireMail.Text
            + dateComp
            + dateSign
            + " WHERE ID = " + Request.QueryString["id"];

        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();

        DataRow oldData = c.exeRequetteOpen("SELECT * FROM Ventes WHERE ID = " + Request.QueryString["id"]).Tables[0].Rows[0];
        c.exeRequetteOpen(req);

        //Absoluement degueulasse, mais j'ai vraiment la flemme de faire un update propre de toutes les lignes
        //En plus, si l'acheteur change, les anciennes remuneration sont obsolete, autant delete et recalculer a chaque changement.
        /*if (oldData["commission"].ToString() == TextBoxPrix.Text && (int)oldData["id_acquereur"] == int.Parse(DropDownListAcq.SelectedValue))
        {

        }
        else*/

        Membre member = (Membre)Session["membre"];

        //int idNegoAcq = (int)c.exeRequetteOpen("SELECT idclient FROM Acquereurs WHERE id_acq = " + DropDownListAcq.SelectedValue).Tables[0].Rows[0]["idclient"];
        int idNegoAcq = (int)c.exeRequetteOpen("SELECT idclient FROM Acquereurs WHERE id_acq = " + DropDownListAcq.SelectedValue).Tables[0].Rows[0]["idclient"];

        int idVente = int.Parse(Request.QueryString["id"]);
        //int idNegoVente = 0;
        
        string idNegoV = c.exeRequetteOpen("SELECT * FROM Biens WHERE ref = '" + Request.QueryString["ref"] + "'").Tables[0].Rows[0]["idclient"].ToString();


        int idNegoVente = int.Parse(idNegoV);

        //bool mandatPlusVente = (idNegoAcq == member.IDCLIENT);
        bool mandatPlusVente = (idNegoAcq == idNegoVente);
        ArrayList listeParrainsVendeur = new ArrayList();
        ArrayList listeParrainsAcq = new ArrayList();

        c.exeRequetteOpen("DELETE * From Ventes_honoraires WHERE id_vente = " + idVente);

        //Enregistrement des honoraires
        enregistrerHonoraire(mandatPlusVente, idVente, int.Parse(TextBoxHonoraires.Text), idNegoAcq, idNegoVente);

        c.Close();
        c = null;
        
        enregistrerFichiers(idVente.ToString());
        Response.Redirect("./mesVentes.aspx?action=modif");
        //msg.Text =" Mise à jour effectuée.<br/>";
    }

    protected void saveVente_Click(object sender, EventArgs e)
    {                
        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        msg.Text = "";

        bool mandatPlusVente = true;    //Si la personne qui apporte le mandat est la meme que celle qui effectue la vente.
        int honoraires = int.Parse(TextBoxHonoraires.Text);

        Membre member = (Membre)Session["Membre"];

        if (member == null)
            Response.Redirect("sessionExpire.aspx");

        //Enregistrement de la vente

        double ratioMandataire = double.Parse(ratioNegoMandat.Text) / 100;
        double ratioVendeur = (70 - double.Parse(ratioNegoMandat.Text)) / 100;

        string[] date = TextBoxDateCompromis.Text.Split('/');
        string dateCompromisEN = "null";
        if (date.Length == 3)
            dateCompromisEN = "#" + date[1] + "/" + date[0] + "/" + date[2] + "#";

        date = TextBoxDateSignature.Text.Split('/');
        string dateSignatureEN = "null";
        if (date.Length == 3)
            dateSignatureEN = "#" + date[1] + "/" + date[0] + "/" + date[2] + "#";

        string requete = "INSERT INTO Ventes(`id_nego`, `id_acquereur`, `ref_bien`, `prix_vente`, `commission`, `sequestre`, `nom_notaire`, `prenom_notaire`, `adresse_notaire`, `cp_notaire`, `ville_notaire`, `tel_notaire`, `mail_notaire`, `taux_mandat`, `taux_vente`, `date_compromis`, `date_signature`) VALUES "
            + "("
            + member.IDCLIENT + "," + DropDownListAcq.SelectedValue + ",'" + Request.QueryString["ref"] + "',"
            + TextBoxPrix.Text + "," + TextBoxHonoraires.Text + "," + TextBoxSequestre.Text + ","
            + "'" + textnotnom.Text + "','" + textnotprenom.Text + "','" + textnotadresse.Text + "','" + textnotcp.Text + "','" + textnotville.Text + "','" + textnottel.Text + "','" + textnotmail.Text + "'"
            + "," + ratioMandataire.ToString().Replace(',', '.') + "," + ratioVendeur.ToString().Replace(',', '.')
            + "," + dateCompromisEN
            + "," + dateSignatureEN
            + ")";

        c.Open();

        c.exeRequetteOpen(requete);

        c.Close();


        //recupération de l'idNegoAcq
        c.Open();
        
        //int idNegoAcq = (int)c.exeRequetteOpen("SELECT idclient FROM Acquereurs WHERE id_acq = " + DropDownListAcq.SelectedValue).Tables[0].Rows[0]["idclient"];
        int idNegoAcq = (int)c.exeRequetteOpen("SELECT idclient FROM Acquereurs WHERE id_acq = " + DropDownListAcq.SelectedValue).Tables[0].Rows[0]["idclient"];

        c.Close();
        labelTest.Text = idNegoAcq.ToString();
        //recupératino de ID de la vente
        string requet = "SELECT Ventes.ID FROM Ventes WHERE (Ventes.ref_bien)='" + Request.QueryString["ref"] + "' ORDER BY Ventes.ID DESC";

        OdbcConnection co = new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        OdbcCommand requett = new OdbcCommand(requet, co);

        co.Open();

        OdbcDataReader read = requett.ExecuteReader();

        read.Read();

        int idvente = int.Parse(read["ID"].ToString());

        co.Close();

        //Recupération de idNegoVente
        string req = "SELECT Biens.idclient FROM Biens WHERE (((Biens.ref)='" + Request.QueryString["ref"] + "'))";

        OdbcConnection connect = new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        OdbcCommand requette = new OdbcCommand(req, connect);

        connect.Open();

        OdbcDataReader reader = requette.ExecuteReader();

        reader.Read();

        int idNegoVente = int.Parse(reader["idclient"].ToString());

        connect.Close();

        //Test si c'est le même négo
        if (idNegoAcq != idNegoVente)
            mandatPlusVente = false;

        //Enregistrement des honoraires
        enregistrerHonoraire(mandatPlusVente, idvente, honoraires, idNegoAcq, idNegoVente);

        enregistrerFichiers(idvente.ToString());

        Response.Redirect("./mesVentes.aspx?action=ajout");
        //msg.Text ="Vente enregistrée.<br/><br/>";

    }

    private void getParrains(Connexion c, ArrayList list, int idnego)
    {
        negoMail.Text = "test";
        int i = 0;
        //string idparrain = c.exeRequetteOpen("SELECT idparrain FROM Clients WHERE idclient = " + idnego).Tables[0].Rows[0]["idparrain"].ToString();
        //while (idparrain != "")
        //{
        //    if (i == 7) break;
        //    list.Add(idparrain);
        //    idparrain = c.exeRequetteOpen("SELECT idparrain FROM Clients WHERE idclient = " + idparrain).Tables[0].Rows[0]["idparrain"].ToString();
        //    i++;
        //}
        
        string req = "SELECT idparrain FROM Clients WHERE idclient =" +idnego ;
        OdbcConnection connection = new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        OdbcCommand execReq = new OdbcCommand(req, connection);
        connection.Open();
        OdbcDataReader reader = execReq.ExecuteReader();

        string read = "";
        int idP;
        reader.Read();
        read = reader["idparrain"].ToString();
        int.TryParse(read, out idP);
        reader.Close();
        read = "";
        int id;
        id = idP;
        
        while (id != null || id != 0)
        {
            if (i == 7 || id == 0) break;
            list.Add(id);
            string req1 = "SELECT idparrain FROM Clients WHERE idclient =" + id;
            OdbcCommand execReq1 = new OdbcCommand(req1, connection);
            OdbcDataReader reader1 = execReq1.ExecuteReader();
            
            reader1.Read();
            if (reader1.HasRows)
            {
                read = reader1["idparrain"].ToString();
                int.TryParse(read, out id);
                reader1.Close();
                read = "";
                i++;
            }
            else
                break;
        }
        connection.Close();
    }

    private void enregistrerHonoraire(bool mandatPlusVente, int idVente, int honoraires, int idNegoAcq, int idNegoVente)
    {
        double[] ratioParrain = { 0.05, 0.04, 0.03, 0.02, 0.01, 0.005, 0.0025 };
        double ratioMandataire = double.Parse(ratioNegoMandat.Text) / 100;
        double ratioVendeur = (70 - double.Parse(ratioNegoMandat.Text)) / 100;
        ArrayList listeParrain = new ArrayList();

        Membre member = (Membre)Session["membre"];

        string req = null, type = null;
        double pourcentage = 0, montant = 0;
        int i = 0;

        //si les deux nego sont identiques
        if (mandatPlusVente)
        {
            type = "'Mandat et Vente'";
            pourcentage = 0.7;
            montant = honoraires * pourcentage;

            req = "INSERT INTO Ventes_honoraires(`id_vente`, `id_nego`, `parrainage`, `type`, `montant`, `pourcentage`) VALUES('" + idVente + "','" + idNegoVente + "'," + "false" + "," + type + ",'" + montant + "','" + pourcentage + "')";

            Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            c.Open();

            c.exeRequette(req);

            c.Close();

            getParrains(c, listeParrain, idNegoVente);

            while (i != listeParrain.Count)
            {

                montant = honoraires * ratioParrain[i];

                req = "INSERT INTO Ventes_honoraires(`id_vente`, `id_nego`, `parrainage`, `type`, `montant`, `pourcentage`) VALUES('" + idVente + "','" + listeParrain[i] + "'," + "true" + "," + type + ",'" + montant + "','" + ratioParrain[i] + "')";

                c.Open();

                c.exeRequette(req);

                c.Close();

                i++;
            }
            labelTest.Text =  idNegoVente.ToString();
        }
        else
        {
            type = "'Mandat'";
            pourcentage = ratioMandataire;
            montant = honoraires * pourcentage;

            req = "INSERT INTO Ventes_honoraires(`id_vente`, `id_nego`, `parrainage`, `type`, `montant`, `pourcentage`) VALUES('" + idVente + "','" + idNegoVente + "'," + "false" + "," + type + ",'" + montant + "','" + pourcentage + "')";

            Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            c.Open();

            c.exeRequette(req);

            c.Close();

            getParrains(c, listeParrain, idNegoVente);

            while (i != listeParrain.Count)
            {
                var coeffParain = ratioMandataire / (ratioMandataire + ratioVendeur);
                montant = honoraires * ratioParrain[i] * coeffParain;

                req = "INSERT INTO Ventes_honoraires(`id_vente`, `id_nego`, `parrainage`, `type`, `montant`, `pourcentage`) VALUES('" + idVente + "','" + listeParrain[i] + "'," + "true" + "," + type + ",'" + montant + "','" + ratioParrain[i] + "')";

                c.Open();

                c.exeRequette(req);

                c.Close();

                i++;
            }

            type = "'Vente'";
            pourcentage = ratioVendeur;
            montant = honoraires * pourcentage;

            req = "INSERT INTO Ventes_honoraires(`id_vente`, `id_nego`, `parrainage`, `type`, `montant`, `pourcentage`) VALUES('" + idVente + "','" + idNegoAcq + "'," + "false" + "," + type + ",'" + montant + "','" + pourcentage + "')";

            c.Open();

            c.exeRequette(req);

            c.Close();

            listeParrain.Clear();
            i = 0;

            getParrains(c, listeParrain, idNegoAcq);

            while (i != listeParrain.Count)
            {
                var coeffParain = ratioVendeur / (ratioMandataire + ratioVendeur);
                montant = honoraires * ratioParrain[i] * coeffParain;

                req = "INSERT INTO Ventes_honoraires(`id_vente`, `id_nego`, `parrainage`, `type`, `montant`, `pourcentage`) VALUES('" + idVente + "','" + listeParrain[i] + "'," + "true" + "," + type + ",'" + montant + "','" + ratioParrain[i] + "')";

                c.Open();

                c.exeRequette(req);

                c.Close();

                i++;
            }
            labelTest.Text = "PFFF";
        }
    }

    private void enregistrerFichiers(string idvente)
    {

            Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c.Open();
            System.Data.DataSet ds2 = c.exeRequette("Select * from Environnement");
            c.Close();
            String racine_site = (String)ds2.Tables[0].Rows[0]["Chemin_racine_site"];
            string filePathPromesse = racine_site + "Ventes\\" + Request.QueryString["id"] + "_promesse.pdf";

            //if (!System.IO.File.Exists(filePathPromesse))
            //{

                if (filePromesse.HasFile || fileActe.HasFile)
                {
                    try
                    {
                        if (filePromesse.HasFile)
                            filePromesse.SaveAs(racine_site + "Ventes\\" + idvente + "_promesse.pdf");


                        if (fileActe.HasFile)
                            fileActe.SaveAs(racine_site + "Ventes\\" + idvente + "_acte.pdf");
                    }
                    catch (Exception ex) { msg.Text = "ERROR: " + ex.Message.ToString(); }
                }
            //}

    }

    protected void enregistrerlenotaire(object sender, EventArgs e)
    {
        Membre member = (Membre)Session["Membre"];

        string req = null;

        OdbcConnection c = new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        if (textnotfax.Text != "" && textnotpays.Text != "")
        {
            req = "INSERT INTO Notaires(`nom`, `prenom`, `adresse`, `code_postal`, `ville`, `mail`, `telephone`, `pays`, `fax`) VALUES('" + textnotnom.Text + "','" + textnotprenom.Text + "','" + textnotadresse.Text + "','" + textnotcp.Text + "','" + textnotville.Text + "','" + textnotmail.Text + "','" + textnottel.Text + "','" + textnotpays.Text + "','" + textnotfax.Text + "')";
        }
        if (textnotpays.Text == "")
        {
            req = "INSERT INTO Notaires(`nom`, `prenom`, `adresse`, `code_postal`, `ville`, `mail`, `telephone`, `pays`, `fax`) VALUES('" + textnotnom.Text + "','" + textnotprenom.Text + "','" + textnotadresse.Text + "','" + textnotcp.Text + "','" + textnotville.Text + "','" + textnotmail.Text + "','" + textnottel.Text + "','" + "France" + "','" + textnotfax.Text + "')";
        }
        if (textnotfax.Text == "")
        {
            req = "INSERT INTO Notaires(`nom`, `prenom`, `adresse`, `code_postal`, `ville`, `mail`, `telephone`, `pays`, `fax`) VALUES('" + textnotnom.Text + "','" + textnotprenom.Text + "','" + textnotadresse.Text + "','" + textnotcp.Text + "','" + textnotville.Text + "','" + textnotmail.Text + "','" + textnottel.Text + "','" + textnotpays.Text + "','" + "0" + "')";
        }
        if (textnotfax.Text == "" && textnotpays.Text == "")
        {
            req = "INSERT INTO Notaires(`nom`, `prenom`, `adresse`, `code_postal`, `ville`, `mail`, `telephone`, `pays`, `fax`) VALUES('" + textnotnom.Text + "','" + textnotprenom.Text + "','" + textnotadresse.Text + "','" + textnotcp.Text + "','" + textnotville.Text + "','" + textnotmail.Text + "','" + textnottel.Text + "','" + "France" + "','" + "0" + "')";
        }

        OdbcCommand requette = new OdbcCommand(req, c);

        c.Open();

        requette.ExecuteNonQuery();

        c.Close();

        //remplissage de la table lien_client_notaire
        req = "SELECT Notaires.id_notaire FROM Notaires ORDER BY Notaires.id_notaire DESC";

        requette = new OdbcCommand(req, c);

        c.Open();

        OdbcDataReader read = requette.ExecuteReader();

        read.Read();

        int idNotaire = int.Parse(read["id_notaire"].ToString());

        c.Close();

        req = "INSERT INTO lien_clients_notaires(`id_notaire`,`id_client`) VALUES('" + idNotaire + "','" + member.IDCLIENT + "')";

        requette = new OdbcCommand(req, c);

        c.Open();

        requette.ExecuteNonQuery();

        c.Close();

        Response.Redirect(Request.RawUrl);
    }

    protected void modifiernot(object sender, EventArgs e)
    {
        string req = null;

        OdbcConnection c = new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        req = "UPDATE Notaires SET nom='" + textnotnom.Text + "',prenom='" + textnotprenom.Text + "',adresse='" + textnotadresse.Text + "',code_postal='" + textnotcp.Text + "',ville='" + textnotville.Text + "',mail='" + textnotmail.Text + "',telephone='" + textnottel.Text + "',pays='" + textnotpays.Text + "',fax='" + textnotfax.Text + "' WHERE id_notaire=" + textnotid.Text;

        OdbcCommand requette = new OdbcCommand(req, c);

        c.Open();

        requette.ExecuteNonQuery();

        c.Close();

        Response.Redirect(Request.RawUrl);

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

    protected void InformationNegoAcquereur()
    {

        if (Request.QueryString["acq"] != null && Request.QueryString["acq"] != "0" && Request.QueryString["acq"] != "")
        {
            string req = "SELECT Clients.id_client, Clients.nom_client, Clients.prenom_client, Clients.tel_client, Clients.adresse_client, Clients.postal_client, Clients.ville_client  FROM Acquereurs INNER JOIN Clients ON Acquereurs.idclient = Clients.idclient WHERE (Acquereurs.id_acq)=" + Request.QueryString["acq"];

            Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            c.Open();

            DataRow negoacq = c.exeRequetteOpen(req).Tables[0].Rows[0];

            c.Close();

            string codeiso = Code_iso("negoacq");

            negoacqnom.Text = negoacq["prenom_client"].ToString() + " " + negoacq["nom_client"].ToString().ToUpper();
            negoacqadresse.Text = "<img height='20px'  src='../img_site/drapeau/" + codeiso + ".png'/>" + "<div class='tooltip'><span>" + "<img height='50px'  src='../img_site/drapeau/" + codeiso + ".png'/></span></div>" + "&nbsp;" + "<a href='https://www.google.fr/maps/place/" + negoacq["adresse_client"] + " " + negoacq["ville_client"] + "' target='_blank'><img style='cursor:pointer' src='../img_site/flat_round/monde.png' height='20px'/></a>" + " " + negoacq["adresse_client"].ToString() + "<br/>" + "&nbsp;&nbsp;" + negoacq["postal_client"].ToString() + ", " + negoacq["ville_client"].ToString();
            negoacqtel.Text = negoacq["tel_client"].ToString();
            negoacqmail.Text = "<a href='mailto:" + negoacq["id_client"] + "'>" + negoacq["id_client"].ToString() + "</a>";
         }
        
        else
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != "" && Request.QueryString["id"] !="0")
            {
                //string req = "SELECT Clients.id_client, Clients.nom_client, Clients.prenom_client, Clients.tel_client, Clients.adresse_client, Clients.postal_client, Clients.ville_client  FROM Acquereurs INNER JOIN Clients ON Acquereurs.idclient = Clients.idclient WHERE (Acquereurs.id_acq)=" + Request.QueryString["acq"];
                string req = "SELECT Clients.idclient, Clients.id_client, Clients.nom_client, Clients.prenom_client, Clients.tel_client, Clients.adresse_client, Clients.postal_client, Clients.ville_client FROM Ventes INNER JOIN Clients ON Ventes.id_nego = Clients.idclient WHERE (Ventes.ID)=" + Request.QueryString["id"];
                Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                c.Open();

                DataRow negoacq = c.exeRequetteOpen(req).Tables[0].Rows[0];

                c.Close();
                string idNego = negoacq["idclient"].ToString();
                string codeiso = Code_iso("negoacq", null, idNego);
                
                negoacqnom.Text = negoacq["prenom_client"].ToString() + " " + negoacq["nom_client"].ToString().ToUpper();
                negoacqadresse.Text = "<img height='20px'  src='../img_site/drapeau/" + codeiso + ".png'/>" + "<div class='tooltip'><span>" + "<img height='50px'  src='../img_site/drapeau/" + codeiso + ".png'/></span></div>" + "&nbsp;" + "<a href='https://www.google.fr/maps/place/" + negoacq["adresse_client"] + " " + negoacq["ville_client"] + "' target='_blank'><img style='cursor:pointer' src='../img_site/flat_round/monde.png' height='20px'/></a>" + " " + negoacq["adresse_client"].ToString() + "<br/>" + "&nbsp;&nbsp;" + negoacq["postal_client"].ToString() + ", " + negoacq["ville_client"].ToString();
                negoacqtel.Text = negoacq["tel_client"].ToString();
                negoacqmail.Text = "<a href='mailto:" + negoacq["id_client"] + "'>" + negoacq["id_client"].ToString() + "</a>";
            }

    }

    protected void Change_info_nego_acq(object sender, EventArgs e)
    {
        string req = "SELECT Clients.idclient, Clients.id_client, Clients.nom_client, Clients.prenom_client, Clients.tel_client, Clients.adresse_client, Clients.postal_client, Clients.ville_client FROM Acquereurs INNER JOIN Clients ON Acquereurs.idclient = Clients.idclient WHERE (Acquereurs.id_acq)=" + DropDownListAcq.SelectedValue.ToString();

        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        c.Open();

        DataRow negoacq = c.exeRequetteOpen(req).Tables[0].Rows[0];

        c.Close();
        string idNego = negoacq["idclient"].ToString();
        string codeiso = Code_iso("negoacq",null, idNego);

        negoacqnom.Text = negoacq["prenom_client"].ToString() + " " + negoacq["nom_client"].ToString().ToUpper();
        negoacqadresse.Text = "<img height='20px'  src='../img_site/drapeau/" + codeiso + ".png'/>" + "<div class='tooltip'><span>" + "<img height='50px'  src='../img_site/drapeau/" + codeiso + ".png'/></span></div>" + "&nbsp;" + "<a href='https://www.google.fr/maps/place/" + negoacq["adresse_client"] + " " + negoacq["ville_client"] + "' target='_blank'><img style='cursor:pointer' src='../img_site/flat_round/monde.png' height='20px'/></a>" + " " + negoacq["adresse_client"].ToString() + "<br/>" + "&nbsp;&nbsp;" + negoacq["postal_client"].ToString() + ", " + negoacq["ville_client"].ToString();
        negoacqtel.Text = negoacq["tel_client"].ToString();
        negoacqmail.Text = "<a href='mailto:" + negoacq["id_client"] + "'>" + negoacq["id_client"].ToString() + "</a>";

        Change_info_titre_acq(sender, e);

    }

    protected void Change_info_titre_acq(object sender, EventArgs e)
    {
        string req = "SELECT Acquereurs.nom, Acquereurs.prenom FROM Acquereurs WHERE (Acquereurs.id_acq)=" + DropDownListAcq.SelectedValue.ToString();

        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        c.Open();

        DataRow acq = c.exeRequetteOpen(req).Tables[0].Rows[0];

        c.Close();

        nomacquereur.Text = acq["nom"].ToString() + " " + acq["prenom"].ToString();

    }

    protected string Code_iso(string choix, Bien bien = null, string nego = null)
    {

        string req = null;

        switch (choix)
        {

            case "bieniso":
                req = "SELECT Pays.codeiso FROM (Biens INNER JOIN optionsBiens ON Biens.ref = optionsBiens.refOptions) INNER JOIN Pays ON optionsBiens.PaysBien = Pays.Titre_Pays WHERE (((Biens.ref)='" + bien.REFERENCE + "'))";
                break;

            case "vendeur":
                if (bien.PAYS_VENDEUR != null && bien.PAYS_VENDEUR != "")
                    req = "SELECT Pays.codeiso FROM Biens INNER JOIN Pays ON Biens.[pays vendeur] = Pays.Titre_Pays WHERE (((Biens.[pays vendeur])='" + bien.PAYS_VENDEUR + "'))";
                else
                    req = "";
                break;

            case "negomandat":
                req = "SELECT Pays.codeiso FROM (Biens INNER JOIN Clients ON Biens.idclient = Clients.idclient) INNER JOIN Pays ON Clients.pays_client = Pays.Titre_Pays WHERE (((Biens.ref)='" + Request.QueryString["ref"] + "'))";
                break;

            case "negoacq":
                if (nego != null)
                    req = "SELECT Pays.codeiso FROM (Acquereurs INNER JOIN Clients ON Clients.idclient = Acquereurs.idclient) INNER JOIN Pays ON Clients.pays_client = Pays.Titre_Pays WHERE Acquereurs.idclient =" + nego;
                else
                    if (nego == null)
                        req = "SELECT Pays.codeiso FROM (Acquereurs INNER JOIN Clients ON Acquereurs.idclient = Clients.idclient) INNER JOIN Pays ON Clients.pays_client = Pays.Titre_Pays WHERE (Acquereurs.id_acq)=" + Request.QueryString["acq"];
                break;

            case "notaire":
                req = "";
                break;
        }
        OdbcConnection c = null;
        string codeiso;
        if (req != "")
        {
            c = new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            OdbcCommand requette = new OdbcCommand(req, c);
            c.Open();
            OdbcDataReader reader = requette.ExecuteReader();
            reader.Read();
            codeiso = reader["codeiso"].ToString();
            c.Close();
        }
        else
            codeiso = "";
        return codeiso;
    }



}


