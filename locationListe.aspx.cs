using System;
using System.Data;
using System.Data.Odbc;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public partial class locationListe : System.Web.UI.Page
{
    string _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    string racine_site;

    protected void Page_Load(object sender, EventArgs e)
    {
        Membre member = (Membre)Session["Membre"];
        if (member == null || member.STATUT != "ultranego")
        {
            Response.Redirect("recherche.aspx");
            Response.Close();
        }

        ((Label)Page.Master.FindControl("titrebandeau")).Text = "Accueil";

        Connexion cI = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        cI.Open();
        System.Data.DataSet dsI = cI.exeRequette("Select * from Environnement");
        cI.Close();

        racine_site = (String)dsI.Tables[0].Rows[0]["Chemin_racine_site"];

        if (!IsPostBack)
        {
            Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c.Open();
            DataRowCollection listAcq = c.exeRequetteOpen("SELECT id_acq,nom,prenom,ville,code_postal FROM Acquereurs WHERE actif = 'actif' ORDER BY nom ASC").Tables[0].Rows;
            DataRowCollection listNego = c.exeRequetteOpen("SELECT idclient,nom_client,prenom_client FROM Clients WHERE statut = 'nego' OR statut = 'ultranego' ORDER BY nom_client ASC").Tables[0].Rows;
            c.Close();
            c = null;

            //Remplissage des listes deroulantes
            foreach (DataRow ligne in listAcq)
            {
                FuAsp_acq.Items.Add(new ListItem(ligne["nom"].ToString().ToUpper() + " " + ligne["prenom"] + " (" + ligne["ville"] + " - " + ligne["code_postal"] + ")", ligne["id_acq"].ToString()));
            }

            foreach (DataRow ligne in listNego)
            {
                FuAsp_nego.Items.Add(new ListItem(ligne["nom_client"].ToString().ToUpper() + " " + ligne["prenom_client"], ligne["idclient"].ToString()));
            }

            //Remplissage avec les anciens criteres de recherches
            if (Session["annoncesPage"] != null)
                DropDownListPageSize.SelectedValue = Session["annoncesPage"].ToString();
            else
                DropDownListPageSize.SelectedValue = "30";
            GridView1.PageSize = int.Parse(DropDownListPageSize.SelectedValue);
            if (Session["vl_valideProp"] != null)
                valideProp.SelectedValue = Session["vl_valideProp"].ToString();

            if (Session["vl_valideVente"] != null)
                valideVente.SelectedValue = Session["vl_valideVente"].ToString();

            //if (Session["vl_dateCompromisMin"] != null)
            //    TB_DateCompromisMin.Text = Session["vl_dateCompromisMin"].ToString();
            //if (Session["vl_dateCompromisMax"] != null)
            //    TB_DateCompromisMax.Text = Session["vl_dateCompromisMax"].ToString();
            if (Session["vl_dateSignBailMin"] != null)
                TB_DateSignatureMin.Text = Session["vl_dateSignBailMin"].ToString();
            if (Session["vl_dateSignBailMax"] != null)
                TB_DateSignatureMax.Text = Session["vl_dateSignBailMax"].ToString();

            if (Session["vl_FuAsp_nego"] != null)
                FuAsp_nego.SelectedValue = Session["vl_FuAsp_nego"].ToString();
            if (Session["vl_FuAsp_acq"] != null)
                FuAsp_acq.SelectedValue = Session["vl_FuAsp_acq"].ToString();

            BindData();

        }



    }


    protected void PaginateTheData(object sender, GridViewPageEventArgs e)
    {
        List<string> list = new List<string>();
        if (ViewState["SelectedRecordsX"] != null)
        {
            list = (List<string>)ViewState["SelectedRecordsX"];
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
        table.DefaultView.Sort = (String)Session["vl_sortExpression"] + (String)Session["vl_direction"];
        GridView1.DataSource = table;
        ViewState["SelectedRecordsX"] = list;
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
        Session["vl_sortExpression"] = e.SortExpression;
        Session["vl_direction"] = string.Empty;

        if (SortDirection == SortDirection.Ascending)
        {
            SortDirection = SortDirection.Descending;
            Session["vl_direction"] = " DESC";
        }
        else
        {
            SortDirection = SortDirection.Ascending;
            Session["vl_direction"] = " ASC";
        }
        DataTable table = this.GetData();
        table.DefaultView.Sort = (String)Session["vl_sortExpression"] + (String)Session["vl_direction"];
        GridView1.DataSource = table;
        GridView1.DataBind();
    }

    private void BindData()
    {
        // specify the data source for the GridView
        GridView1.DataSource = this.GetData();
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
            if (ViewState["vl_SortDirection"] == null)
            {
                ViewState["vl_SortDirection"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["vl_SortDirection"];
        }
        set
        {
            ViewState["vl_SortDirection"] = value;
        }
    }

    /// <summary> 
    /// Gets the data. 
    /// </summary> 
    private DataTable GetData()
    {
        string critere = "";

        if (Session["vl_valideProp"] == "1")
            critere += " AND valider_proposition = true";
        else if (Session["vl_valideProp"] == "0")
            critere += " AND valider_proposition = false";

        if (Session["vl_valideVente"] == "1")
            critere += " AND valider_signature = true";
        if (Session["vl_valideVente"] == "0")
            critere += " AND valider_signature = false";

        if (FuAsp_acq.SelectedValue != "-1")
            critere += " AND Acquereurs.id_acq = " + FuAsp_acq.SelectedValue;

        if (FuAsp_nego.SelectedValue != "-1")
            critere += " AND Clients.idclient = " + FuAsp_nego.SelectedValue;


        //if (Session["vl_dateCompromisMin"] != null && Session["vl_dateCompromisMin"].ToString() != "")
        //{
        //    string[] date = Session["vl_dateCompromisMin"].ToString().Split('/');
        //    critere += " AND date_compromis < #" + date[1] + "/" + date[0] + "/" + date[2] + "#";
        //}

        //if (Session["vl_dateCompromisMax"] != null && Session["vl_dateCompromisMax"].ToString() != "")
        //{
        //    string[] date = Session["vl_dateCompromisMax"].ToString().Split('/');
        //    critere += " AND date_compromis > #" + date[1] + "/" + date[0] + "/" + date[2] + "#";
        //}

        if (Session["vl_dateSignBailMin"] != null && Session["vl_dateSignBailMin"].ToString() != "")
        {
            string[] date = Session["vl_dateSignBailMin"].ToString().Split('/');
            critere += " AND date_signature_bail < #" + date[1] + "/" + date[0] + "/" + date[2] + "#";
        }

        if (Session["vl_dateSignBailMax"] != null && Session["vl_dateSignBailMax"].ToString() != "")
        {
            string[] date = Session["vl_dateSignBailMax"].ToString().Split('/');
            critere += " AND date_signature_bail > #" + date[1] + "/" + date[0] + "/" + date[2] + "#";
        }

        DataTable table = new DataTable();
        string sql = "SELECT *,nom_client,prenom_client,nom,prenom,[nom vendeur],[prenom vendeur] FROM Biens,Locations,Clients,Acquereurs WHERE Biens.ref = Locations.ref_bien AND Locations.id_nego = Clients.idclient AND id_acq = id_acquereur"
             + critere
             + " ORDER BY ID DESC";

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
        if (table.Rows.Count == 0)
            gtfo.Visible = true;

        return table;
    }

    /// <summary> 
    /// Looks for selection. 
    /// </summary> 
    /// <param name="sender">The sender.</param> 
    /// <param name="e">The <seecref="System.Web.UI.WebControls.GridViewRowEventArgs"/>
    ///     instance containing the event data.</param> 
    protected void ReSelectSelectedRecords(object sender, GridViewRowEventArgs e)
    {
        List<string> list = ViewState["SelectedRecordsX"] as List<string>;
        if (e.Row.RowType == DataControlRowType.DataRow && list != null)
        {
            var reference = GridView1.DataKeys[e.Row.RowIndex].Value.ToString();
            if (list.Contains(reference))
            {
                CheckBox check = (CheckBox)e.Row.FindControl("CheckBoxArchiver");
                check.Checked = true;
            }
        }

        //On crée la bulle pour la case tout sélectionner.
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //Ajoute un parametre title a la cellule
            //e.Row.Cells[1].ToolTip = "YOYOYO";
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[2].Text = "<a href='fichedetail1.aspx?ref=" + DataBinder.Eval(e.Row.DataItem, "ref_bien") + "'>"
                + e.Row.Cells[2].Text + "</a>"
                + "<div class='tooltip'><span>" + e.Row.Cells[2].Text + "</span></div>";
            e.Row.Cells[3].Text += " " + DataBinder.Eval(e.Row.DataItem, "nom_client");

            e.Row.Cells[4].Text = "<a href='modifier_acquereur.aspx?reference=" + DataBinder.Eval(e.Row.DataItem, "id_acquereur") + "'>"
                + e.Row.Cells[4].Text + " " + DataBinder.Eval(e.Row.DataItem, "nom")
                + "</a>"
                + "<div class='tooltip'><span>" + e.Row.Cells[4].Text + " " + DataBinder.Eval(e.Row.DataItem, "nom") + "</span></div>";

            //e.Row.Cells[8].Text += " " + DataBinder.Eval(e.Row.DataItem, "nom_notaire");
           // e.Row.Cells[8].Text +=
           //         "<div class='tooltip'><span>" + e.Row.Cells[8].Text + "<br/>"
           //         + DataBinder.Eval(e.Row.DataItem, "tel_notaire") + "<br/>"
           //         + DataBinder.Eval(e.Row.DataItem, "mail_notaire") + "<br/>"
           //         + DataBinder.Eval(e.Row.DataItem, "adresse_notaire") + "<br/>"
           //         + DataBinder.Eval(e.Row.DataItem, "cp_notaire") + DataBinder.Eval(e.Row.DataItem, "ville_notaire")
           //         + "</span></div>";

            //e.Row.Cells[8].Text = espaceTel(e.Row.Cells[8].Text);
            //e.Row.Cells[9].Text = "<a href='mailto:" + e.Row.Cells[9].Text + "'>" + e.Row.Cells[9].Text + "</a>"
            //    + "<div class='tooltip'><span>" + e.Row.Cells[9].Text + "</span></div>";

            //e.Row.Cells[8].Text = (e.Row.Cells[8].Text == "True")
            //    ? "<img class='croix_rouge' src='../img_site/true.png' />"
            //    : "<img class='croix_rouge' src='../img_site/false.png' />";

            e.Row.Cells[9].Text = (e.Row.Cells[9].Text == "True")
                ? "<img class='croix_rouge' src='../img_site/true.png' />"
                : "<img class='croix_rouge' src='../img_site/false.png' />";

            e.Row.Cells[10].Text = "<a href='location.aspx?ref=" + DataBinder.Eval(e.Row.DataItem, "ref_bien") + "&id=" + DataBinder.Eval(e.Row.DataItem, "id")
                    + "'><img src='../img_site/calepin3.gif' class='croix_rouge' alt = ''></a><div class ='tooltip'><span>Modifier</span></div>";

            e.Row.Cells[11].Text = "<a href='locationAfficher.aspx?id=" + DataBinder.Eval(e.Row.DataItem, "id")
                    + "'><img src='../img_site/loupe.png' class='croix_rouge' alt = ''></a><div class ='tooltip'><span>Voir détails</span></div>";


            string filePathBail = racine_site + "Locations\\" + DataBinder.Eval(e.Row.DataItem, "id") + "_bail.pdf";

            if (System.IO.File.Exists(filePathBail))
                e.Row.Cells[12].Text = "<a href='../Locations/" + DataBinder.Eval(e.Row.DataItem, "id") + "_bail.pdf' target='_blank'><img src='../img_site/pdf.png' class='croix_rouge' alt = ''></a>";

            //if (System.IO.File.Exists(filePathActe))
            //    e.Row.Cells[17].Text = "<a href='../Ventes/" + DataBinder.Eval(e.Row.DataItem, "id") + "_acte.pdf' target='_blank'><img src='../img_site/pdf.png' class='croix_rouge' alt = ''></a>";

            if ((bool)DataBinder.Eval(e.Row.DataItem, "valider_signature") == true)
                e.Row.Cells[10].Text = "";
            else
            {
                ((ImageButton)e.Row.FindControl("buttonDelete")).Attributes["customvalue"] = DataBinder.Eval(e.Row.DataItem, "ID").ToString();
            }

            for (int i = 0; i < 14; i++)
            {
                if (i == 2  || i == 4  || i == 9|| i ==10 || i == 11 ||i ==12  || i == 13 || i == 14)
                    continue;
                e.Row.Cells[i].Text = e.Row.Cells[i].Text + "<div class='tooltip'><span>" + e.Row.Cells[i].Text + "</span></div>";
            }

        }
    }

    protected void ItemChange(object sender, EventArgs e)
    {
        if ((((DropDownList)sender).SelectedValue).ToString() == "10")
        {
            GridView1.PageSize = 10;
            Session["annoncesPageX"] = 10;
        }
        if ((((DropDownList)sender).SelectedValue).ToString() == "20")
        {
            GridView1.PageSize = 20;
            Session["annoncesPageX"] = 20;
        }
        if ((((DropDownList)sender).SelectedValue).ToString() == "30")
        {
            GridView1.PageSize = 30;
            Session["annoncesPageX"] = 30;
        }
        if ((((DropDownList)sender).SelectedValue).ToString() == "50")
        {
            GridView1.PageSize = 50;
            Session["annoncesPageX"] = 50;
        }
        if ((((DropDownList)sender).SelectedValue).ToString() == "100")
        {
            GridView1.PageSize = 100;
            Session["annoncesPageX"] = 100;
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


    protected void filtrer(object sender, EventArgs e)
    {
        Session["vl_FuAsp_nego"] = FuAsp_nego.SelectedValue;
        Session["vl_FuAsp_acq"] = FuAsp_acq.SelectedValue;

        Session["vl_valideProp"] = valideProp.SelectedValue;
        Session["vl_valideVente"] = valideVente.SelectedValue;
        Session["vl_dateSignBailMin"] = TB_DateSignatureMin.Text;
        Session["vl_dateSignBailMax"] = TB_DateSignatureMax.Text;
        BindData();
    }

    //Buttou valider vente
    protected void buttonValiderProp(object sender, EventArgs e)
    {
        msg.Text = "";
        validerLocation(false);
    }

    protected void buttonValiderLocation(object sender, EventArgs e)
    {
        msg.Text = "";
        validerLocation(true);
    }

    //Boutton corbeille
    protected void deleteLocation(object sender, EventArgs e)
    {
        Location.deleteLocation(((ImageButton)sender).Attributes["customvalue"]);
        msg.Text = "Location supprimée";
        BindData();
    }

    private void validerLocation(bool location)
    {
        //string champ = "valider_proposition = (NOT valider_proposition) ";
        string listId = "";
        bool dateSignatureValide = true;
        bool valide = true;
        string champ = "";

        if (location)
            champ = "valider_signature = (NOT valider_signature) ";

        //On ajoute la valeur de la référence du bien dans la variable de session ref_sel

        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox check = (CheckBox)row.FindControl("CheckBoxArchiver");
            string selectedKey = GridView1.DataKeys[row.RowIndex].Value.ToString();
            if (check.Checked)
            {
                listId += selectedKey + ",";
                if (location)
                {
                    string[] dateArray = row.Cells[8].Text.Split('<')[0].Split('/');
                    if (dateArray.Length == 3)
                    {
                        int y = int.Parse(dateArray[2]);
                        int m = int.Parse(dateArray[1]);
                        int d = int.Parse(dateArray[0]);
                        DateTime date = new DateTime(y, m, d);
                        if (date > DateTime.Now)
                        {
                            valide = false;
                            msg.Text += "<br/>Impossible de valider la location, la date de signature du bail n'est pas encore passée.";
                        }
                    }
                    else if (dateArray.Length == 1)
                    {
                        msg.Text += "<br/>Impossible de valider la location, aucune date de signature du bail n'a été saisie.";
                        valide = false;
                    }
                }
            }
        }



        if (listId == "")
        {
            valide = false;
            msg.Text += "<br/>Veuillez séléctionner au moins une location.";
        }

        if (valide)
        {
            //On recupere la liste des biens dans la variable de session
            string requete = "UPDATE Locations SET " + champ + "  WHERE ID IN (" + listId + ")";
            Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c.Open();
            c.exeRequette(requete);
            c.Close();
            c = null;
            BindData();

            msg.Text = "Mise à jour effectuée<br/>";
        }
    }

    private string espaceTel(string tel)
    {
        if (tel == "&nbsp;")
            return tel;
        Regex x = new Regex("[. ,]");
        tel = x.Replace(tel, "");
        string formatTel = "";

        int i = 0;
        while (i + 2 < tel.Length)
        {
            formatTel += tel.Substring(i, 2) + " ";
            i = i + 2;
        }
        formatTel += tel.Substring(i, tel.Length - i);

        return formatTel;
    }

    protected void directionAjoutCommissionLibre(object sender, EventArgs e)
    {
        LabelError.Visible = false;

        List<string> list = new List<string>();

        //On récupère tous les ID vente sélectionné
        foreach (GridViewRow row in GridView1.Rows)
        {
            System.Web.UI.WebControls.CheckBox check = (System.Web.UI.WebControls.CheckBox)row.FindControl("CheckBoxArchiver");
            var selectedKey = GridView1.DataKeys[row.RowIndex].Value.ToString();

            if (check.Checked)
            {
                if (!list.Contains(selectedKey))
                {
                    list.Add(selectedKey);
                }
            }
        }
        //si il n'y a pas de vente sélectionnée
        if (list.Count < 1)
        {
            LabelError.Visible = true;
            LabelError.Text = "veuillez sélectionnez une location à ajouter des commission libre<br/><br/>";
        }

        //si il y a plus d'une vente sélectionnée
        if (list.Count > 1)
        {

            LabelError.Visible = true;
            LabelError.Text = "veuillez sélectionnez une unique vente pour ajouter des commissions libre!<br/><br/>";

        }

        if (list.Count == 1)
        {
            foreach (string item in list)
            {
                Response.Redirect("ajoutCommissionLibre.aspx?Ref=" + item);
            }


        }


    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}