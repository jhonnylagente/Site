<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="louver.aspx.cs" Inherits="louver" Title="PATRIMONIUM : Louver" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>
                <div id="present" style="width: 1080px; float: left">
                    <h3>
                        &nbsp;&nbsp;&nbsp;&nbsp; Je loue</h3>
                    <p>
                        &nbsp;&nbsp;&nbsp;&nbsp; Vous souhaitez faire gérer votre bien ?</p>
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
                                        <td class="estimertitle">
                                            <strong>Votre bien</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            &nbsp;Type de bien
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxTypedebienlestimer" runat="server" CssClass="tbsanswidth"
                                                Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            &nbsp;Surface habitation
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxSurfacehabitablelestimer" runat="server" CssClass="tbsanswidth"
                                                Width="200px"></asp:TextBox>
                                            m²
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            &nbsp;Surface terrain
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxSurfaceterrainlestimer" runat="server" CssClass="tbsanswidth"
                                                Width="200px"></asp:TextBox>
                                            m²
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            &nbsp;Nombre de pièces
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxnombredepiecelestimer" runat="server" CssClass="tbsanswidth"
                                                Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            &nbsp;Localisation
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxlocalisationlestimer" runat="server" CssClass="tbsanswidth"
                                                Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            &nbsp;Prix de vente souhaité
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxprixlestimer" runat="server" CssClass="tbsanswidth" Width="200px"></asp:TextBox>
                                            &#8364;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            &nbsp;Votre message
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxmessagelestimer" runat="server" CssClass="tbsanswidth"
                                                Width="200px" Height="120px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="estimertitle">
                                            <strong>Vos coordonnées</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            &nbsp;*Votre nom
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxNomlestimer" runat="server" CssClass="tbsanswidth" Width="200px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TextBoxNomlestimer"
                                                runat="server" ErrorMessage="Veuillez saisir votre nom"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            *Prénom
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxPrenomlestimer" runat="server" CssClass="tbsanswidth"
                                                Width="200px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextBoxPrenomlestimer"
                                                runat="server" ErrorMessage="Veuillez saisir votre prénom"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            *Téléphone
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxTellestimer" runat="server" CssClass="tbsanswidth" Width="200px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="TextBoxTellestimer"
                                                runat="server" ErrorMessage="Veuillez saisir votre téléphone"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            *Email
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxEmaillestimer" runat="server" CssClass="tbsanswidth" Width="200px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="TextBoxEmaillestimer"
                                                runat="server" ErrorMessage="Veuillez saisir votre email"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            Adresse
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxAdresselestimer" runat="server" CssClass="tbsanswidth"
                                                Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            Code Postal
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxCodePostallestimer" runat="server" CssClass="tbsanswidth"
                                                Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            Ville
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxVillelestimer" runat="server" CssClass="tbsanswidth" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="normal3" style="width: 186px">
                                            Nom du conseiller PATRIMO
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBox1lestimer" runat="server" CssClass="tbsanswidth" Width="200px"> </asp:TextBox>
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
                    <asp:Button ID="Buttonlestimer" runat="server" Text="Envoyer" OnClick="Buttonlestimer_Click"
                        Height="35px" CssClass="myButton" Width="150px" /></center>
            </td>
        </tr>
        <tr>
            <td>
                <center>
                    - Les champs précédés d'une astérisque * sont obligatoires.</center>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
    
    </script>
</asp:Content>
