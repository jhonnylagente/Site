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

public partial class pages_ajout_acquereur : System.Web.UI.Page
{
    string _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    protected Membre member = null;
    String hote = "";
    OdbcConnection c3;

    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Page.Master.FindControl("titrebandeau")).Text = "Mon espace";
        if ((Membre)Session["Membre"] != null)
        {
            member = (Membre)Session["Membre"];
            if (member.STATUT == "ultranego") DDLContractuel.Visible = true;
        }

        if (!IsPostBack)
        {
            DropDownListNbClient.SelectedValue = Session["nbClientParPage"].ToString();
            DDLContractuel.SelectedValue = Session["DDLContractuel"].ToString();
        }
        c3 = new OdbcConnection(_ConnectionString);
        OdbcDataReader reader;
        c3.Open();
        OdbcCommand commande = new OdbcCommand("Select * from Environnement", c3);
        reader = commande.ExecuteReader();
        reader.Read();
        hote = reader["IP"].ToString();
        reader.Close();
        c3.Close();
    }

    protected void Button1_Click_Tab(object sender, EventArgs e)
    {
    }

    protected void clickModi(object sender, EventArgs e)
    {

        Response.Redirect("./afficherCompte.aspx?field1=" + txt.Text);

    }

    protected String generateLocalisationString(String Pays)
    {
        String loc = "";
        OdbcDataReader reader;
        c3.Open();

        OdbcCommand commande = new OdbcCommand("SELECT codeiso FROM Pays WHERE Titre_Pays= ? ", c3);
        OdbcParameter paramRef = new OdbcParameter("@ref", DbType.String);
        paramRef.Value = Pays;
        commande.Parameters.Add(paramRef);
        reader = commande.ExecuteReader();
        if (reader.Read())
        {
            loc += "<img style='margin-top:-3px;margin-bottom:-3px' src='http://" + hote + "/img_site/drapeau/" + reader["codeiso"] + ".png' alt='" + Pays + "'/>";
            reader.Close();
        }
        c3.Close();

        return loc;
    }

    protected void clickLoc(object sender, EventArgs e)
    {
        boton = "LOC";
        Session["Transaction"] = "location2";
        Session["IDCLIENT"] = txt.Text;
        //variable pour recuperer le donnée du idclient 
        Response.Redirect("./affichagerecherche.aspx?field1=" + Session["IDCLIENT"]);
    }
    public static string boton = "";
    protected void clickAch(object sender, EventArgs e)
    {
        boton = "ACH";
        Session["Transaction"] = "achat2";
        Session["IDCLIENT"] = txt.Text;
        Response.Redirect("./affichagerecherche.aspx?field1=" + Session["IDCLIENT"]);
    }

    protected void clickSite(object sender, EventArgs e)
    {
        boton = "ACH";

        Response.Redirect("./agent.aspx?id_client=" + txt.Text);
    }


    public void DropDownListNbClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["nbClientParPage"] = DropDownListNbClient.SelectedValue;
        Response.Redirect("./Recherche_agent.aspx?page=1");
    }

    public void DDLContractuel_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["DDLContractuel"] = DDLContractuel.SelectedValue;
        Response.Redirect("./Recherche_agent.aspx?page=1");
    }

    public String getCivilite(String id)
    {
        String civil;
        c3 = new System.Data.Odbc.OdbcConnection(_ConnectionString);
        OdbcDataReader reader;
        OdbcCommand commande = new OdbcCommand("SELECT * FROM Clients WHERE id_client= ? ", c3);
        OdbcParameter paramID = new OdbcParameter("", DbType.String);
        paramID.Value = id;
        commande.Parameters.Add(paramID);
        c3.Open();
        reader = commande.ExecuteReader();
        reader.Read();
        civil= reader["civilite"].ToString();
        reader.Close();
        c3.Close();

        return civil;

    }

}
