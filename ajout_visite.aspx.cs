
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;


/// <summary>
/// Description résumée de Class1
/// </summary>
public partial class pages_ajout_visite : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Page.Master.FindControl("titrebandeau")).Text = "Mon espace";
        //create_radiobutton();
     
   

        if (this.RadioButtonMesBiens.Checked)
        {
            fill_table("Mes biens");

        }
        else if (RadioButtonTousLesBiens.Checked)
        {
            fill_table("Tous les biens");
        }
        else if (RadioButtonMonAgence.Checked)
        {
            fill_table("Mon agence");
        }
        else
        {
            fill_table("Mes biens");
        }


        if (Session["logged"].Equals(true))
        {
            // permet le "Bonjour Mr X"
            Membre member = (Membre)Session["Membre"];
            LabelPrenom.Text = member.CIVILITE;
            LabelNom.Text = member.NOM;
        }
        else
        {
            Response.Redirect("./recherche.aspx");
        }

		//Lorsque l'on clique sur certains items, tels que les radiobuttons, l'option autopostback="true", permet recharger la page mais pas ce qui suit :
        if (!Page.IsPostBack)
        {
            RadioButtonMesBiens.Checked = true;
            populate_DDL_Acq();
        }
    }

    //POPULATINGS
    protected void populate_DDL_Acq()
    {
        DropDownListAcquereurs.Items.Clear();
        DropDownListAcquereurs.Items.Add(new ListItem(" ","0"));


        Membre member3 = (Membre)Session["Membre"];

        #region Peuplement de DropDownListAcquereurs
        //Peuplement des DropdownList à partir de la table table_types
        string requette = "select `id_acq`, `nom`, `prenom`, `adresse`, `ville`, `code_postal`, `tel`, `mail` from Acquereurs where `idclient`=" + member3.IDCLIENT + "AND `actif`='actif'";

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
            if (ligne["nom"].ToString() != "null")
            {
                DropDownListAcquereurs.Items.Add(new ListItem(ligne["nom"].ToString() + " " + ligne["prenom"].ToString() + " " + ligne["adresse"].ToString() + " " + ligne["ville"].ToString() + " " + ligne["code_postal"].ToString() + " " + ligne["tel"].ToString() + " " + ligne["mail"].ToString(), ligne["id_acq"].ToString()));
            }
        }
        #endregion
    }



    //CONSTRUCTION DU TABLEAU DES BIENS 
    protected void fill_table(string whose)
    {
	//PRINCIPE : on déclare le strict minimum du tableau dans la page aspx.
	//On remplit le tableau en c#. On met dans une cellule du texte ou une checkbox rattachée à un event.
	// On peut aisément générer des ID dynamiquement.
	//On insère cette cellule dans une ligne. On ajoute cette ligne à une varaible tableau. 
	//On rattache cette variable tableau au tableau déclaré dans la page aspx.
	

        TablePlanif.Rows.Clear();
        TableRow tRow;
        TableCell tCell1;
        CheckBox cb;
        int j = 0; // indice pour l'alternance des couleurs

        // affichage du nom des colonnes
        tRow = new TableRow();

        tCell1 = new TableCell();
        tCell1.Text = "<strong>Référence</strong>";
        tRow.Cells.Add(tCell1);

        tCell1 = new TableCell();
        tCell1.Text = "<strong>Négociateur</strong>";
        tRow.Cells.Add(tCell1);

        tCell1 = new TableCell();
        tCell1.Text = "<strong>Prix de vente</strong>";
        tRow.Cells.Add(tCell1);

        tCell1 = new TableCell();
        tCell1.Text = "<strong>Type de bien</strong>";
        tRow.Cells.Add(tCell1);

        tCell1 = new TableCell();
        tCell1.Text = "<strong>Date de dossier</strong>";
        tRow.Cells.Add(tCell1);

        tCell1 = new TableCell();
        tCell1.Text = "<strong>Ville</strong>";
        tRow.Cells.Add(tCell1);

        tCell1 = new TableCell();
        tCell1.Text = "<strong>Code postal</strong>";
        tRow.Cells.Add(tCell1);

        tCell1 = new TableCell();
        tCell1.Text = "<strong>Surface</strong>";
        tRow.Cells.Add(tCell1);

        tCell1 = new TableCell();


        tCell1 = new TableCell();
        cb = new CheckBox();
        cb.ID ="CheckBoxGlobale";
        cb.AutoPostBack = true;
        cb.  CheckedChanged += new EventHandler(globale_cb_changed);


        tCell1.Controls.Add(cb);
        tRow.Cells.Add(tCell1);
       // tCell1.Text = "<strong>Visite</strong>";


        tRow.CssClass = "champs";
        TablePlanif.Rows.Add(tRow);

        // Cases de tri. Les fleches sont des liens vers la meme page en ajoutant des variables dans l'url
        tRow = new TableRow();

        // Cellule fleche ref
        tCell1 = new TableCell();

        Table minitab = new Table();
        TableRow tMiniRow = new TableRow();
        TableCell tMiniCell = new TableCell();
        ImageButton fleche = new ImageButton();
        fleche.ImageUrl = "../img_site/fleche_tri_bas.png";
        fleche.Click += new ImageClickEventHandler(ImageButton_Click);
        fleche.ID = "refDESC";
        tMiniCell.Controls.Add(fleche);
        tMiniRow.Cells.Add(tMiniCell);

        tMiniCell = new TableCell();
        fleche = new ImageButton();
        fleche.ImageUrl = "../img_site/fleche_tri_haut.png";
        fleche.Click += new ImageClickEventHandler(ImageButton_Click);
        fleche.ID = "refASC";
        tMiniCell.Controls.Add(fleche);

        tMiniRow.Cells.Add(tMiniCell);
        minitab.Rows.Add(tMiniRow);
        tCell1.Controls.Add(minitab);
        tRow.Cells.Add(tCell1);

        // Cellule fleche nego
        tCell1 = new TableCell();

        minitab = new Table();
        tMiniRow = new TableRow();
        tMiniCell = new TableCell();

        fleche = new ImageButton();
        fleche.ImageUrl = "../img_site/fleche_tri_bas.png";
        fleche.Click += new ImageClickEventHandler(ImageButton_Click);
        fleche.ID = "negoDESC";
        tMiniCell.Controls.Add(fleche);
        tMiniRow.Cells.Add(tMiniCell);

        tMiniCell = new TableCell();
        fleche = new ImageButton();
        fleche.ImageUrl = "../img_site/fleche_tri_haut.png";
        fleche.Click += new ImageClickEventHandler(ImageButton_Click);
        fleche.ID = "negoASC";
        tMiniCell.Controls.Add(fleche);

        tMiniRow.Cells.Add(tMiniCell);
        minitab.Rows.Add(tMiniRow);
        tCell1.Controls.Add(minitab);
        tRow.Cells.Add(tCell1);

        // Cellule fleche prix de vente
        tCell1 = new TableCell();

        minitab = new Table();
        tMiniRow = new TableRow();
        tMiniCell = new TableCell();
        fleche = new ImageButton();
        fleche.ImageUrl = "../img_site/fleche_tri_bas.png";
        fleche.Click += new ImageClickEventHandler(ImageButton_Click);
        fleche.ID = "prixDESC";
        tMiniCell.Controls.Add(fleche);
        tMiniRow.Cells.Add(tMiniCell);

        tMiniCell = new TableCell();
        fleche = new ImageButton();
        fleche.ImageUrl = "../img_site/fleche_tri_haut.png";
        fleche.Click += new ImageClickEventHandler(ImageButton_Click);
        fleche.ID = "prixASC";
        tMiniCell.Controls.Add(fleche);

        tMiniRow.Cells.Add(tMiniCell);
        minitab.Rows.Add(tMiniRow);
        tCell1.Controls.Add(minitab);
        tRow.Cells.Add(tCell1);

        // Cellule fleche type
        tCell1 = new TableCell();

        minitab = new Table();
        tMiniRow = new TableRow();
        tMiniCell = new TableCell();
        fleche = new ImageButton();
        fleche.ImageUrl = "../img_site/fleche_tri_bas.png";
        fleche.Click += new ImageClickEventHandler(ImageButton_Click);
        fleche.ID = "typeDESC";
        tMiniCell.Controls.Add(fleche);
        tMiniRow.Cells.Add(tMiniCell);

        tMiniCell = new TableCell();
        fleche = new ImageButton();
        fleche.ImageUrl = "../img_site/fleche_tri_haut.png";
        fleche.Click += new ImageClickEventHandler(ImageButton_Click);
        fleche.ID = "typeASC";
        tMiniCell.Controls.Add(fleche);

        tMiniRow.Cells.Add(tMiniCell);
        minitab.Rows.Add(tMiniRow);
        tCell1.Controls.Add(minitab);
        tRow.Cells.Add(tCell1);

        // Cellule fleche date
        tCell1 = new TableCell();

        minitab = new Table();
        tMiniRow = new TableRow();
        tMiniCell = new TableCell();
        fleche = new ImageButton();
        fleche.ImageUrl = "../img_site/fleche_tri_bas.png";
        fleche.Click += new ImageClickEventHandler(ImageButton_Click);
        fleche.ID = "dateDESC";
        tMiniCell.Controls.Add(fleche);
        tMiniRow.Cells.Add(tMiniCell);

        tMiniCell = new TableCell();
        fleche = new ImageButton();
        fleche.ImageUrl = "../img_site/fleche_tri_haut.png";
        fleche.Click += new ImageClickEventHandler(ImageButton_Click);
        fleche.ID = "dateASC";
        tMiniCell.Controls.Add(fleche);

        tMiniRow.Cells.Add(tMiniCell);
        minitab.Rows.Add(tMiniRow);
        tCell1.Controls.Add(minitab);
        tRow.Cells.Add(tCell1);

        // Cellule fleche ville
        tCell1 = new TableCell();

        minitab = new Table();
        tMiniRow = new TableRow();
        tMiniCell = new TableCell();
        fleche = new ImageButton();
        fleche.ImageUrl = "../img_site/fleche_tri_bas.png";
        fleche.Click += new ImageClickEventHandler(ImageButton_Click);
        fleche.ID = "villeDESC";
        tMiniCell.Controls.Add(fleche);
        tMiniRow.Cells.Add(tMiniCell);

        tMiniCell = new TableCell();
        fleche = new ImageButton();
        fleche.ImageUrl = "../img_site/fleche_tri_haut.png";
        fleche.Click += new ImageClickEventHandler(ImageButton_Click);
        fleche.ID = "villeASC";
        tMiniCell.Controls.Add(fleche);

        tMiniRow.Cells.Add(tMiniCell);
        minitab.Rows.Add(tMiniRow);
        tCell1.Controls.Add(minitab);
        tRow.Cells.Add(tCell1);

        // Cellule fleche cp
        tCell1 = new TableCell();

        minitab = new Table();
        tMiniRow = new TableRow();
        tMiniCell = new TableCell();
        fleche = new ImageButton();
        fleche.ImageUrl = "../img_site/fleche_tri_bas.png";
        fleche.Click += new ImageClickEventHandler(ImageButton_Click);
        fleche.ID = "cpDESC";
        tMiniCell.Controls.Add(fleche);
        tMiniRow.Cells.Add(tMiniCell);

        tMiniCell = new TableCell();
        fleche = new ImageButton();
        fleche.ImageUrl = "../img_site/fleche_tri_haut.png";
        fleche.Click += new ImageClickEventHandler(ImageButton_Click);
        fleche.ID = "cpASC";
        tMiniCell.Controls.Add(fleche);

        tMiniRow.Cells.Add(tMiniCell);
        minitab.Rows.Add(tMiniRow);
        tCell1.Controls.Add(minitab);
        tRow.Cells.Add(tCell1);

        // Cellule fleche type
        tCell1 = new TableCell();

        minitab = new Table();
        tMiniRow = new TableRow();
        tMiniCell = new TableCell();
        fleche = new ImageButton();
        fleche.ImageUrl = "../img_site/fleche_tri_bas.png";
        fleche.Click += new ImageClickEventHandler(ImageButton_Click);
        fleche.ID = "surfaceDESC";
        tMiniCell.Controls.Add(fleche);
        tMiniRow.Cells.Add(tMiniCell);

        tMiniCell = new TableCell();
        fleche = new ImageButton();
        fleche.ImageUrl = "../img_site/fleche_tri_haut.png";
        fleche.Click += new ImageClickEventHandler(ImageButton_Click);
        fleche.ID = "surfaceASC";
        tMiniCell.Controls.Add(fleche);

        tMiniRow.Cells.Add(tMiniCell);
        minitab.Rows.Add(tMiniRow);
        tCell1.Controls.Add(minitab);
        tRow.Cells.Add(tCell1);

        tRow.CssClass = "tritableaudebord";
        TablePlanif.Rows.Add(tRow);

        // Choix du tri. Variables récupérées dans l'url
        String Ordre = "ASC";
        String OrderBy = "ref";

        // selon la variable récupérée, on forme le orderby pour la requette
        if (Session["type"] != null)
        {
            if (Session["type"].ToString() == "refASC")
            {
                OrderBy = "ref";
                Ordre = "ASC";
            }
            else if (Session["type"].ToString() == "refDESC")
            {
                OrderBy = "ref";
                Ordre = "DESC";
            }
            else if (Session["type"].ToString() == "negoASC")
            {
                OrderBy = "negociateur";
                Ordre = "ASC";

            }
            else if (Session["type"].ToString() == "negoDESC")
            {
                OrderBy = "negociateur";
                Ordre = "DESC";
            }
            else if (Session["type"].ToString() == "prixASC")
            {
                OrderBy = "prix de vente";
                Ordre = "ASC";
            }
            else if (Session["type"].ToString() == "prixDESC")
            {
                OrderBy = "prix de vente";
                Ordre = "DESC";
            }
            else if (Session["type"].ToString() == "typeASC")
            {
                OrderBy = "type de bien";
                Ordre = "ASC";
            }
            else if (Session["type"].ToString() == "typeDESC")
            {
                OrderBy = "type de bien";
                Ordre = "DESC";
            }
            else if (Session["type"].ToString() == "dateASC")
            {
                OrderBy = "date dossier";
                Ordre = "ASC";
            }
            else if (Session["type"].ToString() == "dateDESC")
            {
                OrderBy = "date dossier";
                Ordre = "DESC";
            }
            else if (Session["type"].ToString() == "villeASC")
            {
                OrderBy = "ville du bien";
                Ordre = "ASC";
            }
            else if (Session["type"].ToString() == "villeDESC")
            {
                OrderBy = "ville du bien";
                Ordre = "DESC";
            }
            else if (Session["type"].ToString() == "cpASC")
            {
                OrderBy = "code postal du bien";
                Ordre = "ASC";
            }
            else if (Session["type"].ToString() == "cpDESC")
            {
                OrderBy = "code postal du bien";
                Ordre = "DESC";
            }
            else if (Session["type"].ToString() == "surfaceASC")
            {
                OrderBy = "surface habitable";
                Ordre = "ASC";
            }
            else if (Session["type"].ToString() == "surfaceDESC")
            {
                OrderBy = "surface habitable";
                Ordre = "DESC";
            }
        }

        Membre member1 = (Membre)Session["Membre"];
        int idClientNego = member1.IDCLIENT;

        // On forme la requette sur la table bien suivant les biens ou tous les biens
        String requette = "";
        if (whose == "Mes biens")
        {
            requette = "select ref, `negociateur`, `loyer_cc`, `prix de vente`, `ville du bien`, `code postal du bien`, `type de bien`, `date dossier`, `surface habitable` from biens where `actif`='actif' AND `idclient`=" + idClientNego + " ORDER BY Biens.[" + OrderBy + "]" + Ordre;
        }
        else if (whose == "Tous les biens")
        {
            requette = "select ref, `negociateur`, `loyer_cc`, `prix de vente`, `ville du bien`, `code postal du bien`, `type de bien`, `date dossier`, `surface habitable` from biens where `actif`='actif' ORDER BY Biens.[" + OrderBy + "]" + Ordre;
        }
        else if (whose == "Mon agence")
        {
            requette = "select ref, `negociateur`, `loyer_cc`, `prix de vente`, `ville du bien`, `code postal du bien`, `type de bien`, `date dossier`, `surface habitable` from biens where `actif`='actif' AND `num`='" + member1.NUM_AGENCE + "' ORDER BY Biens.[" + OrderBy + "]" + Ordre;
        }


        System.Data.DataSet ds = null;
        Connexion c = null;

        c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();
        ds = c.exeRequette(requette);
        c.Close();
        c = null;

        // Boucle d'affichage des biens
        System.Data.DataRowCollection dr = ds.Tables[0].Rows;
        foreach (System.Data.DataRow ligne in dr)
        {

            tRow = new TableRow();

            tCell1 = new TableCell();
            tCell1.Text = ((String)ligne["ref"].ToString());
            tCell1.CssClass = "centre";
            tRow.Cells.Add(tCell1);

            tCell1 = new TableCell();
            tCell1.Text = ((String)ligne["negociateur"].ToString());
            tCell1.CssClass = "centre";
            tRow.Cells.Add(tCell1);

            tCell1 = new TableCell();
            if ((String)ligne["ref"].ToString().Substring(0, 1) == "V")
                tCell1.Text = ((String)ligne["prix de vente"].ToString()) + " €";
            else
                tCell1.Text = ((String)ligne["loyer_cc"].ToString()) + " €";
            tCell1.CssClass = "droite";
            tRow.Cells.Add(tCell1);

            tCell1 = new TableCell();
            tCell1.Text = ((String)ligne["type de bien"].ToString());
            tCell1.CssClass = "centre";
            tRow.Cells.Add(tCell1);

            tCell1 = new TableCell();
            tCell1.Text = ((String)ligne["date dossier"].ToString().Substring(0, 10));
            tCell1.CssClass = "centre";
            tRow.Cells.Add(tCell1);


            tCell1 = new TableCell();
            tCell1.Text = ((String)ligne["ville du bien"].ToString());
            tRow.Cells.Add(tCell1);

            tCell1 = new TableCell();
            tCell1.Text = ((String)ligne["code postal du bien"].ToString());
            tCell1.CssClass = "centre";
            tRow.Cells.Add(tCell1);


            tCell1 = new TableCell();
            tCell1.Text = ((String)ligne["surface habitable"].ToString());
            tCell1.CssClass = "centre";
            tRow.Cells.Add(tCell1);



            tCell1 = new TableCell();
            cb = new CheckBox();
            cb.ID = ((String)ligne["ref"]);
            cb.AutoPostBack = false;
            //cb.CheckedChanged += new EventHandler(cb_CheckedChanged);

            tCell1.Controls.Add(cb);
            tRow.Cells.Add(tCell1);

            if ((j % 2) == 0)
                tRow.CssClass = "pair";
            else
                tRow.CssClass = "impair";

            j++;

            TablePlanif.Rows.Add(tRow); // Ajout de la ligne dans la table

        }

    }

    protected void rb_CheckedChanged(object sender, EventArgs e)
    {
        Session["ref_sel"] = "";
    }

    //Remplit la variable de session ref_sel avec les références des biens sélectionnés (checkbox cochée)
    protected void cb_CheckedChanged(object sender, EventArgs e)
    {
        //On ajoute la valeur dela référence du bien dans la variable de session ref_sel
        int i;
        Session["ref_sel"] = "";
        for (i = 2; i < TablePlanif.Rows.Count; i++)
        {
            if (Session["ref_sel"] == "")
            {
                if (((CheckBox)TablePlanif.Rows[i].Cells[8].Controls[0]).Checked)
                {
                    Session["ref_sel"] = ((CheckBox)TablePlanif.Rows[i].Cells[8].Controls[0]).ID;
                }
            }
            else
            {
                if (((CheckBox)TablePlanif.Rows[i].Cells[8].Controls[0]).Checked)
                {
                    Session["ref_sel"] = Session["ref_sel"] + ";" + ((CheckBox)TablePlanif.Rows[i].Cells[8].Controls[0]).ID;
                }
            }
        }
    }


    protected void ItemChange(object sender, EventArgs e)
    {
        Session["acq_sel"] = (((DropDownList)sender).SelectedValue).ToString();
    }



    protected void ButtonImpressionBon_Click1(object sender, EventArgs e)
    {
        //On va directement sur le bon de visite sans enregistrer
        cb_CheckedChanged(null, null);
        Response.Redirect("./bon_de_visite.aspx");

    }


    protected void ButtonImpressionBon_Click2(object sender, EventArgs e)
    {
        //Bon de visite + enregistrement de la visite
        string requete = "";
		Membre member = null;
        if (Session["logged"].Equals(true))
        {
            // permet le "Bonjour Mr X"
            member = (Membre)Session["Membre"];
            LabelPrenom.Text = member.CIVILITE;
            LabelNom.Text = member.NOM;
        }
        else
        {
            Response.Redirect("./recherche.aspx");
        }

        cb_CheckedChanged(null, null);

        int i = 0;
        Session["ref_sel"] = "";
	  //Parcours des checkboxs de la page      
	  for (i = 2; i < TablePlanif.Rows.Count; i++)
        {
            if (Session["ref_sel"] == "")
            {
                if (((CheckBox)TablePlanif.Rows[i].Cells[8].Controls[0]).Checked)
                {
                    Session["ref_sel"] = ((CheckBox)TablePlanif.Rows[i].Cells[8].Controls[0]).ID;
                }
            }
            else
            {
                if (((CheckBox)TablePlanif.Rows[i].Cells[8].Controls[0]).Checked)
                {
                    Session["ref_sel"] = Session["ref_sel"] + ";" + ((CheckBox)TablePlanif.Rows[i].Cells[8].Controls[0]).ID;
                }
            }
        }



        if (Session["ref_sel"] != null)
        {
            //On recupere la liste des biens dans la variable de session
            string Ref = (string)Session["ref_sel"];
            string[] WordArray;
            string[] stringSeparators = new string[] { ";" };
            WordArray = Ref.Split(stringSeparators, StringSplitOptions.None);
            i = 0;

            if (Session["ref_sel"] == "" || DropDownListAcquereurs.SelectedValue == "0")
            {
                LabelMessage.Text = "La visite ne peut être enregistrée tant que ne sont pas sélectionnés, au moins, un acquéreur et un bien.";
            }
            else
            {
                //On ajoute dans la base
                if (WordArray.Length >= 1)
                {
                    while (i < WordArray.Length)
                    {
                        requete = " INSERT INTO visite("
                        + "`id_bien`,"
                        + "`acquereur`,"
                        + "`idclient`,"
                        + "`actif`,"
                        + "`date_visite`)"
                        + "values('" + WordArray[i] + "','"
                        + DropDownListAcquereurs.SelectedValue + "','"
                        + member.IDCLIENT + "','"
                        + "actif" + "','"
                        + DateTime.Now.ToString() + "'"
                        + ")";


                        System.Data.DataSet ds = null;
                        Connexion c = null;

                        c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                        c.Open();
                        ds = c.exeRequette(requete);
                        c.Close();
                        c = null;
                        i++;
                    }
                }

                LabelMessage.Text = "La visite a bien été enregistrée.";
            }
        }
    }


    protected void ButtonImpressionBon_Click3(object sender, EventArgs e)
    {
        // Permet de recommencer la sélection
        // On efface la variable de session contenant les biens sélectionnés
        Session["ref_sel"] = "";
        Response.Redirect("./ajout_visite.aspx");
    }

    protected void ImageButton_Click(object sender, EventArgs e)
    {
        Session["type"] = ((ImageButton)sender).ID;
        if (RadioButtonMesBiens.Checked)
        {
            fill_table("Mes biens");

        }
        else if (RadioButtonTousLesBiens.Checked)
        {
            fill_table("Tous les biens");
        }
        else if (RadioButtonMonAgence.Checked)
        {
            fill_table("Mon agence");
        }
    }

    protected void globale_cb_changed(object sender, EventArgs e)
    {
        int i = 0;
		  //Parcours des checkboxs de la page
          if( ((CheckBox)sender).Checked == true)
          {
                for (i = 2; i < TablePlanif.Rows.Count; i++)
              {
                   ((CheckBox)TablePlanif.Rows[i].Cells[8].Controls[0]).Checked = true;     
              }
              
                
          }
          else if(((CheckBox)sender).Checked == false)
          {
            for (i = 2; i < TablePlanif.Rows.Count; i++)
            {
                ((CheckBox)TablePlanif.Rows[i].Cells[8].Controls[0]).Checked = false;     
            }
        
         }
    }
}