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

public partial class pages_historique_visite : System.Web.UI.Page
{
    string _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
		Membre member = (Membre)Session["Membre"];
        if (member == null || (member.STATUT != "nego" && member.STATUT != "ultranego"))
        {
            Response.Close();
        }
		
        ((Label)Page.Master.FindControl("titrebandeau")).Text = "Mon espace";


        if (!IsPostBack)
        {
            DropDownListPageSize.SelectedValue = Session["annoncesPage"].ToString();
            GridViewHist.PageSize = int.Parse(DropDownListPageSize.SelectedValue);
            BindData();
        }
    }

    protected void PaginateTheData(object sender, GridViewPageEventArgs e)
    {
        List<string> list = new List<string>();
        DataTable table = this.GetData();
        table.DefaultView.Sort = (String)Session["sortExpressionH"] + (String)Session["directionH"];
        GridViewHist.DataSource = table;
        ViewState["SelectedRecordsH"] = list;
        GridViewHist.PageIndex = e.NewPageIndex;
        GridViewHist.DataBind();
    }

    protected void SortRecords(object sender, GridViewSortEventArgs e)
    {
        Session["sortExpressionH"] = e.SortExpression;
        Session["directionH"] = string.Empty;

        if (SortDirection == SortDirection.Ascending)
        {
            SortDirection = SortDirection.Descending;
            Session["directionH"] = " DESC";
        }
        else
        {
            SortDirection = SortDirection.Ascending;
            Session["directionH"] = " ASC";
        }
        DataTable table = this.GetData();
        table.DefaultView.Sort = (String)Session["sortExpressionH"] + (String)Session["directionH"];
        GridViewHist.DataSource = table;
        GridViewHist.DataBind();
    }

    private void BindData()
    {
        // specify the data source for the GridView
        GridViewHist.DataSource = this.GetData();
        // bind the data now
        GridViewHist.DataBind();
        if(GridViewHist.Rows.Count == 0)
        {
            LabelOK.Visible = true;
            LabelOK.Text = "Il n'y a pas eu de visites sur ce bien";
        }
        else
        {
            LabelOK.Visible = false;
        }
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
            if (ViewState["SortDirectionH"] == null)
            {
                ViewState["SortDirectionH"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["SortDirectionH"];
        }
        set
        {
            ViewState["SortDirectionH"] = value;
        }
    }

    /// <summary> 
    /// Gets the data. 
    /// </summary> 
    private DataTable GetData()
    {
        String idBien;
        if (Request.QueryString["ref"] == null)
        {
            idBien = Session["idbien"].ToString();
        }
        else
        {
            idBien = Request.QueryString["ref"];
        }
        DataTable table = new DataTable();
        string sql = "SELECT Biens.[nom vendeur], Biens.[negociateur], visite.[date_visite], Acquereurs.[nom], Acquereurs.[prenom], Acquereurs.[adresse], Acquereurs.[ville], Acquereurs.[code_postal], Acquereurs.[tel], Acquereurs.[portable], Acquereurs.[mail], Acquereurs.[prix_min], Acquereurs.[prix_max], Acquereurs.[categorie], Acquereurs.[id_acq] FROM (Biens LEFT JOIN visite ON Biens.[ref] = visite.[id_bien]) LEFT JOIN Acquereurs ON visite.[acquereur] = Acquereurs.[id_acq] WHERE (((Acquereurs.[nom]) Is Not Null) AND visite.[id_bien] ='" + idBien + "')";
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
    /// Looks for selection. 
    /// </summary> 
    /// <param name="sender">The sender.</param> 
    /// <param name="e">The <seecref="System.Web.UI.WebControls.GridViewRowEventArgs"/>
    ///     instance containing the event data.</param> 
    protected void ReSelectSelectedRecords(object sender, GridViewRowEventArgs e)
    {
        //List<string> list = ViewState["SelectedRecordsH"] as List<string>;
        //if (e.Row.RowType == DataControlRowType.DataRow && list != null)
        //{
        //    var reference = GridViewHist.DataKeys[e.Row.RowIndex].Value.ToString();
        //}

        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.Cells[13].Attributes.Add("style", "display:none");
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.Cells[14].Attributes.Add("style", "display:none");
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[13].Attributes.Add("style", "display:none");
            if (e.Row.Cells[13].Text == "precis")
            {
                e.Row.BackColor = System.Drawing.Color.YellowGreen;
            }
            else if (e.Row.Cells[13].Text == "large")
            {
                e.Row.BackColor = System.Drawing.Color.PaleGreen;
            }
            else if (e.Row.Cells[13].Text == "investisseur ancien")
            {
                e.Row.BackColor = System.Drawing.Color.BurlyWood;
            }
            else if (e.Row.Cells[13].Text == "investisseur neuf")
            {
                e.Row.BackColor = System.Drawing.Color.Khaki;
            }
            e.Row.Cells[14].Visible = false;
        }
        List<string> list = ViewState["SelectedRecordsA"] as List<string>;
        if (e.Row.RowType == DataControlRowType.DataRow && list != null)
        {
            var reference = GridViewHist.DataKeys[e.Row.RowIndex].Value.ToString();
            if (list.Contains(reference))
            {
                CheckBox check = (CheckBox)e.Row.FindControl("CheckBoxArchiver");
                check.Checked = true;
            }
        }

        //On crée la bulle pour la case tout sélectionner.
        if (e.Row.RowType == DataControlRowType.Header)
        {

        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            

            // on affiche les accents correctement et on affiche le texte en tooltip et on met visible à false
            e.Row.Cells[4].Text = e.Row.Cells[4].Text.Replace("&#233;", "é");
            e.Row.Cells[4].Text = e.Row.Cells[4].Text.Replace("&#232;", "è");
            e.Row.Cells[4].Text = e.Row.Cells[4].Text.Replace("&#234;", "ê");
            e.Row.Cells[0].Text = e.Row.Cells[0].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[0].Text + "</span></div>";
            e.Row.Cells[1].Text = e.Row.Cells[1].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[1].Text + "</span></div>";
            e.Row.Cells[2].Text = e.Row.Cells[2].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[2].Text + "</span></div>";
            e.Row.Cells[3].Text = e.Row.Cells[3].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[3].Text + "</span></div>";
            e.Row.Cells[4].Text = e.Row.Cells[4].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[4].Text + "</span></div>";
            e.Row.Cells[5].Text = e.Row.Cells[5].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[5].Text + "</span></div>";
            e.Row.Cells[6].Text = e.Row.Cells[6].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[6].Text + "</span></div>";
            e.Row.Cells[7].Text = e.Row.Cells[7].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[7].Text + "</span></div>";
            e.Row.Cells[8].Text = e.Row.Cells[8].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[8].Text + "</span></div>";
            e.Row.Cells[9].Text = e.Row.Cells[9].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[9].Text + "</span></div>";
            if (e.Row.Cells[10].Text.Length > 20)
            {
                string A = e.Row.Cells[10].Text;
                //e.Row.Cells[11].Text = e.Row.Cells[11].Text.ToString().Substring(0, 20);
                e.Row.Cells[10].Text = "<A HREF=mailto:" + A + ">" + A.ToString().Substring(0, 20) + "</A>";
                e.Row.Cells[10].Text = e.Row.Cells[10].Text + "<div class = \"tooltip\"><span>" + A + "</span></div>";
            }
            else
            {
                e.Row.Cells[10].Text = "<A HREF=mailto:" + e.Row.Cells[10].Text + ">" + e.Row.Cells[10].Text + "</a><div class = \"tooltip\"><span>" + e.Row.Cells[10].Text + "</span></div>";
            }

         
            e.Row.Cells[11].Text = e.Row.Cells[11].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[11].Text + "</span></div>";
            e.Row.Cells[12].Text = e.Row.Cells[12].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[12].Text + "</span></div>";
           
            string cinq = e.Row.Cells[5].Text;
           

    }
    }    

    protected void Button1_Click_Tab(object sender, EventArgs e)
    {
        BindData();
    }
    protected void ItemChange(object sender, EventArgs e)
    {
        if ((((DropDownList)sender).SelectedValue).ToString() == "10")
        {
            GridViewHist.PageSize = 10;
            Session["annoncesPageH"] = 10;
        }
        if ((((DropDownList)sender).SelectedValue).ToString() == "20")
        {
            GridViewHist.PageSize = 20;
            Session["annoncesPageH"] = 20;
        }
        if ((((DropDownList)sender).SelectedValue).ToString() == "30")
        {
            GridViewHist.PageSize = 30;
            Session["annoncesPageH"] = 30;
        }
        if ((((DropDownList)sender).SelectedValue).ToString() == "50")
        {
            GridViewHist.PageSize = 50;
            Session["annoncesPageH"] = 50;
        }
        if ((((DropDownList)sender).SelectedValue).ToString() == "100")
        {
            GridViewHist.PageSize = 100;
            Session["annoncesPageH"] = 100;
        }
        BindData();
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

    protected string modifier_acquereur(string text)
    {
        string stext = "";
        stext = "<a href=\"modifier_acquereur.aspx?reference=" + text + "\"><img class=\"croix_rouge\" src=\"../img_site/calepin3.gif\" /></a>";
        return stext;
    }

    protected void GridViewHist_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}