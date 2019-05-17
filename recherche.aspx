<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="recherche.aspx.cs" Inherits="recherche" Title="PATRIMO : Recherche de biens" %>

<%@ Register TagPrefix="uc" TagName="controlCible" Src="controlAjoutAcquereur_new.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- JS et css lies a la world map et a la map d'Europe -->
		<link rel="stylesheet" type="text/css" media="screen,projection" href="../worldmap/cssmap-continents.css" />
		<link rel="stylesheet" href="../worldmap/customWM.css"/>
		<script type="text/javascript" src="../worldmap/jquery.cssmap.js"></script> 
		<script type="text/javascript" src="../worldmap/customWM.js"></script>
		
		<link rel="stylesheet" type="text/css" media="screen,projection" href="../map-europe/cssmap-europe.css" />
		<link rel="stylesheet" href="../map-europe/customEM.css"/>
		<!--<script type="text/javascript" src="../map-europe/jquery.cssmap.js"></script> -->
		<script type="text/javascript" src="../map-europe/customEM.js"></script>

        <script src="../JSplugins/jQueryRangeSlide/jquery-ui.js"></script>
        <link rel="stylesheet" href="../JSplugins/jQueryRangeSlide/style.css">
		
<script type="text/javascript">

    $(document).ready(function () {

        $("#CB_Maison").prop('checked', $("#<%=checkBoxMaison.ClientID %>").is(':checked'));
        $("#CB_Appartement").prop('checked', $("#<%=checkBoxAppart.ClientID %>").is(':checked'));
        $("#CB_Terrain").prop('checked', $("#<%=checkBoxTerrain.ClientID %>").is(':checked'));
        $("#CB_Autres").prop('checked', $("#<%=checkBoxAutre.ClientID %>").is(':checked'));

        $("#CB_1P").prop('checked', $("#<%=checkBoxPiece1.ClientID %>").is(':checked'));
        $("#CB_2P").prop('checked', $("#<%=checkBoxPiece2.ClientID %>").is(':checked'));
        $("#CB_3P").prop('checked', $("#<%=checkBoxPiece3.ClientID %>").is(':checked'));
        $("#CB_4P").prop('checked', $("#<%=checkBoxPiece4.ClientID %>").is(':checked'));
        $("#CB_5P").prop('checked', $("#<%=checkBoxPiece5.ClientID %>").is(':checked'));

        $("#CB_CdC").prop('checked', $("#<%=chckBxCdC.ClientID %>").is(':checked'));
        $("#CB_Prestige").prop('checked', $("#<%=chckBxPrestige.ClientID %>").is(':checked'));
        $("#CB_Mer").prop('checked', $("#<%=chckBxMer.ClientID %>").is(':checked'));
        $("#CB_Montagne").prop('checked', $("#<%=chckBxMontagne.ClientID %>").is(':checked'));

        $("#<%=BTN_V.ClientID %>").hover(
            function () {
                $(this).css('width');
                $(this).css('width', '80px');
                if ($(this).val() == "V") { $(this).val("Vente"); }
                else { $(this).val("Location"); }

            }, function () {
                $(this).css('width', '42px');
                if ($(this).val() == "Vente") { $(this).val("V"); }
                else { $(this).val("L"); }
            }
        );

        $("#<%=BTN_V.ClientID %>").click(
                function () {
                    switch ($(this).val()) {
                        case "Vente": $(this).val("Location"); $("#<%=radioButtonLocation.ClientID %>").prop('checked', 'true'); break;
                        case "Location": $(this).val("Vente"); $("#<%=radioButtonLocation.ClientID %>").prop('checked', 'true'); break;
                        default: break;
                    }
                }
            );
    });


function extend_recherche(){
	if(document.getElementById('box_rech_extend').style.display == 'none')
	{
		document.getElementById('main_container').style.transition = "all 0.5s";
		document.getElementById('box_rech').style.transition = "all 0.5s";
		document.getElementById('box_rech_extend').style.transition = "all 1s";

		document.getElementById('<%=BTN_Extend_Recherche.ClientID %>').value = '-';
		document.getElementById('main_container').style.height = '700px';
		document.getElementById('box_rech').style.top = '150px';
		document.getElementById('box_rech_extend').style.display = 'block';
		document.getElementById('box_rech_extend').style.top = '300px';
	}
	else
	{
	    document.getElementById('<%=BTN_Extend_Recherche.ClientID %>').value = '+';
		document.getElementById('main_container').style.height = '400px';
		document.getElementById('box_rech').style.top = '250px';
		document.getElementById('box_rech_extend').style.display = 'none';
		document.getElementById('box_rech_extend').style.top = '300px';
	}
}

    function Shield_CB() {
        document.getElementById('<%=chckBxCdC.ClientID %>').checked = document.getElementById('CB_CdC').checked;
        document.getElementById('<%=chckBxPrestige.ClientID %>').checked = document.getElementById('CB_Prestige').checked;
        document.getElementById('<%=chckBxMer.ClientID %>').checked = document.getElementById('CB_Mer').checked;
        document.getElementById('<%=chckBxMontagne.ClientID %>').checked = document.getElementById('CB_Montagne').checked;                  
    }

    function Shield_pieces() {
        var txt = "";
        if (document.getElementById('CB_1P').checked) txt += "1, ";
        if (document.getElementById('CB_2P').checked) txt += "2, ";
        if (document.getElementById('CB_3P').checked) txt += "3, ";
        if (document.getElementById('CB_4P').checked) txt += "4, ";
        if (document.getElementById('CB_5P').checked) txt += "5, ";

        if (txt != "") {
            txt = txt.substring(0, txt.length - 2);
            if (txt == "1") txt += " pièce";
            else txt += " pièces";
            if (document.getElementById('CB_5P').checked) txt += " ou +";
        }
        document.getElementById('<%=TB_nbre_pieces.ClientID %>').value = txt;  

        document.getElementById('<%=checkBoxPiece1.ClientID %>').checked = document.getElementById('CB_1P').checked;
        document.getElementById('<%=checkBoxPiece2.ClientID %>').checked = document.getElementById('CB_2P').checked;
        document.getElementById('<%=checkBoxPiece3.ClientID %>').checked = document.getElementById('CB_3P').checked;
        document.getElementById('<%=checkBoxPiece4.ClientID %>').checked = document.getElementById('CB_4P').checked;
        document.getElementById('<%=checkBoxPiece5.ClientID %>').checked = document.getElementById('CB_5P').checked;
    }

    function Shield_types() {

        var txt = "";
        if (document.getElementById('CB_Maison').checked) txt += "Maisons, ";
        if (document.getElementById('CB_Appartement').checked) txt += "Appartements, ";
        if (document.getElementById('CB_Terrain').checked) txt += "Terrains, ";
        if (document.getElementById('CB_Autres').checked) txt += "Autres, ";

        if (txt != "") txt = txt.substring(0, txt.length - 2);

        document.getElementById('<%=TB_TypeBien.ClientID %>').value = txt;

        document.getElementById('<%=checkBoxMaison.ClientID %>').checked = document.getElementById('CB_Maison').checked;
        document.getElementById('<%=checkBoxAppart.ClientID %>').checked = document.getElementById('CB_Appartement').checked;
        document.getElementById('<%=checkBoxTerrain.ClientID %>').checked = document.getElementById('CB_Terrain').checked;
        document.getElementById('<%=checkBoxAutre.ClientID %>').checked = document.getElementById('CB_Autres').checked;

    }

    function Shield_Budget() {
        var TB_Budg_Max = $("#<%=TB_Budget_Max.ClientID %>");
        var text_prix_min = $("#<%=TB_Texte_prix_min.ClientID %>");
        var text_prix_max = $("#<%=TB_Texte_prix_max.ClientID %>");
                                   
        var reg = /^\d+$/;

        if (TB_Budg_Max.val().length != 0) {
            if (reg.test(TB_Budg_Max.val())) {
                if (parseInt(text_prix_min.val(), 10) > parseInt(TB_Budg_Max.val(), 10)) text_prix_min.val("0");
                text_prix_max.val(TB_Budg_Max.val());
                $("#sliderPrix").slider({ values: [text_prix_min.val(), TB_Budg_Max.val()] });
                
            }
            TB_Budg_Max.val(TB_Budg_Max.val() + " €");
        }
    }

    function Manage_Budget() {
        var TB_Budg_Max = $("#<%=TB_Budget_Max.ClientID %>");
        var long = TB_Budg_Max.val().length;
        if (long >= 2) TB_Budg_Max.val(TB_Budg_Max.val().substring(0, long - 2));
    }


    function Shield_Surface() {
        var TB_Surf_Min = $("#<%=TB_Surface_Min.ClientID %>");
        var text_surf_min = $("#<%=TB_Texte_Surf_min.ClientID %>");
        var text_surf_max = $("#<%=TB_Texte_Surf_max.ClientID %>");

        var reg = /^\d+$/;

        if (TB_Surf_Min.val().length != 0) {
            if (reg.test(TB_Surf_Min.val())) {
                if (parseInt(text_surf_max.val(), 10) < parseInt(TB_Surf_Min.val(), 10)) TB_Surf_Min.val(text_surf_max.val());
                if (500 == parseInt(TB_Surf_Min.val(), 10)) TB_Surf_Min.val("450");
                text_surf_min.val(TB_Surf_Min.val());

                $("#sliderSurf").slider({ values: [TB_Surf_Min.val(), text_surf_max.val()] });            
            }
            TB_Surf_Min.val(TB_Surf_Min.val() + " m²");
        }
    }

    function Manage_Surface() {
        var TB_Surf_Min = $("#<%=TB_Surface_Min.ClientID %>");
        var long = TB_Surf_Min.val().length;
        if (long >= 3) TB_Surf_Min.val(TB_Surf_Min.val().substring(0, long - 3));
    }

    function Check_val_num(type) {
        var TB_id;
        var reg = /^\d+$/;

        if (type == 'budget') TB_id = $("#<%=TB_Budget_Max.ClientID %>");
        if (type == 'surface') TB_id = $("#<%=TB_Surface_Min.ClientID %>");
            
        if (TB_id.val().length != 0) {
            if (!reg.test(TB_id.val())) {
                TB_id.val(TB_id.val().substring(0, TB_id.val().length - 1));
            }
        }
    }

		//Réinitialise tous les critères de recherches
		function vider_formulaire_recherche()
		{
			//Si seulement ceux qui ont fait le site a l'origine connaissant la balise <form>...
			//J'aurai eu besoin d'une seule ligne : <input type="reset" value="Annuler">
			/*$("#<%=radioButtonAchat.ClientID %>").prop('checked', true);
			$("#<%=TB_Texte_prix_min.ClientID %>").val("");	
			$("#<%=TB_Texte_prix_max.ClientID %>").val("");	
			$("#<%=TB_Texte_Surf_min.ClientID %>").val("");
			$("#<%=TB_Texte_Surf_max.ClientID %>").val("");
			$("#<%=checkBoxMaison.ClientID %>").prop('checked', true);
			$("#<%=checkBoxAppart.ClientID %>").prop('checked', true);
			$("#<%=checkBoxTerrain.ClientID %>").prop('checked', true);
			$("#<%=checkBoxAutre.ClientID %>").prop('checked', true);
			$("#<%=chckBxCdC.ClientID %>").prop('checked', false);
			$("#<%=chckBxPrestige.ClientID %>").prop('checked', false);
			$("#<%=DDL_Neuf.ClientID %>").val("Tous");
			$("#<%=checkBoxPiece1.ClientID %>").prop('checked', true);
			$("#<%=checkBoxPiece2.ClientID %>").prop('checked', true);
			$("#<%=checkBoxPiece3.ClientID %>").prop('checked', true);
			$("#<%=checkBoxPiece4.ClientID %>").prop('checked', true);
			$("#<%=checkBoxPiece5.ClientID %>").prop('checked', true);
			$("#<%=TB_MotCle1.ClientID %>").val("");	
			$("#<%=TB_MotCle2.ClientID %>").val("");	
			$("#<%=TB_MotCle3.ClientID %>").val("");	
			$("#<%=TB_MotCle4.ClientID %>").val("");	*/
		}
		
		//Vide le champ situation
		function emptyListeLieu()
		{
			$("#<%=ButtonEmpty.ClientID%>").click();
		}
		
		//Fonction lié à la worldmap
		
		function choisirPays(button,pays)
		{
			map_hide();
			$("#<%=TBAjaxEuropeMap.ClientID %>").val(pays);			//Truc absoluement immonde pour simuler une requete ajax
			$("#<%=BouttonAjaxEuropeMap.ClientID %>").click();		//Flemme de corriger tout
			$(button).removeClass("active-region");
		}
		
		function choisirEurope(button)								//Fonction JS appelé par un bouton
		{															//Qui simule l'action onclick server d'un asp:Button qui est invisible
			var continent = "Europe";								//Qui se trouve dans un bloque qui ne raffraichit pas la page
			map_hide();												//Et si on deplace ce bouton invisible de son div, la page est raffraichit
			$("#<%=TBAjaxWorldMap.ClientID %>").val(continent);		
			$("#<%=BouttonAjaxWorldMap.ClientID %>").click();
		}
	
		function choisirContinent(htmlObject,continent) 
		{
			var cssClass = $(htmlObject).attr('class');
			cssClass = cssClass.substr(3,cssClass.Lenght);
			map_hide();
			if(cssClass == "focus")
			{
				$("#<%=TBAjaxWorldMap2.ClientID %>").val(continent);
				$("#<%=BouttonAjaxWorldMap2.ClientID %>").click();
			}
			else
			{
				$("#<%=TBAjaxWorldMap.ClientID %>").val(continent);
				$("#<%=BouttonAjaxWorldMap.ClientID %>").click();
			}
        }


    $(function () {
        $("#sliderPrix").slider({
            range: true,
            min: 0,
            max: 2000000,
            step: 10000,
            values: [0, 2000000],
            slide: function (event, ui) {
                $("#<%=TB_Texte_prix_min.ClientID %>").val(ui.values[0]);
                $("#<%=TB_Texte_prix_max.ClientID %>").val(ui.values[1]);

                $("#<%=TB_Budget_Max.ClientID %>").val(ui.values[1] + " €");
            }
        });
        if ('<%=(String)Session["TextBoxBudgetMin"] %>'.length > 0) $("#<%=TB_Texte_prix_min.ClientID %>").val('<%=(String)Session["TextBoxBudgetMin"] %>');
        else $("#<%=TB_Texte_prix_min.ClientID %>").val($("#sliderPrix").slider("values", 0));
        if ('<%=(String)Session["TextBoxBudgetMax"] %>'.length > 0) $("#<%=TB_Texte_prix_max.ClientID %>").val('<%=(String)Session["TextBoxBudgetMax"] %>');
        else $("#<%=TB_Texte_prix_max.ClientID %>").val($("#sliderPrix").slider("values", 1));
    });

    $(function () {
        $("#sliderSurf").slider({
            range: true,
            min: 0,
            max: 500,
            step: 5,
            values: [0, 500],
            slide: function (event, ui) {
                $("#<%=TB_Texte_Surf_min.ClientID %>").val(ui.values[0]);
                $("#<%=TB_Texte_Surf_max.ClientID %>").val(ui.values[1]);

                $("#<%=TB_Surface_Min.ClientID %>").val(ui.values[0] + " m²");

                $("#<%=TB_Texte_Surf_max.ClientID %>").val(ui.values[1]);
            }
        });
        if ('<%=(String)Session["textBoxSurfaceMin"] %>'.length > 0) $("#<%=TB_Texte_Surf_min.ClientID %>").val('<%=(String)Session["textBoxSurfaceMin"] %>');
        else $("#<%=TB_Texte_Surf_min.ClientID %>").val($("#sliderSurf").slider("values", 0));
        if ('<%=(String)Session["textBoxSurfaceMax"] %>'.length > 0) $("#<%=TB_Texte_Surf_max.ClientID %>").val('<%=(String)Session["textBoxSurfaceMax"] %>');
        else $("#<%=TB_Texte_Surf_max.ClientID %>").val($("#sliderSurf").slider("values", 1));

    });

  </script>

<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
    <div id='main_container' style='position:relative; background-color:white; height:400px; width:100%; overflow: hidden;'>
	    <img alt="background" src='<%=img_bg %>' class='main_picture' style='width:104%; margin-left:-3px; margin-top:-10px'/>
        <!-- RECHERCHE PRINCIPALE -->	
        <div id='box_rech' class='bloc_rech' style='background-color:white; min-height:130px; width:88%;'>
		    <center>
                <br/>
                <asp:Button ID="BTN_V" runat="server" OnClientClick="return false;" CssClass="flat-button2" Text="V" /><!-- JQuery pour l'action de ce bouton -->		
                <div style='display:inline-block; position:relative'>	
                    <div id="ddl_type" class='cssmenu2' style="position:absolute;" >
                        <ul>
                           <li><a href="javascript:void()" style="cursor:default"><span><asp:TextBox ID="TB_TypeBien" runat="server" ReadOnly="true" CssClass="big_textbox" style='background-image:url(); color: darkgrey; width:100px' placeholder="Type de bien"></asp:TextBox>
                                    </span></a>
                              <ul>
                                 <li><a href="javascript:void()"><span><input type="checkbox" onclick="Shield_types() " name="CB_Maison" id="CB_Maison" class="css-checkbox" checked /><label for="CB_Maison" class="css-label">Maisons</label><br />
                            </span></a></li>
                                    <li><a href="javascript:void()"><span><input type="checkbox" onclick="Shield_types() " name="CB_Appartement" id="CB_Appartement" class="css-checkbox" checked /><label for="CB_Appartement" class="css-label">Appartements</label><br />
                            </span></a></li>
                                    <li><a href="javascript:void()"><span><input type="checkbox" onclick="Shield_types() " name="CB_Terrain" id="CB_Terrain" class="css-checkbox" checked /><label for="CB_Terrain" class="css-label">Terrains</label><br />
                             </span></a></li>
                                    <li><a href="javascript:void()"><span><input type="checkbox" onclick="Shield_types() " name="CB_Autres" id="CB_Autres" class="css-checkbox" checked /><label for="CB_Autres" class="css-label">Autres</label><br />
                       </span></a></li>
                              </ul>
                           </li>
                        </ul>
                        </div>

                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" style="display:inline-block;margin-left:130px; margin-right:3px;">
                        <ContentTemplate>
                        <div style="position:relative">
                            <uc:controlCible ID="ucCible" runat="server"/>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:TextBox ID="TB_Budget_Max" autocomplete="off" runat="server" onblur="Shield_Budget()" onkeyup="Check_val_num('budget')" onfocus="Manage_Budget()" CssClass="big_textbox" style=' width:200px; margin-right:10px;' placeholder="Budget Maximum"></asp:TextBox>
					<asp:TextBox ID="TB_Surface_Min" autocomplete="off" runat="server" onblur="Shield_Surface()" onkeyup="Check_val_num('surface')" onfocus="Manage_Surface()" CssClass="big_textbox" style=' width:200px; margin-right:10px;' placeholder="Surface Minimum"></asp:TextBox>
                    <br/>
                    <br/> 
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" style="float:left; " >
                        <ContentTemplate>
                            <asp:Label ID="LBL_nbre_bien" runat="server" style="margin-left:30px; color:darkgrey; font-size:20px; " />
                            <asp:Panel ID="PNL_resultPanel" Visible="false" runat="server" style=" display:inline-block ;text-align:left;width:550px; height: 40px; overflow:auto; margin-left:130px;" ></asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:Button ID="BTN_Rechercher" runat="server" OnClick="Button1_Click" CssClass="flat-button" Text="Rechercher" style='float:right; margin-right:20px;'/>
                    <asp:Button ID="BTN_Extend_Recherche" OnClientClick="extend_recherche(); return false;" runat="server"  CssClass="flat-button" Text="+" style='width:25px; float:right; margin-right:10px;'/>
					<br/><br/>
				</div>
            </center>
		</div>
         <!-- RECHERCHE AVANCEE -->	
		<div id='box_rech_extend' class='bloc_rech' style='display:none; background-color:white; min-height:350px; width:88%;'>
			<table>
				<tr>
                    <!-- Nombre de pieces, budget, surface, mots clef -->
					<td width='40%' valign="top">
                    <br />   
                        <center>  
                        <div class='cssmenu2' style="margin-left:50px">
                        <ul>
                           <li><a href="javascript:void()" style="cursor:default"><span><asp:TextBox ID="TB_nbre_pieces"  ReadOnly="true" runat="server" CssClass="big_textbox" style='cursor:default; width:100%; color: darkgrey; margin-right:10px;' placeholder="1, 2, 3, 4, 5 pièces ou +"></asp:TextBox></span></a>
                              <ul>
                                 <li><a href="javascript:void()"><span><input type="checkbox" onclick="Shield_pieces()" name="CB_1P" id="CB_1P" class="css-checkbox" checked /><label for="CB_1P" class="css-label">1 pièce</label>
                                    </span></a></li>
                                    <li><a href="javascript:void()"><span><input type="checkbox" onclick="Shield_pieces()" name="CB_1P" id="CB_2P" class="css-checkbox" checked /><label for="CB_2P" class="css-label">2 pièces</label>
                                    </span></a></li>
                                    <li><a href="javascript:void()"><span><input type="checkbox" onclick="Shield_pieces()" name="CB_3P" id="CB_3P" class="css-checkbox" checked /><label for="CB_3P" class="css-label">3 pièces</label>
                                    </span></a></li>
                                    <li><a href="javascript:void()"><span><input type="checkbox" onclick="Shield_pieces()" name="CB_4P" id="CB_4P" class="css-checkbox" checked /><label for="CB_4P" class="css-label">4 pièces</label>
                                    </span></a></li>
                                    <li><a href="javascript:void()"><span><input type="checkbox" onclick="Shield_pieces()" name="CB_5P" id="CB_5P" class="css-checkbox" checked /><label for="CB_5P" class="css-label">5 pièces ou plus</label>
                                    </span></a></li>
                              </ul>
                           </li>
                        </ul>
                        </div>
                        <div style="width:80%">      
                            <p style="border:0; color:#31516B; text-align:left; font-weight:bold;">
                                Budget : Entre 
                                <asp:TextBox ID="TB_Texte_prix_min" runat="server"  style="text-align:center; width:50px; border:0; color:#31516B; font-weight:bold;"/>
                                € et 
                                <asp:TextBox ID="TB_Texte_prix_max" runat="server"  style="text-align:center; width:50px; border:0; color:#31516B; font-weight:bold;"/>
                                €
                            </p>
                            <div id="sliderPrix"></div>
                        </div>
                   
                        <div style="width:80%; margin-top:10px;">
                        <p style="border:0; color:#31516B; text-align:left; font-weight:bold;">
                                Surface : Entre 
                                <asp:TextBox ID="TB_Texte_Surf_min" runat="server" style="text-align:center; width:25px; border:0; color:#31516B; font-weight:bold;"/>
                                m² et 
                                <asp:TextBox ID="TB_Texte_Surf_max" runat="server" style="text-align:center; width:25px; border:0; color:#31516B; font-weight:bold;"/>
                                m²
                            </p>

                            <div id="sliderSurf"></div>
                        </div>
                        <br />
                        <asp:TextBox ID="TB_MotCle1" runat="server" CssClass="big_textbox" style=' width:130px; margin-right:10px; margin-top : 10px' placeholder="Mot Clef 1"></asp:TextBox>
                        <asp:TextBox ID="TB_MotCle2" runat="server" CssClass="big_textbox" style=' width:130px; margin-right:10px; margin-top : 10px' placeholder="Mot Clef 2"></asp:TextBox>
                           
                        <asp:TextBox ID="TB_MotCle3" runat="server" CssClass="big_textbox" style=' width:130px; margin-right:10px; margin-top : 10px; margin-bottom: 10px; ' placeholder="Mot Clef 3"></asp:TextBox>
                        <asp:TextBox ID="TB_MotCle4" runat="server" CssClass="big_textbox" style=' width:130px; margin-right:10px; margin-top : 10px; margin-bottom: 10px;' placeholder="Mot Clef 4"></asp:TextBox>
                         
                        </center>
					</td>
                    <!-- Neuf, Mer, Montagne, Prestige, CdC, Alerte Mail -->
                    <td width='25%' valign="top">
                    <div style='width:100%'>
                        <br />
                        <asp:DropDownList ID="DDL_Neuf" runat="server" CssClass="big_textbox" style="margin-bottom:5px; width:95%" >
                            <asp:ListItem Value="2">Neuf (VEFA) et Autres </asp:ListItem>
                            <asp:ListItem Value="1">VEFA uniquement</asp:ListItem>
                            <asp:ListItem Value="0">Autres uniquement</asp:ListItem>
                        </asp:DropDownList>
                        <input type="checkbox" onclick="Shield_CB()" name="CB_CdC" id="CB_CdC" class="css-checkbox" /><label for="CB_CdC" class="css-label">Coups de coeur</label><br />
                        <input type="checkbox" onclick="Shield_CB()" name="CB_Prestige" id="CB_Prestige" class="css-checkbox" /><label for="CB_Prestige" class="css-label">Biens de prestige</label><br />
                        <input type="checkbox" onclick="Shield_CB()" name="CB_Mer" id="CB_Mer" class="css-checkbox" /><label for="CB_Mer" class="css-label">Mer</label><br />
                        <input type="checkbox" onclick="Shield_CB()" name="CB_Montagne" id="CB_Montagne" class="css-checkbox" /><label for="CB_Montagne" class="css-label">Montagne</label><br/>
                        </div> 
                        <br />
                        
                        <p style ="font-size:18px;"><img src="../img_site/flat_round/courrier.png" alt="courrier" style="height:20px;margin-right:5px;margin-bottom:-4px;" />Enregistrer une alerte Mail:</p>
                        <asp:TextBox ID="TextBoxMail" runat="server" CssClass="big_textbox" placeholder="Votre adresse email" Style="width: 220px"></asp:TextBox>
					</td>
                    <!-- Map -->
					<td width='35%' valign="top">
                        <div class="mapandannonce" >
                            <div id="mapoffrance" >
                                <br/>
						        <div id='wm_placeholder'>
                                    <div id='calque' onclick='map_hide()'></div>
                                </div>
						        <div class="tooltipContainer">
							        <img style="vertical-align:middle;width:40px;cursor:pointer" src="../img_site/flat_round/monde.png" alt="globe" onclick="WM_toggleAll()"/> 
							        <span style="color:#31536C;font-weight:bold">&nbsp;AUTRES PAYS</span>
							        <div class="tooltip2" style="z-index:5;">
								        <span>Le monde à votre portée.</span>
							        </div>
						        </div>
							    <div id="mapContainer" ondblclick="map_hide();">
									<img id="WM_close" src="../img_site/croix_rouge_32.png" alt="close" onclick="map_hide();"/>
									<div id="WM_titre">CARTE DU MONDE</div>
									<div id="map-continents">
									    <ul class="continents">
									    <li id="wm_af" class="c1" onclick="choisirContinent(this,'Afrique');"><a href="#africa">Afrique</a></li>
									    <li id="wm_as" class="c2" onclick="choisirContinent(this,'Asie');"><a href="#asia">Asie</a></li>
									    <li id="wm_oc" class="c3" onclick="choisirContinent(this,'Océanie');"><a href="#australia-and-southern-pacific">Océanie</a></li>
									    <li id="wm_eu" class="c4" onclick="WM_hide();WM_setUnselected('eu');EM_show()"><a href="#europe">Europe</a></li>
									    <li id="wm_na" class="c5" onclick="choisirContinent(this,'AmériqueN');"><a href="#north-america">Amérique du nord</a></li>
									    <li id="wm_sa" class="c6" onclick="choisirContinent(this,'AmériqueS');"><a href="#south-america">Amérique du sud</a></li>
									    </ul>
									</div>
								</div>
								<div id="em_mapContainer">
									<img id="EM_close" src="../img_site/croix_rouge_32.png" alt="close" onclick="map_hide();"/>
									<div id="selectEurope" onclick="choisirEurope(this);WM_setSelected('eu');">Sélectionner<br/>toute l'Europe</div>
									<div id="EM_titre">CARTE DE L'EUROPE</div>
									<div id="map-europe" onclick="map_hide();">
										    <ul class="europe">
										<li class="eu1" onclick="choisirPays(this,'Albanie')"><a href="#albania">Albanie</a></li>
										<li class="eu2" onclick="choisirPays(this,'Andorre')"><a href="#andorra">Andorre</a></li>
										<li class="eu3" onclick="choisirPays(this,'Autriche')"><a href="#austria">Autriche</a></li>
										<li class="eu4" onclick="choisirPays(this,'Biélorussie')"><a href="#belarus">Biéolorussie</a></li>
										<li class="eu5" onclick="choisirPays(this,'Belgique')"><a href="#belgium">Belgique</a></li>
										<li class="eu6" onclick="choisirPays(this,'Bosnie-Herzégovine')"><a href="#bosnia-and-herzegovina">Bosnie-Herzégovine</a></li>
										<li class="eu7" onclick="choisirPays(this,'Bulgarie')"><a href="#bulgaria">Bulgarie</a></li>
										<li class="eu8" onclick="choisirPays(this,'Croatie')"><a href="#croatia">Croatie</a></li>
										<li class="eu9" onclick="choisirPays(this,'Chypre')"><a href="#cyprus">Chypre</a></li>
										<li class="eu10" onclick="choisirPays(this,'Tchèque (République)')"><a href="#czech-republic">République Tchèque</a></li>
										<li class="eu11" onclick="choisirPays(this,'Danemark')"><a href="#denmark">Danemark</a></li>
										<li class="eu12" onclick="choisirPays(this,'Estonie')"><a href="#estonia">Estonie</a></li>
										<li class="eu13" onclick="choisirPays(this,'France')"><a href="#france">France</a></li>
										<li class="eu14" onclick="choisirPays(this,'Finlande')"><a href="#finland">Finlande</a></li>
										<li class="eu15" onclick="choisirPays(this,'Géorgie')"><a href="#georgia">Géorgie</a></li>
										<li class="eu16" onclick="choisirPays(this,'Allemagne')"><a href="#germany">Allemagne</a></li>
										<li class="eu17" onclick="choisirPays(this,'Grèce')"><a href="#greece">Grèce</a></li>
										<li class="eu18" onclick="choisirPays(this,'Hongrie')"><a href="#hungary">Hongrie</a></li>
										<li class="eu19" onclick="choisirPays(this,'Islande')"><a href="#iceland">Islande</a></li>
										<li class="eu20" onclick="choisirPays(this,'Irlande')"><a href="#ireland">Irlande</a></li>
										<li class="eu21" onclick="choisirPays(this,'Saint-Marin')"><a href="#san-marino">Saint-Marin</a></li>
										<li class="eu22" onclick="choisirPays(this,'Italie')"><a href="#italy">Italie</a></li>
										<li class="eu23" onclick="choisirPays(this,'Kosovo')"><a href="#kosovo">Kosovo</a></li>
										<li class="eu24" onclick="choisirPays(this,'Lettonie')"><a href="#latvia">Lettonie</a></li>
										<li class="eu25" onclick="choisirPays(this,'Liechtenstein')"><a href="#liechtenstein">Liechtenstein</a></li>
										<li class="eu26" onclick="choisirPays(this,'Lituanie')"><a href="#lithuania">Lituanie</a></li>
										<li class="eu27" onclick="choisirPays(this,'Luxembourg')"><a href="#luxembourg">Luxembourg</a></li>
										<li class="eu28" onclick="choisirPays(this,'Macédoine')"><a href="#macedonia">Macédoine <abbr title="The Former Yugoslav Republic of Macedonia">(F.Y.R.O.M.)</abbr></a></li>
										<li class="eu29" onclick="choisirPays(this,'Malte et Gozo ')"><a href="#malta">Malte</a></li>
										<li class="eu30" onclick="choisirPays(this,'Moldavie')"><a href="#moldova">Moldavie</a></li>
										<li class="eu31" onclick="choisirPays(this,'Monaco')"><a href="#monaco">Monaco</a></li>
										<li class="eu32" onclick="choisirPays(this,'Monténégro')"><a href="#montenegro">Monténégro</a></li>
										<li class="eu33" onclick="choisirPays(this,'Pays-Bas')"><a href="#netherlands">Pays-Bas</a></li>
										<li class="eu34" onclick="choisirPays(this,'Norvège')"><a href="#norway">Norvège</a></li>
										<li class="eu35" onclick="choisirPays(this,'Pologne')"><a href="#poland">Pologne</a></li>
										<li class="eu36" onclick="choisirPays(this,'Portugal')"><a href="#portugal">Portugal</a></li>
										<li class="eu37" onclick="choisirPays(this,'Roumanie')"><a href="#romania">Roumanie</a></li>
										<li class="eu38" onclick="choisirPays(this,'Russie')"><a href="#russian-federation">Russie</a></li>
										<li class="eu39" onclick="choisirPays(this,'Serbie')"><a href="#serbia">Serbie</a></li>
										<li class="eu40" onclick="choisirPays(this,'Slovaquie')"><a href="#slovakia">Slovaquie</a></li>
										<li class="eu41" onclick="choisirPays(this,'Slovénie')"><a href="#slovenia">Slovénie</a></li>
										<li class="eu42" onclick="choisirPays(this,'Espagne')"><a href="#spain">Espagne</a></li>
										<li class="eu43" onclick="choisirPays(this,'Suède')"><a href="#sweden">Suède</a></li>
										<li class="eu44" onclick="choisirPays(this,'Suisse')"><a href="#switzerland">Suisse</a></li>
										<li class="eu45" onclick="choisirPays(this,'Turquie')"><a href="#turkey">Turquie</a></li>
										<li class="eu46" onclick="choisirPays(this,'Ukraine')"><a href="#ukraine">Ukraine</a></li>
										<li class="eu47" onclick="choisirPays(this,'Royaume-Uni')"><a href="#united-kingdom">Royaume-Uni</a></li>
										<!-- remove this comment and UK list item (above) to activate the United Kingdom countries
										<li class="eu48"><a href="#england">England</a></li>
										<li class="eu49"><a href="#isle-of-man">Isle of Man</a></li>
										<li class="eu50"><a href="#northern-ireland">Northern Ireland</a></li>
										<li class="eu51"><a href="#scotland">Scotland</a></li>
										<li class="eu52"><a href="#wales">Wales</a></li>
										-->
									</ul>
									</div>
								</div>
                                <table>
                                    <tr>
                                        <td>
                                            <div>
                                            <div id="francemap" >
                                                <img id="map" src="../imagemap/francedepartments.png" alt="france" width="275" height="281" border="0"/>
                                                <img id="department" src="../imagemap/blank.png" width="275" height="281" border="0" usemap="#Map" />
                                            </div>
                                            <map name="Map" id="theworldmapimage">
    <area shape="poly" id="29" coords="22,63,30,63,39,63,39,70,39,75,37,79,40,83,41,86,36,85,31,82,25,85,24,80,19,79"
        title="Finistère" class="cursor_link" onmouseover="show('finistere')" onmouseout="hide()"
        onclick="fillTextBox(29)" />
<area shape="poly" id="22" coords="41,61,46,58,51,63,54,69,61,65,64,67,64,72,64,75,59,77,58,78,55,80,47,77,42,79,39,76,38,63"
        title="Côtes-d'Armor" class="cursor_link" onmouseover="show('cotesdarmor')" onmouseout="hide()"
        onclick="fillTextBox(22)" />
<area shape="poly" id="56" coords="44,86,46,94,54,94,61,96,63,88,59,80,54,79,47,79,40,79,39,85"class="cursor_link" title="Morbihan"
        onmouseover="show('Morbihan')" onmouseout="hide()"
        onclick="fillTextBox(56)" />
<area shape="poly" id="35" coords="66,66,67,73,64,77,62,80,66,88,69,93,74,90,78,90,81,83,81,80,78,72,73,67,69,65"
        class="cursor_link" title="Ille-et-Vilaine"
        onmouseover="show('IlleetVilaine')" onmouseout="hide()"onclick="fillTextBox(35)" />
<area shape="poly" id="44" coords="65,92,62,96,58,98,56,101,64,105,63,110,69,112,76,112,82,108,77,102,83,100,81,92,73,91"
        class="cursor_link"title="Loire Atlantique"
        onmouseover="show('LoireAtlantique')" onmouseout="hide()"
        onclick="fillTextBox(44)"  />
<area shape="poly" id="50" coords="75,67,75,59,73,52,70,44,69,39,71,39,76,41,80,42,84,49,87,55,85,65,91,68,88,70,82,70"
        class="cursor_link"title="Manche"
        onmouseover="show('manche')" onmouseout="hide()" 
        onclick="fillTextBox(50)" />
<area shape="poly" id="53" coords="91,69,97,74,98,81,93,90,88,91,82,87,81,79,79,69,83,71"
        class="cursor_link" title="Mayenne"
        onmouseover="show('Mayenne')" onmouseout="hide()" 
        onclick="fillTextBox(53)" />
<area shape="poly" id="49" coords="87,91,81,87,79,92,84,97,81,103,83,109,89,110,97,109,101,105,101,98,101,96,94,92"
        class="cursor_link" title="Maine-et-Loire"
        onmouseover="show('MaineetLoire')" onmouseout="hide()"
        onclick="fillTextBox(49)" />
<area shape="poly" id="85" coords="64,110,66,116,70,120,74,128,81,128,88,124,88,114,85,109,79,107,76,113,69,111"
        class="cursor_link" title="Vendée"
        onmouseover="show('Vendee')" onmouseout="hide()" 
        onclick="fillTextBox(85)" />
<area shape="poly" id="17" coords="78,130,78,135,77,141,81,145,84,151,93,159,98,157,96,149,93,144,96,140,95,134,88,133,87,129,80,128"
        class="cursor_link" title="Charente-Maritime"
        onmouseover="show('CharenteMaritime')" onmouseout="hide()"
        onclick="fillTextBox(17)" />
<area shape="poly" id="33" coords="79,149,77,155,77,160,75,170,78,174,85,179,92,184,97,182,98,176,100,172,97,167,98,163,95,160,89,157,82,153"
        class="cursor_link" title="Gironde"
        onmouseover="show('Gironde')" onmouseout="hide()"
        onclick="fillTextBox(33)" />
<area shape="poly" id="40" coords="76,177,74,182,73,189,73,194,71,199,73,203,80,203,89,201,91,201,92,196,94,193,97,193,99,191,97,187,91,184,87,181,82,178,78,175"
        class="cursor_link" title="Landes"
        onmouseover="show('Landes')" onmouseout="hide()" 
        onclick="fillTextBox(40)" />
<area shape="poly" id="64" coords="92,218,91,222,86,221,80,218,74,217,71,215,69,212,69,210,67,208,66,207,68,202,70,201,73,203,80,204,86,203,89,200,92,201,95,203,96,206,96,210,93,213"
        class="cursor_link" title="Pyrénées-Atlantiques"
        onmouseover="show('PyreneesAtlantiques')" onmouseout="hide()"  
        onclick="fillTextBox(64)" />
<area shape="poly" id="65" coords="107,218,108,221,106,223,106,226,99,225,96,224,93,220,93,213,96,210,97,203,93,200,98,203,102,207,108,208,108,210,107,213"
        class="cursor_link" title="Hautes-Pyrénées"
        onmouseover="show('HautesPyrenees')" onmouseout="hide()" 
        onclick="fillTextBox(65)" />
<area shape="poly" id="32" coords="118,204,118,199,116,195,114,189,110,188,107,190,102,191,96,193,93,195,93,202,97,203,102,207,107,209,110,208,113,206"
        class="cursor_link" title="Gers"
        onmouseover="show('Gers')" onmouseout="hide()" 
        onclick="fillTextBox(32)" />
<area shape="poly" id="47" coords="113,188,115,185,116,182,116,177,114,174,110,172,106,173,104,172,103,172,101,173,99,176,96,184,98,187,101,190,104,191"
        class="cursor_link" title="Lot-Et-Garonne"
        onmouseover="show('LotEtGaronne')" onmouseout="hide()" 
        onclick="fillTextBox(47)" />
<area shape="poly" id="24" coords="121,160,120,154,117,151,114,149,111,148,108,150,106,154,102,158,98,160,97,165,100,170,102,173,105,173,110,175,114,175,119,179,119,174,124,172,124,166"
        class="cursor_link" title="Dordogne"
        onmouseover="show('Dordogne')" onmouseout="hide()" 
        onclick="fillTextBox(24)" />
<area shape="poly" id="16" coords="101,158,105,155,108,151,111,147,113,143,115,139,113,137,111,134,107,134,107,136,103,135,101,134,97,139,97,141,96,144,96,147,98,153"
        class="cursor_link" title="Charente"
        onmouseover="show('Charente')" onmouseout="hide()" 
        onclick="fillTextBox(16)" />
<area shape="poly" id="79" coords="98,122,99,127,101,132,100,137,98,138,94,137,90,134,85,131,82,127,88,124,88,116,87,112,95,112,98,112,98,115,100,118"
        class="cursor_link"title="Deux-Sèvres "
        onmouseover="show('DeuxSevres')" onmouseout="hide()" 
        onclick="fillTextBox(79)" />
<area shape="poly" id="14" coords="84,47,89,48,92,48,98,48,103,47,106,46,107,50,108,53,108,57,108,60,99,59,93,61,87,63,84,58,85,53"
        class="cursor_link"title="Calvados"
        onmouseover="show('valvados')" onmouseout="hide()" 
        onclick="fillTextBox(14)" />
<area shape="poly" id="61" coords="110,59,113,64,114,68,117,73,116,77,115,79,111,76,109,74,107,71,103,73,100,73,100,70,96,69,94,70,90,66,88,61,96,60,103,58"
        class="cursor_link" title="orne"
        onmouseover="show('Orne')" onmouseout="hide()"
        onclick="fillTextBox(61)" />
<area shape="poly" id="72" coords="104,72,108,75,112,80,114,80,114,85,113,90,109,92,104,95,100,93,95,90,94,84,96,79,95,70"
        class="cursor_link"title="Sarthe"
        onmouseover="show('Sarthe')" onmouseout="hide()" 
        onclick="fillTextBox(72)" />
<area shape="poly" id="37" coords="114,92,117,94,119,98,121,101,121,104,124,106,124,110,123,111,120,111,119,115,120,119,117,121,114,117,113,115,110,111,104,112,103,108,102,104,103,98,105,95,108,94"
        class="cursor_link" title="Indre-et-Loire"
        onmouseover="show('IndreetLoire')" onmouseout="hide()"
        onclick="fillTextBox(37)"  />
<area shape="poly" id="86" coords="120,122,122,125,121,130,119,129,117,135,112,135,106,133,103,125,100,117,99,111,100,105,104,111,109,112,112,116"
        class="cursor_link" title="Vienne"
        onmouseover="show('Vienne')" onmouseout="hide()"
        onclick="fillTextBox(86)"  />
<area shape="poly" id="76" coords="126,31,129,34,131,39,132,44,132,49,128,46,125,48,123,50,118,48,115,45,109,45,107,46,105,43,105,38,110,35,121,33,117,33"
        class="cursor_link"title="Seine-Maritime"
        onmouseover="show('SeineMaritime')" onmouseout="hide()"  
        onclick="fillTextBox(76)" />
<area shape="poly" id="27" coords="131,51,129,54,127,58,127,61,124,63,116,66,114,61,109,55,109,50,109,46,113,45,122,47,126,47"
        class="cursor_link" title="Eure"
        onmouseover="show('Eure')" onmouseout="hide()" 
        onclick="fillTextBox(27)" />
<area shape="poly" id="28" coords="127,63,132,72,131,77,133,80,135,81,134,87,127,90,120,90,115,85,114,78,114,71,118,66"
        class="cursor_link"title="Eure-Et-Loir"
        onmouseover="show('EureEtLoir')" onmouseout="hide()"  
        onclick="fillTextBox(28)" />
<area shape="poly" id="41" coords="128,86,129,90,131,92,135,93,141,94,141,96,139,100,137,106,131,104,127,104,122,102,120,97,116,94,113,91,114,87,115,82,116,80,120,82,123,84"
        class="cursor_link"title="Loir-et-Cher"
        onmouseover="show('LoiretCher')" onmouseout="hide()" 
        onclick="fillTextBox(41)" />
<area shape="poly" id="36" coords="124,104,128,104,132,106,133,108,136,107,137,110,139,116,140,119,140,123,140,126,139,127,133,126,131,127,126,128,122,128,120,124,119,118,120,112"
        class="cursor_link" title="Indre"
        onmouseover="show('Indre')" onmouseout="hide()"
        onclick="fillTextBox(36)"  />
<area shape="poly" id="87" coords="125,131,126,134,127,136,129,138,132,142,133,145,134,147,134,148,131,151,128,153,125,155,123,155,120,152,118,150,113,149,112,147,114,142,115,140,114,137,118,133,120,131"
        class="cursor_link" title="Haute-Vienne"
        onmouseover="show('HauteVienne')" onmouseout="hide()"
        onclick="fillTextBox(87)"  />
<area shape="poly" id="19" coords="125,153,123,156,124,160,128,163,130,164,132,164,134,164,136,164,139,163,139,162,140,160,140,157,142,154,143,153,146,151,146,148,146,146,142,146,140,146,137,146,132,145,130,147"
        class="cursor_link" title="Corrèze"
        onmouseover="show('Correze')" onmouseout="hide()" 
        onclick="fillTextBox(19)" />
<area shape="poly" id="23" coords="132,144,132,141,128,139,127,136,125,134,124,127,131,128,138,127,140,128,143,130,145,134,146,138,145,142,145,144,142,145,138,145"
        class="cursor_link" title="Creuse"
        onmouseover="show('Creuse')" onmouseout="hide()" 
        onclick="fillTextBox(23)" />
 
<area shape="poly" id="46" coords="124,169,123,173,119,178,119,181,121,184,125,186,130,186,134,185,133,179,136,177,138,171,137,167,131,166,126,166"
        class="cursor_link" title="Lot"
        onmouseover="show('Lot')" onmouseout="hide()"
        onclick="fillTextBox(46)"  />
<area shape="poly" id="82" coords="117,179,116,184,116,187,114,192,115,195,117,199,119,203,119,200,123,197,126,195,130,192,131,190,133,188,133,185,129,185,123,184,120,183,118,180"
        class="cursor_link" title="Tarn-et-Garonne"
        onmouseover="show('TarnetGaronne')" onmouseout="hide()"
        onclick="fillTextBox(31)" />
<area shape="poly" id="31" coords="126,197,130,202,132,203,135,206,135,208,134,209,127,212,123,212,119,214,115,217,115,221,115,222,112,222,110,220,109,216,108,216,108,210,108,208,109,207,114,206,115,205,116,201,118,200,119,198,121,197"
        class="cursor_link" title="Haute-Garonne"
        onmouseover="show('HauteGaronne')" onmouseout="hide()"
        onclick="fillTextBox(09)" />
<area shape="poly" id="62" coords="141,6,143,9,146,13,148,15,154,16,156,20,158,26,159,32,151,30,143,28,137,24,132,21,132,11,135,7"
        class="cursor_link" title="Pas-de-Calais"
        onmouseover="show('PasdeCalais')" onmouseout="hide()" 
        onclick="fillTextBox(62)" />
<area shape="poly" id="59" coords="138,4,143,3,147,4,147,9,151,11,155,11,158,14,161,17,163,19,167,21,170,23,173,26,174,29,168,30,159,30,153,24,151,16,144,13,139,9"
        class="cursor_link" title="Nord"
        onmouseover="show('Nord')" onmouseout="hide()"
        onclick="fillTextBox(59)"  />
<area shape="poly" id="80" coords="126,30,128,26,128,21,133,24,138,27,144,27,151,31,155,34,154,38,148,41,139,40,134,38,129,35"
        class="cursor_link" title="Somme"
        onmouseover="show('Somme')" onmouseout="hide()" 
        onclick="fillTextBox(80)" />
 
<area shape="poly" id="45" coords="132,89,135,85,137,80,139,78,144,78,149,81,153,83,155,87,154,93,151,97,146,97,139,94"
        class="cursor_link" title="Loiret"
        onmouseover="show('Loiret')" onmouseout="hide()"
        onclick="fillTextBox(45)"  />
<area shape="poly" id="18" coords="139,117,138,111,137,106,139,99,142,94,150,98,152,103,153,109,155,115,152,119,146,120,147,122,143,125,142,126"
            class="cursor_link" title="Cher"
        onmouseover="show('Cher')" onmouseout="hide()"
        onclick="fillTextBox(18)" />
<area shape="poly" id="03" coords="141,127,144,131,147,134,149,133,155,135,162,136,168,138,169,131,171,128,167,122,164,119,158,120,155,118,149,120,147,122" 
        class="cursor_link"title="Allier"
        onmouseover="show('Allier')" onmouseout="hide()"
        onclick="fillTextBox(03)"  />
<area shape="poly" id="63" coords="147,134,147,139,146,143,146,148,146,151,149,155,155,156,159,154,165,155,170,155,172,150,168,143,166,137,159,137,152,135" 
        class="cursor_link" title="Puy-de-Dôme"
        onmouseover="show('PuydeDome')" onmouseout="hide()"
        onclick="fillTextBox(63)" />
<area shape="poly" id="60" coords="155,38,151,40,148,43,143,41,135,39,133,43,134,49,136,52,140,53,147,54,151,56,155,56,154,51,154,44" 
        class="cursor_link"title="Oise"
        onmouseover="show('Oise')" onmouseout="hide()"
        onclick="fillTextBox(60)"  />
<area shape="poly" id="15" coords="156,155,152,155,148,153,144,151,142,156,140,161,136,164,139,169,141,172,146,169,150,165,153,169,157,165,160,161,157,157" 
            class="cursor_link"title="Cantal"
        onmouseover="show('Cantal')" onmouseout="hide()"
        onclick="fillTextBox(15)" />
<area shape="poly" id="43" coords="175,155,171,157,166,157,160,156,159,160,162,165,164,168,168,170,174,169,177,165,180,160,178,155"  
            class="cursor_link"title="Haute-Loire"
        onmouseover="show('HauteLoire')" onmouseout="hide()"
        onclick="fillTextBox(43)" />
<area shape="poly" id="12" coords="150,168,146,171,145,174,141,175,136,178,135,182,138,187,144,189,147,195,154,198,160,193,157,185,154,173"  
            class="cursor_link"title="Aveyron"
        onmouseover="show('Aveyron')" onmouseout="hide()"
        onclick="fillTextBox(12)" />
<area shape="poly" id="81" coords="144,193,141,189,137,187,135,189,130,193,127,197,132,202,137,206,143,206,147,206,149,202,153,199,147,196"  
            class="cursor_link"title="Tarn"
        onmouseover="show('Tarn')" onmouseout="hide()"
        onclick="fillTextBox(81)" />
<area shape="poly" id="09" coords="130,212,125,212,120,214,117,218,118,223,122,226,127,228,132,228,136,226,133,223,135,218,131,215"  
            class="cursor_link"title="Ariège"
        onmouseover="show('Ariege')" onmouseout="hide()"
        onclick="fillTextBox(09)" />
<area shape="poly" id="66" coords="131,229,132,231,137,235,141,233,146,236,151,233,157,232,155,227,155,220,148,222,142,224,136,227"  
            class="cursor_link"title="Pyrénées-Orientales"
        onmouseover="show('PyreneesOrientales')" onmouseout="hide()"
        onclick="fillTextBox(66)" />
<area shape="poly" id="11" coords="148,210,145,208,140,207,136,209,132,211,134,214,136,218,135,223,137,225,142,223,150,222,154,220,157,212,151,209"  
            class="cursor_link"title="Aude"
        onmouseover="show('Aude')" onmouseout="hide()"
        onclick="fillTextBox(11)"/>
<area shape="poly" id="34" coords="160,194,158,198,153,200,149,204,148,209,151,209,157,211,162,211,166,208,173,204,177,201,173,196,169,192,162,195"  
            class="cursor_link"title="Hérault"
        onmouseover="show('Herault')" onmouseout="hide()"
        onclick="fillTextBox(34)" />
<area shape="poly" id="30" coords="182,182,179,184,175,182,173,186,169,189,164,189,160,188,162,194,169,193,173,197,177,201,179,204,182,200,185,196,187,192,186,187" 
            class="cursor_link"title="Gard"
        onmouseover="show('Gard')" onmouseout="hide()"
        onclick="fillTextBox(30)" />
<area shape="poly" id="48" coords="167,170,163,168,159,167,157,171,156,176,158,181,160,185,163,187,169,188,172,187,172,180,170,173"  
            class="cursor_link"title="Lozère"
        onmouseover="show('Lozere')" onmouseout="hide()"
        onclick="fillTextBox(48)" />
<area shape="poly" id="02" coords="173,31,170,32,166,32,161,32,156,33,157,39,157,43,156,48,156,52,157,57,160,61,162,60,163,57,164,52,168,49,170,48,170,42,173,39,173,34" 
            class="cursor_link"title="Aisne"
        onmouseover="show('Aisne')" onmouseout="hide()"
        onclick="fillTextBox(02)" />
<area shape="poly" id="08" coords="185,35,184,31,184,27,181,33,178,33,173,34,174,39,173,43,173,47,176,48,180,51,185,51,189,46,189,42,189,39,187,36"  
            class="cursor_link"title="Ardennes"
        onmouseover="show('Ardennes')" onmouseout="hide()"
        onclick="fillTextBox(08)" />
<area shape="poly" id="51" coords="179,51,175,50,173,48,169,50,165,53,165,57,164,61,162,63,164,67,167,71,171,66,177,67,181,70,185,67,186,62,187,58,187,54,183,52"  
            class="cursor_link"title="Marne"
        onmouseover="show('Marne')" onmouseout="hide()"
        onclick="fillTextBox(51)" />
<area shape="poly" id="10" coords="182,71,179,70,175,68,171,69,169,71,164,71,163,73,165,77,168,80,170,84,175,85,179,84,183,81,185,77,182,74" 
            class="cursor_link"title="Aube"
        onmouseover="show('Aube')" onmouseout="hide()"
        onclick="fillTextBox(10)" />
<area shape="poly" id="52" coords="195,73,193,71,189,69,187,66,183,69,185,74,186,78,186,81,186,84,190,88,190,92,194,93,198,92,201,90,202,86,200,82,199,78,196,77"  
            class="cursor_link"title="Haute-Marne"
        onmouseover="show('HauteMarne')" onmouseout="hide()"
        onclick="fillTextBox(52)" />
<area shape="poly" id="89" coords="169,84,166,80,162,76,158,74,155,77,155,83,156,86,156,92,155,95,158,96,163,96,168,99,173,101,173,96,175,92,175,87,172,85"  
            class="cursor_link"title="Yonne"
        onmouseover="show('Yonne')" onmouseout="hide()"
        onclick="fillTextBox(89)" />
<area shape="poly" id="21" coords="192,93,188,93,188,88,186,85,182,84,177,86,177,91,175,96,175,100,174,105,178,108,184,111,189,112,194,112,196,108,197,103,196,98,194,94" 
            class="cursor_link"title="Côte-d'Or"
        onmouseover="show('CotedOr')" onmouseout="hide()"
        onclick="fillTextBox(21)" />
<area shape="poly" id="58" coords="175,107,173,104,169,101,164,99,158,98,152,97,153,102,155,107,156,114,154,118,158,120,162,119,166,119,170,119,172,116,173,110"  
            class="cursor_link"title="Nièvre"
        onmouseover="show('Nievre')" onmouseout="hide()"
        onclick="fillTextBox(58)" />
<area shape="poly" id="71" coords="186,114,182,112,178,109,174,111,173,116,171,119,167,120,168,123,171,126,171,131,175,133,180,131,184,131,188,127,190,124,195,126,196,121,196,114,191,112" 
            class="cursor_link"title="Saône-et-Loire"
        onmouseover="show('SaoneetLoire')" onmouseout="hide()"
        onclick="fillTextBox(71)" />
<area shape="poly" id="55" coords="192,40,194,44,198,47,200,53,202,59,201,64,201,70,196,73,193,70,189,67,187,60,187,52,189,46"  
            class="cursor_link"title="Meuse"
        onmouseover="show('Meuse')" onmouseout="hide()"
        onclick="fillTextBox(55)" />
<area shape="poly" id="54" coords="205,50,203,47,202,44,198,43,199,48,201,50,202,56,203,60,201,64,202,68,205,72,208,71,213,72,216,71,220,72,223,69,218,66,213,64,208,60,205,56"  
            class="cursor_link"title="Meurthe-et-Moselle"
        onmouseover="show('MeurtheetMoselle')" onmouseout="hide()"
        onclick="fillTextBox(54)" />
<area shape="poly" id="57" coords="226,53,222,51,217,51,214,48,211,44,207,44,203,44,205,49,207,53,207,57,210,60,213,63,217,65,222,68,225,67,226,63,223,60,223,57,226,56,230,57,231,53,228,52"  
            class="cursor_link"title="Moselle"
        onmouseover="show('Moselle')" onmouseout="hide()"
        onclick="fillTextBox(57)" />
<area shape="poly" id="88" coords="224,70,219,73,212,72,205,72,201,72,197,74,198,77,201,78,201,82,203,86,207,83,211,84,216,85,219,86,222,85,223,79,224,74"  
            class="cursor_link"title="Vosges"
        onmouseover="show('Vosges')" onmouseout="hide()"
        onclick="fillTextBox(88)" />
<area shape="poly" id="67" coords="242,55,238,54,233,54,230,57,226,57,223,59,226,61,227,65,227,67,225,70,226,73,230,75,233,78,235,72,236,66,239,61,242,58"  
            class="cursor_link"title="Bas-Rhin"
        onmouseover="show('BasRhin')" onmouseout="hide()"
        onclick="fillTextBox(67)" />
<area shape="poly" id="68" coords="233,80,230,76,225,74,224,79,223,84,222,87,224,89,225,93,228,95,230,98,232,94,233,87,233,82"  
            class="cursor_link"title="Haut-Rhin"
        onmouseover="show('HautRhin')" onmouseout="hide()"
        onclick="fillTextBox(68)" />
<area shape="poly" id="90" coords="220,88,221,92,223,96,226,96,225,92,224,89,223,86"  
            class="cursor_link"title="Territoire de Belfort"
        onmouseover="show('TerritoiredeBelfort')" onmouseout="hide()"
        onclick="fillTextBox(90)" />
<area shape="poly" id="70" coords="221,91,220,86,215,86,209,84,204,87,202,91,199,92,196,94,198,99,200,103,203,103,207,100,211,98,215,94,219,94,222,93"  
            class="cursor_link"title="Haute-Saône"
        onmouseover="show('HauteSaone')" onmouseout="hide()"
        onclick="fillTextBox(70)"  />
<area shape="poly" id="25" coords="223,101,224,98,221,96,216,96,212,99,208,101,204,102,203,104,204,109,207,111,209,114,211,117,210,119,210,122,212,118,215,115,216,111,219,107,223,104"  
            class="cursor_link"title="Doubs"
        onmouseover="show('Doubs')" onmouseout="hide()"
        onclick="fillTextBox(25)"  />
<area shape="poly" id="39" coords="210,119,209,114,207,112,204,109,203,106,201,104,197,101,197,106,195,110,195,114,197,118,197,122,197,126,198,129,201,128,204,127,206,128,208,126,208,122"  
            class="cursor_link"title="Jura"
        onmouseover="show('Jura')" onmouseout="hide()"
        onclick="fillTextBox(39)" />
<area shape="poly" id="01" coords="207,133,208,131,210,128,208,127,205,128,202,129,198,130,195,126,192,126,189,127,186,130,187,134,187,137,189,139,192,142,196,140,199,142,202,146,205,142,207,136"  
            class="cursor_link"title="Ain"
        onmouseover="show('Ain')" onmouseout="hide()"
        onclick="fillTextBox(01)"  />
<area shape="poly" id="74" coords="223,131,223,127,218,126,214,129,212,133,208,134,208,138,208,141,213,144,217,139,221,141,225,140,228,137,225,134"  
            class="cursor_link"title="Haute-Savoie"
        onmouseover="show('HauteSavoie')" onmouseout="hide()"
        onclick="fillTextBox(74)" />
<area shape="poly" id="73" coords="227,147,224,145,221,143,218,141,216,144,212,144,208,142,205,144,203,148,208,150,213,152,213,156,214,160,220,160,224,158,229,156,230,152"  
            class="cursor_link"title="Savoie"
        onmouseover="show('Savoie')" onmouseout="hide()"
        onclick="fillTextBox(73)" />
<area shape="poly" id="38" coords="212,158,212,154,211,152,206,152,203,148,200,145,197,143,193,144,192,147,188,150,188,154,191,156,195,158,196,162,199,162,202,166,203,169,206,171,208,167,211,167,215,165,211,161"  
            class="cursor_link"title="Isère"
        onmouseover="show('Isere')" onmouseout="hide()"
        onclick="fillTextBox(38)" />
<area shape="poly" id="26" coords="203,172,201,169,200,165,198,163,194,161,194,159,191,157,188,157,189,161,190,164,190,169,188,171,188,176,187,180,186,184,189,182,193,181,195,183,198,184,200,187,204,185,202,182,200,180,201,176"  
            class="cursor_link"title="Drôme"
        onmouseover="show('Drome')" onmouseout="hide()"
        onclick="fillTextBox(26)"  />
<area shape="poly" id="07" coords="187,154,187,159,190,164,190,169,187,172,187,177,185,182,180,183,174,182,172,180,171,175,170,171,174,170,178,166,180,163,181,159,183,160,185,158"  
            class="cursor_link"title="Ardeche"
        onmouseover="show('Ardeche')" onmouseout="hide()"
        onclick="fillTextBox(07)"  />
<area shape="poly" id="42" coords="180,134,178,133,175,134,171,133,170,137,168,140,170,143,171,146,172,150,172,154,175,154,178,155,181,157,184,157,185,154,183,151,181,149,179,145,178,140"  
            class="cursor_link"title="Loire"
        onmouseover="show('Loire')" onmouseout="hide()"
        onclick="fillTextBox(42)"  />
<area shape="poly" id="69" coords="187,139,186,136,185,132,181,132,181,136,179,139,180,143,181,147,184,150,187,148,190,147,191,144,188,142"  
            class="cursor_link"title="Rhone"
        onmouseover="show('Rhone')" onmouseout="hide()"
        onclick="fillTextBox(69)" />
<area shape="poly" id="05" coords="207,171,204,174,204,178,202,179,204,182,207,183,208,179,212,178,214,176,218,176,221,176,224,173,227,171,230,170,229,167,225,166,223,164,221,162,217,162,213,162,214,166,210,168"  
            class="cursor_link"title="Hautes-Alpes"
        onmouseover="show('HautesAlpes')" onmouseout="hide()"
        onclick="fillTextBox(05)" />
<area shape="poly" id="04" coords="227,178,227,174,228,172,225,173,223,176,219,177,213,179,210,181,208,184,206,184,203,187,204,190,205,193,208,196,213,197,216,195,220,195,223,195,226,191,224,188,224,183,226,180"  
            class="cursor_link"title="Alpes-de-Haute-Provence"
        onmouseover="show('AlpesdeHauteProvence')" onmouseout="hide()"
        onclick="fillTextBox(04)"  />
<area shape="poly" id="06" coords="236,186,233,185,229,183,227,180,226,184,226,188,227,192,226,195,228,198,230,201,233,198,236,196,238,193,240,191,242,186,241,183,238,185"  
            class="cursor_link"title="Alpes-Maritimes"
        onmouseover="show('AlpesMaritimes')" onmouseout="hide()"
        onclick="fillTextBox(06)"  />
<area shape="poly" id="83" coords="229,202,227,200,225,197,222,196,218,196,215,198,210,198,207,199,207,203,207,207,207,211,210,214,214,213,216,212,221,211,223,209,227,204"  
            class="cursor_link"title="Var"
        onmouseover="show('Var')" onmouseout="hide()"
        onclick="fillTextBox(83)" />
<area shape="poly" id="13" coords="206,211,206,206,205,201,201,200,197,198,192,196,189,194,186,197,184,200,182,202,180,204,185,206,189,207,193,207,192,203,196,204,198,207,201,210"  
            class="cursor_link"title="Bouches-du-Rhône"
        onmouseover="show('BouchesduRhone')" onmouseout="hide()"
        onclick="fillTextBox(13)" />
<area shape="poly" id="84" coords="206,195,203,193,203,189,203,187,201,188,197,186,194,184,191,184,188,185,188,189,189,192,192,194,196,196,200,198,204,198"  
            class="cursor_link"title="Vaucluse"
        onmouseover="show('Vaucluse')" onmouseout="hide()"
        onclick="fillTextBox(84)" />
<area shape="poly" id="2B" coords="247,211,247,207,246,203,244,207,243,211,240,210,239,214,235,215,233,219,237,222,240,225,244,228,247,233,249,229,250,222,248,215"  
            class="cursor_link"title="Haute-Corse"
        onmouseover="show('HauteCorse')" onmouseout="hide()"
        onclick="fillTextBox('2B')"  />
<area shape="poly" id="2A" coords="247,235,245,232,243,228,239,226,236,223,233,223,233,228,235,231,236,235,237,238,238,241,242,244,245,245,246,240"  
            class="cursor_link"title="Corse-du-Sud"
        onmouseover="show('CorseduSud')" onmouseout="hide()"
        onclick="fillTextBox('2A')"  />
<area shape="poly" id="750" coords="132,51,130,55,128,59,128,64,131,68,132,75,134,80,139,77,144,78,148,81,152,80,154,75,159,74,161,70,160,64,159,60,155,57,152,56,141,53,137,53"
        class="cursor_link" title="Île-de-France"
        onmouseover="show('IledeFrance')" onmouseout="hide()"
        onclick="zsregister()"   />
<area shape="poly" id="D1" coords="40,263,39,261,36,259,35,257,34,254,31,251,27,250,24,250,21,251,19,253,17,255,15,258,17,261,18,265,21,268,25,270,29,271,33,271,37,270,38,267" class="cursor_link"onclick="domtom()" />
<area shape="poly" id="D2" coords="87,256,83,253,79,249,75,246,70,244,66,244,64,247,61,251,62,255,63,259,66,262,65,266,65,269,64,271,63,274,65,276,68,274,73,274,76,275,78,271,80,267,83,263,86,260" class="cursor_link"onclick="domtom()"/>
<area shape="poly" id="D3" coords="125,260,126,258,124,257,120,254,117,252,113,250,110,252,111,257,113,260,115,263,119,264,120,268,118,269,118,272,124,272,128,274,130,272,128,267,125,264" class="cursor_link" onclick="domtom()"/>
<area shape="poly" id="D4" coords="160,258,157,257,155,256,152,255,153,261,153,264,153,267,155,271,158,271,161,268,161,263,164,261,168,260,172,259,175,259,171,256,169,253,167,250,164,248,164,253,163,256" class="cursor_link"onclick="domtom()" /></map>
                                            <div id="zsreg" class="reg_tab"  >
                                                <div id="ildefrance">
                                                    <img id="paris" src="../imagemap/ile_de_france.png" width="150" height="114" border="0" />
                                                    <img id="departmentparis" src="../imagemap/blank1.png"  width="150" height="114" border="0" usemap="#Map2" />
   
                                                </div> 
                                                <map name="Map2" id="Map2">  

            <area shape="circle" coords="8,7,8" alt="close" title="close" href="javascript:;" onclick="closeildefance();" />
            <area shape="poly" id="78" coords="10,24,12,30,14,36,17,42,19,51,18,57,20,63,27,67,32,76,35,80,42,73,46,67,47,57,55,51,54,45,57,36,53,31,43,27,37,25,29,22,17,21" class="cursor_link"  title="Yvelines" onmouseover="showparis('Yvelines')" onmouseout="hideparis()"
                        onclick="fillTextBox(78)" />
            <area shape="poly" id="95" coords="21,19,23,14,25,7,29,11,37,13,44,12,48,9,55,13,60,13,65,12,74,17,81,20,79,26,74,31,68,32,62,32,60,34,57,33,29,23,38,26,45,28" class="cursor_link"title="Val-d'Oise" onmouseover="showparis('ValdOise')" onmouseout="hideparis()"
                        onclick="fillTextBox(95)" />
            <area shape="poly" id="77" coords="83,21,81,27,84,34,83,41,82,47,83,51,80,59,80,65,78,72,79,81,76,88,72,92,75,100,77,108,86,110,98,109,108,105,111,94,114,88,125,88,135,86,139,77,141,69,145,63,139,50,140,46,136,40,126,32,117,20,96,20" class="cursor_link"title="Seine-et-Marne" onmouseover="showparis('SeineetMarne')" onmouseout="hideparis()"
                        onclick="fillTextBox(77)" />
            <area shape="poly" id="91" coords="40,77,42,86,45,95,53,96,59,91,66,93,73,91,78,81,78,70,78,61,77,54,63,52,57,48,49,57" class="cursor_link"title="Essonne" onmouseover="showparis('Essonne')" onmouseout="hideparis()"
                        onclick="fillTextBox(91)"/>
            <area shape="poly" id="93" coords="67,34,70,38,74,43,80,42,82,33,80,27,73,30" class="cursor_link" title="Seine-Saint-Denis" onmouseover="showparis('SeineSaintDenis')" onmouseout="hideparis()"
                        onclick="fillTextBox(93)"/>
            <area shape="poly" id="94" coords="67,47,66,51,72,53,80,57,81,52,82,45,82,37,76,45,70,45" class="cursor_link" title="Val-de-Marne" onmouseover="showparis('ValdeMarne')" onmouseout="hideparis()"
                        onclick="fillTextBox(94)"/>
            <area shape="poly" id="92" coords="67,33,63,32,58,34,56,39,54,44,57,50,65,52,65,48,62,44,61,39,66,35" class="cursor_link"title="Hauts-de-Seine" onmouseover="showparis('HautsdeSeine')" onmouseout="hideparis()"
                        onclick="fillTextBox(92)"/>
            <area shape="poly" id="75" coords="63,38,62,43,64,48,71,46,73,42,70,38,66,35" class="cursor_link" title="Paris" onmouseover="showparis('Paris')" onmouseout="hideparis()"
                        onclick="fillTextBox(75)"/>
            </map>
                                            </div>
                                            <div id="domtommap" class="reg_tab" >
                                                <div id="domtom">
                                                    <img id="domtomcarte"src="../imagemap/domtom.png" width="235" height="280" border="0"/>
                                                    <img id="departmentdomtom"src="../imagemap/blank2.png" width="235" height="280"border="0" usemap="#Map3"/>
                                                </div>
                                                <map name="Map3" id="map3">
                <area shape="circle" coords="13,8,10" class="cursor_link" title="close" onclick="closedomtom()" />
                <area shape="poly"  coords="62,27,70,42,78,53,73,61,59,55,50,44,38,19,51,24" class="cursor_link" title="Martinique"onmouseover="showdomtom('Martinique')" onmouseout="hidedomtom()"
                            onclick="fillTextBox(972)"/>
                <area shape="poly" coords=="124,24,135,31,144,42,140,52,124,54,111,43,109,27" class="cursor_link"title="Réunion"onmouseover="showdomtom('Reunion')" onmouseout="hidedomtom()"
                            onclick="fillTextBox(974)"/>
                <area shape="poly"  coords="176,36,167,35,172,61,182,53,181,39,199,40,195,37,191,23,186,36" class="cursor_link" title="Guadeloupe"onmouseover="showdomtom('Guadeloupe')" onmouseout="hidedomtom()"
                            onclick="fillTextBox(971)"/>
                <area shape="poly"  coords="58,98,74,107,65,130,52,132,51,117,44,101" class="cursor_link" title="Guyane"onmouseover="showdomtom('Guyane')" onmouseout="hidedomtom()"
                            onclick="fillTextBox(973)"/>
                <area shape="poly" coords="113,92,116,105,109,128,132,132,123,103,118,95" class="cursor_link"title="Saint-Pierre et-Miquelon" onmouseover="showdomtom('SaintPierreetMiquelon')" onmouseout="hidedomtom()"
                            onclick="fillTextBox(975)"/>
                <area shape="poly" coords="181,118,177,96,195,102,193,127,176,132"  class="cursor_link" title="Mayotte" onmouseover="showdomtom('Mayotte')" onmouseout="hidedomtom()"
                            onclick="fillTextBox(976)"/>
                <area shape="poly" coords="53,171,46,179,31,171,39,188,62,197,71,168"class="cursor_link" title="Saint Martin"onmouseover="showdomtom('SaintMartin')" onmouseout="hidedomtom()"
                            onclick="fillTextBox(978)"/>
                <area shape="poly" coords="114,190,97,169,117,181,127,171,139,183,126,191" class="cursor_link" title="Saint-Barthélémy"onmouseover="showdomtom('SaintBarthelemy')" onmouseout="hidedomtom()"
                            onclick="fillTextBox(977)"/>
                <area shape="poly" coords="167,166,184,190,217,197,206,168" class="cursor_link" title="Nouvelle-Calédonie"onmouseover="showdomtom('NouvelleCaledonie')" onmouseout="hidedomtom()"
                            onclick="fillTextBox(988)"/>
                <area shape="poly" coords="141,234,140,259,180,263,185,242,159,228" class="cursor_link" title="Polynésie Française"onmouseover="showdomtom('PolynesieFrancaise')" onmouseout="hidedomtom()"
                            onclick="fillTextBox(987)"/>
                </map>
                                            </div>
                                            <div style="clear:both"></div>
                                        </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="clear:both"></div>
                        </div>
					</td>
				</tr>
			</table>
		</div>
		</div>

		<!-- MENU 1 -->
        <div style='background-color:white; min-height:100px;'>
			<br/><br/>
			<center>
				<div>
                        <a href="./Recherche_agent.aspx" style='color:black;display:inline-block; cursor:pointer'>
					        <img style='margin-bottom:-6px;' src='../img_site/new_search/agent.png' alt='agent'/>
					        <div class='texte_menu_footer'>Trouvez <br/>un agent</div>
                        </a>
                        <a href="./vendre_estimer.aspx" style='color:black;display:inline-block; cursor:pointer'>
					        <img style='margin-bottom:-6px;' src='../img_site/new_search/estimer.png' alt='estimer'/>
					        <div class='texte_menu_footer'>Estimez <br/>votre bien</div>
					    </a>
                        <a href="./recrutement.aspx" style='color:black;display:inline-block; cursor:pointer'>
                            <img style='margin-bottom:-6px;' src='../img_site/new_search/equipe.png' alt='recrutement'/>
					        <div class='texte_menu_footer'>Rejoignez <br/>notre équipe</div>
					    </a>
                        <a href="./partenaires.aspx" style='color:black;display:inline-block; cursor:pointer'>
                            <img style='margin-bottom:-6px;' src='../img_site/new_search/partenaires.png' alt='partenaires'/>
					        <div class='texte_menu_footer'>Nos <br/>partenaires</div>
					    </a>
                        <div onclick='show_vid()' style='display:inline-block; cursor:pointer'>
                            <img style='margin-bottom:-6px;' src='../img_site/new_search/reseau_2.png' alt='video'/>
					        <div class='texte_menu_footer'>Notre <br/>Réseau</div>
					    </div>
				    </div>
			</center>
			<br/><br/>
		</div>
        <!-- RECRUTEMENT -->
        <div class='bloc_infos' >
		    <br/>
		    <table>
			    <tr>
			        <td width='43%'>
				        <center>
					        <font style='font-size:20px;color:#31536c;'><strong>Rejoignez l'équipe PATRIMO et devenez agent immobilier indépendant dans un reseau en plein développement !</strong></font>
				        </center>
			        </td>
			        <td width='14%'>
				        <br/>
                        <a href="./recrutement.aspx" style=' cursor:pointer'>
				            <img alt="recrutement" src='../img_site/new_search/reseau.png' style='width:100%;'/>
                        </a>
				        <br/><br/>
			        </td>
			        <td width='43%'>
			            <center>
			                <font style='font-size:18px;color:#31536c;'>
                            <strong>
			                Nous offrons la meilleure rénumération du marché.<br/>
			                Developpez rapidement votre propre réseau de filleuls.<br/>
			                Une formation et un suivi gratuit et personnalisé.<br/>
			                </strong>
                            </font>
			            </center>
			        </td>
			    </tr>
		    </table>
		    <br/>	
		</div>
        <!-- EXCLUSIVITES -->
        <div style='background-color:white; min-height:400px; width:100%; '>
		    <center>
                <br/>
		        <strong>NOS DERNIERES EXCLUSIVITES</strong>
		        <br/><br/>
                 <asp:Label ID="LBL_Exclu" style="color:Black" runat="server"/>
		        <br/>
		        <br/><br/>
            </center>
		</div>

        <!-- INFOS PATRIMO -->
		<div class='bloc_infos' >
		    <br/><br/>
		    <table>
		        <tr>
		            <td width="200px">
			            <center>
			                <img src='../img_site/logo_patrimo.jpg' style='border: 2px solid darkgrey' width='115px'>
			            </center>
		            </td>
		            <td>
			            <div class='patrimo_info'>	
			            PATRIMO a été fondé par Olivier SAGLIO, ancien ingénieur diplômé de l'ENSAM PARISTECH ayant plus de 15 ans d'expérience dans les métiers de l'informatique et de l'immobilier.
			            </div>	
			            <div class='patrimo_info'>
			            Ayant débuté comme agence à Bois-Colombes, PATRIMO se développe désormais en tant que réseau immobilier partout en France et à l'étranger.
			            </div>
			            <div class='patrimo_info'>
			            PATRIMO entend porter une autre image des affaires, où l’on peut être fier de réussir et de gagner de l’argent, tout en n’oubliant pas ceux à qui la vie a moins réussi.
			            </div>
		            </td>
		        </tr>
		    </table>
			
		    <br/><br/>
		</div>
     
      <!--Des choses invisibles -->
     <div class="invisible"  >
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:TextBox runat="server" ID="HiddenField3" class="invisible" Text="" />
                <div class="invisible">
			        <% //Les actions faites ici ne rafraichissent pas la page, wtf%>
			        <asp:Button runat="server" id="ButtonEmpty" CssClass="invisible" onclick="clear2"></asp:Button>
			        <asp:Button runat="server" ID="BouttonAjaxEuropeMap" OnClick="ajouterPays" />
                    <asp:TextBox runat="server" ID="TBAjaxEuropeMap"></asp:TextBox>
			        <asp:Button runat="server" ID="BouttonAjaxWorldMap2" OnClick="supprimerContinent" />
                    <asp:TextBox runat="server" ID="TBAjaxWorldMap2"></asp:TextBox>
			        <asp:Button runat="server" ID="BouttonAjaxWorldMap" OnClick="ajouterContinent" />
                    <asp:TextBox runat="server" ID="TBAjaxWorldMap"></asp:TextBox>
                    <asp:Button runat="server" ID="BouttonAjaxMap" OnClick="ajouterDepartement" />
                    <asp:TextBox runat="server" ID="TBAjaxMap"></asp:TextBox>
                </div>                   
            </ContentTemplate>
        </asp:UpdatePanel> 
        <script type="text/javascript">
            var txtVar;
            var saveBegText;
            var saveEndText;

            function selectVille(ville) {
                var src = document.getElementById("txtVille");
                src.value = saveBegText + ville + saveEndText;
                btnLostFocusClick();
            }
        </script>
        <asp:UpdatePanel ID="actualiser" runat="server">
            <ContentTemplate>
                <asp:Label ID="LabelErrorLogin" runat="server" Font-Bold="True" Font-Size="12" ForeColor="#CC3333"
                    Text="LabelErrorLogin"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>                 
        
        
         <br />
     
        <asp:CheckBox ID="chckBxCdC" runat="server" />Cdc
        <asp:CheckBox ID="chckBxPrestige" runat="server" />Prest
        <asp:CheckBox ID="chckBxMer" runat="server" /> Mer
        <asp:CheckBox ID="chckBxMontagne" runat="server" /> Montagne
        <asp:CheckBox ID="checkBoxPiece1" Checked="true" runat="server" />1
        <asp:CheckBox ID="checkBoxPiece2" Checked="true" runat="server" />2
        <asp:CheckBox ID="checkBoxPiece3" Checked="true" runat="server" />3
        <asp:CheckBox ID="checkBoxPiece4" Checked="true" runat="server" />4
        <asp:CheckBox ID="checkBoxPiece5" Checked="true" runat="server" />5 ou +;<br />
        <asp:CheckBox ID="checkBoxMaison" runat="server" Font-Bold="False" />M
        <asp:CheckBox ID="checkBoxAppart" runat="server" />A
        <asp:CheckBox ID="checkBoxTerrain" runat="server" />T
        <asp:CheckBox ID="checkBoxAutre" runat="server" />X
        Vente <asp:RadioButton ID="radioButtonAchat" runat="server" GroupName="radioButtonGroup" Checked="true" Font-Bold="False" />
        Loc <asp:RadioButton ID="radioButtonLocation" runat="server" Checked="false" GroupName="radioButtonGroup" />

    </div>                 
    <script type="text/javascript">
		
        function show(department) {
            document.getElementById("department").src = "../imagemap/" + department + ".png";
            document.getElementById("department").alt = department;
        }

        function hide() {
            document.getElementById("department").src = "../imagemap/blank.png";
            document.getElementById("department").alt = "";
        }
        function showparis(department) {
            document.getElementById("departmentparis").src = "../imagemap/" + department + ".png";
            document.getElementById("departmentparis").alt = department;
        }

        function hideparis() {
            document.getElementById("departmentparis").src = "../imagemap/blank1.png";
            document.getElementById("departmentparis").alt = "";
        }
        function showdomtom(department) {
            document.getElementById("departmentdomtom").src = "../imagemap/" + department + ".png";
            document.getElementById("departmentdomtom").alt = department;
        }
        function hidedomtom() {
            document.getElementById("departmentdomtom").src = "../imagemap/blank1.png";
            document.getElementById("departmentdomtom").alt = "";
        }
        function fillTextBox(departmentId) {
            $("#<%=TBAjaxMap.ClientID %>").val(departmentId);
            $("#<%=BouttonAjaxMap.ClientID %>").click();
        }
		
        function zsregister() {
            document.getElementById("zsreg").style.display = 'block';
            document.getElementById("francemap").style.opacity = "0.4";
            document.getElementById("paris").style.opacity = "1";
        }
        function closeildefance() {
            document.getElementById("zsreg").style.display = 'none';
            document.getElementById("francemap").style.opacity = "1";
        }
        function domtom() {
            document.getElementById("domtommap").style.display = "block";
            document.getElementById("francemap").style.opacity = "0.4";
            document.getElementById("domtomcarte").style.opacity = "1";
        }
        function closedomtom() {
            document.getElementById("domtommap").style.display = 'none';
            document.getElementById("francemap").style.opacity = "1";
        }
</script>   
</asp:Content>
