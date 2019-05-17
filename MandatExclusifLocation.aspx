<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MandatExclusifLocation.aspx.cs" Inherits="pages_MandatExclusifLocation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<style>
@media print
{
table {page-break-after:always}
}
</style>
</head>

<body>

<table width="1100" cellspacing="20" cellpadding="1" border="0" align=center >

<tr>
<td align=center>
<img style="padding: 5px; border: 0px solid #000000;" src="logo_patrimo_100.jpg" align=left>
<font size="6">
<b>
MANDAT   DE LOCATION  AVEC  EXCLUSIVITÉ N° <%string Re = (string)Session["idmandat"];
                                          String requette1 = "select `num_mandat`from biens where `ref`='" + Re + "'";
                                          System.Data.DataSet ds1 = null;
                                          Connexion c1 = null;
                                          c1 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                                          c1.Open();
                                          ds1 = c1.exeRequette(requette1);
                                          c1.Close();
                                          c1 = null;
                                          Response.Write(ds1.Tables[0].Rows[0]["num_mandat"].ToString());
                                          %>
</b>
</font>
<br />
<font size="4">
<i>
(Article 6 loi N° 70-9 du 2 janvier 1970 et articles 72 et suivants du décret N° 72-678 du 20 juillet 1972)
</i>
</font>
</td>
</tr>
<tr>
<td style="background-color:yellow" height=20><font size="5">
<b>
LE MANDANT
</b>
</font>
</td>
</tr>
<tr>
<td align=center>
<font size="4">
<b>
<%Membre member = (Membre)Session["Membre"];
    if(Session["idmandat"].ToString() != ""){
                string Ref = (string)Session["idmandat"];
                String requette2 = "select `nom vendeur`, `prenom vendeur`, `adresse vendeur`,`code postal vendeur`, `ville vendeur` from biens where `ref`='" + Ref + "'";
                System.Data.DataSet ds2 = null;
                Connexion c2= null;
                           
                c2 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                c2.Open();
                ds2 = c2.exeRequette(requette2);
                c2.Close();
                c2 = null;
                Response.Write(ds2.Tables[0].Rows[0]["nom vendeur"].ToString() + " " + ds2.Tables[0].Rows[0]["prenom vendeur"].ToString() + "<br/>" + " " + ds2.Tables[0].Rows[0]["adresse vendeur"].ToString() + " " + ds2.Tables[0].Rows[0]["code postal vendeur"].ToString() + " " + ds2.Tables[0].Rows[0]["ville vendeur"].ToString());
            }
       %>
</b>
<br />
</font>
</td>
</tr>
<tr>
<td style="background-color:yellow" height=20><font size="5">
<b>
LE MANDATAIRE
</b>
</font>
</td>
</tr>
<tr>
<td align="justify">
<font size="4">
<center><b> PATRIMO, 56 bis rue Victor Hugo  92270 BOIS COLOMBES </b></center>
<br />
Titulaire de la carte professionnelle « transactions sur immeubles et fonds de commerce » n° 06.92.N. 578 T02032  délivrée par la Préfecture de Nanterre, garanti par Allianz 87 rue de Richelieu   75002 PARIS sous le n° 41404407 , pour un montant de 110000 € , titulaire du compte spécial (article 55 du décret du 20 juillet 1972) n°30003 04061 00028000002 04 ouvert auprès de La Société Générale.
<br /><br />APRÈS AVOIR PRIS CONNAISSANCE DES CONDITIONS GÉNÉRALES, CI-APRÈS, le mandant confère au mandataire, qui accepte, mandat AVEC EXCLUSIVITÉ de louer les biens et droits immobiliiers dont il est seul propriétaire ou usufruitier, aux loyers, charges et conditions suivants :
</font>
</td>
</tr>
<tr>
<td style="background-color:yellow" height=20><font size="5">
<b>
OBJET ET CONDITIONS DE LA LOCATION
</b>
</font>
</td>
</tr>
<tr>
<td align="justify">
<font size="4">
<b>
Nature:</b><%if (Session["idmandat"].ToString() != "")
             {
                 string Ref = (string)Session["idmandat"];
                 String requette2 = "select `type de bien` from biens where `ref`='" + Ref + "'";
                 System.Data.DataSet ds2 = null;
                 Connexion c2 = null;

                 c2 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                 c2.Open();
                 ds2 = c2.exeRequette(requette2);
                 c2.Close();
                 c2 = null;
                 if (ds2.Tables[0].Rows[0]["type de bien"].ToString() == "A")
                     {
                         Response.Write(" Appartement");
                     }
                     else if (ds2.Tables[0].Rows[0]["type de bien"].ToString() == "M")
                     {
                         Response.Write(" Maison");
                     }
                     else if (ds2.Tables[0].Rows[0]["type de bien"].ToString() == "I")
                     {
                         Response.Write(" Immeuble");
                     }
                     else if (ds2.Tables[0].Rows[0]["type de bien"].ToString() == "T")
                     {
                         Response.Write(" Terrain");
                     }
                     else if (ds2.Tables[0].Rows[0]["type de bien"].ToString() == "Local")
                     {
                         Response.Write(" Local");
                     }
             } %><br/>
<b>Adresse:</b><%if (Session["idmandat"].ToString() != "")
             {
                 string Ref = (string)Session["idmandat"];
                 String requette2 = "select `adresse vendeur`,`code postal vendeur`, `ville vendeur` from biens where `ref`='" + Ref + "'";
                 System.Data.DataSet ds2 = null;
                 Connexion c2 = null;

                 c2 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                 c2.Open();
                 ds2 = c2.exeRequette(requette2);
                 c2.Close();
                 c2 = null;
                 Response.Write(ds2.Tables[0].Rows[0]["adresse vendeur"].ToString() + " " + ds2.Tables[0].Rows[0]["code postal vendeur"].ToString() + " " + ds2.Tables[0].Rows[0]["ville vendeur"].ToString());
             } %><br/>
<b>Désignation succincte </b>(la désignation détaillée faisant l’objet d’une fiche séparée) – renseignements cadastre – copropriété : n° de lot, superficie privative des lots supérieurs à 8m² à l’exclusion des lots à usage de cave, garage et emplacements de stationnement<br />
<br />
<br />
<br />
<b>Usage: </b> habitation - mixte habitation/professionnel - professionnel - commercial
<br /><br /><b>Durée du bail: </b> 
<br /><br /><b>Loyer mensuel:</b> 
<br />– montant : 
<br />– révision : – indice de référence : 

<br /><br /><b>Charges</b> (provisions mensuelles) : avec régularisation annuelle. 
<br /><br /><b>Mode de paiement:</b> par trimestre(1) - par mois(1) - d'avance(1) - à terme échu(1) 
<br /><br /><b>Dépôt de garantie:</b>
<br /><br /><b>Jouissance:</b> Le mandant déclare que les biens sont libres(1) - seront libres(1) de toute location, occupation, réquisition ou préavis de réquisition le 
<br /><br /><b>Conditions particulières:</b> 
<br /><br /><br /><br />
</font>
<br />
</td>
</tr>

<tr>
<td style="background-color:yellow" height=20><font size="5">
<b>
REMUNERATION
</b>
</font>
</td>
</tr>
<tr>
<td align="justify">
<font size="4">
Lorsque la location aura été effectivement conclue, la rémunération du mandataire deviendra immédiatement exigible.  
<br />Le mandataire aura droit aux honoraires suivants, établis selon le tarif de son cabinet et détaillés s’il y a lieu sur la facture à établir, d’un montant H.T. de &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 soit au taux actuel de la T.V.A. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                           . 
<br />Cette rémunération sera : à la charge du locataire (1) et à la charge du bailleur (1) - partagée par moitié entre le bailleur et le locataire (1)
<br />En cas de litige, le seul tribunal compétent sera celui du domicile du mandataire. 
</td>
</tr>
<tr>
<td valign=bottom align=right height=100%>
Paraphes
<br /><br /><br />
</td>
</tr>
<tr>
<td align="justifiy"><font size="4">
<i>(1) rayer les mentions inutiles</i><br />
-----------------   BORDERAU DETACHABLE   ---------------------------------------------------------------------------------------------------------------------
</font>
<font size="2">
<br /><i>( Selon l'article L121-25 du code de la consommation, 
"Dans les sept jours, jours fériés compris, à compter de la commande ou de l'engagement d'achat, le client a la faculté d'y renoncer par lettre recommandée avec accusé de réception. Si ce délai expire normalement un samedi, un dimanche ou un jour férié ou chômé, il est prorogé jusqu'au premier jour ouvrable suivant."
</i>
</font>
<br /><br />
<font size="3">
<i>Je soussigné  <%string Refer = (string)Session["idmandat"];
                  String requette4 = "select `nom vendeur`, `prenom vendeur` from biens where `ref`='" + Refer + "'";
                  System.Data.DataSet ds4 = null;
                  Connexion c4 = null;

                  c4 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                  c4.Open();
                  ds4 = c4.exeRequette(requette4);
                  c4.Close();
                  c4 = null;
                  Response.Write(ds4.Tables[0].Rows[0]["nom vendeur"].ToString() + " " + ds4.Tables[0].Rows[0]["prenom vendeur"].ToString());%> souhaite utiliser ma faculté de renonciation aux présent mandat n° <%string Refe = (string)Session["idmandat"];
                                                                                                                                                                                                                   String requette3 = "select `num_mandat`from biens where `ref`='" + Refe + "'";
                                                                                                                                                                                                                   System.Data.DataSet ds3 = null;
                                                                                                                                                                                                                   Connexion c3 = null;

                                                                                                                                                                                                                   c3 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                                                                                                                                                                                                                   c3.Open();
                                                                                                                                                                                                                   ds3 = c3.exeRequette(requette3);
                                                                                                                                                                                                                   c3.Close();
                                                                                                                                                                                                                   c3 = null;
                                                                                                                                                                                                                   Response.Write(ds3.Tables[0].Rows[0]["num_mandat"].ToString());
                                                                                                                                                                                                                   %> (cf. article L121-25 du code de la conso.)
<br /><br />Fait à &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;le
<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Signature
</i>
</font>
<br /><br /><br />
</td>
</table>


<table width="1100"   cellspacing="5" cellpadding="1" border="0" align=center>

<tr>
<td align=center>
<font size="6">
<b>CONDITIONS GENERALES DU MANDAT</b>
</font>
<br /><br />
</td>
</tr>
<tr>
<td style="background-color:yellow" height=20><font size="5">
<b>
POUVOIR
<br />
</b>
</font>
</td>
</tr>
<tr>
<td align="justify">
<font size="4">
<br />
En conséquence du présent mandat, le mandant donne au mandataire qui accepte, pouvoir de : 
<br />— rédiger et signer tous actes nécessaires à l’accomplissement des présentes et notamment les engagements exclusifs de réservation, le bail et le constat d’état des lieux, et procéder à la remise des clés ; 
<br />— réclamer toutes pièces utiles auprès de toutes personnes privées ou publiques, notamment le certificat d’urbanisme ; 
<br />— établir ou faire établir tous les diagnostics obligatoires ainsi que tous documents indispensables à l’information du locataire et notamment celui relatif aux risques naturels et technologiques, conformément à l’article L 125-5 du code de l’environnement ; 
<br />— transmettre les informations à des partenaires commerciaux, faire tout ce qu’il jugera utile pour parvenir à la location, effectuer toute publicité à sa convenance notamment photos, panonceaux, insertions dans des supports électroniques et notamment www.fnaim.fr et .com, aux frais du mandataire ; 
<br />— l’autorise, mais seulement en cas de mandat de location avec carte portant la mention «gestion immobilière» à percevoir pour le compte du mandant le premier terme du loyer, des provisions pour charges et le dépôt de garantie. 

<br /><br /></font>
</td>
</tr>
<tr>
<td style="background-color:yellow" height=20><font size="5">
<b>
OBLIGATION DU MANDANT
</b>
</font>
</td>
</tr>
<tr>
<td align="justify">
<font size="4">
<br />
Le mandant : 
<br />— s’engage à produire toutes les pièces justificatives de propriété demandées ; 
<br />— s’oblige à assurer au mandataire le moyen de faire visiter lesdits locaux pendant le présent mandat à toute personne que le mandataire jugera utile ; 
<br />— s’engage pendant la durée du mandat à accepter tout preneur présenté par le mandataire aux conditions des présentes ; 
<br /><b>— s’interdit, pendant le cours du présent mandat et de ses renouvellements ainsi que dans les six mois suivant l’expiration ou la résiliation de celui-ci, de traiter directement ou par l’intermédiaire d’un autre mandataire avec un locataire à qui le bien aurait été présenté par le mandataire ou un mandataire substitué. A défaut de respecter cette clause, le mandataire aura droit à une indemnité forfaitaire, à titre de clause pénale, à la charge du mandant d’un montant égal à celui de la rémunération toutes taxes comprises du mandataire prévue au présent mandat ;
<br />— il s’interdit, pendant la durée du mandat, de louer directement ou indirectement les locaux ci-dessus désignés et s’engage à diriger sur le mandataire toutes les demandes qui lui seraient adressées personnellement.</b>
<br />— s’oblige à informer le mandataire dès lors qu’il a été indemnisé pour tous sinistres survenus conformément aux articles L 125-2 ou L 128-2 du code des assurances.
<br /><br /><b>A défaut de respecter l’une ou l’autre de ces clauses, il s’engage expressément à verser au mandataire, à titre de clause pénale, une indemnité forfaitaire d’un montant égal à celui des honoraires que son mandataire aurait perçu en cas de réalisation par ses soins, indépendamment de toutes indemnités qui pourraient être dues au locataire évincé.</b>
<br /><br />
</td>
</tr>
<tr>
<td style="background-color:yellow" height=20><font size="5">
<b>
OBLIGATION DU MANDATAIRE
<br />
</b>
</font>
</td>
</tr>
<tr>
<td align="justify">
<font size="4">
<br />
Le mandataire s’oblige : 
<br />— à effectuer toutes diligences qu’il jugera utiles pour réaliser la location, objet des présentes ; 
<br />— à rendre compte de ses diligences à la demande du mandant et au moins en fin de mandat. 
<br /><br /></font>
</td>
</tr>
<tr>
<td style="background-color:yellow" height=20><font size="5">
<b>
DUREE
<br />
</b>
</font>
</td>
</tr>
<tr>
<td align="justify">
<font size="4">
<br />
Le mandant donne le présent mandat à compter de ce jour pour une durée de six mois. Passé ce délai, il se renouvellera par tacite reconduction de trois mois en trois mois, étant précisé cependant qu’il pourra être dénoncé à tout moment avec préavis de quinze jours par lettre recommandée avec avis de réception. Il prendra fin au terme de l’opération de location et dans tous les cas au plus tard dans le délai d’un an à compter de ce jour. Le mandant dispense le mandataire de l’aviser par lettre recommandée avec avis de réception de l’accomplissement du présent mandat. S’il est détenteur de la carte « gestion immobilière », dès qu’il sera crédité des sommes versées par le locataire, le mandataire devra les régler au mandant sous déduction éventuelle de la quote-part des honoraires incombant à ce dernier. 
<br /><br /><br />
<i>
Fait au cabinet du mandataire, en deux exemplaires, dont l'un a été remis au mandant qui le reconnaît, et dont l'autre est conservé par le mandataire, et le restera dans tous les cas par dérogation à l'article 2004 du Code civil.  
</i>
</font>

<br /><br />
Mots nuls ...  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   Lignes nulles ... 
<br /><br />
A &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  Le
	
<br /><br /><br /><br />	
LE MANDANT	
&nbsp;&nbsp;&nbsp;
</font>
<font size="2"><i>( mention " Lu et approuvé " )</i>
</font>
<font size="4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
LE MANDATAIRE
&nbsp;&nbsp;&nbsp;
</font>
<font size="2"><i>( mention " Lu et approuvé " )</i>
</font>
<font size="4">
</font>
</td>
</tr>
<tr>
<td valign=bottom align=right height=100%>
<br />
<br />
<br />
<br />
<br />
Paraphes
</td>
</tr>
</table>

</body>
</html>
