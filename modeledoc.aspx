<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="modeledoc.aspx.cs" Inherits="modeledoc" Title="PATRIMONIUM : Modèles de documents" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script>
	$(function()
	{
		$(".plusminusP").click(
			function(){toggleDisplay(this);}
		);
		
		function toggleDisplay(dir)
		{
			if($(dir).html() == "+")
			{
				$(dir).html("-");
				$(dir).attr("class", "plusminusM cursor_link");
			}
			else
			{
				$(dir).html("+");
				$(dir).attr("class", "plusminusP cursor_link");
			}
			var profondeur = parseInt($(dir).parent().parent().attr("profondeur"));
			var ligne = $(dir).parent().parent().next();
			while(parseInt(ligne.attr("profondeur")) != profondeur)
			{
				if(parseInt(ligne.attr("profondeur")) === (profondeur + 1))
					ligne.toggle();
				ligne = ligne.next();
			}
		}
	});
</script>

	<h2 class="tamid">Documents à télécharger</h2>
		<table id="tableContainer" style="line-height: 40px; margin: auto;">
			<% displayDir();%>
		</table>
</asp:Content>

