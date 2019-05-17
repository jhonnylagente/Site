<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="tableaudebord.aspx.cs" Inherits="pages_monCompte" Title="PATRIMONIUM : Mon espace client" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table border="0" cellpadding="0" cellspacing="0" style="border-top: rgb(255,255,255) 3px solid;
        left: 0px; width: 803px; border-bottom: rgb(255,255,255) 3px solid; top: 0px">
        <tr>
            <td bgcolor="#31536c" style="margin-left: 10px" width="10">
            </td>
            <td bgcolor="#31536c" style="margin-left: 10px" width="200">
                <p align="left">
                    <strong><big><big><font color="#ffffff">Mon compte</font></big></big></strong></p>
            </td>
            <td style="width: 5px; height: 60px">
            </td>
            <td align="right" style="height: 60px">
                <img alt="Golfe de Saint-Tropez" src="../img_site/patrimoniumfond.jpg"
                    width="600" /></td>
        </tr>
</table>

<table class="moncompte" >
    <tr>   
        <td class="moncompteG1">
            <b>Mes options</b>
        </td>
           
        <td class="moncompteD1">                                   
                        <strong>Bienvenue
                            <asp:Label ID="LabelPrenom" runat="server" Text="LabelPrenom"></asp:Label>&nbsp
                            <asp:Label ID="LabelNom" runat="server" Text="LabelNom"></asp:Label>                        </strong>                                 
        </td>        
    </tr>
    
    <tr >
        <td class="moncompteG">
            <a href="./moncomteCoordonnees.aspx" style="cursor: hand"><img src='../img_site/fleche2.ico' border='0' width='15px' height='13px'> Modifier mes coordonnées</a><br /><br />
            <a href="./monCompteAlertes.aspx" style="cursor: hand"><img src='../img_site/fleche2.ico' border='0' width='15px' height='13px'> Afficher mes alertes</a><br /><br />
            <a href="./monCompteAnnonces.aspx" style="cursor: hand"><img src='../img_site/fleche2.ico' border='0' width='15px' height='13px'> Consulter ma sélection</a><br /><br />            
            <a href="./monCompteDeconnexion.aspx" style="cursor: hand"><img src='../img_site/fleche2.ico' border='0' width='15px' height='13px'> Se déconnecter</a><br /><br />
            <%  
                Membre member = (Membre)Session["Membre"];
                String MailNego = member.ID_CLIENT;
                if (member.STATUT == "nego")
                {
            %>
            <a href="./ajout_nego.aspx" style="cursor: hand"><img src='../img_site/fleche2.ico' border='0' width='15px' height='13px'> Ajout d'une vente</a>
            <% } %>
       
        </td>
        <td  class="moncompteD">
        <%
            int i=0;
           // String requette2 = "Select * From Biens where `negociateur`='OLIVIER SAGLIO'";
            String requette2 = "SELECT Clients.id_client, Clients.prenom_client, Clients.nom_client FROM Biens LEFT JOIN Clients ON Biens.idclient = Clients.idclient GROUP BY Clients.id_client";
            System.Data.DataSet ds2 = null;
            Connexion c2 = null;

            c2 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c2.Open();
            ds2 = c2.exeRequette(requette2);
            c2.Close();
            c2 = null;

            System.Data.DataRowCollection dr2 = ds2.Tables[0].Rows;
            
          %>  
            <table class="tableaubilan">
                <tr class="champs">
                    <td><Strong>Références</Strong> </td>
                    <td><Strong>Date de dossier</Strong></td>
                    <td><Strong>Type de transaction</Strong></td>
                    <td><Strong>Type de bien</Strong></td>                
                    <td><Strong>Code postal</Strong></td>
                    <td><Strong>Ville</Strong></td>
                    <td><Strong>Prix de vente</Strong></td>
                    <td><Strong>Nombre de pièces</Strong></td>
                    <td><Strong>Surface</Strong></td>
                    <td><Strong>Modifier</Strong></td>
                    <td><Strong>Supprimer</Strong></td>
                </tr>
                
          <%
              foreach (System.Data.DataRow ligne in dr2)
              {
                  if ((i % 2) == 1) Response.Write("<tr class=\"pair\">");
                  else Response.Write("<tr>");
                  i++;
                  Response.Write("<td>"); Response.Write((String)ligne["ref"]); Response.Write("</td>");

                  Response.Write("<td>"); Response.Write((String)ligne["date dossier"].ToString().Substring(0, 10)); Response.Write("</td>");

                  Response.Write("<td>"); if ((String)ligne["ref"].ToString().Substring(0, 1) == "L") Response.Write("Location");
                  else if ((String)ligne["ref"].ToString().Substring(0, 1) == "V") Response.Write("Vente");
                  Response.Write("</td>");

                  Response.Write("<td>"); if ((String)ligne["type de bien"].ToString().Substring(0, 1) == "M") Response.Write("Maison");
                  else if ((String)ligne["type de bien"].ToString().Substring(0, 1) == "A") Response.Write("Appartement");
                  else if ((String)ligne["type de bien"].ToString().Substring(0, 1) == "L") Response.Write("Loft");
                  else if ((String)ligne["type de bien"].ToString().Substring(0, 1) == "T") Response.Write("Terrain");
                  Response.Write("</td>");

                  Response.Write("<td class=\"centre\">"); Response.Write(ligne["code postal du bien"]); Response.Write("</td>");
                  Response.Write("<td>"); Response.Write((String)ligne["ville du bien"]); Response.Write("</td>");
                  Response.Write("<td class=\"droite\">"); Response.Write((int)ligne["prix de vente"] + "€"); Response.Write("</td>");
                  Response.Write("<td class=\"centre\">"); Response.Write(ligne["nombre de pieces"]); Response.Write("</td>");
                  Response.Write("<td class=\"centre\">"); Response.Write(ligne["Surface habitable"] + " m²"); Response.Write("</td>");

                  Response.Write("<td>"); Response.Write("<a href=\"ajout_nego2.aspx?reference=" + (String)ligne["ref"] + "\">Modifier</a>"); Response.Write("</td>");
                  Response.Write("<td>"); Response.Write("<a href=\"supprimervente.aspx?reference=" + (String)ligne["ref"] + "\">Supprimer</a>"); Response.Write("</td>");          
 
              }  %>

                </tr>
            </table>        
</table>
   
</asp:Content>

