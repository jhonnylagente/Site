using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class pages_hierarchie : System.Web.UI.Page
{
    String requeteTotF, requeteTotP, requetePar;

    protected void Page_Load(object sender, EventArgs e)
    {
        Label label = new Label();
        if ((Membre)Session["Membre"] != null)
        {
            Membre client = (Membre)Session["Membre"];
            if (client.CIVILITE == "Mr") label.Text = "<br /><br />Bienvenu";
            else label.Text = "<br /><br />Bienvenue";
            label.Text += " sur votre espace hiérarchique, veuillez trouver ci-dessous vos filleuls et vos parrains.";
            label.CssClass = "labelBienvenu";
            for (int k = 0; k < 7; k++)
            {
                calculNbF(k);
            }
            exeRequete();
            caFilleul();
        }
        else
        {
            label.Text = "<br/><br/><br/><br/><br/>Vous n'êtes pas connecté ! Si jamais vous souhaitez vous connecter à votre réseau.<br/><br/><br/><br/><br/>";
            label.CssClass = "labelErreur";
            PanelTop.Style.Add("display", "none");
        }
        panelBienvenue.Controls.Add(label);
    }

    public String exeRequeteTotalF(int niveau, int client)
    {
        if (niveau == 1) requeteTotF = "SELECT Clients_1.nom_client, Clients_1.prenom_client, Clients_1.idclient FROM Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain WHERE (((Clients.idclient)=" + client + " AND Clients_1.contractuel = true)) ORDER BY Clients_1.nom_client";
        if (niveau == 2) requeteTotF = "SELECT Clients_2.nom_client, Clients_2.prenom_client, Clients_2.idclient FROM (Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain) INNER JOIN Clients AS Clients_2 ON Clients_1.idclient = Clients_2.idparrain WHERE (((Clients.idclient)=" + client + " AND Clients_2.contractuel = true)) ORDER BY Clients_2.nom_client";
        if (niveau == 3) requeteTotF = "SELECT Clients_3.nom_client, Clients_3.prenom_client, Clients_3.idclient FROM ((Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain) INNER JOIN Clients AS Clients_2 ON Clients_1.idclient = Clients_2.idparrain) INNER JOIN Clients AS Clients_3 ON Clients_2.idclient = Clients_3.idparrain WHERE (((Clients.idclient)=" + client + " AND Clients_3.contractuel = true)) ORDER BY Clients_3.nom_client";
        if (niveau == 4) requeteTotF = "SELECT Clients_4.nom_client, Clients_4.prenom_client, Clients_4.idclient FROM (((Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain) INNER JOIN Clients AS Clients_2 ON Clients_1.idclient = Clients_2.idparrain) INNER JOIN Clients AS Clients_3 ON Clients_2.idclient = Clients_3.idparrain) INNER JOIN Clients AS Clients_4 ON Clients_3.idclient = Clients_4.idparrain WHERE (((Clients.idclient)=" + client + " AND Clients_4.contractuel = true)) ORDER BY Clients_4.nom_client";
        if (niveau == 5) requeteTotF = "SELECT Clients_5.nom_client, Clients_5.prenom_client, Clients_5.idclient FROM (((((Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain) INNER JOIN Clients AS Clients_2 ON Clients_1.idclient = Clients_2.idparrain) INNER JOIN Clients AS Clients_3 ON Clients_2.idclient = Clients_3.idparrain) INNER JOIN Clients AS Clients_4 ON Clients_3.idclient = Clients_4.idparrain) INNER JOIN Clients AS Clients_5 ON Clients_4.idclient = Clients_5.idparrain) WHERE (((Clients.idclient)=" + client + " AND Clients_5.contractuel = true)) ORDER BY Clients_5.nom_client";
        if (niveau == 6) requeteTotF = "SELECT Clients_6.nom_client, Clients_6.prenom_client, Clients_6.idclient FROM (((((Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain) INNER JOIN Clients AS Clients_2 ON Clients_1.idclient = Clients_2.idparrain) INNER JOIN Clients AS Clients_3 ON Clients_2.idclient = Clients_3.idparrain) INNER JOIN Clients AS Clients_4 ON Clients_3.idclient = Clients_4.idparrain) INNER JOIN Clients AS Clients_5 ON Clients_4.idclient = Clients_5.idparrain) INNER JOIN Clients AS Clients_6 ON Clients_5.idclient = Clients_6.idparrain WHERE (((Clients.idclient)=" + client + " AND Clients_6.contractuel = true)) ORDER BY Clients_6.nom_client";
        if (niveau == 7) requeteTotF = "SELECT Clients_7.nom_client, Clients_7.prenom_client, Clients_7.idclient FROM ((((((Clients INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain) INNER JOIN Clients AS Clients_2 ON Clients_1.idclient = Clients_2.idparrain) INNER JOIN Clients AS Clients_3 ON Clients_2.idclient = Clients_3.idparrain) INNER JOIN Clients AS Clients_4 ON Clients_3.idclient = Clients_4.idparrain) INNER JOIN Clients AS Clients_5 ON Clients_4.idclient = Clients_5.idparrain) INNER JOIN Clients AS Clients_6 ON Clients_5.idclient = Clients_6.idparrain) INNER JOIN Clients AS Clients_7 ON Clients_6.idclient = Clients_7.idparrain WHERE (((Clients.idclient)=" + client + " AND Clients_7.contractuel = true)) ORDER BY Clients_7.nom_client";

        return requeteTotF;
    }

    public String exeRequeteTotalP(int niveau)
    {
        Membre client = (Membre)Session["Membre"];
        requeteTotP = "SELECT Clients_" + (niveau + 1) + ".idclient, Clients_" + (niveau + 1) + ".nom_client, Clients_" + (niveau + 1) + ".prenom_client FROM (((((((Clients INNER JOIN Clients AS Clients_1 ON Clients.idparrain = Clients_1.idclient) INNER JOIN Clients AS Clients_2 ON Clients_1.idparrain = Clients_2.idclient) INNER JOIN Clients AS Clients_3 ON Clients_2.idparrain = Clients_3.idclient) INNER JOIN Clients AS Clients_4 ON Clients_3.idparrain = Clients_4.idclient) INNER JOIN Clients AS Clients_5 ON Clients_4.idparrain = Clients_5.idclient) INNER JOIN Clients AS Clients_6 ON Clients_5.idparrain = Clients_6.idclient) INNER JOIN Clients AS Clients_7 ON Clients_6.idparrain = Clients_7.idclient) INNER JOIN Clients AS Clients_8 ON Clients_7.idparrain = Clients_8.idclient WHERE (((Clients.idparrain)=" + client.IDCLIENT + ") AND Clients.contractuel = true)";
        return requeteTotP;
    }

    protected void exeRequete()
    {
        Membre client = (Membre)Session["Membre"];
        if (client != null)
        {
            Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            DataSet ds;
            DataRowCollection dr;
            c.Open();

            for (int j = 1; j < 8; j++)
            {
                ds = c.exeRequette(exeRequeteTotalP(j));
                dr = ds.Tables[0].Rows;
                foreach (DataRow ligne in dr)
                {
                    Button btn = new Button();
                    btn.Text = ligne["nom_client"].ToString().ToUpper() + " " + ligne["prenom_client"].ToString().Substring(0, 1).ToUpper() + ligne["prenom_client"].ToString().Substring(1, ligne["prenom_client"].ToString().Length - 1).ToLower();
                    btn.CssClass = "hierarchie";
                    btn.Attributes.Add("onclick", "btnIdClick('" + ligne["idclient"].ToString() + "')");

                    if (j == 1 && !TableCellP1.HasControls()) TableCellP1.Controls.Add(btn);
                    if (j == 2 && !TableCellP2.HasControls()) TableCellP2.Controls.Add(btn);
                    if (j == 3 && !TableCellP3.HasControls()) TableCellP3.Controls.Add(btn);
                    if (j == 4 && !TableCellP4.HasControls()) TableCellP4.Controls.Add(btn);
                    if (j == 5 && !TableCellP5.HasControls()) TableCellP5.Controls.Add(btn);
                    if (j == 6 && !TableCellP6.HasControls()) TableCellP6.Controls.Add(btn);
                    if (j == 7 && !TableCellP7.HasControls()) TableCellP7.Controls.Add(btn);

                }
            }
            c.Close();
        }
    }

    protected void onClickID(object sender, EventArgs e)
    {
        String idClicked = HiddenField.Text;
        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataSet ds;
        DataRowCollection dr;
        c.Open();
        ds = c.exeRequette("SELECT id_client FROM Clients WHERE idclient = " + idClicked);
        dr = ds.Tables[0].Rows;

        c.Close();

        Response.Redirect("./agent.aspx?id_client=" + dr[0]["id_client"]);
    }

    protected void onOverID(object sender, EventArgs e)
    {
        Membre client = (Membre)Session["Membre"];
        int idOver = int.Parse(HiddenFieldOver.Text);
        int pos = int.Parse(HiddenFieldOverPos.Text);
        int nbclicked1 = 0, nbclicked2 = 0, nbclicked3 = 0, nbclicked4 = 0, nbclicked5 = 0, nbclicked6 = 0, nbclicked7 = 0;
        ArrayList pos1 = new ArrayList();

        foreach (String post in Session["TableCell"].ToString().Split(','))
        {
            pos1.Add(post);
        }

        for (int i = 0; i < pos1.Count; i++)
        {
            if (pos1[i].ToString() == "0") nbclicked1++;
            if (pos1[i].ToString() == "1") nbclicked2++;
            if (pos1[i].ToString() == "2") nbclicked3++;
            if (pos1[i].ToString() == "3") nbclicked4++;
            if (pos1[i].ToString() == "4") nbclicked5++;
            if (pos1[i].ToString() == "5") nbclicked6++;
            if (pos1[i].ToString() == "6") nbclicked7++;
        }
        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataSet ds, ds1;
        DataRowCollection dr, dr1;
        ArrayList listeId = new ArrayList();
        Boolean boolie = false;
        c.Open();
        listeId.Add(idOver.ToString());
        for (int k = 1; k < 8 - pos; k++)
        {
            ds1 = c.exeRequette(exeRequeteTotalF(k, idOver));
            dr1 = ds1.Tables[0].Rows;
            foreach (DataRow ligne in dr1)
            {
                listeId.Add(ligne["idclient"].ToString());
            }
        }
        TableCellF1.Controls.Clear();
        TableCellF2.Controls.Clear();
        TableCellF3.Controls.Clear();
        TableCellF4.Controls.Clear();
        TableCellF5.Controls.Clear();
        TableCellF6.Controls.Clear();
        TableCellF7.Controls.Clear();

        for (int j = 1; j < 8; j++)
        {
            ds = c.exeRequette(exeRequeteTotalF(j, client.IDCLIENT));
            dr = ds.Tables[0].Rows;
            foreach (DataRow ligne in dr)
            {
                for (int i = 0; i < listeId.Count; i++)
                {
                    if (listeId[i].ToString() == ligne["idclient"].ToString()) boolie = true;
                }
                Button btn = new Button();
                btn.Text = ligne["nom_client"].ToString().ToUpper() + " " + ligne["prenom_client"].ToString().Substring(0, 1).ToUpper() + ligne["prenom_client"].ToString().Substring(1, ligne["prenom_client"].ToString().Length - 1).ToLower(); 
                btn.Attributes.Add("onclick", "btnIdClick('" + ligne["idclient"].ToString() + "')");
                btn.Attributes.Add("onmouseover", "btnOverID('" + ligne["idclient"].ToString() + "', " + j + ")");
                if (boolie) btn.CssClass = "hierarchieHover";
                else btn.CssClass = "hierarchie";

                if (j == 1 && nbclicked1 % 2 != 0) TableCellF1.Controls.Add(btn);
                if (j == 2 && nbclicked2 % 2 != 0) TableCellF2.Controls.Add(btn); 
                if (j == 3 && nbclicked3 % 2 != 0) TableCellF3.Controls.Add(btn);
                if (j == 4 && nbclicked4 % 2 != 0) TableCellF4.Controls.Add(btn);
                if (j == 5 && nbclicked5 % 2 != 0) TableCellF5.Controls.Add(btn);
                if (j == 6 && nbclicked6 % 2 != 0) TableCellF6.Controls.Add(btn);
                if (j == 7 && nbclicked7 % 2 != 0) TableCellF7.Controls.Add(btn);
                boolie = false;
            }
        }
        c.Close();
    }

    public void caFilleul()
    {
        Membre client = (Membre)Session["Membre"];
        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataSet ds, ds1;
        DataRowCollection dr, dr1;
        double pourcentage = 0D, caFTot = 0D;
        double[] caF = new double[7] { 0D, 0D, 0D, 0D, 0D, 0D, 0D };
        Label labelTot = new Label(), label1 = new Label(), label2 = new Label(), label3 = new Label(), label4 = new Label(), label5 = new Label(), label6 = new Label(), label7 = new Label();
        label1.CssClass = "labelCA"; label2.CssClass = "labelCA"; label3.CssClass = "labelCA"; label4.CssClass = "labelCA"; label5.CssClass = "labelCA"; label6.CssClass = "labelCA"; label7.CssClass = "labelCA";
        labelTot.CssClass = "labelTot";
        c.Open();
        for (int j = 1; j < 8; j++)
        {
            ds = c.exeRequette(exeRequeteTotalF(j, client.IDCLIENT));
            dr = ds.Tables[0].Rows;
            foreach (DataRow ligne in dr)
            {
                String requeteCA = "SELECT Sum([ca_mandat_details].ca) AS ca "
                                   + "FROM(SELECT [commission]*[taux_mandat] AS ca "
                                   + "FROM Clients INNER JOIN Ventes ON Clients.idclient = Ventes.id_nego "
                                   + "WHERE Clients.idclient= " + ligne["idclient"].ToString() + " AND Ventes.[valider_paiement]=True UNION ALL SELECT [commission]*[taux_vente] AS ca FROM (Ventes INNER JOIN Acquereurs ON Ventes.id_acquereur = Acquereurs.id_acq) INNER JOIN Clients ON Acquereurs.idclient = Clients.idclient WHERE Clients.idclient = " + ligne["idclient"].ToString() + " AND valider_paiement= true) AS ca_mandat_details";

                ds1 = c.exeRequette(requeteCA);
                dr1 = ds1.Tables[0].Rows;
                if (j == 1) pourcentage = 0.05;
                if (j == 2) pourcentage = 0.04;
                if (j == 3) pourcentage = 0.03;
                if (j == 4) pourcentage = 0.02;
                if (j == 5) pourcentage = 0.01;
                if (j == 6) pourcentage = 0.005;
                if (j == 7) pourcentage = 0.0025;
                if (dr1[0]["ca"].ToString() != "") caF[j - 1] += double.Parse(dr1[0]["ca"].ToString()) * pourcentage;
            }
        }
        for (int k = 0; k < 7; k++)
        {
            caFTot += caF[k];
        }
        label1.Text = Math.Round(caF[0], 2).ToString() + " €";
        label2.Text = Math.Round(caF[1], 2).ToString() + " €";
        label3.Text = Math.Round(caF[2], 2).ToString() + " €";
        label4.Text = Math.Round(caF[3], 2).ToString() + " €";
        label5.Text = Math.Round(caF[4], 2).ToString() + " €";
        label6.Text = Math.Round(caF[5], 2).ToString() + " €";
        label7.Text = Math.Round(caF[6], 2).ToString() + " €";
        labelTot.Text = Math.Round(caFTot, 2).ToString() + " €";
        if (!TableCellCA1.HasControls()) TableCellCA1.Controls.Add(label1);
        if (!TableCellCA2.HasControls()) TableCellCA2.Controls.Add(label2);
        if (!TableCellCA3.HasControls()) TableCellCA3.Controls.Add(label3);
        if (!TableCellCA4.HasControls()) TableCellCA4.Controls.Add(label4);
        if (!TableCellCA5.HasControls()) TableCellCA5.Controls.Add(label5);
        if (!TableCellCA6.HasControls()) TableCellCA6.Controls.Add(label6);
        if (!TableCellCA7.HasControls()) TableCellCA7.Controls.Add(label7);
        if (!TableCellCATot.HasControls()) TableCellCATot.Controls.Add(labelTot);

        c.Close();
    }

    protected void displayFilleul(object sender, EventArgs e)
    {
        String pos = position.Text;
        int nbclicked1 = 0, nbclicked2 = 0, nbclicked3 = 0, nbclicked4 = 0, nbclicked5 = 0, nbclicked6 = 0, nbclicked7 = 0;
        bool dejafait1 = false, dejafait2 = false, dejafait3 = false, dejafait4 = false, dejafait5 = false, dejafait6 = false, dejafait7 = false;
        if (pos != "") Session["TableCell"] += "," + pos;
        ArrayList pos1 = new ArrayList();
        int f = 0;
        Membre client = (Membre)Session["Membre"];

        foreach (String post in Session["TableCell"].ToString().Split(','))
        {
            pos1.Add(post);
        }

        foreach (String post in pos1)
        {
            if (post != "-1")
            {
                Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                DataSet ds;
                DataRowCollection dr;
                c.Open();
                if (post == "0") f = 1;
                if (post == "1") f = 2;
                if (post == "2") f = 3;
                if (post == "3") f = 4;
                if (post == "4") f = 5;
                if (post == "5") f = 6;
                if (post == "6") f = 7;
                ds = c.exeRequette(exeRequeteTotalF(f, client.IDCLIENT));
                dr = ds.Tables[0].Rows;
                foreach (DataRow ligne in dr)
                {
                    Button btn = new Button();
                    btn.Text = ligne["nom_client"].ToString().ToUpper() + " " + ligne["prenom_client"].ToString().Substring(0, 1).ToUpper() + ligne["prenom_client"].ToString().Substring(1, ligne["prenom_client"].ToString().Length - 1).ToLower();
                    btn.Attributes.Add("onclick", "btnIdClick('" + ligne["idclient"].ToString() + "')");
                    btn.Attributes.Add("onmouseover", "btnOverID('" + ligne["idclient"].ToString() + "', " + post + ")");
                    btn.CssClass = "hierarchie";

                    if (post == "0" && !dejafait1) TableCellF1.Controls.Add(btn);
                    if (post == "1" && !dejafait2) TableCellF2.Controls.Add(btn);
                    if (post == "2" && !dejafait3) TableCellF3.Controls.Add(btn);
                    if (post == "3" && !dejafait4) TableCellF4.Controls.Add(btn);
                    if (post == "4" && !dejafait5) TableCellF5.Controls.Add(btn);
                    if (post == "5" && !dejafait6) TableCellF6.Controls.Add(btn);
                    if (post == "6" && !dejafait7) TableCellF7.Controls.Add(btn);
                }
                if (post == "0") dejafait1 = true;
                if (post == "1") dejafait2 = true;
                if (post == "2") dejafait3 = true;
                if (post == "3") dejafait4 = true;
                if (post == "4") dejafait5 = true;
                if (post == "5") dejafait6 = true;
                if (post == "6") dejafait7 = true;
            }
        }

        for (int i = 0; i < pos1.Count; i++)
        {
            if (pos1[i].ToString() == "0") nbclicked1++;
            if (pos1[i].ToString() == "1") nbclicked2++;
            if (pos1[i].ToString() == "2") nbclicked3++;
            if (pos1[i].ToString() == "3") nbclicked4++;
            if (pos1[i].ToString() == "4") nbclicked5++;
            if (pos1[i].ToString() == "5") nbclicked6++;
            if (pos1[i].ToString() == "6") nbclicked7++;
        }

        if (nbclicked1 % 2 == 0) TableCellF1.Controls.Clear();
        if (nbclicked2 % 2 == 0) TableCellF2.Controls.Clear();
        if (nbclicked3 % 2 == 0) TableCellF3.Controls.Clear();
        if (nbclicked4 % 2 == 0) TableCellF4.Controls.Clear();
        if (nbclicked5 % 2 == 0) TableCellF5.Controls.Clear();
        if (nbclicked6 % 2 == 0) TableCellF6.Controls.Clear();
        if (nbclicked7 % 2 == 0) TableCellF7.Controls.Clear();

        if (TableCellF1.HasControls() || TableCellF2.HasControls() || TableCellF3.HasControls() || TableCellF4.HasControls() || TableCellF5.HasControls() || TableCellF6.HasControls() || TableCellF7.HasControls()) TableRow2.Style.Add("display", "");
        else TableRow2.Style.Add("display", "none");
        UpdatePanel2.Update();
    }

    public void calculNbF(int j)
    {
        Membre client = (Membre)Session["Membre"];
        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        DataSet ds;
        DataRowCollection dr;
        c.Open();
        
        String requete = "SELECT Count(*) AS nbF FROM (((((";
        if (j >= 0) requete += "Clients ";
        if (j >= 1) requete += "INNER JOIN Clients AS Clients_1 ON Clients.idclient = Clients_1.idparrain) ";
        else requete += ")";
        if (j >= 2) requete += "INNER JOIN Clients AS Clients_2 ON Clients_1.idclient = Clients_2.idparrain) ";
        else requete += ")";
        if (j >= 3) requete += "INNER JOIN Clients AS Clients_3 ON Clients_2.idclient = Clients_3.idparrain) ";
        else requete += ")";
        if (j >= 4) requete += "INNER JOIN Clients AS Clients_4 ON Clients_3.idclient = Clients_4.idparrain) ";
        else requete += ")";
        if (j >= 5) requete += "INNER JOIN Clients AS Clients_5 ON Clients_4.idclient = Clients_5.idparrain) ";
        else requete += ")";
        if (j >= 6) requete += "INNER JOIN Clients AS Clients_6 ON Clients_5.idclient = Clients_6.idparrain ";

        requete += "WHERE (((Clients.idparrain)=" + client.IDCLIENT + ") AND Clients";
        if (j > 0) requete += "_" + j;
        requete += ".contractuel = true)";
        string filleul = " filleul";
        ds = c.exeRequette(requete);
        dr= ds.Tables[0].Rows;
        Button btn = new Button();
        btn.CssClass = "hierarchieBis";
        btn.OnClientClick = "displayFilleuls(" + j + ")";
        if ((int)dr[0]["nbF"] >= 2) filleul = " filleuls";
        if (j == 0 && !TableCellNbF1.HasControls()) { btn.Text = dr[0]["nbF"].ToString() + filleul; TableCellNbF1.Controls.Add(btn); }
        if (j == 1 && !TableCellNbF2.HasControls()) { btn.Text = dr[0]["nbF"].ToString() + filleul; TableCellNbF2.Controls.Add(btn); }
        if (j == 2 && !TableCellNbF3.HasControls()) { btn.Text = dr[0]["nbF"].ToString() + filleul; TableCellNbF3.Controls.Add(btn); }
        if (j == 3 && !TableCellNbF4.HasControls()) { btn.Text = dr[0]["nbF"].ToString() + filleul; TableCellNbF4.Controls.Add(btn); }
        if (j == 4 && !TableCellNbF5.HasControls()) { btn.Text = dr[0]["nbF"].ToString() + filleul; TableCellNbF5.Controls.Add(btn); }
        if (j == 5 && !TableCellNbF6.HasControls()) { btn.Text = dr[0]["nbF"].ToString() + filleul; TableCellNbF6.Controls.Add(btn); }
        if (j == 6 && !TableCellNbF7.HasControls()) { btn.Text = dr[0]["nbF"].ToString() + filleul; TableCellNbF7.Controls.Add(btn); }
                  
    }
}