<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="recrutement_accompagnement.aspx.cs" Inherits="pages_recrutement_accompagnement" Title="PATRIMONIUM : Recrutement accompagnement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table cellpadding="6" cellspacing="15" style="font-size: 12pt" >
<tr><td valign="top">
<!--#include file="./recrutementmenugauche.aspx"-->
</td>
<td>
<p><strong>Notre siège et nos managers sont à votre disposition pour les services suivants:</strong></p>

<p style="text-align: justify">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Répondre à vos questions lors de votre démarrage et accompagnement dans vos démarches d’inscription.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assistance informatique et logicielle gratuite et illimitée.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Organisation des formations, gratuites et illimitées au siège et en région.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Qualification des acheteurs potentiels et envoi des coordonnées aux conseillers <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Contrôle de la rédaction de vos annonces, la qualité des photos, et la vérification de vos publications sur les différents supports.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Traduction de vos annonces en anglais et assistance à tous les niveaux d’un client étranger los des transactions<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Vérification de la validité de vos mandats et leur conformité à la loi.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Un contrôle et un suivi de tous les documents de la signature du compromis à l’acte authentique.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Résolution des dossiers qui comportent des irrégularités.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Vérification de la validité des mandats cession de commerces, droit au bail et location de locaux commerciaux.

</p><br />

</td>
</tr>
</table>
<script type="text/javascript">
    window.onload = function () {
        var sousMenuload = document.getElementById("sousmenu1");
        var sousMenuloadcolor = document.getElementById("recrutement_accompagnement");
        sousMenuload.style.display = "block";
        sousMenuloadcolor.style.background = "#008282";
    }
    
</script>
</asp:Content>
