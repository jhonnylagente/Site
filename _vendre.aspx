<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="_vendre.aspx.cs" Inherits="vendre" Title="PATRIMONIUM : Vendre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<script>
    function verifForm() {
        var isValid = true;
        if ($('#<%= TextBoxNomvestimer.ClientID %>').text() == "") { $('#RequiredFieldValidator1').text("Veuillez saisir votre nom"); isValid = false; }
        if ($('#<%= TextBoxPrenomvestimer.ClientID %>').text() == "") { $('#RequiredFieldValidator2').text("Veuillez saisir votre prénom"); isValid = false; }
        if ($('#<%= TextBoxTelvestimer.ClientID %>').text() == "") {$('#RequiredFieldValidator3').text("Veuillez saisir votre téléphone";); isValid = false;}
        if ($('#<%= TextBoxEmailvestimer.ClientID %>').text() == "") { $('#RequiredFieldValidator4').text("Veuillez saisir votre email";); isValid = false; }
        return isValid;
    }
</script>
    <table>
        <tr>
            <td>
                <div id="present" style="width: 1080px; float: left">
                    <h3>
                        &nbsp;&nbsp;&nbsp;&nbsp; Je vends</h3>
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp; Vous souhaitez faire estimer votre bien ?</p>
                    <asp:Label ID="Label1" runat="server" Width="1100px" Style="text-align: center;"> </asp:Label></div>
            </td>
        </tr>
        <tr>
            <td>
                <div id="formavis" runat="server">
                    <table>
                        <tr>
                            <td valign="top">
                                <table>
                                    <tr>
                                        <td>
                                            <a href="Recherche_agent.aspx">
                                                <img id="botton_votreagent" src="../img_site/image_patrimo_votreagent.jpg" alt="votreagent" /></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="vendre_estimer.aspx">
                                                <img id="botton_estimation" src="../img_site/image_patrimo_estimation.jpg" alt="estimation" /></a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="left" valign="top" style="width: 500px">
                                <table class="tableestimer" style="width: 500px">
                                    <tr>
                                        <td class="estimertitle" style="width: 186px">
                                            <strong>Votre bien</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            &nbsp;Type de bien
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="TextBoxTypedebienvestimer" runat="server" CssClass="tbsanswidth"
                                                Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            &nbsp;Surface habitation
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="TextBoxSurfacehabitablevestimer" runat="server" CssClass="tbsanswidth"
                                                Width="200px"></asp:TextBox>
                                            m²
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            &nbsp;Surface terrain
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="TextBoxSurfaceterrainvestimer" runat="server" CssClass="tbsanswidth"
                                                Width="200px"></asp:TextBox>
                                            m²
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            &nbsp;Nombre de pièces
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="TextBoxnombredepiecevestimer" runat="server" CssClass="tbsanswidth"
                                                Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            &nbsp;Localisation
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="TextBoxlocalisationvestimer" runat="server" CssClass="tbsanswidth"
                                                Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            &nbsp;Prix de vente souhaité
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="TextBoxprixvestimer" runat="server" CssClass="tbsanswidth" Width="200px"></asp:TextBox>
                                            &#8364;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            &nbsp;Votre message
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="TextBoxmessagevestimer" runat="server" CssClass="tbsanswidth"
                                                Width="200px" Height="120px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="estimertitle" style="width: 186px">
                                            <strong>Vos coordonnées</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            &nbsp;*Votre nom
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="TextBoxNomvestimer" runat="server" CssClass="tbsanswidth" Width="200px"></asp:TextBox>
                                            <span ID="RequiredFieldValidator1" style='color:Red;' runat="server"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            *Prénom
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="TextBoxPrenomvestimer" runat="server" CssClass="tbsanswidth"
                                                Width="200px"></asp:TextBox>
                                           <span ID="RequiredFieldValidator2" style='color:Red;' runat="server"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            *Téléphone
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="TextBoxTelvestimer" runat="server" CssClass="tbsanswidth" Width="200px"></asp:TextBox>
                                            <span ID="RequiredFieldValidator3" style='color:Red;' runat="server"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            *Email
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="TextBoxEmailvestimer" runat="server" CssClass="tbsanswidth" Width="200px"></asp:TextBox>
                                            <span ID="RequiredFieldValidator4" style='color:Red;' runat="server"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            Adresse
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="TextBoxAdressevestimer" runat="server" CssClass="tbsanswidth"
                                                Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            Code Postal
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="TextBoxCodePostalvestimer" runat="server" CssClass="tbsanswidth"
                                                Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            Ville
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="TextBoxVillevestimer" runat="server" CssClass="tbsanswidth" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            Nom du conseiller PATRIMO
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="TextBox1vestimer" runat="server" CssClass="tbsanswidth" Width="200px"> </asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top">
                                <table>
                                    <tr>
                                        <td>
                                            <a href="./recrutement.aspx">
                                                <img id="botton_recrutement" src="../img_site/image_patrimo_recrutement.jpg" alt="recrutement" /></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="recrutement_remuneration.aspx">
                                                <img src="../img_site/remuneration.gif" alt="remuneration" /></a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <center>
                    <asp:Button ID="BoutonEnvoyer" runat="server" Text="Envoyer" OnClick="BoutonEnvoyer_Click"
                        Height="35px" CssClass="myButton" /></center>
            </td>
        </tr>
        <tr>
            <td>
                <center>
                    - Les champs précédés d'une astérisque * sont obligatoires.</center>
            </td>
        </tr>
    </table>
</asp:Content>
