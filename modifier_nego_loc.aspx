<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="modifier_nego_loc.aspx.cs" Inherits="pages_ajout_nego" Title="PATRIMONIUM : Mon espace client" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="uc" TagName="ongletProprietaire"  Src="onglet_proprietaire.ascx" %>
<%@ Register TagPrefix="uc" TagName="ongletVendeurPrix" Src="onglet_vendeurprix.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >

    <ajaxtoolkit:ToolkitScriptManager ID="ScriptManager1" runat="server">
   </ajaxtoolkit:ToolkitScriptManager>
    <script language="javascript" type="text/javascript">
        var launch = false;
        function launchModal() {
            launch = true;
        }
        function pageLoad() {
            if (launch) {
                $("#<%=ButtonModale.ClientID %>").click();
            }
        }
        function annulerModale() {
            launch = false;
        }
    </script>

    <asp:Button ID="ButtonModale" runat="server" Text="Button" style="display:none" />

    <asp:panel id="PanelModal" style="display: none" runat="server">
        <div class="HellowWorldPopup">
            <div class="PopupHeader" id="PopupHeader">Attention</div>
            <div class="PopupBody">
                <p>Vous allez supprimer votre mandat.</p>
            </div>
            <div class="ControlsModale">
                <asp:Button ID="btnOkay" runat="server" Text="OK" onclick="mandatChangeConfirme" />
                <input id="btnCancel" type="button" value="Annuler" onclick="annulerModale()" />
	        </div>
        </div>
    </asp:panel>
    
    <!-- Ce morceau contient le javascript de la page -->
	<script>
		var typeID = '#<%=DropDownListTypeBien.ClientID %>';
		var cpID = '#<%=TextBoxCodePostalBien.ClientID %>';
		var villeID = '#<%=TextBoxVilleBien.ClientID %>';
		var paysID = '#<%=TextBoxPaysBien.ClientID %>';
		var categorieBien = '#<%=DropDownListCategorie.ClientID %>';
		var typeBien = '#<%=DropDownListTypeBien.ClientID %>';
		var loyerID = '#ctl00_contentPlaceHolder1_TextBoxLoyerCc';
		var surfaceID = '#ctl00_contentPlaceHolder1_TextBoxSurfaceHabitable';
	</script>
    <script type="text/javascript" src="../JavaScript/ajouterBien.js"></script>
    <script type="text/javascript" src="ajout_modif_nego.js"></script>


        <strong id="error" class="rouge"><asp:Label ID="LabelErrorLogin" runat="server" ForeColor="Red" Visible="true" Width="400px"></asp:Label></strong>

        <div class="boutonMilieu">
		<%  Membre member = (Membre)Session["Membre"];
       String refe;
       refe = Request.QueryString["reference"];
       string requette = "select negociateur from Biens Where ref='" + refe + "'";
       Connexion c = null;
       c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
       c.Open();
       System.Data.DataSet dsnego = c.exeRequette(requette);
       c.Close();
       c = null;

       var test_DropList = DropDownListTypeBien.SelectedValue.ToString();

       string nego = (string)dsnego.Tables[0].Rows[0]["negociateur"];
       if (nego!= null && nego == member.PRENOM + " " + member.NOM || member.STATUT == "ultranego")
       { 
        %>       

	 <asp:Button ID="ButtonFicheNego" runat="server" Text="Fiche Negociateur" OnClick="versFicheNego" CssClass="myButtopetiteajouter" style="text-align:center;height:20px"/>
      &nbsp;
      <asp:Button ID="BoutonAjouter" runat="server" Text="Modifier le bien" OnClientClick="return validerForm2();" OnClick="ButtonModifierBien_Click1" CssClass="myButtopetiteajouter" style="text-align:center;height:20px;margin-top:2px" />  
      &nbsp;
	  <%} %>          
    <asp:Button ID="BoutonRetour" runat="server" Text="Retour" OnClick="verstableaudebord" CssClass="myButtopetiteajouter" style="text-align:center;height:20px"/>
	</div>
    <br />
        
<!-- Pour ce formulaire on utilise un système d'onglet fait avec du javascript -->        
<div class="systeme_onglets">
    <!-- Voici la liste des différents onglets vu en haut de page -->
    <div class="onglets">
        <span class="onglet_0 onglet" id="onglet_mandat" onclick="javascript:change_onglet('mandat');"><strong>Mandat</strong></span>
         <span class="onglet_0 onglet" id="onglet_proprietaire" onclick="javascript:change_onglet('proprietaire');"><strong>Propriétaire</strong></span>
        <span class="onglet_0 onglet" id="onglet_autre" onclick="javascript:change_onglet('autre');"><strong>Localisation & Finance</strong></span> 
        <!-- <span class="onglet_0 onglet" id="onglet_vendeurprix" onclick="javascript:change_onglet('vendeurprix');"><strong>Vendeur & Prix</strong></span>-->
        <!-- span class="onglet_0 onglet" id="onglet_juridiqueagence" onclick="javascript:change_onglet('juridiqueagence');"><strong>Juridique</strong></span> -->
        <span class="onglet_0 onglet" id="onglet_descriptiftechnique" onclick="javascript:change_onglet('descriptiftechnique');"><strong>Descriptif Technique</strong></span>
        <span class="onglet_0 onglet" id="onglet_photos" onclick="javascript:change_onglet('photos');"><strong>Photos & Texte</strong></span>
        <!-- <span class="onglet_0 onglet" id="onglet_valider" onclick="javascript:change_onglet('valider');"><strong>Valider</strong></span> -->   
    </div>
    
    <!-- Voici le contenu des onglets déclarés en haut -->
    <div class="contenu_onglets">
        <!-- ONGLET MANDAT -->
        <div class="contenu_onglet" id="contenu_onglet_mandat">
          <div class="contenu_ongletG"> 
            <fieldset class="fieldset_2champs">
		        <legend><strong>Références</strong>
						<%
							string reference_bien = Request.QueryString["reference"];
							Response.Write(reference_bien);
                            Response.Write(" <a href='./fichedetail1.aspx?ref=" + reference_bien + "'target='_blank'><img src='../img_site/goDetail.png'/></a>");
                        %>
						</legend>
                <table>
                    <tr>
                        <td class="cellulePer">Négociateur <!--AUTOMATIQUE--></td>  
                        <%
                            String requett = "SELECT Biens.negociateur, Biens.ref FROM Biens WHERE ((Biens.ref)='" + reference_bien + "')";
							System.Data.DataSet ds = null;
							c = null;				
							c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
							c.Open();
							ds = c.exeRequette(requett);
							c.Close();
							c = null;
							System.Data.DataRowCollection dr = ds.Tables[0].Rows;
							foreach (System.Data.DataRow ligne in dr)
							{
								TextBoxNegociateur.Text = ligne["negociateur"].ToString();
							}
                        %>
                        <td><asp:TextBox ID="TextBoxNegociateur" class="grey" ReadOnly="true" runat="server" CssClass="tbsanswidth"  ></asp:TextBox></td>  
						<td class="cellulePer">    Date </td>
						<td><%  
							Response.Write("   " + DateTime.Today.ToShortDateString());
                        %>   
						</td>
					</tr>
                    <tr>
                        <td class="cellulePer">Type</td>
                        <td>
                            <asp:DropDownList ID="DropDownListTypeBien" runat="server" CssClass=" tbsanswidth" AutoPostBack="true" OnSelectedIndexChanged="ItemChange">
                            <asp:ListItem>Appartement</asp:ListItem>
                            <asp:ListItem>Maison</asp:ListItem>
                            <asp:ListItem>Immeuble</asp:ListItem>
                            <asp:ListItem>Local</asp:ListItem>
                            <asp:ListItem>Terrain</asp:ListItem>
                            </asp:DropDownList> 
                        </td>
                        <!-- <td id="etat"></td> -->
                        <td>Etat</td>
                        <td>
                            <asp:DropDownList ID="DropDownListEtat" CssClass=" tbsanswidth" runat="server" >
                            </asp:DropDownList>  
                        </td>
                   </tr>
                </table>
            </fieldset>
            
            <fieldset class="fieldset_5champs"  style="height:195px;">
		        <legend><strong>Adresse du bien</strong></legend>
                <table>           
                    <tr>  
                        <td class="cellulePer"> Adresse du bien </td>             
                        <td id="test" ><asp:TextBox ID="TextBoxAdresseBien" ClientIDMode="static" CssClass=" tb200"  runat="server" onchange='javascript:checkfield_alpha_num("balise_spoiler", this.value)' ></asp:TextBox> </td>
                        <td id="balise_spoiler" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td> <!-- Permet d'afficher une croix rouge lorsque le champs ne respecte pas le regex -->
                        <td class="tooltipContainer"><a href='javascript:carte_google()'><img src="../img_site/flat_round/monde.png" width="25px" alt="" /><div class="tooltip2"><span>Emplacement sur GoogleMap</span></div></a></td>
                        <script language="javascript" type="text/javascript">
                            function carte_google() {
                                    window.open("https://maps.google.fr/maps?hl=fr&authuser=1&q=" + document.getElementById('<%=TextBoxAdresseBien.ClientID%>').value + "+" + document.getElementById('<%=TextBoxCodePostalBien.ClientID%>').value + "+" + document.getElementById('<%=TextBoxVilleBien.ClientID%>').value);
                                }
                        </script>
                    </tr>
                    <tr>
                        <td class="cellulePer">Code postal<span class="rouge">*</span></td>
                        <td><asp:TextBox ID="TextBoxCodePostalBien" runat="server" CssClass=" tb200"  onchange='javascript:checkfield_num("balise_spoiler2", this.value)'></asp:TextBox> </td> 
                        <td id="balise_spoiler2" class="balise_spoiler2" > <img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
						<td id='saisieautocp0'></td>
					</tr>
                    <tr>
                        <td class="cellulePer">Ville du bien<span class="rouge">*</span></td>
                        <td><asp:TextBox ID="TextBoxVilleBien" runat="server" CssClass=" tb200"  onchange='javascript:checkfield_alpha("balise_spoiler3", this.value)' ></asp:TextBox></td>
                        <td id="balise_spoiler3" class="balise_spoiler2" > <img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
						<td id='saisieautoville0'></td>
					</tr>
                    <tr>
                        <td class="cellulePer">Pays du bien<span class="rouge">*</span></td>
                        <td><asp:TextBox ID="TextBoxPaysBien" runat="server" CssClass="tbsanswidth" onblur='viderListeDeroulante(0)' onkeyup='listePays(this,0)' onchange='javascript:checkfield_alpha("balise_spoilerPays", this.value)'></asp:TextBox></td>
						<td id="balise_spoilerPays" class="balise_spoiler" > <img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                        <td id='saisieautopays0'></td>
                    </tr>
                    <tr> 
                        <td class="cellulePer">Localisation du bien</td>
                        <td><asp:TextBox ID="TextBoxLocalisationBien" placeholder="Centre-ville, ..." CssClass=" tb200" runat="server"  onchange='javascript:checkfield_alpha_num("balise_spoiler4", this.value)'></asp:TextBox></td>            
                        <td id="balise_spoiler4" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                    </tr>
                    
                </table>
            </fieldset >
            <span class="rouge">*</span> : Champs obligatoires
         </div>
         <div class="contenu_mandatD">    
            <fieldset class="fieldset_8champs"  style="height:294px;">
		        <legend><strong>Info. Mandat</strong></legend>
                        
                <%
                    String refel;
                    refel = Request.QueryString["reference"];
					
					String requettee = "SELECT DISTINCT Biens.idclient, Clients.idclient, Biens.ref, Biens.negociateur FROM Biens LEFT JOIN Clients ON Biens.idclient = Clients.idclient WHERE ((((Biens.ref)='" + refel + "')) AND (((Biens.negociateur)='" + member.PRENOM + " " + member.NOM + "'))) GROUP BY Biens.idclient, Clients.idclient, Biens.ref, Biens.negociateur";
					System.Data.DataSet ds1 = null;
					c = null;
					c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
					c.Open();
					ds1 = c.exeRequette(requettee);
					c.Close();
					c = null;
					System.Data.DataRowCollection dr1 = ds1.Tables[0].Rows;
					foreach (System.Data.DataRow ligne in dr)
					{
					
					if(ligne["negociateur"].ToString() == member.PRENOM + " " + member.NOM)
					{
						// On teste s'il y a un Mandat pour ce bien
						if (TestMandat(refel)) // Si oui, on l'affiche, avec un bouton supprimer
						{
						Response.Write("Mandat : ");
						Response.Write("../Mandats/" + refel + ".pdf"); 
						Response.Write("<br /><strong><a href='../Mandats/" + refel + ".pdf' target='_blank'>Voir mandat&nbsp;&nbsp;&nbsp;</a></strong>");						
				%>
                        <asp:Button ID="SupprimerMandat" runat="server" Text="Supprimer" CommandArgument="M" OnCommand='SupprMandat' CssClass="myButtopetite"/> 
                        <br /> <br />
				<%  	}
						// Sinon, on laisse la possibilité d'en charger une
						else
						{
				%>      Mandat : <asp:FileUpload ID="FileUpload9" runat="server" /><br /><br />
				<%  
						}
					}
					}
				%>
                
                 <table>
                    <tr>
           
                        <td>Type de mandat</td>    
                    <td>
                        <asp:DropDownList ID="DropDownListTypeMandat" CssClass=" tb200" runat="server"  onchange='javascript:checkfield_alpha("balise_spoiler6", this.value)'>
                        </asp:DropDownList>   
                        </td>
                        <td id="balise_spoiler6" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                    </tr>      
                    <tr>  
                        <td>Date des échéances</td>
                        <td><asp:TextBox ID="TextBoxDateEcheance" CssClass=" tb200" runat="server" ></asp:TextBox></td>
                       <asp:CalendarExtender   ID="CalendarExtender1"    TargetControlID="TextBoxDateEcheance"    runat="server" /> 
                    </tr>    
                    
                    <tr>
                        <td>Coup de coeur</td>  
                        <td><asp:CheckBox ID="coupDeCoeur" runat="server"></asp:CheckBox></td> 
                    </tr>
                    
                    <tr>      
                        <td>Prestige</td>    
                        <td><asp:CheckBox ID="prestige" runat="server"></asp:CheckBox></td>
                    </tr>
                                        
                    <tr>      
                        <td>Neuf</td>    
                        <td><asp:CheckBox ID="neuf" runat="server"></asp:CheckBox></td>
                    </tr>

                    <tr>      
                        <td>Disponibilité</td>    
                        <td><asp:TextBox ID="TextBoxDisponibilite" CssClass=" tb200" runat="server" placeholder="Libre | Date de dispo" onchange='javascript:checkfield_alpha_num("balise_spoiler7", this.value)'></asp:TextBox></td> 
                        <td id="balise_spoiler7" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                    </tr>
                    <tr>  
                        <td>Date de libération</td>
                        <td><asp:TextBox ID="TextBoxDateLiberation" CssClass=" tb200" runat="server" ></asp:TextBox></td>
                       <asp:CalendarExtender   ID="CalendarExtender2" TargetControlID="TextBoxDateLiberation"    runat="server" /> 
                         
                   </tr>
                   <!--<tr>      
                        <td>Montant du loyer</td>
                        <td><asp:TextBox ID="TextBoxMontantLoyer" runat="server" Width="150px" placeholder="Loyer présent ou passé" onchange='javascript:checkfield_num("balise_spoiler8", this.value)'></asp:TextBox> </td>  
                        <td id="balise_spoiler8" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>    
                   </tr>-->
                 </table>
            </fieldset>    
         </div>           
        </div>

        <!-- ONGLET PROPRIETAIRE -->    
       <uc:ongletProprietaire id="onglet_Proprietaire" 
        runat="server" 
        MinValue="1" 
        MaxValue="10" />
                 
        <!-- ONGLET LOCALISATION ET FINANCE -->    
        <!--#include file="onglet_localisationfinance.aspx"-->

        <!-- ONGLET VENDEUR ET PRIX -->    
        <uc:ongletVendeurPrix id="onglet_VendeurPrix" 
        runat="server" 
        MinValue="1" 
        MaxValue="10" />

        <!-- ONGLET JURIDIQUE -->
        <!--#include file="onglet_juridique.aspx"-->
        
        
        <!-- ONGLET DESCRIPTIF TECHNIQUE -->
		<!--#include file="onglet_descriptif_technique.aspx"-->

<!-- ******************************************* /Diagnostic de performance énergétique ****************************************************************** -->

         </div>    
        </div>
      <!-- ONGLET VALIDER -->
        <div class="contenu_onglet" id="contenu_onglet_valider">
            <div class="ModifierBien">
                <asp:Button ID="ButtonModifierBien" runat="server" Text="Modifier le bien" OnClick="ButtonModifierBien_Click1" CssClass="myButtopetiteajouter"/>                
        </div>
      
    </div>
    
      
    <!-- ONGLET PHOTOS -->
	<!--#include file="onglet_photo.aspx" -->
        
        <div class="contenu_onglet" id="contenu_onglet_textespublicitaires">
         <div class="contenu_ongletG3">
          
         </div> 
         <div class="contenu_ongletD3">
          <fieldset class="fieldset_8champsplus"> 
                <legend><strong>Texte Publicité</strong></legend>
                    <asp:TextBox ID="TextBoxTextePublicite" runat="server" TextMode="multiline" class="TextePublicite"></asp:TextBox>
          </fieldset>
         </div>
         <div> 
            <fieldset class="fieldset_8champsplus"> 
                <legend><strong>Texte Mailing</strong></legend>
                <asp:TextBox ID="TextBoxTexteMailing" runat="server" TextMode="multiline" class="TexteMailing"></asp:TextBox>
            </fieldset>     
         </div>
        </div>
    </div>  
</div>



<script type="text/javascript">
    //<!--
    // Permet de se retrouver sur l'onglet photos apres avoir supprimé une image
    var url = window.location.href;
    var tmp = new Array();
    tmp = url.split('=');

    if (tmp[2] == "photos")
        var anc_onglet = 'photos';

    else
        var anc_onglet = 'mandat';
            
    change_onglet(anc_onglet);
    //-->
</script>

</asp:Content>

