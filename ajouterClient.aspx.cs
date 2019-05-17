using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using System.Data;

public partial class pages_AjouterClient : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Connexion c1 = new Connexion();
        OdbcCommand selectAllNego = new OdbcCommand("select * from Clients where statut ='ultranego' or statut = 'nego' order by nom_client");
        c1.Open();
        DataRowCollection reader = c1.exeRequetteParametree(selectAllNego).Tables[0].Rows;
        c1.Close();

        foreach (DataRow nego in reader)
        {
            ListItem unNegociateur = new ListItem(nego["nom_client"].ToString() + "  " + nego["prenom_client"].ToString(), nego["idclient"].ToString());
            DropDownListParain.Items.Add(unNegociateur);
          //  if (unNegociateur.Value == "5") unNegociateur.Selected = true;
        }
        foreach (DataRow ultranego in reader)
        {
            ListItem unUltraNegociateur = new ListItem(ultranego["nom_client"].ToString() + "  " + ultranego["prenom_client"].ToString(), ultranego["idclient"].ToString());
            DropDownListParain.Items.Add(unUltraNegociateur);
            //  if (unNegociateur.Value == "5") unNegociateur.Selected = true;
        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        LabelErrorLogin.Text = "ptmadre";
        LabelErrorLogin.Visible = true;
    }
    protected void ButtonEnregistrer_Click1(object sender, EventArgs e)
    {
       
    }
    protected void RadioButtonMme_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void RadioButtonMlle_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void RadioButtonMr_CheckedChanged(object sender, EventArgs e)
    {

    }
}