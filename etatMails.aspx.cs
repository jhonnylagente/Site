using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using System.Configuration;

public partial class pages_etatMails : System.Web.UI.Page
{
    OdbcConnection c = new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected Int32 MG_nb_mails=0, MG_nb = 0, MG_tps = 0, MR_nb = 0, MR_tps = 0, AP_nb = 0, AP_tps = 0, AE_nb = 0, AE_tps = 0, AE_new = 0;
    protected DateTime MG_fin, MR_fin, AP_fin, AE_fin;
    protected String type_dernier_mail = "", id_dernier_mail = "", date_dernier_mail_general="";

    protected void Page_Load(object sender, EventArgs e)
    {

        if ((Membre)Session["Membre"] != null)
        {            
            Membre member = (Membre)Session["Membre"];

            Dernier_mails.Text = "";
            if (member.STATUT == "ultranego")
            {
                //Liste des derniers mails
                getLatestMails();

                //Date de la derniere lettre PATRIMO envoyée
                getLatestMailGeneral();

                //Gestion des informations selon le type de mail
                getMailGeneraux();
                getMailRapprochement();
                getAlertePerim();
                getAlerteMail();
            }
        }
        else Response.Redirect("./Recherche.aspx");

       
        
    }

    protected void getLatestMails()
    {
        OdbcCommand trouverMails = new OdbcCommand("select TOP 10 * from Envoi_mails order by date_envoi desc ", c);
        OdbcDataReader reader;
        c.Open();
        reader = trouverMails.ExecuteReader();

        if (reader.HasRows)
        {
            while(reader.Read())
            {
                Dernier_mails.Text += "<tr><td><strong>" + reader["date_envoi"].ToString() +"</strong> </td><td style='padding-left:15px;'> " + reader["Type"].ToString() + " pour " + reader["destinataire"].ToString() + "</td></tr>";
            }
        }
        c.Close();

    }

    protected void getLatestMailGeneral()
    {
        OdbcCommand trouverMails = new OdbcCommand("select TOP 1 * from MailGeneral order by date_mail desc ", c);
        OdbcDataReader reader;
        c.Open();
        reader = trouverMails.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                date_dernier_mail_general += reader["date_mail"].ToString();
            }
        }

        c.Close();




    }

    protected void getMailGeneraux()
    {
        List<String[]> Mail_IDs=new List<String[]>();
        Int32 nombre_mails_total = 0, nombre_mails;

        OdbcCommand trouverMail = new OdbcCommand("select * from MailGeneral where etat <> 2 order by etat desc ", c);
        OdbcDataReader reader;
        c.Open();
        reader = trouverMail.ExecuteReader();

        if(reader.HasRows)
        {
            while (reader.Read()) Mail_IDs.Add(new String[] { reader["ID"].ToString(), reader["destinataire"].ToString() });
            reader.Close();

            //Pour chanque mail general, on va compter combien de membres il reste à envoyer
            foreach (String[] s in Mail_IDs)
            {
                string cond = "";
                switch (s[1])
                {
                    case "1": cond = "where statut = 'ultranego' AND"; break;
                    case "2": cond = "where statut = 'nego' AND"; break;
                    case "3": cond = "where (statut = 'nego' OR statut = 'ultranego') AND"; break;
                    case "4": cond = "where (statut <> 'nego' AND statut <> 'ultranego') AND"; break;
                    case "5": cond = "where "; break;
                    default: cond = "where statut = 'ultranego' AND"; break;
                }

                //On recupere le premier mail a envoyer
                if (id_dernier_mail == "")
                {
                    string cmd = "SELECT TOP 1 id_client from Clients " + cond + " id_client not in (" + "select IdClient from Lien_MailGeneral_Client where IdMail = " + s[0] + ");";
                    OdbcCommand getid_client = new OdbcCommand(cmd, c);
                    reader = getid_client.ExecuteReader();
                    if (reader.HasRows)
                    {
                        type_dernier_mail = "Mail général à ";
                        reader.Read();
                        id_dernier_mail=reader["id_client"].ToString();
                        reader.Close();
                    }
                }

                string sql = "select COUNT(*) from Clients " + cond + " id_client not in (" + "select IdClient from Lien_MailGeneral_Client where IdMail = " + s[0] + ");";
                OdbcCommand requette = new OdbcCommand(sql, c);
                reader = requette.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    Int32.TryParse(reader[0].ToString(), out nombre_mails);
                    reader.Close();
                }
                else nombre_mails=0;

                nombre_mails_total += nombre_mails;
            }

            MG_nb_mails = Mail_IDs.Count;
            MG_nb = nombre_mails_total;
            MG_tps = MG_nb * 30;
            MG_fin = DateTime.Now.AddSeconds(MG_tps);

        }
        else
        {
            MG_nb_mails = 0;
            MG_nb = 0;
            MG_tps = 0;
            MG_fin = DateTime.Now;
        }

        c.Close();
    }

    protected void getMailRapprochement()
    {
        OdbcCommand requette = new OdbcCommand("Select COUNT(*) from HistoriqueMail where sent = false", c);
        OdbcDataReader reader;
        c.Open();
        reader = requette.ExecuteReader();

        if (reader.HasRows)
        {
            reader.Read();
            Int32.TryParse(reader[0].ToString(), out MR_nb);
            reader.Close();

            //On recupere le premier mail a envoyer
            if (id_dernier_mail == "")
            {
                OdbcCommand getid_client = new OdbcCommand("Select TOP 1 * from HistoriqueMail where sent = false order by dateEnvoie DESC", c);
                reader = getid_client.ExecuteReader();
                if (reader.HasRows)
                {
                    type_dernier_mail = "Mail de rapprochement pour ";
                    reader.Read();
                    id_dernier_mail = reader["destinataire"].ToString();
                    reader.Close();
                }
            }

            MR_tps = MR_nb * 30;
            MR_fin = MG_fin.AddSeconds(MR_tps);
        }
        else
        {
            MR_nb = 0;
            MR_tps = 0;
            MR_fin = MG_fin;
        }
        c.Close();
    }

    protected void getAlertePerim()
    {
        OdbcCommand requette = new OdbcCommand("Select COUNT(*) from alerte_mail where dateEnregistrement < ? AND actif = true ", c);
        OdbcParameter paramToday = new OdbcParameter("@Today", System.Data.DbType.DateTime);
        DateTime perimMois = DateTime.Now.AddMonths(-3);
        paramToday.Value = perimMois;
        requette.Parameters.Add(paramToday);
        
        OdbcDataReader reader;
        c.Open();
        reader = requette.ExecuteReader();

        if (reader.HasRows)
        {
            reader.Read();
            Int32.TryParse(reader[0].ToString(), out AP_nb);
            reader.Close();


            //On recupere le premier mail a envoyer
            if (id_dernier_mail == "")
            {
                OdbcCommand getid_client = new OdbcCommand("Select TOP 1 * from alerte_mail where dateEnregistrement < ? AND actif = true order by dateEnregistrement ASC;", c);
                OdbcParameter paramOld = new OdbcParameter("@Today", System.Data.DbType.DateTime);
                paramOld.Value = DateTime.Now.AddMonths(-3);
                getid_client.Parameters.Add(paramOld);
                reader = getid_client.ExecuteReader();
                if (reader.HasRows)
                {
                    type_dernier_mail = "Alerte Perimée pour ";
                    reader.Read();
                    id_dernier_mail = reader["id_client"].ToString();
                    reader.Close();
                }
            }

            AP_tps = AP_nb * 30;
            AP_fin = MR_fin.AddSeconds(AP_tps);
        }
        else
        {
            AP_nb = 0;
            AP_tps = 0;
            AP_fin = MR_fin;
        }
        c.Close();
    }

    protected void getAlerteMail()
    {
        OdbcCommand requette = new OdbcCommand("Select COUNT(*) from alerte_mail where dateEnregistrement > ? AND actif = true ", c);
        OdbcParameter paramToday = new OdbcParameter("@Today", System.Data.DbType.DateTime);
        DateTime perimMois = DateTime.Now.AddMonths(-3);
        paramToday.Value = perimMois;
        requette.Parameters.Add(paramToday);

        OdbcDataReader reader;
        c.Open();
        reader = requette.ExecuteReader();

        if (reader.HasRows)
        {
            reader.Read();
            Int32.TryParse(reader[0].ToString(), out AE_nb);
            reader.Close();


            //On recupere le premier mail a envoyer
            if (id_dernier_mail == "")
            {
                OdbcCommand getid_client = new OdbcCommand("Select TOP 1 * from alerte_mail where dateEnregistrement > ? AND actif = true order by dateDerReponse ASC;", c);
                OdbcParameter paramOld = new OdbcParameter("@Today", System.Data.DbType.DateTime);
                paramOld.Value = DateTime.Now.AddMonths(-3);
                getid_client.Parameters.Add(paramOld);
                reader = getid_client.ExecuteReader();
                if (reader.HasRows)
                {
                    type_dernier_mail = "Verification Alerte Mail pour ";
                    reader.Read();
                    id_dernier_mail = reader["id_client"].ToString();
                    reader.Close();
                }
            }


            AE_tps = AE_nb * 30;
            AE_fin = AP_fin.AddSeconds(AE_tps);
        }
        else
        {
            AE_nb = 0;
            AE_tps = 0;
            AE_fin = AP_fin;
        }
        c.Close();
    }

    protected void getLog()
    {
        String texte = "<font color='green' > AUCUNE ERREUR DETECTEE</font><br/><br/> ";
        String log = System.IO.File.ReadAllText(@"C:\base_patrimo\Mailing\logMailingPatrimoFreuh.txt");
        if (log.Contains("System.Data.Odbc.OdbcException")) texte = "<font color='red' > ERREUR DETECTEE</font><br/><br/> ";
        texte += log;
        Response.Write(texte);
    }

}