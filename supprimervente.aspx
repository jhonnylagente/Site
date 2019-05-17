<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="supprimervente.aspx.cs" Inherits="pages_supprimer_vente" Title="PATRIMONIUM : Mon espace client" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<table class="moncompte" >
    <tr>   
        <td class="moncompteG1">
            <b>Mes options</b>
        </td>
           
        <td class="moncompteD1">                                   
                        <strong>Suppression du bien</strong>                                 
        </td>        
    </tr>
    
    <tr >
        <td class="moncompteG">
            <% Membre member = (Membre)Session["Membre"]; %>
            <!-- Menu de liens à gauche -->
            <!--#include file="./menumoncompte.aspx"--> 
        </td>
        <td>
           Etes vous sur de vouloir supprimer ce bien ?<br />
           <asp:Button ID="non" runat="server" Text="Non" OnClick="verstableaudebord"/>
           <asp:Button ID="oui" runat="server" Text="Oui" OnClick="ButtonSupprimerBien"/>

        </td>

    </tr>
</table>
   
</asp:Content>

