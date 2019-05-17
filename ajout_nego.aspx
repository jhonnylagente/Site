<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="ajout_nego.aspx.cs" Inherits="pages_ajout_nego" Title="PATRIMONIUM : Mon espace client" EnableEventValidation="false" %>
<%@ Register TagPrefix="uc" TagName="ongletProprietaire" Src="onglet_proprietaire.ascx" %>
<%@ Register TagPrefix="uc" TagName="ongletVendeurPrix" Src="onglet_vendeurprix.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >

    <% //La saisie se automatique des champs se fait en ajax a l'aide de _ajaxGetList.aspx.cs 
	%>
	
	<% var test_DropList = DropDownListTypeBien.SelectedValue.ToString(); %>
	
    <!-- Ce morceau contient le javascript de la page -->
	<script>
		var typeID = '#<%=DropDownListTypeBien.ClientID %>';
		var cpID = '#<%=TextBoxCodePostalBien.ClientID %>';
		var villeID = '#<%=TextBoxVilleBien.ClientID %>';
		var paysID = '#<%=TextBoxPaysBien.ClientID %>';
		var categorieBien = '#<%=DropDownListCategorie.ClientID %>';
		var typeBien = '#<%=DropDownListTypeBien.ClientID %>';
		
		var prixID = '#ctl00_contentPlaceHolder1_onglet_VendeurPrix_TextBoxPrixVente';
		var surfaceID = '#ctl00_contentPlaceHolder1_TextBoxSurfaceHabitable';
	</script>
	
    <script type="text/javascript" src="../JavaScript/ajouterBien.js"></script>
    <script type="text/javascript" src="ajout_modif_nego.js"></script>

    
        <strong id="error" class="rouge"><asp:Label ID="LabelErrorLogin" runat="server" ForeColor="Red" Visible="False" Width="600px"></asp:Label></strong>


        <!-- Pour ce formulaire on utilise un système d'onglet fait avec du javascript -->          

<div class="systeme_onglets">
    <!-- Voici la liste des différents onglets vu en haut de page -->
    <div class="onglets">
        <span class="onglet_0 onglet" id="onglet_mandat" onclick="javascript:change_onglet('mandat');"><strong>Mandat</strong></span>
        <span class="onglet_0 onglet" id="onglet_vendeurprix" onclick="javascript:change_onglet('vendeurprix');"><strong>Vendeur & Prix</strong></span>
        <span class="onglet_0 onglet" id="onglet_juridiqueagence" onclick="javascript:change_onglet('juridiqueagence');"><strong>Juridique</strong></span>
        <span class="onglet_0 onglet" id="onglet_descriptiftechnique" onclick="javascript:change_onglet('descriptiftechnique');"><strong>Descriptif Technique</strong></span>
        <span class="onglet_0 onglet" id="onglet_photos" onclick="javascript:change_onglet('photos');"><strong>Photos & Texte</strong></span>
       <!-- <span class="onglet_0 onglet" id="onglet_autre" onclick="javascript:change_onglet('autre');"><strong>Autres</strong></span> -->
       <!-- <span class="onglet_0 onglet" id="onglet_valider" onclick="javascript:change_onglet('valider');"><strong>Valider</strong></span> -->        
    </div>
    
    <!-- Voici le contenu des onglets déclarés en haut -->
    <div class="contenu_onglets">
    
        <div class="contenu_onglet" id="contenu_onglet_mandat" style="height:355px">
          <div class="contenu_ongletG"> 
            <fieldset class="fieldset_2champs" style="height:120px">
		        <legend><strong>Références</strong></legend>
                <table>
                    <tr>
                        <td class="cellulePer">Négociateur <!--AUTOMATIQUE--></td>  
                        <% 
                            string refe = "";
                            string nego = "";
                             Membre member = (Membre)Session["Membre"];
                             TextBoxNegociateur.Text = member.NOM + " " + member.PRENOM;
                        %>                 
                        <td><asp:TextBox ID="TextBoxNegociateur" class="grey" ReadOnly="true" runat="server"  CssClass="tbsanswidth"  OnSelectedValueChanged="Index_Changed" ></asp:TextBox></td>  
						<td class="cellulePer">    Date </td>
						<td><%  
							Response.Write("   " + DateTime.Today.ToShortDateString());
                        %>     
						</td> 
					</tr>
                    <tr>
                        <td class="cellulePer">Type du bien</td>   
                        <td>    
                         <asp:DropDownList ID="DropDownListTypeBien" runat="server" onchange="updateType();" CssClass=" tbsanswidth" > 
	                            <asp:ListItem Value="Appartement" Text="Appartement" /> 
	                            <asp:ListItem Value="Maison" Text="Maison" /> 
	                            <asp:ListItem Value="Immeuble" Text="Immeuble" /> 
	                            <asp:ListItem Value="Local" Text="Local" /> 
	                            <asp:ListItem Value="Terrain" Text="Terrain" /> 
                        </asp:DropDownList>

                        </td>
                        <td>Etat du bien</td>    
						<td>
                        <asp:DropDownList ID="DropDownListEtat" runat="server" CssClass=" tbsanswidth" onClick="javascript:dropDwnValueChange()">
                        </asp:DropDownList> 
                        <br />
                        <span id="spanPub" class="invisible" runat="server">
                            <asp:CheckBox ID="chckBxPub" Checked="false" runat="server" />Pub locale<br />  
                        </span>  

                               
                        </td>           
                   </tr>                  
                </table>        
            </fieldset>
           <script type="text/javascript">
                var etat = document.getElementById('<%=DropDownListEtat.ClientID %>');
                var chckBxPub = document.getElementById('<%= spanPub.ClientID %>');
                function dropDwnValueChange() {
                    if (etat.value == "Estimation") {
                        chckBxPub.className = 'notInvisible';
                    }
                    else {
                        chckBxPub.className = 'invisible';
                    }
                }
                dropDwnValueChange();
            </script>
            
            <fieldset class="fieldset_18champs" style="height:195px">
		        <legend><strong>Adresse du bien</strong></legend>
                <table>           
                    <tr>  
                        <td class="cellulePer"> Adresse du bien </td>             
                        <td id="test" ><asp:TextBox ID="TextBoxAdresseBien" ClientIDMode="static"  runat="server" CssClass="tb200" onchange='javascript:checkfield_alpha_num("balise_spoiler", this.value)' ></asp:TextBox> </td>
                        <td class="tooltipContainer"><a href='javascript:carte_google()'><img src="../img_site/flat_round/monde.png" width="25px" alt="" /><div class="tooltip2"><span>Emplacement sur GoogleMap</span></div></a></td>
                        <td id="balise_spoiler" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td> <!-- Permet d'afficher une croix rouge lorsque le champs ne respecte pas le regex --> 
                        <script language="javascript" type="text/javascript">
                            function carte_google() {
                                window.open("https://maps.google.fr/maps?hl=fr&authuser=1&q=" + document.getElementById('<%=TextBoxAdresseBien.ClientID%>').value + "+" + document.getElementById('<%=TextBoxCodePostalBien.ClientID%>').value + "+" + document.getElementById('<%=TextBoxVilleBien.ClientID%>').value);

                            }
                            

                        </script>
        
                    </tr>
                    <tr>
                        <td class="cellulePer">Code postal<span class="rouge">*</span></td>
                        <td><asp:TextBox ID="TextBoxCodePostalBien" AutoComplete="postal-code" runat="server" CssClass="tbsanswidth" onblur='viderListeDeroulante(0)' onkeyup='listeCP(event,0)' onchange='javascript:checkfield_num("balise_spoiler2", this.value)'></asp:TextBox> </td> 
                        <td id="balise_spoiler2" class="balise_spoiler" > <img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                        <td id='saisieautocp0'></td>
                    </tr>
                    <tr>
                        <td class="cellulePer">Ville du bien<span class="rouge">*</span></td>
                        <td><asp:TextBox ID="TextBoxVilleBien" runat="server" CssClass="tbsanswidth" onblur='viderListeDeroulante(0)' onkeyup='listeVilles(event,0)' onchange='javascript:checkfield_alpha("balise_spoiler3", this.value)' ></asp:TextBox></td>
                        <td id="balise_spoiler3" class="balise_spoiler" > <img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                        <td id='saisieautoville0'></td>
                    </tr>
                    <tr>
                        <td class="cellulePer">Pays du bien<span class="rouge">*</span></td>
                        <td><asp:TextBox ID="TextBoxPaysBien" value="France" runat="server" CssClass="tbsanswidth" onblur='viderListeDeroulante(0)' onkeyup='listePays(event,0)' onchange='javascript:checkfield_alpha("balise_spoilerPays", this.value)'></asp:TextBox></td>
						<td id="balise_spoilerPays" class="balise_spoiler" > <img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                        <td id='saisieautopays0'></td>
                    </tr>
                    <tr>
                        <td class="cellulePer">Localisation du bien</td>
                        <td><asp:TextBox ID="TextBoxLocalisationBien" placeholder="Centre-ville, ..." CssClass="tbsanswidth" runat="server"  onchange='javascript:checkfield_alpha_num("balise_spoiler4", this.value)'></asp:TextBox></td>            
                        <td id="balise_spoiler4" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
					</tr>
					
                </table>
            </fieldset >
         </div>
         <div class="contenu_mandatD">    
            <fieldset class="fieldset_8champs" style="height:294px">
		        <legend><strong>Info. Mandat</strong></legend>
					
                    Mandat : <asp:FileUpload ID="FileUpload9" runat="server" /><br /><br />
				
                <table>                     
                    <tr>
                        <td>Type de mandat</td>    
                    <td>
                        <asp:DropDownList ID="DropDownListTypeMandat" runat="server" CssClass=" tbsanswidth"  onchange='javascript:checkfield_alpha("balise_spoiler6", this.value)'>
                        </asp:DropDownList>   
                        </td>
                        <td id="balise_spoiler6" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                    </tr>
                       
                    <tr>
                        <td>Coup de coeur</td>    
                        <td><asp:CheckBox ID="coupDeCoeur" runat="server"></asp:CheckBox></td> 
                        <td>Mer</td>    
                        <td><asp:CheckBox ID="cb_Mer" runat="server"></asp:CheckBox></td> 
                    </tr>
                    
                    <tr>      
                        <td>Prestige</td>    
                        <td><asp:CheckBox ID="prestige" runat="server"></asp:CheckBox></td>
                        <td>Montagne</td>    
                        <td><asp:CheckBox ID="cb_Montagne" runat="server"></asp:CheckBox></td> 
                    </tr>
                    
                    <tr>      
                        <td>Neuf</td>    
                        <td><asp:CheckBox ID="neuf" runat="server"></asp:CheckBox></td>
                    </tr>

                    <tr>      
                        <td>Disponibilité</td>    
                        <td><asp:TextBox ID="TextBoxDisponibilite" runat="server" placeholder="Libre | Date de dispo" CssClass="tbsanswidth" onchange='javascript:checkfield_alpha_num("balise_spoiler7", this.value)'></asp:TextBox></td> 
                        <td id="balise_spoiler7" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>
                    </tr>
                     <tr>      
                        <td>Montant du loyer</td>
                        <td><asp:TextBox ID="TextBoxMontantLoyer" runat="server" placeholder="Loyer présent ou passé" onchange='javascript:checkfield_num("balise_spoiler8", this.value)' CssClass="tbsanswidth"></asp:TextBox> </td>  
                        <td id="balise_spoiler8" class="balise_spoiler"><img class="croix_rouge" src="../img_site/croix_rouge.png" /></td>    
                   </tr>
                 </table>
            </fieldset>    
         </div>           
        </div>
            
        <!-- ONGLET PROPRIETAIRE -->    
        <uc:ongletProprietaire id="onglet_Proprietaire" runat="server" />
		
        <!-- ONGLET LOCALISATION ET FINANCE -->    
        <!--#include file="onglet_localisationfinance.aspx"-->

        <!-- ONGLET VENDEUR ET PRIX -->   
        <uc:ongletVendeurPrix id="onglet_VendeurPrix" runat="server" />

        <!-- ONGLET JURIDIQUE -->
        <!--#include file="onglet_juridique.aspx"-->

        <!-- ONGLET DESCRIPTIF TECHNIQUE -->
		<!--#include file="onglet_descriptif_technique.aspx"-->

<!-- ******************************************* /Diagnostic de performance énergétique ****************************************************************** -->

         </div>    
        </div>
        
        
        <div class="contenu_onglet" id="contenu_onglet_valider">
            <div class="ajouterbien">
                <asp:Button ID="ButtonAddBien" runat="server" Text="Ajouter le bien" OnClientClick="return validerForm();" OnClick="ButtonAddBien_Click1" CssClass="myButton" />
                <asp:Button ID="Mika" runat="server" Text="Mika" OnClick="ButtonAddBien_Click2" CssClass="myButton"/>
            </div>
        </div>  
    
        <!-- ONGLET PHOTO -->
        <!--#include file="onglet_photo.aspx" -->
        
        <div class="contenu_onglet" id="contenu_onglet_textespublicitaires">
         <div class="contenu_ongletG3">
          
         </div> 
         <div class="contenu_ongletD3">
          <fieldset class="fieldonglet1"> 
                <legend><strong>Texte Publicité</strong></legend>
                    <asp:TextBox ID="TextBoxTextePublicite" runat="server" TextMode="multiline" CssClass=" tbsanswidth" ></asp:TextBox>
          </fieldset>
         </div>
         <div> 
            <fieldset class="fieldonglet1"> 
                <legend><strong>Texte Mailing</strong></legend>
                <asp:TextBox ID="TextBoxTexteMailing" runat="server" TextMode="multiline" CssClass=" tbsanswidth" ></asp:TextBox>
            </fieldset>    
            
         </div>
           
        </div>
        
    </div> 
    
</div>

    <br/>
<div>
<div class="boutonMilieuNew"><asp:Button ID="BoutonAjouter" runat="server" Text="Ajouter le bien" OnClientClick="return validerForm();" OnClick="ButtonAddBien_Click1" style="padding:6px;" CssClass="myButtopetiteajouter"/></div>

    <div class='champsObligatoire'>
       <span class="rouge">*</span>: Champs obligatoires              
        <br/>
        <!--<div class="rouge" style='margin-left:30px;'>
            code postal du bien<br/>
		    ville du bien<br/>
            pays du bien<br />
		    prix de vente<br/>
		    surface habitable<br/>
		</div>-->
    </div>

</div>
<br />
					
    

<script type="text/javascript">
    var anc_onglet = 'mandat';
    change_onglet(anc_onglet);
    document.getElementById("FileUpload1").style.opacity = "0";
    document.getElementById("FileUpload9").style.opacity = "0";
</script>
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
    }
    function closeCalender(d) {
        var boxObj = d.parentNode.parentNode.parentNode;
        boxObj.parentNode.removeChild(boxObj);
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
        var calenderObj = document.createElement("span");
        calenderObj.innerHTML = HS_calender(new Date());
        calenderObj.style.position = "absolute";
        calenderObj.targetObj = inputObj;
        inputObj.parentNode.insertBefore(calenderObj, inputObj.nextSibling);
    }
  </script>
</asp:Content>

