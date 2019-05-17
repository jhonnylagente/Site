<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="monCompteAcquereur.aspx.cs" Inherits="pages_monCompte_acquereur" Title="PATRIMONIUM : Mon espace client" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table class="moncompte" >
    <tr>   
        <td class="moncompteG1">
            <%--<b>Visites</b>--%>
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
            <%--<!--#include file="./menumoncompte.aspx"-->           --%> 
        </td>
        <td  class="moncompteD_menu">
               
                <table class="tableauTransaction">
                <tr class="ligneInterm" >
                    <td></td>
                    <td></td>
                    
                   
                </tr>
                <tr class="ligneMilieu">
                <td class="celluleMilieuGauche">                               
                    <a href="./ajout_acquereur.aspx" style="cursor: hand"><span class="TexteTransaction">Ajouter un acquéreur</span></a>                         
                </td>
                <td >                 
                    <a href="./liste_acquereur.aspx" style="cursor: hand"><span class="TexteTransaction">Liste des acquéreurs</span></a>                    
                </td>
                </tr>
                <tr class="ligneInterm" >
                    <td></td>
                    <td></td>
                   
                </tr>
                
                </table>
          
          
        </td>
    </tr>
</table>
   
</asp:Content>

