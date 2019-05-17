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
using System.Web.UI.HtmlControls;
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
		Membre member = (Membre)Session["Membre"];
		if (member == null || (member.STATUT != "nego" && member.STATUT != "ultranego"))
		{
			Response.Redirect("./recherche.aspx");
			Response.Close();
		}
	
        ((Label)Page.Master.FindControl("titrebandeau")).Text = "Mon espace";
       
        if ((String)Session["TypeTransaaction"]=="L")
        {
            lbltitle.Text = "Dernières visites pour les Locations";
        }
        if ((String)Session["TypeTransaaction"] == "V")
        {
            lbltitle.Text = "Dernières visites pour les Ventes";
        }
/*else
		{	//F*** this, really. Pas de valeur par defaut, et on ne connait pas les variables GET ou POST ici.
			Session["TypeTransaaction"] = "V";
			lbltitle.Text = "Dernières visites pour les Ventes";
		}*/
		
		if(Session["ARCHIVEVARIABLE"] == null)
			Session["ARCHIVEVARIABLE"] = "actif";
		
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
    
    protected string btn_Memo(string text)
    {
        string stext = "";
        string remplissage;
        String sql = "SELECT Memo FROM visite WHERE id_visite = '" + text + "'";
        //Modifier3.Text = text;
        using (OdbcConnection db =
        new OdbcConnection(_ConnectionString))
        {
            // Create the Command and Parameter objects.
            OdbcCommand command = new OdbcCommand(sql, db);


            // Open the connection in a try/catch block. 
            // Create and execute the DataReader, writing the result
            // set to the console window.
            try
            {
                db.Open();
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    remplissage = reader[0].ToString();
                    if (remplissage != "")
                    {
                        stext = "<img style='width:25px;' src='../img_site/memo1.png' alt='bloc-note'>";
                    }
                    else if (remplissage == "")
                    {
                        stext = "<img style='width:25px;' src='../img_site/memo.png' alt='bloc-note'>";
                    }
                }
                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        
        return stext;
    }
   
    protected string tooltip_Memo(string text)
    {
        string stext = "";
        String sql = "SELECT Memo FROM visite WHERE id_visite = '" + text + "'";
        using (OdbcConnection db =
        new OdbcConnection(_ConnectionString))
        {
            // Create the Command and Parameter objects.
            OdbcCommand command = new OdbcCommand(sql, db);


            // Open the connection in a try/catch block. 
            // Create and execute the DataReader, writing the result
            // set to the console window.
            try
            {
                db.Open();
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    stext = "<div class = \"tooltip3 span MySpace\"><span style='white-space:normal;width: 200px'>" + (String)reader[0] + "</span></div>";
                }
                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }



        return stext;
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
    /// 

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

        string sql = "SELECT visite.Memo, Biens.[texte internet], visite.[id_visite] ,visite.[date_visite] , Biens.[ref], Biens.[type de bien], Biens.[adresse vendeur], Biens.[code postal vendeur], Biens.[ville vendeur], Biens.[nom vendeur], Biens.[tel domicile vendeur], Biens.[adresse mail vendeur], Acquereurs.nom, Acquereurs.tel, Acquereurs.mail, Biens.etat, Acquereurs.categorie, Acquereurs.id_acq FROM ((Biens INNER JOIN optionsBiens ON Biens.ref = optionsBiens.refOptions) INNER JOIN visite ON Biens.ref = visite.id_bien) INNER JOIN Acquereurs ON visite.acquereur = Acquereurs.id_acq WHERE (((Biens.ref) Like '" 
					+ Session["TypeTransaaction"].ToString() + "%') AND((Biens.actif)='" 
					+ Session["ARCHIVEVARIABLE"].ToString() + "') AND ((visite.idclient)="
					+ member.IDCLIENT + ")) ORDER BY visite.date_visite DESC";
       
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
            e.Row.Cells[13].Attributes.Add("style", "display:none");
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.Cells[5].Attributes.Add("style", "display:none");
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.Cells[19].Attributes.Add("style", "display:none");
        //if (e.Row.RowType == DataControlRowType.Header)
            //e.Row.Cells[13].Attributes.Add("style", "display:none");
        

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            /*if (e.Row.Cells[11].Text == "precis")
            {
                e.Row.Cells[12].BackColor = System.Drawing.Color.YellowGreen;
                e.Row.Cells[13].BackColor = System.Drawing.Color.YellowGreen;
                e.Row.Cells[14].BackColor = System.Drawing.Color.YellowGreen;

            }
            else if (e.Row.Cells[11].Text == "large")
            {
                e.Row.Cells[12].CssClass = "Style1";
                e.Row.Cells[13].CssClass = "Style1";
                e.Row.Cells[14].CssClass = "Style1";

            }
            else if (e.Row.Cells[11].Text == "investisseur ancien")
            {
                e.Row.Cells[12].BackColor = System.Drawing.Color.BurlyWood;
                e.Row.Cells[13].BackColor = System.Drawing.Color.BurlyWood;
                e.Row.Cells[14].BackColor = System.Drawing.Color.BurlyWood;
            }
            else if (e.Row.Cells[11].Text == "investisseur neuf")
            {
                e.Row.Cells[12].BackColor = System.Drawing.Color.Khaki;
                e.Row.Cells[13].BackColor = System.Drawing.Color.Khaki;
                e.Row.Cells[14].BackColor = System.Drawing.Color.Khaki;
            }*/
            e.Row.Cells[13].Visible = false;
            //e.Row.Cells[15].Visible = true;
            e.Row.Cells[16].Visible = true;
            e.Row.Cells[17].Visible = true;
            e.Row.Cells[19].Visible = false;
            e.Row.Cells[5].Visible = false;

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
            if ((String)Session["TypeTransaaction"] == "L")
            {
                e.Row.Cells[3].Attributes["onClick"] = "location.href='fichedetail1.aspx?ref=" + DataBinder.Eval(e.Row.DataItem, "ref") + "'";
            }

            if ((String)Session["TypeTransaaction"] == "V")
            {
                e.Row.Cells[3].Attributes["onClick"] = "location.href='fichedetail1.aspx?ref=" + DataBinder.Eval(e.Row.DataItem, "ref") + "'";
            }
            
            //pour l'acquereur

            //e.Row.Cells[12].Attributes["onClick"] = "location.href='afficher_acquereur.aspx?ref=" + DataBinder.Eval(e.Row.DataItem, "id_acq") + "'";
            //string refe = e.Row.Cells[1].Text.ToString();




            string texte_internet = "";
			if(DataBinder.Eval(e.Row.DataItem, "texte internet").ToString() != "") 
				texte_internet = "<br/><br/>" + DataBinder.Eval(e.Row.DataItem, "texte internet").ToString();
			else
				texte_internet = "";
            string adresse_vendeur = "";
            if (DataBinder.Eval(e.Row.DataItem, "adresse vendeur").ToString() != "")
                adresse_vendeur = "<br/><br/>" + DataBinder.Eval(e.Row.DataItem, "adresse vendeur").ToString();
            else
                adresse_vendeur = "";
            string code_postal_vendeur = "";
            if (DataBinder.Eval(e.Row.DataItem, "code postal vendeur").ToString() != "")
                code_postal_vendeur = "<br/><br/>" + DataBinder.Eval(e.Row.DataItem, "code postal vendeur").ToString();
            else
                code_postal_vendeur = "";


            e.Row.Cells[3].Text = DataBinder.Eval(e.Row.DataItem, "ref") + "</a>"
                                    + "<div class = \"tooltip3 span MySpace\"><span style='white-space:normal;'>" + e.Row.Cells[3].Text + nl2br(texte_internet) + "</span></div>";

            //Modifier3.Text = DataBinder.Eval(e.Row.DataItem, "ref").ToString();
			
          /*string refer = e.Row.Cells[1].Text;		
            string type_bien = DataBinder.Eval(e.Row.DataItem, "type de bien").ToString();
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
            }*/

            if (e.Row.Cells[4].Text.Length > 20)
            {
                string A = e.Row.Cells[4].Text;
                e.Row.Cells[4].Text = e.Row.Cells[4].Text.ToString().Substring(0, 20);
                e.Row.Cells[4].Text = e.Row.Cells[4].Text + "<div class = \"tooltip\"><span>" + A + "</span></div>";
            }
            else
            {
                e.Row.Cells[4].Text = e.Row.Cells[4].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[4].Text + "</span></div>";
            }

            if (e.Row.Cells[8].Text.Length > 20)
            {
                string A = e.Row.Cells[8].Text;
                e.Row.Cells[8].Text = e.Row.Cells[8].Text.ToString().Substring(0, 20);
                e.Row.Cells[8].Text = e.Row.Cells[8].Text + "<div class = \"tooltip\"><span>" + A + "</span></div>";
            }
            else
            {
                e.Row.Cells[8].Text = e.Row.Cells[8].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[8].Text + "</span></div>";
            }


            if (e.Row.Cells[10].Text.Length > 20)
            {
                string A = e.Row.Cells[10].Text;
                e.Row.Cells[10].Text = e.Row.Cells[10].Text.ToString().Substring(0, 20);
                e.Row.Cells[10].Text = e.Row.Cells[10].Text + "<div class = \"tooltip\"><span>" + A + "</span></div>";
            }
            else
            {
                string A = e.Row.Cells[10].Text;
                e.Row.Cells[10].Text = e.Row.Cells[10].Text.ToString();
                e.Row.Cells[10].Text = e.Row.Cells[10].Text + "<div class = \"tooltip\"><span>" + A + "</span></div>";
            }

            /*if (e.Row.Cells[11].Text.Length > 20)
            {
                string A = e.Row.Cells[11].Text;
                e.Row.Cells[11].Text = "<A HREF=mailto:" + A + ">" + A.ToString().Substring(0, 20) + "</A>";
                e.Row.Cells[11].Text = e.Row.Cells[11].Text + "<div class = \"tooltip\"><span>" + A + "</span></div>";
            }
            else
            {
                e.Row.Cells[11].Text = e.Row.Cells[11].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[11].Text + "</span></div>";
            }*/

            /*if (e.Row.Cells[12].Text.Length > 3)
            {
                string A = e.Row.Cells[12].Text;
                e.Row.Cells[12].Text = e.Row.Cells[12].Text.ToString().Substring(0, 3);
                e.Row.Cells[12].Text = e.Row.Cells[12].Text + "<div class = \"tooltip\"><span>" + A + "</span></div>";
                

            }
            else
            {
                e.Row.Cells[12].Text = e.Row.Cells[12].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[12].Text + "</span></div>";
            }*/

           //.Row.Cells[0].Text = e.Row.Cells[0].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[0].Text + "</span></div>";
          //e.Row.Cells[4].Text = e.Row.Cells[4].Text + "<div class = \"tooltip\"><span>" + e.Row.Cells[4].Text + "</span></div>";
            e.Row.Cells[2].Text = e.Row.Cells[2].Text + "<div class = \"tooltip4\"><span>" + e.Row.Cells[2].Text + "</span></div>";
            e.Row.Cells[7].Text = e.Row.Cells[7].Text + "<div class = \"tooltip3\"><span style='white-space:normal;'>" + e.Row.Cells[7].Text + nl2br(adresse_vendeur) + nl2br(code_postal_vendeur) + "</span></div>";
            e.Row.Cells[9].Text = e.Row.Cells[9].Text + "<div class = \"tooltip4\"><span>" + e.Row.Cells[9].Text + "</span></div>";
            e.Row.Cells[10].Text = e.Row.Cells[10].Text;
            
            e.Row.Cells[15].Text = e.Row.Cells[15].Text + "<div class = \"tooltip4\"><span>" + e.Row.Cells[15].Text + "</span></div>";
            e.Row.Cells[16].Text = e.Row.Cells[16].Text + "<div class = \"tooltip4\"><span>" + e.Row.Cells[16].Text + "</span></div>";

            var loue = e.Row.Cells[3].Text.ToString().Substring(0, 1);
            var couleur = e.Row.Cells[5].Text.ToString().Substring(0, 3);
            var couleurbis = e.Row.Cells[13].Text.ToString();


            switch (couleurbis)
                {
                case "precis":
            
                e.Row.Cells[13].BackColor = System.Drawing.Color.YellowGreen;
                e.Row.Cells[13].CssClass = "centerimage";
                e.Row.Cells[14].BackColor = System.Drawing.Color.YellowGreen;
                e.Row.Cells[14].CssClass = "centerimage";
                e.Row.Cells[15].BackColor = System.Drawing.Color.YellowGreen;
                e.Row.Cells[15].CssClass = "centerimage";
                e.Row.Cells[16].BackColor = System.Drawing.Color.YellowGreen;
                e.Row.Cells[16].CssClass = "centerimage";
                e.Row.Cells[17].BackColor = System.Drawing.Color.YellowGreen;
                e.Row.Cells[17].CssClass = "centerimage";
                e.Row.Cells[18].BackColor = System.Drawing.Color.YellowGreen;
                e.Row.Cells[18].CssClass = "centerimage";
                

                break;
                
                case "large":
            
                e.Row.Cells[13].CssClass = "Style1";
                e.Row.Cells[14].CssClass = "Style1";
                e.Row.Cells[15].CssClass = "Style1";
                e.Row.Cells[16].CssClass = "Style1";
                e.Row.Cells[17].CssClass = "Style1";
                e.Row.Cells[18].CssClass = "Style1";
                

                break;
            
                case "investisseur ancien":
            
                e.Row.Cells[13].BackColor = System.Drawing.Color.BurlyWood;
                e.Row.Cells[13].CssClass = "centerimage";
                e.Row.Cells[14].BackColor = System.Drawing.Color.BurlyWood;
                e.Row.Cells[14].CssClass = "centerimage";
                e.Row.Cells[15].BackColor = System.Drawing.Color.BurlyWood;
                e.Row.Cells[15].CssClass = "centerimage";
                e.Row.Cells[16].BackColor = System.Drawing.Color.BurlyWood;
                e.Row.Cells[16].CssClass = "centerimage";
                e.Row.Cells[17].BackColor = System.Drawing.Color.BurlyWood;
                e.Row.Cells[17].CssClass = "centerimage";
                e.Row.Cells[18].BackColor = System.Drawing.Color.BurlyWood;
                e.Row.Cells[18].CssClass = "centerimage";
                

                break;
            
                case "investisseur neuf":
            
                e.Row.Cells[13].BackColor = System.Drawing.Color.Khaki;
                e.Row.Cells[13].CssClass= "centerimage";
                e.Row.Cells[14].BackColor = System.Drawing.Color.Khaki;
                e.Row.Cells[14].CssClass = "centerimage";
                e.Row.Cells[15].BackColor = System.Drawing.Color.Khaki;
                e.Row.Cells[15].CssClass = "centerimage";
                e.Row.Cells[16].BackColor = System.Drawing.Color.Khaki;
                e.Row.Cells[16].CssClass = "centerimage";
                e.Row.Cells[17].BackColor = System.Drawing.Color.Khaki;
                e.Row.Cells[17].CssClass = "centerimage";
                e.Row.Cells[18].BackColor = System.Drawing.Color.Khaki;
                e.Row.Cells[18].CssClass = "centerimage";
                

                break;

                default:
                e.Row.Cells[13].CssClass = "Disponible";
                
                e.Row.Cells[14].CssClass = "Disponible";
                
                e.Row.Cells[15].CssClass = "Disponible";
             
                e.Row.Cells[16].CssClass = "Disponible";
                
                e.Row.Cells[17].CssClass = "Disponible";
                
                e.Row.Cells[18].CssClass = "Disponible";


                break;
            
            }
            switch (couleur)
            {
                case "Dis":
                    e.Row.Cells[0].CssClass = "Disponible";
                    e.Row.Cells[2].CssClass = "cursor_link Disponible";
                    e.Row.Cells[1].CssClass = "Disponible";
                    e.Row.Cells[3].CssClass = "Disponible";
                    e.Row.Cells[4].CssClass = "Disponible";
                    e.Row.Cells[5].CssClass = "Disponible";
                    e.Row.Cells[6].CssClass = "Disponible";
                    e.Row.Cells[7].CssClass = "Disponible";
                    e.Row.Cells[8].CssClass = "Disponible";
                    e.Row.Cells[9].CssClass = "Disponible";
                    e.Row.Cells[10].CssClass = "Disponible";
                    e.Row.Cells[11].CssClass = "Disponible";

                    break;

                case "Off":
                    e.Row.Cells[0].CssClass = "Offre";
                    e.Row.Cells[2].CssClass = "cursor_link Offre";
                    e.Row.Cells[1].CssClass = "Offre";
                    e.Row.Cells[3].CssClass = "Offre";
                    e.Row.Cells[4].CssClass = "Offre";
                    e.Row.Cells[5].CssClass = "Offre";
                    e.Row.Cells[6].CssClass = "Offre";
                    e.Row.Cells[7].CssClass = "Offre";
                    e.Row.Cells[8].CssClass = "Offre";
                    e.Row.Cells[9].CssClass = "Offre";
                    e.Row.Cells[10].CssClass = "Offre";
                    e.Row.Cells[11].CssClass = "Offre";

                    break;
                case "Est":
                    e.Row.Cells[0].CssClass = "Estimation";
                    e.Row.Cells[2].CssClass = "cursor_link Estimation";
                    e.Row.Cells[1].CssClass = "Estimation";
                    e.Row.Cells[3].CssClass = "Estimation";
                    e.Row.Cells[4].CssClass = "Estimation";
                    e.Row.Cells[5].CssClass = "Estimation";
                    e.Row.Cells[6].CssClass = "Estimation";
                    e.Row.Cells[7].CssClass = "Estimation";
                    e.Row.Cells[8].CssClass = "Estimation";
                    e.Row.Cells[9].CssClass = "Estimation";
                    e.Row.Cells[10].CssClass = "Estimation";
                    e.Row.Cells[11].CssClass = "Estimation";

                    break;

                case "Sus":
                    switch (loue)
                    {
                        case "V":
                            e.Row.Cells[0].CssClass = "Suspendu";
                            e.Row.Cells[2].CssClass = "cursor_link Suspendu";
                            e.Row.Cells[1].CssClass = "Suspendu";
                            e.Row.Cells[3].CssClass = "Suspendu";
                            e.Row.Cells[4].CssClass = "Suspendu";
                            e.Row.Cells[5].CssClass = "Suspendu";
                            e.Row.Cells[6].CssClass = "Suspendu";
                            e.Row.Cells[7].CssClass = "Suspendu";
                            e.Row.Cells[8].CssClass = "Suspendu";
                            e.Row.Cells[9].CssClass = "Suspendu";
                            e.Row.Cells[10].CssClass = "Suspendu";
                            e.Row.Cells[11].CssClass = "Suspendu";
                            break;
                        case "L":
                            e.Row.Cells[0].CssClass = "SuspenduL";
                            e.Row.Cells[2].CssClass = "cursor_link SuspenduL";
                            e.Row.Cells[1].CssClass = "SuspenduL";
                            e.Row.Cells[3].CssClass = "SuspenduL";
                            e.Row.Cells[4].CssClass = "SuspenduL";
                            e.Row.Cells[5].CssClass = "SuspenduL";
                            e.Row.Cells[6].CssClass = "SuspenduL";
                            e.Row.Cells[7].CssClass = "SuspenduL";
                            e.Row.Cells[8].CssClass = "SuspenduL";
                            e.Row.Cells[9].CssClass = "SuspenduL";
                            e.Row.Cells[10].CssClass = "SuspenduL";
                            e.Row.Cells[11].CssClass = "SuspenduL";

                            break;
                    }
                    break;

                case "Ret":
                    switch (loue)
                    {
                        case "V":
                            e.Row.Cells[0].CssClass = "Retire";
                            e.Row.Cells[2].CssClass = "cursor_link Retire";
                            e.Row.Cells[1].CssClass = "Retire";
                            e.Row.Cells[3].CssClass = "Retire";
                            e.Row.Cells[4].CssClass = "Retire";
                            e.Row.Cells[5].CssClass = "Retire";
                            e.Row.Cells[6].CssClass = "Retire";
                            e.Row.Cells[7].CssClass = "Retire";
                            e.Row.Cells[8].CssClass = "Retire";
                            e.Row.Cells[9].CssClass = "Retire";
                            e.Row.Cells[10].CssClass = "Retire";
                            e.Row.Cells[11].CssClass = "Retire";


                            break;
                        case "L":
                            e.Row.Cells[0].CssClass = "RetireL";
                            e.Row.Cells[2].CssClass = "cursor_link RetireL";
                            e.Row.Cells[1].CssClass = "RetireL";
                            e.Row.Cells[3].CssClass = "RetireL";
                            e.Row.Cells[4].CssClass = "RetireL";
                            e.Row.Cells[5].CssClass = "RetireL";
                            e.Row.Cells[6].CssClass = "RetireL";
                            e.Row.Cells[7].CssClass = "RetireL";
                            e.Row.Cells[8].CssClass = "RetireL";
                            e.Row.Cells[9].CssClass = "RetireL";
                            e.Row.Cells[10].CssClass = "RetireL";
                            e.Row.Cells[11].CssClass = "RetireL";

                            break;
                    }
                    break;

                case "est":
                    e.Row.Cells[0].CssClass = "Estimation";
                    e.Row.Cells[2].CssClass = "cursor_link Estimation";
                    e.Row.Cells[1].CssClass = "Estimation";
                    e.Row.Cells[3].CssClass = "Estimation";
                    e.Row.Cells[4].CssClass = "Estimation";
                    e.Row.Cells[5].CssClass = "Estimation";
                    e.Row.Cells[6].CssClass = "Estimation";
                    e.Row.Cells[7].CssClass = "Estimation";
                    e.Row.Cells[8].CssClass = "Estimation";
                    e.Row.Cells[9].CssClass = "Estimation";
                    e.Row.Cells[10].CssClass = "Estimation";
                    e.Row.Cells[11].CssClass = "Estimation";

                    break;

                case "Com":
                    e.Row.Cells[0].CssClass = "Compromis";
                    e.Row.Cells[2].CssClass = "cursor_link Compromis";
                    e.Row.Cells[1].CssClass = "Compromis";
                    e.Row.Cells[3].CssClass = "Compromis";
                    e.Row.Cells[4].CssClass = "Compromis";
                    e.Row.Cells[5].CssClass = "Compromis";
                    e.Row.Cells[6].CssClass = "Compromis";
                    e.Row.Cells[7].CssClass = "Compromis";
                    e.Row.Cells[8].CssClass = "Compromis";
                    e.Row.Cells[9].CssClass = "Compromis";
                    e.Row.Cells[10].CssClass = "Compromis";
                    e.Row.Cells[11].CssClass = "Compromis";

                    break;

                case "Lib":
                    e.Row.Cells[0].CssClass = "Libre";
                    e.Row.Cells[2].CssClass = "cursor_link Libre";
                    e.Row.Cells[1].CssClass = "Libre";
                    e.Row.Cells[3].CssClass = "Libre";
                    e.Row.Cells[4].CssClass = "Libre";
                    e.Row.Cells[5].CssClass = "Libre";
                    e.Row.Cells[6].CssClass = "Libre";
                    e.Row.Cells[7].CssClass = "Libre";
                    e.Row.Cells[8].CssClass = "Libre";
                    e.Row.Cells[9].CssClass = "Libre";
                    e.Row.Cells[10].CssClass = "Libre";
                    e.Row.Cells[11].CssClass = "Libre";

                    break;

                case "Occ":
                    e.Row.Cells[0].CssClass = "Occupe";
                    e.Row.Cells[2].CssClass = "cursor_link Occupe";
                    e.Row.Cells[1].CssClass = "Occupe";
                    e.Row.Cells[3].CssClass = "Occupe";
                    e.Row.Cells[4].CssClass = "Occupe";
                    e.Row.Cells[5].CssClass = "Occupe";
                    e.Row.Cells[6].CssClass = "Occupe";
                    e.Row.Cells[7].CssClass = "Occupe";
                    e.Row.Cells[8].CssClass = "Occupe";
                    e.Row.Cells[9].CssClass = "Occupe";
                    e.Row.Cells[10].CssClass = "Occupe";
                    e.Row.Cells[11].CssClass = "Occupe";

                    break;

                case "Lou":
                    e.Row.Cells[0].CssClass = "Loue";
                    e.Row.Cells[2].CssClass = "cursor_link Loue";
                    e.Row.Cells[1].CssClass = "Loue";
                    e.Row.Cells[3].CssClass = "Loue";
                    e.Row.Cells[4].CssClass = "Loue";
                    e.Row.Cells[5].CssClass = "Loue";
                    e.Row.Cells[6].CssClass = "Loue";
                    e.Row.Cells[7].CssClass = "Loue";
                    e.Row.Cells[8].CssClass = "Loue";
                    e.Row.Cells[9].CssClass = "Loue";
                    e.Row.Cells[10].CssClass = "Loue";
                    e.Row.Cells[11].CssClass = "Loue";

                    break;

                case "Opt":
                    e.Row.Cells[0].CssClass = "Option";
                    e.Row.Cells[2].CssClass = "cursor_link Option";
                    e.Row.Cells[1].CssClass = "Option";
                    e.Row.Cells[3].CssClass = "Option";
                    e.Row.Cells[4].CssClass = "Option";
                    e.Row.Cells[5].CssClass = "Option";
                    e.Row.Cells[6].CssClass = "Option";
                    e.Row.Cells[7].CssClass = "Option";
                    e.Row.Cells[8].CssClass = "Option";
                    e.Row.Cells[9].CssClass = "Option";
                    e.Row.Cells[10].CssClass = "Option";
                    e.Row.Cells[11].CssClass = "Option";

                    break;

                default:

                    e.Row.Cells[0].CssClass = "Reserve";
                    e.Row.Cells[2].CssClass = "cursor_link Reserve";
                    e.Row.Cells[1].CssClass = "Reserve";
                    e.Row.Cells[3].CssClass = "Reserve";
                    e.Row.Cells[4].CssClass = "Reserve";
                    e.Row.Cells[5].CssClass = "Reserve";
                    e.Row.Cells[6].CssClass = "Reserve";
                    e.Row.Cells[7].CssClass = "Reserve";
                    e.Row.Cells[8].CssClass = "Reserve";
                    e.Row.Cells[9].CssClass = "Reserve";
                    e.Row.Cells[10].CssClass = "Reserve";
                    e.Row.Cells[11].CssClass = "Reserve";

                    break;

            }
            
           
        }
    }



    /*protected void OpenWindow(object sender, EventArgs e)
    {
        string url = "popup.aspx";
        string s = "window.open('" + url + "', 'popup_window', 'width=500,height=450,left=100,top=100,resizable=yes');";
        ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
    }*/   
    

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
    
    protected void addnote_onclick(object sender, EventArgs e)
    {
        OdbcConnection db = new OdbcConnection();
        
        string ref_bien = Modifier3.Text;
        var memory = textarea2.Text;
        OdbcCommand update = new OdbcCommand();
        update.CommandType = System.Data.CommandType.Text;
        update.CommandText = "UPDATE visite SET Memo = '" + memory + "' WHERE id_bien = '" + ref_bien + "'";
        db = new OdbcConnection(_ConnectionString);
        update.Connection = db;
        db.Open();
        update.ExecuteNonQuery();
        db.Close();
    }

    protected string Voir_Historique(string text)
    {
        String selectedValue = text;
        string stext = "";
        Session["idbien"] = selectedValue;

        stext = "<a href=\"./historique_visite.aspx\"><img class=\"croix_rouge\" src=\"../img_site/flat_round/modifier.png\" /></a>";

            LabelErrorLogin.Visible = false;
        return stext;
    }
    protected string modifier_acquereur(string text)
    {
        string stext = "";
        stext = "<a href=\"modifier_acquereur.aspx?reference=" + text + "\"><img class=\"croix_rouge\" src=\"../img_site/flat_round/modifier.png\" /></a>";
        return stext;
    }
    protected string modifier_bien(string text)
    {
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

    protected void GridViewHist_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridViewHist_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }

	
	protected String nl2br(string s)
	{
		Regex rgx = new Regex("\r\n|\r|\n");
		return rgx.Replace(s,"<br/>"); 
	}


}

