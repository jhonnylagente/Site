<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="affichagerecherche.aspx.cs" Inherits="affichagerecherche" Title="PATRIMONIUM : Résultat de la recherche" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <%--<asp:Panel ID="panel1" runat="server" DefaultButton="ButtonMail">
</asp:Panel>
<asp:Panel ID="panel2" runat="server" DefaultButton="ButtonMail2">
</asp:Panel>--%>
<script>

	var saisi = "#saisie";
	var champVille = "#<%=textBoxVille.ClientID%>";
	var champPays = "#<%=textBoxPays.ClientID%>";
	var champDep = "#<%=textBoxDep.ClientID%>";

	var idCdc = "#<%=chckBxCdC.ClientID%>";
	var idPrestige = "#<%=chckBxPrestige.ClientID%>";
    var idMer = "#<%=chckBxMer.ClientID%>";
	var idMontagne = "#<%=chckBxMontagne.ClientID%>";
	var idNeuf = "#<%=ListeNeuf.ClientID%>";
	var idAchat = "#<%=radioButtonAchat.ClientID%>";
	var idMaison = "#<%=checkBoxMaison.ClientID%>";
	var idAppart = "#<%=checkBoxAppart.ClientID%>";
	var idTerrain = "#<%=checkBoxTerrain.ClientID%>";
	var idAutre = "#<%=checkBoxAutre.ClientID%>";
	var idP1 = "#<%=checkBoxPiece1.ClientID%>";
	var idP2 = "#<%=checkBoxPiece2.ClientID%>";
	var idP3 = "#<%=checkBoxPiece3.ClientID%>";
	var idP4 = "#<%=checkBoxPiece4.ClientID%>";
	var idP5 = "#<%=checkBoxPiece5.ClientID%>";
	var idSurfMin = "#<%=textBoxSurfaceMin.ClientID%>";
	var idSurfMax = "#<%=textBoxSurfaceMax.ClientID%>";
	var idPrixMin = "#<%=TextBoxBudgetMin.ClientID%>";
	var idPrixMax = "#<%=TextBoxBudgetMax.ClientID%>";
    var idMotClef1 =  "#<%=tb_motcle1.ClientID%>";
    var idMotClef2 =  "#<%=tb_motcle2.ClientID%>";
    var idMotClef3 =  "#<%=tb_motcle3.ClientID%>";
    var idMotClef4 =  "#<%=tb_motcle4.ClientID%>";
	var idNbResultat = "#Select1";
	
	//Fix pour la page Recherche_agent.aspx
	var negoID = "<%=Request.QueryString["field1"]%>";
	var negoName = "<%=Request.QueryString["ref"]%>";
	
</script>


<script type="text/javascript" src="../JavaScript/afficherrecherche_ajax.js"></script>

<!-- Ajax pour le champ Situation -->
<script type="text/javascript" src="../JavaScript/ajax_listeLieu.js"></script>
<script type="text/javascript" src="../JavaScript/ajax_saisieLieu.js"></script>

<script>
	function guiAddLieu(input, name, code)
	{
		$("#listeFiltreLieu").append("<div id='LL_"+code.toString().replace(" ", "_")+"' class='boxLieu' style='margin-left:10px;font-size:10pt;'>"
									+"<img onclick=\"removeLieu('"+input+"', '"+code.toString()+"')\" src='../img_site/boutton_Supprimer.png' alt='Retirer' class='cursor_link' style='margin-bottom:-4px'>&nbsp;"
									+name+"</div>");
	}

	function removeLieu(input, code)
	{
		var regex = new RegExp( code + "[^,]*,");
		var newChaine = $(input).val().replace(regex , "");
		$(input).val(newChaine);
		$("#LL_"+code.replace(" ","_")).remove();
    }

function setModeTri2() {
    //Si la categorie ne change pas, inverse l'ordre de tri
    mode = document.getElementById('DDL_tri').value;

    if (mode == $("#modeTri").html())
        toggleOrdreTri();

    $("#modeTri").html(mode);

    ajaxSearch();
}

</script>

    <script language="javascript" type="text/javascript">
		function popUp(URL) 
		{
			day = new Date();
			id = day.getTime();
			eval("page" + id + " = window.open(URL, '" + id + "', 'toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=no,width=430,height=430,left = 440,top = 312');");
		}
        // <!CDATA[



    </script>
    <table>
        <tr>
            <td valign="top">
                <table>
                    <tr>
                        <td class="RechercheTiny" style="padding:0">
							<fieldset style="margin-left:0;margin-bottom:5px;width:213px">
								<legend style="font-size:12pt;" class="bold">Affiner vos critères</legend>
									
								<div style=" text-align:center">
									<asp:RadioButton ID="radioButtonAchat" runat="server" GroupName="radioButtonGroup" Checked="true" Font-Bold="False" /><label for="<%=radioButtonAchat.ClientID %>"><strong>Achat</strong></label>
                                    <asp:RadioButton ID="radioButtonLocation" runat="server" Checked="false" GroupName="radioButtonGroup" /><label for="<%=radioButtonLocation.ClientID %>"><strong> Location</strong></label>
								<br />
                                </div>
                                
                                <table>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="checkBoxMaison" runat="server" Checked="true"/>Maison<br />
                                        <asp:CheckBox ID="checkBoxAppart" runat="server" Checked="true"/>Appartement<br />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="checkBoxTerrain" runat="server" Checked="true"/>Terrain<br />
									    <asp:CheckBox ID="checkBoxAutre" runat="server" Checked="true"/>Autre
                                    </td>
                                </tr>
                                </table>

                                <div style="margin-top:5px">
										<div class="bold" style="float:left;width:60px">Surface</div>
										<div>
										    <asp:TextBox CssClass="style2d" ID="textBoxSurfaceMin" runat="server" Style="width:50px;font-size:8pt;"></asp:TextBox>
										    &nbsp;à&nbsp;
										    <asp:TextBox CssClass="style2d" ID="textBoxSurfaceMax" runat="server" Style="width:50px;font-size:8pt;"></asp:TextBox>
										    &nbsp;m²
										</div>
									</div>
									
									<div style="margin-top:5px">
										<div class="bold" style="float:left;width:60px">Budget</div>
										<div><asp:TextBox CssClass="style2d" ID="TextBoxBudgetMin" runat="server" Style="width:50px;font-size:8pt;"></asp:TextBox>
										    &nbsp;à&nbsp;
										    <asp:TextBox CssClass="style2d" ID="TextBoxBudgetMax" runat="server" value="" Style="width:50px;font-size:8pt;"></asp:TextBox>
										    &nbsp;€
									    </div>
									</div>
                                    <hr />
                                <div style="margin-top:8px"><span class="bold">Nb pièces</span> 
									<asp:CheckBox ID="checkBoxPiece1" Checked="true" runat="server" />1
									<asp:CheckBox ID="checkBoxPiece2" Checked="true" runat="server" />2
									<asp:CheckBox ID="checkBoxPiece3" Checked="true" runat="server" />3
									<asp:CheckBox ID="checkBoxPiece4" Checked="true" runat="server" />4
									<asp:CheckBox ID="checkBoxPiece5" Checked="true" runat="server" />5+
								</div>
                                 <div style="margin-top:8px">
                                    <span class="bold">Neuf : </span>
								    <asp:DropDownList ID="ListeNeuf" runat="server">
                                            <asp:ListItem Value="2" Text="Tous (VEFA et autres)" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="VEFA uniquement"></asp:ListItem>
                                            <asp:ListItem Value="0" Text="Autres uniquement"></asp:ListItem>
								    </asp:DropDownList>
                                    <br />
                                    <table style="margin-top:4px;">
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chckBxCdC" runat="server" /> Coups de coeur<br />
                                                <asp:CheckBox ID="chckBxPrestige" runat="server" /> Prestige
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chckBxMer" runat="server" /> Mer<br />
                                                <asp:CheckBox ID="chckBxMontagne"   runat="server" /> Montagne
                                            </td>
                                        </tr>
                                    </table> 
								</div>
								
                                <asp:TextBox ID="tb_motcle1" CssClass="style2d" Style="width:100px;font-size:8pt;margin-top:5px;" placeholder="Mot Clef1" runat="server" ></asp:TextBox>
                                <asp:TextBox ID="tb_motcle2" CssClass="style2d" Style="width:100px;font-size:8pt;" placeholder="Mot Clef2" runat="server" ></asp:TextBox>
                                <asp:TextBox ID="tb_motcle3" CssClass="style2d" Style="width:100px;font-size:8pt;margin-top:5px;" placeholder="Mot Clef3" runat="server" ></asp:TextBox>
                                <asp:TextBox ID="tb_motcle4" CssClass="style2d" Style="width:100px;font-size:8pt;" placeholder="Mot Clef4" runat="server" ></asp:TextBox>

								<div class="clear"></div>

                                <hr />

									<div style="margin-top:8px;line-height:24px">
										<div class="bold" style="float:left;width:60px">Localité </div>
										<div><input id="saisie" class="style2d" style="width:90px;font-size:8pt;" type="text" onkeyup="requeteAjax(event, this, 0, 42,'mini')" placeholder="Pays, ville, CP ...">&nbsp;<span id="saisieauto0"></span></div>
									</div>
									
									<div id="listeFiltreLieu" style="margin-top:10px;padding-left:7px">
									
									</div>
									
									<asp:TextBox ID="textBoxVille" runat="server" class="invisible"/>
									<asp:TextBox ID="textBoxDep" runat="server" class="invisible"/>
									<asp:TextBox ID="textBoxPays" runat="server" class="invisible"/>

              
                                    <input name="valid" type="button" id="validate" value="ok" class="myButtonOK2 cursor_link" onclick="ajaxSearch();" style="padding: 3px 10px; float: left; margin-left: 130px;"/>
							        <img src="../img_site/boutton_Supprimer.png" class="cursor_link" alt="cancel" onclick="vider();" style="padding: 3px 10px; float: left; margin-right: 0px;"/>
                            </fieldset>
                        </td>
                    </tr>


                </table>
            </td>
            <td valign="top">
                <!-- VERIFICATION DES PARAMETRES DE L'AFFICHAGE -->
                <% 
                    string typebien = "";
                    string nbpieces = "";
                    string surfterrain = "";
                    string typeTri = "";
                    string refer = "";
                    int var1 = 30;
                    int boole = 0;


                    Membre member = (Membre)Session["Membre"];

                    try
                    {
                        if (Request.Params["nbannonces"].ToString() == "10")
                        {
                            Session["annoncesPage"] = 10;
                            var1 = 10;
                        }
                        else if (Request.Params["nbannonces"].ToString() == "20")
                        {
                            Session["annoncesPage"] = 20;
                            var1 = 20;
                        }
                        else if (Request.Params["nbannonces"].ToString() == "30")
                        {
                            Session["annoncesPage"] = 30;
                            var1 = 30;
                        }
                        else if (Request.Params["nbannonces"].ToString() == "50")
                        {
                            Session["annoncesPage"] = 50;
                            var1 = 50;
                        }
                    }
                    catch
                    {
                        boole = 1;
                        var1 = 30;

                    }

                    if (Request.Params["Tri"] == "prix")
                    {
                        Session["Tri"] = "prix";
                    }
                    else if (Request.Params["Tri"] == "pieces")
                    {
                        Session["Tri"] = "pieces";
                    }
                    else if (Request.Params["Tri"] == "surface")
                    {
                        Session["Tri"] = "surface";
                    }
                    else if (Request.Params["Tri"] == "codepostal")
                    {
                        Session["Tri"] = "codepostal";
                    }
                    else if (Request.Params["Tri"] == "ville")
                    {
                        Session["Tri"] = "ville";
                    }
                    else if (Request.Params["Tri"] == "type")
                    {
                        Session["Tri"] = "type";
                    }
                    else if (Request.Params["Tri"] == "date")
                    {
                        Session["Tri"] = "date";
                    }

                    else if (Request.Params["Tri"] == "consommation")
                    {
                        Session["Tri"] = "consommation";
                    }

                    Session["NumPage"] = Request.Params["Numpage"];  
					
                %>
                <div class="Header-dessous">
                </div>
                <!-- VERIFICATION DU CHOIX DU CLASSEMENT DES RECHERCHES -->
                <% 
					RequeteBien requete = null;
                    if (Session["requete"] == null) requete = new RequeteBien();
                    else
                    {
                        try { requete = (RequeteBien)Session["requete"]; }
                        catch { requete = new RequeteBien(); }
                    }
					

                    if (Request.Params["ref"] != null)
                    {
                        requete.NEGOCIATEUR = Request.Params["ref"];
                    }

                    System.Collections.Generic.List<Bien> biens = null;
                    
                    String tri = "";
                    String ordre = "";
                    if (Session["Tri"] != null) tri = Session["Tri"].ToString();
                    else
                    {
                        tri = "date";
                        Session["Tri"] = ordre;
                    }
                    if (Session["Ordre"] != null) ordre = Session["Ordre"].ToString();
                    else
                    {
                        ordre = "DESC";
                        Session["Ordre"] = ordre;
                    }
                    
   
                    switch (tri)
                    {
                        case "date":
                            requete.REQUETE_ORDER = " ORDER BY Biens.[date modification] " + ordre;
                            break;
                        case "prix":
                            if (Session["Transaction"].ToString() == "achat" || Session["Transaction"].ToString() == "achat2")
                            {
                                requete.REQUETE_ORDER = " ORDER BY Biens.[prix de vente]" + ordre;
                            }
                            else requete.REQUETE_ORDER = " ORDER BY Biens.[loyer_cc]" + ordre;
                            break;
                        case "pieces":
                            requete.REQUETE_ORDER = " ORDER BY Biens.[nombre de pieces]" + ordre;
                            break;
                        case "surface":
                            requete.REQUETE_ORDER = " ORDER BY Biens.[surface habitable]" + ordre;
                            break;
                        case "codepostal":
                            requete.REQUETE_ORDER = " ORDER BY Biens.[code postal du bien]" + ordre;
                            break;
                        case "ville":
                            requete.REQUETE_ORDER = " ORDER BY Biens.[ville du bien]" + ordre;
                            break;
                        case "type":
                            requete.REQUETE_ORDER = " ORDER BY Biens.[type de bien] " + ordre;
                            break;
                        case "consommation":
                            requete.REQUETE_ORDER = " ORDER BY Biens.[nombre_conso] " + ordre;
                            break;
                        case "emission":
                            requete.REQUETE_ORDER = " ORDER BY Biens.[nombre_energie] " + ordre;
                            break;
                    }
                    String s = Request.QueryString["field1"];
                    string va = s;
                    string requet = "";
                    if (requete != null)
                    {
                        biens = BienDAO.getAllBiens(requete.REQUETE_SQL_Recherche);
                    }
                    if (Session["Transaction"] == "location2")
                    {
                        requet = "SELECT * FROM Biens INNER JOIN optionsBiens ON Biens.ref = optionsBiens.refOptions WHERE (((Biens.etat)='Libre') AND ((Biens.actif)='actif') AND ((Biens.idclient)=" + Session["IDCLIENT"] + "))" + requete.REQUETE_ORDER;
                        biens = BienDAO.getAllBiens(requet);
                    }
                    else if (Session["Transaction"] == "achat2")
                    {
                        requet = "SELECT * FROM Biens INNER JOIN optionsBiens ON Biens.ref = optionsBiens.refOptions WHERE (((Biens.etat)='Disponible') AND ((Biens.actif)='actif') AND ((Biens.idclient)=" + Session["IDCLIENT"] + ")) OR (((Biens.etat)='Estimation') AND ((Biens.actif)='actif') AND ((Biens.idclient)=" + Session["IDCLIENT"] + "))" + requete.REQUETE_ORDER;
						biens = BienDAO.getAllBiens(requet);
                    }
                    int nbrBiens = biens.Count;

                    System.Collections.Generic.IEnumerator<Bien> enume = biens.GetEnumerator();
                    ArrayList tabref = new ArrayList();
                    while (enume.MoveNext())
                    {
                        tabref.Add(enume.Current.REFERENCE.ToString());

                    }
                    Session["tabref"] = tabref;
                    

                //----------------------------------------------------------------------------------------------------------------- -->

                    int j = biens.Count;
                    int nbrePage = 0;

                    typeTri = Session["Tri"].ToString();
                    int indexPage = 0;
                    if (Session["NumPage"] == null)
                    {
                        indexPage = 1;
                    }
                    else
                    {
                        indexPage = Int32.Parse(Session["NumPage"].ToString()); //index de la page utilisateur
                    }

                    if (j % var1 != 0) { nbrePage = (j / var1) + 1; }
                    else { nbrePage = (j / var1); }
                %>


                <!-- CHOIX ORDRE DE LA RECHERCHE -->
                <div class="ResultHaut">
                    <div >
                        <table class="tableafficherecherche" width="100%" border="0" >
                        <!-- BOUTON RETOUR -->
                            <tr>
                                <td width="30%">
                                    <asp:Button ID="BtnBacktoCrits" runat="server" Text="Retour aux criteres" CssClass="flat-button" style="width:150px;" OnClick="BacktoCrits" />
                                </td>
                            </tr>
                            <!-- NBRE TOTAL D'ANNONCES et MSG d'ERREUR -->
                            <tr>
                                <td colspan=3 width="68%" class="menu_bas" style="font-size: large; color:#31536C">
								    <span id="resultNumber">&nbsp;</span>
								    <asp:Label id="negoName" runat="server"></asp:Label>
                                    <% if (Request.QueryString["field1"] != null)
                                       {%>
                                            <span class='drapeautooltip'>
					                                <img src="../img_site/boutton_Supprimer.png" class="cursor_link" alt="cancel" onClick="javascript:window.history.go(-1)" style="padding: 3px 10px; float: right; margin-right: 0px;"/>
					                            <span style="padding: 3px 10px; float: right; margin-right: 0px;">Retour à la page précédente</span>
				                            </span>
                                    <%} %>
                                    <font color="red" size="4">
                                    <asp:Label ID="LabelErrorLogin" runat="server" Font-Bold="True" ForeColor="#CC3333"
                                        Visible="false" Width="350px"><br /></asp:Label>
                                </font>
                                <br /><br />
                                </td>
                            </tr>
                            <!-- TRI ET NB ANNONCES PAR PAGE et NAVIGATION PAGES -->
                            <tr>
                                <td width="30%">
									    Trier par : 
									
                                        <select size="1" onchange="setModeTri2()" id="DDL_tri" style="" >
                                            <option value="prix">Prix</option>
                                            <option value="date" >Date</option>
                                            <option value="surface" >Surface</option>
                                            <option value="code postal" >Code Postal</option>
                                            <option value="ville" >Ville</option>
                                            <option value="consommation" >Consommation</option>
                                            <option value="émissions" >Emissions</option>
                                            <option value="type" >Type</option>
                                        </select>
                                        <%
                                                if (ordre == "ASC")
                                                {
												    Response.Write("<span class='cursor_link' onclick='toggleOrdreTri()'> <img id='ordreTri' border=\"0\" src=\"../img_site/haut.jpg\" alt='TriCroissant' title='Cliquer pour trier par ordre décroissant' style='vertical-align:middle;'/></span> ");
                                                }
                                                if (ordre == "DESC")
                                                {
												    Response.Write("<span class='cursor_link' onclick='toggleOrdreTri()'> <img id='ordreTri' border=\"0\" src=\"../img_site/bas.jpg\" alt='TriDecroissant' title='Cliquer pour trier par ordre croissant' style='vertical-align:middle;'/></span> ");
                                                }
                                        %>
                                </td>
                                <td width="30%" class="tacenter">
                                     <span id="menuPage1" class="tacenter">
									    <!-- Menu pages resultats -->
								    </span>
                                </td>
                                <td class="annoncesparpage" width="30%">
                                        <select name="choix_nbpages" size="1" onchange="Select1_onchange()" id="Select1"
                                            onclick="return Select1_onclick()">
                                            <option value="10">10</option>
                                            <option value="20">20</option>
                                            <option value="30">30</option>
                                            <option value="50">50</option>
                                        </select>Annonces par page
                                        <%
                                            if (boole != 1)
                                            {
                                                object nbannonces = Session["annoncesPage"]; 
                                        %>
                                        &nbsp;<%
                                            }
                                        %>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>


                <!-- ALERTE MAIL -->
                <% 
                    if (Session["mail"] == "true")
                    {
                        Session["mail"] = false;
                        RequeteBien alerte = (RequeteBien)Session["alerte"];
                        if (alerte.ID_ALERTE.Equals(0))
                        {
                            AlerteMailDAO.addAlerteMail(alerte);
                        }
                        else AlerteMailDAO.updateAlerteMail(alerte);

                        Label1.Visible = true;
                        Label1.Text = "Votre alerte mail pour " + alerte.ID_CLIENT + " vient d'être créé.";
                        
                        /* Avant, on activais l'alerte seulement si le nombre de réultats était plus petit que 100. Je sais pas pourquoi :/
                        if (biens.Count <= 100)
                        {
                            RequeteBien alerte = (RequeteBien)Session["alerte"];
                            if (alerte.ID_ALERTE.Equals(0))
                            {
                                AlerteMailDAO.addAlerteMail(alerte);
                            }
                            else AlerteMailDAO.updateAlerteMail(alerte);

                            Label1.Visible = true;
                            Label1.Text = "Votre alerte mail pour "+ alerte.ID_CLIENT+" vient d'être créé.";
                        }
                        else
                        {
                            Label1.Visible = true;
                            Label1.Text = "Trop de résultat (plus de 100), veuillez affiner les critères de la recherche pour envoyer l'alerte mail.";
                        }*/
                    }
                    %>
                <asp:UpdatePanel ID="actualiser" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#CC3333" Font-Size="12"
                            Text="LabelErrorLogin" Visible="false"></asp:Label>
                        <fieldset class="fieldsetMail">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <img id="Img1" src="../img_site/flat_round/courrier.png" height="25px" style="margin-bottom:-6px" alt="courrier" />
                                        <strong>Créer une alerte e-mail :</strong>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxMail" runat="server" Style="width: 300px"></asp:TextBox>
                                    </td>
                                    <td align="right">
                                        <asp:Button ID="ButtonMail" runat="server" Text="Valider" CssClass="myButton" Style="width: 118px"
                                            OnClick="ButtonMail_Click" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </ContentTemplate>
                </asp:UpdatePanel>


                <!-- RESULTATS -->
			<div id="loadingRecherche">
				<img style="" src="../img_site/loadingbar.gif" alt="Chargement..."><br>
				Chargement ...
			</div>
			<div id="listeAnnonces" style="min-height:150px">
				<!-- Affichage des resultats en AJAX | voir pages/ajax/ajaxRechercheBien.aspx -->
			</div>
			   <br />

                <!-- ALERTE MAIL -->
                <asp:UpdatePanel ID="actualiser2" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#CC3333" Font-Size="12"
                            Text="LabelErrorLogin" Visible="false"></asp:Label>
                        <fieldset class="fieldsetMail">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <img id="Img2" src="../img_site/flat_round/courrier.png" height="25px" style="margin-bottom:-6px" alt="courrier" />
                                        <strong>Créer une alerte e-mail :</strong>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxMail2" runat="server" Style="width: 300px"></asp:TextBox>
                                    </td>
                                    <td align="right">
                                        <asp:Button ID="ButtonMail2" runat="server" Text="Valider" CssClass="myButton" Style="width: 118px"
                                            OnClick="ButtonMail2_Click" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <div class="ResultHaut">
                    <table border="0" width="780px">
                        <tr">
                            <td >
									Trier par : 
									
                                    <select size="1" onchange="setModeTri2()" id="Select2" style="" >
                                        <option value="prix">Prix</option>
                                        <option value="date" >Date</option>
                                        <option value="surface" >Surface</option>
                                        <option value="code postal" >Code Postal</option>
                                        <option value="ville" >Ville</option>
                                        <option value="consommation" >Consommation</option>
                                        <option value="émissions" >Emissions</option>
                                        <option value="type" >Type</option>
                                    </select>
                                    <%
                                            if (ordre == "ASC")
                                            {
												Response.Write("<span class='cursor_link' onclick='toggleOrdreTri()'> <img id='ordreTri' border=\"0\" src=\"../img_site/haut.jpg\" alt='TriCroissant' title='Cliquer pour trier par ordre décroissant' style='vertical-align:middle;'/></span> ");
                                            }
                                            if (ordre == "DESC")
                                            {
												Response.Write("<span class='cursor_link' onclick='toggleOrdreTri()'> <img id='ordreTri' border=\"0\" src=\"../img_site/bas.jpg\" alt='TriDecroissant' title='Cliquer pour trier par ordre croissant' style='vertical-align:middle;'/></span> ");
                                            }
                                    %>
                            </td>
                            <td width="30%" >
                                 <span id="menuPage2" >
									<!-- Menu pages resultats -->
								</span>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%">
                            <br />
                                <asp:Button ID="BtnBacktoCrits2" runat="server" Text="Retour aux criteres" CssClass="flat-button" style="width:150px;" OnClick="BacktoCrits" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>

    <!-- Trucs invisibles -->
    <span id='modeTri' style='display:none'><%=Session["Tri"].ToString()%></span>


</asp:Content>