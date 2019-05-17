<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="liste_acquereur.aspx.cs" Inherits="pages_liste_acquereur" Title="PATRIMONIUM : Mon espace client" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- VERIFICATION DES PARAMETRES DE L'AFFICHAGE -->

	
<script>
	var champPays = "#<%=textBoxPays.ClientID%>";
	var champDep = "#<%=textBoxDep.ClientID%>";
	var champVille = "#<%=textBoxVille.ClientID%>";
	var saisie = "#<%=textBoxVille1.ClientID%>";
</script>

<script type="text/javascript" src="../JavaScript/ajax_listeLieu.js"></script>
<script type="text/javascript" src="../JavaScript/ajax_saisieLieu.js"></script>

<script>

	function bouton_annuler()
	{
		$("#<%=radioButtonAcheteur.ClientID%>").prop('checked', true);
		$("#<%=checkBoxMaison.ClientID%>").prop('checked', true);
		$("#<%=checkBoxAppart.ClientID%>").prop('checked', true);
		$("#<%=checkBoxTerrain.ClientID%>").prop('checked', true);
		$("#<%=checkBoxAutre.ClientID%>").prop('checked', true);
		$("#<%=dropDownListType.ClientID%>").val("Tous");
		$("#<%=textBoxDate.ClientID%>").val("");
		$("#<%=textBoxDateFin.ClientID%>").val("");
		$("#<%=TextBoxBudgetMin.ClientID%>").val("");
		$("#<%=TextBoxBudgetMax.ClientID%>").val("");
		$("#<%=radioButtonAcheteur.ClientID%>").prop('checked', true);
		$("#<%=checkBoxPiece1.ClientID%>").prop('checked', true);
		$("#<%=checkBoxPiece2.ClientID%>").prop('checked', true);
		$("#<%=checkBoxPiece3.ClientID%>").prop('checked', true);
		$("#<%=checkBoxPiece4.ClientID%>").prop('checked', true);
		$("#<%=checkBoxPiece5.ClientID%>").prop('checked', true);
		$("#<%=checkBoxChambre1.ClientID%>").prop('checked', true);
		$("#<%=checkBoxChambre2.ClientID%>").prop('checked', true);
		$("#<%=checkBoxChambre3.ClientID%>").prop('checked', true);
		$("#<%=checkBoxChambre4.ClientID%>").prop('checked', true);
		$("#<%=checkBoxChambre5.ClientID%>").prop('checked', true);
		$("#<%=textBoxSurfaceTMin.ClientID%>").val("");
		$("#<%=textBoxSurfaceTMax.ClientID%>").val("");
		$("#<%=textBoxSurfaceMin.ClientID%>").val("");
		$("#<%=textBoxSurfaceMax.ClientID%>").val("");
		$("#<%=textBoxSurfaceSMin.ClientID%>").val("");
		$("#<%=textBoxSurfaceSMax.ClientID%>").val("");
		$("#<%=textBoxFacadeMin.ClientID%>").val("");
		$("#<%=textBoxFacadeMax.ClientID%>").val("");
		$("#<%=textBoxProfondeurMin.ClientID%>").val("");
		$("#<%=textBoxProfondeurMax.ClientID%>").val("");
		$("#<%=checkBoxSous.ClientID%>").prop('checked', false);
		$("#<%=checkBoxPark.ClientID%>").prop('checked', false);
		$("#<%=checkBoxAsc.ClientID%>").prop('checked', false);
		$("#<%=textBoxNom1.ClientID%>").val("");
		$("#<%=textBoxPrenom1.ClientID%>").val("");
		$("#<%=textBoxTel.ClientID%>").val("");
		$("#<%=textBoxPortable.ClientID%>").val("");
		$("#<%=textBoxMail.ClientID%>").val("");
		$("#<%=textBoxVille1.ClientID%>").val("");
		$("#<%=textBoxMotCle1.ClientID%>").val("");
		$("#<%=textBoxMotCle2.ClientID%>").val("");
		$("#<%=textBoxMotCle3.ClientID%>").val("");
		$("#<%=textBoxMotCle4.ClientID%>").val("");
		
	}
</script>
<style type="text/css">
 #donate label input {
    position:absolute;
    top:-20px;
}

#donate .white {
    background-color:#FFFFFF;
    color:#333;
}
</style>
    <%
        // messages de validation (lors de l'ajout d'un acquereur)
        if (Request.Params["valid"] == "oui")
        {
            LabelOK.Visible = true;
            LabelOK.Text = "Félicitations, votre acquereur a été enregistré";
        }
        Membre member = (Membre)Session["Membre"];
        String NomNego = member.PRENOM + " " + member.NOM;
    %>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
    <table class="moncompte">
        <tr>
            <td class="moncompteD1">
                <asp:Label ID="LabelPrenom" Visible="false" runat="server" Text="LabelPrenom"></asp:Label>&nbsp
                <asp:Label ID="LabelNom" Visible="false" runat="server" Text="LabelNom"></asp:Label>
                <asp:Label ID="LabelOK" runat="server" Font-Bold="True" class="rouge" Visible="False"></asp:Label>
                <!-- Message de confirmation d'ajout -->
                <!-- Affichage de l'erreur -->
                    <span style="background-color: Red; float: right;">
                        <asp:Label ID="Label1" runat="server" BorderStyle="None"></asp:Label>
                    </span>
                <div style="width: 350px; text-align: center; margin-top: 5px">
                    <asp:Label ID="LabelErrorLogin" runat="server" Font-Bold="True" ForeColor="#CC3333"
                        Visible="false" Width="350px"></asp:Label>
                </div>
                <div id="donate">
                <label class="white" style="margin-left:7px">
                <asp:RadioButton ID="radioButtonAcheteur" runat="server" GroupName="radioButtonGroup" Font-Bold="False" AutoPostBack="true" OnCheckedChanged="radio_button_checka" CssClass="myButtonblue" Text="Acheteur"/> 
				<asp:RadioButton ID="radioButtonLoueur" runat="server" GroupName="radioButtonGroup" Font-Bold="False" AutoPostBack="true" OnCheckedChanged="radio_button_checkl" CssClass="myButtonred" Text="Loueur" />
                </label>
               </div> 
                <!-- FORMULAIRE DE RECHERCHE -->
                <div class="Recherche">

                    <fieldset id="fieldsetRecherche">
                       <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
                        <ContentTemplate>   
						
						<!-- Type de bien recherche -->
						<fieldset>
							<legend class="bold">Type de bien</legend>
							<div class="tablerecherche1">
								<div class="searchFilterDiv" style="width:44%">
									<div class="paramName">
										
										Type de biens&nbsp;
									</div>
									
									<div class="paramValue">
										
										<div class="listChckBox">
											<div class="paramValue">
												<asp:CheckBox ID="checkBoxMaison" runat="server" AutoPostBack="true" Font-Bold="False" />Maison
												<asp:CheckBox ID="checkBoxAppart" runat="server" AutoPostBack="true" Font-Bold="False" />Appart
												<asp:CheckBox ID="checkBoxTerrain" runat="server" AutoPostBack="true" Font-Bold="False" />Terrain
												<asp:CheckBox ID="checkBoxAutre" runat="server" AutoPostBack="true" Font-Bold="False" />Autre
											</div>
										</div>
									</div>
								</div>
							</div>
							
							<div class="tablerecherche1">
								<div class="searchFilterDiv" style="width:25%">
									<div class="paramName">
										Type d'acquéreur
									</div>
									
									<div class="paramValue">
                                      <!--
                                      Mr S voulait une DDL avec des checkboxes pour pouvoir selectionner plusieurs type.
                                      Vous pouvez utiliser le code suivant pour le faire. Attention à ne pas oublier le JS et les asp:checkbox correspondantes.
                                      J'ai remis ce que j'avais fait dans recherche.aspx, le fonctionnement est le même par rapport à ce qui est demandé.
                                      <div class='cssmenu2' style="margin-left:50px">
                                        <ul>
                                           <li><a href="javascript:void()" style="cursor:default"><span><asp:TextBox ID="TB_type_acquereur"  ReadOnly="true" runat="server" CssClass="RechercheInputII" style='cursor:default; width:100%; color: darkgrey; margin-right:10px;' placeholder="1, 2, 3, 4, 5 pièces ou +"></asp:TextBox></span></a>
                                              <ul>
                                                 <li><a href="javascript:void()"><span><input type="checkbox" onclick="Shield_pieces()" name="CB_Large" id="CB_Large" class="css-checkbox" checked /><label for="CB_Large" class="css-label">Large</label>
                                                    </span></a></li>
                                                    <li><a href="javascript:void()"><span><input type="checkbox" onclick="Shield_pieces()" name="CB_Precis" id="CB_Precis" class="css-checkbox" checked /><label for="CB_Precis" class="css-label">Precis</label>
                                                    </span></a></li>
                                                    <li><a href="javascript:void()"><span><input type="checkbox" onclick="Shield_pieces()" name="CB_Ancien" id="CB_Ancien" class="css-checkbox" checked /><label for="CB_Ancien" class="css-label">Ancien</label>
                                                    </span></a></li>
                                                    <li><a href="javascript:void()"><span><input type="checkbox" onclick="Shield_pieces()" name="CB_Neuf" id="CB_Neuf" class="css-checkbox" checked /><label for="CB_Neuf" class="css-label">Neuf</label>
                                                    </span></a></li>
                                              </ul>
                                           </li>
                                        </ul>
                                        </div-->


										<asp:DropDownList ID="dropDownListType" runat="server" CssClass="RechercheInputII">
											<asp:ListItem>Tous</asp:ListItem>
											<asp:ListItem style="background-color: palegreen">Large</asp:ListItem>
											<asp:ListItem style="background-color: yellowgreen">Précis</asp:ListItem>
											<asp:ListItem style="background-color: burlywood">Ancien</asp:ListItem>
											<asp:ListItem style="background-color: khaki">Neuf</asp:ListItem>
										</asp:DropDownList>
										<br/>
										<asp:DropDownList ID="dropDownListEtat" runat="server" CssClass="RechercheInputII" Visible="false"></asp:DropDownList>&nbsp;
									</div>
								</div>
							</div>
							
							<div class="tablerecherche1">
								<div class="searchFilterDiv">
									<div class="paramName">
										<strong>Date d'ajout</strong>
										de <asp:TextBox ID="textBoxDate" class="RechercheInputII" runat="server" Width="70px" onfocus="HS_setDate(this)" onclick="stopPropagation(event)"></asp:TextBox>
										&nbsp;à&nbsp;<asp:TextBox ID="textBoxDateFin" class="RechercheInputII" runat="server" Width="70px" onfocus="HS_setDate(this)" onclick="stopPropagation(event)"></asp:TextBox>
									</div>
								</div>
							</div>
						</fieldset>
						
						<!-- Caracteristique du bien recherche -->
						<fieldset style="margin-top:5px">
							<legend class="bold">Caratéristiques du bien</legend>
							<table class="tablerechercheTableau" style="line-height:25px;">
								<tr  class="vatop">
									<td class="taright">
										<strong>Budget&nbsp;</strong><br/>
										<%if (checkBoxAppart.Checked || checkBoxMaison.Checked)
										{%>
											<strong>Pieces&nbsp;<br/>
											Chambres&nbsp;</strong>
										<%} %>
									</td>
									
									<td>
										<asp:TextBox ID="TextBoxBudgetMin" runat="server" class="RechercheInputII rechercheTextBoxPetite"></asp:TextBox>
										 à <asp:TextBox ID="TextBoxBudgetMax" runat="server" class="RechercheInputII rechercheTextBoxPetite"></asp:TextBox> &#8364;<br/>
										<%if (checkBoxAppart.Checked || checkBoxMaison.Checked)
										{%>
											<asp:CheckBox ID="checkBoxPiece1" Font-Bold="False" runat="server" />1
											<asp:CheckBox ID="checkBoxPiece2" Font-Bold="False" runat="server" />2
											<asp:CheckBox ID="checkBoxPiece3" Font-Bold="False" runat="server" />3
											<asp:CheckBox ID="checkBoxPiece4" Font-Bold="False" runat="server" />4
											<asp:CheckBox ID="checkBoxPiece5" Font-Bold="False" runat="server" />5+ 
											<br/>
											<asp:CheckBox ID="checkBoxChambre1" Font-Bold="False" runat="server" />1
											<asp:CheckBox ID="checkBoxChambre2" Font-Bold="False" runat="server" />2
											<asp:CheckBox ID="checkBoxChambre3" Font-Bold="False" runat="server" />3
											<asp:CheckBox ID="checkBoxChambre4" Font-Bold="False" runat="server" />4
											<asp:CheckBox ID="checkBoxChambre5" Font-Bold="False" runat="server" />5+
										 <%} %>
									</td>
									<td class="taright">
										<%if (checkBoxMaison.Checked || checkBoxTerrain.Checked)
										{ %>
										<strong>Surface terrain&nbsp;</strong><br />
										<%} %>
										
										<%if (checkBoxAppart.Checked || checkBoxMaison.Checked)
										{%>
										<strong>Surface habitable&nbsp;<br />
										Surface séjour&nbsp;</strong><br />
										<%} %>
									</td>
									<td>
										<%if (checkBoxMaison.Checked || checkBoxTerrain.Checked)
										{ %>                   
										<asp:TextBox ID="textBoxSurfaceTMin" runat="server" class="RechercheInputII rechercheTextBoxSurface"></asp:TextBox> à
										<asp:TextBox ID="textBoxSurfaceTMax" runat="server" class="RechercheInputII rechercheTextBoxSurface"></asp:TextBox> m² <br/>
										<%}%>
										
										<%if (checkBoxAppart.Checked || checkBoxMaison.Checked)
										{%>
											<asp:TextBox ID="textBoxSurfaceMin" runat="server" class="RechercheInputII rechercheTextBoxSurface" Style="text-align: right"></asp:TextBox> à
											<asp:TextBox ID="textBoxSurfaceMax" runat="server" class="RechercheInputII rechercheTextBoxSurface" Style="text-align: right"></asp:TextBox> m²
											<br/>
											<asp:TextBox ID="textBoxSurfaceSMin" runat="server" class="RechercheInputII rechercheTextBoxSurface"></asp:TextBox> à
											<asp:TextBox ID="textBoxSurfaceSMax" runat="server" class="RechercheInputII rechercheTextBoxSurface"></asp:TextBox> m²
										<%} %>
									</td>
									
									<td class="taright">
										<%if (checkBoxTerrain.Checked)
										  { %>
											<strong>Façade&nbsp;<br />
											Profondeur&nbsp;</strong><br />
										<%}%>
									</td>
									
									
									<td>
										<%if (checkBoxTerrain.Checked)
										{ %>
											<asp:TextBox ID="textBoxFacadeMin" runat="server" class="RechercheInputII rechercheTextBoxSurface"></asp:TextBox> à
											<asp:TextBox ID="textBoxFacadeMax" runat="server" class="RechercheInputII rechercheTextBoxSurface"></asp:TextBox>m²
											<br/>
											<asp:TextBox ID="textBoxProfondeurMin" runat="server" class="RechercheInputII rechercheTextBoxSurface"></asp:TextBox> à
											<asp:TextBox ID="textBoxProfondeurMax" runat="server" class="RechercheInputII rechercheTextBoxSurface"></asp:TextBox> m²
										<br />
										<%}%>
									</td>
									
									
									<td class="taright">
										<%if (checkBoxAppart.Checked || checkBoxMaison.Checked)
										{%>
											<strong>Autre&nbsp;</strong>
										<%}%>
									</td>
									
									
									<td>
										<%if (checkBoxAppart.Checked || checkBoxMaison.Checked)
										{%>
											<asp:CheckBox ID="checkBoxSous" Font-Bold="False" runat="server" /> <strong>Sous-sol</strong><br/>
											<asp:CheckBox ID="checkBoxPark" Font-Bold="False" runat="server" /> <strong>Parking/Box</strong><br/>
										<%} %>
										
										<%if (checkBoxAppart.Checked)
										{%>
											<asp:CheckBox ID="checkBoxAsc" Font-Bold="False" runat="server" /><strong>Ascenseur</strong>
										<%} %>
									</td>
								</tr>
							</table>
						</fieldset>
						
						<fieldset style="margin-top:5px;float:right;">
							<legend class="bold">Info acquéreur</legend>
							<table style="line-height:25px;">
								<tr class="vatop">
									<td>
										<strong>Nom
										<br/>Prénom</strong>
									</td>
									
									<td style="padding-right:20px;">
										&nbsp;<asp:TextBox ID="textBoxNom1" runat="server" Width="150px" class="RechercheInputII"></asp:TextBox><br/>
										&nbsp;<asp:TextBox ID="textBoxPrenom1" runat="server" Width="150px" class="RechercheInputII"></asp:TextBox>
									</td>
									
									<td>
										<strong>Téléphone
										<br/>Portable
										<br/>Mail</strong>
									</td>
									
									<td>
										&nbsp;<asp:TextBox ID="textBoxTel" runat="server" Width="150px" class="RechercheInputII"></asp:TextBox><br/>
										&nbsp;<asp:TextBox ID="textBoxPortable" runat="server" Width="150px" class="RechercheInputII"></asp:TextBox><br/>
										&nbsp;<asp:TextBox ID="textBoxMail" runat="server" Width="150px" class="RechercheInputII"></asp:TextBox>
									</td>
								</tr>
							</table>
						</fieldset>

                        </ContentTemplate> 
                        </asp:UpdatePanel> 
						
						<fieldset style="margin-top:5px;min-height:99px">
							<legend class="bold">Lieu recherché (CP, villes)</legend>
							<div class="tablerecherche1">
								<div class="searchFilterDiv" style="width:200px;line-height:24px">
									<div>
										<asp:TextBox ID="textBoxVille1" placeholder="ville, département, pays" class="RechercheInputII" runat="server" onkeyup="RequetteAjax(event,this,0.42)" />
										&nbsp;
										<div class="tooltipContainer">
											<img src="../img_site/boutton_Supprimer.png" class="cursor_link" alt="cancel" style="margin-bottom:-2px" onclick="viderTout();">
											<div class="tooltip2" style="z-index:5;">
												<span>Vider la liste des lieux</span>
											</div>
										</div>
										&nbsp;<span id="saisieauto0" onclick="stopPropag(event);"></span><br/>
										<!--<button class="myButtonClear cursor_link" onclick="viderTout(); return false;" style="margin-top:5px;">Vider</button>-->
										<asp:TextBox ID="textBoxVille" runat="server" class="invisible"/>
										<asp:TextBox ID="textBoxDep"  runat="server" class="invisible"/>
										<asp:TextBox ID="textBoxPays" runat="server" class="invisible"/>
									</div>
								</div>
								
								<div id="listeFiltreLieu" style="float:left;">
								</div>
							</div>
						</fieldset>
						
						<br/><br/>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" >
                        <ContentTemplate>  
                        <table class="tablerechercheTableau" style="line-height:25px;">
                            <tr>
								<td>
									<strong>Mot clé (facultatif)</strong>&nbsp;
                                    <asp:TextBox ID="textBoxMotCle1" class="RechercheInputII" runat="server" Width="80px"></asp:TextBox>&nbsp;
                                    <asp:TextBox ID="textBoxMotCle2" class="RechercheInputII" runat="server" Width="80px"></asp:TextBox>&nbsp;
                                    <asp:TextBox ID="textBoxMotCle3" class="RechercheInputII" runat="server" Width="80px"></asp:TextBox>&nbsp;
                                    <asp:TextBox ID="textBoxMotCle4" class="RechercheInputII" runat="server" Width="80px"></asp:TextBox>
                                    <div class="clear">
                                    </div>
								</td>
                                <td colspan="4" style="text-align: right">
                                    <asp:Button ID="Button1" runat="server" Text="Filtrer" OnClick="Button1_Click_Tab"
                                        TabIndex="1" CssClass="myButton" />
									<button class="myButton" onclick="bouton_annuler();">Annuler</button>
                                    <asp:CheckBox ID="CheckBoxArchive" Font-Bold="False" runat="server" Text="Voir archives"
                                        Visible="true" />
                                </td>
                            </tr>
                        </table>
                        </ContentTemplate> 
                        </asp:UpdatePanel> 
                    </fieldset>
                </div>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                        <ContentTemplate>  

		<div style="float:left;margin-left:5px"><asp:Label ID="LabelbnBiens" runat="server"></asp:Label> résultats</div>
        <div align="right">
			Nombre de résultat par page&nbsp;
            <asp:DropDownList ID="DropDownListPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ItemChange">
                <asp:ListItem Value="10" Text="10" />
                <asp:ListItem Value="20" Text="20" />
                <asp:ListItem Value="30" Text="30" />
                <asp:ListItem Value="50" Text="50" />
                <asp:ListItem Value="100" Text="100" />
            </asp:DropDownList>&nbsp;&nbsp;&nbsp;
        </div>
        <div class="tabacq">
            <asp:GridView ID="GridViewAcq" CssClass="Gridview2" runat="server" AutoGenerateColumns="false"
                AllowPaging="true" DataKeyNames="id_acq" Width="82%" 
                HorizontalAlign="Center" OnPageIndexChanging="PaginateTheData"
                PagerSettings-Mode="Numeric" OnRowDataBound="ReSelectSelectedRecords" AllowSorting="true"
                OnSorting="SortRecords" CellPadding="2">
                <Columns>

                    <%--0--%><asp:BoundField HeaderText="Id" Visible="false" DataField="id_acq" SortExpression="id_acq"
                        HeaderStyle-CssClass="EntetAdresse" />
                    <%--1--%><asp:BoundField HeaderText="Date d'ajout" Visible="true" DataField="date_ajout"
                        SortExpression="date_ajout" DataFormatString="{0:d}" HeaderStyle-CssClass="EntetAdresse" />
                    <%--2--%><asp:BoundField HeaderText="Nom" Visible="true" DataField="nom" SortExpression="nom"
                        DataFormatString="{0:d}" HeaderStyle-CssClass="EntetAdresse" />
                    <%--3--%><asp:BoundField HeaderText="Prenom" Visible="true" DataField="prenom" SortExpression="prenom"
                        HeaderStyle-CssClass="EntetAdresse" />
                    <%--4--%><asp:BoundField HeaderText="Adresse" Visible="true" DataField="adresse"
                        SortExpression="adresse" HeaderStyle-CssClass="EntetAdresse" />
                    <%--5--%><asp:BoundField HeaderText="Adresse Ville" Visible="true" DataField="ville" SortExpression="ville"
                        HeaderStyle-CssClass="EntetAdresse" />
                    <%--6--%><asp:BoundField HeaderText="Code postal" Visible="true" DataField="code_postal"
                        SortExpression="code_postal" HeaderStyle-CssClass="EntetAdresse" />
                    <%--7--%><asp:BoundField HeaderText="Tél." Visible="true" DataField="tel" SortExpression="tel"
                        HeaderStyle-CssClass="EntetAdresse" />
                    <%--8--%><asp:BoundField HeaderText="Port." Visible="false" DataField="portable"
                        SortExpression="portable" HeaderStyle-CssClass="EntetAdresse" />
                    <%--9--%><asp:TemplateField HeaderText="Mail" Visible="true" HeaderStyle-CssClass="EntetAdresse">
                        <ItemTemplate>
                            <asp:Label ID="Mail" runat="server" Text='<%# affiche_Mail(Eval("mail").ToString())%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--10--%><asp:BoundField HeaderText="Lieu Ciblé" Visible="true" DataField="cible"
                        SortExpression="cible" HeaderStyle-CssClass="EntetAdresse" />
                    <%--11--%><asp:BoundField HeaderText="Etat avancement" DataField="etat_Avancement" SortExpression="etat_avancement"
                        HeaderStyle-CssClass="EntetAdresse" Visible="false" />
                    <%--12--%><asp:TemplateField HeaderText="A" HeaderStyle-CssClass="Entet">
                        <ItemTemplate>
                            <asp:Label ID="A" runat="server" Text='<%# affiche_A(Eval("id_acq").ToString())%>' />
                            <div class="tooltip">
                                <span>Appartement</span></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--13--%><asp:TemplateField HeaderText="M" HeaderStyle-CssClass="Entet">
                        <ItemTemplate>
                            <asp:Label ID="M" runat="server" Text='<%# affiche_M(Eval("id_acq").ToString())%>' />
                            <div class="tooltip">
                                <span>Maison</span></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--14--%><asp:TemplateField HeaderText="T" HeaderStyle-CssClass="Entet">
                        <ItemTemplate>
                            <asp:Label ID="T" runat="server" Text='<%# affiche_T(Eval("id_acq").ToString())%>' />
                            <div class="tooltip">
                                <span>Terrain</span></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--15--%><asp:TemplateField HeaderText="D" HeaderStyle-CssClass="Entet">
                        <ItemTemplate>
                            <asp:Label ID="D" runat="server" Text='<%# affiche_D(Eval("id_acq").ToString())%>'></asp:Label>
                            <div class="tooltip">
                                <span>Divers</span></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--16--%><asp:BoundField HeaderText="Nbr. pièces min" DataField="nombre_de_pieces_min"
                        SortExpression="nombre_de_pieces_min" HeaderStyle-CssClass="EntetAdresse" Visible="true" />
                    <%--17--%><asp:BoundField HeaderText="Nbr. pièces max" DataField="nombre_de_pieces_max" SortExpression="nombre_de_pieces_max"
                        HeaderStyle-CssClass="EntetAdresse" Visible="true" />
                    <%--18--%><asp:BoundField HeaderText="Nbr. chambres min" DataField="nombre_de_chambres_min"
                        SortExpression="nombre_de_chambres_min" HeaderStyle-CssClass="EntetAdresse" Visible="false" />
                    <%--19--%><asp:BoundField HeaderText="Nbr. chambres max" DataField="nombre_de_chambres_max"
                        SortExpression="nombre_de_chambres_max" HeaderStyle-CssClass="EntetAdresse" Visible="false" />
                    <%--20--%><asp:BoundField HeaderText="Surf. hab. min" DataField="surface_habitable_min"
                        SortExpression="surface_habitable_min" HeaderStyle-CssClass="EntetAdresse" Visible="true" />
                    <%--21--%><asp:BoundField HeaderText="Surf. hab. max" DataField="surface_habitable_max"
                        SortExpression="surface_habitable_max" HeaderStyle-CssClass="EntetAdresse" Visible="true" />
                    <%--22--%><asp:BoundField HeaderText="Surf. sejour min" DataField="surface_sejour_min" SortExpression="surface_sejour_min"
                        HeaderStyle-CssClass="EntetAdresse" Visible="false" />
                    <%--23--%><asp:BoundField HeaderText="Surf. sejour max" DataField="surface_sejour_max" SortExpression="surface_sejour_max"
                        HeaderStyle-CssClass="EntetAdresse" Visible="false" />
                    <%--24--%><asp:BoundField HeaderText="Surf. terr. min" DataField="surface_terrain_min" SortExpression="surface_terrain_min"
                        HeaderStyle-CssClass="EntetAdresse" />
                    <%--24--%><asp:BoundField HeaderText="Surf. terr. max" DataField="surface_terrain_max" SortExpression="surface_terrain_max"
                        HeaderStyle-CssClass="EntetAdresse" Visible="false" />
                    <%--25--%><asp:BoundField HeaderText="Asc." DataField="ascenseur" SortExpression="ascenseur"
                        HeaderStyle-CssClass="EntetAdresse" Visible="true" />
                    <%--26--%><asp:BoundField HeaderText="Parking/Box" DataField="parking/box" SortExpression="parking/box"
                        HeaderStyle-CssClass="Entet" Visible="false" />
                    <%--27--%><asp:BoundField HeaderText="sous-sol" DataField="sous-sol" SortExpression="sous-sol"
                        HeaderStyle-CssClass="Entet" Visible="false" />
                    <%--28--%><asp:BoundField HeaderText="Facade" DataField="facade" SortExpression="facade" HeaderStyle-CssClass="Entet"
                        Visible="true" />
                    <%--29--%><asp:BoundField HeaderText="Profondeur" DataField="profondeur" SortExpression="profondeur"
                        HeaderStyle-CssClass="Entet" Visible="true" />
                    <%--30--%><asp:BoundField HeaderText="Prix min" DataField="prix_min" SortExpression="prix_min"
                        DataFormatString="{0:C0}" HeaderStyle-CssClass="EntetAdresse" />
                    <%--31--%><asp:BoundField HeaderText="Prix max" DataField="prix_max" SortExpression="prix_max"
                        DataFormatString="{0:C0}" HeaderStyle-CssClass="EntetAdresse" />
                    <%--32--%><asp:BoundField HeaderText="categorie" Visible="true" DataField="categorie" HeaderStyle-CssClass="EntetAdresse" />
                    <%--33--%><asp:TemplateField HeaderStyle-CssClass="Entet">
                        <HeaderTemplate>
                            <asp:Image ID="Image1" ImageUrl="../img_site/calepin3.gif" CssClass="croix_rouge"
                                runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Modifier" runat="server" Text='<%# modifier_acquereur(Eval("id_acq").ToString())%>'></asp:Label>
                            <div class="tooltip">
                                <span>modifier l'acquéreur</span></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--34--%><asp:TemplateField HeaderStyle-CssClass="Entet">
                        <HeaderTemplate>
                            <asp:CheckBox ID="CheckBoxSelection" AutoPostBack="true" OnCheckedChanged="Tout_Selectionner"
                                runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBoxArchiver" runat="server" />
                            <div class="tooltip">
                                <span>Sélection multiple</span></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--35--%><asp:TemplateField HeaderText="Choisir une ligne" HeaderStyle-CssClass="Entet">
                        <ItemTemplate>
                            <input name="MyRadioButton" id="MyRadioButton" type="radio" value='<%# Eval("id_Acq") %>' />
                            <div class="tooltip">
                                <span>Sélection unique</span></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--36--%><asp:TemplateField HeaderText="rapproch." HeaderStyle-CssClass="Entet">
                        <ItemTemplate>
                            <a href="../pages/rapprochement.aspx?idAcq=<%# Eval("id_Acq") %>">
                                <img id="imgphoto" src="../img_site/rapprochement.png" alt="fleche" style="width: 25px" />
                            </a>
                            <div class="tooltip">
                                <span>rapprochement</span></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
				<pagerstyle horizontalalign="Center"/>
            </asp:GridView>
        </div>
        </ContentTemplate>
    <Triggers>
<asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
</Triggers>
</asp:UpdatePanel>
        <div style="color: #31536C">
            &nbsp;<strong>Large:</strong>
            <div style="background-color: PaleGreen; display: inline;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
            &nbsp;&nbsp;<strong>Précis:</strong>
            <div style="background-color: YellowGreen; display: inline;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
            &nbsp;&nbsp;<strong>Ancien:</strong>
            <div style="background-color: BurlyWood; display: inline;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
            &nbsp;&nbsp;<strong>Neuf:</strong>
            <div style="background-color: Khaki; display: inline;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
        </div>
        <div align="right">
            <p>
                <table style="width: 772px">
                    <td>
                        <fieldset>
                            <legend><strong style="color: #31536c">
                                <asp:Image ID="Image3" runat="server" Height="16px" ImageUrl="~/img_site/Carre.jpg"
                                    Width="16px" />
                                &nbsp;Choix multiple</strong></legend>
                            <asp:Button ID="Button3" runat="server" Text="Rapprochement" OnClick="CalculRapprochement"
                                CssClass="myButton" />
                        </fieldset>
                    </td>
                    <td>
                        <fieldset>
                            <legend>
                                <asp:Image ID="Image2" runat="server" Height="16px" ImageUrl="~/img_site/Ronde.jpg"
                                    Width="16px" />
                                <strong style="color: #31536c">&nbsp;Choix unique </legend>
                            <asp:Button ID="Buttonplus" runat="server" OnClick="Ajout_Acq" Text="Ajouter acquéreur"
                                ToolTip="Ajouter un acquereur" CssClass="myButton" Width="177px" />
                            <strong style="color: #31536c">
                                <asp:Button ID="BoutonHistorique" runat="server" CssClass="myButton" OnClick="Voir_Historique"
                                    Text="historique" ToolTip="historique visite" Width="123px" />
                            </strong></strong>
                        </fieldset>
                    </td>
                    <td>
                        <fieldset>
                            <legend><strong style="color: #31536c">Actions </legend>
                            <asp:Button ID="BoutonArchiver" runat="server" OnClick="Archiver_Reactiver" Text="Archiver/Reactiver"
                                CssClass="myButton" />
                            </strong>
                        </fieldset>
                    </td>
                </table>
            </p>
        </div>
	

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
</asp:Content>
