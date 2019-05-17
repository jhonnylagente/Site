<%@ Page Title="" Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="desinscription.aspx.cs" Inherits="pages_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder1" Runat="Server">
<br /><br />
<center>
    <asp:Label ID="labelReponse" runat="server"></asp:Label>
        <br /> <br />
    <asp:Label ID="labelRetour" runat="server"></asp:Label><br /><br />
    <asp:Button ID="btnAlertes"  text="ok" class="myButtonOK cursor_link" runat="server" OnClick="Redirect"></asp:Button>
</center>
<br /><br />
</asp:Content>