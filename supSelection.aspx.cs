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

public partial class supSelection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Page.Master.FindControl("titrebandeau")).Text = "Mes alertes";
    }
    protected void ButtonSupprimer_Click(object sender, EventArgs e)
    {
        String reference = Request.Params["ref"].ToString();
        Membre member = (Membre)Session["membre"];
        String mail = member.ID_CLIENT;

        BienDAO.removeBienSelection(reference, mail);
        Response.Redirect("./monCompteAnnonces.aspx");
    }
    protected void ButtonRetour_Click(object sender, EventArgs e)
    {
        Response.Redirect("./monCompteAnnonces.aspx");
    }
}
