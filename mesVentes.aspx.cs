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
using System.Windows.Forms;

public partial class mesVentes : System.Web.UI.Page
{
    string _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
	string racine_site;
	
    protected void Page_Load(object sender, EventArgs e)
    {		
		Membre member = (Membre)Session["Membre"];
        if (member == null || (member.STATUT != "nego" && member.STATUT != "ultranego"))
        {
			Response.Redirect("recherche.aspx");
            Response.Close();
        }
        
        string action = Request.QueryString["action"];
        if(action != null )
            if(action == "modif")
                msg.Text = "La vente a été mise à jour";
            if (action == "ajout")
                msg.Text = "La vente a été ajoutée";
        
        ((System.Web.UI.WebControls.Label)Page.Master.FindControl("titrebandeau")).Text = "Accueil";
		
		Connexion cI = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        cI.Open();
        System.Data.DataSet dsI = cI.exeRequette("Select * from Environnement");
        cI.Close();

        racine_site = (String)dsI.Tables[0].Rows[0]["Chemin_racine_site"];
		
        if(!IsPostBack)
        {
            Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c.Open();
            DataRowCollection listAcq = c.exeRequetteOpen("SELECT id_acq,nom,prenom FROM Acquereurs WHERE type_acquereur = 'Acheteur' AND idclient = " + member.IDCLIENT + " AND actif = 'actif' ORDER BY nom ASC").Tables[0].Rows;
            c.Close();
            c = null;

            //Remplissage des listes deroulantes
            foreach (DataRow ligne in listAcq)
            {
                FuAsp_acq.Items.Add(new ListItem(ligne["nom"].ToString().ToUpper() + " " + ligne["prenom"], ligne["id_acq"].ToString()));
            }


            //Remplissage avec les anciens criteres de recherches
			
            if(Session["annoncesPage"] != null)
				DropDownListPageSize.SelectedValue = Session["annoncesPage"].ToString();
			else
				DropDownListPageSize.SelectedValue = "30";
			GridView1.PageSize = int.Parse(DropDownListPageSize.SelectedValue);
			
            if (Session["mesVentes_validePropMy"] != null)
                valideProp.SelectedValue = Session["mesVentes_validePropMy"].ToString();

            if (Session["mesVentes_valideVente"] != null)
                valideVente.SelectedValue = Session["mesVentes_valideVente"].ToString();

            if(Session["mesVentes_dateCompromisMin"] != null)
             TB_DateCompromisMin.Text = Session["mesVentes_dateCompromisMin"].ToString();
            if(Session["mesVentes_dateCompromisMax"] != null)
             TB_DateCompromisMax.Text = Session["mesVentes_dateCompromisMax"].ToString();
            if(Session["mesVentes_dateSignatureMin"] != null)
             TB_DateSignatureMin.Text = Session["mesVentes_dateSignatureMin"].ToString();
            if (Session["mesVentes_dateSignatureMax"] != null)
             TB_DateSignatureMax.Text = Session["mesVentes_dateSignatureMax"].ToString();

            if (Session["mesVentes_FuAsp_acq"] != null)
                FuAsp_acq.SelectedValue = Session["mesVentes_FuAsp_acq"].ToString();

			
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
            System.Web.UI.WebControls.CheckBox check = (System.Web.UI.WebControls.CheckBox)row.FindControl("CheckBoxArchiver");
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
        table.DefaultView.Sort = (String)Session["mv_sortExpression"] + (String)Session["mv_direction"];
        GridView1.DataSource = table;
        ViewState["SelectedRecordsX"] = list;
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
        // On coche la checkbox tout sélectionner.
        int i = 0;
        foreach (GridViewRow row in GridView1.Rows)
        {
            System.Web.UI.WebControls.CheckBox check = (System.Web.UI.WebControls.CheckBox)row.FindControl("CheckBoxArchiver");
            if (check.Checked)
            {
                i++;
            }
        }
        if (i == GridView1.PageSize)
        {
            GridViewRow rowe = GridView1.HeaderRow;
            System.Web.UI.WebControls.CheckBox checkboxSelect = (System.Web.UI.WebControls.CheckBox)rowe.FindControl("CheckBoxSelection");
            checkboxSelect.Checked = true;
        }
    }

    protected void SortRecords(object sender, GridViewSortEventArgs e)
    {
        Session["mv_sortExpression"] = e.SortExpression;
        Session["mv_direction"] = string.Empty;

        if (SortDirection == SortDirection.Ascending)
        {
            SortDirection = SortDirection.Descending;
            Session["mv_direction"] = " DESC";
        }
        else
        {
            SortDirection = SortDirection.Ascending;
            Session["mv_direction"] = " ASC";
        }
        DataTable table = this.GetData();
        table.DefaultView.Sort = (String)Session["mv_sortExpression"] + (String)Session["mv_direction"];
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
            
        if (Session["mesVentes_validePropMy"] == "1")
            critere += " AND valider_proposition = true";
        else if (Session["mesVentes_validePropMy"] == "0")
            critere += " AND valider_proposition = false";

        if(Session["mesVentes_valideVente"] == "1")
            critere += " AND valider_signature = true";
        if (Session["mesVentes_valideVente"] == "0")
            critere += " AND valider_signature = false";

        if (FuAsp_acq.SelectedValue != "-1")
            critere += " AND Acquereurs.id_acq = " + FuAsp_acq.SelectedValue;



        if (Session["mesVentes_dateCompromisMin"] != null && Session["mesVentes_dateCompromisMin"].ToString() != "")
        {
            string[] date = Session["mesVentes_dateCompromisMin"].ToString().Split('/');
            critere += " AND date_compromis < #" + date[1] + "/" + date[0] + "/" + date[2] + "#";
        }

        if (Session["mesVentes_dateCompromisMax"] != null && Session["mesVentes_dateCompromisMax"].ToString() != "")
        {
            string[] date = Session["mesVentes_dateCompromisMax"].ToString().Split('/');
            critere += " AND date_compromis > #" + date[1] + "/" + date[0] + "/" + date[2] + "#";
        }

        if (Session["mesVentes_dateSignatureMin"] != null && Session["mesVentes_dateSignatureMin"].ToString() != "")
        {
            string[] date = Session["mesVentes_dateSignatureMin"].ToString().Split('/');
            critere += " AND date_signature < #" + date[1] + "/" + date[0] + "/" + date[2] + "#";
        }

        if (Session["mesVentes_dateSignatureMax"] != null && Session["mesVentes_dateSignatureMax"].ToString() != "")
        {
            string[] date = Session["mesVentes_dateSignatureMax"].ToString().Split('/');
            critere += " AND date_signature > #" + date[1] + "/" + date[0] + "/" + date[2] + "#";
        }

        DataTable table = new DataTable();
        string sql = "SELECT Ventes.*,nom_client,prenom_client,nom,prenom,[nom vendeur],[prenom vendeur] FROM Biens,Ventes,Clients,Acquereurs WHERE Ventes.ref_bien = Biens.ref AND Ventes.id_nego = Clients.idclient AND id_acq = id_acquereur" 
			+ " AND (Ventes.id_nego =" + member.IDCLIENT + " OR Acquereurs.idclient =" + member.IDCLIENT +")"
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
                System.Web.UI.WebControls.CheckBox check = (System.Web.UI.WebControls.CheckBox)e.Row.FindControl("CheckBoxArchiver");
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
				+ "<div class='tooltip'><span>"+e.Row.Cells[2].Text+"</span></div>";
            e.Row.Cells[3].Text += " " + DataBinder.Eval(e.Row.DataItem, "nom vendeur");

            e.Row.Cells[4].Text = "<a href='modifier_acquereur.aspx?reference=" + DataBinder.Eval(e.Row.DataItem, "id_acquereur") + "'>"
                + e.Row.Cells[4].Text + " " + DataBinder.Eval(e.Row.DataItem, "nom")
                +"</a>"
				+ "<div class='tooltip'><span>"+ e.Row.Cells[4].Text + " " + DataBinder.Eval(e.Row.DataItem, "nom")+"</span></div>";


            e.Row.Cells[7].Text += " " + DataBinder.Eval(e.Row.DataItem, "nom_notaire");
			
			e.Row.Cells[7].Text += 
					"<div class='tooltip'><span>"+e.Row.Cells[7].Text+"<br/>" 
					+ DataBinder.Eval(e.Row.DataItem, "tel_notaire")  + "<br/>"
					+ DataBinder.Eval(e.Row.DataItem, "mail_notaire") + "<br/>"
					+ DataBinder.Eval(e.Row.DataItem, "adresse_notaire") +"<br/>"
					+ DataBinder.Eval(e.Row.DataItem, "cp_notaire") + DataBinder.Eval(e.Row.DataItem, "ville_notaire") 
					+"</span></div>";
			
            e.Row.Cells[8].Text = espaceTel(e.Row.Cells[8].Text);
            e.Row.Cells[9].Text = "<a href='mailto:" + e.Row.Cells[9].Text + "'>" + e.Row.Cells[9].Text + "</a>" + "<div class='tooltip'><span>"+e.Row.Cells[9].Text+"</span></div>";

            e.Row.Cells[11].Text = (e.Row.Cells[11].Text == "True")
                ? "<img class='croix_rouge' src='../img_site/true.png' />"
                : "<img class='croix_rouge' src='../img_site/false.png' />";

            e.Row.Cells[13].Text = (e.Row.Cells[13].Text == "True")
                ? "<img class='croix_rouge' src='../img_site/true.png' />"
                : "<img class='croix_rouge' src='../img_site/false.png' />";
				
			e.Row.Cells[14].Text = "<a href='vente.aspx?ref=" + DataBinder.Eval(e.Row.DataItem, "ref_bien") + "&id=" + DataBinder.Eval(e.Row.DataItem, "id") 
					+ "'><img src='../img_site/calepin3.gif' class='croix_rouge' alt = ''></a><div class ='tooltip'><span>Modifier</span></div>";
					
					
			string filePathActe = racine_site + "Ventes\\" + DataBinder.Eval(e.Row.DataItem, "id") + "_acte.pdf";
			string filePathPromesse = racine_site + "Ventes\\" + DataBinder.Eval(e.Row.DataItem, "id") + "_promesse.pdf";

			e.Row.Cells[15].Text = "<a href='venteAfficher.aspx?id=" + DataBinder.Eval(e.Row.DataItem, "id") 
					+ "'><img src='../img_site/loupe.png' class='croix_rouge' alt = ''></a><div class ='tooltip'><span>Voir détails</span></div>";
			
			if (System.IO.File.Exists(filePathPromesse))
				e.Row.Cells[16].Text = "<a href='../Ventes/"+DataBinder.Eval(e.Row.DataItem, "id")+"_promesse.pdf'><img src='../img_site/pdf.png' class='croix_rouge' alt = ''></a>";
				
			if (System.IO.File.Exists(filePathActe))
				e.Row.Cells[17].Text = "<a href='../Ventes/"+DataBinder.Eval(e.Row.DataItem, "id")+"_acte.pdf'><img src='../img_site/pdf.png' class='croix_rouge' alt = ''></a>";
			
			if((bool)DataBinder.Eval(e.Row.DataItem, "valider_signature") == true)
				e.Row.Cells[18].Text = "";
			
			for(int i = 0; i< 14 ; i++)
			{
				if(i == 2 || i ==7 || i == 4 || i == 9 | i == 11 || i == 13 || i == 14)
					continue;
				e.Row.Cells[i].Text = e.Row.Cells[i].Text + "<div class='tooltip'><span>"+e.Row.Cells[i].Text+"</span></div>";
			}

        }
    }

	protected void deleteVente(object sender, EventArgs e)
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
        if (list.Count < 1)
        {
            LabelError.Visible = true;
            LabelError.Text = "veuillez sélectionnez au moins une vente à supprimer<br/><br/>";
        }

        //si il y a des ventes sélectionnées
        if (list.Count > 0)
        {
            bool valid = true;

            //on regarde si les proposition de vente ont été validés
            foreach (string item in list)
            {
                string reqProposition = "SELECT Ventes.valider_proposition FROM Ventes WHERE Ventes.ID=" + item;

                OdbcConnection c = new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                OdbcCommand requetteProposition = new OdbcCommand(reqProposition, c);

                c.Open();

                OdbcDataReader read = requetteProposition.ExecuteReader();

                while (read.Read())
                {
                    string validprop = read["valider_proposition"].ToString();

                    if (validprop == "True")
                        valid = false;

                }

                c.Close();
            }
            
            //si les propositions de vente ne sont pas validés on supprime les ventes
            if (valid == true)
            {
                foreach (string item in list)
                {
                    string reqVente = "DELETE FROM Ventes WHERE ID=" + item;
                    string reqHonoraire = "DELETE FROM Ventes_honoraires WHERE id_vente=" + item;

                    OdbcConnection c = new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                    OdbcCommand requetteVente = new OdbcCommand(reqVente, c);
                    OdbcCommand requetteHonoraire = new OdbcCommand(reqHonoraire, c);

                    c.Open();

                    requetteVente.ExecuteNonQuery();
                    requetteHonoraire.ExecuteNonQuery();

                    c.Close();
                }

                Response.Redirect(Request.RawUrl);
            }
            else
            {
                LabelError.Visible = true;
                LabelError.Text = "Au moins une vente sélectionnée à été validé par un administrateur et ne peut pas être supprimée<br/>Si vous souhaitez la supprimer, veuillez contacter un administrateur<br/><br/>";

            }

        }

    }

    protected void ItemChange(object sender, EventArgs e)
    {
        if ((((DropDownList)sender).SelectedValue).ToString() == "10")
        {
            GridView1.PageSize = 10;
            Session["mv_annoncesPage"] = 10;
        }
        if ((((DropDownList)sender).SelectedValue).ToString() == "20")
        {
            GridView1.PageSize = 20;
            Session["mv_annoncesPage"] = 20;
        }
        if ((((DropDownList)sender).SelectedValue).ToString() == "30")
        {
            GridView1.PageSize = 30;
            Session["mv_annoncesPage"] = 30;
        }
        if ((((DropDownList)sender).SelectedValue).ToString() == "50")
        {
            GridView1.PageSize = 50;
            Session["mv_annoncesPage"] = 50;
        }
        if ((((DropDownList)sender).SelectedValue).ToString() == "100")
        {
            GridView1.PageSize = 100;
            Session["mv_annoncesPage"] = 100;
        }
        BindData();
    }

    protected void Tout_Selectionner(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.CheckBox CheckBoxSelect = (System.Web.UI.WebControls.CheckBox)sender;
        if (CheckBoxSelect.Checked)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                System.Web.UI.WebControls.CheckBox check = (System.Web.UI.WebControls.CheckBox)row.FindControl("CheckBoxArchiver");
                check.Checked = true;
            }
        }
        else
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                System.Web.UI.WebControls.CheckBox check = (System.Web.UI.WebControls.CheckBox)row.FindControl("CheckBoxArchiver");
                check.Checked = false;
            }
        }
    }

    
    protected void filtrer(object sender, EventArgs e)
    {
        Session["mesVentes_FuAsp_acq"] = FuAsp_acq.SelectedValue;
            
        Session["mesVentes_validePropMy"] = valideProp.SelectedValue;
        Session["mesVentes_valideVente"] = valideVente.SelectedValue;
        Session["mesVentes_dateCompromisMin"] = TB_DateCompromisMin.Text;
        Session["mesVentes_dateCompromisMax"] = TB_DateCompromisMax.Text;
        Session["mesVentes_dateSignatureMin"] = TB_DateSignatureMin.Text;
        Session["mesVentes_dateSignatureMax"] = TB_DateSignatureMax.Text;
        BindData();
    }


    private string espaceTel(string tel)
    {
		if(tel == "&nbsp;")
			return tel;

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
