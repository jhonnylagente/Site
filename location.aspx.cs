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

public partial class location : System.Web.UI.Page
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
            int honoraires = (int)bien["honoraires"];
            int prix = (int)bien["loyer_cc"];
            int depotGarantie = (int)bien["depot_guarantie"];

            if (depotGarantie == 0 || depotGarantie == null)
            {
                depotGarantie = prix;
            }
            ((Label)Page.Master.FindControl("titrebandeau")).Text = "Proposer location";
            //*****HONORAIRES TextBoxHonoraires.Text = honoraires.ToString();
            TextBoxPrix.Text = prix.ToString();
            TextBoxDepotGarantie.Text = depotGarantie.ToString();

            if (Request.QueryString["acq"] != null)
            {
            
                TextBoxHonoraires.Text = (prix*2).ToString();
            }
            else
                TextBoxHonoraires.Text = honoraires.ToString();

            string codeiso = Code_iso("negomandat");

            DataRow negoMandat = c.exeRequetteOpen("SELECT Clients.* FROM Clients,Biens WHERE Biens.idclient = Clients.idclient AND Biens.ref = '" + Request.QueryString["ref"] + "'").Tables[0].Rows[0];
            nego.Text = negoMandat["prenom_client"].ToString() + " " + negoMandat["nom_client"].ToString().ToUpper();
            negoadresse.Text = "<img height='20px'  src='../img_site/drapeau/" + codeiso + ".png'/>" + "<div class='tooltip'><span>" + "<img height='50px'  src='../img_site/drapeau/" + codeiso + ".png'/></span></div>" + "&nbsp;" + "<a href='https://www.google.fr/maps/place/" + negoMandat["adresse_client"] + " " + negoMandat["ville_client"].ToString() + "' target='_blank'><img style='cursor:pointer' src='../img_site/flat_round/monde.png' height='20px'/></a>" + " " + negoMandat["adresse_client"].ToString() + "<br/>" + "&nbsp;&nbsp;" + negoMandat["postal_client"].ToString() + ", " + negoMandat["ville_client"].ToString();
            negoTel.Text = negoMandat["tel_client"].ToString();
            negoMail.Text = "<a href='mailto:" + negoMandat["id_client"] + "'>" + negoMandat["id_client"] + "</a>";

            string req, req1;
            if (member.STATUT == "ultranego")
            {
                req = "SELECT id_acq,nom,prenom,tel,mail,code_postal,ville,idclient,adresse,pays FROM Acquereurs WHERE actif='actif' AND type_acquereur = 'Loueur' ORDER BY Nom ASC";
                req1 = "SELECT id_notaire,nom,prenom,adresse,code_postal,ville,mail,telephone,pays,fax FROM Notaires ORDER BY Nom ASC";
            }
            else
            {
                req = "SELECT id_acq,nom,prenom,tel,mail,code_postal,ville,idclient,adresse,pays FROM Acquereurs WHERE actif='actif' AND type_acquereur = 'Loueur' AND idclient = " + member.IDCLIENT + " ORDER BY Nom ASC";
                req1 = "SELECT Notaires.id_notaire,nom,prenom,adresse,code_postal,ville,mail,telephone,pays,fax FROM Notaires INNER JOIN lien_clients_notaires ON lien_clients_notaires.id_notaire=Notaires.id_notaire WHERE lien_clients_notaires.id_client = " + member.IDCLIENT + " ORDER BY Nom ASC";
            }

            DataRowCollection listeAcquereur = c.exeRequetteOpen(req).Tables[0].Rows;
            foreach (DataRow acq in listeAcquereur)
            {
                string nomnegoacq = null, prenomnegoacq = null;

                string idacq = acq["id_acq"].ToString();

                req = "SELECT Clients.nom_client, Clients.prenom_client  FROM Acquereurs INNER JOIN Clients ON Acquereurs.idclient = Clients.idclient WHERE ((Acquereurs.id_acq)=" + idacq + ")";

                OdbcConnection connect = new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                OdbcCommand maCommande = new OdbcCommand(req, connect);

                connect.Open();

                OdbcDataReader read = maCommande.ExecuteReader();

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

            // ********** NOTAIRE****************

            //******CONSULTATION DETAILS LOCATION******//
            if (Request.QueryString["id"] != null)
            {
                DataSet dataSet = c.exeRequetteOpen("SELECT * FROM Environnement");
                String racine_site = (String)dataSet.Tables[0].Rows[0]["Chemin_racine_site"];

                // *** AJOUTER LE CHEMIN ***//
                String filePathBail = racine_site + "Locations\\" + Request.QueryString["id"] + "_bail.pdf";

                if (System.IO.File.Exists(filePathBail))
                {
                    //oldpromesse a changer dans le design pareil pour file promesse et newpromesse
                    oldBail.Text = "<span id='newBail'><a href='../Locations/" + Request.QueryString["id"] + "_bail.pdf' target='_blank'>Voir Fichier</a></span>";
                    fileBail.Attributes["style"] += ";width: 140px;color:white;";
                }

                string val = "";

                if (Request.QueryString["id"] != null)
                    val = Request.QueryString["id"];
                else
                    if (Request.QueryString["acq"] != null)
                        val = Request.QueryString["acq"];
                // Changer vente et verifier dans la table si les locations sont prises en compte ou non
                DataRow location = c.exeRequetteOpen("SELECT * FROM Locations WHERE ID =" + val).Tables[0].Rows[0];
                // besoin d'une signature pour une location ?
                bool locationValidee = (bool)location["valider_signature"];
                DropDownListAcq.SelectedValue = location["id_acquereur"].ToString();
                TextBoxDateSignature.Text = location["date_signature_bail"].ToString().Split(' ')[0];
                ratioNegoMandat.Text = ((double)location["taux_mandat"] * 100).ToString();
                ratioNegoVente.Text = ((double)location["taux_location"] * 100).ToString();

                // table vente ?
                TextBoxPrix.Text = location["prix_loyer"].ToString();
                TextBoxDepotGarantie.Text = location["depot_garantie"].ToString();
                TextBoxHonoraires.Text = location["commission"].ToString();

                //*****NOTAIRE*****//

                int idNegoMandataire = (int)location["id_nego"];
                int idNegoLocation = (int)c.exeRequetteOpen("SELECT idclient FROM Acquereurs WHERE id_acq = " + location["id_acquereur"].ToString()).Tables[0].Rows[0]["idclient"];

                SaveLocation.Visible = false;
                //saveLocation.Visible=false;

                // VOIR SI IL FAUT FAIRE CETTE VERIF POUR UNE LOCATION
                if ((!locationValidee && member.IDCLIENT == idNegoMandataire) || (!locationValidee && member.IDCLIENT == idNegoLocation) || member.STATUT == "ultranego")
                {
                    UpdateLocation.Visible = true;
                }
                else
                {
                    edit = false;
                    if (locationValidee)
                        msg.Text = "Location validée, aucune modification possible.<br/>";
                }
            }
            c.Close();
            RemplirTableauBien(Request.QueryString["ref"]);
        }
    }
    protected void RemplirTableauBien(string refBien)
    {
        String req = "SELECT * FROM Biens INNER JOIN optionsBiens ON Biens.ref = optionsBiens.refOptions WHERE Biens.ref = '" + refBien + "'";
        DataSet dataSet = null;
        Connexion c = null;

        c = new Connexion(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();
        dataSet = c.exeRequette(req);
        c.Close();
        c = null;

        DataRowCollection dataRow = dataSet.Tables[0].Rows;

        Bien bien = new Bien();

        foreach (DataRow ligne in dataRow)
        {
            bien.REFERENCE = ligne["ref"].ToString();
            bien.REFERENCE = ligne["ref"].ToString();
            bien.ETAT = ligne["etat"].ToString();
            bien.TYPE_BIEN = ligne["type de bien"].ToString();
            bien.S_HABITABLE = (int)ligne["surface habitable"];
            bien.S_SEJOUR = (int)ligne["surface séjour"];
            bien.S_TERRAIN = (int)ligne["surface terrain"];
            bien.NBRE_PIECE = (int)ligne["nombre de pieces"];
            bien.NBRE_CHAMBRE = (int)ligne["nombre de chambres"];
            bien.CODE_POSTAL_BIEN = ligne["code postal du bien"].ToString();
            bien.VILLE_BIEN = ligne["ville du bien"].ToString().ToUpper();
            bien.NEGOCIATEUR = ligne["negociateur"].ToString();
            bien.LOYER_CC = (int)ligne["loyer_cc"];
            bien.PRIX_VENTE = (int)ligne["prix de vente"];
            bien.PAYS = ligne["PaysBien"].ToString().ToUpper();
            bien.ADRESSE_BIEN = ligne["adresse du bien"].ToString();
            bien.ADRESSE_VENDEUR = ligne["adresse vendeur"].ToString();
            //bien.CODE_POSTAL_VENDEUR = int.Parse(ligne2["code postal vendeur"].ToString());
            bien.CODE_POSTAL_VENDEUR = ligne["code postal vendeur"].ToString();
            bien.VILLE_VENDEUR = ligne["ville vendeur"].ToString();
            bien.PAYS_VENDEUR = ligne["pays vendeur"].ToString();
            bien.PRENOM_VENDEUR = ligne["prenom vendeur"].ToString();
            bien.NOM_VENDEUR = ligne["nom vendeur"].ToString();
        }
        // METHODE A FAIRE
        int nbPhotos = CheckNombrePhotos(bien.REFERENCE);

        switch (nbPhotos)
        {
            case 0:
                LabelImage.Text = "<img style='width:125px;' src='../img_site/images_par_defaut/" + bien.TYPE_BIEN + ".jpg' alt='photo'>"
                                 + "<div class='tooltip'><span>" + "<img style='width:250px' src='../img_site/images_par_defaut/" + bien.TYPE_BIEN + ".jpg' alt='photo'></span></div>";
                break;

            case 1:
                LabelImage.Text = "<img style='width:125px;' src='../images/" + bien.REFERENCE + "A.jpg' alt='photo'>"
                                 + "<div class='tooltip'><span>" + nbPhotos + " Photo <br/>" + "<img style='width:250px' src='../images/" + bien.REFERENCE + "A.jpg' alt='photo'></span></div>";
                break;

            default:
                LabelImage.Text = "<img style='width:125px;' src='../images/" + bien.REFERENCE + "A.jpg' alt='photo'>"
                                 + "<div class='tooltip'><span>" + nbPhotos + " Photos <br/>" + "<img style='width:250px;' src='../images/" + bien.REFERENCE + "A.jpg' alt='photo'> " + "<img style='margin-left:5px;width:250px;' src='../images/" + bien.REFERENCE + "B.jpg' alt='photo'></span></div>";
                break;
        }

        //REMPLASSER LABEL0 PAR lblReference
        lblReference.Text = ": " + bien.REFERENCE;
        // REMPLASSER Label12 PAR lblFicheDetails
        Label12.Text = "<a href=\"./fichedetail1.aspx?ref=" + bien.REFERENCE + "\" target='_blank'>Voir Fiche</a>";

        switch (bien.TYPE_BIEN)
        {
            case "A":
                lblTypeBien.Text = ": Appartement";
                //Label2.Text = ": Appartement";
                break;
            case "M":
                lblTypeBien.Text = ": Maison";
                //Label2.Text = ": Maison";
                break;
            case "I":
                lblTypeBien.Text = ": Immeuble";
                //Label2.Text = ": Immeuble";
                break;
            case "L":
                lblTypeBien.Text = ": Local";
                //Label2.Text = ": Local";
                break;
            case "T":
                lblTypeBien.Text = ": Terrain";
                //Label2.Text = ": Terrain";
                break;
        }
        string codeiso = Code_iso("bieniso", bien);

        //Label3.Text = ": " + bien.S_HABITABLE.ToString();
        lblSurfaceHabitableBien.Text = ": " + bien.S_HABITABLE.ToString();
        //Label3bis.Text = ": " + bien.S_SEJOUR.ToString();
        lblSurfaceSejourBien.Text = ": " + bien.S_SEJOUR.ToString();
        //Label4.Text = ": " + bien.S_TERRAIN.ToString();
        lblSurfaceTerrainBien.Text = ": " + bien.S_TERRAIN.ToString();
        //Label5.Text = ": " + bien.NBRE_PIECE.ToString();
        lblNbPiecesBien.Text = ": " + bien.NBRE_PIECE.ToString();
        //Label6.Text = bien.CODE_POSTAL_BIEN + ", " + bien.VILLE_BIEN;
        lblCpVilleBien.Text = bien.CODE_POSTAL_BIEN + ", " + bien.VILLE_BIEN;
        //Label7.Text = ": " + "<img height='20px'  src='../img_site/drapeau/" + codeiso + ".png'/>" + "<div class='tooltip'><span>" + "<img height='50px'  src='../img_site/drapeau/" + codeiso + ".png'/></span></div>" + "&nbsp;" + "<a href='https://www.google.fr/maps/place/" + bien.ADRESSE_BIEN + " " + bien.VILLE_BIEN + "' target='_blank'><img style='cursor:pointer' src='../img_site/flat_round/monde.png' height='20px'/></a>" + " " + bien.ADRESSE_BIEN;
        lblCodeIsoBien.Text = ": " + "<img height='20px'  src='../img_site/drapeau/" + codeiso + ".png'/>" + "<div class='tooltip'><span>" + "<img height='50px'  src='../img_site/drapeau/" + codeiso + ".png'/></span></div>" + "&nbsp;" + "<a href='https://www.google.fr/maps/place/" + bien.ADRESSE_BIEN + " " + bien.VILLE_BIEN + "' target='_blank'><img style='cursor:pointer' src='../img_site/flat_round/monde.png' height='20px'/></a>" + " " + bien.ADRESSE_BIEN;

        //Label9.Text = ": " + bien.LOYER_CC.ToString();
        lblLoyerCC.Text = ": " + bien.LOYER_CC.ToString();

        string temp = lblLoyerCC.Text;
        string prix = "";
        int k = 0;

        while ((k + 1) * 3 < temp.Length)
        {
            prix = temp.Substring((temp.Length - (k + 1) * 3), 3) + " " + prix;
            k++;
        }
        prix = temp.Substring(0, temp.Length - k * 3) + " " + prix;

        lblLoyerCC.Text = prix;

        codeiso = Code_iso("vendeur", bien, null);

        if (codeiso != "" && bien.ADRESSE_VENDEUR != "" && bien.VILLE_VENDEUR != "")
            adresseLoueur.Text = "<img height='20px'  src='../img_site/drapeau/" + codeiso + ".png'/>" + "<div class='tooltip'><span>" + "<img height='50px'  src='../img_site/drapeau/" + codeiso + ".png'/></span></div>" + "&nbsp;" + "<a href='https://www.google.fr/maps/place/" + bien.ADRESSE_VENDEUR + " " + bien.VILLE_VENDEUR + "' target='_blank'><img style='cursor:pointer' src='../img_site/flat_round/monde.png' height='20px'/></a>" + " " + bien.ADRESSE_VENDEUR + "<br/>&nbsp;&nbsp;" + bien.CODE_POSTAL_VENDEUR + ", " + bien.VILLE_VENDEUR;
        else
            if (codeiso == "" || bien.VILLE_VENDEUR == "" || bien.ADRESSE_VENDEUR == "")
                if (bien.ADRESSE_VENDEUR == "" || bien.VILLE_VENDEUR == "")
                    if (codeiso == "")
                        adresseLoueur.Text = bien.ADRESSE_VENDEUR + "<br/>&nbsp;&nbsp;" + bien.CODE_POSTAL_VENDEUR + bien.VILLE_VENDEUR;
                    else
                        adresseLoueur.Text = "<img height='20px'  src='../img_site/drapeau/" + codeiso + ".png'/>" + "<div class='tooltip'><span>" + "<img height='50px'  src='../img_site/drapeau/" + codeiso + ".png'/></span></div>" + "&nbsp;" + " " + bien.ADRESSE_VENDEUR + "<br/>&nbsp;&nbsp;" + bien.CODE_POSTAL_VENDEUR + bien.VILLE_VENDEUR;
                else
                    adresseLoueur.Text = "<a href='https://www.google.fr/maps/place/" + bien.ADRESSE_VENDEUR + " " + bien.VILLE_VENDEUR + "' target='_blank'><img style='cursor:pointer' src='../img_site/flat_round/monde.png' height='20px'/></a>" + " " + bien.ADRESSE_VENDEUR + "<br/>&nbsp;&nbsp;" + bien.CODE_POSTAL_VENDEUR + bien.VILLE_VENDEUR;

        nomvendeur.Text = bien.NOM_VENDEUR + " " + bien.PRENOM_VENDEUR;
    }
    
    //****A FAIRE****//
    protected void UpdateLocation_Click(object sender, EventArgs e)
    {
        if (TextBoxDepotGarantie.Text == "")
            TextBoxDepotGarantie.Text = "0";

        //string[] date = TextBoxDateCompromis.Text.Split('/');
        string[] dateS = TextBoxDateSignature.Text.Split('/');
        //string dateComp = ",null";
        string dateSign = "";

        //if (date.Length == 3)
            //dateComp = "', date_compromis = #" + date[1] + "/" + date[0] + "/" + date[2] + "#";


        if (dateS.Length == 3)
            dateSign = ", date_signature_bail = #" + dateS[1] + "/" + dateS[0] + "/" + dateS[2] + "#";

        double ratioMandataire = double.Parse(ratioNegoMandat.Text)/100;
        double ratioLocation = (70 - double.Parse(ratioNegoMandat.Text)) / 100;
        
        string req = "UPDATE Locations SET"
            + " id_acquereur = " + int.Parse(DropDownListAcq.SelectedValue)
            + ", prix_loyer = " + int.Parse(TextBoxPrix.Text)
            + ", commission = " + int.Parse(TextBoxHonoraires.Text)
            + ", taux_mandat = " + ratioMandataire.ToString().Replace(',', '.')
            + ", taux_location = " + ratioLocation.ToString().Replace(',', '.')         
            + ", depot_garantie = " + int.Parse(TextBoxDepotGarantie.Text)
            + dateSign
            + " WHERE ID = " + Request.QueryString["id"];

        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();

        DataRow oldData = c.exeRequetteOpen("SELECT * FROM Locations WHERE ID = " + Request.QueryString["id"]).Tables[0].Rows[0];
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

        int idLocation = int.Parse(Request.QueryString["id"]);
        //int idNegoVente = 0;

        string idNegoL = c.exeRequetteOpen("SELECT * FROM Biens WHERE ref = '" + Request.QueryString["ref"] + "'").Tables[0].Rows[0]["idclient"].ToString();


        int idNegoLocation = int.Parse(idNegoL);

        //bool mandatPlusVente = (idNegoAcq == member.IDCLIENT);
        bool mandatPlusLocation = (idNegoAcq == idNegoLocation);
        ArrayList listeParrainsLoueur = new ArrayList();
        ArrayList listeParrainsAcq = new ArrayList();

        c.exeRequetteOpen("DELETE * From Ventes_honoraires WHERE id_location = " + idLocation);

        //Enregistrement des honoraires
        EnregistrerHonoraire(mandatPlusLocation, idLocation, int.Parse(TextBoxHonoraires.Text), idNegoAcq, idNegoLocation);

        c.Close();
        c = null;

        EnregistrerFichiers(idLocation.ToString());
        Response.Redirect("./mesLocations.aspx?action=modif");
        //msg.Text =" Mise à jour effectuée.<br/>";
    }
    protected void SaveLocation_Click(object sender, EventArgs e)
    {
        Connexion c = new Connexion(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        msg.Text = "";
        
        bool mandatPlusLocation = true;
        int honoraires;
        try { honoraires = int.Parse(TextBoxHonoraires.Text); }
        catch { honoraires = 0; }

        Membre member = (Membre)Session["Membre"];
        if (member == null)
            Response.Redirect("sessionExpire.aspx");

        //double ratioMandataire = double.Parse(ratioNegoMandat.Text) / 100;
        //double ratioLoueur = (70 - double.Parse(ratioNegoMandat.Text)) / 100;
        double ratioMandataire = double.Parse(ratioNegoMandat.Text) / 100;
        double ratioLoueur = (70 - double.Parse(ratioNegoMandat.Text)) /100;
        string[] dateSignatureBail = TextBoxDateSignature.Text.Split('/');
        string dateSignBail = "null";
        int depot = int.Parse(TextBoxDepotGarantie.Text);
        if (dateSignatureBail.Length == 3)
        {
            dateSignBail = "#" + dateSignatureBail[1] + "/" + dateSignatureBail[0] + "/" + dateSignatureBail[2] + "#";
        }
        if (TextBoxDepotGarantie.Text == "0"|| TextBoxDepotGarantie.Text == "" )
            depot = int.Parse(TextBoxPrix.Text);
        string requete = "INSERT INTO Locations(`id_nego`, `id_acquereur`, `ref_bien`, `prix_loyer`, `commission`, `taux_mandat`, `taux_location`, `depot_garantie`,  `date_signature_bail`) VALUES "
            + "("
            + member.IDCLIENT + "," + DropDownListAcq.SelectedValue + ",'" + Request.QueryString["ref"] + "',"
            + TextBoxPrix.Text + "," + honoraires + "," + ratioMandataire.ToString().Replace(',', '.') + "," + ratioLoueur.ToString().Replace(',', '.') + "," 
            + depot + "," + dateSignBail
           // + "'" + textnotnom.Text + "','" + textnotprenom.Text + "','" + textnotadresse.Text + "','" + textnotcp.Text + "','" + textnotville.Text + "','" + textnottel.Text + "','" + textnotmail.Text + "'"         
            + ")";

        c.Open();

        c.exeRequetteOpen(requete);

        c.Close();
        //recupération de l'idNegoAcq
        c.Open();

        //int idNegoAcq = (int)c.exeRequetteOpen("SELECT idclient FROM Acquereurs WHERE id_acq = " + DropDownListAcq.SelectedValue).Tables[0].Rows[0]["idclient"];
        int idNegoAcq = (int)c.exeRequetteOpen("SELECT idclient FROM Acquereurs WHERE id_acq = " + DropDownListAcq.SelectedValue).Tables[0].Rows[0]["idclient"];

        c.Close();
        //labelTest.Text = idNegoAcq.ToString();
        //recupératino de ID de la vente
        string requet = "SELECT Locations.ID FROM Locations WHERE (Locations.ref_bien)='" + Request.QueryString["ref"] + "' ORDER BY Locations.ID DESC";

        OdbcConnection co = new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        OdbcCommand req1 = new OdbcCommand(requet, co);

        co.Open();

        OdbcDataReader read = req1.ExecuteReader();

        read.Read();

        int idLocation = int.Parse(read["ID"].ToString());

        co.Close();

        //Recupération de idNegoVente
        string req = "SELECT Biens.idclient FROM Biens WHERE (((Biens.ref)='" + Request.QueryString["ref"] + "'))";

        OdbcConnection connect = new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        OdbcCommand requette = new OdbcCommand(req, connect);

        connect.Open();

        OdbcDataReader reader = requette.ExecuteReader();

        reader.Read();

        int idNegoLocation = int.Parse(reader["idclient"].ToString());

        connect.Close();

        //Test si c'est le même négo
        if (idNegoAcq != idNegoLocation)
            mandatPlusLocation = false;

        //Enregistrement des honoraires
        EnregistrerHonoraire(mandatPlusLocation, idLocation, honoraires, idNegoAcq, idNegoLocation);

        EnregistrerFichiers(idLocation.ToString());

        Response.Redirect("./mesLocations.aspx?action=ajout");

    }
    
    protected void enregistrerlenotaire(object sender, EventArgs e)
    {
    
    }
    protected void modifiernot(object sender, EventArgs e)
    {
    }
    
    
    private void EnregistrerHonoraire(bool mandatPlusLocation, int idLocation, int honoraires, int idNegoAcq, int idNegoLocation)
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
        if (mandatPlusLocation)
        {
            type = "'Mandat et Location'";
            pourcentage = 0.7;
            montant = honoraires * pourcentage;

            req = "INSERT INTO Ventes_honoraires(`id_nego`, `parrainage`, `type`, `montant`, `pourcentage`, `id_location`) VALUES('" + idNegoLocation + "'," + "false" + "," + type + ",'" + montant + "','" + pourcentage + "','" + idLocation +"')";

            Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            c.Open();

            c.exeRequette(req);

            c.Close();

            GetParrains(c, listeParrain, idNegoLocation);

            while (i != listeParrain.Count)
            {

                montant = honoraires * ratioParrain[i];

                req = "INSERT INTO Ventes_honoraires(`id_nego`, `parrainage`, `type`, `montant`, `pourcentage`, `id_location`) VALUES('"+ listeParrain[i] + "'," + "true" + "," + type + ",'" + montant + "','" + ratioParrain[i] + "','" + idLocation + "')";

                c.Open();

                c.exeRequette(req);

                c.Close();

                i++;
            }
            //labelTest.Text = idNegoVente.ToString();
        }
         else
        {
            type = "'Mandat'";
            pourcentage = ratioMandataire;
            montant = honoraires * pourcentage;

            req = "INSERT INTO Ventes_honoraires(`id_nego`, `parrainage`, `type`, `montant`, `pourcentage`, `id_location`) VALUES('"  + idNegoLocation + "'," + "false" + "," + type + ",'" + montant + "','" + pourcentage + "','" + idLocation + "')";

            Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            c.Open();

            c.exeRequette(req);

            c.Close();

            GetParrains(c, listeParrain, idNegoLocation);

            while (i != listeParrain.Count)
            {
                var coeffParain = ratioMandataire / (ratioMandataire + ratioVendeur);
                montant = honoraires * ratioParrain[i] * coeffParain;

                req = "INSERT INTO Ventes_honoraires(`id_nego`, `parrainage`, `type`, `montant`, `pourcentage`, `id_location`) VALUES('" + listeParrain[i] + "'," + "true" + "," + type + ",'" + montant + "','" + ratioParrain[i] + "','" + idLocation + "')";

                c.Open();

                c.exeRequette(req);

                c.Close();

                i++;
            }

            type = "'Location'";
            pourcentage = ratioVendeur;
            montant = honoraires * pourcentage;

            req = "INSERT INTO Ventes_honoraires( `id_nego`, `parrainage`, `type`, `montant`, `pourcentage`, `id_location`) VALUES('" + idNegoAcq + "'," + "false" + "," + type + ",'" + montant + "','" + pourcentage + "','" + idLocation + "')";

            c.Open();

            c.exeRequette(req);

            c.Close();

            listeParrain.Clear();
            i = 0;

            GetParrains(c, listeParrain, idNegoAcq);

            while (i != listeParrain.Count)
            {
                var coeffParrain = ratioVendeur / (ratioMandataire + ratioVendeur);
                montant = honoraires * ratioParrain[i] * coeffParrain;

                req = "INSERT INTO Ventes_honoraires(`id_nego`, `parrainage`, `type`, `montant`, `pourcentage`, `id_location`) VALUES('" + listeParrain[i] + "'," + "true" + "," + type + ",'" + montant + "','" + ratioParrain[i] + "','" + idLocation + "')";

                c.Open();

                c.exeRequette(req);

                c.Close();

                i++;
            }
            //labelTest.Text = "PFFF";
        }
    }
    private void EnregistrerFichiers(string idLocation)
    {
        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();
        System.Data.DataSet dataSet = c.exeRequette("Select * from Environnement");
        c.Close();
        String racine_site = (String)dataSet.Tables[0].Rows[0]["Chemin_racine_site"];
        string filePathBail = racine_site + "Locations\\" + Request.QueryString["id"] + "_bail.pdf";

        try
        {
            if (fileBail.HasFile)
            {
                fileBail.SaveAs(racine_site + "Locations\\" + idLocation + "_bail.pdf");
            }
        }
        catch (Exception ex) { msg.Text = "ERROR : " + ex.Message.ToString(); }
           
    }
    
    private void GetParrains(Connexion c, ArrayList list, int idNego)
    {
        int i = 0;
        string req = "SELECT idparrain FROM Clients WHERE idclient =" + idNego;
        OdbcConnection connect = new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        OdbcCommand execReq = new OdbcCommand(req, connect);
        connect.Open();
        OdbcDataReader reader = execReq.ExecuteReader();

        string read = "";
        int idP, id;
        reader.Read();
        read = reader["idparrain"].ToString();
        int.TryParse(read, out idP);
        reader.Close();
        read = "";
        id = idP;

        while (id != null || id != 0)
        {
            if (i == 7 || id == 0) break;
            list.Add(id);
            string req1 = "SELECT idparrain FROM Clients WHERE idclient =" + id;
            OdbcCommand execReq1 = new OdbcCommand(req1, connect);
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
        connect.Close();
    }
    protected string Code_iso(string choix, Bien bien = null, string nego = null)
    {
        string req = "";

        switch (choix)
        {
            case "bienIso":
                req = "SELECT Pays.codeiso FROM (Biens INNER JOIN optionsBiens ON Biens.ref = optionsBiens.refOptions) INNER JOIN Pays ON optionsBiens.PaysBien = Pays.Titre_Pays WHERE (((Biens.ref)='" + bien.REFERENCE + "'))";
                break;

            case "loueur":
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
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != "" && Request.QueryString["id"] != "0")
            {
                //string req = "SELECT Clients.id_client, Clients.nom_client, Clients.prenom_client, Clients.tel_client, Clients.adresse_client, Clients.postal_client, Clients.ville_client  FROM Acquereurs INNER JOIN Clients ON Acquereurs.idclient = Clients.idclient WHERE (Acquereurs.id_acq)=" + Request.QueryString["acq"];
                string req = "SELECT Clients.idclient, Clients.id_client, Clients.nom_client, Clients.prenom_client, Clients.tel_client, Clients.adresse_client, Clients.postal_client, Clients.ville_client FROM Locations INNER JOIN Clients ON Locations.id_nego = Clients.idclient WHERE (Locations.ID)=" + Request.QueryString["id"];
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
        string codeiso = Code_iso("negoacq", null, idNego);

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
}