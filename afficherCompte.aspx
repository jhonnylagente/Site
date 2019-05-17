<%@ Page Language="C#" MasterPageFile ="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="afficherCompte.aspx.cs" Inherits="afficherCompte" Title="PATRIMONIUM : Mon espace client" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript">
    // <!CDATA[

    function Select1_onchange() {
   
        var url = window.location.href;
        var taille = url.length - 2;
        var partie1 = url.substring(0, taille);
        var temp = new Array();
        temp = partie1.split('=');
        var temp2 = temp[1].split('&');
        //Quand l'utilisateur affiche davantage d'annonces par pages, il doit être redirigé vers la première page car il se peut que celle sur laquelle il se trouve n'existe plus.
        var url_built = temp[0] + "=1" + "&" + temp2[1] + "=" + temp[2] + "=" + temp[3] + "=" + document.getElementById("Select1").value;

        window.location.href = url_built;
        //window.location.href = partie1+document.getElementById("Select1").value;

    }

</script>


<center>  
    <p class="titrecreation" style="margin-left:5px;color:#31536c">
        <strong style="font-size: x-large">Modification 
        du Compte</strong></p>
</center>  

<div style="width:488px;text-align:center;height:30px;margin-left:236px">
    <asp:Label ID="lblmail" runat="server" Font-Bold="True" Font-Size="Larger" 
        ForeColor="Red" Text="Le courriel est déjà attribué." Visible="False"></asp:Label>
</div>
  
<table>
    <tr>
	    <td valign="top" style="width:157px; height:530px">
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
	    </td>
	    <td valign="top" style="width:490px; height:530px">
	        <fieldset>
	            <legend>
	                <strong> Informations</strong>
	            </legend>
                <table  cellpadding="5" cellspacing="0">
                    <tr>
                        <td style="height: 20px; " colspan="4">
                            Civilité 
                        </td>
                        <td style="height: 20px; " colspan="12">
                            <asp:RadioButton ID="RadioButtonMme" runat="server" GroupName="radioButtonGroup" Text="Mme"/>
                            <asp:RadioButton ID="RadioButtonMlle" runat="server" GroupName="radioButtonGroup" Text="Mlle"/>
                            <asp:RadioButton ID="RadioButtonMr" runat="server" GroupName="radioButtonGroup" Text="Mr"/>
                        </td>
                        <td style="height: 20px; width: 181px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 376px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 248px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 260px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 285px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                        <td style="height: 20px; width: 207px;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="height: 24px;" colspan="4"  >
                            Nom  
                            <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
                        </td>
                        <td style="height: 24px;" colspan="23"  >
                            <asp:TextBox ID="textBoxnom" runat="server" Width="307px" Height="20px"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequieredFielValidator1" runat="server" ControlToValidate="textBoxnom" ErrorMessage="Ce champ est obligatoire." Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                        <td style="height: 24px;" colspan="5"  >
                            Prénom<asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                        </td>
                        <td style="height: 24px;" colspan="18"  >
                            <asp:TextBox ID="TextBoxPrenom" runat="server" Width="232px" Height="20px"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequieredFielValidator2" runat="server" ControlToValidate="TextBoxPrenom" ErrorMessage="Ce champ est obligatoire." Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="textBoxForm" colspan="6">
                            Adresse  
                        </td>
                        <td class="textBoxForm" colspan="29">
                            <asp:TextBox ID="TextBoxAdresse" runat="server" Width="383px" Height="20px"></asp:TextBox>
                        </td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:260px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:285px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="textBoxForm" colspan="7">
                            Code Postal</td>
                        <td class="textBoxForm" colspan="7">
                            <asp:TextBox ID="TextBoxCodePostal" runat="server" Width="81px" Height="20px"></asp:TextBox>
                       
                        </td>
                        <td class="textBoxForm" colspan="3">
                            Ville  
                       
                        </td>
                        <td class="textBoxForm" colspan="11">
                            <asp:TextBox ID="TextBoxVille" runat="server" Width="141px" Height="20px"></asp:TextBox>
                       
                        </td>
                        <td class="textBoxForm" colspan="3">
                            Pays</td>
                        <td class="textBoxForm" colspan="13">
                            <asp:DropDownList ID="DropDownListPays" runat="server" Width="158px" 
                                Height="23px">       
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
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:285px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="height: 12px;" colspan="5">
                            Email 
                            <asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label>
                        </td>
                        <td style="height: 12px;" colspan="38">
                            <asp:TextBox ID="TextBoxEmail" runat="server" Width="395px" Height="20px"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequieredFielValidator3" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="Ce champ est obligatoire." Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat ="server" ErrorMessage="Vérifiez l'addresse" ControlToValidate="TextBoxEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  Display="Dynamic"></asp:RegularExpressionValidator>
                       
                            <br />
                        </td>
                        <td style="width:207px; height: 12px;">
                            </td>
                        <td style="width:207px; height: 12px;">
                            </td>
                        <td style="width:207px; height: 12px;">
                            </td>
                        <td style="width:207px; height: 12px;">
                            </td>
                        <td style="width:285px; height: 12px;">
                            </td>
                        <td style="width:207px; height: 12px;">
                            </td>
                        <td style="width:207px; height: 12px;">
                            </td>
                    </tr>
                    <tr>
                        <td style="height: 7px;" colspan="8">
                            Mot de passe   
                            <asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                        </td>
                        <td style="height: 7px;" colspan="19">
                            <asp:TextBox ID="TextBoxPassword" runat="server" MaxLength="15" Width="248px" 
                                Height="20px" ></asp:TextBox>
                             <br />
                             <asp:RequiredFieldValidator ID="RequieredFiledValidator4" runat="server" ControlToValidate="TextBoxPassword" ErrorMessage= "Ce champ est obligatoire." ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                             </td>
                        <td style="height: 7px;" colspan="7">
                            Confirmation<asp:Label ID="Label6" runat="server" 
                                Text="*" ForeColor="Red"></asp:Label>
                        </td>
                        <td style="height: 7px;" colspan="16">
                            <asp:TextBox ID="TextBoxPasswordConfirmation" runat="server" MaxLength="15" 
                                Width="197px" Height="20px" ></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequieredFieldValidator5" runat="server" ControlToValidate="TextBoxPasswordConfirmation" ErrorMessage="Ce champ est obligatoire." ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Les mots de passe ne correspondent pas." ControlToCompare="TextBoxPasswordConfirmation" ControlToValidate="TextBoxPassword" Display="Dynamic"> </asp:CompareValidator>

                                    
                                </td>
                    </tr>
                    <tr>
                        <td class="textBoxForm" colspan="7">
                            Téléphone</td>
                        <td class="textBoxForm" colspan="13">
                            <asp:TextBox ID="TextBoxTel" runat="server" Width="165px" Height="20px"></asp:TextBox>
                        </td>
                        <td class="textBoxForm" colspan="3">
                            fax  </td>
                        <td class="textBoxForm" colspan="11">
                            <asp:TextBox ID="TextBoxFax" runat="server" Width="134px" Height="20px"></asp:TextBox>
                        </td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:260px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:285px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="textBoxForm" colspan="6">
                            Société </td>
                        <td class="textBoxForm" colspan="13">
                            <asp:TextBox ID="TextBoxSociete" runat="server" Width="166px" Height="20px"></asp:TextBox>
                        </td>
                        <td class="textBoxForm" colspan="5">
                            Parain</td>
                        <td class="textBoxForm" colspan="25">
                            <asp:DropDownList ID="DropDownListParain" runat="server">
                            <asp:ListItem Value="0" Text=""> </asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="textBoxForm" colspan="13">
                                Contractuel <asp:CheckBox ID="CheckBoxContractuel" runat="server" />
                                </td>
                        <td class="textBoxForm" colspan="11">
                                Num. Agence
                                <asp:TextBox ID="txtnAgence" runat="server" Height="23px" Width="52px">001</asp:TextBox>
                            </td>
                        <td class="textBoxForm" colspan="4">
                            Statut </td>
                        <td class="textBoxForm" colspan="12">
                            <asp:DropDownList ID="DropDownListStatut" runat="server" EnableTheming="True">
                                <asp:ListItem Value=" "> </asp:ListItem>
                                <asp:ListItem Value="nego" >Negociateur</asp:ListItem>
                                <asp:ListItem Value="ultranego ">UltraNego</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:285px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                    </tr>
                    <tr>

                        <td style="width:207px" class="textBoxForm" colspan="6">
                            Kbis</td>
                        <td style="width:207px" class="textBoxForm" colspan="13">
                            <asp:TextBox ID="TextBoxKbis" runat="server" Height="20px" Width="166px"></asp:TextBox>
                        </td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:585px" class="textBoxForm">
                            &nbsp;</td>
                        <td class="textBoxForm" colspan="15">
                                Nombre annonces 
                                min. SeLoger </td>
                        <td style="width:207px" class="textBoxForm" colspan="4">
                            <asp:TextBox ID="TextBoxNbSeLoger" runat="server" Width="36px"></asp:TextBox>
                        </td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm" colspan="2">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm" colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>

                        <td style="width:388px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:208px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:201px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm" colspan="2">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm" colspan="2">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:585px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:181px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:156px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm" colspan="2">
                            &nbsp;</td>
                        <td class="textBoxForm" colspan="9">
                                <asp:Button ID="ButtonEnregistrer" runat="server" Text="Modifier" 
                                    OnClick="ButtonEnregistrer_Click1" class="myButton"  />
                        </td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:248px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:260px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:285px" class="textBoxForm">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width:388px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:208px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td class="menu_bas" colspan="42">
                            <span style="color: rgb(0, 0, 0); font-family: 'Times New Roman'; font-size: medium; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none;">
                            - Les champs précédés d'une astérisque * sont obligatoires.-</span></td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:285px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                        <td style="width:207px" class="textBoxForm">
                            &nbsp;</td>
                    </tr>
                    </table>
            </fieldset>
	    </td>
	</tr>
</table>
<div class="aumilieu" style="text-align: center;">
</div>	

    
    

    
</asp:Content>

