using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class votreavis : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Page.Master.FindControl("titrebandeau")).Text = "Votre Avis";
    }
    protected void Buttonvotreavis_Click(object sender, EventArgs e) 
    {
        SmtpClient smtp = new SmtpClient();
        MailMessage message = new MailMessage();
        String ip = Request.UserHostAddress.ToString();
        String date = DateTime.Now.ToString();

        if (Page.IsValid)
        {
            try
            {
                Session["nomavis"] = TextBoxNomvotreavis.Text.Trim();
                Session["emailavis"] = TextBoxEmailvotreavis.Text.Trim();
                Session["prenomavis"]=TextBoxPrenomvotreavis.Text.Trim();
                Session["telephoneavis"]=TextBoxTelvotreavis.Text.Trim();
                Session["adresseavis"]=TextBoxAdressevotreavis.Text.Trim();
                Session["codepostalavis"]=TextBoxCodePostalvotreavis.Text.Trim();
                Session["villeavis"]= TextBoxVillevotreavis.Text.Trim();
                string moyens = "";
                if (CheckBox1.Checked) { moyens += CheckBox1.Text + ";"; }
                if (CheckBox2.Checked) { moyens += CheckBox2.Text + ";"; }
                if (CheckBox3.Checked) { moyens += CheckBox3.Text + ";"; }
                if (CheckBox4.Checked) { moyens += CheckBox4.Text + ";"; }
                if (CheckBox5.Checked) { moyens += CheckBox5.Text + ";"; }
                else { moyens = ""; }

                string recommand = "";
                if (recommander.Checked) { recommand = "oui"; }
                else if (Radi1.Checked) { recommand = "non"; }
                string question1="";
                if (radio1.Checked) {question1 = "Très Satisfait"; }
                else if (radio2.Checked) { question1 = "Satisfait"; }
                else if (radio3.Checked) { question1 = "Pas satisfait"; }
                else if (radio4.Checked) { question1 = "Pas du tout satisfait"; }
                string question2 = "";
                if (radio5.Checked) { question2 = "Très Satisfait"; }
                else if (radio6.Checked) { question2 = "Satisfait"; }
                else if (radio7.Checked) { question2 = "Pas satisfait"; }
                else if (radio8.Checked) { question2 = "Pas du tout satisfait"; }
                string question3 = "";
                if (radio9.Checked) { question3 = "Très Satisfait"; }
                else if (radio10.Checked) { question3 = "Satisfait"; }
                else if (radio11.Checked) { question3 = "Pas satisfait"; }
                else if (radio12.Checked) { question3 = "Pas du tout satisfait"; }
                string question4 = "";
                if (radio13.Checked) { question4 = "Très Satisfait"; }
                else if (radio14.Checked) { question4 = "Satisfait"; }
                else if (radio15.Checked) { question4 = "Pas satisfait"; }
                else if (radio16.Checked) { question4 = "Pas du tout satisfait"; }
                string question5 = "";
                if (radio17.Checked) { question5 = "Très Satisfait"; }
                else if (radio18.Checked) { question5 = "Satisfait"; }
                else if (radio19.Checked) { question5 = "Pas satisfait"; }
                else if (radio20.Checked) { question5 = "Pas du tout satisfait"; }
                string question6 = "";
                if (radio21.Checked) { question6 = "Très Satisfait"; }
                else if (radio22.Checked) { question6 = "Satisfait"; }
                else if (radio23.Checked) { question6 = "Pas satisfait"; }
                else if (radio24.Checked) { question6 = "Pas du tout satisfait"; }
                string question7 = "";
                if (radio25.Checked) { question7 = "Très Satisfait"; }
                else if (radio26.Checked) { question7 = "Satisfait"; }
                else if (radio27.Checked) { question7 = "Pas satisfait"; }
                else if (radio28.Checked) { question7 = "Pas du tout satisfait"; }
                string question8 = "";
                if (radio29.Checked) { question8 = "Très Satisfait"; }
                else if (radio30.Checked) { question8 = "Satisfait"; }
                else if (radio31.Checked) { question8 = "Pas satisfait"; }
                else if (radio32.Checked) { question8 = "Pas du tout satisfait"; }
                string question9 = "";
                if (radio33.Checked) { question9 = "Très Satisfait"; }
                else if (radio34.Checked) { question9 = "Satisfait"; }
                else if (radio35.Checked) { question9 = "Pas satisfait"; }
                else if (radio36.Checked) { question9 = "Pas du tout satisfait"; }

                MailAddress avisfrom = new MailAddress(TextBoxEmailvotreavis.Text.Trim());

                Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                c.Open();
                System.Data.DataSet ds = c.exeRequette("Select * from Environnement");
                c.Close();
                String strhost = (String)ds.Tables[0].Rows[0]["HostSMTP"];
                string stremail = (string)ds.Tables[0].Rows[0]["email_commande"];
                smtp.Host = strhost;
                smtp.Port = 25;
                message.From = new MailAddress(TextBoxEmailvotreavis.Text.Trim());        
                string proprietes = "";
                if (Acquéreur.Checked) { proprietes = "Acquéreur"; message.Subject = "Avis de Acquéreur"; }
                else if (Vendeur.Checked) { proprietes = "Vendeur"; message.Subject = "Avis de Vendeur"; }
                else { message.Subject = "Avis de nous"; }

                message.To.Add(stremail);
                message.IsBodyHtml = true;
                message.Body =
                    "<form border='1'><tr><td>nom:</td><td>" + Session["nomavis"] + "</td></tr>" +
                    "<tr><td>prenom:</td><td>" + Session["prenomavis"] + "</td></tr>" +
                    "<tr><td>telephone:</td><td>" + Session["telephoneavis"] + "</td></tr>" +
                    "<tr><td>email:</td><td>" + Session["emailavis"] + "</td></tr>" +
                    "<tr><td>adress:</td><td>" + Session["adresseavis"] + "</td></tr>" +
                    "<tr><td>codepostal:</td><td>" + Session["codepostalavis"] + "</td></tr>" +
                    "<tr><td>ville:</td><td>" + Session["villeavis"] + "</td></tr>" +
                    "<tr><td>La présentation et l'attitude de votre conseiller:</td><td>" + question1 + "</td></tr>" +
                    "<tr><td>L'écoute et la compréhension de vos attentes:</td><td>" + question2 + "</td></tr>" +
                    "<tr><td>La présentation des services et de l'accompagnement proposés:</td><td>" + question3 + "</td></tr>" +
                    "<tr><td>La qualité de l'accompagnement de votre conseiller:</td><td>" + question4 + "</td></tr>" +
                    "<tr><td>L'efficacité de votre conseiller:</td><td>" + question5 + "</td></tr>" +
                    "<tr><td>Qualité des informations juridiques communiquées:</td><td>" + question6 + "</td></tr>" +
                    "<tr><td>Qualité des conseils et des biens proposés:</td><td>" + question7 + "</td></tr>" +
                    "<tr><td>Qualité du suivi commercial et administratif:</td><td>" + question8 + "</td></tr>" +
                    "<tr><td>Votre opinion en général du service PATRIMO:</td><td>" + question9 + "</td></tr>" +
                    "<tr><td>Découvert PATRIMO par:</td><td> " + moyens + "</td></tr>" +
                    "<tr><td>Recommanderiez-vous PATRIMO autour de vous :</td><td>" + recommand + "</td></tr>" +
                    "<tr><td>content:</td><td>" + tbBodyvotreavis.Text + "</td></tr>" +
                    "</form>";
                   
              
                smtp.Send(message);

                Style avisstyle = new Style();
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Font.Size = new FontUnit(18);
                Label1.Text = "Formulare envoyé avec succès";

                this.formavis.Visible = false;


            }
            catch(Exception ex)
            {
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "Erreur email : " + ex.Message;
            }
        
        }
    
    }
}