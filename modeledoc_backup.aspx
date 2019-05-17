<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="modeledoc.aspx.cs" Inherits="modeledoc" Title="PATRIMONIUM : Modèles de documents" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%
	Regex regex = new Regex("[-_]");
%>
	<h2 class="tamid">Modèles à télécharger</h2>
	<table style="margin:auto;line-height:40px">
<%foreach(string fileName in fileList)
	{
%>
		<tr>
			<td><a href="../<%=dir%>/<%=Uri.EscapeDataString(fileName)%>"><img src="../img_site/download.png" alt="Télécharger" title="Télécharger"></a></td>
			<td><a style="color:initial;" href="../<%=dir%>/<%=Uri.EscapeDataString(fileName)%>"><%=regex.Replace(fileName," ")%></a></td>
		</tr>
		
<%	}
	if(fileList.Length == 0)
		Response.Write("<tr><td>Aucun document disponible pour le moment</td></tr>");
%>
	</table>
</asp:Content>

