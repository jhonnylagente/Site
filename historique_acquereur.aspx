<%@ Page Language="C#" AutoEventWireup="true" CodeFile="historique_acquereur.aspx.cs" MasterPageFile="~/pages/MasterPage.master" Inherits="pages_historique_acquereur" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!-- Ce morceau contient le javascript de la page -->
<script type="text/javascript" src="checkfield.js"></script>
<% string reference = Session["idbien"].ToString();

    Bien b = BienDAO.getBien(reference);%>
    <table class="moncompte" >
        <td valign="top" class="toIgnore">
    <div class="historique" >
     <%-- <% 
            if ((Session["Transaction"].ToString() == "achat") /*|| (Request.Params["page"].ToString() == "4")*/)
            {
                Response.Write("Mandat: " + b.NUMERO_MANDAT + " Negociateur: " + b.NEGOCIATEUR + "<br />");
                Response.Write(b.CATEGORIE + " - " + b.NBRE_PIECE + " pièces - " + b.S_HABITABLE + " m² - " + b.ADRESSE_BIEN + " " + b.CODE_POSTAL_BIEN + " " + b.VILLE_BIEN + " - " + b.PRIX_VENTE + " &#8364; <br />");
                Response.Write("Propriétaire: " + b.NOM_VENDEUR + " " + b.PRENOM_VENDEUR + " " + b.TEL_DOMICILE_VENDEUR);
            }
            else
            {
                Response.Write("Mandat: " + b.NUMERO_MANDAT + " Negociateur: " + b.NEGOCIATEUR + "<br />");
                Response.Write(b.CATEGORIE + " - " + b.NBRE_PIECE + " pièces - " + b.S_HABITABLE + " m² - " + b.ADRESSE_BIEN + " " + b.CODE_POSTAL_BIEN + " " + b.VILLE_BIEN + " - " + b.LOYER + " &#8364; CC");
                Response.Write("Propriétaire: " + b.NOM_VENDEUR + " " + b.PRENOM_VENDEUR + " " + b.TEL_DOMICILE_VENDEUR);
            }
        %> --%>
        <p style="width:100%"></p>    
    </div> 
    <asp:Label ID="LabelOK" runat="server" Font-Bold="True" class="rouge" Visible="False"></asp:Label>            
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
<div align="left">
<table style="width: 830px; font-size: medium; height: 116px; color: #31536C;" 
        bgcolor="White">
    <tr style="font-size: medium">
    <td class="rechercheTextBoxPetite" 
        style="width: 274px; height: 1px; text-align: right;">
       
        Nom:
       
    </td>
    <td style="height: 1px" colspan="3" class="ligneInterm">
       <asp:Label  runat="server" ID="lblNom" style="font-weight: 700" ></asp:Label> 
        </td>
    <tr style="font-size: medium">
    <td class="rechercheTextBoxPetite" 
        style="width: 274px; height: 5px; text-align: right;">
       
        Addresse:</td>
    <td style="height: 5px" colspan="3" class="ligneInterm">
        <asp:Label ID="lblAddresse" runat="server" style="font-weight: 700"></asp:Label>
        </td>
    </tr>
    <tr style="font-size: medium">
    <td style="width: 274px; text-align: right; height: 6px;">
        Ville: </td>
    <td style="width: 229px; height: 6px;">
        <asp:Label ID="lblVille" runat="server" style="font-weight: 700"></asp:Label>
        </td>
    <td style="width: 113px; text-align: right; height: 6px;">
        Code Postal:
        </td>
    <td style="height: 6px">
        <asp:Label ID="lblcp" runat="server" style="font-weight: 700"></asp:Label>
        </td>
    </tr>
    <tr style="font-size: medium">
    <td class="rechercheTextBoxPetite" 
            style="width: 274px; height: 3px; text-align: right;">
        Departement:</td>
    <td style="height: 3px; width: 229px;">
        <asp:Label ID="lblDepartement" runat="server" style="font-weight: 700"></asp:Label>
        </td>
    <td style="height: 3px; width: 113px; text-align: right;">
        Pays:</td>
    <td style="height: 3px">
        <asp:Label ID="lblPays" runat="server" style="font-weight: 700"></asp:Label>
        </td>
    </tr>
    <tr style="font-size: medium">
    <td class="rechercheTextBoxPetite" 
            style="width: 274px; height: 3px; text-align: right;">
        Tél:</td>
    <td style="height: 3px; width: 229px;">
        <asp:Label ID="lbltel" runat="server" style="font-weight: 700"></asp:Label>
        </td>
    <td style="height: 3px; width: 113px;">
        </td>
    <td style="height: 3px" class="ligneInterm">
        </td>
    </tr>
    <tr style="font-size: medium">
    <td class="rechercheTextBoxPetite" 
            style="width: 274px; height: 4px; text-align: right;">
        Mail:</td>
    <td style="height: 4px; width: 229px;">
        <asp:Label ID="lblMail" runat="server" style="font-weight: 700"></asp:Label>
        </td>
    <td style="height: 4px; width: 113px;">
        </td>
    <td style="height: 4px">
        </td>
    </tr>
</table>
</div>
<div align="right">
   
   <asp:DropDownList ID="DropDownListPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ItemChange" > 
	    <asp:ListItem Value="10" Text="10" Selected="True"/> 
	    <asp:ListItem Value="20" Text="20" /> 
	    <asp:ListItem Value="30" Text="30" /> 
	    <asp:ListItem Value="50" Text="50" /> 
	    <asp:ListItem Value="100" Text="100" /> 
    </asp:DropDownList>
</div>
<div>
    <asp:GridView ID="GridViewHist" runat="server" AutoGenerateColumns="false" AllowPaging="true" DataKeyNames="nom vendeur" HorizontalAlign="Center"
     OnPageIndexChanging="PaginateTheData" PagerSettings-Mode="Numeric" OnRowDataBound="ReSelectSelectedRecords" AllowSorting="true" OnSorting="SortRecords" CellPadding="2" >
     <Columns>
        <%--<asp:BoundField  HeaderText="nom vendeur" DataField="nom vendeur" SortExpression="nom vendeur" HeaderStyle-CssClass="EntetAdresse" Visible="false" />
        <asp:BoundField HeaderText="negociateur" DataField="negociateur" SortExpression="negociateur" HeaderStyle-CssClass="EntetAdresse" Visible="false" />
   --%>  <asp:BoundField  HeaderText="Réf." DataField="ref" SortExpression="ref"  HeaderStyle-CssClass="EntetAdresse" />
        <asp:BoundField HeaderText="Date de création" DataField="date dossier" SortExpression="date dossier" DataFormatString="{0:d}" HeaderStyle-CssClass="EntetAdresse" />
       <%-- <asp:BoundField HeaderText="Type Transac" DataField="type_transac" SortExpression="type_transac" HeaderStyle-CssClass="EntetAdresse" />--%>
        <asp:BoundField HeaderText="Etat" DataField="etat" SortExpression="etat" HeaderStyle-CssClass="EntetAdresse" />
        <asp:BoundField HeaderText="Nom de propio" DataField="nom vendeur" SortExpression="nom vendeur" HeaderStyle-CssClass="EntetAdresse" />
        <asp:BoundField HeaderText="Adresse" DataField="adresse vendeur" SortExpression="adresse vendeur" HeaderStyle-CssClass="EntetAdresse" />
        <asp:BoundField HeaderText="Code postal" DataField="code postal vendeur" SortExpression="code postal vendeur" HeaderStyle-CssClass="EntetAdresse" />
        <asp:BoundField HeaderText="Ville" DataField="ville vendeur" SortExpression="ville vendeur" HeaderStyle-CssClass="EntetAdresse" />
        <asp:BoundField HeaderText="Tél." DataField="tel domicile vendeur" SortExpression="tel domicile vendeur" HeaderStyle-CssClass="EntetAdresse" />
   <%-- <asp:BoundField HeaderText="Mail" DataField="mail" SortExpression="mail" HeaderStyle-CssClass="EntetAdresse" />
--%>    <asp:BoundField HeaderText="Prix" DataField="prix de vente" SortExpression="prix de vente" DataFormatString="{0:C0}" HeaderStyle-CssClass="EntetAdresse" />
    <asp:BoundField HeaderText="Mail" DataField="mail" SortExpression="mail" HeaderStyle-CssClass="EntetAdresse" />
                <asp:TemplateField HeaderText="rapproch." HeaderStyle-CssClass="Entet">
                    <ItemTemplate>
                        <a href="../pages/rapprochementbien.aspx?idAcq=<%# Eval("ref") %>">
                            <img id="imgphoto" src="../img_site/rapprochement.png" alt="fleche" style="width:25px" />
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
</table>
</asp:Content>