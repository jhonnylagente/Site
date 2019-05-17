<%@ Control Language="C#" AutoEventWireup="true" CodeFile="onglet_vendeurprix.ascx.cs" Inherits="pages_onglet_vendeurprix" %>
<% TextBox TextBoxAdresseBien = Parent.FindControl("TextBoxAdresseBien") as TextBox;
   TextBox TextBoxCodePostalBien = Parent.FindControl("TextBoxCodePostalBien") as TextBox;
   TextBox TextBoxVilleBien = Parent.FindControl("TextBoxVilleBien") as TextBox;
   TextBox TextBoxPaysBien = Parent.FindControl("TextBoxPaysBien") as TextBox;
%>
<script>
			function calcul(arg)
			{
				switch(arg)
				{
					case 0 : calculHonoraire();calcPourcentHonoraire();calculPrixNet();break;
					case 1 : calcPourcentHonoraire();calculPrixNet();	break;
					case 2 : calculHonoraire();calculPrixNet();break;
					case 3 : calculPrixVente();calcPourcentHonoraire();break;
				}
			}
			
			function calculPrixNet()
			{
				var prixVente = parseFloat($('#<%=TextBoxPrixVente.ClientID%>').val()) - parseFloat($('#<%=TextBoxHonoraires.ClientID%>').val());
				if(!isNaN(prixVente))
					$('#<%=TextBoxNetVendeur.ClientID%>').val(prixVente);
			}

			function calculPrixVente()
			{
				var prixVente = parseFloat($('#<%=TextBoxNetVendeur.ClientID%>').val()) + parseFloat($('#<%=TextBoxHonoraires.ClientID%>').val());
				if(!isNaN(prixVente))
					$('#<%=TextBoxPrixVente.ClientID%>').val(prixVente);
			}
			
			function calculHonoraire()
			{
				var honoraire = Math.round(parseFloat($('#<%=TextBoxPrixVente.ClientID%>').val()) * parseFloat($('#<%=TextBoxPourcentageVendeur.ClientID%>').val()) / 100);
				if(!isNaN(honoraire))
					$('#<%=TextBoxHonoraires.ClientID%>').val(honoraire);
			}
			
			function calcPourcentHonoraire() {

			    var pourcentage = 100 * parseFloat($('#<%=TextBoxHonoraires.ClientID%>').val()) / parseFloat($('#<%=TextBoxPrixVente.ClientID%>').val());
				if(!isNaN(pourcentage))
				{
					pourcentage = Math.round(pourcentage*100)/100;
					$('#<%=TextBoxPourcentageVendeur.ClientID%>').val(pourcentage);
				}
			}
</script>
        <div class="contenu_onglet" id="contenu_onglet_vendeurprix">
           <div class="contenu_ongletG">    
            <fieldset class="fieldset_8champsplus" style="height:230px;">
		        <legend><strong>Coordonnées Vendeur</strong></legend>
                <table>           
                    <tr>
						<td style="width:100px">Civilité</td>
                        <td>          
                            <asp:RadioButton ID="RadioButtonMme" runat="server" GroupName="RadioButtonGroup" Text="Mme" />
                            <asp:RadioButton ID="RadioButtonMlle" runat="server" GroupName="RadioButtonGroup" Text="Mlle" />
                            <asp:RadioButton ID="RadioButtonMr" runat="server" GroupName="RadioButtonGroup" Text="Mr" />
                        </td>
                    </tr>
                    <tr>
                        <td>Nom </td>   
                        <td><asp:TextBox ID="TextBoxNomVendeur" runat="server"  CssClass=" tb200"  onchange='javascript:checkfield_alpha("balise_spoiler9", this.value)'></asp:TextBox></td>
                        <td id="balise_spoiler9" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                    </tr>   
                    <tr>   
                        <td>Prénom </td>                       
                        <td><asp:TextBox ID="TextBoxPrenomVendeur" runat="server"  CssClass=" tb200"  onchange='javascript:checkfield_alpha("balise_spoiler10", this.value)'></asp:TextBox></td>
                        <td id="balise_spoiler10" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                    </tr>   
                    <tr>
                        <td>Adresse </td> 
                        <td><asp:TextBox ID="TextBoxAdresseVendeur" runat="server" text=""  CssClass=" tb200" onchange='javascript:checkfield_alpha_num("balise_spoiler11", this.value)' /></td>
                        <td title="Copier/coller les données du mandat"><asp:ImageButton ImageUrl="../img_site/icon_copy.png" OnClientClick="javascript:Copy(event)" runat="server" ID="icon_button_style" /></td>
                        <td title="Visualisation google map"><a href='javascript:carte_google()'><img src="../img_site/flat_round/monde.png" width="25px" alt="" /></a></td>
                        <script language="javascript">
                            function Copy(e) {

                                var Ad_Bien = document.getElementById('<%=TextBoxAdresseBien.ClientID%>').value;
                                var CodPost_Bien = document.getElementById('<%=TextBoxCodePostalBien.ClientID%>').value;
                                var Ville_Bien = document.getElementById('<%=TextBoxVilleBien.ClientID%>').value;
                                var Pays_Bien = document.getElementById('<%=TextBoxPaysBien.ClientID%>').value;

                                if (Ad_Bien || CodPost_Bien || Ville_Bien != null) {
                                    document.getElementById('<%=TextBoxAdresseVendeur.ClientID%>').value = Ad_Bien;
                                    document.getElementById('<%=TextBoxCodePostalVendeur.ClientID%>').value = CodPost_Bien;
                                    document.getElementById('<%=TextBoxVilleVendeur.ClientID%>').value = Ville_Bien;
                                    document.getElementById('<%=TextBoxPaysVendeur.ClientID%>').value = Pays_Bien;

                                }

                                e.preventDefault();
                            }

                            function carte_google() {
                                window.open("https://maps.google.fr/maps?hl=fr&authuser=1&q=" + document.getElementById('<%=TextBoxAdresseBien.ClientID%>').value + "+" + document.getElementById('<%=TextBoxCodePostalBien.ClientID%>').value + "+" + document.getElementById('<%=TextBoxVilleBien.ClientID%>').value);
                            }
                        </script>
                        <td id="balise_spoiler11" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                                           
                    </tr>
                    <tr> 
                        <td>Ville </td>
                        <td><asp:TextBox ID="TextBoxVilleVendeur" runat="server"  CssClass=" tb200"  onblur='viderListeDeroulante(1)' onkeyup='listeVilles(event,1)'  onchange='javascript:checkfield_alpha("balise_spoiler13", this.value)'></asp:TextBox></td>
                        <td><img id="balise_spoiler13" class="croix_rouge balise_spoiler" src="../img_site/croix_rouge.png" /></td> 
                        <td>Code postal</td> 
                        <td><asp:TextBox ID="TextBoxCodePostalVendeur" runat="server" CssClass=" tb200" style="width:35px"  onblur='viderListeDeroulante(1)' onkeyup='listeCP(event,1)' onchange='javascript:checkfield_num("balise_spoiler12", this.value)'></asp:TextBox> </td>   
                        <td><img id="balise_spoiler12" class="croix_rouge balise_spoiler" src="../img_site/croix_rouge.png" /></td>                  
                        <td id='saisieautocp1'></td>
						<td id='saisieautoville1'></td>
                    </tr>
                    <tr>
                        <td>Pays </td>
                        <td><asp:TextBox ID="TextBoxPaysVendeur" value="France" runat="server"  CssClass=" tb200"  onblur='viderListeDeroulante(1)' onkeyup='listePays(event,1)' onchange='javascript:checkfield_alpha("balise_spoiler14", this.value)'></asp:TextBox> </td>    
                        <td id="balise_spoiler14" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>                  
                        <td colspan="2" id='saisieautopays1'></td>
                    </tr> 
                </table>
            </fieldset>
            
           <fieldset class="fieldsetchamps">
		        <legend><strong>Renseignements Financiers</strong></legend>
                <table style="width:100%">
                    <tr>
                        <td>Prix de vente<span class="rouge">*</span></td>
                        <td><asp:TextBox ID="TextBoxPrixVente" runat="server" CssClass="tbsanswidth" style="width:100px" onchange='javascript:calcul(0);checkfield_num("balise_spoiler15", this.value);'></asp:TextBox>€
                        <span id="balise_spoiler15" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                        <td>Prix estimé</td>
                        <td><asp:TextBox ID="TextBoxPrixEstime" onchange='checkfield_num("balise_spoiler16tier", this.value);' runat="server" style="width:100px" CssClass=" tbsanswidth" ></asp:TextBox>€
							<span id="balise_spoiler16tier" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                    </tr>
                    <tr>
                        <td>Honoraires</td>
                        <td><asp:TextBox ID="TextBoxHonoraires"  runat="server" CssClass=" tbsanswidth" style="width:100px" onchange='calcul(1);checkfield_num("balise_spoiler16bis", this.value);'></asp:TextBox>€
						<span id="balise_spoiler16bis" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                        <td>Pourcentage</td>
						<td><asp:TextBox ID="TextBoxPourcentageVendeur" runat="server" CssClass="tbsanswidth" style="width:32px;"  onchange='calcul(2);checkfield_num("balise_spoiler16-5", this.value);' class="cellulePetite"></asp:TextBox> %
                        <span id="balise_spoiler16-5" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                    </tr>
                    <tr>
                        <td>Net vendeur</td>
                        <td colspan="3"><asp:TextBox ID="TextBoxNetVendeur" runat="server" CssClass=" tbsanswidth" style="width:100px" onchange='calcul(3);checkfield_num("balise_spoiler16", this.value);'></asp:TextBox>€
                        <span colspan=2 id="balise_spoiler16" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                    </tr>
				
                </table>
            </fieldset>
           </div>
           
            <!-- <h1> Origine Vendeur</h1> -->
           
           <div class="contenu_vendeurprix" style="height:445px;">    
            <fieldset class="fieldset_4champs">
                <legend><strong>Téléphones et notes</strong></legend>
                <table>
                    <tr>  
                       <td>Tél. domicile </td>
					   <td><asp:TextBox ID="TextBoxTelDomicileVendeur" CssClass=" tbsanswidth"  runat="server"  onchange='javascript:checkfield_alpha_num("balise_spoiler17", this.value)'></asp:TextBox></td>
                       <td id="balise_spoiler17" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                       
                    </tr>   
                    <tr>   
                       <td>Tél. bureau </td>
						<td><asp:TextBox ID="TextBoxTelBureauVendeur" CssClass=" tbsanswidth"  runat="server"  onchange='javascript:checkfield_alpha_num("balise_spoiler18", this.value)'></asp:TextBox></td>
                       <td id="balise_spoiler18" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
					
					</tr>
                    <tr>
                        <td>Mail </td>
						<td><asp:TextBox ID="TextBoxAdresseMailVendeur" runat="server" CssClass=" tb200"  onchange='javascript:checkfield_mail("balise_spoiler24", this.value)'></asp:TextBox> </td>                 
                        <td id="balise_spoiler24" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                    </tr>
           
                </table>
            </fieldset>
           
            <fieldset class="fieldset_4champs"><br/><br/>
                <legend><br/><strong>Impots et charges</strong></legend>
                <table>  
                   <tr>
                       <td>Prix des travaux éventuels</td>
                       <td><asp:TextBox ID="TextBoxPrixTravaux" runat="server" CssClass=" tb80"   onchange='javascript:checkfield_num("balise_spoiler20", this.value)'></asp:TextBox>€</td>
                       <td id="balise_spoiler20" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                   
                       <td>Charges</td>
                       <td><asp:TextBox ID="TextBoxCharges" runat="server" CssClass=" tb80"  onchange='javascript:checkfield_num("balise_spoiler23", this.value)'></asp:TextBox>€</td>
                       <td id="balise_spoiler23" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                   </tr>
                   <tr>
                       <td>Taxe foncière</td>
                       <td><asp:TextBox ID="TextBoxTaxeFonciere" runat="server" CssClass=" tb80"   onchange='javascript:checkfield_num("balise_spoiler21", this.value)'></asp:TextBox>€</td>
                       <td id="balise_spoiler21" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                   
                       <td>Taxe d'habitation</td>
                       <td><asp:TextBox ID="TextBoxTaxeHabitation" runat="server" CssClass=" tb80"  onchange='javascript:checkfield_num("balise_spoiler22", this.value)'></asp:TextBox>€</td>
                       <td id="balise_spoiler22" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                   </tr>
                 </table>  
            </fieldset>
           </div>
       </div> 