using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Net.Mail;


/// <summary>
/// Summary description for ProcedeAlerteMail
/// </summary>
[WebService(Namespace = "http://patrimo.net/")]
[WebServiceBinding(ConformsTo = WsiProfiles.None)]
public class ProcedeAlerteMail : System.Web.Services.WebService {

    public ProcedeAlerteMail () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    public string envoiMail(string dest, string sujet, string body)
    {
        SmtpClient smtp = new SmtpClient();
        MailMessage message = new MailMessage();
        String date = DateTime.Now.ToString();
        string retour = "";

        //smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
        try
        {
            Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c.Open();
            System.Data.DataSet ds = c.exeRequette("Select * from Environnement");
            c.Close();

            String Host_smtp = (String)ds.Tables[0].Rows[0]["Host_smtp"];
            String Port_smtp = (String)ds.Tables[0].Rows[0]["Port_smtp"];

            //IP adresse du serveur SMTP
            smtp.Host = Host_smtp;

            // port par defaut pour le protocol SMTP
            smtp.Port = int.Parse(Port_smtp);

            //l'adresse de l'expéditeur est transmise a l'objet MailAddress
            message.From = new MailAddress("info@patrimo.fr");

            // adresse une collection 
            message.Subject = sujet;

            message.To.Add(dest);

            message.IsBodyHtml = true;

            message.Body = body;

            retour = "Envoi d'un mail. From : " + message.From + " To : " + dest;
            // envoie au serveur SMTP
            smtp.Send(message);

        }
        catch (Exception ex)
        {
            retour += "\n erreur "+ex.GetType().ToString()+"dans la creation et l'envoi du mail : " + ex.Message + "\n source : " + ex.StackTrace + "  \n";
        }
        return retour;
    }


    /// <summary>
    /// permet d'afficher un bien au format html a partir de sa reference
    /// 
    /// Attention, on formate en utf8 pour la page html (grâce à "System.Web.HttpUtility.HtmlEncode");
    /// 
    /// </summary>
    /// <param name="reference"></param>
    /// <returns></returns>
    private String afficheBien(String reference) 
    {

        String texteHtmlDeRetour = "";


        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();
        System.Data.DataSet ds = c.exeRequette("Select * from Environnement");
        c.Close();

        String racine_site = (String)ds.Tables[0].Rows[0]["Chemin_racine_site"];

        String path = reference;
        string srcJpg = racine_site+"/images/" + path + "A.JPG";
        string sourceJpg = "./" + path + "A.JPG";
        if (System.IO.File.Exists(srcJpg) == false) sourceJpg = "./logo_320.jpg";


        Bien b = BienDAO.getBien(reference);



        double prixFranc = b.PRIX_VENTE * 6.55957;

        String  Francs = prixFranc.ToString();
        String euro = b.PRIX_VENTE.ToString();



        int indexF = Francs.IndexOf(',');

        int indexFin = Francs.Length;
        int indexFinEuro = euro.Length;


        if (indexF != -1) Francs = Francs.Remove(indexF, indexFin - indexF);
        indexFin = Francs.Length;

        do
        {
            indexFin = indexFin - 3;
            if (indexFin > 0) Francs = Francs.Insert(indexFin, " ");
        }
        while (indexFin > 0);

        do
        {
            indexFinEuro = indexFinEuro - 3;
            if (indexFinEuro > 0) euro = euro.Insert(indexFinEuro, " ");
        }
        while (indexFinEuro > 0);

        texteHtmlDeRetour +=
                 "<br />"
                 + "<table border=\"0\" width=\"600\">"
                 + "<tr><td width=\"128\"></td><td width=\"322\"></td><td width=\"150\"></td></tr>"
            //+"<div class=\"Resultat-header\">"
                 + "<tr><td colspan=\"2\" width=\"450\" bgcolor=\"#31536c\"><b>"
            // + "<div class=\"Resultat-header-prix-euro\">"
                              + "<a href=\"http://www.patrimo.fr/fichedetail.aspx?ref=" + System.Web.HttpUtility.HtmlEncode(b.REFERENCE) + "\">"
                              + "<font color=\"#FFFFFF\">" + System.Web.HttpUtility.HtmlEncode(b.CATEGORIE) + " - " + b.NBRE_PIECE + System.Web.HttpUtility.HtmlEncode(" pièces - ")
                              + b.S_HABITABLE + System.Web.HttpUtility.HtmlEncode(" m²") + " - " + System.Web.HttpUtility.HtmlEncode(b.VILLE_BIEN) + "</b></font>"
                          + "</a>"
            // + "</div>"
                     + "</td><td colspan=\"1\" width=\"150\" bgcolor=\"#31536c\">"
                      + "<div class=\"Resultat-header-left\" align=\"right\">"
                          + "<a href=\"http://www.patrimo.fr/pages/fichedetail.aspx?ref=" + System.Web.HttpUtility.HtmlEncode(b.REFERENCE) + "\">"
                              + "<font color=\"#FFFFFF\"><b>" + System.Web.HttpUtility.HtmlEncode(euro) + System.Web.HttpUtility.HtmlEncode(" euros  ") + "</b></font>"
                              + "</a>"
                      + "</div>"
                  //+ "</div>"
                  //+ "<div class=\"Resultat\">"
                  + "</td></tr>"
                 //+ "<table border=\"0\" width=\"600\">"
                 + "<tr><td colspan=\"1\" width=\"128\">"
                     // + "<div class=\"Resultat-photo\">"
                          + "<a class=\"lienImage\" href=\"http://www.patrimo.fr/pages/fichedetail1.aspx?ref=" + System.Web.HttpUtility.HtmlEncode(b.REFERENCE) + "\"> <img alt=\"photo\" src=\"http://www.patrimo.fr/images/" + sourceJpg + "\" style=\" border:none; float:left; width:128px; height:96px\" /></a>"
                    //  + "</div>"
                      + "</td><td colspan=\"2\" width=\"472\">"
                     // + "<div class=\"Resultat-text\">"
                         + "<p align=\"justify\">"+System.Web.HttpUtility.HtmlEncode(b.TEXTE_INTERNET)+"</p>" + "<br />"
                         + "<STRONG>" + System.Web.HttpUtility.HtmlEncode("Référence : ") + " </STRONG>" + System.Web.HttpUtility.HtmlEncode(b.REFERENCE) + "<br />"
                         + "<STRONG>Contact : </STRONG>" + System.Web.HttpUtility.HtmlEncode(b.NOM_AGENCE) + " - " + System.Web.HttpUtility.HtmlEncode(b.ADRESSE_AGENCE)
                         + " " + System.Web.HttpUtility.HtmlEncode(b.CODE_POSTALE_AGENCE) + "  " + System.Web.HttpUtility.HtmlEncode(b.VILLE_AGENCE) + "<br />T&eacute;l : " + System.Web.HttpUtility.HtmlEncode(b.TEL_AGENCE)
                     // + "</div>"
                      + "</td></tr></table>"
                 //+ "</div>"
                 + "<p>&nbsp;</p><hr />"
                      ;
        
        return texteHtmlDeRetour;
    }

    [WebMethod]
    public string procede()
    {

        //la chaine retournée
        String retour = "";

        //la connection a la bdd

        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();



        //pour tous les membres
        System.Collections.Generic.IList<Membre> members = MembreDAO.getAllMembers();
        System.Collections.Generic.IEnumerator<Membre> i = members.GetEnumerator();
        while (i.MoveNext())
        {

            //les bien interessants pour le client
            System.Collections.Generic.List<System.Data.DataRow> drClient = new System.Collections.Generic.List<DataRow>();

            //pour toutes les alertes emails
            System.Collections.Generic.IList<RequeteBien> listeMembres = MembreDAO.getAlerteMembre(i.Current);
            System.Collections.Generic.IEnumerator<RequeteBien> l = listeMembres.GetEnumerator();
            while (l.MoveNext())
            {

                try
                {

                    System.Data.DataSet ds = null;
                    ds = c.exeRequette(l.Current.REQUETE_SQL);

                    //pour tous les biens correspondant a l'alerte mail ... et qui on été soient modifiés soient ajoutés :
                    System.Collections.IEnumerator dr = ds.Tables[0].Rows.GetEnumerator();
                    while (dr.MoveNext())
                    {
                        //si le bien a été mis a jour récement
                        if (((bool)(((System.Data.DataRow)dr.Current)["maj"])))
                        {
                            drClient.Add((System.Data.DataRow)dr.Current);
                        }
                    }// fin biens
                }
                catch (Exception ee) { retour += "\n erreur dans la recherche des biens interessants pour le client : " + ee.Message + "\n"; }

            }//fin alerte mail



            //on envoie que si il y a des nouveaux biens interessants pour l'utilisateur : 
            if (drClient.Count != 0)
            {

                retour += " \nmail envoyé à : " + i.Current.ID_CLIENT;

                #region envoie du mail


                SmtpClient smtp = new SmtpClient();
                MailMessage message = new MailMessage();
                String date = DateTime.Now.ToString();


                try
                {
                    Connexion c1 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    c1.Open();
                    System.Data.DataSet ds = c.exeRequette("Select * from Environnement");
                    c1.Close();

                    String Host_smtp = (String)ds.Tables[0].Rows[0]["HostSMTP"];
                    String Port_smtp = (String)ds.Tables[0].Rows[0]["Port_smtp"];

                    //IP adresse du serveur SMTP
                    smtp.Host = Host_smtp;

                    // port par defaut pour le protocol SMTP
                    smtp.Port = int.Parse(Port_smtp);

                    //l'adresse de l'expéditeur est transmise a l'objet MailAddress
                    message.From = new MailAddress("info@patrimo.net");

                    // adresse une collection 
                    message.Subject = "Patrimo : un bien vous interesse";

                    message.To.Add(i.Current.ID_CLIENT);

                    message.IsBodyHtml = true;

                    message.Body = "";

                    //on met tous les biens intressants dans le corp du message
                    System.Collections.Generic.IEnumerator<System.Data.DataRow> iDr = drClient.GetEnumerator();

                    message.Body += "<body><table border=\"0\" width=\"600\" cellspacing=\"0\" cellpadding=\"0\">"
                                    + "<tr><td width=\"100%\">"
                                    + "<img src=\"http://www.patrimo.fr/img_site/logo_patrimonium.jpg\" /><font size=\"4\"><b>PATRIMO - Agence immobili&egrave;re</b></font></td></tr>"
                                    + "<tr><td width=\"100%\">";
                    while (iDr.MoveNext())
                        message.Body += afficheBien((String)(iDr.Current)["ref"]);

                    message.Body += "</td></tr>"
                                    + "<tr><td width=\"100%\">"
                                    + "<p align=\"center\">Agence Patrimo | <a href=\"http://www.patrimo.fr/\" target=\"_blank\">www.patrimo.fr</a> | 01.46.49.82.60 | 25 rue Gabriel Peri - 92700 Colombes</p>"
                                    + "</td></tr></table></body>";


                    // envoie au serveur SMTP
                    smtp.Send(message);


                    String requete = "INSERT INTO Messages (email_contact,message,ip_address,date_mail) VALUES ( '" + message.From.ToString() + "','" + message.Body.ToString() + "','???','" + date + "')";

                    c.exeRequette(requete);


                }
                catch (Exception ex)
                {
                    retour += "\n erreur dans la creation et l'envoi du mail : " + ex.Message + "\n source : " + ex.StackTrace + "  \n";
                }

                #endregion

            }


        }//fin du menbre



        try
        {
            //enfin, on spécifie que les maj on été éffectués dans la table bien : 
            c.exeRequette("UPDATE Biens SET Biens.maj = True");
        }
        catch (Exception e) { retour += " \nerreur dans la mise a jour de la table bien " + e.Message + "\n"; }

        if (c != null)
            c.Close();

        return "Resultats du " + DateTime.Now + "  :  \n" + retour;
    }

}







