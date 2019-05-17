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

        if (Session["Membre"] != null) labelRetour.Text = "Retourner à mes alertes:";
        else  labelRetour.Text = "Retourner au menu principal :";
           
        
        int idAlerte;
        string type=Request.QueryString["type"];


        if (Int32.TryParse(Request.QueryString["id"], out idAlerte))
        {
            //Connexion à la BDD et recuperation de l'alerte
            Connexion c = new Connexion();
            OdbcCommand verifierAlerte = new OdbcCommand("select * from alerte_mail where id_alerte_mail = ?");
            OdbcParameter paramID = new OdbcParameter("", DbType.Int32);
            paramID.Value = idAlerte;
            verifierAlerte.Parameters.Add(paramID);
            DataRowCollection drc = c.exeRequetteParametree(verifierAlerte).Tables[0].Rows;


            if (drc.Count != 0)
            {
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
                if ((cle != hashValue) || (drc.Count == 0))
                {
                    labelReponse.Text = "Lien invalide: pas d'alerte correspondant";
                    Response.End();
                }


                if (type == "SUP")
                {
                    /*
                    OdbcCommand fermerAlerte = new OdbcCommand("update alerte_mail set actif = false where id_alerte_mail = ?");
                    OdbcParameter paramId2 = new OdbcParameter("", DbType.Int32);
                    paramId2.Value = idAlerte;
                    fermerAlerte.Parameters.Add(paramId2);
                    c.exeRequetteParametree(fermerAlerte);*/

                    AlerteMailDAO.removeAlerteMail(idAlerte);
                    labelReponse.Text = "Votre alerte a été supprimée avec succes !";

                }
                else if (type == "ACT")
                {
                    //toutes les conditons ont été verifiées
                    OdbcCommand fermerAlerte = new OdbcCommand("update alerte_mail set dateEnregistrement = ?, actif=true where id_alerte_mail = ?");
                    OdbcParameter paramDate = new OdbcParameter("", DbType.DateTime);
                    paramDate.Value = DateTime.Now;
                    fermerAlerte.Parameters.Add(paramDate);
                    OdbcParameter paramId2 = new OdbcParameter("", DbType.Int32);
                    paramId2.Value = idAlerte;
                    fermerAlerte.Parameters.Add(paramId2);
                    c.exeRequetteParametree(fermerAlerte);
                    labelReponse.Text = "Votre alerte a été reactualisée avec succès !";

                }
                else labelReponse.Text = "Lien invalide";
            }
            else labelReponse.Text = "L'alerte que vous avez demandés n'existe pas ou a déjà été supprimée !";
        }
        else
        {
            labelReponse.Text = "Numero d'alerte invalide";
        }
        
    }

    protected void Redirect(object sender, EventArgs e)
    {
        if (Session["Membre"] != null) Response.Redirect("./monCompteAlertes.aspx");
        else Response.Redirect("./recherche.aspx");
        Response.End();
    }

}