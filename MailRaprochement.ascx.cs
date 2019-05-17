using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_MailRaprochement : System.Web.UI.UserControl
{
    protected string hote;
    protected void Page_Load(object sender, EventArgs e)
    {
        string requette = "SELECT * from environnement";
        System.Data.DataSet ds = null;
        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();
        ds = c.exeRequette(requette);
        c.Close();
        c = null;
        System.Data.DataRowCollection dr = ds.Tables[0].Rows;

        System.Data.DataRow ligne = dr[0];

        
        hote = ligne["IP"].ToString();
    }

    protected bool testFile(string file)
    {
        if (System.IO.File.Exists(MapPath(file)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}