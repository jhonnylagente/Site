<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="supprimeracquereur.aspx.cs" Inherits="pages_supprimer_acquereur" Title="PATRIMONIUM : Mon espace client" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<table class="moncompte" >
    <tr>   
        <td class="moncompteG1">
            <b>Mes options</b>
        </td>          
        <td class="moncompteD1">                                   
            <strong>Suppression de l'acquéreur</strong>                                 
        </td>        
    </tr>
    
    <tr >
        <td class="moncompteG">
            <% Membre member = (Membre)Session["Membre"]; %>
            <!-- Menu de liens à gauche -->
            <!--#include file="./menumoncompte.aspx"--> 
        </td>
        <td>
           Etes vous sur de vouloir supprimer cet acquereur ?<br />
           <asp:Button ID="non" runat="server" Text="Non" OnClick="versListeAcquereur"/>
           <asp:Button ID="oui" runat="server" Text="Oui" OnClick="ButtonSupprimerAcquereur"/>
        </td>
    </tr>
</table>
   
</asp:Content>

