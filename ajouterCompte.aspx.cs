using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data.Odbc;
using System.Data;
using System.Windows.Forms;

public partial class ajouterCompte : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblmail.Text = "";
        Membre member = (Membre)Session["Membre"];
        if (member == null || (member.STATUT != "nego" && member.STATUT != "ultranego"))
        {
           Response.Redirect("./recherche.aspx");
		   Response.Close();
        }
		
        //cette methode est pour remplir le DROPBOX de parrain
        Connexion c = new Connexion();
        OdbcCommand selectAllNego = new OdbcCommand("select * from Clients where statut ='ultranego' or statut = 'nego' order by nom_client");
        c.Open();
        DataRowCollection reader = c.exeRequetteParametree(selectAllNego).Tables[0].Rows;
        c.Close();
        foreach (DataRow nego in reader)
        {
            ListItem unNegociateur = new ListItem(nego["nom_client"].ToString()+"  "+nego["prenom_client"].ToString(), nego["idclient"].ToString() );
            DropDownListParain.Items.Add(unNegociateur);
            //if (unNegociateur.Value == "5") unNegociateur.Selected = true;
        }
    }
    private void remplir(Membre member) 
    {
        String temp = "", temp2 = "";
        // on remplit l'objet member

        //Champ Civilité  
         try
        {
           temp = RadioButtonMr.ClientID;
            temp = temp.Replace("_", "$");
            temp = temp.Replace("RadioButtonMr", RadioButtonMr.GroupName);
            temp2 = Page.Request.Form[temp];

            if (temp2 == "RadioButtonMr") { member.CIVILITE = "Mr"; }

            if (temp2 == "RadioButtonMme") member.CIVILITE = "Mme";
            if (temp2 == "RadioButtonMlle") member.CIVILITE = "Mlle";
        }
        catch
        {
            member.CIVILITE = "erreur";
        }

        //Champ NOM
         try
         {
             temp = TextBoxNom.ClientID;
             temp = temp.Replace("_", "$");
             temp2 = Page.Request.Form[temp];
             member.NOM = temp2;

         }
         catch
         {
             member.NOM = "erreur";

         }

        //Champ PRENOM
         try
         {
             temp = TextBoxPrenom.ClientID;
             temp = temp.Replace("_", "$");
             temp2 = Page.Request.Form[temp];
             member.PRENOM = temp2;

         }
         catch
         {
             member.PRENOM = "erreur";
         }
        //Champ Adresse
         try
         {
             temp = TextBoxAdresse.ClientID;
             temp = temp.Replace("_", "$");
             member.ADRESSE = Page.Request.Form[temp];
         }
         catch
         {
             member.ADRESSE = "NC";
         }
        //Champ CODE POSTAL
         try
         {
             temp = TextBoxCodePostal.ClientID;
             temp = temp.Replace("_", "$");
             member.CODE_POSTAL = Page.Request.Form[temp];
         }
         catch
         {
             member.CODE_POSTAL = "NC";
         }

        //Champ VILLE
         try
         {
             temp = TextBoxVille.ClientID;
             temp = temp.Replace("_", "$");
             member.VILLE = Page.Request.Form[temp];
         }
         catch
         {
             member.VILLE = "NC";
         }
        //Champ PAYS
         try
         {
             temp = DropDownListPays.ClientID;
             temp = temp.Replace("_", "$");
             member.PAYS = Page.Request.Form[temp];
         }
         catch
         {
             member.PAYS = "NC";
         }

        //Champ Email
         try
         {
             temp = TextBoxEmail.ClientID;
             temp = temp.Replace("_", "$");
             temp2 = Page.Request.Form[temp];
             member.ID_CLIENT = temp2;

         }
         catch
         {
            
         }
        //Champ MOT DE PASSE
         try
         { 
             temp = TextBoxPasswordConfirmation.ClientID;
             temp = temp.Replace("_", "$");
             temp2=Page.Request.Form[temp];
             member.PASSWORD = temp2;
         }
         catch
         {

         }
        //Champ TELEPHONE
         try
         {
             temp = TextBoxTel.ClientID;
             temp = temp.Replace("_", "$");
             member.TEL = Page.Request.Form[temp];
         }
         catch
         {
             member.TEL = "NC";
         }
        //champ FAX
         try
         {
             temp = TextBoxFax.ClientID;
             temp = temp.Replace("_", "$");
             member.FAX = Page.Request.Form[temp];
         }
         catch
         {
             member.FAX = "NC";
         }
        //Champ  Societe
         try
         {
             temp = TextBoxSociete.ClientID;
             temp = temp.Replace("_", "$");
             member.SOCIETE = Page.Request.Form[temp];
         }
         catch
         {
             member.SOCIETE = "NC";
         }


        //Champ Parrain

         try
         {
             temp = DropDownListParain.ClientID;

             temp = temp.Replace("_", "$");
             string nomparrain = "";
             string nompa = DropDownListParain.SelectedValue;
             nomparrain = Page.Request.Form[temp];
             member.IDPARAIN = Convert.ToInt32(nomparrain);
         }
         catch
         {
             member.IDPARAIN = 0;
         }
        //Champ Statuts
         try
         {
             temp = DropDownListStatut.ClientID;
             temp = temp.Replace("_", "$");
             member.STATUT = Page.Request.Form[temp];
         }
         catch
         {
             member.STATUT = "";
         }
        //Champ Contractuel 

        try
        {
            temp = CheckBoxContractuel.ClientID;
            temp = temp.Replace("_", "$");
            temp2 = Page.Request.Form[temp];
            if (temp2 == "on")
                member.Contractuel = "YES";
            else
                member.Contractuel = "NO";

        }
        catch
        {
            member.Contractuel = "NO";
        }


        //récuperer le num de l'agence 
        try
        {
            temp = txtnAgence.ClientID;
            temp = temp.Replace("_", "$");
            member.NUM_AGENCE = Page.Request.Form[temp];
        }
        catch
        {
            member.NUM_AGENCE = "erreur";
        }
        
        // KBIS
        // Je ne trouvais pas comment mettre le kbis par defaut si le textbox etait vide alors je le met ici ..
        try
        {
            temp = TextBoxKbis.ClientID;
            temp = temp.Replace("_", "$");
            if (Page.Request.Form[temp] != "")
            {
                member.KBIS_CLIENT = Page.Request.Form[temp];
            }
            else
                member.KBIS_CLIENT = "454067596";
        }
        catch
        {
            member.KBIS_CLIENT = "erreur";
        }

        // NUMMINSELOGER
        try
        {
            temp = TextBoxNbminseloger.ClientID;
            temp = temp.Replace("_", "$");
            string nbMin = Page.Request.Form[temp];
            member.NBMINSELOGER_CLIENT = Convert.ToInt32(nbMin);
        }
        catch
        {
            member.NBMINSELOGER_CLIENT = 5;
        }
    }

    protected void ButtonEnregistrer_Click1(object sender, EventArgs e)
    {
		Regex regEmail = new Regex(@"^([\w\-.]+)@([\w]+)\.([\w]+)$");
        Regex regKbis = new Regex("^([0-9]{9})|([0-9]{14})$");
        bool valide = true;
		if(!regEmail.IsMatch(TextBoxEmail.Text))
		{
			lblmail.Text += "<br/>Email invalide";
			valide = false;
		}
        if (TextBoxEmail.Text == "")
        {
            lblmail.Text += "<br/>Email obligatoire";
            valide = false;
        }
        if (TextBoxKbis.Text != "" && !regKbis.IsMatch(TextBoxKbis.Text))
            {
                lblmail.Text += "<br/>Kbis invalide";
                valide = false;
            }
		if(TextBoxPassword.Text != TextBoxPasswordConfirmation.Text)
		{
			lblmail.Text += "<br/>Les mots de passe ne correspondent pas";
			valide = false;
		}

		if(TextBoxPassword.Text == "")
		{
			lblmail.Text += "<br/>Mot de passe vide";
			valide = false;
		}
		if(TextBoxNom.Text == "" || TextBoxPrenom.Text == "")
		{
			lblmail.Text += "<br/>Champs requis manquant";
			valide = false;
		}


        

        Membre member = new Membre();
        remplir(member);

       // Methode pour verifier si le email est deja utilisé 
        String email = member.ID_CLIENT;
        string sql = "SELECT * FROM Clients WHERE id_client='" + email + "'";
        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();
        System.Data.DataSet ds = c.exeRequette(sql);
        c.Close();
        string temp3 = "";
        try
        {
           temp3=(String)ds.Tables[0].Rows[0]["id_client"];             
        }
        catch
        {

        }
        if(valide == true && temp3 == email )
        {
            lblmail.Text += "Le courriel est déjà attribué.";
            lblmail.Visible = true;
        }
        else
        {

            MembreDAO.addMember(member);
            Response.Redirect("./moncomptetableaudebord_bis.aspx");
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        TextBoxNom.BorderColor = System.Drawing.Color.OrangeRed;  
    }
    protected void DropDownListParain_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}