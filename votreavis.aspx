<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="votreavis.aspx.cs" Inherits="votreavis" Title="PATRIMONIUM : Votre-avis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>
                <div id="present" style="width: 1080px">
                    <h3>
                        VOTRE AVIS NOUS INTERESSE!</h3>
                    <p>
                        Vous avez rencontré récemment un conseiller en immobilier PATRIMO dans le cadre
                        de la vente ou de l&#8217;achat d&#8217;un bien immobilier.<br />
                        La priorité de PATRIMO restant l&#8217;aboutissement de votre projet par un accompagnement
                        de qualité et personnalisé, nous souhaiterions connaître, par le biais d&#8217;un
                        simple questionnaire, votre degré de satisfaction afin d&#8217;adapter au mieux
                        nos prestations et répondre à vos attentes.Nous restons à votre entière disposition
                        pour tous renseignements complémentaires. Nous vous remercions de nous accorder
                        de votre temps et vous prions de croire, cher(e) client(e), à nos sentiments les
                        plus sincères.</p>
                    <asp:Label ID="Label1" runat="server" Width="1100px" Style="text-align: center;"> </asp:Label></div>
            </td>
        </tr>
        <tr>
            <td>
                <div id="formavis" runat="server">
                    <fieldset class="fieldsetContact">
                        <legend>Merci de remplir ce Questionnaire!</legend>
                        <table>
                            <tr>
                                <td align="center" valign="top">
                                    <table class="table_contact">
                                        <tr>
                                            <td valign="top" class="normal3">
                                                Vous êtes *
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="Acquéreur" runat="server" Text="Acquéreur" GroupName="proprietes" />
                                                <asp:RadioButton ID="Vendeur" runat="server" Text="Vendeur" GroupName="proprietes" />
                                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>		<!--FIX ME -->
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" class="normal3">
                                                Nom *
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxNomvotreavis" runat="server" CssClass=" tbsanswidth"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TextBoxNomvotreavis"
                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>	<!--FIX ME -->
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" class="normal3">
                                                Pr&eacute;nom *
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxPrenomvotreavis" runat="server" CssClass=" tbsanswidth"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="TextBoxPrenomvotreavis"
                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>		<!--FIX ME -->
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" class="normal3">
                                                Téléphone
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxTelvotreavis" runat="server" CssClass=" tbsanswidth"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" class="normal3">
                                                Email *
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxEmailvotreavis" runat="server" CssClass=" tbsanswidth"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="TextBoxEmailvotreavis"
                                                    runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>		<!--FIX ME -->
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" class="normal3">
                                                Adresse
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxAdressevotreavis" runat="server" CssClass=" tbsanswidth"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" class="normal3">
                                                Code Postal
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxCodePostalvotreavis" runat="server" CssClass=" tbsanswidth"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" class="normal3">
                                                Ville
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBoxVillevotreavis" runat="server" CssClass=" tbsanswidth"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <%--          </table>
                  <table>--%>
                                        <tr>
                                            <td valign="top" class="normal3">
                                                Nom du conseiller PATRIMO
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox1votreavis" runat="server" CssClass=" tbsanswidth"> </asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <!-- Envoie de mail -->
                                        <tr>
                                            <td valign="top" class="normal3">
                                                Merci de préciser votre demande:
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="left">
                                                <asp:TextBox class="textmail" ID="tbBodyvotreavis" runat="server" TextMode="MultiLine" Height="30px" Width="150" CssClass=" tbsanswidth"></asp:TextBox><br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Button Style="right: 3px;" ID="Buttonvotreavis" runat="server" Text="Envoyer"
                                                    CssClass="myButton" OnClick="Buttonvotreavis_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                    <center>
                                        - Les champs précédés d'une astérisque * sont obligatoires.</center>
                                </td>
                                <td align="center" valign="top">
                                    <table>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <img src="../img_site/entete_form_avis_01.gif" alt="++" title="++" width="60" height="85" />
                                            </td>
                                            <td>
                                                <img src="../img_site/entete_form_avis_02.gif" alt="++" title="++" width="60" height="85" />
                                            </td>
                                            <td>
                                                <img src="../img_site/entete_form_avis_03.gif" alt="++" title="++" width="60" height="85" />
                                            </td>
                                            <td>
                                                <img src="../img_site/entete_form_avis_04.gif" alt="++" title="++" width="60" height="85" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                La présentation et l'attitude de votre conseiller<br />
                                                (Tenue - Sympathie ...)
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Très Satisfait" GroupName="1" ID="radio1" />
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Satisfait" GroupName="1" ID="radio2" />
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Pas satisfait" GroupName="1" ID="radio3" />
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Pas du tout satisfait" GroupName="1" ID="radio4" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                L'écoute et la compréhension de vos attentes
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Très Satisfait" GroupName="2" ID="radio5" />
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Satisfait" GroupName="2" ID="radio6" />
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Pas satisfait" GroupName="2" ID="radio7" />
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Pas du tout satisfait" GroupName="2" ID="radio8" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                La présentation des services et de l'accompagnement proposés
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Très Satisfait" GroupName="3" ID="radio9" />
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Satisfait" GroupName="3" ID="radio10" />
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Pas satisfait" GroupName="3" ID="radio11" />
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Pas du tout satisfait" GroupName="3" ID="radio12" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                La qualité de l'accompagnement de votre conseiller<br />
                                                (Prise en charge - Ponctualité des RDV - Rappels téléphoniques - Suivi...)
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Très Satisfait" GroupName="4" ID="radio13" />
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Satisfait" GroupName="4" ID="radio14" />
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Pas satisfait" GroupName="4" ID="radio15" />
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Pas du tout satisfait" GroupName="4" ID="radio16" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                L'efficacité de votre conseiller
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Très Satisfait" GroupName="5" ID="radio17" />
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Satisfait" GroupName="5" ID="radio18" />
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Pas satisfait" GroupName="5" ID="radio19" />
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Pas du tout satisfait" GroupName="5" ID="radio20" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Qualité des informations juridiques communiquées
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Très Satisfait" GroupName="6" ID="radio21" />
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Satisfait" GroupName="6" ID="radio22" />
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Pas satisfait" GroupName="6" ID="radio23" />
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Pas du tout satisfait" GroupName="6" ID="radio24" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Qualité des conseils et des biens proposés
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Très Satisfait" GroupName="7" ID="radio25" />
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Satisfait" GroupName="7" ID="radio26" />
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Pas satisfait" GroupName="7" ID="radio27" />
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Pas du tout satisfait" GroupName="7" ID="radio28" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Qualité du suivi commercial et administratif<br />
                                                (Visites de biens - Signature de compromis - Acte authentique)
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Très Satisfait" GroupName="8" ID="radio29" />
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Satisfait" GroupName="8" ID="radio30" />
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Pas satisfait" GroupName="8" ID="radio31" />
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Pas du tout satisfait" GroupName="8" ID="radio32" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Votre opinion en général du service PATRIMO
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Très Satisfait" GroupName="9" ID="radio33" />
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Satisfait" GroupName="9" ID="radio34" />
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Pas satisfait" GroupName="9" ID="radio35" />
                                            </td>
                                            <td>
                                                <asp:RadioButton runat="server" value="Pas du tout satisfait" GroupName="9" ID="radio36" />
                                            </td>
                                        </tr>
                                        <%--<tr>
                        <td>La présentation et l'attitude de votre conseiller<br />(Tenue - Sympathie ...)
                        </td>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                            </asp:RadioButtonList>
                        </td>
                       
                    </tr>--%>
                                        <tr>
                                            <td>
                                                Par quels moyens avez-vous découvert PATRIMO ?
                                            </td>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" Text="Télévision" />
                                                    <asp:CheckBox ID="CheckBox2" runat="server" Text="Internet" />
                                                    <asp:CheckBox ID="CheckBox3" runat="server" Text="Bouche à oreille" />
                                                    <asp:CheckBox ID="CheckBox4" runat="server" Text="Presse papier" />
                                                    <asp:CheckBox ID="CheckBox5" runat="server" Text="Radio" />
                                                </td>
                                            </tr>
                                        </tr>
                                        <tr>
                                            <td>
                                                Recommanderiez-vous PATRIMO autour de vous ?
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:RadioButton runat="server" ID="recommander" value="Oui" GroupName="10" />oui
                                                <asp:RadioButton runat="server" ID="Radi1" value="non" GroupName="10" />non
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
    
    </script>
</asp:Content>
