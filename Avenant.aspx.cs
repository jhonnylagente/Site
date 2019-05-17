using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_Avenant : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        String idBien = (String)Session["idbien"];
        //String requete = "SELECT 'etat civil vendeur','nom vendeur','adresse vendeur','code postal vendeur','ville vendeur','prix de vente','net vendeur','adresse du bien','code postal du bien','ville du bien' from Biens where 'ref'='" + idBien + "'";
        String requete = "SELECT * from Biens where ref='" + idBien + "'";

        Connexion c2 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c2.Open();
        System.Data.DataSet ds2 = c2.exeRequette(requete);
        c2.Close();
        System.Data.DataRowCollection dr = ds2.Tables[0].Rows;
        dr = ds2.Tables[0].Rows;
        foreach (System.Data.DataRow ligne in dr)
        {
            firstRow.Text = ligne["etat civil vendeur"] + " " + ligne["nom vendeur"]+"</br>";
            secondRow.Text = ligne["adresse vendeur"].ToString() + "</br>";

            thirdRow.Text = ligne["code postal vendeur"].ToString() + " " + ligne["ville vendeur"].ToString() + "</br>";

            fourthRow.Text = ligne["net vendeur"].ToString() + " ";

            fifthRow.Text = ligne["etat civil vendeur"].ToString() + " " + ligne["nom vendeur"].ToString() + " ";
            sixthRow.Text = ligne["adresse vendeur"].ToString() + " " + ligne["code postal vendeur"].ToString() + " " + ligne["ville vendeur"].ToString() + " ";
            seventhRow.Text = ligne["adresse du bien"].ToString() + " " + ligne["code postal du bien"].ToString() + " " + ligne["ville du bien"].ToString() + " ";
            eigthRow.Text = ligne["prix de vente"].ToString() + " ";
            Label1.Text = ligne["negociateur"].ToString();
        }

    }
}