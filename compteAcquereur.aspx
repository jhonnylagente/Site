<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="compteAcquereur.aspx.cs" Inherits="pages_compteAcquereur" Title="PATRIMONIUM : Modifier mes coordonnées" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<!-- Ce morceau contient le javascript de la page -->
<script type="text/javascript" src="checkfield.js"></script>

<strong><asp:Label ID="LabelErrorLogin" runat="server" class="rouge"></asp:Label></strong>
<strong><asp:Label ID="LabelOk" runat="server"></asp:Label></strong>
   
<table class="moncompte">
    <tr>
        <td class="moncompteG1">
            <b>Mes options</b>
        </td>
        <td class="moncompteD1">
           <strong>Ajouter un Acquereur</strong>
            
        </td>
    </tr>
    
    <tr>
        <td class="moncompteG">
            <% Membre member = (Membre)Session["Membre"]; %>
            <!-- Menu de liens à gauche -->
            <!--#include file="./menumoncompte.aspx"-->                            
        </td>
        <td  class="moncompteD">
        
        <div class="acquereur">
        <fieldset>
        <legend><strong>Inscription d'un acquéreur</strong></legend>
            <table cellpadding="0" cellspacing="10">
                <tr>
                    <td class="normal3">
                        Civilité :</td>
                    <td>
                        <asp:RadioButton ID="RadioButtonMme" runat="server" GroupName="radioButtonGroup" Text="Mme" />
                        <asp:RadioButton ID="RadioButtonMlle" runat="server" GroupName="radioButtonGroup" Text="Mlle" />
                        <asp:RadioButton ID="RadioButtonMr" runat="server" GroupName="radioButtonGroup" Text="Mr" />
                    </td>
                </tr>
                <tr> 
                    <td class="normal3">Nom* :</td>
                    <td ><asp:TextBox ID="TextBoxNom" runat="server" onchange='javascript:checkfield_alpha("balise_spoiler", this.value)'></asp:TextBox></td>
                    <td id="balise_spoiler" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                </tr>
                <tr>
                    <td class="normal3">Prénom :</td>
                    <td ><asp:TextBox ID="TextBoxPrenom" runat="server" onchange='javascript:checkfield_alpha("balise_spoiler2", this.value)'></asp:TextBox></td>
                    <td id="balise_spoiler2" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                </tr>           
                <tr>
                    <td class="normal3">Adresse :</td>
                    <td ><asp:TextBox ID="TextBoxAdresse" runat="server" onchange='javascript:checkfield_alpha("balise_spoiler3", this.value)'></asp:TextBox></td>
                    <td id="balise_spoiler3" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                </tr>
                <tr>
                    <td class="normal3">Code Postal :</td>
                    <td ><asp:TextBox ID="TextBoxCodePostal" runat="server" onchange='javascript:checkfield_num("balise_spoiler4", this.value)'></asp:TextBox></td>
                    <td id="balise_spoiler4" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                </tr>
                <tr>
                    <td class="normal3">Ville :</td>
                    <td><asp:TextBox ID="TextBoxVille" runat="server" onchange='javascript:checkfield_alpha("balise_spoiler5", this.value)'></asp:TextBox></td>
                    <td id="balise_spoiler5" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                </tr>
                <tr>
                    <td class="normal3">Tel* :</td>
                    <td><asp:TextBox ID="TextBoxTel" runat="server" onchange='javascript:checkfield_alpha_num("balise_spoiler6", this.value)'></asp:TextBox></td>
                    <td id="balise_spoiler6" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                </tr>
                <tr>
                    <td class="normal3">Mail :</td>
                    <td><asp:TextBox ID="TextBoxMail" runat="server" onchange='javascript:checkfield_mail("balise_spoiler7", this.value)'></asp:TextBox></td>
                    <td id="balise_spoiler7" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                </tr>
                <tr>
                    <td class="normal3">Pays :</td>
                    <td><asp:TextBox ID="TextBoxPays" runat="server" onchange='javascript:checkfield_alpha("balise_spoiler8", this.value)'></asp:TextBox></td>
                    <td id="balise_spoiler8" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                </tr>
                <tr  >
                    <td colspan=2 class="boutonMilieu">
                        <asp:Button ID="ButtonEnregistrer" runat="server" Text="Enregistrer" OnClick="ajouterAcquereur" />  
                    </td>
                </tr>
            </table>
        </fieldset>
        </div>   
             
        </td>
    </tr>
</table>
       


</asp:Content>

