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

public partial class modeledoc : System.Web.UI.Page
{
	protected string[] fileList;
	protected string dir = "reseau_documents";

    protected void Page_Load(object sender, EventArgs e)
    {
	    Membre member = (Membre)Session["Membre"];
        if (member == null || (member.STATUT != "ultranego" && member.STATUT!="nego"))
        {
            Response.Redirect("./recherche.aspx");
        }
		
		if (Request.QueryString["type"] == "doc")
			dir = "reseau_documents";
		if (Request.QueryString["type"] == "lettres")
			dir = "reseau_lettres";
		
		((Label)Page.Master.FindControl("titrebandeau")).Text = "Modèles de documents";
	
		fileList = System.IO.Directory.GetFiles(MapPath("../"+dir));
		for(int i = 0 ; i < fileList.Length ; i++)
		{
			string[] temp = fileList[i].Split('\\');
			fileList[i] = temp[temp.Length - 1];
		}
		
    }
}
