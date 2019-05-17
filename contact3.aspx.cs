using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;


public partial class contact3 : System.Web.UI.Page
{
    protected List<String> agence; 


    protected void Page_Load(object sender, EventArgs e)
    {
        int i = 0;
        String num_max_agence = "001";
        String requette = "SELECT `num` FROM Biens WHERE `actif`='actif' GROUP BY `num` ORDER BY Count(Biens.[num]) DESC";

        System.Data.DataSet ds = null;
        Connexion c = null;

        c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();
        ds = c.exeRequette(requette);
        c.Close();
        c = null;

        System.Data.DataRowCollection dr = ds.Tables[0].Rows;

        foreach (System.Data.DataRow ligne in dr)
        {
            num_max_agence = (string)ligne["num"].ToString();
            break;

        }
        requette = "SELECT `lien_plan_google`,`num_agence`,`adresse_agence`, `code_postal_agence`, `ville_agence`, `telephone_agence`, `email_agence`, `telecopie_agence` FROM Agences WHERE Agences.[num_agence]='" + num_max_agence + "'";
        c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();
        ds = c.exeRequette(requette);
        c.Close();
        c = null;

        dr = ds.Tables[0].Rows;

        foreach (System.Data.DataRow ligne in dr)
        {
            agence = new List<string> { (string)ligne["num_agence"].ToString(), (string)ligne["adresse_agence"].ToString(), (string)ligne["code_postal_agence"].ToString(), (string)ligne["ville_agence"].ToString(), (string)ligne["email_agence"].ToString(), (string)ligne["telephone_agence"].ToString(), (string)ligne["lien_plan_google"].ToString() };
            new ListItem((string)ligne["ville_agence"].ToString() + " - " + (string)ligne["code_postal_agence"].ToString() + " - " + (string)ligne["adresse_agence"].ToString() + " - " + (string)ligne["telephone_agence"].ToString(), (string)ligne["num_agence"].ToString());
        }

        i++;
        requette = "SELECT `lien_plan_google`,`num_agence`,`adresse_agence`, `code_postal_agence`, `ville_agence`, `telephone_agence`, `email_agence`, `telecopie_agence` FROM Agences WHERE `num_agence` <> '" + num_max_agence + "' ORDER BY Agences.[ville_agence]";
        c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();
        ds = c.exeRequette(requette);
        c.Close();
        c = null;
        dr = ds.Tables[0].Rows;
        foreach (System.Data.DataRow ligne in dr)
        {
            new ListItem((string)ligne["ville_agence"].ToString() + " - " + (string)ligne["code_postal_agence"].ToString() + " - " + (string)ligne["adresse_agence"].ToString() + " - " + (string)ligne["telephone_agence"].ToString(), (string)ligne["num_agence"].ToString());
            i++;
        }


        if (!Page.IsPostBack)
        {
            if (Request.QueryString["ref_bien"] != null) tbBody.Text = "Bonjour,\r\nJe vous contacte à propos du bien de référence " + Request.QueryString["ref_bien"] + ".\r\n \r\n ";

            if ((Membre)Session["Membre"] != null)
            {
                Membre member = (Membre)Session["Membre"];
                if (member.NOM != null) TextBoxNomcontact.Text = member.NOM;
                if (member.PRENOM != null) TextBoxPrenomcontact.Text = member.PRENOM;
                if (member.TEL != null) TextBoxTelcontact.Text = member.TEL;
                if (member.ID_CLIENT != null) TextBoxEmailcontact.Text = member.ID_CLIENT;
                TextBoxAdressecontact.Text="";
                if (member.ADRESSE != null) TextBoxAdressecontact.Text += member.ADRESSE + ", ";
                if (member.CODE_POSTAL != null) TextBoxAdressecontact.Text += member.CODE_POSTAL + ", ";
                if (member.VILLE != null) TextBoxAdressecontact.Text += member.VILLE;
            }
           }
        }


    protected void Button1_Click(object sender, EventArgs e)
    {
        SmtpClient smtp = new SmtpClient();
        MailMessage message = new MailMessage();
        String ip = Request.UserHostAddress.ToString();
        String date = DateTime.Now.ToString();

         if (Page.IsValid) 
         {  
            try
            {
                String nomContact, emailcontact, prenomcontact, telcontact, adressecontact;
                nomContact = TextBoxNomcontact.Text.Trim();
                emailcontact = TextBoxEmailcontact.Text.Trim();
                prenomcontact = TextBoxPrenomcontact.Text.Trim();
                telcontact = TextBoxTelcontact.Text.Trim();
                adressecontact = TextBoxAdressecontact.Text.Trim();

                MailAddress adresseExpediteur = new MailAddress(TextBoxEmailcontact.Text.Trim());

                //IP adresse du serveur SMTP
                Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                c.Open();
                System.Data.DataSet ds = c.exeRequette("Select * from Environnement");
                c.Close();
                String strhost = (String)ds.Tables[0].Rows[0]["HostSMTP"];
                smtp.Host = strhost;
                string stremail = (string)ds.Tables[0].Rows[0]["email_commande"];
                //port par defaut pour le protocol SMTP
                smtp.Port = 25;

                //l'adresse de l'expéditeur est transmise a l'objet MailAddress
                message.From = new MailAddress(TextBoxEmailcontact.Text.Trim());

                //adresse une collection 
                message.Subject = "Contact patrimo.net";

                message.To.Add(stremail);

                message.IsBodyHtml = true;
                 
                message.Body = "Nom:" + nomContact + "<br/> " + "Prenom:" + prenomcontact + "<br/> " + "Telephone:" +telcontact + "<br/> " + "Email:" + emailcontact + "<br/> " + "Adresse:" + adressecontact + "<br/> " + tbBody.Text + "<br/><hr/><br/>URL du bien: http://213.41.249.27/pages/fichedetail1.aspx?ref="+Request.QueryString["ref_bien"]+"&page=2";

                //envoie au serveur SMTP

                try
                {
                    smtp.Send(message);

                }
                catch (Exception ex)
                {
                    Response.Write(ex);

                }

                Style monstyle = new Style();
                LBLInfoMail.ForeColor = System.Drawing.Color.Green;

                LBLInfoMail.Text = "Email envoyé avec succès<br/> Nous vous recontacterons dès que possible";

                //Label1.ForeColor = Color.blue;
            

                //Connexion c = null;

                String requete = "INSERT INTO Messages (email_contact,message,ip_address,date_mail) VALUES ( '" + message.From.ToString() + "','" + message.Body.ToString() + "','" + ip + "','"+date+"')";

                c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                c.Open();
                c.exeRequette(requete);
                c.Close();
                c = null;
            
            }
            catch (Exception ex)
            {

                LBLInfoMail.ForeColor = System.Drawing.Color.Red;
                LBLInfoMail.Text = "Erreur email : " + ex.Message;
            }
       
             }
        
             else 
             {
                 LBLInfoMail.Text = "Il manque un champs requis !";
             }
      
   }


    protected void DropDownListAgence1_SelectedIndex(object sender, EventArgs e)
    {
        DataSet ds = null;
        String requette = "SELECT `lien_plan_google`,`num_agence`,`adresse_agence`, `code_postal_agence`, `ville_agence`, `telephone_agence`, `email_agence`, `telecopie_agence` FROM Agences WHERE  `num_agence`='001' ORDER BY Agences.[ville_agence]";

        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();
        ds = c.exeRequette(requette);
        c.Close();
        c = null;


        System.Data.DataRowCollection dr = ds.Tables[0].Rows;



        foreach (System.Data.DataRow ligne in dr)
        {
            Session["adresse agence"] = (string)ligne["adresse_agence"].ToString();
            Session["code postal agence"] = (string)ligne["code_postal_agence"].ToString();
            Session["ville agence"] = (string)ligne["ville_agence"].ToString();
            Session["mail agence"] = (string)ligne["email_agence"].ToString();
            Session["telephone agence"] = (string)ligne["telephone_agence"].ToString();
            Session["telecopie agence"] = (string)ligne["telecopie_agence"].ToString();
            Session["lien_plan_google"] = (string)ligne["lien_plan_google"].ToString();

        }
    }
}

  



   
