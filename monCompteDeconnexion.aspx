<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="monCompteDeconnexion.aspx.cs" Inherits="pages_deconnexionCompte" Title="PATRIMONIUM : Déconnexion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">





<%  if (Session["logged"].Equals(true))
    {
        Session.Abandon();
        Response.Redirect("./recherche.aspx");
       
    }
    else Response.Redirect("./accueil.aspx");%>
       








</asp:Content>

