<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="rapprochement.aspx.cs" Inherits="pages_rapprochement" Title="PATRIMONIUM : Calcul de rapprochement pour un acquéreur" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Reference Control="MultiMailRaprochement.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script type="text/javascript">
	//Permet de decaler le span des mails par rapport a sa taille pour eviter que ceux-ci sortent de l'ecran
	$(document).ready(function()
	{
		$('.marqueurMail').each(function()
			{
				$(this).parent().css("margin-top","-5px");
			}
		);
	});
	
	function confirmMail()
	{
		var isMailChecked = false;
		var checkedBoxNumber = 0;
        var copieNego=".";
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
			alert("Veuillez selectioner au moins un bien !");
			return false;
		}
		else
			return confirm('Vous allez proposer ' + checkedBoxNumber + " bien(s) par mail à <%=Label4.Text%> <%=Label3.Text%>.");
	}
</script>


	<div id='my'></div>
    <%Connexion c = new Connexion(); %>
    <table>
        <tr>
            <td class="moncompteacq5">
                <br />
                <asp:Label ID="LabelMail" Visible="false" runat="server" Text="LabelMail" Font-Bold="True" ForeColor="#CC3333" Font-Size="12" ></asp:Label>         
                <br />
               
                    <asp:Label ID="Label3" Font-Bold="True"  Font-Size="14" Visible="true" runat="server" Text="NOM" />
                    <asp:Label ID="Label4" Font-Bold="True"  Font-Size="14" Visible="true" runat="server" Text="Prenom" /><br />
                    
                    <asp:Label ID="Label1" Visible="true" runat="server" Text="adresse" /><br />
                    <asp:Label ID="Label2" Visible="true" runat="server" Text="tel" />
                    <asp:Label ID="Label5" Visible="true" runat="server" Text="email" />
                    
                    <br /><br />
                    <strong>A la recherche de : </strong>

					<br /> <a href="modifier_acquereur.aspx?redirect=rapprochement&reference=<%=Request.QueryString["idAcq"]%>" target="_blank">(Modifier les critères)</a>
					<br/><br/>
				<div style="margin:auto;">
					<asp:Label ID="critere" runat="server" Text=""/>
				</div>

                <br /><span style="font-style:italic;">Sélection parmi les 50 premiers résultats</span>
				
				<asp:Label ID="TryAgain" runat="server"/>
            </td>
        </tr>
    </table>
    <asp:Table ID="TableAcquereur" runat="server" CssClass="moncompteacq5">
        <asp:TableHeaderRow ID="TableAcquereurHeader" CssClass="moncompteacq2, moncompteacq5" runat="server">
			<asp:TableHeaderCell Scope="Column" Text="Date d'ajout" CssClass="moncompteacq7" style="border-style:none" />
            <asp:TableHeaderCell Scope="Column" Text="Reference" CssClass="moncompteacq7" />
            <asp:TableHeaderCell Scope="Column" Text="Etat" CssClass="moncompteacq7bis" />
            <asp:TableHeaderCell Scope="Column" Text="Type<br/>bien" CssClass="moncompteacq7bis" />
            <asp:TableHeaderCell Scope="Column" Text="Surface<br/>habitable" CssClass="moncompteacq7bis" />
            <asp:TableHeaderCell Scope="Column" Text="Surface<br/>terrain" CssClass="moncompteacq7bis" />
            <asp:TableHeaderCell Scope="Column" Text="Nombre<br/> de pieces" CssClass="moncompteacq7" />
            <asp:TableHeaderCell Scope="Column" Text="Ville" CssClass="moncompteacq7" />
            <asp:TableHeaderCell Scope="Column" Text="Négociateur" CssClass="moncompteacq7" />
            <asp:TableHeaderCell Scope="Column" CssClass="moncompteacq7" >
                <asp:Label ID="Label78" runat="server" Text="Label78" />
            </asp:TableHeaderCell>
            <asp:TableHeaderCell Scope="Column" Text="Photos" CssClass="moncompteacq7" />
            <asp:TableHeaderCell Scope="Column" Text="Mandat" CssClass="moncompteacq7" />
            <asp:TableHeaderCell Scope="Column" Text="Contact<br/>vendeur" CssClass="moncompteacq7" />
            <asp:TableHeaderCell Scope="Column" Text="" CssClass="moncompteacq7icon">
				<img class='croix_rouge' src='../img_site/calepin3.gif' alt=''/>
				<div class='tooltip'><span><strong>Modifier l'acquéreur</strong></span></div>	
			</asp:TableHeaderCell>
            <asp:TableHeaderCell Scope="Column" Text="" CssClass="moncompteacq7icon">
				<img class='imgphoto' style="width: 25px" src='../img_site/rapprochement.png' alt=''/>
				<div class='tooltip'><span><strong>Rapprochement</strong></span></div></td>
			</asp:TableHeaderCell>
            <asp:TableHeaderCell Scope="Column" CssClass="moncompteacq7size10" >
                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="AllCheck" /> Envoyer
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <br/>
    <div style="float:right;">
    <asp:Button ID="Button1" runat="server" Text="Envoyer les biens" class="myButton myButtonRight" OnClientClick="return confirmMail();"
        OnClick="contacterAcquereur" />
	<br/><br/><br/>
    <asp:CheckBox ID="CBCopieNego"  runat="server" /><asp:Label runat="server" ID="LBLCopieNego">Recevoir une copie du mail.</asp:Label>  
    
    </div>
    <div >
		<div style="float:left;">
			<a style="text-decoration:underline" href="recherche.aspx">Retour à la recherche<br/>
			<img alt="retour" height="65" src="../img_site/milou.jpg" width="65" style="display:block;" /></a>
		</div>
		<div id='legend' runat='server' style="display:inline-block;margin-left:50px;">
			<div style="float:left">Critères de recherche acquéreur : </div>
				<div style="float:left">
					<div style="display:inline-block;width:20px;background-color:#F4A460; border:1px solid black; margin-left:15px;">&nbsp;</div> : Estimation<br/>
                    <div style="display:inline-block;width:20px;background-color:#F4A490; border:1px solid black; margin-left:15px;">&nbsp;</div> : Pub Locale<br/>
					<div style="display:inline-block;width:20px;background-color:#FFFFFF; border:1px solid black; margin-left:15px;">&nbsp;</div> : Disponible
				</div>
				<div style="float:left">
					<div style="display:inline-block;width:20px;background-color:#FFE4C4; border:1px solid black; margin-left:15px;">&nbsp;</div> : Offre<br/>
					<div style="display:inline-block;width:20px;background-color:#808080; border:1px solid black; margin-left:15px;">&nbsp;</div> : Suspendu
				</div>
				<div style="float:left">
					<div style="display:inline-block;width:20px;background-color:#008000; border:1px solid black; margin-left:15px;">&nbsp;</div> : Retiré<br/>
					<div style="display:inline-block;width:20px;background-color:#FFFF00; border:1px solid black; margin-left:15px;">&nbsp;</div> : Compromis
				</div>
		</div>
		<div style="clear:both"></div>
		
	</div>
</asp:Content>
