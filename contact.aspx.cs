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
using System.Net.Mail;
using System.Net;
using System.IO;

public partial class contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       ((Label)Page.Master.FindControl("titrebandeau")).Text = "Contact";

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SmtpClient smtp = new SmtpClient();
        MailMessage message = new MailMessage();
        String ip = Request.UserHostAddress.ToString();
        String date = DateTime.Now.ToString();
       

        try
        {
            MailAddress adresseExpediteur = new MailAddress(tbExpediteur2.Text);


            //IP adresse du serveur SMTP
            smtp.Host = "127.0.0.1";

            //port par defaut pour le protocol SMTP
            smtp.Port = 25;

            //l'adresse de l'expéditeur est transmise a l'objet MailAddress
            message.From = new MailAddress(tbExpediteur2.Text);

            //adresse une collection 
            message.Subject = "contact patrimo.net";


            message.To.Add("info@patrimo.net");

            message.IsBodyHtml = false;

            message.Body = tbBody.Text;

            //envoie au serveur SMTP
            smtp.Send(message);

            Label1.Text = "Email envoyé avec succès";

            Connexion c = null;

            String requete = "INSERT INTO Messages (email_contact,message,ip_address,date_mail) VALUES ( '" + message.From.ToString() + "','" + message.Body.ToString() + "','" + ip + "','"+date+"')";

            c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c.Open();
            c.exeRequette(requete);
            c.Close();
            c = null;
            
        }
        catch (Exception ex)
        {
            Label1.Text = "Erreur email : " + ex.Message;
        }
   }



}
