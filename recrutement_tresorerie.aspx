<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="recrutement_tresorerie.aspx.cs" Inherits="pages_recrutement_tresorerie"  Title="PATRIMONIUM : Recrutement tresorerie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table cellpadding="6" cellspacing="15" style="font-size: 12pt">
<tr><td valign="top">
<!--#include file="./recrutementmenugauche.aspx"-->
</td>
<td>
<p><strong>Ai-je besoin de trésorerie pour débuter mon activité ?</strong></p>

<p style="text-align: justify">
Le concept PATRIMO ne génère que très peu de frais, contrairement à une agence immobilière classique. On ne vous demande ni droit d’entrée, ni investissement lourd.<br />
Toutefois, même avec l’option du régime fiscal de l’auto-entrepreneur et même si d’autres réseaux le font, nous pensons qu’il serait malhonnête de vous accueillir si vous n’avez pas un minimum de trésorerie, car il vous faudra assurer vos dépenses personnelles et vos frais jusqu’à l’encaissement de vos premiers honoraires…<br /><br />

&nbsp;&nbsp;&nbsp;&nbsp;Si vous êtes commercial en immobilier (sans interruption d’activité) : il faudra que vous prévoyiez 1 mois d’autonomie financière. <br />
&nbsp;&nbsp;&nbsp;&nbsp;Si vous cessez tout juste de travailler pour une agence ou en indépendant, les commissions issues de vos derniers mois d’activité feront le lien.<br />
&nbsp;&nbsp;&nbsp;&nbsp;Si vous êtes commercial en immobilier (avec interruption d’activité) : nous vous conseillons d’avoir 3 à 4 mois d’autonomie financière.<br />
&nbsp;&nbsp;&nbsp;&nbsp;Si vous êtes commercial sans expérience en immobilier : prévoyez 4 à 6 mois d’autonomie financière. Vous mettrez peut être un peu plus de temps à signer vos premières affaires. Et dans l’immobilier, les commissions ne sont versées qu’à la signature de l’acte authentique, soit  3 mois après le compromis de vente.


</p><br />

</td>
</tr>
</table>
<script type="text/javascript">
    window.onload = function () {
        var sousMenuload = document.getElementById("sousmenu2");
        var sousMenuloadcolor = document.getElementById("recrutement_tresorerie");
        sousMenuload.style.display = "block";
        sousMenuloadcolor.style.background = "#008282";
    }
    
</script>
</asp:Content>
