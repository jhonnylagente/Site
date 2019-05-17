using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Odbc;
using System.Configuration;

public partial class ajoutCommissionLibre : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Membre member = (Membre)Session["Membre"];

        if (!IsPostBack)
        {
            Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            string req = "SELECT Ventes.ref_bien, Ventes.prix_vente, Ventes.commission, Ventes.id_acquereur FROM Ventes WHERE Ventes.ID=" + Request.QueryString["Ref"];

            c.Open();

            DataRow vente = c.exeRequetteOpen(req).Tables[0].Rows[0];

            c.Close();

            refVente.Text = "<a href=\"./fichedetail1.aspx?ref=" + vente["ref_bien"].ToString() + "\" target='_blank'>" + vente["ref_bien"].ToString() + "</a>";
            prixVente.Text = vente["prix_vente"].ToString() + " €";
            commissionVente.Text = vente["commission"].ToString();
            commissionVenteTextBox.Text = commissionVente.Text;

            req = "SELECT SUM(montant) FROM Ventes_honoraires WHERE Ventes_honoraires.id_vente=" + Request.QueryString["Ref"];

            OdbcConnection connection = new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            OdbcCommand requette2 = new OdbcCommand(req, connection);

            connection.Open();

            double sommeCommissionVenteDouble = (double)requette2.ExecuteScalar();
            sommeCommissionVente.Text = sommeCommissionVenteDouble.ToString(); 
            sommeCommissionVenteTxtBox.Text = sommeCommissionVente.Text;

            connection.Close();

            commissionDispoAjout.Text = (Convert.ToDouble(vente["commission"].ToString()) - sommeCommissionVenteDouble).ToString();
            commissionDispoAjoutTextBox.Text = commissionDispoAjout.Text;

            req = "SELECT Ventes_honoraires.montant, Clients.nom_client, Clients.prenom_client, Clients.idclient FROM Ventes_honoraires INNER JOIN Clients ON Ventes_honoraires.id_nego = Clients.idclient WHERE Ventes_honoraires.parrainage=False AND Ventes_honoraires.type <> 'Libre' AND Ventes_honoraires.id_vente=" + Request.QueryString["Ref"];

            DataRowCollection listeNego = c.exeRequetteOpen(req).Tables[0].Rows;

            c.Close();

            //si c'est le même négociateur
            if (listeNego.Count == 1)
            {
                tableNegoSolo.Visible = true;
                btnEnregistrerCommissionSolo.Visible = true;

                foreach (DataRow nego in listeNego)
                {
                    //on cherche si il existe une commission libre pour le nego
                    req = "SELECT COUNT(Ventes_honoraires.montant) FROM Ventes_honoraires WHERE Ventes_honoraires.type='Libre' AND Ventes_honoraires.id_nego=" + nego["idclient"].ToString() + "AND Ventes_honoraires.id_vente=" + Request.QueryString["Ref"];

                    OdbcConnection connect = new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                    OdbcCommand requett = new OdbcCommand(req, connect);

                    connect.Open();

                    Int32 count = (Int32)requett.ExecuteScalar();

                    connect.Close();

                    //si il y a déjà une commission libre
                    if (count != 0)
                    {
                        req = "SELECT Ventes_honoraires.montant FROM Ventes_honoraires WHERE Ventes_honoraires.type='Libre' AND Ventes_honoraires.id_nego=" + nego["idclient"].ToString() + "AND Ventes_honoraires.id_vente=" + Request.QueryString["Ref"];
                        
                        c.Open();

                        DataRow commissionLibre = c.exeRequetteOpen(req).Tables[0].Rows[0];

                        c.Close();

                        commissionNegoSolo.Text = (Convert.ToInt32(nego["montant"].ToString()) + Convert.ToInt32(commissionLibre["montant"].ToString())).ToString() + " €";
                        commissionLibreSolo.Text = commissionLibre["montant"].ToString();
                        commissionLibreSoloTextBox.Text = commissionLibreSolo.Text;
                    }
                    else
                    {
                        commissionNegoSolo.Text = nego["montant"].ToString() + " €";
                        commissionLibreSolo.Text = "0";
                        commissionLibreSoloTextBox.Text = commissionLibreSolo.Text;
                    }

                    nomNegoSolo.Text = nego["nom_client"].ToString().ToUpper() + " " + nego["prenom_client"].ToString();
                    idNegoSolo.Text = nego["idclient"].ToString();
                }

            }
            //si il y a deux négociateur différent
            else
            {
                tableDoubleNego.Visible = true;
                btnEnregistrerCommission.Visible = true;

                int flag = 1;

                foreach (DataRow nego in listeNego)
                {
                    if (flag == 1)
                    {   
                        //on cherche si il existe une commission libre pour le nego
                        req = "SELECT COUNT(Ventes_honoraires.montant) FROM Ventes_honoraires WHERE Ventes_honoraires.type='Libre' AND Ventes_honoraires.id_nego=" + nego["idclient"].ToString() + "AND Ventes_honoraires.id_vente=" + Request.QueryString["Ref"];

                        OdbcConnection connect = new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                        OdbcCommand requett = new OdbcCommand(req, connect);

                        connect.Open();

                        Int32 count = (Int32)requett.ExecuteScalar();

                        connect.Close();

                        if (count != 0)
                        {

                            req = "SELECT Ventes_honoraires.montant FROM Ventes_honoraires WHERE Ventes_honoraires.type='Libre' AND Ventes_honoraires.id_nego=" + nego["idclient"].ToString() + "AND Ventes_honoraires.id_vente=" + Request.QueryString["Ref"];

                            c.Open();

                            DataRow commissionLibre = c.exeRequetteOpen(req).Tables[0].Rows[0];

                            c.Close();

                            commissionNegoVente.Text = (Convert.ToInt32(nego["montant"].ToString()) + Convert.ToInt32(commissionLibre["montant"].ToString())).ToString() + " €";
                            commissionLibreVente.Text = commissionLibre["montant"].ToString();
                            commissionLibreVenteTextBox.Text = commissionLibreVente.Text;
                        }
                        else
                        {
                            commissionNegoVente.Text = nego["montant"].ToString() + " €";
                            commissionLibreVente.Text = "0";
                            commissionLibreVenteTextBox.Text = commissionLibreVente.Text;
                        }

                        nomNegoVente.Text = nego["nom_client"].ToString().ToUpper() + " " + nego["prenom_client"].ToString();
                        idNegoVente.Text = nego["idclient"].ToString();
                        flag = 2;
                    }
                    else
                    {
                        //on cherche si il existe une commission libre pour le nego
                        req = "SELECT COUNT(Ventes_honoraires.montant) FROM Ventes_honoraires WHERE Ventes_honoraires.type='Libre' AND Ventes_honoraires.id_nego=" + nego["idclient"].ToString() + "AND Ventes_honoraires.id_vente=" + Request.QueryString["Ref"];

                        OdbcConnection connect = new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                        OdbcCommand requett = new OdbcCommand(req, connect);

                        connect.Open();

                        Int32 count = (Int32)requett.ExecuteScalar();

                        connect.Close();

                        if (count != 0)
                        {

                            req = "SELECT Ventes_honoraires.montant FROM Ventes_honoraires WHERE Ventes_honoraires.type='Libre' AND Ventes_honoraires.id_nego=" + nego["idclient"].ToString() + "AND Ventes_honoraires.id_vente=" + Request.QueryString["Ref"];

                            c.Open();

                            DataRow commissionLibre = c.exeRequetteOpen(req).Tables[0].Rows[0];

                            c.Close();

                            commissionNegoAcq.Text = (Convert.ToInt32(nego["montant"].ToString()) + Convert.ToInt32(commissionLibre["montant"].ToString())).ToString() + " €";
                            commissionLibreAcq.Text = commissionLibre["montant"].ToString();
                            commissionLibreAcqTextBox.Text = commissionLibreAcq.Text;
                        }
                        else
                        {
                            commissionNegoAcq.Text = nego["montant"].ToString() + " €";
                            commissionLibreAcq.Text = "0";
                            commissionLibreAcqTextBox.Text = commissionLibreAcq.Text;
                        }

                        nomNegoAcq.Text = nego["nom_client"].ToString().ToUpper() + " " + nego["prenom_client"].ToString();
                        idNegoAcq.Text = nego["idclient"].ToString();
                    }
                }

            }

        }


    }

    protected void EnregistrerCommissionDuo(object sender, EventArgs e)
    {

        if (ajoutCommissionVente.Text != "")
        {
            string reqVente = "INSERT INTO Ventes_honoraires(`id_vente`, `id_nego`, `parrainage`, `type`, `montant`) VALUES('" + Request.QueryString["Ref"] + "','" + idNegoVente.Text + "'," + "false" + ",'" + "Libre" + "','" + ajoutCommissionVente.Text + "')";

            OdbcConnection c = new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            OdbcCommand requette = new OdbcCommand(reqVente, c);

            c.Open();

            requette.ExecuteNonQuery();

            c.Close();
        }

        if (ajoutCommissionAcq.Text != "")
        {
            string reqAcq = "INSERT INTO Ventes_honoraires(`id_vente`, `id_nego`, `parrainage`, `type`, `montant`) VALUES('" + Request.QueryString["Ref"] + "','" + idNegoAcq.Text + "'," + "false" + ",'" + "Libre" + "','" + ajoutCommissionAcq.Text + "')";
            
            OdbcConnection c = new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            OdbcCommand requette2 = new OdbcCommand(reqAcq, c);

            c.Open();

            requette2.ExecuteNonQuery();

            c.Close();
        }

        confirmationEnregistrement.Visible = true;
        Response.Redirect("./listeCommissions.aspx?action=add");

    }

    protected void EnregistrerCommissionSolo(object sender, EventArgs e)
    {

        string req = "INSERT INTO Ventes_honoraires(`id_vente`, `id_nego`, `parrainage`, `type`, `montant`) VALUES('" + Request.QueryString["Ref"] + "','" + idNegoSolo.Text + "'," + "false" + ",'" + "Libre" + "','" + ajoutCommissionSolo.Text + "')";

        OdbcConnection c = new OdbcConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        
        OdbcCommand requette = new OdbcCommand(req, c);

        c.Open();

        requette.ExecuteNonQuery();

        c.Close();

        confirmationEnregistrement.Visible = true;

    }
}