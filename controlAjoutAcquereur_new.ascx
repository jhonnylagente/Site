<%@ Control Language="C#" AutoEventWireup="true" CodeFile="controlAjoutAcquereur_new.ascx.cs" Inherits="controlAjoutAcquereur" EnableViewState="True" ViewStateMode="Enabled" %>

<!-- controlAjoutAcquereur -->
<!-- ERREURS 

Erreurs remarquées : 
- Les arrondissements ne sont pas pris en compte (c'est la ville qui est prise en compte)
- On ajoute un arrondissement. On Ajoute 'tous les codes postaux' de la meme ville. Il ne se passe rien
- On fait une recherche avec des crtères de lieu. On supprime ou on ajoute un lieu : pas pris en compte quand on reviens sur le page de recherche
-->


<script src="../JSplugins/jQueryRangeSlide/jquery-ui.js"></script>
<link rel="stylesheet" href="../JSplugins/jQueryRangeSlide/style.css">
<script>

    $(function () {
        $("#sliderDist").slider({
            value: 0,
            min: 0,
            max: 60,
            slide: function (event, ui) {
                $("#txtDist").val(ui.value + " km");
                $("#<%=HiddenField2.ClientID %>").val(ui.value);

            }
        });
        $("#txtDist").val($("#sliderDist").slider("value") + " km");
    });

    function show_Dist() {
        $("#sliderDist").slider({
            min: 0,
            max: 60,
            slide: function (event, ui) {
                $("#txtDist").val(ui.value + " km");
                $("#<%=HiddenField2.ClientID %>").val(ui.value);

            }
        });
        $("#txtDist").val($("#sliderDist").slider("value") + " km");
        $("#<%=LBL_nbre_bien.ClientID %>").hide();
        $("#<%=PNL_Dist.ClientID %>").css('visibility', 'visible'); 
    }
</script>


<div style="display:inline-block;height:44px; margin-bottom:-17px; overflow:hidden;">
    <!--div class="unselectable"-->
            <asp:TextBox ID="TextBoxCible" onclick="show_Dist();" onblur="hide_Dist();" placeholder="Pays, Ville, CP ..." CssClass="big_textbox" runat="server" style=" width:200px;" autocomplete="off"></asp:TextBox>        
            
            <!-- cet updatePanel gere les villes selectionée -->
            <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional"  runat="server" ViewStateMode="Enabled" OnInit="UpdatePanel1_Init" OnInitComplete="UpdatePanel1_InitComplete" onLoad="UpdatePanel1_Load">
                <Triggers><asp:AsyncPostBackTrigger ControlID="TextBoxCible" /> </Triggers>
                <ContentTemplate>                          
                    <div class="tableau_selectionSimpleAjoutAcquereur selectionSimple" >
                        <!-- Liste deroulante des lieux -->
                         <div id="liste_lieux" class="ligne_selectionSimpleAjoutAcquereur" style="position:absolute;top: -<%=hauteur_liste %>px;">                  
                            <div class="cell_selectionSimpleAjoutAcquereur">
                                <div class="liste_lieu">
                                <asp:Table ID="TableAideRecherche" runat="server" ViewStateMode="Disabled"></asp:Table>
                                </div>
                            </div>
                        </div>
                        <!-- Slider distance -->
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" >
                        <ContentTemplate>
                             <asp:Panel ID="PNL_Dist" runat="server" CssClass="pnl_dist" style="position: absolute; top:50px;left:-210px; text-align:left;width:180px;white-space: nowrap;">
                                Chercher dans un rayon de :<br />
                                <div style="width:150px; margin-top:2px;">
                                    <div id="sliderDist" style="margin-left:10px; margin-right:10px;"></div>
                                    <input type="text" id="txtDist" readonly style="text-align:center; border:0; margin-top:2px;">    
                                </div> 
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <!-- Barre de chargement -->
                    <!--div class="ligne_selectionSimpleAjoutAcquereur" style="position:absolute;top:30px;left:-40px; "-->
                    <div class="ligne_selectionSimpleAjoutAcquereur" style="position:absolute;top:15px;left:90px; ">
                        <div class="cell_selectionSimpleAjoutAcquereur">                            
                            <div style="display:inline-block;width:24px">
				                <asp:UpdateProgress runat="server" id="PageUpdateProgress">
					                <ProgressTemplate>
						                <img src='../img_site/loading.gif' alt='loading' />
					                </ProgressTemplate>
				                </asp:UpdateProgress>
			                </div>
                        </div>
                    </div>
                </div>                  
            </ContentTemplate>
        </asp:UpdatePanel>
    <!--/div-->
  </div>  
	<!--<asp:Button ID="buttonClear" runat="server" onclick="clear2" class="myButtonClear" style="position:absolute;" Text="Vider"/>-->

    
<!-- cet update panel doit servir pour la barre defilante de la distance -->
<div class="Recherche" style="height:0px;" >
    <div id="spanKm" class="invisible" style="position:absolute;display:none">
        <asp:Label ID="testKm" runat="server" Font-Size="16px" Text="<span class='spankm' >Villes à <span id='sliderValue' class='spankm' >0 </span> km</span>"></asp:Label>
    </div>
    <asp:TextBox runat="server" ID="HiddenField2" class="invisible" Text="" ViewStateMode="Enabled" /><!--  Distance -->
    <asp:TextBox runat="server" ID="HiddenField3" class="invisible" Text="" />
</div>

<!-- Ancien slider, bien caché -->
<div id="monSlider_div" class="sliderBar" style="display:none"  onmousemove="curseurMouseover(event)" onmouseout="curseurMouseout()" onmouseover="curseurMouseover(event)"
    onmousedown="barClick('monSlider_div', 'curseurSlider', null, displayValue, null, event)">
    <div id="curseurSlider" class="sliderCursor" onmousedown="curseurMousedown(this, 'monSlider_div', 'monSlider_div', displayValue)">
    </div>
</div> 

<!-- OLD -->



<!--div class="tooltipContainer" style="display:none">
				&nbsp;<asp:ImageButton runat="server" ID="resetButton" ImageUrl="../img_site/boutton_Supprimer.png" CssClass="cursor_link" onclick="clear2"  />
				<div class="tooltip2" style="z-index:5;">
					<span>Effacer la cible</span>
				</div>
			</div-->






<script type="text/javascript">

    var mouseDown = null;
    var xmin = null;
    var xmax = null;
    var barX = null;
    var funct = function () { alert('funct error'); };
    curseurMouseout();

    function moveCursor(event) {
        if (mouseDown != null && xmin != null && xmax != null && barX != null) {
            var mouseX = event.clientX;
            var bodyScroll = document.documentElement.scrollLeft;
            var decalage = mouseDown.offsetWidth / 2;

            if (((barX + xmin + decalage) <= (mouseX + bodyScroll)) && ((mouseX + bodyScroll) <= (barX + xmax + decalage))) {
                mouseDown.style.left = mouseX - barX - decalage + bodyScroll + 'px';
            } else if (mouseX + bodyScroll < barX + xmin + decalage) {
                mouseDown.style.left = xmin + 'px';
            } else if (barX + xmax + decalage < mouseX + bodyScroll) {
                mouseDown.style.left = xmax + 'px';
            }
            funct();
        }
    }

    function getPos(tmp) {
        var pos = 0;

        do {
            pos += tmp.offsetLeft;
            tmp = tmp.offsetParent;
        } while (tmp !== null);

        return pos;
    };

    function curseurMousedown(cursor, antObId, postObId, nextFunction) {
        var antOb = document.getElementById(antObId);
        var postOb = document.getElementById(postObId);

        if (antOb == postOb) {
            xmin = 0;
            xmax = antOb.offsetWidth - cursor.offsetWidth;
            barX = getPos(antOb);
        } else if (getPos(cursor) < getPos(postOb)) {
            xmin = 0;
            xmax = postOb.offsetLeft - cursor.offsetWidth;
            barX = getPos(antOb);
        } else {
            xmin = antOb.offsetLeft + antOb.offsetWidth;
            xmax = postOb.offsetWidth - cursor.offsetWidth;
            barX = getPos(postOb);
        }
        mouseDown = cursor;
        mouseDown.className = 'sliderCursorHover';
        funct = nextFunction;
    }
    function curseurMouseup() {
        mouseDown.className = 'sliderCursor';
        mouseDown = null;
        barSelect = null;
        numCursor = null;
        xmin = null;
        xmax = null;
        barX = null;
    }

    function barClick(barId, cursor1Id, cursor2Id, nxtFnctCrs1, nxtFnctCrs2, event) {
        var mouseX = event.clientX + document.documentElement.scrollLeft - getPos(document.getElementById(barId));

        if (cursor2Id == null) {
            curseurMousedown(document.getElementById(cursor1Id), barId, barId, nxtFnctCrs1);
            moveCursor(event);
        } else {
            if (mouseX < document.getElementById(cursor1Id).offsetLeft) {
                curseurMousedown(document.getElementById(cursor1Id), barId, cursor2Id, nxtFnctCrs1);
                moveCursor(event);
            } else if (mouseX > document.getElementById(cursor2Id).offsetLeft) {
                curseurMousedown(document.getElementById(cursor2Id), cursor1Id, barId, nxtFnctCrs2);
                moveCursor(event);
            }
        }
    }

    function add(barId, cursorId, unit, xmax, nextFunction) {
        var bar = document.getElementById(barId);
        var cursor = document.getElementById(cursorId);
        var newPos = cursor.offsetLeft + unit;
        if (newPos <= xmax) {
            cursor.style.left = newPos + 'px';
        } else {
            cursor.style.left = xmax + 'px';
        }
        nextFunction();
    }
    function sub(barId, cursorId, unit, xmin, nextFunction) {
        var bar = document.getElementById(barId);
        var cursor = document.getElementById(cursorId);
        var newPos = cursor.offsetLeft - unit;
        if (newPos >= xmin) {
            cursor.style.left = newPos + 'px';
        } else {
            cursor.style.left = xmin + 'px';
        }
        nextFunction();
    }

    function PlusMouseDown(object) {
        object.className = 'btnPclick';
    }
    function PlusMouseUp(object) {
        object.className = 'btnP';
    }
    function MoinsMouseDown(object) {
        object.className = 'btnMclick';
    }
    function MoinsMouseUp(object) {
        object.className = 'btnM';
    }
    function okMouseDown(object) {
        object.className = 'btnOKclick';
    }
    function okMouseUp(object) {
        object.className = 'btnOK';
    }


    function curseurMouseover(event) {
        var lbl = document.getElementById('<%=testKm.ClientID %>');
        var div = document.getElementById('spanKm');
        lbl.className = 'notinvisible';
        div.className = 'notinvisible';
        var scrollTop1;
        var scrollTop2;
        var scrollTop;
        if (typeof document.body.scrollTop != 'undefined' && document.body.scrollTop != null) {
            scrollTop1 = document.body.scrollTop;
        }
        else scrollTop1 = 0;
        if (typeof document.documentElement.scrollTop != 'undefined' && document.documentElement.scrollTop != null) {
            scrollTop2 = document.documentElement.scrollTop;
        }
        else scrollTop2 = 0;
        scrollTop = Math.max(scrollTop1, scrollTop2);
        var top = event.clientY + 20 + scrollTop;
        var left = event.clientX;
        div.style.left = left + 'px';
        div.style.top = top + 'px';
        moveCursor(event);
    }
    function curseurMouseout() {
        var lbl = document.getElementById('<%=testKm.ClientID %>');
        var div = document.getElementById('spanKm');
        lbl.className = 'invisible';
        div.className = 'invisible';
        displayValue();
    }

    function displayValue() {
        var sliderValue = document.getElementById('sliderValue');
        //valeur de la distance à rechercher
        sliderValue.innerHTML = Math.floor((document.getElementById('curseurSlider').offsetLeft) / 2);
        var trans = document.getElementById('<%=HiddenField2.ClientID %>');
        trans.value = sliderValue.innerHTML;
        //document.getElementById('<%=TextBoxCible.ClientID %>').value = sliderValue.innerHTML;
    }

    function displayKm() {
        var src = document.getElementById("txtVille");
        src.value += document.getElementById('<%=HiddenField3.ClientID %>').value;
    }

    function addVilleKm() {
        clickBtnKm();
        setTimeout(function () { displayKm(); }, 1500);
    }
</script>
<script type="text/javascript">

    //gestion des trucs qui disparaissent
    var selectionType = "simple";

    function selectionSimple() {
        $(".selectionAvancee").fadeOut();
        $(".selectionSimple").fadeIn();
        $(".structSelectionSimple").fadeTo("slow", 1);
        $(".structSelectionAvancee").fadeTo("slow", 0.2);
        selectionType = "simple";
    }
    var rechercheID = 0;
    //gestion du formulaire de recherche
    function rechercheDiffereeTicket() {
        rechercheID++;
        var id = rechercheID;
        setTimeout(function () { rechercheDiffereeEnvoye(id) }, 500);
    }

    function rechercheDiffereeEnvoye(id) {
        if (id == rechercheID) {
            
            __doPostBack("<%=TextBoxCible.UniqueID %>", document.getElementById("<%=TextBoxCible.ClientID %>").value);
            rechercheID = 0;
            
       }
    }

    //derouler ligne detaillée
    function derouleDetaille(element) {
        $(element).parent().parent().parent().parent().next().show();
        $(element).hide();
        $(element).next().show();
        reglerLargeurCelluleCP();
    }

    function EnrouleDetaille(element) {
        $(element).parent().parent().parent().parent().next().hide();
        $(element).hide();
        $(element).prev().show();

    }

    function ClickSurCellClient() {
        $("#<%=TextBoxCible.ClientID %>").val(""); //Vide le champ Situation/cible
    }

    //remet le curseur au bon endroit a chaques postback
    function loadCursor() {
        var trans = document.getElementById('<%=HiddenField2.ClientID %>');
        var distance
        if (!trans) distance = 0;
        else distance = trans.value;
        (document.getElementById('curseurSlider')).style.left = distance * 2 + 'px';
    }
    Sys.Application.add_load(loadCursor);

    //gere l evenement avant et apres postback
    var listeTeuteu;
    function beforeAsyncPostBackDivInvisible() {
        listeTeuteu = {};
        $('.teuteu').each(function () {
            var id = $(this).attr("id")
            var style = $(this).attr("style");
            if (typeof style == undefined || style == null) style = "";
            listeTeuteu[id] = style;
        });
    }

    function afterAsyncPostBackDivInvisible() {
        for (var divID in listeTeuteu) {

            var element = $("#" + divID);
            if (element.length) {
                //L'élément existe
                $("#" + divID).attr("style", listeTeuteu[divID]);
            } else {
                //L'élément n'existe pas
            }
        }
    }

    var listeScroll;
    function beforeAsyncPostBackDivScroll() {
        listeScroll = {};
        $('.teuteu').each(function () {
            var id = $(this).attr("id")
            var scroll = $(this).scrollTop();
            if (typeof scroll == undefined || scroll == null) scroll = 0;
            listeScroll[id] = scroll;
        });
    }

    function afterAsyncPostBackDivScroll() {
        for (var divID in listeScroll) {
            var element = $("#" + divID);
            if (element.length) {
                //L'élément existe
                var scroll = listeScroll[divID];
                document.getElementById(divID).scrollTop = scroll;
            } else {
                //L'élément n'existe pas
            }
        }
    }



    var scrollSimple;
    var scrollAvance;

    function beforeAsyncPostBackGereSelectionAvance() {
        scrollavance = $("#ScrollSelectionAvance").scrollTop();
        scrollsimple = $("#ScrollSelectionSimple").scrollTop();

    }

    function afterAsyncPostBackGereSelectionAvance() {
        if (selectionType == "simple") selectionSimple();
        else if (selectionType == "avance") selectionAvance();

        $("#ScrollSelectionAvance").scrollTop(scrollavance);
        $("#ScrollSelectionSimple").scrollTop(scrollsimple);

    }

    function reglerLargeurCelluleCP() {
        $("div.celuleArrondissement ").each(function () {
            var largeurMax = 400;
            var largeur = 0;
            $("div.AjoutacquereurCellulleListeVille", $(this)).each(function () {
                largeur += $(this).width();
                var marginLeft = $(this).css("margin-left");
                marginLeft = marginLeft.split("px")[0] * 1;
                var marginRight = $(this).css("margin-right");
                marginRight = marginRight.split("px")[0] * 1;
                largeur += marginLeft + marginRight;
            });
            if (largeur > largeurMax) largeur = largeurMax;
            $(this).width(largeur);

        });
    }



    function BeginHandler() {
        beforeAsyncPostBackDivInvisible();
        beforeAsyncPostBackDivScroll();
        beforeAsyncPostBackGereSelectionAvance();
    }

    function EndHandler() {
        afterAsyncPostBackDivInvisible();
        afterAsyncPostBackDivScroll();
        afterAsyncPostBackGereSelectionAvance();
        reglerLargeurCelluleCP();
    }

    Sys.Application.add_init(appl_init);

    function appl_init() {
        var pgRegMgr = Sys.WebForms.PageRequestManager.getInstance();
        pgRegMgr.add_beginRequest(BeginHandler);
        pgRegMgr.add_endRequest(EndHandler);
    }
    //fin gestion evenement avant apres post back
</script>