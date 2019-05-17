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

public partial class pages_suppressionAlerte : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		((Label)Page.Master.FindControl("titrebandeau")).Text = "Mes alertes";
		
            String reference = Request.Params["ref"];

            String decode1 = (String)Session["double1"];
            String decode2 = (String)Session["double2"];


            reference = reference.Replace(decode1, "");
            reference = reference.Replace(decode2, "");

            Session["referenceAlerteMail"] = reference;
        
    }
    protected void ButtonSupprimer_Click(object sender, EventArgs e)
    {
            Int32 reference = Int32.Parse(Session["referenceAlerteMail"].ToString());

            Membre member = (Membre)Session["membre"];

            AlerteMailDAO.removeAlerteMail(reference);
            Response.Redirect("./monCompteAlertes.aspx");
        
    }
    protected void ButtonRetour_Click(object sender, EventArgs e)
    {
        Response.Redirect("./monCompteAlertes.aspx");    
    }
}
