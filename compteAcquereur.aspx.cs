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

public partial class pages_compteAcquereur : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private Boolean checkField(Acquereur acquereur)
    {
		((Label)Page.Master.FindControl("titrebandeau")).Text = "Mon espace";
		
        #region attributs

        Regex regEmail = new Regex(@"^([\w\-.]+)@([a-zA-Z0-9\-.]+)$");
        Regex numReg = new Regex("^[0-9 ]+$");
        Regex alphaNumReg = new Regex("^[0-9 a-zA-Zéèçàâù . ]+$|^()+$");
        Regex alphaReg = new Regex("^[a-zA-Zéèçàâù ]+$");


        Boolean boolCivilite = false;
        Boolean boolNom = false;
        Boolean boolPrenom = false;
        Boolean boolAdresse = false;
        Boolean boolCodePostal = false;
        Boolean boolVille = false;
        Boolean boolPays = false;
        Boolean boolTel = false;
        Boolean boolMail = false;


        #endregion

        //boolCivilite = CheckBoxCiviliteMr.Checked ;
        boolNom = alphaReg.IsMatch(TextBoxNom.Text.Trim());
        boolPrenom = alphaReg.IsMatch(TextBoxPrenom.Text.Trim());
        boolAdresse = alphaNumReg.IsMatch(TextBoxAdresse.Text.Trim());
        boolCodePostal = numReg.IsMatch(TextBoxCodePostal.Text.Trim());
        boolVille = alphaReg.IsMatch(TextBoxVille.Text.Trim());
        boolTel = alphaNumReg.IsMatch(TextBoxTel.Text.Trim());
        boolMail = regEmail.IsMatch(TextBoxMail.Text.Trim());
        #region try...catch


        try
        {
            if (RadioButtonMr.Checked) acquereur.CIVILITE = "Mr";
            if (RadioButtonMme.Checked) acquereur.CIVILITE = "Mme";
            if (RadioButtonMlle.Checked) acquereur.CIVILITE = "Mlle";
        }
        catch
        {
            acquereur.CIVILITE = "erreur";
        }
        try
        {
            if (boolNom) acquereur.NOM = TextBoxNom.Text.Trim();
        }
        catch
        {
            acquereur.NOM = "";
        }

        try
        {
            if (boolPrenom) acquereur.PRENOM = TextBoxPrenom.Text.Trim();
        }
        catch
        {
            acquereur.PRENOM = "";
        }
        try
        {
            acquereur.ADRESSE = TextBoxAdresse.Text.Trim();
        }
        catch
        {
            acquereur.ADRESSE = "";
        }
        try
        {
            acquereur.CODE_POSTAL = TextBoxCodePostal.Text.Trim();
        }
        catch
        {
            acquereur.CODE_POSTAL = "";
        }
        try
        {
            acquereur.VILLE = TextBoxVille.Text.Trim();
        }
        catch
        {
            acquereur.VILLE = "";
        }
        try
        {
            acquereur.TEL = TextBoxTel.Text.Trim();
        }
        catch
        {
            acquereur.TEL = "";
        }
        try
        {
            acquereur.PAYS = TextBoxPays.Text;
        }
        catch
        {
            acquereur.PAYS = "";
        }

        try
        {
            acquereur.MAIL = TextBoxMail.Text;
        }
        catch
        {
            acquereur.MAIL = "";
        }

        #endregion

        if (boolNom && boolPrenom && boolAdresse && boolCodePostal && boolVille && boolTel && boolMail)
        {
        LabelOk.Text = " -> L'acquéreur a été correctement ajouté<br />";
        LabelOk.Visible = true;
        return true;
  
       }
       else
       {
            LabelErrorLogin.Visible = true;

            LabelErrorLogin.Text = "Erreur de saisie pour les champs suivants : <br />";

            // MANDAT
            if (boolNom == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Nom de l'acquéreur <br />";
            // Adresse du bien
            if (boolPrenom == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Prénom de l'acquéreur <br />";
            if (boolAdresse == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Adresse de l'acquéreur <br />";
            if (boolCodePostal == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Code Postal du bien <br />";
            if (boolVille == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Ville de l'acquéreur <br />";
            if (boolTel == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Téléphone du bien <br />";
            if (boolMail == false) LabelErrorLogin.Text = LabelErrorLogin.Text + " -> Adresse email l'acquéreur <br />";
            return false;
        }
    }



    protected void ajouterAcquereur(object sender, EventArgs e)
    {
        Acquereur acquereur = new Acquereur();

     

        if (checkField(acquereur))
        {
            AcquereurDAO.addAcquereur(acquereur, 0, ""); // TODO
        }
    }
}

