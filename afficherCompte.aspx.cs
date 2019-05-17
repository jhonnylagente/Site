using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data.Odbc;
using System.Data;
using System.ComponentModel;

public partial class afficherCompte : System.Web.UI.Page
{
    string idclients = "";
    //Variables pour l'email
    string emailA = "", emailN = "";
     
    protected void Page_Load(object sender, EventArgs e)
    {

        //le variable pour recuperer les pages Web 
           String s = Request.QueryString["field1"];
           string sql = "SELECT * FROM Clients WHERE idclient="+s;
           Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
           c.Open();
           System.Data.DataSet ds = c.exeRequette(sql);
           c.Close();

        ///clients
           idclients = TextBoxEmail.Text = (String)ds.Tables[0].Rows[0]["id_client"];
           
           int parrain2 = 0;
           try
           {
               parrain2 = (Int32)ds.Tables[0].Rows[0]["idparrain"];
           }
           catch 
           {
               parrain2 = 0;
           }
           Connexion c1 = new Connexion();
           OdbcCommand selectAllNego = new OdbcCommand("select * from Clients where statut ='ultranego' or statut = 'nego' order by nom_client");
           c1.Open();
           DataRowCollection reader = c1.exeRequetteParametree(selectAllNego).Tables[0].Rows;
           c1.Close();
           int parra =0;
           int cont = 0;
           foreach (DataRow nego in reader)
           {
               ListItem unNegociateur = new ListItem(nego["nom_client"].ToString() + "  " + nego["prenom_client"].ToString(), nego["idclient"].ToString());
               DropDownListParain.Items.Add(unNegociateur);
               if (unNegociateur.Value == parrain2.ToString())
               {
                   parra = cont;
                   //unNegociateur.Selected = true; 
               }
               cont++;
           }
           DropDownListParain.Items[Convert.ToInt32(parra+1)].Selected = true;
            // DropDownListParain.Text = parra;
         
            ///Afficher les données récuperes de la base de donées 
            ///Champ Civilité
           if ((String)ds.Tables[0].Rows[0]["civilite"] == "Mr") 
           {
               RadioButtonMr.Checked = true;
           }
           else if ((String)ds.Tables[0].Rows[0]["civilite"] == "Mlle") 
           {
               RadioButtonMlle.Checked = true;
           }
           else if ((String)ds.Tables[0].Rows[0]["civilite"] == "Mme") 
           {
               RadioButtonMme.Checked = true;
           }

           //Champ NOM 
           try
           {
               textBoxnom.Text = (String)ds.Tables[0].Rows[0]["nom_client"];
           }
           catch
           {
               textBoxnom.Text = "";
           }
            //Champ prénom
           try
           {
               TextBoxPrenom.Text = (String)ds.Tables[0].Rows[0]["prenom_client"];
           }
           catch
           {
               TextBoxPrenom.Text = "";
           }
            //Champ Adresse
           try
           {
               TextBoxAdresse.Text = (String)ds.Tables[0].Rows[0]["adresse_client"];
           }
           catch
           {
               TextBoxAdresse.Text = "";
           }
            //Champ CODE POSTAL
           try
           {
               TextBoxCodePostal.Text = (String)ds.Tables[0].Rows[0]["postal_client"];
           }
           catch
           {
               TextBoxCodePostal.Text = "";
           }
            //Champ VILLE
           try
           {
               TextBoxVille.Text = (String)ds.Tables[0].Rows[0]["ville_client"];
           }
           catch
           {
               TextBoxVille.Text = "";
           }
            //Champ PAYS
           try
           {
               DropDownListPays.Text = (String)ds.Tables[0].Rows[0]["pays_client"];
           }
           catch
           {
               DropDownListPays.Text = "";
           }
            //Champ EMAIL
           try
           {
               TextBoxEmail.Text = (String)ds.Tables[0].Rows[0]["id_client"];
               //on garde l'anccien email
               emailA = (String)ds.Tables[0].Rows[0]["id_client"];
           }
           catch
           {
               TextBoxEmail.Text = "";
           }
            //Champ MOT DE PASSE
           try
           {
               TextBoxPassword.Text = (String)ds.Tables[0].Rows[0]["pass_client"];
           }
           catch
           {
               TextBoxPassword.Text = "";
           }
           //Champ MOT DE PASSE (CONFIRMATION)
           try
           {
               TextBoxPasswordConfirmation.Text = (String)ds.Tables[0].Rows[0]["pass_client"];
           }
           catch
           {
               TextBoxPasswordConfirmation.Text = "";
           }
           //Champ TELEPHONE
           try
           {
               TextBoxTel.Text = (String)ds.Tables[0].Rows[0]["tel_client"];
           }
           catch
           {
               TextBoxTel.Text = "";
           }
           //Champ FAX
           try
           {
               TextBoxFax.Text = (String)ds.Tables[0].Rows[0]["fax_client"];

           }
           catch
           {
               TextBoxFax.Text = "";
           }
           //Champ SOCIETE
           try
           {
               TextBoxSociete.Text = (String)ds.Tables[0].Rows[0]["société_client"];
           }
           catch
           {
               TextBoxSociete.Text = "";
           }

           //Champ STATUS
           try
           {
               string stat = (String)ds.Tables[0].Rows[0]["statut"].ToString().Trim();

               if (stat == "ultranego" || stat == "ultranego ")
               {
                   DropDownListStatut.SelectedIndex = 2;

               }
               else if (stat == "nego")
               {
                   DropDownListStatut.SelectedIndex = 1;

               }
               else if (stat == "")
               {
                   DropDownListStatut.SelectedIndex = 0;

               }
           }
           catch
           {

           }
            //Champ CONTRACTUEL
           if ((bool)ds.Tables[0].Rows[0]["contractuel"] == true)
           {

               CheckBoxContractuel.Checked = true;
           }
            //Champ numero d'agence 
           try
           {
               txtnAgence.Text = (String)ds.Tables[0].Rows[0]["num_agence"];
           }
           catch
           {
               txtnAgence.Text = "";
           }  
           
           // Champ KBIS
           try
           {
               TextBoxKbis.Text = (String)ds.Tables[0].Rows[0]["kbis_client"];
           }
           catch
           {
               TextBoxKbis.Text = "";
           }
            // Champ NBMINSELOGER
           int nbMinSeLoger = 0;
           try
           {
               nbMinSeLoger = (int)ds.Tables[0].Rows[0]["nbminseloger_client"];
               TextBoxNbSeLoger.Text = nbMinSeLoger.ToString();
           }
           catch
           {
               TextBoxNbSeLoger.Text = "";
           }
    }

    //Méthode pour Remplir les données dans la classe MEMBRE
    private void remplir(Membre member)
    {
        String temp = "", temp2 = "";
        // on remplit l'objet member
        member.ID_CLIENTA = idclients;
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
            temp = textBoxnom.ClientID;
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
        //Champ Addresse
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
        //Champ CODE POSTALE
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
            emailN = temp2;
        }
        catch
        {

        }
        //Champ MOT DE PASSE
        try
        {
            temp = TextBoxPasswordConfirmation.ClientID;
            temp = temp.Replace("_", "$");
            temp2 = Page.Request.Form[temp];
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


        //récuperer le donnée de l'agence 
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
        try
        {
            temp = TextBoxKbis.ClientID;
            temp = temp.Replace("_", "$");
            member.KBIS_CLIENT = Page.Request.Form[temp];
        }
        catch
        {
            member.KBIS_CLIENT = "";
        }
        // NBMINSELOGER
        try
        {
            temp = TextBoxNbSeLoger.ClientID;
            temp = temp.Replace("_", "$");
            string nbMin = Page.Request.Form[temp];
            member.NBMINSELOGER_CLIENT = Convert.ToInt32(nbMin);
        }
        catch
        {
            member.NBMINSELOGER_CLIENT = 5;
        }
    }



    //static bool ValidatePassword(string password)
    //{
    //    const int MIN_LENGTH = 7;
    //    const int MAX_LENGTH = 15;

    //    if (password == null) throw new ArgumentNullException();

    //    bool meetsLengthRequirements = password.Length >= MIN_LENGTH && password.Length <= MAX_LENGTH;
    //    bool hasUpperCaseLetter = false;
    //    bool hasLowerCaseLetter = false;
    //    bool hasDecimalDigit = false;

    //    if (meetsLengthRequirements)
    //    {
    //        foreach (char c in password)
    //        {
    //            if (char.IsUpper(c)) hasUpperCaseLetter = true;
    //            else if (char.IsLower(c)) hasLowerCaseLetter = true;
    //            else if (char.IsDigit(c)) hasDecimalDigit = true;
    //        }
    //    }

    //    bool isValid = meetsLengthRequirements
    //                && hasUpperCaseLetter
    //                && hasLowerCaseLetter
    //                && hasDecimalDigit
    //                ;
    //    return isValid;

    //}

    //private Boolean checkField(Membre member)
    //{
    //    #region attributs
    //    // Les différents regex permettant de vérifier si les champs sont corrects
    //    Regex regEmail = new Regex(@"^([\w\-.]+)@([a-zA-Z0-9\-.]+)$");
    //    Regex numReg = new Regex("^[0-9 ]+$");
    //    Regex alphaNumReg = new Regex("^[0-9]+$|^[a-zA-Zéèçàâù ]+$|^()+$");
    //    Regex alphaReg = new Regex("^[a-zA-Zéèçàâù ]+$");


    //    Boolean boolMail = false;
    //    Boolean boolNom = false;
    //    Boolean boolPrenom = false;
    //    Boolean boolPassword2 = false;
    //    Boolean boolVille = false;
    //    Boolean boolPassword = false;

    //    String temp="", temp2="";

    //    #endregion

    //    temp = TextBoxPassword.ClientID;
    //    temp = temp.Replace("_", "$");
    //    temp2 = Page.Request.Form[temp];
    //    boolPassword2 = alphaReg.IsMatch(temp2);

    //    temp = TextBoxEmail.ClientID;
    //    temp = temp.Replace("_", "$");
    //    temp2 = Page.Request.Form[temp];
    //    boolMail = regEmail.IsMatch(temp2);

    //    temp = textBoxnom.ClientID;
    //    temp = temp.Replace("_", "$");
    //    temp2 = Page.Request.Form[temp];
    //    boolNom = alphaReg.IsMatch(temp2);

    //    temp = TextBoxPrenom.ClientID;
    //    temp = temp.Replace("_", "$");
    //    temp2 = Page.Request.Form[temp];
    //    boolPrenom = alphaReg.IsMatch(temp2);

        
    //    temp = TextBoxPassword.ClientID;
    //    temp = temp.Replace("_", "$");
    //    temp2 = Page.Request.Form[temp];
    //    boolPassword = regEmail.IsMatch(temp2);
        
    //    temp = TextBoxVille.ClientID;
    //    temp = temp.Replace("_", "$");
    //    temp2 = Page.Request.Form[temp];
    //    boolVille = alphaReg.IsMatch(temp2);
    //    member.ID_CLIENTA = idclients;

    //    #region try...catch
      
    //    // on remplit l'objet member
    //    try
    //    {
    //        temp = CheckBoxContractuel.ClientID;
    //        temp = temp.Replace("_", "$");
    //        temp2 = Page.Request.Form[temp];
    //        if(temp2=="on")
    //        member.Contractuel = "YES";
    //        else
    //            member.Contractuel = "NO";

    //    }
    //    catch
    //    {
    //        member.Contractuel = "NO";
    //    }

    //    try
    //    {
    //        //if (RadioButtonMr.Checked) member.CIVILITE = "Mr";
    //        //else if (RadioButtonMlle.Checked) member.CIVILITE = "Mlle";
    //        //else if (RadioButtonMme.Checked) member.CIVILITE = "Mme"; 
    //        temp = RadioButtonMr.ClientID;
    //        temp = temp.Replace("_", "$");
    //        temp = temp.Replace("RadioButtonMr", RadioButtonMr.GroupName);
    //        temp2 = Page.Request.Form[temp];
            
    //        if (temp2 == "RadioButtonMr") { member.CIVILITE = "Mr"; }

    //        if (temp2 == "RadioButtonMme") member.CIVILITE = "Mme";
    //        if (temp2 == "RadioButtonMlle") member.CIVILITE = "Mlle";
    //    }
    //    catch
    //    {
    //        member.CIVILITE = "erreur";
    //    }
    //    try
    //    {
    //        temp = TextBoxEmail.ClientID;
    //        temp = temp.Replace("_", "$");
    //        if (boolMail) member.ID_CLIENT = Page.Request.Form[temp] ;//TextBoxEmail.Text.Trim();
           
          
    //    }
    //    catch
    //    {

    //    }
    //    try
    //    {
    //        temp = textBoxnom.ClientID;
    //        temp = temp.Replace("_", "$");
    //        if (boolNom) member.NOM = Page.Request.Form[temp];

            
    //    }
    //    catch
    //    {
    //        member.NOM = "erreur";

    //    }
    //    try
    //    {
    //        temp = TextBoxPrenom.ClientID;
    //        temp = temp.Replace("_", "$");
    //        if (boolPrenom) member.PRENOM = Page.Request.Form[temp];
           
    //    }
    //    catch
    //    {
    //        member.PRENOM = "erreur";
    //    }

    //    //récuperer le donnée de l'agence 
    //    try
    //    {
    //        temp = txtnAgence.ClientID;
    //        temp = temp.Replace("_", "$");
    //        member.NUM_AGENCE= Page.Request.Form[temp];
    //    }
    //    catch 
    //    {
    //        member.NUM_AGENCE = "erreur";
    //    }
    //    try
    //    {
    //        temp = TextBoxAdresse.ClientID;
    //        temp = temp.Replace("_", "$");
    //        member.ADRESSE = Page.Request.Form[temp];
    //    }
    //    catch
    //    {
    //        member.ADRESSE = "NC";
    //    }
    //    try
    //    {
    //        temp = TextBoxCodePostal.ClientID;
    //        temp = temp.Replace("_", "$");
    //        member.CODE_POSTAL = Page.Request.Form[temp];
    //    }
    //    catch
    //    {
    //        member.CODE_POSTAL = "NC";
    //    }
    //    try
    //    {
    //        temp = TextBoxVille.ClientID;
    //        temp = temp.Replace("_", "$");
    //        member.VILLE = Page.Request.Form[temp];
    //    }
    //    catch
    //    {
    //        member.VILLE = "NC";
    //    }
    //    try
    //    {
    //        temp = TextBoxTel.ClientID;
    //        temp = temp.Replace("_", "$");
    //        member.TEL = Page.Request.Form[temp];
    //    }
    //    catch
    //    {
    //        member.TEL = "NC";
    //    }
    //    try
    //    {
    //        temp = TextBoxFax.ClientID;
    //        temp = temp.Replace("_", "$");
    //        member.FAX = Page.Request.Form[temp];
    //    }
    //    catch
    //    {
    //        member.FAX = "NC";
    //    }
    //    try
    //    {
    //        temp = TextBoxSociete.ClientID;
    //        temp = temp.Replace("_", "$");
    //        member.SOCIETE = Page.Request.Form[temp];
    //    }
    //    catch
    //    {
    //        member.SOCIETE = "NC";
    //    }
    //    try
    //    {
    //        temp = TextBoxPassword.ClientID;
    //        temp = temp.Replace("_", "$");

    //        string mail = "", confir = "";
    //        temp = TextBoxPassword.ClientID;
    //        temp = temp.Replace("_", "$");
    //        mail = Page.Request.Form[temp];
    //        temp = TextBoxPasswordConfirmation.ClientID;
    //        temp = temp.Replace("_", "$");
    //        confir = Page.Request.Form[temp];
    //        if (mail == confir)
    //        {
    //            member.PASSWORD = mail;
    //            boolPassword = true;
    //        }
    //    }
    //    catch
    //    {

    //    }
    //    try
    //    {
    //        temp = DropDownListPays.ClientID;
    //        temp = temp.Replace("_", "$");
    //        member.PAYS = Page.Request.Form[temp];
    //    }
    //    catch
    //    {
    //        member.PAYS = "NC";
    //    }

        

    //    try
    //    {
    //        temp = DropDownListStatut.ClientID;
    //        temp = temp.Replace("_", "$");
    //        member.STATUT = Page.Request.Form[temp];
    //    }
    //    catch
    //    {
    //        member.STATUT = "";
    //    }
    //    ///obtenir la valeur du Parrain a modifier
    //    try
    //    {
    //        temp = DropDownListParain.ClientID;

    //        temp = temp.Replace("_", "$");
    //        string nomparrain = "";
    //        string nompa = DropDownListParain.SelectedValue;
    //        //Connexion s1 = new Connexion();
    //        //OdbcCommand selectAllNegoP = new OdbcCommand("select * from Clients where statut ='ultranego' or statut = 'nego' order by nom_client");
    //        //s1.Open();
    //        //DataRowCollection reader = s1.exeRequetteParametree(selectAllNegoP).Tables[0].Rows;
    //        //s1.Close();


    //        //string sql = "SELECT * FROM Clients WHERE where statut ='ultranego' or statut = 'nego' order by nom_client";
    //        //Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    //        //c.Open();
    //        //System.Data.DataSet ds = c.exeRequette(sql);
    //        //c.Close();
    //        nomparrain = Page.Request.Form[temp];
    //        member.IDPARAIN = Convert.ToInt32(nomparrain);
    //    }
    //    catch
    //    {
    //        member.IDPARAIN = 0;
    //    }


    //    #endregion



    //    // Si toutes les vérifs sont ok, la checkfield est ok
    //    if (boolMail && boolNom && boolPrenom && boolPassword && (TextBoxPassword.Text == TextBoxPasswordConfirmation.Text))
    //        return true;

    //    // sinon, on fait des messages d'erreur personalisés
    //    else
    //    {
    //        LabelErrorLogin.Visible = true;
    //        LabelErrorLogin.Text = "Veuillez indiquer : <br />";
    //        if (boolNom == false)
    //        {
    //            LabelErrorLogin.Text += " -> votre nom <br /> ";
    //        }
    //        if (boolPrenom == false)
    //        {
    //            LabelErrorLogin.Text += " -> votre prénom <br /> ";
    //        }
    //        if (boolMail == false)
    //        {
    //            LabelErrorLogin.Text += " -> votre email <br /> ";
    //        }
    //        if (boolPassword == false)
    //        {
    //            LabelErrorLogin.Text += " -> votre mot de passe <br />";
    //        }
    //        if (TextBoxPassword.Text != TextBoxPasswordConfirmation.Text)
    //        {
    //            LabelErrorLogin.Text += " -> le même mot de passe <br />";
    //        }
    //        return false;
    //    }
    //}
    
    //Méthode pour voir si l'adresse mail se trouve déjà utilisé
    private bool verifier() 
    {
        string sql = "SELECT * FROM Clients WHERE id_client='" + emailA + "'";
        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();
        System.Data.DataSet ds = c.exeRequette(sql);
        c.Close();
        string temp3 = "";
        try
        {

            temp3 = (String)ds.Tables[0].Rows[0]["id_client"];

        }
        catch
        {
           
        }
        if (emailA == temp3)
        {
            return true;
        }
        else 
        {
            return false;
        }


    }
    protected void ButtonEnregistrer_Click1(object sender, EventArgs e)
    {
        Membre member = new Membre();
        remplir(member);
  
       // Méthode pour vérifier si l'email est modifie
        if (emailN.Trim() == emailA.Trim())// si est le même courriel l'utilisateur n'a pas changé l'email
        {
            MembreDAO.updateMember(member);
            Response.Redirect("./Recherche_agent.aspx");
        }
        else //si non l'utilisateur a changé l'email il faut vérifier si se trouve déjà utilisé
        {
            String email = member.ID_CLIENT;
            string sql = "SELECT * FROM Clients WHERE id_client='" + email + "'";
            Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c.Open();
            System.Data.DataSet ds = c.exeRequette(sql);
            c.Close();
            string temp3 = "";
            try
            {

                temp3 = (String)ds.Tables[0].Rows[0]["id_client"];

            }
            catch
            {
                MembreDAO.updateMember(member);
                Response.Redirect("./Recherche_agent.aspx");
            }

            if (temp3 == email)
            {
                lblmail.Visible = true;
                lblmail.Text="Email déjà utilisé, veuillez recommencer votre inscription";
            }
        }

        //if (checkField(member))
        //{
        //    try
        //    {
        //        MembreDAO.updateMember(member);

        //        Response.Redirect("./Recherche_agent.aspx");
        //    }
        //    catch
        //    {
        //        LabelErrorLogin.Visible = true;


        //        LabelErrorLogin.Text = "Email déjà utilisé, veuillez recommencer votre inscription";
        //    }


        //}
    }
   

}