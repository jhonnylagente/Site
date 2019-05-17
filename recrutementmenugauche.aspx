<div id="menu">
	<div class="menu" id="menu1" onclick="afficheMenu(this)">
		<a href="#">Présentation</a>
	</div>
	<div id="sousmenu1" style="display:none">
		<div class="sousmenu">
			<a href="recrutement_leconcept.aspx" id="recrutement_leconcept"> Le concept</a>
		</div>
		<div class="sousmenu">
			<a href="recrutement_lesavantages.aspx"id="recrutement_lesavantages"> Les avantages</a>
		</div>
		<div class="sousmenu">
			<a href="recrutement_laformation.aspx" id="recrutement_laformation"> Les formations</a>
		</div>
		<div class="sousmenu">
			<a href="recrutement_remuneration.aspx" id="recrutement_remuneration"> Votre rémunération</a>
		</div>
        <div class="sousmenu">
			<a href="recrutement_accompagnement.aspx" id="recrutement_accompagnement"> Un accompagnement au quotidien</a>
		</div>
	</div>
	<div class="menu" id="menu2" onclick="afficheMenu(this)">
		<a href="#"> Qui peut nous rejoindre ?</a>
	</div>
	<div id="sousmenu2" style="display:none">
		<div class="sousmenu">
			<a href="recrutement_aijelebonprofil.aspx" id="recrutement_aijelebonprofil"> Ai-je le bon profil ?</a>
		</div>
		<div class="sousmenu">
			<a href="recrutement_tresorerie.aspx" id="recrutement_tresorerie"> Ai-je besoin de trésorerie <br />pour débuter ?</a>
		</div>
	</div>
	<div class="menu" id="menu3" onclick="afficheMenu(this)">
		<a href="recrutement_statutagentcommercial.aspx" id="A1"> Le statut d'agent commercial</a>
	</div>
	<div class="menu" id="menu4" onclick="afficheMenu(this)">
		<a href="recrutement_agentimmobilier.aspx" id="menu3color"> Etre conseiller immobilier ?</a>
	</div>
	
	<div class="menu" id="menu5" onclick="afficheMenu(this)">
		<a href="recrutement_foireauxquestions.aspx" id="menu4color"> Foire Aux Questions</a>
	</div>
    <div class="menu" id="menu6" onclick="afficheMenu(this)">
		<a href="contact3.aspx?appelcontact='menu'" id="menu5color"> Contact</a>
	</div>

</div>
<script type="text/javascript">
    function afficheMenu(obj) {

        var idMenu = obj.id;
        var idSousMenu = 'sous' + idMenu;
        var sousMenu = document.getElementById(idSousMenu);

        /*****************************************************/
        /**	on cache tous les sous-menus pour n'afficher    **/
        /** que celui dont le menu correspondant est cliqué **/
        /** où 4 correspond au nombre de sous-menus         **/
        /*****************************************************/
        for (var i = 1; i <= 4; i++) {
            if (document.getElementById('sousmenu' + i) && document.getElementById('sousmenu' + i) != sousMenu) {
                document.getElementById('sousmenu' + i).style.display = "none";
            }
        }

        if (sousMenu) {
            //alert(sousMenu.style.display);
            if (sousMenu.style.display == "block") {
                sousMenu.style.display = "none";
            }
            else {
                sousMenu.style.display = "block";
            }
        }

    }
</script>