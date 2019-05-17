
        <div class="contenu_onglet" id="contenu_onglet_autre">
            <div class="contenu_ongletG">    
            <fieldset class="fieldset_9champs">
                <legend><strong>Environnement</strong></legend>
                <table>
                    <!--<tr>
                        <td>Référence du propriétaire</td>
                        <td><asp:TextBox ID="TextBoxReferenceProprietaire" runat="server" onchange='javascript:checkfield_alpha_num("balise_spoiler8_1", this.value)'  CssClass=" tbsanswidth"></asp:TextBox> </td>  
                        <td id="balise_spoiler8_1" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>    
                    </tr>-->
                    <tr>
                        <td>Résidence</td>
                        <td><asp:TextBox ID="TextBoxResidence" runat="server" onchange='javascript:checkfield_alpha_num("balise_spoiler8_2", this.value)' CssClass=" tbsanswidth"></asp:TextBox> </td>  
                        <td id="balise_spoiler8_2" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                    </tr>
                    <tr>
                        <td>Proximité</td>
                        <td><asp:DropDownList ID="DropDownListProximite" runat="server" CssClass=" tbsanswidth"></asp:DropDownList></td>  
                    </tr>
                    <tr>
                        <td>Quartier</td>
                        <td><asp:TextBox ID="TextBoxQuartier" runat="server" onchange='javascript:checkfield_alpha_num("balise_spoiler8_3", this.value)' CssClass=" tbsanswidth"></asp:TextBox> </td>  
                        <td id="balise_spoiler8_3" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                    </tr>
                    <tr>
                        <td>Transport</td>
                        <td><asp:DropDownList ID="DropDownListTransport" runat="server" CssClass=" tbsanswidth"></asp:DropDownList></td>
                    </tr>                        
                </table>       
            </fieldset>   
            </div>
            
            <div class="contenu_ongletD">
            <fieldset class="fieldset_9champs">
                <legend><strong>Renseignements financiers</strong></legend>
                <table>
                    <tr>
                        <td>Loyer Hors Charges</td>
                        <td><asp:TextBox ID="TextBoxLoyerHc" runat="server"  CssClass=" tbsanswidth"></asp:TextBox>€
                        </td>
                    </tr>
                    <tr>
                        <td>Loyer Charges Comprises<span class="rouge">*</span></td>
                        <td><asp:TextBox ID="TextBoxLoyerCc"  runat="server"  CssClass=" tbsanswidth"></asp:TextBox>€
                        </td>
                    </tr>
                    <tr>
                        <td>Dépôt de garantie</td>
                        <td><asp:TextBox ID="TextBoxDepotGarantie" runat="server"  CssClass=" tbsanswidth" ></asp:TextBox>€
                        </td>
                    </tr>
                </table>
            </fieldset>
            </div>
                
        </div>