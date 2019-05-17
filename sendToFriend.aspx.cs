using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Net.Mail;

public partial class pages_sendAtFriend : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void prenom1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void mail_TextChanged(object sender, EventArgs e)
    {

    }
    protected void message_TextChanged(object sender, EventArgs e)
    {

    }
    protected void prenom2_TextChanged(object sender, EventArgs e)
    {

    }
    protected void send_Click(object sender, EventArgs e)
    {

        #region envoie du mail

        SmtpClient smtp = new SmtpClient();
        MailMessage message = new MailMessage();
        String date = DateTime.Now.ToString();
        if(mail.Text != "")
        {
            try
            {
                // On récupère le port et l'hote smtp dans la table environnement
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
                message.From = new MailAddress("no-reply@patrimo.fr");

                // adresse une collection 
                message.Subject = "Voici une annonce qui pourrait t'intéresser (de la part de " + prenom2.Text + ")";

                message.To.Add(mail.Text);

                message.IsBodyHtml = true;

                message.Body = "";
         
                message.Body += "<div style=\"background-color:White;border-bottom: black 1px solid;padding-bottom:5px;height:100px\">"
                                    + "<div style=\"float:left\">"
                                        + "<img alt=\"photo\" src=\"http://www.patrimo.net/patrimo/img_site/logo_patrimonium.jpg\" style=\" border:none;width:80px; height:80px\" />"
                                      + "</div>"
                                      + "<div style=\"float:left;font-size:25px;font-weight:bold;color:#31536c;margin-left:10px;margin-top:28px\">"
                                        + "<span style=\"font-family:font-family:Times New Roman\">Annonce provenant de l'agence PATRIMO<span>"
                                      + "</div>"
                                + "</div>"
                                + "<div style=\"background-color:White;font-weight:bold;border-bottom: black 1px solid;padding-bottom:5px;margin-top:3px;height:15px\">"
                                    + message1.Text
                                + "</div>";

                message.Body += afficheBien(Request.Params["ref"].ToString());

                message.Body += "<div style=\"background-color:White;font-weight:bold;border-bottom: black 1px solid;padding-bottom:5px;margin-top:3px;height:15px\">"
                                    + "de la part de " + prenom2.Text;


                // envoi au serveur SMTP
                smtp.Send(message);

                // Notification de réussite de l'envoi
                LabelEnvoi.Visible = true;
                LabelEnvoi.Text = "Le message a bien été envoyé";

            }

            catch { }
        }
        else
        {
                LabelEnvoi.Visible = true;
                LabelEnvoi.Text = "Le mail du destinataire est requis.";
        }

        #endregion

        
    }

    private String afficheBien(String reference)
    {
        String texteHtmlDeRetour = "";
        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();
        System.Data.DataSet ds = c.exeRequette("Select * from Environnement");
        c.Close();

        String racine_site = (String)ds.Tables[0].Rows[0]["Chemin_racine_site"];

        String path = reference;
        string srcJpg = racine_site + "/images/" + path + "A.JPG";
        string sourceJpg = "./" + path + "A.JPG";
        if (System.IO.File.Exists(srcJpg) == false) sourceJpg = "./logo_320.jpg";

        Bien b = BienDAO.getBien(reference);
        String euro = "";
        String type = "";

        if (b.LOYER == 0)
        {
            euro = b.PRIX_VENTE.ToString();
            euro += " euros";
            type = "4";
        }
        else
        {
            euro = b.LOYER.ToString();
            euro += " euros CC";
            type = "5";            
        }

        int indexFinEuro = euro.Length;

        texteHtmlDeRetour +=
                 "<br />"
                 

                      + "<div class=\"Resultat-header-prix-euro\" style=\"float:right;font-size:12pt;font-family:Times New Roman;color:Black;background-color:White;margin-right:10px;font-weight: bold;\">"
                          + "<a style=\"color:black;text-decoration:none\" href=http://www.patrimo.net/patrimo/pages/fichedetail1.aspx?page=" + type + "+&ref=" + System.Web.HttpUtility.HtmlEncode(b.REFERENCE) + ">"
                              + System.Web.HttpUtility.HtmlEncode(euro)
                              + "</a>"
                      + "</div>"

                      + "<div class=\"Resultat-header-left\" style=\"font-weight: bold;font-size: 12pt;color: black;font-family: 'Times New Roman';text-decoration: none;margin-left:2px;\">"
                              + "<a style=\"color:black;text-decoration:none\" href=http://www.patrimo.net/patrimo/pages/fichedetail1.aspx?page=" + type + "&ref=" + System.Web.HttpUtility.HtmlEncode(b.REFERENCE) + ">"
                              + System.Web.HttpUtility.HtmlEncode(b.CATEGORIE) + " - " + b.NBRE_PIECE + " pieces - " + b.S_HABITABLE + System.Web.HttpUtility.HtmlEncode(" m² - ") + b.CODE_POSTAL_BIEN + " - " + b.VILLE_BIEN
                          + "</a>"
                      + "</div>"
                  + "</div>"

                  + "<div class=\"Resultat\" style=\"background-color:White;border-bottom: black 1px solid;margin-bottom: 0px;\">"
                      + "<div class=\"Resultat-photo\" style=\"float: left;height: 96px;border-top: #ffffff 2px solid;border-bottom: #ffffff 2px solid;margin-left:2px;margin-right:2px;\">"
                          + "<a class=\"lienImage\" href=http://www.patrimo.net/patrimo/pages/fichedetail1.aspx?page=" + type + "&ref=" + System.Web.HttpUtility.HtmlEncode(b.REFERENCE) + "> <img alt=\"photo\" src=http://www.patrimo.net/patrimo/images/" + sourceJpg + " style=\" border:none; float:left; width:128px; height:96px\" /></a>"
                      + "</div>";


        // Au niveau du contact de la fiche détail dans le mail envoyé, on va chercher soit les coordonnées de l'agence
        // Soit celles du négo
        if (b.REFERENCE.Substring(1, 3) == "999") // pour le négo, adresse siege mais tel et mail négo
        {
            String nom_siege = (String)ds.Tables[0].Rows[0]["nom_societe"];
            String adresse_siege = (String)ds.Tables[0].Rows[0]["adresse_societe"];
            String cp_siege = (String)ds.Tables[0].Rows[0]["cp_societe"];
            String ville_siege = (String)ds.Tables[0].Rows[0]["ville_societe"];
            String tel_siege = (String)ds.Tables[0].Rows[0]["tel_societe"];

            Connexion c2 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c2.Open();
            System.Data.DataSet ds2 = c2.exeRequette("Select * from Clients WHERE `idclient`=" + b.IDCLIENT);
            c2.Close();

            String tel_nego = (String)ds2.Tables[0].Rows[0]["tel_client"];
            String email_nego = (String)ds2.Tables[0].Rows[0]["id_client"];

            texteHtmlDeRetour +=

                       "<div class=\"Resultat-text\" style=\"background-color: White;color: Black;font-family: Times New Roman;font-size: 10pt;height: 110px;width: 500px;border-top: #ffffff 2px solid;border-bottom: #ffffff 2px solid;text-align: justify; \">"
                         + System.Web.HttpUtility.HtmlEncode(b.TEXTE_INTERNET) + "<br />" + "<br />"
                         + "<STRONG>" + System.Web.HttpUtility.HtmlEncode("Reférence : ") + " </STRONG>" + System.Web.HttpUtility.HtmlEncode(b.REFERENCE) + " - tel: " + System.Web.HttpUtility.HtmlEncode(tel_nego) + "<br />"
                         + "<STRONG>Contact : </STRONG>" + System.Web.HttpUtility.HtmlEncode(nom_siege) + " - " + System.Web.HttpUtility.HtmlEncode(adresse_siege)
                         + " - " + System.Web.HttpUtility.HtmlEncode(cp_siege) + "  " + System.Web.HttpUtility.HtmlEncode(ville_siege) + "<br />"
                         + "<STRONG> email : </STRONG>" + System.Web.HttpUtility.HtmlEncode(email_nego)
                      + "</div>"
                 + "</div>"
                      ;
        }
        else // Pour l'agence
        {
            if (b.NEGOCIATEUR != "")
            {
                //Si l'annonce a été envoyée par un nego, on récupère dans la table Clients les coordonnées de ce nego.   
                string PrenomNomNego = b.NEGOCIATEUR;
                string[] WordArray;
                string[] stringSeparators = new string[] { " " };
                WordArray = PrenomNomNego.Split(stringSeparators, StringSplitOptions.None);
                if (WordArray.Length > 1)
                {
                    Response.Write("<tr><td>");
                    String NomNego = WordArray[1];
                    String PrenomNego = WordArray[0];
                    String requette = "select id_client, tel_client from Clients where `idclient`=" + b.IDCLIENT;
                    System.Data.DataSet ds2 = null;

                    Connexion c2 = null;

                    c2 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    c2.Open();
                    ds2 = c2.exeRequette(requette);
                    c2.Close();
                    c2 = null;

                    System.Data.DataRowCollection dr2 = ds2.Tables[0].Rows;

                    foreach (System.Data.DataRow ligne in dr2)
                    {
                        texteHtmlDeRetour +=

                           "<div class=\"Resultat-text\" style=\"background-color: White;color: Black;font-family: Times New Roman;font-size: 10pt;height: 110px;width: 500px;border-top: #ffffff 2px solid;border-bottom: #ffffff 2px solid;text-align: justify; \">"
                             + System.Web.HttpUtility.HtmlEncode(b.TEXTE_INTERNET) + "<br />" + "<br />"
                             + "<STRONG>" + System.Web.HttpUtility.HtmlEncode("Reférence : ") + " </STRONG>" + System.Web.HttpUtility.HtmlEncode(b.REFERENCE) + "<br/><strong>tel vendeur:</strong> " + System.Web.HttpUtility.HtmlEncode(b.TEL_AGENCE) + "<br />"
                             + "<br/><STRONG>Contact : </STRONG>" + System.Web.HttpUtility.HtmlEncode(PrenomNego) + " " + System.Web.HttpUtility.HtmlEncode(NomNego)
                             + "<br/><strong>tel : </strong>" + System.Web.HttpUtility.HtmlEncode(ligne["tel_client"].ToString())
                             + "<br/><STRONG>email : </STRONG>" + System.Web.HttpUtility.HtmlEncode(ligne["id_client"].ToString())
                          + "</div>"
                     + "</div>"
                          ;
                    }
                }
            }
            else if (b.NOM_AGENCE != "")
            {
                texteHtmlDeRetour +=

                           "<div class=\"Resultat-text\" style=\"background-color: White;color: Black;font-family: Times New Roman;font-size: 10pt;height: 110px;width: 500px;border-top: #ffffff 2px solid;border-bottom: #ffffff 2px solid;text-align: justify; \">"
                             + System.Web.HttpUtility.HtmlEncode(b.TEXTE_INTERNET) + "<br />" + "<br />"
                             + "<STRONG>" + System.Web.HttpUtility.HtmlEncode("Reférence : ") + " </STRONG>" + System.Web.HttpUtility.HtmlEncode(b.REFERENCE) + " - tel: " + System.Web.HttpUtility.HtmlEncode(b.TEL_AGENCE) + "<br />"
                             + "<STRONG>Contact : </STRONG>" + System.Web.HttpUtility.HtmlEncode(b.NOM_AGENCE) + " - " + System.Web.HttpUtility.HtmlEncode(b.ADRESSE_AGENCE)
                             + " - " + System.Web.HttpUtility.HtmlEncode(b.CODE_POSTALE_AGENCE) + "  " + System.Web.HttpUtility.HtmlEncode(b.VILLE_AGENCE)
                             + "<STRONG> email : </STRONG>" + System.Web.HttpUtility.HtmlEncode(b.MAIL_AGENCE)
                          + "</div>"
                     + "</div>"
                          ;
            }

         }
        return texteHtmlDeRetour;
    }


}