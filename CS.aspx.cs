using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
public partial class pages_CS : System.Web.UI.Page
{
    [WebMethod]
    public static string[] Getvilles(string prefix)
    {
        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        List<string> ville = new List<string>();
        string rech = prefix;
        prefix = prefix.Replace(" ", "-");
        string query1 = "SELECT TOP 25 Pays.url_drap,copie_ville.Nom, copie_ville.[Code Postal], Pays.Titre_Pays FROM copie_ville, Pays WHERE copie_ville.slug LIKE '%" + prefix + "%' AND copie_ville.refpays = Pays.codeiso ";
        string query2 = "select TOP 10 url_drap,Titre_Pays from Pays WHERE Titre_Pays LIKE '%" + prefix + "%' ORDER BY Titre_Pays";
        string query3 = "select TOP 10 departement_code,departement_nom from departement,Pays WHERE departement_code = '" + prefix + "' OR departement_nom LIKE '%" + prefix + "%'";
        string query4 = "select TOP 20 Nom,[Code Postal] from Arrondissement WHERE Arrondissement.Nom LIKE '%" + rech + "%'";
        c.Open();
        DataTable dt1 = c.exeRequette(query1).Tables[0];
        DataTable dt2 = c.exeRequette(query2).Tables[0];
        DataTable dt3 = c.exeRequette(query3).Tables[0];
        DataTable dt4 = c.exeRequette(query4).Tables[0];
        c.Close();
        c = null;
        string newLine = ((char)13).ToString() +((char)10).ToString(); ;     
            foreach (DataRow dr1 in dt2.Rows)
        {
                ville.Add(dr1[0].ToString() + "/"+dr1[1].ToString());
        }
        foreach (DataRow dr2 in dt3.Rows)
        {
            ville.Add(dr2[1].ToString() + "/" + "-" + dr2[2].ToString());
        }
        foreach (DataRow dr3 in dt4.Rows)
        {
            ville.Add(dr3[0].ToString());
        }
        foreach (DataRow dr in dt1.Rows)
            {

                ville.Add(dr[0].ToString() +"/"+ dr[1].ToString() + "  " + dr[2].ToString() + " (" + dr[3].ToString() + ")");
            }
            
        if (ville.Count.Equals(0))
        {
        ville.Add("Aucun résultat!");
            return ville.ToArray();
        }
        else
            return ville.ToArray();
    }

    protected void Submit(object sender, EventArgs e)
    {
        
        string localiteId = Request.Form[hfCustomerId.UniqueID];
        //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + localite + "\\nID: " + localiteId + "');", true);
    }
}