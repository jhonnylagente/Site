<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true"  CodeFile="monComptetableaudebord_bis.aspx.cs" Inherits="pages_monCompte" Title="PATRIMONIUM : Mon espace client" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>

<script type="text/javascript">
	var champPays = "#<%=textBoxPays.ClientID%>";
	var champDep = "#<%=textBoxDep.ClientID%>";
	var champVille = "#<%=textBoxVille.ClientID%>";
	var saisie = "#<%=textBoxVille1.ClientID%>";
	var cp = "";
	var dept = "";
</script>
<script type="text/javascript" src="../JavaScript/ajax_listeLieu.js"></script>
<script type="text/javascript" src="../JavaScript/ajax_saisieLieu.js"></script>
<script type="text/javascript">
    //<!--
    function change_onglet(name) {
        document.getElementById('onglet_' + anc_onglet).className = 'onglet_0 onglet';
        document.getElementById('onglet_' + name).className = 'onglet_1 onglet';
        document.getElementById('contenu_onglet_' + anc_onglet).style.display = 'none';
        document.getElementById('contenu_onglet_' + name).style.display = 'block';
        var contenu = document.getElementById('contenu_onglet_achat').innerHTML;
        document.getElementById('contenu_onglet_location').innerHTML = contenu;

        anc_onglet = name;
    }
   </script>

    <!-- VERIFICATION DES PARAMETRES DE L'AFFICHAGE -->
    <style type="text/css">
        
        #fade { /*--Masque opaque noir de fond--*/
	display: none; /*--masqué par défaut--*/
	background: #000;
	position: fixed; left: 0; top: 0;
	width: 100%; height: 100%;
	opacity: .80;
	z-index: 9999;
}
.popup_block{
	display: none; /*--masqué par défaut--*/
	background: #fff;
	padding: 20px;
	border: 20px solid #ddd;
	float: left;
	font-size: 1.2em;
	position: fixed;
	top: 50%; left: 50%;
	z-index: 99999;
	/*--Les différentes définitions de Box Shadow en CSS3--*/
	-webkit-box-shadow: 0px 0px 20px #000;
	-moz-box-shadow: 0px 0px 20px #000;
	box-shadow: 0px 0px 20px #000;
	/*--Coins arrondis en CSS3--*/
	-webkit-border-radius: 10px;
	-moz-border-radius: 10px;
	border-radius: 10px;
}
img.btn_close {
	float: right;
	margin: -55px -55px 0 0;
}
/*--Gérer la position fixed pour IE6--*/
*html #fade {
position: absolute;
}
*html .popup_block {
position: absolute;
}
        .GreenTypeComboBoxStyle option.bad .ajax__combobox_itemlist li
        {
            background-color: DarkGreen;
            border: 1px solid YellowGreen;
            color: White;
            font-size: medium;
            font-family: Courier New;
            padding-bottom: 5px;
        }
        
        select.large option
        {
            color: Black;
            font-family: Monospace;
            white-space: pre;
        }
        select.large option.large
        {
            background-color: PaleGreen;
            font-family: Monospace;
            white-space: pre;
        }
        
        select.large option.precis
        {
            background-color: YellowGreen;
            font-family: Monospace;
            white-space: pre;
        }
        
        select.large option.anncien
        {
            background-color: BurlyWood;
            font-family: Monospace;
            white-space: pre;
        }
        select.large option.neuf
        {
            background-color: khaki;
            font-family: Monospace;
            white-space: pre;
        }
        
        
        .large
        {
        }
                
     
         .style4
         {
             width: 510px;
         }
            
     
         .style8
         {
             width: 419px;
         }
         .style9
         {
             width: 350px;
         }
            
     
         .style5
         {
             width: 650px;
         }
         
         .boutonDoc
         {
             width: 32px;
         }
         #donate label input {
    position:absolute;
    top:-20px;
}

#donate .white {
    background-color:#FFFFFF;
    color:#333;
}
.progress{background:url('../img_site/loading.gif') no-repeat right center;}

         </style>
    <%
        // messages de validation (lors de l'ajout d'une vente/location)
        if (Request.Params["valid"] == "oui")
        {
            LabelOK.Visible = true;
            LabelOK.Text = "Félicitations, votre bien a été enregistré";
        }
		
		
    %>
<body>
   <asp:UpdateProgress ID="UpdateProgress1" DynamicLayout="true" runat="server"  AssociatedUpdatePanelID="UpdatePanel1" >
        <ProgressTemplate>
            <div class='progress'>
                <img src="../img_site/712.gif" alt="Chargement..." style="position:fixed; margin-left: 470px; margin-top: 50px; width:80px"/>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdateProgress ID="UpdateProgress2" DynamicLayout="true" runat="server"  AssociatedUpdatePanelID="UpdatePanel3" >
        <ProgressTemplate>
            <div class="progress">
               <img src="../img_site/712.gif" alt="Chargement..." style="position:fixed; margin-left: 470px; margin-top: 50px; width:80px"/>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>


    <asp:UpdateProgress ID="UpdateProgress3" DynamicLayout="true" runat="server"  AssociatedUpdatePanelID="UpdatePanel4" >
        <ProgressTemplate>
            <div class="progress" >
                <img src="../img_site/712.gif" alt="Chargement..." style="position:fixed; margin-left: 470px; margin-top: 50px; width:80px"/>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdateProgress ID="UpdateProgress5" DynamicLayout="true" runat="server"  AssociatedUpdatePanelID="UpdatePanel6" >
        <ProgressTemplate>
            <div class="progress">
                <img  src="../img_site/712.gif" alt="Chargement..." style="position:fixed; margin-left: 470px; margin-top: 50px; width:80px"/>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    
<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
       
    <table class="moncompte">
        <tr>
            <td class="moncompteD1" style="height: 49px">
            
                <asp:Label ID="LabelOK" runat="server" Font-Bold="True" class="rouge" Visible="False"></asp:Label>
                <asp:Label ID="Labelmodif" runat="server" Font-Bold="True" class="rouge" Visible="False"></asp:Label>
                <!-- Message de confirmation d'ajout -->
                <!-- Affichage de l'erreur -->
                    <span style="background-color: Red;">
                        <asp:Label ID="Label1" runat="server" BorderStyle="None" Height="16px"></asp:Label>
                    </span>

                   
                        <asp:Label ID="LabelErrorLogin" runat="server" Font-Bold="True" ForeColor="#CC3333"
                            Visible="False" Width="502px"></asp:Label>
                            

                <div id="donate">
                    <label class="white" style="margin-left:7px">
                        <asp:RadioButton ID="radioButtonAchat" runat="server" Checked="true" GroupName="radioButtonGroup" Text="Achat" 
										    Font-Bold="False" AutoPostBack="true" OnCheckedChanged="radio_button_check" CssClass="myButtonblue" />
                    </label>
                    <label class="white">
				        <asp:RadioButton ID="radioButtonLocation" runat="server" Checked="false" GroupName="radioButtonGroup" Text="Location"
										    Font-Bold="false" AutoPostBack="true" OnCheckedChanged="radio_button_checkb" CssClass="myButtonred"/>   
                   </label>
               </div>
                                        
                <!-- FORMULAIRE DE RECHERCHE -->
                <div class="Recherche">
                    <fieldset>
                        
						<asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                        <ContentTemplate>  
						<fieldset>
							<legend class="bold">Détails de l'offre</legend>
							<div class="tablerecherche1">
								<div class="searchFilterDiv marginR30">
									<div class="paramName2">
										
										Type de bien
									</div>
									
									<div class="paramValue2">
										
										
										<div class="listChckBox">
											<div class="paramValue">
												<asp:CheckBox ID="checkBoxMaison"  runat="server" Checked="True" Font-Bold="False" Autopostback="true"/>Maison<br/>
												<asp:CheckBox ID="checkBoxAppart"  runat="server" Checked="True" Font-Bold="False" Autopostback="true"/>Appartement<br/>
												<asp:CheckBox ID="checkBoxTerrain"  runat="server" Checked="false" Font-Bold="False" Autopostback="true"/>Terrain<br/>
												<asp:CheckBox ID="checkBoxAutre"  runat="server" Checked="false" Font-Bold="False" Autopostback="true"/>Autre
											</div>
										</div>
									</div>
								</div>
								
								<div class="searchFilterDiv marginR30">
									<strong>Statut de l'offre</strong>
									<br/>
									<div class="paramValue listChckBox" style="margin-left:30px">
										<%if (radioButtonAchat.Checked)
										  { %>
										<asp:CheckBox ID="checkBoxEstimation" Font-Bold="False" runat="server" />Estimation<br/>
										<asp:CheckBox ID="checkBoxDisponible" Font-Bold="False" runat="server" />Disponible<br/>
										<asp:CheckBox ID="checkBoxOffre" Font-Bold="False" runat="server" />Offre
										<%}
										  else
										  { %>
										<asp:CheckBox ID="checkBoxLibre" Font-Bold="False" runat="server" />Libre<br/>
										<asp:CheckBox ID="checkBoxOccupe" Font-Bold="False" runat="server" />Occupé<br/>
										<asp:CheckBox ID="checkBoxLoue" Font-Bold="False" runat="server" />Loué
										<%} %>
									</div>
									<div class="paramValue listChckBox">
									<%if (radioButtonAchat.Checked)
									  { %>
									<asp:CheckBox ID="checkBoxSuspendu" Font-Bold="False" runat="server" />Suspendu<br/>
									<asp:CheckBox ID="checkBoxRetire" Font-Bold="False" runat="server" />Retiré<br/>
									<asp:CheckBox ID="checkBoxCompromis" Font-Bold="False" runat="server" />Compromis
									<%}
									  else
									  { %>
									<asp:CheckBox ID="checkBoxOption" Font-Bold="False" runat="server" />Option<br/>
									<asp:CheckBox ID="checkBoxReserve" Font-Bold="False" runat="server" />Réservé<br/>
									<asp:CheckBox ID="checkBoxRet" Font-Bold="False" runat="server" />Retiré<br/>
									<asp:CheckBox ID="checkBoxSusp" Font-Bold="False" runat="server" />Suspendu
									<%} %>
									</div>	
								</div>
								
								<div class="searchFilterDiv marginR30">
									<div class="paramName">
										Référence<br/>
										Type de mandat
										<%Membre member = (Membre)Session["Membre"];
                                        String NomNego = member.PRENOM + " " + member.NOM; 
                                        if (member.STATUT == "ultranego" || member.STATUT == "nego")
										{ %>
											<br/>Négociateurs
										<%} %>
									</div>
									<div class="paramValue">
										<asp:TextBox ID="tbReferance" runat="server" CssClass="RechercheInputII" width="70"></asp:TextBox>
										&nbsp;<br/>
										<asp:DropDownList ID="DropDownListTypeMandat" runat="server" CssClass="RechercheInputII">
											<asp:ListItem></asp:ListItem>
											<asp:ListItem>Simple</asp:ListItem>
											<asp:ListItem>Exclusif</asp:ListItem>
										</asp:DropDownList>&nbsp;
										<%if (member.STATUT == "ultranego" || member.STATUT == "nego")
										{ %>
											<br/>
											<asp:DropDownList ID="DropDownListNegociateur" runat="server" CssClass="RechercheInputII" Width="160px"
												AutoPostBack="true" OnSelectedIndexChanged="charge_page">
												<asp:ListItem></asp:ListItem>
											</asp:DropDownList>&nbsp;
										<%} %>
									</div>
								</div>
								
								<div class="searchFilterDiv">
									<div class="paramName">
                                        <!--<div style="position: absolute; top: 390px; left: 100">-->
										<strong>Date de création </strong><br/>
										<asp:TextBox ID="textBoxDateCreationMin" runat="server" CssClass="tb80" Width="65" MaxLength="25" Style="margin-left:10px; text-align: right" onfocus="HS_setDate(this)" onclick="stopPropagation(event)"></asp:TextBox>
										&nbsp;à&nbsp; 
										<asp:TextBox ID="textBoxDateCreationMax" runat="server" CssClass="tb80" Width="65" MaxLength="25" Style="margin-bottom:5px;text-align: right" onfocus="HS_setDate(this)" onclick="stopPropagation(event)"></asp:TextBox>
										<br/>
										<strong>Date de mise à jour </strong><br/>
										<asp:TextBox ID="textBoxDateMajMin" runat="server" CssClass="tb80" Width="65" MaxLength="25" Style="margin-left:10px;text-align: right" onfocus="HS_setDate(this)" onclick="stopPropagation(event)"></asp:TextBox>
										&nbsp;à&nbsp; 
										<asp:TextBox ID="textBoxDateMajMax" runat="server" CssClass="tb80" Width="65" MaxLength="25" Style="margin-bottom:5px;text-align: right" onfocus="HS_setDate(this)" onclick="stopPropagation(event)"></asp:TextBox>
									</div>
								</div>
							</div>
						</fieldset>
						
						<fieldset style="margin-top:5px">
							<legend class="bold">Caractéristiques du bien</legend>
							<div class="tablerecherche1">
								<div class="searchFilterDiv widthTier">
									<div class="paramName">
										Budget<br/>
										Pièces<br/>
										Chambres
									</div>
									
									<div class="paramValue">
										<asp:TextBox ID="TextBoxBudgetMin" runat="server" MaxLength="10" CssClass="RechercheInputII" Style="text-align: right" Width="60"></asp:TextBox>
										 &nbsp;à&nbsp;
										 <asp:TextBox ID="TextBoxBudgetMax" runat="server" MaxLength="11" CssClass="RechercheInputII" Style="text-align: right" Width="60"></asp:TextBox>&nbsp;&#8364;
										&nbsp;<br/>
										<asp:CheckBox ID="checkBoxPiece1" Font-Bold="False" runat="server" />1
										<asp:CheckBox ID="checkBoxPiece2" Font-Bold="False" runat="server" />2
										<asp:CheckBox ID="checkBoxPiece3" Font-Bold="False" runat="server" />3
										<asp:CheckBox ID="checkBoxPiece4" Font-Bold="False" runat="server" />4
										<asp:CheckBox ID="checkBoxPiece5" Font-Bold="False" runat="server" />5+&nbsp;
										<br/>
										<asp:CheckBox ID="checkBoxChambre1" Font-Bold="False" runat="server" />1
										<asp:CheckBox ID="checkBoxChambre2" Font-Bold="False" runat="server" />2
										<asp:CheckBox ID="checkBoxChambre3" Font-Bold="False" runat="server" />3
										<asp:CheckBox ID="checkBoxChambre4" Font-Bold="False" runat="server" />4
										<asp:CheckBox ID="checkBoxChambre5" Font-Bold="False" runat="server" />5+ &nbsp;
									</div>
								</div>
								
								<div class="searchFilterDiv widthTier">
									<div class="paramName">
										<%if (checkBoxMaison.Checked || checkBoxTerrain.Checked)
										{ %>
										<strong>Surface terrain&nbsp;</strong><br />
										<%} %>
										
										<%if (checkBoxAppart.Checked || checkBoxMaison.Checked)
										{%>
											<strong>Surface habitable&nbsp;<br />
											Surface séjour&nbsp;</strong><br />
										<%} %>
									</div>
									
									<div class="paramValue">
										<%if (checkBoxMaison.Checked || checkBoxTerrain.Checked)
										{ %>
											<asp:TextBox ID="textBoxSurfaceTMin" runat="server" CssClass="RechercheInputII" MaxLength="6" Style="text-align: right" Width="40"></asp:TextBox>
											&nbsp;à&nbsp;
											<asp:TextBox ID="textBoxSurfaceTMax" runat="server" CssClass="RechercheInputII" MaxLength="6" Style="text-align: right" Width="40"></asp:TextBox>
											&nbsp;m²<br/>
										<%} %>
										
										<%if (checkBoxAppart.Checked || checkBoxMaison.Checked)
										{%>
											<asp:TextBox ID="textBoxSurfaceMin" runat="server" MaxLength="5" CssClass="RechercheInputII" Style="text-align: right" Width="40"></asp:TextBox>
											&nbsp;à&nbsp;
											<asp:TextBox ID="textBoxSurfaceMax" runat="server" MaxLength="5" CssClass="RechercheInputII" Style="text-align: right" Width="40"></asp:TextBox>
											&nbsp;m²<br/>
											<asp:TextBox ID="TextBoxSurfaceSMin" runat="server" MaxLength="5" CssClass="RechercheInputII" Style="text-align: right" Width="40"></asp:TextBox>
											&nbsp;à&nbsp;
											<asp:TextBox ID="TextBoxSurfaceSMax" runat="server" MaxLength="5" CssClass="RechercheInputII" Style="text-align: right" Width="40"></asp:TextBox>
											&nbsp;m²<br/>
										<%} %>
									</div>
								</div>
								
								<div class="searchFilterDiv widthTier">
									<div class="paramName">
                                        <table>
                                            <tr>
                                                <td>
												    <asp:CheckBox ID="chckBxCdC" Checked="false" runat="server" />&nbsp;Coup de Coeur<br />
												    <asp:CheckBox ID="chckBxPrestige" Checked="false" runat="server" />&nbsp;Prestige<br />
                                                    Neuf&nbsp;
												    <asp:DropDownList ID="ListeNeuf" runat="server">
													    <asp:ListItem Value="2" Text="Tous" Selected="true"></asp:ListItem>
													    <asp:ListItem Value="1" Text="Oui"></asp:ListItem>
													    <asp:ListItem Value="0" Text="Non"></asp:ListItem>
												    </asp:DropDownList>
                                                </td>
                                                <td valign="top">
                                                    <asp:CheckBox ID="chckBxMer" Checked="false" runat="server" />&nbsp;Mer<br />
												    <asp:CheckBox ID="chckBxMontagne" Checked="false" runat="server" />&nbsp;Montagne
                                                </td>
                                            </tr>
                                        </table>
									</div>
								</div>
							</div>
						</fieldset>
						
						
						<fieldset style="float:right;margin-top:5px;min-height:71px">
							<legend class="bold">Vendeur</legend>
							<div class="tablerecherche1">
								<div class="searchFilterDiv">

									<div class="paramName">
										Nom<br/>
										Adresse
									</div>
								</div>
								<div class="searchFilterDiv" style="margin-right:15px;">
									<div class="paramValue">
										 <asp:TextBox ID="tbNomVendeur" CssClass="RechercheInputII" runat="server" Width="120px"></asp:TextBox>&nbsp;<br/>
										 <asp:TextBox ID="TextBoxAdresseVendeur" CssClass="RechercheInputII" runat="server" Width="120px"></asp:TextBox>&nbsp;
									</div>
									
									<div class="paramName">
										Tél.<br/>
										Mail
									</div>
								</div>
								<div class="searchFilterDiv">
									<div class="paramValue">
										<asp:TextBox ID="TextBoxTelVendeur" CssClass="RechercheInputII" runat="server" Width="120px"></asp:TextBox>&nbsp;<br/>
										<asp:TextBox ID="TextBoxMailVendeur" CssClass="RechercheInputII" runat="server" Width="120px"></asp:TextBox>&nbsp;
									</div>
								</div>
						</fieldset>
						
                        </ContentTemplate> 
                        </asp:UpdatePanel> 
						
						<fieldset style="margin-top: 5px; min-height: 71px;">
							<legend class="bold">Localisation (CP, villes)</legend>
							<div class="tablerecherche1">
								<div class="searchFilterDiv" style="width:200px;line-height:24px">
									<div>
										<%--<asp:TextBox ID="textBoxVille1" placeholder="ville, département, pays" class="RechercheInputII" runat="server" onkeyup="requeteAjax(event,this, 0,42)"/>--%>
                                        <asp:TextBox ID="textBoxVille1" runat="server" placeholder="ville, département, pays" class="RechercheInputII"/>
                                        <div id="ok" class="tooltipContainer">
											<img src="../img_site/boutton_Supprimer.png" class="cursor_link" alt="cancel" style="margin-bottom:-2px" onclick="viderTout();">
											<div id="list_search" class="tooltip2" style="z-index:5;">
												<span>Vider la liste des lieux</span>
											</div>
										</div>
										&nbsp;<span id="saisieauto0" onclick="stopPropag(event);"></span><br/>
										<!--<button class="myButtonClear cursor_link" onclick="viderTout(); return false;" style="margin-top:5px;">Vider</button>-->
										<asp:TextBox ID="textBoxVille" runat="server" class="invisible" ClientIDMode="Static"/>
										<asp:TextBox ID="textBoxDep" runat="server" class="invisible"/>
										<asp:TextBox ID="textBoxPays" runat="server" class="invisible"/>
									</div>
								</div>
								<div id="listeFiltreLieu" style="float:left;">
								</div>
							</div>
						</fieldset>
						<br/>
                                        <!--<div>
									<strong>Adresse du Bien</strong>
									<br />
									<asp:TextBox ID="textBoxAdresseBien" runat="server" onkeydown="chkKey(arguments[0]);" CssClass="tbsituation"
										onkeyup="chkKey(arguments[0]);" onkeypress="chkKey(arguments[0]);" Rows="0" TextMode="MultiLine" style="max-width: 250px; " Height="60" Width="200" />
                                </div>-->
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" >
                        <ContentTemplate>  
						<div style="float:left;">
							<strong>Mot clé (facultatif)</strong> &nbsp;&nbsp;
							<asp:TextBox ID="textBoxMotCle1" runat="server" CssClass="tb10"></asp:TextBox>
							&nbsp;
							<asp:TextBox ID="textBoxMotCle2" runat="server" CssClass="tb10"></asp:TextBox>
							&nbsp;
							<asp:TextBox ID="textBoxMotCle3" runat="server" CssClass="tb10"></asp:TextBox>
							&nbsp;
							<asp:TextBox ID="textBoxMotCle4" runat="server" CssClass="tb10"></asp:TextBox>
						</div>
						
						<div style="float:right;">

							<asp:Button ID="Button1" runat="server" CssClass="myButtonOK cursor_link" Text="ok" OnClick="Button1_Click_Tab" 
								TabIndex="1" onkeyup="requeteAjax(event,this, 0,42)" OnClientClick="javascript:onbtnclick()"/>
							<asp:ImageButton ImageURL="../img_site/boutton_Supprimer.png" ID="Button2" runat="server" OnClick="Annuler"  />
							<asp:CheckBox ID="CheckBoxArchive" Font-Bold="False" runat="server" Visible="true" Text="Voir archives"/>
                          <div id="loadingRecherche">
			            </div>          
						</div>
                        </ContentTemplate> 
                        </asp:UpdatePanel> 
                    </fieldset>
                </div>
            </td>
        </tr>
    </table>
  <asp:UpdatePanel ID="UpdatePanel4" runat="server" >
                        <ContentTemplate>  
    <div>                    
        &nbsp;&nbsp;Nombre de biens : &nbsp;&nbsp;<asp:Label ID="LabelbnBiens" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RadioButton ID="RadioButtonMesBiens" runat="server" GroupName="radioButtonGroup1"
            Text="mes biens" Checked="true" AutoPostBack="true" OnCheckedChanged="charge_page" />
        <asp:RadioButton ID="RadioButtonMonAgence" runat="server" GroupName="radioButtonGroup1"
            Text="mon agence" Checked="false" AutoPostBack="true" OnCheckedChanged="charge_page" />
        <asp:RadioButton ID="RadioButtonTousLesBiens" runat="server" GroupName="radioButtonGroup1"
            Text="tous les biens" Checked="false" AutoPostBack="true" OnCheckedChanged="charge_page" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Nombre de biens par page <asp:DropDownList ID="DropDownListPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ItemChange">
            <asp:ListItem Value="10" Text="10" />
            <asp:ListItem Value="20" Text="20" />
            <asp:ListItem Value="30" Text="30" />
            <asp:ListItem Value="50" Text="50" />
            <asp:ListItem Value="100" Text="100" />
        </asp:DropDownList>
    </div>
        <asp:GridView ID="GridView1" CssClass="Gridview" runat="server" AutoGenerateColumns="false"
            AllowPaging="true" DataKeyNames="ref" Width="100%" 
            HorizontalAlign="Center" OnPageIndexChanging="PaginateTheData"
            PagerSettings-Mode="Numeric" OnRowDataBound="ReSelectSelectedRecords" AllowSorting="true"
            OnSorting="SortRecords" CellPadding="2" 
            onselectedindexchanged="GridView1_SelectedIndexChanged">
            <Columns>
                <%--0--%><asp:BoundField HeaderText="Réf." DataField="ref" SortExpression="ref" HeaderStyle-CssClass="Entet"/>
                <%--1--%><asp:BoundField HeaderText="Date de création" DataField="date dossier" SortExpression="date dossier"
                    DataFormatString="{0:d}" HeaderStyle-CssClass="Entet" />
                <%--2--%><asp:TemplateField HeaderText="Type" SortExpression="ref" HeaderStyle-CssClass="Entet">
                </asp:TemplateField>
                <%--3--%><asp:TemplateField HeaderText="Type bien" SortExpression="type de bien" HeaderStyle-CssClass="Entet">
                </asp:TemplateField>
                <%--4--%><asp:BoundField HeaderText="Etat" DataField="etat" SortExpression="etat" HeaderStyle-CssClass="Entet" />
                <%--5--%><asp:BoundField HeaderText="Nom de proprio" DataField="nom vendeur" SortExpression="nom vendeur"
                    HeaderStyle-CssClass="Entet" />
                <%--6--%><asp:BoundField HeaderText="Adresse" DataField="adresse du bien" SortExpression="code postal du bien"
                    HeaderStyle-CssClass="Entet" />
                <%--7--%><asp:BoundField HeaderText="Code postal" DataField="code postal du bien" SortExpression="code postal du bien"
                    HeaderStyle-CssClass="Entet" />
                <%--8--%><asp:BoundField HeaderText="Ville" DataField="ville du bien" SortExpression="ville du bien"
                    HeaderStyle-CssClass="Entet" />
                <%--9--%><asp:BoundField HeaderText="Pays" DataField="PaysBien" SortExpression="PaysBien"
                    HeaderStyle-CssClass="Entet" />
                <%--10--%><asp:BoundField HeaderText="Tél." DataField="tel domicile vendeur" SortExpression="tel domicile vendeur"
                    HeaderStyle-CssClass="Entet" />
                <%--11--%><asp:BoundField HeaderText="Mail" DataField="adresse mail vendeur" SortExpression="adresse mail vendeur"
                    HeaderStyle-CssClass="Entet" />
                <%--12--%><asp:BoundField HeaderText="Loyer" DataField="loyer_cc" SortExpression="loyer_cc"
                    DataFormatString="{0:C0}" HeaderStyle-CssClass="EntetAdresse" Visible="true" />
                <%--13--%><asp:BoundField HeaderText="Prix" DataField="prix de vente" SortExpression="prix de vente"
                    DataFormatString="{0:C0}" HeaderStyle-CssClass="EntetAdresse" Visible="true" />
				<%--14--%><asp:TemplateField HeaderText="Prix <br/>du m²" HeaderStyle-CssClass="EntetAdresse">
                    <ItemTemplate>
                        <asp:Label ID="Prixm" runat="server" Text='<%# affiche_prix(DataBinder.Eval(Container, "DataItem.[surface habitable]").ToString(),DataBinder.Eval(Container, "DataItem.[prix de vente]").ToString())%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--15--%><asp:BoundField HeaderText="Nbr. pièces" DataField="nombre de pieces" SortExpression="nombre de pieces"
                    HeaderStyle-CssClass="Entet" />
                <%--16--%><asp:BoundField HeaderText="Surf. hab." DataField="surface habitable" SortExpression="surface habitable"
                    HeaderStyle-CssClass="Entet" />
                <%--17--%><asp:BoundField HeaderText="Surf. terr." DataField="surface terrain" SortExpression="surface terrain"
                    HeaderStyle-CssClass="Entet" />
                <%--18--%><asp:BoundField HeaderText="Et." DataField="etage" SortExpression="etage" HeaderStyle-CssClass="Entet" />
                <%--19--%><asp:BoundField HeaderText="Asc." DataField="ascenceur" SortExpression="ascenceur"
                    HeaderStyle-CssClass="Entet" />
                <%--20--%><asp:BoundField HeaderText="Mandat" DataField="type mandat" SortExpression="type mandat"
                    HeaderStyle-CssClass="Entet" />
                <%--21--%><asp:BoundField HeaderText="Nego." DataField="negociateur" SortExpression="negociateur"
                    HeaderStyle-CssClass="EntetAdresse" />
                <%--22--%><asp:TemplateField HeaderText="Photo" HeaderStyle-CssClass="Entet">
                    <ItemTemplate>
                        <img id="imgphoto" src="<%# affiche_photo(DataBinder.Eval(Container, "DataItem.ref").ToString())%>"
                            class="icone_photo" alt="" />
                        <%# tooltip_photo(DataBinder.Eval(Container, "DataItem.ref").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--23--%><asp:TemplateField HeaderStyle-CssClass="Entet">
                    <HeaderTemplate>
                        <asp:Image ID="Image1" ImageUrl="../img_site/flat_round/modifier.png" CssClass="croix_rouge"
                            runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Modifier" runat="server" Text='<%# modifier_bien(DataBinder.Eval(Container, "DataItem.ref").ToString())%>'></asp:Label>
                        <div class="tooltip">
                            <span>Modifier le bien</span></div>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--24--%><asp:TemplateField HeaderStyle-CssClass="Entet">
                    <HeaderTemplate>
                        <asp:CheckBox ID="CheckBoxSelection" AutoPostBack="true" OnCheckedChanged="Tout_Selectionner"
                            runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBoxArchiver" OnClick="Achive_Click" runat="server" />
                        <div class="tooltip">
                            <span>Sélection multiple</span></div>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--25--%><asp:TemplateField HeaderText="Choisir une ligne" HeaderStyle-CssClass="Entet">
                    <ItemTemplate>
                        <input name="MyRadioButton" id="MyRadioButton" type="radio" value='<%# Eval("ref") %>' />
                        <div class="tooltip">
                            <span>Sélection unique</span></div>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--26--%><asp:TemplateField HeaderText="rapproch." HeaderStyle-CssClass="Entet">
                    <ItemTemplate>
                        <a href="../pages/rapprochementbien.aspx?idAcq=<%# Eval("ref") %>">
                            <img id="imgphoto" src="../img_site/rapprochement.png" alt="fleche" style="width:25px" />
                        </a>
                        <div class="tooltip">
                            <span>rapprochement</span></div>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--27--%><asp:TemplateField HeaderStyle-CssClass="Entet" HeaderText="Cdc, Pr & Nf">
                    <ItemTemplate>
                        <asp:Label ID="imgCdcPrestige" runat="server" Text='<%# imgCdcPrestige(DataBinder.Eval(Container, "DataItem.cdcPrestige").ToString()) %>'></asp:Label>
                        <div class="tooltip">
                            <span>Rouge = Coup de coeur<br />
                                Jaune = Prestige
                                <br />
                                Vert = Neuf</span></div>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--28--%><asp:TemplateField HeaderText="His." HeaderStyle-CssClass="Entet">
                    <ItemTemplate>
                        <a href="../pages/historique_visite.aspx?ref=<%# Eval("ref") %>">
                            <img id="imgphoto" src="../img_site/historique_b.png" alt="fleche" style="width:25px" />
                        </a>
                        <div class="tooltip">
                            <span>historique</span></div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
			<pagerstyle horizontalalign="Center"/>
        </asp:GridView>
            </ContentTemplate>
    <Triggers>
<asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
</Triggers>
</asp:UpdatePanel>
    <table align="center">
        <tr>
            <td  style="width: 872px">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
<ContentTemplate>  
                <div style="color: #31536C">
                    <%if (radioButtonAchat.Checked == true)
                    {%>
                    &nbsp;<strong>Estimation:</strong>
                    <div style="background-color: #F4A460; display: inline;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    &nbsp;&nbsp;<strong>Pub Locale:</strong>
                    <div style="background-color: #F4A490; display: inline;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    &nbsp;&nbsp;<strong>Disponible:</strong>
                    <div style="background-color: #FFFFFF; display: inline; border:1px solid black;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    &nbsp;&nbsp;<strong>Offre:</strong>
                    <div style="background-color: #FFE4C4; display: inline;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    &nbsp;&nbsp;<strong>Suspendu:</strong>
                    <div style="background-color: #808080; display: inline;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    &nbsp;&nbsp;<strong>Retiré:</strong>
                    <div style="background-color: #008000; display: inline;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    &nbsp;&nbsp;<strong>Compromis:</strong>
                    <div style="background-color: #FFFF00; display: inline;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    <%}
                    else if (radioButtonLocation.Checked == true)
                    {%>
                    &nbsp;<strong>Libre:</strong>
                    <div style="background-color: #FFFFFF; display: inline;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    &nbsp;&nbsp;<strong>Occupé:</strong>
                    <div style="background-color: #FFD700; display: inline;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    &nbsp;&nbsp;<strong>Loué:</strong>
                    <div style="background-color: #ADD8E6; display: inline;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    &nbsp;&nbsp;<strong>Option:</strong>
                    <div style="background-color: #FFA500; display: inline;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    &nbsp;&nbsp;<strong>Réservé:</strong>
                    <div style="background-color: #DDA0DD; display: inline;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    &nbsp;&nbsp;<strong>Retirer:</strong>
                    <div style="background-color: #000080; display: inline;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    &nbsp;&nbsp;<strong>Suspendu:</strong>
                    <div style="background-color: #808080; display: inline;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    <%}%>
                </div>
    </ContentTemplate>
    <Triggers>
<asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
</Triggers>
</asp:UpdatePanel>

                <div class="divcombobox">
                    <asp:Label ID="Label2" Text="Choisissez un acquereur: " runat="server" Font-Bold="True"
                        ForeColor="#CC3333" Visible="true"></asp:Label>
                    <table style="width: 125px; height: 19px;" visible="false">
                        
                                    <td style="width: 358px" class="table_listeAvanceAjoutacquereur">
                                        <div style="width: 205px">
                                            <asp:ComboBox ID="ComboBox1" runat="server" AutoCompleteMode="None" AutoPostBack="false"
                                                RenderMode="Block" CssClass="large" Visible="False">
                                            </asp:ComboBox>
                                            
                                          <tr>
                        <td class="style4" colspan="3">
                        <b>Acquéreur </b>:&nbsp;&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" style="max-width: 250px;"><asp:ListItem></asp:ListItem></asp:DropDownList>
                        </td>
                    </tr>                     
                                    </table>
                </div>
                <table style="width: 939px">
  
                    <tr>
                        <td class="style8">
                            <fieldset style="width: 344px; height:154px">
                                <legend><strong style="color: #31536c">
                                    <asp:Image ID="Image3" runat="server" Height="16px" 
                                        ImageUrl="~/img_site/Carre.jpg" Width="16px" />
                                    &nbsp;Choix multiple</strong></legend>

                                
                                <asp:LinkButton ID="ButtonBonDeVisite" runat="server" OnClick="Bon_De_Visite" style='color:black;cursor:pointer;' class="search">
                                    <img class="boutonDoc" style='margin-bottom:-15px;' src='../img_site/bon_visite.png'/> <div style="width:100px" class='texte_menu_footer'>Bon de visite</div> 
                                </asp:LinkButton>
                                <asp:LinkButton ID="Button3" runat="server" OnClick="Listaffaires_click" style='color:black;cursor:pointer;' class="search">
                                <span title="LISTE AFFAIRE">
                                    <img class="boutonDoc" style='margin-bottom:-15px;' src='../img_site/bouton_liste.png'/> <div class='texte_menu_footer'>Liste aff.</div>
                                </span> 
                                </asp:LinkButton>
                                
                                <div style="height:15px"></div>

                                <asp:LinkButton runat="server" OnClick="fichenegociateur_click" style='color:black;cursor:pointer;' class="search">
                                <span title="FICHE NEGOCIATEUR">
                                    <img class="boutonDoc" style='margin-bottom:-15px;' src='../img_site/fiche_negociateur.png'/> <div style="width:100px" class='texte_menu_footer'>Fiche nego.</div>
                                </span>
                                </asp:LinkButton>

                                <asp:LinkButton runat="server" OnClick="fichecommerciale_click" style='color:black;cursor:pointer;' class="search">
                                <span title="FICHE COMMERCIALE">
                                    <img class="boutonDoc" style='margin-bottom:-15px;' src='../img_site/fiche_commerciale.png'/> <div class='texte_menu_footer'>Fiche com.</div>
                                </span> 
                                </asp:LinkButton>

                                <div style="height:15px"></div>
                                
                                 <asp:UpdatePanel ID="UpdatePanel6" runat="server" >
                                 <ContentTemplate>     
                                    <%Membre member3 = (Membre)Session["Membre"];
                                      String NomNego = member3.PRENOM + " " + member3.NOM;
                                      if (RadioButtonMesBiens.Checked == true || member3.STATUT == "ultranego")
                                    {%>
                                <asp:LinkButton ID="BoutonArchiver" runat="server" OnClick="Archiver_Reactiver" style='color:black;cursor:pointer;' class="search" Visible="true">
                                    <img class="boutonDoc" style='margin-bottom:-15px;' src='../img_site/archiver.png'/> <div class='texte_menu_footer'>Archiver/Reactiver</div> 
                                </asp:LinkButton>
                                
                                <div style="height:15px"></div>

                                <%}%>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                                
                                    <%Membre member2 = (Membre)Session["Membre"];
                                      String NomNego = member2.PRENOM + " " + member2.NOM; 
                                      if (member2.STATUT == "ultranego")
                                    {%>
                                    <a href="#" data-width="500" data-rel="popup1" class="poplight">
                                        <asp:LinkButton ID="Button6" runat="server" OnClick="fichenegociateur_click" style='color:black;cursor:pointer;' class="search" Visible="true">
                                        <span title="MODIFIER NEGOCIATEUR">
                                            <img class="boutonDoc" style='margin-bottom:-15px;' src='../img_site/modif_nego.png'/> <div class='texte_menu_footer'>Modifier nego.</div>
                                        </span>
                                        </asp:LinkButton>
                                    </a>
                                     <%}%>
                                    <div id="popup1" class="popup_block" style="display: none; width: 500px; margin-top: -159.5px; margin-left: -290px;">
	                                <p>Choisissez le nouveau négociateur en charge:<asp:DropDownList ID="DropDownList2" runat="server" CssClass="RechercheInputII" Width="160px">
												<asp:ListItem></asp:ListItem>
											</asp:DropDownList>&nbsp;
                                    </p>
                                    <asp:Button ID="apply" runat="server" CssClass="myButton" 
                                    OnClick="apply_click" Text="ok" Visible="true" Width="154px" />
                                    </div>
                                <br />
                            </fieldset>
                        </td>
                        <td class="style9">
                            <fieldset style="width: 350px; height:154px">
                                <legend>
                                    <asp:Image ID="Image2" runat="server" Height="16px" 
                                        ImageUrl="~/img_site/Ronde.jpg" Width="16px" />
                                    <strong style="color: #31536c">&nbsp;Choix unique </legend>

                                <asp:LinkButton ID="ButtonAvenant" runat="server" OnClick="Button_Avenant" style='color:black;cursor:pointer;' class="search">
                                    <img class="boutonDoc" style='margin-bottom:-15px;' src='../img_site/mandat_avenant.png'/> <div style="width:120px" class='texte_menu_footer'>Mandat avenant</div>
                                </asp:LinkButton>
                                

                                <asp:LinkButton ID="ButtonMandat" runat="server" OnClick="Mandat" style='color:black;cursor:pointer;' class="search">
                                    <img class="boutonDoc" style='margin-bottom:-15px;' src='../img_site/mandat_a_signe.png'/> <div class='texte_menu_footer'>Mandat</div> 
                                </asp:LinkButton>
                                
                                <div style="height:15px"></div>

                                <asp:LinkButton ID="ButtonMandatencours" runat="server" OnClick="Mandatencours" style='color:black;cursor:pointer;' class="search">
                                    <img class="boutonDoc" style='margin-bottom:-15px;' src='../img_site/mandat_en_cours.png'/> <div style="width:120px" class='texte_menu_footer'>Mandat en cours</div> 
                                </asp:LinkButton>

                                <asp:LinkButton ID="BoutonDupliquer" runat="server" OnClick="Dupliquer" style='color:black;cursor:pointer'  class="search">
                                    <img class="boutonDoc" style='margin-bottom:-15px;' src='../img_site/dupliquer.png'/> <div class='texte_menu_footer'>Dupliquer</div> 
                                </asp:LinkButton>

                                <div style="height:15px"></div>

                                <asp:LinkButton ID="ButtonVente" runat="server" OnClick="vente" style='color:black;cursor:pointer;' class="search" Visible="False">
                                <span title="ENREGISTRER VENTE">
                                    <img class="boutonDoc" style='margin-bottom:-15px;' src='../img_site/enregistrement_vente.png'/> <div class='texte_menu_footer'>Enr. vente</div> 
                                </span>
                                </asp:LinkButton>
                                <asp:LinkButton ID="ButtonLocation" runat="server" OnClick="Location" style='color:black;cursor:pointer;' class="search" Visible="False">
                                <span title="ENREGISTRER LOCATION">
                                    <img class="boutonDoc" style='margin-bottom:-15px;' src='../img_site/enregistrement_vente.png'/> <div class='texte_menu_footer'>Enr. location</div>
                                </span>
                                </asp:LinkButton>
                                </strong>
                            </fieldset></td>
                        <td class="style5">
                            <fieldset style="width: 216px; height:154px">
                                <legend><strong style="color: #31536c">&nbsp;Actions </legend>
                                    
                                <asp:LinkButton runat="server" OnClick="Ajout_Acq" style='color:black;cursor:pointer;' class="search">
                                    <img class="boutonDoc" style='margin-bottom:-15px;' src='../img_site/ajout_acquereur.png'/> <div class='texte_menu_footer'>Ajouter acquereur</div> 
                                </asp:LinkButton>
                                
                                <div style="height:15px"></div>
                                
                                <asp:LinkButton runat="server" OnClick="Ajouterunbien" style='color:black;cursor:pointer;' class="search">
                                    <img class="boutonDoc" style='margin-bottom:-15px;' src='../img_site/ajout_bien.png'/> <div class='texte_menu_footer'>Ajouter bien</div> 
                                </asp:LinkButton>
                                
                                <div style="height:15px"></div>                                

                                <asp:LinkButton runat="server" OnClick="Dernieres_Visites" style='color:black;cursor:pointer;' class="search">
                                    <img class="boutonDoc" style='margin-bottom:-15px;' src='../img_site/dernieres_visites.png'/> <div class='texte_menu_footer'>Dernières visites</div> 
                                </asp:LinkButton>      
                                </strong>
							</fieldset>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

   <script type="text/javascript">
       //<!--
       var anc_onglet = 'achat';
       change_onglet(anc_onglet);
       //-->
        </script>
    <script src="http://code.jquery.com/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
<link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css" rel="Stylesheet" type="text/css" />
<link href="jquery-ui.css" rel="stylesheet" type="text/css" /> 
<script type="text/javascript">
    $(function () {
        var div = "";
        var elt = "";
        var inp = $("[id$=textBoxVille]");
        var inp2 = $("[id$=textBoxPays]");
        if (inp.val().length != 0) {
            $("[id$=textBoxVille]").val(" ");
        };
        if (inp2.val().length != 0) {
            $("[id$=textBoxPays]").val(" ");
        };
        $("[id$=textBoxVille1]").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: '<%=ResolveUrl("~/pages/monComptetableaudebord_bis.aspx/Getvilles") %>',
                    data: "{ 'prefix': '" + request.term + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                label: item
                            };
                        }));
                    }
                });
            },
            search: function (e, u) {
                $(this).addClass('progress');
            },
            response: function (e, u) {
                $(this).removeClass('progress');
            },
            error: function (response) {
                alert(response.responseText);
            },
            minLength: 2,
            select: function (e, ui) {
                div = document.getElementById('listeFiltreLieu');
                if (ui.item.label == "warning_red_24.png/Aucun résultat!") {
                    return false;
                }
                var select = ui.item.label.split('/')[1];
                //                var count = "";
                //                alert("select " + select.toString().split(' ').length);
                //                    if (select.toString().split(' ').length == 1) {
                //                    count += "," + select.toString().split(' ');
                //                    $("#<%=textBoxPays.ClientID%>").val(count.toString());
                //                    alert( "list pays: " + count.toString());
                //                    alert("val textbox pays  "+ $("#<%=textBoxPays.ClientID%>").val());
                //                }
                div.innerHTML = div.innerHTML + "<div id='LL_" + "/" + select + "/" + "' class='boxLieu' onclick='getId(this);'><img id='img' src='../img_site/boutton_Supprimer.png' alt='Retirer' class='cursor_link' style='margin-bottom:-4px'/>" + " " + select.toString() + " " + "</div>" + "  ";
                $("[id$=textBoxVille1]").val("");
                elt = document.getElementById("LL_" + "/" + select + "/" + "");
                $("[id$=textBoxVille]").val("");
                if (select.toString().split(' ')[1].length == 2) {
                    $("[id$=textBoxDep]").val("");
                    dept += ',' + select.toString().split(' ')[1];
                    $("#<%=textBoxDep.ClientID%>").val(dept.replace(',', ''));
                }
                alert("dept textbox: " + $("[id$=textBoxDep]").val());
                if (select.toString().split(' ')[1].length == 5) {
                    var first = elt.innerText.replace("(", "");
                    var second = first.toString().replace(")", "");
                    var third = second.toString().split(' ')[2] + " " + second.toString().split(' ')[3];
                    cp += "," + third.toString().split(' ')[0];
                    alert("cp: " + cp);
                    alert("dept: " + dept);
                    inp.val(cp.replace(',', ''));
                }
                if (($("[id$=textBoxVille]").val() == "") || ($("[id$=textBoxVille1]").val() == "")) {
                    cp = "";
                }
                if ($("[id$=textBoxDep]").val() == "") {
                    dept = "";
                    cp = "";
                }
                return false;
            }
        }).data("autocomplete")._renderItem = function (ul, item) {
            return $("<li></li>")
                    .data("item.autocomplete", item)
                    .append("<div class='ajouterAcquereur_ClickableCell'><table><tr><td><a><img src='../img_site/drapeau/" + item.label.split('/')[0] + "'/></td><td>" + item.label.split('/')[1] + "</a></td></tr></table></div>")
                   .appendTo(ul);
        }
    });
     </script>
    <script type="text/javascript">
        function onbtnclick() {
            if (($("[id$=textBoxVille]").val() == "")||($("[id$=textBoxVille1]").val()=="")) {
                cp = "";
            }
            if ($("[id$=textBoxDep]").val() == "") {
                dept = "";
            }
        };
     </script>
    <script type="text/javascript">
        jQuery(function ($) {

            //When you click on a link with class of poplight and the href starts with a # 
            $('a.poplight').on('click', function () {
                var popID = $(this).data('rel'); //Get Popup Name
                var popWidth = $(this).data('width'); //Gets Popup Width

                //Fade in the Popup and add close button
                $('#' + popID).fadeIn().css({ 'width': popWidth }).prepend('<a href="#" class="close"><img src="../img_site/boutton_Supprimer.png" class="btn_close" title="Close Window" alt="Close" /></a>');

                //Define margin for center alignment (vertical + horizontal) - we add 80 to the height/width to accomodate for the padding + border width defined in the css
                var popMargTop = ($('#' + popID).height() + 80) / 2;
                var popMargLeft = ($('#' + popID).width() + 80) / 2;

                //Apply Margin to Popup
                $('#' + popID).css({
                    'margin-top': -popMargTop,
                    'margin-left': -popMargLeft
                });

                //Fade in Background
                $('body').append('<div id="fade"></div>'); //Add the fade layer to bottom of the body tag.
                $('#fade').css({ 'filter': 'alpha(opacity=80)' }).fadeIn(); //Fade in the fade layer 

                return false;
            });
            //Close Popups and Fade Layer
            $('body').on('click', 'a.close, #fade', function () { //When clicking on the close or fade layer...
                $('#fade , .popup_block').fadeOut(function () {
                    $('#fade, a.close').remove();
                }); //fade them both out

                return false;
            });
        });
    </script>
    <script type="text/javascript">
        function HS_DateAdd(interval, number, date) {
            number = parseInt(number);
            if (typeof (date) == "string") { var date = new Date(date.split("-")[0], date.split("-")[1], date.split("-")[2]) }
            if (typeof (date) == "object") { var date = date }
            switch (interval) {
                case "y": return new Date(date.getFullYear() + number, date.getMonth(), date.getDate()); break;
                case "m": return new Date(date.getFullYear(), date.getMonth() + number, checkDate(date.getFullYear(), date.getMonth() + number, date.getDate())); break;
                case "d": return new Date(date.getFullYear(), date.getMonth(), date.getDate() + number); break;
                case "w": return new Date(date.getFullYear(), date.getMonth(), 7 * number + date.getDate()); break;
            }
        }
        function checkDate(year, month, date) {
            var enddate = ["31", "28", "31", "30", "31", "30", "31", "31", "30", "31", "30", "31"];
            var returnDate = "";
            if (year % 4 == 0) { enddate[1] = "29" }
            if (date > enddate[month]) { returnDate = enddate[month] } else { returnDate = date }
            return returnDate;
        }
        function WeekDay(date) {
            var theDate;
            if (typeof (date) == "string") { theDate = new Date(date.split("-")[0], date.split("-")[1], date.split("-")[2]); }
            if (typeof (date) == "object") { theDate = date }
            return theDate.getDay();
        }
        function HS_calender() {
            var lis = "";
            var style = "";
            /*&#21487;&#20197;&#25226;&#19979;&#38754;&#30340;css&#21098;&#20999;&#20986;&#21435;&#29420;&#31435;&#19968;&#20010;css&#25991;&#20214;zzjs.net*/
            style += "<style type='text/css'>";
            style += ".calender { width:170px; height:auto; font-size:12px; margin-right:14px; background:url(calenderbg.gif) no-repeat right center #fff; border:1px solid #397EAE; padding:1px}";
            style += ".calender ul {list-style-type:none; margin:0; padding:0;}";
            style += ".calender .day { background-color:#EDF5FF; height:20px;}";
            style += ".calender .day li,.calender .date li{ float:left; width:14%; height:20px; line-height:20px; text-align:center}";
            style += ".calender li a { text-decoration:none; font-family:Tahoma; font-size:11px; color:#333}";
            style += ".calender li a:hover { color:#f30; text-decoration:underline}";
            style += ".calender li a.hasArticle {font-weight:bold; color:#f60 !important}";
            style += ".lastMonthDate, .nextMonthDate {color:#bbb;font-size:11px}";
            style += ".selectThisYear a, .selectThisMonth a{text-decoration:none; margin:0 2px; color:#000; font-weight:bold}";
            style += ".calender .LastMonth, .calender .NextMonth{ text-decoration:none; color:#000; font-size:18px; font-weight:bold; line-height:16px;}";
            style += ".calender .LastMonth { float:left;}";
            style += ".calender .NextMonth { float:right;}";
            style += ".calenderBody {clear:both}";
            style += ".calenderTitle {text-align:center;height:20px; line-height:20px; clear:both}";
            style += ".today { background-color:#ffffaa;border:1px solid #f60; padding:2px}";
            style += ".today a { color:#f30; }";
            style += ".calenderBottom {clear:both; border-top:1px solid #ddd; padding: 3px 0; text-align:left}";
            style += ".calenderBottom a {text-decoration:none; margin:2px !important; font-weight:bold; color:#000}";
            style += ".calenderBottom a.closeCalender{float:right}";
            style += ".closeCalenderBox {float:right; border:1px solid #000; background:#fff; font-size:9px; width:11px; height:11px; line-height:11px; text-align:center;overflow:hidden; font-weight:normal !important}";
            style += "</style>";
            var now;
            if (typeof (arguments[0]) == "string") {
                selectDate = arguments[0].split("-");
                var year = selectDate[0];
                var month = parseInt(selectDate[1]) - 1 + "";
                var date = selectDate[2];
                now = new Date(year, month, date);
            } else if (typeof (arguments[0]) == "object") {
                now = arguments[0];
            }
            var lastMonthEndDate = HS_DateAdd("d", "-1", now.getFullYear() + "-" + now.getMonth() + "-01").getDate();
            var lastMonthDate = WeekDay(now.getFullYear() + "-" + now.getMonth() + "-01");
            var thisMonthLastDate = HS_DateAdd("d", "-1", now.getFullYear() + "-" + (parseInt(now.getMonth()) + 1).toString() + "-01");
            var thisMonthEndDate = thisMonthLastDate.getDate();
            var thisMonthEndDay = thisMonthLastDate.getDay();
            var todayObj = new Date();
            today = todayObj.getFullYear() + "-" + todayObj.getMonth() + "-" + todayObj.getDate();
            for (i = 0; i < lastMonthDate; i++) {  // Last Month's Date
                lis = "<li class='lastMonthDate'>" + lastMonthEndDate + "</li>" + lis;
                lastMonthEndDate--;
            }
            for (i = 1; i <= thisMonthEndDate; i++) { // Current Month's Date
                if (today == now.getFullYear() + "-" + now.getMonth() + "-" + i) {
                    var todayString = now.getFullYear() + "-" + (parseInt(now.getMonth()) + 1).toString() + "-" + i;
                    lis += "<li><a href=javascript:void(0) class='today' onclick='_selectThisDay(this)' title='" + now.getFullYear() + "-" + (parseInt(now.getMonth()) + 1) + "-" + i + "'>" + i + "</a></li>";
                } else {
                    lis += "<li><a href=javascript:void(0) onclick='_selectThisDay(this)' title='" + now.getFullYear() + "-" + (parseInt(now.getMonth()) + 1) + "-" + i + "'>" + i + "</a></li>";
                }
            }
            var j = 1;
            for (i = thisMonthEndDay; i < 6; i++) {  // Next Month's Date
                lis += "<li class='nextMonthDate'>" + j + "</li>";
                j++;
            }
            lis += style;
            var CalenderTitle = "<a href='javascript:void(0)' class='NextMonth' onclick=HS_calender(HS_DateAdd('m',1,'" + now.getFullYear() + "-" + now.getMonth() + "-" + now.getDate() + "'),this) title='Next Month'>»</a>";
            CalenderTitle += "<a href='javascript:void(0)' class='LastMonth' onclick=HS_calender(HS_DateAdd('m',-1,'" + now.getFullYear() + "-" + now.getMonth() + "-" + now.getDate() + "'),this) title='Previous Month'>«</a>";
            CalenderTitle += "<span class='selectThisMonth'><a href='javascript:void(0)' onclick='CalenderselectMonth(this)' title='Click here to select other month'>" + (parseInt(now.getMonth()) + 1).toString() + "</a></span>, <span class='selectThisYear'><a href='javascript:void(0)' onclick='CalenderselectYear(this)' title='Click here to select other year' >" + now.getFullYear() + "</a></span>,";
            if (arguments.length > 1) {
                arguments[1].parentNode.parentNode.getElementsByTagName("ul")[1].innerHTML = lis;
                arguments[1].parentNode.innerHTML = CalenderTitle;
            } else {
                var CalenderBox = style + "<div class='calender'><div class='calenderTitle'>" + CalenderTitle + "</div><div class='calenderBody'><ul class='day'><li>dim.</li><li>lun.</li><li>mar.</li><li>mer.</li><li>jeu.</li><li>ven.</li><li>sam.</li></ul><ul class='date' id='thisMonthDate'>" + lis + "</ul></div><div class='calenderBottom'><a href='javascript:void(0)' class='closeCalender' onclick='closeCalender(this)'>×</a><span><span><a href=javascript:void(0) onclick='_selectThisDay(this)' title='" + todayString + "'>Aujourd'hui</a></span></span></div></div>";
                return CalenderBox;
            }
        }
        function _selectThisDay(d) {
            var boxObj = d.parentNode.parentNode.parentNode.parentNode.parentNode;
            boxObj.targetObj.value = d.title;
            boxObj.parentNode.removeChild(boxObj);
			inputSelected = null;
        }
        function closeCalender(d) {
            var boxObj = d.parentNode.parentNode.parentNode;
            boxObj.parentNode.removeChild(boxObj);
			inputSelected = null;
			
        }
        function CalenderselectYear(obj) {
            var opt = "";
            var thisYear = obj.innerHTML;
            for (i = 1970; i <= 2020; i++) {
                if (i == thisYear) {
                    opt += "<option value=" + i + " selected>" + i + "</option>";
                } else {
                    opt += "<option value=" + i + ">" + i + "</option>";
                }
            }
            opt = "<select onblur='selectThisYear(this)' onchange='selectThisYear(this)' style='font-size:11px'>" + opt + "</select>";
            obj.parentNode.innerHTML = opt;
        }
        function selectThisYear(obj) {
            HS_calender(obj.value + "-" + obj.parentNode.parentNode.getElementsByTagName("span")[1].getElementsByTagName("a")[0].innerHTML + "-1", obj.parentNode);
        }
        function CalenderselectMonth(obj) {
            var opt = "";
            var thisMonth = obj.innerHTML;
            for (i = 1; i <= 12; i++) {
                if (i == thisMonth) {
                    opt += "<option value=" + i + " selected>" + i + "</option>";
                } else {
                    opt += "<option value=" + i + ">" + i + "</option>";
                }
            }
            opt = "<select onblur='selectThisMonth(this)' onchange='selectThisMonth(this)' style='font-size:11px'>" + opt + "</select>";
            obj.parentNode.innerHTML = opt;
        }
        function selectThisMonth(obj) {
            HS_calender(obj.parentNode.parentNode.getElementsByTagName("span")[0].getElementsByTagName("a")[0].innerHTML + "-" + obj.value + "-1", obj.parentNode);
        }
        function HS_setDate(inputObj) {
			if(inputObj != inputSelected)
			{
				removeCalendar();
				inputSelected = inputObj;
				var calenderObj = document.createElement("span");
				calenderObj.onclick = stopPropagation;
				calenderObj.innerHTML = HS_calender(new Date());
				calenderObj.style.position = "absolute";
				calenderObj.targetObj = inputObj;
				inputObj.parentNode.insertBefore(calenderObj, inputObj.nextSibling);
			}
            
        }
		
		var inputSelected = null;
		
		function stopPropagation(event)
		{
			event.stopPropagation();
		}
		
		$(document).click(function(event)
		{ 
			removeCalendar(); 
		});
		
		function removeCalendar()
		{
			if(inputSelected != null)
			{
				var calendar = inputSelected.nextSibling;
				inputSelected.parentNode.removeChild(calendar);
				inputSelected = null;
			}
		}
    </script>
     </body>
</asp:Content>
