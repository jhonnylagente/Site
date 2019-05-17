<%@ Page Language="C#"  MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="Recherche_agent.aspx.cs" Inherits="pages_ajout_acquereur" Title="PATRIMONIUM : Mon espace client" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<script type="text/javascript">
    var saisi = "#saisie";
    var champPays = "#<%=textBoxPays.ClientID%>";
    var champDep = "#<%=textBoxDep.ClientID%>";
    var champVille = "#<%=textBoxVille.ClientID%>";
</script>

<script type="text/javascript" src="../JavaScript/ajax_listeLieu.js"></script>
<script type="text/javascript" src="../JavaScript/ajax_saisieLieu.js"></script>

<script type="text/javascript">
    function guiAddLieu(input, name, code) {

        $("#listeFiltreLieu").append("<div id='LL_" + code.toString().replace(" ", "_") + "' class='boxLieu_PlusGros' style='margin-left:10px;'>" 
									+ "<img onclick=\"removeLieu('" + input + "', '" + code.toString() + "')\" src='../img_site/boutton_Supprimer.png' alt='Retirer' class='cursor_link' style='margin-left:5px;margin-bottom:-5px'>&nbsp;"
									+ "<div style='margin-top:5px ; float:right'>" + name + "&nbsp&nbsp</div>" + "</div>");

        $("#<%=textBoxVille1.ClientID%>").val('');
        $s = $("#<%=saisieLoc.ClientID%>").val() + code.toString() + " ";
        $("#<%=saisieLoc.ClientID%>").val($s);
    
    }

    function removeLieu(input, code) {
        var regex = new RegExp(code + "[^,]*,");
        var newChaine = $(input).val().replace(regex, "");
        $(input).val(newChaine);
        $("#LL_" + code.replace(" ", "_")).remove();

        var text = $("#<%=saisieLoc.ClientID%>").val();
        text = text.replace(code+" ", " ");
        $("#<%=saisieLoc.ClientID%>").val(text);

    }
</script>

    <script language="javascript" type="text/javascript">

            // <!CDATA[

        function Select1_onchange()
             {
                var url = window.location.href;
                var taille = url.length - 2;
                var partie1 = url.substring(0, taille);
                var temp = new Array();
                    temp = partie1.split('=');
                var temp2 = temp[1].split('&');
                //Quand l'utilisateur affiche davantage d'annonces par pages, il doit être redirigé vers la première page car il se peut que celle sur laquelle il se trouve n'existe plus.
                var url_built = temp[0] + "=1" + "&" + temp2[1] + "=" + temp[2] + "=" + temp[3] + "=" + document.getElementById("Select1").value;
                window.location.href = url_built;
                //window.location.href = partie1+document.getElementById("Select1").value;

             }

    </script>
    
    
        <div id="mapoffranceAgent">
            <div>
                <div>
                    <img id="map" src="../imagemap/francedepartments.png" alt="france" width="275" height="281" border="0"/>
                    <img id="department"  src="../imagemap/blank.png" width="275" height="281" border="0" usemap="#Map"/>
                 </div>
                        <map name="Map"  id="theworldmapimage">
                          <area shape="poly" id="29" coords="22,63,30,63,39,63,39,70,39,75,37,79,40,83,41,86,36,85,31,82,25,85,24,80,19,79"
                                    title="Finistère" href="#" onmouseover="show('finistere')" onmouseout="hide()"
                                    onclick="fillTextBox(29)" />
                          <area shape="poly" id="22" coords="41,61,46,58,51,63,54,69,61,65,64,67,64,72,64,75,59,77,58,78,55,80,47,77,42,79,39,76,38,63"
                                    title="Côtes-d'Armor" href="#" onmouseover="show('cotesdarmor')" onmouseout="hide()"
                                    onclick="fillTextBox(22)" />
                          <area shape="poly" id="56" coords="44,86,46,94,54,94,61,96,63,88,59,80,54,79,47,79,40,79,39,85"href="#" title="Morbihan"
                                    onmouseover="show('Morbihan')" onmouseout="hide()"
                                    onclick="fillTextBox(56)"  />
                          <area shape="poly" id="35" coords="66,66,67,73,64,77,62,80,66,88,69,93,74,90,78,90,81,83,81,80,78,72,73,67,69,65"
                                    href="#" title="Ille-et-Vilaine"
                                    onmouseover="show('IlleetVilaine')" onmouseout="hide()"onclick="fillTextBox(35)"/>
                          <area shape="poly" id="44" coords="65,92,62,96,58,98,56,101,64,105,63,110,69,112,76,112,82,108,77,102,83,100,81,92,73,91"
                                    href="#"title="Loire Atlantique"
                                    onmouseover="show('LoireAtlantique')" onmouseout="hide()"
                                    onclick="fillTextBox(44)" />
                          <area shape="poly" id="50" coords="75,67,75,59,73,52,70,44,69,39,71,39,76,41,80,42,84,49,87,55,85,65,91,68,88,70,82,70"
                                    href="#"title="Manche"
                                    onmouseover="show('manche')" onmouseout="hide()" 
                                    onclick="fillTextBox(50)"/>
                          <area shape="poly" id="53" coords="91,69,97,74,98,81,93,90,88,91,82,87,81,79,79,69,83,71"
                                    href="#" title="Mayenne"
                                    onmouseover="show('Mayenne')" onmouseout="hide()" 
                                    onclick="fillTextBox(53)"/>
                          <area shape="poly" id="49" coords="87,91,81,87,79,92,84,97,81,103,83,109,89,110,97,109,101,105,101,98,101,96,94,92"
                                    href="#" title="Maine-et-Loire"
                                    onmouseover="show('MaineetLoire')" onmouseout="hide()"
                                    onclick="fillTextBox(49)"  />
                          <area shape="poly" id="85" coords="64,110,66,116,70,120,74,128,81,128,88,124,88,114,85,109,79,107,76,113,69,111"
                                    href="#" title="Vendée"
                                    onmouseover="show('Vendee')" onmouseout="hide()" 
                                    onclick="fillTextBox(85)" />
                          <area shape="poly" id="17" coords="78,130,78,135,77,141,81,145,84,151,93,159,98,157,96,149,93,144,96,140,95,134,88,133,87,129,80,128"
                                    href="#" title="Charente-Maritime"
                                    onmouseover="show('CharenteMaritime')" onmouseout="hide()"
                                    onclick="fillTextBox(17)" />
                          <area shape="poly" id="33" coords="79,149,77,155,77,160,75,170,78,174,85,179,92,184,97,182,98,176,100,172,97,167,98,163,95,160,89,157,82,153"
                                    href="#" title="Gironde"
                                    onmouseover="show('Gironde')" onmouseout="hide()"
                                    onclick="fillTextBox(33)" />
                          <area shape="poly" id="40" coords="76,177,74,182,73,189,73,194,71,199,73,203,80,203,89,201,91,201,92,196,94,193,97,193,99,191,97,187,91,184,87,181,82,178,78,175"
                                    href="#" title="Landes"
                                    onmouseover="show('Landes')" onmouseout="hide()" 
                                    onclick="fillTextBox(40)"/>
                          <area shape="poly" id="64" coords="92,218,91,222,86,221,80,218,74,217,71,215,69,212,69,210,67,208,66,207,68,202,70,201,73,203,80,204,86,203,89,200,92,201,95,203,96,206,96,210,93,213"
                                    href="#" title="Pyrénées-Atlantiques"
                                    onmouseover="show('PyreneesAtlantiques')" onmouseout="hide()"  
                                    onclick="fillTextBox(64)"/>
                          <area shape="poly" id="65" coords="107,218,108,221,106,223,106,226,99,225,96,224,93,220,93,213,96,210,97,203,93,200,98,203,102,207,108,208,108,210,107,213"
                                    href="#" title="Hautes-Pyrénées"
                                    onmouseover="show('HautesPyrenees')" onmouseout="hide()" 
                                    onclick="fillTextBox(65)" />
                          <area shape="poly" id="32" coords="118,204,118,199,116,195,114,189,110,188,107,190,102,191,96,193,93,195,93,202,97,203,102,207,107,209,110,208,113,206"
                                    href="#" title="Gers"
                                    onmouseover="show('Gers')" onmouseout="hide()" 
                                    onclick="fillTextBox(32)"/>
                          <area shape="poly" id="47" coords="113,188,115,185,116,182,116,177,114,174,110,172,106,173,104,172,103,172,101,173,99,176,96,184,98,187,101,190,104,191"
                                    href="#" title="Lot-Et-Garonne"
                                    onmouseover="show('LotEtGaronne')" onmouseout="hide()" 
                                    onclick="fillTextBox(47)"/>
                          <area shape="poly" id="24" coords="121,160,120,154,117,151,114,149,111,148,108,150,106,154,102,158,98,160,97,165,100,170,102,173,105,173,110,175,114,175,119,179,119,174,124,172,124,166"
                                    href="#" title="Dordogne"
                                    onmouseover="show('Dordogne')" onmouseout="hide()" 
                                    onclick="fillTextBox(24)"/>
                          <area shape="poly" id="16" coords="101,158,105,155,108,151,111,147,113,143,115,139,113,137,111,134,107,134,107,136,103,135,101,134,97,139,97,141,96,144,96,147,98,153"
                                    href="#" title="Charente"
                                    onmouseover="show('Charente')" onmouseout="hide()" 
                                    onclick="fillTextBox(16)"/>
                          <area shape="poly" id="79" coords="98,122,99,127,101,132,100,137,98,138,94,137,90,134,85,131,82,127,88,124,88,116,87,112,95,112,98,112,98,115,100,118"
                                    href="#"title="Deux-Sèvres "
                                    onmouseover="show('DeuxSevres')" onmouseout="hide()" 
                                    onclick="fillTextBox(79)"/>
                          <area shape="poly" id="14" coords="84,47,89,48,92,48,98,48,103,47,106,46,107,50,108,53,108,57,108,60,99,59,93,61,87,63,84,58,85,53"
                                    href="#"title="Valvados"
                                    onmouseover="show('valvados')" onmouseout="hide()" 
                                    onclick="fillTextBox(14)" />
                          <area shape="poly" id="61" coords="110,59,113,64,114,68,117,73,116,77,115,79,111,76,109,74,107,71,103,73,100,73,100,70,96,69,94,70,90,66,88,61,96,60,103,58"
                                    href="#" title="orne"
                                    onmouseover="show('Orne')" onmouseout="hide()"
                                    onclick="fillTextBox(61)" />
                          <area shape="poly" id="72" coords="104,72,108,75,112,80,114,80,114,85,113,90,109,92,104,95,100,93,95,90,94,84,96,79,95,70"
                                    href="#"title="Sarthe"
                                    onmouseover="show('Sarthe')" onmouseout="hide()" 
                                    onclick="fillTextBox(72)" />
                          <area shape="poly" id="37" coords="114,92,117,94,119,98,121,101,121,104,124,106,124,110,123,111,120,111,119,115,120,119,117,121,114,117,113,115,110,111,104,112,103,108,102,104,103,98,105,95,108,94"
                                    href="#" title="Indre-et-Loire"
                                    onmouseover="show('IndreetLoire')" onmouseout="hide()"
                                    onclick="fillTextBox(37)" />
                          <area shape="poly" id="86" coords="120,122,122,125,121,130,119,129,117,135,112,135,106,133,103,125,100,117,99,111,100,105,104,111,109,112,112,116"
                                    href="#" title="Vienne"
                                    onmouseover="show('Vienne')" onmouseout="hide()"
                                    onclick="fillTextBox(86)" />
                          <area shape="poly" id="76" coords="126,31,129,34,131,39,132,44,132,49,128,46,125,48,123,50,118,48,115,45,109,45,107,46,105,43,105,38,110,35,121,33,117,33"
                                    href="#"title="Seine-Maritime"
                                    onmouseover="show('SeineMaritime')" onmouseout="hide()"  
                                    onclick="fillTextBox(76)"/>
                          <area shape="poly" id="27" coords="131,51,129,54,127,58,127,61,124,63,116,66,114,61,109,55,109,50,109,46,113,45,122,47,126,47"
                                    href="#" title="Eure"
                                    onmouseover="show('Eure')" onmouseout="hide()" 
                                    onclick="fillTextBox(27)"/>
                          <area shape="poly" id="28" coords="127,63,132,72,131,77,133,80,135,81,134,87,127,90,120,90,115,85,114,78,114,71,118,66"
                                    href="#"title="Eure-Et-Loir"
                                    onmouseover="show('EureEtLoir')" onmouseout="hide()"  
                                    onclick="fillTextBox(28)"/>
                          <area shape="poly" id="41" coords="128,86,129,90,131,92,135,93,141,94,141,96,139,100,137,106,131,104,127,104,122,102,120,97,116,94,113,91,114,87,115,82,116,80,120,82,123,84"
                                    href="#"title="Loir-et-Cher"
                                    onmouseover="show('LoiretCher')" onmouseout="hide()" 
                                    onclick="fillTextBox(41)" />
                          <area shape="poly" id="36" coords="124,104,128,104,132,106,133,108,136,107,137,110,139,116,140,119,140,123,140,126,139,127,133,126,131,127,126,128,122,128,120,124,119,118,120,112"
                                    href="#" title="Indre"
                                    onmouseover="show('Indre')" onmouseout="hide()"
                                    onclick="fillTextBox(36)" />
                          <area shape="poly" id="87" coords="125,131,126,134,127,136,129,138,132,142,133,145,134,147,134,148,131,151,128,153,125,155,123,155,120,152,118,150,113,149,112,147,114,142,115,140,114,137,118,133,120,131"
                                    href="#" title="Haute-Vienne"
                                    onmouseover="show('HauteVienne')" onmouseout="hide()"
                                    onclick="fillTextBox(87)" />
                          <area shape="poly" id="19" coords="125,153,123,156,124,160,128,163,130,164,132,164,134,164,136,164,139,163,139,162,140,160,140,157,142,154,143,153,146,151,146,148,146,146,142,146,140,146,137,146,132,145,130,147"
                                    href="#" title="Corrèze"
                                    onmouseover="show('Correze')" onmouseout="hide()" 
                                    onclick="fillTextBox(19)"/>
                          <area shape="poly" id="23" coords="132,144,132,141,128,139,127,136,125,134,124,127,131,128,138,127,140,128,143,130,145,134,146,138,145,142,145,144,142,145,138,145"
                                    href="#" title="Creuse"
                                    onmouseover="show('Creuse')" onmouseout="hide()" 
                                    onclick="fillTextBox(23)"/>
                          <area shape="poly" id="46" coords="124,169,123,173,119,178,119,181,121,184,125,186,130,186,134,185,133,179,136,177,138,171,137,167,131,166,126,166"
                                    href="#" title="Lot"
                                    onmouseover="show('Lot')" onmouseout="hide()"
                                    onclick="fillTextBox(46)" />
                          <area shape="poly" id="82" coords="117,179,116,184,116,187,114,192,115,195,117,199,119,203,119,200,123,197,126,195,130,192,131,190,133,188,133,185,129,185,123,184,120,183,118,180"
                                    href="#" title="Tarn-et-Garonne"
                                    onmouseover="show('TarnetGaronne')" onmouseout="hide()"
                                    onclick="fillTextBox(31)" />
                          <area shape="poly" id="31" coords="126,197,130,202,132,203,135,206,135,208,134,209,127,212,123,212,119,214,115,217,115,221,115,222,112,222,110,220,109,216,108,216,108,210,108,208,109,207,114,206,115,205,116,201,118,200,119,198,121,197"
                                    href="#" title="Haute-Garonne"
                                    onmouseover="show('HauteGaronne')" onmouseout="hide()"
                                    onclick="fillTextBox(09)" />
                          <area shape="poly" id="62" coords="141,6,143,9,146,13,148,15,154,16,156,20,158,26,159,32,151,30,143,28,137,24,132,21,132,11,135,7"
                                    href="#" title="Pas-de-Calais"
                                    onmouseover="show('PasdeCalais')" onmouseout="hide()" 
                                    onclick="fillTextBox(62)"/>
                          <area shape="poly" id="59" coords="138,4,143,3,147,4,147,9,151,11,155,11,158,14,161,17,163,19,167,21,170,23,173,26,174,29,168,30,159,30,153,24,151,16,144,13,139,9"
                                    href="#" title="Nord"
                                    onmouseover="show('Nord')" onmouseout="hide()"
                                    onclick="fillTextBox(59)" />
                          <area shape="poly" id="80" coords="126,30,128,26,128,21,133,24,138,27,144,27,151,31,155,34,154,38,148,41,139,40,134,38,129,35"
                                    href="#" title="Somme"
                                    onmouseover="show('Somme')" onmouseout="hide()" 
                                    onclick="fillTextBox(80)"/>
                          <area shape="poly" id="45" coords="132,89,135,85,137,80,139,78,144,78,149,81,153,83,155,87,154,93,151,97,146,97,139,94"
                                    href="#" title="Loiret"
                                    onmouseover="show('Loiret')" onmouseout="hide()"
                                    onclick="fillTextBox(45)" />
                          <area shape="poly" id="18" coords="139,117,138,111,137,106,139,99,142,94,150,98,152,103,153,109,155,115,152,119,146,120,147,122,143,125,142,126"
                                     href="#" title="Cher"
                                    onmouseover="show('Cher')" onmouseout="hide()"
                                    onclick="fillTextBox(18)"/>
                          <area shape="poly" id="03" coords="141,127,144,131,147,134,149,133,155,135,162,136,168,138,169,131,171,128,167,122,164,119,158,120,155,118,149,120,147,122" 
                                    href="#"title="Allier"
                                    onmouseover="show('Allier')" onmouseout="hide()"
                                    onclick="fillTextBox(03)" />
                          <area shape="poly" id="63" coords="147,134,147,139,146,143,146,148,146,151,149,155,155,156,159,154,165,155,170,155,172,150,168,143,166,137,159,137,152,135" 
                                    href="#" title="Puy-de-Dôme"
                                    onmouseover="show('PuydeDome')" onmouseout="hide()"
                                    onclick="fillTextBox(63)"/>
                          <area shape="poly" id="60" coords="155,38,151,40,148,43,143,41,135,39,133,43,134,49,136,52,140,53,147,54,151,56,155,56,154,51,154,44" 
                                    href="#"title="Oise"
                                    onmouseover="show('Oise')" onmouseout="hide()"
                                    onclick="fillTextBox(60)" />
                          <area shape="poly" id="15" coords="156,155,152,155,148,153,144,151,142,156,140,161,136,164,139,169,141,172,146,169,150,165,153,169,157,165,160,161,157,157" 
                                     href="#"title="Cantal"
                                    onmouseover="show('Cantal')" onmouseout="hide()"
                                    onclick="fillTextBox(15)" />
                          <area shape="poly" id="43" coords="175,155,171,157,166,157,160,156,159,160,162,165,164,168,168,170,174,169,177,165,180,160,178,155"  
                                     href="#"title="Haute-Loire"
                                    onmouseover="show('HauteLoire')" onmouseout="hide()"
                                    onclick="fillTextBox(43)" />
                          <area shape="poly" id="12" coords="150,168,146,171,145,174,141,175,136,178,135,182,138,187,144,189,147,195,154,198,160,193,157,185,154,173"  
                                     href="#"title="Aveyron"
                                    onmouseover="show('Aveyron')" onmouseout="hide()"
                                    onclick="fillTextBox(12)" />
                          <area shape="poly" id="81" coords="144,193,141,189,137,187,135,189,130,193,127,197,132,202,137,206,143,206,147,206,149,202,153,199,147,196"  
                                     href="#"title="Tarn"
                                    onmouseover="show('Tarn')" onmouseout="hide()"
                                    onclick="fillTextBox(81)" />
                          <area shape="poly" id="09" coords="130,212,125,212,120,214,117,218,118,223,122,226,127,228,132,228,136,226,133,223,135,218,131,215"  
                                     href="#"title="Ariège"
                                    onmouseover="show('Ariege')" onmouseout="hide()"
                                    onclick="fillTextBox(09)" />
                          <area shape="poly" id="66" coords="131,229,132,231,137,235,141,233,146,236,151,233,157,232,155,227,155,220,148,222,142,224,136,227"  
                                     href="#"title="Pyrénées-Orientales"
                                    onmouseover="show('PyreneesOrientales')" onmouseout="hide()"
                                    onclick="fillTextBox(66)" />
                          <area shape="poly" id="11" coords="148,210,145,208,140,207,136,209,132,211,134,214,136,218,135,223,137,225,142,223,150,222,154,220,157,212,151,209"  
                                     href="#"title="Aude"
                                    onmouseover="show('Aude')" onmouseout="hide()"
                                    onclick="fillTextBox(11)" />
                          <area shape="poly" id="34" coords="160,194,158,198,153,200,149,204,148,209,151,209,157,211,162,211,166,208,173,204,177,201,173,196,169,192,162,195"  
                                     href="#"title="Hérault"
                                    onmouseover="show('Herault')" onmouseout="hide()"
                                    onclick="fillTextBox(34)" />
                          <area shape="poly" id="30" coords="182,182,179,184,175,182,173,186,169,189,164,189,160,188,162,194,169,193,173,197,177,201,179,204,182,200,185,196,187,192,186,187" 
                                     href="#"title="Gard"
                                    onmouseover="show('Gard')" onmouseout="hide()"
                                    onclick="fillTextBox(30)" />
                          <area shape="poly" id="48" coords="167,170,163,168,159,167,157,171,156,176,158,181,160,185,163,187,169,188,172,187,172,180,170,173"  
                                     href="#"title="Lozère"
                                    onmouseover="show('Lozere')" onmouseout="hide()"
                                    onclick="fillTextBox(48)" />
                          <area shape="poly" id="02" coords="173,31,170,32,166,32,161,32,156,33,157,39,157,43,156,48,156,52,157,57,160,61,162,60,163,57,164,52,168,49,170,48,170,42,173,39,173,34" 
                                     href="#"title="Aisne"
                                    onmouseover="show('Aisne')" onmouseout="hide()"
                                    onclick="fillTextBox(02)" />
                          <area shape="poly" id="08" coords="185,35,184,31,184,27,181,33,178,33,173,34,174,39,173,43,173,47,176,48,180,51,185,51,189,46,189,42,189,39,187,36"  
                                    href="#"title="Ardennes"
                                    onmouseover="show('Ardennes')" onmouseout="hide()"
                                    onclick="fillTextBox(08)" />
                          <area shape="poly" id="51" coords="179,51,175,50,173,48,169,50,165,53,165,57,164,61,162,63,164,67,167,71,171,66,177,67,181,70,185,67,186,62,187,58,187,54,183,52"  
                                     href="#"title="Marne"
                                    onmouseover="show('Marne')" onmouseout="hide()"
                                    onclick="fillTextBox(51)" />
                          <area shape="poly" id="10" coords="182,71,179,70,175,68,171,69,169,71,164,71,163,73,165,77,168,80,170,84,175,85,179,84,183,81,185,77,182,74" 
                                     href="#"title="Aube"
                                    onmouseover="show('Aube')" onmouseout="hide()"
                                    onclick="fillTextBox(10)" />
                          <area shape="poly" id="52" coords="195,73,193,71,189,69,187,66,183,69,185,74,186,78,186,81,186,84,190,88,190,92,194,93,198,92,201,90,202,86,200,82,199,78,196,77"  
                                     href="#"title="Haute-Marne"
                                    onmouseover="show('HauteMarne')" onmouseout="hide()"
                                    onclick="fillTextBox(52)" />
                          <area shape="poly" id="89" coords="169,84,166,80,162,76,158,74,155,77,155,83,156,86,156,92,155,95,158,96,163,96,168,99,173,101,173,96,175,92,175,87,172,85"  
                                     href="#"title="Yonne"
                                    onmouseover="show('Yonne')" onmouseout="hide()"
                                    onclick="fillTextBox(89)" />
                          <area shape="poly" id="21" coords="192,93,188,93,188,88,186,85,182,84,177,86,177,91,175,96,175,100,174,105,178,108,184,111,189,112,194,112,196,108,197,103,196,98,194,94" 
                                     href="#"title="Côte-d'Or"
                                    onmouseover="show('CotedOr')" onmouseout="hide()"
                                    onclick="fillTextBox(21)" />
                          <area shape="poly" id="58" coords="175,107,173,104,169,101,164,99,158,98,152,97,153,102,155,107,156,114,154,118,158,120,162,119,166,119,170,119,172,116,173,110"  
                                     href="#"title="Nièvre"
                                    onmouseover="show('Nievre')" onmouseout="hide()"
                                    onclick="fillTextBox(58)" />
                          <area shape="poly" id="71" coords="186,114,182,112,178,109,174,111,173,116,171,119,167,120,168,123,171,126,171,131,175,133,180,131,184,131,188,127,190,124,195,126,196,121,196,114,191,112" 
                                     href="#"title="Saône-et-Loire"
                                    onmouseover="show('SaoneetLoire')" onmouseout="hide()"
                                    onclick="fillTextBox(71)" />
                          <area shape="poly" id="55" coords="192,40,194,44,198,47,200,53,202,59,201,64,201,70,196,73,193,70,189,67,187,60,187,52,189,46"  
                                     href="#"title="Meuse"
                                    onmouseover="show('Meuse')" onmouseout="hide()"
                                    onclick="fillTextBox(55)" />
                          <area shape="poly" id="54" coords="205,50,203,47,202,44,198,43,199,48,201,50,202,56,203,60,201,64,202,68,205,72,208,71,213,72,216,71,220,72,223,69,218,66,213,64,208,60,205,56"  
                                     href="#"title="Meurthe-et-Moselle"
                                    onmouseover="show('MeurtheetMoselle')" onmouseout="hide()"
                                    onclick="fillTextBox(54)" />
                          <area shape="poly" id="57" coords="226,53,222,51,217,51,214,48,211,44,207,44,203,44,205,49,207,53,207,57,210,60,213,63,217,65,222,68,225,67,226,63,223,60,223,57,226,56,230,57,231,53,228,52"  
                                     href="#"title="Moselle"
                                    onmouseover="show('Moselle')" onmouseout="hide()"
                                    onclick="fillTextBox(57)" />
                          <area shape="poly" id="88" coords="224,70,219,73,212,72,205,72,201,72,197,74,198,77,201,78,201,82,203,86,207,83,211,84,216,85,219,86,222,85,223,79,224,74"  
                                     href="#"title="Vosges"
                                    onmouseover="show('Vosges')" onmouseout="hide()"
                                    onclick="fillTextBox(88)" />
                          <area shape="poly" id="67" coords="242,55,238,54,233,54,230,57,226,57,223,59,226,61,227,65,227,67,225,70,226,73,230,75,233,78,235,72,236,66,239,61,242,58"  
                                     href="#"title="Bas-Rhin"
                                    onmouseover="show('BasRhin')" onmouseout="hide()"
                                    onclick="fillTextBox(67)" />
                          <area shape="poly" id="68" coords="233,80,230,76,225,74,224,79,223,84,222,87,224,89,225,93,228,95,230,98,232,94,233,87,233,82"  
                                     href="#"title="Haut-Rhin"
                                    onmouseover="show('HautRhin')" onmouseout="hide()"
                                    onclick="fillTextBox(68)" />
                          <area shape="poly" id="90" coords="220,88,221,92,223,96,226,96,225,92,224,89,223,86"  
                                     href="#"title="Territoire de Belfort"
                                    onmouseover="show('TerritoiredeBelfort')" onmouseout="hide()"
                                    onclick="fillTextBox(90)" />
                          <area shape="poly" id="70" coords="221,91,220,86,215,86,209,84,204,87,202,91,199,92,196,94,198,99,200,103,203,103,207,100,211,98,215,94,219,94,222,93"  
                                     href="#"title="Haute-Saône"
                                    onmouseover="show('HauteSaone')" onmouseout="hide()"
                                    onclick="fillTextBox(70)" />
                          <area shape="poly" id="25" coords="223,101,224,98,221,96,216,96,212,99,208,101,204,102,203,104,204,109,207,111,209,114,211,117,210,119,210,122,212,118,215,115,216,111,219,107,223,104"  
                                     href="#"title="Doubs"
                                    onmouseover="show('Doubs')" onmouseout="hide()"
                                    onclick="fillTextBox(25)" />
                          <area shape="poly" id="39" coords="210,119,209,114,207,112,204,109,203,106,201,104,197,101,197,106,195,110,195,114,197,118,197,122,197,126,198,129,201,128,204,127,206,128,208,126,208,122"  
                                     href="#"title="Jura"
                                    onmouseover="show('Jura')" onmouseout="hide()"
                                    onclick="fillTextBox(39)" />
                          <area shape="poly" id="01" coords="207,133,208,131,210,128,208,127,205,128,202,129,198,130,195,126,192,126,189,127,186,130,187,134,187,137,189,139,192,142,196,140,199,142,202,146,205,142,207,136"  
                                     href="#"title="Ain"
                                    onmouseover="show('Ain')" onmouseout="hide()"
                                    onclick="fillTextBox(01)" />
                          <area shape="poly" id="74" coords="223,131,223,127,218,126,214,129,212,133,208,134,208,138,208,141,213,144,217,139,221,141,225,140,228,137,225,134"  
                                     href="#"title="Haute-Savoie"
                                    onmouseover="show('HauteSavoie')" onmouseout="hide()"
                                    onclick="fillTextBox(74)" />
                          <area shape="poly" id="73" coords="227,147,224,145,221,143,218,141,216,144,212,144,208,142,205,144,203,148,208,150,213,152,213,156,214,160,220,160,224,158,229,156,230,152"  
                                     href="#"title="Savoie"
                                    onmouseover="show('Savoie')" onmouseout="hide()"
                                    onclick="fillTextBox(73)" />
                          <area shape="poly" id="38" coords="212,158,212,154,211,152,206,152,203,148,200,145,197,143,193,144,192,147,188,150,188,154,191,156,195,158,196,162,199,162,202,166,203,169,206,171,208,167,211,167,215,165,211,161"  
                                     href="#"title="Isère"
                                    onmouseover="show('Isere')" onmouseout="hide()"
                                    onclick="fillTextBox(38)" />
                          <area shape="poly" id="26" coords="203,172,201,169,200,165,198,163,194,161,194,159,191,157,188,157,189,161,190,164,190,169,188,171,188,176,187,180,186,184,189,182,193,181,195,183,198,184,200,187,204,185,202,182,200,180,201,176"  
                                     href="#"title="Drôme"
                                    onmouseover="show('Drome')" onmouseout="hide()"
                                    onclick="fillTextBox(26)" />
                          <area shape="poly" id="07" coords="187,154,187,159,190,164,190,169,187,172,187,177,185,182,180,183,174,182,172,180,171,175,170,171,174,170,178,166,180,163,181,159,183,160,185,158"  
                                     href="#"title="Ardeche"
                                    onmouseover="show('Ardeche')" onmouseout="hide()"
                                    onclick="fillTextBox(07)" />
                          <area shape="poly" id="42" coords="180,134,178,133,175,134,171,133,170,137,168,140,170,143,171,146,172,150,172,154,175,154,178,155,181,157,184,157,185,154,183,151,181,149,179,145,178,140"  
                                     href="#"title="Loire"
                                    onmouseover="show('Loire')" onmouseout="hide()"
                                    onclick="fillTextBox(42)" />
                          <area shape="poly" id="69" coords="187,139,186,136,185,132,181,132,181,136,179,139,180,143,181,147,184,150,187,148,190,147,191,144,188,142"  
                                     href="#"title="Rhone"
                                    onmouseover="show('Rhone')" onmouseout="hide()"
                                    onclick="fillTextBox(69)" />
                          <area shape="poly" id="05" coords="207,171,204,174,204,178,202,179,204,182,207,183,208,179,212,178,214,176,218,176,221,176,224,173,227,171,230,170,229,167,225,166,223,164,221,162,217,162,213,162,214,166,210,168"  
                                     href="#"title="Hautes-Alpes"
                                    onmouseover="show('HautesAlpes')" onmouseout="hide()"
                                    onclick="fillTextBox(05)" />
                          <area shape="poly" id="04" coords="227,178,227,174,228,172,225,173,223,176,219,177,213,179,210,181,208,184,206,184,203,187,204,190,205,193,208,196,213,197,216,195,220,195,223,195,226,191,224,188,224,183,226,180"  
                                     href="#"title="Alpes-de-Haute-Provence"
                                    onmouseover="show('AlpesdeHauteProvence')" onmouseout="hide()"
                                    onclick="fillTextBox(04)" />
                          <area shape="poly" id="06" coords="236,186,233,185,229,183,227,180,226,184,226,188,227,192,226,195,228,198,230,201,233,198,236,196,238,193,240,191,242,186,241,183,238,185"  
                                     href="#"title="Alpes-Maritimes"
                                    onmouseover="show('AlpesMaritimes')" onmouseout="hide()"
                                    onclick="fillTextBox(06)" />
                          <area shape="poly" id="83" coords="229,202,227,200,225,197,222,196,218,196,215,198,210,198,207,199,207,203,207,207,207,211,210,214,214,213,216,212,221,211,223,209,227,204"  
                                     href="#"title="Var"
                                    onmouseover="show('Var')" onmouseout="hide()"
                                    onclick="fillTextBox(83)" />
                          <area shape="poly" id="13" coords="206,211,206,206,205,201,201,200,197,198,192,196,189,194,186,197,184,200,182,202,180,204,185,206,189,207,193,207,192,203,196,204,198,207,201,210"  
                                     href="#"title="Bouches-du-Rhône"
                                    onmouseover="show('BouchesduRhone')" onmouseout="hide()"
                                    onclick="fillTextBox(13)" />
                          <area shape="poly" id="84" coords="206,195,203,193,203,189,203,187,201,188,197,186,194,184,191,184,188,185,188,189,189,192,192,194,196,196,200,198,204,198"  
                                     href="#"title="Vaucluse"
                                    onmouseover="show('Vaucluse')" onmouseout="hide()"
                                    onclick="fillTextBox(84)" />
                          <area shape="poly" id="2B" coords="247,211,247,207,246,203,244,207,243,211,240,210,239,214,235,215,233,219,237,222,240,225,244,228,247,233,249,229,250,222,248,215"  
                                     href="#"title="Haute-Corse"
                                    onmouseover="show('HauteCorse')" onmouseout="hide()"
                                    onclick="fillTextBox('2B')" />
                          <area shape="poly" id="2A" coords="247,235,245,232,243,228,239,226,236,223,233,223,233,228,235,231,236,235,237,238,238,241,242,244,245,245,246,240"  
                                     href="#"title="Corse-du-Sud"
                                    onmouseover="show('CorseduSud')" onmouseout="hide()"
                                    onclick="fillTextBox('2A')" />
                          <area shape="poly" id="750" coords="132,51,130,55,128,59,128,64,131,68,132,75,134,80,139,77,144,78,148,81,152,80,154,75,159,74,161,70,160,64,159,60,155,57,152,56,141,53,137,53"
                                    href="#" title="Île-de-France"
                                    onmouseover="show('IledeFrance')" onmouseout="hide()"
                                    onclick="zsregister()"  />
                          <area shape="poly" id="D1" 
                              coords="40,263,39,261,36,259,35,257,34,254,31,251,27,250,24,250,21,251,19,253,17,255,15,258,17,261,18,265,21,268,25,270,29,271,33,271,37,270,38,267" href="#" />
                          <area shape="poly" id="D2" 
                              coords="87,256,83,253,79,249,75,246,70,244,66,244,64,247,61,251,62,255,63,259,66,262,65,266,65,269,64,271,63,274,65,276,68,274,73,274,76,275,78,271,80,267,83,263,86,260" href="#" />
                          <area shape="poly" id="D3" 
                               coords="125,260,126,258,124,257,120,254,117,252,113,250,110,252,111,257,113,260,115,263,119,264,120,268,118,269,118,272,124,272,128,274,130,272,128,267,125,264" href="#" />
                          <area shape="poly" id="D4" 
                               coords="160,258,157,257,155,256,152,255,153,261,153,264,153,267,155,271,158,271,161,268,161,263,164,261,168,260,172,259,175,259,171,256,169,253,167,250,164,248,164,253,163,256" href="#" />
                       </map>
             </div>
            <div id="zsreg" class="reg_tab"  >
                 <div id="ildefrance">
                    <img id="paris" src="../imagemap/ile_de_france.png" width="150" height="114" border="0" />
                    <img id="departmentparis" src="../imagemap/blank1.png"  width="150" height="114" border="0" usemap="#Map2" />
                  </div> 
                    <map name="Map2" id="Map2">  
                        <area shape="circle" coords="8,7,8" alt="close" title="close" href="javascript:;" onclick="closeildefance();" />
                        <area shape="poly" id="78" coords="10,24,12,30,14,36,17,42,19,51,18,57,20,63,27,67,32,76,35,80,42,73,46,67,47,57,55,51,54,45,57,36,53,31,43,27,37,25,29,22,17,21" href="#"  title="Yvelines" onmouseover="showparis('Yvelines')" onmouseout="hideparis()"
                                    onclick="fillTextBox(78)" />
                        <area shape="poly" id="95" coords="21,19,23,14,25,7,29,11,37,13,44,12,48,9,55,13,60,13,65,12,74,17,81,20,79,26,74,31,68,32,62,32,60,34,57,33,29,23,38,26,45,28" href="#"title="Val-d'Oise" onmouseover="showparis('ValdOise')" onmouseout="hideparis()"
                                    onclick="fillTextBox(95)" />
                        <area shape="poly" id="77" coords="83,21,81,27,84,34,83,41,82,47,83,51,80,59,80,65,78,72,79,81,76,88,72,92,75,100,77,108,86,110,98,109,108,105,111,94,114,88,125,88,135,86,139,77,141,69,145,63,139,50,140,46,136,40,126,32,117,20,96,20" href="#"title="Seine-et-Marne" onmouseover="showparis('SeineetMarne')" onmouseout="hideparis()"
                                    onclick="fillTextBox(77)" />
                        <area shape="poly" id="91" coords="40,77,42,86,45,95,53,96,59,91,66,93,73,91,78,81,78,70,78,61,77,54,63,52,57,48,49,57" href="#"title="Essonne" onmouseover="showparis('Essonne')" onmouseout="hideparis()"
                                    onclick="fillTextBox(91)"/>
                        <area shape="poly" id="93" coords="67,34,70,38,74,43,80,42,82,33,80,27,73,30" href="#" title="Seine-Saint-Denis" onmouseover="showparis('SeineSaintDenis')" onmouseout="hideparis()"
                                    onclick="fillTextBox(93)"/>
                        <area shape="poly" id="94" coords="67,47,66,51,72,53,80,57,81,52,82,45,82,37,76,45,70,45" href="#" title="Val-de-Marne" onmouseover="showparis('ValdeMarne')" onmouseout="hideparis()"
                                    onclick="fillTextBox(94)"/>
                        <area shape="poly" id="92" coords="67,33,63,32,58,34,56,39,54,44,57,50,65,52,65,48,62,44,61,39,66,35" href="#"title="Hauts-de-Seine" onmouseover="showparis('HautsdeSeine')" onmouseout="hideparis()"
                                    onclick="fillTextBox(92)"/>
                        <area shape="poly" id="75" coords="63,38,62,43,64,48,71,46,73,42,70,38,66,35" href="#" title="Paris" onmouseover="showparis('Paris')" onmouseout="hideparis()"
                                    onclick="fillTextBox(75)"/>
                    </map>
            </div>
            <div style="clear:both">
            </div>
         </div>
    
    <script type="text/javascript">
        function dep_clique(nbr) 
             {
              //on rempli la première textbox vide... si il n'y en a pas, on rempli la derniere texttbox
              if (document.getElementById("ctl00_ContentPlaceHolder1_textBoxVille1").value.length == 0)
                  document.getElementById("ctl00_ContentPlaceHolder1_textBoxVille1").value = nbr;
               else if (document.getElementById("ctl00_ContentPlaceHolder1_textBoxVille2").value.length == 0)
                  document.getElementById("ctl00_ContentPlaceHolder1_textBoxVille2").value = nbr;
               else if (document.getElementById("ctl00_ContentPlaceHolder1_textBoxVille3").value.length == 0)
                        document.getElementById("ctl00_ContentPlaceHolder1_textBoxVille3").value = nbr;
               else
                        document.getElementById("ctl00_ContentPlaceHolder1_textBoxVille4").value = nbr;
              }
     </script>




<table cellspacing="10"> 
    <td class="RechercheAgent" align="center" 
        style="width: 798px; text-align: center;">
        <strong><div style='font-family:PT Sans;font-weight: bold; font-size:30px'>Trouvez votre conseiller de proximité:</div></strong>
        <br/>
    </td>
    <!-- Zone de recherche -->
    <tr>
        <td align="center" style="height: 39px; color: #31536c;">
        <div class="shadow_box" style="margin-left:10%;margin-right:10%">
        <br />
            <asp:TextBox ID="TextBoxNom" placeholder="Nom de l'agent" CssClass="big_textbox" runat="server"></asp:TextBox>
            <br /><br />
            <asp:TextBox ID="textBoxVille1"  autocomplete="off" onkeyup="requeteAjax(event, this, 0,100,'bigtextbox')" placeholder="Pays, Ville, CP " CssClass="big_textbox" runat="server"></asp:TextBox>
            <br />
            <span id="saisieauto0"></span>
            <br />
            <div id="listeFiltreLieu" style="margin-left:10%;margin-right:10%"> </div>
            <br />       
            <asp:Button ID="Button1" class='flat-button' runat="server" Text="Rechercher" /> <!--Ce bouton sert uniquement a generer un postback ... -->
        <br/> <br/>
        </div>
        </td>
    </tr>
</table>
            
<table style="margin-left:20px;width:100%;margin-right:20px">
    <tr>
         <td style="width: 740px" class="cellulePer">
        <%  /* Generation et execution de la requette de recherche */
                             
            //Je sais pas pourquoi elle est aussi compliquée cette requette, par rapport à ce qu'elle fait, mais la j'ai pas le courage de la simplifier ...
            string sql = "TRANSFORM Sum(biens_par_nego.CountOfref) AS SumOfCountOfref SELECT Clients.id_client, Clients.num_agence, Clients.id_devise, Clients.nom_client, Clients.prenom_client, Clients.adresse_client, Clients.postal_client, Clients.ville_client, Clients.tel_client, Clients.fax_client, Clients.société_client, Clients.pass_client, Clients.pays_client, Clients.date_inscription, Clients.statut, Clients.idclient, Clients.idparrain, Clients.contractuel, Clients.num_contrat FROM Clients LEFT JOIN biens_par_nego ON Clients.idclient = biens_par_nego.idclient WHERE (";
                            
            //Localisations
            String requetteLoc = "";
            List<string> Localisations = new List<string>(saisieLoc.Text.Split(new[]{' '}, StringSplitOptions.RemoveEmptyEntries));
            int DepCP=-1;

            foreach (String s in Localisations) 
            {
                DepCP=-1;
                //Si c'est un nombre, c'est un CP ou un departement (meme traitement). Sinon, c'est un pays.
                if (Int32.TryParse(s, out DepCP)) requetteLoc += " OR (Clients.postal_client) LIKE '" + DepCP + "%'";
                else requetteLoc += " OR Clients.pays_client LIKE '%" + s.ToLower()+"%' ";
            }
                   
            //Nom - Prenom
            String requetteNom = "";
            List<string> NomsPrenoms = new List<string>(TextBoxNom.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            foreach (String s in NomsPrenoms)
            {
                requetteNom += " OR (Clients.nom_client) LIKE '%" + s + "%' OR (Clients.prenom_client) LIKE '%" + s + "%'";
            }

            //Droit admin
            string sqlDroitAdmin = "";
            if (member != null && member.STATUT == "ultranego" && DDLContractuel.SelectedValue=="0") sqlDroitAdmin = " AND ((Clients.statut)='nego' or (Clients.statut)='ultranego') ";
            else sqlDroitAdmin = " AND (Clients.contractuel)=TRUE";
                             
                            
            //On rajoute les elements pertinents
            if (TextBoxNom.Text != "") sql += "(FALSE"+requetteNom+")";
            else if (saisieLoc.Text != "") sql +="FALSE"+ requetteLoc;
            else sql += " TRUE ";
                            
            //On met bout a bout :
            sql+= sqlDroitAdmin + ") GROUP BY Clients.id_client, Clients.num_agence, Clients.id_devise, Clients.nom_client, Clients.prenom_client, Clients.adresse_client, Clients.postal_client, Clients.ville_client, Clients.tel_client, Clients.fax_client, Clients.société_client, Clients.pass_client, Clients.pays_client, Clients.date_inscription, Clients.statut, Clients.idclient, Clients.idparrain, Clients.contractuel, Clients.num_contrat ORDER BY Clients.nom_client PIVOT biens_par_nego.etat;";

                             
            System.Collections.Generic.List<Client> clients = null;
            clients = ClientDAO.getAllClients2(sql);
            int nbrClients = clients.Count;
                             
            System.Collections.Generic.IEnumerator<Client> enume = clients.GetEnumerator();
            ArrayList tabref = new ArrayList();
                
            while (enume.MoveNext())
            {
                tabref.Add(enume.Current.ID_CLIENT.ToString());
            }
            Session["tabref"] = tabref;                      
            %>
        <% 
        Response.Write("<script language=\"javascript\" type=\"text/javascript\">" +
                    "function popUp(URL) {" +
                    "day = new Date();" +
                    "id = day.getTime();" +
                    "eval(\"page\" + id + \" = window.open(URL, '\" + id + \"', 'toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=no,width=430,height=430,left = 440,top = 312');\");" +
                    "}" +
                    "</script>");
        %>
        <%
        //récupération de la racine du site web pour la vérificaton de la présence des images :
        Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        c.Open();
        System.Data.DataSet ds = c.exeRequette("Select * from Environnement");
        c.Close();
        String racine_site = (String)ds.Tables[0].Rows[0]["Chemin_racine_site"];
        %> 
        <%
        //Boucle d'affichage des resultats de la recherche
        int nbClientParPage = Convert.ToInt32(Session["nbClientParPage"]);                
                            
        //Navigation entre les pages
        int page;
        String affichage_page = "";
        int nbPage = (int)decimal.Round(clients.Count / nbClientParPage) + 1;
        if (Request.Params["page"] != null)  page = Convert.ToInt32(Request.Params["page"]);
        else page = 1;
        if (page < 1)  page = 1;
        else if (page > nbPage) page = (int)nbPage;

        Response.Write("<div id=\"pagesHaut\">");
        if (nbPage >= 1)
        {
            affichage_page += "<a href=\"./Recherche_agent.aspx?page=" + Convert.ToString(page - 1) + "\" ><</a>  ";
            if (page == 1) affichage_page += "<strong><a href=\"./Recherche_agent.aspx?page=1\" >1</a></strong>";
            else  affichage_page += "<a href=\"./Recherche_agent.aspx?page=1\" >1</a>";

            for (int i = 2; i <= (nbPage); i++)
            {
                if (i == page) affichage_page +="   <strong><a href=\"./Recherche_agent.aspx?page=" + Convert.ToString(i) + "\" >" + Convert.ToString(i) + "</a></strong>";
                else  affichage_page += "   <a href=\"./Recherche_agent.aspx?page=" + Convert.ToString(i) + "\" >" + Convert.ToString(i) + "</a>";
            }
            affichage_page += "  <a href=\"./Recherche_agent.aspx?page=" + Convert.ToString(page + 1) + "\">></a>";
        }
                            
        %>                 
                         
		<table style="width:95%">
            <td style="float:top;">
                    <%Response.Write("<strong>" + nbrClients + " </strong>"); %> Conseillers
            </td>
            <td style="width:60%;">
                    <% Response.Write("<center>"+affichage_page+"</center>"); %>
            </td>

            <td style="float:right;">
                Afficher par page <asp:DropDownList ID="DropDownListNbClient" runat="server" CssClass=" tbsanswidth" OnSelectedIndexChanged="DropDownListNbClient_SelectedIndexChanged" AutoPostBack="true" ViewStateMode="Enabled">					
				<asp:ListItem Value="9" Selected="True">9</asp:ListItem>
				<asp:ListItem Value="15">15</asp:ListItem>
				<asp:ListItem Value="21">21</asp:ListItem>
				<asp:ListItem Value="33">33</asp:ListItem>
				<asp:ListItem Value="49">49</asp:ListItem>
				</asp:DropDownList>
            </td>
            <td style="float:right;margin-right:10px">
                <asp:DropDownList ID="DDLContractuel" runat="server" Visible="false" CssClass=" tbsanswidth" OnSelectedIndexChanged="DDLContractuel_SelectedIndexChanged" AutoPostBack="true" ViewStateMode="Enabled">					
				<asp:ListItem Value="0" Selected="True">Tout le monde</asp:ListItem>
				<asp:ListItem Value="1">Contractuels seuls</asp:ListItem>
				</asp:DropDownList>
            </td>
        </table>
             
        <% Response.Write(" </div>"); 

            System.Collections.Generic.List<Client> dixClients = null;
            try
            {
                if ((int)clients.Count - (page - 1) * nbClientParPage >= nbClientParPage)
                {
                    dixClients = clients.GetRange((page - 1) * nbClientParPage, nbClientParPage);
                }
                else
                {
                    dixClients = clients.GetRange((page - 1) * nbClientParPage, ((int)clients.Count - nbClientParPage));
                }
            }
            catch
            {
                dixClients = clients.GetRange(0, (int)clients.Count);
            }
            System.Collections.Generic.IEnumerator<Client> cl = dixClients.GetEnumerator();
                string path = "";
                    
            //Debut de l'enumeration    
            while (cl.MoveNext())
            {
                RequeteBien recherche = new RequeteBien();

                recherche.PRIXMIN = 0;
                recherche.PRIXMAX = 1000000000;
                recherche.SURFACEMIN = 0;
                recherche.SURFACEMAX = 9999999;

                recherche.VILLE1 = "";
                string vil = "";
                recherche.villepostal = new List<string>(vil.Split(' '));

                recherche.PIECE1 = true;
                recherche.PIECE2 = true;
                recherche.PIECE3 = true;
                recherche.PIECE4 = true;
                recherche.PIECE5 = true;

                recherche.TYPEBIEN += "A";
                recherche.TYPEBIEN += "M";
                recherche.TYPEBIEN += "T";
                recherche.TYPEBIEN += "X";

                recherche.TYPEVENTE = "V";
                //sauvegarde l'objet recherche dans la session

                Session["requete"] = recherche;
                path = cl.Current.IDCLIENT.ToString();
                string srcJpg = racine_site + "img_nego/" + path + "_PHOTO.jpg";
                string sourceJpg = "../img_nego/" + path + "_PHOTO.JPG";




                String civil = getCivilite(cl.Current.ID_CLIENT);
                
                if (System.IO.File.Exists(srcJpg) == false)
                {
                    if (civil.Trim().ToLower() == "mr")
                    {

                        sourceJpg = "../img_site/man.png";
                    }
                    else
                    {
                        sourceJpg = "../img_site/woman.png";
                    }
                }
                               
                //Ecriture des cartes de visite
                if (member != null && member.STATUT == "ultranego")  Response.Write("<div class=\"Resultat-header2-ultranego\" >");
                else Response.Write( "<div class=\"Resultat-header2\" >");
                                   
                Response.Write(  "<div class=\"Resultat\">"
                                + "<div class=\"Resultat-photo2\">"
                                + "<a class=\"lienImage\" href=\"./agent.aspx?id_client=" +  cl.Current.ID_CLIENT + "\">  <img alt=\"photo\" src= \"" + sourceJpg
                                        + "\" style=\"border:none; float:left; margin-left:3px ;max-width:90px; height:90px\" /></a>"
                                + "</div>");
                                                    

                //Boutons du dessous
                                    
                //Dernier petits traitements
                String shortMail = "";
                String villeFormated = "";
                if (cl.Current.ID_CLIENT.Length >= 23) shortMail = cl.Current.ID_CLIENT.Substring(0, 20) + "[...]";
                else shortMail = cl.Current.ID_CLIENT;
                villeFormated= cl.Current.VILLE_CLIENT;
                if (villeFormated.Length>2) villeFormated = villeFormated.Substring(0, 1).ToUpper() + villeFormated.Substring(1, villeFormated.Length - 1).ToLower();
                                    
                Response.Write("<div class=\"Resultat-text2\" >");
                Response.Write("<Strong> " + "<a href=\"./agent.aspx?id_client=" +  cl.Current.ID_CLIENT + "\" style='color:black'>" + cl.Current.NOM_CLIENT.ToUpper() + " " + cl.Current.PRENOM_CLIENT + "</a></Strong><br />");
                Response.Write(villeFormated + " (" + cl.Current.POSTAL_CLIENT + ")<br />");
                Response.Write("<div id='zoom'><img style='height:20px' src='../img_site/tel_round_dark.png'/><font size='4'> " + cl.Current.TEL_CLIENT + "</font></div>");

                Response.Write("<img style='height:20px;' src='../img_site/mail_round_dark.png'/>" + "<A HREF=mailto:" + cl.Current.ID_CLIENT + "> " + shortMail + "</A HREF>");
                                   
                Response.Write("</div>");
                                    
                Response.Write("<div style='float:left;margin-left:30px'>"+generateLocalisationString(cl.Current.PAYS_CLIENT)+"</div>" +"<div class=\"Resultat-lien-droit2\" >"
                    
                                + "<input type=\"button\"  style=\"margin-right:15px;\" onclick=\"clickSite('" + cl.Current.ID_CLIENT + "')\"class=\"flat-button\" value=\"Voir son site\" />" 
                                +"</div>");

                                    
                //Parametres ultranego
                if (member != null && member.STATUT == "ultranego")
                {
                    Response.Write("<br/><br/><hr/><div class=\"Resultat-lien-bas\" >");
                    if (cl.Current.Contractuel) Response.Write("<b>Contractuel</b>");
                    Response.Write("<input type=\"button\" onclick=\"clickModi('" + cl.Current.IDCLIENT + "')\" class=\"myButton\" style='float:right;' value=\"Modifier\" /><br />"
                                    + "<br/>"
                                    + "Location : " + cl.Current.LIBRE + " Libre<br />"
                                    + "Ventes : " + cl.Current.ESTIMATION + " Estimation(s) " + cl.Current.DISPONIBLE + " Disponible(s)<br />" 
                                    + "</div>");
                }
                                    
                Response.Write("</div></div></div>");
                }
            %>

        <%
        Response.Write("<tr id=\"pageBas\"><td><br/><center>");
        Response.Write(affichage_page);
        Response.Write("</center></td></tr>");
        %>
    </td>
    </tr>
</table>
               
<!-- Zone invisible -->
<asp:TextBox ID="textBoxVille" runat="server" class="invisible"/>
<asp:TextBox ID="textBoxDep" runat="server" class="invisible"/>
<asp:TextBox ID="textBoxPays" runat="server" class="invisible"/>

<asp:Textbox runat="server" ID="saisieLoc" hidden="true" />
<asp:Textbox runat="server" ID="txt" CssClass="invisible" hidden="true" />
<asp:Button runat="server" ID="btnModi" CssClass="invisible" onClick="clickModi" hidden="true" />
<asp:Button runat="server" ID="btnSite" CssClass="invisible" onClick="clickSite" hidden="true" />

<script type="text/javascript">
    function carte_google(ville) {
        window.open("https://maps.google.fr/maps?hl=fr&authuser=1&q=" + ville);
    }

    function clickModi(nomClient) {
        var btn = document.getElementById('<%=btnModi.ClientID %>');
        var txt = document.getElementById('<%=txt.ClientID %>');
        txt.value = nomClient;
        btn.click();
    }


    function clickSite(nomClient) {
        var btn = document.getElementById('<%=btnSite.ClientID %>');
        var txt = document.getElementById('<%=txt.ClientID %>');
        txt.value = nomClient;
        btn.click();
    }

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
    function fillTextBox(departmentId) {
        if (document.getElementById("<%=saisieLoc.ClientID %>").value != "") document.getElementById("<%=saisieLoc.ClientID %>").value += " " + departmentId;
        else document.getElementById("<%=saisieLoc.ClientID %>").value += departmentId;
        var dptb = document.getElementById("<%=saisieLoc.ClientID %>").value;
        var dpsep = dptb.split(" ");
        var dpnorept = dpsep.deldistinct(); //use the function deldistinct() delete repeated postcode
        var dpfinal = dpnorept.join(" ");
        document.getElementById("<%=saisieLoc.ClientID %>").value = dpfinal;

        //En attendant d'afficher les box
        if (document.getElementById("<%=textBoxVille1.ClientID %>").value != "") document.getElementById("<%=textBoxVille1.ClientID %>").value += " " + departmentId;
        else document.getElementById("<%=textBoxVille1.ClientID %>").value += departmentId;
    }



    var baseText = null;
    function zsregister() {
        document.getElementById("zsreg").style.display = 'block';
        document.getElementById("francemap").style.opacity = "0.4";
        document.getElementById("paris").style.opacity = "1";
    }
    function closeildefance() {
        document.getElementById("zsreg").style.display = 'none';
        document.getElementById("francemap").style.opacity = "1";
    }
</script>
</asp:Content>


