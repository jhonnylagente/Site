<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="location.aspx.cs" Inherits="location" Title="Informations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="../JavaScript/calendar.js"></script>
    <script>
        function setBail(input) 
        {
            var temp = input.value.split("\\");
            $("#newBail").html(temp[temp.length - 1]);
        }
        function validateForm() 
        {
            $(".msg").html("");
            var valide = true;
            var bail = $("#newBail").val();
            
            if (bail != "") {
                if ($("#<%=fileBail.ClientID %>").val() == "" && $("#<%=DropDownListAcq.ClientID %>").val() != "") {
                    $("#BailLocation").show();
                    $(".msg").append("Veuillez ajouter un bail au format pdf.<br/>");
                    valide = false;
                }
            }

            if (parseInt($("#<%=ratioNegoMandat.ClientID%>").val()) < 0 || parseInt($("#<%=ratioNegoMandat.ClientID%>").val()) > 70) {
                $("#msgpourcentage").show();
                $("#croixcommission").show();
                $(".msg").append("Veuillez modifier le pourçentage de commission.<br/>");
                valide = false;
            }

            if ($("#<%=DropDownListAcq.ClientID%>").val() == "") {
                $("#validAcq").show();
                $(".msg").append("Veuillez sélectionner un acquéreur.<br/>");
                valide = false;
            }

            if ($("#<%=TextBoxDateSignature.ClientID%>").val() == "" && $("#<%=DropDownListAcq.ClientID%>").val() != "") {
                $("#TextDateSignature").show();
                $(".msg").append("Date de signature manquante.<br/>");
                valide = false;
            }

            if ($("#<%=fileBail.ClientID%>").val() != "") {
                var temp = $("#<%=fileBail.ClientID%>").val().split(".");
                var ext1 = temp[temp.length - 1];
                if (ext1.toLowerCase() != "pdf") {
                    $(".msg").append("Le contrat de location/bail doit être au format pdf.<br/>");
                    valide = false;
                }
            }
            return valide;
        }
        $(function()
        {
            $("#tableinfonego").hide();

            function acquereur()
            {
                if($("#<%=DropDownListAcq.ClientID%>").val() != ""){
				    $("#validAcq").hide();
                    $("#infoacquereur").show();
                    $("#tableinfocommission").show();
                    $("#tableinfonego").show();
                    $("#tableinfovente").show();            
                    
                    var tel = $("#<%=DropDownListAcq.ClientID%>").children("option").filter(":selected").attr("tel");
                    var mail = $("#<%=DropDownListAcq.ClientID%>").children("option").filter(":selected").attr("mail");
                    var idclient = $("#<%=DropDownListAcq.ClientID%>").children("option").filter(":selected").attr("idclient");
                    var adresse = "<img height='20px'  src='../img_site/drapeau/" + $("#<%=DropDownListAcq.ClientID%>").children("option").filter(":selected").attr("codeiso") + ".png'/>" + "<div class='tooltip'><span>" + "<img height='50px'  src='../img_site/drapeau/" + $("#<%=DropDownListAcq.ClientID%>").children("option").filter(":selected").attr("codeiso") + ".png'/></span></div>" + "&nbsp;" + "<a href='https://www.google.fr/maps/place/" + $("#<%=DropDownListAcq.ClientID%>").children("option").filter(":selected").attr("adresse") + " " + $("#<%=DropDownListAcq.ClientID%>").children("option").filter(":selected").attr("ville") + "' target='_blank'><img style='cursor:pointer' src='../img_site/flat_round/monde.png' height='20px'/></a>"+ " " + $("#<%=DropDownListAcq.ClientID%>").children("option").filter(":selected").attr("adresse") + "<br/>"+ "&nbsp;&nbsp;" + $("#<%=DropDownListAcq.ClientID%>").children("option").filter(":selected").attr("code_postal")+ ", " + $("#<%=DropDownListAcq.ClientID%>").children("option").filter(":selected").attr("ville");
                    var nom = $("#<%=DropDownListAcq.ClientID%>").children("option").filter(":selected").attr("nom") + " " + $("#<%=DropDownListAcq.ClientID%>").children("option").filter(":selected").attr("prenom");

                    $("#<%=nomacquereur.ClientID%>").html(nom);
                    if (mail != null)
                        $("#<%=acqMail.ClientID%>").html("<a href='mailto:"+mail+"'>" + mail + "</a>");
                    if (tel != null)
                        $("#<%=acqTel.ClientID%>").html(tel);

                    $("#<%=acqnom.ClientID%>").html(nom);
                    $("#<%=acqadresse.ClientID%>").html(adresse);
                }
                else{
                    $("#infoacquereur").hide();
                    $("#tableinfocommission").hide();
                    $("#tableinfonego").hide();
                    $("#tableinfovente").hide();  
                }
            }

            var edit = <%=edit.ToString().ToLower()%>;
            if(!edit)
                $("input").attr("readonly","");

            function depotGarantie(){

                if(parseInt($("#<%=TextBoxDepotGarantie.ClientID%>").val()) < 0)
                    $("#<%=TextBoxDepotGarantie.ClientID%>").val(0);

                if(parseInt($("#<%=TextBoxDepotGarantie.ClientID%>").val()) > parseInt($("#<%=TextBoxPrix.ClientID%>").val()))
                    $("#<%=TextBoxDepotGarantie.ClientID%>").val(parseInt($("#<%=TextBoxPrix.ClientID%>").val()));

            }

            function netVendeur()
            {
                var prixVente = parseInt($("#<%=TextBoxPrix.ClientID%>").val());
                var honoraire = parseInt($("#<%=TextBoxHonoraires.ClientID%>").val());

                if(parseInt($("#<%=TextBoxPrix.ClientID%>").val()) < 0){
                    $("#<%=TextBoxPrix.ClientID%>").val(0);
                    prixVente = parseInt($("#<%=TextBoxPrix.ClientID%>").val());
                    }

                if(parseInt($("#<%=TextBoxHonoraires.ClientID%>").val()) < 0){
                    $("#<%=TextBoxHonoraires.ClientID%>").val(0);
                    honoraire = parseInt($("#<%=TextBoxHonoraires.ClientID%>").val());
                    }

                /*if(parseInt($("#<%=TextBoxHonoraires.ClientID%>").val()) > parseInt($("#<%=TextBoxPrix.ClientID%>").val())){
                    $("#<%=TextBoxHonoraires.ClientID%>").val(parseInt($("#<%=TextBoxPrix.ClientID%>").val()));
                    honoraire = parseInt($("#<%=TextBoxHonoraires.ClientID%>").val()); 
                    } */

                if (!isNaN(prixVente) && !isNaN(honoraire))
                    $("#netvendeur").val(prixVente - honoraire);
                
                depotGarantie();
                
            }

            function calculerValeurRatio()
			{
                $("#msgpourcentage").hide();
                $("#croixcommission").hide();
                
                var valeurpoucentageacq=0;

                if(parseInt($("#<%=ratioNegoMandat.ClientID%>").val()) >= 0 && parseInt($("#<%=ratioNegoMandat.ClientID%>").val()) <= 70){

                    valeurpoucentageacq = 70 - parseInt($("#<%=ratioNegoMandat.ClientID%>").val());
                    $("#<%=ratioNegoVente.ClientID%>").html(valeurpoucentageacq);

                    var value1 = parseInt($("#<%=TextBoxHonoraires.ClientID%>").val()) * valeurpoucentageacq  / 100;
				    var value2 = parseInt($("#<%=TextBoxHonoraires.ClientID%>").val()) * parseInt($("#<%=ratioNegoMandat.ClientID%>").val())  / 100;            

				    if(!isNaN(value1))
					    $("#<%=valRatioNegoVente.ClientID%>").html(Math.floor(value1) + " &#8364;");
				    if(!isNaN(value2))
					    $("#<%=valRatioNegoMandat.ClientID%>").html(Math.floor(value2) + " &#8364;");
                    }
                else{
                    $("#msgpourcentage").show();
                    $("#croixcommission").show();
                }
			}

            function changeHonoraire()
			{
				netVendeur();
				calculerValeurRatio();
			}

            function signature()
            {
                $("#TextDateSignature").hide();
            }

            function bail()
            {
                $("#BailLocation").hide();
            }
            
            changeHonoraire();
            acquereur(); 
            
            $("#<%=ratioNegoMandat.ClientID%>").keyup(calculerValeurRatio);
			
            $("#<%=TextBoxPrix.ClientID%>").change(netVendeur);
            $("#<%=TextBoxHonoraires.ClientID%>").change(changeHonoraire);
            $("#<%=TextBoxDepotGarantie.ClientID%>").change(depotGarantie);   

            $("#<%=DropDownListAcq.ClientID%>").change(acquereur);
			
            $("#<%=TextBoxDateSignature.ClientID%>").focusin(signature);
            $("#<%=fileBail.ClientID%>").focusin(bail);

        });
    </script>
    <style>
        .mid{margin:auto;}
        .contain
        {
            /*width:80%;*/
        }
        .center
        {
            margin:auto;
        }
        .monpremiertruc
        {
            color:Red;
            border-width:2px;
            border-style:outset;
            border-color:Window;
        }
    
        .secondcol
        {
            margin-left:284px;
            line-height:24px;
        }
        .firstcol
        {
            margin-left:50px;
            line-height:24px;
        }
        .marg{margin-left:65px}
        .martop{margin-top:5px}
    </style>
    <div class="contain center">
        <div class="addAccountTitle tamid" style="padding-left:50px">CARACTÉRISTIQUES DU BIEN (<asp:Label ID="Label12" runat="server" Text="Label12"/>)</div>
        <div class="tamid">
            <table class="moncompteacq" cellspacing="0" cellpadding="0" style="margin:auto;">
                <tr style="vertical-align:top;text-align:left;">
                    <td>
                        <asp:Label ID="LabelImage" runat="server" />
                    </td>
                    <td style="font-weight:bold;">
                        &nbsp;&nbsp;Réference&nbsp;<br/>
                    </td>
                    <td>
				        <asp:Label ID="lblReference" runat="server" Text="lblReference"/>&nbsp;&nbsp;<br/>
				    </td>
                    <td style="font-weight:bold;">
                        type<br /><br />
                        Adresse&nbsp;
                    </td>
                    <td>
                        <asp:Label ID="lblTypeBien" runat="server" Text="Label2" /><br /><br />
                        <asp:Label ID="lblCodeIsoBien" runat="server" Text="Label7"/><br />&nbsp;&nbsp;
                        <asp:Label ID="lblCpVilleBien" runat="server" Text="Label6" />
                    </td>
                    <td style="font-weight:bold;">
                        Pièces&nbsp;
                        <br /><br />
                        Surfaces&nbsp;
                    </td>
                    <td style="padding-bottom:5px;">
                        <asp:Label ID="lblNbPiecesBien" runat="server" Text="Label5"/>&nbsp;pièce(s)<br/><br/>
						<asp:Label ID="lblSurfaceSejourBien" runat="server" Text="Label3bis"/>&nbsp;m² (séjour)<br/>
						<asp:Label ID="lblSurfaceHabitableBien" runat="server" Text="Label3"/>&nbsp;m² (habitable)<br/>
						<asp:Label ID="lblSurfaceTerrainBien" runat="server" Text="Label4"/>&nbsp;m² (terrain)
                    </td>
                    <td  style="font-weight:bold;font-size:x-large;">
                        Prix du loyer&nbsp;
                    </td>
                    <td style="font-size:x-large">
                        <b>
                            <asp:Label ID="lblLoyerCC" runat="server" Text="Label9" />
                                &nbsp;&#8364;
                        </b>
                    </td>
                </tr>
                <tr>
                    <td colspan=9 style="height:35px">
                        <hr style="width:90%"/>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan=8>
                        <table cellspacing="0" cellpadding="0">
                            <tr style="vertical-align:top;text-align:left;">
                                <td class="bold">
									Loueur<br/><br/>
									<img style='height:20px;' src='../img_site/mail_round_dark.png'/> Mail
							    </td>
                                <td style="padding-left:10px">
									: <%=bien["prenom vendeur"].ToString() + " " +bien["nom vendeur"].ToString().ToUpper()%><br/><br/>
									: <a href="mailto:<%=bien["adresse mail vendeur"]%>"><%=bien["adresse mail vendeur"]%></a>
								</td>
                                <td style="width:40px"></td>
                                <td class="bold">                                        
									<img style='height:20px' src='../img_site/tel_round_dark.png'/> Tél Domicile                                       
                                    <br />
                                    <br />	                                            
									<img style='height:20px' src='../img_site/tel_round_dark.png'/> Tél Bureau				                                                                       
								</td>
                                <td style="padding-left:10px">
                                    <div class="zoom_simple">
                                        : <%=bien["tel domicile vendeur"]%>
                                    </div>
                                    <br />
                                    <div class="zoom_simple">
                                        : <%=bien["tel bureau vendeur"]%>
                                    </div>
                                </td>
                                <td style="width:40px"></td>
                                <td class="bold">
									<span class="bold">
                                        Adresse&nbsp;
                                    </span> 
								</td>
                                <td style="padding-left:10px">
								    : <asp:Label runat="server" id="adresseLoueur"></asp:Label>
								</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table> 
            <br />
        </div>

        <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="addAccountTitle tamid">
                    DETAILS DE LA LOCATION DE <asp:Label runat="server" ID="nomvendeur"></asp:Label> À <asp:Label runat="server" ID="nomacquereur"></asp:Label>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DropDownListAcq" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        <br />
        <center>
            <div>
                <b>Numéro de mandat</b> : <%=bien["num_mandat"] %><br /><br />
                <b>Acquéreur</b> : &nbsp;&nbsp;<asp:DropDownList ID="DropDownListAcq" AutoPostBack="true" OnSelectedIndexChanged="Change_info_nego_acq" runat="server" style="max-width: 250px;"><asp:ListItem></asp:ListItem></asp:DropDownList>&nbsp;&nbsp;<img id="validAcq" class="croix_rouge" src="../img_site/croix_rouge.png" style="display:none;"/>
            </div>
            <br />
            <table style="text-align: left;display:none;" id="infoacquereur">
                <tr>
                    <td><b>Nom et Prénom</b></td>
                    <td>: <asp:Label runat="server" ID="acqnom"></asp:Label></td>
                    <td style="width:40px"></td>
                    <td><b>Adresse</b></td>
                    <td>: <asp:Label runat="server" ID="acqadresse"></asp:Label></td>
                </tr>
                <tr>
                    <td><img style='height:20px' src='../img_site/tel_round_dark.png'/> <b>Téléphone</b></td>
                    <td class="zoom_simple">: <asp:Label runat="server" ID="acqTel"></asp:Label></td>
                    <td style="width:40px"></td>
                    <td><img style='height:20px;' src='../img_site/mail_round_dark.png'/> <b>Mail</b></td>
                    <td>: <asp:Label runat="server" ID="acqMail"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="7" style="height:35px"><hr style="width:90%"/></td>
                </tr>
            </table>
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">  
                <ContentTemplate>
                    <table id="tableinfonego" style="text-align: left;display:inline-block">
                        <tr>
                            <td><b>Négociateur Mandataire</b></td><td>: <asp:Label runat="server" ID="nego"></asp:Label></td>
                            <td style="width:40px"></td><td><b>Négociateur acquéreur</b></td>
                            <td>: <asp:Label runat="server" ID="negoacqnom"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><b>Adresse</b></td><td>: <asp:Label runat="server" ID="negoadresse"></asp:Label></td>
                            <td style="width:40px"></td><td><b>Adresse</b></td>
                            <td>: <asp:Label runat="server" ID="negoacqadresse"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><img style='height:20px' src='../img_site/tel_round_dark.png'/> <b>Téléphone</b></td>
                            <td class="zoom_simple">: <asp:Label runat="server" ID="negoTel"></asp:Label></td>
                            <td style="width:40px"></td>
                            <td><img style='height:20px' src='../img_site/tel_round_dark.png'/> <b>Téléphone</b></td>
                            <td class="zoom_simple">: <asp:Label runat="server" ID="negoacqtel"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><img style='height:20px;' src='../img_site/mail_round_dark.png'/> <b>Mail</b></td>
                            <td>: <asp:Label runat="server" ID="negoMail"></asp:Label></td><td style="width:40px"></td>
                            <td><img style='height:20px;' src='../img_site/mail_round_dark.png'/> <b>Mail</b></td>
                            <td>: <asp:Label runat="server" ID="negoacqmail"></asp:Label></td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="DropDownListAcq" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
            <table id="tableinfocommission" style="text-align: left;display:inline;">
                <tr>
                    <td>&nbsp;&nbsp;</td>
                </tr>
                <tr>
                    <td><b>Pourcentage commission mandataire</b></td>
                    <td>: <asp:TextBox runat="server" ID="ratioNegoMandat" CssClass="style2d taright" Text="35" Width="35"></asp:TextBox> %</td>
                    <td>  <img id="croixcommission" class="croix_rouge" src="../img_site/croix_rouge.png" style="display:none;"></td>
                    <td style="width:40px"></td><td><b>Pourcentage commission acquéreur</b></td>
                    <td>: <asp:Label runat="server" ID="ratioNegoVente"></asp:Label> %</td>
                </tr>
                <tr>
                    <td><b>Commission</b></td>
                    <td>: <asp:Label runat="server" ID="valRatioNegoMandat"></asp:Label></td>
                    <td></td><td style="width:40px"></td><td><b>Commission</b></td>
                    <td>: <asp:Label runat="server" ID="valRatioNegoVente"></asp:Label></td>
                </tr>
            </table>
            <br />
            <div id="msgpourcentage" style="color:Red;display:none">
                Le pouçentage doit être comprit entre 0 et 70 %.
            </div>
            <br />

            <table id="tableinfovente" style="text-align: left;display:inline">
                <tr>
                    <td colspan="7" style="height:35px"><hr style="width:90%"/></td>
                </tr>
                <tr>
                    <td><b>Prix du loyer</b></td>
                    <td>: <asp:TextBox runat="server" ID="TextBoxPrix" CssClass="style2d taright"></asp:TextBox> &#8364;</td>
                    <td style="width:40px"></td>
                    <td><b>Date de signature du bail</b></td>
                    <td>: <asp:TextBox ID="TextBoxDateSignature" runat="server" CssClass="style2d taright"  placeholder="JJ/MM/AAAA" onfocus="HS_setDate(this)" onclick="stopPropagation(event)"></asp:TextBox></td>
                    <td><img id="TextDateSignature" class="croix_rouge" src="../img_site/croix_rouge.png" style="display:none;"/></td>
                </tr>
                <tr>
                    <td><b>Dépôt de garantie</b></td>
                    <td>: <asp:TextBox runat="server" ID="TextBoxDepotGarantie" CssClass="style2d taright" value="0"></asp:TextBox> &#8364;</td>
                    <td style="width:40px"></td>
                    <!--<td><b>Date de signature du bail</b></td>
                    <td>: <asp:TextBox ID="TextBoxDateCompromis" runat="server" CssClass="style2d taright" placeholder="JJ/MM/AAAA" onfocus="HS_setDate(this)" onclick="stopPropagation(event)"></asp:TextBox></td>
                    <td><img id="TextDateCompromis" class="croix_rouge" src="../img_site/croix_rouge.png" style="display:none;"></td> -->
                </tr>
                <tr>
                    <td><b>Honoraire</b></td>
                    <td>: <asp:TextBox runat="server" ID="TextBoxHonoraires" Text="" CssClass="style2d taright"></asp:TextBox> &#8364;</td>
                    <td style="width:40px"></td><td><b>Bail</b></td>
                    <td>: <asp:FileUpload ID="fileBail" runat="server" onChange="SetBail(this);"/><asp:Label runat="server" ID="oldBail" Text="" ></asp:Label></td>
                    <td><img id="BailLocation" class="croix_rouge" src="../img_site/croix_rouge.png" style="display:none;"></td>
                </tr>
                <!--<tr>
                    <td><b>Net vendeur</b></td>
                    <td>: <input type="text" id="netvendeur" class="style2d taright" /> &#8364;</td>
                    <td style="width:40px"></td>
                    <td><b>Acte de vente</b></td>
                    <td>: <asp:FileUpload  ID="fileActe" runat="server" onChange="setActe(this);"/><asp:Label runat="server" ID="oldActe"></asp:Label></td>
                </tr> -->
            </table>
        </center>
        <br />
        <!-- <div class="addAccountTitle">NOTAIRE</div>
        <center>
            <br />
            <table>
                <tr>
                    <td><b>Notaire</b></td>
                    <td>: <asp:DropDownList ID="DropDownListNotaire" runat="server" style="max-width: 340px;"><asp:ListItem></asp:ListItem></asp:DropDownList></td>
                    <td><img id="notairecroix" class="croix_rouge" src="../img_site/croix_rouge.png" style="display:none;"></td>
                    <td><input id="Button2" type="button" runat="server" class="myButton" value="Ajouter un Notaire" onclick="ajouternouveaunotairejs()" /></td>
                    <td><input  type="button" class="myButton" value="Modifier un notaire"  onclick="modifiernotjs()" /></td>
                </tr>
            </table>
            <br />
            <br />
            <table id="infonotaire" style="display:none;">
                <tr>
                    <td class="paramName">Nom</td>
                    <td>: <asp:label runat="server" ID="notaireNom"></asp:label></td>
                    <td style="width:40px"></td><td class="paramName">Adresse</td>
                    <td>: <asp:label runat="server" ID="notaireAdresse" ></asp:label></td>
                    <td style="width:40px"></td>
                    <td class="paramName"><img style='height:20px' src='../img_site/tel_round_dark.png'/> Télephone</td>
                    <td class="zoom_simple">: <asp:label runat="server" ID="notaireTel" ></asp:label></td>
                </tr>
                <tr>
                    <td class="paramName">Prenom</td>
                    <td>: <asp:label runat="server" ID="notairePrenom" ></asp:label></td>
                    <td style="width:40px"></td><td>&nbsp;</td>
                    <td>&nbsp;&nbsp;<asp:label runat="server" ID="notaireCPetville" ></asp:label></td>
                    <td style="width:40px"></td>
                    <td class="paramName">Pays</td>
                    <td>: <asp:label runat="server" ID="notairePays" ></asp:label></td>
                </tr>
                <tr>
                    <td class="paramName"><img style='height:20px;' src='../img_site/mail_round_dark.png'/> Mail</td>
                    <td>: <asp:label runat="server" ID="notaireMail" ></asp:label></td>
                    <td style="width:40px"></td>
                    <td>&nbsp;</td><td>&nbsp;</td><td style="width:40px"></td>
                    <td class="paramName">Fax</td>
                    <td>: <asp:label runat="server" ID="notaireFax" ></asp:label></td>
                </tr>
            </table>
            <table id="infonouveaunotaire" style="display:none;">
                <tr>
                    <td class="paramName">Nom</td>
                    <td>: <asp:textbox runat="server" ID="textnotnom"></asp:textbox></td>
                    <td><img id="croixnot1" class="croix_rouge" src="../img_site/croix_rouge.png" style="display:none;"/></td>
                    <td style="width:40px"></td><td class="paramName">Adresse</td>
                    <td>: <asp:textbox runat="server" ID="textnotadresse" ></asp:textbox></td>
                    <td style="width:40px"></td><td>&nbsp;</td>
                    <td class="paramName"><img style='height:20px' src='../img_site/tel_round_dark.png'/> Télephone</td>
                    <td>: <asp:textbox runat="server" ID="textnottel" ></asp:textbox></td>
                    <td><img id="croixnot7" class="croix_rouge" src="../img_site/croix_rouge.png" style="display:none;"/></td>
                </tr>                
                <tr>
                    <td class="paramName">Prenom</td>
                    <td>: <asp:textbox runat="server" ID="textnotprenom" ></asp:textbox></td>
                    <td>&nbsp;</td><td style="width:40px"></td><td class="paramName">Code Postal</td>
                    <td>: <asp:textbox runat="server" ID="textnotcp" ></asp:textbox></td>
                    <td><img id="croixnot4" class="croix_rouge" src="../img_site/croix_rouge.png" style="display:none;"/></td>
                    <td style="width:40px"></td><td class="paramName">Pays</td>
                    <td>: <asp:textbox runat="server" ID="textnotpays" ></asp:textbox></td>
                </tr>
                <tr>
                    <td class="paramName"><img style='height:20px;' src='../img_site/mail_round_dark.png'/> Mail</td>
                    <td>: <asp:textbox runat="server" ID="textnotmail" ></asp:textbox></td>
                    <td>&nbsp;</td>
                    <td style="width:40px"></td>
                    <td class="paramName">Ville</td>
                    <td>: <asp:textbox runat="server" ID="textnotville" ></asp:textbox></td>
                    <td><img id="croixnot5" class="croix_rouge" src="../img_site/croix_rouge.png" style="display:none;"/></td>
                    <td style="width:40px"></td><td class="paramName">Fax</td>
                    <td>: <asp:textbox runat="server" ID="textnotfax" ></asp:textbox></td>
                </tr>        
                <tr>
                    <td class="invisible"><asp:textbox runat="server" ID="textnotid" ></asp:textbox></td>
                </tr>
            </table>
            <div id="enregistrernot" style="display:none;">
                <br/>
                <input type="button" class="myButton" value="Enregistrer le nouveau notaire" onclick="validerenregistrernot()" />
                <asp:Button ID="enregistrernotaire" runat="server" class="invisible" OnClick="enregistrerlenotaire"/>                
                <br/>
                <br/>
                <div id="msgnotaire" class="msg rouge" style="display:none;"> 
                    Information(s) sur le notaire manquante(s).
                </div>
                <div id="msgnotaireok" class="msg rouge" style="display:none;"> 
                    Notaire enregistré.
                </div>
            </div>
            <br />
            <input id="btnenregistrermodifnot" type="button" class="myButton" value="Enregistrer les modifications" onclick="modifierlenotaire()" style="display:none;"/>
            <asp:Button ID="Button1" runat="server" class="invisible" OnClick="modifiernot"/>
            <div id="msgmodifnotok" class="msg rouge" style="display:none;">
                Notaire Modifié avec succès.
            </div>
            <div id="msgmodifnot" class="msg rouge" style="display:none;"> 
                Veuillez sélectioner un notaire à modifier puis re-cliquez à nouveau.
            </div>
        </center> -->
        <br />
        <div class="addAccountTitle">ENREGISTREMENT DE LA LOCATION</div>
        <br/>
        <div class="tamid">
            <asp:Button runat="server" class="myButton" ID="SaveLocation" OnClientClick="return validateForm()" OnClick="SaveLocation_Click" Text="Enregistrer la location" />
            <asp:Button runat="server" class="myButton" ID="UpdateLocation" OnClientClick="return validateForm()" OnClick="UpdateLocation_Click" Text="Mettre à jour la location" Visible="false"/>
            <br />
            <br />
            <div class="tamid">
                <asp:Label runat="server" ID="msg" CssClass="msg rouge"></asp:Label>
            </div>
    </div>
    </div>
</asp:Content>