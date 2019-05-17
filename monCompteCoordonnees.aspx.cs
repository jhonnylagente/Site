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
using System.Data.Odbc;
using System.Data.OleDb;

public partial class pages_moncomteCoordonnees : System.Web.UI.Page
{
    protected Membre member2=null;
    protected String id_client="";
    protected String _ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if ((Membre)Session["membre"]!=null)
        {
            member2=(Membre)Session["membre"];
            if (CheckPhotoProfil(member2.IDCLIENT)) Show_Photo_Panel.Visible = true;
            else Add_Photo_Panel.Visible = true;
            id_client = member2.ID_CLIENT;
            if (member2.STATUT == "nego" || member2.STATUT == "ultranego") Site_Panel.Visible = true;

            LBLBonjour.Text = "Bonjour <strong>" + member2.CIVILITE + " " + member2.NOM + "</strong> !";
        }

        if (!IsPostBack)
        {
            try
            {
                Membre member = member2;

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
                    TextBoxEmail.Text = member.ID_CLIENT;
                    TextBoxSociete2.Text = member.SOCIETE;
                    DropDownListPays2.Text = member.PAYS;


                    if (member.STATUT == "nego")
                    {
                        TextBoxNom2.ReadOnly = true;
                        TextBoxPrenom2.ReadOnly = true;
                        LBLInfoNego.Text = "<i><font size='2px'>Les negociateurs ne peuvent pas changer leur nom, prenom et email.<br/>Pour plus de details, contactez info@patrimo.net</font></i>";                    
                    }
                    if (member.STATUT != "ultranego") TextBoxEmail.ReadOnly = true;

                    load_Quote();
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
            //member.ADRESSE = "aaa";
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
            member.ID_CLIENT = TextBoxEmail.Text.Trim();
        }
        catch
        {
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
            if (!TextBoxPassword2.Text.Length.Equals(0) || !TextBoxPasswordConfirmation2.Text.Length.Equals(0))
            {
                if (TextBoxCurrentPassword.Text == member.PASSWORD)
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
                else
                {
                    LabelErreur.Text = "Ce n'est pas votre mot de passe actuel !";
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
        member.ID_CLIENTA = member.ID_CLIENT;
        if (checkField(member)!=null)
        {
            
            updateMember(member);
            LabelErreur.Text = "Vos informations ont été modifiées avec succès";
            LabelErreur.Visible = true;
        }

    }


    protected void updateMember(Membre member)
    {

        DataSet ds = null;
        Connexion c = new Connexion(_ConnectionString);
        c.Open();
        ds = c.exeRequette("select * from Clients WHERE id_client ='" + member.ID_CLIENTA + "'");
        c.Close();

        if (((int)ds.Tables[0].Rows.Count) != 1)
        {
            member = new Membre();
        }
        else
        {

            OdbcConnection c3 = new OdbcConnection(_ConnectionString);
            OdbcCommand commande = new OdbcCommand("UPDATE Clients SET civilite= ?,nom_client=?, prenom_client= ?, adresse_client=?, postal_client=?, ville_client=?, tel_client=?, id_client=?, pass_client=?, société_client= ?, pays_client=?  WHERE id_client= ?", c3);
            
                #region parametres odbc
                OdbcParameter param0 = new OdbcParameter("", DbType.String);
                param0.Value = member.CIVILITE;
                commande.Parameters.Add(param0);

                OdbcParameter param1 = new OdbcParameter("", DbType.String);
                param1.Value = member.NOM;
                commande.Parameters.Add(param1);
                OdbcParameter paramIdClient = new OdbcParameter("", DbType.String);
                paramIdClient.Value = member.PRENOM;
                commande.Parameters.Add(paramIdClient);

                OdbcParameter param2 = new OdbcParameter("", DbType.String);
                param2.Value = member.ADRESSE;
                commande.Parameters.Add(param2);
                OdbcParameter param3 = new OdbcParameter("", DbType.String);
                param3.Value = member.CODE_POSTAL;
                commande.Parameters.Add(param3);

                OdbcParameter param4 = new OdbcParameter("", DbType.String);
                param4.Value = member.VILLE;
                commande.Parameters.Add(param4);
                OdbcParameter param5 = new OdbcParameter("", DbType.String);
                param5.Value = member.TEL;
                commande.Parameters.Add(param5);

                OdbcParameter param50 = new OdbcParameter("", DbType.String);
                param50.Value = member.ID_CLIENT;
                commande.Parameters.Add(param50);

                OdbcParameter param6 = new OdbcParameter("", DbType.String);
                param6.Value = member.PASSWORD;
                commande.Parameters.Add(param6);
                OdbcParameter param7 = new OdbcParameter("", DbType.String);
                param7.Value = member.SOCIETE;
                commande.Parameters.Add(param7);

                OdbcParameter param8 = new OdbcParameter("", DbType.String);
                param8.Value = member.PAYS;
                commande.Parameters.Add(param8);


                OdbcParameter param9 = new OdbcParameter("", DbType.String);
                param9.Value = member.ID_CLIENTA;
                commande.Parameters.Add(param9);
                #endregion
                    
                
            c3.Open();
            commande.ExecuteNonQuery();
            c3.Close();

            save_Quote();
        }
    }


    protected bool CheckPhotoProfil(int idclient)
    {

        // Récupère le chemin racine du site
        Connexion cI = new Connexion(_ConnectionString);
        cI.Open();
        System.Data.DataSet dsI = cI.exeRequette("Select * from Environnement");
        cI.Close();
        String racine_site = (String)dsI.Tables[0].Rows[0]["Chemin_racine_site"];

        String Image = racine_site + "img_nego\\" + idclient + "_PHOTO.jpg";

        // On regarde si l'image en question existe
        if (System.IO.File.Exists(Image) == true)
            return true;

        else
            return false;
    }

    protected Boolean FileUpload(object sender, EventArgs e)
    {
        Boolean boolFileUpload1 = true;


        // Récupère le chemin racine du site
        Connexion c = new Connexion(_ConnectionString);
        c.Open();
        System.Data.DataSet ds2 = c.exeRequette("Select * from Environnement");
        c.Close();

        String racine_site = (String)ds2.Tables[0].Rows[0]["Chemin_racine_site"];

        Membre member = (Membre)Session["Membre"];

        // chargement de photo

        if (FileUpload1.HasFile)
        {
            string fileExt1 = System.IO.Path.GetExtension(FileUpload1.FileName);
            if (fileExt1 == ".jpg" || fileExt1 == ".jpeg" || fileExt1 == ".JPG" || fileExt1 == ".JPEG")
            {
                try { FileUpload1.SaveAs(racine_site + "img_nego\\" + member.IDCLIENT + "_PHOTO" + fileExt1); }
                catch (Exception ex) { Label1.Text = "ERROR: " + ex.Message.ToString(); }
            }
            else
            {
                Label1.Text = "Only .jpg files allowed!";
                boolFileUpload1 = false;
            }
        }

        if (boolFileUpload1)
            return true;
        else
            return false;
    }

    protected void SupprimerProfilPicture(object sender, EventArgs e)
    {
        // Récupère le chemin racine du site
        Connexion cI = new Connexion(_ConnectionString);
        cI.Open();
        System.Data.DataSet dsI = cI.exeRequette("Select * from Environnement");
        cI.Close();

        String racine_site = (String)dsI.Tables[0].Rows[0]["Chemin_racine_site"];

        Membre member = (Membre)Session["Membre"];

        String Image = racine_site + "img_nego\\" + member.IDCLIENT + "_PHOTO.jpg";

        // On supprime
        if (System.IO.File.Exists(Image))
            System.IO.File.Delete(Image);

        Response.Redirect("monCompteCoordonnees.aspx");

    }

    protected void ButtonAddProfilPicture(object sender, EventArgs e)
    {
        //Ca a l'air con comme ça de forcer la redirection mais ça evite la postback, avec lequel on aurais un bug
        //Par contre ca fait qu'on perd ce qui a été modifié ailleurs
        if (FileUpload(sender, e)) Response.Redirect("monCompteCoordonnees.aspx");
    }


    protected void voir_Site(object sender, EventArgs e)
    {
        Response.Redirect("./agent.aspx?id_client="+id_client);
    }

    protected void load_Quote()
    {
        OdbcConnection c3 = new OdbcConnection(_ConnectionString);
        OdbcDataReader reader;
        OdbcCommand commande = new OdbcCommand("SELECT * FROM Clients WHERE id_client = ? AND (statut = 'nego' OR statut = 'ultranego') ", c3);
        OdbcParameter paramID = new OdbcParameter("", DbType.String);
        paramID.Value = id_client;
        commande.Parameters.Add(paramID);
        c3.Open();
        reader = commande.ExecuteReader();
        if (reader.HasRows)
        {
            reader.Read();
            if (reader["quote"] != null)
            {
                if (reader["quote"].ToString() == "")
                {
                    TBQuote.Text = "\r\n \r\n L'immobilier est un vrai métier qui requiert connaissance du marché, savoir-faire commercial et rigueur professionnelle. La promotion et la vente de votre bien sont l'affaire d'un professionnel."
                                   + "\r\n \r\n Je suis votre interlocuteur PRIVILÉGIÉ et à votre écoute pour vous guider dans vos démarches avec sérieux, vous accompagner dans toutes les étapes de votre projet, trouver des solutions adaptées à vos besoins, assurer le suivi du processus jusqu’à la signature en toute sécurité devant notaire, réaliser vos rêves avec le sourire."
                                   //+ "\r\n \r\n Je mettrai en oeuvre pour la réussite et la concrétisation de votre projet:  Réactivité, Rigueur, Anticipation, Sincérité et Disponibilité ."
                                   + "\r\n \r\n Je suis à votre disposition pour un entretien, un renseignement ou tout simplement une question."; 
                }
                else
                {
                    TBQuote.Text = reader["quote"].ToString() + reader["quote2"].ToString() + reader["quote3"].ToString();                    
                }
            }
            reader.Close();
        }
        c3.Close();

    }
    
    protected void save_Quote()
    {
        String[] quotes = { "", "", "" };
        String Quote = TBQuote.Text;
        int quote_length=TBQuote.Text.Length;

        if (quote_length <= 250) quotes[0] = Quote;
        else
        {
            quotes[0] = Quote.Substring(0, 250);
            if (quote_length <= 500) quotes[1] = Quote.Substring(250, quote_length - 250);
            else
            {
                quotes[1] = Quote.Substring(250, 250);
                if (quote_length <= 750) quotes[2] = Quote.Substring(500, quote_length - 500);
                else quotes[2] = Quote.Substring(500, 250);
            }
        }
        

        OdbcConnection c3 = new OdbcConnection(_ConnectionString);
        OdbcCommand commande = new OdbcCommand("UPDATE Clients SET quote= ?,quote2= ?, quote3 = ?  WHERE id_client= ?", c3);
        OdbcParameter paramQuote = new OdbcParameter("", DbType.String);
        paramQuote.Value = quotes[0];
        commande.Parameters.Add(paramQuote);
        OdbcParameter paramQuote2 = new OdbcParameter("", DbType.String);
        paramQuote2.Value = quotes[1];
        commande.Parameters.Add(paramQuote2);
        OdbcParameter paramQuote3 = new OdbcParameter("", DbType.String);
        paramQuote3.Value = quotes[2];
        commande.Parameters.Add(paramQuote3);
        OdbcParameter paramIDClient = new OdbcParameter("", DbType.String);
        paramIDClient.Value = id_client;
        commande.Parameters.Add(paramIDClient);
        c3.Open();
        commande.ExecuteNonQuery();
        c3.Close();
    }



}
