<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="_aaa.aspx.cs" Inherits="aaa" Title="Informations" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script>
    function aa() {
        alert("Test");
    }
</script>
	<div id="divAllItemList" runat="server" class="divAllItemList aaa">aaa</div>
	<asp:Button ID="btnSave" runat="server" OnClick="test" Text="Save" />
	<asp:Label ID="ab" runat="server" Text="PlaceHolder"></asp:Label>
	<asp:ImageButton ID="img" runat="server" OnClick="test" ImageUrl="../img_site/trash.png" customValue="TRAAASH"/>
</asp:Content>

