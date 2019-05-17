using System;
using System.Data;
using System.Data.Odbc;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Globalization;
using System.Web.UI.HtmlControls;






public partial class pages_liste_acquereur : System.Web.UI.Page
{
    string _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
	
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Page.Master.FindControl("titrebandeau")).Text = "Mon compte";

        Membre member = (Membre)Session["Membre"];

        dropDownListEtat.Items.Clear();
        dropDownListEtat.Items.Add("Tous");
        if ((bool)Session["radioButtonAcheteur"] == true)
        {
            dropDownListEtat.Items.Add("Estimation");
            dropDownListEtat.Items[1].Attributes.Add("style", "background-color:#F4A460");
            dropDownListEtat.Items.Add("Disponible");
            dropDownListEtat.Items[2].Attributes.Add("style", "background-color:#FFFFFF");
            dropDownListEtat.Items.Add("Offre");
            dropDownListEtat.Items[3].Attributes.Add("style", "background-color:#FFE4C4");
            dropDownListEtat.Items.Add("Suspendu");
            dropDownListEtat.Items[4].Attributes.Add("style", "background-color:#808080");
            dropDownListEtat.Items.Add("Retiré");
            dropDownListEtat.Items[5].Attributes.Add("style", "background-color:#008000");
            dropDownListEtat.Items.Add("Compromis");
            dropDownListEtat.Items[6].Attributes.Add("style", "background-color:#FFFF00");
        } 
        else if((bool)Session["radioButtonLoueur"] == true)
        {
            dropDownListEtat.Items.Add("Libre");
            dropDownListEtat.Items[1].Attributes.Add("style", "background-color:#FFFFFF");
            dropDownListEtat.Items.Add("Occupé");
            dropDownListEtat.Items[2].Attributes.Add("style", "background-color:#FFD700; color:#FF0000");
            dropDownListEtat.Items.Add("Loué");
            dropDownListEtat.Items[3].Attributes.Add("style", "background-color:#ADD8E6");
            dropDownListEtat.Items.Add("Option");
            dropDownListEtat.Items[4].Attributes.Add("style", "background-color:#FFA500");
            dropDownListEtat.Items.Add("Réservé");
            dropDownListEtat.Items[5].Attributes.Add("style", "background-color:#DDA0DD");
            dropDownListEtat.Items.Add("Retiré");
            dropDownListEtat.Items[6].Attributes.Add("style", "background-color:#000080");
            dropDownListEtat.Items.Add("Suspendu");
            dropDownListEtat.Items[6].Attributes.Add("style", "background-color:#D2B48C");

        }
		
        if (!IsPostBack)
        {
            textBoxSurfaceMin.Text = (String)Session["SminAcq"];
            textBoxSurfaceMax.Text = (String)Session["SmaxAcq"];
            textBoxVille.Text = (String)Session["VilleRechercheAcq"];
            textBoxPays.Text = (String)Session["PaysRechercheAcq"];
            textBoxDep.Text = (String)Session["DepRechercheAcq"];
            textBoxMotCle1.Text = (String)Session["textBoxMotCle1Acq"];
            textBoxMotCle2.Text = (String)Session["textBoxMotCle2Acq"];
            textBoxMotCle3.Text = (String)Session["textBoxMotCle3Acq"];
            textBoxMotCle4.Text = (String)Session["textBoxMotCle4Acq"];
            TextBoxBudgetMin.Text = (String)Session["TextBoxBudgetMinAcq"];
            TextBoxBudgetMax.Text = (String)Session["TextBoxBudgetMaxAcq"];
            textBoxSurfaceMin.Text = (String)Session["textBoxSurfaceMinAcq"];
            textBoxSurfaceMax.Text = (String)Session["textBoxSurfaceMaxAcq"];
            radioButtonAcheteur.Checked = (bool)Session["radioButtonAcheteur"];
            radioButtonLoueur.Checked = (bool)Session["radioButtonLoueur"];
            checkBoxPiece1.Checked = (bool)Session["checkBoxPiece1Acq"];
            checkBoxPiece2.Checked = (bool)Session["checkBoxPiece2Acq"];
            checkBoxPiece3.Checked = (bool)Session["checkBoxPiece3Acq"];
            checkBoxPiece4.Checked = (bool)Session["checkBoxPiece4Acq"];
            checkBoxPiece5.Checked = (bool)Session["checkBoxPiece5Acq"];
            checkBoxChambre1.Checked = (bool)Session["checkBoxChambre1Acq"];
            checkBoxChambre2.Checked = (bool)Session["checkBoxChambre2Acq"];
            checkBoxChambre3.Checked = (bool)Session["checkBoxChambre3Acq"];
            checkBoxChambre4.Checked = (bool)Session["checkBoxChambre4Acq"];
            checkBoxChambre5.Checked = (bool)Session["checkBoxChambre5Acq"];
            checkBoxMaison.Checked = (bool)Session["checkBoxMaisonAcq"];
            checkBoxAppart.Checked = (bool)Session["checkBoxAppartAcq"];
            checkBoxTerrain.Checked = (bool)Session["checkBoxTerrainAcq"];
            checkBoxAutre.Checked = (bool)Session["checkBoxAutreAcq"];
            textBoxSurfaceSMin.Text = (String)Session["TextBoxSurfaceSMinAcq"];
            textBoxSurfaceSMax.Text = (String)Session["TextBoxSurfaceSMaxAcq"];
            textBoxSurfaceTMin.Text = (String)Session["textBoxSurfaceTMinAcq"];
            textBoxSurfaceTMax.Text = (String)Session["textBoxSurfaceTMaxAcq"];
            textBoxFacadeMin.Text = (String)Session["textBoxFacadeMin"];
            textBoxFacadeMax.Text = (String)Session["textBoxFacadeMax"];
            textBoxProfondeurMin.Text = (String)Session["textBoxProfondeurMin"];
            textBoxProfondeurMax.Text = (String)Session["textBoxProfondeurMax"];
            checkBoxAsc.Checked = (bool)Session["checkBoxAsc"];
            checkBoxSous.Checked = (bool)Session["checkBoxSous"];
            checkBoxPark.Checked = (bool)Session["checkBoxPark"];
            DropDownListPageSize.SelectedValue = Session["annoncesPageAcq"].ToString();
            dropDownListEtat.SelectedValue = Session["dropDownListEtat"].ToString();
            if (Session["dropDownListTypeAcq"] == null)
                Session["dropDownListTypeAcq"] = "";
            dropDownListType.SelectedValue = Session["dropDownListTypeAcq"].ToString();
            textBoxNom1.Text = (String)Session["textBoxNom1"];
            textBoxPrenom1.Text = (String)Session["textBoxPrenom1"];
            textBoxTel.Text = (String)Session["textBoxTel"];
            textBoxPortable.Text = (String)Session["textBoxPortable"];
            textBoxMail.Text = (String)Session["textBoxMail"];
            //textBoxDate.Text = (String)Session["textBoxDateMin"];
            //textBoxDateFin.Text = (String)Session["textBoxDateMax"];
            if (Session["textBoxDateMin"] != null && (String)Session["textBoxDateMin"] != "")
            {
                var tempDate = (String)Session["textBoxDateMin"]; // 22/10/2012
                var tempDateParts = tempDate.Split('/'); // {"22", "10", "2012"}
                tempDate = string.Format("{0}-{1}-{2}", tempDateParts[2], tempDateParts[1], tempDateParts[0]); // 2012-10-22
                textBoxDate.Text = tempDate;
            }
            else textBoxDate.Text = "";

            if (Session["textBoxDateMax"] != null && (String)Session["textBoxDateMax"] != "")
            {
                var tempDate = (String)Session["textBoxDateMax"]; // 22/10/2012
                var tempDateParts = tempDate.Split('/'); // {"22", "10", "2012"}
                tempDate = string.Format("{0}-{1}-{2}", tempDateParts[2], tempDateParts[1], tempDateParts[0]); // 2012-10-22
                textBoxDateFin.Text = tempDate;
            }
            else textBoxDateFin.Text = "";

            DropDownListPageSize.SelectedValue = Session["annoncesPageA"].ToString();
            GridViewAcq.PageSize = int.Parse(DropDownListPageSize.SelectedValue);
			
			
            if (Session["CB_BT"] != null)
            {
					if (Session["CB_BT"].ToString() == "true")
					{ CheckBoxArchive.Checked = true; }
					if (Session["CB_BT"].ToString() == "false")
					{ CheckBoxArchive.Checked = false; }
				}
				
			if(Session["sortExpressionA"] == null && Session["directionA"] == null)
			{
				Session["sortExpressionA"] = "date_ajout";
				Session["directionA"] = " DESC";
			}
			
            BindData(true);
        }
    }

    protected void modif_admintab(object sender, EventArgs e)
    {
        if (((CheckBox)sender).Checked == true) { Session["CB_BT"] = "true"; }
        if (((CheckBox)sender).Checked == false) { Session["CB_BT"] = "false"; }
        //Response.Redirect("./moncomptetableaudebord_bis.aspx?Numpage=" + 1 + "&Tri=" + Session["Tri"] + "&Ordre=" + Session["Ordre"] + "&nbannonces=" + Session["annoncesPage"]);
    }

    private RequeteAcquereur verifChampSaisi(RequeteAcquereur maRecher)
    {

        #region attribut
        Regex numReg = new Regex("^[0-9 ]+$");
        Regex alphaNumReg = new Regex("^[0-9]+$|^[a-zA-Zéèçàù ]+$|^()+$");
        Regex regEmail = new Regex(@"^([\w\-.]+)@([a-zA-Z0-9\-.]+)$");

        //old
        //Regex date = new Regex("^[1-9]|[12][0-9]|3[01]+$[/]+$[1-9]|1[012]+$[/](19|20)+$");
        Regex date = new Regex(@"^((19)|(20))[0-9]{2}([-_/ ])((0[0-9])|(1[120])|([0-9]))([-_/ ])((([012][0-9])|(3[120])|([0-9])))$");

        /// 3 bool permettant d'identifier si la recherche se fait par code postaux , departement ou nom de la ville

        bool regnom = false;
        bool regprenom = false;
        bool regtelephone = false;
        bool regportable = false;
        bool regmail = false;
        bool regSurfaceMin = false;
        bool regSurfaceMax = false;
        bool regSurfaceSMin = false;
        bool regSurfaceSMax = false;
        bool regSurfaceTMin = false;
        bool regSurfaceTMax = false;
        bool regFacadeMin = false;
        bool regFacadeMax = false;
        bool regProfondeurMin = false;
        bool regProfondeurMax = false;
        bool regBudgetMin = false;
        bool regBudgetMax = false;
        bool regDatedecreation = false;
        bool regDatedefin = false;



        String smin = "erreur de saisie pour la surface minimal";
        String smax = "\n erreur de saisie pour la surface maximal";
        String bmin = "\n erreur de saisie pour la budget minimal";
        String bmax = "\n erreur de saisie pour la budget maximal";
        String ville_1 = "\n erreur de saisie pour la ville";



        #endregion


        #region Série de test sur les textBoxs des ville pour savoir si la recherche est Code postal, departement ou nom de ville



        //Regex rCP = new Regex(@"^\d{5}$");
        Regex rCP = new Regex(@"^([0-9][0-9][0-9][0-9][0-9][ ]?)+$");
        Regex rDepartement = new Regex(@"^([0-9][0-9][ ]?)+$");






        #endregion


        
        TextBoxBudgetMin.Text = TextBoxBudgetMin.Text.Replace(" ", "");
        TextBoxBudgetMax.Text = TextBoxBudgetMax.Text.Replace(" ", "");
        
        //test le contenu des box par expression reguliere si OK alors true
        if (textBoxNom1.Text != "")
        {
            regnom = alphaNumReg.IsMatch(textBoxNom1.Text);
        }
        else
        {
            regnom = true;
        }
        if (textBoxPrenom1.Text != "")
        {
            regprenom = alphaNumReg.IsMatch(textBoxPrenom1.Text);
        }
        else
        {
            regprenom = true;
        }
        if (textBoxTel.Text.Trim() != "")
        {
            regtelephone = numReg.IsMatch(textBoxTel.Text.Trim());
        }
        else
        {
            regtelephone = true;
        }
        if (textBoxPortable.Text.Trim() != "")
        {
            regportable = numReg.IsMatch(textBoxPortable.Text.Trim());
        }
        else
        {
            regportable = true;
        }
        if (textBoxMail.Text != "")
        {
            regmail = regEmail.IsMatch(textBoxMail.Text);
        }
        else
        {
            regmail = true;
        }

        bool testDateOk = (textBoxDate.Text.Trim() != "");
        string testTextBox = textBoxDate.Text.Trim();
        if (textBoxDate.Text.Trim() != "")
        {
            regDatedecreation = date.IsMatch(textBoxDate.Text.Trim());
        }
        else regDatedecreation = true;

        if (textBoxDateFin.Text.Trim() != "")
        {
            regDatedefin = date.IsMatch(textBoxDateFin.Text.Trim());
        }
        else regDatedefin = true;
		


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

        if (textBoxSurfaceSMin.Text.Trim() != "")
        {
            regSurfaceSMin = numReg.IsMatch(textBoxSurfaceSMin.Text.Trim());
        }
        else regSurfaceSMin = true; // si la text box est vide on effectue qd meme la recherche

        if (textBoxSurfaceSMax.Text.Trim() != "")
        {
            regSurfaceSMax = numReg.IsMatch(textBoxSurfaceSMax.Text.Trim());
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

        if (textBoxFacadeMin.Text.Trim() != "")
        {
            regFacadeMin = numReg.IsMatch(textBoxFacadeMin.Text.Trim());
        }
        else regFacadeMin = true; // si la text box est vide on effectue qd meme la recherche

        if (textBoxFacadeMax.Text.Trim() != "")
        {
            regFacadeMax = numReg.IsMatch(textBoxFacadeMax.Text.Trim());
        }
        else
        {
            regFacadeMax = true; // si la text box est vide on effectue qd meme la recherche
        }

        if (textBoxProfondeurMin.Text.Trim() != "")
        {
            regProfondeurMin = numReg.IsMatch(textBoxProfondeurMin.Text.Trim());
        }
        else regProfondeurMin = true; // si la text box est vide on effectue qd meme la recherche

        if (textBoxProfondeurMax.Text.Trim() != "")
        {
            regProfondeurMax = numReg.IsMatch(textBoxProfondeurMax.Text.Trim());
        }
        else
        {
            regProfondeurMax = true; // si la text box est vide on effectue qd meme la recherche
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
        if (regnom == false || regprenom == false || regtelephone == false || regmail == false || regSurfaceMin == false || regSurfaceMax == false || regBudgetMin == false || regBudgetMax == false|| regDatedefin==false||regDatedecreation == false)
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
        if (maRecher.Datedefin != Convert.ToDateTime("01/01/0001 00:00:00"))
        {
            if (DateTime.Compare(maRecher.Datedecreation, maRecher.Datedefin) > 0)
            {
                regDatedecreation = false;
                LabelErrorLogin.Visible = true;
                LabelErrorLogin.Text = "erreur de saisie, veuillez resaisir les critères de votre recherche";
            }
        }
        if (regDatedecreation == false)
        {
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "erreur de saisie, veuillez resaisir les critères de votre recherche";
        }
        if (maRecher.SURFACEMAX < maRecher.SURFACEMIN)
        {
            regSurfaceMin = false;
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "erreur de saisie, veuillez resaisir les critères de votre recherche";
        }

        if (maRecher.SURFACESMAX < maRecher.SURFACESMIN)
        {
            regSurfaceSMin = false;
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "erreur de saisie, veuillez resaisir les critères de votre recherche";
        }

        if (maRecher.SURFACETMAX < maRecher.SURFACETMIN)
        {
            regSurfaceTMin = false;
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "erreur de saisie, veuillez resaisir les critères de votre recherche";
        }

        if (maRecher.FACADEMAX < maRecher.FACADEMIN)
        {
            regFacadeMin = false;
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "erreur de saisie, veuillez resaisir les critères de votre recherche";
        }

        if (maRecher.PROFONDEURMAX < maRecher.PROFONDEURMIN)
        {
            regProfondeurMin = false;
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "erreur de saisie, veuillez resaisir les critères de votre recherche";
        }

        if (regnom == true && regprenom == true && regtelephone == true && regportable == true && regmail == true && regDatedecreation==true && regDatedefin==true && regSurfaceMin == true && regSurfaceMax == true && regSurfaceSMin == true && regSurfaceSMax == true && regSurfaceTMin == true && regSurfaceTMax == true && regFacadeMin == true && regFacadeMax == true && regProfondeurMin == true && regProfondeurMax == true  && regBudgetMin == true && regBudgetMax == true)
            maRecher.RECHERCHE_OK = true;
        ///Si tout est OK alors maRecherche.RECHERCHE_OK =true -----> permet d'executer la requete
		//Absurde, si les 4 bool en dessous sont true, et on peut lancer une recherche contenant des tonnes de valeurs invalides!? 
        else if (regSurfaceMin == true && regSurfaceMax == true  && regBudgetMin == true && regBudgetMax == true)
        {
            maRecher.RECHERCHE_OK = true;
        }
        else maRecher.RECHERCHE_OK = false;

        if (maRecher.RECHERCHE_OK == true)
        {
            LabelErrorLogin.Text = "";
            LabelErrorLogin.Visible = false;
        }

        return maRecher;
    }

    protected void PaginateTheData(object sender, GridViewPageEventArgs e)
    {
        List<string> list = new List<string>();
        if (ViewState["SelectedRecordsA"] != null)
        {
            list = (List<string>)ViewState["SelectedRecordsA"];
        }
        foreach (GridViewRow row in GridViewAcq.Rows)
        {
            CheckBox check = (CheckBox)row.FindControl("CheckBoxArchiver");
            var selectedKey = GridViewAcq.DataKeys[row.RowIndex].Value.ToString();
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
        table.DefaultView.Sort = (String)Session["sortExpressionA"] + (String)Session["directionA"];
        GridViewAcq.DataSource = table;
        ViewState["SelectedRecordsA"] = list;
		ViewState["NbRecords"] = table.Rows.Count;
        GridViewAcq.PageIndex = e.NewPageIndex;
        GridViewAcq.DataBind();
        // On coche la checkbox tout sélectionner.
        int i = 0;
        foreach (GridViewRow row in GridViewAcq.Rows)
        {
            CheckBox check = (CheckBox)row.FindControl("CheckBoxArchiver");
            if (check.Checked)
            {
                i++;
            }
        }
        if (i == GridViewAcq.PageSize)
        {
            GridViewRow rowe = GridViewAcq.HeaderRow;
            CheckBox checkboxSelect = (CheckBox)rowe.FindControl("CheckBoxSelection");
            checkboxSelect.Checked = true;
        }
    }

    protected void SortRecords(object sender, GridViewSortEventArgs e)
    {
        Session["sortExpressionA"] = e.SortExpression;
        Session["directionA"] = string.Empty;

        if (SortDirection == SortDirection.Ascending)
        {
            SortDirection = SortDirection.Descending;
            Session["directionA"] = " DESC";
        }
        else
        {
            SortDirection = SortDirection.Ascending;
            Session["directionA"] = " ASC";
        }
        DataTable table = this.GetData();
        table.DefaultView.Sort = (String)Session["sortExpressionA"] + (String)Session["directionA"];
        GridViewAcq.DataSource = table;
		ViewState["NbRecords"] = table.Rows.Count;
        GridViewAcq.DataBind();
    }

    private void BindData(bool conserverModeTri = false)
    {
        // specify the data source for the GridView
		DataTable table = this.GetData();
		if(conserverModeTri)
			table.DefaultView.Sort = (String)Session["sortExpressionA"] + (String)Session["directionA"];
        GridViewAcq.DataSource = table;
		ViewState["NbRecords"] = table.Rows.Count;
        // bind the data now
        GridViewAcq.DataBind();
		
		if ((int)ViewState["NbRecords"] == 0)
        {
            LabelbnBiens.Text = "0";
        }
    }

    protected void radio_button_checka(object sender, EventArgs e)
    {
        radioButtonAcheteur.CssClass = "myButtonblue";
        radioButtonLoueur.CssClass = "myButtonred";
        BindData();
    }
    protected void radio_button_checkl(object sender, EventArgs e)
    {
        radioButtonAcheteur.CssClass = "myButtonred";
        radioButtonLoueur.CssClass = "myButtonblue";
        BindData();
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
            if (ViewState["SortDirectionA"] == null)
            {
                ViewState["SortDirectionA"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["SortDirectionA"];
        }
        set
        {
            ViewState["SortDirectionA"] = value;
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

        RequeteAcquereur recherche = new RequeteAcquereur();

		switch(dropDownListType.Text)
		{
			case "Précis" 	: recherche.TypeAcquisition = "precis"; break;
			case "Large" 	: recherche.TypeAcquisition = "large"; break;
			case "Ancien" 	: recherche.TypeAcquisition = "investisseur ancien"; break;
			case "Neuf" 	: recherche.TypeAcquisition = "investisseur neuf"; break;
		}
		
		
        if (TextBoxBudgetMin.Text == "") recherche.PRIXMIN = 0;
        if (TextBoxBudgetMax.Text == "") recherche.PRIXMAX = 1000000000;
        if (textBoxSurfaceMin.Text == "") recherche.SURFACEMIN = 0;
        if (textBoxSurfaceMax.Text == "") recherche.SURFACEMAX = 9999999;
        if (textBoxSurfaceSMin.Text == "") recherche.SURFACESMIN = 0;
        if (textBoxSurfaceSMax.Text == "") recherche.SURFACESMAX = 9999999;
        if (textBoxSurfaceTMin.Text == "") recherche.SURFACETMIN = 0;
        if (textBoxSurfaceTMax.Text == "") recherche.SURFACETMAX = 9999999;
        if (textBoxFacadeMin.Text == "") recherche.FACADEMIN = 0;
        if (textBoxFacadeMax.Text == "") recherche.FACADEMAX = 9999999;
        if (textBoxProfondeurMin.Text == "") recherche.PROFONDEURMIN = 0;
        if (textBoxProfondeurMax.Text == "") recherche.PROFONDEURMAX = 9999999;
		
		//Ces 2 erreurs sont traités dans verifierSaisie || En fait non, elle sont mals traitées.
		//F*** this, on va ignorere le champ si le format est invalide
        if (textBoxDate.Text != "") 
		{
			try{recherche.Datedecreation = Convert.ToDateTime(textBoxDate.Text + " 00:00:00 AM");}
			catch{textBoxDate.Text = "";}
		}
        if (textBoxDateFin.Text != "")
		{
			try{recherche.Datedefin = Convert.ToDateTime(textBoxDateFin.Text + " 11:59:59 PM").AddDays(1);}
			catch{textBoxDateFin.Text = "";}
		}

        bool testOK = verifChampSaisi(recherche).RECHERCHE_OK;
        if (verifChampSaisi(recherche).RECHERCHE_OK == true)
        {

            if (TextBoxBudgetMin.Text != "") recherche.PRIXMIN = Int64.Parse(TextBoxBudgetMin.Text.Trim());
            if (TextBoxBudgetMax.Text != "") recherche.PRIXMAX = Int64.Parse(TextBoxBudgetMax.Text.Trim());
            if (textBoxSurfaceMin.Text != "") recherche.SURFACEMIN = Int64.Parse(textBoxSurfaceMin.Text.Trim());
            if (textBoxSurfaceMax.Text != "") recherche.SURFACEMAX = Int64.Parse(textBoxSurfaceMax.Text.Trim());
            if (textBoxSurfaceSMin.Text != "") recherche.SURFACESMIN = Int64.Parse(textBoxSurfaceSMin.Text.Trim());
            if (textBoxSurfaceSMax.Text != "") recherche.SURFACESMAX = Int64.Parse(textBoxSurfaceSMax.Text.Trim());
            if (textBoxFacadeMin.Text != "") recherche.FACADEMIN = Int64.Parse(textBoxFacadeMin.Text.Trim());
            if (textBoxFacadeMax.Text != "") recherche.FACADEMAX = Int64.Parse(textBoxFacadeMax.Text.Trim());
            if (textBoxProfondeurMin.Text != "") recherche.PROFONDEURMIN = Int64.Parse(textBoxProfondeurMin.Text.Trim());
            if (textBoxProfondeurMax.Text != "") recherche.PROFONDEURMAX = Int64.Parse(textBoxProfondeurMax.Text.Trim());
            if (textBoxDate.Text != "") recherche.Datedecreation = Convert.ToDateTime(textBoxDate.Text + " 00:00:00 AM");
            if (textBoxDateFin.Text != "") recherche.Datedefin = Convert.ToDateTime(textBoxDateFin.Text + " 11:59:59 PM").AddDays(1);
            
            recherche.MOTCLE1 = textBoxMotCle1.Text.Trim();
            recherche.MOTCLE2 = textBoxMotCle2.Text.Trim();
            recherche.MOTCLE3 = textBoxMotCle3.Text.Trim();
            recherche.MOTCLE4 = textBoxMotCle4.Text.Trim();

            Membre member = (Membre)Session["Membre"];
            recherche.IDCLIENT = member.IDCLIENT;

            recherche.NOM = textBoxNom1.Text;
            recherche.PRENOM = textBoxPrenom1.Text;
            recherche.TEL = textBoxTel.Text.Trim();
            recherche.PORTABLE = textBoxPortable.Text.Trim();
            recherche.MAIL = textBoxMail.Text;
            
			recherche.ListeVille = textBoxVille.Text;
			recherche.ListePays = textBoxPays.Text;
			recherche.ListeDep = textBoxDep.Text;

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

            if (checkBoxAppart.Checked == false && checkBoxTerrain.Checked == false && checkBoxMaison.Checked == false && checkBoxAutre.Checked == false)
            {
                recherche.APPART += "False";
                recherche.MAIS += "False";
                recherche.TERR += "False";
                recherche.AUTR += "False";
            }
            else
            {
                if (checkBoxAppart.Checked) recherche.APPART += "True";
                else recherche.APPART += "False";
                if (checkBoxMaison.Checked) recherche.MAIS += "True";
                else recherche.MAIS += "False";
                if (checkBoxTerrain.Checked) recherche.TERR += "True";
                else recherche.TERR += "False";
                if (checkBoxAutre.Checked) recherche.AUTR += "True";
                else recherche.AUTR += "False";
            }

            if (checkBoxAsc.Checked) recherche.ASC = "OUI";
            else recherche.ASC = "NON";

            if (checkBoxSous.Checked) recherche.SOUS = "OUI";
            else recherche.SOUS = "NON";

            if (checkBoxPark.Checked) recherche.PARK = "OUI";
            else recherche.PARK = "NON";

            recherche.ETATAVANCEMENT = dropDownListEtat.SelectedValue;
            recherche.TYPEACQ = dropDownListType.SelectedValue;

            //sauvegarde l'objet recherche dans la session

            Session["requeteAcq"] = recherche;
        }
        if (radioButtonAcheteur.Checked)
        {
            recherche.TYPEACQ = "'Acheteur'";
        }
        else
        {
            recherche.TYPEACQ = "'Loueur'";
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
                    // fire Fill method to fetch the data and fill into DataTable 
                    ad.Fill(table);
                }
            }
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
        if (ViewState["SelectedRecordsA"] != null)
        {
            list = (List<string>)ViewState["SelectedRecordsA"];
        }
        foreach (GridViewRow row in GridViewAcq.Rows)
        {
            CheckBox check = (CheckBox)row.FindControl("CheckBoxArchiver");
            var selectedKey = GridViewAcq.DataKeys[row.RowIndex].Value.ToString();
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
        ViewState["SelectedRecordsA"] = list;
        if (CheckBoxArchive.Checked)
        {
            List<string> liste = ViewState["SelectedRecordsA"] as List<string>;
            if (list != null)
            {
                foreach (string id in list)
                {
                    requete = "UPDATE Acquereurs SET `actif`='actif' WHERE `id_acq`=" + id + "";

                    System.Data.DataSet ds = null;
                    Connexion c = null;

                    c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    c.Open();
                    ds = c.exeRequette(requete);
                    c.Close();
                    c = null;
                    listes.Add(id);
                }
            }
        }
        else
        {
            List<string> liste = ViewState["SelectedRecordsA"] as List<string>;
            if (list != null)
            {
                foreach (string id in list)
                {
                    requete = "UPDATE Acquereurs SET `actif`='archive' WHERE `id_acq`=" + id + "";

                    System.Data.DataSet ds = null;
                    Connexion c = null;

                    c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    c.Open();
                    ds = c.exeRequette(requete);
                    c.Close();
                    c = null;
                    listes.Add(id);
                }
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
    protected void ReSelectSelectedRecords(object sender, GridViewRowEventArgs e)
    {

        /*var precis = System.Drawing.ColorTranslator.FromHtml("#00FF7F");
        var large = System.Drawing.ColorTranslator.FromHtml("#32CD32");
        var investisseur_ancien = System.Drawing.ColorTranslator.FromHtml("#FFA500");
        var investisseur_neuf = System.Drawing.ColorTranslator.FromHtml("#FFD700");*/
        
        if(e.Row.RowType == DataControlRowType.Header)
            e.Row.Cells[33].Attributes.Add("style", "display:none");
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[33].Attributes.Add("style", "display:none");
            if (e.Row.Cells[33].Text == "precis")
            {
                e.Row.BackColor = System.Drawing.Color.YellowGreen;
            }
            else if (e.Row.Cells[33].Text == "large")
            {
                e.Row.BackColor = System.Drawing.Color.PaleGreen;
            }
            else if (e.Row.Cells[33].Text == "investisseur ancien")
            {
                e.Row.BackColor = System.Drawing.Color.BurlyWood;
            }
            else if (e.Row.Cells[33].Text == "investisseur neuf")
            {
                e.Row.BackColor = System.Drawing.Color.Khaki;
            }
        }

        List<string> list = ViewState["SelectedRecordsA"] as List<string>;
        if (e.Row.RowType == DataControlRowType.DataRow && list != null)
        {
            var reference = GridViewAcq.DataKeys[e.Row.RowIndex].Value.ToString();
            if (list.Contains(reference))
            {
                CheckBox check = (CheckBox)e.Row.FindControl("CheckBoxArchiver");
                check.Checked = true;
            }
        }

        //On crée la bulle pour la case tout sélectionner.
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // On doit mettre la visibilité à false ici sinon on ne peut pas afficher le texte en tooltip
            e.Row.Cells[3].Visible = false;	//Prenom
            e.Row.Cells[4].Visible = false;
            //e.Row.Cells[5].Visible = false;
            //e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = true;
            //e.Row.Cells[16].Visible = false;//nb de piece min
            //e.Row.Cells[17].Visible = false;//nb de piece max
            e.Row.Cells[19].Visible = true;
            //e.Row.Cells[21].Visible = false;
            e.Row.Cells[22].Visible = false;//surface sejour max
            e.Row.Cells[23].Visible = false;//parking/box
            e.Row.Cells[24].Visible = false;//surface terrain min
            e.Row.Cells[25].Visible = false;
            e.Row.Cells[26].Visible = false;
            //e.Row.Cells[34].Visible = false;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
			
			e.Row.Cells[31].Attributes.Add("class", "nowrap");	//Empeche le retour a la ligne pour prix min
			e.Row.Cells[32].Attributes.Add("class", "nowrap");	//prix max
		
            // on affiche les accents correctement et on affiche le texte en tooltip et on met visible à false
            e.Row.Cells[4].Text = e.Row.Cells[4].Text.Replace("&#233;", "é");
            e.Row.Cells[4].Text = e.Row.Cells[4].Text.Replace("&#232;", "è");
            e.Row.Cells[4].Text = e.Row.Cells[4].Text.Replace("&#234;", "ê");
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            //e.Row.Cells[5].Visible = false;
            //e.Row.Cells[6].Visible = false;
            //e.Row.Cells[7].Visible = false;
            e.Row.Cells[19].Visible = true;
            e.Row.Cells[24].Visible = false;
            e.Row.Cells[25].Visible = false;
            e.Row.Cells[26].Visible = false;
            //e.Row.Cells[34].ToolTip = "Sélectionner un seul acquereur";

            // On ne fait pas apparaître les champs vides dans les tooltips
            int i = 0;
            while (i < 32)
            {
                e.Row.Cells[i].ToolTip = e.Row.Cells[i].ToolTip.Replace("&nbsp;", "");
                i++;
            }

			if(e.Row.Cells[1].Text  != "&nbsp;") e.Row.Cells[1].Text = e.Row.Cells[1].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[1].Text + "</span></div>";	//Date d'ajout	Consultier liste_acquereur.aspx
            if(e.Row.Cells[11].Text  != "&nbsp;") e.Row.Cells[11].Text =  e.Row.Cells[11].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[11].Text + "</span></div>";	//?
            if(e.Row.Cells[16].Text  != "&nbsp;") e.Row.Cells[16].Text =  e.Row.Cells[16].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[16].Text + "</span></div>";	//Nb piece min
            if(e.Row.Cells[17].Text  != "&nbsp;") e.Row.Cells[17].Text =  e.Row.Cells[17].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[17].Text + "</span></div>";	//Nb piece max
            if(e.Row.Cells[18].Text  != "&nbsp;") e.Row.Cells[18].Text =  e.Row.Cells[18].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[18].Text + "</span></div>";	//?
            if(e.Row.Cells[19].Text  != "&nbsp;") e.Row.Cells[19].Text =  e.Row.Cells[19].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[19].Text + "</span></div>";	//?
            if(e.Row.Cells[20].Text  != "&nbsp;") e.Row.Cells[20].Text =  e.Row.Cells[20].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[20].Text + "</span></div>";	//Surf. hab min
            if(e.Row.Cells[21].Text  != "&nbsp;") e.Row.Cells[21].Text =  e.Row.Cells[21].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[21].Text + "</span></div>";	//Surf? hab max
            if(e.Row.Cells[22].Text  != "&nbsp;") e.Row.Cells[22].Text =  e.Row.Cells[22].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[22].Text + "</span></div>";	//
            if(e.Row.Cells[23].Text  != "&nbsp;") e.Row.Cells[23].Text =  e.Row.Cells[23].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[23].Text + "</span></div>";
            if(e.Row.Cells[24].Text  != "&nbsp;") e.Row.Cells[24].Text =  e.Row.Cells[24].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[24].Text + "</span></div>";
            if(e.Row.Cells[25].Text  != "&nbsp;") e.Row.Cells[25].Text =  e.Row.Cells[25].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[25].Text + "</span></div>";
            if(e.Row.Cells[26].Text  != "&nbsp;") e.Row.Cells[26].Text =  e.Row.Cells[26].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[26].Text + "</span></div>";
            if(e.Row.Cells[28].Text  != "&nbsp;") e.Row.Cells[28].Text =  e.Row.Cells[28].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[28].Text + "</span></div>";
            if(e.Row.Cells[29].Text  != "&nbsp;") e.Row.Cells[29].Text =  e.Row.Cells[29].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[29].Text + "</span></div>";	//Facade?
            if(e.Row.Cells[32].Text  != "&nbsp;") e.Row.Cells[32].Text =  e.Row.Cells[32].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[32].Text + "</span></div>";	//Prix max
            if(e.Row.Cells[33].Text  != "&nbsp;") e.Row.Cells[33].Text =  e.Row.Cells[33].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[33].Text + "</span></div>";	//?
            
			string cinq = e.Row.Cells[5].Text;
            if(e.Row.Cells[5].Text  != "&nbsp;") e.Row.Cells[5].Text = e.Row.Cells[5].Text + "<div class = \"tooltip taleft\"><span>" + e.Row.Cells[4].Text + ((e.Row.Cells[4].Text != "&nbsp;")?"<br/>":"") + e.Row.Cells[6].Text + "&nbsp;" + e.Row.Cells[5].Text + "</span></div>";
            if(e.Row.Cells[6].Text  != "&nbsp;") e.Row.Cells[6].Text = e.Row.Cells[6].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[4].Text + "&nbsp;" + cinq + "&nbsp;" + e.Row.Cells[6].Text + "</span></div>";

            if(e.Row.Cells[2].Text  != "&nbsp;") e.Row.Cells[2].Text = e.Row.Cells[2].Text + "<div class = \"tooltip spanMySpace\"><span style='white-space: normal;'>" + ((e.Row.Cells[3].Text=="&nbsp;")?"":e.Row.Cells[3].Text) + " " + e.Row.Cells[2].Text 
																		+ ((DataBinder.Eval(e.Row.DataItem, "texte_complementaire").ToString() != "")
																			? ("<br/><br/>" + nl2br(DataBinder.Eval(e.Row.DataItem, "texte_complementaire").ToString()))
																			: "")
																		+ "</span></div>";
            
			e.Row.Cells[7].Text = e.Row.Cells[7].Text + "<div class = \"tooltip4\"><span>" + "Bureau: " + espaceTel(e.Row.Cells[7].Text);
			if(DataBinder.Eval(e.Row.DataItem, "portable").ToString() != "") e.Row.Cells[7].Text += "<br/> Portable: " + espaceTel(DataBinder.Eval(e.Row.DataItem, "portable").ToString());
			e.Row.Cells[7].Text += "</span></div>";
            
			if(e.Row.Cells[10].Text  != "&nbsp;") e.Row.Cells[10].Text = parserCible(e.Row.Cells[10].Text);
			e.Row.Cells[10].Attributes.Add("class", "nowrap");
			
            if(e.Row.Cells[27].Text  != "&nbsp;") e.Row.Cells[27].Text = e.Row.Cells[27].Text + "<div class = \"tooltip\"><span>" + "surf. terrain min: " + e.Row.Cells[20].Text + "\n surf. terrain max: " + e.Row.Cells[21].Text + "</span></div>";
            if(e.Row.Cells[30].Text  != "&nbsp;") e.Row.Cells[30].Text = e.Row.Cells[30].Text + "<div class = \"tooltip\"><span>Sélectionner tous les acquereurs</span></div>";
            //e.Row.Cells[30].ToolTip = "Modifier le bien" + "\n ascenseur: " + e.Row.Cells[22].Text + "\n parking: " + e.Row.Cells[23].Text + "\n sous-sol: " + e.Row.Cells[24].Text + "\n façade: " + e.Row.Cells[25].Text + "\n profondeur: " + e.Row.Cells[26].Text;
            if(e.Row.Cells[31].Text  != "&nbsp;") e.Row.Cells[31].Text = e.Row.Cells[31].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[31].Text + "</span></div>";
        }
		
        if (ViewState["NbRecords"] == null)
        {
            LabelbnBiens.Text = "0";
        }
        LabelbnBiens.Text = ViewState["NbRecords"].ToString();
    } 

    protected void Button1_Click_Tab(object sender, EventArgs e)
    {
        if (radioButtonAcheteur.Checked == true)
        {
            Session["TransactionAcq"] = "achat";
        }
        else
        {
            Session["TransactionAcq"] = "location";
        }

        Session["SminAcq"] = textBoxSurfaceMin.Text;
        Session["SmaxAcq"] = textBoxSurfaceMax.Text;
        Session["VilleRechercheAcq"] = textBoxVille.Text;
        Session["PaysRechercheAcq"] = textBoxPays.Text;
        Session["DepRechercheAcq"] = textBoxDep.Text;

        #region try...catch
        try
        {
            Session["textBoxMotCle1Acq"] = textBoxMotCle1.Text;
        }
        catch
        {
            Session["textBoxMotCle1Acq"] = " ";
        }

        try
        {
            Session["textBoxMotCle2Acq"] = textBoxMotCle2.Text;
        }
        catch
        {
            Session["textBoxMotCle2Acq"] = "";
        }

        try
        {
            Session["textBoxMotCle3Acq"] = textBoxMotCle3.Text;
        }
        catch
        {
            Session["textBoxMotCle3Acq"] = "";
        }
        try
        {
            Session["textBoxMotCle4Acq"] = textBoxMotCle4.Text;
        }
        catch
        {
            Session["textBoxMotCle4Acq"] = "";
        }
        try
        {
            Session["TextBoxBudgetMinAcq"] = TextBoxBudgetMin.Text;
        }
        catch
        {
            Session["TextBoxBudgetMinAcq"] = "";
        }
        try
        {
            Session["TextBoxBudgetMaxAcq"] = TextBoxBudgetMax.Text;
        }
        catch
        {
            Session["TextBoxBudgetMaxAcq"] = "";
        }
        try
        {
            Session["textBoxSurfaceMinAcq"] = textBoxSurfaceMin.Text;
        }
        catch
        {
            Session["textBoxSurfaceMinAcq"] = "";
        }
        try
        {
            Session["textBoxSurfaceMaxAcq"] = textBoxSurfaceMax.Text;
        }
        catch
        {
            Session["textBoxSurfaceMaxAcq"] = "";
        }
        try
        {
            Session["TextBoxSurfaceSMinAcq"] = textBoxSurfaceSMin.Text;
        }
        catch
        {
            Session["TextBoxSurfaceSMinAcq"] = "";
        }
        try
        {
            Session["TextBoxSurfaceSMaxAcq"] = textBoxSurfaceSMax.Text;
        }
        catch
        {
            Session["TextBoxSurfaceSMaxAcq"] = "";
        }
        try
        {
            Session["textBoxSurfaceTMinAcq"] = textBoxSurfaceTMin.Text;
        }
        catch
        {
            Session["textBoxSurfaceTMinAcq"] = "";
        }
        try
        {
            Session["textBoxSurfaceTMaxAcq"] = textBoxSurfaceTMax.Text;
        }
        catch
        {
            Session["textBoxSurfaceTMaxAcq"] = "";
        }
        try
        {
            Session["textBoxFacadeMin"] = textBoxFacadeMin.Text;
        }
        catch
        {
            Session["textBoxFacadeMin"] = "";
        }
        try
        {
            Session["textBoxFacadeMax"] = textBoxFacadeMax.Text;
        }
        catch
        {
            Session["textBoxFacadeMax"] = "";
        }
        try
        {
            Session["textBoxProfondeurMin"] = textBoxProfondeurMin.Text;
        }
        catch
        {
            Session["textBoxProfondeurMin"] = "";
        }
        try
        {
            Session["textBoxProfondeurMax"] = textBoxProfondeurMax.Text;
        }
        catch
        {
            Session["textBoxProfondeurMax"] = "";
        }
        try
        {
            Session["textBoxNom1"] = textBoxNom1.Text;
        }
        catch
        {
            Session["textBoxNom1"] = "";
        }        
        try
        {
            Session["textBoxPrenom1"] = textBoxPrenom1.Text;
        }
        catch
        {
            Session["textBoxPrenom1"] = "";
        }
        try
        {
            Session["textBoxTel"] = textBoxTel.Text;
        }
        catch
        {
            Session["textBoxTel"] = "";
        }
        try
        {
            Session["textBoxPortable"] = textBoxPortable.Text;
        }
        catch
        {
            Session["textBoxPortable"] = "";
        }
        try
        {
            Session["textBoxMail"] = textBoxMail.Text;
        }
        catch
        {
            Session["textBoxMail"] = "";
        }

        try
        {
            var tempDate = textBoxDate.Text; // 2012-10-22
            var tempDateParts = tempDate.Split('-'); // {"2012", "10", "22"}
            tempDate = string.Format("{0}/{1}/{2}", tempDateParts[2], tempDateParts[1], tempDateParts[0]); // 22/10/2012
            Session["textBoxDateMin"] = tempDate;
        }
        catch
        {
            Session["textBoxDateMin"] = "";
        }
        try
        {
            var tempDate = textBoxDateFin.Text;
            var tempDateParts = tempDate.Split('-');
            tempDate = string.Format("{0}/{1}/{2}", tempDateParts[2], tempDateParts[1], tempDateParts[0]);
            Session["textBoxDateMax"] = tempDate;
        }
        catch
        {
            Session["textBoxDateMax"] = "";
        }
        #endregion

        Session["radioButtonAcheteur"] = radioButtonAcheteur.Checked;
        Session["radioButtonLoueur"] = radioButtonLoueur.Checked;
        Session["checkBoxPiece1Acq"] = checkBoxPiece1.Checked;
        Session["checkBoxPiece2Acq"] = checkBoxPiece2.Checked;
        Session["checkBoxPiece3Acq"] = checkBoxPiece3.Checked;
        Session["checkBoxPiece4Acq"] = checkBoxPiece4.Checked;
        Session["checkBoxPiece5Acq"] = checkBoxPiece5.Checked;
        Session["checkBoxChambre1Acq"] = checkBoxChambre1.Checked;
        Session["checkBoxChambre2Acq"] = checkBoxChambre2.Checked;
        Session["checkBoxChambre3Acq"] = checkBoxChambre3.Checked;
        Session["checkBoxChambre4Acq"] = checkBoxChambre4.Checked;
        Session["checkBoxChambre5Acq"] = checkBoxChambre5.Checked;
        Session["annoncesPageAcq"] = DropDownListPageSize.SelectedValue;
        Session["dropDownListEtat"] = dropDownListEtat.SelectedValue;
        Session["dropDownListTypeAcq"] = dropDownListType.SelectedValue;
        Session["checkBoxAsc"] = checkBoxAsc.Checked;
        Session["checkBoxSous"] = checkBoxSous.Checked;
        Session["checkBoxPark"] = checkBoxPark.Checked;


        Session["checkBoxMaisonAcq"] = checkBoxMaison.Checked;
        Session["checkBoxAppartAcq"] = checkBoxAppart.Checked;
        Session["checkBoxTerrainAcq"] = checkBoxTerrain.Checked;
        Session["checkBoxAutreAcq"] = checkBoxAutre.Checked;
        BindData();
    }






    protected void ItemChange(object sender, EventArgs e)
    {
        if ((((DropDownList)sender).SelectedValue).ToString() == "10")
        {
            GridViewAcq.PageSize = 10;
            Session["annoncesPageA"] = 10;
        }
        if ((((DropDownList)sender).SelectedValue).ToString() == "20")
        {
            GridViewAcq.PageSize = 20;
            Session["annoncesPageA"] = 20;
        }
        if ((((DropDownList)sender).SelectedValue).ToString() == "30")
        {
            GridViewAcq.PageSize = 30;
            Session["annoncesPageA"] = 30;
        }
        if ((((DropDownList)sender).SelectedValue).ToString() == "50")
        {
            GridViewAcq.PageSize = 50;
            Session["annoncesPageA"] = 50;
        }
        if ((((DropDownList)sender).SelectedValue).ToString() == "100")
        {
            GridViewAcq.PageSize = 100;
            Session["annoncesPageA"] = 100;
        }
        BindData();
    }

    protected void Tout_Selectionner(object sender, EventArgs e)
    {
        CheckBox CheckBoxSelect = (CheckBox)sender;
        if (CheckBoxSelect.Checked)
        {
            foreach (GridViewRow row in GridViewAcq.Rows)
            {
                CheckBox check = (CheckBox)row.FindControl("CheckBoxArchiver");
                check.Checked = true;
            }
        }
        else
        {
            foreach (GridViewRow row in GridViewAcq.Rows)
            {
                CheckBox check = (CheckBox)row.FindControl("CheckBoxArchiver");
                check.Checked = false;
            }
        }
    }

    protected String affiche_A(string id)
    {
        String requete = "select `appartement` as appart from Acquereurs Where Acquereurs.[id_acq]=" + id + "";
        Connexion c1 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c1.Open();
        System.Data.DataSet ds1 = c1.exeRequette(requete);
        c1.Close();
        string appart = ds1.Tables[0].Rows[0]["appart"].ToString();
        string app = "";
        if (appart == "True")
        {
            app = "X";
        }
        return app;
    }

    protected String affiche_M(string id)
    {
        String requete2 = "select `maison` as mais from Acquereurs Where Acquereurs.[id_acq]=" + id + "";
        Connexion c2 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c2.Open();
        System.Data.DataSet ds2 = c2.exeRequette(requete2);
        c2.Close();
        string maison = ds2.Tables[0].Rows[0]["mais"].ToString();
        string mais = "";
        if (maison == "True")
        {
            mais = "X";
        }
        return mais;
    }

    protected String affiche_T(string id)
    {
        String requete3 = "select `terrain` as terr from Acquereurs Where Acquereurs.[id_acq]=" + id + "";
        Connexion c3 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c3.Open();
        System.Data.DataSet ds3 = c3.exeRequette(requete3);
        c3.Close();
        string terrain = ds3.Tables[0].Rows[0]["terr"].ToString();
        string terr = "";
        if (terrain == "True")
        {
            terr = "X";
        }
        return terr;
    }

    protected String affiche_D(string id)
    {
        String requete4 = "select `autre` as autr from Acquereurs Where Acquereurs.[id_acq]=" + id + "";
        Connexion c4 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c4.Open();
        System.Data.DataSet ds4 = c4.exeRequette(requete4);
        c4.Close();
        string autre = ds4.Tables[0].Rows[0]["autr"].ToString();
        string aut = "";
        if (autre == "True")
        {
            aut = "X";
        }
        return aut;
    }

    protected String affiche_Mail(string mail)
    {
		if(mail == "") return "<div class = \"tooltip\"><span>Non renseigné</span></div>";
		
		string mailTrunc = "";
		if(mail.Length > 12) mailTrunc = mail.Substring(0,12) + "[...]";
		else mailTrunc = mail;
        string stext = "";
        stext = "<A HREF=mailto:" + mail + ">" + mailTrunc + "</A><div class = \"tooltip\"><span>" + mail + "</span></div>";
        return stext;
    }

    protected string modifier_acquereur(string text)
    {
        string stext = "";
        stext = "<a href=\"modifier_acquereur.aspx?reference=" + text + "\"><img class=\"croix_rouge\" src=\"../img_site/calepin3.gif\" /></a>";
        return stext;
    }

    protected void Ajout_Acq(object sender, EventArgs e)
    {
        Session["ajout_acquereur"] = "true";
        Response.Redirect("./ajout_acquereur.aspx");
    }

    protected void Mandat(object sender, EventArgs e)
    {
        Session["idmandatRecherche"] = Request.Form["MyRadioButton"];
        if (Session["idmandatRecherche"] == null)
        {
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "veuillez sélectionnez un acquéreur grâce aux radio boutons";
        }
        else
        {
            Response.Redirect("./MandatRecherche.aspx");
        }
    }

	protected void CalculRapprochement(object sender, EventArgs e)
    {
		string selectedValue = Request.Form["MyRadioButton"];
		string id = selectedValue;
        if (id == null)
        {
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "veuillez sélectionner un radio bouton";
        }
        else
        {	
			Response.Redirect("./rapprochement.aspx?idAcq=" + id + "");
        }
    }

    protected void Voir_Historique(object sender, EventArgs e)
    {
        String selectedValue = Request.Form["MyRadioButton"];
        Session["idacquereur"] = selectedValue;
        if ((String)Session["idacquereur"] == null)
        {
            LabelErrorLogin.Visible = true;
            LabelErrorLogin.Text = "veuillez sélectionner un radio bouton";
        }
        else
        {
            Response.Redirect("./historique_acquereur.aspx");
        }
    }
	
	
	
	
	//Methodes d'affichage esthetique
	
	//NewLine To <br/>
	protected String nl2br(string s)
	{
		Regex rgx = new Regex("\r\n|\r|\n");
		return rgx.Replace(s,"<br/>"); 
	}
	
	protected string espaceTel(string tel)
	{
		string telFormat = "";
		int k = 0;
		while((k+1)*2 < tel.Length)
		{
			telFormat = telFormat + " "  + tel.Substring(k*2, 2);
			k++;
		}
		telFormat = telFormat + " "  +  tel.Substring(k*2, tel.Length - k*2);
		
		return telFormat;
	}
	
	private string parserCible(string cible)
	{
		string[] champCible = new string[]{"",""};
		string[] listeCible = cible.Split(new string[]{"|"},System.StringSplitOptions.RemoveEmptyEntries);
		int i = 0;
		
		foreach(string ligne in listeCible)
		{	
			Dictionary<string,string> hashMap = new Dictionary<string,string>();
			string[] listeValue = ligne.Split(new string[]{"%"},System.StringSplitOptions.RemoveEmptyEntries);
			
			foreach(string value in listeValue)
			{
				string[] param = value.Split(new string[]{":"},System.StringSplitOptions.RemoveEmptyEntries);
				hashMap.Add(param[0],param[1]);
			}
			
			string newCible = "";
			string newCibleComplet = "";
			
			if(hashMap["type"] == "pays")
				newCibleComplet = hashMap["nom"] + "<br/>";
			else
				newCibleComplet = hashMap["nom"] + " (" + hashMap["code"] + ")<br/>";
			newCible = hashMap["nom"];
				
			if(i<2)//limite a 2 lignes, utilise pour l'affichage
			{
				if(newCible.Length > 15)
					champCible[0] += newCible.Substring(0,15) + "...<br/>";
				else
					champCible[0] += newCible + "<br/>";	
			}
			champCible[1] += newCibleComplet;			//tous les criteres de localisation, utilise pour le span
				
			i++;
		}
		
		champCible[0] = champCible[0].Substring(0, champCible[0].Length - 5);
		if(i>2) champCible[0] += " <br/>[...]";
		champCible[1] = champCible[1].Substring(0, champCible[1].Length - 5);
		
		return champCible[0] + "<div class = 'tooltip taleft'><span>" + champCible[1] +"</span></div>";
	}
}


