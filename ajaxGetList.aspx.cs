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

public partial class ajaxquery : System.Web.UI.Page
{

	private string genererLigne(string onClick, string nomLieu, string cssClass)
	{
		if(cssClass == "")
			return nomLieu + "\n";
		else
			return "<tr><td class='"+cssClass+"' onclick=\" "+ onClick +" \">"+nomLieu+"</td></tr>";
	}

	
    protected void Page_Load(object sender, EventArgs e)
    {
       /*
        * recupere la liste des pays/villes/cp correspondant a la saisie de la recherche,
        * et retourne cette liste sous forme de liste deroulante
        * Utilise les parametres ?type=xxx&recherche=xxx dans l'url
        */

        string indentation = "";
        string onglet = Request.QueryString["onglet"];	//Sert a choisir un margin suivant la page
		string type = Request.QueryString["type"];		//in {ville,pays,cp}
		string recherche = Request.QueryString["recherche"];	//Valeur saisie par l'utilisateur
		string style = Request.QueryString["style"];		//Style css, valeur par defaut oui | si style = no, renvoie les donnes sans mise en page separe par un \n
		string cssClass = "";
		
		switch(style)
		{
			case "no" : cssClass = ""; break;
			case "mini" : cssClass = "ajouterAcquereur_ClickableCellMini"; break;
			default : cssClass = "ajouterAcquereur_ClickableCell"; break;
		}
		
		
		
        if (onglet == "0") indentation = "-220";    //onglet mandat
        else if (onglet == "1") //onglet vendeur
		{
			if(type == "cp") indentation = "-130";
			else if(type == "ville") indentation = "-380";
			else indentation = "-216"; 
		}  
        else if (onglet == "2") indentation = "-216";   //onglet juridique
        else if (onglet == "3") indentation = "-216";   //onglet proprietaire
		else indentation = "0";

		string table = "<div class='AjoutacquereurScrollCell100' style='z-index:2;background-color:#EFEFEF;position:absolute;margin-left:"+indentation+"px;margin-top:10px;padding-right:18px;'><table border='0'><tbody>";		
		string tableend = "</tbody></table></div>";
		string result = "";
		string query = "";
            
			
		if(type != "" && recherche != "")
		{
			recherche = recherche.Replace("'","''");
			int temp = 0;
		
			if(type=="all" || type == "pays")  //Recherche pour un pays
			{
				query = "select Titre_Pays from Pays WHERE Titre_Pays LIKE '%" + recherche + "%' ORDER BY Titre_Pays";
					
				Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
				c.Open();
				System.Data.DataSet ds = c.exeRequette(query);
				c.Close();
				c = null;

				System.Data.DataRowCollection dr = ds.Tables[0].Rows;
			
								
				foreach (System.Data.DataRow ligne in dr)
				{
					string onclick = "saisiePays(this,"+onglet+")";
					string nomLieu = ligne[0].ToString().ToUpper();
					result += genererLigne(onclick, nomLieu, "bold " + cssClass);
				}
			}
			
			if(type=="all" || type == "dep")  //Recherche pour un dep
			{
				if(int.TryParse(recherche,out temp))
				{
					string zero = (recherche.Length == 1)?"0":"";
					query = "select departement_code,departement_nom from departement WHERE departement_code = '" + zero + recherche + "' ORDER BY departement_nom";
					
				}
				else
					query = "select departement_code,departement_nom from departement WHERE departement_slug LIKE '%" + recherche + "%' OR departement_nom LIKE '%" + recherche + "%' ORDER BY departement_nom";
				
				Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
				c.Open();
				System.Data.DataSet ds = c.exeRequette(query);
				c.Close();
				c = null;

				System.Data.DataRowCollection dr = ds.Tables[0].Rows;
					
				
				
				foreach (System.Data.DataRow ligne in dr)
				{
					string onclick = "saisieDep('" + ligne[1].ToString().Replace("'","\\\'") + "',"+ ligne[0] +","+onglet+")";
					string nomLieu = ligne[1].ToString().ToUpper()+ " (" + ligne[0] +  ")";
					result += genererLigne(onclick, nomLieu, "bold " +cssClass);
				}
			}
			
            if (type=="all" || type == "ville")    //Recherche pour une ville
			{	
                //requete sql
				string query1 = "select Nom,[Code Postal],refpays from Ville WHERE Nom LIKE '%" + recherche + "%'";
				string query2 = "select Nom,[Code Postal],refpays from Arrondissement WHERE Nom LIKE '%" + recherche + "%'";
					
                //execution des 2 requete
				Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
				c.Open();
				System.Data.DataTable dt1 = c.exeRequette(query1).Tables[0];
				System.Data.DataTable dt2 = c.exeRequette(query2).Tables[0];
				c.Close();
				c = null;

                dt1.Merge(dt2);     //Fusion des 2 resultats
                DataView view = new DataView(dt1);
                view.Sort = "Nom ASC";  //Tri des resultat | Order by n'est pas utilise dans le sql vu qu'il faut fusionner apres

                foreach (System.Data.DataRowView ligne in view)
                {
                    if (ligne[1].ToString().Length > 5 && type != "all") //On ignore les villes regroupant plusieurs arrondissements (ayant un champ code postal contenant plus d'un cp)
                        continue;                       //Pour afficher les arrondissements de maniere independantes

					string onclick = "saisieVille('" + ligne[0].ToString().Replace("'","\\\'") + "','" + ligne[1] + "'," + onglet+ ")";
                    string pays =""+ ligne[2].ToString();
					string nomLieu = pays+ ligne[0].ToString();
					if(ligne[1].ToString().Length > 5)
						nomLieu += " (Tous les arrondissements)";
					else
						nomLieu += " (" + ligne[1] + ")";
					result += genererLigne(onclick, nomLieu, cssClass);
                }
			}
			
			
			
            if (type=="all" && int.TryParse(recherche,out temp) || type == "cp")  //Recherche pour un code postal
            {
                string query1 = "select Nom,[Code Postal] from Ville WHERE [Code Postal] LIKE '" + recherche + "%'";
                string query2 = "select Nom,[Code Postal] from Arrondissement WHERE [Code Postal] LIKE '" + recherche + "%'";

                Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                c.Open();
                System.Data.DataTable dt1 = c.exeRequette(query1).Tables[0];
                System.Data.DataTable dt2 = c.exeRequette(query2).Tables[0];
                c.Close();
                c = null;

                dt1.Merge(dt2);
                DataView view = new DataView(dt1);
                view.Sort = "Nom ASC";
								
                foreach (System.Data.DataRowView ligne in view)
                {
                    if (ligne[1].ToString().Length > 5)
                        continue;

					string onclick = "saisieVille('" + ligne[0].ToString().Replace("'","\\\'") + "','" + ligne[1] + "'," + onglet+ ")";
					string nomLieu = ligne[0] + " (" + ligne[1] + ")";
					result += genererLigne(onclick, nomLieu, cssClass);	
                }
            }
			
            if (result != "")
                Response.Write(table + result + tableend);
		}
    }
}
