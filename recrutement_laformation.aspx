<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="recrutement_laformation.aspx.cs" Inherits="pages_recrutement_laformation" Title="PATRIMONIUM : Recrutement La formation"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table cellpadding="6" cellspacing="15" style="font-size: 12pt">
<tr><td valign="top">
<!--#include file="./recrutementmenugauche.aspx"-->
</td>
<td>
<p><strong>Votre réussite passe aussi par la formation PATRIMO</strong></p>

<p style="text-align: justify">Face à des questions particulières sur le marché immobilier ou à des demandes très spécifiques, il est important de savoir répondre rapidement et correctement aux clients.<br /><br />

Pour ce faire, PATRIMO développe des modules de formation disponibles sur son extranet<br /><br />

Chez PATRIMO, les possibilités d&#8217;évolution de carrière sont nombreuses<br /><br /> 

Vous pouvez devenir<br /> 
-&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Formateur<br />
-&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Recruteur<br />
-&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Manager<br />
-&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Directeur Régional<br /><br />

Votre principale évolution se fera naturellement par la croissance du réseau.</p><br />

</td>
</tr>
</table>
<script type="text/javascript">
    window.onload = function () {
        var sousMenuload = document.getElementById("sousmenu1");
        var sousMenuloadcolor = document.getElementById("recrutement_laformation");
        sousMenuload.style.display = "block";
        sousMenuloadcolor.style.background = "#008282";
    }
    
</script>
</asp:Content>