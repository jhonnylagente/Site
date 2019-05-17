<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="monCompteAjout.aspx.cs" Inherits="pages_monCompteAjout" Title="PATRIMONIUM : Mon espace client" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
            <% Membre member = (Membre)Session["Membre"]; %>
            <!-- Menu de liens à gauche -->
            <!--#include file="./menumoncompte.aspx"-->      
        </td>
            <td >
                <table>
                    <tr> 
                         <td>Ajouter un bien </td>
                    </tr>
                    <tr>
                        <td><a href="./ajout_nego.aspx"> à Vendre</a></td>       <td>à Louer</td>
                    </tr>
                </table>
            </td>
   
    </tr>
</table>
   
</asp:Content>

