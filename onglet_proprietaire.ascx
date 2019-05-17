<%@ Control Language="C#" AutoEventWireup="true" CodeFile="onglet_proprietaire.ascx.cs" Inherits="pages_onglet_proprietaire" %>
<% TextBox TextBoxAdresseBien = Parent.FindControl("TextBoxAdresseBien") as TextBox;
   TextBox TextBoxCodePostalBien = Parent.FindControl("TextBoxCodePostalBien") as TextBox;
   TextBox TextBoxVilleBien = Parent.FindControl("TextBoxVilleBien") as TextBox;
%>

<div class="contenu_onglet" id="contenu_onglet_proprietaire">
  <div class="contenu_ongletG">    
            <fieldset class="fieldset_24champs">
		        <legend><strong>Coordonnées</strong></legend>
                <table> 
                <tr>
                        <td>          
                            <asp:RadioButton ID="RadioButtonMadame" runat="server" GroupName="RadioButtonGroup" Text="Mme" />
                            <asp:RadioButton ID="RadioButtonMademoiselle" runat="server" GroupName="RadioButtonGroup" Text="Mlle" />
                            <asp:RadioButton ID="RadioButtonMonsieur" runat="server" GroupName="RadioButtonGroup" Text="Mr" />
                        </td>
                        </tr>
                
                    
                    <tr>
                        <td>Nom</td>   
                        <td><asp:TextBox ID="TextBoxNomProprietaire" runat="server" CssClass=" tb200"  onchange='javascript:checkfield_alpha("balise_spoilerp1", this.value)'></asp:TextBox></td>
                        <td id="balise_spoilerp1" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                    </tr>   
                    <tr>   
                        <td>Prénom</td>                       
                        <td><asp:TextBox ID="TextBoxPrenomProprietaire" runat="server" CssClass=" tb200"  onchange='javascript:checkfield_alpha("balise_spoilerp2", this.value)'></asp:TextBox></td>
                        <td id="balise_spoilerp2" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                    </tr>   
                    <tr>
                        <td>Adresse</td> 
                        <td><asp:TextBox ID="TextBoxAdresseProprietaire" runat="server" CssClass=" tb200"  onchange='javascript:checkfield_alpha_num("balise_spoilerp3", this.value)'></asp:TextBox></td>
                        <td title="Copier/coller les données du mandat"><asp:ImageButton ImageUrl="../img_site/icon_copy.png" OnClientClick="javascript:Copy_loc(event)" runat="server" ID="icon_button_style_loc" /></td>
                        <td id="balise_spoilerp3" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>  
                        <td title="Visualisation google map"><a href='javascript:carte_google()'><img src="../img_site/loupe_googlemap.png" alt=""/></a></td>
                        <script language="javascript">
                            function Copy_loc(e) {

                                var Ad_Bien = document.getElementById('<%=TextBoxAdresseBien.ClientID%>').value;
                                var CodPost_Bien = document.getElementById('<%=TextBoxCodePostalBien.ClientID%>').value;
                                var Ville_Bien = document.getElementById('<%=TextBoxVilleBien.ClientID%>').value;
                                var Pays_Bien = document.getElementById('ctl00_contentPlaceHolder1_TextBoxPaysBien').value;

                                if (Ad_Bien || CodPost_Bien || Ville_Bien != null) {
                                    document.getElementById('<%=TextBoxAdresseProprietaire.ClientID%>').value = Ad_Bien;
                                    document.getElementById('<%=TextBoxCodePostalProprietaire.ClientID%>').value = CodPost_Bien;
                                    document.getElementById('<%=TextBoxVilleProprietaire.ClientID%>').value = Ville_Bien;
                                    document.getElementById('<%=TextBoxPaysProprietaire.ClientID%>').value = Pays_Bien;

                                }

                                e.preventDefault();
                            }
                            function carte_google() {
                                window.open("https://maps.google.fr/maps?hl=fr&authuser=1&q=");
                            }
                        </script>                  
                    </tr>
                    <tr>
                        <td>Code postal</td> 
                        <td><asp:TextBox ID="TextBoxCodePostalProprietaire" runat="server"  CssClass=" tb200" onblur='viderListeDeroulante(3)' onkeyup='listeCP(event,3)' onchange='javascript:checkfield_num("balise_spoilerp4", this.value)'></asp:TextBox> </td>   
                        <td id="balise_spoilerp4" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>                  
                        <td colspan="2" id='saisieautocp3'></td>
                    </tr>
                    <tr> 
                        <td>Ville</td>
                        <td><asp:TextBox ID="TextBoxVilleProprietaire" runat="server" CssClass=" tb200"  onblur='viderListeDeroulante(3)' onkeyup='listeVilles(event,3)'   onchange='javascript:checkfield_alpha("balise_spoilerp5", this.value)'></asp:TextBox></td>
                        <td id="balise_spoilerp5" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td> 
                        <td colspan="2" id='saisieautoville3'></td>
                    </tr>
                    <tr>
                        <td>Pays</td>
                        <td><asp:TextBox ID="TextBoxPaysProprietaire" value="France" runat="server" CssClass=" tb200"  onblur='viderListeDeroulante(3)' onkeyup='listePays(event,3)' onchange='javascript:checkfield_alpha("balise_spoilerp6", this.value)'></asp:TextBox> </td>    
                        <td id="balise_spoilerp6" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>                  
                        <td colspan="2" id='saisieautopays3'></td>
                    </tr> 
                    <tr>
                        <td>Mail</td>
                        <td><asp:TextBox ID="TextBoxAdresseMailProprietaire" runat="server" CssClass=" tb200"  onchange='javascript:checkfield_alpha("balise_spoilerp", this.value)'></asp:TextBox> </td>                 
                    </tr> 
                </table>
                
            </fieldset>
                </div>


            <div class="contenu_onglet_proprietaire">    
            <fieldset class="fieldset_25champs">
                <legend><strong>Téléphones</strong></legend>
                <table>
                    <tr>  
                       <td>Téléphone domicile</td>
                    </tr>   
                    <tr>   
                       <td><asp:TextBox ID="TextBoxTelDomicileProprietaire"  CssClass=" tbsanswidth"  runat="server"  onchange='javascript:checkfield_alpha_num("balise_spoilerp7", this.value)'></asp:TextBox></td>
                       <td id="balise_spoilerp7" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                    </tr>
                    <tr>
                       <td>Téléphone de bureau</td>
                    </tr>   
                    <tr>   
                       <td><asp:TextBox ID="TextBoxTelBureauProprietaire" CssClass=" tbsanswidth"  runat="server"  onchange='javascript:checkfield_alpha_num("balise_spoilerp8", this.value)'></asp:TextBox></td>
                       <td id="balise_spoilerp8" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                    </tr>
                    </table>
                    </fieldset>
                    </div> 
                 </div>  
