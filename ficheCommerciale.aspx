<%@ Page Language="C#" CodeFile="ficheCommerciale.aspx.cs" Inherits="pages_ficheCommerciale" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<style>
		.sousTableau
		{
			width: 100%;
		}
		
		.sousTableau th
		{
			border-bottom: solid #04276C;
			text-align: left;
		}
		
		.sousTableau tr
		{
			margin-bottom: 5px;
			font-size: 16pt;
		}
		
	</style>
</head>
	<body style="border:solid #04276C; width: 1070px;">
		<form id="form1" runat="server">
			<table width="100%" cellspacing="10" cellpadding="1" border="0" align="center">
				<thead>
					<tr>
						<td colspan="2">
							<table width="100%">
								<tr>
									<td width="95px"><img align="top" src="../img_site/logo_patrimo.jpg" alt="logo de patrimo" /></td>
									<td><font size="6"><b>Patrimo</b></font><br/><font size="5">Réseau Immobilier</font></td>
									<td style="text-align: center;"><b><font size="5">VOTRE CONSEILLER : <br/><asp:Label ID="Label36" runat="server" /></b></td>
								</tr>
							</table>
						</td>
					</tr>
				</thead>
				<tbody>
					<tr>
						<td colspan="2" align=center>
							<b><font size="8"><asp:Label ID="Labeltype" runat="server" />
							<%if(Label1.Text != "Terrain"){%>
								<asp:Label ID="Label1" runat="server" /><%}%>
							</font></b> 
						</td>
					</tr>
					<tr>
						<td width="50%">
							<!-- DESCRIPTIF -->
							<table class="sousTableau">
								<thead>
									<tr>
										<th><font size="5">DESCRIPTIF</font></th>
										<th style="text-align:right"><font size="5">REF : <asp:Label ID="Label3" runat="server" /></font></th>
									</tr>
								</thead>
								<tbody>
									<tr>
										<td>Pièce(s)</td>
										<td><asp:Label ID="Label9" runat="server" /></td>
									</tr>
									<tr>
										<td>Chambre(s) </font></td>
										<td><asp:Label ID="Label10" runat="server" /></td>
									</tr>
									<tr>
										<td>Surface Hab. </font></td>
										<td><asp:Label ID="Label11" runat="server" />m²</td>
									</tr>
									<tr>
										<td>Surface carrez </font></td>
										<td><asp:Label ID="Label12" runat="server" />m² </td>
									</tr>
									<tr>
										<td>Surface séjour </td>
										<td><asp:Label ID="Label13" runat="server" />m² </td>
									</tr>
									<tr>
										<td>Exposition sejour </td>
										<td><asp:Label ID="Label14" runat="server" /></td>
									</tr>
									<tr>
										<td>Surface terrain </td>
										<td><asp:Label ID="surfaceTerrain" runat="server" /></td>
									</tr>
									<tr>
										<td>Etage </td>
										<td><asp:Label ID="Label15" runat="server" /></td>
									</tr>
									<tr>
										<td>Nombre etages </td>
										<td><asp:Label ID="Label16" runat="server" /></td>
									</tr>
									<tr>
										<td>Code etage </td>
										<td><asp:Label ID="Label17" runat="server" /></td>
									</tr>
									<tr>
										<td>Annee construction </td>
										<td><asp:Label ID="Label18" runat="server" /></td>
									</tr>
									<tr>
										<td>Type cuisine </td>
										<td><asp:Label ID="Label19" runat="server" /></td>
									</tr>
									<tr>
										<td>Surface terrain</td>
										<td><asp:Label ID="Label38" runat="server" /></td>
									</tr>
									<tr>
										<td>WC </td>
										<td><asp:Label ID="Label20" runat="server" /></td>
									</tr>
									<tr>
										<td>Salles de bain </td>
										<td><asp:Label ID="Label21" runat="server" /></td>
									</tr>
									<tr>
										<td>Salles d'eau </td>
										<td><asp:Label ID="Label22" runat="server" /></td>
									</tr>
									<tr>
										<td>Parkings interieurs </td>
										<td> <asp:Label ID="Label23" runat="server" /></td>
									</tr>
									<tr>
										<td>Parkings exterieurs </td>
										<td><asp:Label ID="Label24" runat="server" /></td>
									</tr>
									<tr>
										<td>Caves </td>
										<td><asp:Label ID="Label25" runat="server" /> </td>
									</tr>
									<tr>
										<td> Type chauffage </td>
										<td><asp:Label ID="Label26" runat="server" /></td>
									</tr>
									<tr>
										<td>Nature chauffage </td>
										<td><asp:Label ID="Label27" runat="server" /></td>
									</tr>
									<tr>
										<td>Ascenceur </td>
										<td><asp:Label ID="Label28" runat="server" /></td>
									</tr>
									<tr>
										<td>Balcon </td>
										<td><asp:Label ID="Label29" runat="server" /></td>
									</tr>
									<tr>
										<td>Terrasse </td>
										<td><asp:Label ID="Label30" runat="server" /></td>
									</tr>
									<tr>
										<td style="visibility: hidden;">invisible</td>
									</tr>
								</tbody>
							</table>
						</td>
						<td width="50%" height="663px">
							<!-- Prix + photo -->
							<table class="sousTableau">
								<thead>
									<tr>
										<th style="text-align:right;"><font size="5"><asp:Label ID="Label2" runat="server" />€</font></th>
									</tr>
								</thead>
								<tbody>
									<tr>
										<td width="50%">
											<asp:Image ID="ImageBatiment" runat="server" />
											<asp:Label ID="Label35" runat="server" />
										</td>
									</tr>
									<tr>
										<td>
											<!-- INFOS FINANCIERES -->
											<table class="sousTableau">
												<tr>
													<th colspan="2"><font size="5">INFORMATIONS FINANCIERES</font></th>
												</tr>
												<tr>
													<td>Charges mensuelles</td>
													<td><asp:Label ID="Label5" runat="server" />€</td>
												</tr>
												<tr>
													<td>Travaux </font></td>
													<td><asp:Label ID="Label6" runat="server" />€ </td>
												</tr>
												<tr>
													<td>Taxe habitation </td>
													<td><asp:Label ID="Label7" runat="server" />€ </td>
												</tr>
												<tr>
													<td>Taxe foncière </td>
													<td><asp:Label ID="Label8" runat="server" />€ </td>
												</tr>
												<tr><td height="162px" style="visibility:hidden;">invisible</td>
											</table>
										</td>
									</tr>
								</tbody>
							</table>
						</td>
					</tr>
					<tr>
						<td colspan="2">
							<table width="100%">
									<tr>
										<th colspan="3" style="border-bottom: solid #04276C; text-align:center;"><font size="5">IMAGES DU BIEN</th>
									</tr>
									<tr style="margin: auto">
										<td style="padding-bottom: 20px; padding-top: 20px;" align="center"><asp:Image ID="ImageBatiment2" runat="server" /></td>
										<td style="padding-bottom: 20px; padding-top: 20px;" align="center"><asp:Image ID="ImageBatiment3" runat="server" /></td>
										<td style="padding-bottom: 20px; padding-top: 20px;" align="center"><asp:Image ID="ImageBatiment4" runat="server" /></td>
									</tr>
							</table>
						</td>
					</tr>
				</tbody>
				<br/>
				<tfoot>
					<tr>
						<td colspan="2">
							<table style="border-top: solid #04276C ">
								<tr>
									<td style="border-right:solid #04276C" width="200" cellspacing="0" border="0">
										<font size="2">
											<asp:Label ID="Label31" runat="server" />
											<asp:Label ID="Label32" runat="server" />
											<asp:Label ID="Label33" runat="server" />
											<asp:Label ID="Label34" runat="server" />
											<a style="color:black;text-decoration:none;border: none"; href="mailto:info@patrimo.net">info@patrimo.net</a><br/>
											<a style="color:black;text-decoration:none;border: none"; href="http://www.patrimo.net">www.patrimo.net</a>
										</font>
									</td>
									<td>
										<font size="2">
											<i>Garantie ALLIANZ 110000€<br />
											Carte professionnelle de la préfecture des Hauts de Seine Nanterre<br/><br/>
											</i>
											<b>Patrimo</b>, titulaire de la carte professionnelle portant la mention "transactions sur 
											immeubles et fonds de commerce" n° <b><u>06.92.N.578</u> T2032</b> délivré par la Préfecture 
											de <b> Nanterre</b> garanti(e) par Allianz 87 rue de Richelieu - 75002 PARIS sous le n° 41404407 
											pour un montant de <b>110 000 €</b> titulaire du compte spécial (article 55 du décret du 20 juillet 1972)
											n°<b>300003 04061 00028000002 04</b> ouvert auprès de <b>La Société Générale.</b>
										</font>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</tfoot>
			</table>	
		</form>
	</body>
</html>
