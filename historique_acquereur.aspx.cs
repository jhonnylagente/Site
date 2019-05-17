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

public partial class pages_historique_acquereur : System.Web.UI.Page
{
    string _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Page.Master.FindControl("titrebandeau")).Text = "Mon espace";

        try
        {
            if (Session["logged"].Equals(true))
            {
                // permet le "Bonjour Mr X"
                Membre member = (Membre)Session["Membre"];
            }
        }
        catch
        {
            Response.Redirect("./moncompte.aspx");
        }
        if (!IsPostBack)
        {
            DropDownListPageSize.SelectedValue = Session["annoncesPage"].ToString();
            GridViewHist.PageSize = int.Parse(DropDownListPageSize.SelectedValue);
            BindData();
        }
        //Pour afficher les données du acquereur
        String  idAcquereur;
        
        idAcquereur = (String)Session["idacquereur"];
        //le variable pour recuperer les pages Web 
        string sql = "SELECT Acquereurs.id_acq, Acquereurs.civilite, Acquereurs.date_ajout, Acquereurs.negociateur, Acquereurs.nom, Acquereurs.prenom, Acquereurs.adresse, Acquereurs.ville, Acquereurs.code_postal, Acquereurs.pays, Acquereurs.portable , Acquereurs.mail FROM Acquereurs WHERE (((Acquereurs.id_acq)=" + idAcquereur + "))";
        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();
        System.Data.DataSet ds = c.exeRequette(sql);
        c.Close();

        ///clients
        try
        {
            lblNom.Text =  (String)ds.Tables[0].Rows[0]["nom"].ToString().ToUpper() + " " + (String)ds.Tables[0].Rows[0]["prenom"].ToString().ToUpper();
        }
        catch 
        {
            lblNom.Text = " ";
        }

        try
        {
            lblVille.Text =  (String)ds.Tables[0].Rows[0]["ville"];
        }
        catch
        {
            lblVille.Text = " ";
        }
        try
        {
            lblcp.Text = (String)ds.Tables[0].Rows[0]["code_postal"];
        }
        catch
        {
            lblcp.Text = " ";
        }

        try
        {
            lblMail.Text =  (String)ds.Tables[0].Rows[0]["mail"];
        }
        catch
        {
            lblMail.Text = " ";
        }
        try
        {
            lbltel.Text =  (String)ds.Tables[0].Rows[0]["portable"];
        }
        catch
        {
            lbltel.Text = " ";
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
        if (GridViewHist.Rows.Count == 0)
        {
            LabelOK.Visible = true;
            LabelOK.Text = "Il n'y a pas de historique pour cet acquereur.";
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
        String idBien, idAcquereur;
        idBien = (String)Session["idbien"];
        idAcquereur = (String)Session["idacquereur"];
        DataTable table = new DataTable();
        string sql = "SELECT   Biens.ref, Biens.[date dossier], Biens.etat, Biens.[nom vendeur],Biens.[adresse vendeur], Biens.[code postal vendeur],  Biens.[ville vendeur], Biens.[tel domicile vendeur], Biens.[prix de vente], Acquereurs.mail FROM (Acquereurs INNER JOIN visite ON Acquereurs.id_acq = visite.acquereur) INNER JOIN Biens ON visite.id_bien = Biens.ref WHERE (((Acquereurs.id_acq)=" + idAcquereur + ")) ORDER BY Biens.[date dossier] DESC";
       
        //String idBien;
        //idBien = (String)Session["idbien"];
        //DataTable table = new DataTable();
        //string sql = "SELECT Biens.[nom vendeur], Biens.[negociateur], visite.[date_visite], Acquereurs.[nom], Acquereurs.[prenom], Acquereurs.[adresse], Acquereurs.[ville], Acquereurs.[code_postal], Acquereurs.[tel], Acquereurs.[portable], Acquereurs.[mail], Acquereurs.[prix_min], Acquereurs.[prix_max] FROM (Biens LEFT JOIN visite ON Biens.[ref] = visite.[id_bien]) LEFT JOIN Acquereurs ON visite.[acquereur] = Acquereurs.[id_acq] WHERE (((Acquereurs.[nom]) Is Not Null) AND visite.[id_bien] ='" + idBien + "')";
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
    //protected void ReSelectSelectedRecords(object sender, GridViewRowEventArgs e)
    //{
    //    List<string> list = ViewState["SelectedRecordsH"] as List<string>;
    //    if (e.Row.RowType == DataControlRowType.DataRow && list != null)
    //    {
    //        var reference = GridViewHist.DataKeys[e.Row.RowIndex].Value.ToString();
    //    }
    //}


    protected void ReSelectSelectedRecords(object sender, GridViewRowEventArgs e)
    {
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
           
            string cinq = e.Row.Cells[5].Text;

            //if (e.Row.Cells[2].Text == "Estimation")
            //{
            //    e.Row.CssClass = "Estimation";
            //}
            //else if (e.Row.Cells[2].Text == "Disponibe")
            //{
            //    e.Row.CssClass = "Disponible";
            //}
            //else if (e.Row.Cells[2].Text == "offre")
            //{
            //    e.Row.BackColor = System.Drawing.Color.BurlyWood;
            //}
            //else if (e.Row.Cells[2].Text == "retirer")
            //{
            //    e.Row.BackColor = System.Drawing.Color.Khaki;
            //}
            var couleur = e.Row.Cells[2].Text.ToString().Substring(0,3);
            var loue = e.Row.Cells[0].Text.ToString().Substring(0, 1);
           
            switch (couleur)
            {
                case "Dis":
                    e.Row.CssClass = "Disponible";
                    break;
                case "Est":
                    e.Row.CssClass = "Estimation";
                    break;
                case "Off":
                    e.Row.CssClass = "Offre";
                    break;
                case "Sus":
                    switch (loue)
                    {
                        case "V":
                            e.Row.CssClass = "Suspendu";
                        break;
                        case "L":
                            e.Row.CssClass = "SuspenduL";
                         break;
                     }
                break;
                case "Ret":
                    switch (loue)
                    {
                        case "V":
                            e.Row.CssClass = "Retire";
                        break;
                        case "L":
                            e.Row.CssClass = "RetireL";
                        break;
                    }
                break;
                case "Com":
                    e.Row.CssClass = "Compromis";
                 break;
            }
            if (e.Row.Cells[9].Text.Length > 20)
            {
                string A = e.Row.Cells[9].Text;
                //e.Row.Cells[11].Text = e.Row.Cells[11].Text.ToString().Substring(0, 20);
                e.Row.Cells[9].Text = "<A HREF=mailto:" + A + ">" + A.ToString().Substring(0, 20) + "</A>";
                e.Row.Cells[9].Text = e.Row.Cells[9].Text + "<div class = \"tooltip\"><span>" + A + "</span></div>";
            }
            else
            {
                e.Row.Cells[9].Text = e.Row.Cells[9].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[9].Text + "</span></div>";
            }
            for(int i = 0; i < 1 ; i++)
                e.Row.Cells[i].Attributes["onClick"] = "location.href='fichedetail1.aspx?ref=" + DataBinder.Eval(e.Row.DataItem, "ref") + "'";
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
}