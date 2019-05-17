<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="afficher_acquereur.aspx.cs" Inherits="afficher_acquereur" %>

<%@ Register TagPrefix="uc" TagName="controlAjoutAcquereur" Src="controlAjoutAcquereur.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:PlaceHolder ID="PlaceHolderTest" runat="server"></asp:PlaceHolder>
        <!-- Ce morceau contient le javascript de la page -->
        <script type="text/javascript" src="checkfield.js"></script>
        <strong>
            <asp:Label ID="LabelErrorLogin" runat="server" class="rouge"></asp:Label></strong>
        <strong>
            <asp:Label ID="LabelOk" runat="server"></asp:Label></strong>
        <!-- Formulaire d'ajout de l'acquéreur -->
        <div class="contenu_ongletGA">
            <fieldset class="fieldset_20champs">
                <legend><strong>Général</strong></legend>
                <table>
                    <tr>
                        <td colspan="2">
                            <asp:RadioButton ID="RadioButtonMr" runat="server" GroupName="radioButtonGroup" Text="Mr"
                                Checked="true" />
                            <asp:RadioButton ID="RadioButtonMlle" runat="server" GroupName="radioButtonGroup"
                                Text="Mlle" />
                            <asp:RadioButton ID="RadioButtonMme" runat="server" GroupName="radioButtonGroup"
                                Text="Mme" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nom *
                        </td>
                        <td style="width: 192px">
                            <asp:TextBox ID="TextBoxNom" runat="server" CssClass="tb150" Width="173px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="PersonalInfoGroup"
                                ControlToValidate="TextBoxNom" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                        <td class="cellulePetite" style="width: 50px">
                            Prénom
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="TextBoxPrenom" runat="server" CssClass="tb150"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Adresse
                        </td>
                        <td colspan="3" style="width: 174px">
                            <asp:TextBox ID="TextBoxAdresse" runat="server" CssClass="tb150" Width="399px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Ville
                        </td>
                        <td style="width: 192px">
                            <asp:TextBox ID="TextBoxVille" runat="server" CssClass="tb150" Width="175px"></asp:TextBox>
                        </td>
                        <td class="cellulePetite" style="width: 50px">
                            Code postal
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxCodePostal" runat="server" CssClass="tb150"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Pays
                        </td>
                        <td style="width: 192px">
                            <asp:TextBox ID="TextBoxPays" runat="server" CssClass="tb150" Width="175px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tel *
                        </td>
                        <td style="width: 192px">
                            <asp:TextBox ID="TextBoxTel" runat="server" CssClass="tb150" Width="172px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="PersonalInfoGroup"
                                ControlToValidate="TextBoxTel" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                        <td class="cellulePetite" style="width: 50px">
                            Portable
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxPortable" runat="server" CssClass="tb150"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Mail
                        </td>
                        <td style="width: 192px">
                            <asp:TextBox ID="TextBoxMail" runat="server" CssClass="tb150" Width="171px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset class="fieldset_23champs">
                <legend><strong>Caractéristiques principales</strong></legend>
                <table>
                    <tr>
                        <td colspan="2">
                            <asp:CheckBox ID="CheckBoxAppartement" runat="server" Text="Appartement" Checked="true"
                                Font-Bold="false" AutoPostBack="true"></asp:CheckBox>
                            <asp:CheckBox ID="CheckBoxMaison" runat="server" Text="Maison" Font-Bold="false"
                                AutoPostBack="true"></asp:CheckBox>
                            <asp:CheckBox ID="CheckBoxTerrain" runat="server" Text="Terrain" Font-Bold="false"
                                AutoPostBack="true"></asp:CheckBox>
                            <asp:CheckBox ID="CheckBoxAutre" runat="server" Text="Autre" Font-Bold="false" AutoPostBack="true">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Type d'acquereur
                            <asp:TextBox ID="TextBoxType_acquereur" runat="server" CssClass="tb150" Width="171px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Recherche
                            <asp:TextBox ID="TextBoxRecherche" runat="server" CssClass="tb150" 
                                Width="171px"></asp:TextBox>
                        </td>
                        <td colspan="2">
                            <asp:CheckBox ID="CheckBoxVendeur" runat="server" Text="Vendeur" Font-Bold="false"
                                AutoPostBack="true"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr id="etat_avancement">
                        <td>
                            Etat avancement
                            <asp:TextBox ID="TextBoxEtatAvancement" runat="server" CssClass="tb150" 
                                Width="171px"></asp:TextBox>
                        </td>
                </table>
                <br />
                <br />
            </fieldset>
        </div>
        <div class="contenu_ongletGB">
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
            </asp:ScriptManager>
            <uc:controlAjoutAcquereur ID="ucAjoutAcquereur" runat="server" />
            <fieldset class="fieldset_20champs">
                <legend><strong>Critères</strong></legend>
                <table class="tablecarateristique">
                    <tr>
                        <td>
                            Prix min
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxPrixMin" runat="server" CssClass="tb75"></asp:TextBox>&nbsp;&#8364;&nbsp;&nbsp;&nbsp;
                        </td>
                        <td>
                            Prix max
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxPrixMax" runat="server" CssClass="tb75"></asp:TextBox>&nbsp;&#8364;
                        </td>
                    </tr>
                    <%if (CheckBoxAppartement.Checked || CheckBoxMaison.Checked)
                      {%>
                    <tr>
                        <td>
                            Nb de pièces min
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxPiecesMin" runat="server" CssClass=" tb40"></asp:TextBox>
                        </td>
                        <td>
                            Nb de pièces max
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxPiecesMax" runat="server" CssClass=" tb40"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nb de chambres min
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxChambresMin" runat="server" CssClass=" tb40"></asp:TextBox>
                        </td>
                        <td>
                            Nb de chambres max
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxChambresMax" runat="server" CssClass=" tb40"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Surface habitable min
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSurfaceHabitableMin" runat="server" CssClass=" tb40"></asp:TextBox>m²
                        </td>
                        <td>
                            Surface habitable max
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSurfaceHabitableMax" runat="server" CssClass=" tb40"></asp:TextBox>m²
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Surface séjour min
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSurfaceSejourMin" runat="server" CssClass=" tb40"></asp:TextBox>m²
                        </td>
                        <td>
                            Surface séjour max
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSurfaceSejourMax" runat="server" CssClass=" tb40"></asp:TextBox>m²
                        </td>
                    </tr>
                    <%} %>
                    <%if (CheckBoxTerrain.Checked)
                      {%>
                    <tr>
                        <td>
                            Façade
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxFacade" runat="server" CssClass="tb40"></asp:TextBox>m²
                        </td>
                        <td>
                            Profondeur
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxProfondeur" runat="server" CssClass=" tb40"></asp:TextBox>m²
                        </td>
                    </tr>
                    <%}
                      if (CheckBoxTerrain.Checked || CheckBoxMaison.Checked)
                      { %>
                    <tr>
                        <td>
                            Surface terrain min
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSurfaceTerrainMin" runat="server" CssClass=" tb40"></asp:TextBox>m²
                        </td>
                        <td>
                            Surface terrain max
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSurfaceTerrainMax" runat="server" CssClass=" tb40"></asp:TextBox>m²
                        </td>
                    </tr>
                    <%} %>
                    <%if (CheckBoxAppartement.Checked)
                      {%>
                </table>
                <table>
                    <tr>
                        <td>
                            Ascenseur
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxAscenseur" runat="server"></asp:CheckBox>
                        </td>
                        <%} %>
                        <%if (CheckBoxMaison.Checked || CheckBoxAppartement.Checked)
                          {%>
                        <td>
                            &nbsp;Sous-sol
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxSousSol" runat="server"></asp:CheckBox>
                        </td>
                        <td>
                            &nbsp;Parking/Box
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBoxParking" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                    <%} %>
                </table>
            </fieldset>
            <fieldset class="fieldset_22champs">
                <legend><strong>Informations complémentaires (balcon,...)</strong></legend>
                <asp:TextBox ID="TextBoxTexteComplementaire" runat="server" TextMode="multiline"
                    CssClass="tbinformation"></asp:TextBox>
            </fieldset>
        </div>
        <%if (Session["ajout_acquereur"] == "true")
          {%>
        <%}
          else
          {%>
        <%}%>
    </div>
</asp:Content>

