<%@ Control Language="C#" AutoEventWireup="true" CodeFile="controlAjoutAcquereur.ascx.cs" Inherits="controlAjoutAcquereur" EnableViewState="True" ViewStateMode="Enabled" %>

<!-- controlAjoutAcquereur -->

<fieldset id ="fieldAjoutAcquereurCible" class="fieldset_21champs">
    <div class="unselectable">
        

        <div class="ajoutAcquereurConteneur">
            <div class="tableau_selectionAjoutAcquereur" style="display:none;">
                <div class="cell_selectionAjoutAcquereur"><a onclick="selectionAvance()" class="structSelectionSimple">Options avancées</a></div>
                <div class="cell_selectionAjoutAcquereur"><a onclick="selectionSimple()" style="opacity: 0.2;"  class="structSelectionAvancee">Options simples</a></div>
            </div>
            cible:&nbsp;<asp:TextBox ID="TextBoxCible" placeholder="Pays, Ville, CP ou departement" runat="server" Width="185" autocomplete="off"></asp:TextBox>
			<div style="display:inline-block;width:24px">
				<asp:UpdateProgress runat="server" id="PageUpdateProgress">
					<ProgressTemplate>
						<img src='../img_site/loading.gif' alt='loading' />
					</ProgressTemplate>
				</asp:UpdateProgress>
			</div>
			<div class="tooltipContainer">
				&nbsp;<asp:ImageButton runat="server" ID="resetButton" ImageUrl="../img_site/boutton_Supprimer.png" CssClass="cursor_link" onclick="clear2"  />
				<div class="tooltip2" style="z-index:5;">
					<span>Effacer la cible</span>
				</div>
			</div>
			
			
            <div>
                                
                distance: <div id="btnM" class="btnM" onclick="sub('monSlider_div', 'curseurSlider', 2, 0, displayValue)" onmouseover="curseurMouseover(event)" onmouseout="curseurMouseout()"
                    onmousedown="MoinsMouseDown(this)" onmouseup="MoinsMouseUp(this)">
                </div>
                <div id="monSlider_div" class="sliderBar" onmousemove="curseurMouseover(event)" onmouseout="curseurMouseout()" onmouseover="curseurMouseover(event)"
                    onmousedown="barClick('monSlider_div', 'curseurSlider', null, displayValue, null, event)">
                    <div id="curseurSlider" class="sliderCursor" onmousedown="curseurMousedown(this, 'monSlider_div', 'monSlider_div', displayValue)">
                    </div>
                </div>
                                    
                <div id="btnP" onclick="add('monSlider_div', 'curseurSlider', 2, 100, displayValue)" class="btnP" onmouseover="curseurMouseover(event)" onmouseout="curseurMouseout()" onmousedown="PlusMouseDown(this)"
                    onmouseup="PlusMouseUp(this)">
                </div>
            </div>
			
			
            <!-- cet updatePanel gere les villes selectionée -->
            <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server" ViewStateMode="Enabled" OnInit="UpdatePanel1_Init" OnInitComplete="UpdatePanel1_InitComplete" onLoad="UpdatePanel1_Load">
                <Triggers><asp:AsyncPostBackTrigger ControlID="TextBoxCible" /> </Triggers>
                <ContentTemplate>
                                
                    <div class="tableau_selectionSimpleAjoutAcquereur selectionSimple">
                        <div class="ligne_selectionSimpleAjoutAcquereur">
                            <div class="cell_selectionSimpleAjoutAcquereur">
                                <div class="AjoutacquereurScrollCell100">
                                <asp:Table ID="TableAideRecherche" runat="server" ViewStateMode="Disabled"></asp:Table>
                                </div>
                            </div>
                        </div>
                        <div class="ligne_selectionSimpleAjoutAcquereur">
                            <div class="cell_selectionSimpleAjoutAcquereur">
                                <div id="ScrollSelectionSimple" class="AjoutacquereurScrollCell">
                                    <asp:Table ID="TableSelectionSimple" runat="server" ></asp:Table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="selectionAvancee invisible">
                        <div class="tableau_selectionAvanceAjoutAcquereur">
                            
                            <div class="cell_selectionAvanceAjoutAcquereur">
                                <div id="ScrollSelectionAvance" class="AjoutacquereurScrollCell2">
                                    <asp:Table ID="TableSelectionAvance" runat="server" CssClass="selectionAvancee invisible table_listeAvanceAjoutacquereur" Caption="<div style='text-align:left'>Liste detaillée</div>">
                                    </asp:Table>
                                </div>
                            </div>
                            
                            
                            <div class="cell_selectionAvanceAjoutAcquereur">
                                <div class="AjoutacquereurScrollCell2">
                                    <asp:Table ID="TableListeNoire" runat="server" CssClass="selectionAvancee invisible table_listeAvanceAjoutacquereur" Caption="<div style='text-align:left'> Liste noire</div>">
                                    </asp:Table>
                                </div>
                            </div>
                            
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
	<!--<asp:Button ID="buttonClear" runat="server" onclick="clear2" class="myButtonClear" style="position:absolute;" Text="Vider"/>-->
</fieldset>


<!-- cet update panel doit servir pour la barre defilante de la distance -->
<div class="Recherche" style="height:0px;">
    <div id="spanKm" class="invisible" style="position:absolute;">
        <asp:Label ID="testKm" runat="server" Font-Size="16px" Text="<span class='spankm' >Villes à <span id='sliderValue' class='spankm' >0 </span> km</span>"></asp:Label>
    </div>
    <asp:TextBox runat="server" ID="HiddenField2" class="invisible" Text="" ViewStateMode="Enabled" />
    <asp:TextBox runat="server" ID="HiddenField3" class="invisible" Text="" />
    <asp:TextBox runat="server" ID="HiddenField4" class="invisible" Text="" />
    <asp:TextBox runat="server" ID="HiddenField5" class="invisible" Text="" />
    <asp:TextBox runat="server" ID="HiddenField6" class="invisible" Text="" />
    <asp:TextBox runat="server" ID="HiddenField7" class="invisible" Text="" />
</div>
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
    function selectionAvance() {
        $(".selectionAvancee").fadeIn();
        $(".selectionSimple").fadeOut();
        $(".structSelectionSimple").fadeTo("slow", 0.2);
        $(".structSelectionAvancee").fadeTo("slow", 1);
        selectionType = "avance";
    }
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
        $("#<%=TextBoxCible.ClientID %>").val("");	//Vide le champ Situation/cible
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