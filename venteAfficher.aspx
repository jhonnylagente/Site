<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="venteAfficher.aspx.cs" Inherits="venteAfficher" Title="Détails vente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="addAccountTitle tamid">VENTE</div>
	<div style="padding-left:170px">
		<table style="float:left">
			<tr>
				<td class="bold">Réference Bien</td> 
				<td><%=vente["ref_bien"] %> (<a href="fichedetail1.aspx?ref=<%=vente["ref_bien"] %>">Voir fiche</a>)</td>
			
			<tr>	
				<td class="bold">Numéro mandat</td> 
				<td><%=vente["num_mandat"] %></td>
			</tr>
			
			<tr>
				<td class="bold"  style="padding-top:15px">Date du compromis</td> 
				<td  style="padding-top:15px"><%=vente["date_compromis"].ToString().Split(' ')[0]%></td>
			</tr>
			
			<tr>
				
				<td class="bold">Date de signature</td> 
				<td><%=vente["date_signature"].ToString().Split(' ')[0]%></td>
			</tr>
		</table>
	
		<table style="float:left;padding-left:30px">
			<tr>
				<td class="bold">Prix de vente</td> 
				<td class="taright" style="padding-left:10px"><%=espaceNombre(vente["prix_vente"].ToString()) %> €</td>
			</tr>
			<tr>
				<td class="bold">Honoraires</td> 
				<td class="taright" style="padding-left:10px"><%=espaceNombre(vente["commission"].ToString()) %> €</td>
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
				<td class="taright" style="padding-left:10px"><%=espaceNombre(((int)vente["commission"] - totalCommission).ToString()) %> €</td>
			</tr> 
		<%}%>
		</table>
		
		<table style ="float:left;padding-left:60px">
			<tr>
				<td class="bold">
					Promesse
				</td>
				<td>
					<asp:Label runat="server" ID="oldPromesse"></asp:Label>
				</td>
			</tr>
			
			<tr>
				<td  class="bold">
					Acte
				</td>
				<td>
					<asp:Label runat="server" ID="oldActe"></asp:Label>
				</td>
			</tr>
			
		</table>
	</div>
	
	<div class="clear"></div>
	<br/>
		<table style="padding-left:170px;">
		<tr>
			<td class="bold">Négociateur</td> 
            <td><%=vente["prenom_client"] + " " +vente["nom_client"]  %></td>
			
			<td class="bold" style="padding-left:50px">Notaire</td> 
            <td><%=vente["prenom_notaire"] + " " +vente["nom_notaire"]  %></td>
			
			<td class="bold" style="padding-left:50px">Vendeur</td> 
            <td><%=vente["prenom vendeur"] + " " +vente["nom vendeur"]  %></td>
			
			<td class="bold" style="padding-left:50px">Acquéreur</td> 
            <td><%=vente["prenom"] + " " +vente["nom"]  %></td>
			
		</tr>
		
		<tr>
			<td class="bold">Mail</td>
			<td><a href="mailto:<%=vente["id_client"]%>"><%=vente["id_client"]%></td>
			
			<td class="bold" style="padding-left:50px">Mail</td>
			<td><a href="mailto:<%=vente["mail_notaire"]%>"><%=vente["mail_notaire"]%></a></td>
			
			<td class="bold" style="padding-left:50px">Mail</td>
			<td><a href="mailto:<%=vente["adresse mail vendeur"]%>"><%=vente["adresse mail vendeur"]%></td>
			
			<td class="bold" style="padding-left:50px">Mail</td>
			<td><a href="mailto:<%=vente["mail"]%>"><%=vente["mail"]%></td>
		</tr>
		
		<tr style="vertical-align:top;">
			<td class="bold">Tél</td>
			<td><%=vente["tel_client"]%></td>
			
			<td class="bold" style="padding-left:50px">Tél</td>
			<td><%=vente["tel_notaire"]%></td>
			
			<td class="bold" style="padding-left:50px">Tél</td>
			<td><%=vente["tel domicile vendeur"]%><br/><%=vente["tel bureau vendeur"]%></td>
			
			<td class="bold" style="padding-left:50px">Tél</td>
			<td><%=vente["tel"]%></td>
			
		</tr>
	</table>
	<br/>
	
    <div class="addAccountTitle tamid">DÉTAILS COMMISSIONS</div>
	<% 
	%>
		<div style="float:left;width:50%">
			<table style="float:right;padding-right:20px;">	
				<%if(!venteEtMandat)
				{%>
				<tr>
					<td colspan=4 class="tamid bold">
						Négociateur acquéreur<br/>
						Taux acquéreur : <%=((double)vente["taux_vente"]*100).ToString()%> %<br/><br/>
					</td>
				</tr>
				<%
				}
					int i =0;
				if(membre.IDCLIENT.ToString() == listeHonoraire[0]["id_nego"] || membre.STATUT == "ultranego")
				{
				foreach(System.Data.DataRow ligne in listeHonoraire)
				{ 
					if(ligne["type"].ToString() == "Vente" || ligne["type"].ToString() == "Mandat et Vente")
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
		<%if(!venteEtMandat)
		{%>
			<table style="padding-left:20px">
				<tr>
					<td colspan=3 class="tamid bold">
                        Négociateur mandat<br/>
						Taux mandat : <%=((double)vente["taux_mandat"] * 100 ).ToString()%> %<br/><br/>
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

	
	/*DeleteMe*/
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

