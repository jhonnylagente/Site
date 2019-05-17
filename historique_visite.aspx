<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="historique_visite.aspx.cs" Inherits="pages_historique_visite" Title="PATRIMONIUM : Mon espace client" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!-- Ce morceau contient le javascript de la page -->
<script type="text/javascript" src="checkfield.js"></script>
<% string reference;
   if (Request.QueryString["ref"] == null)
   {
       reference = Session["idbien"].ToString();
   }
   else
   {
       reference = Request.QueryString["ref"];
   }

    Bien b = BienDAO.getBien(reference);%>
    <table class="moncompte" >
        <td class="moncompteG1_bis" rowspan=2>
          <%--  <b>Mes options</b><br /><br /><br />
        <%
		      Membre member = (Membre)Session["Membre"];
              String NomNego = member.PRENOM + " " + member.NOM;
        %>
            <br /><br />--%>

			
            <!-- Menu mon compte -->
            <!-- Menu de liens à gauche -->
           <%-- <%if(member.STATUT == "ultranego" || member.STATUT == "nego" || member.STATUT == "nego_agence")
              { %>
            <!--#include file="./menumoncompte.aspx"-->
            <%} %>
            <%else
              { %>
            <!--#include file="./menumoncompte1.aspx"-->
            <%} %>--%>
        </td>
        <td valign="top"  class="toIgnore">
    <asp:Label ID="LabelOK" runat="server" Font-Bold="True" class="rouge" Visible="False"></asp:Label>            
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
<div align="right">
    <br /><div>
       <table align="center" 
            style="width: 749px; height: 70px; color: #31536C; font-size: large;">
        <td style="width: 36px" >
            <strong>Mandat</strong></td>
        <td class="rechercheTextBoxPetite" 
               style="width: 28px; height: 23px; color: #31536C">
            <div style="width: 89px">
             <% 
            if ((Session["Transaction"].ToString() == "achat") /*|| (Request.Params["page"].ToString() == "4")*/)
            {
                Response.Write( b.NUMERO_MANDAT );
            }
            else
            {
                Response.Write( b.NUMERO_MANDAT );
               
            }
        %>
            </div>
           </td>
        <td style="height: 23px; text-align: left; width: 70px;" class="titrecreation">
            
            <strong>Negociateur</td>
        <td style="width: 243px; height: 23px; color: #31536C;">
            <div style="width: 281px">
             <% 
            if ((Session["Transaction"].ToString() == "achat") /*|| (Request.Params["page"].ToString() == "4")*/)
            {
                Response.Write( b.NEGOCIATEUR );
               
            }
            else
            {
                Response.Write( b.NEGOCIATEUR );
               
            }
        %>
            </div>
        </td>
           <tr>
        <td colspan="4" style="color: #31536C">
            <div>
             <% 
            if ((Session["Transaction"].ToString() == "achat") /*|| (Request.Params["page"].ToString() == "4")*/)
            {
               
                Response.Write(b.CATEGORIE + " - " + b.NBRE_PIECE + " pièces - " + b.S_HABITABLE + " m² - " + b.ADRESSE_BIEN + " " + b.CODE_POSTAL_BIEN + " " + b.VILLE_BIEN + " - " + b.PRIX_VENTE + " &#8364; <br />");
                
            }
            else
            {
               
                Response.Write(b.CATEGORIE + " - " + b.NBRE_PIECE + " pièces - " + b.S_HABITABLE + " m² - " + b.ADRESSE_BIEN + " " + b.CODE_POSTAL_BIEN + " " + b.VILLE_BIEN + " - " + b.LOYER + " &#8364; CC");
               
            }
        %>
            </div>
               </td>
           </tr>
           <tr>
        <td colspan="1" style="width: 36px"  >
            <strong>Propietaire</strong></td>
        <td style="height: 23px" colspan="3">
            <div>
             <% 
            if ((Session["Transaction"].ToString() == "achat") /*|| (Request.Params["page"].ToString() == "4")*/)
            {
                
                Response.Write( b.NOM_VENDEUR + " " + b.PRENOM_VENDEUR + " " + b.TEL_DOMICILE_VENDEUR);
            }
            else
            {
                
                Response.Write(b.NOM_VENDEUR + " " + b.PRENOM_VENDEUR + " " + b.TEL_DOMICILE_VENDEUR);
            }
        %>
            </div>
        </td>
           </tr>
       </table>

    </div>
    <asp:DropDownList ID="DropDownListPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ItemChange" > 
	    <asp:ListItem Value="10" Text="10" /> 
	    <asp:ListItem Value="20" Text="20" /> 
	    <asp:ListItem Value="30" Text="30" /> 
	    <asp:ListItem Value="50" Text="50" /> 
	    <asp:ListItem Value="100" Text="100" /> 
    </asp:DropDownList>
    <br />
    </div>
<div>
    <asp:GridView ID="GridViewHist" runat="server" AutoGenerateColumns="false" AllowPaging="true" DataKeyNames="nom vendeur" HorizontalAlign="Center"
     OnPageIndexChanging="PaginateTheData" PagerSettings-Mode="Numeric" OnRowDataBound="ReSelectSelectedRecords" AllowSorting="true" OnSorting="SortRecords" CellPadding="2" >
     <Columns>
        <asp:BoundField  HeaderText="nom vendeur" DataField="nom vendeur" SortExpression="nom vendeur" HeaderStyle-CssClass="EntetAdresse" Visible="false" />
        <asp:BoundField HeaderText="negociateur" DataField="negociateur" SortExpression="negociateur" HeaderStyle-CssClass="EntetAdresse" Visible="false" />
        <asp:BoundField  HeaderText="Date visite" DataField="date_visite" SortExpression="date_visite" DataFormatString="{0:d}" HeaderStyle-CssClass="EntetAdresse" />
        <asp:BoundField HeaderText="nom" DataField="nom" SortExpression="nom" HeaderStyle-CssClass="EntetAdresse" />
        <asp:BoundField HeaderText="Prenom" DataField="prenom" SortExpression="prenom" HeaderStyle-CssClass="EntetAdresse" />
        <asp:BoundField HeaderText="Adresse" DataField="adresse" SortExpression="adresse" HeaderStyle-CssClass="EntetAdresse" />
        <asp:BoundField HeaderText="Code postal" DataField="code_postal" SortExpression="code_postal" HeaderStyle-CssClass="EntetAdresse" />
        <asp:BoundField HeaderText="Ville" DataField="ville" SortExpression="ville" HeaderStyle-CssClass="EntetAdresse" />
        <asp:BoundField HeaderText="Tél." DataField="tel" SortExpression="tel" HeaderStyle-CssClass="EntetAdresse" />
        <asp:BoundField HeaderText="Port." DataField="portable" SortExpression="portable" HeaderStyle-CssClass="EntetAdresse" />
        <asp:BoundField HeaderText="Mail" DataField="mail" SortExpression="mail" HeaderStyle-CssClass="EntetAdresse" />
        <asp:BoundField HeaderText="Prix min" DataField="prix_min" SortExpression="prix_min" DataFormatString="{0:C0}" HeaderStyle-CssClass="EntetAdresse" />
        <asp:BoundField HeaderText="Prix max" DataField="prix_max" SortExpression="prix_max" DataFormatString="{0:C0}" HeaderStyle-CssClass="EntetAdresse" />
         <asp:BoundField HeaderText="Categorie" DataField="categorie" SortExpression="categorie" HeaderStyle-CssClass="EntetAdresse" />
          <asp:BoundField HeaderText="id_acq" DataField="id_acq" SortExpression="id_acq"  HeaderStyle-CssClass="EntetAdresse" />
      <asp:TemplateField HeaderText="rapproch." HeaderStyle-CssClass="Entet">
                        <ItemTemplate>
                            <a href="../pages/rapprochement.aspx?idAcq=<%# Eval("id_acq") %>">
                                <img id="imgphoto" src="../img_site/rapprochement.png" alt="fleche" style="width: 25px" />
                            </a>
                            <div class="tooltip">
                                <span>rapprochement</span></div>
                        </ItemTemplate>
                    </asp:TemplateField>
     </Columns>    
     </asp:GridView>
</div>
  </body>
</html>
</td>
        <td valign="top"  class="toIgnore">
            &nbsp;</td>
        <td valign="top"  class="toIgnore">
            &nbsp;</td>
</table>
</asp:Content>


