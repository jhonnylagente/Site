        <!-- ******************************************* Descriptif technique ******************************************************************************** -->

<!-- ******************************************* Caractéristiques principales ************************************************************************ -->

        <div class="contenu_onglet" id="contenu_onglet_descriptiftechnique">
          <div class="contenu_ongletG">

<!-- ******************************************* Affichage pour Maison/Appartement/Terrain *********************************************************** -->

            <%
            if (test_DropList == "Maison" || test_DropList == "Appartement" || test_DropList == "Terrain" || test_DropList == "Immeuble" || test_DropList == "Local")
               { %>
          <fieldset class="fieldset_10champs" id="fieldset_CaracPrincip">
                <legend><strong>Caractéristique principales</strong></legend>    
                <table>
                    <tr id="categorie" runat="server">
                        <td>Catégorie</td>
                        <td><asp:DropDownList ID="DropDownListCategorie" CssClass="tbsanswidth" runat="server">
                            <asp:ListItem></asp:ListItem>
                            </asp:DropDownList></td> 
                    </tr>
                    <% 
                        if (test_DropList == "Maison" || test_DropList == "Appartement")
                { %>
                    <tr id="nombre_pieces">
                        <td >Nb de pièces</td>
                        <td ><asp:TextBox ID="TextBoxNombrePieces" runat="server" class="cellulePetite" CssClass=" tb40" onchange='javascript:checkfield_num("balise_spoiler28-5", this.value)'></asp:TextBox>
						<span id="balise_spoiler28-5" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                        <td id="nombre_chambres">Nb de chambres</td>
                        <td><asp:TextBox ID="TextBoxNombreChambre" runat="server" class="cellulePetite" CssClass=" tb40" onchange='javascript:checkfield_num("balise_spoiler29", this.value)'></asp:TextBox>
						<span  id="balise_spoiler29" class="balise_spoiler"><img  class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                    </tr>
                    <%} %>
                    <tr id="murs_mitoyens">
                         <td>Nb de murs mitoyens</td>
                         <td><asp:TextBox ID="TextBoxNombreMursMitoyens" class="cellulePetite"  CssClass=" tb40" runat="server" onchange='javascript:checkfield_num("balise_spoiler30", this.value)'></asp:TextBox>
						 <span  id="balise_spoiler30" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                    </tr>
                    
                    <tr id="surface_habitable">
                    <%if (test_DropList == "Maison" || test_DropList == "Appartement" || test_DropList == "Immeuble")
                      { %>
                        <td>Surface habitable<span class="rouge">*</span></td>
                        <td><asp:TextBox ID="TextBoxSurfaceHabitable" runat="server"  CssClass=" tb40" onchange='javascript:checkfield_num("balise_spoiler31", this.value)'></asp:TextBox>
						<span id="balise_spoiler31" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                    <%} %>
                    <% if (test_DropList == "Maison" || test_DropList == "Appartement" || test_DropList == "Immeuble" || test_DropList == "Local")
                       { %>
                    
                        <td id="surface_carrez">Surface carrez</td>
                        <td><asp:TextBox ID="TextBoxSurfaceCarrez" runat="server" CssClass=" tb40" onchange='javascript:checkfield_num("balise_spoiler32", this.value)'></asp:TextBox>
                        <span id="balise_spoiler32" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                    <%} %>
                    </tr>
                    
                    <%if (test_DropList == "Maison" || test_DropList == "Appartement")
                      { %>
                    <tr id="surface_sejour">
                        <td>Surface séjour</td>
                        <td><asp:TextBox ID="TextBoxSurfaceSejour" runat="server" CssClass=" tb40" onchange='javascript:checkfield_num("balise_spoiler33", this.value)'></asp:TextBox>
                        <span id="balise_spoiler33" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                    
                        <td id="exposition_sejour">Exposition séjour</td>
                        <td><asp:TextBox ID="TextBoxExpositionSejour" runat="server" CssClass=" tb40" onchange='javascript:checkfield_alpha_num("balise_spoiler34", this.value)'></asp:TextBox>
                        <span id="balise_spoiler34" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                    </tr>
                    <%} %>
                    <% 
                if (test_DropList == "Maison" || test_DropList == "Terrain" || test_DropList=="Immeuble" || test_DropList == "Local")
                { %>
                    <tr id="surface_terrain">
                        <td>Surface terrain</td>
                        <td><asp:TextBox ID="TextBoxSurfaceTerrain" runat="server" CssClass=" tb40" onchange='javascript:checkfield_num("balise_spoiler35", this.value)'></asp:TextBox>
                        <span id="balise_spoiler35" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                    </tr>
                    <%} %>
                    <%if (test_DropList == "Maison" || test_DropList == "Appartement" || test_DropList=="Immeuble")
                      { %>
                    <tr id="etage">
                        <td>Etage</td>
                        <td><asp:TextBox ID="TextBoxEtage" runat="server" placeHolder="0=RdC" CssClass=" tb40"  onchange='javascript:checkfield_num("balise_spoiler36", this.value)'></asp:TextBox>
                        <span id="balise_spoiler36" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                    
                        <td id="nombre_etages">Nb étages</td>
                        <td><asp:TextBox ID="TextBoxNombreEtage" runat="server" class="cellulePetite" CssClass=" tb40"  onchange='javascript:checkfield_num("balise_spoiler37", this.value)'></asp:TextBox>
						<span id="balise_spoiler37" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                    </tr>
                    <%}%>
                   <!-- <tr id="code_etage">
                        <td>Code étage</td>
                        <td><asp:TextBox ID="TextBoxCodeEtage" runat="server" Width="150px" onchange='javascript:checkfield_alpha_num("balise_spoiler38", this.value)'></asp:TextBox></td>
                        <td id="balise_spoiler38" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                    </tr>-->
              
                <%if (test_DropList == "Terrain")
                  { %>
                    <tr id="facade_terrain">
                        <td>Façade terrain</td> 
                        <td><asp:TextBox ID="TextBoxFacadeTerrain" runat="server" Width="150px" CssClass=" tb40" onchange='javascript:checkfield_num("balise_spoiler39", this.value)'></asp:TextBox>
                        <span id="balise_spoiler39" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                    </tr>
                    <%} %>
                    <%if (test_DropList == "Terrain")
                      { %>
                    <tr id="profondeur_terrain">
                        <td>Profondeur du terrain</td> 
                        <td><asp:TextBox ID="TextBoxProfondeurTerrain" runat="server" Width="150px" CssClass=" tb40" onchange='javascript:checkfield_num("balise_spoiler40", this.value)'></asp:TextBox>
                        <span id="balise_spoiler340" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                    </tr>
                    <%} %>
                    <%if (test_DropList == "Terrain")
                      { %>
                    <tr id="cos_terrain">
                        <td>Cos du terrain</td> 
                        <td><asp:TextBox ID="TextBoxCosTerrain" runat="server" Width="150px" CssClass=" tb40" onchange='javascript:checkfield_num("balise_spoiler41", this.value)'></asp:TextBox>
                        <span id="balise_spoiler41" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                    </tr>
                    <%} %>
                    <%if (test_DropList == "Terrain")
                      { %>
                    <tr id="shon_terrain">
                        <td>Shon du terrain</td>
                        <td><asp:TextBox ID="TextBoxShonTerrain" runat="server" Width="150px" CssClass=" tb40" onchange='javascript:checkfield_num("balise_spoiler42", this.value)'></asp:TextBox>
                        <span id="balise_spoiler42" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                    </tr>
                    <%} %>           
            
                </table>
          </fieldset>
          <%} %>

<!-- ******************************************* /Caractéristiques principales ************************************************************************ -->

<!-- ******************************************* Information complémentaires ************************************************************************** -->

<!-- ******************************************* Affichage pour Maison/Appartement/Terrain ************************************************************ -->

           <%if (test_DropList == "Maison" || test_DropList == "Terrain" || test_DropList == "Appartement")
                  { %>
          <fieldset class="fieldset_6champs" id="fieldset_InfoCompl">
                <legend><strong>Informations complémentaires</strong></legend>
                <table>
                <%if (test_DropList == "Maison" || test_DropList == "Appartement")
                  { %>
                    <tr id="annee_construction">
                        <td>Année de construction</td>
                        <td><asp:TextBox ID="TextBoxAnneeConstruction" runat="server" CssClass=" tb80"  onchange='javascript:checkfield_num("balise_spoiler43", this.value)'></asp:TextBox>
                        <span id="balise_spoiler43" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                    
                        <td id="meuble">
                        <asp:CheckBox ID="CheckBoxMeuble" runat="server" Text="Meublé" />
                        </td>
                    </tr>
                    <%} %>
                    <%if (test_DropList == "Maison" || test_DropList == "Appartement")
                      { %>
                    <tr id="type_cuisine">
                        <td>Type de cuisine</td>
                        <td>
                            <asp:DropDownList ID="DropDownListTypeCuisine" CssClass=" tb80" runat="server" >
                            <asp:ListItem></asp:ListItem>
                           
                            </asp:DropDownList>     
                        </td>
                        
                    </tr>
                    <%} %>
                    <%if (test_DropList == "Maison" || test_DropList == "Appartement")
                  { %>
                    <tr id="type_chauffage">
                        <td>Type de chauffage</td>
                        <td>
                        <asp:DropDownList ID="DropDownListTypeChauffage" CssClass=" tb80" runat="server" >
                        <asp:ListItem></asp:ListItem>
                             </asp:DropDownList>   </td>
                   
                        <td id="nature_chauffage">Nature du chauffage</td>
                        <td> 
                            <asp:DropDownList ID="DropDownListNatureChauffage" CssClass=" tb80" runat="server" >
                            <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>  </td>
                    </tr>
                    <%} %>
                    <%if (test_DropList == "Maison" || test_DropList == "Appartement")
                  { %>
                    <tr id="type_sous_sol">
                        <td>Type de sous-sol</td>
                       
                        <td><asp:DropDownList  ID="DropDownListTypeSousSol" CssClass=" tb200" runat="server" Width="158px">
                         <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>  </td>
                    </tr>
                    <%} %>
                    <%if (test_DropList == "Terrain")
                      { %>     
                    <tr>
                        <td id="eau"><asp:CheckBox ID="CheckBoxEau" runat="server"  Text="Eau" Checked="True" /></td>
                    </tr>
                    <%} %>
                    <%if (test_DropList == "Terrain")
                      { %>
                    <tr>
                        <td id="gaz"><asp:CheckBox ID="CheckBoxGaz" runat="server"  Text="Gaz" Checked="True" /></td>
                    </tr>
                    <%} %>
                    <%if (test_DropList == "Terrain")
                      { %>
                    <tr id="electricite">
                        <td><asp:CheckBox ID="CheckBoxElectricite" runat="server" Text="Electricite" Checked="True" /></td>
                    </tr>
                    <%} %>
                    <%if (test_DropList == "Terrain")
                      { %>
                    <tr id="tout_a_legout">
                        <td><asp:CheckBox ID="CheckBoxToutaLegout" runat="server" Text="Tout à l'égout" Checked="True" /></td>
                    </tr>
                    <%} %> 
                  <!--  <%if (test_DropList == "Terrain")
                      { %>                   
                    <tr id="lotissement">
                        <td><asp:CheckBox ID="CheckBoxLotissement" runat="server" Text="Lotissement" /></td>
                    </tr>
                    <%} %>
                    <%if (test_DropList == "Terrain")
                      { %>
                    <tr id="alignement">
                        <td><asp:CheckBox ID="CheckBoxAlignement" runat="server" Text="Alignement" /></td>
                    </tr>
                    <%} %>-->
                    <%if (test_DropList == "Terrain")
                      { %>
                    <tr id="numero_lotissement" onchange='javascript:checkfield_num("balise_spoiler51", this.value)'>
                        <td>Numéro du lotissement </td>
                        <td><asp:TextBox ID="TextBoxNumeroLotissement" runat="server" CssClass=" tb40" Width="150px"></asp:TextBox></td>
                    </tr>
                    <%} %>
                </table>
                
          </fieldset>
          <%} %>

          </div>  
                
<!-- ******************************************* /Information complémentaires ************************************************************************** -->

<!-- ******************************************* Disposition intérieure ******************************************************************************** -->

<!-- ******************************************* Affichage pour Maison/Appartement ********************************************************************* -->
        
          <div class="contenu_DescriptifTechnique">
          <%if (test_DropList == "Maison" || test_DropList == "Appartement")
                            { %>
            <fieldset class="fieldset_12champs" id="fieldset_DispoInt">
              
                <legend><strong>Disposition intérieure</strong></legend>    
				<%if (test_DropList == "Appartement")
				{ %>
                        <span id="ascenseur"><asp:CheckBox ID="CheckBoxAscenseur" runat="server"  Text="Ascenseur" /></span>
                        <span id="balcon" style="margin-left:10px"><asp:CheckBox ID="CheckBoxBalcon" runat="server"  Text="Balcon" /></span>
                        <%} %>
                        <%if (test_DropList == "Maison" || test_DropList == "Appartement")
                            { %>
                        <span id="terrasse" style="margin-left:10px"><asp:CheckBox ID="CheckBoxTerrasse" runat="server" Text="Terrasse" /></span>
                <%} %>
                <table>
                    <tr id="nombre_wc">
                        <td >Nb de wc</td>
                        <td ><asp:TextBox ID="TextBoxNombreWc" runat="server" class="cellulePetite" CssClass=" tb40" onchange='javascript:checkfield_num("balise_spoiler44", this.value)'></asp:TextBox>
                        <span id="balise_spoiler44" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                    </tr>
                    <tr id="nombre_salles_bain">
                        <td>Nb de salles de bain</td>
                        <td><asp:TextBox ID="TextBoxNombreSallesBain" runat="server" class="cellulePetite" CssClass=" tb40"  onchange='javascript:checkfield_num("balise_spoiler45", this.value)'></asp:TextBox>
                        <span id="balise_spoiler45" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                    
                        <td id="nombre_salles_eau">Nombre de salles d'eau</td>
                        <td><asp:TextBox ID="TextBoxNombreSallesEau" runat="server" class="cellulePetite" CssClass=" tb40" onchange='javascript:checkfield_num("balise_spoiler46", this.value)'></asp:TextBox>
                        <span id="balise_spoiler46" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                    </tr>
                    <tr id="nombre_parking_interieurs">
                        <td>Nb de parkings intérieurs</td>
                        <td><asp:TextBox ID="TextBoxNombreParkingInterieurs" runat="server" class="cellulePetite" CssClass=" tb40" onchange='javascript:checkfield_num("balise_spoiler47", this.value)'></asp:TextBox>
                        <span id="balise_spoiler47" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                    
                        <td id="nombre_parking_exterieurs">Nb de parking extérieurs</td>
                        <td><asp:TextBox ID="TextBoxNombreParkingExterieurs" runat="server" class="cellulePetite" CssClass=" tb40" onchange='javascript:checkfield_num("balise_spoiler48", this.value)'></asp:TextBox>
                        <span id="balise_spoiler48" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                    </tr>
                    <%if (test_DropList == "Maison")
                      { %>
                    <tr id="nombre_garages">
                        <td>Nb de garages</td>
                        <td><asp:TextBox ID="TextBoxNombreGarages" runat="server" class="cellulePetite" CssClass=" tb40" onchange='javascript:checkfield_num("balise_spoiler49", this.value)'></asp:TextBox>
                        <span id="balise_spoiler49" class="balise_spoiler"><img  class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                    </tr>
                    <%} %>
                    <tr id="nombre_caves">
                        <td >Nb de caves</td>
                        <td><asp:TextBox ID="TextBoxNombreCaves" runat="server" class="cellulePetite" CssClass=" tb40" onchange='javascript:checkfield_num("balise_spoiler50", this.value)'></asp:TextBox>
                       <span id="balise_spoiler50" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                    </tr> 
                    
                </table>
            </fieldset>

<!-- ******************************************* /Disposition intérieure ******************************************************************************** -->

<!-- ******************************************* Diagnostic de performance énergétique ****************************************************************** -->

<!-- ******************************************* Affichage pour Maison/Appartement ********************************************************************* -->

            <%} %>
            <%if (test_DropList == "Maison" || test_DropList == "Appartement")
                  { %> 
                  
                  <fieldset class="fieldset_6champs" id="fieldset_DPE">
            
                <legend><strong>Diagnostic de performance énergétique</strong></legend>
                <table>
                    <tr id="lettre_conso">
                        <td>DPE Lettre conso</td>
                        <td>
                            <asp:DropDownList ID="DropDownListLettreConso" runat="server" CssClass=" tb80">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>A</asp:ListItem>
                            <asp:ListItem>B</asp:ListItem>
                            <asp:ListItem>C</asp:ListItem>
                            <asp:ListItem>D</asp:ListItem>
                            <asp:ListItem>E</asp:ListItem>
                            <asp:ListItem>F</asp:ListItem>
                            <asp:ListItem>G</asp:ListItem>
                            </asp:DropDownList> 
                        </td>
                    
                        <td id="nombre_conso">DPE Nb conso</td>
                        <td>  <asp:TextBox ID="TextBoxNombreConso" runat="server" CssClass=" tb80" onchange='javascript:checkfield_num("balise_spoiler52", this.value)'></asp:TextBox>
                        <span id="balise_spoiler52" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                    </tr>
                    <tr id="lettre_energie">
                        <td>GES Lettre émission</td>
                        <td>
                            <asp:DropDownList ID="DropDownListLettreEnergie" CssClass=" tb80" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>A</asp:ListItem>
                            <asp:ListItem>B</asp:ListItem>
                            <asp:ListItem>C</asp:ListItem>
                            <asp:ListItem>D</asp:ListItem>
                            <asp:ListItem>E</asp:ListItem>
                            <asp:ListItem>F</asp:ListItem>
                            <asp:ListItem>G</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        
                        <td id="nombre_energie">GES Nb émission</td>
                        <td><asp:TextBox ID="TextBoxNombreEnergie" runat="server" CssClass=" tb80" onchange='javascript:checkfield_num("balise_spoiler53", this.value)'></asp:TextBox>  
                        <span id="balise_spoiler53" class="balise_spoiler"><img  class="croix_rouge" src="../img_site/croix_rouge.png" /></span></td>
                    </tr>
                
                </table>
            
            </fieldset>
            <%} %>