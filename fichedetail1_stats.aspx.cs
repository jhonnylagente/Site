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

public partial class fichedetail1_stats : System.Web.UI.Page
{
	protected Bien b;
	protected DataRowCollection statsFiche;
	protected DataRowCollection statsResult;
	protected ArrayList listeMois;
	protected ArrayList listeVisiteFiche;
	protected ArrayList listeVisite;

    protected void Page_Load(object sender, EventArgs e)
    {
		((Label)Page.Master.FindControl("titrebandeau")).Text = "Statistiques<br/>Pages visitées";
		
		string reference = Request.Params["ref"];
		Membre member = (Membre)Session["Membre"];
		b = BienDAO.getBien(reference);
		
		if(member != null && Request.QueryString["ref"] != null && (member.STATUT == "ultranego" || (member.STATUT == "nego" && b.NEGOCIATEUR == member.PRENOM + " " + member.NOM)))
		{
			string requete1 = "SELECT Year(Time) AS year, Month(Time) AS month, Count(*) AS nbvisite "
							+ "FROM (SELECT ref,Time FROM log_visite_page_bien WHERE ref='"+reference+"' AND ficheDetaillee = true) "
							+ "GROUP BY Year(Time), Month(Time) ORDER BY Year(Time),Month(Time);";
			
			string requete2 = "SELECT Year(Time) AS year, Month(Time) AS month, Count(*) AS nbvisite "
							+ "FROM (SELECT ref,Time FROM log_visite_page_bien WHERE ref='"+reference+"' AND ficheDetaillee = false) "
							+ "GROUP BY Year(Time), Month(Time) ORDER BY Year(Time),Month(Time);";
								
			Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
			c.Open();
			statsFiche = c.exeRequette(requete1).Tables[0].Rows;
			statsResult = c.exeRequette(requete2).Tables[0].Rows;
			c.Close();
			
			
			listeMois = new ArrayList();
			listeVisiteFiche = new ArrayList();
			listeVisite = new ArrayList();
			DateTime today = DateTime.Now;
			
			int y = 0;
			int j = 0;
			for(int i =0 ; i<12 ; i++)
			{
				string month = ((today.Month + i)%12 + 1).ToString();
				string year = (today.Month + i > 12)? today.Year.ToString() : (today.Year -1).ToString();
				listeMois.Add(((today.Month + i)%12 + 1).ToString() + "/" + year);
				
				bool found1 = false;
				for(int k = j; k< statsResult.Count; k++)
				{
					if(month == statsResult[k]["month"].ToString() && year == statsResult[k]["year"].ToString())
					{
						listeVisiteFiche.Add(statsResult[k]["nbvisite"].ToString());
						j = k+1;
						found1 = true;
						break;
					}
				}
				if(!found1)
				{
					listeVisiteFiche.Add("0");
				}
				
				bool found2 = false;
				for(int x = y; x< statsFiche.Count; x++)
				{
					if(month == statsFiche[x]["month"].ToString() && year == statsFiche[x]["year"].ToString())
					{
						listeVisite.Add(statsFiche[x]["nbvisite"].ToString());
						y = x+1;
						found2 = true;
						break;
					}
				}
				if(!found2)
				{
					listeVisite.Add("0");
				}
			}
			

		}
		else
		{
			Response.Redirect("recherche.aspx");
			Response.End();
		}
    }
}
