<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="monComptecompleterprofil.aspx.cs" Inherits="pages_monCompte" Title="PATRIMONIUM : Mon espace client" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table class="moncompte" >
    <tr>   
        <td class="moncompteG1">
            <%--<b>Mes options</b>--%>
        </td>
           
        <td class="moncompteD1">                                   
                        <strong>Bienvenue
                            <asp:Label ID="LabelPrenom" runat="server" Text="LabelPrenom"></asp:Label>&nbsp
                            <asp:Label ID="LabelNom" runat="server" Text="LabelNom"></asp:Label>                        </strong>                                 
        </td>        
    </tr>
    
    <tr >
        <td class="moncompteG">
        
            <% Membre member = (Membre)Session["Membre"]; %>
            <!-- Menu de liens à gauche -->
            <%--<!--#include file="./menumoncompte.aspx"--> --%>         
            
        </td>
        <td  class="moncompteProfilPicture">
            <%
                if (CheckPhotoProfil(member.IDCLIENT))
                {
                    Response.Write("<strong>Votre photo de profil :</strong><br /><br />");
                    Response.Write("<img src=\"../img_nego/" + member.IDCLIENT + "_PHOTO.jpg" + "\" />"); %>
                    <br /><br /><asp:Button ID="ButtonSupprimerProfilPicture" runat="server" Text="Supprimer" OnClick='SupprimerProfilPicture'/>
                <%
                }
                else
                {
                 %>
                <strong>Ajouter une photo de profil : </strong><br /><br />
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Label ID="Label1" runat="server" class="TexteInternet"></asp:Label>   <br /><br />
                <asp:Button ID="ButtonAddProfilPhoto" runat="server" Text="Valider" CssClass="myButton" OnClick="ButtonAddProfilPicture"/> 
            <%} %>
        </td>
    </tr>
</table>
   
</asp:Content>

