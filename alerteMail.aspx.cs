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

public partial class pages_alerteMail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Page.Master.FindControl("titrebandeau")).Text = "Mes alertes";

        String reference = "";

        if (Session["logged"].Equals(true))
        {
            if (IsPostBack == false)
            {
                #region recuperation de l'alerte

                ///si il s'agit d'une update d'alerte email on la recupère grâce à l'id passé en GET et on la décode
                ///sinon il s'agit d'une creation... alors l'execution va sortir du bloc try sur une Null exception.

                try
                {
                    reference = Request.Params["ref"].ToString();

                    String decode1 = (String)Session["double1"];
                    String decode2 = (String)Session["double2"];


                    reference = reference.Replace(decode1, "");
                    reference = reference.Replace(decode2, "");

                    int id = int.Parse(reference);

                    Session["alerte"] = AlerteMailDAO.getAlerteMail(id);


                    RequeteBien alerte = AlerteMailDAO.getAlerteMail(id);

                    Session["alerteMail"] = alerte;

                    if (alerte.TYPEVENTE == "V") radioButtonAchat.Checked = true;
                    else radioButtonAchat.Checked = false;

                    if (alerte.TYPEBIEN.Contains("M")) checkBoxMaison.Checked = true;
                    else checkBoxMaison.Checked = false;

                    if (alerte.TYPEBIEN.Contains("A")) checkBoxAppart.Checked = true;
                    else checkBoxAppart.Checked = false;

                    if (alerte.TYPEBIEN.Contains("T")) checkBoxTerrain.Checked = true;
                    else checkBoxTerrain.Checked = false;

                    if (alerte.TYPEBIEN.Contains("X")) checkBoxAutre.Checked = true;
                    else checkBoxAutre.Checked = false;

                    if (alerte.PIECE1.Equals(true)) checkBoxPiece1.Checked = true;
                    else checkBoxPiece1.Checked = false;

                    if (alerte.PIECE2.Equals(true)) checkBoxPiece2.Checked = true;
                    else checkBoxPiece2.Checked = false;

                    if (alerte.PIECE3.Equals(true)) checkBoxPiece3.Checked = true;
                    else checkBoxPiece3.Checked = false;

                    if (alerte.PIECE4.Equals(true)) checkBoxPiece4.Checked = true;
                    else checkBoxPiece4.Checked = false;

                    if (alerte.PIECE5.Equals(true)) checkBoxPiece5.Checked = true;
                    else checkBoxPiece5.Checked = false;

                    if (alerte.MOTCLE1.Length.Equals(0) == false)
                    {
                        textBoxMotCle1.Text = alerte.MOTCLE1;
                    }

                    if (alerte.MOTCLE2.Length.Equals(0) == false)
                    {
                        textBoxMotCle2.Text = alerte.MOTCLE2;
                    }

                    if (alerte.MOTCLE3.Length.Equals(0) == false)
                    {
                        textBoxMotCle3.Text = alerte.MOTCLE3;
                    }

                    if (alerte.MOTCLE4.Length.Equals(0) == false)
                    {
                        textBoxMotCle4.Text = alerte.MOTCLE4;
                    }

                    if (alerte.PRIXMIN.Equals(0) == false)
                    {
                        TextBoxBudgetMin.Text = alerte.PRIXMIN.ToString();
                    }

                    if (alerte.PRIXMAX.Equals(1000000000) == false)
                    {
                        TextBoxBudgetMax.Text = alerte.PRIXMAX.ToString();
                    }

                    if (alerte.SURFACEMIN.Equals(0) == false)
                    {
                        textBoxSurfaceMin.Text = alerte.SURFACEMIN.ToString();
                    }

                    if (alerte.SURFACEMAX.Equals(0) == false)
                    {
                        textBoxSurfaceMax.Text = alerte.SURFACEMAX.ToString();
                    }



            }
            catch
            {

            }
                #endregion

                // efface le label
                Label1.Text = "";
            }
        }
        else Response.Redirect("./inscriptionAccueil.aspx");
    }

    private RequeteBien verifChampSaisi(RequeteBien maRecher)
    {

        #region attribut
        Regex numReg = new Regex("^[0-9 ]+$");
        Regex alphaNumReg = new Regex("^[0-9]+$|^[a-zA-Zéèçàâù ]+$|^()+$");


        /// 3 bool permettant d'identifier si la recherche se fait par code postaux , departement ou nom de la ville
        bool ville1CodePostal = new Boolean();
        bool ville1Dep = new Boolean();
        bool ville1Nom = new Boolean();

        //bool ville2CodePostal = new Boolean();
        //bool ville2Dep = new Boolean();
        //bool ville2Nom = new Boolean();

        //bool ville3CodePostal = new Boolean();
        //bool ville3Dep = new Boolean();
        //bool ville3Nom = new Boolean();

        //bool ville4CodePostal = new Boolean();
        //bool ville4Dep = new Boolean();
        //bool ville4Nom = new Boolean();

        bool regSurfaceMin = false;
        bool regSurfaceMax = false;
        bool regBudgetMin = false;
        bool regBudgetMax = false;


        ville1CodePostal = false;
        ville1Dep = false;
        ville1Nom = false;

        //ville2CodePostal = false;
        //ville2Dep = false;
        //ville2Nom = false;

        //ville3CodePostal = false;
        //ville3Dep = false;
        //ville3Nom = false;

        //ville4CodePostal = false;
        //ville4Dep = false;
        //ville4Nom = false;


        /// Contenu des textBox des ville apres un trim
        //String ville2 = textBoxVille2.Text.Trim();
        //String ville3 = textBoxVille3.Text.Trim();
        //String ville4 = textBoxVille4.Text.Trim();


        String smin = "erreur de saisie pour la surface minimal";
        String smax = "\n erreur de saisie pour la surface maximal";
        String bmin = "\n erreur de saisie pour la budget minimal";
        String bmax = "\n erreur de saisie pour la budget maximal";
        String ville_1 = "\n erreur de saisie pour la ville";



        #endregion


        #region Série de test sur les textBoxs des ville pour savoir si la recherche est Code postal, departement ou nom de ville



        ///Verif si la demande sur textBoxVille1 est code postal , departement ou nom

        ///Verif si la demande sur textBoxVille2 est code postal , departement ou nom

        //ville2Nom = alphaNumReg.IsMatch(ville2);
        //if (ville2Nom) maRecher.VILLE2_CODE_DEP = "nom";

        //if (ville2.Length == 2)
        //{
        //    ville2Dep = numReg.IsMatch(ville2);
        //    if (ville2Dep) maRecher.VILLE2_CODE_DEP = "departement";
        //}
        //else if (ville2.Length == 5)
        //{
        //    ville2CodePostal = alphaNumReg.IsMatch(ville2);
        //    if (ville2CodePostal) maRecher.VILLE2_CODE_DEP = "code postal";
        //}




        ///Verif si la demande sur textBoxVille3 est code postal , departement ou nom

        //ville3Nom = alphaNumReg.IsMatch(ville3);
        //if (ville3Nom) maRecher.VILLE3_CODE_DEP = "nom";

        //if (ville3.Length == 2)
        //{
        //    ville3Dep = numReg.IsMatch(ville3);
        //    if (ville3Dep) maRecher.VILLE3_CODE_DEP = "departement";
        //}
        //else if (ville3.Length == 5)
        //{
        //    ville3CodePostal = alphaNumReg.IsMatch(ville3);
        //    if (ville3CodePostal) maRecher.VILLE3_CODE_DEP = "code postal";
        //}





        ///Verif si la demande sur textBoxVille4 est code postal , departement ou nom

        //ville4Nom = alphaNumReg.IsMatch(ville4);
        //if (ville4Nom) maRecher.VILLE4_CODE_DEP = "nom";

        //if (ville4.Length == 2)
        //{
        //    ville4Dep = numReg.IsMatch(ville4);
        //    if (ville4Dep) maRecher.VILLE4_CODE_DEP = "departement";
        //}
        //else if (ville4.Length == 5)
        //{
        //    ville4CodePostal = alphaNumReg.IsMatch(ville4);
        //    if (ville4CodePostal) maRecher.VILLE4_CODE_DEP = "code postal";
        //}

        #endregion

        
        TextBoxBudgetMin.Text = TextBoxBudgetMin.Text.Replace(" ", "");
        TextBoxBudgetMax.Text = TextBoxBudgetMax.Text.Replace(" ", "");

        try
        {
            maRecher.PRIXMIN = long.Parse(TextBoxBudgetMin.Text.Trim());
        }
        catch
        {

        }
        try
        {
            maRecher.PRIXMAX = long.Parse(TextBoxBudgetMax.Text.Trim());
        }
        catch
        {

        }
        try
        {
            maRecher.SURFACEMAX = long.Parse(textBoxSurfaceMax.Text.Trim());
        }
        catch
        {

        }
        try
        {
            maRecher.SURFACEMIN = long.Parse(textBoxSurfaceMin.Text.Trim());
        }
        catch
        {

        }

        //test le contenu des box par expression reguliere si OK alors true
        if (textBoxSurfaceMin.Text.Trim() != "")
        {
            regSurfaceMin = numReg.IsMatch(textBoxSurfaceMin.Text.Trim());
        }
        else regSurfaceMin = true; // si la text box est vide on effectue qd meme la recherche

        if (textBoxSurfaceMax.Text.Trim() != "")
        {
            regSurfaceMax = numReg.IsMatch(textBoxSurfaceMax.Text.Trim());
        }
        else
        {
            regSurfaceMax = true; // si la text box est vide on effectue qd meme la recherche
        }

        if (TextBoxBudgetMin.Text.Trim() != "")
        {
            regBudgetMin = numReg.IsMatch(TextBoxBudgetMin.Text.Trim());
        }
        else regBudgetMin = true; // si la text box est vide on effectue qd meme la recherche

        if (TextBoxBudgetMax.Text.Trim() != "")
        {
            regBudgetMax = numReg.IsMatch(TextBoxBudgetMax.Text.Trim());
        }
        else regBudgetMax = true; // si la text box est vide on effectue qd meme la recherche



        /// affichage des erreurs de saisie dans le label 1
        Label1.Text = "";
        if (regSurfaceMin == false || regSurfaceMax == false || regBudgetMin == false || regBudgetMax == false)
        {
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "erreur de saisie, veuillez resaisir les critères de votre recherche";
        }
        
        if (maRecher.PRIXMAX < maRecher.PRIXMIN)
        {
            regSurfaceMin = false;
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "erreur de saisie, veuillez resaisir les critères de votre recherche";
        }

        if (maRecher.SURFACEMAX < maRecher.SURFACEMIN)
        {
            regSurfaceMin = false;
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "erreur de saisie, veuillez resaisir les critères de votre recherche";
        }

        if (regSurfaceMin == true && regSurfaceMax == true && (maRecher.VILLE1_REG == false) && regBudgetMin == true && regBudgetMax == true)
            maRecher.RECHERCHE_OK = true;

        ///Si tout est OK alors maRecherche.RECHERCHE_OK =true -----> permet d'executer la requete
        else if (regSurfaceMin == true && regSurfaceMax == true && (maRecher.VILLE1_REG == true) && regBudgetMin == true && regBudgetMax == true)
            maRecher.RECHERCHE_OK = true;
        else maRecher.RECHERCHE_OK = false;

        return maRecher;
    }


    protected void ButtonAlerteMail_Click(object sender, EventArgs e)
    {
        RequeteBien alerte = null;

        if (Session["logged"].Equals(true))
        {
            try
            {
                //// recupère l'alerte mail dans la session
                //// si ça plante c'est qu'il n'y a pas d'alerte mail dans la session alors 
                //// on créer une instance dans le bloque catch
                alerte = (RequeteBien)Session["alerte"];
            }
            catch
            {
                alerte = new RequeteBien();
            }

            Membre member = (Membre)Session["membre"];


            if (TextBoxBudgetMin.Text == "") alerte.PRIXMIN = 0;
            if (TextBoxBudgetMax.Text == "") alerte.PRIXMAX = 1000000000;
            if (textBoxSurfaceMin.Text == "") alerte.SURFACEMIN = 0;
            if (textBoxSurfaceMax.Text == "") alerte.SURFACEMAX = 9999999;

            if (verifChampSaisi(alerte).RECHERCHE_OK == true)
            {

                if (TextBoxBudgetMin.Text != "") alerte.PRIXMIN = Int64.Parse(TextBoxBudgetMin.Text.Trim());
                if (TextBoxBudgetMax.Text != "") alerte.PRIXMAX = Int64.Parse(TextBoxBudgetMax.Text.Trim());
                if (textBoxSurfaceMin.Text != "") alerte.SURFACEMIN = Int64.Parse(textBoxSurfaceMin.Text.Trim());
                if (textBoxSurfaceMax.Text != "") alerte.SURFACEMAX = Int64.Parse(textBoxSurfaceMax.Text.Trim());

                alerte.MOTCLE1 = textBoxMotCle1.Text.Trim();
                alerte.MOTCLE2 = textBoxMotCle2.Text.Trim();
                alerte.MOTCLE3 = textBoxMotCle3.Text.Trim();
                alerte.MOTCLE4 = textBoxMotCle4.Text.Trim();

                alerte.PIECE1 = checkBoxPiece1.Checked;
                alerte.PIECE2 = checkBoxPiece2.Checked;
                alerte.PIECE3 = checkBoxPiece3.Checked;
                alerte.PIECE4 = checkBoxPiece4.Checked;
                alerte.PIECE5 = checkBoxPiece5.Checked;



                if (checkBoxAppart.Checked == false && checkBoxTerrain.Checked == false && checkBoxMaison.Checked == false && checkBoxAutre.Checked == false)
                {
                    alerte.TYPEBIEN = "AMTX";
                }
                else
                {
                    alerte.TYPEBIEN = "";// permet de réinitialisé le champ
                    if (checkBoxAppart.Checked) alerte.TYPEBIEN += "A";
                    if (checkBoxMaison.Checked) alerte.TYPEBIEN += "M";
                    if (checkBoxTerrain.Checked) alerte.TYPEBIEN += "T";
                    if (checkBoxAutre.Checked) alerte.TYPEBIEN += "X";
                }
                

                alerte.Cible = ucCible.listeVilleRecherche.createString();

                if (radioButtonAchat.Checked) alerte.TYPEVENTE = "V";
                else if (radioButtonLocation.Checked) alerte.TYPEVENTE = "L";

                if (ListeNeuf.SelectedItem.Value == "0")
                {
                    alerte.NeufOuPas = false;
                    alerte.NEUF = false;
                }
                else if (ListeNeuf.SelectedItem.Value == "1")
                {
                    alerte.NeufOuPas = false;
                    alerte.NEUF = true;
                }
                else
                {
                    alerte.NeufOuPas = true;
                }
                alerte.PRESTIGE = CBPrestige.Checked;
                alerte.COUP_DE_COEUR = CBCoeur.Checked;
                //sauvegarde l'objet alerte dans la session
                
                if (checkBoxMaison.Checked == true) Session["Type"] += " maison";
                if (checkBoxAppart.Checked == true) Session["Type"] += " appartement";
                if (checkBoxTerrain.Checked == true) Session["Type"] += " terrain";
                if (radioButtonAchat.Checked == true) Session["Transaction"] = "achat";
                else Session["Transaction"] = "location";

                Session["Smin"] = textBoxSurfaceMin.Text;
                Session["Smax"] = textBoxSurfaceMax.Text;

                Session["BudgetMin"] = TextBoxBudgetMin.Text;
                Session["BudgetMax"] = TextBoxBudgetMax.Text;

                Session["NumPage"] = 1;
                Session["Tri"] = "prix";

                Session["radioButtonAchat"] = radioButtonAchat.Checked;

                Session["checkBoxPiece1"] = checkBoxPiece1.Checked;
                Session["checkBoxPiece2"] = checkBoxPiece2.Checked;
                Session["checkBoxPiece3"] = checkBoxPiece3.Checked;
                Session["checkBoxPiece4"] = checkBoxPiece4.Checked;
                Session["checkBoxPiece5"] = checkBoxPiece5.Checked;


                Session["checkBoxMaison"] = checkBoxMaison.Checked;
                Session["checkBoxAppart"] = checkBoxAppart.Checked;
                Session["checkBoxTerrain"] = checkBoxTerrain.Checked;
                Session["checkBoxAutre"] = checkBoxAutre.Checked;



                alerte.ID_CLIENT = member.ID_CLIENT;



                if (alerte.ID_ALERTE.Equals(0))
                {
                    AlerteMailDAO.addAlerteMail(alerte);
                }
                else AlerteMailDAO.updateAlerteMail(alerte);

                Session["alerte"] = alerte;

                Response.Redirect("./monCompteAlertes.aspx");
            }//Fin de if
        }
        else Response.Redirect("./inscriptionAccueil.aspx"); // l'utilisateur n'est pas loggué on le redirige vers la page de login/inscription
    }
    protected void ButtonAnnuler_Click(object sender, EventArgs e)
    {
        checkBoxMaison.Checked = true;
        checkBoxAppart.Checked = true;
        checkBoxTerrain.Checked = false;
        checkBoxAutre.Checked = false;
        checkBoxPiece1.Checked = true;
        checkBoxPiece2.Checked = true;
        checkBoxPiece3.Checked = true;
        checkBoxPiece4.Checked = true;
        checkBoxPiece5.Checked = true;
        radioButtonLocation.Checked = false;
        radioButtonAchat.Checked = true;
        textBoxMotCle1.Text = "";
        textBoxMotCle2.Text = "";
        textBoxMotCle3.Text = "";
        textBoxMotCle4.Text = "";
        textBoxSurfaceMax.Text = "";
        textBoxSurfaceMin.Text = "";
        //textBoxVille2.Text = "";
        //textBoxVille3.Text = "";
        //textBoxVille4.Text = "";
        TextBoxBudgetMax.Text = "";
        TextBoxBudgetMin.Text = "";
        ucCible.clear();
    }
}
