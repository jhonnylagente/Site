<script>
	var img1 = "#<%=FileUpload1.ClientID%>";
	var img2 = "#<%=FileUpload2.ClientID%>";
	var img3 = "#<%=FileUpload3.ClientID%>";
	var img4 = "#<%=FileUpload4.ClientID%>";
	var img5 = "#<%=FileUpload5.ClientID%>";
	var img6 = "#<%=FileUpload6.ClientID%>";
	var img7 = "#<%=FileUpload7.ClientID%>";
	var img8 = "#<%=FileUpload8.ClientID%>";
	
	
	function defaultVid()
	{
	    $("#videoAnnonce").html('<iframe width="246" height="190" src="https://www.youtube.com/embed/fPWMyl2kZ3g" frameborder="0" allowfullscreen="true"></iframe>');
		$("#<%=TextBoxUrlVideo.ClientID%>").val("");
		hideDelete();
	}
	
	function showDelete() {$("#deleteVid").show();}
	function hideDelete() {$("#deleteVid").hide();}
	function clickAdd()
	{
		if(addVideo($('#<%=TextBoxUrlVideo.ClientID%>').val()))
			showDelete();
	}
	
	$(function()
		{
			if($("#<%=TextBoxUrlVideo.ClientID%>").val() != "")
			{
				addVideo($("#<%=TextBoxUrlVideo.ClientID%>").val());
			}
		}
	);
</script>
<script type="text/javascript" src="../JavaScript/addVideo.js"></script>
       <div class="contenu_onglet" id="contenu_onglet_photos">
        <table>
			<tbody class="vatop">
				<tr>
				<td class="phototexte">
				<%--<div class="contenu_ongletG"> --%>
				 <div>
					<fieldset class="fieldset_14champs" >
						<legend><strong>Photos</strong></legend>
						<strong>Les photos ne doivent pas dépasser 2MO et vérifiez bien que tous les champs obligatoires sont remplis avant d'ajouter le bien.</strong><br /><br />
						<%
							Boolean test = (System.IO.Path.GetFileName(Request.PhysicalPath) == "modifier_nego.aspx")
											?(nego == member.PRENOM + " " + member.NOM || member.STATUT == "ultranego")
											:(member.STATUT == "ultranego" || member.STATUT == "nego");
							refe = Request.QueryString["reference"];
							if (test)
							{
								// On teste s'il y a une image A pour ce bien
								if (TestImage("A") == true) // Si oui, on l'affiche, avec un bouton supprimer
								{
									Response.Write("<strong>Photo 1 :</strong>");
									Response.Write("<img class='petiteImage petiteImageStyle' src='../images/" + refe + "A" + get_extension(refe,"A")+"'/>");  

									
						%> 
								<asp:Button ID="supprimerPhotoA" runat="server" Text="Supprimer" CommandArgument="A" OnCommand='SupprimerPhoto' CssClass="myButton"/> 
								<br /> <br />
						<%  	}
								else // Sinon, on laisse la possibilité d'en charger une
								{    
						%>      <strong>Photo 1 :</strong>
								<asp:FileUpload ID="FileUpload1" runat="server" Accept="image/jpeg"/><br /><br />
						<% } %>
						
						<%  if (TestImage("B"))
							{
								Response.Write("<strong>Photo 2 :</strong>");
                                Response.Write("<img class='petiteImage petiteImageStyle' src='../images/" + refe + "B" + get_extension(refe,"B")+"'/>"); 
						        %>                                      
								<asp:Button ID="supprimerPhotoB" runat="server" Text="Supprimer" CommandArgument="B" OnCommand='SupprimerPhoto' CssClass="myButton"/> 
								<br /> <br />
						<%  }
							else
							{    
						%>       <strong>Photo 2 :</strong>
								 <asp:FileUpload ID="FileUpload2" runat="server" /><br /><br />
						<% } %>
						
						<%  if (TestImage("C"))
							{
								Response.Write("<strong>Photo 3 :</strong>");
								Response.Write("<img class=\"petiteImage petiteImageStyle\" src='../images/" + refe + "C" + get_extension(refe,"C")+"'/>");  
						        %>                                        
								<asp:Button ID="supprimerPhotoC" runat="server" Text="Supprimer" CommandArgument="C" OnCommand='SupprimerPhoto' CssClass="myButton"/> 
								<br /> <br />
						<%  }
							else
							{    
						%>       <strong>Photo 3 :</strong>
								 <asp:FileUpload ID="FileUpload3" runat="server" /><br /><br />
						<% } %>
						
						<%  if (TestImage("D"))
							{
								Response.Write("<strong>Photo 4 :</strong>");
								Response.Write("<img class=\"petiteImage petiteImageStyle\" src='../images/" + refe + "D" + get_extension(refe,"D")+"'/>"); 
						        %>                                        
								<asp:Button ID="supprimerPhotoD" runat="server" Text="Supprimer" CommandArgument="D" OnCommand='SupprimerPhoto' CssClass="myButton"/> 
								<br /> <br />
						<%  }
							else
							{    
						%>       <strong>Photo 4 :</strong>
								 <asp:FileUpload ID="FileUpload4" runat="server" /><br /><br />
						<% } %>

						<%  if (TestImage("E"))
							{
								Response.Write("<strong>Photo 5 :</strong>");
								Response.Write("<img class=\"petiteImage petiteImageStyle\" src='../images/" + refe + "E" + get_extension(refe,"E")+"'/>");  
						        %>                                        
								<asp:Button ID="supprimerPhotoE" runat="server" Text="Supprimer" CommandArgument="E" OnCommand='SupprimerPhoto' CssClass="myButton"/> 
								<br /> <br />
						<%  }
							else
							{    
						%>       <strong>Photo 5 :</strong>
								 <asp:FileUpload ID="FileUpload5" runat="server" /><br /><br />
						<% } %>

						<%  if (TestImage("F"))
							{
								Response.Write("<strong>Photo 6 :</strong>");
								Response.Write("<img class=\"petiteImage petiteImageStyle\" src='../images/" + refe + "F" + get_extension(refe,"F")+"'/>");   
						        %>                                        
								<asp:Button ID="supprimerPhotoF" runat="server" Text="Supprimer" CommandArgument="F" OnCommand='SupprimerPhoto' CssClass="myButton"/> 
								<br /> <br />
						<%  }
							else
							{    
						%>       <strong>Photo 6 :</strong>
								 <asp:FileUpload ID="FileUpload6" runat="server" /><br /><br />
						<% } %>

						<%  if (TestImage("G"))
							{
								Response.Write("<strong>Photo 7 :</strong>");
								Response.Write("<img class=\"petiteImage petiteImageStyle\" src='../images/" + refe + "G" + get_extension(refe,"G")+"'/>");  
						        %>                                        
								<asp:Button ID="supprimerPhotoG" runat="server" Text="Supprimer" CommandArgument="G" OnCommand='SupprimerPhoto' CssClass="myButton"/> 
								<br /> <br />
						<%  }
							else
							{    
						%>       <strong>Photo 7 :</strong>
								 <asp:FileUpload ID="FileUpload7" runat="server" /><br /><br />
						<% } %>

						<%  if (TestImage("H"))
							{
								Response.Write("<strong>Photo 8 :</strong>");
								Response.Write("<img class=\"petiteImage petiteImageStyle\" src='../images/" + refe + "H" + get_extension(refe,"H")+"'/>");  
						        %>                                        
								<asp:Button ID="supprimerPhotoH" runat="server" Text="Supprimer" CommandArgument="H" OnCommand='SupprimerPhoto' CssClass="myButton"/> 
								<br /> <br />
						<%  }
							else
							{    
						%>       <strong>Photo 8 :</strong>
								 <asp:FileUpload ID="FileUpload8" runat="server" /><br /><br />
						<% }
							} %>
						<asp:Label ID="Label1" runat="server"></asp:Label>    
									
					</fieldset>      
					</div>
				</td>
				<td class="phototexte">
				<%--<div class="contenu_photos">--%>
				<div>
					<fieldset class="fieldset_16champs">
						<legend><strong>Texte Internet</strong></legend>  
							<asp:TextBox ID="TextBoxTexteInternet" runat="server" TextMode="multiline"  CssClass=" TexteInternet" placeholder="Texte de votre annonce publiée sur les sites commerciaux partenaires (Sebag, Annonces jaunes, etc...)"></asp:TextBox>
					</fieldset>
					 <fieldset class="fieldset_16champs">
						<legend><strong>Texte Commentaires</strong></legend>  
							<asp:TextBox ID="tbCommentaires" runat="server" TextMode="multiline" CssClass=" TexteInternet" placeholder="Texte repris sur la fiche négociateur non publiée. Utilisez le librement pour vos renseignements de visite (tél gardien, horaires de visite, etc...)"></asp:TextBox>
					</fieldset>
					</div> 
				</td>
				
				<td>
					<fieldset>
						<legend class="bold">Vidéo</legend>
						Attacher une vidéo à votre annonce via son URL.<br/>
						(Fonctionne seulement avec YouTube & Dailymotion)
						<br/><br/>
						<asp:TextBox ID="TextBoxUrlVideo" runat="server" CssClass="tb200" style="width:150px" placeholder="URL de la vidéo" />
						<span class="myButtonClear" style="padding:1px 6px" onclick="clickAdd()">+</span>
						<img id="deleteVid" title="Supprimer le lien" alt="Supprimer Lien" class="cursor_link" style="margin-bottom:-2px;display:none;" src="../img_site/boutton_Supprimer.png" onclick="defaultVid();">
						<br/><span id="invalideURL" class="rouge"></span>
						<br/>
						<br/>
						<div id="videoAnnonce">
							<iframe width="246" height="190" src="https://www.youtube.com/embed/fPWMyl2kZ3g" frameborder="0" allowfullscreen="true"></iframe>
						</div>
					</fieldset>
				</td>
				</tr>
			</tbody>
        </table>
            
        </div>	