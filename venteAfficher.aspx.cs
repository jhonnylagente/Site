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

public partial class venteAfficher : System.Web.UI.Page
{
    protected DataRow vente;
    protected DataRowCollection listeHonoraire;
	protected bool venteEtMandat = false;
	protected Membre membre;
	protected string[] ratioParrain = { "", "5", "4", "3", "2", "1", "0,5", "0,25" };
	protected int totalCommission = 0;
	
    protected void Page_Load(object sender, EventArgs e)
    {
		membre = (Membre)Session["membre"];
        if (membre == null || (membre.STATUT != "ultranego" && membre.STATUT != "nego") || Request.QueryString["id"] == null)
            Response.Redirect("recherche.aspx");

        string requete = "SELECT Ventes.*,Biens.*, id_client,tel_client,nom_client,prenom_client,nom,prenom,tel,portable,mail FROM Biens,Ventes,Clients,Acquereurs WHERE Biens.ref = ref_bien AND Ventes.id_nego = Clients.idclient AND id_acq = id_acquereur AND ID = " + Request.QueryString["id"];
        string requete2 = "SELECT Ventes_honoraires.*,nom_client,prenom_client FROM Ventes_honoraires,Clients WHERE id_nego = Clients.idclient AND id_vente = " + Request.QueryString["id"] + " ORDER BY type,montant DESC";
        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();
        vente = c.exeRequetteOpen(requete).Tables[0].Rows[0];
        listeHonoraire = c.exeRequette(requete2).Tables[0].Rows;
		venteEtMandat = (listeHonoraire[0]["type"].ToString() == "Mandat et Vente");
		
		foreach(DataRow ligne in listeHonoraire)
		{
			totalCommission += (int)ligne["montant"];
		}
		
		System.Data.DataSet ds2 = c.exeRequetteOpen("Select * from Environnement");
		String racine_site = (String)ds2.Tables[0].Rows[0]["Chemin_racine_site"];
		
		string filePathActe = racine_site + "Ventes\\" + Request.QueryString["id"] + "_acte.pdf";
		string filePathPromesse = racine_site + "Ventes\\" + Request.QueryString["id"] + "_promesse.pdf";
		
		if (System.IO.File.Exists(filePathPromesse))
			oldPromesse.Text = "<span id='newPromesse'><a href='../Ventes/"+Request.QueryString["id"]+"_promesse.pdf'>Voir Fichier</a></span>";
		else
			oldPromesse.Text = "Aucun fichier";
		
		if (System.IO.File.Exists(filePathActe))
			oldActe.Text = "<span id='newPromesse'><a href='../Ventes/"+Request.QueryString["id"]+"_acte.pdf'>Voir Fichier</a></span>";
		else
			oldActe.Text = "Aucun fichier";
		
		
        c.Close();
        c = null;
    }
	
	protected string espaceNombre(string nombre)
	{
		string prixFormat = "";
		int k = 0;
		if(nombre.Length >3)
		{
			while((k+1)*3 < nombre.Length)
			{
				prixFormat = nombre.Substring((nombre.Length -(k+1)*3), 3) + " " +prixFormat;
				k++;
			}
			prixFormat = nombre.Substring(0, nombre.Length - k*3) + " " +prixFormat;
		}
		else prixFormat = nombre;
		
		return prixFormat;
	}
}
