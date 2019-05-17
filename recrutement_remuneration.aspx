<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="recrutement_remuneration.aspx.cs" Inherits="pages_recrutement_remuneration" Title="PATRIMONIUM : Recrutement remuneration" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table cellpadding="6" cellspacing="15" style="font-size: 12pt">
<tr><td valign="top">
<!--#include file="./recrutementmenugauche.aspx"-->
</td>
<td>
<p><strong>La plus forte rémunération des réseaux - 7 niveaux hierarchiques</strong></p>

<p style="text-align: justify">Chez PATRIMO vous cumulez votre chiffre d'affaire et un pourcentage sur celui de vos filleuls.<br /><br />

Pour Chacune des ventes de votre réseau (en pourcentage de la commission d'agence): 85,75% dont 70% en direct et 15,75% en réseau<br /><br />

+ 70% HT sur vos ventes directes<br />
+ 5% sur le premier niveau de filleuls<br />
+ 4% sur le second niveau de filleuls<br />
+ 3% sur le troisième niveau de filleuls<br />
+ 2% sur le quatrième niveau de filleuls<br />
+ 1% sur le cinquième niveau de filleuls<br />
+ 0.5% sur le sixième niveau de filleuls<br />
+ 0.25% sur le septième niveau de filleuls<br /><br />

Auto-entrepreneurs ou demandeurs d’emploi (ACCRE) renseignez-vous sur les éventuelles exonérations de cotisations la première année.<br /></p><br />

</td>
</tr>
</table>
<script type="text/javascript">
    window.onload = function () {
        var sousMenuload = document.getElementById("sousmenu1");
        var sousMenuloadcolor = document.getElementById("recrutement_remuneration");
        sousMenuload.style.display = "block";
        sousMenuloadcolor.style.background = "#008282";
    }
    
</script>
</asp:Content>