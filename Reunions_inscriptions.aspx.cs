using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data.Odbc;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Net.Mail;


public class Reunion
{
    public String ID_CONF{get;set;}
    public String ID_CLIENT { get; set; }
    public String IDCLIENT { get; set; }
    public String ADRESSE_CONF { get; set; }
    public String DATE_CONF { get; set; }
    public String DUREE { get; set; }
    public String DESCRIPTION { get; set; }
    public String CP_CONF { get; set; }
    public String VILLE_CONF { get; set; }

    public String NEGO_CIVILITE{ get; set; }
    public String NEGO_NOM { get; set; }
    public String NEGO_PRENOM{ get; set; }
    public String NEGO_TEL { get; set; }


    public DateTime get_Datetime()
    {
        DateTime date= DateTime.ParseExact(DATE_CONF, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        return date;
    }

    public String get_Heure_fin()
    {
        String Heure_fin = DATE_CONF.Substring(11, 5);

        Double duree = Double.Parse(DUREE);
        DateTime DT_date = DateTime.ParseExact(DATE_CONF, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        DateTime DT_date_fin = DT_date.AddMinutes(duree);
        Heure_fin = DT_date_fin.ToString().Substring(11, 5);

        return Heure_fin;
        
    }

}

public partial class pages_Inscription_Conf : System.Web.UI.Page
{
    OdbcConnection c = new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    Membre member;
    Reunion ma_reunion = new Reunion();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id_conf"] != null) ma_reunion.ID_CONF = Request.QueryString["id_conf"];
        else Response.Redirect("./Reunions_afficher.aspx");

        OdbcCommand requette = new OdbcCommand("SELECT * FROM Conferences, Clients WHERE Conferences.id_client=Clients.id_client AND id_conf= ? ORDER BY date_conf ASC ", c);
        OdbcParameter paramId_conf = new OdbcParameter("", DbType.String);
        paramId_conf.Value = ma_reunion.ID_CONF;
        requette.Parameters.Add(paramId_conf);

        OdbcDataReader reader;
        c.Open();
        reader = requette.ExecuteReader();

        if (reader.HasRows)
        {
            reader.Read();
            ma_reunion.ID_CLIENT = reader["id_client"].ToString();
            ma_reunion.IDCLIENT = reader["idclient"].ToString();
            ma_reunion.NEGO_CIVILITE = reader["civilite"].ToString();
            ma_reunion.NEGO_NOM = reader["nom_client"].ToString();
            ma_reunion.NEGO_PRENOM = reader["prenom_client"].ToString();
            ma_reunion.NEGO_TEL = reader["tel_client"].ToString();

            ma_reunion.ADRESSE_CONF = reader["adresse_conf"].ToString();
            ma_reunion.CP_CONF = reader["CP_conf"].ToString();
            ma_reunion.VILLE_CONF = reader["Ville_conf"].ToString();
            ma_reunion.DATE_CONF = reader["date_conf"].ToString();
            ma_reunion.DESCRIPTION = reader["description_conf"].ToString();
            ma_reunion.DUREE = reader["duree"].ToString();
           
            reader.Close();

            String sourceJpg = getImageProfil(ma_reunion.IDCLIENT, ma_reunion.NEGO_CIVILITE);
            String[] date = ma_reunion.DATE_CONF.Split(' ');

            Boolean Connected = (Membre)Session["Membre"] != null;
            Boolean Was_here = false;

            if (Connected)
            {
                member = (Membre)Session["Membre"];
                Was_here = checkIfParticipated(member.ID_CLIENT);
            }

            //Gestion du panneau 
            if (DateTime.Now > ma_reunion.get_Datetime())
            {
                PNL_Autres.Visible = true;
                //Cas de base:
                LBL_Autre.Text = "Vous ne pouvez plus vous inscrire à cette réunion. <br />Pour revenir à la liste des reunions disponibles, cliquez ici:";
                if (Connected)
                { 
                    if(Was_here) LBL_Autre.Text = "Vous avez déjà participé a cette réunion. <br />Pour voir les autres reunions disponibles, cliquez ici:";
                }
            }
            else 
            {
                if (Connected)
                {
                    if (Was_here)
                    {
                        PNL_Autres.Visible = true;
                        LBL_Autre.Text = "Vous êtes inscrit à cette réunion, et nous vous en remercions. <br />Si vous ne l'avez pas déjà recu, vous recevrez prochainement un mail de confirmation. <br />Si vous souhaitez voir les autres reunions disponibles, cliquez ici:";
                    }
                    else PNL_Connected.Visible = true;
                }
                else PNL_Not_Connected.Visible = true;
            }

            if (Connected && (member.STATUT == "ultranego" || member.ID_CLIENT == ma_reunion.ID_CLIENT))
            {
                PNL_Autres.Visible = false;
                PNL_Connected.Visible = false;
                PNL_Not_Connected.Visible = false;
                PNL_Nego.Visible = true;
                LBL_Liste.Text = "";

                if (member.STATUT == "ultranego")
                {
                    populate_Select_Member();
                    DDL_Select_Client.Visible = true;
                }
                if(!IsPostBack) populate_infos_reu();

                OdbcCommand requette2 = new OdbcCommand("SELECT * FROM Conferences_inscriptions, Clients WHERE Conferences_inscriptions.id_client=Clients.id_client AND id_conf= ? ORDER BY nom_client ASC ", c);
                OdbcParameter paramId_conf2 = new OdbcParameter("", DbType.String);
                paramId_conf2.Value = ma_reunion.ID_CONF;
                requette2.Parameters.Add(paramId_conf2);
                reader = requette2.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        LBL_Liste.Text += "<tr><td><a href='mailto:" + reader["id_client"].ToString() + "'>" + reader["id_client"].ToString() + "</td><td>  - " + reader["civilite"].ToString() + "</td><td> " + reader["nom_client"].ToString().ToUpper() + "</td><td> " + reader["prenom_client"].ToString() + "</td></tr><br/>";
                    }
                }
                else LBL_Liste.Text = "<br/> Aucun membre inscrit pour l'instant.<br/> ";

                reader.Close();
            }

            //Label Infos reunion
            LBL_InfoReu.Text = "<strong>REUNION LE " + date[0] + "</strong><br/><br/>";

            LBL_InfoReu.Text += ma_reunion.ADRESSE_CONF.ToUpper()+"<br/>";
            LBL_InfoReu.Text += ma_reunion.VILLE_CONF.ToUpper() + " (" + ma_reunion.CP_CONF + ")<br/><strong>";


            if (ma_reunion.DUREE != "0")
                {
                    LBL_InfoReu.Text += "De " + ma_reunion.DATE_CONF.Substring(11, 5) + " a " + ma_reunion.get_Heure_fin() +"</strong><br/><br/>";
                }
            else LBL_InfoReu.Text += "A " + ma_reunion.DATE_CONF.Substring(11, 5) + "</strong><br/><br/>";

            LBL_InfoReu.Text += ma_reunion.DESCRIPTION;

            //Label info Nego
            LBL_InfoNego.Text = "<strong>AVEC " + ma_reunion.NEGO_PRENOM.ToUpper() + " " + ma_reunion.NEGO_NOM.ToUpper() + "</strong><br/><br/>";
            LBL_InfoNego.Text += "<img src='" + sourceJpg + "' class='bloc_photo_conference'/>";

            LBL_InfoNego.Text += "<div style='float:left;margin-left: 20px; width:50%;text-align:left'>";
            LBL_InfoNego.Text += "<br/><img src='../img_site/tel_round_dark.png' style='margin-bottom:-7px;margin-right:5px;' height='30px'/><strong>" + ma_reunion.NEGO_TEL;
            LBL_InfoNego.Text += "</strong><br/></div>";

            LBL_InfoNego.Text += "<div style='float:left;margin-left: 20px'>";
            LBL_InfoNego.Text += "<img src='../img_site/mail_round_dark.png' style='margin-bottom:-7px;margin-right:5px;' height='30px'/><strong>" + ma_reunion.ID_CLIENT + "</strong>";
            LBL_InfoNego.Text += "</div>";
            LBL_InfoNego.Text += "<br/><br/><br/><br/><br/><br/><a href='./agent.aspx?id_client=" + ma_reunion.ID_CLIENT + "' class='flat-button' style='color:White; font-size: 16px; font-family: Sans-Serif; padding: 4px 19px 4px 19px; margin-right:5px'>Voir son site</a>";

            
        }
        else
        {
            c.Close();
            Response.Redirect("./Reunions_afficher.aspx");
        }

        c.Close();
    }

    protected void retour_liste(object sender, EventArgs e)
    {
        Response.Redirect("./Reunions_afficher.aspx");
    }

    protected void retour_gerer(object sender, EventArgs e)
    {
        Response.Redirect("./Reunions_gerer.aspx");
    }

    protected void Inscription_Reunion(object sender, EventArgs e)
    {
        if ((Membre)Session["Membre"] != null)
        {
            Add_to_Conferences_inscriptions(member.ID_CLIENT);
        }
        Response.Redirect("./Reunions_inscriptions.aspx?id_conf=" + ma_reunion.ID_CONF);
    }

    protected void send_confirmation_mail(String id_client)
    {
        SmtpClient smtp = new SmtpClient();
        MailMessage message = new MailMessage();
        ConnectionState initial_Conn_State = c.State;

        if (initial_Conn_State == ConnectionState.Closed) c.Open();
        OdbcCommand requette = new OdbcCommand("SELECT * FROM Environnement", c);
        OdbcDataReader reader = requette.ExecuteReader();
        reader.Read();
        String strhost = reader["HostSMTP"].ToString();
        String stremail = reader["email_commande"].ToString();
        String current_IP = reader["IP"].ToString();
        reader.Close();

        if (initial_Conn_State == ConnectionState.Closed) c.Close();

        smtp.Host = strhost;
        smtp.Port = 25;
        message.From = new MailAddress(stremail,"Patrimo");  
        message.Subject = "Confirmation de votre inscription à notre réunion PATRIMO";



        message.To.Add(new MailAddress(id_client));
        message.IsBodyHtml = true;
        message.Body = "<!DOCTYPE html><html><head>"
            //Head
            + "<style type='text/css'> body {margin:0; background: #ece6e6;border:1px solid black} #titre { background: #31536c; width:100%; height: 140px; text-align:center; position: top; }"
            + " #main_title{font-size:25px; color:lightgrey} #subtitle { margin:0; font-size:18px; color:lightgrey} h1 {font-size:20px}  #bloc { background: #FFFFFF; border: 1px solid lightgrey; position: top}"
            + " #bloc_nego { background: orange ; color:white; border: 1px solid pink; position: top} </style> </head> <body>"
            //Entete
            + " <div id='titre'> <a href='http://www.patrimo.net'> <img src='http://" + current_IP + "/img_site/logo_white.png' style='margin-left:10px; margin-top:5px' height='130' align='left' alt='logo_white'/></a>"
            + "<br/><p id='main_title'><strong>Confirmation d'inscription à notre réunion PATRIMO</strong></p> "
            + "<p id='subtitle'><strong>Le " + ma_reunion.DATE_CONF.Substring(0, 10) + " à " + ma_reunion.VILLE_CONF.ToUpper() + " avec " + ma_reunion.NEGO_CIVILITE + " " + ma_reunion.NEGO_NOM.ToUpper() + "</strong></p> <br/></div>"
            //Corps
            + "<table><tr><td style='width:8%'></td><td>"
            + "<p id='subtitle'></p><br/></div><br/><br/> <div id='bloc'><center><h1><strong>Details de la reunion:</strong></h1><br/>"
            + "<strong>Adresse:</strong><br/>"
            + ma_reunion.ADRESSE_CONF + "<br/>" + ma_reunion.VILLE_CONF.ToUpper() + " (" + ma_reunion.CP_CONF + ") <br/><br/>"
            + "<strong>Horaires:</strong><br/>"
            + "Le " + ma_reunion.DATE_CONF.Substring(0, 10) + "<br/>";
        if (ma_reunion.DUREE != "0") message.Body += "De " + ma_reunion.DATE_CONF.Substring(11, 5) + " à " +ma_reunion.get_Heure_fin() +"<br/>";
        else message.Body += "A " + ma_reunion.DATE_CONF.Substring(11, 5) + "<br/>";
            message.Body += "<br/>" 
            + "<strong>Votre conseiller:</strong><br/>"
            + ma_reunion.NEGO_CIVILITE + " " + ma_reunion.NEGO_NOM.ToUpper() + " " + ma_reunion.NEGO_PRENOM + "<br/>";
        if (ma_reunion.NEGO_TEL != "") message.Body += ma_reunion.NEGO_TEL+"<br/>";
            message.Body += ma_reunion.ID_CLIENT
            + "<br/><br/></center> </div>"
            + "</td><td style='width:8%'></td></tr><tr><td><br/></td></tr><tr><td style='width:8%'></td><td>"

            + " <div id='bloc_nego'><div style='margin-left:10px;margin-top:10px'> <b>&nbsp Nous recrutons des agents mandataires sur toute la France. Nous offrons la meilleur rénumération du marché. Rejoignez-nous. Envoyez cv + lm à info@patrimo.net</b><br/><br/></div>"
            + "</td><td style='width:8%'></td></tr><tr><td style='width:5%'></td><td><br/>"

            + " <div id='footer'><img src='http://" + current_IP + "/img_site/logo_transparent.png' style='margin-left:10px; margin-top:5px' height='130' align='left' alt='logo_transparent'/>&nbsp PATRIMO<br/>&nbsp 56 bis rue Victor Hugo<br/>&nbsp 92270 Bois Colombes<br/>&nbsp Tel: 0146498260<br/>&nbsp Mobile: 0672381516<br/>&nbsp http://www.patrimo.net<br/>&nbsp info@patrimo.net<br/><br/><br/></div>"

            + "</td><td style='width:8%'></td></tr></table>"
            + "  <br/>"
            
            + "</body></html>";

        smtp.Send(message);
    }

    protected void Add_to_Conferences_inscriptions(String id_client)
    {

        OdbcCommand requette = new OdbcCommand("INSERT INTO Conferences_inscriptions VALUES (?,?) ", c);
        OdbcParameter paramId_conf = new OdbcParameter("", DbType.String);
        paramId_conf.Value = ma_reunion.ID_CONF;
        requette.Parameters.Add(paramId_conf);
        OdbcParameter paramId_client = new OdbcParameter("", DbType.String);
        paramId_client.Value = id_client;
        requette.Parameters.Add(paramId_client);

        c.Open();
        requette.ExecuteNonQuery();
        c.Close();

        send_confirmation_mail(id_client);

    }

    protected Boolean checkIfParticipated(String idClient)
    {
        Boolean participated = true;
        ConnectionState initial_Conn_State = c.State;

        if (initial_Conn_State == ConnectionState.Closed) c.Open();
        //On verifie si le membre a participé a la reunion en question
        //Surement optimisable
        OdbcCommand requette2 = new OdbcCommand("SELECT * FROM Conferences_inscriptions WHERE id_conf= ? AND id_client= ? ", c);
        OdbcParameter paramId_conf2 = new OdbcParameter("", DbType.String);
        paramId_conf2.Value = ma_reunion.ID_CONF;
        requette2.Parameters.Add(paramId_conf2);

        OdbcParameter paramId_client2 = new OdbcParameter("", DbType.String);
        paramId_client2.Value = idClient;
        requette2.Parameters.Add(paramId_client2);

        OdbcDataReader reader2 = requette2.ExecuteReader();

        participated = reader2.HasRows;

        if (initial_Conn_State == ConnectionState.Closed) c.Close();

        return participated;
    }

    protected void connexion_inscription(object sender, EventArgs e)
    {
        Membre member = checkMember();

        if (member != null)
        {
            connectMember(member);
            if (!checkIfParticipated(member.ID_CLIENT)) Add_to_Conferences_inscriptions(member.ID_CLIENT);

            Response.Redirect("./Reunions_inscriptions.aspx?id_conf=" + ma_reunion.ID_CONF);
        }

    }

    protected void connectMember(Membre member)
    {
        if (member != null)
        {
            Session["membre"] = member;
            Session["logged"] = true;
            HttpCookie ClientIDcookie = Request.Cookies["ClientID"];
            if (Request.Cookies["ClientID"] != null)
            {
                ClientIDcookie.Expires = System.DateTime.Now.AddDays(-7);
            }
            ClientIDcookie = new HttpCookie("ClientID");
            ClientIDcookie.Value = member.ID_CLIENT;
            ClientIDcookie.Expires = System.DateTime.Now.AddDays(7);
            Response.Cookies.Add(ClientIDcookie);
        }
    }

    private Membre checkMember()
    {
        Membre member = null;
        LBL_Erreur.Text = "";

        try
        {
            member = MembreDAO.getMember(TBIdentifiantConnexion.Text.Trim());

            if (member == null)
            {
                LBL_Erreur.Visible = true;
                LBL_Erreur.Text = "Votre adresse email est introuvable  <br />";
            }
            else
            {
                if (member.PASSWORD == TBPassConnexion.Text)
                {
                    try
                    {
                        Session["logged"] = true;
                        HttpCookie ClientIDcookie = Request.Cookies["ClientID"];
                        if (Request.Cookies["ClientID"] != null)
                        {
                            ClientIDcookie.Expires = System.DateTime.Now.AddDays(-7);
                        }
                        ClientIDcookie = new HttpCookie("ClientID");
                        ClientIDcookie.Value = member.ID_CLIENT;
                        ClientIDcookie.Expires = System.DateTime.Now.AddDays(7);
                        Response.Cookies.Add(ClientIDcookie);
                    }
                    catch
                    {
                        LBL_Erreur.Visible = true;
                        LBL_Erreur.Text = "Mot de passe invalide <br />";
                        member = null;
                    }
                }
                else
                {
                    LBL_Erreur.Visible = true;
                    LBL_Erreur.Text = "Mot de passe invalide <br />";
                    member = null;
                }
            }
        }
        catch
        {
            LBL_Erreur.Visible = true;
            LBL_Erreur.Text = "Une erreur est survenue, veuillez reessayer<br />";
            member = null;
        }
        return member;
    }

    protected String getImageProfil(String idClient, String ClientCivilite)
    {
        //Recuperation de l'image
        string sourceJpg = "../img_nego/" + idClient + "_PHOTO.JPG";

        if (!System.IO.File.Exists(MapPath("~/img_nego/" + idClient + "_PHOTO.jpg")))
        {
            if (ClientCivilite == "Mr") sourceJpg = "../img_site/man.png";
            else sourceJpg = "../img_site/woman.png";
        }

        return sourceJpg;
    }

    private Boolean checkField(Membre member)
    {
        try
        {
            // on remplit l'objet member
            member.CIVILITE = DDLCivil.SelectedValue;
            member.ID_CLIENT = TBMail.Text.Trim();
            member.NOM = TBNom.Text.Trim();
            member.PRENOM = TBPrenom.Text.Trim();
            member.ADRESSE = TBAdresse.Text.Trim();
            member.CODE_POSTAL = TBCP.Text.Trim();
            member.VILLE = TBVille.Text.Trim();
            member.TEL = TBTel.Text.Trim();
            member.FAX = TBFax.Text.Trim();
            member.SOCIETE = TBSociete.Text.Trim();
            if (TBPass.Text == TBPassConfirm.Text) member.PASSWORD = TBPass.Text;
            member.PAYS = DropDownListPays.Text;
        }
        catch (Exception ex)
        {
            Response.Write("<strong>Bonjour, l'erreur suivante a été générée :</strong><br/>" + ex + "Veuillez retenter cette opération. Si elle devait de produire a nouveau, veuillez envoyer cette erreur a info@patrimo.net<br/>");
            return false;
        }

        return true;
    }

    protected void inscription(object sender, EventArgs e)
    {
        Membre member = new Membre();

        if (checkField(member))
        {
            try
            {
                MembreDAO.addMember(member);
                if (!checkIfParticipated(member.ID_CLIENT)) Add_to_Conferences_inscriptions(member.ID_CLIENT);
                connectMember(member);
                Response.Redirect("./Reunions_inscriptions.aspx?id_conf=" + ma_reunion.ID_CONF);
            }
            catch
            {
                LBL_Erreur.Visible = true;
                LBL_Erreur.Text = "Email déjà utilisé, veuillez recommencer votre inscription";
            }
        }

    }

    protected void populate_Select_Member()
    {
        if (DDL_Select_Client.Items.Count == 0)
        {
            OdbcCommand requette = new OdbcCommand("SELECT * FROM Clients WHERE  contractuel = true AND (statut='ultranego' OR statut='nego' ) ORDER BY nom_client ASC ", c);

            ConnectionState currentState = c.State;
            if (currentState == ConnectionState.Closed) c.Open();
            OdbcDataReader reader = requette.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DDL_Select_Client.Items.Add(new ListItem(reader["nom_client"].ToString().ToUpper() + " " + reader["prenom_client"].ToString(), reader["id_client"].ToString()));
                }
                reader.Close();
                if (member != null) DDL_Select_Client.SelectedValue = ma_reunion.ID_CLIENT;
            }
            else DDL_Select_Client.Visible = false;
            if (currentState == ConnectionState.Closed) c.Close();
        }
    }

    protected void Load_member(object sender, EventArgs e)
    {
        OdbcCommand requette = new OdbcCommand("SELECT * FROM Clients WHERE id_client= ?", c);

        OdbcParameter paramId_client = new OdbcParameter("", DbType.String);
        paramId_client.Value = DDL_Select_Client.SelectedValue;
        requette.Parameters.Add(paramId_client);
        c.Open();
        OdbcDataReader reader = requette.ExecuteReader();
        if (reader.HasRows)
        {
            reader.Read();
            TBNomNego.Text = reader["nom_client"].ToString();
            TBPrenomNego.Text = reader["prenom_client"].ToString();
            TBTelNego.Text = reader["tel_client"].ToString();
            TBMailNego.Text = reader["id_client"].ToString();
            reader.Close();
        }
        c.Close();
    }

    protected void populate_infos_reu()
    {
        TBNomNego.Text = ma_reunion.NEGO_NOM;
        TBPrenomNego.Text = ma_reunion.NEGO_PRENOM;
        TBTel.Text = ma_reunion.NEGO_TEL;
        TBMailNego.Text = ma_reunion.ID_CLIENT;
        TBAdresseConf.Text = ma_reunion.ADRESSE_CONF;
        TBCPConf.Text = ma_reunion.CP_CONF;
        TBVilleConf.Text = ma_reunion.VILLE_CONF;
        TBDate.Text = ma_reunion.DATE_CONF.Substring(0,16);
        TBDate2.Text = ma_reunion.DATE_CONF.Substring(0, 16);
        DDLDuree.SelectedValue = ma_reunion.DUREE;
        TBBody.Text = ma_reunion.DESCRIPTION;
    }

    protected void modifier_conf(object sender, EventArgs e)
    {
        OdbcCommand requette = new OdbcCommand("UPDATE Conferences SET id_client = ?, adresse_conf = ? , CP_conf = ? , Ville_conf = ? , date_conf = ? , duree = ? , description_conf = ? WHERE id_conf= ? ", c);

        OdbcParameter paramId_client = new OdbcParameter("", DbType.String);
        paramId_client.Value = TBMailNego.Text;
        requette.Parameters.Add(paramId_client);

        OdbcParameter paramAdresse = new OdbcParameter("", DbType.String);
        paramAdresse.Value = TBAdresseConf.Text;
        requette.Parameters.Add(paramAdresse);

        OdbcParameter paramCP = new OdbcParameter("", DbType.String);
        paramCP.Value = TBCPConf.Text;
        requette.Parameters.Add(paramCP);

        OdbcParameter paramVille = new OdbcParameter("", DbType.String);
        paramVille.Value = TBVilleConf.Text;
        requette.Parameters.Add(paramVille);

        DateTime date = DateTime.ParseExact(TBDate2.Text, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
        OdbcParameter paramDate_Conf = new OdbcParameter("", DbType.DateTime);
        paramDate_Conf.Value = date;
        requette.Parameters.Add(paramDate_Conf);

        OdbcParameter paramDuree_Conf = new OdbcParameter("", DbType.Int32);
        paramDuree_Conf.Value = Int32.Parse(DDLDuree.SelectedValue);
        requette.Parameters.Add(paramDuree_Conf);

        OdbcParameter paramDescr = new OdbcParameter("", DbType.String);
        paramDescr.Value = TBBody.Text;
        requette.Parameters.Add(paramDescr);

        OdbcParameter paramidConf = new OdbcParameter("", DbType.String);
        paramidConf.Value = ma_reunion.ID_CONF;
        requette.Parameters.Add(paramidConf);

        ConnectionState currentState = c.State;
        if (currentState == ConnectionState.Closed) c.Open();
        requette.ExecuteNonQuery();
        if (currentState == ConnectionState.Closed) c.Close();

        LBLInfoMail.Text = "Votre conférence a bien été enregistrée";

        Response.Redirect("./Reunions_inscriptions.aspx?id_conf="+ma_reunion.ID_CONF);
    }


}