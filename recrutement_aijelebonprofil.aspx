<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="recrutement_aijelebonprofil.aspx.cs" Inherits="pages_recrutement_aijelebonprofil" Title="PATRIMONIUM : Recrutement Ai-je le bon profil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table cellpadding="6" cellspacing="15" style="font-size: 12pt">
<tr><td valign="top">
<!--#include file="./recrutementmenugauche.aspx"-->
</td>
<td>
<p><strong>Avez-vous le profil pour intégrer PATRIMO ?</strong></p>

<p style="text-align: justify">
Qualités requises : avoir la fibre commerciale, être motivé, le sens du relationnel, avoir pour objectif la satisfaction du client, avoir une très forte envie et volonté d’entreprendre.<br /><br />

Sont bienvenus chez PATRIMO : les commerciaux confirmés, agents commerciaux, négociateurs, etc., issus de tous domaines d’activités ; mais aussi les commerçants, certains artisans et professions libérales, les indépendants, les patrons de PME...<br /><br />

Sachez qu’il n’est pas indispensable d’avoir une expérience dans l’immobilier : 55% des conseillers immobiliers n'ont pas d’expérience du secteur avant de commencer leur activité.<br /><br />

Partager nos valeurs et nos règles de fonctionnement !<br /><br />

L’honnêteté, la droiture, l’esprit de collaboration, le sens des relations humaines sont des atouts et des valeurs qui nous sont chères et que nous jugeons indispensables pour la bonne réussite dans notre réseau.

</p><br />

</td>
</tr>
</table>
<script type="text/javascript">
    window.onload = function () {
        var sousMenuload = document.getElementById("sousmenu2");
        var sousMenuloadcolor = document.getElementById("recrutement_aijelebonprofil");
        sousMenuload.style.display = "block";
        sousMenuloadcolor.style.background = "#008282";
    }
    
</script>
</asp:Content>
