using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class louver : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("./vendre.aspx?type=loc");
    }
    protected void Buttonlestimer_Click(object sender, EventArgs e)
    {
        SmtpClient smtp = new SmtpClient();
        MailMessage message = new MailMessage();
        String ip = Request.UserHostAddress.ToString();
        String date = DateTime.Now.ToString();

        if (Page.IsValid)
        {
            try
            {
                Session["typedebienlestimer"] = TextBoxTypedebienlestimer.Text.Trim();
                Session["Surfacehabitablelestimer"] = TextBoxSurfacehabitablelestimer.Text.Trim();
                Session["Surfaceterrainlestimer"] = TextBoxSurfaceterrainlestimer.Text.Trim();
                Session["nombredepiecelestimer"] = TextBoxnombredepiecelestimer.Text.Trim();
                Session["localisationlestimer"] = TextBoxlocalisationlestimer.Text.Trim();
                Session["prixlestimer"] = TextBoxprixlestimer.Text.Trim();
                Session["nomlestimer"] = TextBoxNomlestimer.Text.Trim();
                Session["emaillestimer"] = TextBoxEmaillestimer.Text.Trim();
                Session["prenomlestimer"] = TextBoxPrenomlestimer.Text.Trim();
                Session["telephonelestimer"] = TextBoxTellestimer.Text.Trim();
                Session["adresselestimer"] = TextBoxAdresselestimer.Text.Trim();
                Session["codepostallestimer"] = TextBoxCodePostallestimer.Text.Trim();
                Session["villelestimer"] = TextBoxVillelestimer.Text.Trim();




                MailAddress estimerfrom = new MailAddress(TextBoxEmaillestimer.Text.Trim());

                Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                c.Open();
                System.Data.DataSet ds = c.exeRequette("Select * from Environnement");
                c.Close();
                String strhost = (String)ds.Tables[0].Rows[0]["HostSMTP"];
                string stremail = (string)ds.Tables[0].Rows[0]["email_commande"];
                smtp.Host = strhost;
                smtp.Port = 25;
                message.From = new MailAddress(TextBoxEmaillestimer.Text.Trim());
                message.Subject = "Je loue contact Patrimo";

                message.To.Add(stremail);
                message.IsBodyHtml = true;
                message.Body =
                    "<form border='1'><tr><td>nom:</td><td>" + Session["nomlestimer"] + "</td></tr>" +
                    "<tr><td>prenom:</td><td>" + Session["prenomlestimer"] + "</td></tr>" +
                    "<tr><td>telephone:</td><td>" + Session["telephonelestimer"] + "</td></tr>" +
                    "<tr><td>email:</td><td>" + Session["emaillestimer"] + "</td></tr>" +
                    "<tr><td>adress:</td><td>" + Session["adresselestimer"] + "</td></tr>" +
                    "<tr><td>codepostal:</td><td>" + Session["codepostallestimer"] + "</td></tr>" +
                    "<tr><td>ville:</td><td>" + Session["villelestimer"] + "</td></tr>" +
                    "<tr><td>Type de bien:</td><td>" + Session["typedebienlestimer"] + "</td></tr>" +
                    "<tr><td>Surface habitable:</td><td>" + Session["Surfacehabitablelestimer"] + "</td></tr>" +
                    "<tr><td>Surface terrain:</td><td>" + Session["Surfaceterrainlestimer"] + "</td></tr>" +
                    "<tr><td>Nombre de pièces:</td><td>" + Session["nombredepiecelestimer"] + "</td></tr>" +
                    "<tr><td>Localisation:</td><td>" + Session["localisationlestimer"] + "</td></tr>" +
                    "<tr><td>Prix de vente souhaité:</td><td>" + Session["prixlestimer"] + "</td></tr>" +
                    "<tr><td>content:</td><td>" + TextBoxmessagelestimer.Text + "</td></tr>" +
                    "</form>";


                smtp.Send(message);

                Style avisstyle = new Style();
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Font.Size = new FontUnit(18);
                Label1.Text = "Formulare envoyé avec succès";

                this.formavis.Visible = false;


            }
            catch (Exception ex)
            {
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "Erreur email : " + ex.Message;
            }

        }

    }
}