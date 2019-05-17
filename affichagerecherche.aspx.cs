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

public partial class affichagerecherche : System.Web.UI.Page
{
	
    public void Page_Load(object sender, EventArgs e)
    {

		if(Request.QueryString["ref"] != null)
			negoName.Text = "gérées par " + Request.QueryString["ref"];
		if(Request.QueryString["field1"] != null)
		{
			Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
		
			c.Open();
			DataSet ds = c.exeRequette("SELECT nom_client, prenom_client FROM Clients WHERE idclient = " + Request.QueryString["field1"] + ";");
			DataRowCollection dr2 = ds.Tables[0].Rows;
			c.Close(); c = null;
		
			foreach (DataRow ligne in dr2)
			{
				negoName.Text = "gérées par " + ligne["prenom_client"] + " " + ligne["nom_client"];
			}
		}
		
		#region chargement critere derniere recherche
        //Parametres provenant d'une alerte mail
        if (Request.QueryString["incoming"] == "Alerte")
        {
            if (Request.QueryString["Transaction"] == "achat" || Request.QueryString["Transaction"] == "achat2" || Request.QueryString["Transaction"] == "") radioButtonAchat.Checked = true;
            else radioButtonLocation.Checked = true;

            Boolean tempBool=true;
            Boolean.TryParse(Request.QueryString["checkBoxMaison"],out tempBool);
            checkBoxMaison.Checked = tempBool;
            Boolean.TryParse(Request.QueryString["checkBoxAppart"], out tempBool);
            checkBoxAppart.Checked = tempBool;
            Boolean.TryParse(Request.QueryString["checkBoxTerrain"], out tempBool);
            checkBoxTerrain.Checked = tempBool;
            Boolean.TryParse(Request.QueryString["checkBoxAutre"], out tempBool);
            checkBoxAutre.Checked = tempBool;
            TextBoxBudgetMin.Text = Request.QueryString["TextBoxBudgetMin"];
            TextBoxBudgetMax.Text = Request.QueryString["TextBoxBudgetMax"];

            textBoxSurfaceMin.Text = Request.QueryString["Smin"];
            textBoxSurfaceMax.Text = Request.QueryString["Smax"];

            Boolean.TryParse(Request.QueryString["checkBoxPiece1"], out tempBool);
            checkBoxPiece1.Checked = tempBool;
            Boolean.TryParse(Request.QueryString["checkBoxPiece2"], out tempBool);
            checkBoxPiece2.Checked = tempBool;
            Boolean.TryParse(Request.QueryString["checkBoxPiece3"], out tempBool);
            checkBoxPiece3.Checked = tempBool;
            Boolean.TryParse(Request.QueryString["checkBoxPiece4"], out tempBool);
            checkBoxPiece4.Checked = tempBool;
            Boolean.TryParse(Request.QueryString["checkBoxPiece5"], out tempBool);
            checkBoxPiece5.Checked = tempBool;

            /*MOTS CLEFS ?*/

            Boolean.TryParse(Request.QueryString["checkBoxMer"], out tempBool);
            chckBxMer.Checked = tempBool;
            Boolean.TryParse(Request.QueryString["checkBoxMontagne"], out tempBool);
            chckBxMontagne.Checked = tempBool;
            Boolean.TryParse(Request.QueryString["chckBxCdC"], out tempBool);
            chckBxCdC.Checked = tempBool;
            Boolean.TryParse(Request.QueryString["chckBxPrestige"], out tempBool);
            chckBxPrestige.Checked = tempBool;
            Boolean.TryParse(Request.QueryString["ListeNeuf"], out tempBool);
            if (tempBool) ListeNeuf.SelectedIndex= 1;
            else ListeNeuf.SelectedIndex=0;


        }
            //Parametres provenant de la page de recherche
        else if (!IsPostBack)
        {
			if (Session["Transaction"] == "achat" || Session["Transaction"] == "achat2" || Session["Transaction"] == "")
			{
				radioButtonAchat.Checked = true;
			}
			else
			{
				radioButtonLocation.Checked = true;
			}
			
			if(Request.QueryString["field1"] == null && Request.QueryString["ref"] == null)
            {

				checkBoxMaison.Checked = (bool)Session["checkBoxMaison"];
				checkBoxAppart.Checked = (bool)Session["checkBoxAppart"];
				checkBoxTerrain.Checked = (bool)Session["checkBoxTerrain"];
				checkBoxAutre.Checked = (bool)Session["checkBoxAutre"];

				TextBoxBudgetMin.Text = (String)Session["TextBoxBudgetMin"];
				TextBoxBudgetMax.Text = (String)Session["TextBoxBudgetMax"];

				textBoxSurfaceMin.Text = (String)Session["Smin"];
				textBoxSurfaceMax.Text = (String)Session["Smax"];

				checkBoxPiece1.Checked = (bool)Session["checkBoxPiece1"];
				checkBoxPiece2.Checked = (bool)Session["checkBoxPiece2"];
				checkBoxPiece3.Checked = (bool)Session["checkBoxPiece3"];
				checkBoxPiece4.Checked = (bool)Session["checkBoxPiece4"];
				checkBoxPiece5.Checked = (bool)Session["checkBoxPiece5"];

                tb_motcle1.Text = (String)Session["textBoxMotCle1"];
                tb_motcle2.Text = (String)Session["textBoxMotCle2"];
                tb_motcle3.Text = (String)Session["textBoxMotCle3"];
                tb_motcle4.Text = (String)Session["textBoxMotCle4"];

				textBoxVille.Text = (String)Session["VilleRechercheRech"];
				textBoxPays.Text = (String)Session["PaysRechercheRech"];
				textBoxDep.Text = (String)Session["DepRechercheRech"];

				try
				{
					chckBxCdC.Checked = (bool)Session["chckBxCdC"];
					chckBxPrestige.Checked = (bool)Session["chckBxPrestige"];
                    chckBxMer.Checked = (bool)Session["chckBxMer"];
                    chckBxMontagne.Checked = (bool)Session["chckBxMontagne"];
					ListeNeuf.SelectedIndex =(int) Session["ListeNeuf"];
				}
				catch
				{
					chckBxCdC.Checked = false;
					chckBxPrestige.Checked = false;
                    chckBxMer.Checked = false;
                    chckBxMontagne.Checked = false;
					ListeNeuf.SelectedIndex = 2;
				}
			}
        }
		#endregion
	
		Membre member = (Membre)Session["Membre"];

        Label2.Visible = false;

        Session["NumPage"] = Request.Params["Numpage"];
        if(Request.Params["Ordre"] != null) Session["Ordre"] = (string)Request.Params["Ordre"].ToUpper();
		
        String tri = "";
        if (Session["Tri"] != null)
        {
            tri = Session["Tri"].ToString();
        }
        else
        {
            tri = "date";
        }
        String ordre = "";
        if (Session["Ordre"] != null)
        {
            ordre = Session["Ordre"].ToString();
        }
        else
        {
            ordre = "DESC";
			Session["Ordre"] = ordre;
        }
	
		// == if(false) lol ...
        if (ordre.CompareTo("ASC") == 0 && ordre.CompareTo("DESC") == 0) ordre = "DESC";

        if (tri != "prix" && tri != "pieces" && tri != "surface" && tri != "codepostal" && tri != "ville" && tri != "consommation" && tri != "emissions" && tri != "date" && tri != "type")
        {
            Session["Tri"] = "date";
        }

    }

	
	//Bouton alerte mail
    protected void ButtonMail_Click(object sender, EventArgs e)
    {
        Regex verifMail = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$", RegexOptions.IgnoreCase);
        if (TextBoxMail.Text != "")
        {
            if (verifMail.IsMatch(TextBoxMail.Text.Trim()) == true)
            {
                RequeteBien alerte = (RequeteBien)Session["requete"];
                alerte.ID_CLIENT = TextBoxMail.Text;

                if (alerte.ID_ALERTE.Equals(0)) AlerteMailDAO.addAlerteMail(alerte);
                else AlerteMailDAO.updateAlerteMail(alerte);
                Label1.Visible = true;
                Label1.Text = "Votre alerte mail pour " + alerte.ID_CLIENT + " vient d'être créé.";
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "erreur de saisie, adresse e-mail invalide";
            }
        }
    }
    protected void ButtonMail2_Click(object sender, EventArgs e)
    {
        Regex verifMail = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$", RegexOptions.IgnoreCase);

        if (TextBoxMail2.Text != "")
        {
            if (verifMail.IsMatch(TextBoxMail2.Text.Trim()) == true)
            {
                Label2.Visible = false;
                RequeteBien alerte = (RequeteBien)Session["requete"];
                alerte.ID_CLIENT = TextBoxMail2.Text;

                if (alerte.ID_ALERTE.Equals(0)) AlerteMailDAO.addAlerteMail(alerte);
                else AlerteMailDAO.updateAlerteMail(alerte);
                Label2.Visible = true;
                Label2.Text = "Votre alerte mail pour "+alerte.ID_CLIENT+ " vient d'être créé.";
                
            }
            else
            {
                Label2.Visible = true;
                Label2.Text = "erreur de saisie, adresse e-mail invalide";
            } 
        }

    }

    protected void BacktoCrits(object sender, EventArgs e)
    {
        Response.Redirect("./recherche.aspx");

    }
}
