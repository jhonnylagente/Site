<%@ Page Language="C#"CodeFile="ficheNegociateur.aspx.cs" Inherits="pages_ficheNegociateur" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title></title>
		<style>
			body{
				padding:0;
				margin:0;
			}
			
			td
			{
				font-size: 15pt;
			}
			
			#tableauPrincipal
			{
				margin: 0;
				padding:5px;
				border: 2px solid black;
				border-spacing: 10px 20px;
			}
			.sousTableau
			{
				width:100%;
			}
			
			.sousTitre
			{
				border-bottom: 2px solid black;
			}
			
		</style>
	</head>
	<body style="border:8px solid #04276C; width:1100px; border:0px; width:1100px; align:center;" cellspacing="1">
		<table id="tableauPrincipal" width="1070px" cellpadding="1" align="center">
		
			<!-- ENTETE DE LA PAGE -->
		
			<thead style="padding-bottom:6px;">
				<tr>
					<th colspan="2">
						<b><font size="8">FICHE NEGOCIATEUR</font></b>
					</th>
				</tr>
			</thead>
			
			<!-- CORPS DE LA PAGE -->
			
			<tbody>
				<tr>
					<td>
						<!-- INFORMATIONS PATRIMO -->
						<table align=center width="100%" style="text-align:center;">
							<tr>
								<td>
									<img src="../img_site/logo_patrimo.jpg" alt="logo de patrimo" />
								</td>
								<td>
									<font size="5"><asp:Label ID="Label31" runat="server" /></font>
									<font size="4"><asp:Label ID="Label32" runat="server" />
									<asp:Label ID="Label33" runat="server" />
									<asp:Label ID="Label34" runat="server" />
									<a href="mailto:info@patrimo.net" style="text-decoration:none; color: black;">Email: info@patrimo.net</a><br />
									<a href="http://www.patrimo.net" style="text-decoration:none; color: black;">Web: www.patrimo.net</a></font>
								</td>
							</tr>
							<tr style="font-size: 17pt">
								<td colspan="2"> 
									<!-- <asp:Label ID="Label35" runat="server" /> -->
									<br/><br/>
									<b style="font-size:"5">VOTRE CONSEILLER</b><br/>
									<asp:Label ID="Label36" runat="server" />
								</td>
							</tr>
						</table>
					</td>
					<!-- IMAGE BIEN -->
					<td width=50% style="border:3px solid black">					
						<asp:Image ID="ImageBatiment" runat="server" />
					</td>
				</tr>
				<tr>
					<td>
						<!-- GENERALITES -->
						<table class="sousTableau">
							<thead>
								<tr>
									<th class="sousTitre" colspan="2"><font size="5">GENERALITÉS</font></th>
								</tr>
							</thead>
							<tbody>
								<tr>
									<td>N° dossier</td>
									<td><asp:Label ID="Ndossier" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td>Mandat N°</td>
									<td><asp:Label ID="NMandat" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td>Date mandat</td>
									<td><asp:Label ID="Datemandat" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td>Type mandat</td>
									<td><asp:Label ID="Label1" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td>Négociateur</td>
									<td><asp:Label ID="Négociateur" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td style="visibility:hidden;"> s</td>
								</tr>
							</tbody>
						</table>
					</td>
					<td>
						<!-- LOCALISATION -->
						<table class="sousTableau">
							<thead>
								<tr>
									<th class="sousTitre" colspan="2"><font size="5">LOCALISATION</font></th>
								</tr>
							</thead>
							<tbody>
								<tr>
									<td>Vendeur</td>
									<td><asp:Label ID="Vendeur" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td>Addresse</td>
									<td><asp:Label ID="Addresse" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td>C.P-Ville</td>
									<td>
										<asp:Label ID="cp" runat="server"></asp:Label>
										<asp:Label ID="ville" runat="server"></asp:Label>
									</td>
								</tr>
								<tr>
									<td>Tél.domicile</td>
									<td><asp:Label ID="teledomicile" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td>Tél.bureau</td>
									<td><asp:Label ID="telebureau" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td>E-mail</td>
									<td><asp:Label ID="mail" runat="server"></asp:Label></td>
								</tr>
							</tbody>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<!-- INFOS FINACIERES -->
						<table class="sousTableau">
							<thead>
								<tr>
									<th class="sousTitre" colspan="4"><font size="5">INFORMATIONS FINANCIÈRES</font></th>
								</tr>
							</thead>
							<tbody>
								<tr>
									<td>Prix de vente</td>
									<td><asp:Label ID="prixdevente" runat="server"></asp:Label> €</td>
								</tr>
								<tr>
									<td>Net vendeur</td>
									<td><asp:Label ID="Netvendeur" runat="server"></asp:Label> €</td>
									<td>Charges</td>
									<td><asp:Label ID="Charges" runat="server"></asp:Label> €</td>
								</tr>
								<tr>
									<td>Honoraires</td>
									<td><asp:Label ID="Honoraires" runat="server"></asp:Label> €</td>
									<td>Travaux</td>
									<td><asp:Label ID="Travaux" runat="server"></asp:Label> €</td>
								</tr>
								<tr>
									<td>Taux hono.</td>
									<td><asp:Label ID="Tauxhono" runat="server">0</asp:Label> €</td>
									<td>Taxe fonc.</td>
									<td><asp:Label ID="Taxefonc" runat="server"></asp:Label> €</td>
								</tr>
								<tr>
									<td>Prix estimé</td>
									<td><asp:Label ID="prixestime" runat="server"></asp:Label> €</td>
									<td>Taxe hab.</td>
									<td><asp:Label ID="Taxehab" runat="server"></asp:Label> €</td>
								</tr>
							</tbody>
						</table>
					</td>
					<td>
						<!-- ZONE COMMENTAIRE -->
						<table class="sousTableau">
							<thead>
								<tr>
									<th class="sousTitre"><font  size="5">TEXTE COMMENTAIRES <asp:Label ID="nclès" runat="server"></asp:Label></font></th>
								</tr>
							</thead>
							<tbody style=" 2px solid black" height="506px">
								<tr>
									<td>
										<div width="100%" style="height: 128px; border: 2px solid #777; padding:2px;overflow:hidden; text-overflow: ellipsis; text-align:justify">
											<font size="2" ><asp:Label ID="textarea" runat="server"></asp:Label></font>
										</div>
									</td>
								</tr>
							</tbody>
						</table>
					</td>
				</tr>
				<tr>
					<td class="element">
						<!-- DESCRIPTIF APPARTEMENT -->
						<table class="sousTableau">
							<thead>
								<tr>
									<th class="sousTitre" colspan="4"><font size="5">DESCRIPTIF APPARTEMENT</font></th>
								</tr>
							</thead>
							<tbody>
								<tr>
									<td>Pièce(s)</td>
									<td><asp:Label ID="Pièce" runat="server"></asp:Label></td>
									<td>Surf.Carrez</td>
									<td><asp:Label ID="SurfCarrez" runat="server"></asp:Label>m²</td>
								</tr>
								<tr>
									<td>Chambre(s)</td>
									<td><asp:Label ID="Chambre" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td>Surface Hab.</font></td>
									<td><asp:Label ID="SurfaceHab" runat="server"></asp:Label>m²</td>
									<td>W.C</td>
									<td><asp:Label ID="wc" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td>Surface séjour</td>
									<td><asp:Label ID="Surfaceséjour" runat="server"></asp:Label></td>
									<td>Salle de bains</font></td>
									<td><asp:Label ID="Salledebains" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td>EXPO. séjour</td>
									<td><asp:Label ID="EXPOséjour" runat="server"></asp:Label></td>
									<td>Salle d'eau</td>
									<td><asp:Label ID="Salledeau" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td>Jardin</td>
									<td><asp:Label ID="Jardin" runat="server"></asp:Label>m²</td>
									<td>Parking intérieur</td>
									<td><asp:Label ID="Parkingintérieur" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td>Etage</td>
									<td><asp:Label ID="Etage" runat="server"></asp:Label></td>
									<td>Parking extérieur</td>
									<td><asp:Label ID="Parkingextérieur" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td>Nb étages</td>
									<td><asp:Label ID="Nbétages" runat="server"></asp:Label></td>
									<td>Box</td>
									<td><asp:Label ID="Box" runat="server"></asp:Label></td>
								</tr>
							</tbody>
						</table>
					</td>
					<td>
						<!-- DESCRIPTIF SUITE -->
						<table class="sousTableau">
							<thead>
								<tr></tr>
							</thead>
							<tbody>
								<tr>
									<td >Code étages</td>
									<td ><asp:Label ID="Codeétages" runat="server"></asp:Label></td>
								</tr>	
								<tr>	   
									<td >Année const.</td>
									<td ><asp:Label ID="Annéeconst" runat="server"></asp:Label></td>
									<td >Cave</td>
									<td ><asp:Label ID="Cave" runat="server"></asp:Label></td>	
								</tr>
								<tr>
									<td >Cuisine</td>
									<td ><asp:Label ID="Cuisine" runat="server"></asp:Label></td>
									<td >Ascenseur</td>
									<td ><asp:Label ID="Ascenseur" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td >Type chauff.</td>
									<td ><asp:Label ID="Typechauff" runat="server"></asp:Label></td>
									<td >Balcon</td>
									<td ><asp:Label ID="Balcon" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td >Nature chauff.</td>
									<td ><asp:Label ID="Naturechauff" runat="server"></asp:Label></td>
									<td >Terrasse</td>
									<td ><asp:Label ID="Terrasse" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td >Surface terrain</td>
									<td ><asp:Label ID="Label2" runat="server"></asp:Label></td>
								</tr>
							</tbody>
						</table>
					</td>
				</tr>
				<tr>
					<td colspan="2" >
						<table width="100%">
							<tr>
								<th class="sousTitre" colspan="3"><font size="5">IMAGES DU BIEN</font></th>
							</tr>
							<tr>
								<td style="visibility: hidden">invisible</td>
							</tr>
							<tr>
								<td align=center><asp:Image ID="ImageBatiment2" runat="server" /></td>
								<td><asp:Image ID="ImageBatiment3" runat="server" /></td>
								<td><asp:Image ID="ImageBatiment4" runat="server" /></td>
							</tr>
						</table>
					</td>
				</tr>
			</tbody>
		</table>
		<asp:Label ID="Label37" visible="false" runat="server" />		
	</body>
</html>
