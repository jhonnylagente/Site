using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class vendre : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Page.Master.FindControl("titrebandeau")).Text = "Je vends";
    }
    protected void BoutonEnvoyer_Click(object sender, EventArgs e)
    {
        SmtpClient smtp = new SmtpClient();
        MailMessage message = new MailMessage();
        String ip = Request.UserHostAddress.ToString();
        String date = DateTime.Now.ToString();

        bool isNomEmpty = (TextBoxNomvestimer.Text.Length == 0);
        bool isPrenomEmpty = (TextBoxPrenomvestimer.Text.Length == 0);
        bool isTelEmpty = (TextBoxTelvestimer.Text.Length == 0);
        bool isMailEmpty = (TextBoxEmailvestimer.Text.Length == 0);

        if (isNomEmpty) RequiredFieldValidator1.InnerText = "Veuillez saisir votre nom";
        if (isPrenomEmpty) RequiredFieldValidator2.InnerText = "Veuillez saisir votre prénom";
        if (isTelEmpty) RequiredFieldValidator3.InnerText = "Veuillez saisir votre téléphone";
        if (isMailEmpty) RequiredFieldValidator4.InnerText = "Veuillez saisir votre email";

        if (!isNomEmpty && !isPrenomEmpty && !isTelEmpty && !isMailEmpty)
        {
            try
            {
                Session["typedebienvestimer"] = TextBoxTypedebienvestimer.Text.Trim();
                Session["Surfacehabitablevestimer"] = TextBoxSurfacehabitablevestimer.Text.Trim();
                Session["Surfaceterrainvestimer"] = TextBoxSurfaceterrainvestimer.Text.Trim();
                Session["nombredepiecevestimer"] = TextBoxnombredepiecevestimer.Text.Trim();
                Session["localisationvestimer"] = TextBoxlocalisationvestimer.Text.Trim();
                Session["prixvestimer"] = TextBoxprixvestimer.Text.Trim();
                Session["nomvestimer"] = TextBoxNomvestimer.Text.Trim();
                Session["emailvestimer"] = TextBoxEmailvestimer.Text.Trim();
                Session["prenomvestimer"] = TextBoxPrenomvestimer.Text.Trim();
                Session["telephonevestimer"] = TextBoxTelvestimer.Text.Trim();
                Session["adressevestimer"] = TextBoxAdressevestimer.Text.Trim();
                Session["codepostalvestimer"] = TextBoxCodePostalvestimer.Text.Trim();
                Session["villevestimer"] = TextBoxVillevestimer.Text.Trim();




                MailAddress estimerfrom = new MailAddress(TextBoxEmailvestimer.Text.Trim());

                Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                c.Open();
                System.Data.DataSet ds = c.exeRequette("Select * from Environnement");
                c.Close();
                String strhost = (String)ds.Tables[0].Rows[0]["HostSMTP"];
                string stremail = (string)ds.Tables[0].Rows[0]["email_commande"];
                smtp.Host = strhost;
                smtp.Port = 25;
                message.From = new MailAddress(TextBoxEmailvestimer.Text.Trim());
                message.Subject = "Je vends contact Patrimo";

                message.To.Add(stremail);
                message.IsBodyHtml = true;
                message.Body =
                    "<form border='1'><tr><td>nom:</td><td>" + Session["nomvestimer"] + "</td></tr>" +
                    "<tr><td>prenom:</td><td>" + Session["prenomvestimer"] + "</td></tr>" +
                    "<tr><td>telephone:</td><td>" + Session["telephonevestimer"] + "</td></tr>" +
                    "<tr><td>email:</td><td>" + Session["emailvestimer"] + "</td></tr>" +
                    "<tr><td>adress:</td><td>" + Session["adressevestimer"] + "</td></tr>" +
                    "<tr><td>codepostal:</td><td>" + Session["codepostalvestimer"] + "</td></tr>" +
                    "<tr><td>ville:</td><td>" + Session["villevestimer"] + "</td></tr>" +
                    "<tr><td>Type de bien:</td><td>" + Session["typedebienvestimer"] + "</td></tr>" +
                    "<tr><td>Surface habitable:</td><td>" + Session["Surfacehabitablevestimer"] + "</td></tr>" +
                    "<tr><td>Surface terrain:</td><td>" + Session["Surfaceterrainvestimer"] + "</td></tr>" +
                    "<tr><td>Nombre de pièces:</td><td>" + Session["nombredepiecevestimer"] + "</td></tr>" +
                    "<tr><td>Localisation:</td><td>" + Session["localisationvestimer"] + "</td></tr>" +
                    "<tr><td>Prix de vente souhaité:</td><td>" + Session["prixvestimer"] + "</td></tr>" +
                    "<tr><td>content:</td><td>" + TextBoxmessagevestimer.Text + "</td></tr>" +
                    "</form>";


                //smtp.Send(message);

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