using System;
using System.Data;
using System.Data.Odbc;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Text;

public partial class pages_parrains : System.Web.UI.Page
{
    string _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    protected Membre member = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Page.Master.FindControl("titrebandeau")).Text = "Mon espace";
        if (Session["Membre"] != null) member = (Membre)Session["Membre"];

        if (!IsPostBack)
        {

        }
      
    }
    protected void Button1_Click_Tab(object sender, EventArgs e)
    {
         Session["Transaction"] = "location";
        RequeteBien recherche = (RequeteBien)Session["requete"];
        recherche.TYPEVENTE = "L";
        Response.Redirect("./afficherCompte.aspx?field1=" + txt.Text);
    }

    protected void clickLoc(object sender, EventArgs e)
    {
        Session["Transaction"] = "location";
        RequeteBien recherche = (RequeteBien)Session["requete"];
        Response.Redirect("./afficherCompte.aspx?field1=" + txt.Text);

    }
    protected void clickAch(object sender, EventArgs e)
    {
        Session["Transaction"] = "location";
        RequeteBien recherche = (RequeteBien)Session["requete"];
        Response.Redirect("./afficherprofil.aspx?field1=" + txt.Text);
    }

    public void DropDownListNbClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["nbClientParPage"] = DropDownListNbClient.SelectedValue;
        Response.Redirect("./parrains.aspx?page=1");
    }
}