//Saisie semi auto
var xhr;




/***********************
 *Validation formulaire
 ***********************/
 
function imageValide(inputID)
{
	if($(inputID)[0].files.length == 0)
		return true;

	var idImage = inputID.substring(inputID.length-1,inputID.length);
	var sizeValide = ($(inputID)[0].files[0].size < 2097152);
	var extensionValide = false;
	var extension = "";
	var temp = $(inputID)[0].files[0].name.split(".");
	
	if(temp.length > 1)
		extension = temp[temp.length - 1];
	else
		extension = temp[0];
	extension = extension.toLowerCase();
	
	extensionValide = (extension == "jpeg") || (extension == "jpg");
	
	if(!sizeValide & !extensionValide)
	{
		if($("#error").html() === "") $("#error").html("Erreur de saisie pour les champs suivants : <br/>");
		$("#error").append("-> Photo "+idImage+" (taille > 2 MO et format différent de jpeg) <br/>");
	}
	else if(!sizeValide)
	{
		if($("#error").html() === "") $("#error").html("Erreur de saisie pour les champs suivants : <br/>");
		$("#error").append("-> Photo "+idImage+" (taille > 2 MO) <br/>");
	}
	
	else if(!extensionValide)
	{
		if($("#error").html() === "") $("#error").html("Erreur de saisie pour les champs suivants : <br/>");
		$("#error").append("-> Photo "+idImage+" (format différent de jpg)<br/>");
	}
	
	return sizeValide && extensionValide;
}



function allImageValide()
{
	return imageValide(img1)
		&& imageValide(img2)
		&& imageValide(img3)
		&& imageValide(img4)
		&& imageValide(img5)
		&& imageValide(img6)
		&& imageValide(img7)
		&& imageValide(img8);
}

 
function cpValide()
{
	var valide = checkfield_num("balise_spoiler2", $(cpID).val()) && ($(cpID).val() != "");
	if(!valide)
	{
		if($("#error").html() === "") $("#error").html("Erreur de saisie pour les champs suivants : <br/>");
		$("#error").append("-> Code Postal du bien <br/>");
	}
	return valide;
}

function villeValide()
{
	var valide = checkfield_alpha("balise_spoiler3", $(villeID).val()) && ($(villeID).val() != "");
	if(!valide)
	{
		if($("#error").html() === "") $("#error").html("Erreur de saisie pour les champs suivants : <br/>");
		$("#error").append("-> Ville du bien <br/>");
	}
	return valide;
}

function paysValide()
{
	var valide = checkfield_alpha("balise_spoilerPays", $(paysID).val()) && ($(paysID).val() != "");
	if(!valide)
	{
		if($("#error").html() === "") $("#error").html("Erreur de saisie pour les champs suivants : <br/>");
		$("#error").append("-> Pays du bien  <br/>");
	}
	return valide && $(paysID).val() != "";
}

function prixValide()
{
	var valide = checkfield_num("balise_spoiler15", $(prixID).val())  && ($(prixID).val() != "");
	if(!valide)
	{
		if($("#error").html() === "") $("#error").html("Erreur de saisie pour les champs suivants : <br/>");
		$("#error").append("-> Prix de vente <br/>");
	}
	return valide;
}

function loyerValide()
{
	var reg = /^\d+$/;
	var valide = reg.test($(loyerID).val())  && ($(loyerID).val() != "");
	if(!valide)
	{
		if($("#error").html() === "") $("#error").html("Erreur de saisie pour les champs suivants : <br/>");
		$("#error").append("-> Loyer Charges Comprises <br/>");
	}
	return valide;
}

function surfaceValide()
{
	if($(typeID).val() == 'Local' || $(typeID).val() == 'Terrain')
		return true;
	else
	{
		var valide = checkfield_num("balise_spoiler31", $(surfaceID).val()) && ($(surfaceID).val() != "");
		if(!valide)
		{
			if($("#error").html() === "") $("#error").html("Erreur de saisie pour les champs suivants : <br/>");
			$("#error").append("-> Surface Habitable <br/>");
		}
	}
	return valide;
}

function validerForm()
{	
	$("#error").html("");
	var cp = cpValide();
	var ville = villeValide();
	var pays = paysValide();
	var prix = prixValide();
	var surface = surfaceValide();
	var photo = allImageValide();
	
	//On n'ecrit pas le return en une ligne pour forcer l'execution de tous les tests
	//Et non pas un arret apres le return false;
	
	return cp && ville && pays && prix && surface && photo;
}

function validerForm2()
{	
	$("#error").html("");
	var cp = cpValide();
	var ville = villeValide();
	var pays = paysValide();
	var prix = loyerValide();
	var surface = surfaceValide();
	var photo = allImageValide();
	
	return cp && ville && pays && prix && surface && photo;
}


//listeChamp[numeroOnglet] = [idinputVille, idInputCodePostal, idInputPays]
var listeChamp = [
    ["#ctl00_contentPlaceHolder1_TextBoxVilleBien", "#ctl00_contentPlaceHolder1_TextBoxCodePostalBien", "#ctl00_contentPlaceHolder1_TextBoxPaysBien"],
    ["#ctl00_contentPlaceHolder1_onglet_VendeurPrix_TextBoxVilleVendeur", "#ctl00_contentPlaceHolder1_onglet_VendeurPrix_TextBoxCodePostalVendeur", "#ctl00_contentPlaceHolder1_onglet_VendeurPrix_TextBoxPaysVendeur"],
    ["#ctl00_contentPlaceHolder1_TextBoxVilleSyndic", "", ""],
    ["#ctl00_contentPlaceHolder1_onglet_Proprietaire_TextBoxVilleProprietaire", "#ctl00_contentPlaceHolder1_onglet_Proprietaire_TextBoxCodePostalProprietaire", "#ctl00_contentPlaceHolder1_onglet_Proprietaire_TextBoxPaysProprietaire"]
];


/**********************************
 *	Requete ajax pour liste deroulante
 *********************************/


//hack fix pas tres propre
//Vide les liste deroulante lorsque le champ perd le focus apres 100ms
//Permet d'eviter que les liste deroulantes disparaissent avant que le clique sur un champ ait lieu
function viderListeDeroulante(onglet)
{
    var fn = function () {
        $("#saisieautopays"+onglet).html("");
        $("#saisieautoville" + onglet).html("");
        $("#saisieautocp" + onglet).html("");
    };

    setTimeout(fn, 100);
}

function saisiePays(ligne,onglet)
{
    $(listeChamp[onglet][2]).val($(ligne).html());
	$("#saisieautopays" + onglet).html("");
}

function saisieVille(nom, cp, onglet)
{
	if(!isNaN(nom.substring(nom.length-2, nom.length)))
		nom = nom.substring(0, nom.length - 2);	
	if(!isNaN(nom.substring(nom.length-3, nom.length)))
		nom = nom.substring(0, nom.length - 3);
    $(listeChamp[onglet][0]).val(nom);
    $(listeChamp[onglet][1]).val(cp);
    $(listeChamp[onglet][2]).val("France");
	$("#saisieautoville"+onglet).html("");
	$("#saisieautocp"+onglet).html("");
}

function listePays(e,onglet)
{
    //Si le champs est vide, on ne lance pas de requete ajax
    if ($(listeChamp[onglet][2]).val() == "")
        $("#saisieautopays" + onglet).html("");
    else if (e.keyCode != 27)
    {
        $("#saisieautopays"+onglet).html("<img src='../img_site/loading.gif' alt='loading' />");

        var fn = function ()
        {
            if (xhr && xhr.readyState != 4) //Si une requete ajax est en cours, on l'interrompte
            {
                xhr.abort();
            }
            
            //Requete ajax
            xhr = $.ajax({
                url: "ajaxGetList.aspx?type=pays&recherche=" + $(listeChamp[onglet][2]).val() + "&onglet=" + onglet,
                success: function (data) 
                {
                    $("#saisieautopays" + onglet).html(data);
                }
            });
        };

        var interval = setTimeout(fn, 500);    //Delay de 500ms avant de lancer la requete ajax
    }
}

function listeVilles(e,onglet)
{
    if ($(listeChamp[onglet][0]).val() == "")
        $("#saisieautoville"+onglet).html("");
    else if (e.keyCode != 27)
    {
		$("#saisieautoville"+onglet).html("<img src='../img_site/loading.gif' alt='loading' />");

        var fn = function () {
            if (xhr && xhr.readyState != 4)
            {
                xhr.abort();
            }

            xhr = $.ajax({
                url: "ajaxGetList.aspx?type=ville&recherche=" + $(listeChamp[onglet][0]).val() + "&onglet=" + onglet,
                success: function (data) {
                    $("#saisieautoville" + onglet).html(data);
                }
            });
        };

        var interval = setTimeout(fn, 500);
    }
}

function listeCP(e,onglet)
{
    if ($(listeChamp[onglet][1]).val() == "" || isNaN($(listeChamp[onglet][1]).val()))
        $("#saisieautocp"+onglet).html("");
    else if (e.keyCode != 27)
    {
        $("#saisieautocp"+onglet).html("<img src='../img_site/loading.gif' alt='loading' />");
    
        var fn = function () {
            if (xhr && xhr.readyState != 4) {
                xhr.abort();
            }

            xhr = $.ajax({
                url: "ajaxGetList.aspx?type=cp&recherche=" + $(listeChamp[onglet][1]).val() + "&onglet=" + onglet,
                success: function (data) {
                    $("#saisieautocp"+onglet).html(data);
                }
            });
        };

        var interval = setTimeout(fn, 500);
    }
}


    function change_onglet(name) 
    {
        document.getElementById('onglet_' + anc_onglet).className = 'onglet_0 onglet';
        document.getElementById('onglet_' + name).className = 'onglet_1 onglet';
        document.getElementById('contenu_onglet_' + anc_onglet).style.display = 'none';
        document.getElementById('contenu_onglet_' + name).style.display = 'block';
        anc_onglet = name;        
    }


    //TO CHECK dynamically fields' values

    function checkfield_mail(id_pers    , value) {

        var regex = /^[-\w.]+[@]{1}[a-zA-Z0-9\-.]+[.]{1}[-a-zA-Z0-9]+$/;

        if (value != null)
            if(regex.test(value) || value == "")
			{
                document.getElementById(id_pers).className = 'balise_spoiler';
				return true;
			}
            else
                document.getElementById(id_pers).className = '';

		return false;
    }

    function checkfield_alpha_num(id_pers, value) 
    {
       var regex = /^[-0-9 a-zA-Zéèçàâùô . , ']+$|^()+$/;
       
       if(value!=null){
            if(regex.test(value) || value == "")
			{
                document.getElementById(id_pers).className = 'balise_spoiler';
				return true;
			}
            else
                document.getElementById(id_pers).className = '';
       }
	   return false;
    }


    function checkfield_alpha(id_pers, value) 
    {
        var regex = /^[-a-zA-Zéèçàâùô.' ]+$/;

        if (value != null)
        {
            if(regex.test(value) || value == "")
			{
                document.getElementById(id_pers).className = 'balise_spoiler';
				return true;
			}
            else
                document.getElementById(id_pers).className = '';
        }
		return false;
    }


    function checkfield_num(id_pers, value) 
    {
        var regex = /^[0-9]+(,[0-9]+)?$/;

        if (value != null)
        {
            if(regex.test(value) || value == "")
			{
                document.getElementById(id_pers).className = 'balise_spoiler';
				return true;
			}
            else
                document.getElementById(id_pers).className = '';
        }
		return false;
    }
    

   
   //Pour afficher le descriptif technique selon la catégorie sélectionnée
    function check_type_bien() {

       var e = document.getElementById("DropDownListTypeBien");
        var strUser = e.options[e.selectedIndex].value;
		
        if (strUser == "Maison") {
            //alert(strUser);
            
            // visible
            document.getElementById("categorie").style.display = 'table-row';
            document.getElementById("nombre_pieces").style.display = 'table-row';
            document.getElementById("surface_habitable").style.display = 'table-row';
            document.getElementById("surface_carrez").style.display = 'table-row';
            document.getElementById("surface_sejour").style.display = 'table-row';
            document.getElementById("surface_terrain").style.display = 'table-row';
            document.getElementById("nombre_chambres").style.display = 'table-row';
            document.getElementById("murs_mitoyens").style.display = 'table-row';
            document.getElementById("exposition_sejour").style.display = 'table-row';
            document.getElementById("nombre_etages").style.display = 'table-row';

            document.getElementById("annee_construction").style.display = 'table-row';
            document.getElementById("ctl00_contentPlaceHolder1_DropDownListNatureChauffage").style.display = 'table-row';
            document.getElementById("ctl00_contentPlaceHolder1_DropDownListTypeSousSol").style.display = 'table-row';
            document.getElementById("ctl00_contentPlaceHolder1_DropDownListTypeCuisine").style.display = 'table-row';
            document.getElementById("type_sous_sol").style.display = 'table-row';
            document.getElementById("terrasse").style.display = 'table-row';
            document.getElementById("nombre_wc").style.display = 'table-row';
            document.getElementById("nombre_salles_bain").style.display = 'table-row';
            document.getElementById("nombre_salles_eau").style.display = 'table-row';
            document.getElementById("nombre_parking_interieurs").style.display = 'table-row';
            document.getElementById("nombre_parking_exterieurs").style.display = 'table-row';
            document.getElementById("nombre_garages").style.display = 'table-row';
            document.getElementById("nombre_caves").style.display = 'table-row';

            document.getElementById("lettre_conso").style.display = 'table-row';
            document.getElementById("nombre_conso").style.display = 'table-row';
            document.getElementById("lettre_energie").style.display = 'table-row';
            document.getElementById("nombre_energie").style.display = 'table-row';


            document.getElementById("fieldset_CaracPrincip").className = "fieldset_10champs";
            document.getElementById("fieldset_InfoCompl").className = "fieldset_5champs";
            document.getElementById("fieldset_DispoInt").className = "fieldset_10champs";
            document.getElementById("fieldset_DPE").className = "fieldset_5champs";

            document.getElementById("fieldset_InfoCompl").style.display = 'block';
            document.getElementById("fieldset_DPE").style.display = 'block';

            //invisible
                          
            document.getElementById("etage").style.display = 'none';
            
            document.getElementById("code_etage").style.display = 'none';
            
            document.getElementById("type_chauffage").style.display = 'none';
            
            document.getElementById("balcon").style.display = 'none';
            
            document.getElementById("ascenseur").style.display = 'none';
            

            document.getElementById("ctl00_contentPlaceHolder1_DropDownListTypeChauffage").style.display = 'none';
            
            document.getElementById("facade_terrain").style.display = 'none';
            document.getElementById("profondeur_terrain").style.display = 'none';
            document.getElementById("cos_terrain").style.display = 'none';
            document.getElementById("shon_terrain").style.display = 'none';
            document.getElementById("eau").style.display = 'none';
            document.getElementById("gaz").style.display = 'none';
            document.getElementById("electricite").style.display = 'none';
            document.getElementById("tout_a_legout").style.display = 'none';
            document.getElementById("alignement").style.display = 'none';
            document.getElementById("lotissement").style.display = 'none';
            document.getElementById("numero_lotissement").style.display = 'none';
			

        }

        if (strUser == "Appartement") {
            //alert(strUser);
            // visible
            document.getElementById("categorie").style.display = 'table-row';
            document.getElementById("nombre_pieces").style.display = 'table-row';
            document.getElementById("nombre_chambres").style.display = 'table-row';
            document.getElementById("surface_habitable").style.display = 'table-row';
            document.getElementById("surface_carrez").style.display = 'table-row';
            document.getElementById("surface_sejour").style.display = 'table-row';
            document.getElementById("exposition_sejour").style.display = 'table-row';
            document.getElementById("etage").style.display = 'table-row';
            
            document.getElementById("nombre_etages").style.display = 'table-row';
            document.getElementById("code_etage").style.display = 'table-row';
            document.getElementById("annee_construction").style.display = 'table-row';
            document.getElementById("type_cuisine").style.display = 'table-row';
            document.getElementById("type_chauffage").style.display = 'table-row';
            document.getElementById("nature_chauffage").style.display = 'table-row';
            document.getElementById("balcon").style.display = 'table-row';
            document.getElementById("terrasse").style.display = 'table-row';
            document.getElementById("ascenseur").style.display = 'table-row';
            document.getElementById("nombre_wc").style.display = 'table-row';
            document.getElementById("nombre_salles_bain").style.display = 'table-row';
            document.getElementById("nombre_salles_eau").style.display = 'table-row';
            document.getElementById("nombre_parking_interieurs").style.display = 'table-row';
            document.getElementById("nombre_parking_exterieurs").style.display = 'table-row';
            document.getElementById("nombre_garages").style.display = 'table-row';
            document.getElementById("nombre_caves").style.display = 'table-row';
                                       
            document.getElementById("type_chauffage").style.display = 'table-row';
            document.getElementById("nature_chauffage").style.display = 'table-row';
            document.getElementById("type_sous_sol").style.display = 'table-row';
            document.getElementById("type_cuisine").style.display = 'table-row';
                                       
            document.getElementById("lettre_conso").style.display = 'table-row';
            document.getElementById("nombre_conso").style.display = 'table-row';
            document.getElementById("lettre_energie").style.display = 'table-row';
            document.getElementById("nombre_energie").style.display = 'table-row';
                             
            document.getElementById("ctl00_contentPlaceHolder1_DropDownListTypeChauffage").style.display = 'table-row';
            document.getElementById("ctl00_contentPlaceHolder1_DropDownListNatureChauffage").style.display = 'table-row';
            document.getElementById("ctl00_contentPlaceHolder1_DropDownListTypeCuisine").style.display = 'table-row';

            document.getElementById("fieldset_CaracPrincip").className = "fieldset_special";
            document.getElementById("fieldset_InfoCompl").className = "fieldset_3champs";
            document.getElementById("fieldset_DispoInt").className = "fieldset_special";
            document.getElementById("fieldset_DPE").className = "fieldset_3champs";

            document.getElementById("fieldset_InfoCompl").style.display = 'block';
            document.getElementById("fieldset_DPE").style.display = 'block';


            //invisible
            document.getElementById("type_sous_sol").style.display = 'none';
            document.getElementById("ctl00_contentPlaceHolder1_DropDownListTypeSousSol").style.display = 'none';
                                                                  
            document.getElementById("surface_terrain").style.display = 'none';
            document.getElementById("facade_terrain").style.display = 'none';
            document.getElementById("profondeur_terrain").style.display = 'none';
            document.getElementById("cos_terrain").style.display = 'none';
            document.getElementById("shon_terrain").style.display = 'none';
            document.getElementById("eau").style.display = 'none';
            document.getElementById("gaz").style.display = 'none';
            document.getElementById("electricite").style.display = 'none';
            document.getElementById("tout_a_legout").style.display = 'none';
            document.getElementById("alignement").style.display = 'none';
            document.getElementById("lotissement").style.display = 'none';
            document.getElementById("numero_lotissement").style.display = 'none';
            document.getElementById("murs_mitoyens").style.display = 'none';
                 
        }

        if (strUser == "Terrain") {
            //alert(strUser);
            
            document.getElementById("categorie").style.display = 'table-row';
            document.getElementById("surface_terrain").style.display = 'table-row';
            document.getElementById("facade_terrain").style.display = 'table-row';
            document.getElementById("profondeur_terrain").style.display = 'table-row';
            document.getElementById("cos_terrain").style.display = 'table-row';
            document.getElementById("shon_terrain").style.display = 'table-row';
            document.getElementById("eau").style.display = 'table-row';
            document.getElementById("gaz").style.display = 'table-row';
            document.getElementById("electricite").style.display = 'table-row';
            document.getElementById("tout_a_legout").style.display = 'table-row';
            document.getElementById("alignement").style.display = 'table-row';
            document.getElementById("lotissement").style.display = 'table-row';
            document.getElementById("numero_lotissement").style.display = 'table-row';

            document.getElementById("nombre_pieces").style.display = 'none';
            document.getElementById("nombre_chambres").style.display = 'none';
            document.getElementById("murs_mitoyens").style.display = 'none';
            document.getElementById("surface_habitable").style.display = 'none';
            document.getElementById("surface_carrez").style.display = 'none';
            document.getElementById("surface_sejour").style.display = 'none';
            document.getElementById("exposition_sejour").style.display = 'none';
            document.getElementById("etage").style.display = 'none';
            document.getElementById("nombre_etages").style.display = 'none';
            document.getElementById("code_etage").style.display = 'none';
            document.getElementById("annee_construction").style.display = 'none';
            document.getElementById("type_cuisine").style.display = 'none';
            document.getElementById("type_chauffage").style.display = 'none';
            document.getElementById("nature_chauffage").style.display = 'none';
            document.getElementById("balcon").style.display = 'none';
            document.getElementById("terrasse").style.display = 'none';
            document.getElementById("ascenseur").style.display = 'none';
            document.getElementById("nombre_wc").style.display = 'none';
            document.getElementById("nombre_salles_bain").style.display = 'none';
            document.getElementById("nombre_salles_eau").style.display = 'none';
            document.getElementById("nombre_parking_interieurs").style.display = 'none';
            document.getElementById("nombre_parking_exterieurs").style.display = 'none';
            document.getElementById("nombre_garages").style.display = 'none';
            document.getElementById("nombre_caves").style.display = 'none';
                                       
            document.getElementById("type_chauffage").style.display = 'none';
            document.getElementById("nature_chauffage").style.display = 'none';
            document.getElementById("type_sous_sol").style.display = 'none';
            document.getElementById("type_cuisine").style.display = 'none';

            document.getElementById("lettre_conso").style.display = 'none';
            document.getElementById("nombre_conso").style.display = 'none';
            document.getElementById("lettre_energie").style.display = 'none';
            document.getElementById("nombre_energie").style.display = 'none';
                             
            document.getElementById("ctl00_contentPlaceHolder1_DropDownListTypeChauffage").style.display = 'none';
            document.getElementById("ctl00_contentPlaceHolder1_DropDownListNatureChauffage").style.display = 'none';
            document.getElementById("ctl00_contentPlaceHolder1_DropDownListTypeSousSol").style.display = 'none';

            document.getElementById("fieldset_CaracPrincip").className = "fieldset_7champs";
            document.getElementById("fieldset_InfoCompl").style.display = 'none';
            document.getElementById("fieldset_DispoInt").className = "fieldset_7champs";
            document.getElementById("fieldset_DPE").style.display = 'none';

        }

        if (strUser == "Immeuble") {
            //alert(strUser);

            // visible
            document.getElementById("categorie").style.display = 'table-row';
            document.getElementById("annee_construction").style.display = 'table-row';
            document.getElementById("nombre_etages").style.display = 'table-row';
            document.getElementById("ascenseur").style.display = 'none';
            document.getElementById("nombre_parking_interieurs").style.display = 'table-row';
            document.getElementById("nombre_parking_exterieurs").style.display = 'table-row';
            document.getElementById("nombre_garages").style.display = 'table-row';
            document.getElementById("surface_terrain").style.display = 'table-row';
            document.getElementById("lettre_conso").style.display = 'table-row';
            document.getElementById("nombre_conso").style.display = 'table-row';
            document.getElementById("lettre_energie").style.display = 'table-row';
            document.getElementById("nombre_energie").style.display = 'table-row';
            
            document.getElementById("etage").className = "disparait";
            document.getElementById("fieldset_InfoCompl").style.display = 'block';
            document.getElementById("fieldset_DPE").style.display = 'block';


            document.getElementById("fieldset_CaracPrincip").className = "fieldset_4champs";
            document.getElementById("fieldset_InfoCompl").className = "fieldset_4champs";
            document.getElementById("fieldset_DispoInt").className = "fieldset_4champs";
            document.getElementById("fieldset_DPE").className = "fieldset_4champs";

            
            

            //invisible
            document.getElementById("code_etage").style.display = 'none';
            document.getElementById("nombre_chambres").style.display = 'none';
            document.getElementById("exposition_sejour").style.display = 'none';
            document.getElementById("nombre_pieces").style.display = 'none';
            document.getElementById("surface_habitable").style.display = 'none';
            document.getElementById("surface_carrez").style.display = 'none';
            document.getElementById("surface_sejour").style.display = 'none';
            document.getElementById("type_cuisine").style.display = 'none';
            document.getElementById("nature_chauffage").style.display = 'none';
            document.getElementById("nombre_chambres").style.display = 'none';
            document.getElementById("murs_mitoyens").style.display = 'none';
            document.getElementById("exposition_sejour").style.display = 'none';
            
            document.getElementById("ctl00_contentPlaceHolder1_DropDownListNatureChauffage").style.display = 'none';
            document.getElementById("ctl00_contentPlaceHolder1_DropDownListTypeSousSol").style.display = 'none';
            document.getElementById("ctl00_contentPlaceHolder1_DropDownListTypeCuisine").style.display = 'none';

            document.getElementById("terrasse").style.display = 'none';
            document.getElementById("nombre_wc").style.display = 'none';
            document.getElementById("nombre_salles_bain").style.display = 'none';
            document.getElementById("nombre_salles_eau").style.display = 'none';
    
            document.getElementById("nombre_caves").style.display = 'none';

            document.getElementById("etage").style.display = 'none';

            document.getElementById("code_etage").style.display = 'none';

            document.getElementById("type_chauffage").style.display = 'none';
        
            document.getElementById("balcon").style.display = 'none';

            document.getElementById("type_chauffage").style.display = 'none';
            document.getElementById("type_sous_sol").style.display = 'none';
            document.getElementById("ctl00_contentPlaceHolder1_DropDownListTypeChauffage").style.display = 'none';

            document.getElementById("facade_terrain").style.display = 'none';
            document.getElementById("profondeur_terrain").style.display = 'none';
            document.getElementById("cos_terrain").style.display = 'none';
            document.getElementById("shon_terrain").style.display = 'none';
            document.getElementById("eau").style.display = 'none';
            document.getElementById("gaz").style.display = 'none';
            document.getElementById("electricite").style.display = 'none';
            document.getElementById("tout_a_legout").style.display = 'none';
            document.getElementById("alignement").style.display = 'none';
            document.getElementById("lotissement").style.display = 'none';
            document.getElementById("numero_lotissement").style.display = 'none';

        }

        if (strUser == "Local") {
            //alert(strUser);

            // visible
            document.getElementById("categorie").style.display = 'table-row';
            document.getElementById("annee_construction").style.display = 'table-row';

            document.getElementById("nombre_pieces").style.display = 'none';
            document.getElementById("etage").style.display = 'table-row';
            document.getElementById("nombre_etages").style.display = 'table-row';
            document.getElementById("nombre_parking_interieurs").style.display = 'table-row';
            document.getElementById("nombre_parking_exterieurs").style.display = 'table-row';
            document.getElementById("lettre_conso").style.display = 'table-row';
            document.getElementById("nombre_conso").style.display = 'table-row';
            document.getElementById("lettre_energie").style.display = 'table-row';
            document.getElementById("nombre_energie").style.display = 'table-row';
            document.getElementById("type_sous_sol").style.display = 'none';
            document.getElementById("fieldset_InfoCompl").style.display = 'block';
            document.getElementById("fieldset_DPE").style.display = 'block';


            document.getElementById("fieldset_CaracPrincip").className = "fieldset_4champs";
            document.getElementById("fieldset_InfoCompl").className = "fieldset_4champs";
            document.getElementById("fieldset_DispoInt").className = "fieldset_4champs";
            document.getElementById("fieldset_DPE").className = "fieldset_4champs";
            
            
            //invisible

            document.getElementById("ascenseur").style.display = 'none';
            
            document.getElementById("nombre_garages").style.display = 'none';
            document.getElementById("surface_terrain").style.display = 'none'; 
            document.getElementById("surface_habitable").style.display = 'none';
            document.getElementById("surface_carrez").style.display = 'none';
            document.getElementById("surface_sejour").style.display = 'none';
            document.getElementById("type_cuisine").style.display = 'none';
            document.getElementById("nombre_chambres").style.display = 'none';
            document.getElementById("murs_mitoyens").style.display = 'none';
            document.getElementById("exposition_sejour").style.display = 'none';

            document.getElementById("ctl00_contentPlaceHolder1_DropDownListNatureChauffage").style.display = 'none';
            document.getElementById("ctl00_contentPlaceHolder1_DropDownListTypeSousSol").style.display = 'none';
            document.getElementById("ctl00_contentPlaceHolder1_DropDownListTypeCuisine").style.display = 'none';

            document.getElementById("terrasse").style.display = 'none';
            document.getElementById("nombre_wc").style.display = 'none';
            document.getElementById("nombre_salles_bain").style.display = 'none';
            document.getElementById("nombre_salles_eau").style.display = 'none';

            document.getElementById("nombre_caves").style.display = 'none';
            document.getElementById("code_etage").style.display = 'none';

            document.getElementById("type_chauffage").style.display = 'none';
            document.getElementById("nature_chauffage").style.display = 'none';
            document.getElementById("balcon").style.display = 'none';

            document.getElementById("type_chauffage").style.display = 'none';

            document.getElementById("ctl00_contentPlaceHolder1_DropDownListTypeChauffage").style.display = 'none';

            document.getElementById("facade_terrain").style.display = 'none';
            document.getElementById("profondeur_terrain").style.display = 'none';
            document.getElementById("cos_terrain").style.display = 'none';
            document.getElementById("shon_terrain").style.display = 'none';
            document.getElementById("eau").style.display = 'none';
            document.getElementById("gaz").style.display = 'none';
            document.getElementById("electricite").style.display = 'none';
            document.getElementById("tout_a_legout").style.display = 'none';
            document.getElementById("alignement").style.display = 'none';
            document.getElementById("lotissement").style.display = 'none';
            document.getElementById("numero_lotissement").style.display = 'none';

        }
            
            
    }
    
    //Effectue en direct les calculs liant le prix de vente, les honoraires, le porcentage vendeur et le net venteur.
function from_net_vendeur(thi) 
{
var regex = /^[0-9]+(.[0-9]+)?$/ ;                    

var prix_de_vente;
var prix_de_vente= document.getElementById("ctl00_contentPlaceHolder1_TextBoxPrixVente").value;
var honoraires_vendeur = document.getElementById("ctl00_contentPlaceHolder1_TextBoxHonoraires").value;
var pourcentage_vendeur= document.getElementById("ctl00_contentPlaceHolder1_TextBoxPourcentageVendeur").value;
var net_vendeur= document.getElementById("ctl00_contentPlaceHolder1_TextBoxNetVendeur").value;

    if(regex.test(prix_de_vente) && regex.test(net_vendeur))
    {
    //alert('net vendeur valide');
        if(prix_de_vente  != 0 )
        {
               //pourcentage_vendeur ='33';
               document.getElementById("ctl00_contentPlaceHolder1_TextBoxPourcentageVendeur").value  = Math.round(((prix_de_vente  - net_vendeur )/prix_de_vente  * 100)*100)/100; 
               document.getElementById("ctl00_contentPlaceHolder1_TextBoxHonoraires").value  = prix_de_vente  - net_vendeur ;                        
        }
    }
    
}    
    
    
function from_pourcentage_vendeur() 
{
var regex = /^[0-9]+(.[0-9]+)?$/;                    

var prix_de_vente;
var prix_de_vente= document.getElementById("ctl00_contentPlaceHolder1_TextBoxPrixVente").value;
var honoraires_vendeur = document.getElementById("ctl00_contentPlaceHolder1_TextBoxHonoraires").value;
var pourcentage_vendeur= document.getElementById("ctl00_contentPlaceHolder1_TextBoxPourcentageVendeur").value;
var net_vendeur= document.getElementById("ctl00_contentPlaceHolder1_TextBoxNetVendeur").value;

 
   // alert('pourcentage valide');
        if(prix_de_vente  > 0)
        {
                  
            document.getElementById("ctl00_contentPlaceHolder1_TextBoxHonoraires").value = Math.round((prix_de_vente * pourcentage_vendeur / 100) * 100)/100;
            document.getElementById("ctl00_contentPlaceHolder1_TextBoxNetVendeur").value = Math.round((prix_de_vente - prix_de_vente * pourcentage_vendeur / 100)*100)/100;
        }
      
}
    
    
function from_honoraires_vendeur() 
{
var regex = /^[0-9]+(.[0-9]+)?$/ ;                    

var prix_de_vente;
var prix_de_vente= document.getElementById("ctl00_contentPlaceHolder1_TextBoxPrixVente").value;
var honoraires_vendeur = document.getElementById("ctl00_contentPlaceHolder1_TextBoxHonoraires").value;
var pourcentage_vendeur= document.getElementById("ctl00_contentPlaceHolder1_TextBoxPourcentageVendeur").value;
var net_vendeur= document.getElementById("ctl00_contentPlaceHolder1_TextBoxNetVendeur").value;



    if(regex.test(honoraires_vendeur) && regex.test(prix_de_vente))
    {
   // alert('honoraires valide');
        if (prix_de_vente > 0) {
               document.getElementById("ctl00_contentPlaceHolder1_TextBoxPourcentageVendeur").value  = Math.round(((prix_de_vente  - (prix_de_vente  - honoraires_vendeur ))/ (prix_de_vente ) * 100) * 100) / 100;    
               document.getElementById("ctl00_contentPlaceHolder1_TextBoxNetVendeur").value  = prix_de_vente  - honoraires_vendeur;                   
        }
    }   
}
       