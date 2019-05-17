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

public partial class listeCommissions : System.Web.UI.Page
{
    string _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {		
		Membre member = (Membre)Session["Membre"];
        if (member == null ||  member.STATUT != "ultranego")
        {
			Response.Redirect("recherche.aspx");
            Response.Close();
        }
		
		((Label)Page.Master.FindControl("titrebandeau")).Text = "Accueil";
        
        string action = Request.QueryString["action"];
        if (action != null)
            if (action == "add")
                msg.Text = "La commission a été ajoutée";


        if(!IsPostBack)
        {
			
			Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c.Open();
            DataRowCollection listNego = c.exeRequetteOpen("SELECT idclient,nom_client,prenom_client FROM Clients WHERE statut = 'nego' OR statut = 'ultranego' ORDER BY nom_client ASC").Tables[0].Rows;
            c.Close();
            c = null;
            

            //Remplissage des listes deroulantes
            foreach (DataRow ligne in listNego)
            {
                FuAsp_nego.Items.Add(new ListItem(ligne["nom_client"].ToString().ToUpper() + " " + ligne["prenom_client"], ligne["idclient"].ToString()));
            }

            //Remplissage avec les anciens criteres de recherches
			if(Session["annoncesPage"] != null)
				DropDownListPageSize.SelectedValue = Session["annoncesPage"].ToString();
			else
				DropDownListPageSize.SelectedValue = "30";
				
			GridView1.PageSize = int.Parse(DropDownListPageSize.SelectedValue);

            if(Session["dateCompromisMin"] != null)
             TB_DateCompromisMin.Text = Session["dateCompromisMin"].ToString();
            if(Session["dateCompromisMax"] != null)
             TB_DateCompromisMax.Text = Session["dateCompromisMax"].ToString();
            if(Session["dateSignatureMin"] != null)
             TB_DateSignatureMin.Text = Session["dateSignatureMin"].ToString();
            if (Session["dateSignatureMax"] != null)
             TB_DateSignatureMax.Text = Session["dateSignatureMax"].ToString();

            if (Session["dateSignBailMin"] != null)
                TB_DateSignBailMin.Text = Session["dateSignBailMin"].ToString();
            if (Session["dateSignBailMax"] != null)
                TB_DateSignBailMax.Text = Session["dateSignBailMax"].ToString();

            if(Session["FuAsp_nego"] != null)
                FuAsp_nego.SelectedValue = Session["FuAsp_nego"].ToString();
			
			
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
        table.DefaultView.Sort = (String)Session["sortExpressionX"] + (String)Session["directionX"];
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
        Session["sortExpressionX"] = e.SortExpression;
        Session["directionX"] = string.Empty;

        if (SortDirection == SortDirection.Ascending)
        {
            SortDirection = SortDirection.Descending;
            Session["directionX"] = " DESC";
        }
        else
        {
            SortDirection = SortDirection.Ascending;
            Session["directionX"] = " ASC";
        }
        DataTable table = this.GetData();
        table.DefaultView.Sort = (String)Session["sortExpressionX"] + (String)Session["directionX"];
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
            if (ViewState["SortDirectionX"] == null)
            {
                ViewState["SortDirectionX"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["SortDirectionX"];
        }
        set
        {
            ViewState["SortDirectionX"] = value;
        }
    }

    /// <summary> 
    /// Gets the data. 
    /// </summary> 
    private DataTable GetData()
    {
		Membre member = (Membre)Session["Membre"];
        string critere = "";
            



        if (FuAsp_nego.SelectedValue != "-1")
            critere += " AND Clients.idclient = " + FuAsp_nego.SelectedValue;

        if (Session["dateCompromisMin"] != null && Session["dateCompromisMin"].ToString() != "")
        {
            string[] date = Session["dateCompromisMin"].ToString().Split('/');
            critere += " AND date_compromis < #" + date[1] + "/" + date[0] + "/" + date[2] + "#";
        }

        if (Session["dateCompromisMax"] != null && Session["dateCompromisMax"].ToString() != "")
        {
            string[] date = Session["dateCompromisMax"].ToString().Split('/');
            critere += " AND date_compromis > #" + date[1] + "/" + date[0] + "/" + date[2] + "#";
        }

        if (Session["dateSignatureMin"] != null && Session["dateSignatureMin"].ToString() != "")
        {
            string[] date = Session["dateSignatureMin"].ToString().Split('/');
            critere += " AND date_signature < #" + date[1] + "/" + date[0] + "/" + date[2] + "#";
        }

        if (Session["dateSignatureMax"] != null && Session["dateSignatureMax"].ToString() != "")
        {
            string[] date = Session["dateSignatureMax"].ToString().Split('/');
            critere += " AND date_signature > #" + date[1] + "/" + date[0] + "/" + date[2] + "#";
        }
        if (Session["dateSignBailMax"] != null && Session["dateSignBailMax"].ToString() != "")
        {
            string[] date = Session["dateSignBailMax"].ToString().Split('/');
            critere += " AND date_signature_bail > #" + date[1] + "/" + date[0] + "/" + date[2] + "#";
        }


        DataTable table = new DataTable();
        string sql = "SELECT  Ventes.*, Ventes_Honoraires.*, nom_client,prenom_client,nom,prenom FROM  Ventes_Honoraires,Ventes,Clients,Acquereurs "
                    +"WHERE Ventes_Honoraires.id_nego = Clients.idclient "
                    +"AND id_acq = Ventes.id_acquereur AND Ventes.valider_proposition = true AND Ventes.valider_signature=true AND Ventes.ID = Ventes_Honoraires.id_vente "
                    + critere        
             + " ORDER BY date_signature DESC";

        string sql1 = "SELECT Locations.*, Ventes_Honoraires.*, nom_client,prenom_client,nom,prenom FROM Locations, Ventes_Honoraires,Clients,Acquereurs "
                      +"WHERE Ventes_Honoraires.id_nego = Clients.idclient "
                    +"AND id_acq = Locations.id_acquereur AND Locations.valider_signature= true AND Locations.ID = Ventes_Honoraires.id_location"
             + critere        
             + " ORDER BY date_signature_bail DESC";
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
        using (OdbcConnection cI = new OdbcConnection(_ConnectionString))
        {
            // write the sql statement to execute 
            //string sql = recherche.ToString();
            // instantiate the command object to fire 
            using (OdbcCommand cmd = new OdbcCommand(sql1, cI))
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
            

            e.Row.Cells[2].Text = "" + DataBinder.Eval(e.Row.DataItem, "date_signature_bail", "{0:d}") + DataBinder.Eval(e.Row.DataItem, "date_signature", "{0:d}");
                e.Row.Cells[3].Text = "<a href='fichedetail1.aspx?ref=" + DataBinder.Eval(e.Row.DataItem, "ref_bien") + "'>"
                + e.Row.Cells[3].Text + "</a>";
                e.Row.Cells[4].Text += " " + DataBinder.Eval(e.Row.DataItem, "nom_client");

                e.Row.Cells[5].Text = "<a href='modifier_acquereur.aspx?reference=" + DataBinder.Eval(e.Row.DataItem, "id_acquereur") + "'>"
                    + e.Row.Cells[5].Text + " " + DataBinder.Eval(e.Row.DataItem, "nom")
                    +"</a>";
			
			    if((bool)DataBinder.Eval(e.Row.DataItem, "parrainage") == true)
				e.Row.Cells[6].Text = "Parrainage";
			    else
                    if (DataBinder.Eval(e.Row.DataItem, "type").ToString() == "Libre")
				        e.Row.Cells[6].Text = "Libre";
                    else
                    {
                        e.Row.Cells[6].Text = "Commission";
                    }
			
                e.Row.Cells[8].Text += " " + DataBinder.Eval(e.Row.DataItem, "prenom_notaire");
                e.Row.Cells[9].Text = espaceTel(e.Row.Cells[9].Text);
                e.Row.Cells[10].Text = "<a href='mailto:" + e.Row.Cells[10].Text + "'>" + e.Row.Cells[10].Text + "</a>";

                e.Row.Cells[12].Text = (e.Row.Cells[12].Text == "True")
                    ? "<img class='croix_rouge' src='../img_site/true.png' />"
                    : "<img class='croix_rouge' src='../img_site/false.png' />";

                e.Row.Cells[14].Text = (e.Row.Cells[14].Text == "True")
                    ? "<img class='croix_rouge' src='../img_site/true.png' />"
                    : "<img class='croix_rouge' src='../img_site/false.png' />";


                if (DataBinder.Eval(e.Row.DataItem, "id_vente").ToString() != "")
                {
                    e.Row.Cells[15].Text = "<a href='venteAfficher.aspx?id=" + DataBinder.Eval(e.Row.DataItem, "id_vente")
                        + "'><img src='../img_site/loupe.png' class='croix_rouge' alt = ''></a><div class ='tooltip'><span>Voir détails</span></div>";
                }
                else
                {
                    e.Row.Cells[15].Text = "<a href='locationAfficher.aspx?id=" + DataBinder.Eval(e.Row.DataItem, "id_location")
                    + "'><img src='../img_site/loupe.png' class='croix_rouge' alt = ''></a><div class ='tooltip'><span>Voir détails</span></div>";
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
        BindData();
    }


    private string espaceTel(string tel)
    {
        Regex x = new Regex("[. ,]");
        tel = x.Replace(tel, "");
        string formatTel = "";

        int i = 0;
        while(i+2 < tel.Length)
        {
            formatTel += tel.Substring(i, 2) + " ";
            i = i + 2;
        }
        formatTel += tel.Substring(i, tel.Length - i);

        return formatTel;
    }
}
