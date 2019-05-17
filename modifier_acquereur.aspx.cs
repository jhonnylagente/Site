using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

public partial class pages_ajout_acquereur : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        String idAcq;
        idAcq = Request.QueryString["reference"];
        Session["ajout_acquereur"] = "false";
        Session["ajout_acquereur_id"] = idAcq;
		string param = "";
		foreach (String key in Request.QueryString.AllKeys)
		{
			param += key + "=" + Request.QueryString[key] + "&";
		}
		Response.Redirect("./ajout_acquereur.aspx?" + param);

    }
}