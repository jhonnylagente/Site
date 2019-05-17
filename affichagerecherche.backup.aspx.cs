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
		#region chargement critere derniere recherche
		if (!IsPostBack)
        {
            if (Session["Transaction"] == "achat" || Session["Transaction"] == "")
            {
                radioButtonAchat.Checked = true;
            }
            else
            {
                radioButtonLocation.Checked = true;
            }

            checkBoxMaison.Checked = (bool)Session["checkBoxMaison"];
            checkBoxAppart.Checked = (bool)Session["checkBoxAppart"];
            checkBoxTerrain.Checked = (bool)Session["checkBoxTerrain"];
            checkBoxAutre.Checked = (bool)Session["checkBoxAutre"];

            TextBoxBudgetMin.Text = (String)Session["TextBoxBudgetMin"];
            TextBoxBudgetMax.Text = (String)Session["TextBoxBudgetMax"];

            textBoxSurfaceMin.Text = (String)Session["textBoxSurfaceMin"];
            textBoxSurfaceMax.Text = (String)Session["textBoxSurfaceMax"];

            checkBoxPiece1.Checked = (bool)Session["checkBoxPiece1"];
            checkBoxPiece2.Checked = (bool)Session["checkBoxPiece2"];
            checkBoxPiece3.Checked = (bool)Session["checkBoxPiece3"];
            checkBoxPiece4.Checked = (bool)Session["checkBoxPiece4"];
            checkBoxPiece5.Checked = (bool)Session["checkBoxPiece5"];
			
			textBoxVille.Text = (String)Session["VilleRechercheRech"];
            textBoxPays.Text = (String)Session["PaysRechercheRech"];
            textBoxDep.Text = (String)Session["DepRechercheRech"];

            try
            {
                chckBxCdC.Checked = (bool)Session["chckBxCdC"];
                chckBxPrestige.Checked = (bool)Session["chckBxPrestige"];
                ListeNeuf.SelectedIndex =(int) Session["ListeNeuf"];
            }
            catch
            {
                chckBxCdC.Checked = false;
                chckBxPrestige.Checked = false;
                ListeNeuf.SelectedIndex = 2;
            }

        }
		#endregion
	
		Membre member = (Membre)Session["Membre"];
		((Label)Page.Master.FindControl("titrebandeau")).Text = "Recherche";

        Label2.Visible = false;

        Session["NumPage"] = Request.Params["Numpage"];
        Session["Tri"] = Request.Params["Tri"];
        Session["Ordre"] = Request.Params["Ordre"];
        
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
        }

        if (ordre.CompareTo("ASC") == 0 && ordre.CompareTo("DESC") == 0) ordre = "DESC";

        if (tri != "prix" || tri != "pieces" || tri != "surface" || tri != "codepostal" || tri != "ville" || tri != "date" || tri != ("type"))
        {
            Session["Tri"] = "date";
        }
        Session["Ordre"] = ordre;
        Session["Tri"] = tri;
    }

	private bool checkField()
	{
		return true;
	}
	
	protected void rechercher(object sender, EventArgs e)
	{
		if(checkField())
		{
			
			RequeteBien recherche = new RequeteBien();
			
			#region critere recherche
			
			recherche.ListePays2 = textBoxPays.Text;
			recherche.ListeVille2 = textBoxVille.Text;
			recherche.ListeDep2 = textBoxDep.Text;
			
			
			if (textBoxSurfaceMin.Text != "") recherche.SURFACEMIN = Int64.Parse(textBoxSurfaceMin.Text.Trim());
            if (textBoxSurfaceMax.Text != "") recherche.SURFACEMAX = Int64.Parse(textBoxSurfaceMax.Text.Trim());
			recherche.PIECE1 = checkBoxPiece1.Checked;
            recherche.PIECE2 = checkBoxPiece2.Checked;
            recherche.PIECE3 = checkBoxPiece3.Checked;
            recherche.PIECE4 = checkBoxPiece4.Checked;
            recherche.PIECE5 = checkBoxPiece5.Checked;

            recherche.COUP_DE_COEUR = chckBxCdC.Checked;
            recherche.PRESTIGE = chckBxPrestige.Checked;
			if (ListeNeuf.SelectedValue == "0")
            {
                recherche.NeufOuPas = false;
                recherche.NEUF = false;
            }
            else if (ListeNeuf.SelectedValue == "1")
            {
                recherche.NeufOuPas = false;
                recherche.NEUF = true;
            }
            else
            {
                recherche.NeufOuPas = true;
            }
			
			if (checkBoxAppart.Checked == false && checkBoxTerrain.Checked == false && checkBoxMaison.Checked == false && checkBoxAutre.Checked == false)
            {
                recherche.TYPEBIEN = "AMTX";
            }
            else
            {
                if (checkBoxAppart.Checked) recherche.TYPEBIEN += "A";
                if (checkBoxMaison.Checked) recherche.TYPEBIEN += "M";
                if (checkBoxTerrain.Checked) recherche.TYPEBIEN += "T";
                if (checkBoxAutre.Checked) recherche.TYPEBIEN += "X";
            }

            if (radioButtonAchat.Checked)
            {
                recherche.TYPEVENTE = "V";
				if (TextBoxBudgetMin.Text != "") recherche.PRIXMIN = Int64.Parse(TextBoxBudgetMin.Text.Trim());
				if (TextBoxBudgetMax.Text != "") recherche.PRIXMAX = Int64.Parse(TextBoxBudgetMax.Text.Trim());
            }
            else
            {
                recherche.TYPEVENTE = "L";
				if (TextBoxBudgetMin.Text != "") recherche.LOYERMIN = Int64.Parse(TextBoxBudgetMin.Text.Trim());
				if (TextBoxBudgetMax.Text != "") recherche.LOYERMAX = Int64.Parse(TextBoxBudgetMax.Text.Trim());
            }
			
			#endregion
			
			#region passage en session
			Session["VilleRechercheRech"] = textBoxVille.Text;
			Session["PaysRechercheRech"] = textBoxPays.Text;
			Session["DepRechercheRech"] = textBoxDep.Text;
			
			Session["requete"] = recherche;

            if (radioButtonAchat.Checked == true) Session["Transaction"] = "achat";
            else Session["Transaction"] = "location";
			
			Session["Smin"] = textBoxSurfaceMin.Text;
            Session["Smax"] = textBoxSurfaceMax.Text;

            Session["radioButtonAchat"] = radioButtonAchat.Checked;
            Session["checkBoxPiece1"] = checkBoxPiece1.Checked;
            Session["checkBoxPiece2"] = checkBoxPiece2.Checked;
            Session["checkBoxPiece3"] = checkBoxPiece3.Checked;
            Session["checkBoxPiece4"] = checkBoxPiece4.Checked;
            Session["checkBoxPiece5"] = checkBoxPiece5.Checked;

            Session["checkBoxMaison"] = checkBoxMaison.Checked;
            Session["checkBoxAppart"] = checkBoxAppart.Checked;
            Session["checkBoxTerrain"] = checkBoxTerrain.Checked;
            Session["checkBoxAutre"] = checkBoxAutre.Checked;


            Session["TextBoxBudgetMax"] = TextBoxBudgetMax.Text;
            Session["TextBoxBudgetMin"] = TextBoxBudgetMin.Text;

            Session["chckBxCdC"] = chckBxCdC.Checked;
            Session["chckBxPrestige"] = chckBxPrestige.Checked;
            Session["ListeNeuf"] = ListeNeuf.SelectedIndex;
			
			Session["NumPage"] = 1;
			Session["Tri"] = "prix";
			#endregion
			
		}
	}
	
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
                Label1.Text = "Votre alerte mail vient d'être créé.";
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "erreur de saisie, adresse e-mail invalide";
            }
        }
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
                Label2.Text = "Votre alerte mail vient d'être créé.";
            }
            else
            {
                Label2.Visible = true;
                Label2.Text = "erreur de saisie, adresse e-mail invalide";
            }
        }

    }
	
	protected string espaceNombre(string nombre)
	{
		string prixFormat = "";
		int k = 0;
		if(nombre.Length >3)
		{
			while((k+1)*3 < nombre.Length)
			{
				prixFormat = nombre.Substring((nombre.Length -(k+1)*3), 3) + " " +prixFormat;
				k++;
			}
			prixFormat = nombre.Substring(0, nombre.Length - k*3) + " " +prixFormat;
		}
		else prixFormat = nombre;
		
		return prixFormat;
	}
   
}
