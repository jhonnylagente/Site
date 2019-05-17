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

public partial class pages_moncomteCoordonnees : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		((Label)Page.Master.FindControl("titrebandeau")).Text = "Coordonnées";

        if (!IsPostBack) 
        {
            try
            {
                Membre member = (Membre)Session["membre"];

                if (Session["logged"].Equals(true))
                {
                    if (member.CIVILITE == "Mr")
                    {
                        RadioButtonMr.Checked = true;
                    }
                    else if (member.CIVILITE == "Mme")
                    {
                        RadioButtonMme.Checked = true;
                    }
                    else
                    {
                        RadioButtonMlle.Checked = true;
                    }
                    TextBoxNom2.Text = member.NOM;
                    TextBoxPrenom2.Text = member.PRENOM;
                    TextBoxAdresse2.Text = member.ADRESSE;
                    TextBoxVille2.Text = member.VILLE;
                    TextBoxCodePostal2.Text = member.CODE_POSTAL;
                    TextBoxTel2.Text = member.TEL;
                    TextBoxFax.Text = member.FAX;
                    TextBoxSociete2.Text = member.SOCIETE;
                    DropDownListPays2.Text = member.PAYS;
                }
                else
                {
                    Response.Redirect("./inscriptionAccueil.aspx");
                }
            }
            catch
            {
                Response.Redirect("./inscriptionAccueil.aspx");
            }
        }

    }


    private Membre checkField(Membre member)
    {
        #region attributs

        Regex numReg = new Regex("^[0-9 ]+$");
        Regex alphaNumReg = new Regex("^[0-9]+$|^[a-zA-Zéèçàâù ]+$|^()+$");
        Regex alphaReg = new Regex("^[a-zA-Zéèçàâù ]+$");

        Boolean boolNom = false;
        Boolean boolPrenom = false;
        Boolean boolPassword = false;
        Boolean boolVille = false;
        Boolean boolCP = false;

        #endregion

        LabelErreur.Visible = false;


        boolNom = alphaReg.IsMatch(TextBoxNom2.Text.Trim());
        boolPrenom = alphaReg.IsMatch(TextBoxPrenom2.Text.Trim());
        boolVille = alphaReg.IsMatch(TextBoxVille2.Text.Trim());

        #region try...catch


        try
        {
            if (RadioButtonMr.Checked == true) member.CIVILITE = "Mr";
            else if (RadioButtonMme.Checked == true) member.CIVILITE = "Mme";
            else if (RadioButtonMlle.Checked == true) member.CIVILITE = "Mlle";
        }
        catch
        {
            member.CIVILITE = "erreur";
        }
        try
        {
            if (boolNom) member.NOM = TextBoxNom2.Text.Trim();
            else
            {
                LabelErreur.Text = "Erreur de saisie";
                LabelErreur.Visible = true;
            }
        }
        catch
        {
            member.NOM = "erreur";
        }
        try
        {
            if (boolPrenom) member.PRENOM = TextBoxPrenom2.Text.Trim();
            else
            {
                LabelErreur.Text = "Erreur de saisie";
                LabelErreur.Visible = true;
            }
        }
        catch
        {
            member.PRENOM = "erreur";
        }
        try
        {
            member.ADRESSE = TextBoxAdresse2.Text.Trim();
        }
        catch
        {
            member.ADRESSE = "NC";
        }
        try
        {
            member.VILLE = TextBoxVille2.Text.Trim();
        }
        catch
        {
            member.VILLE = "NC";
        }
        try
        {
            member.CODE_POSTAL = TextBoxCodePostal2.Text.Trim();
        }
        catch
        {
            member.CODE_POSTAL = "NC";
        }
        try
        {
            member.TEL = TextBoxTel2.Text.Trim();
        }
        catch
        {
            member.TEL = "NC";
        }
        try
        {
            member.FAX = TextBoxFax.Text.Trim();
        }
        catch
        {
            member.FAX = "NC";
        }
        try
        {
            member.SOCIETE = TextBoxSociete2.Text.Trim();
        }
        catch
        {
            member.SOCIETE = "NC";
        }
        try
        {
            if (TextBoxPassword2.Text.Length.Equals(0) == false || TextBoxPasswordConfirmation2.Text.Length.Equals(0) == false)
            {
                if (TextBoxPassword2.Text == TextBoxPasswordConfirmation2.Text)
                {
                    member.PASSWORD = TextBoxPassword2.Text;
                }
                else
                {
                    LabelErreur.Text = "Verification du mot de passe invalide";
                    LabelErreur.Visible = true;
                    member = null;
                    return member;
                }
            }
        }
        catch
        {
            member.PASSWORD = "erreur";
        }
        try
        {
            member.PAYS = DropDownListPays2.Text;
        }
        catch
        {
            member.PAYS = "NC";
        }

        #endregion

        if (boolNom && boolPrenom) return member;
        else
        {
            member = null;
            return member;
        }
    }


    protected void ButtonEnregistrer_Click(object sender, EventArgs e)
    {
        Membre member = (Membre)Session["membre"];

        if (checkField(member)!=null)
        {
            MembreDAO.updateMember(member);
            LabelErreur.Text = "Vos informations ont été modifiées avec succès";
            LabelErreur.Visible = true;
        }
    }
}
