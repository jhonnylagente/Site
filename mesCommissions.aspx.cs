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

public partial class mesCommissions : System.Web.UI.Page
{
    string _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {		
		Membre member = (Membre)Session["Membre"];
        if (member == null || (member.STATUT != "nego" && member.STATUT != "ultranego"))
        {
			Response.Redirect("recherche.aspx");
            Response.Close();
        }
		
		((Label)Page.Master.FindControl("titrebandeau")).Text = "Accueil";

        if(!IsPostBack)
        {

            //Remplissage des listes deroulantes


            //Remplissage avec les anciens criteres de recherches
			if(Session["annoncesPage"] != null)
				DropDownListPageSize.SelectedValue = Session["annoncesPage"].ToString();
			else
				DropDownListPageSize.SelectedValue = "30";
				
			GridView1.PageSize = int.Parse(DropDownListPageSize.SelectedValue);
			BindData();
        }

        

    }


    protected void PaginateTheData(object sender, GridViewPageEventArgs e)
    {
        List<string> list = new List<string>();
        if (ViewState["mc_SelectedRecords"] != null)
        {
            list = (List<string>)ViewState["mc_SelectedRecords"];
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
        table.DefaultView.Sort = (String)Session["mc_sortExpressionX"] + (String)Session["mc_directionX"];
        GridView1.DataSource = table;
        ViewState["mc_SelectedRecords"] = list;
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
        Session["mc_sortExpressionX"] = e.SortExpression;
        Session["mc_directionX"] = string.Empty;

        if (SortDirection == SortDirection.Ascending)
        {
            SortDirection = SortDirection.Descending;
            Session["mc_directionX"] = " DESC";
        }
        else
        {
            SortDirection = SortDirection.Ascending;
            Session["mc_directionX"] = " ASC";
        }
        DataTable table = this.GetData();
        table.DefaultView.Sort = (String)Session["mc_sortExpressionX"] + (String)Session["mc_directionX"];
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
            if (ViewState["mc_SortDirectionX"] == null)
            {
                ViewState["mc_SortDirectionX"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["mc_SortDirectionX"];
        }
        set
        {
            ViewState["mc_SortDirectionX"] = value;
        }
    }

    /// <summary> 
    /// Gets the data. 
    /// </summary> 
    private DataTable GetData()
    {
		Membre member = (Membre)Session["Membre"];
        string critere = "";
            





        if (Session["mc_dateCompromisMin"] != null && Session["mc_dateCompromisMin"].ToString() != "")
        {
            string[] date = Session["mc_dateCompromisMin"].ToString().Split('/');
            critere += " AND date_compromis < #" + date[1] + "/" + date[0] + "/" + date[2] + "#";
        }

        if (Session["mc_dateCompromisMax"] != null && Session["mc_dateCompromisMax"].ToString() != "")
        {
            string[] date = Session["mc_dateCompromisMax"].ToString().Split('/');
            critere += " AND date_compromis > #" + date[1] + "/" + date[0] + "/" + date[2] + "#";
        }

        if (Session["mc_dateSignatureMin"] != null && Session["mc_dateSignatureMin"].ToString() != "")
        {
            string[] date = Session["mc_dateSignatureMin"].ToString().Split('/');
            critere += " AND date_signature < #" + date[1] + "/" + date[0] + "/" + date[2] + "#";
        }

        if (Session["mc_dateSignatureMax"] != null && Session["mc_dateSignatureMax"].ToString() != "")
        {
            string[] date = Session["mc_dateSignatureMax"].ToString().Split('/');
            critere += " AND date_signature > #" + date[1] + "/" + date[0] + "/" + date[2] + "#";
        }

                    

        DataTable table = new DataTable();
        string sql = "SELECT Ventes.*, Ventes_Honoraires.*, [prenom vendeur], [nom vendeur] , nom_client,prenom_client,nom,prenom FROM Biens,Ventes_Honoraires,Ventes,Clients,Acquereurs WHERE Biens.ref = Ventes.ref_bien AND Ventes.id_nego = Clients.idclient AND id_acq = id_acquereur AND valider_proposition = true AND valider_signature=true AND Ventes.ID = Ventes_Honoraires.id_vente AND Ventes_Honoraires.id_nego = " + member.IDCLIENT + " "
             + critere        
             + " ORDER BY date_signature DESC";

        //string sql1 ="SELECT Locations.*, Ventes_Honoraires.*, [prenom vendeur], [nom vendeur] , nom_client,prenom_client,nom,prenom FROM Biens,Ventes_Honoraires,Locations,Clients,Acquereurs WHERE Biens.ref = Locations.ref_bien AND Locations.id_nego = Clients.idclient AND id_acq = id_acquereur AND valider_proposition = true AND valider_signature=true AND Locations.ID = Ventes_Honoraires.id_location AND Ventes_Honoraires.id_nego = " + member.IDCLIENT + " "
        //     + critere
        //     + " ORDER BY date_signature DESC";

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
        //using (OdbcConnection cI = new OdbcConnection(_ConnectionString))
        //{
        //    // write the sql statement to execute 
        //    //string sql = recherche.ToString();
        //    // instantiate the command object to fire 
        //    using (OdbcCommand cmd = new OdbcCommand(sql1, cI))
        //    {
                // get the adapter object and attach the command object to it 
      //          using (OdbcDataAdapter ad = new OdbcDataAdapter(cmd))
       //         {
                    // fire Fill method to fetch the data and fill into DataTable 
         //           ad.Fill(table);
           //     }
           // }
        //}
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
        List<string> list = ViewState["mc_SelectedRecords"] as List<string>;
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
            e.Row.Cells[3].Text = "<a href='fichedetail1.aspx?ref=" + DataBinder.Eval(e.Row.DataItem, "ref_bien") + "'>"
                + e.Row.Cells[3].Text + "</a>"
				+ "<div class='tooltip'><span>"+e.Row.Cells[2].Text+"</span></div>";
            e.Row.Cells[4].Text += " " + DataBinder.Eval(e.Row.DataItem, "nom vendeur");
			
            e.Row.Cells[5].Text += " " + DataBinder.Eval(e.Row.DataItem, "nom_client");

            e.Row.Cells[6].Text = "<a href='modifier_acquereur.aspx?reference=" + DataBinder.Eval(e.Row.DataItem, "id_acquereur") + "'>"
                + e.Row.Cells[6].Text + " " + DataBinder.Eval(e.Row.DataItem, "nom")
                + "</a>"
				+ "<div class='tooltip'><span>"+e.Row.Cells[6].Text+ " " + DataBinder.Eval(e.Row.DataItem, "nom") + "</span></div>";
			

            //****************************** *^* ********************************
			if((bool)DataBinder.Eval(e.Row.DataItem, "parrainage") == true)
				e.Row.Cells[7].Text = "Parrainage";
			else
                if (DataBinder.Eval(e.Row.DataItem, "type").ToString() == "Libre")
				    e.Row.Cells[7].Text = "Libre";
                else
                {
                    e.Row.Cells[7].Text = "Commission";
                }
				
			e.Row.Cells[9].Text = "<a href='venteAfficher.aspx?id=" + DataBinder.Eval(e.Row.DataItem, "id") 
					+ "'><img src='../img_site/loupe.png' class='croix_rouge' alt = ''></a><div class ='tooltip'><span>Voir détails</span></div>";



			for(int i = 1; i< 9 ; i++)
			{
				if(i == 3 || i == 6)
					continue;
				e.Row.Cells[i].Text = e.Row.Cells[i].Text + "<div class='tooltip'><span>"+e.Row.Cells[i].Text+"</span></div>";
			}
        }
    }

    protected void ItemChange(object sender, EventArgs e)
    {
        if ((((DropDownList)sender).SelectedValue).ToString() == "10")
        {
            GridView1.PageSize = 10;
            Session["mc_annoncesPageX"] = 10;
        }
        if ((((DropDownList)sender).SelectedValue).ToString() == "20")
        {
            GridView1.PageSize = 20;
            Session["mc_annoncesPageX"] = 20;
        }
        if ((((DropDownList)sender).SelectedValue).ToString() == "30")
        {
            GridView1.PageSize = 30;
            Session["mc_annoncesPageX"] = 30;
        }
        if ((((DropDownList)sender).SelectedValue).ToString() == "50")
        {
            GridView1.PageSize = 50;
            Session["mc_annoncesPageX"] = 50;
        }
        if ((((DropDownList)sender).SelectedValue).ToString() == "100")
        {
            GridView1.PageSize = 100;
            Session["mc_annoncesPageX"] = 100;
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
