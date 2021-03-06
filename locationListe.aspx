﻿<%@ Page Title="Liste des locations" Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="locationListe.aspx.cs" Inherits="locationListe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder1" Runat="Server">
<script type="text/javascript" src="../Javascript/venteListe.js"></script>

    <style>
        
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
        
        .mid{margin:auto}
        .gridviewx
        {
            font-size:9pt;
        }
        .m{margin-left:100px}
        .ml{margin-left:20px}
    </style>

    <div class="tamid">
        <asp:Label ID="msg" runat="server" CssClass="rouge"></asp:Label>
    </div>
    <br />
	<div class="Recherche">
		<fieldset class="mid" style="width:90%">
			<legend class="bold">FILTRER LES RÉSULTATS</legend>
			<div class="paramName">
				<br />
			Proposition validée<br />
			location validée <br />
			</div>
			<div class="paramValue">
				<br />
				<asp:DropDownList ID="valideProp" runat="server" CssClass="style2d"> 
					<asp:ListItem Value="2" Text="Tout" />
					<asp:ListItem Value="1" Text="Oui" />
					<asp:ListItem Value="0" Text="Non" />
				</asp:DropDownList><br />

				<asp:DropDownList ID="valideVente" runat="server" CssClass="style2d"> 
					<asp:ListItem Value="2" Text="Tout" />
					<asp:ListItem Value="1" Text="Oui" />
					<asp:ListItem Value="0" Text="Non" />
				</asp:DropDownList>
			</div>

			<div class="paramValue ml bold">
				Date de signature du bail<br />
				<div class="taright">
				 de <asp:TextBox runat="server" ID="TB_DateSignatureMin" CssClass="style2d" placeholder="JJ/MM/AAA"/><br />
				 à <asp:TextBox runat="server" ID="TB_DateSignatureMax" CssClass="style2d" placeholder="JJ/MM/AAA"/>
				</div>
			</div>

			<div class="paramName  ml">
				<br />
			Acquéreur<br />
			Negociateur<br />
			</div>
			<div class="paramValue">
				<br />
				<asp:DropDownList ID="FuAsp_acq" runat="server" CssClass="style2d" style="max-width: 300px;"> 
					<asp:ListItem Value="-1" Text="" />
				</asp:DropDownList><br />

				<asp:DropDownList ID="FuAsp_nego" runat="server" CssClass="style2d"> 
					<asp:ListItem Value="-1" Text="" /> 
				</asp:DropDownList>
			</div>

			<div class=" clear"></div>

			<br/>
			<div class="tamid"><asp:Button ID="buttonFiltrer" class="myButton"  runat="server" OnClick="filtrer" Text="Filtrer" /></div>
		</fieldset>
    </div>
    <div align="right">
		Résultats par page 
        <asp:DropDownList ID="DropDownListPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ItemChange" > 
	        <asp:ListItem Value="10" Text="10" /> 
	        <asp:ListItem Value="20" Text="20" /> 
	        <asp:ListItem Value="30" Text="30" /> 
	        <asp:ListItem Value="50" Text="50" /> 
	        <asp:ListItem Value="100" Text="100" /> 
        </asp:DropDownList>
    </div>

    <div class="tamid"><asp:Label runat="server" ID="gtfo" Visible ="false" Text="Aucun résultat ne correspond à vos critères"></asp:Label></div>
    <div class="gridviewx">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
            AllowPaging="true" DataKeyNames="ID" HorizontalAlign="Center"
         OnPageIndexChanging="PaginateTheData" PagerSettings-Mode="Numeric" 
            OnRowDataBound="ReSelectSelectedRecords" AllowSorting="true" 
            OnSorting="SortRecords" CellPadding="2" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" >
         <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" SortExpression="ID" HeaderStyle-CssClass="EntetAdresse" Visible="true"/>
            <asp:BoundField HeaderText="Date d'ajout" DataField="date_ajout" SortExpression="date_ajout" DataFormatString="{0:d}" HeaderStyle-CssClass="EntetAdresse" />
            <asp:BoundField HeaderText="RefBien" DataField="ref_bien" SortExpression="ref_bien" HeaderStyle-CssClass="EntetAdresse" />
            <asp:BoundField HeaderText="Nego" DataField="prenom_client" SortExpression="prenom_client" HeaderStyle-CssClass="EntetAdresse" />
            <asp:BoundField HeaderText="ACQ" DataField="prenom" SortExpression="prenom" HeaderStyle-CssClass="EntetAdresse" />        
        		
            <asp:BoundField HeaderText="Loueur" DataField="nom vendeur" SortExpression="nom vendeur" HeaderStyle-CssClass="EntetAdresse" />
            <asp:BoundField HeaderText="Prix du loyer" DataField="prix_loyer" SortExpression="prix_loyer" DataFormatString="{0:C0}" HeaderStyle-CssClass="EntetAdresse"> <ItemStyle CssClass="taright"></ItemStyle></asp:BoundField>
            <asp:BoundField HeaderText="Commission" DataField="commission" SortExpression="commission" DataFormatString="{0:C0}" HeaderStyle-CssClass="EntetAdresse"><ItemStyle CssClass="taright"></ItemStyle></asp:BoundField>
                  
            <asp:BoundField HeaderText="Date signature" DataField="date_signature_bail" SortExpression="date_signature_bail" DataFormatString="{0:d}" HeaderStyle-CssClass="EntetAdresse" />
            <asp:BoundField HeaderText="Location validée" DataField="valider_signature" SortExpression="valider_signature" HeaderStyle-CssClass="EntetAdresse" ><ItemStyle CssClass="tamid"></ItemStyle></asp:BoundField>

            <asp:TemplateField HeaderStyle-CssClass="Entet">
                <HeaderTemplate>
                    <asp:Image ID="ImageModifier" ImageUrl="../img_site/calepin3.gif" CssClass="croix_rouge" runat="server" />
                </HeaderTemplate>
                <itemtemplate> 
                    <asp:Label ID="x" runat="server" Text=''></asp:Label>
                </itemtemplate>
            </asp:TemplateField>
			
			<asp:TemplateField HeaderStyle-CssClass="Entet">
                <HeaderTemplate>
                    <asp:Image ID="ImageLoupe" ImageUrl="../img_site/loupe.png" CssClass="croix_rouge" runat="server" />
                </HeaderTemplate>
                <itemtemplate> 
                    <asp:Label ID="Modifier" runat="server" Text=''></asp:Label>
                </itemtemplate>
            </asp:TemplateField>
			
			<asp:TemplateField HeaderStyle-CssClass="Entet">
				<ItemStyle CssClass="tamid"></ItemStyle>
                <HeaderTemplate>
                    Bail
                </HeaderTemplate>
            </asp:TemplateField>
			

			<asp:TemplateField HeaderStyle-CssClass="Entet">
                <HeaderTemplate>
                    <asp:Image ID="ImageTrash" ImageUrl="../img_site/trash.png" CssClass="croix_rouge" runat="server" />
                </HeaderTemplate>
				<ItemTemplate>
                    <asp:ImageButton ID="buttonDelete" runat="server" OnClientClick="return confirmDeleteLocation();" OnClick="deleteLocation" ImageUrl="../img_site/trash.png" CssClass="croix_rouge"/>
					<div class='tooltip'><span>Supprimer la location</span></div>
				</ItemTemplate>
            </asp:TemplateField>
			
            <asp:TemplateField HeaderStyle-CssClass="Entet">
                <HeaderTemplate>
                    <asp:CheckBox ID="CheckBoxSelection" AutoPostBack="true"  OnCheckedChanged="Tout_Selectionner" runat="server" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBoxArchiver" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
         </Columns>    
		 <pagerstyle horizontalalign="Center"/>
         </asp:GridView>
    </div>
    <br/>
    <center>
    <asp:Label runat="server" ID="LabelError" style="color:Red; font-weight:bold" Visible="False"/>
    </center>
    <br />
    <div class="tamid">
      <asp:Button runat="server" ID="buttonValider" class="myButton" OnClick="buttonValiderProp" Text="Valider/Invalider proposition" />&nbsp;&nbsp;
      <asp:Button runat="server" ID="button1" class="myButton"  OnClick="buttonValiderLocation" Text="Valider/Invalider location" />&nbsp;&nbsp;
      <asp:Button runat="server" ID="btnAjouterCommission" class="myButton"  OnClick="directionAjoutCommissionLibre" Text="Ajouter commission libre" />
    </div>
</asp:Content>

