        <div class="contenu_onglet" id="contenu_onglet_juridiqueagence">
            <div class="contenu_ongletGH"> 
            <fieldset class="fieldset_6champs">
		        <legend><strong>Coord Syndic</strong></legend>
                <table>
                    <tr>
                        <td>Nom</td>
                        <td><asp:TextBox ID="TextBoxNomSyndic" runat="server" width="200px" CssClass=" tb200"  onchange='javascript:checkfield_alpha("balise_spoiler23-5", this.value)'></asp:TextBox></td>
                        <td id="balise_spoiler23-5" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Ville</td>
                        <td><asp:TextBox ID="TextBoxVilleSyndic" runat="server" width="200px" CssClass=" tb200" onblur='viderListeDeroulante(2)' onkeyup='listeVilles(event,2)' onchange='javascript:checkfield_alpha("balise_spoiler24", this.value)'></asp:TextBox></td>
                        <td id="balise_spoiler24" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                        <td id='saisieautoville2'></td>
                    </tr>
                    <tr>
                        <td>Tel</td>
                        <td><asp:TextBox ID="TextBoxTelSyndic" runat="server" CssClass=" tb200"  onchange='javascript:checkfield_alpha_num("balise_spoiler25", this.value)'></asp:TextBox></td>
                        <td id="balise_spoiler25" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Fax</td>
                        <td><asp:TextBox ID="TextBoxFaxSyndic" runat="server" CssClass=" tb200"  onchange='javascript:checkfield_alpha_num("balise_spoiler26", this.value)'></asp:TextBox></td>
                        <td id="balise_spoiler26" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                        <td></td>
                    </tr> 
					
					<tr>
                        <td>Mail</td>
                        <td><asp:TextBox ID="TextBoxMailSyndic" runat="server" CssClass=" tb200"  onchange='javascript:checkfield_mail("balise_spoiler26b", this.value)'></asp:TextBox></td>
                        <td id="balise_spoiler26b" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                        <td></td>
                    </tr> 
					
                </table>
            </fieldset>
            </div>
            <div class="contenu_juridique">  
            <fieldset class="fieldset_6champs">
		        <legend><strong>Consignes de visite</strong></legend>
                <table>
                    <tr>
                        <td>Numéro clés</td>
                        <td><asp:TextBox ID="TextBoxNumeroCles" runat="server" CssClass=" tb200"  onchange='javascript:checkfield_alpha_num("balise_spoiler27", this.value)'></asp:TextBox></td>
                        <td id="balise_spoiler27" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                    </tr>
                    <tr>
                        <td>Texte Syndic</td>
                        <td><asp:TextBox style="font-size:12px" ID="TextBoxTexteSyndic" TextMode="multiline" runat="server" CssClass=" tb200"  onchange='javascript:checkfield_alpha_num("balise_spoiler28", this.value)'></asp:TextBox></td>
                        <td id="balise_spoiler28" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                    </tr>
                
                </table>
            </fieldset>    
            </div>
        </div>    