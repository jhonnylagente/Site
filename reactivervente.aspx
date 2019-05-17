<%@ Page Language="C#"  MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="reactivervente.aspx.cs" Inherits="pages_reactivervente" Title="PATRIMONIUM : Mon espace client" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<table class="moncompte" >
    <tr>   
        <td class="moncompteG1">
            <b>Mes options</b>
        </td>
           
        <td class="moncompteD1">                                   
                        <strong>Réactivation du bien</strong>                                 
        </td>        
    </tr>
    
    <tr >
        <td class="moncompteG">
            <% Membre member = (Membre)Session["Membre"]; %>
            <!-- Menu de liens à gauche -->
            <!--#include file="./menumoncompte.aspx"--> 
        </td>
        <td>
           Etes vous sur de vouloir réactiver ce bien ?<br />
           <asp:Button ID="non" runat="server" Text="Non" OnClick="verstableaudebord"/>
           <asp:Button ID="oui" runat="server" Text="Oui" OnClick="ButtonReactiverBien"/>

        </td>

    </tr>
</table>
   
</asp:Content>
