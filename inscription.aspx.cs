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

public partial class pages_inscription : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		//((Label)Page.Master.FindControl("titrebandeau")).Text = "Inscription";
    }
/*
    private Boolean checkField(Membre member)
    {
        #region attributs
            // Les différents regex permettant de vérifier si les champs sont corrects
            Regex regEmail = new Regex(@"^([\w\-.]+)@([a-zA-Z0-9\-.]+)$");
            Regex numReg = new Regex("^[0-9 ]+$");
            Regex alphaNumReg = new Regex("^[0-9]+$|^[a-zA-Zéèçàâù ]+$|^()+$");
            Regex alphaReg = new Regex("^[a-zA-Zéèçàâù ]+$");
            

            Boolean boolMail=false;
            Boolean boolNom=false;
            Boolean boolPrenom=false;
            Boolean boolVille=false;
            Boolean boolPassword=false;

        #endregion

        boolMail = regEmail.IsMatch(TextBoxEmail.Text.Trim());
        boolNom =  alphaReg.IsMatch(TextBoxNom.Text.Trim());
        boolPrenom = alphaReg.IsMatch(TextBoxPrenom.Text.Trim());
        boolVille = alphaReg.IsMatch(TextBoxVille.Text.Trim());
        boolPassword = alphaReg.IsMatch(TextBoxPassword.Text.Trim());
        
        #region try...catch
            // on remplit l'objet member
            try
            {
                if (RadioButtonMr.Checked) member.CIVILITE = "Mr";
                if (RadioButtonMme.Checked) member.CIVILITE = "Mme";
                if (RadioButtonMlle.Checked) member.CIVILITE = "Mlle";
            }
            catch
            {
                member.CIVILITE = "erreur";
            }
            try
            {
                if (boolMail) member.ID_CLIENT = TextBoxEmail.Text.Trim();
            }
            catch
            {

            }
            try
            {
                if (boolNom) member.NOM = TextBoxNom.Text.Trim();
            }
            catch
            {
                member.NOM = "erreur";
                
            }
            try
            {
                if (boolPrenom) member.PRENOM = TextBoxPrenom.Text.Trim();
            }
            catch
            {
                member.PRENOM = "erreur";
            }
            try
            {
                member.ADRESSE = TextBoxAdresse.Text.Trim();
            }
            catch
            {
                member.ADRESSE = "NC";
            }
            try
            {
                member.CODE_POSTAL = TextBoxCodePostal.Text.Trim();
            }
            catch
            {
                member.CODE_POSTAL = "NC";
            }
            try
            {
                member.VILLE = TextBoxVille.Text.Trim();
            }
            catch
            {
                member.VILLE = "NC";
            }
            try
            {
                member.TEL = TextBoxTel.Text.Trim();
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
                member.SOCIETE = TextBoxSociete.Text.Trim();
            }
            catch
            {
                member.SOCIETE = "NC";
            }
            try
            {
                if (boolPassword && TextBoxPassword.Text == TextBoxPasswordConfirmation.Text)
                {
                    member.PASSWORD = TextBoxPassword.Text;
                }
            }
            catch
            {

            }
            try
            {
                member.PAYS = DropDownListPays.Text;
            }
            catch
            {
                member.PAYS="NC";
            }

        #endregion



            // Si toutes les vérifs sont ok, la checkfield est ok
            if (boolMail && boolNom && boolPrenom && boolPassword && (TextBoxPassword.Text == TextBoxPasswordConfirmation.Text)) 
                return true;

            // sinon, on fait des messages d'erreur personalisés
            else
            {
                LabelErrorLogin.Visible = true;
                LabelErrorLogin.Text = "Veuillez indiquer : <br />";
                if (boolNom == false)
                {
                    LabelErrorLogin.Text += " -> votre nom <br /> ";
                }
                if (boolPrenom == false)
                {
                    LabelErrorLogin.Text += " -> votre prénom <br /> ";
                }
                if (boolMail == false)
                {
                    LabelErrorLogin.Text += " -> votre email <br /> ";
                }
                if (boolPassword == false)
                {
                    LabelErrorLogin.Text += " -> votre mot de passe <br />";
                }
                if (TextBoxPassword.Text != TextBoxPasswordConfirmation.Text)
                {
                    LabelErrorLogin.Text += " -> le même mot de passe <br />";
                }
                return false;
            }
    }

    */



    private Boolean checkField(Membre member)
    {
        try
        {
            // on remplit l'objet member
            member.CIVILITE = DDLCivil.SelectedValue;
            member.ID_CLIENT = TBMail.Text.Trim();
            member.NOM = TBNom.Text.Trim();
            member.PRENOM = TBPrenom.Text.Trim();
            member.ADRESSE = TBAdresse.Text.Trim();
            member.CODE_POSTAL = TBCP.Text.Trim();
            member.VILLE = TBVille.Text.Trim();
            member.TEL = TBTel.Text.Trim();
            member.FAX = TBFax.Text.Trim();
            member.SOCIETE = TBSociete.Text.Trim();
            if (TBPass.Text == TBPassConfirm.Text) member.PASSWORD = TBPass.Text;
            member.PAYS = DropDownListPays.Text;
        }
        catch (Exception ex)
        {
            Response.Write("<strong>Bonjour, l'erreur suivante a été générée :</strong><br/>" + ex + "Veuillez retenter cette opération. Si elle devait de produire a nouveau, veuillez envoyer cette erreur a info@patrimo.net<br/>");
            return false;
        }

        return true;
    }


    protected void ButtonEnregistrer_Click1(object sender, EventArgs e)
    {
        Membre member = new Membre();

        if (checkField(member))
        {
            try
            {
                MembreDAO.addMember(member);
                Response.Redirect("./inscriptionAccueil.aspx?valid=oui");
            }
            catch
            {
                LabelErrorLogin.Visible = true;
               
              
                LabelErrorLogin.Text = "Email déjà utilisé, veuillez recommencer votre inscription";                
            }                
        }
      
    }
}
