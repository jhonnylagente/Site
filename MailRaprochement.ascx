<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MailRaprochement.ascx.cs" Inherits="pages_MailRaprochement" %>
<asp:PlaceHolder ID="PlaceHolder1" runat="server">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />

</head>
<body>
<%
    int LOYER = 0;
    string nbpiece = "";
    string reference = Request.QueryString["idAcq"];
    Bien b = BienDAO.getBien(reference);
    String path = b.REFERENCE.ToString();

    string relativePath = "/images/";
    string absolutePath = "~/images/";
    String JpgA = path + "A.JPG";
    %>
    
     <!-- debut generation -->
     <br /> 

<div class="fiche" style="width:100%;
    max-width:600px;
    border-right:#000000 1px solid;
    border-top:#000000 1px solid;
    border-left:#000000 1px solid;
    border-bottom:#000000 1px solid;
    height:auto;
    margin:auto;">

    <div class="ficheDetail" style="font-size:20px;
    font-family:Verdana;
    color:Black;
    background-color:White;
    width:100%;">

	<img style='margin-top:-3px;margin-bottom:-3px' src='http://<%=hote%>/img_site/drapeau/<%=b.CODEPAYS%>.png' alt='<%=b.CODEPAYS%>'/>
    <a href= 'https://www.google.fr/maps/place/<%=b.VILLE_BIEN %>+<%=b.PAYS%>' target="_blank"><img style='margin-top:-3px;margin-bottom:-3px' src='http://<%=hote%>/img_site/globe.png' alt='<%=b.VILLE_BIEN%>' height="20px" width="20px"/></a>
       
        <% 
            String type_bien = "";
            String nbpieces = "";
         
			if(b.CATEGORIE == "")
			{
				if (b.TYPE_BIEN == "A")
				{
					type_bien = "Appartement";
				}
				else if (b.TYPE_BIEN == "M")
				{
					type_bien = "Maison";
				}
				else if (b.TYPE_BIEN == "L")
				{
					type_bien = "Local";
				}
				else if (b.TYPE_BIEN == "T")
				{
					type_bien = "Terrain";
				}
				else if (b.TYPE_BIEN == "I")
				{
					type_bien = "Immeuble";
				}
			}
			else type_bien = b.CATEGORIE.ToString();
			
			
			if(b.NBRE_PIECE != 0)
			{
				nbpieces = b.NBRE_PIECE + " pièces - ";
			}
			
            if ((Session["Transaction"].ToString() == "achat") && (b.TYPE_BIEN == "A" || b.TYPE_BIEN == "M"  ))
            {
                %><%=type_bien + " - " + nbpieces + b.S_HABITABLE + " m² - " + b.CODE_POSTAL_BIEN + " " + b.VILLE_BIEN + " - " + b.PRIX_VENTE + " €"%><%             
            }
			if ((Session["Transaction"].ToString() == "achat") && (b.TYPE_BIEN == "T" || b.TYPE_BIEN == "I"|| b.TYPE_BIEN == "L"  ))
            {
				if(b.NBRE_PIECE == 0)
				{
					if(b.S_TERRAIN == 0)
					{
						%><%=type_bien + " - " + nbpiece + b.CODE_POSTAL_BIEN + " " + b.VILLE_BIEN + " - " + b.PRIX_VENTE + " €"%><%             
					}
					else %><%=type_bien + " - " + nbpiece + b.S_TERRAIN + " m² - " + b.CODE_POSTAL_BIEN + " " + b.VILLE_BIEN + " - " + b.PRIX_VENTE + " €"%><%             
				}
				else
				{
					nbpiece = b.NBRE_PIECE + " pièce(s) - ";
					if(b.S_TERRAIN == 0)
					{
						%><%=type_bien + " - " + nbpiece + b.CODE_POSTAL_BIEN + " " + b.VILLE_BIEN + " - " + b.PRIX_VENTE + " €"%><%             
					}
					else %><%=type_bien + " - " + nbpiece + b.S_TERRAIN + " m² - " + b.CODE_POSTAL_BIEN + " " + b.VILLE_BIEN + " - " + b.PRIX_VENTE + " €"%><%             
				}
			}
            if(Session["Transaction"].ToString() == "location")
            {
				
				String pathe = b.REFERENCE.ToString();
				String requette = "SELECT Biens.* FROM Biens WHERE (((Biens.ref)='" + b.REFERENCE.ToString() + "'));";
				System.Data.DataSet ds1 = null;
				Connexion c1 = null;
				c1 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
				c1.Open();
				ds1 = c1.exeRequette(requette);
				c1.Close();
				c1 = null;
				System.Data.DataRowCollection dr1 = ds1.Tables[0].Rows;
				foreach (System.Data.DataRow ligne in dr1)
				{
					LOYER = (int)ligne["loyer_cc"];
				}
			
                %>
                
                
                <%=b.CATEGORIE + " - " + b.NBRE_PIECE + " pièces - " + b.S_HABITABLE + " m² - " + b.CODE_POSTAL_BIEN + " " + b.VILLE_BIEN + " - " + LOYER + " € CC"%><%           
            }
        %>     
    </div>
    <table>
        <tr>
            <td>
                <div class="fichePhoto" style="color:White; max-width:250px; margin-right: 10px; overflow:hidden;">
                    <div class="fichePhotoGauche" style="height:100%; width:100%; margin-left:2px;">
                        <div id="centerImg">
                        <%
                            if (testFile(absolutePath + JpgA) == false)
                            {
                                JpgA = "http://" + hote + "/img_site/images_par_defaut/" + b.TYPE_BIEN + ".jpg";
                            }
                            else
                            {
                                JpgA = "http://" + hote + relativePath + JpgA;
                            }
                         %>
                         <a href="http://<%=hote%>/pages/fichedetail1.aspx?ref=<%=b.REFERENCE%>&page=2" style="max-width:100%; max-height:100%;"><img alt="" id="grosseImage" src="<%= JpgA %>" /></a>
                        </div>
                        <br />
                    </div>
                </div>
            </td>
            <td align="justify" style="vertical-align: top;" > 
                <p><%=b.TEXTE_INTERNET%></p>
                <a style="text-align:left;" href="http://<%=hote%>/pages/fichedetail1.aspx?ref=<%=b.REFERENCE%>&page=2">Plus d'informations</a> 
            </td>
        </tr>
    </table>                                                                                                                                                        
    <!-- CONSO ENERGETIQUE -->
     <% if (b.LETTRE_CONSO != "" && b.LETTRE_ENERGIE != "" && b.NOMBRE_CONSO != 0 && b.NOMBRE_ENERGIE != 0)
        { %>
    
        <table class="dpe" style ="font-size:10pt; border-collapse:collapse; font-family:Times New Roman;" >
            <tr>
                <td class="titre_dpe" colspan="4">
                    <strong>Diagnostic de performance énergétique</strong>
                </td>
            </tr>
            
            <tr >
                <td class="case_dpe0" colspan="2" >
                    <strong>Consommation énergétique</strong>  <br />(en énergie primaire) pour le chauffage, la production d'eau sanitaire et le refroidissement
                </td>
                <td class="case_dpe1" colspan="2" >
                    <strong>Emission des gaz à effet de serre</strong> <br /> (GES) pour le chauffage, la production d'eau sanitaire et le refroidissement <br /><br />
                </td>   
            </tr>
            
            <tr >
                <td class="case_dpe2">
                    <strong>Consommation<br /> réelle :</strong> 
                </td>
                <td class="case_dpe3">
                   
                  <strong><% if (b.NOMBRE_CONSO != 0)
                             { %><%=b.NOMBRE_CONSO%><% }
                             else
                             { %><%="N.C"%><%} %> 
                  </strong> kWh/m².an
                </td>
                <td class="case_dpe4">
                    <strong>Estimation des émissions :</strong> 
                </td>   
                <td class="case_dpe5">
                  <strong><% if (b.NOMBRE_ENERGIE != 0) { %><%=b.NOMBRE_ENERGIE%><% } else %><%="N.C"%>
                  </strong> kg/m².an
                </td>
            </tr>
     <% } 
        if (b.LETTRE_CONSO != "" || b.LETTRE_ENERGIE != "")
        { %>
    <tr >
        <td class="case_dpe0" colspan="2" >
            <br />
            <% if (b.LETTRE_CONSO == "A") %><%="<img src=http://" + hote + "/img_dpe/high_quality/dpe/dpe_a.gif\"/HEIGHT=299 WIDTH=298>"%>
            <% if (b.LETTRE_CONSO == "B") %><%="<img src=http://" + hote + "/img_dpe/high_qualitY/dpe/dpe_b.gif\"/HEIGHT=299 WIDTH=298>"%> 
            <% if (b.LETTRE_CONSO == "C") %><%="<img src=http://" + hote + "/img_dpe/high_quality/dpe/dpe_c.gif\"/HEIGHT=299 WIDTH=298>"%>
            <% if (b.LETTRE_CONSO == "D") %><%="<img src=http://" + hote + "/img_dpe/high_quality/dpe/dpe_d.gif\"/HEIGHT=299 WIDTH=298>"%>
            <% if (b.LETTRE_CONSO == "E") %><%="<img src=http://" + hote + "/img_dpe/high_quality/dpe/dpe_e.gif\"/HEIGHT=299 WIDTH=298>"%>
            <% if (b.LETTRE_CONSO == "F") %><%="<img src=http://" + hote + "/img_dpe/high_quality/dpe/dpe_f.gif\"/HEIGHT=299 WIDTH=298>"%>
            <% if (b.LETTRE_CONSO == "G") %><%="<img src=http://" + hote + "/img_dpe/high_quality/dpe/dpe_g.gif\"/HEIGHT=299 WIDTH=298>"%>
        </td>
        <td class="case_dpe1" colspan="2" >
            <% if (b.LETTRE_ENERGIE == "A") %><%="<img src=http://" + hote + "/img_dpe/high_quality/ges/ges_a.gif\"/HEIGHT=299 WIDTH=298>"%>
            <% if (b.LETTRE_ENERGIE == "B") %><%="<img src=http://" + hote + "/img_dpe/high_quality/ges/ges_b.gif\"/HEIGHT=299 WIDTH=298>"%> 
            <% if (b.LETTRE_ENERGIE == "C") %><%="<img src=http://" + hote + "/img_dpe/high_quality/ges/ges_c.gif\"/HEIGHT=299 WIDTH=298>"%>
            <% if (b.LETTRE_ENERGIE == "D") %><%="<img src=http://" + hote + "/img_dpe/high_quality/ges/ges_d.gif\"/HEIGHT=299 WIDTH=298>"%>
            <% if (b.LETTRE_ENERGIE == "E") %><%="<img src=http://" + hote + "/img_dpe/high_quality/ges/ges_e.gif\"/HEIGHT=299 WIDTH=298>"%>
            <% if (b.LETTRE_ENERGIE == "F") %><%="<img src=http://" + hote + "/img_dpe/high_quality/ges/ges_f.gif\"/HEIGHT=299 WIDTH=298>"%>
            <% if (b.LETTRE_ENERGIE == "G") %><%="<img src=http://" + hote + "/img_dpe/high_quality/ges/ges_g.gif\"/HEIGHT=299 WIDTH=298>"%>
            <br />
        </td>   
    </tr>
</table>
        <%} %>

<!-- INFORMATION AGENCE -->
    <!-- CONSO ENERGETIQUE -->
    
    <table class="info_agence" style="width: 100%; border-bottom: 1px solid black; border-collapse: collapse;">
        <tr>
            <td class="titre_dpe" style="font-family: Times New Roman; width: 100%; font-size: 12pt;
                border-bottom: 1px solid black; vertical-align: middle;">
                <table>
                    <tr>
                        <td>
                            
                            <br />
                            Nous recrutons des agents mandataires sur toute la France. Nous offrons la meilleure
                            rémunération du marché. Rejoignez-nous. Envoyez cv + lm à info@patrimo.net
                            <br />
                            <br />
                            <strong>Votre contact : </strong>
                        </td>
                        <td>
                            <a href="http://<%=hote%>/pages/recrutement.aspx">
                                <img id="re" style="width: 100%;" src="http://<%=hote%>/img_site/image_patrimo_recrutement.jpg"
                                    alt="recrutement" />
                            </a>
                        </td>
                        </tr>
                </table>
            </td>
        </tr>
    </table>
    <table>
            <tr>
                <td style="width:50px">
                    <img src="http://<%=hote%>/img_site/logoMini.jpg" alt="Patrimo" />
                </td>
      <% if(b.NEGOCIATEUR != "")
         {
            //Si l'annonce a été envoyée par un nego, on récupère dans la table Clients les coordonnées de ce nego.   
            string PrenomNomNego = b.NEGOCIATEUR;
            string[] WordArray;
            string[] stringSeparators = new string[] { " " };
            WordArray = PrenomNomNego.Split(stringSeparators, StringSplitOptions.None);
            if (WordArray.Length > 1)
            {
                %><%="<td>"%><%
                String NomNego = WordArray[1];
                String PrenomNego = WordArray[0];
                String requette = "select id_client, tel_client from Clients where `idclient`=" + b.IDCLIENT;
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
                    %><%=PrenomNego + " " + NomNego + "<br/>"
                    + "tel: " + ligne["tel_client"].ToString() + "<br/>"
                    + ligne["id_client"].ToString() + "</td>"%><%

                }
            }
        }
         else if (b.NOM_AGENCE != "")
         {
             %><td>
              <strong>Reférence : </strong><%=b.REFERENCE%> - tel: <%= b.TEL_AGENCE %><br />
              <strong>Contact : </strong>
             <%=b.NOM_AGENCE + " - " + b.ADRESSE_AGENCE
             + " - " + b.CODE_POSTALE_AGENCE + "  " + b.VILLE_AGENCE%>
             </td><%
         }
        else
        {
            %><td>
                 <strong>Reférence : </strong><%= b.REFERENCE + " - tel: " + b.TEL_AGENCE %> <br />
                 <strong>Contact : </strong>
            <%=" PATRIMO - " + b.ADRESSE_AGENCE
            + " - " + b.CODE_POSTALE_AGENCE + "  " + b.VILLE_AGENCE%>
            </td><%
                                
        } %>
        </tr>
        </table>
</div>
</body>
</html>
</asp:PlaceHolder>