using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class pages_monCompte : System.Web.UI.Page
{
    string _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    System.Windows.Forms.ComboBox ComboBox2 = new System.Windows.Forms.ComboBox();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Membre member = (Membre)Session["Membre"];
        if (member == null || (member.STATUT != "nego" && member.STATUT != "ultranego"))
        {
            Response.Close();
        }

        String NomNego = member.PRENOM + " " + member.NOM;

        // Varible para guardar el del droplist el texto y la variable Session["DropDownListChoixNegociateurText"] 
        //y la variable para guardar el valor del dropbox  Session["DropDownListChoixNegociateurValue"] 

        ((Label)Page.Master.FindControl("titrebandeau")).Text = "Mon compte";
        LabelbnBiens.Text = "0";

        
        

        if (!IsPostBack)
        {
            
            //cuando se recarga la pagina lo que hace es tomar los valores de las variables de sesion para asignarles a los datos
            tbNomVendeur.Text = (String)Session["NomVendeur"];
            tbReferance.Text = (String)Session["lareferance"];
            TextBoxAdresseVendeur.Text = (String)Session["TextBoxAdresseVendeur"];
            TextBoxTelVendeur.Text = (String)Session["TextBoxTelVendeur"];
            textBoxSurfaceMin.Text = (String)Session["Smin"];
            textBoxSurfaceMax.Text = (String)Session["Smax"];
            textBoxVille1.Text = (String)Session["Localisation"];
            textBoxVille.Text = (String)Session["VilleRechercheAcq"];

            textBoxPays.Text = (String)Session["PaysRechercheAcq"];
            textBoxDep.Text = (String)Session["DepRechercheAcq"];
            textBoxAdresseBien.Text = (String)Session["textBoxAdresseBien"];
            textBoxMotCle1.Text = (String)Session["textBoxMotCle1"];
            textBoxMotCle2.Text = (String)Session["textBoxMotCle2"];
            textBoxMotCle3.Text = (String)Session["textBoxMotCle3"];
            textBoxMotCle4.Text = (String)Session["textBoxMotCle4"];
            TextBoxMailVendeur.Text = (String)Session["TextBoxMailVendeur"];
            TextBoxBudgetMin.Text = (String)Session["TextBoxBudgetMin"];
            TextBoxBudgetMax.Text = (String)Session["TextBoxBudgetMax"];
            textBoxSurfaceMin.Text = (String)Session["textBoxSurfaceMin"];
            textBoxSurfaceMax.Text = (String)Session["textBoxSurfaceMax"];


            //ButtonAchat.Click += new EventHandler(this.button_check);
            radioButtonAchat.Checked = (bool)Session["radioButtonAchat"];
            radioButtonLocation.Checked = (bool)Session["radioButtonLocation"];
            checkBoxPiece1.Checked = (bool)Session["checkBoxPiece1"];
            checkBoxPiece2.Checked = (bool)Session["checkBoxPiece2"];
            checkBoxPiece3.Checked = (bool)Session["checkBoxPiece3"];
            checkBoxPiece4.Checked = (bool)Session["checkBoxPiece4"];
            checkBoxPiece5.Checked = (bool)Session["checkBoxPiece5"];
            checkBoxChambre1.Checked = (bool)Session["checkBoxChambre1"];
            checkBoxChambre2.Checked = (bool)Session["checkBoxChambre2"];
            checkBoxChambre3.Checked = (bool)Session["checkBoxChambre3"];
            checkBoxChambre4.Checked = (bool)Session["checkBoxChambre4"];
            checkBoxChambre5.Checked = (bool)Session["checkBoxChambre5"];
            checkBoxEstimation.Checked = (bool)Session["checkBoxEstimation"];
            checkBoxDisponible.Checked = (bool)Session["checkBoxDisponible"];
            checkBoxOffre.Checked = (bool)Session["checkBoxOffre"];
            checkBoxSuspendu.Checked = (bool)Session["checkBoxSuspendu"];
            checkBoxRetire.Checked = (bool)Session["checkBoxRetire"];
            checkBoxCompromis.Checked = (bool)Session["checkBoxCompromis"];
            checkBoxLibre.Checked = (bool)Session["checkBoxLibre"];
            checkBoxOccupe.Checked = (bool)Session["checkBoxOccupe"];
            checkBoxLoue.Checked = (bool)Session["checkBoxLoue"];
            checkBoxOption.Checked = (bool)Session["checkBoxOption"];
            checkBoxReserve.Checked = (bool)Session["checkBoxReserve"];
            checkBoxRet.Checked = (bool)Session["checkBoxRet"];
            checkBoxSusp.Checked = (bool)Session["checkBoxSusp"];

            checkBoxMaison.Checked = (bool)Session["checkBoxMaison"];
            checkBoxAppart.Checked = (bool)Session["checkBoxAppart"];
            checkBoxTerrain.Checked = (bool)Session["checkBoxTerrain"];
            checkBoxAutre.Checked = (bool)Session["checkBoxAutre"];

            TextBoxSurfaceSMin.Text = (String)Session["TextBoxSurfaceSMin"];
            TextBoxSurfaceSMax.Text = (String)Session["TextBoxSurfaceSMax"];
            textBoxSurfaceTMin.Text = (String)Session["textBoxSurfaceTMin"];
            textBoxSurfaceTMax.Text = (String)Session["textBoxSurfaceTMax"];


            RadioButtonMesBiens.Checked = (bool)Session["LastradioButtonMesBiens"];
            RadioButtonMesBiens.Checked = (bool)Session["radioButtonMesBiens"];
            RadioButtonMonAgence.Checked = (bool)Session["radioButtonMonAgence"];
            RadioButtonTousLesBiens.Checked = (bool)Session["radioButtonTousLesBiens"];

            chckBxCdC.Checked = (bool)Session["chckBxCdC"];
            chckBxPrestige.Checked = (bool)Session["chckBxPrestige"];
            chckBxMer.Checked = (bool)Session["chckBxMer"];
            chckBxMontagne.Checked = (bool)Session["chckBxMontagne"];


            if (Session["ListeNeuf"] != null) ListeNeuf.SelectedIndex = (int)Session["ListeNeuf"];

            #region
            //var tempDate = (String)Session["textBoxDateCreationMin"];
            //var tempDateParts = tempDate.Split('/');
            //tempDate = string.Format("{0}-{1}-{2}", tempDateParts[2], tempDateParts[1], tempDateParts[0]);
            //textBoxDateCreationMin.Text = tempDate;
            textBoxDateCreationMin.Text = (String)Session["textBoxDateCreationMin"];
            //var tempDate = (String)Session["textBoxDateCreationMax"];
            //var tempDateParts = tempDate.Split('/');
            //tempDate = string.Format("{0}-{1}-{2}", tempDateParts[2], tempDateParts[1], tempDateParts[0]);
            //textBoxDateCreationMax.Text = tempDate;
            textBoxDateCreationMax.Text = (String)Session["textBoxDateCreationMax"];

            //tempDate = (String)Session["textBoxDateMajMin"];
            //tempDateParts = tempDate.Split('/');
            //tempDate = string.Format("{0}-{1}-{2}", tempDateParts[2], tempDateParts[1], tempDateParts[0]);
            //textBoxDateMajMin.Text = tempDate;
            textBoxDateMajMin.Text = (String)Session["textBoxDateMajMin"];
            //tempDate = (String)Session["textBoxDateMajMax"];
            //tempDateParts = tempDate.Split('/');
            //tempDate = string.Format("{0}-{1}-{2}", tempDateParts[2], tempDateParts[1], tempDateParts[0]);
            //textBoxDateMajMax.Text =tempDate;
            textBoxDateMajMax.Text = (String)Session["textBoxDateMajMax"];
            // La variable de sesion de la dropdownlist negociateur ne marche pas.
            DropDownListPageSize.SelectedValue = Session["annoncesPage"].ToString();
            DropDownListTypeMandat.SelectedValue = (String)Session["DropDownListTypeMandat"];

            //y la variable Session["DropDownListChoixNegociateurText"] 
            // DropDownListNegociateur.SelectedValue = (String)Session["DropDownListChoixNegociateurText"];
            //DropDownListNegociateur.SelectedValue = (String)Session["DropDownListChoixNegociateur"];

            //cada vez que se recarga la pagina se queda con el valor del idcliente seleccionado cuando debe de guardar solo el nombre 


            //DropDownListPageSize.SelectedValue = Session["annoncesPageT"].ToString();
            GridView1.PageSize = int.Parse(DropDownListPageSize.SelectedValue);
            //String requette = "SELECT Biens.negociateur FROM Biens GROUP BY Biens.negociateur, Biens.[actif] HAVING (((Biens.[actif])='actif')) ORDER BY Biens.negociateur";
            //System.Data.DataSet ds = null;
            //Connexion c = null;

            //c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //c.Open();
            //ds = c.exeRequette(requette);
            //c.Close();
            //c = null;

            //System.Data.DataRowCollection dr = ds.Tables[0].Rows;
            //foreach (System.Data.DataRow ligne in dr)
            //{
            //    if (ligne["negociateur"].ToString() != "null")
            //    {
            //        DropDownListNegociateur.Items.Add(new ListItem(ligne["negociateur"].ToString(), ligne["negociateur"].ToString()));
            //    }
            //}
            // Membre member = (Membre)Session["Membre"];

            //l--------------------------------------------------------------------------------------------------------

            member = (Membre)Session["Membre"];

            //if (Session["logged"].Equals(true))
            //   {

            //     Response.Redirect("./moncompte.aspx");
            //}

            //----------------------------------------------------------------------------------------------------------
            #endregion

            if (RadioButtonMesBiens.Checked && (member.STATUT == "ultranego" || member.STATUT == "nego"))
            {
                Session["NumAgence"] = member.NUM_AGENCE;
                DropDownListNegociateur.Items.Clear();
                DropDownListNegociateur.SelectedValue = member.NOM.ToUpper() + " " + member.PRENOM;
                DropDownListNegociateur.Items.Add(new ListItem(member.NOM.ToUpper() + " " + member.PRENOM));
            }
            else if (RadioButtonMonAgence.Checked && (member.STATUT == "ultranego" || member.STATUT == "nego"))
            {
                Session["NumAgence"] = member.NUM_AGENCE;
                String requette = "SELECT DISTINCT Clients.id_client, Clients.nom_client, Clients.prenom_client, Clients.num_agence FROM Biens LEFT JOIN Clients ON Biens.idclient = Clients.idclient GROUP BY Clients.id_client, Clients.nom_client, Clients.prenom_client, Clients.num_agence HAVING (((Clients.num_agence)='" + member.NUM_AGENCE + "'))ORDER BY Clients.nom_client";
                System.Data.DataSet ds = null;
                Connexion c = null;
                DropDownListNegociateur.Items.Clear();

                DropDownListNegociateur.Items.Add(new ListItem(Session["DropDownListChoixNegociateur"].ToString()));
                c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                c.Open();
                ds = c.exeRequette(requette);
                c.Close();
                c = null;
                System.Data.DataRowCollection dr = ds.Tables[0].Rows;

                if (Session["DropDownListChoixNegociateur"].ToString() != "Tous")
                {
                    DropDownListNegociateur.Items.Add(new ListItem("Tous"));
                }

                foreach (System.Data.DataRow ligne in dr)
                {
                    if (ligne["nom_client"].ToString().ToUpper() + " " + ligne["prenom_client"].ToString() != DropDownListNegociateur.SelectedValue.ToString())
                    {
                        if (ligne["nom_client"].ToString() != "null"
                            || ligne["prenom_client"].ToString() != "null")
                        {
                            DropDownListNegociateur.Items.Add(new ListItem(ligne["nom_client"].ToString().ToUpper() + " " + ligne["prenom_client"].ToString()));
                        }
                    }
                }
            }
            else if (RadioButtonTousLesBiens.Checked && (member.STATUT == "ultranego" || member.STATUT == "nego"))
            {
                Session["NumAgence"] = member.NUM_AGENCE;
                String requette = "";
                //SELECT Clients.id_client, Clients.nom_client, Clients.prenom_client, Count(Clients.nom_client) AS CountOfnom_client FROM Clients INNER JOIN Biens ON Clients.idclient = Biens.idclient WHERE (((Biens.ref) Like "v*")) GROUP BY Clients.id_client, Clients.nom_client, Clients.prenom_client, Biens.actif, Clients.statut HAVING (((Biens.actif)="actif") AND ((Clients.statut) Like "*nego*")) ORDER BY Clients.nom_client, Clients.prenom_client;
                //if (CheckBoxArchive.Checked == true) requette = "SELECT DISTINCT Clients.id_client, Clients.nom_client, Clients.prenom_client FROM Biens LEFT JOIN Clients ON Biens.idclient = Clients.idclient GROUP BY Clients.id_client, Clients.nom_client, Clients.prenom_client ORDER BY Clients.nom_client";
                if (CheckBoxArchive.Checked == true)
                {
                    //SELECT Clients.id_client, Clients.nom_client, Clients.prenom_client, Count(Clients.nom_client) AS CountOfnom_client, Clients.idclient FROM Clients INNER JOIN Biens ON Clients.idclient = Biens.idclient WHERE (((Biens.ref) Like 'v%')) GROUP BY Clients.id_client, Clients.nom_client, Clients.prenom_client, Biens.actif, Clients.statut, Clients.idclient HAVING (((Biens.actif)='actif') AND ((Clients.statut) Like '%nego%')) ORDER BY Clients.nom_client, Clients.prenom_client
                    requette = "SELECT Clients.id_client, Clients.nom_client, Clients.prenom_client, Count(Clients.nom_client) AS CountOfnom_client, Clients.idclient FROM Clients INNER JOIN Biens ON Clients.idclient = Biens.idclient WHERE (((Biens.ref) Like 'v%')) GROUP BY Clients.id_client, Clients.nom_client, Clients.prenom_client, Biens.actif, Clients.statut, Clients.idclient HAVING (((Biens.actif)='actif') AND ((Clients.statut) Like '%nego%')) ORDER BY Clients.nom_client, Clients.prenom_client";
                    //else requette = "SELECT DISTINCT Clients.id_client, Clients.nom_client, Clients.prenom_client FROM Biens   LEFT JOIN Clients ON Biens.idclient = Clients.idclient WHERE Biens.actif NOT LIKE 'archive'GROUP BY Clients.id_client, Clients.nom_client, Clients.prenom_client, Biens.actif ORDER BY Clients.nom_client";
                }
                else
                {
                    requette = "SELECT Clients.id_client, Clients.nom_client, Clients.prenom_client, Count(Clients.nom_client) AS CountOfnom_client, Clients.idclient FROM Clients INNER JOIN Biens ON Clients.idclient = Biens.idclient WHERE (((Biens.ref) Like 'v%')) GROUP BY Clients.id_client, Clients.nom_client, Clients.prenom_client, Biens.actif, Clients.statut, Clients.idclient HAVING (((Biens.actif)='archive') AND ((Clients.statut) Like '%nego%')) ORDER BY Clients.nom_client, Clients.prenom_client";
                }
                System.Data.DataSet ds = null;
                Connexion c = null;
                DropDownListNegociateur.Items.Clear();
                DropDownListNegociateur.Items.Add(new ListItem(Session["DropDownListChoixNegociateurText"].ToString(), Session["DropDownListChoixNegociateurValue"].ToString()));
                //DropDownListNegociateur.Items.Add(new ListItem(Session["DropDownListChoixNegociateur"].ToString()));
                c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                c.Open();
                ds = c.exeRequette(requette);
                c.Close();
                c = null;

                if (Session["DropDownListChoixNegociateur"].ToString() != "Tous")
                {
                    DropDownListNegociateur.Items.Add(new ListItem("Tous", "0"));
                }

                System.Data.DataRowCollection dr = ds.Tables[0].Rows;
                foreach (System.Data.DataRow ligne in dr)
                {
                    if (ligne["nom_client"].ToString().ToUpper() + " " + ligne["prenom_client"].ToString() != DropDownListNegociateur.SelectedValue.ToString())
                    {
                        if (ligne["nom_client"].ToString() != "null"
                            || ligne["prenom_client"].ToString() != "null")
                        {
                            DropDownListNegociateur.Items.Add(new ListItem(ligne["nom_client"].ToString().ToUpper() + " " + ligne["prenom_client"].ToString(), ligne["idclient"].ToString()));
                        }
                    }
                }
            }

            Remplir_DDL_Acq(sender, e);

            int id = member.IDCLIENT;

            int id1 = member.IDCLIENT;
            string typeBien2 = (radioButtonAchat.Checked)
                                    ? "'v%'"
                                    : "'l%'";
            String requete2 = "SELECT Clients.id_client, Clients.nom_client, Clients.prenom_client, Count(Clients.nom_client) AS CountOfnom_client, Clients.idclient FROM Clients INNER JOIN Biens ON Clients.idclient = Biens.idclient WHERE (((Biens.ref) Like " + typeBien2 + ")) GROUP BY Clients.id_client, Clients.nom_client, Clients.prenom_client, Biens.actif, Clients.statut, Clients.idclient HAVING (((Biens.actif)='actif') AND ((Clients.statut) Like '%nego%')) ORDER BY Clients.nom_client, Clients.prenom_client";

            System.Data.DataSet ds12 = null;
            Connexion c11 = null;

            c11 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c11.Open();
            ds12 = c11.exeRequette(requete2);
            c11.Close();
            c11 = null;

            System.Data.DataRowCollection dr12 = ds12.Tables[0].Rows;
            DropDownList2.Items.Add(new ListItem("", "0"));
            foreach (System.Data.DataRow ligne in dr12)
            {
                if (ligne["nom_client"].ToString().ToUpper() + " " + ligne["prenom_client"].ToString() != DropDownList2.SelectedValue.ToString())
                {
                    if (ligne["nom_client"].ToString() != "null"
                        || ligne["prenom_client"].ToString() != "null")
                    {
                        DropDownList2.Items.Add(new ListItem(ligne["nom_client"].ToString().ToUpper() + " " + ligne["prenom_client"].ToString() + "   (" + ligne["CountOfnom_client"].ToString() + ")", ligne["idclient"].ToString()));
                    }
                }
            }

            if (Session["CB_BT"] != null)
            {
                if (Session["CB_BT"].ToString() == "true")
                { CheckBoxArchive.Checked = true; }
                if (Session["CB_BT"].ToString() == "false")
                { CheckBoxArchive.Checked = false; }
            }


            //BindData();
            if (Session["sortExpression"] == null && Session["direction"] == null)
            {
                Session["sortExpression"] = "date dossier";
                Session["direction"] = " DESC";
            }
            DataTable table = this.GetData();
            table.DefaultView.Sort = (String)Session["sortExpression"] + (String)Session["direction"];
            GridView1.DataSource = table;
            ViewState["NbRecords"] = table.Rows.Count;
            GridView1.DataBind();

            if (radioButtonLocation.Checked)
            {
                ButtonLocation.Visible = true;
                ButtonVente.Visible = false;
            }
            else
            {
                ButtonLocation.Visible = false;
                ButtonVente.Visible = true;
            }
        }
        
            

        LabelbnBiens.Text = ViewState["NbRecords"].ToString();

        //Tri par default défault chargement



    }

    protected int CheckNombrePhotos(string reference)
    {
        int i = 0;

        // Récupère le chemin racine du site
        Connexion cI = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        cI.Open();
        System.Data.DataSet dsI = cI.exeRequette("Select * from Environnement");
        cI.Close();
        String racine_site = (String)dsI.Tables[0].Rows[0]["Chemin_racine_site"];

        String ImageA = racine_site + "images\\" + reference + "A.jpg";
        String ImageB = racine_site + "images\\" + reference + "B.jpg";
        String ImageC = racine_site + "images\\" + reference + "C.jpg";
        String ImageD = racine_site + "images\\" + reference + "D.jpg";
        String ImageE = racine_site + "images\\" + reference + "E.jpg";
        String ImageF = racine_site + "images\\" + reference + "F.jpg";
        String ImageG = racine_site + "images\\" + reference + "G.jpg";
        String ImageH = racine_site + "images\\" + reference + "H.jpg";

        if (System.IO.File.Exists(ImageA) == true)
            i++;
        if (System.IO.File.Exists(ImageB) == true)
            i++;
        if (System.IO.File.Exists(ImageC) == true)
            i++;
        if (System.IO.File.Exists(ImageD) == true)
            i++;
        if (System.IO.File.Exists(ImageE) == true)
            i++;
        if (System.IO.File.Exists(ImageF) == true)
            i++;
        if (System.IO.File.Exists(ImageG) == true)
            i++;
        if (System.IO.File.Exists(ImageH) == true)
            i++;

        return i;
    }
    protected void modif_admintab(object sender, EventArgs e)
    {
        if (((CheckBox)sender).Checked == true) { Session["CB_AT"] = "true"; }
        if (((CheckBox)sender).Checked == false) { Session["CB_AT"] = "false"; }
        if (((CheckBox)sender).Checked == true) { Session["CB_BT"] = "true"; }
        if (((CheckBox)sender).Checked == false) { Session["CB_BT"] = "false"; }
        //Response.Redirect("./moncomptetableaudebord_bis.aspx?Numpage=" + 1 + "&Tri=" + Session["Tri"] + "&Ordre=" + Session["Ordre"] + "&nbannonces=" + Session["annoncesPage"]);
    }
    private RequeteBien verifChampSaisi(RequeteBien maRecher)
    {

        #region attribut
        Regex regEmail = new Regex(@"^([\w\-.]+)@([a-zA-Z0-9\-.]+)$");
        Regex regTel = new Regex("^[0-9 ]+$");
        Regex numReg = new Regex("^[0-9 ]+$");
        Regex alphaNumReg = new Regex("^[0-9]+$|^[a-zA-Zéèçàâù . , ' ]+$|^()+$");
        Regex date = new Regex("^[1-9]|[12][0-9]|3[01]+$[/]+$[1-9]|1[012]+$[/](19|20)+$");




        bool regSurfaceMin = false;
        bool regSurfaceMax = false;
        bool regSurfaceSMin = false;
        bool regSurfaceSMax = false;
        bool regSurfaceTMin = false;
        bool regSurfaceTMax = false;
        bool regBudgetMin = false;
        bool regBudgetMax = false;
        bool regDateCreationMin = false;
        bool regDateCreationMax = false;
        bool regDateMajMin = false;
        bool regDateMajMax = false;
        bool regMailVendeur = false;
        bool regleTelVendeur = false;
        bool regleAdrVendeur = false;
        bool reglareferance = false;
        bool regNomVendeur = false;


        /// Contenu des textBox des ville apres un trim
        String adr1 = TextBoxAdresseVendeur.Text.Trim();
        String tel1 = TextBoxTelVendeur.Text.Trim();
        String smin = "erreur de saisie pour la surface minimal";
        String smax = "\n erreur de saisie pour la surface maximal";
        String bmin = "\n erreur de saisie pour la budget minimal";
        String bmax = "\n erreur de saisie pour la budget maximal";



        #endregion


        #region Série de test sur les textBoxs des ville pour savoir si la recherche est Code postal, departement ou nom de ville



        //Regex rCP = new Regex(@"^\d{5}$");
        Regex rCP = new Regex(@"^([0-9][0-9][0-9][0-9][0-9][ ]?)+$");
        Regex rDepartement = new Regex(@"^([0-9][0-9][ ]?)+$");




        //Série de test sur les textBoxs des ville pour savoir si la recherche est Code postal, departement ou nom de ville



        ///Verif si la demande sur textBoxVille1 est code postal , departement ou nom




        #endregion



        //if (ville1.Length == 0) maRecher.VILLE1_REG = false;
        //else if (ville1CodePostal || ville1Dep || ville1Nom) { maRecher.VILLE1_REG = true; }



        TextBoxBudgetMin.Text = TextBoxBudgetMin.Text.Replace(" ", "");
        TextBoxBudgetMax.Text = TextBoxBudgetMax.Text.Replace(" ", "");

        /*try
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

        }*/

        //test le contenu des box par expression reguliere si OK alors true
        if (tbReferance.Text.Trim() != "")
        {
            reglareferance = alphaNumReg.IsMatch(tbReferance.Text.Trim());
        }
        else reglareferance = true;

        if (TextBoxAdresseVendeur.Text.Trim() != "")
        {
            regleAdrVendeur = numReg.IsMatch(TextBoxAdresseVendeur.Text.Trim());
        }
        else regleAdrVendeur = true;   // si la text box est vide on effectue qd meme la recherche

        if (TextBoxTelVendeur.Text.Trim() != "")
        {
            regleTelVendeur = numReg.IsMatch(TextBoxTelVendeur.Text.Trim());
        }
        else regleTelVendeur = true;   // si la text box est vide on effectue qd meme la recherche

        if (tbNomVendeur.Text.Trim() != "")
        {
            regNomVendeur = alphaNumReg.IsMatch(tbNomVendeur.Text.Trim());
        }
        else regNomVendeur = true;


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

        if (TextBoxSurfaceSMin.Text.Trim() != "")
        {
            regSurfaceSMin = numReg.IsMatch(TextBoxSurfaceSMin.Text.Trim());
        }
        else regSurfaceSMin = true; // si la text box est vide on effectue qd meme la recherche

        if (TextBoxSurfaceSMax.Text.Trim() != "")
        {
            regSurfaceSMax = numReg.IsMatch(TextBoxSurfaceSMax.Text.Trim());
        }
        else
        {
            regSurfaceSMax = true; // si la text box est vide on effectue qd meme la recherche
        }

        if (textBoxSurfaceTMin.Text.Trim() != "")
        {
            regSurfaceTMin = numReg.IsMatch(textBoxSurfaceTMin.Text.Trim());
        }
        else regSurfaceTMin = true; // si la text box est vide on effectue qd meme la recherche

        if (textBoxSurfaceTMax.Text.Trim() != "")
        {
            regSurfaceTMax = numReg.IsMatch(textBoxSurfaceTMax.Text.Trim());
        }
        else
        {
            regSurfaceTMax = true; // si la text box est vide on effectue qd meme la recherche
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

        if (textBoxDateCreationMin.Text != "")
        {
            //if (numReg.IsMatch(textBoxDateCreationMin.Text.Trim()))
            //{
            //    regDateCreationMin = false;
            //}
            //else
            //{
            //    regDateCreationMin = date.IsMatch(textBoxDateCreationMin.Text.Trim());
            //}

            regDateCreationMin = true;
        }
        else regDateCreationMin = true;

        if (textBoxDateCreationMax.Text != "")
        {
            //if (numReg.IsMatch(textBoxDateCreationMax.Text.Trim()))
            //{
            //    regDateCreationMax = false;
            //}
            //else
            //{
            //    regDateCreationMax = date.IsMatch(textBoxDateCreationMax.Text.Trim());
            //}


            regDateCreationMax = true;
        }
        else regDateCreationMax = true;

        if (textBoxDateMajMin.Text != "")
        {
            //if (numReg.IsMatch(textBoxDateMajMin.Text.Trim()))
            //{
            //    regDateMajMin = false;
            //}
            //else
            //{
            //    regDateMajMin = date.IsMatch(textBoxDateMajMin.Text.Trim());
            //}
            regDateMajMin = true;
        }
        else regDateMajMin = true;

        if (textBoxDateMajMax.Text != "")
        {
            //if (numReg.IsMatch(textBoxDateMajMax.Text.Trim()))
            //{
            //    regDateMajMax = false;
            //}
            //else
            //{
            //    regDateMajMax = date.IsMatch(textBoxDateMajMax.Text.Trim());
            //}
            regDateMajMax = true;
        }
        else regDateMajMax = true;

        if (TextBoxMailVendeur.Text != "")
        {
            regMailVendeur = regEmail.IsMatch(TextBoxMailVendeur.Text);
        }
        else
        {
            regMailVendeur = true;
        }

        if (TextBoxTelVendeur.Text != "")
        {
            regleTelVendeur = regTel.IsMatch(TextBoxTelVendeur.Text);
        }
        else
        {
            regleTelVendeur = true;
        }


        /// affichage des erreurs de saisie dans le label 1
        Label1.Text = "";
        // if (regSurfaceMin == false || regSurfaceMax == false || regSurfaceSMin == false || regSurfaceSMax == false || regSurfaceTMin == false || regSurfaceTMax == false || regBudgetMin == false || regBudgetMax == false || regDateCreationMin == false || regDateCreationMax == false || regDateMajMin == false || regDateMajMax == false || regMailVendeur == false || regleTelVendeur == false)
        if (regSurfaceMin == false)
        {
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "erreur de saisie, veuillez resaisir les critères de votre recherche par N¤ de Tel";
        }



        if (maRecher.PRIXMAX < maRecher.PRIXMIN)
        {
            regSurfaceMin = false;
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "erreur de saisie, veuillez resaisir les critères de votre recherche par prix";
        }

        if (maRecher.SURFACEMAX < maRecher.SURFACEMIN)
        {
            regSurfaceMin = false;
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "erreur de saisie, veuillez resaisir les critères de votre recherche par surface";
        }

        if (DateTime.Compare(maRecher.DATECREATIONMIN, maRecher.DATECREATIONMAX) > 0)
        {
            regDateCreationMin = false;
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "erreur de saisie, veuillez resaisir les critères de votre recherche par date creation";
        }

        if (DateTime.Compare(maRecher.DATEMAJMIN, maRecher.DATEMAJMAX) > 0)
        {
            regDateMajMin = false;
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "erreur de saisie, veuillez resaisir les critères de votre recherche par date ajour";
        }

        if (regSurfaceMin == true && regSurfaceMax == true && regSurfaceSMin == true && regSurfaceSMax == true && regSurfaceTMin == true && regSurfaceTMax == true && regBudgetMin == true && regBudgetMax == true && regDateCreationMin == true && regDateCreationMax == true && regDateMajMin == true && regDateMajMax == true)
            maRecher.RECHERCHE_OK = true;

        ///Si tout est OK alors maRecherche.RECHERCHE_OK =true -----> permet d'executer la requete
        else if (regSurfaceMin == true && regSurfaceMax == true && regSurfaceSMin == true && regSurfaceSMax == true && regSurfaceTMin == true && regSurfaceTMax == true && regBudgetMin == true && regBudgetMax == true && regDateCreationMin == true && regDateCreationMax == true && regDateMajMin == true && regDateMajMax == true)
            maRecher.RECHERCHE_OK = true;
        else maRecher.RECHERCHE_OK = false;

        return maRecher;

    }
    protected void PaginateTheData(object sender, GridViewPageEventArgs e)
    {
        List<string> list = new List<string>();
        if (ViewState["SelectedRecords"] != null)
        {
            list = (List<string>)ViewState["SelectedRecords"];
        }
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox check = (CheckBox)row.FindControl("CheckBoxArchiver");
            var selectedKey = GridView1.DataKeys[row.RowIndex].Value.ToString();
            if (check.Checked)
            {
                if (!list.Contains(selectedKey))
                {
                    list.Add(selectedKey);
                }
            }
            else
            {
                if (list.Contains(selectedKey))
                {
                    list.Remove(selectedKey);
                }
            }
        }
        DataTable table = this.GetData();
        table.DefaultView.Sort = (String)Session["sortExpression"] + (String)Session["direction"];
        GridView1.DataSource = table;
        ViewState["NbRecords"] = table.Rows.Count;
        ViewState["SelectedRecords"] = list;
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();


        // On coche la checkbox tout sélectionner.
        int i = 0;
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox check = (CheckBox)row.FindControl("CheckBoxArchiver");
            if (check.Checked)
            {
                i++;
            }
        }
        if (i == GridView1.PageSize)
        {
            GridViewRow rowe = GridView1.HeaderRow;
            CheckBox checkboxSelect = (CheckBox)rowe.FindControl("CheckBoxSelection");
            checkboxSelect.Checked = true;
        }
    }
    protected void SortRecords(object sender, GridViewSortEventArgs e)
    {
        Session["sortExpression"] = e.SortExpression;
        Session["direction"] = string.Empty;

        if (SortDirection == SortDirection.Ascending)
        {
            SortDirection = SortDirection.Descending;
            Session["direction"] = " DESC";
        }
        else
        {
            SortDirection = SortDirection.Ascending;
            Session["direction"] = " ASC";
        }
        DataTable table = this.GetData();
        table.DefaultView.Sort = (String)Session["sortExpression"] + (String)Session["direction"];
        GridView1.DataSource = table;
        ViewState["NbRecords"] = table.Rows.Count;
        GridView1.DataBind();
    }
    private void BindData()
    {
        // specify the data source for the GridView
        DataTable table = this.GetData();
        GridView1.DataSource = table;
        ViewState["NbRecords"] = table.Rows.Count;
        // bind the data now
        GridView1.DataBind();
    }
    /// <summary>
    /// Gets or sets the grid view sort direction.
    /// </summary>
    /// <value>
    /// The grid view sort direction.
    /// </value>
    public SortDirection SortDirection
    {
        get
        {
            if (ViewState["SortDirection"] == null)
            {
                ViewState["SortDirection"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["SortDirection"];
        }
        set
        {
            ViewState["SortDirection"] = value;
        }
    }
    /// <summary> 
    /// Gets the data. 
    /// </summary> 
    private DataTable GetData()
    {
        if ((CheckBoxArchive).Checked == true)
        { Session["CB_BT"] = "true"; }
        if ((CheckBoxArchive).Checked == false)
        { Session["CB_BT"] = "false"; }


        RequeteBien recherche = new RequeteBien();


        if (TextBoxBudgetMin.Text == "") recherche.PRIXMIN = 0;
        if (TextBoxBudgetMax.Text == "") recherche.PRIXMAX = 1000000000;
        if (TextBoxBudgetMin.Text == "") recherche.LOYERMIN = 0;
        if (TextBoxBudgetMax.Text == "") recherche.LOYERMAX = 1000000000;
        if (textBoxSurfaceMin.Text == "") recherche.SURFACEMIN = 0;
        if (textBoxSurfaceMax.Text == "") recherche.SURFACEMAX = 9999999;
        if (TextBoxSurfaceSMin.Text == "") recherche.SURFACESMIN = 0;
        if (TextBoxSurfaceSMax.Text == "") recherche.SURFACESMAX = 9999999;
        if (textBoxSurfaceTMin.Text == "") recherche.SURFACETMIN = 0;
        if (textBoxSurfaceTMax.Text == "") recherche.SURFACETMAX = 9999999;

        if (TextBoxBudgetMin.Text != "")
        {
            if (radioButtonAchat.Checked)
            {
                recherche.PRIXMIN = Int64.Parse(TextBoxBudgetMin.Text.Trim());
                recherche.LOYERMIN = 0;
            }
            else
            {
                recherche.PRIXMIN = 0;
                recherche.LOYERMIN = Int64.Parse(TextBoxBudgetMin.Text.Trim());
            }
        }
        if (TextBoxBudgetMax.Text != "")
        {
            if (radioButtonAchat.Checked)
            {
                recherche.PRIXMAX = Int64.Parse(TextBoxBudgetMax.Text.Trim());
                recherche.LOYERMAX = 1000000000;
            }
            else
            {
                recherche.PRIXMAX = 1000000000;
                recherche.LOYERMAX = Int64.Parse(TextBoxBudgetMax.Text.Trim());
            }
        }
        if (textBoxSurfaceMin.Text != "") recherche.SURFACEMIN = Int64.Parse(textBoxSurfaceMin.Text.Trim());
        if (textBoxSurfaceMax.Text != "") recherche.SURFACEMAX = Int64.Parse(textBoxSurfaceMax.Text.Trim());
        if (TextBoxSurfaceSMin.Text != "") recherche.SURFACESMIN = Int64.Parse(TextBoxSurfaceSMin.Text.Trim());
        if (TextBoxSurfaceSMax.Text != "") recherche.SURFACESMAX = Int64.Parse(TextBoxSurfaceSMax.Text.Trim());
        if (textBoxSurfaceTMin.Text != "") recherche.SURFACETMIN = Int64.Parse(textBoxSurfaceTMin.Text.Trim());
        if (textBoxSurfaceTMax.Text != "") recherche.SURFACETMAX = Int64.Parse(textBoxSurfaceTMax.Text.Trim());
        if (textBoxDateCreationMin.Text != "") recherche.DATECREATIONMIN = Convert.ToDateTime(textBoxDateCreationMin.Text + " 00:00:00 AM");
        if (textBoxDateCreationMax.Text != "") recherche.DATECREATIONMAX = Convert.ToDateTime(textBoxDateCreationMax.Text + " 11:59:59 PM").AddDays(1);	//L'heure n'est pas prise en compte
        if (textBoxDateMajMin.Text != "") recherche.DATEMAJMIN = Convert.ToDateTime(textBoxDateMajMin.Text + " 00:00:00 AM");
        if (textBoxDateMajMax.Text != "") recherche.DATEMAJMAX = Convert.ToDateTime(textBoxDateMajMax.Text + " 11:59:59 PM").AddDays(1);	//Access prend 0:00:00 AM par defaut -> +1 jour pour etre non exclusif

        recherche.MAILVENDEUR = TextBoxMailVendeur.Text;
        recherche.ADRESSEBIEN = TextBoxAdresseVendeur.Text;
        string texte = null;
        try
        {
            texte = TextBoxAdresseVendeur.Text;
            texte = texte.Replace("'", "''");
            recherche.ADRESSEBIEN = texte.Trim();
        }
        catch { recherche.ADRESSEBIEN = ""; }


        if (verifChampSaisi(recherche).RECHERCHE_OK == true)
        {
            texte = textBoxMotCle1.Text;
            texte = texte.Replace("'", "''");
            recherche.MOTCLE1 = texte.Trim();

            texte = textBoxMotCle2.Text;
            texte = texte.Replace("'", "''");
            recherche.MOTCLE2 = texte.Trim();

            texte = textBoxMotCle3.Text;
            texte = texte.Replace("'", "''");
            recherche.MOTCLE3 = texte.Trim();

            texte = textBoxMotCle4.Text;
            texte = texte.Replace("'", "''");
            recherche.MOTCLE4 = texte.Trim();

            recherche.lareferance1 = tbReferance.Text.Trim();
            recherche.leTelVendeur1 = TextBoxTelVendeur.Text.Trim();
            //recherche.leAdrVendeur1 = TextBoxAdresseVendeur.Text.Trim();
            recherche.nomvendeur1 = tbNomVendeur.Text.Trim();

            recherche.TYPEMANDAT = DropDownListTypeMandat.SelectedValue;

            if (Session["DropDownListChoixNegociateur"] != "Tous")
            {
                if (DropDownListNegociateur.SelectedValue.ToString() != "Tous")
                {
                    //string[] substring = Regex.Split(DropDownListNegociateur.SelectedValue.ToString(), " ");
                    //recherche.NEGOCIATEUR = substring[1] + " " + substring[0];
                    //Response.Write(substring[0] + substring[1]);

                    ////

                    string nompa = DropDownListNegociateur.SelectedValue;
                    recherche.IDCLIENTAJOUTE = nompa;

                }
            }
            else
            {
                recherche.NEGOCIATEUR = "";
            }

            Membre member = (Membre)Session["Membre"];
            //if (member.STATUT == "ultranego" && RadioButtonTousLesBiens.Checked)
            if (RadioButtonTousLesBiens.Checked)
            {
                recherche.IDCLIENT = 0;
                GridView1.Columns[22].Visible = true;
                BoutonArchiver.Visible = true;
                BoutonDupliquer.Visible = true;
            }
            else if (RadioButtonMonAgence.Checked && member.STATUT == "ultranego")
            {
                recherche.IDCLIENT = 01;
                recherche.NUMAGENCE = member.NUM_AGENCE;
                GridView1.Columns[22].Visible = true;
                BoutonArchiver.Visible = true;
                BoutonDupliquer.Visible = true;
            }
            else if (RadioButtonMonAgence.Checked && member.STATUT != "ultranego")
            {
                recherche.IDCLIENT = 01;
                recherche.NUMAGENCE = member.NUM_AGENCE;
                GridView1.Columns[22].Visible = true;
                BoutonArchiver.Visible = false;
                BoutonDupliquer.Visible = false;
            }
            else if (RadioButtonTousLesBiens.Checked && member.STATUT != "ultranego")
            {
                recherche.IDCLIENT = 02;
                GridView1.Columns[22].Visible = false;
                BoutonArchiver.Visible = false;
                BoutonDupliquer.Visible = false;
            }
            else if (RadioButtonMesBiens.Checked && member.STATUT != "ultranego")
            {
                recherche.IDCLIENT = member.IDCLIENT;
                GridView1.Columns[22].Visible = true;
                BoutonArchiver.Visible = true;
                BoutonDupliquer.Visible = true;
            }
            else
            {
                recherche.IDCLIENT = member.IDCLIENT;
                GridView1.Columns[22].Visible = true;
                BoutonArchiver.Visible = true;
                BoutonDupliquer.Visible = true;
            }

            if (RadioButtonMesBiens.Checked && (member.STATUT == "ultranego" || member.STATUT == "nego"))
            {
                Session["NumAgence"] = member.NUM_AGENCE;
                DropDownListNegociateur.Items.Clear();
                DropDownListNegociateur.SelectedValue = member.NOM.ToUpper() + " " + member.PRENOM;
                DropDownListNegociateur.Items.Add(new ListItem(member.NOM.ToUpper() + " " + member.PRENOM));
            }
            else if (RadioButtonMonAgence.Checked && (member.STATUT == "ultranego" || member.STATUT == "nego"))
            {
                Session["NumAgence"] = member.NUM_AGENCE;
                String requette = "SELECT DISTINCT Clients.id_client,Clients.idclient, Clients.nom_client, Clients.prenom_client, Clients.num_agence FROM Biens LEFT JOIN Clients ON Biens.idclient = Clients.idclient GROUP BY Clients.id_client, Clients.nom_client, Clients.prenom_client, Clients.num_agence, Clients.idclient HAVING (((Clients.num_agence)='" + member.NUM_AGENCE + "'))ORDER BY Clients.nom_client";
                System.Data.DataSet ds = null;
                Connexion c = null;
                DropDownListNegociateur.Items.Clear();

                DropDownListNegociateur.Items.Add(new ListItem(Session["DropDownListChoixNegociateur"].ToString()));
                c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                c.Open();
                ds = c.exeRequette(requette);
                c.Close();
                c = null;

                if (Session["DropDownListChoixNegociateur"].ToString() != "Tous")
                {
                    DropDownListNegociateur.Items.Add(new ListItem("Tous", "0"));
                }

                System.Data.DataRowCollection dr = ds.Tables[0].Rows;
                foreach (System.Data.DataRow ligne in dr)
                {
                    if (ligne["nom_client"].ToString().ToUpper() + " " + ligne["prenom_client"].ToString() != DropDownListNegociateur.SelectedValue.ToString())
                    {
                        if (ligne["nom_client"].ToString() != "null"
                            || ligne["prenom_client"].ToString() != "null")
                        {
                            DropDownListNegociateur.Items.Add(new ListItem(ligne["nom_client"].ToString().ToUpper() + " " + ligne["prenom_client"].ToString(), ligne["idclient"].ToString()));
                        }
                    }
                }
            }
            else if (RadioButtonTousLesBiens.Checked && (member.STATUT == "ultranego" || member.STATUT == "ultranego " || member.STATUT == "nego"))
            {
                string typeBien = (radioButtonAchat.Checked)
                                    ? "'v%'"
                                    : "'l%'";
                Session["NumAgence"] = member.NUM_AGENCE;
                String requette = "";
                //SELECT Clients.id_client, Clients.nom_client, Clients.prenom_client, Count(Clients.nom_client) AS CountOfnom_client FROM Clients INNER JOIN Biens ON Clients.idclient = Biens.idclient WHERE (((Biens.ref) Like 'v%')) GROUP BY Clients.id_client, Clients.nom_client, Clients.prenom_client, Biens.actif, Clients.statut HAVING (((Biens.actif)='actif') AND ((Clients.statut) Like '%nego%')) ORDER BY Clients.nom_client, Clients.prenom_client
                //if (CheckBoxArchive.Checked == true) requette = "SELECT DISTINCT Clients.id_client, Clients.nom_client, Clients.prenom_client FROM Biens LEFT JOIN Clients ON Biens.idclient = Clients.idclient GROUP BY Clients.id_client, Clients.nom_client, Clients.prenom_client ORDER BY Clients.nom_client";

                if (CheckBoxArchive.Checked == true) requette = "SELECT Clients.id_client, Clients.nom_client, Clients.prenom_client, Count(Clients.nom_client) AS CountOfnom_client, Clients.idclient FROM Clients INNER JOIN Biens ON Clients.idclient = Biens.idclient WHERE (((Biens.ref) Like " + typeBien + ")) GROUP BY Clients.id_client, Clients.nom_client, Clients.prenom_client, Biens.actif, Clients.statut, Clients.idclient HAVING (((Biens.actif)='archive') AND ((Clients.statut) Like '%nego%')) ORDER BY Clients.nom_client, Clients.prenom_client";
                //SELECT Clients.id_client, Clients.nom_client, Clients.prenom_client, Count(Clients.nom_client) AS CountOfnom_client FROM Clients INNER JOIN Biens ON Clients.idclient = Biens.idclient WHERE (((Biens.ref) Like 'v%')) GROUP BY Clients.id_client, Clients.nom_client, Clients.prenom_client, Biens.actif, Clients.statut HAVING (((Biens.actif)='archive') AND ((Clients.statut) Like '%nego%')) ORDER BY Clients.nom_client, Clients.prenom_client
                //else requette = "SELECT DISTINCT Clients.id_client, Clients.nom_client, Clients.prenom_client FROM Biens   LEFT JOIN Clients ON Biens.idclient = Clients.idclient WHERE Biens.actif NOT LIKE 'archive'GROUP BY Clients.id_client, Clients.nom_client, Clients.prenom_client, Biens.actif ORDER BY Clients.nom_client";
                else requette = "SELECT Clients.id_client, Clients.nom_client, Clients.prenom_client, Count(Clients.nom_client) AS CountOfnom_client, Clients.idclient FROM Clients INNER JOIN Biens ON Clients.idclient = Biens.idclient WHERE (((Biens.ref) Like " + typeBien + ")) GROUP BY Clients.id_client, Clients.nom_client, Clients.prenom_client, Biens.actif, Clients.statut, Clients.idclient HAVING (((Biens.actif)='actif') AND ((Clients.statut) Like '%nego%')) ORDER BY Clients.nom_client, Clients.prenom_client";
                System.Data.DataSet ds = null;
                Connexion c = null;
                DropDownListNegociateur.Items.Clear();
                DropDownListNegociateur.Items.Add(new ListItem(Session["DropDownListChoixNegociateurText"].ToString(), Session["DropDownListChoixNegociateurValue"].ToString()));
                //DropDownListNegociateur.Items.Add(new ListItem(Session["DropDownListChoixNegociateur"].ToString()));
                c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                c.Open();
                ds = c.exeRequette(requette);
                c.Close();
                c = null;

                if (Session["DropDownListChoixNegociateur"].ToString() != "Tous")
                {
                    DropDownListNegociateur.Items.Add(new ListItem("Tous", "0"));
                }

                System.Data.DataRowCollection dr = ds.Tables[0].Rows;
                foreach (System.Data.DataRow ligne in dr)
                {
                    if (ligne["nom_client"].ToString().ToUpper() + " " + ligne["prenom_client"].ToString() != DropDownListNegociateur.SelectedValue.ToString())
                    {
                        if (ligne["nom_client"].ToString() != "null"
                            || ligne["prenom_client"].ToString() != "null")
                        {
                            DropDownListNegociateur.Items.Add(new ListItem(ligne["nom_client"].ToString().ToUpper() + " " + ligne["prenom_client"].ToString() + "   (" + ligne["CountOfnom_client"].ToString() + ")", ligne["idclient"].ToString()));
                        }
                    }
                }
            }

            recherche.tel1 = TextBoxTelVendeur.Text.Trim();

            //--------------------------------------------------------------------------------------------------------
            //recherche.leTelVendeur1 = new List<string>(TextBoxTelVendeur.Text.Split(' '));
            if (checkBoxAppart.Checked == true && checkBoxTerrain.Checked == true)
            {
                recherche.PIECE1 = checkBoxPiece1.Checked;
                recherche.PIECE2 = checkBoxPiece2.Checked;
                recherche.PIECE3 = checkBoxPiece3.Checked;
                recherche.PIECE4 = checkBoxPiece4.Checked;
                recherche.PIECE5 = checkBoxPiece5.Checked;

                recherche.CHAMBRE1 = checkBoxChambre1.Checked;
                recherche.CHAMBRE2 = checkBoxChambre2.Checked;
                recherche.CHAMBRE3 = checkBoxChambre3.Checked;
                recherche.CHAMBRE4 = checkBoxChambre4.Checked;
                recherche.CHAMBRE5 = checkBoxChambre5.Checked;
            }

            recherche.ESTI = checkBoxEstimation.Checked;
            recherche.DISP = checkBoxDisponible.Checked;
            recherche.OFFR = checkBoxOffre.Checked;
            recherche.SUSP = checkBoxSuspendu.Checked;
            recherche.RETI = checkBoxRetire.Checked;
            recherche.COMP = checkBoxCompromis.Checked;

            recherche.LIBRE = checkBoxLibre.Checked;
            recherche.OCCUPE = checkBoxOccupe.Checked;
            recherche.LOUE = checkBoxLoue.Checked;
            recherche.OPTION = checkBoxOption.Checked;
            recherche.RESERV = checkBoxReserve.Checked;
            recherche.RETIRE = checkBoxRet.Checked;
            recherche.SUSPEN = checkBoxSusp.Checked;

            recherche.COUP_DE_COEUR = chckBxCdC.Checked;
            recherche.PRESTIGE = chckBxPrestige.Checked;
            recherche.MER = chckBxMer.Checked;
            recherche.MONTAGNE = chckBxMontagne.Checked;

            if (ListeNeuf.SelectedValue == "0")
            {
                recherche.NeufOuPas = false;
                recherche.NEUF = false;
            }
            else if (ListeNeuf.SelectedValue == "1")
            {
                recherche.NeufOuPas = false;
                recherche.NEUF = true;
            }
            else
            {
                recherche.NeufOuPas = true;
            }

            if (checkBoxAppart.Checked == false && checkBoxTerrain.Checked == false && checkBoxMaison.Checked == false && checkBoxAutre.Checked == false)
            {
                recherche.TYPEBIEN = "AMTX";
            }
            else
            {
                if (checkBoxAppart.Checked) recherche.TYPEBIEN += "A";
                if (checkBoxMaison.Checked) recherche.TYPEBIEN += "M";
                if (checkBoxTerrain.Checked) recherche.TYPEBIEN += "T";
                if (checkBoxAutre.Checked) recherche.TYPEBIEN += "X";
            }

            if (radioButtonAchat.Checked)
            {
                radioButtonAchat.CssClass = "myButtonblue";
                radioButtonLocation.CssClass = "myButtonred";
                recherche.TYPEVENTE += "V";
            }
            if (radioButtonLocation.Checked)
            {
                radioButtonLocation.CssClass = "myButtonblue";
                radioButtonAchat.CssClass = "myButtonred";
                recherche.TYPEVENTE += "L";
            }
            /*
                        if (RadioButtonTousLesBiens.Checked)
                        {
                            recherche.NEGOCIATEUR = (String)Session["DropDownListChoixNegociateur"];
                        }
                        if (RadioButtonMonAgence.Checked)
                        {
                            recherche.NEGOCIATEUR = (String)Session["DropDownListChoixNegociateur"];
                        }
            */
            //sauvegarde l'objet recherche dans la session

            recherche.ListeVille2 = textBoxVille.Text;
            recherche.ListePays2 = textBoxPays.Text;
            recherche.ListeDep2 = textBoxDep.Text;

            Session["requete"] = recherche;
        }
        DataTable table = new DataTable();
        string sql = "";
        if (CheckBoxArchive.Checked)
        {
            sql = recherche.REQUETE_SQL_Archive;
        }
        else
        {
            sql = recherche.REQUETE_SQL;
        }

        #region odbc Connexion
        /*
        // get the connection 
        using (OdbcConnection cI = new OdbcConnection(_ConnectionString))
        {
            // write the sql statement to execute 
            //string sql = recherche.ToString();
            // instantiate the command object to fire 
            using (OdbcCommand cmd = new OdbcCommand(sql, cI))
            {
                // get the adapter object and attach the command object to it 
                using (OdbcDataAdapter ad = new OdbcDataAdapter(cmd))
                {					
					//System.IO.File.WriteAllText(@"C:\PATRIMO\PATRIMO\pages\requete.txt", sql);
					// fire Fill method to fetch the data and fill into DataTable 
                    ad.Fill(table);
                }
            }
        }*/
        #endregion

        Connexion conn = new Connexion();
        conn.Open();
        DataSet oDs = conn.exeRequette(sql);
        conn.Close();
        table = oDs.Tables[sql];

        table.Columns.Add("cdcPrestige");
        string imgcdcPrestige;
        for (int i = 0; i < table.Rows.Count; i++)
        {
            if ((bool)table.Rows[i]["CoupDeCoeur"] || (bool)table.Rows[i]["Prestige"] || (bool)table.Rows[i]["Neuf"] || (bool)table.Rows[i]["PubLocale"])
            {
                imgcdcPrestige = "<img class=\"pointsCdcPrestige\" src=\"../img_site/pointsCdcPrNf/points";
                if ((bool)table.Rows[i]["CoupDeCoeur"])
                {
                    imgcdcPrestige += "CoupDeCoeur";
                }
                if ((bool)table.Rows[i]["Prestige"])
                {
                    imgcdcPrestige += "Prestige";
                }
                if ((bool)table.Rows[i]["Neuf"])
                {
                    imgcdcPrestige += "Neuf";
                }
                if ((bool)table.Rows[i]["PubLocale"])
                {
                    imgcdcPrestige += "Pub";
                }
                imgcdcPrestige += ".png\" alt=\"Cdc, Pr & Nf\" />";
            }
            else
            {
                imgcdcPrestige = "";
            }
            table.Rows[i]["cdcPrestige"] = imgcdcPrestige;
        }

        return table;
    }
    /// <summary> 
    /// Gets the selected records. 
    /// </summary> 
    /// <param name="sender">The sender.</param> 
    /// <param name="e">The <see cref="System.EventArgs"/>
    ///    instance containing the event data.</param> 
    protected void Archiver_Reactiver(object sender, EventArgs e)
    {
        string requete = "";
        List<string> list = new List<string>();
        if (ViewState["SelectedRecords"] != null)
        {
            list = (List<string>)ViewState["SelectedRecords"];
        }
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox check = (CheckBox)row.FindControl("CheckBoxArchiver");
            var selectedKey = GridView1.DataKeys[row.RowIndex].Value.ToString();
            if (check.Checked)
            {
                if (!list.Contains(selectedKey))
                {
                    list.Add(selectedKey);
                }
            }
            else
            {
                if (list.Contains(selectedKey))
                {
                    list.Remove(selectedKey);
                }
            }
        }
        //Création d'une nouvelle liste pour stocker les références qui seront supprimées de la liste ensuite.
        List<string> listes = new List<string>();
        ViewState["SelectedRecords"] = list;
        if (CheckBoxArchive.Checked)
        {
            List<string> liste = ViewState["SelectedRecords"] as List<string>;
            if (list != null)
            {
                foreach (string id in list)
                {
                    requete = "UPDATE Biens SET `actif`='actif' WHERE `ref`='" + id + "'";

                    System.Data.DataSet ds = null;
                    Connexion c = null;

                    c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    c.Open();
                    ds = c.exeRequette(requete);
                    c.Close();
                    c = null;
                    listes.Add(id);
                }
                LabelErrorLogin.Visible = false;
            }
        }
        else
        {
            List<string> liste = ViewState["SelectedRecords"] as List<string>;
            if (list != null)
            {
                foreach (string id in list)
                {
                    requete = "UPDATE Biens SET `actif`='archive' WHERE `ref`='" + id + "'";

                    System.Data.DataSet ds = null;
                    Connexion c = null;

                    c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    c.Open();
                    ds = c.exeRequette(requete);
                    c.Close();
                    c = null;
                    listes.Add(id);
                }
                LabelErrorLogin.Visible = false;
            }
        }
        foreach (string id in listes)
        {
            list.Remove(id);
        }
        BindData();
    }
    /// <summary> 
    /// Looks for selection. 
    /// </summary> 
    /// <param name="sender">The sender.</param> 
    /// <param name="e">The <seecref="System.Web.UI.WebControls.GridViewRowEventArgs"/>
    ///     instance containing the event data.</param> 
    ///     
    protected void ReSelectSelectedRecords(object sender, GridViewRowEventArgs e)
    {
        List<string> list = ViewState["SelectedRecords"] as List<string>;
        if (e.Row.RowType == DataControlRowType.DataRow && list != null)
        {
            var reference = GridView1.DataKeys[e.Row.RowIndex].Value.ToString();
            if (list.Contains(reference))
            {
                CheckBox check = (CheckBox)e.Row.FindControl("CheckBoxArchiver");
                check.Checked = true;
            }
        }
        // On crée les petites bulles pour chaque colonne.
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string loue = e.Row.Cells[0].Text.ToString().Substring(0, 1);
            string couleur = e.Row.Cells[4].Text.ToString().Substring(0, 3);

            //Permet d'afficher soit le loyer soit le prix de vente.
            if (e.Row.Cells[0].Text.ToString().Substring(0, 1) == "V")
            {
                GridView1.Columns[13].Visible = true;
                GridView1.Columns[12].Visible = false;
            }
            else
            {
                GridView1.Columns[12].Visible = true;
                GridView1.Columns[13].Visible = false;
            }

            //Cacher la colonne adresse, code postal, pays
            GridView1.Columns[6].Visible = false;
            GridView1.Columns[7].Visible = false;
            GridView1.Columns[9].Visible = false;

            //Ligne permettant que le click sur la ligne renvoie à la fiche détail sauf pour les 2dernières colonnes
            // Pour faire toute la ligne: e.Row.Attributes["OnClick"] = "...";$
            //for(int i = 0; i < 23 ; i++)
            //   e.Row.Cells[i].Attributes["onClick"] = "location.href='fichedetail1.aspx?ref=" + DataBinder.Eval(e.Row.DataItem, "ref") + "'";
            e.Row.Cells[6].Attributes["class"] = "nowrap";

            string refe = e.Row.Cells[0].Text.ToString();


            string texte_internet = "";
            if (DataBinder.Eval(e.Row.DataItem, "texte internet").ToString() != "")
                texte_internet = "<br/><br/>" + DataBinder.Eval(e.Row.DataItem, "texte internet").ToString();
            else
                texte_internet = "";


            e.Row.Cells[0].Attributes["onClick"] = "window.open('fichedetail1.aspx?ref=" + DataBinder.Eval(e.Row.DataItem, "ref") + "')";

            e.Row.Cells[0].Attributes["style"] = "cursor:pointer";

            e.Row.Cells[0].Text = DataBinder.Eval(e.Row.DataItem, "ref") + "</a>"
                                    + "<div class = \"tooltip3 span MySpace\"><span style='white-space:normal;'>" + DataBinder.Eval(e.Row.DataItem, "ref") + nl2br(texte_internet) + "</span></div>";
            e.Row.Cells[1].Text = e.Row.Cells[1].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[1].Text + "</span></div>";

            if (e.Row.Cells[0].Text.ToString().Substring(0, 1) == "V")
            {
                e.Row.Cells[2].Text = "V<div class = \"tooltip\"><span>Vente</span></div>";
            }
            else
            {
                e.Row.Cells[2].Text = "L<div class = \"tooltip\"><span>Location</span></div>";
            }

            string refer = DataBinder.Eval(e.Row.DataItem, "ref").ToString();
            string type_bien = DataBinder.Eval(e.Row.DataItem, "type de bien").ToString();
            switch (type_bien)
            {
                case "A":
                    e.Row.Cells[3].Text = "A<div class = \"tooltip\"><span>Appartement</span></div>";
                    break;

                case "M":
                    e.Row.Cells[3].Text = "M<div class = \"tooltip\"><span>Maison</span></div>";
                    break;

                case "T":
                    e.Row.Cells[3].Text = "T<div class = \"tooltip\"><span>Terrain</span></div>";
                    break;

                case "L":
                    e.Row.Cells[3].Text = "L<div class = \"tooltip\"><span>Local</span></div>";
                    break;

                default:
                    e.Row.Cells[3].Text = "I<div class = \"tooltip\"><span>Immeuble</span></div>";
                    break;
            }

            e.Row.Cells[8].Text = "<img style='margin-top:-3px;margin-right:2px; margin-bottom:-3px;cursor:pointer' src='../img_site/flat_round/monde.png' height='16px'/>" + e.Row.Cells[8].Text.ToLower();
            e.Row.Cells[8].Attributes["style"] = "text-align:left; width:86px";

            e.Row.Cells[8].Attributes["onClick"] = "window.open('https://www.google.fr/maps/place/" + DataBinder.Eval(e.Row.DataItem, "adresse du bien") + " " + DataBinder.Eval(e.Row.DataItem, "ville du bien") + "')";
            e.Row.Cells[8].Text += "<div class = \"tooltip\"><span>" + DataBinder.Eval(e.Row.DataItem, "adresse du bien")
                                    + ((DataBinder.Eval(e.Row.DataItem, "adresse du bien") != "") ? "<br/>" : "")
                                    + DataBinder.Eval(e.Row.DataItem, "ville du bien")
                                    + " (" + DataBinder.Eval(e.Row.DataItem, "code postal du bien") + ")"
                                    + "</span></div>";


            if (e.Row.Cells[6].Text.Length > 18)
            {
                string A = e.Row.Cells[6].Text;
                e.Row.Cells[6].Text = e.Row.Cells[6].Text.ToString().Substring(0, 18) + "[...]<br/>" + DataBinder.Eval(e.Row.DataItem, "code postal du bien") + " " + DataBinder.Eval(e.Row.DataItem, "ville du bien");
                e.Row.Cells[6].Text = e.Row.Cells[6].Text + "<div class = \"tooltip\"><span>" + A
                                        + "<br/>" + DataBinder.Eval(e.Row.DataItem, "code postal du bien") + " " + DataBinder.Eval(e.Row.DataItem, "ville du bien") + "</span></div>";
            }
            else
            {
                string A = e.Row.Cells[6].Text;
                string br = (DataBinder.Eval(e.Row.DataItem, "adresse du bien") == "") ? "" : "<br/>";
                e.Row.Cells[6].Text = e.Row.Cells[6].Text + br + DataBinder.Eval(e.Row.DataItem, "code postal du bien") + " " + DataBinder.Eval(e.Row.DataItem, "ville du bien") + "<div class = \"tooltip\"><span>";
                e.Row.Cells[6].Text += A + br + DataBinder.Eval(e.Row.DataItem, "code postal du bien") + " " + DataBinder.Eval(e.Row.DataItem, "ville du bien") + "</span></div>";
            }

            if (e.Row.Cells[16].Text != "0")
            {
                int prix = 0;
                if (refe.Substring(0, 1) == "V")
                    prix = (int)DataBinder.Eval(e.Row.DataItem, "prix de vente");   //prix total
                else if (refe.Substring(0, 1) == "L")
                    prix = (int)DataBinder.Eval(e.Row.DataItem, "loyer_cc"); //prix total
                int surface = int.Parse(e.Row.Cells[16].Text);

                //prix metre carre
                string prixFormat = espaceNombre((prix / surface).ToString());

                e.Row.Cells[14].Text = prixFormat + "€";
            }
            e.Row.Cells[5].Text = e.Row.Cells[5].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[5].Text + "</span></div>";
            e.Row.Cells[7].Text = e.Row.Cells[7].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[7].Text + "</span></div>";
            e.Row.Cells[9].Text = e.Row.Cells[9].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[9].Text + "</span></div>";
            e.Row.Cells[10].Text = e.Row.Cells[10].Text + "<div class = \"tooltip4\"><span>" + e.Row.Cells[10].Text + "<br/>" + DataBinder.Eval(e.Row.DataItem, "tel bureau vendeur") + "</span></div>";

            string shortMail = "";
            if (e.Row.Cells[11].Text.Length > 7) shortMail = e.Row.Cells[11].Text.Substring(0, 7) + "[...]";

            if (e.Row.Cells[11].Text != "&nbsp;")
                e.Row.Cells[11].Text = "<a href='mailto:" + e.Row.Cells[11].Text + "'>" + shortMail + "</a><div class = \"tooltip\"><span>" + e.Row.Cells[11].Text + "</span></div>";
            else
                e.Row.Cells[11].Text = "<div class = \"tooltip\"><span>Non renseigné</span></div>";
            //bug fix pour 1ere ligne vide pour le prix lors du changement de filtre vente/location
            e.Row.Cells[12].Text = espaceNombre(DataBinder.Eval(e.Row.DataItem, "loyer_cc").ToString()) + " €";
            e.Row.Cells[12].Text = e.Row.Cells[12].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[12].Text + "</span></div>";
            e.Row.Cells[13].Text = espaceNombre(DataBinder.Eval(e.Row.DataItem, "prix de vente").ToString()) + " €";
            e.Row.Cells[13].Text = e.Row.Cells[13].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[13].Text + "</span></div>";
            e.Row.Cells[14].Text = e.Row.Cells[14].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[14].Text + "</span></div>";

            e.Row.Cells[15].Text = e.Row.Cells[15].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[15].Text + "</span></div>";
            e.Row.Cells[16].Text = e.Row.Cells[16].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[16].Text + " m²</span></div>";
            e.Row.Cells[17].Text = e.Row.Cells[17].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[17].Text + " m²</span></div>";
            e.Row.Cells[18].Text = e.Row.Cells[18].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[18].Text + "</span></div>";
            e.Row.Cells[19].Text = e.Row.Cells[19].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[19].Text + "</span></div>";
            e.Row.Cells[21].Text = e.Row.Cells[21].Text.Replace(" ", "<br/>") + "<div class = \"tooltip\"><span>" + e.Row.Cells[21].Text + "</span></div>";
            if (e.Row.Cells[20].Text.Length > 8)
            {
                e.Row.Cells[20].Text = e.Row.Cells[20].Text.ToString().Substring(0, 7) + "<div class = \"tooltip\"><span>" + e.Row.Cells[20].Text + "</span></div>";
            }
            else
            {
                e.Row.Cells[20].Text = e.Row.Cells[20].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[20].Text + "</span></div>";
            }


            switch (couleur.ToLower())
            {
                case "dis":
                    e.Row.CssClass = "Disponible";
                    e.Row.Cells[4].Text = "Dis";
                    e.Row.Cells[4].Text = e.Row.Cells[4].Text + "<div class = \"tooltip\"><span>Disponible</span></div>";
                    break;

                case "off":
                    e.Row.CssClass = "Offre";
                    e.Row.Cells[4].Text = "Off";
                    e.Row.Cells[4].Text = e.Row.Cells[4].Text + "<div class = \"tooltip\"><span>Offre</span></div>";
                    break;

                case "sus":
                    switch (loue)
                    {
                        case "V":
                            e.Row.CssClass = "Suspendu";
                            e.Row.Cells[4].Text = "Sus";
                            e.Row.Cells[4].Text = e.Row.Cells[4].Text + "<div class = \"tooltip\"><span>Suspendu</span></div>";
                            break;
                        case "L":
                            //e.Row.CssClass = "SuspenduL";
                            e.Row.CssClass = "Suspendu";
                            e.Row.Cells[4].Text = "Sus";
                            e.Row.Cells[4].Text = e.Row.Cells[4].Text + "<div class = \"tooltip\"><span>Suspendu</span></div>";
                            break;
                    }
                    break;

                case "ret":
                    switch (loue)
                    {
                        case "V":
                            e.Row.CssClass = "Retire";
                            e.Row.Cells[4].Text = "Ret";
                            e.Row.Cells[4].Text = e.Row.Cells[4].Text + "<div class = \"tooltip\"><span>Retiré</span></div>";

                            break;
                        case "L":
                            e.Row.CssClass = "RetireL";
                            e.Row.Cells[4].Text = "Ret";
                            e.Row.Cells[4].Text = e.Row.Cells[4].Text + "<div class = \"tooltip\"><span>Retiré</span></div>";
                            break;
                    }
                    break;

                case "est":
                    string connectionString = "Dsn=patrimo";
                    OdbcConnection c3 = new OdbcConnection(connectionString);
                    OdbcDataReader reader;
                    OdbcCommand commande = new OdbcCommand("SELECT PubLocale FROM optionsBiens WHERE refOptions= ?", c3);
                    OdbcParameter paramRef = new OdbcParameter("@ref", DbType.String);
                    paramRef.Value = DataBinder.Eval(e.Row.DataItem, "ref");
                    commande.Parameters.Add(paramRef);
                    c3.Open();
                    reader = commande.ExecuteReader();
                    reader.Read();
                    if (reader["PubLocale"].ToString() == "True")
                    {
                        e.Row.CssClass = "PubLocale";
                        //e.Row.CssClass = "Estimation";
                        e.Row.Cells[4].Text = "Est";
                        e.Row.Cells[4].Text = e.Row.Cells[4].Text + "<div class = \"tooltip\"><span>Estimation Pub Locale</span></div>";
                    }
                    else
                    {
                        e.Row.CssClass = "Estimation";
                        e.Row.Cells[4].Text = "Est";
                        e.Row.Cells[4].Text = e.Row.Cells[4].Text + "<div class = \"tooltip\"><span>Estimation</span></div>";
                    }
                    reader.Close();
                    c3.Close();
                    break;

                case "com":
                    e.Row.CssClass = "Compromis";
                    e.Row.Cells[4].Text = "Com";
                    e.Row.Cells[4].Text = e.Row.Cells[4].Text + "<div class = \"tooltip\"><span>Compromis</span></div>";
                    break;

                case "lib":
                    e.Row.CssClass = "Libre";
                    e.Row.Cells[4].Text = "Lib";
                    e.Row.Cells[4].Text = e.Row.Cells[4].Text + "<div class = \"tooltip\"><span>Libre</span></div>";
                    break;

                case "occ":
                    e.Row.CssClass = "Occupe";
                    e.Row.Cells[4].Text = "Occ";
                    e.Row.Cells[4].Text = e.Row.Cells[4].Text + "<div class = \"tooltip\"><span>Occupé</span></div>";
                    break;

                case "lou":
                    e.Row.CssClass = "Loue";
                    e.Row.Cells[4].Text = "Lou";
                    e.Row.Cells[4].Text = e.Row.Cells[4].Text + "<div class = \"tooltip\"><span>Loué</span></div>";
                    break;

                case "opt":
                    e.Row.CssClass = "Option";
                    e.Row.Cells[4].Text = "Opt";
                    e.Row.Cells[4].Text = e.Row.Cells[4].Text + "<div class = \"tooltip\"><span>Option</span></div>";
                    break;

                default:
                    e.Row.CssClass = "Reserve";
                    e.Row.Cells[4].Text = "Rés";
                    e.Row.Cells[4].Text = e.Row.Cells[4].Text + "<div class = \"tooltip\"><span>Réservé</span></div>";
                    break;
            }
            //e.Row.Cells[25].CssClass = "";
            //e.Row.Cells[25].Text = e.Row.Cells[25].Text + "<div class = \"tooltip\"><span>Rouge = Coup de coeur, Jaune = Prestige et Vert = Neuf</span></div>";
        }
        if (ViewState["NbRecords"] == null)
        {
            LabelbnBiens.Text = "0";
        }
        LabelbnBiens.Text = ViewState["NbRecords"].ToString();

    }
    protected string affiche_prix(string surface, string prix)
    {
        string prixm = "";
        prix = prix.Trim();
        int pri = int.Parse(prix);
        int surf = int.Parse(surface);
        if (surf != 0)
        {
            int prim = pri / surf;
            prixm = prim.ToString();
            switch (prixm.Length)
            {
                case 4:
                    string pr1 = prixm;
                    pr1 = pr1.Remove(1, 3);
                    string p1 = prixm;
                    p1 = p1.Remove(0, 1);
                    prixm = pr1 + " " + p1 + " €";
                    break;

                case 5:
                    string pr2 = prixm;
                    pr2 = pr2.Remove(2, 3);
                    string p2 = prixm;
                    p2 = p2.Remove(0, 2);
                    prixm = pr2 + " " + p2 + " €";
                    break;

                case 6:
                    string pr3 = prixm;
                    pr3 = pr3.Remove(3, 3);
                    string p3 = prixm;
                    p3 = p3.Remove(0, 1);
                    prixm = pr3 + " " + p3 + " €";
                    break;

                default:
                    prixm = prixm + " €";
                    break;
            }
        }
        return prixm;
    }
    protected string affiche_photo(string text)
    {
        string stext = "";
        int sc = CheckNombrePhotos(text);
        switch (sc)
        {
            case 0:
                stext = "";
                break;
            case 1:
                stext = "../img_site/miniature_image.jpg";
                break;
            default:
                stext = "../img_site/miniature_multiples_images.png";
                break;
        }
        return stext;
    }
    protected string modifier_bien(string text)
    {
        Session["DropDownListChoixNegociateur"] = DropDownListNegociateur.SelectedValue;

        if (RadioButtonMesBiens.Checked)
        {
            Session["radioButtonMesBiens"] = RadioButtonMesBiens.Checked;
            Session["LastradioButtonMesBiens"] = true;
        }

        if (RadioButtonMonAgence.Checked)
        {

            String requette = "SELECT DISTINCT Clients.id_client, Clients.nom_client, Clients.prenom_client, Clients.num_agence FROM Biens LEFT JOIN Clients ON Biens.idclient = Clients.idclient GROUP BY Clients.id_client, Clients.nom_client, Clients.prenom_client, Clients.num_agence HAVING (((Clients.num_agence) <> '" + Session["NumAgence"] + "'))ORDER BY Clients.nom_client";
            System.Data.DataSet ds = null;
            Connexion c = null;
            c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c.Open();
            ds = c.exeRequette(requette);
            c.Close();
            c = null;

            System.Data.DataRowCollection dr = ds.Tables[0].Rows;
            foreach (System.Data.DataRow ligne in dr)
            {
                if (ligne["nom_client"].ToString().ToUpper() + " " + ligne["prenom_client"].ToString() == Session["DropDownListChoixNegociateur"].ToString())
                {
                    Session["DropDownListChoixNegociateur"] = "Tous";
                }
            }

            if ((bool)Session["LastradioButtonMesBiens"] == true)
            {
                Session["LastradioButtonMesBiens"] = false;
                Session["DropDownListChoixNegociateur"] = "Tous";
            }
            Session["radioButtonMonAgence"] = RadioButtonMonAgence.Checked;
        }

        if (RadioButtonTousLesBiens.Checked)
        {
            if ((bool)Session["LastradioButtonMesBiens"] == true)
            {
                Session["LastradioButtonMesBiens"] = false;
                Session["DropDownListChoixNegociateur"] = "Tous";
            }
            Session["radioButtonTousLesBiens"] = RadioButtonTousLesBiens.Checked;
        }
        string stext = "";
        if (text.Substring(0, 1) == "L")
        {
            stext = "<a href=\"modifier_nego_loc.aspx?reference=" + text + "\"><img class=\"croix_rouge\" src=\"../img_site/flat_round/modifier.png\" /></a>";
        }
        else
        {
            stext = "<a href=\"modifier_nego.aspx?reference=" + text + "\"><img class=\"croix_rouge\" src=\"../img_site/flat_round/modifier.png\" /></a>";
        }
        return stext;
    }
    protected String affiche_Mail(string mail)
    {
        string stext = "";
        stext = "<A HREF=mailto:" + mail + ">" + mail + "</A>";
        return stext;
    }
    protected string imgCdcPrestige(string img)
    {
        return img;
    }
    //bouton rechercher
    protected void Button1_Click_Tab(object sender, EventArgs e)
    {
        if (radioButtonAchat.Checked == true)
        {
            Session["Transaction"] = "achat";
        }
        else
        {
            Session["Transaction"] = "location";
        }

        Session["Smin"] = textBoxSurfaceMin.Text;
        Session["Smax"] = textBoxSurfaceMax.Text;
        Session["VilleRechercheAcq"] = textBoxVille.Text;
        Session["PaysRechercheAcq"] = textBoxPays.Text;
        Session["DepRechercheAcq"] = textBoxDep.Text;

        #region try...catch
        try
        {
            Session["lareferance"] = tbReferance.Text;
        }
        catch
        {
            Session["lareferance"] = "";
        }
        try
        {
            Session["leTelVendeur"] = TextBoxTelVendeur.Text;
        }
        catch
        {
            Session["leTelVendeur"] = "";
        }
        try
        {
            Session["NomVendeur"] = tbNomVendeur.Text;
        }
        catch
        {
            Session["NomVendeur"] = "";
        }
        try
        {
            Session["textBoxAdresseBien"] = textBoxAdresseBien.Text;
        }
        catch
        {
            Session["textBoxAdresseBien"] = "";
        }
        try
        {
            Session["textBoxMotCle1"] = textBoxMotCle1.Text;
        }
        catch
        {
            Session["textBoxMotCle1"] = " ";
        }

        try
        {
            Session["textBoxMotCle2"] = textBoxMotCle2.Text;
        }
        catch
        {
            Session["textBoxMotCle2"] = "";
        }

        try
        {
            Session["textBoxMotCle3"] = textBoxMotCle3.Text;
        }
        catch
        {
            Session["textBoxMotCle3"] = "";
        }
        try
        {
            Session["textBoxMotCle4"] = textBoxMotCle4.Text;
        }
        catch
        {
            Session["textBoxMotCle4"] = "";
        }
        try
        {
            Session["TextBoxMailVendeur"] = TextBoxMailVendeur.Text;
        }
        catch
        {
            Session["TextBoxMailVendeur"] = "";
        }
        try
        {
            Session["TextBoxBudgetMin"] = TextBoxBudgetMin.Text;
        }
        catch
        {
            Session["TextBoxBudgetMin"] = "";
        }
        try
        {
            Session["TextBoxBudgetMax"] = TextBoxBudgetMax.Text;
        }
        catch
        {
            Session["TextBoxBudgetMax"] = "";
        }
        try
        {
            Session["textBoxSurfaceMin"] = textBoxSurfaceMin.Text;
        }
        catch
        {
            Session["textBoxSurfaceMin"] = "";
        }
        try
        {
            Session["textBoxSurfaceMax"] = textBoxSurfaceMax.Text;
        }
        catch
        {
            Session["textBoxSurfaceMax"] = "";
        }
        try
        {
            Session["TextBoxSurfaceSMin"] = TextBoxSurfaceSMin.Text;
        }
        catch
        {
            Session["TextBoxSurfaceSMin"] = "";
        }
        try
        {
            Session["TextBoxSurfaceSMax"] = TextBoxSurfaceSMax.Text;
        }
        catch
        {
            Session["TextBoxSurfaceSMax"] = "";
        }
        try
        {
            Session["textBoxSurfaceTMin"] = textBoxSurfaceTMin.Text;
        }
        catch
        {
            Session["textBoxSurfaceTMin"] = "";
        }
        try
        {
            Session["textBoxSurfaceTMax"] = textBoxSurfaceTMax.Text;
        }
        catch
        {
            Session["textBoxSurfaceTMax"] = "";
        }
        try
        {
            var tempDate = textBoxDateCreationMin.Text; // 2012-10-22
            var tempDateParts = tempDate.Split('-'); // {"2012", "10", "22"}
            tempDate = string.Format("{0}/{1}/{2}", tempDateParts[2], tempDateParts[1], tempDateParts[0]); // 22/10/2012
            Session["textBoxDateCreationMin"] = tempDate;

        }
        catch
        {
            Session["textBoxDateCreationMin"] = "";
        }
        try
        {
            var tempDate = textBoxDateCreationMax.Text; // 2012-10-22
            var tempDateParts = tempDate.Split('-'); // {"2012", "10", "22"}
            tempDate = string.Format("{0}/{1}/{2}", tempDateParts[2], tempDateParts[1], tempDateParts[0]); // 22/10/2012
            Session["textBoxDateCreationMax"] = tempDate;
            //Session["textBoxDateCreationMax"] = textBoxDateCreationMax.Text;
        }
        catch
        {
            Session["textBoxDateCreationMax"] = "";
        }
        try
        {
            var tempDate = textBoxDateMajMin.Text; // 2012-10-22
            var tempDateParts = tempDate.Split('-'); // {"2012", "10", "22"}
            tempDate = string.Format("{0}/{1}/{2}", tempDateParts[2], tempDateParts[1], tempDateParts[0]); // 22/10/2012
            Session["textBoxDateMajMin"] = tempDate;

            //Session["textBoxDateMajMin"] = textBoxDateMajMin.Text;
        }
        catch
        {
            Session["textBoxDateMajMin"] = "";
        }
        try
        {
            var tempDate = textBoxDateMajMax.Text; // 2012-10-22
            var tempDateParts = tempDate.Split('-'); // {"2012", "10", "22"}
            tempDate = string.Format("{0}/{1}/{2}", tempDateParts[2], tempDateParts[1], tempDateParts[0]); // 22/10/2012
            Session["textBoxDateMajMax"] = tempDate;

            //Session["textBoxDateMajMax"] = textBoxDateMajMax.Text;
        }
        catch
        {
            Session["textBoxDateMajMax"] = "";
        }
        #endregion

        Session["radioButtonAchat"] = radioButtonAchat.Checked;
        Session["radioButtonLocation"] = radioButtonLocation.Checked;
        if (checkBoxAppart.Checked == true && checkBoxTerrain.Checked == true)
        {
            Session["checkBoxPiece1"] = checkBoxPiece1.Checked;
            Session["checkBoxPiece2"] = checkBoxPiece2.Checked;
            Session["checkBoxPiece3"] = checkBoxPiece3.Checked;
            Session["checkBoxPiece4"] = checkBoxPiece4.Checked;
            Session["checkBoxPiece5"] = checkBoxPiece5.Checked;

            Session["checkBoxChambre1"] = checkBoxChambre1.Checked;
            Session["checkBoxChambre2"] = checkBoxChambre2.Checked;
            Session["checkBoxChambre3"] = checkBoxChambre3.Checked;
            Session["checkBoxChambre4"] = checkBoxChambre4.Checked;
            Session["checkBoxChambre5"] = checkBoxChambre5.Checked;
        }
        if (radioButtonAchat.Checked)
        {
            Session["checkBoxEstimation"] = checkBoxEstimation.Checked;
            Session["checkBoxDisponible"] = checkBoxDisponible.Checked;
            Session["checkBoxOffre"] = checkBoxOffre.Checked;
            Session["checkBoxSuspendu"] = checkBoxSuspendu.Checked;
            Session["checkBoxRetire"] = checkBoxRetire.Checked;
            Session["checkBoxCompromis"] = checkBoxCompromis.Checked;
            Session["btnVente"] = ButtonVente.Visible;
        }
        else
        {
            Session["checkBoxLibre"] = checkBoxLibre.Checked;
            Session["checkBoxOccupe"] = checkBoxOccupe.Checked;
            Session["checkBoxLoue"] = checkBoxLoue.Checked;
            Session["checkBoxOption"] = checkBoxOption.Checked;
            Session["checkBoxReserve"] = checkBoxReserve.Checked;
            Session["checkBoxRet"] = checkBoxRet.Checked;
            Session["checkBoxSusp"] = checkBoxSusp.Checked;
            Session["btnLocation"] = ButtonLocation.Visible;
        }
        Session["DropDownListChoixNegociateur"] = DropDownListNegociateur.SelectedValue;
        Session["annoncesPage"] = DropDownListPageSize.SelectedValue;
        Session["DropDownListTypeMandat"] = DropDownListTypeMandat.SelectedValue;
        if (RadioButtonMesBiens.Checked)
        {
            Session["radioButtonMesBiens"] = RadioButtonMesBiens.Checked;
            Session["LastradioButtonMesBiens"] = true;
            Session["radioButtonMonAgence"] = false;
            Session["radioButtonTousLesBiens"] = false;
        }
        if (RadioButtonMonAgence.Checked)
        {
            Session["radioButtonMonAgence"] = RadioButtonMonAgence.Checked;
            Session["LastradioButtonMesBiens"] = false;
            Session["radioButtonMesBiens"] = false;
            Session["radioButtonTousLesBiens"] = false;
        }
        if (RadioButtonTousLesBiens.Checked)
        {
            Session["radioButtonTousLesBiens"] = RadioButtonTousLesBiens.Checked;
            Session["LastradioButtonMesBiens"] = false;
            Session["radioButtonMonAgence"] = false;
            Session["radioButtonMesBiens"] = false;
        }
        Session["checkBoxMaison"] = checkBoxMaison.Checked;
        Session["checkBoxAppart"] = checkBoxAppart.Checked;
        Session["checkBoxTerrain"] = checkBoxTerrain.Checked;
        Session["checkBoxAutre"] = checkBoxAutre.Checked;

        Session["chckBxCdC"] = chckBxCdC.Checked;
        Session["chckBxPrestige"] = chckBxPrestige.Checked;
        Session["chckBxMer"] = chckBxMer.Checked;
        Session["chckBxMontagne"] = chckBxMontagne.Checked;
        Session["ListeNeuf"] = ListeNeuf.SelectedIndex;

        BindData();
    }
    //bouton annuler
    protected void Annuler(object sender, EventArgs e)
    {

        if (radioButtonAchat.Checked == true)
        {
            Session["Transaction"] = "achat";


            radioButtonAchat.Checked = true;
            radioButtonLocation.Checked = false;


            // Achat
            checkBoxEstimation.Checked = true;
            checkBoxDisponible.Checked = true;
            checkBoxOffre.Checked = true;
            checkBoxSuspendu.Checked = true;
            checkBoxRetire.Checked = true;
            checkBoxCompromis.Checked = true;





        }
        else
            if (radioButtonLocation.Checked)
            {
                Session["Transaction"] = "location";
                radioButtonLocation.Checked = true;
                radioButtonAchat.Checked = false;
                // location
                checkBoxLibre.Checked = true;
                checkBoxOccupe.Checked = true;
                checkBoxLoue.Checked = true;
                checkBoxOption.Checked = true;
                checkBoxReserve.Checked = true;
                checkBoxRet.Checked = true;
                checkBoxSusp.Checked = true;
            }


        checkBoxPiece1.Checked = true;
        checkBoxPiece2.Checked = true;
        checkBoxPiece3.Checked = true;
        checkBoxPiece4.Checked = true;
        checkBoxPiece5.Checked = true;
        checkBoxChambre1.Checked = true;
        checkBoxChambre2.Checked = true;
        checkBoxChambre3.Checked = true;
        checkBoxChambre4.Checked = true;
        checkBoxChambre5.Checked = true;

        Session["Smin"] = "";
        Session["Smax"] = "";
        Session["Localisation"] = "";
        Session["lareferance"] = "";
        Session["leTelVendeur"] = "";
        Session["NomVendeur"] = "";
        Session["textBoxAdresseBien"] = "";
        Session["textBoxMotCle1"] = " ";
        Session["textBoxMotCle2"] = "";
        Session["textBoxMotCle3"] = "";
        Session["textBoxMotCle4"] = "";
        Session["TextBoxMailVendeur"] = "";
        Session["TextBoxBudgetMin"] = "";
        Session["TextBoxBudgetMax"] = "";
        Session["textBoxSurfaceMin"] = "";
        Session["textBoxSurfaceMax"] = "";
        Session["TextBoxSurfaceSMin"] = "";
        Session["TextBoxSurfaceSMax"] = "";
        Session["textBoxSurfaceTMin"] = "";
        Session["textBoxSurfaceTMax"] = "";
        Session["Smin"] = textBoxSurfaceMin.Text;
        Session["Smax"] = textBoxSurfaceMax.Text;
        Session["Localisation"] = "";

        TextBoxAdresseVendeur.Text = "";
        textBoxSurfaceMin.Text = "";
        textBoxSurfaceMax.Text = "";
        textBoxVille1.Text = "";
        textBoxVille.Text = "";
        textBoxPays.Text = "";
        textBoxDep.Text = "";
        TextBoxTelVendeur.Text = "";
        tbNomVendeur.Text = "";
        textBoxAdresseBien.Text = "";
        textBoxMotCle1.Text = "";
        textBoxMotCle2.Text = "";
        textBoxMotCle3.Text = "";
        textBoxMotCle4.Text = "";
        TextBoxMailVendeur.Text = "";
        TextBoxBudgetMin.Text = "";
        TextBoxBudgetMax.Text = "";
        textBoxSurfaceMin.Text = "";
        textBoxSurfaceMax.Text = "";
        TextBoxSurfaceSMin.Text = "";
        TextBoxSurfaceSMax.Text = "";
        textBoxSurfaceTMin.Text = "";
        textBoxSurfaceTMax.Text = "";
        tbReferance.Text = "";

        textBoxDateCreationMin.Text = "";
        textBoxDateCreationMax.Text = "";
        textBoxDateMajMin.Text = "";
        textBoxDateMajMax.Text = "";

        chckBxMer.Checked = false;
        chckBxMontagne.Checked = false;
        chckBxCdC.Checked = false;
        chckBxPrestige.Checked = false;

        checkBoxMaison.Checked = true;
        checkBoxAppart.Checked = true;
        checkBoxTerrain.Checked = true;
        checkBoxAutre.Checked = true;
    }
    //change la taille de la gridvieww
    protected void ItemChange(object sender, EventArgs e)
    {

        if ((((DropDownList)sender).SelectedValue).ToString() == "10")
        {
            GridView1.PageSize = 10;
            Session["annoncesPageT"] = 10;
        }
        if ((((DropDownList)sender).SelectedValue).ToString() == "20")
        {
            GridView1.PageSize = 20;
            Session["annoncesPageT"] = 20;
        }
        if ((((DropDownList)sender).SelectedValue).ToString() == "30")
        {
            GridView1.PageSize = 30;
            Session["annoncesPageT"] = 30;
        }
        if ((((DropDownList)sender).SelectedValue).ToString() == "50")
        {
            GridView1.PageSize = 50;
            Session["annoncesPageT"] = 50;
        }
        if ((((DropDownList)sender).SelectedValue).ToString() == "100")
        {
            GridView1.PageSize = 100;
            Session["annoncesPageT"] = 100;
        }
        BindData();
    }
    protected void Tout_Selectionner(object sender, EventArgs e)
    {
        CheckBox CheckBoxSelect = (CheckBox)sender;
        if (CheckBoxSelect.Checked)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox check = (CheckBox)row.FindControl("CheckBoxArchiver");
                check.Checked = true;
            }
        }
        else
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox check = (CheckBox)row.FindControl("CheckBoxArchiver");
                check.Checked = false;
            }
        }
    }
    //radiobutton achat
    protected void radio_button_check(object sender, EventArgs e)
    {
        RadioButton Achat = (RadioButton)sender;
        if (Achat.Checked)
        {
            radioButtonAchat.CssClass = "myButtonblue";
            radioButtonLocation.CssClass = "myButtonred";
            checkBoxEstimation.Checked = (bool)Session["checkBoxEstimation"];
            checkBoxDisponible.Checked = (bool)Session["checkBoxDisponible"];
            checkBoxOffre.Checked = (bool)Session["checkBoxOffre"];
            checkBoxSuspendu.Checked = (bool)Session["checkBoxSuspendu"];
            checkBoxRetire.Checked = (bool)Session["checkBoxRetire"];
            checkBoxCompromis.Checked = (bool)Session["checkBoxCompromis"];
            Session["typeTransaction"] = true;
            // On nettoie la liste
            DropDownList1.Items.Clear();
            // Rajout de la première ligne 
            DropDownList1.Items.Add(new ListItem("", ""));
            // Remplissage de la liste
            Remplir_DDL_Acq(sender, e);
            ButtonVente.Visible = true;
            ButtonLocation.Visible = false;

        }
        //Session["TypeTransaaction"] = "V";
        BindData();
    }

    //radiobutton location
    protected void radio_button_checkb(object sender, EventArgs e)
    {
        RadioButton Location = (RadioButton)sender;
        if (Location.Checked)
        {
            radioButtonAchat.CssClass = "myButtonred";
            radioButtonLocation.CssClass = "myButtonblue";
            checkBoxLibre.Checked = (bool)Session["checkBoxLibre"];
            checkBoxOccupe.Checked = (bool)Session["checkBoxOccupe"];
            checkBoxLoue.Checked = (bool)Session["checkBoxLoue"];
            checkBoxOption.Checked = (bool)Session["checkBoxOption"];
            checkBoxReserve.Checked = (bool)Session["checkBoxReserve"];
            checkBoxRet.Checked = (bool)Session["checkBoxRet"];
            checkBoxSusp.Checked = (bool)Session["checkBoxSusp"];
            DropDownList1.Items.Clear();
            DropDownList1.Items.Add(new ListItem("", ""));
            Remplir_DDL_Acq(sender, e);
            ButtonVente.Visible = false;
            ButtonLocation.Visible = true;

        }
        //Session["TypeTransaaction"] = "L";
        BindData();
    }
    protected void Ajouterunbien(object sender, EventArgs e)
    {
        if (radioButtonAchat.Checked)
        {
            Response.Redirect("./ajout_nego.aspx");
        }
        else { Response.Redirect("./ajout_nego_loc.aspx"); }
    }
    protected void Voir_Historique(object sender, EventArgs e)
    {
        String selectedValue = Request.Form["MyRadioButton"];
        Session["idbien"] = selectedValue;
        if ((String)Session["idbien"] == null)
        {
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "veuillez sélectionner un radio bouton";
        }
        else
        {
            Response.Redirect("./historique_visite.aspx");
        }
    }
    protected void Button_Avenant(object sender, EventArgs e)
    {
        Session["ref_sel"] = "";
        string selectedValue = Request.Form["MyRadioButton"];
        if (selectedValue == null)
        {
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "Veuillez sélectionner un bien dans la colonne \"Choisir une ligne\"";
        }
        else
        {
            Session["ref_sel"] = selectedValue;


            Response.Write("<script language=javascript> window.open( 'Avenant.aspx'); </script> ");
        }
    }

    //Créer un bon de visite
    protected void Bon_De_Visite(object sender, EventArgs e)
    {
        //ComboBox1.Items.Clear();

        //On ajoute la valeur de la référence du bien dans la variable de session ref_sel
        Session["ref_sel"] = "";
        Session["acq_sel"] = DropDownList1.SelectedValue.ToString();

        // Session["acq_sel"] = ComboBox1.SelectedValue.ToString();
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox check = (CheckBox)row.FindControl("CheckBoxArchiver");
            var selectedKey = GridView1.DataKeys[row.RowIndex].Value.ToString();
            if (check.Checked)
            {
                if ((String)Session["ref_sel"] == "")
                {
                    Session["ref_sel"] = selectedKey;
                }
                else
                {
                    Session["ref_sel"] = Session["ref_sel"] + ";" + selectedKey;
                }
            }
        }

        if ((String)Session["ref_sel"] == "" || DropDownList1.SelectedValue == "")
        //if ((String)Session["ref_sel"] == "" || ComboBox1.SelectedValue == "")
        {
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "veuillez sélectionnez au moins un bien grâce aux checkbox et un acquereur";
        }
        else
        {
            //On recupere la liste des biens dans la variable de session
            Membre member = (Membre)Session["Membre"];
            string requete2 = "";
            int i = 0;
            string Ref = (string)Session["ref_sel"];
            string[] WordArray;
            string[] stringSeparators = new string[] { ";" };
            WordArray = Ref.Split(stringSeparators, StringSplitOptions.None);
            i = 0;
            //On ajoute dans la base
            if (WordArray.Length >= 1)
            {
                while (i < WordArray.Length)
                {
                    requete2 = "SELECT TOP 1 id_visite from visite Order By id_visite DESC";

                    using (OdbcConnection db =
                    new OdbcConnection(_ConnectionString))
                    {
                        // Create the Command and Parameter objects.
                        OdbcCommand command = new OdbcCommand(requete2, db);
                        OdbcCommand insert = new OdbcCommand();
                        insert.CommandType = System.Data.CommandType.Text;
                        insert.Connection = db;

                        // Open the connection in a try/catch block. 
                        // Create and execute the DataReader, writing the result
                        // set to the console window.

                        db.Open();
                        OdbcDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string num = "" + (String)reader[0] + "";
                            int numinc = Convert.ToInt32(num) + 1;
                            string numincrémenter = Convert.ToString(numinc);

                            insert.CommandText = " INSERT INTO visite("
                        + "`id_visite`,"
                        + "`id_bien`,"
                        + "`acquereur`,"
                        + "`idclient`,"
                        + "`actif`,"
                        + "`date_visite`)"
                        + "values('" + numincrémenter + "','"
                        + WordArray[i] + "','"
                        + DropDownList1.SelectedValue + "','"
                                //+ ComboBox1.SelectedValue + "','"
                        + member.IDCLIENT + "','"
                        + "actif" + "','"
                        + DateTime.Now.ToString() + "'"
                        + ")";
                            insert.ExecuteNonQuery();
                        }
                        reader.Close();
                        db.Close();
                        i++;
                    }
                    LabelErrorLogin.Visible = false;
                }
                //On va directement sur le bon de visite sans enregistrer
                Response.Write("<script language=javascript> window.open( 'bon_de_visite.aspx'); </script>");
            }

        }

    }

    protected void Mandat(object sender, EventArgs e)
    {
        Session["idmandat"] = Request.Form["MyRadioButton"];
        if (Session["idmandat"] == null)
        {
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "veuillez sélectionnez un bien grâce aux radio boutons";
        }
        else
        {
            string Ref = (string)Session["idmandat"];
            String requette2 = "select `type mandat` from biens where `ref`='" + Ref + "'";
            System.Data.DataSet ds2 = null;
            Connexion c2 = null;

            c2 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c2.Open();
            ds2 = c2.exeRequette(requette2);
            c2.Close();
            c2 = null;
            String TypeMandat = ds2.Tables[0].Rows[0]["type mandat"].ToString();
            if (Ref.Contains("V"))
            {
                if (TypeMandat == "Simple")
                {
                    Response.Write("<script language=javascript> window.open( 'MandatSimple.aspx'); </script> ");
                }
                if (TypeMandat == "SemiExclusif")
                {
                    Response.Write("<script language=javascript> window.open( 'MandatSemiExclusif.aspx'); </script> ");
                }
                if (TypeMandat == "Exclusif")
                {
                    Response.Write("<script language=javascript> window.open( 'MandatExclusif.aspx'); </script> ");
                }
                if (TypeMandat == "Confiance")
                {
                    Response.Write("<script language=javascript> window.open( 'MandatConfiance.aspx'); </script> ");
                }
            }
            else
            {
                if (TypeMandat == "Simple")
                {
                    Response.Write("<script language=javascript> window.open( 'MandatSimpleLocation.aspx'); </script> ");
                }
                if (TypeMandat == "SemiExclusif")
                {
                    Response.Write("<script language=javascript> window.open( 'MandatSemiExclusifLocation.aspx'); </script> ");
                }
                if (TypeMandat == "Exclusif")
                {
                    Response.Write("<script language=javascript> window.open( 'MandatExclusifLocation.aspx'); </script> ");
                }
                if (TypeMandat == "Confiance")
                {
                    Response.Write("<script language=javascript> window.open( 'MandatConfianceLocation.aspx'); </script> ");
                }
            }
        }
    }

    protected void Mandatencours(object sender, EventArgs e)
    {
        Session["idmandat"] = Request.Form["MyRadioButton"];
        if (Session["idmandat"] == null)
        {
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "veuillez sélectionnez un bien grâce aux radio boutons";
        }
        else
        {
            string Ref = (string)Session["idmandat"];
            String requette2 = "Select * from Environnement";
            System.Data.DataSet ds2 = null;
            Connexion c2 = null;

            c2 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c2.Open();
            ds2 = c2.exeRequette(requette2);
            c2.Close();
            c2 = null;

            String racine_site = (String)ds2.Tables[0].Rows[0]["Chemin_racine_site"];
            String Mandatfile = racine_site + "Mandats\\" + Ref + ".pdf";
            string MandFile = "../Mandats/" + Ref + ".pdf";

            if (System.IO.File.Exists(Mandatfile))
            {
                Response.Write("<script>");
                Response.Write("window.open('" + MandFile + "', '_newtab');");
                Response.Write("</script>");
            }
            else
            {
                LabelErrorLogin.Visible = true;
                LabelErrorLogin.Text = "Il n'y a pas de mandat pour ce bien.";
            }
        }

    }

    protected void Dupliquer(object sender, EventArgs e)
    {
        String selectedValue = Request.Form["MyRadioButton"];
        Session["idbien"] = selectedValue;
        if ((String)Session["idbien"] == null)
        {
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "veuillez sélectionnez un bien grâce aux radio boutons";
        }
        else
        {
            string refe = "";
            if (selectedValue.Contains("V"))
            {
                refe = "V001";
            }
            else { refe = "L001"; }

            String pre_requete = " ";
            Connexion c0 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c0.Open();
            System.Data.DataSet ds2 = c0.exeRequette("SELECT MAX(id_bien) as id_bien1 from Biens");
            c0.Close();
            //Connexion cref = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //cref.Open();
            ////System.Data.DataSet ds2 = c0.exeRequette("SELECT MAX(id_bien) as id_bien1 from Biens");
            //System.Data.DataSet dsref = cref.exeRequette("SELECT ref FROM Biens");
            //cref.Close();

            //int[] reflast4;
            //reflast4 = new int[(int)dsref.Tables[0].Rows.Count];
            //for (int i = 0; i < (int)dsref.Tables[0].Rows.Count; i++)
            //{
            //    reflast4[i] = (int)dsref.Tables[0].Rows[i]["ref"];
            //}
            //int refmax = reflast4.Max();

            ////int refmax = (int)dsref.Tables[0].Compute("Max(ref1)","");
            //int id_bienmax = (int)ds2.Tables[0].Rows[0]["id_bien1"];

            //int id_bien = Math.Max(refmax, id_bienmax);
            int id_bien = (int)ds2.Tables[0].Rows[0]["id_bien1"];
            id_bien = id_bien + 1;
            refe = refe + id_bien;
            String requette = "select * from Biens where Biens.[ref]='" + selectedValue + "'";
            System.Data.DataSet ds = null;
            Connexion c = null;

            c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c.Open();
            ds = c.exeRequette(requette);
            c.Close();
            c = null;

            System.Data.DataRowCollection dr = ds.Tables[0].Rows;

            string texteadressebien = "";
            string texteinternet = "";
            string textepubli = "";
            string textemailing = "";
            string texteadressevendeur = "";

            foreach (System.Data.DataRow ligne in dr)
            {
                try
                {
                    texteadressebien = ligne["adresse du bien"].ToString();
                    texteadressebien = texteadressebien.Replace("'", "''");
                }
                catch { texteadressebien = ligne["adresse du bien"].ToString(); }

                try
                {
                    texteinternet = ligne["texte internet"].ToString();
                    texteinternet = texteinternet.Replace("'", "''");
                }
                catch { texteinternet = ligne["texte internet"].ToString(); }

                try
                {
                    textepubli = ligne["texte publicité"].ToString();
                    textepubli = textepubli.Replace("'", "''");
                }
                catch { textepubli = ligne["texte publicité"].ToString(); }

                try
                {
                    textemailing = ligne["texte mailing"].ToString();
                    textemailing = textemailing.Replace("'", "''");
                }
                catch { textemailing = ligne["texte mailing"].ToString(); }

                try
                {
                    texteadressevendeur = ligne["adresse vendeur"].ToString();
                    texteadressevendeur = texteadressevendeur.Replace("'", "''");
                }
                catch { texteadressevendeur = ligne["adresse vendeur"].ToString(); }

                //Validation des champs pour les valeurs nulls 
                if (ligne["prix de vente"].ToString().Trim() == "")
                {
                    ligne["prix de vente"] = 0;
                }
                if (ligne["net vendeur"].ToString().Trim() == "")
                {
                    ligne["net vendeur"] = 0;
                }
                if (ligne["honoraires"].ToString().Trim() == "")
                {
                    ligne["honoraires"] = 0;
                }
                if (ligne["prix estimé"].ToString().Trim() == "")
                {
                    ligne["prix estimé"] = 0;
                }
                if (ligne["travaux"].ToString().Trim() == "")
                {
                    ligne["travaux"] = 0;
                }
                if (ligne["num_mandat"].ToString().Trim() == "")
                {
                    ligne["num_mandat"] = 0;
                }
                if (ligne["nombre de pieces"].ToString().Trim() == "")
                {
                    ligne["nombre de pieces"] = 0;
                }
                if (ligne["nombre de chambres"].ToString().Trim() == "")
                {
                    ligne["nombre de chambres"] = 0;
                }
                if (ligne["surface habitable"].ToString().Trim() == "")
                {
                    ligne["surface habitable"] = 0;
                }
                if (ligne["surface carrez"].ToString().Trim() == "")
                {
                    ligne["surface carrez"] = 0;
                }
                if (ligne["surface séjour"].ToString().Trim() == "")
                {
                    ligne["surface séjour"] = 0;
                }
                if (ligne["surface terrain"].ToString().Trim() == "")
                {
                    ligne["surface terrain"] = 0;
                }
                if (ligne["etage"].ToString().Trim() == "")
                {
                    ligne["etage"] = 0;
                }
                if (ligne["loyer_hc"].ToString().Trim() == "")
                {
                    ligne["loyer_hc"] = 0;
                }
                if (ligne["loyer_cc"].ToString().Trim() == "")
                {
                    ligne["loyer_cc"] = 0;
                }
                if (ligne["depot_guarantie"].ToString().Trim() == "")
                {
                    ligne["depot_guarantie"] = 0;
                }
                if (ligne["nombre_conso"].ToString().Trim() == "")
                {
                    ligne["nombre_conso"] = 0;
                }
                if (ligne["nombre_energie"].ToString().Trim() == "")
                {
                    ligne["nombre_energie"] = 0;
                }
                if (ligne["numero_cles"].ToString().Trim() == "")
                {
                    ligne["numero_cles"] = 0;
                }

                #region Ecriture de la requete
                String requete = " INSERT INTO Biens ("
                            + "[code_client], "
                            + "[ref], "
                            + "[num], "
                            + "[type de bien], "
                            + "[etat], "
                            + "[negociateur], "
                            + "[idclient], "
                            + "[prix de vente], "
                            + "[net vendeur], "
                            + "[honoraires], "
                            + "[prix estimé], "
                            + "[travaux], "
                            + "[taxe fonciere], "
                            + "[taxe habitation], "
                            + "[charges], "
                            + "[etat civil vendeur], "
                            + "[nom vendeur], "
                            + "[prenom vendeur], "
                            + "[adresse vendeur], "
                            + "[code postal vendeur], "
                            + "[ville vendeur], "
                            + "[pays vendeur], "
                            + "[tel domicile vendeur], "
                            + "[tel bureau vendeur], "
                            + "[num_mandat], "
                            + "[adresse mail vendeur], "
                            + "[type mandat], "
                            + "[date dossier], "
                            + "[date modification], "
                            + "[disponibilité], "
                            + "[montant loyer], "
                            + "[adresse du bien], "
                            + "[code postal du bien], "
                            + "[ville du bien], "
                            + "[localisation du bien], "
                            + "[categorie], "
                            + "[nombre de pieces], "
                            + "[nombre de chambres], "
                            + "[surface habitable], "
                            + "[surface carrez], "
                            + "[surface séjour], "
                            + "[surface terrain], "
                            + "[exposition sejour], "
                            + "[etage], "
                            + "[code etage], "
                            + "[nombre etages], "
                            + "[annee construction], "
                            + "[type cuisine], "
                            + "[nombre wc], "
                            + "[nombre salles de bain], "
                            + "[nombre salles eau], "
                            + "[nombre parkings interieurs], "
                            + "[nombre parkings exterieurs], "
                            + "[nombre garages], "
                            + "[type sous-sol], "
                            + "[nombre de caves], "
                            + "[type chauffage], "
                            + "[nature chauffage], "
                            + "[ascenceur], "
                            + "[balcon], "
                            + "[terrasse], "
                            + "[nombre de murs mitoyens], "
                            + "[facade terrain], "
                            + "[profondeur terrain], "
                            + "[cos terrain], "
                            + "[shon terrain], "
                            + "[eau], "
                            + "[gaz], "
                            + "[electricite], "
                            + "[tout egout], "
                            + "[lotissement], "
                            + "[num_lotissement], "
                            + "[alignement], "
                            + "[texte internet], "
                            + "[texte publicité], "
                            + "[texte mailing], "
                            + "[raison sociale agence], "
                            + "[adresse agence], "
                            + "[code postal agence], "
                            + "[ville agence], "
                            + "[telephone agence], "
                            + "[telecopie agence], "
                            + "[email agence], "
                            + "[actif], "
                            + "[date_maj], "
                            + "[num_lot], "
                            + "[ref_proprio], "
                            + "[residence], "
                            + "[proximite], "
                            + "[quartier], "
                            + "[transport], "
                            + "[loyer_hc], "
                            + "[loyer_cc], "
                            + "[depot_guarantie], "
                            + "[meuble], "
                            + "[lettre_conso], "
                            + "[nombre_conso], "
                            + "[lettre_energie], "
                            + "[nombre_energie], "
                            + "[ville_internet], "
                            + "[cp_internet], "
                            + "[nom_syndic], "
                            + "[ville_syndic], "
                            + "[tel_syndic], "
                            + "[fax_syndic], "
                            + "[mail_syndic], "
                            + "[numero_cles],"
                            + "[texte_syndic] )"
                            + " values('"
                            + ligne["code_client"] + "', '"
                            + refe + "', '"
                            + ligne["num"] + "', '"
                            + ligne["type de bien"] + "', '"
                            + ligne["etat"] + "', '"
                            + ligne["negociateur"] + "', "
                            + ligne["idclient"] + ", "
                            + ligne["prix de vente"] + ", "
                            + ligne["net vendeur"] + ", "
                            + ligne["honoraires"] + ", "
                            + ligne["prix estimé"] + ", "
                            + ligne["travaux"] + ", '"
                            + ligne["taxe fonciere"] + "', '"
                            + ligne["taxe habitation"] + "', '"
                            + ligne["charges"] + "', '"
                            + ligne["etat civil vendeur"] + "', '"
                            + ligne["nom vendeur"] + "', '"
                            + ligne["prenom vendeur"] + "', '"
                            + texteadressevendeur + "', '"
                            + ligne["code postal vendeur"] + "', '"
                            + ligne["ville vendeur"] + "', '"
                            + ligne["pays vendeur"] + "', '"
                            + ligne["tel domicile vendeur"] + "', '"
                            + ligne["tel bureau vendeur"] + "', "
                            + ligne["num_mandat"] + ", '"
                            + ligne["adresse mail vendeur"] + "', '"
                            + ligne["type mandat"] + "', '"
                            + DateTime.Now.ToString() + "', '"
                            + DateTime.Now.ToString() + "', '"
                            + ligne["disponibilité"] + "', '"
                            + ligne["montant loyer"] + "', '"
                            + texteadressebien + "', '"
                            + ligne["code postal du bien"] + "', '"
                            + ligne["ville du bien"] + "', '"
                            + ligne["localisation du bien"] + "', '"
                            + ligne["categorie"] + "', "
                            + ligne["nombre de pieces"] + ", "
                            + ligne["nombre de chambres"] + ", "
                            + ligne["surface habitable"] + ", "
                            + ligne["surface carrez"] + ", "
                            + ligne["surface séjour"] + ", "
                            + ligne["surface terrain"] + ", '"
                            + ligne["exposition sejour"] + "', "
                            + ligne["etage"] + ", '"
                            + ligne["code etage"] + "', '"
                            + ligne["nombre etages"] + "', '"
                            + ligne["annee construction"] + "', '"
                            + ligne["type cuisine"] + "', '"
                            + ligne["nombre wc"] + "', '"
                            + ligne["nombre salles de bain"] + "', '"
                            + ligne["nombre salles eau"] + "', '"
                            + ligne["nombre parkings interieurs"] + "', '"
                            + ligne["nombre parkings exterieurs"] + "', '"
                            + ligne["nombre garages"] + "', '"
                            + ligne["type sous-sol"] + "', '"
                            + ligne["nombre de caves"] + "', '"
                            + ligne["type chauffage"] + "', '"
                            + ligne["nature chauffage"] + "', '"
                            + ligne["ascenceur"] + "', '"
                            + ligne["balcon"] + "', '"
                            + ligne["terrasse"] + "', '"
                            + ligne["nombre de murs mitoyens"] + "', '"
                            + ligne["facade terrain"] + "', '"
                            + ligne["profondeur terrain"] + "', '"
                            + ligne["cos terrain"] + "', '"
                            + ligne["shon terrain"] + "', '"
                            + ligne["eau"] + "', '"
                            + ligne["gaz"] + "', '"
                            + ligne["electricite"] + "', '"
                            + ligne["tout egout"] + "', '"
                            + ligne["lotissement"] + "', '"
                            + ligne["num_lotissement"] + "', '"
                            + ligne["alignement"] + "', '"
                            + texteinternet + "', '"
                            + textepubli + "', '"
                            + textemailing + "', '"
                            + ligne["raison sociale agence"] + "', '"
                            + ligne["adresse agence"] + "', '"
                            + ligne["code postal agence"] + "', '"
                            + ligne["ville agence"] + "', '"
                            + ligne["telephone agence"] + "', '"
                            + ligne["telecopie agence"] + "', '"
                            + ligne["email agence"] + "', '"
                            + ligne["actif"] + "', '"
                            + DateTime.Today.ToString() + "', '"
                            + ligne["num_lot"] + "', '"
                            + ligne["ref_proprio"] + "', '"
                            + ligne["residence"] + "', '"
                            + ligne["proximite"] + "', '"
                            + ligne["quartier"] + "', '"
                            + ligne["transport"] + "', "
                            + ligne["loyer_hc"] + ", "
                            + ligne["loyer_cc"] + ","
                            + ligne["depot_guarantie"] + ", '"
                            + ligne["meuble"] + "', '"
                            + ligne["lettre_conso"] + "',"
                            + ligne["nombre_conso"] + ", '"
                            + ligne["lettre_energie"] + "', "
                            + ligne["nombre_energie"] + ", '"
                            + ligne["ville_internet"] + "', '"
                            + ligne["cp_internet"] + "', '"
                            + ligne["nom_syndic"] + "', '"
                            + ligne["ville_syndic"] + "', '"
                            + ligne["tel_syndic"] + "', '"
                            + ligne["fax_syndic"] + "', '"
                            + ligne["mail_syndic"] + "',"
                            + ligne["numero_cles"] + ", '"
                            + ligne["texte_syndic"] + "' "
                            + ")";
                #endregion

                System.Data.DataSet ds3 = null;
                Connexion c1 = null;

                c1 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                c1.Open();
                ds3 = c1.exeRequette(requete);
                c1.Close();
                c1 = null;
            }

            String requette4 = "select * from optionsBiens where optionsBiens.[refOptions]='" + selectedValue + "'";
            System.Data.DataSet ds4 = null;
            Connexion c2 = null;

            c2 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c2.Open();
            ds4 = c2.exeRequette(requette4);
            c2.Close();
            c2 = null;

            System.Data.DataRowCollection dr2 = ds4.Tables[requette4].Rows;


            foreach (System.Data.DataRow ligne in dr2)
            {

                if (ligne["AncienPrix"].ToString().Trim() == "")
                {
                    ligne["AncienPrix"] = 0;
                }

                String requete2 = " INSERT INTO optionsBiens ("
                            + "[refOptions], "
                            + "[CoupDeCoeur], "
                            + "[Prestige],"
                            + "[Mer], "
                            + "[Montagne],"
                            + "[AncienPrix],"
                            + "[Neuf],"
                            + "[PubLocale],"
                            + "[PaysBien],"
                            + "[urlVideo])"
                            + " values('"
                            + refe + "', "
                            + ligne["CoupDeCoeur"] + ", "
                            + ligne["Prestige"] + ", "
                            + ligne["Mer"] + ", "
                            + ligne["Montagne"] + ", "
                            + ligne["AncienPrix"] + ", "
                            + ligne["Neuf"] + ", "
                            + ligne["PubLocale"] + ", "
                            + "'" + ligne["PaysBien"] + "', "
                            + "'" + ligne["urlVideo"] + "' "
                            + ")";

                System.Data.DataSet ds5 = null;
                Connexion c3 = null;

                c3 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                c3.Open();
                ds5 = c3.exeRequette(requete2);
                c3.Close();
                c3 = null;
            }

            Connexion cI = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            cI.Open();
            System.Data.DataSet dsI = cI.exeRequette("Select * from Environnement");
            cI.Close();
            String racine_site = (String)dsI.Tables[0].Rows[0]["Chemin_racine_site"];

            string[] tabImage = { "A", "B", "C", "D", "E", "F", "G", "H" };

            foreach (string imageID in tabImage)
            {
                String Image = racine_site + "images\\" + selectedValue + imageID + ".jpg";
                if (System.IO.File.Exists(Image))
                    System.IO.File.Copy(Image, racine_site + "images\\" + refe + imageID + ".jpg");
            }

            String mandat = racine_site + "Mandats\\" + selectedValue + ".pdf";
            if (System.IO.File.Exists(mandat))
                System.IO.File.Copy(mandat, racine_site + "Mandats\\" + refe + ".pdf");

            Response.Redirect("./moncomptetableaudebord_bis.aspx");
        }
    }

    //à chaque changement des dropdownlist ou radiobutton cette fonction est appelée
    protected void charge_page(object sender, EventArgs e)
    {
        //aqui es en donde se tiene que guardar los valores del droplist el valor como tal y el texto
        Session["DropDownListChoixNegociateurText"] = DropDownListNegociateur.Items.FindByValue(DropDownListNegociateur.SelectedValue);
        Session["DropDownListChoixNegociateurValue"] = DropDownListNegociateur.SelectedValue;
        DropDownListNegociateur.Items.FindByValue(DropDownListNegociateur.SelectedValue);
        //Session["DropDownListChoixNegociateur"] = DropDownListNegociateur.SelectedValue;
        Session["DropDownListChoixNegociateur"] = DropDownListNegociateur.SelectedValue;

        if (RadioButtonMesBiens.Checked)
        {
            Session["radioButtonMesBiens"] = RadioButtonMesBiens.Checked;
            Session["LastradioButtonMesBiens"] = true;
            Session["radioButtonMonAgence"] = false;
            Session["radioButtonTousLesBiens"] = false;
        }

        if (RadioButtonMonAgence.Checked)
        {

            String requette = "SELECT DISTINCT Clients.id_client, Clients.nom_client, Clients.prenom_client, Clients.num_agence FROM Biens LEFT JOIN Clients ON Biens.idclient = Clients.idclient GROUP BY Clients.id_client, Clients.nom_client, Clients.prenom_client, Clients.num_agence HAVING (((Clients.num_agence) <> '" + Session["NumAgence"] + "'))ORDER BY Clients.nom_client";

            System.Data.DataSet ds = null;
            Connexion c = null;
            c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c.Open();
            ds = c.exeRequette(requette);
            c.Close();
            c = null;

            System.Data.DataRowCollection dr = ds.Tables[0].Rows;
            foreach (System.Data.DataRow ligne in dr)
            {
                if (ligne["nom_client"].ToString().ToUpper() + " " + ligne["prenom_client"].ToString() == Session["DropDownListChoixNegociateur"].ToString())
                {
                    Session["DropDownListChoixNegociateur"] = "Tous";
                }
            }

            if ((bool)Session["LastradioButtonMesBiens"] == true)
            {
                Session["LastradioButtonMesBiens"] = false;
                Session["DropDownListChoixNegociateur"] = "Tous";
            }
            Session["radioButtonMonAgence"] = RadioButtonMonAgence.Checked;
            Session["radioButtonMesBiens"] = false;
            Session["radioButtonTousLesBiens"] = false;

        }

        if (RadioButtonTousLesBiens.Checked)
        {
            if ((bool)Session["LastradioButtonMesBiens"] == true)
            {
                Session["LastradioButtonMesBiens"] = false;
                //cambiar el valor cuando se entra a este boton lo que hace es seleccionar el valor de todos los datos 
                Session["DropDownListChoixNegociateur"] = "Tous";
                Session["DropDownListChoixNegociateurText"] = "Tous";
                Session["DropDownListChoixNegociateurValue"] = "0";
            }
            Session["radioButtonTousLesBiens"] = RadioButtonTousLesBiens.Checked;
            Session["radioButtonMesBiens"] = false;
            Session["radioButtonMonAgence"] = false;

            Session["DropDownListChoixNegociateurSelect"] = DropDownListNegociateur.Text;
            //int val = DropDownListNegociateur.SelectedIndex;

        }

        BindData();
    }

    protected void Ajout_Acq(object sender, EventArgs e)
    {
        Response.Redirect("./ajout_acquereur.aspx");
    }

    protected void fichecommerciale_click(object sender, EventArgs e)
    {
        Session["ref_sel"] = "";
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox check = (CheckBox)row.FindControl("CheckBoxArchiver");
            var selectedKey = GridView1.DataKeys[row.RowIndex].Value.ToString();
            if (check.Checked)
            {
                if ((String)Session["ref_sel"] == "")
                {
                    Session["ref_sel"] = selectedKey;
                }
                else
                {
                    Session["ref_sel"] = Session["ref_sel"] + ";" + selectedKey;
                }
            }
        }
        if ((String)Session["ref_sel"] == "")
        {
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "veuillez sélectionnez au moins un bien grâce aux checkbox";
        }
        else
        {
            Membre member = (Membre)Session["Membre"];
            int i = 0;
            string Ref = (string)Session["ref_sel"];
            string[] WordArray;
            string[] stringSeparators = new string[] { ";" };
            WordArray = Ref.Split(stringSeparators, StringSplitOptions.None);
            i = 0;
            //On ajoute dans la base
            if (WordArray.Length >= 1)
            {
                while (i < WordArray.Length)
                {
                    string refe = WordArray[i];
                    // Response.Redirect("./ficheCommerciale.aspx");

                    Response.Write("<script language=javascript> window.open( 'ficheCommerciale.aspx?refsepare=" + refe + "'); </script> ");
                    i++;
                }
                LabelErrorLogin.Visible = false;
            }
        }
    }
    protected void Listaffaires_click(object sender, EventArgs e)
    {
        Session["ref_sel"] = "";
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox check = (CheckBox)row.FindControl("CheckBoxArchiver");
            var selectedKey = GridView1.DataKeys[row.RowIndex].Value.ToString();
            if (check.Checked)
            {
                if ((String)Session["ref_sel"] == "")
                {
                    Session["ref_sel"] = selectedKey;
                }
                else
                {
                    Session["ref_sel"] = Session["ref_sel"] + ";" + selectedKey;
                }
            }
        }
        if ((String)Session["ref_sel"] == "")
        {
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "veuillez sélectionnez au moins un bien grâce aux checkbox";
        }
        else
        {
            LabelErrorLogin.Visible = false;
            //Response.Redirect("./listAffaires.aspx");
            Response.Write("<script language=javascript> window.open( './listAffaires.aspx'); </script> ");
        }
    }
    protected void avenant_clicke(object sender, EventArgs e)
    {
        String selectedValue = Request.Form["MyRadioButton"];
        Session["idbien"] = selectedValue;
        if ((String)Session["idbien"] == null)
        {
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "veuillez sélectionner un radio bouton";
        }
        else
        {
            Response.Redirect("./Avenant.aspx");
        }
    }
    protected void fichenegociateur_click(object sender, EventArgs e)
    {
        Session["ref_sel"] = "";
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox check = (CheckBox)row.FindControl("CheckBoxArchiver");
            var selectedKey = GridView1.DataKeys[row.RowIndex].Value.ToString();
            if (check.Checked)
            {
                if ((String)Session["ref_sel"] == "")
                {
                    Session["ref_sel"] = selectedKey;
                }
                else
                {
                    Session["ref_sel"] = Session["ref_sel"] + ";" + selectedKey;
                }
            }
        }
        if ((String)Session["ref_sel"] == "")
        {
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "veuillez sélectionnez au moins un bien grâce aux checkbox";
        }
        else
        {
            Membre member = (Membre)Session["Membre"];
            int i = 0;
            string Ref = (string)Session["ref_sel"];
            string[] WordArray;
            string[] stringSeparators = new string[] { ";" };
            WordArray = Ref.Split(stringSeparators, StringSplitOptions.None);
            i = 0;
            //On ajoute dans la base
            if (WordArray.Length >= 1)
            {
                while (i < WordArray.Length)
                {
                    string refer = WordArray[i];
                    // Response.Redirect("./ficheCommerciale.aspx");

                    Response.Redirect("./ficheNegociateur.aspx?refse=" + refer + "");
                    i++;
                }
                LabelErrorLogin.Visible = false;
            }

        }
    }

    protected void Rapprochement(object sender, EventArgs e)
    {
        string selectedValue = Request.Form["MyRadioButton"];
        string reference = selectedValue;
        if (reference == null)
        {
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "veuillez sélectionner un radio bouton";
        }
        else
        {
            Response.Redirect("./rapprochementbien.aspx?idAcq=" + reference + "");
        }
    }

    protected void Achive_Click(object sender, EventArgs e)
    {
        //Page_Load(object sender, EventArgs e);
    }

    public bool regleTelVendeur { get; set; }

    public bool regleAdrVendeur { get; set; }

    protected string tooltip_photo(string text)
    {
        string stext = "";
        int sc = CheckNombrePhotos(text);

        if (sc == 0)
            stext = "<div class='tooltip tooltipLeft0'><span>pas de photo";
        else if (sc == 1)
            stext = "<div class='tooltip tooltipLeft1'><span>" + sc + " photo<br/>"
                    + "<img style='width:160px;' src='../images/" + text + "A.jpg' alt='photo'>";
        else
            stext += "<div class='tooltip tooltipLeft'><span>" + sc + " photos<br/>"
                    + "<img style='width:160px;' src='../images/" + text + "A.jpg' alt='photo'>"
                    + "<img style='margin-left:5px;width:160px;' src='../images/" + text + "B.jpg' alt='photo'>";
        stext += "</span></div>";
        return stext;
    }


    protected void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public string GreenTypeComboBoxStyle { get; set; }
    protected void ComboBox1_DataBound(object sender, EventArgs e)
    {
        foreach (ListItem myItem in ComboBox1.Items)
        {
            myItem.Attributes.Add("style", "brackground-color:#111111");
        }
    }

    protected void Dernieres_Visites(object sender, EventArgs e)
    {
        string temp = "", temp2 = "";

        temp = radioButtonAchat.ClientID;
        temp = temp.Replace("_", "$");
        temp = temp.Replace("radioButtonAchat", radioButtonAchat.GroupName);
        temp2 = Page.Request.Form[temp];

        if (temp2 == "radioButtonAchat")
        {
            Session["TypeTransaaction"] = "V";

            temp = CheckBoxArchive.ClientID;
            temp = temp.Replace("_", "$");
            temp2 = Page.Request.Form[temp];
            if (temp2 == "on")
                Session["ARCHIVEVARIABLE"] = "archive";
            else
                Session["ARCHIVEVARIABLE"] = "actif";

            Response.Redirect("./dernieres_visites.aspx");
        }
        temp = radioButtonLocation.ClientID;
        temp = temp.Replace("_", "$");
        temp = temp.Replace("radioButtonLocation", radioButtonLocation.GroupName);
        temp2 = Page.Request.Form[temp];

        if (temp2 == "radioButtonLocation")
        {
            Session["TypeTransaaction"] = "L";

            temp = CheckBoxArchive.ClientID;
            temp = temp.Replace("_", "$");
            temp2 = Page.Request.Form[temp];
            if (temp2 == "on")
                Session["ARCHIVEVARIABLE"] = "archive";
            else
                Session["ARCHIVEVARIABLE"] = "actif";

            Response.Redirect("./dernieres_visites.aspx");
        }
    }

    protected void vente(object sender, EventArgs e)
    {
        String selectedValue = Request.Form["MyRadioButton"];
        Session["idbien"] = selectedValue;

        string numero_id_acq = "0";

        if (DropDownList1.SelectedValue != "")
            numero_id_acq = DropDownList1.SelectedValue;

        if ((String)Session["idbien"] == null)
        {
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "veuillez sélectionner un radio bouton";
        }
        else
        {
            Response.Redirect("./vente.aspx?ref=" + selectedValue + "&acq=" + numero_id_acq);
        }
    }
    protected void Location(object sender, EventArgs e)
    {
        String selectedValue = Request.Form["MyRadioButton"];
        Session["idbien"] = selectedValue;

        string numero_id_acq = "0";

        if (DropDownList1.SelectedValue != "")
            numero_id_acq = DropDownList1.SelectedValue;
        if ((String)Session["idbien"] == null)
        {
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "Veuillez sélectionner radio bouton";
        }
        else
        {
            Response.Redirect("./location.aspx?ref=" + selectedValue + "&acq=" + numero_id_acq);
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void apply_click(object sender, EventArgs e)
    {
        //string modifnego = textbox1.Text;
        //string requete = "";
        Session["ref_sel"] = "";
        Session["acq_nego"] = DropDownList2.SelectedValue.ToString();
        List<string> list = new List<string>();
        if (ViewState["SelectedRecords"] != null)
        {
            list = (List<string>)ViewState["SelectedRecords"];
        }

        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox check = (CheckBox)row.FindControl("CheckBoxArchiver");
            var selectedKey = GridView1.DataKeys[row.RowIndex].Value.ToString();
            if (check.Checked == false)
            {
                Labelmodif.Visible = false;
                LabelErrorLogin.Visible = true;
                LabelErrorLogin.Text = "veuillez sélectionnez au moins un bien grâce aux checkbox";
            }

            if (check.Checked)
            {
                LabelErrorLogin.Visible = false;
                if (!list.Contains(selectedKey))
                {
                    list.Add(selectedKey);
                }
            }
            else
            {
                if (list.Contains(selectedKey))
                {
                    list.Remove(selectedKey);
                }
            }
        }

        //Création d'une nouvelle liste pour stocker les références qui seront supprimées de la liste ensuite.
        List<string> listes = new List<string>();
        ViewState["SelectedRecords"] = list;

        List<string> liste = ViewState["SelectedRecords"] as List<string>;

        if (list != null)
        {
            foreach (string id in list)
            {
                /*requete = "UPDATE Biens SET idclient ='" +modifnego+ "' WHERE `ref`='" + id + "'";

                System.Data.DataSet ds = null;
                Connexion c = null;

                c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                c.Open();
                ds = c.exeRequette(requete);
                c.Close();
                c = null;*/
                string ident;
                String sql = "SELECT Clients.prenom_client, Clients.nom_client FROM Clients WHERE Clients.idclient = " + Session["acq_nego"] + "";
                using (OdbcConnection db =
                new OdbcConnection(_ConnectionString))
                {
                    // Create the Command and Parameter objects.
                    OdbcCommand command = new OdbcCommand(sql, db);
                    OdbcCommand update = new OdbcCommand();
                    update.CommandType = System.Data.CommandType.Text;
                    update.Connection = db;

                    // Open the connection in a try/catch block. 
                    // Create and execute the DataReader, writing the result
                    // set to the console window.

                    db.Open();
                    OdbcDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ident = "" + (String)reader[0] + " " + (String)reader[1] + "";
                        Session["mod_nego"] = ident;
                        update.CommandText = "UPDATE Biens SET Biens.idclient = '" + Session["acq_nego"] + "', Biens.negociateur ='" + ident + "' WHERE ref = '" + id + "'";
                        update.ExecuteNonQuery();
                    }
                    reader.Close();
                    db.Close();
                }
                listes.Add(id);

                Labelmodif.Visible = true;

                if (listes.Count() == 1)
                {
                    Labelmodif.Text = "Vous avez modifié " + listes.Count() + " biens. " + Session["mod_nego"] + " est le nouveau négociateur en charge de ce bien. ";

                }
                else
                {
                    Labelmodif.Text = "Vous avez modifié " + listes.Count() + " biens. " + Session["mod_nego"] + " est le nouveau négociateur en charge de ces biens. ";
                }
                LabelErrorLogin.Visible = false;

            }


        }

        foreach (string id in listes)
        {
            list.Remove(id);
        }
        BindData();

    }


    /*************************
     * Fonctions utilitaires *
     *************************/

    //Prend un nombre sous forme de string et le retourne le nombre avec un espace tous les 3 chiffres
    private string espaceNombre(string nombre)
    {
        string prixFormat = "";
        int k = 0;
        if (nombre.Length > 3)
        {
            while ((k + 1) * 3 < nombre.Length)
            {
                prixFormat = nombre.Substring((nombre.Length - (k + 1) * 3), 3) + " " + prixFormat;
                k++;
            }
            prixFormat = nombre.Substring(0, nombre.Length - k * 3) + " " + prixFormat;
        }
        else prixFormat = nombre;

        return prixFormat;
    }

    protected String nl2br(string s)
    {
        Regex rgx = new Regex("\r\n|\r|\n");
        return rgx.Replace(s, "<br/>");
    }

    protected void Remplir_DDL_Acq(object sender, EventArgs e)
    {
        Membre member = (Membre)Session["Membre"];

        string req = "";

        if (member.STATUT == "ultranego")
        {
            req = "SELECT id_acq,nom,prenom,tel,mail,code_postal,ville,type_acquereur FROM Acquereurs WHERE actif='actif' AND idclient = " + member.IDCLIENT + " ORDER BY Nom ASC";
        }
        else
            req = "SELECT id_acq, nom, prenom, tel, mail, code_postal, ville, type_acquereur FROM Acquereurs WHERE actif = 'actif' AND idclient = " + member.IDCLIENT + " ORDER BY Nom ASC";

        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();

        DataRowCollection listeAcquereur = c.exeRequetteOpen(req).Tables[0].Rows;

        if (radioButtonAchat.Checked)
        {
            foreach (DataRow acq in listeAcquereur)
            {
                string type = acq["type_acquereur"].ToString();
                if (type == "Acheteur")
                {
                    ListItem x = new ListItem(acq["nom"].ToString().ToUpper() + " " + acq["prenom"].ToString() + " (" + acq["ville"].ToString() + " - " + acq["code_postal"].ToString() + ")");
                    x.Value = acq["id_acq"].ToString();
                    DropDownList1.Items.Add(x);
                }
            }
        }
        else
            if (radioButtonLocation.Checked)
                foreach (DataRow acq in listeAcquereur)
                {
                    string type = acq["type_acquereur"].ToString();
                    if (type == "Loueur")
                    {
                        ListItem x = new ListItem(acq["nom"].ToString().ToUpper() + " " + acq["prenom"].ToString() + " (" + acq["ville"].ToString() + " - " + acq["code_postal"].ToString() + ")");
                        x.Value = acq["id_acq"].ToString();
                        DropDownList1.Items.Add(x);
                    }
                }

        c.Close();
    }

}
