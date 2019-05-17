using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using System.Data;
using System.Globalization;
using System.Configuration;

public partial class pages_Conferences : System.Web.UI.Page
{
    OdbcConnection c = new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        Membre member = null;
        if ((Membre)Session["Membre"] != null)
        {
            member = (Membre)Session["Membre"];
        }
                OdbcCommand requette = new OdbcCommand("SELECT * FROM Conferences, Clients WHERE Conferences.id_client=Clients.id_client ORDER BY date_conf ASC ", c);

                
                OdbcDataReader reader;
                c.Open();
                reader = requette.ExecuteReader();
                
                String bloc_conference = "";
                LBLConferences.Text = "";

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DateTime DT_date = DateTime.ParseExact(reader["date_conf"].ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                        if (DT_date > DateTime.Now)
                        {
                            String sourceJpg = getImageProfil(reader["idclient"].ToString(), reader["civilite"].ToString());
                            String[] date = reader["date_conf"].ToString().Split(' ');

                            bloc_conference = "";
                            bloc_conference += "<div class='bloc_Conference' style='float:left'>";
                            bloc_conference += "<center>LE <strong>" + date[0] + "</strong> A <strong>" + date[1].Substring(0, 5) + "</strong> AVEC <strong>" + reader["civilite"].ToString().ToUpper() + " " + reader["nom_client"].ToString().ToUpper() + "</strong></center><hr/>";
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
                            bloc_conference += "<br/><div style='display:inline-block; width:100%; margin-bottom:10px'>";

                            if (reader["description_conf"].ToString().Length < 115) bloc_conference += reader["description_conf"].ToString() + "</div>";
                            else bloc_conference += reader["description_conf"].ToString().Substring(0, 112) + "...<br/></div>";
                            bloc_conference += "<a href='./Reunions_inscriptions.aspx?id_conf=" + reader["id_conf"].ToString() + "' class='flat-button' style='color:White; font-size: 16px; font-family: Sans-Serif; padding: 4px 19px 4px 19px; margin-right:5px; text-align:right'>Voir Infos</a>";
                            if (member != null && checkIfParticipated(member.ID_CLIENT, reader["id_conf"].ToString())) bloc_conference += "<strong><font color='green'> (Déjà inscrit !)</font></strong>";
                            bloc_conference += "</div><br/>";

                            bloc_conference += "</div>";

                            LBLConferences.Text += bloc_conference;
                        }
                    }
                    if (LBLConferences.Text == "") LBLConferences.Text = "<center>Pas de reunions organisées pour l'instant !</center>";
                     
                }
                else LBLConferences.Text = "<center>Pas de reunions organisées pour l'instant !</center>";
                reader.Close();
                c.Close();
    }

    protected Boolean checkIfParticipated(String idClient, String idConf)
    {
        Boolean participated = true;
        ConnectionState initial_Conn_State = c.State;

        if (initial_Conn_State == ConnectionState.Closed) c.Open();
        //On verifie si le membre a participé a la reunion en question
        //Surement optimisable
        OdbcCommand requette2 = new OdbcCommand("SELECT * FROM Conferences_inscriptions WHERE id_conf= ? AND id_client= ? ", c);
        OdbcParameter paramId_conf2 = new OdbcParameter("", DbType.String);
        paramId_conf2.Value = idConf;
        requette2.Parameters.Add(paramId_conf2);

        OdbcParameter paramId_client2 = new OdbcParameter("", DbType.String);
        paramId_client2.Value = idClient;
        requette2.Parameters.Add(paramId_client2);

        OdbcDataReader reader2 = requette2.ExecuteReader();

        participated = reader2.HasRows;

        if (initial_Conn_State == ConnectionState.Closed) c.Close();

        return participated;

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


}