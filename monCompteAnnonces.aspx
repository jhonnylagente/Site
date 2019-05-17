<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="monCompteAnnonces.aspx.cs" Inherits="pages_monCompteAnnonces" Title="PATRIMONIUM : Mes annonces favorites" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table class="moncompte">
    <tr>
        <td class="moncompteG1">
            <b style="color:#31536c;"></b>
        </td>
        <td class="moncompteD1">
            <strong>Ma sélection</strong>
        </td>
    </tr>

    <tr >
        <td class="moncompteG">
            <% Membre member = (Membre)Session["Membre"]; %>
            <!-- Menu de liens à gauche -->
            <%--<%if(member.STATUT == "ultranego" || member.STATUT == "nego" || member.STATUT == "nego_agence")
              { %>
            <!--#include file="./menumoncompte.aspx"-->
            <%} %>
            <%else
              { %>
            <!--#include file="./menumoncompte1.aspx"-->
            <%} %>  --%>   
        </td>
        <td  class="moncompteD">
        <%
            //récupération de la racine du site web pour la vérificaton de la présence des images :
            Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c.Open();
            System.Data.DataSet ds = c.exeRequette("Select * from Environnement");
            c.Close();

            String racine_site = (String)ds.Tables[0].Rows[0]["Chemin_racine_site"];
            
            System.Collections.Generic.IList<Bien> memberAnnonce = MembreDAO.getAnnonceMembre(member);
            System.Collections.Generic.IEnumerator<Bien> b = memberAnnonce.GetEnumerator();

            string path = "";
            int indexF = -1;
            int indexFin = -1;
            int indexFinEuro = -1;
            String Francs = "";
            String euro = "";
            double prixFranc = 0;
            /*if(b.Current.NEGOCIATEUR != "")
                           {
                              
                                //Si l'annonce a été envoyée par un nego, on récupère dans la table Clients les coordonnées de ce nego.   
                                int idclient = b.Current.IDCLIENT;
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
                                         Response.Write("<STRONG>Reférence : </STRONG>" + b.Current.REFERENCE + " - tel: " 
                                                                                        + ligne["tel_client"].ToString() + "<br />");
                                         Response.Write("<STRONG>Contact : </STRONG>" + ligne["nom_client"] + " " + ligne["prenom_client"] + " - "
                                                        + ligne["id_client"].ToString() + "<br />");
                                    }
                                }
                           else if (b.Current.NUM_AGENCE != "")
                           {
                               Response.Write("<STRONG>Reférence : </STRONG>" + b.Current.REFERENCE + " - tel: " + b.Current.TEL_AGENCE + "<br />"
                               + "<STRONG>Contact : </STRONG>" + b.Current.NOM_AGENCE + " - " + b.Current.ADRESSE_AGENCE);
                               Response.Write(" - " + b.Current.CODE_POSTALE_AGENCE + "  " + b.Current.VILLE_AGENCE);
                           }*/

            while (b.MoveNext())
            {
                path = b.Current.REFERENCE.ToString();
                string srcJpg = racine_site + "images/" + path + "A.JPG";
                string sourceJpg = "../images/" + path + "A.JPG";

                if (System.IO.File.Exists(srcJpg) == false) sourceJpg = "../img_site/logo_320.jpg";

                if (b.Current.LOYER == 0)
                {
                    euro = b.Current.PRIX_VENTE.ToString();
                    euro += " €";
                }
                else
                {
                    euro = b.Current.LOYER.ToString();
                    euro += " € CC";
                }
                indexFinEuro = euro.Length;

                //if (indexF != -1) Francs = Francs.Remove(indexF, indexFin - indexF);
                //indexFin = Francs.Length;

                //do
                //{
                //    indexFin = indexFin - 3;
                //    if (indexFin > 0) Francs = Francs.Insert(indexFin, " ");
                //}
                //while (indexFin > 0);

                //do
                //{
                //    indexFinEuro = indexFinEuro - 3;
                //    if (indexFinEuro > 0) euro = euro.Insert(indexFinEuro, " ");
                //}
                //while (indexFinEuro > 0);

                Response.Write(
                                  "<div class=\"Resultat2-header\">"
                                      + "<div class=\"Resultat2-header-prix-franc\">"
                                      + "</div>"

                                      + "<div class=\"Resultat2-header-prix-euro\">"
                                          + "<a href=\"./fichedetail1.aspx?ref=" + b.Current.REFERENCE + "&page=3\">"
                                              + euro
                                              + "</a>"
                                      + "</div>"

                                      + "<div class=\"Resultat2-header-left\">"
                                              + "<a href=\"./fichedetail1.aspx?ref=" + b.Current.REFERENCE + "&page=3\">"
                                              + b.Current.CATEGORIE + " - " + b.Current.VILLE_BIEN + " - " + b.Current.NBRE_PIECE + " pièces - "
                                              + b.Current.S_HABITABLE + " m²"
                                          + "</a>"
                                      + "</div>"
                                  + "</div>"

                                  + "<div class=\"Resultat2\">"
                                      + "<div class=\"Resultat2-photo\">"
                                          + "<a class=\"lienImage\" href=\"./fichedetail1.aspx?ref=" + b.Current.REFERENCE + "&page=3\"> <img alt=\"photo\" src=" + sourceJpg + "  /></a>"
                                      + "</div>"
                                      + "<div class=\"Resultat2-text\">"
                                         + b.Current.TEXTE_INTERNET + "<br />" + "<br />");
                                         if(b.Current.NEGOCIATEUR != "")
                           {
                              
                                //Si l'annonce a été envoyée par un nego, on récupère dans la table Clients les coordonnées de ce nego.   
                                int idclient = b.Current.IDCLIENT;
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
                                         Response.Write("<STRONG>Reférence : </STRONG>" + b.Current.REFERENCE + " - tel: " 
                                                                                        + ligne["tel_client"].ToString() + "<br />");
                                         Response.Write("<STRONG>Contact : </STRONG>" + ligne["nom_client"] + " " + ligne["prenom_client"] + " - "
                                                        + "<A HREF=mailto:" + ligne["id_client"].ToString() + ">" + ligne["id_client"].ToString() + "</A>" + "<br />");
                                    }
                                }
                           else if (b.Current.NUM_AGENCE != "")
                           {
                               Response.Write("<STRONG>Reférence : </STRONG>" + b.Current.REFERENCE + " - tel: " + b.Current.TEL_AGENCE + "<br />"
                               + "<STRONG>Contact : </STRONG>" + b.Current.NOM_AGENCE + " - " + b.Current.ADRESSE_AGENCE);
                               Response.Write(" - " + b.Current.CODE_POSTALE_AGENCE + "  " + b.Current.VILLE_AGENCE);
                           }
                                 Response.Write("</div>"
                                                  + "</div>"
                                                  + "<br/>"
                              );
            }
        %>
        </td>
    </tr>
</table>
       
</asp:Content>
