using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Windows.Forms;

public partial class pages_recrutement_agentimmobilier : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((System.Web.UI.WebControls.Label)Page.Master.FindControl("titrebandeau")).Text = "Agent immobilier";
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
                Session["nomrecrutement"] = TextBoxNomrecrutement.Text.Trim();
                Session["emailrecrutement"] = TextBoxEmailrecrutement.Text.Trim();
                Session["prenomrecrutement"] = TextBoxPrenomrecrutement.Text.Trim();
                Session["telephonerecrutement"] = TextBoxTelrecrutement.Text.Trim();
                Session["adresserecrutement"] = TextBoxAdresserecrutement.Text.Trim();
                Session["codepostalrecrutement"] = TextBoxCodePostalrecrutement.Text.Trim();
                Session["villerecrutement"] = TextBoxVillerecrutement.Text.Trim();


                MailAddress recrutementfrom = new MailAddress(TextBoxEmailrecrutement.Text.Trim());

                Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                c.Open();
                System.Data.DataSet ds = c.exeRequette("Select * from Environnement");
                c.Close();
                String strhost = (String)ds.Tables[0].Rows[0]["HostSMTP"];
                string stremail = (string)ds.Tables[0].Rows[0]["email_commande"];
                smtp.Host = strhost;
                smtp.Port = 25;
                message.From = new MailAddress(TextBoxEmailrecrutement.Text.Trim());
                message.Subject = "Patrimo Recrutement CV";

                message.To.Add(stremail);
                //message.To.Add("woshisann@gmail.com");
                message.IsBodyHtml = true;
                message.Body =
                    "<form border='1'><tr><td>nom:</td><td>" + Session["nomrecrutement"] + "</td></tr>" +
                    "<tr><td>prenom:</td><td>" + Session["prenomrecrutement"] + "</td></tr>" +
                    "<tr><td>telephone:</td><td>" + Session["telephonerecrutement"] + "</td></tr>" +
                    "<tr><td>email:</td><td>" + Session["emailrecrutement"] + "</td></tr>" +
                    "<tr><td>adress:</td><td>" + Session["adresserecrutement"] + "</td></tr>" +
                    "<tr><td>codepostal:</td><td>" + Session["codepostalrecrutement"] + "</td></tr>" +
                    "<tr><td>ville:</td><td>" + Session["villerecrutement"] + "</td></tr>" +
                    "<tr><td>content:</td><td>" + TextBoxmessagerecrutement.Text + "</td></tr>" +
                    "</form>";

                
                if (FileUpload1.HasFile)
                {
                   
                    message.Attachments.Add(new Attachment(FileUpload1.PostedFile.InputStream, FileUpload1.FileName));
                }
                else { MessageBox.Show("c pas bon"); }
                
      

                smtp.Send(message);

                Style avisstyle = new Style();
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Font.Size = new FontUnit(18);
                Label1.Text = "Formulare envoyé avec succès";


            }
            catch (Exception ex)
            {
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "Erreur email : " + ex.Message;
            }

        }

    }

}