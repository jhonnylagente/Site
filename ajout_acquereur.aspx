<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" EnableViewState="true"
    MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="ajout_acquereur.aspx.cs"
    Inherits="pages_ajout_acquereur" Title="PATRIMONIUM : Modifier mes coordonnées" %>

<%@ Register TagPrefix="uc" TagName="controlAjoutAcquereur" Src="controlAjoutAcquereur.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="onglets">
        <span class="onglet_0 onglet" id="onglet_général" onclick="javascript:change_onglet('général');"><strong>Général</strong></span>
        <span class="onglet_0 onglet" id="onglet_descriptiftechnique2" onclick="javascript:change_onglet('descriptiftechnique2');"><strong>Descriptif Technique</strong></span>
        
    </div>
    <div style="overflow:hidden;margin-bottom:15px;">
        <asp:PlaceHolder ID="PlaceHolderTest" runat="server"></asp:PlaceHolder>
        <!-- Ce morceau contient le javascript de la page -->
        <script type="text/javascript" src="checkfield.js"></script>
         <script type="text/javascript" src="../JavaScript/ajouterBien.js"></script>
    <script type="text/javascript" src="ajout_modif_nego.js"></script>
        <strong>
            <asp:Label ID="LabelErrorLogin" runat="server" class="rouge"></asp:Label></strong>
        <strong>
            <asp:Label ID="LabelOk" runat="server"></asp:Label></strong>
        <!-- Formulaire d'ajout de l'acquéreur -->

        <div class="contenu_onglets">
    
        <div class="contenu_onglet" id="contenu_onglet_général" style="height:300px">
          <div class="contenu_ongletGA">
             
            <fieldset class="fieldset_20champs">
                <legend><strong>Références</strong></legend>
                <table width="100%" height="260px">
                    <tr>
						<td style="padding-right:20px;">
							Civilité
						</td>
                        <td>
                            <asp:RadioButton ID="RadioButtonMr" runat="server" GroupName="radioButtonGroup" Text="Mr"
                                Checked="true" />
                            <asp:RadioButton ID="RadioButtonMlle" runat="server" GroupName="radioButtonGroup"
                                Text="Mlle" />
                            <asp:RadioButton ID="RadioButtonMme" runat="server" GroupName="radioButtonGroup"
                                Text="Mme" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nom *
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxNom" runat="server" CssClass="tbsanswidth" style="margin-top:8px; width:130px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="PersonalInfoGroup"
                                ControlToValidate="TextBoxNom" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            Prénom
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxPrenom" runat="server" CssClass="tbsanswidth" style="width:130px;"></asp:TextBox>
                        </td>
                    </tr>
					<tr style="height:7px;"></tr>
                    <tr>
                        <td>
                            Adresse
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxAdresse" runat="server" CssClass="tbsanswidth" style="width:130px;"></asp:TextBox>
                        </td>
                        <td>
                            Pays
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListPays" runat="server" CssClass="tbsanswidth" style="width:137px;">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Ville
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxVille" runat="server" CssClass="tbsanswidth" style="width:130px;"></asp:TextBox>
                        </td>
                        <td>
                            Code postal
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxCodePostal" runat="server" CssClass="tbsanswidth" style="width:130px;"></asp:TextBox>
                        </td>
                    </tr>
					<tr style="height:7px;"></tr>
                    <tr>
                        <td>
                            Tel *
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxTel" runat="server" CssClass="tbsanswidth" style="width:130px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="PersonalInfoGroup"
                                ControlToValidate="TextBoxTel" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            Portable
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxPortable" runat="server" CssClass="tbsanswidth" style="width:130px;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Mail
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxMail" runat="server" CssClass="tbsanswidth" style="width:130px;"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </fieldset>
            </div>
            <div class="contenu_ongletGB">
            <fieldset class="fieldset_23champs">
                <legend><strong>Caractéristiques principales</strong></legend>
                <table width="100%">
                    <tr>
                        <td>
                            Type d'acquereur
						</td>
						<td>
                            <asp:DropDownList ID="DropDownListTypeAcq" runat="server" CssClass="tbsanswidth" AutoPostBack="true" style="width:140px">
                                <asp:ListItem Selected="True">Acheteur</asp:ListItem>
                                <asp:ListItem>Loueur</asp:ListItem>
                            </asp:DropDownList>
                        </td>
						<td rowspan="4" style="vertical-align:top">
							Type de biens recherchés :<br/>
                            <asp:CheckBox ID="CheckBoxAppartement" runat="server" Text="Appartement" Checked="true" Font-Bold="false" AutoPostBack="true" style="padding-left:15px"></asp:CheckBox><br/>
                            <asp:CheckBox ID="CheckBoxMaison" runat="server" Text="Maison" Font-Bold="false" AutoPostBack="true" style="padding-left:15px"></asp:CheckBox><br/>
                            <asp:CheckBox ID="CheckBoxTerrain" runat="server" Text="Terrain" Font-Bold="false" AutoPostBack="true" style="padding-left:15px"></asp:CheckBox><br/>
                            <asp:CheckBox ID="CheckBoxAutre" runat="server" Text="Autre" Font-Bold="false" AutoPostBack="true" style="padding-left:15px"></asp:CheckBox>
						</td>
                    </tr>
					<tr>
                        <td>
                            <asp:CheckBox ID="CheckBoxVendeur" runat="server" Text="Vendeur" Font-Bold="false"
                                AutoPostBack="true"></asp:CheckBox>
                        </td>
						<td></td>
					</tr>
                    <tr>
                        <td>
                            Recherche
						</td>
						<td>
                            <asp:DropDownList ID="DDLCategorieAcquereur" runat="server" CssClass="tbsanswidth" style="width:140px">
                                <asp:ListItem Value="precis" Text="precis"></asp:ListItem>
                                <asp:ListItem Value="large" Text="large"></asp:ListItem>
                                <asp:ListItem Value="investisseur ancien" Text="investisseur ancien"></asp:ListItem>
                                <asp:ListItem Value="investisseur neuf" Text="investisseur neuf"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="etat_avancement">
                        <td>
                            Etat avancement
						</td>
						<td>
                            <asp:DropDownList ID="DropDownListEtatAvancement" runat="server" CssClass=" tbsanswidth" style="width:140px">
                                <asp:ListItem Selected="True">Disponible</asp:ListItem>
                                <asp:ListItem>Offre</asp:ListItem>
                                <asp:ListItem>Suspendu</asp:ListItem>
                                <asp:ListItem>Retiré</asp:ListItem>
                                <asp:ListItem>Compromis</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
            </asp:ScriptManager>
            <div style="padding-top:9px"><uc:controlAjoutAcquereur ID="ucAjoutAcquereur" runat="server" /></div>
                   
        </div>
        </div>
        <div class="contenu_onglet" id="contenu_onglet_descriptiftechnique2" style="height:260px">

            <fieldset class="fieldset_20champs" style="display:inline; width:47%">
                <legend><strong>Critères</strong></legend>
                <table class="tablecarateristique" width="100%">
                    <tr>
					
                        <td>
							<% if ( DropDownListTypeAcq.SelectedValue == "Loueur") {%>
                            Loyer min
							<%}else{%>
							Prix min
							<%}%>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxPrixMin" runat="server" CssClass="tbsanswidth" style="width:60px"></asp:TextBox>&nbsp;&#8364;&nbsp;&nbsp;&nbsp;
                        </td>
                        <td>
							<% if ( DropDownListTypeAcq.SelectedValue == "Loueur") {%>
                            Loyer max
							<%}else{%>
							Prix max
							<%}%>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxPrixMax" runat="server" CssClass="tbsanswidth" style="width:60px"></asp:TextBox>&nbsp;&#8364;
                        </td>
                    </tr>
                    <%if (CheckBoxAppartement.Checked || CheckBoxMaison.Checked)
                      {%>
                    <tr>
                        <td>
                            Nb de pièces min
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxPiecesMin" runat="server" CssClass=" tb40"></asp:TextBox>
                        </td>
                        <td>
                            Nb de pièces max
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxPiecesMax" runat="server" CssClass=" tb40"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nb de chambres min
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxChambresMin" runat="server" CssClass=" tb40"></asp:TextBox>
                        </td>
                        <td>
                            Nb de chambres max
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxChambresMax" runat="server" CssClass=" tb40"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Surface habitable min
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSurfaceHabitableMin" runat="server" CssClass=" tb40"></asp:TextBox>m²
                        </td>
                        <td>
                            Surface habitable max
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSurfaceHabitableMax" runat="server" CssClass=" tb40"></asp:TextBox>m²
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Surface séjour min
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSurfaceSejourMin" runat="server" CssClass=" tb40"></asp:TextBox>m²
                        </td>
                        <td>
                            Surface séjour max
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSurfaceSejourMax" runat="server" CssClass=" tb40"></asp:TextBox>m²
                        </td>
                    </tr>
                    <%} %>
                    <%if (CheckBoxTerrain.Checked)
                      {%>
                    <tr>
                        <td>
                            Façade
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxFacade" runat="server" CssClass="tb40"></asp:TextBox>m²
                        </td>
                        <td>
                            Profondeur
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxProfondeur" runat="server" CssClass=" tb40"></asp:TextBox>m²
                        </td>
                    </tr>
                    <%}
                      if (CheckBoxTerrain.Checked || CheckBoxMaison.Checked)
                      { %>
                    <tr>
                        <td>
                            Surface terrain min
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSurfaceTerrainMin" runat="server" CssClass=" tb40"></asp:TextBox>m²
                        </td>
                        <td>
                            Surface terrain max
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSurfaceTerrainMax" runat="server" CssClass=" tb40"></asp:TextBox>m²
                        </td>
                    </tr>
                    <%} %>
                </table>
                <table style="margin-top:10px;">
                    <tr>
					<%if (CheckBoxAppartement.Checked)
                      {%>
                        <td>
                            <asp:CheckBox ID="CheckBoxAscenseur" runat="server"></asp:CheckBox> Ascenseur
                        </td>
                        <%} %>
                        <%if (CheckBoxMaison.Checked || CheckBoxAppartement.Checked)
                          {%>
                        <td style="padding-left:15px;">
                            <asp:CheckBox ID="CheckBoxSousSol" runat="server"></asp:CheckBox> Sous-sol
                        </td>
                        <td style="padding-left:15px;">
                            <asp:CheckBox ID="CheckBoxParking" runat="server"></asp:CheckBox> Parking/Box
                        </td>
                    </tr>
                    <%} %>
                </table>
            </fieldset>
            <fieldset class="fieldset_22champs" style="float:right ; width:47%">
                <legend><strong>Informations complémentaires (balcon,...)</strong></legend>
                <asp:TextBox ID="TextBoxTexteComplementaire" runat="server" TextMode="multiline"
                    CssClass="tbinformation" style="height:202px"></asp:TextBox>
            </fieldset>
        </div>
    </div>
    </div>
    
	<%if (Session["ajout_acquereur"] == "true")
	  {%>
				<asp:Button ID="ButtonAddAcquereur" runat="server" Text="Ajouter l'acquereur" OnClick="ButtonAddAcquereur_Click"
		CssClass="myButtonright" style="display:block;float:none;margin:auto;"/>
	<%}
	  else
	  {%>
				<asp:Button ID="ButtonModifierAcquereur" runat="server" Text="Modifier l'acquereur" OnClick="ButtonModifierAcquereur_Click"
		CssClass="myButtonright" style="display:block;float:none;margin:auto;"/>
	<%}%>
	<br/>

    <script type="text/javascript">
        var anc_onglet = 'général';
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
        /*可以把下面的css剪切出去独立一个css文件zzjs.net*/
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
