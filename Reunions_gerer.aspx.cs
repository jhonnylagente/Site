using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data.Odbc;
using System.Data;
using System.Configuration;
using System.Net.Mail;

public partial class pages_AjouterConference : System.Web.UI.Page
{
    OdbcConnection c = new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    Membre member;

    protected void Page_Load(object sender, EventArgs e)
    {

        if ((Membre)Session["Membre"] != null)
        {
            member = (Membre)Session["Membre"];
            if (member.STATUT == "nego" || member.STATUT == "ultranego")
            {
                int nb_new = 0, nb_old = 0;

                if (member.STATUT == "ultranego")
                {
                    populate_Select_Member();
                    DDL_Select_Client.Visible = true;
                }

                if (!IsPostBack)
                {
                    TBMailNego.Text = member.ID_CLIENT;
                    TBNomNego.Text = member.NOM;
                    TBPrenomNego.Text = member.PRENOM;
                    if (member.TEL != "") TBTelNego.Text = member.TEL;
                }

                OdbcCommand requette = new OdbcCommand("SELECT * FROM Conferences, Clients WHERE Conferences.id_client=Clients.id_client AND Conferences.id_client= ? ORDER BY date_conf ASC ", c);
                OdbcParameter paramId_client = new OdbcParameter("", DbType.String);
                paramId_client.Value = TBMailNego.Text;
                requette.Parameters.Add(paramId_client);


                //VOS CONFERENCES
                OdbcDataReader reader;
                c.Open();
                reader = requette.ExecuteReader();

                String bloc_conference = "";
                LBLConferences.Text = "";    

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        String sourceJpg = getImageProfil(reader["idclient"].ToString(), reader["civilite"].ToString());
                        String[] date = reader["date_conf"].ToString().Split(' ');
                        DateTime DT_date = DateTime.ParseExact(reader["date_conf"].ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        
                        bloc_conference = "";
                        bloc_conference += "<div class='bloc_Conference' style='float:left'>";
                        bloc_conference += "<center>LE <strong>" + date[0] + "</strong> A <strong>" + date[1].Substring(0, 5) + "</strong> AVEC <strong>" + reader["civilite"].ToString().ToUpper() + " " + reader["nom_client"].ToString() + "</strong></center><hr/>";
                        bloc_conference += "<img src='" + sourceJpg + "' class='bloc_photo_conference'/>";

                        bloc_conference += "<div style='float:left; width:65%; margin-left:20px;  overflow-wrap : break-word;'>";

                        bloc_conference += "<strong>Adresse:</strong> " + reader["adresse_conf"];
                        bloc_conference += "<br/><strong>Ville:</strong> " + reader["Ville_conf"].ToString() + " (" + reader["CP_conf"].ToString() + ")";
                        if (reader["duree"].ToString() != "0")
                        {
                            Double duree = Double.Parse(reader["duree"].ToString());
                            DateTime DT_date_fin = DT_date.AddMinutes(duree);
                            bloc_conference += "<br/><strong>De:</strong> " + DT_date.ToString().Substring(11, 5) + " à " + DT_date_fin.ToString().Substring(11, 5);
                        }
                        //bloc_conference += "<br/><strong>Avec :</strong>" + reader["civilite"].ToString().ToUpper() + " " + reader["nom_client"].ToString().ToUpper() + " " + reader["prenom_client"].ToString();
                        bloc_conference += "<br/><div style='display:inline-block; width:100%; margin-bottom:10px'>";
                        
                        if (reader["description_conf"].ToString().Length < 115) bloc_conference += reader["description_conf"].ToString()+"</div>";
                        else bloc_conference += reader["description_conf"].ToString().Substring(0,112)+"...<br/></div>";
                        bloc_conference += "<a href='./Reunions_inscriptions.aspx?id_conf=" + reader["id_conf"].ToString()+ "' class='flat-button' style='color:White; font-size: 16px; font-family: Sans-Serif; padding: 4px 19px 4px 19px; margin-right:5px; text-align:right'>Voir</a>";
              
                        bloc_conference += "</div><br/>";
                         
                        bloc_conference += "</div>";

                        if (DT_date > DateTime.Now)
                        {
                            if (nb_new < 10)
                            {
                                LBLConferences.Text += bloc_conference;
                                nb_new++;
                            }
                        }
                        else 
                        {
                            if (nb_old < 10)
                            {
                                LBLOldConferences.Text += bloc_conference;
                                nb_old++;
                            }
                        }
                    }

                    if (LBLOldConferences.Text == "") LBLOldConferences.Text = "<center>Vous n'avez pas encore organisé de réunion</center>";
                    if (LBLConferences.Text == "") LBLConferences.Text = "<center>Aucune réunion a venir</center>";
                    
                }
                else bloc_conference = "Pas de conferences enregistrées";
                reader.Close();
                c.Close();
            }
            else Response.Redirect("./Recherche.aspx");
        }
        else Response.Redirect("./Recherche.aspx");
    }

    protected void populate_Select_Member()
    {
        if (DDL_Select_Client.Items.Count == 0)
        {
            OdbcCommand requette = new OdbcCommand("SELECT * FROM Clients WHERE  contractuel = true AND (statut='ultranego' OR statut='nego' ) ORDER BY nom_client ASC ", c);

            c.Open();
            OdbcDataReader reader = requette.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DDL_Select_Client.Items.Add(new ListItem(reader["nom_client"].ToString().ToUpper() + " " + reader["prenom_client"].ToString(), reader["id_client"].ToString()));
                }
                reader.Close();
                if (member != null) DDL_Select_Client.SelectedValue = member.ID_CLIENT;
            }
            else DDL_Select_Client.Visible = false;
            c.Close();


        }
    }

    protected void Add_conf(object sender, EventArgs e)
    {

        OdbcCommand requette = new OdbcCommand("INSERT INTO Conferences (id_client, adresse_conf, CP_conf, Ville_conf, date_conf, duree, description_conf) VALUES (?,?,?,?,?,?,?)", c);
        
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

        c.Open();
        requette.ExecuteNonQuery();
        c.Close();

        send_confirmation_mail();

        LBLInfoMail.Text = "Votre conférence a bien été enregistrée";

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

    protected void send_confirmation_mail()
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
        message.From = new MailAddress(stremail, "Patrimo");
        message.Subject = "Nouvelle réunion PATRIMO";

        //message.To.Add(new MailAddress(stremail));
        message.To.Add(new MailAddress("azertqsdf353@gmail.com"));
        message.IsBodyHtml = true;
        message.Body = "<!DOCTYPE html><html><head>"
        //Head
        + "<style type='text/css'> body {margin:0; background: #ece6e6;border:1px solid black} #titre { background: #31536c; width:100%; height: 140px; text-align:center; position: top; }"
        + " #main_title{font-size:25px; color:lightgrey} #subtitle { margin:0; font-size:18px; color:lightgrey} h1 {font-size:20px}  #bloc { background: #FFFFFF; border: 1px solid lightgrey; position: top}"
        + " #bloc_nego { background: orange ; color:white; border: 1px solid pink; position: top} </style> </head> <body>"
        //Entete
        + " <div id='titre'> <a href='http://www.patrimo.net'> <img src='http://" + current_IP + "/img_site/logo_white.png' style='margin-left:10px; margin-top:5px' height='130' align='left' alt='logo_white'/></a>"
        + "<br/><p id='main_title'><strong>Un negociateur à ajouté une réunion</strong></p> "
        + "<p id='subtitle'><strong>Le " + TBDate2.Text.Substring(0, 10) + " à " + TBVilleConf.Text.ToUpper() + " avec " + TBNomNego.Text.ToUpper() + " " + TBPrenomNego.Text + "</strong></p> <br/></div>"
        //Corps
        + "<table style='padding-left:50px; padding-right: 50px' ><tr style='padding-left:50px; padding-right: 50px'><td style='width:8%'></td><td style='padding-left:50px; padding-right: 50px'>"
        + "<p id='subtitle'></p><br/></div><br/><br/> <div id='bloc'><center><h1><strong>Details de la reunion:</strong></h1><br/>"
        + "<strong>Adresse:</strong><br/>"
        + TBAdresseConf.Text + "<br/>" + TBVilleConf.Text.ToUpper() + " (" + TBCPConf.Text + ") <br/><br/>"
        + "<strong>Horaires:</strong><br/>"
        + "Le " + TBDate2.Text.Substring(0, 10) + "<br/>";
        if (DDLDuree.SelectedValue != "0") message.Body += "De " + TBDate2.Text.Substring(11, 5) + " A " + get_Heure_fin(TBDate2.Text, DDLDuree.SelectedValue) + " <br/>";
        else message.Body += "A " + TBDate2.Text.Substring(11, 5) + "<br/>";
        message.Body += "<br/>"
        + "<strong>Le negociateur : </strong><br/>"
        + TBNomNego.Text.ToUpper() + " " + TBPrenomNego.Text +"<br/>";
        if (TBTelNego.Text != "") message.Body += TBTelNego.Text + "<br/>";
        message.Body += TBMailNego.Text
        + "<br/><br/></center> </div>"
        + "</td><td style='width:8%'></td></tr><tr><td style='width:8%'></td><td><br/>"
        + " <div id='footer'><img src='http://" + current_IP + "/img_site/logo_transparent.png' style='margin-left:10px; margin-top:5px' height='130' align='left' alt='logo_transparent'/>&nbsp PATRIMO<br/>&nbsp 56 bis rue Victor Hugo<br/>&nbsp 92270 Bois Colombes<br/>&nbsp Tel: 0146498260<br/>&nbsp Mobile: 0672381516<br/>&nbsp http://www.patrimo.net<br/>&nbsp info@patrimo.net<br/><br/></div>"

        + "</td><td style='width:8%'></td></tr><tr><td></td><td><div style='width:100%;visibility:hidden '><i>Patrimo Patrimo Patrimo Patrimo Patrimo Patrimo Patrimo Patrimo Patrimo Patrimo Patrimo Patrimo Patrimo Patrimo Patrimo Patrimo Patrimo Patrimo Patrimo Patrimo Patrimo Patrimo Patrimo Patrimo</i> </div></td><td></td></tr></table>"

        + "</body></html>";

        smtp.Send(message);
    }


    public String get_Heure_fin(String date_conf, String Duree)
    {
        String Heure_fin = date_conf.Substring(11, 5);

        Double duree = Double.Parse(Duree);
        DateTime DT_date = DateTime.ParseExact(date_conf, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
        DateTime DT_date_fin = DT_date.AddMinutes(duree);
        Heure_fin = DT_date_fin.ToString().Substring(11, 5);

        return Heure_fin;

    }



}