using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class statsrecherche : System.Web.UI.Page
{
	protected Dictionary<string, int> basicData;
	protected long searchNb;
	protected DataRowCollection drcListeDep;
	protected DataRowCollection drcListeVille;
	protected DataRowCollection drcListePays;
	
    protected void Page_Load(object sender, EventArgs e)
    {
		Membre member = (Membre)Session["Membre"];
		if(member == null || member.STATUT != "ultranego")
		{
			Response.Redirect("recherche.aspx");
			Response.End();
		}
	}
}
