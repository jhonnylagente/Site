<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="ajoutCommissionLibre.aspx.cs" Inherits="ajoutCommissionLibre" Title="Ajout De Commission Libre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" src="../JavaScript/calendar.js"></script>

<script>

    function validationAjoutCommission() {

        var valid = true;

        $("#croixCommissionAcq").hide();
        $("#croixCommissionVente").hide(); 

        if ($("#<%=ajoutCommissionAcq.ClientID%>").val() == "" && $("#<%=ajoutCommissionVente.ClientID%>").val() == "") {

            $("#<%=msgErreur.ClientID%>").text("Veuillez entrer au moins une commission libre à ajouter");
            $("#<%=msgErreur.ClientID%>").show();
            $("#croixCommissionAcq").show();
            $("#croixCommissionVente").show();

            valid = false;
        }

        if (isNaN($("#<%=ajoutCommissionAcq.ClientID%>").val()) || isNaN($("#<%=ajoutCommissionVente.ClientID%>").val())) {

            $("#<%=msgErreur.ClientID%>").text("Veuillez entrer uniquement des nombres");
            $("#<%=msgErreur.ClientID%>").show();

            if (isNaN($("#<%=ajoutCommissionAcq.ClientID%>").val()))
                $("#croixCommissionAcq").show();

            if (isNaN($("#<%=ajoutCommissionVente.ClientID%>").val()))
                $("#croixCommissionVente").show();

            valid = false;
        }

        if ($("#<%=ajoutCommissionAcq.ClientID%>").val() == "") {

            if (parseInt($("#<%=ajoutCommissionVente.ClientID%>").val()) > parseInt($("#<%=commissionDispoAjoutTextBox.ClientID%>").val())) {
                $("#croixCommissionVente").show();
                $("#<%=msgErreur.ClientID%>").text("Le montant des commissions à ajouter ne doit pas excéder le montant de commission disponible pour l'ajout");
                $("#<%=msgErreur.ClientID%>").show();
                valid = false;
            }
        }

        if ($("#<%=ajoutCommissionVente.ClientID%>").val() == "") {

            if (parseInt($("#<%=ajoutCommissionAcq.ClientID%>").val()) > parseInt($("#<%=commissionDispoAjoutTextBox.ClientID%>").val())) {
                $("#croixCommissionAcq").show();
                $("#<%=msgErreur.ClientID%>").text("Le montant des commissions à ajouter ne doit pas excéder le montant de commission disponible pour l'ajout");
                $("#<%=msgErreur.ClientID%>").show();
                valid = false;
            }
        }

        if ($("#<%=ajoutCommissionVente.ClientID%>").val() != "" && $("#<%=ajoutCommissionAcq.ClientID%>").val() != "") {
            if ( (parseInt($("#<%=ajoutCommissionAcq.ClientID%>").val()) + parseInt($("#<%=ajoutCommissionVente.ClientID%>").val()) ) > parseInt($("#<%=commissionDispoAjoutTextBox.ClientID%>").val())) {
                $("#croixCommissionAcq").show();
                $("#croixCommissionVente").show();
                $("#<%=msgErreur.ClientID%>").text("Les montant des commissions à ajouter ne doivent pas excéder le montant de commission disponible pour l'ajout");
                $("#<%=msgErreur.ClientID%>").show();
                valid = false;
            }
        }

        if ($("#<%=ajoutCommissionVente.ClientID%>").val() != "" && (parseInt($("#<%=ajoutCommissionVente.ClientID%>").val()) < 0)) {
            $("#croixCommissionVente").show();
            $("#<%=msgErreur.ClientID%>").text("Le montant des commissions à ajouter ne doit pas être négatif");
            $("#<%=msgErreur.ClientID%>").show();
            valid = false;
        }

        if ($("#<%=ajoutCommissionAcq.ClientID%>").val() != "" && (parseInt($("#<%=ajoutCommissionAcq.ClientID%>").val()) < 0)) {
            $("#croixCommissionAcq").show();
            $("#<%=msgErreur.ClientID%>").text("Le montant des commissions à ajouter ne doit pas être négatif");
            $("#<%=msgErreur.ClientID%>").show();
            valid = false;
        }

        return valid;

    }

    function validationAjoutCommissionSolo() {

        $("#croixCommissionSolo").hide();

        var valid = true;

        if ($("#<%=ajoutCommissionSolo.ClientID%>").val() == "") {

            $("#<%=msgErreur.ClientID%>").text("Veuillez entrer une commission libre à ajouter");
            $("#<%=msgErreur.ClientID%>").show(); 
            $("#croixCommissionSolo").show();
            valid = false;
        }

        if (isNaN($("#<%=ajoutCommissionSolo.ClientID%>").val())) {

            $("#<%=msgErreur.ClientID%>").text("Veuillez entrer uniquement des nombres");
            $("#<%=msgErreur.ClientID%>").show(); 
            $("#croixCommissionSolo").show();
            valid = false;
        }

        if (parseInt($("#<%=ajoutCommissionSolo.ClientID%>").val()) > parseInt($("#<%=commissionDispoAjoutTextBox.ClientID%>").val())) {
            $("#<%=msgErreur.ClientID%>").text("Le montant des commissions à ajouter ne doit pas excéder le montant de commission disponible pour l'ajout");
            $("#<%=msgErreur.ClientID%>").show();
            $("#croixCommissionSolo").show();
            valid = false;
        }

        if (parseInt($("#<%=ajoutCommissionSolo.ClientID%>").val()) < 0) {
            $("#<%=msgErreur.ClientID%>").text("Le montant des commissions à ajouter ne doit pas être négatif");
            $("#<%=msgErreur.ClientID%>").show();
            $("#croixCommissionSolo").show();
            valid = false;
        }

        return valid;

    }

</script>

<center>
<br />
<div>

<div class="addAccountTitle">Récapitulatif de la vente</div>
<br/>

<table id="referenceVente" runat="server">
<tr><td style="font-weight:bold">Vente référence</td><td>: <asp:Label id="refVente" runat="server"/></td><td style="width:40px"></td><td style="font-weight:bold">Prix de vente</td><td>: <asp:Label id="prixVente" runat="server"/></td><td style="width:40px"></td><td style="font-weight:bold">Commission sur la vente</td><td>: <asp:Label id="commissionVente" runat="server"/> €<asp:TextBox runat="server" ID="commissionVenteTextBox"  style="display:none;"/></td></tr>
</table>
<br />
<table>
<tr><td style="font-weight:bold">Somme des commissions a payer sur la vente</td><td>: <asp:Label runat="server" id="sommeCommissionVente" /> €<asp:TextBox ID="sommeCommissionVenteTxtBox" runat="server" style="display:none;" /></td></tr>
</table>

<br/>
<div class="addAccountTitle">Négociateur(s)</div>
<br/>

<table id="tableCommissionDispo" runat="server">
<tr><td style="font-weight:bold">Commissions disponible pour ajout</td><td>: <asp:Label runat="server" ID="commissionDispoAjout" /> €<asp:TextBox runat="server" ID="commissionDispoAjoutTextBox" style="display:none;"/></td></tr>
</table>

<br />

<table id="tableDoubleNego" visible="false" runat="server">
<tr><td colspan=9 style="height:35px"><hr style="width:90%"/></td></tr>
<tr><td style="display:none;"><asp:Textbox runat="server" ID="idNegoAcq" /></td><td style="font-weight:bold">Négociateur acquéreur</td><td>: <asp:Label id="nomNegoAcq" runat="server"/></td><td style="width:40px"></td><td style="font-weight:bold">Commission du négociateur</td><td>: <asp:Label id="commissionNegoAcq" runat="server"/> dont <asp:Label runat="server" id="commissionLibreAcq" /> € de commission libre <asp:TextBox runat="server" ID="commissionLibreAcqTextBox" style="display:none;" /></td><td style="width:40px"></td></tr>
<tr><td style="height:1px"></td></tr>
<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td style="font-weight:bold">Commission libre à ajouter</td><td>: <asp:TextBox runat="server" ID="ajoutCommissionAcq" style="width:80px; text-align:right;"/> €</td><td><img id="croixCommissionAcq" class="croix_rouge" src="../img_site/croix_rouge.png" style="display:none;"/></td></tr>
<tr><td style="height:40px">&nbsp;</td></tr>
<tr><td style="display:none;"><asp:Textbox runat="server" ID="idNegoVente" /></td><td style="font-weight:bold">Négociateur vendeur</td><td>: <asp:Label id="nomNegoVente" runat="server"/></td><td style="width:40px"></td><td style="font-weight:bold">Commission du négociateur</td><td>: <asp:Label id="commissionNegoVente" runat="server"/> dont <asp:Label runat="server" id="commissionLibreVente" /> € de commission libre <asp:TextBox runat="server" ID="commissionLibreVenteTextBox" style="display:none;" /></td><td style="width:40px"></td></tr>
<tr><td style="height:1px"></td></tr>
<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td style="font-weight:bold">Commission libre à ajouter</td><td>: <asp:TextBox runat="server" ID="ajoutCommissionVente" style="width:80px; text-align:right;"/> €</td><td><img id="croixCommissionVente" class="croix_rouge" src="../img_site/croix_rouge.png" style="display:none;"/></td></tr>
</table>

<table id="tableNegoSolo" visible="false" runat="server">
<tr><td colspan=9 style="height:35px"><hr style="width:90%"/></td></tr>
<tr><td style="display:none;"><asp:Textbox runat="server" ID="idNegoSolo" /></td><td style="font-weight:bold">Négociateur</td><td>: <asp:Label runat="server" ID="nomNegoSolo" /></td><td style="width:40px"></td><td style="font-weight:bold">Commission du négociateur</td><td>: <asp:Label runat="server" ID="commissionNegoSolo"/> dont <asp:Label runat="server" id="commissionLibreSolo" /> € de commission libre <asp:TextBox runat="server" ID="commissionLibreSoloTextBox" style="display:none;" /></td><td style="width:40px"></td><td style="font-weight:bold">Commission libre à ajouter</td><td>: <asp:TextBox runat="server" ID="ajoutCommissionSolo" style="width:80px; text-align:right;"/> €</td><td><img id="croixCommissionSolo" class="croix_rouge" src="../img_site/croix_rouge.png" style="display:none;"/></td></tr>
</table>

<br/>
<asp:Label runat="server" class="msg rouge" ID="msgErreur" style="display:none; font-weight:bold;"/>
<br/><br/>
<asp:Button runat="server" id="btnEnregistrerCommission" class="myButton" visible="false" OnClientClick="return validationAjoutCommission();" OnClick="EnregistrerCommissionDuo" Text="Enregistrer les commissions libre"/>
<asp:Button runat="server" id="btnEnregistrerCommissionSolo" class="myButton" visible="false" OnClientClick="return validationAjoutCommissionSolo();" OnClick="EnregistrerCommissionSolo" Text="Enregistrer les commissions libre"/>
<br /><br/>
<div id="confirmationEnregistrement" visible="false" class="msg rouge" runat="server" style="font-weight:bold">Enregistrement de ou des commissions libre effectué</div>
</div>
</center>
</asp:Content>
