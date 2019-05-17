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
using System.Text.RegularExpressions;

public partial class pages_detailsCA : System.Web.UI.Page
{
    protected Bien b;
    protected DataRowCollection statsCATot;
    protected ArrayList listeMois;
    protected ArrayList listeVisiteFiche, listeVisiteFicheF;
    protected ArrayList listeVisite, listeVisiteF;
    protected ArrayList listedebile1, listedebile2, listedebile3, listedebile21, listedebile22, listedebile23;
    protected string year;

    protected void Page_Load(object sender, EventArgs e)
    {
        string reference = Request.Params["id_client"];
        Membre member = (Membre)Session["Membre"];

        if (Request.QueryString["id_client"] != null)
        {
            string requete2 = "SELECT Year(date_signature) AS year, Month(date_signature) AS month, Sum([ca_mandat_details].ca) AS ca "
                            + "FROM (SELECT [commission]*[taux_mandat] AS ca, Ventes.date_signature "
                            + "FROM Clients INNER JOIN Ventes ON Clients.idclient = Ventes.id_nego "
                            + "WHERE Clients.id_client='" + reference + "' AND Ventes.[valider_paiement]=True UNION ALL SELECT [commission]*[taux_vente] AS ca, Ventes.date_signature FROM (Ventes INNER JOIN Acquereurs ON Ventes.id_acquereur = Acquereurs.id_acq) INNER JOIN Clients ON Acquereurs.idclient = Clients.idclient WHERE Clients.id_client = '" + reference + "' AND valider_paiement= true) AS ca_mandat_details "
                            + "GROUP BY Year(date_signature), Month(date_signature) "
                            + "ORDER BY Year(date_signature), Month(date_signature)";

            
            Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c.Open();
            statsCATot = c.exeRequette(requete2).Tables[0].Rows;
            c.Close();

            listeMois = new ArrayList();
            listeVisite = new ArrayList();
            DateTime today = DateTime.Now;

            int y = 0;
            int j = 0;
            for (int i = 0; i < 12; i++)
            {
                string month = ((today.Month + i) % 12 + 1).ToString();
                year = (today.Month + i > 12) ? today.Year.ToString() : (today.Year - 1).ToString();
                switch (month)
                {
                    case "1":
                        listeMois.Add("Janvier");
                        break;
                    case "2":
                        listeMois.Add("Février");
                        break;
                    case "3":
                        listeMois.Add("Mars");
                        break;
                    case "4":
                        listeMois.Add("Avril");
                        break;
                    case "5":
                        listeMois.Add("Mai");
                        break;
                    case "6":
                        listeMois.Add("Juin");
                        break;
                    case "7":
                        listeMois.Add("Juillet");
                        break;
                    case "8":
                        listeMois.Add("Août");
                        break;
                    case "9":
                        listeMois.Add("Septembre");
                        break;
                    case "10":
                        listeMois.Add("Octobre");
                        break;
                    case "11":
                        listeMois.Add("Novembre");
                        break;
                    case "12":
                        listeMois.Add("Décembre");
                        break;
                }
                
                bool found2 = false;
                for (int x = y; x < statsCATot.Count; x++)
                {
                    if (month == statsCATot[x]["month"].ToString() && year == statsCATot[x]["year"].ToString())
                    {
                        listeVisite.Add(statsCATot[x]["ca"].ToString().Replace(',', '.'));
                        y = x + 1;
                        found2 = true;
                        break;
                    }
                }
                if (!found2)
                {
                    listeVisite.Add("0");
                }
            }


        }
        else
        {
            Response.Redirect("recherche.aspx");
            Response.End();
        }
        exeRequeteCAFilleul(reference);
    }

    public void exeRequeteCAFilleul(String mail_client)
    {
        String[] requeteCAF = new String[7] { "", "", "", "", "", "", "" };
        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataSet ds, ds1, ds2;
        DataRowCollection dr, dr1, dr2;
        listeVisiteFicheF = new ArrayList();
        listeVisiteF = new ArrayList();
        listeVisiteFiche = new ArrayList();
        listedebile1 = new ArrayList();
        listedebile2 = new ArrayList();
        listedebile3 = new ArrayList();
        listedebile21 = new ArrayList();
        listedebile22 = new ArrayList();
        listedebile23 = new ArrayList();
        c.Open();
        requeteCAF[0] = "SELECT Clients_1.id_client FROM Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain WHERE (((Clients.id_client)='" + mail_client + "'))";
        requeteCAF[1] = "SELECT Clients_2.id_client FROM (Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain) INNER JOIN Clients AS Clients_2 ON Clients_1.idclient = Clients_2.idparrain WHERE (((Clients.id_client)='" + mail_client + "'))";
        requeteCAF[2] = "SELECT Clients_3.id_client FROM ((Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain) INNER JOIN Clients AS Clients_2 ON Clients_1.idclient = Clients_2.idparrain) INNER JOIN Clients AS Clients_3 ON Clients_2.idclient = Clients_3.idparrain WHERE (((Clients.id_client)='" + mail_client + "'))";
        requeteCAF[3] = "SELECT Clients_4.id_client FROM (((Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain) INNER JOIN Clients AS Clients_2 ON Clients_1.idclient = Clients_2.idparrain) INNER JOIN Clients AS Clients_3 ON Clients_2.idclient = Clients_3.idparrain) INNER JOIN Clients AS Clients_4 ON Clients_3.idclient = Clients_4.idparrain WHERE (((Clients.id_client)='" + mail_client + "'))";
        requeteCAF[4] = "SELECT Clients_5.id_client FROM (((((Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain) INNER JOIN Clients AS Clients_2 ON Clients_1.idclient = Clients_2.idparrain) INNER JOIN Clients AS Clients_3 ON Clients_2.idclient = Clients_3.idparrain) INNER JOIN Clients AS Clients_4 ON Clients_3.idclient = Clients_4.idparrain) INNER JOIN Clients AS Clients_5 ON Clients_4.idclient = Clients_5.idparrain) WHERE (((Clients.id_client)='" + mail_client + "'))";
        requeteCAF[5] = "SELECT Clients_6.id_client FROM (((((Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain) INNER JOIN Clients AS Clients_2 ON Clients_1.idclient = Clients_2.idparrain) INNER JOIN Clients AS Clients_3 ON Clients_2.idclient = Clients_3.idparrain) INNER JOIN Clients AS Clients_4 ON Clients_3.idclient = Clients_4.idparrain) INNER JOIN Clients AS Clients_5 ON Clients_4.idclient = Clients_5.idparrain) INNER JOIN Clients AS Clients_6 ON Clients_5.idclient = Clients_6.idparrain WHERE (((Clients.id_client)='" + mail_client + "'))";
        requeteCAF[6] = "SELECT Clients_7.id_client FROM ((((((Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain) INNER JOIN Clients AS Clients_2 ON Clients_1.idclient = Clients_2.idparrain) INNER JOIN Clients AS Clients_3 ON Clients_2.idclient = Clients_3.idparrain) INNER JOIN Clients AS Clients_4 ON Clients_3.idclient = Clients_4.idparrain) INNER JOIN Clients AS Clients_5 ON Clients_4.idclient = Clients_5.idparrain) INNER JOIN Clients AS Clients_6 ON Clients_5.idclient = Clients_6.idparrain) INNER JOIN Clients AS Clients_7 ON Clients_6.idclient = Clients_7.idparrain WHERE (((Clients.id_client)='" + mail_client + "'))";

        DateTime today = DateTime.Now;

        double pourcentage = 0D;
        for (int m = 0; m < 7; m++)
        {
            if (m == 0) pourcentage = 0.05;
            if (m == 1) pourcentage = 0.04;
            if (m == 2) pourcentage = 0.03;
            if (m == 3) pourcentage = 0.02;
            if (m == 4) pourcentage = 0.01;
            if (m == 5) pourcentage = 0.005;
            if (m == 6) pourcentage = 0.0025;

            ds = c.exeRequette(requeteCAF[m]);
            dr = ds.Tables[0].Rows;

            string requete1 = "SELECT Year(date_signature) AS year, Month(date_signature) AS month, Count(*) AS nbventes "
                              + "FROM (SELECT date_signature FROM ((Clients INNER JOIN Ventes ON Clients.idclient = Ventes.id_nego) INNER JOIN Acquereurs ON Ventes.id_acquereur = Acquereurs.id_acq) INNER JOIN Clients AS Clients_1 ON Acquereurs.idclient = Clients_1.idclient "
                              + "WHERE (Clients.id_client = '" + mail_client + "' OR Clients_1.id_client = '" + mail_client + "') AND valider_signature = true) "
                              + "GROUP BY Year(date_signature), Month(date_signature) ORDER BY Year(date_signature),Month(date_signature)";
            string requete2 = "SELECT Year(date_signature) AS year, Month(date_signature) AS month, Sum([ca_mandat_details].ca) AS ca "
                              + "FROM (SELECT [commission]*[taux_mandat] AS ca, Ventes.date_signature "
                              + "FROM Clients INNER JOIN Ventes ON Clients.idclient = Ventes.id_nego "
                              + "WHERE (Clients.id_client='";
            for (int soul = 0; soul < dr.Count; soul++)
            {
                if (soul == 0)
                {
                    requete2 += dr[soul]["id_client"] + "'";
                }
                else
                {
                    requete2 += " OR Clients.id_client = '" + dr[soul]["id_client"] + "'";
                }
            }
            requete2 += ") AND Ventes.[valider_paiement]=True UNION ALL SELECT [commission]*[taux_vente] AS ca, Ventes.date_signature "
                        + "FROM (Ventes INNER JOIN Acquereurs ON Ventes.id_acquereur = Acquereurs.id_acq) INNER JOIN Clients ON Acquereurs.idclient = Clients.idclient WHERE (Clients.id_client = '";

            for (int soul = 0; soul < dr.Count; soul++)
            {
                if (soul == 0)
                {
                    requete2 += dr[soul]["id_client"] + "'";
                }
                else
                {
                    requete2 += " OR Clients.id_client = '" + dr[soul]["id_client"] + "'";
                }
            }
            requete2 += ") AND valider_paiement= true) AS ca_mandat_details "
                                + "GROUP BY Year(date_signature), Month(date_signature) "
                                + "ORDER BY Year(date_signature), Month(date_signature)";
            ds1 = c.exeRequette(requete1);
            dr1 = ds1.Tables[0].Rows;
            ds2 = c.exeRequette(requete2);
            dr2 = ds2.Tables[0].Rows;

            foreach (DataRow ligne in dr2)
            {
                listedebile21.Add(ligne["year"].ToString());
                listedebile22.Add(ligne["month"].ToString());
                listedebile23.Add(((double)ligne["ca"] * pourcentage).ToString());
            }
            foreach (DataRow ligne in dr1)
            {
                listedebile1.Add(ligne["year"].ToString());
                listedebile2.Add(ligne["month"].ToString());
                listedebile3.Add(ligne["nbventes"].ToString());
            }
        }

        int y = 0;
        int j = 0;
        int nbventes = 0, nblocations = 0;
        for (int i = 0; i < 12; i++)
        {
            string month = ((today.Month + i) % 12 + 1).ToString();
            year = (today.Month + i > 12) ? today.Year.ToString() : (today.Year - 1).ToString();
            bool found1 = false;
            for (int k = j; k < listedebile1.Count; k++)
            {
                if (month == listedebile2[k].ToString() && year == listedebile1[k].ToString())
                {
                    ds = c.exeRequette("SELECT ref_bien FROM Clients AS Clients_1 INNER JOIN ((Ventes INNER JOIN Acquereurs ON Ventes.id_acquereur = Acquereurs.id_acq) INNER JOIN Clients ON Acquereurs.idclient = Clients.idclient) ON Clients_1.idclient = Ventes.id_nego WHERE Month(date_signature) = " + listedebile2[k].ToString() + " AND Year(date_signature) = " + listedebile1[k].ToString() + " AND (Clients_1.id_client = '" + mail_client + "' OR Clients.id_client = '" + mail_client + "')");
                    dr = ds.Tables[0].Rows;

                    foreach (DataRow ligne in dr)
                    {
                        if (ligne["ref_bien"].ToString().Substring(0, 1) == "V") nbventes++;
                        else nblocations++;
                    }
                    
                    listeVisiteFicheF.Add(listedebile3[k].ToString());
                    listeVisiteFiche.Add(nblocations.ToString());
                    j = k + 1;
                    found1 = true;
                    break;
                }
            }
            if (!found1)
            {
                listeVisiteFicheF.Add("0");
                listeVisiteFiche.Add("0");
            }

            bool found2 = false;
            for (int x = y; x < listedebile21.Count; x++)
            {
                if (month == listedebile22[x].ToString() && year == listedebile21[x].ToString())
                {
                    listeVisiteF.Add(listedebile23[x].ToString().Replace(',', '.'));
                    y = x + 1;
                    found2 = true;
                    break;
                }
            }
            if (!found2)
            {
                listeVisiteF.Add("0");
            }
        }
        c.Close();
    }
}
