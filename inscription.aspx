<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="inscription.aspx.cs" Inherits="pages_inscription" Title="PATRIMONIUM : Inscription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">

    function check_same_password() {
        if (document.getElementById("<%=TBPass.ClientID%>").value == document.getElementById("<%=TBPassConfirm.ClientID%>").value) document.getElementById("<%=TBSamePassword.ClientID%>").value = "OK";
        else document.getElementById("<%=TBSamePassword.ClientID%>").value = "";
    }
</script>

<br />
 <div style="font-weight: bold; font-size:20px;text-align:center">INSCRIPTION SUR PATRIMO</div>
<div style="width:488px;text-align:center;height:30px;margin-left:236px">
    <span class="LabeleErrlog"><strong><asp:Label ID="LabelErrorLogin" runat="server" ForeColor="Red" Visible="False" Width="400px"></asp:Label></strong></span>
</div>
<br />
    <div class="bloc_add_conf">
    <br />
        <table>
            <tr>
                <!-- Champs obligatoires -->
                <td width='50%' valign='top'>
               
                <div id="div_inscr">
                    <asp:DropDownList ID="DDLCivil"  CssClass="big_textbox" style="float:left;margin-left:5%; margin-bottom:5px; width:35%" runat="server">
                        <asp:ListItem Value="Mr">Mr</asp:ListItem>
                        <asp:ListItem Value="Mlle">Mlle</asp:ListItem>
                        <asp:ListItem Value="Mme">Mme</asp:ListItem>
                    </asp:DropDownList>

                    <asp:TextBox ID="TBNom" placeholder="Nom*"  CssClass="big_textbox" style="margin-left:5%; margin-bottom:5px" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  runat="server" ControlToValidate="TBNom" ErrorMessage="*" ValidationGroup="infosConf" ></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="infosConf" ControlToValidate="TBNom" ErrorMessage="<br/>Nom invalide" Display="dynamic" ValidationExpression="^[a-zA-Zéèçàâù ]+$" />
                   
                    <asp:TextBox ID="TBPrenom" placeholder="Prénom*" CssClass="big_textbox" style="margin-left:5%; margin-bottom:5px"  runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TBPrenom" ErrorMessage="*" ValidationGroup="infosConf" ></asp:RequiredFieldValidator>  
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TBPrenom" ValidationGroup="infosConf" ErrorMessage="<br/><br/>Nom invalide" Display="dynamic" ValidationExpression="^[a-zA-Zéèçàâù ]+$" />

                    <asp:TextBox ID="TBMail" placeholder="Email*"   CssClass="big_textbox" style="margin-left:5%; margin-bottom:5px"  runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TBMail" runat="server" ErrorMessage="*" ValidationGroup="infosConf" ></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TBMail" ValidationGroup="infosConf" ErrorMessage="<br/><br/>Mail invalide" Display="dynamic"
	ValidationExpression="^[_a-zA-Z0-9-]+(\.[_a-zA-Z0-9-]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*\.(([0-9]{1,3})|([a-zA-Z]{2,3})|(aero|coop|info|museum|name))$" />
                             
                    <asp:TextBox ID="TBPass" placeholder="Mot de passe*" Onchange="check_same_password()" TextMode="password" CssClass="big_textbox" style="width:34%; float:left; margin-left:5%; margin-bottom:5px"  runat="server"></asp:TextBox>     
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="TBPass" runat="server"  style=" float:left;" ErrorMessage="*" ValidationGroup="infosConf"></asp:RequiredFieldValidator>

                    <asp:TextBox ID="TBPassConfirm" placeholder="Confirmer*" Onchange="check_same_password()" TextMode="password" CssClass="big_textbox" style="margin-left:7%;width:34%; float:left; margin-bottom:5px"  runat="server"></asp:TextBox>     
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="TBPassConfirm" style=" float:left;" runat="server" ErrorMessage="*" ValidationGroup="infosConf"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="TBSamePassword" style=" float:left;" runat="server" ErrorMessage="Les mots de passes sont differents" ValidationGroup="infosConf"></asp:RequiredFieldValidator>
                    
                    <br /><br /><br /><br /><br/>
                    <div style="text-align:left; margin-left:5%; color:grey; margin-bottom:5px"><i>Les champs suivis d'une astérisque * sont obligatoires</i></div>                                                         
                    </div>
                </td>

                <!-- Autres champs et envoie -->
                <td width='50%' valign='top'>
                <div id="div_inscr_2">
                   <asp:DropDownList ID="DropDownListPays"  CssClass="big_textbox" style="margin-left:5%;margin-bottom:5px"  runat="server" Width="158px">                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           <asp:ListItem>Afghanistan</asp:ListItem>
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

                   <asp:TextBox ID="TBAdresse" placeholder="Adresse" CssClass="big_textbox" style="margin-left:5%; margin-bottom:5px"  runat="server"></asp:TextBox>     
                    
                   <asp:TextBox ID="TBCP" placeholder="Code Postal" CssClass="big_textbox" style="width:34%; float:left; margin-left:5%; margin-bottom:5px"  runat="server"></asp:TextBox>     
                  
                   <asp:TextBox ID="TBVille" placeholder="Ville" CssClass="big_textbox" style="margin-left:7%;width:34%; float:left; margin-bottom:5px"  runat="server"></asp:TextBox>     
                   <br /><br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TBCP" ErrorMessage="<br/><br/>CP invalide" Display="dynamic" ValidationExpression="^\d{5}$" />
                
                    <asp:TextBox ID="TBTel" placeholder="Téléphone" CssClass="big_textbox" style="margin-left:5%; margin-bottom:5px" runat="server"></asp:TextBox>

                    <asp:TextBox ID="TBFax" placeholder="Fax" CssClass="big_textbox" style="margin-left:5%; margin-bottom:5px" runat="server"></asp:TextBox>

                    <asp:TextBox ID="TBSociete" placeholder="Société"   CssClass="big_textbox" style="margin-left:5%; margin-bottom:5px" runat="server"></asp:TextBox>
                    <br /><br />
                    <center>
                        <asp:Button ID="ButtonEnregistrer" CssClass="flat-button" runat="server" Text="Enregistrer" OnClick="ButtonEnregistrer_Click1" ValidationGroup="infosConf" /> 
                    </center>
                    <br />
                    </div>
                </td>
            </tr>
        </table>
        </div>
        <br />


<!-- Des choses invisibles -->
    <asp:TextBox ID="TBSamePassword" style="display:none" runat="server" />


</asp:Content>

