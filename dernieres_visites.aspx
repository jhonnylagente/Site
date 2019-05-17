<%@ Page Language="C#"  MasterPageFile="~/pages/MasterPage.master"  AutoEventWireup="true" CodeFile="dernieres_visites.aspx.cs" Inherits="pages_dernieres_visites" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script runat="server" type="text/c#">

</script>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
<script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
<link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
    rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $("[id*=btnPopup]").live("click", function () {
        $("#dialog").dialog({
            height: 500,
            width: 600,
            title: "Memo",
            open: function(){
            //$("#pdfViewer").hide(); //On préfèrera le mettre en visibility:hidden pour éviter un décalage de la memobar
            $("#pdfViewer").css('visibility', 'hidden');
            },
            buttons: {
                "ajouterNote": function () {
                    sendMemo($("#memoDiv").html(), currentPage);
                    $(this).dialog("close");
                },
                "Annuler": function () {
                    $(this).dialog("close");
                }
            },
            close: function () {
                //$("#pdfViewer").show(); 
                //$("#pdfViewer").css('visibility', 'visible');
                //CKEDITOR.instances.memoDiv.destroy();               
                $("#note").show();
                $(this).dialog('close');
            }
        });
        return false;
    });
$("#note").button().click(function (event) {
    checkPage(0);
});

$("span.ui-button-text:contains('ajouterNote')").attr("id", "ajouterNote").html("Ajouter la&nbsp;Note");

$("#deleteNote").button().click(function (event) {
checkPage(1);
});
$('#toto').onclick(function (choix,id)
                {
                    $.ajax({
                        type: "POST",
                        url: "<?php echo url_for('@configChemin') ?>",
                        data: "choix=" + choix + "&id=" + id,
                        success: function(html){
                            $('#sf_admin_content').html(html);
                        }
                    });
/*
$("#noteConfirm").dialog("option", "buttons", [{ text: "Confirmer", click: function () { $(this).dialog("close"); $("#noteForm").dialog("open"); } }, { text: "Annuler", click: function () { $(this).dialog("close"); } }]);
*/

    /*<!--$("[id*=btnPopup]").live("click", function () {
        $("#dialog").dialog({
        height: 500,
			width: 600,
            title: "Memo",
            buttons: {
                Close: function () {
                    $(this).dialog('close');
                }
            }
        });
        return false;
    });*/
</script>
<div id="dialog" style="display: none">
 <textarea rows="16" cols="50">
 
</textarea> 
 
</div>


<!-- Ce morceau contient le javascript de la page -->
<script type="text/javascript" src="checkfield.js"></script>

    <table class="moncompte" >
        <td class="moncompteG1_bis" rowspan=2>
         
        </td>
        <td valign="top"  class="toIgnore">
    <asp:Label ID="LabelOK" runat="server" Font-Bold="True" class="rouge" Visible="False"></asp:Label>
    <div style="text-align: center; margin-top: 5px">
                    <font color="red" size="4">
                        <asp:Label ID="LabelErrorLogin" runat="server" Font-Bold="True" ForeColor="#CC3333"
                            Visible="False" Width="502px"></asp:Label>
                        <br />
                    </font>
                </div>     
                <style type="text/css">
        #fade { /*--Masque opaque noir de fond--*/
	display: none; /*--masqué par défaut--*/
	background: #000;
	position: fixed; left: 0; top: 0;
	width: 100%; height: 100%;
	opacity: .80;
	z-index: 9999;
}
.popup_block{
	display: none; /*--masqué par défaut--*/
	background: #fff;
	padding: 20px;
	border: 20px solid #ddd;
	float: left;
	font-size: 1.2em;
	position: fixed;
	top: 50%; left: 50%;
	z-index: 99999;
	/*--Les différentes définitions de Box Shadow en CSS3--*/
	-webkit-box-shadow: 0px 0px 20px #000;
	-moz-box-shadow: 0px 0px 20px #000;
	box-shadow: 0px 0px 20px #000;
	/*--Coins arrondis en CSS3--*/
	-webkit-border-radius: 10px;
	-moz-border-radius: 10px;
	border-radius: 10px;
}
img.btn_close {
	float: right;
	margin: -55px -55px 0 0;
}
/*--Gérer la position fixed pour IE6--*/
*html #fade {
position: absolute;
}
*html .popup_block {
position: absolute;
}  
.textbox
        {}
         </style>    
<html xmlns="http://www.w3.org/1999/xhtml">
<body>

<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always"> 
    
<ContentTemplate>  
<div style="height: 30px; width: 778px">

    &nbsp;&nbsp;&nbsp;</div>

<div align="right" style="height: 50px; width: 0725px;">

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;

 <asp:Label ID="lbltitle" runat="server" Font-Bold="True"
        Font-Size="XX-Large" ForeColor="#31536C" ></asp:Label></div>
        <div align="right" style="height: 30px; width: 1025px;">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    <asp:DropDownList ID="DropDownListPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ItemChange" > 
	    <asp:ListItem Value="10" Text="10" /> 
	    <asp:ListItem Value="20" Text="20" /> 
	    <asp:ListItem Value="30" Text="30" /> 
	    <asp:ListItem Value="50" Text="50" /> 
	    <asp:ListItem Value="100" Text="100" /> 
    </asp:DropDownList>
</div>
    <asp:GridView ID="GridViewHist" runat="server" AutoGenerateColumns="false" 
        AllowPaging="true"  HorizontalAlign="Center"
		OnPageIndexChanging="PaginateTheData" PagerSettings-Mode="Numeric" 
        OnRowDataBound="ReSelectSelectedRecords" AllowSorting="true" 
        OnSorting="SortRecords" CellPadding="2" 
		Width="928px" Font-Size="Smaller" >
		 <Columns>
        <%--0--%><asp:TemplateField HeaderText="Histo." HeaderStyle-CssClass="Entet">
                        <ItemTemplate>
                        <a href="../pages/historique_visite.aspx?ref=<%# Eval("ref") %>">
							  <img id="imgphoto" src="../img_site/flat_round/historique.png" alt="h" style="width:25px;" />
                              </a>
                                <div class="tooltip">
                                <span>Historique du bien</span></div>
                        </ItemTemplate>
                    </asp:TemplateField>
            <%--1--%><asp:TemplateField HeaderText="rapproch. bien" HeaderStyle-CssClass="Entet">
                    <ItemTemplate>
                        <a href="../pages/rapprochementbien.aspx?idAcq=<%# Eval("ref") %>">
                            <img id="imgphoto" src="../img_site/rapprochement.png" alt="fleche" style="width:25px;" />
                        </a>
                        <div class="tooltip">
                            <span>rapprochement bien</span></div>
                    </ItemTemplate>
                </asp:TemplateField>
			<%--2--%><asp:BoundField HeaderText="date visite" DataField="date_visite" SortExpression="date_visite" HeaderStyle-CssClass="EntetAdresse" DataFormatString="{0:d}"   HtmlEncode="false"  />
			<%--3--%><asp:BoundField HeaderText="ref" DataField="ref" SortExpression="ref" HeaderStyle-CssClass="EntetAdresse"  />
			<%--4--%><asp:BoundField HeaderText="type de bien" DataField="type de bien" SortExpression="type de bien" DataFormatString="{0:d}" HeaderStyle-CssClass="EntetAdresse" />
              <%--5--%><asp:BoundField HeaderText="etat" DataField="etat" SortExpression="etat" HeaderStyle-CssClass="EntetAdresse" />  
              <%--6--%><asp:TemplateField HeaderText="Photo" HeaderStyle-CssClass="Entet">
                    <ItemTemplate>
                        <img id="imgphoto" src="<%# affiche_photo(DataBinder.Eval(Container, "DataItem.ref").ToString())%>"
                            class="icone_photo" alt="" />
                        <%# tooltip_photo(DataBinder.Eval(Container, "DataItem.ref").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
			
			<%--7--%><asp:BoundField HeaderText="ville vendeur" DataField="ville vendeur" SortExpression="ville vendeur" HeaderStyle-CssClass="EntetAdresse" />
			<%--8--%><asp:BoundField HeaderText="nom vendeur" DataField="nom vendeur" SortExpression="nom vendeur" HeaderStyle-CssClass="EntetAdresse" />
			<%--9--%><asp:BoundField HeaderText="tel domicile vendeur" DataField="tel domicile vendeur" SortExpression="tel domicile vendeur" HeaderStyle-CssClass="EntetAdresse" />
			<%--10--%><asp:BoundField HeaderText="mail vendeur" DataField="adresse mail vendeur" SortExpression="adresse mail vendeur" HeaderStyle-CssClass="EntetAdresse" />
                <%--11--%><asp:TemplateField HeaderStyle-CssClass="Entet">
                    <HeaderTemplate>
                        <asp:Image ID="Image1" ImageUrl="../img_site/flat_round/modifier.png" CssClass="croix_rouge" alt=""
                            runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Modifier2" runat="server" Text='<%# modifier_bien(DataBinder.Eval(Container, "DataItem.ref").ToString())%>'></asp:Label>
                        <div class="tooltip">
                            <span>Modifier le bien</span></div>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--12--%><asp:TemplateField HeaderText="Memo" HeaderStyle-CssClass="Entet">
                    <ItemTemplate>
                    <!--<asp:Button ID="note" runat="server" Text="Memo" />-->
                    <!--<asp:button ID="btnPopup" runat="server" Text="Memo" />-->
                    <!--<a href="#?idAcq=<%# Eval("id_acq") %>" data-width="500" data-rel="popup1" class="poplight" >-->
                    <a href="../pages/popup.aspx?id_visite=<%# Eval("id_visite") %>" onclick="window.open(this.href, 'popup_window', 'width=285,height=320,left=300,top=300,resizable=0,titlebar=0');return false">
                    
                    
                    <!--<img id="imgphoto2" src="../img_site/memo.png" alt="bloc-note" style="width:25px" />-->
                    <%# btn_Memo(DataBinder.Eval(Container, "DataItem.id_visite").ToString())%>
                    
                     
                                    
                    <%# tooltip_Memo(DataBinder.Eval(Container, "DataItem.id_visite").ToString())%>
                    </a>
                              </ItemTemplate>     
                </asp:TemplateField>   
			<%--13--%><asp:BoundField HeaderText="categorie" DataField="categorie" SortExpression="categorie" HeaderStyle-CssClass="EntetAdresse"  />
            <%--14--%><asp:BoundField HeaderText="nom acquéreur" DataField="nom" SortExpression="nom" HeaderStyle-CssClass="EntetAdresse" />
						
            <%--15--%><asp:BoundField HeaderText="mail acquéreur" DataField="mail" SortExpression="mail" HeaderStyle-CssClass="EntetAdresse"    />
			

			<%--16--%><asp:BoundField HeaderText="télephone acquéreur" DataField="tel" SortExpression="tel" HeaderStyle-CssClass="EntetAdresse" />
            <%--17--%><asp:TemplateField HeaderStyle-CssClass="Entet">
                        <HeaderTemplate>
                            <asp:Image ID="Image1" ImageUrl="../img_site/flat_round/modifier.png" CssClass="croix_rouge"
                                runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                        
                            <asp:Label ID="Modifier" runat="server" Text='<%# modifier_acquereur(Eval("id_acq").ToString())%>'></asp:Label>
                            <div class="tooltip">
                                <span>modifier l'acquéreur</span></div>
                        </ItemTemplate>
                    </asp:TemplateField>
            <%--18--%><asp:TemplateField HeaderText="rapproch." HeaderStyle-CssClass="Entet">
                    <ItemTemplate>
                    <a href="../pages/rapprochement.aspx?idAcq=<%# Eval("id_acq") %>">
							  <img id="imgphoto" src="../img_site/rapprochement.png" alt="fleche" style="width:25px;" />
                              </a>
							 <div class="tooltip">
                             <span>Rapprochement</span></div>
                              </ItemTemplate>
                </asp:TemplateField>
             <%--19--%><asp:BoundField HeaderText="id visite" DataField="id_visite" SortExpression="id_visite" HeaderStyle-CssClass="EntetAdresse"  />   
             
  
		 </Columns>
		<pagerstyle horizontalalign="Center"/>
     </asp:GridView>


              </ContentTemplate>
</asp:UpdatePanel>
    
     <div id="popup1" class="popup_block" style="display: none; width: 500px; margin-top: -159.5px; margin-left: -290px;">
                                    Texte Memo:<asp:Label ID="Modifier3" runat="server" ></asp:Label> 
	                                <p><asp:textbox id="textarea2" runat="server" Height="140px" 
                                    Width="264px" TextMode="MultiLine" CssClass="textbox"></asp:textbox> 
                                    </p>
                                    <asp:button ID="btnModif" runat="server" Text="modifier memo" onclick="addnote_onclick" />

                                    </div>      
                <div style="color: #31536C; margin-left: 53px;">
                    <%if (lbltitle.Text == "Dernières visites pour les Ventes")
                    {%>
                    &nbsp;<strong>Estimation:</strong>
                    <div style="background-color: #F4A460; display: inline;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    &nbsp;&nbsp;<strong>Disponible:</strong>
                    <div style="background-color: #FFFFFF; display: inline; border:1px solid black;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    &nbsp;&nbsp;<strong>Offre:</strong>
                    <div style="background-color: #FFE4C4; display: inline;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    &nbsp;&nbsp;<strong>Suspendu:</strong>
                    <div style="background-color: #808080; display: inline;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    &nbsp;&nbsp;<strong>Retiré:</strong>
                    <div style="background-color: #008000; display: inline;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    &nbsp;&nbsp;<strong>Compromis:</strong>
                    <div style="background-color: #FFFF00; display: inline;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    <%}
                      else if (lbltitle.Text == "Dernières visites pour les Locations")
                    {%>
                    &nbsp;<strong>Libre:</strong>
                    <div style="background-color: #FFFFFF; display: inline;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    &nbsp;&nbsp;<strong>Occupé:</strong>
                    <div style="background-color: #FFD700; display: inline;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    &nbsp;&nbsp;<strong>Loué:</strong>
                    <div style="background-color: #ADD8E6; display: inline;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    &nbsp;&nbsp;<strong>Option:</strong>
                    <div style="background-color: #FFA500; display: inline;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    &nbsp;&nbsp;<strong>Réservé:</strong>
                    <div style="background-color: #DDA0DD; display: inline;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    &nbsp;&nbsp;<strong>Retirer:</strong>
                    <div style="background-color: #000080; display: inline;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    &nbsp;&nbsp;<strong>Suspendu:</strong>
                    <div style="background-color: #808080; display: inline;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    <%}%>
                   </div>

        <div style="color: #31536C; margin-left: 53px;">
            &nbsp;<strong>Large:</strong>
            <div style="background-color: PaleGreen; display: inline;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
            &nbsp;&nbsp;<strong>Précis:</strong>
            <div style="background-color: YellowGreen; display: inline;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
            &nbsp;&nbsp;<strong>Ancien:</strong>
            <div style="background-color: BurlyWood; display: inline;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
            &nbsp;&nbsp;<strong>Neuf:</strong>
            <div style="background-color: Khaki; display: inline;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>

        </div>
    <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    <script type="text/javascript">

        jQuery(function ($) {

            //When you click on a link with class of poplight and the href starts with a # 
            $('a.poplight').on('click', function () {
                var popID = $(this).data('rel'); //Get Popup Name
                var popWidth = $(this).data('width'); //Gets Popup Width
               

                //Fade in the Popup and add close button
                $('#' + popID).fadeIn().css({ 'width': popWidth }).prepend('<a href="#" class="close"><img src="close_pop.png" class="btn_close" title="Close Window" alt="Close" /></a>');

                //Define margin for center alignment (vertical + horizontal) - we add 80 to the height/width to accomodate for the padding + border width defined in the css
                var popMargTop = ($('#' + popID).height() + 80) / 2;
                var popMargLeft = ($('#' + popID).width() + 80) / 2;

                //Apply Margin to Popup
                $('#' + popID).css({
                    'margin-top': -popMargTop,
                    'margin-left': -popMargLeft
                });

                //Fade in Background
                $('body').append('<div id="fade"></div>'); //Add the fade layer to bottom of the body tag.
                $('#fade').css({ 'filter': 'alpha(opacity=80)' }).fadeIn(); //Fade in the fade layer 

                return false;
            });


            //Close Popups and Fade Layer
            $('body').on('click', 'a.close, #fade', function () { //When clicking on the close or fade layer...
                $('#fade , .popup_block').fadeOut(function () {
                    $('#fade, a.close').remove();
                }); //fade them both out

                return false;
            });


        });
        </script>
  </body>

</html>
</td>
</table>


</asp:Content>


