<%@ Page Title="" Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="ajouterCompte.aspx.cs" Inherits="ajouterCompte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script>
    $(function () {
        $("#<%=TextBoxEmail.ClientID%>").attr("required", "");
        $("#<%=TextBoxPassword.ClientID%>").attr("required", "");
        $("#<%=TextBoxPasswordConfirmation.ClientID%>").attr("required", "");
        $("#<%=TextBoxNom.ClientID%>").attr("required", "");
        $("#<%=TextBoxPrenom.ClientID%>").attr("required", "");        
    }
);
	function validerForm()
	{	
		$("#error").html("");
		var mail = validerMail();
		var pass = validerPassword();
		var nom = validerNom();
		var prenom = validerPrenom();
		var kbis = validerKbis();
		return mail && pass && nom && prenom && kbis;
	}
	function validerNom()
	{
		var bool = ($("#<%=TextBoxNom.ClientID%>").val() != "");
		if(!bool)
			$("#error").append("Nom vide.<br/>");
		return bool;
	}
	function validerPrenom()
	{
		var bool = ($("#<%=TextBoxPrenom.ClientID%>").val() != "");
		if(!bool)
			$("#error").append("Prenom vide.<br/>");
		return bool;
	}
	function validerMail()
	{
		var regex = /^[-\w.]+[@]{1}[a-zA-Z]+[.]{1}[-a-zA-Z0-9]+$/;
		var bool = regex.test($("#<%=TextBoxEmail.ClientID%>").val())
        var bool1 = ($("#<%=TextBoxEmail.ClientID%>").val() != "");
        if (!bool1)
            $("#error").append("Email obligatoire.<br/>");
        else
            if(!bool)
			    $("#error").append("Email invalide.<br/>");
		return bool;
	}
	
	function validerPassword()
	{
		var bool = ($("#<%=TextBoxPassword.ClientID%>").val() == $("#<%=TextBoxPasswordConfirmation.ClientID%>").val());
		var bool1 = ($("#<%=TextBoxPassword.ClientID%>").val() != "");
		var bool2 = ($("#<%=TextBoxPasswordConfirmation.ClientID%>").val() != "");
		if (!bool1)
		    $("#error").append("Mot de passe vide.<br/>");
		else
		    if (!bool2)
		        $("#error").append("Confirmation du mot de passe vide.<br/>");
            else
		        if(!bool)
			        $("#error").append("Les mots de passe ne correspondent pas.<br/>");
		return bool;
	}
	function validerKbis() 
    {
        var regex = /^([0-9]{9}|[0-9]{14})$/;
        var bool = regex.test($("#<%=TextBoxKbis.ClientID%>").val());
        var bool1 = ($("#<%=TextBoxKbis.ClientID%>").val() != "");
        var ret = false;
        if (bool1 && !bool) {
            $("#error").append("Veuillez saisir un Kbis valide.<br/>");
            return ret;
        }
	}

</script>

<center>  
    <p class="titrecreation" style="margin-left:5px;color:#31536c">
        <strong style="font-size: x-large">Création de votre compte Patrimo.net</strong></p>
</center>  

<div class="rouge" style="margin: auto; margin-bottom:5px; text-align: center;">
	<span id="error">
    <asp:Label ID="lblmail" runat="server" Font-Bold="True" Font-Size="Larger" 
        ForeColor="Red" Text="Le courriel est déjà attribué." Visible="False"></asp:Label>
	</span>
</div>
  
  
	<div style="width:70%;margin:auto;">
		<div class="addAccountTitle">
			Informations de connexion
		</div>
		<div style="padding-left:80px">
			<div>
				<div class="searchFilterDiv marginR30" style="line-height:32px">
					<div class="paramName taright" style="width:110px">
						Email <span class="rouge">*</span><br/>
						Mot de passe <span class="rouge">*</span>
					</div>
					<div class="paramValue">
						<asp:TextBox ID="TextBoxEmail" CssClass="style2d" runat="server"></asp:TextBox>&nbsp;&nbsp;<br/>
						<asp:TextBox ID="TextBoxPassword" CssClass="style2d" runat="server" MaxLength="15" TextMode="Password"></asp:TextBox>&nbsp;&nbsp;
					</div>
				</div>
			</div>
			
			<div>
				<div class="searchFilterDiv marginR30" style="line-height:32px">
					<div class="paramName taright" style="width:110px">
						Statut
						<br/>Confirmation <span class="rouge">*</span>
					</div>
					<div class="paramValue">
						<asp:DropDownList ID="DropDownListStatut" CssClass="style2d" runat="server">
							<asp:ListItem Value=" "> </asp:ListItem>
							<asp:ListItem Value="nego">Negociateur</asp:ListItem>
							<asp:ListItem Value="ultranego">UltraNego</asp:ListItem>
						</asp:DropDownList>&nbsp;
						<br/><asp:TextBox ID="TextBoxPasswordConfirmation" CssClass="style2d" runat="server" MaxLength="15" TextMode="Password"></asp:TextBox>&nbsp;
					</div>
				</div>
			</div>
			
			<div class="clear" style="height:15px"></div>
			
			<div>
				<div class="searchFilterDiv marginR30" style="line-height:32px">
					<div class="paramName taright" style="width:110px">Parrain</div>
					<div class="paramValue">                            
						<asp:DropDownList ID="DropDownListParain" CssClass="style2d" runat="server" onselectedindexchanged="DropDownListParain_SelectedIndexChanged">
						</asp:DropDownList>&nbsp;
					</div>

				</div>
				<div class="searchFilterDiv marginR30" style="line-height:32px">
					<div class="paramName taright" style="width:110px">
						Contractuel<br/>
						Num. Agence
						</div>
					<div class="paramValue">
						<asp:CheckBox ID="CheckBoxContractuel" runat="server" />&nbsp;<br/>
						<asp:TextBox ID="txtnAgence" CssClass="style2d" runat="server" width="24">001</asp:TextBox>&nbsp;
					</div>
				</div>
			</div>
			
			<div class="clear" style="height:40px"></div>
			
		</div>

		<div class="addAccountTitle">
			Informations personnelles
		</div>
		
		<div style="padding-left:80px">
			
			<div>
				<div class="searchFilterDiv marginR30" style="line-height:32px">
					<div class="paramName taright" style="width:110px">Civilité</div>
					<div class="paramValue">
						<asp:RadioButton ID="RadioButtonMme" runat="server" GroupName="radioButtonGroup" Text="Mme" />
						<asp:RadioButton ID="RadioButtonMlle" runat="server" GroupName="radioButtonGroup" Text="Mlle" />
						<asp:RadioButton ID="RadioButtonMr" runat="server" GroupName="radioButtonGroup" Text="Mr" />
					</div>
				</div>
			</div>
			
			<div class="clear"></div>
			
			<div>
				<div class="searchFilterDiv marginR30" style="line-height:32px">
					<div class="paramName taright" style="width:110px">
						Nom <span class="rouge">*</span>
					</div>
					<div class="paramValue">
						<asp:TextBox ID="TextBoxNom" CssClass="style2d" runat="server" BorderColor=""></asp:TextBox>&nbsp;
					</div>
				</div>
				<div class="searchFilterDiv marginR30" style="line-height:32px">
					<div class="paramName taright" style="width:110px">
						Prénom <span class="rouge">*</span>
					</div>
					<div class="paramValue">
						<asp:TextBox ID="TextBoxPrenom" CssClass="style2d" runat="server"></asp:TextBox>&nbsp;
					</div>
				</div>
			</div>
			

			
			<div class="clear" style="height:10px"></div>

		
			
			<div>
				<div class="searchFilterDiv marginR30" style="line-height:32px">
					<div class="paramName taright" style="width:110px">
						Adresse
					</div>
					
					<div class="paramValue">
						<asp:TextBox ID="TextBoxAdresse" CssClass="style2d" runat="server" Width="472px"></asp:TextBox>&nbsp;
					</div>
				</div>
			</div>
						
			<div>
				<div class="searchFilterDiv marginR30" style="line-height:32px">
					<div class="paramName taright" style="width:110px">
						Code postal
					</div>
					<div class="paramValue">
						<asp:TextBox ID="TextBoxCodePostal" CssClass="style2d" runat="server"></asp:TextBox>&nbsp;
					</div>
				</div>
				
				<div class="searchFilterDiv marginR30" style="line-height:32px">
					<div class="paramName taright" style="width:110px">
						Ville
					</div>
					<div class="paramValue">
						<asp:TextBox ID="TextBoxVille" CssClass="style2d" runat="server"></asp:TextBox>&nbsp;
					</div>
				</div>
				
				<div class="searchFilterDiv marginR30" style="line-height:32px">
					<div class="paramName taright" style="width:110px">
						Pays
					</div>
					<div class="paramValue">
					<asp:DropDownList ID="DropDownListPays" CssClass="style2d" runat="server">
						<asp:ListItem>France</asp:ListItem>
						<asp:ListItem>-----------------------</asp:ListItem>       
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
						<asp:ListItem>France</asp:ListItem>
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
					</asp:DropDownList>&nbsp;
					</div>
				</div>
			</div>
			
			<div class="clear" style="height:10px"></div>
			
			<div>
				<div class="searchFilterDiv marginR30" style="line-height:32px">
					<div class="paramName taright" style="width:110px">Téléphone</div>
					<div class="paramValue"><asp:TextBox ID="TextBoxTel" CssClass="style2d" runat="server"></asp:TextBox>&nbsp;</div>
				</div>
				
				<div class="searchFilterDiv marginR30" style="line-height:32px">
					<div class="paramName taright" style="width:110px">Fax</div>
					<div class="paramValue"><asp:TextBox ID="TextBoxFax" CssClass="style2d" runat="server"></asp:TextBox>&nbsp;</div>
				</div>
			</div>
			
			<div>
				<div class="searchFilterDiv marginR30" style="line-height:32px">
					<div class="paramName taright" style="width:110px">Société</div>
					<div class="paramValue"><asp:TextBox ID="TextBoxSociete" CssClass="style2d" runat="server"></asp:TextBox>&nbsp;</div>
				</div>

			</div>





            <div>    <%-- ///////////////////////////////////////////////////////////////  --%>


				<div class="searchFilterDiv marginR30" style="line-height:32px">
					<div class="paramName taright" style="width:110px">
                        Kbis
                    </div>
					<div class="paramValue"><asp:TextBox ID="TextBoxKbis" CssClass="style2d" runat="server"></asp:TextBox>&nbsp;</div>
				</div>

			</div>  

             <div>    


				<div class="searchFilterDiv marginR30" style="line-height:32px">
					<div class="paramName taright" style="width:190px">Nombre d'annonces</div>
					<div class="paramValue"><asp:TextBox ID="TextBoxNbminseloger" CssClass="style2d" runat="server"></asp:TextBox>&nbsp;</div>
				</div>

			</div>   <%-- //////////////////////////////////////////////////////////////  --%>






			
			<div class="clear"></div>
		
		

			<br/>
			<div class="tamid">
				<asp:Button ID="ButtonEnregistrer" runat="server" Text="Enregistrer" onclientclick="return validerForm();" OnClick="ButtonEnregistrer_Click1" class="myButton" Height="34px" Width="129px" />
				<br/>
				<br/><span style="color: rgb(0, 0, 0); font-family: 'Times New Roman'; font-size: medium; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none;">
					- Les champs précédés d'une astérisque * sont obligatoires.-</span>
			</div>
		</div>
	</div>
  <%--              <td rowspan="5" align="left" style="margin-left: 40px" >
					<asp:Image ID="Image1" runat="server" Height="210px" Width="214px" 
						BorderStyle="Groove" GenerateEmptyAlternateText="True" 
						ImageUrl="~/img_site/001.png" />
					<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Button ID="Button3" runat="server" Height="26px" Text="Choisir image"  
						Width="130px" onclick="Button3_Click" />
				</td>--%>

</asp:Content>

