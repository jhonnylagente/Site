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


public partial class MasterPage : System.Web.UI.MasterPage
{
    protected Membre member;

    protected override void OnInit(EventArgs e)
    {
        string[] tab = new string[54];
        for (int i = 0; i < tab.Length; i++) tab[i] = "azertyuiop";//pour être sur que cette chaine n'est pas dans l'adresse
        tab[0] = "affichagesrecherche.aspx";
        tab[1] = "ajout_acquereur.aspx";
        tab[2] = "ajout_nego.aspx";
        tab[3] = "ajout_nego_loc.aspx";
        tab[4] = "ajout_visite.aspx";
        tab[5] = "ajout_visite_old.aspx";
        tab[6] = "ajoutSelection.aspx";
        tab[7] = "alerteMail.aspx";
        tab[8] = "Avenant.aspx";
        tab[9] = "bon_de_visite.aspx";
        tab[10] = "choixtransaction.aspx";
        tab[11] = "completerprofil.aspx";
        tab[12] = "compteAcquereur.aspx";
        tab[13] = "ficheCommerciale.aspx";
        //tab[14] = "fichedetail1.aspx";
        tab[15] = "ficheNegociateur.aspx";
        tab[16] = "historique_visite.aspx";
        tab[17] = "liste_acquereur.aspx";
        tab[18] = "MailGeneral.aspx";
        tab[19] = "MandatConfiance.aspx";
        tab[20] = "MandatExclusif.aspx";
        tab[21] = "MandatExclusifLocation.aspx";
        tab[22] = "MandatRecherche.aspx";
        tab[23] = "MandatSemiExclusif.aspx";
        tab[24] = "MandatSemiExclusifLocation.aspx";
        tab[25] = "MandatSimple.aspx";
        tab[26] = "MandatSimpleLocation.aspx";
        tab[44] = "modifier_acquereur.aspx";
        tab[27] = "modifier_nego.aspx";
        tab[28] = "modifier_nego_loc.aspx";
        tab[29] = "modifierCompte.aspx";
        tab[30] = "monCompte.aspx";
        tab[31] = "monCompteAcquereur.aspx";
        tab[32] = "monCompteAjout.aspx";
        tab[33] = "monCompteAlertes.aspx";
        tab[34] = "monCompteAnnonces.aspx";
        tab[35] = "monComptechoixtransaction.aspx";
        tab[36] = "monComptecompleterprofil.aspx";
        tab[37] = "monCompteCoordonnees.aspx";
        tab[38] = "moncomptetableaudebord_bis.aspx";
        tab[39] = "monComptevisite.aspx";
        tab[40] = "monComteCoordonnees.aspx";
        tab[41] = "parrains.aspx";
        tab[42] = "rapprochement.aspx";
        tab[43] = "reactivervente.aspx";
        tab[45] = "suppressionAlerte.aspx";
        tab[46] = "supprimeracquereur.aspx";
        tab[47] = "supprimervente.aspx";
        tab[48] = "supprimervisite.aspx";
        tab[50] = "supSelection.aspx";
        tab[51] = "tableaudebord.aspx";
        tab[52] = "tableaudebord_bis_sauv.aspx";
        tab[53] = "vieux.aspx";

        for (int i = 0; i < tab.Length; i++)
        {
            if (Request.Url.PathAndQuery.IndexOf(tab[i]) != -1)// = -1 si tab n'est pas dans l'adresse de la page
            {
                if (Session["logged"] != null)
                {
                    if ( Session["logged"].Equals(true))
                    {
                        member = (Membre)Session["Membre"];
                    }
                    else
                    {
                        Response.Redirect("./recherche.aspx");
                    }
                }
                else
                {
                    Response.Redirect("./recherche.aspx");
                    break;
                }
            }
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        if (Session["logged"].Equals(true))
        {
            Session.Abandon();
            Response.Redirect("./inscriptionAccueil.aspx");
        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["ClientID"] != null)
        {
            HttpCookie ClientIDcookie = Request.Cookies["ClientID"];
            Membre member = null;
            //LabelClientID.Text = ClientIDcookie.Value.ToString();
            member = MembreDAO.getMember(ClientIDcookie.Value);
            Session["membre"] = member;
            Session["logged"] = true;
            if (member.STATUT == "nego" || member.STATUT == "ultranego")
            {
                Response.Redirect("./moncomptetableaudebord_bis.aspx");
            }
            else
            {
                Response.Redirect("./recherche.aspx");
            }
            
        }
        else
        {
            Response.Redirect("./inscriptionAccueil.aspx");
        }
    }
}
