<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="monCompteCoordonnees.aspx.cs" Inherits="pages_moncomteCoordonnees"
    Title="PATRIMONIUM : Modifier mes coordonn�es" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script type="text/javascript">

    function checksize_field(id_pers,id_texte, value, max_size) {

        var reste = max_size - value.length;
        if (reste >= 0) {
            document.getElementById(id_pers).innerHTML = "<i><font size='2px'> Reste " + reste + " caract�res </font></i>";
        }
        else {
            document.getElementById(id_pers).innerHTML = "<i><font size='2px'> Reste 0 caract�res </font></i>";
            document.getElementById(id_texte).value = value.substring(0, max_size)
        } 
    }
</script>


<table>
    <tr>
        <td colspan=3>
            
            <center>
                <asp:Label ID="LBLBonjour" runat="server" />
                <br /><br />
                <asp:Label ID="LabelErreur" runat="server" Font-Bold="True" ForeColor="Red" Visible="false"></asp:Label>
            </center>
        </td>
    </tr>
    <tr>
        <td style="vertical-align:top">
            <!-- Coord principales -->
            <div class="bloc_monCompte" style="width:400px;margin-left:15px">        
            <table cellpadding="0" cellspacing="8" >
                <tr>
                    <td colspan=2>
                        <center><strong>INFORMATIONS GENERALES</strong></center>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td class="normal3" style="height: 20px;" valign="top">
                        Civilit�*
                    </td>
                    <td style="height: 20px">
                        <asp:RadioButton ID="RadioButtonMme" runat="server" GroupName="radioButtonGroup"
                            Text="Mme" />
                        <asp:RadioButton ID="RadioButtonMlle" runat="server" GroupName="radioButtonGroup"
                            Text="Mlle" />
                        <asp:RadioButton ID="RadioButtonMr" runat="server" GroupName="radioButtonGroup" Text="Mr" />
                    </td>
                </tr>
                <tr valign="top">
                    <td class="normal3" style="height: 20px;" valign="top">
                        Nom :
                    </td>
                    <td style="height: 20px;" valign="top">
                        <asp:TextBox ID="TextBoxNom2" runat="server" Width="250px" CssClass="big_textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="normal3" style="height: 20px;" valign="top">
                        Pr�nom :
                    </td>
                    <td style="height: 20px;" valign="top">
                        <asp:TextBox ID="TextBoxPrenom2" runat="server" Width="250px" CssClass=" big_textbox"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td class="normal3" style="height: 20px;" valign="top">
                        Email :
                    </td>
                    <td style="height: 20px;">
                        <asp:TextBox ID="TextBoxEmail" runat="server" Width="250px" CssClass="big_textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan=2>
                        <asp:Label ID="LBLInfoNego" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="normal3" style="height: 20px;" valign="top">
                        Adresse :
                    </td>
                    <td style="height: 20px;" valign="top">
                        <asp:TextBox ID="TextBoxAdresse2" runat="server" Width="250px" CssClass="big_textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="normal3" style="height: 20px;" valign="top" >
                        Code Postal :
                    </td>
                    <td style="height: 20px;" valign="top">
                        <asp:TextBox ID="TextBoxCodePostal2" runat="server" Width="250px" CssClass="big_textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="normal3" style="height: 20px;" valign="top">
                        Ville :
                    </td>
                    <td style="height: 20px;" valign="top">
                        <asp:TextBox ID="TextBoxVille2" runat="server" Width="250px" CssClass="big_textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="normal3" style="height: 20px;" valign="top">
                        Pays :
                    </td>
                    <td style="height: 20px;" valign="top">
                        <asp:DropDownList ID="DropDownListPays2" runat="server" Width="250px" CssClass=" big_textbox">
                            <asp:ListItem>Afghanistan</asp:ListItem>
                            <asp:ListItem>Afrique Du Sud</asp:ListItem>
                            <asp:ListItem>Albanie</asp:ListItem>
                            <asp:ListItem>Alg&#233;rie</asp:ListItem>
                            <asp:ListItem>Allemagne</asp:ListItem>
                            <asp:ListItem>Andorre</asp:ListItem>
                            <asp:ListItem>Angola</asp:ListItem>
                            <asp:ListItem>Anguilla</asp:ListItem>
                            <asp:ListItem>Antilles</asp:ListItem>
                            <asp:ListItem>Arabie Saoudite</asp:ListItem>
                            <asp:ListItem>Argentine</asp:ListItem>
                            <asp:ListItem>Arm&#233;nie</asp:ListItem>
                            <asp:ListItem>Aruba</asp:ListItem>
                            <asp:ListItem>Australie</asp:ListItem>
                            <asp:ListItem>Autriche</asp:ListItem>
                            <asp:ListItem>Azerba&#239;djan</asp:ListItem>
                            <asp:ListItem>Bahamas</asp:ListItem>
                            <asp:ListItem>Bahrein</asp:ListItem>
                            <asp:ListItem>Bangladesh</asp:ListItem>
                            <asp:ListItem>Barbades</asp:ListItem>
                            <asp:ListItem>Belgique</asp:ListItem>
                            <asp:ListItem>Belize</asp:ListItem>
                            <asp:ListItem>B&#233;nin</asp:ListItem>
                            <asp:ListItem>Bermudes</asp:ListItem>
                            <asp:ListItem>Bhoutan</asp:ListItem>
                            <asp:ListItem>Bi&#233;lorussie</asp:ListItem>
                            <asp:ListItem>Birmanie</asp:ListItem>
                            <asp:ListItem>Bolivie</asp:ListItem>
                            <asp:ListItem>Bosnie</asp:ListItem>
                            <asp:ListItem>Botswana</asp:ListItem>
                            <asp:ListItem>Br&#233;sil</asp:ListItem>
                            <asp:ListItem>Brunei</asp:ListItem>
                            <asp:ListItem>Bulgarie</asp:ListItem>
                            <asp:ListItem>Burkina Faso</asp:ListItem>
                            <asp:ListItem>Burundi</asp:ListItem>
                            <asp:ListItem>Cambodge</asp:ListItem>
                            <asp:ListItem>Cameroun</asp:ListItem>
                            <asp:ListItem>Canada</asp:ListItem>
                            <asp:ListItem>Canaries</asp:ListItem>
                            <asp:ListItem>Cap Vert</asp:ListItem>
                            <asp:ListItem>Cara&#239;be</asp:ListItem>
                            <asp:ListItem>Chili</asp:ListItem>
                            <asp:ListItem>Chine</asp:ListItem>
                            <asp:ListItem>Chypre</asp:ListItem>
                            <asp:ListItem>Colombie</asp:ListItem>
                            <asp:ListItem>Comores</asp:ListItem>
                            <asp:ListItem>Congo(R.D.C.)</asp:ListItem>
                            <asp:ListItem>Cor&#233;e</asp:ListItem>
                            <asp:ListItem>Costa Rica</asp:ListItem>
                            <asp:ListItem>Cote D'Ivoire</asp:ListItem>
                            <asp:ListItem>Croatie</asp:ListItem>
                            <asp:ListItem>Cuba</asp:ListItem>
                            <asp:ListItem>Danemark</asp:ListItem>
                            <asp:ListItem>Djibouti</asp:ListItem>
                            <asp:ListItem>Egypte</asp:ListItem>
                            <asp:ListItem>Emirats Arabes</asp:ListItem>
                            <asp:ListItem>Equateur</asp:ListItem>
                            <asp:ListItem>Erythr&#233;e</asp:ListItem>
                            <asp:ListItem>Espagne</asp:ListItem>
                            <asp:ListItem>Estonie</asp:ListItem>
                            <asp:ListItem>Ethiopie</asp:ListItem>
                            <asp:ListItem>Fidji</asp:ListItem>
                            <asp:ListItem>Finlande</asp:ListItem>
                            <asp:ListItem Selected="True">France</asp:ListItem>
                            <asp:ListItem>Gabon</asp:ListItem>
                            <asp:ListItem>Gambie</asp:ListItem>
                            <asp:ListItem>Ghana</asp:ListItem>
                            <asp:ListItem>Gibraltar</asp:ListItem>
                            <asp:ListItem>Gr&#232;ce</asp:ListItem>
                            <asp:ListItem>Groenland</asp:ListItem>
                            <asp:ListItem>Guadeloupe</asp:ListItem>
                            <asp:ListItem>Guam</asp:ListItem>
                            <asp:ListItem>Guatemala</asp:ListItem>
                            <asp:ListItem>Guin&#233;e</asp:ListItem>
                            <asp:ListItem>Guin&#233;e Bissao</asp:ListItem>
                            <asp:ListItem>Guin&#233;e Equ.</asp:ListItem>
                            <asp:ListItem>Guyana</asp:ListItem>
                            <asp:ListItem>Guyane</asp:ListItem>
                            <asp:ListItem>Haiti</asp:ListItem>
                            <asp:ListItem>Honduras</asp:ListItem>
                            <asp:ListItem>Hong Kong</asp:ListItem>
                            <asp:ListItem>Hongrie</asp:ListItem>
                            <asp:ListItem>Iles Ca&#239;man</asp:ListItem>
                            <asp:ListItem>Iles Cocos</asp:ListItem>
                            <asp:ListItem>Iles Cook</asp:ListItem>
                            <asp:ListItem>&#206;les F&#233;ro&#233;</asp:ListItem>
                            <asp:ListItem>&#206;les Mariannes</asp:ListItem>
                            <asp:ListItem>&#206;les Vierges</asp:ListItem>
                            <asp:ListItem>Inde</asp:ListItem>
                            <asp:ListItem>Indon&#233;sie</asp:ListItem>
                            <asp:ListItem>Irak</asp:ListItem>
                            <asp:ListItem>Iran</asp:ListItem>
                            <asp:ListItem>Irlande</asp:ListItem>
                            <asp:ListItem>Islande</asp:ListItem>
                            <asp:ListItem>Isra&#235;l</asp:ListItem>
                            <asp:ListItem>Italie</asp:ListItem>
                            <asp:ListItem>Jama&#239;que</asp:ListItem>
                            <asp:ListItem>Japon</asp:ListItem>
                            <asp:ListItem>Jordanie</asp:ListItem>
                            <asp:ListItem>Kazakhstan</asp:ListItem>
                            <asp:ListItem>Kenya</asp:ListItem>
                            <asp:ListItem>Kirghizstan</asp:ListItem>
                            <asp:ListItem>Kiribati</asp:ListItem>
                            <asp:ListItem>Kowe&#239;t</asp:ListItem>
                            <asp:ListItem>Laos</asp:ListItem>
                            <asp:ListItem>Leeward I.</asp:ListItem>
                            <asp:ListItem>Lesotho</asp:ListItem>
                            <asp:ListItem>Lettonie</asp:ListItem>
                            <asp:ListItem>Liban</asp:ListItem>
                            <asp:ListItem>Lib&#233;ria</asp:ListItem>
                            <asp:ListItem>Libye</asp:ListItem>
                            <asp:ListItem>Lituanie</asp:ListItem>
                            <asp:ListItem>Luxembourg</asp:ListItem>
                            <asp:ListItem>Macau</asp:ListItem>
                            <asp:ListItem>Mac&#233;doine</asp:ListItem>
                            <asp:ListItem>Madagascar</asp:ListItem>
                            <asp:ListItem>Malaisie</asp:ListItem>
                            <asp:ListItem>Malawi</asp:ListItem>
                            <asp:ListItem>Maldives</asp:ListItem>
                            <asp:ListItem>Mali</asp:ListItem>
                            <asp:ListItem>Malouines</asp:ListItem>
                            <asp:ListItem>Malte</asp:ListItem>
                            <asp:ListItem>Maroc</asp:ListItem>
                            <asp:ListItem>Marshall</asp:ListItem>
                            <asp:ListItem>Martinique</asp:ListItem>
                            <asp:ListItem>Maurice</asp:ListItem>
                            <asp:ListItem>Mauritanie</asp:ListItem>
                            <asp:ListItem>Mayotte</asp:ListItem>
                            <asp:ListItem>Mexique</asp:ListItem>
                            <asp:ListItem>Micron&#233;sie</asp:ListItem>
                            <asp:ListItem>Moldavie</asp:ListItem>
                            <asp:ListItem>Monaco</asp:ListItem>
                            <asp:ListItem>Mongolie</asp:ListItem>
                            <asp:ListItem>Montserrat</asp:ListItem>
                            <asp:ListItem>Mozambique</asp:ListItem>
                            <asp:ListItem>Namibie</asp:ListItem>
                            <asp:ListItem>Nauru</asp:ListItem>
                            <asp:ListItem>N&#233;pal</asp:ListItem>
                            <asp:ListItem>Nicaragua</asp:ListItem>
                            <asp:ListItem>Niger</asp:ListItem>
                            <asp:ListItem>Nig&#233;ria</asp:ListItem>
                            <asp:ListItem>Niue</asp:ListItem>
                            <asp:ListItem>Norfolk Island</asp:ListItem>
                            <asp:ListItem>Norv&#232;ge</asp:ListItem>
                            <asp:ListItem>N. Cal&#233;donie</asp:ListItem>
                            <asp:ListItem>N. Z&#233;lande</asp:ListItem>
                            <asp:ListItem>Oman</asp:ListItem>
                            <asp:ListItem>Ouganda</asp:ListItem>
                            <asp:ListItem>Ouzb&#233;kistan</asp:ListItem>
                            <asp:ListItem>Pakistan</asp:ListItem>
                            <asp:ListItem>Palaos</asp:ListItem>
                            <asp:ListItem>Panama</asp:ListItem>
                            <asp:ListItem>Nouvelle Guin&#233;e</asp:ListItem>
                            <asp:ListItem>Paraguay</asp:ListItem>
                            <asp:ListItem>Hollande</asp:ListItem>
                            <asp:ListItem>P&#233;rou</asp:ListItem>
                            <asp:ListItem>Philippines</asp:ListItem>
                            <asp:ListItem>Pologne</asp:ListItem>
                            <asp:ListItem>Polyn&#233;sie</asp:ListItem>
                            <asp:ListItem>Porto Rico</asp:ListItem>
                            <asp:ListItem>Portugal</asp:ListItem>
                            <asp:ListItem>Principe Island</asp:ListItem>
                            <asp:ListItem>Qatar</asp:ListItem>
                            <asp:ListItem>R&#233;p. Centrafricaine</asp:ListItem>
                            <asp:ListItem>R&#233;p. Dominicaine</asp:ListItem>
                            <asp:ListItem>R&#233;p. Tch&#232;que</asp:ListItem>
                            <asp:ListItem>R&#233;union</asp:ListItem>
                            <asp:ListItem>Roumanie</asp:ListItem>
                            <asp:ListItem>Royaume-Uni</asp:ListItem>
                            <asp:ListItem>Russie</asp:ListItem>
                            <asp:ListItem>Rwanda</asp:ListItem>
                            <asp:ListItem>Saint Martin</asp:ListItem>
                            <asp:ListItem>St Pierre &amp; Miq.</asp:ListItem>
                            <asp:ListItem>Sainte Lucie</asp:ListItem>
                            <asp:ListItem>Salomon (&#206;les)</asp:ListItem>
                            <asp:ListItem>Salvador</asp:ListItem>
                            <asp:ListItem>Samoa</asp:ListItem>
                            <asp:ListItem>Samoa US</asp:ListItem>
                            <asp:ListItem>Samoa Occ.</asp:ListItem>
                            <asp:ListItem>Sao Tome</asp:ListItem>
                            <asp:ListItem>S&#233;n&#233;gal</asp:ListItem>
                            <asp:ListItem>Serbie</asp:ListItem>
                            <asp:ListItem>Seychelles</asp:ListItem>
                            <asp:ListItem>Sierra L&#233;one</asp:ListItem>
                            <asp:ListItem>Singapour</asp:ListItem>
                            <asp:ListItem>Slovaquie</asp:ListItem>
                            <asp:ListItem>Slov&#233;nie</asp:ListItem>
                            <asp:ListItem>Somalie</asp:ListItem>
                            <asp:ListItem>Soudan</asp:ListItem>
                            <asp:ListItem>Sri Lanka</asp:ListItem>
                            <asp:ListItem>Su&#232;de</asp:ListItem>
                            <asp:ListItem>Suisse</asp:ListItem>
                            <asp:ListItem>Suriname</asp:ListItem>
                            <asp:ListItem>Swaziland</asp:ListItem>
                            <asp:ListItem>Syrie</asp:ListItem>
                            <asp:ListItem>Tadjikistan</asp:ListItem>
                            <asp:ListItem>Ta&#239;wan</asp:ListItem>
                            <asp:ListItem>Tanzanie</asp:ListItem>
                            <asp:ListItem>Tchad</asp:ListItem>
                            <asp:ListItem>Tha&#239;lande</asp:ListItem>
                            <asp:ListItem>Togo</asp:ListItem>
                            <asp:ListItem>Tonga</asp:ListItem>
                            <asp:ListItem>Trinit&#233; &amp; Tabago</asp:ListItem>
                            <asp:ListItem>Tunisie</asp:ListItem>
                            <asp:ListItem>Turcs</asp:ListItem>
                            <asp:ListItem>Turkm&#233;nistan</asp:ListItem>
                            <asp:ListItem>Turks &amp; Caicos</asp:ListItem>
                            <asp:ListItem>Turquie</asp:ListItem>
                            <asp:ListItem>Tuvalu</asp:ListItem>
                            <asp:ListItem>Ukraine</asp:ListItem>
                            <asp:ListItem>Uruguay</asp:ListItem>
                            <asp:ListItem>Usa</asp:ListItem>
                            <asp:ListItem>Vanuatu</asp:ListItem>
                            <asp:ListItem>V&#233;n&#233;zuela</asp:ListItem>
                            <asp:ListItem>Vietnam</asp:ListItem>
                            <asp:ListItem>Wallis &amp; Futuna</asp:ListItem>
                            <asp:ListItem>Windward Islands</asp:ListItem>
                            <asp:ListItem>Yemen</asp:ListItem>
                            <asp:ListItem>Yougoslavie</asp:ListItem>
                            <asp:ListItem>Za&#239;re</asp:ListItem>
                            <asp:ListItem>Zambie</asp:ListItem>
                            <asp:ListItem>Zimbabwe</asp:ListItem>
                        </asp:DropDownList>
                                    
                    </td>
                </tr>
                <tr>
                    <td class="normal3" style="height: 20px;" valign="top">
                        T�l�phone :
                    </td>
                    <td style="height: 20px;" valign="top">
                        <asp:TextBox ID="TextBoxTel2" runat="server" Width="250px" CssClass="big_textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="normal3" style="height: 20px;" valign="top">
                        Soci�t� :
                    </td>
                    <td style="height: 20px;">
                        <asp:TextBox ID="TextBoxSociete2" runat="server" Width="250px" CssClass="big_textbox"></asp:TextBox>
                    </td>
                </tr>

            </table>
            </div>
        </td>
        <td style="vertical-align:top">             
            <!--PHOTO -->
            <div class="bloc_monCompte"  style="width:290px;margin-left:15px">
                <center><strong>VOTRE PHOTO</strong></center>
                <hr />
                <asp:Panel ID="Show_Photo_Panel" Visible=false runat="server">
                    <center>
                        <img src="../img_nego/<%=member2.IDCLIENT%>_PHOTO.jpg" height="170px" alt="Votre Photo" />
                        <br /><br />
                        <asp:Button ID="ButtonSupprimerProfilPicture" runat="server" Text="Supprimer" CssClass="flat-button" OnClick='SupprimerProfilPicture'/>
                        <br /><br />
                    </center>
                </asp:Panel>
                <asp:Panel ID="Add_Photo_Panel" Visible=false runat="server">
                <center>
                    <strong>Ajouter une photo de profil : </strong><br /><br />
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Label ID="Label1" runat="server" class="TexteInternet"></asp:Label>   <br /><br />
                    <asp:Button ID="ButtonAddProfilPhoto" runat="server" Text="Valider" CssClass="flat-button" OnClick="ButtonAddProfilPicture"/>
                    <br /><br />
                </center>
                </asp:Panel>
            </div>
            <br />

            <!-- Mot de passe -->
            <div class="bloc_monCompte" style="width:290px;margin-left:15px">
                <table >
                    <tr>
                        <td colspan=2>
                            <center><strong>VOTRE MOT DE PASSE</strong></center>
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="normal3" style="height: 20px;" valign="top">
                            Mot de passe actuel :
                        </td>
                        <td style="height: 20px;" valign="top">
                            <asp:TextBox ID="TextBoxCurrentPassword" runat="server" MaxLength="15" TextMode="Password" CssClass="big_textbox"
                                Width="150px"></asp:TextBox>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="normal3" style="height: 20px;" valign="top">
                            Nouveau mot de passe :
                        </td>
                        <td style="height: 20px;" valign="top">
                            <asp:TextBox ID="TextBoxPassword2" runat="server" MaxLength="15" TextMode="Password" CssClass="big_textbox"
                                Width="150px"></asp:TextBox>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="normal3" style="height: 20px;" valign="top">
                            Confirmation :
                        </td>
                        <td style="height: 20px;" valign="top">
                            <asp:TextBox ID="TextBoxPasswordConfirmation2" runat="server" MaxLength="15" TextMode="Password" CssClass=" big_textbox"
                                Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
            </div>
            <br />
        </td>
        <!-- Citation -->
        <td style="vertical-align:top">
        <asp:Panel ID="Site_Panel" visible=false runat="server">
                <div class="bloc_monCompte" style="width:330px;margin-left:15px">
                    <center><strong>VOTRE SITE</strong></center>
                    <hr />
                    <center>Votre citation:
                    <br /><br />
                    <asp:TextBox ID="TBQuote" runat="server" ClientIDMode="Static" onkeyup='javascript:checksize_field("CharLeft","TBQuote", this.value, 740)' Height="390px" Width="85%" MaxLength="750" style="font-family: sans-serif;font-size: 14px;" TextMode="MultiLine" />
                    <br />
                    <span id="CharLeft"><i><font size='2px'>Max: 740 char</font></i></span>
                    <br /><br />
                    <asp:Button ID="BtnVoirSite" CssClass="flat-button" Text="Voir votre site" runat="server" OnClick="voir_Site" />
                    <br /><br />
                    </center>
                </div>
            </asp:Panel>

        </td>
    </tr>  
    <tr>
        <td colspan=3>
         <!--Bouton enregistrement-->
            <center>   
                    <br />
                        <asp:Button ID="ButtonEnregistrer" runat="server" Text="Enregistrer" CssClass="flat-button" OnClick="ButtonEnregistrer_Click" />
                    <br /><br />
            </center>
        </td>
    </tr>
</table>

</asp:Content>
