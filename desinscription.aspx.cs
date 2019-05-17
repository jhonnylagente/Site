using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Odbc;
using System.Security.Cryptography;
using System.Text;

public partial class pages_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        labelReponse.Font.Bold = true;
        int idAlerte;

        if (Session["Membre"] != null) labelRetour.Text = "Retourner à mes alertes:";
        else labelRetour.Text = "Retourner au menu principal :";


        if (Int32.TryParse(Request.QueryString["id"], out idAlerte))
        {
            Connexion c = new Connexion();
            OdbcCommand verifierAlerte = new OdbcCommand("select * from alerte_mail where id_alerte_mail = ?");
            OdbcParameter paramID = new OdbcParameter("",DbType.Int32);
            paramID.Value = idAlerte;
            verifierAlerte.Parameters.Add(paramID);
            DataRowCollection drc = c.exeRequetteParametree(verifierAlerte).Tables[0].Rows;

            //condition a verifier 
            byte[] plainMail = Encoding.UTF8.GetBytes(drc[0]["id_Client"].ToString());
            byte[] plainIdAlerte = Encoding.UTF8.GetBytes(idAlerte.ToString());
            byte[] plainTextWithSaltBytes = new byte[plainMail.Length + plainIdAlerte.Length];

            for (int i = 0; i < plainIdAlerte.Length; i++)
                plainTextWithSaltBytes[i] = plainIdAlerte[i];

            for (int i = 0; i < plainMail.Length; i++)
                plainTextWithSaltBytes[plainIdAlerte.Length + i] = plainMail[i];

            HashAlgorithm hash = new SHA256Managed();
            byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);
            string hashValue = Convert.ToBase64String(hashBytes);

            string cle = Request.QueryString["cle"];
            if (cle != hashValue)
            {
                labelReponse.Text = "pas d'alerte correspondant";
                Response.End();
            }

            if (drc.Count == 0)
            {
                labelReponse.Text = "pas d'alerte correspondant";
                Response.End();
            }

            //toutes les conditons ont été verifiées
            OdbcCommand fermerAlerte = new OdbcCommand("update alerte_mail set actif = false where id_alerte_mail = ?");
            OdbcParameter paramId2 = new OdbcParameter("",DbType.Int32);
            paramId2.Value = idAlerte;
            fermerAlerte.Parameters.Add(paramId2);
            c.exeRequetteParametree(fermerAlerte);
            labelReponse.Text = "Votre alerte a été desactivée avec succès !";
        }
        else
        {
            labelReponse.Text = "Le numéro d'alerte est invalide !";
        }

    }

    protected void Redirect(object sender, EventArgs e)
    {
        if (Session["Membre"] != null) Response.Redirect("./monCompteAlertes.aspx");
        else Response.Redirect("./recherche.aspx");
        Response.End();
    }
}