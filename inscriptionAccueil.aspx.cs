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

public partial class pages_inscriptionAccueil : System.Web.UI.Page
{
    


    protected void Page_Load(object sender, EventArgs e)
    {
		//((Label)Page.Master.FindControl("titrebandeau")).Text = "Identification";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Membre member = checkField();

        if (member!= null)
        {
            Session["membre"] = member; 
            Session["logged"] = true;
            HttpCookie ClientIDcookie = Request.Cookies["ClientID"];
            if (Request.Cookies["ClientID"] != null)
            {
                ClientIDcookie.Expires = System.DateTime.Now.AddDays(-7);
            }
            ClientIDcookie = new HttpCookie("ClientID");
            ClientIDcookie.Value = member.ID_CLIENT;
            ClientIDcookie.Expires = System.DateTime.Now.AddDays(7);
            //HttpCookie Passwordcookie = new HttpCookie("ClientPassword");
            //Passwordcookie.Expires = System.DateTime.Now.AddDays(7);
            //Passwordcookie.Value = member.PASSWORD;
            Response.Cookies.Add(ClientIDcookie);
            //Response.Cookies.Add(Passwordcookie);
            if (member.STATUT == "nego" || member.STATUT == "ultranego")
            {
                Response.Redirect("./moncomptetableaudebord_bis.aspx");
            }
            else
            {
                Response.Redirect("./recherche.aspx");
            }
        }

    }

    private Membre checkField()
    {
        Regex regEmail = new Regex(@"^([\w\-.]+)@([a-zA-Z0-9\-.]+)$");
        Boolean boolMail = false;
        Membre member = null;
        Boolean retour = false;

        LabelErrorLogin.Visible = false;
        LabelErrorLogin.Text = "";

        boolMail = regEmail.IsMatch(TextBoxEmail.Text.Trim());

        try
        {
            if (boolMail) member = MembreDAO.getMember(TextBoxEmail.Text.Trim());
            else
            {
                Label1.Visible = true;
                Label1.Text = "Erreur adresse email invalide<br />";
            }
            if(member == null && boolMail == true)
            {
                Label1.Visible = true;
                Label1.Text = "Votre adresse email est introuvable  <br />";
            }
        }
        catch
        {
            Label1.Visible = true;
            Label1.Text = "Erreur<br />";
        }

        try
        {
            if (member != null && member.PASSWORD == TextBoxPassword.Text)
            {
                Session["logged"] = true;
                HttpCookie ClientIDcookie = Request.Cookies["ClientID"];
                if (Request.Cookies["ClientID"] != null)
                {
                    ClientIDcookie.Expires = System.DateTime.Now.AddDays(-7);
                }
                ClientIDcookie = new HttpCookie("ClientID");
                ClientIDcookie.Value = member.ID_CLIENT;
                ClientIDcookie.Expires = System.DateTime.Now.AddDays(7);
                Response.Cookies.Add(ClientIDcookie);
            }
            else if(member!= null)
            {
                Label1.Text += "Erreur mot de passe invalide<br />";
                Label1.Visible = true;
                member = null;
            }
        }
        catch
        {
            Label1.Text += "Erreur mot de passe invalide<br />";
            Label1.Visible = true;
            member = null;
        }

        return member;
    }

    protected void ButtonRecoveryPassword_Click1(object sender, EventArgs e)
    {
        Response.Redirect("./retrouverPassword.aspx");
    }
    protected void Quickinscription_Click(object sender, EventArgs e)
    {
        Response.Redirect("./inscription.aspx");
    }
}
    