<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="modifierAlerte.aspx.cs" Inherits="pages_modifierAlerte" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



<table border="1" cellpadding="10px" cellspacing="10px">
    <tr>
        <td style="width:175px; border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; height: 44px;">
        <center>
            <b style="color:Red;">Mom compte</b>
        </center>
        </td>
        <td style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; height: 44px;";>
                <table>
                    <tr>
                        <td style="width: 444px">
                            Bienvenue 
                            <strong>
                                <asp:Label ID="LabelPrenom" runat="server" Text="LabelPrenom"></asp:Label>&nbsp
                                <asp:Label ID="LabelNom" runat="server" Text="LabelNom"></asp:Label>
                            </strong>
                        </td>
                        <td>
                        <a href="./inscriptionAccueil.aspx" style="cursor: hand; color: red;"> Se déconnecter</a><span style="color: #ff0000; text-decoration: underline"> </span>
                        </td>
                    </tr>
                </table>
        </td>
    </tr>
</table>

<table border="1" cellpadding="10px" cellspacing="10px">

    <tr style="margin-left:5px;" valign="top" >
        <td style="width:165px; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid;">
            <a href="./moncomteCoordonnees.aspx" style="cursor: hand; text-decoration: underline; color:Red">Modifier mes coordonnées</a><br /><br />
            <a href="./monCompteAlertes.aspx" style="cursor: hand; text-decoration: underline; color:Red">Afficher mes alertes</a><br /><br />
            <a href="./monCompteAnnonces.aspx" style="cursor: hand; text-decoration: underline; color:Red">Consulter ma sélection</a>
        </td>
        <td  valign="top" style="border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid;">
            
            
            
            
            
            
       </td>
    </tr>
</table>





</asp:Content>

