<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="supSelection.aspx.cs" Inherits="supSelection" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<table border="0" cellpadding="10px" cellspacing="10px">
    <tr>
        <td>
            <b style="color:#31536c;">Mes options</b>
        </td>
        <td>
            <table>
                <tr>
                    <td style="width: 640px;text-align:center">
                        <span style="color:#31536c"><strong>Suppression d'une annonce de ma sélection</strong></span>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

<table border="1" cellpadding="10px" cellspacing="10px">
    <tr style="margin-left:5px;" valign="top" >
        <td style="border:none" valign="top">
            <a href="./moncompte.aspx" style="cursor: hand"><img src='../img_site/fleche2.ico' border='0' width='15px' height='13px'> Mon compte accueil</a><br /><br />
            <a href="./moncomteCoordonnees.aspx" style="cursor: hand"><img src='../img_site/fleche2.ico' border='0' width='15px' height='13px'> Modifier mes coordonnées</a><br /><br />
            <a href="./monCompteAnnonces.aspx" style="cursor: hand"><img src='../img_site/fleche2.ico' border='0' width='15px' height='13px'> Consulter ma sélection</a><br /><br />
            <a href="./lettre.aspx" style="cursor: hand"><img src='../img_site/fleche2.ico' border='0' width='15px' height='13px'> Newsletter</a><br /><br />
            <a href="./monCompteDeconnexion.aspx" style="cursor: hand"><img src='../img_site/fleche2.ico' border='0' width='15px' height='13px'> Se déconnecter</a>        
        </td>
        <td  valign="top" style="border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
            <span style="color:#CC3333">Voulez-vous vraiment supprimer cette annoces ?</span><br /><br />
                       
            <%
                string path = "";
                int indexF = -1;
                int indexFin = -1;
                int indexFinEuro = -1;
                String Francs = "";
                String euro = "";
                double prixFranc = 0;

                //récupération de la racine du site web pour la vérificaton de la présence des images :
                Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                c.Open();
                System.Data.DataSet ds = c.exeRequette("Select * from Environnement");
                c.Close();

                String racine_site = (String)ds.Tables[0].Rows[0]["Chemin_racine_site"]; 
                                               
                path = Request.Params["ref"].ToString();
                Bien b = BienDAO.getBien(path);
                string srcJpg = racine_site + "images/" + path + "A.JPG";
                string sourceJpg = "../images/" + path + "A.JPG";
                
                if (System.IO.File.Exists(srcJpg) == false) sourceJpg = "../img_site/logo_320.jpg";


                if (b.LOYER == 0)
                {
                    euro = b.PRIX_VENTE.ToString();
                    euro += " €";
                }
                else
                {
                    euro = b.LOYER.ToString();
                    euro += " € CC";
                }

                indexFin = Francs.Length;
                indexFinEuro = euro.Length;

                Response.Write(
                                  "<div class=\"Resultat2-header\">"
                                      + "<div class=\"Resultat2-header-prix-franc\">"
                                      + "</div>"

                                      + "<div class=\"Resultat2-header-prix-euro\">"
                                          + "<a href=\"./fichedetail1.aspx?ref=" + b.REFERENCE + "&page=3\">"
                                              + euro
                                              + "</a>"
                                      + "</div>"

                                      + "<div class=\"Resultat2-header-left\">"
                                              + "<a href=\"./fichedetail1.aspx?ref=" + b.REFERENCE + "&page=3\">"
                                              + b.CATEGORIE + " - " + b.VILLE_BIEN + " - " + b.NBRE_PIECE + " pièces - "
                                              + b.S_HABITABLE + " m²"
                                          + "</a>"
                                      + "</div>"
                                  + "</div>"

                                  + "<div class=\"Resultat2\">"
                                      + "<div class=\"Resultat2-photo\">"
                                          + "<a class=\"lienImage\" href=\"./fichedetail1.aspx?ref=" + b.REFERENCE + "&page=3\"> <img alt=\"photo\" src=" + sourceJpg + " style=\" border:none; float:left; width:128px; height:96px\" /></a>"
                                      + "</div>"
                                      + "<div class=\"Resultat2-text\">"
                                         + b.TEXTE_INTERNET + "<br />" + "<br />");
                                 if(b.NEGOCIATEUR != "")
                           {
                              
                                //Si l'annonce a été envoyée par un nego, on récupère dans la table Clients les coordonnées de ce nego.   
                                int idclient = b.IDCLIENT;
                                String requette = "select nom_client, prenom_client, tel_client, id_client from Clients where `idclient`=" + idclient;
                                System.Data.DataSet ds2 = null;

                                Connexion c2 = null;

                                c2 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                                c2.Open();
                                ds2 = c2.exeRequette(requette);
                                c2.Close();
                                c2 = null;

                                    System.Data.DataRowCollection dr2 = ds2.Tables[0].Rows;

                                    foreach (System.Data.DataRow ligne in dr2)
                                    {
                                         Response.Write("<STRONG>Reférence : </STRONG>" + b.REFERENCE + " - tel: " 
                                                                                        + ligne["tel_client"].ToString() + "<br />");
                                         Response.Write("<STRONG>Contact : </STRONG>" + ligne["nom_client"] + " " + ligne["prenom_client"] + " - "
                                                        + "<A HREF=mailto:" + ligne["id_client"].ToString() + ">" + ligne["id_client"].ToString() + "</A>" + "<br />");
                                    }
                                }
                           else if (b.NUM_AGENCE != "")
                           {
                               Response.Write("<STRONG>Reférence : </STRONG>" + b.REFERENCE + " - tel: " + b.TEL_AGENCE + "<br />"
                               + "<STRONG>Contact : </STRONG>" + b.NOM_AGENCE + " - " + b.ADRESSE_AGENCE);
                               Response.Write(" - " + b.CODE_POSTALE_AGENCE + "  " + b.VILLE_AGENCE);
                           }
                                 Response.Write("</div>"
                                                  + "</div>"
                                                  + "<br/>"
                              );
                
            %>
             
            <div style="float:left">
                <asp:Button ID="ButtonSupprimer" runat="server" Text="oui" OnClick="ButtonSupprimer_Click" />
                <asp:Button ID="ButtonRetour" runat="server" Text="non" OnClick="ButtonRetour_Click" />
            </div>
            <br />
        </td>
    </tr>
</table>

</asp:Content>

