<%@ Page Language="C#" MasterPageFile="~/pages/MasterPageAndroid.master" AutoEventWireup="true" CodeFile="fichedetail1.aspx.cs" Inherits="pages_fichedetail1" Title="PATRIMONIUM : Détail de l'offre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" src="../JavaScript/ajax_listeLieu.js"></script>
<script type="text/javascript" src="../JavaScript/addVideo.js"></script>
<script type="text/javascript" src="../JavaScript/script.js"></script>
<script type="text/javascript" src="../JavaScript/packed.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<style type="text/css">
.tooltiploupe {position: absolute;}

.tooltiploupe span
{
	display: none;
	white-space: nowrap;
	padding: 4px;
	font-size:16pt;
}
    
    

</style>
<link rel="stylesheet" type="text/css" href="./android.css">

<script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?sensor=false&language=fr">
</script>
<script type='text/javascript'
src='http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js?ver=1.4.2'></script>


<script type="text/javascript" language="javascript">

    function selectText(element) {
        var doc = document;
        var text = doc.getElementById(element);

        if (doc.body.createTextRange) { // ms
            var range = doc.body.createTextRange();
            range.moveToElementText(text);
            range.select();
        } else if (window.getSelection) { // moz, opera, webkit
            var selection = window.getSelection();
            var range = doc.createRange();
            range.selectNodeContents(text);
            selection.removeAllRanges();
            selection.addRange(range);
        }
    }


    function afficher_cacher(id) {
        
        if (document.getElementById(id).style.visibility == "hidden") {
            document.getElementById(id).style.visibility = "visible";
            document.getElementById('bouton_' + id).innerHTML = "<img src='../img_site/flat_round/partager.png' style='margin-bottom:-10px;margin-left:5px;margin-right:5px;margin-top:5px' width='24px'><strong> Cacher lien</strong>";

        }
        else {
            document.getElementById(id).style.visibility = "hidden";
            document.getElementById('bouton_' + id).innerHTML = "<img src='../img_site/flat_round/partager.png' style='margin-bottom:-10px;margin-left:5px;margin-right:5px;margin-top:5px' width='24px'><strong> Partager lien</strong>";
        }
        return true;
    }

    afficher_cacher('texte');

	function popUp(URL) 
	{
		day = new Date();
		id = day.getTime();
		eval("page" + id + " = window.open(URL, '" + id + "', 'toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=no,width=430,height=430,left = 440,top = 312');");
	}
	
    function metGrosseImage(srcNew)
    {
        var grosseImage = document.getElementById("grosseImage");
        grosseImage.src = srcNew;
        return true;
    }

    function affichage_popup(nom_de_la_page, nom_interne_de_la_fenetre)
    {
        window.open(nom_de_la_page, nom_interne_de_la_fenetre)
    }

    function affichage(bloc) 
    {	
        if ( document.getElementById(bloc).getAttribute("className")  == "contenu_ferme" )
        {
            document.getElementById(bloc).setAttribute("className","contenu_ouvert");
        }
        else
        {
            document.getElementById(bloc).setAttribute("className","contenu_ferme");
        }
    }
	
	$(function()
		{
			if($("#videoAnnonce").html() != "")
				addVideo($("#videoAnnonce").html());
		}

	);
    
</script>
<script language="javascript" type="text/javascript">
     function carte_google() {
         window.open('https://maps.google.fr/maps?hl=fr&authuser=1&q=<%=b.VILLE_BIEN %>+<%=b.PAYS%>');
     }

                    </script>
<script type="text/javascript">
    var geocoder;
    var map;
    // initialisation de la carte Google Map de départ
    function initialiserCarte() {
        geocoder = new google.maps.Geocoder();
        // Ici j'ai mis la latitude et longitude du vieux Port de Marseille pour centrer la carte de départ
        var latlng;
        var mapOptions = {
            zoom: 16,
            center: latlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        }
        // map-canvas est le conteneur HTML de la carte Google Map
        map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
    }

    function TrouverAdresse() {
        // Récupération de l'adresse tapée dans le formulaire
        var adresse = document.getElementById('adresse').value;
        geocoder.geocode({ 'address': adresse }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                map.setCenter(results[0].geometry.location);
                // Récupération des coordonnées GPS du lieu tapé dans le formulaire
                var strposition = results[0].geometry.location + "";
                strposition = strposition.replace('(', '');
                strposition = strposition.replace(')', '');
                // Affichage des coordonnées dans le <span>
                document.getElementById('text_latlng').innerHTML = 'Coordonnées : ' + strposition;
                // Création du marqueur du lieu (épingle)
                var marker = new google.maps.Marker({
                    map: map,
                    position: results[0].geometry.location
                });
            } else {
                alert('Adresse introuvable: ' + status);
            }
        });
    }
    // Lancement de la construction de la carte google map
    google.maps.event.addDomListener(window, 'load', initialiserCarte);
    google.maps.event.addDomListener(window, 'load', TrouverAdresse);
</script>

<br />
<asp:Label ID="LBLerreur" Visible=false runat="server" />

<br />
<div style="display:inline-block;width:70%;text-align:center"><strong><asp:Label ID="LBLNav" runat="server"/></strong></div>

<asp:Panel ID="ficheDetail_Panel" style="font-family:PT Sans" runat="Server" Visible="false">
   
   <br /><br />


    <center><strong><asp:Label ID="LBLTitre" style="font-size: 25pt;" runat="server" /></strong></center>
    <br />
            <!-- Colonne principale-->
            <div width="100%" style="vertical-align:top">

                <!-- Photos -->
                <div class="bloc_fichedetail">
                <br />
                <center>
                    <asp:Label ID="LBLPhotos" runat="server" />
                </center>
                </div>
                <br />

                <!-- Texte internet -->
                <asp:Panel ID="Texte_Panel" Visible="true" runat="server">
                    <div class="bloc_fichedetail">
                        <br/>
                        <center>
                            <asp:Label ID="LBLTexteInternet" style="font-size: 16pt;" runat="server" />
                        </center>
                        <div style="margin-left:5px;margin-bottom:3px; font-size: 14pt;font-weight:bold"> Reference : <%=b.REFERENCE %></div>
                    </div>
                </asp:Panel>

                <!-- infos complementaires-->
                <div class="bloc_fichedetail" style="min-height:100px">
                    <asp:Label ID="LBLInfoCompl" runat="server" />
                </div>

                <!-- Consommation energetique-->
                <asp:Panel ID="Conso_Panel" runat="server">
                     <div class="bloc_fichedetail" >
                        <table width="100%">
                            <tr>
                                <asp:Label ID="LBLConso" runat="server"></asp:Label>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
                <br />
            </div>


            <!-- COLONNE DE DROITE -->
            <div width="100%" style="vertical-align:top">
            

                <!-- INFOS IMPORTANTES -->
                <div class="bloc_fichedetail">
                   
                    <table width='100%'>
                    
                        <tr>
                            <td colspan='2' style='border-bottom: 1px solid lightgrey;'>
                            <center>
                                <div style='font-size: 35px;'> <asp:Label ID="LBLPrix" runat="server"/> </div>
                            </center>
                            </td>
                        </tr>
                        <tr>
                            <td style='border-bottom: 1px solid lightgrey;'>
                            <center>
                                <div style='font-size: 25px;text-align:right;margin-right:15px'><asp:Label ID="LBLSurface" runat="server"/></div>
                            </center>
                            </td>
                            <asp:Label ID="LBLPieces" runat="server"/>
                        </tr>
                            <asp:Label ID="LBLPrixMetre" runat="server" />
                            <asp:Label ID="LBLIcone" runat="server" />
                    </table>
                </div>
                <br />

                
                <!-- Localisation-->
                <div class="bloc_fichedetail" >
                    <center>
                    <div class='new_span' style="display:inline-block">
				        <img style='margin-bottom:-5px' src='../img_site/drapeau/<%=b.CODEPAYS%>.png' alt='<%=b.CODEPAYS%>'/>
				        <span style="margin-left:15px;margin-top:-25px;"><%=b.PAYS%></span>
			        </div>
                    <div class='new_span' style="display:inline-block">
                        <a href='javascript:carte_google()'>
                        <img style='margin-top:-3px;margin-bottom:-3px ' src='../img_site/flat_round/monde.png' alt='<%=b.VILLE_BIEN%>' height="20px" width="20px"/>
                        </a>
                        <span style="margin-left:15px;margin-top:-25px;">Géolocalisation</span>
			        </div>

                           <div style='font-size: 25px;display:inline-block'><strong> <%=b.VILLE_BIEN.ToUpper()%> (<%=b.CODE_POSTAL_BIEN %>) </strong></div>
                    </center>
                    <hr />
                     <div id="map-canvas" style="float:right;height:220px;width:100%"></div>
                    <br />
                </div>
                    <br /><br />  
                    <br /><br />  
                    <br /><br />  
                    <br /><br />  
                    <br /><br />  
                    <br /><br />  
                    

                <!-- Negociateur-->
                <div class="bloc_fichedetail">
                    <br/>
                    <center><div style='font-weight: bold;'>Ce bien vous est proposé par :</div><br />
                        <asp:Label ID="LBLNego" runat="server" />
                        <asp:Button ID="BtnSiteNego" runat="server" OnClick="VoirSiteNego" Visible="false" Text="Voir son site" CssClass="flat-button"></asp:Button>
                        <asp:Button ID="Button1" runat="server" OnClick="VoirBiensNego" Text="Voir ses biens" CssClass="flat-button" style="margin-top:5px;"></asp:Button>
                        </center>
                    <br />
                </div>
                <br />


                <!-- Menu boutons-->
                <div class="bloc_fichedetail">
                    
                    <div style="margin-left:15px">
                        <asp:Label ID="LBLMenuBoutons" runat="server" />
                        <div id='texte' class='texte'  style='visibility:hidden'>
                        <br />
                            <asp:TextBox ID="tabpartage" width="80%" runat="server" onfocus="this.select();" onmouseup="return false;" />
                        </div>
                    </div> 
                </div>
                <br />
                 <!-- Admin Panel -->
                <asp:Panel ID="Admin_Panel" runat="server" Visible="false">
                    <div class="bloc_fichedetail" style=" border: 2px solid red">
                    <asp:Label Id="lbl_dates" runat="server" ></asp:Label>
                    <table style="width:100%;border-bottom: 1px solid lightgrey;border-top: 1px solid lightgrey;margin-bottom:3px;margin-top:3px;">
			            <tr>
				            <td>Consultation fiche
					            <div class="tooltipContainer cursor_link">
						            ( <span style="color:#717171;text-decoration:underline">?</span> )
						            <div class="tooltip2" style="margin-left:-150px">
							            <span>Nombre de fois où la fiche détaillée<br/>de l'annonce a été consultée.<br/>Vos visites ne sont pas comptabilisées.</span>
						            </div>
					            </div>
				            </td>
				            <td class="bold taright"><%=b.VISITEFICHED%> fois</td>
			            </tr>
			            <tr>
				            <td>Annonce vue 
					            <div class="tooltipContainer cursor_link">
						            ( <span style="color:#717171;text-decoration:underline">?</span> )
						            <div class="tooltip2" style="margin-left:-150px">
							            <span>Nombre de fois où cette annonce est apparue<br/>dans les résultats d'une recherche</span>
						            </div>
					            </div>
				            </td>
				            <td class="bold taright"><%=b.NBRESULTRECHERCHE%> fois</td>
			            </tr>
		            </table>
		            <a href="fichedetail1_stats.aspx?ref=<%=Request.QueryString["ref"]%>" style="margin-left:15px; color:black"><strong>Voir plus de stats</strong></a>
                    <br />
                    <br />
                    <asp:Label ID="LBLModifBien" runat="server" />
                   
                    <asp:Label ID="LBL_Envois" runat="server" />

                    </div>
                    <br />
                </asp:Panel>
    </div>


     <br />
     <div style="display:inline-block;width:70%;text-align:center"><strong><asp:Label ID="LBLNav2" runat="server"/></strong></div>
     <br />

</asp:Panel>

<br /><br />


<!-- Des choses invisibles ... -->
<input type="text" runat="server" id="adresse" clientidmode="Static" style="display:none"/>

</asp:Content>
