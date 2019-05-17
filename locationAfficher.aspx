<%@ Page Title="Détails location" Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="locationAfficher.aspx.cs" Inherits="locationAfficher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder1" Runat="Server">
    <div class="addAccountTitle tamid">LOCATION</div>
	<div style="padding-left:170px">
		<table style="float:left">
			<tr>
				<td class="bold">Réference Bien</td> 
				<td><%=location["ref_bien"] %> (<a href="fichedetail1.aspx?ref=<%=location["ref_bien"] %>">Voir fiche</a>)</td>
			
			<tr>	
				<td class="bold">Numéro mandat</td> 
				<td><%=location["num_mandat"] %></td>
			</tr>
			
			<tr>
				<td class="bold"  style="padding-top:15px">Date de signature du bail</td> 
				<td  style="padding-top:15px"><%=location["date_signature_bail"].ToString().Split(' ')[0]%></td>
			</tr>
		</table>
	
		<table style="float:left;padding-left:30px">
			<tr>
				<td class="bold">Prix du loyer</td> 
				<td class="taright" style="padding-left:10px"><%=espaceNombre(location["prix_loyer"].ToString()) %> €</td>
			</tr>
			<tr>
				<td class="bold">Honoraires</td> 
				<td class="taright" style="padding-left:10px"><%=espaceNombre(location["commission"].ToString()) %> €</td>
			</tr>
		<%
			if(membre.STATUT == "ultranego")
			{%>
			<tr>
				<td class="bold">Commission à reverser</td> 
				<td class="taright" style="padding-left:10px"><%=espaceNombre(totalCommission.ToString()) %> €</td>
			</tr> 
			<tr>
				<td colspan=2>
					<hr/>
				</td>
			</tr>
			<tr>
				<td class="bold">Bénéfice agence</td> 
				<td class="taright" style="padding-left:10px"><%=espaceNombre(((int)location["commission"] - totalCommission).ToString()) %> €</td>
			</tr> 
		<%}%>
		</table>
		
		<table style ="float:left;padding-left:60px">
			<tr>
				<td class="bold">
					Bail
				</td>
				<td>
					<asp:Label runat="server" ID="oldBail"></asp:Label>
				</td>
			</tr>			
		</table>
	</div>
    <div class="clear"></div>
	<br/>
		<table style="padding-left:170px;">
		<tr>
			<td class="bold">Négociateur</td> 
            <td><%=location["prenom_client"] + " " + location["nom_client"]%></td>
			
			<td class="bold" style="padding-left:50px">Loueur</td> 
            <td><%=location["prenom vendeur"] + " " + location["nom vendeur"]%></td>
			
			<td class="bold" style="padding-left:50px">Acquéreur</td> 
            <td><%=location["prenom"] + " " + location["nom"]%></td>
			
		</tr>
		
		<tr>
			<td class="bold">Mail</td>
			<td><a href="mailto:<%=location["id_client"]%>"><%=location["id_client"]%></td>
			
			<td class="bold" style="padding-left:50px">Mail</td>
			<td><a href="mailto:<%=location["adresse mail vendeur"]%>"><%=location["adresse mail vendeur"]%></td>
			
			<td class="bold" style="padding-left:50px">Mail</td>
			<td><a href="mailto:<%=location["mail"]%>"><%=location["mail"]%></td>
		</tr>
		
		<tr style="vertical-align:top;">
			<td class="bold">Tél</td>
			<td><%=location["tel_client"]%></td>
			
			<td class="bold" style="padding-left:50px">Tél</td>
			<td><%=location["tel domicile vendeur"]%><br/><%=location["tel bureau vendeur"]%></td>
			
			<td class="bold" style="padding-left:50px">Tél</td>
			<td><%=location["tel"]%></td>			
		</tr>
	</table>
	<br/>
        <div class="addAccountTitle tamid">DÉTAILS COMMISSIONS</div>
	<% 
	%>
		<div style="float:left;width:50%">
			<table style="float:right;padding-right:20px;">	
				<%if(!locationEtMandat)
				{%>
				<tr>
					<td colspan=4 class="tamid bold">
						Négociateur acquéreur<br/>
						Taux acquéreur : <%=((double)location["taux_location"]*100).ToString()%> %<br/><br/>
					</td>
				</tr>
				<%
				}
					int i =0;
				if(membre.IDCLIENT.ToString() == listeHonoraire[0]["id_nego"] || membre.STATUT == "ultranego")
				{
				foreach(System.Data.DataRow ligne in listeHonoraire)
				{ 
					if(ligne["type"].ToString() == "Location" || ligne["type"].ToString() == "Mandat et Location")
					{
				  %>
						<tr>
							<td<% if(i>1) Response.Write(" style='padding-left:" + ((i-1)*20) +"px'"); %>>
								<% if(i>0) Response.Write("<img src='../img_site/arrowdr.png' alt=''>"); %>
								<%=ligne["prenom_client"] + " " + ligne["nom_client"]  %>
							</td>
							<td class="taright" style="padding-left:10px"><%=(ligne["montant"].ToString())%> €</td>
							<td class="taleft" style="padding-left:20px"><%=ratioParrain[i]%></td>
							<td><%if(i!=0)Response.Write("%");%></td>
						</tr>
				<%	
					i++;
					}
				}}
				%>
			</table>
		</div>
		<div>
		<%if(!locationEtMandat)
		{%>
			<table style="padding-left:20px">
				<tr>
					<td colspan=3 class="tamid bold">
                        Négociateur mandat<br/>
						Taux mandat : <%=((double)location["taux_mandat"]*100).ToString()%> %<br/><br/>
					</td>
				</tr>
				<%
					i = 0;
				
				if(membre.IDCLIENT.ToString() == listeHonoraire[0]["id_nego"] || membre.STATUT == "ultranego")
				{
				  foreach(System.Data.DataRow ligne in listeHonoraire)
				  { 
					if(ligne["type"].ToString() == "Mandat")
					{
				  %>
						<tr>
							<td<% if(i>1) Response.Write(" style='padding-left:" + ((i-1)*20) +"px'"); %>>
								<% if(i>0) Response.Write("<img src='../img_site/arrowdr.png' alt=''>"); %>
								<%=ligne["prenom_client"] + " " + ligne["nom_client"]  %>
							</td>
							<td style="text-align:right;padding-left:10px"><%=espaceNombre(ligne["montant"].ToString())%> €</td>
							<td class="taleft" style="padding-left:20px"><%=ratioParrain[i]%></td>
							<td><%if(i!=0)Response.Write("%");%></td>
						</tr>
				<%	
					i++;
					}
				}}%>
			</table>
		</div>
		<%}%>
    <%

    if(false)
	{%>
		<table style="margin:auto;">
			<tr>
				<th>Type</th>
				<th>Montant</th>
			</tr>
		<% foreach(System.Data.DataRow ligne in listeHonoraire)
			{ 
			if((int)ligne["id_nego"] == membre.IDCLIENT)
			{
			%>
			<tr>
				<td><%if((bool)ligne["parrainage"] == true) Response.Write("Parrainage"); else Response.Write("Commission");%></td>
				<td class="taright"><%=espaceNombre(ligne["montant"].ToString())%> €</td>
			</tr>
		<%}}%>
		</table>
	<%}%>
	<br/><br/>
</asp:Content>

