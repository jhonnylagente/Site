<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="monCompte.aspx.cs" Inherits="pages_monCompte" Title="PATRIMONIUM : Mon espace client" %>

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
        <%--<%if(member.STATUT == "ultranego" || member.STATUT == "nego" || member.STATUT == "nego_agence")
              { %>
            <!--#include file="./menumoncompte.aspx"-->
            <%} %>
            <%else
              { %>
            <!--#include file="./menumoncompte1.aspx"-->
            <%} %>--%>
        
        </td>
        <td  class="moncompteD_menu">
            <fieldset class="affiche_visite">
                <legend>
                    <strong> Mes annonces </strong>
                </legend>
                <p style="margin-left:5px;">
                    <asp:Label ID="LabelNbreAnnonce" runat="server" Text="LabelNbreAnnonce"></asp:Label>
                </p>
                <p style="margin-left:5px;">
                    <a href="./monCompteAnnonces.aspx"> Consulter / supprimer mes annonces sélectionnées</a>
                </p>
            </fieldset>
            <br />
            <fieldset class="affiche_visite">
                <legend>
                    <strong> Mes alertes </strong>
                </legend>
                <p style="margin-left:5px;">
                    <asp:Label ID="LabelNbreAlerte" runat="server" Text="LabelNbreAlerte"></asp:Label>
                </p>
                <p style="margin-left:5px;">
                <%
                    // Regarde si le membre a des alertes
                    int nbreAlerte = MembreDAO.nombreAlerte(member);
                    if (nbreAlerte == 0) Response.Write("<a href=\"./alerteMail.aspx\"> Ajouter une alerte email</a>");
                    else Response.Write(" <a href=\"./monCompteAlertes.aspx\"> Consulter / ajouter / supprimer mes alertes email</a>");
                %>
                </p>
            </fieldset>
        </td>
    </tr>
</table>
   
</asp:Content>

