<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="errorMaj.aspx.cs" Inherits="errorMaj" Title="Informations" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script>
	$(function()
		{
			var fn = function ()
				{
					document.location.href="recherche.aspx";
				};
				
			var interval = setInterval(fn, 3000);
		}
	);
</script>
<br/>
<center>
Le site est cours de mise � jour, et sera disponible dans un bref instant.<br/>
Veuillez nous excuser pour la g�ne occasionn�e.
</center>
<br/>
</asp:Content>