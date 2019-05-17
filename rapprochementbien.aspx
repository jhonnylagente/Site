<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="rapprochementbien.aspx.cs" Inherits="pages_rapprochementbien" Title="PATRIMONIUM : Calcul de rapprochement pour un acquéreur" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="uc" TagName="mail" Src="MailRaprochement.ascx" %>
<%@ Reference Control="MailRaprochement.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server"> 
<script>
	//Permet de decaler le span des mails par rapport a sa taille pour eviter que ceux-ci sortent de l'ecran
	$(document).ready(function()
	{
		$('.marqueurMail').each(function()
			{
				$(this).parent().css("margin-left","-"+$(this).width()+"px");
			}
		);
	});
	
	function confirmMail()
	{
		var isMailChecked = false;
		var checkedBoxNumber = 0;
		$( "[type=checkbox]" ).each(function()
			{
				if(this.checked)
				{
					isMailChecked = true;
					checkedBoxNumber++;
				}
			});
		
		if(!isMailChecked)
		{
			alert("Veuillez selectioner au moins une personne !");
			return false;
		}
		else
			return confirm('Vous allez envoyer un mail à ' + checkedBoxNumber + " personne(s)");
	}
</script>
<asp:Label ID="Confirm" runat="server" Text="" CssClass="rouge confirm_message"/>
<table class="moncompteacq" cellspacing="0" cellpadding="0">
		<tr>
			<td class="moncompteacq5" colspan=9>	
			<asp:Label ID="LabelPrenom" visible="false" runat="server" Text="LabelPrenom"/>
            <asp:Label ID="LabelNom" visible="false" runat="server" Text="LabelNom"/>
			<asp:Label ID="LabelStatut" visible="false" runat="server" Text="LabelStatut"/>
			<asp:Label ID="LabelNego" visible="false" runat="server" Text="LabelNego"/>	
            <br />	
			<strong>Caractéristique du bien</strong> (<asp:Label ID="Label12" runat="server" Text="Label12"/>)<br/>
            <asp:Label ID="Label8" visible="false" runat="server" Text="Label8"/>
			<asp:Label ID="Label10" visible="false" runat="server" Text="Label10"/>
            <asp:Label ID="Label11" runat="server" Visible="true" Text="Label"/><br />
            <asp:Label ID="Label13" Visible="true" runat="server" Text="adresse" /><br />
            <asp:Label ID="Label14" Visible="true" runat="server" Text="tel" />
            <asp:Label ID="Label15" Visible="true" runat="server" Text="email" /><br />
			</td>
		</tr>

		<tr class="moncompteacq5" style="vertical-align:top;text-align:left;">
			<td style="width:150px">
				<asp:Label ID="LabelImage" runat="server" />
			</td>
			<td style="width:100px;font-weight:bold;">
				Réference : <br/>
				Disponibilité : <br/>
			</td>
			
			<td style="width:90px">
				<asp:Label ID="Label0" runat="server" Text="Label0"/><br/>
				<asp:Label ID="Label1" runat="server" Text="Label1"/><br/>
				
			</td>
			<td  style="width:50px;font-weight:bold;">Prix :</td>
			<td  style="width:120px"><asp:Label ID="Label9" runat="server" Text="Label9"/>&nbsp;&#8364;</td>
			
			
			
			<td style="width:100px;font-weight:bold;">
				Type de bien : <br/>
				Localisation :
			<td style="width:150px">
				<asp:Label ID="Label2" runat="server" Text="Label2"/><br/>
				<asp:Label ID="Label7" runat="server" Text="Label7"/> (<asp:Label ID="Label6" runat="server" Text="Label6"/>)
				
			</td>
		

			<td style="width:60px;font-weight:bold;">
				Surface :
			</td>
			
			<td style="padding-bottom:5px;">
				<asp:Label ID="Label5" runat="server" Text="Label5"/>&nbsp;pièce(s)<br/>
				<asp:Label ID="Label3bis" runat="server" Text="Label3bis"/>&nbsp;m² (séjour)<br/>
				<asp:Label ID="Label3" runat="server" Text="Label3"/>&nbsp;m² (habitable)<br/>
				<asp:Label ID="Label4" runat="server" Text="Label4"/>&nbsp;m² (terrain)
                 <br /> <br />
			</td>

        
 
       
</table>

		<table class="moncompteacq2, moncompteacq5" style="border-collapse:collapse;">
					<tr>
						<td rowspan=2 class="moncompteacqgauche"><strong>Date d'ajout</strong></td>
						<td rowspan=2 class="moncompteacq6bis"><strong>Nom</strong></td>
						<td rowspan=2 class="moncompteacq6bis"><strong>Tél</strong></td>
						<td rowspan=2 class="moncompteacq6bis"><strong>ville/dep. ciblée</strong></td>
						<td colspan=2 class="moncompteacq6bis"><strong>Nb pièce</strong></td>
						<td colspan=2 class="moncompteacq6bis"><strong>Surf hab</strong></td>
						<td rowspan=2 class="moncompteacq6bis"><strong>Prix min</strong></td>
						<td rowspan=2 class="moncompteacq6"><strong>Prix max</strong></td>
						<td rowspan=2 class="moncompteacq8"><strong>
							<img class='croix_rouge' src='../img_site/calepin3.gif'>
							<div class='tooltip'><span>Modifier l'acquéreur</span></div></strong>
						</td>
						<td rowspan=2 class="moncompteacq8"><img class='imgphoto' style="width: 25px" src='../img_site/rapprochement.png'>
							<div class='tooltip'><span>Rapprochement</span></div></strong></td>
                        <td rowspan=2 class="moncompteacq6">
							<asp:CheckBox ID="CheckBox1" runat="server"  AutoPostBack="True" oncheckedchanged="CheckBox1_CheckedChanged" />
							<strong>Contacter</strong>
						</td>
					</tr>
					<tr>
						<td style="border-left:medium solid #31536C;border-right:medium solid #31536C;border-top:medium solid #31536C;font-weight:bold;">min</td>
						<td style="border-left:medium solid #31536C;border-right:medium solid #31536C;border-top:medium solid #31536C;font-weight:bold;">max</td>
						<td style="border-left:medium solid #31536C;border-right:medium solid #31536C;border-top:medium solid #31536C;font-weight:bold;">min</td>
						<td style="border-left:medium solid #31536C;border-right:medium solid #31536C;border-top:medium solid #31536C;font-weight:bold;">max</td>
					</tr>
		</table>
    <asp:Table ID="TableAcquereur" runat="server" width="100%">
    </asp:Table> 
	<asp:Button ID="Button1" runat="server" Text="Contacter" CssClass="myButton myButtonRight" onclientclick="return confirmMail();" onclick="Button1_Click" />
	<br/>
    
	<div>
		<div style="float:left;">
			<a style="text-decoration:underline" href="recherche.aspx">Retour à la recherche<br/>
			<img alt="retour" height="65" src="../img_site/milou.jpg" width="65" style="display:block;" /></a>
		</div>
		<div style="display:inline-block;margin-left:50px;">
			<div style="float:left">Critères de recherche acquéreur : </div>
				<div style="float:left">
					<div style="display:inline-block;width:20px;border:1px solid black;background-color:PaleGreen;margin-left:15px;">&nbsp;</div> : Large<br/>
					<div style="display:inline-block;width:20px;border:1px solid black;background-color:YellowGreen;margin-left:15px;">&nbsp;</div> : Précis
				</div>
				<div style="float:left">
					<div style="display:inline-block;width:20px;border:1px solid black;background-color:BurlyWood;margin-left:15px;">&nbsp;</div> : Investisseur ancien<br/>
					<div style="display:inline-block;width:20px;border:1px solid black;background-color:Khaki;margin-left:15px;">&nbsp;</div> : Investisseur neuf
				</div>
		</div>
		<div style="clear:both"></div>
		
	</div>
</asp:Content>