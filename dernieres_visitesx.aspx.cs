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

public partial class pages_dernieres_visites : System.Web.UI.Page
{

    string _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Page.Master.FindControl("titrebandeau")).Text = "Mon espace";
       
        if ((String)Session["TypeTransaaction"]=="L")
        {
            lbltitle.Text = "Dernières visites pour les Locations";
        }
        if ((String)Session["TypeTransaaction"] == "V")
        {
            lbltitle.Text = "Dernières visites pour les Ventes";
        }
        
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
       // GridViewHist.DataBind();
        if (GridViewHist.Rows.Count == 0)
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
        Membre member = (Membre)Session["Membre"];
        DataTable table = new DataTable();

        string sql = "SELECT visite.[date_visite] , Biens.[ref], Biens.[type de bien], Biens.[adresse vendeur], Biens.[code postal vendeur], Biens.[ville vendeur], Biens.[nom vendeur], Biens.[tel domicile vendeur], Biens.[adresse mail vendeur], Acquereurs.nom, Acquereurs.tel, Acquereurs.mail, Biens.etat, Acquereurs.categorie, Acquereurs.id_acq FROM ((Biens INNER JOIN optionsBiens ON Biens.ref = optionsBiens.refOptions) INNER JOIN visite ON Biens.ref = visite.id_bien) INNER JOIN Acquereurs ON visite.acquereur = Acquereurs.id_acq WHERE (((Biens.ref) Like '" + Session["TypeTransaaction"] + "%') AND((Biens.actif)='" + Session["ARCHIVEVARIABLE"].ToString() + "') AND ((visite.idclient)=" + member.IDCLIENT + ")) ORDER BY visite.date_visite DESC";
       
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
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.Cells[12].Attributes.Add("style", "display:none");
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
                e.Row.CssClass = "Style1";
            }
            else if (e.Row.Cells[13].Text == "investisseur ancien")
            {
                e.Row.BackColor = System.Drawing.Color.BurlyWood;
            }
            else if (e.Row.Cells[13].Text == "investisseur neuf")
            {
                e.Row.BackColor = System.Drawing.Color.Khaki;
            }
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[14].Visible = false;
        }




        List<string> list = ViewState["SelectedRecords"] as List<string>;
        if (e.Row.RowType == DataControlRowType.DataRow && list != null)
        {
            var reference = GridViewHist.DataKeys[e.Row.RowIndex].Value.ToString();
            if (list.Contains(reference))
            {
                CheckBox check = (CheckBox)e.Row.FindControl("CheckBoxArchiver");
                check.Checked = true;
            }
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if (e.Row.Cells[1].Text.ToString().Substring(0, 1) == "V")
            {

            }
            else
            {

            }
            for (int i = 1; i < 2; i++)
                e.Row.Cells[i].Attributes["onClick"] = "location.href='fichedetail1.aspx?ref=" + DataBinder.Eval(e.Row.DataItem, "ref") + "'";

            //pour l'acquereur
            for (int i = 9; i < 10; i++)
                e.Row.Cells[i].Attributes["onClick"] = "location.href='afficher_acquereur.aspx?ref=" + DataBinder.Eval(e.Row.DataItem, "id_acq") + "'";
            string refe = e.Row.Cells[1].Text.ToString();
            String requette = "select `texte internet` as texte_internet from Biens Where Biens.[ref]='" + refe + "'";
            Connexion c0 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c0.Open();
            System.Data.DataSet ds = c0.exeRequette(requette);
            c0.Close();


            try
            {
                string texte_internet = (string)ds.Tables[0].Rows[0]["texte_internet"];
                e.Row.Cells[1].Text = e.Row.Cells[1].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[1].Text + "</span></div>";
            }
            catch { }
            if (e.Row.Cells[1].Text.ToString().Substring(0, 1) == "V")
            {
                e.Row.Cells[2].Text = "Vente<div class = \"tooltip\"><span>Vente</span></div>";
            }
            else
            {
                e.Row.Cells[2].Text = "Location<div class = \"tooltip\"><span>Location</span></div>";
            }
                string refer = e.Row.Cells[1].Text.Split('<')[0];
                String requett = "select Biens.[type de bien] as type_bien from Biens Where Biens.[ref]='" + refer + "'";
                Connexion c1 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                            c1.Open();
                 System.Data.DataSet ds1 = c1.exeRequette(requett);
                            c1.Close();
                string type_bien = ds1.Tables[0].Rows[0]["type_bien"].ToString().Split('<')[0];
            switch (type_bien)
            {
                case "A":
                    e.Row.Cells[2].Text = "Appart.<div class = \"tooltip\"><span>Appartement</span></div>";
                    break;

                case "M":
                    e.Row.Cells[2].Text = "Maison<div class = \"tooltip\"><span>Maison</span></div>";
                    break;

                case "T":
                    e.Row.Cells[2].Text = "Terrain<div class = \"tooltip\"><span>Terrain</span></div>";
                    break;

                case "L":
                    e.Row.Cells[2].Text = "Local<div class = \"tooltip\"><span>Local</span></div>";
                    break;

                default:
                    e.Row.Cells[2].Text = "Immeuble<div class = \"tooltip\"><span>Immeuble</span></div>";
                    break;
            }

            if (e.Row.Cells[3].Text.Length > 20)
            {
                string A = e.Row.Cells[3].Text;
                e.Row.Cells[3].Text = e.Row.Cells[3].Text.ToString().Substring(0, 20);
                e.Row.Cells[3].Text = e.Row.Cells[3].Text + "<div class = \"tooltip\"><span>" + A + "</span></div>";
            }
            else
            {
                e.Row.Cells[3].Text = e.Row.Cells[3].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[3].Text + "</span></div>";
            }

            if (e.Row.Cells[6].Text.Length > 20)
            {
                string A = e.Row.Cells[6].Text;
                e.Row.Cells[6].Text = e.Row.Cells[6].Text.ToString().Substring(0, 20);
                e.Row.Cells[6].Text = e.Row.Cells[6].Text + "<div class = \"tooltip\"><span>" + A + "</span></div>";
            }
            else
            {
                e.Row.Cells[6].Text = e.Row.Cells[6].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[6].Text + "</span></div>";
            }


            if (e.Row.Cells[8].Text.Length > 20)
            {
                string A = e.Row.Cells[9].Text;
                e.Row.Cells[8].Text = e.Row.Cells[8].Text.ToString().Substring(0, 20);
                e.Row.Cells[8].Text = e.Row.Cells[8].Text + "<div class = \"tooltip\"><span>" + A + "</span></div>";
            }
            else
            {
                string A = e.Row.Cells[9].Text;
                e.Row.Cells[8].Text = e.Row.Cells[8].Text.ToString();
                e.Row.Cells[8].Text = e.Row.Cells[8].Text + "<div class = \"tooltip\"><span>" + A + "</span></div>";
            }

            if (e.Row.Cells[11].Text.Length > 20)
            {
                string A = e.Row.Cells[11].Text;
                e.Row.Cells[11].Text = "<A HREF=mailto:" + A + ">" + A.ToString().Substring(0, 20) + "</A>";
                e.Row.Cells[11].Text = e.Row.Cells[11].Text + "<div class = \"tooltip\"><span>" + A + "</span></div>";
            }
            else
            {
                e.Row.Cells[11].Text = e.Row.Cells[11].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[11].Text + "</span></div>";
            }

            if (e.Row.Cells[12].Text.Length > 3)
            {
                string A = e.Row.Cells[12].Text;
                e.Row.Cells[12].Text = e.Row.Cells[12].Text.ToString().Substring(0, 3);
                e.Row.Cells[12].Text = e.Row.Cells[12].Text + "<div class = \"tooltip\"><span>" + A + "</span></div>";
                

            }
            else
            {
                e.Row.Cells[12].Text = e.Row.Cells[12].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[12].Text + "</span></div>";
            }

            e.Row.Cells[0].Text = e.Row.Cells[0].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[0].Text + "</span></div>";
            e.Row.Cells[4].Text = e.Row.Cells[4].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[4].Text + "</span></div>";
            e.Row.Cells[5].Text = e.Row.Cells[5].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[5].Text + "</span></div>";
            e.Row.Cells[7].Text = e.Row.Cells[7].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[7].Text + "</span></div>";
            e.Row.Cells[8].Text = e.Row.Cells[8].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[8].Text + "</span></div>";
            e.Row.Cells[10].Text = e.Row.Cells[10].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[10].Text + "</span></div>";

            var loue = e.Row.Cells[1].Text.ToString().Substring(0, 1);
            var couleur = e.Row.Cells[12].Text.ToString().Substring(0, 3);

            e.Row.Cells[0].CssClass = "Disponible";
            switch (couleur)
            {
                case "Dis":
                    e.Row.Cells[1].CssClass = "Disponible";
                    e.Row.Cells[2].CssClass = "Disponible";
                    e.Row.Cells[3].CssClass = "Disponible";
                    e.Row.Cells[4].CssClass = "Disponible";
                    e.Row.Cells[5].CssClass = "Disponible";
                    e.Row.Cells[6].CssClass = "Disponible";
                    e.Row.Cells[7].CssClass = "Disponible";
                    e.Row.Cells[8].CssClass = "Disponible";

                    break;

                case "Off":
                    e.Row.Cells[1].CssClass = "Offre";
                    e.Row.Cells[2].CssClass = "Offre";
                    e.Row.Cells[3].CssClass = "Offre";
                    e.Row.Cells[4].CssClass = "Offre";
                    e.Row.Cells[5].CssClass = "Offre";
                    e.Row.Cells[6].CssClass = "Offre";
                    e.Row.Cells[7].CssClass = "Offre";
                    e.Row.Cells[8].CssClass = "Offre";

                    break;
                case "Est":
                    e.Row.Cells[1].CssClass = "Estimation";
                    e.Row.Cells[2].CssClass = "Estimation";
                    e.Row.Cells[3].CssClass = "Estimation";
                    e.Row.Cells[4].CssClass = "Estimation";
                    e.Row.Cells[5].CssClass = "Estimation";
                    e.Row.Cells[6].CssClass = "Estimation";
                    e.Row.Cells[7].CssClass = "Estimation";
                    e.Row.Cells[8].CssClass = "Estimation";


                    break;

                case "Sus":
                    switch (loue)
                    {
                        case "V":
                            e.Row.Cells[1].CssClass = "Suspendu";
                            e.Row.Cells[2].CssClass = "Suspendu";
                            e.Row.Cells[3].CssClass = "Suspendu";
                            e.Row.Cells[4].CssClass = "Suspendu";
                            e.Row.Cells[5].CssClass = "Suspendu";
                            e.Row.Cells[6].CssClass = "Suspendu";
                            e.Row.Cells[7].CssClass = "Suspendu";
                            e.Row.Cells[8].CssClass = "Suspendu";
                            break;
                        case "L":
                            e.Row.Cells[1].CssClass = "SuspenduL";
                            e.Row.Cells[2].CssClass = "SuspenduL";
                            e.Row.Cells[3].CssClass = "SuspenduL";
                            e.Row.Cells[4].CssClass = "SuspenduL";
                            e.Row.Cells[5].CssClass = "SuspenduL";
                            e.Row.Cells[6].CssClass = "SuspenduL";
                            e.Row.Cells[7].CssClass = "SuspenduL";
                            e.Row.Cells[8].CssClass = "SuspenduL";

                            break;
                    }
                    break;

                case "Ret":
                    switch (loue)
                    {
                        case "V":
                            e.Row.Cells[1].CssClass = "Retire";
                            e.Row.Cells[2].CssClass = "Retire";
                            e.Row.Cells[3].CssClass = "Retire";
                            e.Row.Cells[4].CssClass = "Retire";
                            e.Row.Cells[5].CssClass = "Retire";
                            e.Row.Cells[6].CssClass = "Retire";
                            e.Row.Cells[7].CssClass = "Retire";
                            e.Row.Cells[8].CssClass = "Retire";


                            break;
                        case "L":
                            e.Row.Cells[1].CssClass = "RetireL";
                            e.Row.Cells[2].CssClass = "RetireL";
                            e.Row.Cells[3].CssClass = "RetireL";
                            e.Row.Cells[4].CssClass = "RetireL";
                            e.Row.Cells[5].CssClass = "RetireL";
                            e.Row.Cells[6].CssClass = "RetireL";
                            e.Row.Cells[7].CssClass = "RetireL";
                            e.Row.Cells[8].CssClass = "RetireL";

                            break;
                    }
                    break;

                case "est":
                    e.Row.Cells[1].CssClass = "Estimation";
                    e.Row.Cells[2].CssClass = "Estimation";
                    e.Row.Cells[3].CssClass = "Estimation";
                    e.Row.Cells[4].CssClass = "Estimation";
                    e.Row.Cells[5].CssClass = "Estimation";
                    e.Row.Cells[6].CssClass = "Estimation";
                    e.Row.Cells[7].CssClass = "Estimation";
                    e.Row.Cells[8].CssClass = "Estimation";

                    break;

                case "Com":
                    e.Row.Cells[1].CssClass = "Compromis";
                    e.Row.Cells[2].CssClass = "Compromis";
                    e.Row.Cells[3].CssClass = "Compromis";
                    e.Row.Cells[4].CssClass = "Compromis";
                    e.Row.Cells[5].CssClass = "Compromis";
                    e.Row.Cells[6].CssClass = "Compromis";
                    e.Row.Cells[7].CssClass = "Compromis";
                    e.Row.Cells[8].CssClass = "Compromis";

                    break;

                case "Lib":
                    e.Row.Cells[1].CssClass = "Libre";
                    e.Row.Cells[2].CssClass = "Libre";
                    e.Row.Cells[3].CssClass = "Libre";
                    e.Row.Cells[4].CssClass = "Libre";
                    e.Row.Cells[5].CssClass = "Libre";
                    e.Row.Cells[6].CssClass = "Libre";
                    e.Row.Cells[7].CssClass = "Libre";
                    e.Row.Cells[8].CssClass = "Libre";

                    break;

                case "Occ":
                    e.Row.Cells[1].CssClass = "Occupe";
                    e.Row.Cells[2].CssClass = "Occupe";
                    e.Row.Cells[3].CssClass = "Occupe";
                    e.Row.Cells[4].CssClass = "Occupe";
                    e.Row.Cells[5].CssClass = "Occupe";
                    e.Row.Cells[6].CssClass = "Occupe";
                    e.Row.Cells[7].CssClass = "Occupe";
                    e.Row.Cells[8].CssClass = "Occupe";
                    break;

                case "Lou":
                    e.Row.Cells[1].CssClass = "Loue";
                    e.Row.Cells[2].CssClass = "Loue";
                    e.Row.Cells[3].CssClass = "Loue";
                    e.Row.Cells[4].CssClass = "Loue";
                    e.Row.Cells[5].CssClass = "Loue";
                    e.Row.Cells[6].CssClass = "Loue";
                    e.Row.Cells[7].CssClass = "Loue";
                    e.Row.Cells[8].CssClass = "Loue";

                    break;

                case "Opt":
                    e.Row.Cells[1].CssClass = "Option";
                    e.Row.Cells[2].CssClass = "Option";
                    e.Row.Cells[3].CssClass = "Option";
                    e.Row.Cells[4].CssClass = "Option";
                    e.Row.Cells[5].CssClass = "Option";
                    e.Row.Cells[6].CssClass = "Option";
                    e.Row.Cells[7].CssClass = "Option";
                    e.Row.Cells[8].CssClass = "Option";

                    break;

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
    protected void GridViewHist_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
}