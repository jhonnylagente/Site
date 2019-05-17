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
using System.Text.RegularExpressions;
using System.Net.Mail;

public partial class pages_retrouverPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		((Label)Page.Master.FindControl("titrebandeau")).Text = "Mon espace";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Regex regEmail = new Regex(@"^([\w\-.]+)@([a-zA-Z0-9\-.]+)$");
        Boolean boolMail = false;

        boolMail = regEmail.IsMatch(TextBoxMail.Text.Trim());
        
        if (boolMail)
        {
            try
            {
                Membre member = MembreDAO.getMember(TextBoxMail.Text.Trim());
                
                if (member != null)
                {
                    mailUser(member);
                    Session["Membre"] = member;
                    Response.Redirect("./inscriptionAccueil.aspx?valid=mail");
                    
                }
                else
                {
                    LabelError.Text = "Adresse Email introuvable";
                }
                
            }
            catch
            {
                LabelError.Text = "Erreur de traitement";
            }
        }
        else
        {
            LabelError.Text = "Adresse email invalide";
        }

    }

    private void mailUser(Membre member)
    {
        SmtpClient smtp = new SmtpClient();
        MailMessage message = new MailMessage();
        String ip = Request.UserHostAddress.ToString();
        String date = DateTime.Now.ToString();
        
            // On récupère le port et l'hote smtp dans la table environnement
            Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c.Open();
            System.Data.DataSet ds = c.exeRequette("Select * from Environnement");
            c.Close();

            String Host_smtp = (String)ds.Tables[0].Rows[0]["HostSMTP"];
            //String Host_smtp = (String)ds.Tables[0].Rows[0]["Host_smtp"];
            String Port_smtp = (String)ds.Tables[0].Rows[0]["Port_smtp"];

            //IP adresse du serveur SMTP
            smtp.Host = Host_smtp;

            // port par defaut pour le protocol SMTP
            smtp.Port = int.Parse(Port_smtp);

            //l'adresse de l'expéditeur est transmise a l'objet MailAddress
            message.From = new MailAddress("no-reply@patrimo.fr");

            message.To.Add(new MailAddress(member.ID_CLIENT));

            // adresse une collection 
            message.Subject = "Identifiants patrimo.net";

            message.IsBodyHtml = true;

            message.Body = "Bonjour, voici vos identifiants vous permettant de vous connecter à votre compte sur http://www.patrimo.net <br/> <br/> <br/> <strong>Votre login: </strong>" + member.ID_CLIENT + "<br/> <br/>" + "<strong>votre mot de passe: </strong>" + member.PASSWORD;

            // envoie au serveur SMTP
            smtp.Send(message);

            //Response.Redirect("./accueil.aspx"); 
        
    }
}
