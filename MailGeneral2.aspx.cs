using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Odbc;
using System.Web;
using System.IO;

public partial class pages_Default2 : System.Web.UI.Page
{
    Connexion c = new Connexion();
    protected Membre member= null;
    private String ListPieceJointes="";


    protected void Page_Load(object sender, EventArgs e)
    {
        //ButtonConfirmation.Visible = false;
        if( Session["Membre"] != null) member = (Membre)Session["Membre"];
        if (member == null || member.STATUT != "ultranego")
        {
            Response.Redirect("./rechercher.aspx");
            Response.End();
        }

        //Pre remplissage des champs
        string template = System.IO.File.ReadAllText(MapPath(@"~\mailGeneral\Templates\default.html"));
        TBCorp.Text = template;
 
        TBTitre.Text = "La lettre de PATRIMO";
    }


    protected void confirmerMail(object sender, EventArgs e)
    {

        
        
        
        /*if ((bool)Session["IsMailConfirmed"]) 
        {
            Session["IsMailConfirmed"]=false;
            envoyerMessage();        
        }
        else
        {
            
            string msg = "Vous souhaitez envoyer un mail à : ";
            if (CBDestNego.Checked) msg += "Négo , ";
            if (CBDestUltraNego.Checked) msg += "UltraNégo , ";
            if (CBDestOther.Checked) msg += "Clients lambda , ";
            if (ListPieceJointes != "") msg += "avec comme fichiers joints: " + ListPieceJointes;
            else msg += "sans piece jointe; ";
            /*LabelResultat.Text = msg;
            ButtonConfirmation.Visible = true;
            ButtonEnvoyer.Visible = false;
            ConfirmationPanel.Visible = true;*/
        //} */

        //envoyerMessage();


    }

 
    protected void addPJ(int idMail)
    {

        HttpFileCollection fileCollection = Request.Files;
        for (int i = 0; i < fileCollection.Count; i++)
        {
            HttpPostedFile uploadfile = fileCollection[i];
            string fileName = Path.GetFileName(uploadfile.FileName);
            if (uploadfile.ContentLength > 0)
            {
                uploadfile.SaveAs(Server.MapPath("~/mailGeneral/") +idMail+"_"+ fileName);
                ListPieceJointes += Server.MapPath("~/mailGeneral/") + idMail + "_" + fileName + ";";
            }
        }
    }


    protected void envoyerMessage(object sender, EventArgs e)
    {
        infoPanel.Visible = true;
        lblInfo.Text = "Votre email a bien été envoyé !"; 

        try
            {
                //Get idmail
                OdbcCommand selectLast = new OdbcCommand("select max(id) as idMax from MailGeneral");
                DataSet ds = c.exeRequetteParametree(selectLast);
                int idMail = 0;
                DataRow dr = ds.Tables[0].Rows[0];
                if (dr["idMax"].ToString() != "") idMail = (int)dr["idMax"];
                idMail++;

                //Traitement piece jointe
                addPJ(idMail);
                
                //Initialisation de quelques autres parametres...
                String corpMail = TBCorp.Text;
                String titreMail = TBTitre.Text;
                
                int destinataireMail=1;

                switch (DestList.SelectedValue)
                {
                    case "1": destinataireMail = 1; break;
                    case "2": destinataireMail = 2; break;
                    case "3": destinataireMail = 3; break;
                    case "4": destinataireMail = 4; break;
                    case "5": destinataireMail = 5; break;
                    default: destinataireMail = 1; break;
                }

                //Generation de la requete
                OdbcCommand insertMail = new OdbcCommand(
                    "insert into MailGeneral (ID,fichier,corp,header,destinataire,etat)"
                  + "values(?,?,?,?,?,?)");
                OdbcParameter paramID = new OdbcParameter("", DbType.Int32);
                paramID.Value = idMail;
                OdbcParameter paramFichier = new OdbcParameter("", DbType.String);
                //paramFichier.Value = pathFile;
                paramFichier.Value = ListPieceJointes;
                //paramFichier.Value = Session["StringPJ"];
                OdbcParameter paramCorp = new OdbcParameter("", OdbcType.NText);
                paramCorp.Value = corpMail;
                //paramCorp.Value = CBDestUltraNego.Checked.ToString();
                OdbcParameter paramHeader = new OdbcParameter("", OdbcType.NText);
                paramHeader.Value = titreMail;
                //paramHeader.Value = CBDestNego.Checked.ToString();
                OdbcParameter paramDestinataire = new OdbcParameter("", DbType.String);
                paramDestinataire.Value = destinataireMail;
                OdbcParameter paramEtat = new OdbcParameter("", DbType.Int32);
                paramEtat.Value = 0;

                insertMail.Parameters.Add(paramID);
                insertMail.Parameters.Add(paramFichier);
                insertMail.Parameters.Add(paramCorp);
                insertMail.Parameters.Add(paramHeader);
                insertMail.Parameters.Add(paramDestinataire);
                insertMail.Parameters.Add(paramEtat);

                c.exeRequetteParametree(insertMail);

                
            }
            catch (Exception ex)
            {
                lblInfo.Text = "Une erreur est survenue : " + ex.Message.ToString();
            }
    }
}