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
    String type = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["type"] != null) type = Request.QueryString["type"];

        switch (type)
        {
            case "v_estim": lbl_titre.Text = "VOUS SOUHAITEZ FAIRE ESTIMER VOTRE BIEN POUR UNE VENTE"; break;
            case "loc": lbl_titre.Text = "VOUS SOUHAITEZ METTRE VOTRE BIEN EN LOCATION"; break;
            case "l_estim": lbl_titre.Text = "VOUS SOUHAITEZ FAIRE ESTIMER VOTRE BIEN POUR UNE LOCATION"; break;
            case "l_gerer": lbl_titre.Text = "VOUS SOUHAITEZ FAIRE GERER VOTRE BIEN POUR UNE LOCATION"; break;
            default: lbl_titre.Text = "VOUS SOUHAITEZ VENDRE VOTRE BIEN"; break;
        }

        if (IsPostBack)
        {
            tb_type_bien.Text = "";
            tb_adresse_bien.Text = "";
            tb_prix_bien.Text = "";
            tb_surf_hab.Text = "";
            tb_surf_ter.Text = "";
            tb_nb_pieces.Text = "";
            tb_message.Text = "";
        }

    }



    protected void Buttonvestimer_Click(object sender, EventArgs e)
    {
        SmtpClient smtp = new SmtpClient();
        MailMessage message = new MailMessage();
        String ip = Request.UserHostAddress.ToString();
        String date = DateTime.Now.ToString();
        bool valid = false;
        String current_bloc = "";
 
        if (Page.IsValid)
        {
            try
            {
                Session["typedebienvestimer"] = tb_type_bien.Text.Trim();
                Session["Surfacehabitablevestimer"] = tb_surf_hab.Text.Trim();
                Session["Surfaceterrainvestimer"] = tb_surf_ter.Text.Trim();
                Session["nombredepiecevestimer"] = tb_nb_pieces.Text.Trim();
                Session["localisationvestimer"] = tb_adresse_bien.Text.Trim();
                Session["prixvestimer"] = tb_prix_bien.Text.Trim();
                Session["nomvestimer"] = tb_nom_client.Text.Trim();
                Session["emailvestimer"] = tb_mail_client.Text.Trim();
                Session["prenomvestimer"] = tb_prenom_client.Text.Trim();
                Session["telephonevestimer"] = tb_tel_client.Text.Trim();
                Session["adressevestimer"] = tb_adresse_client.Text.Trim();
                //Session["codepostalvestimer"] = TextBoxCodePostalvestimer.Text.Trim();
                //Session["villevestimer"] = TextBoxVillevestimer.Text.Trim();


                MailAddress estimerfrom = new MailAddress(tb_mail_client.Text.Trim());

                Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                c.Open();
                System.Data.DataSet ds = c.exeRequette("Select * from Environnement");
                c.Close();
                String strhost = (String)ds.Tables[0].Rows[0]["HostSMTP"];
                string stremail = (string)ds.Tables[0].Rows[0]["email_commande"];
                smtp.Host = strhost;
                smtp.Port = 25;
                message.From = new MailAddress(tb_mail_client.Text.Trim());
                
                switch (type)
                {
                    case "v_estim": message.Subject = "Contact Patrimo - Je fait estimer - vente"; break;
                    case "loc": message.Subject = "Contact Patrimo - Je loue"; break;
                    case "l_estim": message.Subject = "Contact Patrimo - Je fait estimer - location"; break;
                    case "l_gerer": message.Subject = "Contact Patrimo - Je fait gerer - location"; break;
                    default: message.Subject = "Contact Patrimo - Je vends"; break;
                }   

                message.To.Add(stremail);
                message.IsBodyHtml = true;
                message.Body = "<!DOCTYPE html><html><body>"
                + "<table style='width:100%;border:0px;border-collapse : collapse;'><tr><td style='border: 1px solid black;width:100%;background: #31536c; width:100%; height: 120px; text-align:center;'>"
                + "<a href='http://www.patrimo.net'> <img src='http://" + (String)ds.Tables[0].Rows[0]["IP"] + "/img_site/logo_white.png' style='margin-left:10px; margin-top:5px' height='130' align='left' alt='logo_white'/></a>"
                + "<br/><div id='main_title' style='font-size:25px; color:lightgrey; padding-bottom:5px'><strong>Contact Patrimo</strong></div> ";

                current_bloc = "<div id='subtitle' style='font-size:18px; color:lightgrey'><strong>aaaaaa</strong></div>";
                switch (type)
                {
                    case "v_estim": current_bloc = "<div id='subtitle' style='font-size:18px; color:lightgrey'><strong>Une personne souhaite faire estimer un bien en vente !</strong></div>"; break;
                    case "loc": current_bloc = "<div id='subtitle' style='font-size:18px; color:lightgrey'><strong>Une personne souhaite louer son bien !</strong></div>"; break;
                    case "l_estim": current_bloc = "<div id='subtitle' style='font-size:18px; color:lightgrey'><strong>Une personne souhaite faire estimer un bien en location !</strong></div>"; break;             
                    case "l_gerer": current_bloc = "<div id='subtitle' style='font-size:18px; color:lightgrey'><strong>Une personne souhaite faire gerer un bien en location !</strong></div>"; break;
                    default: current_bloc = "<div id='subtitle' style='font-size:18px; color:lightgrey'><strong>Une personne souhaite vendre un bien !</strong></div>"; break;
                }
               
                message.Body += current_bloc;
                current_bloc = "";

                message.Body += "</td></tr><tr><td style='border: 1px solid black;width:100%; margin:0; background: #ece6e6;'>"
                + "<table style='width:100%'><tr><td style='padding:4%'></td><td style='width:84%'>"
                + "<br/></div><br/> <div id='bloc' style='background: #FFFFFF; border: 1px solid lightgrey; position: top'><center><h1 style='font-size:20px'><strong>Son bien:</strong></h1>";
                if (tb_type_bien.Text != "")
                {
                    current_bloc += "<strong>Type de Bien : </strong> " + tb_type_bien.Text + "<br/>";
                    valid = true;
                }
                if (tb_adresse_bien.Text != "") 
                { 
                    current_bloc += "<strong>Adresse du Bien : </strong> " + tb_adresse_bien.Text + "<br/>"; 
                    valid = true; 
                }
                if (tb_prix_bien.Text != "")
                {
                    current_bloc += "<strong>Prix souhaite : </strong> " + tb_prix_bien.Text + "<br/>";
                    valid = true;
                }
                if (tb_surf_hab.Text != "")
                {
                    current_bloc += "<strong>Nombres de pieces : </strong> " + tb_surf_hab.Text + "<br/>";
                    valid = true;
                }
                if (tb_surf_hab.Text != "")
                {
                    current_bloc += "<strong>Surface habitable : </strong> " + tb_surf_hab.Text + "<br/>";
                    valid = true;
                }
                if (tb_nb_pieces.Text != "")
                {
                    current_bloc += "<strong>Surface terrain : </strong> " + tb_nb_pieces.Text + "<br/>";
                    valid = true;
                }

                if (!valid) current_bloc = "<strong>Aucun champs renseigne !<br/>";               
                message.Body += current_bloc + "<br/></center> </div></td><td style='padding:4%'></td></tr>";

                message.Body += "<tr><td style='padding:4%'></td><td style='width:84%'>"
                + "<br/></div><br/> <div id='bloc' style='background: #FFFFFF; border: 1px solid lightgrey; position: top'><center><h1 style='font-size:20px'><strong>Ses Coordonnees:</strong></h1>"
                + "<strong>Le client : </strong> " + tb_nom_client.Text.ToUpper() + " " + tb_prenom_client.Text + "<br/>"
                + "<strong>Telephone : </strong> " + tb_tel_client.Text+ "<br/>"
                + "<strong>email : </strong> " + tb_mail_client.Text+ "<br/>";
                if (tb_adresse_client.Text != "") message.Body += "<strong>Adresse : </strong> " + tb_adresse_client.Text + "<br/>";
                if (tb_conseiller_client.Text != "") message.Body += "<strong>Son conseiller : </strong> " + tb_conseiller_client.Text + "<br/>";

                message.Body += "<br/></center> </div></td><td style='padding:4%'></td></tr>";

                if (tb_message.Text.Length > 1)
                {
                    message.Body += "<tr><td style='padding:4%'></td><td style='width:84%'>"
                    + "<br/></div><br/> <div id='bloc' style='background: #FFFFFF; border: 1px solid lightgrey; position: top'><center><h1 style='font-size:20px'><strong>Son message:</strong></h1>"
                    + tb_message.Text
                    + "<br/><br/></center> </div></td><td style='padding:4%'></td></tr>";
                }

                message.Body += "</table><br/></table>";

                smtp.Send(message);

                /*Style avisstyle = new Style();
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Font.Size = new FontUnit(18);*/
                Label1.Text =  "<div style='color:red; font-size:18px; font-weight:bold'>Formulaire envoyé avec succès</div>Souhaitez vous nous proposer un autre bien ?<br/>";

                //this.formavis.Visible = false
            }
            catch (Exception ex)
            {
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "Erreur email : " + ex.Message;
            }

        }

    }
}