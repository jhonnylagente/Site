<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MandatConfiance.aspx.cs" Inherits="pages_Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<style>
@media print
{
table {page-break-after:auto}
}
</style>
</head>

<body>

<table width="1080" cellspacing="20" cellpadding="1" border="0" align=center >

<tr>
<td align=center>
<img style="padding: 5px; border: 0px solid #000000;" src="../img_site/logo_patrimo.jpg" align=left>
<font size="6">
<b>
MANDAT CONFIANCE DE VENTE N° <%string Re = (string)Session["idmandat"];
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
<br>
<font size="4">
<i>
(Article 6 loi N° 70-9 du 2 janvier 1970 et articles 72 et suivants du décret N° 72-678 du 20 juillet 1972)
</i>
</font>
<br>
<font size="4">
<b>
(Rémunération à la charge de l’acquéreur)
</b>
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
<br>
Titulaire de la carte professionnelle « transactions sur immeubles et fonds de commerce » n° 06.92.N. 578 T02032  délivrée par la Préfecture de Nanterre, garanti par Allianz 87 rue de Richelieu   75002 PARIS sous le n° 41404407 , pour un montant de 110000 € , titulaire du compte spécial (article 55 du décret du 20 juillet 1972) n°30003 04061 00028000002 04 ouvert auprès de La Société Générale.
<br><br>APRÈS AVOIR PRIS CONNAISSANCE DES CONDITIONS GÉNÉRALES, CI-APRÈS, <b>le mandant confère au mandataire, qui accepte, mandat CONFIANCE de vendre les biens ci-après désignés aux prix, charges et conditions suivants :</b>
</font>
</td>
</tr>
<tr>
<td style="background-color:yellow" height=20><font size="5">
<b>
DESIGNATION
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
<b>Désignation succincte </b>(la désignation détaillée faisant l’objet d’une fiche séparée) – renseignements cadastre – copropriété : n° de lot, superficie privative des lots supérieurs à 8m² à l’exclusion des lots à usage de cave, garage et emplacements de stationnement<br>
<br/>
<br/>
<br/>
<br/>
Le mandant déclare que ces biens seront, le jour de la signature de l’acte de vente : 
<br/>
&#9675; libres de toute location ou occupation,
<br/>
&#9675; loués suivant l’état locatif ci-annexé.

</font>
<br/>
</td>
</tr>
<tr>
<td style="background-color:yellow" height=20><font size="5">
<b>
PRIX - MODALITÉS DE PAIEMENT
</b>
</font>
</td>
</tr>
<tr>
<td>
<font size="4">
Le prix demandé - hors rémunération du mandataire - est de &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; €  
<br>payable au plus tard le jour de la signature de l’acte définitif.
</font>
</td>
</tr>
<tr>
<td style="background-color:yellow" height=20><font size="5">
<b>
DUREE DU MANDAT
</b>
</font>
</td>
</tr>
<tr>
<td align="justify">
<font size="4">
<b>Le présent mandat est donné à compter de ce jour pour une durée de trois mois. Passé ce délai, sauf révocation à tout moment par lettre recommandée avec avis de réception, sous réserve d’un préavis de quinze jours, il se poursuivra par tacite reconduction par périodes de 12 mois.</b>
</font>
</td>
</tr>
<tr>
<td style="background-color:yellow" height=20><font size="5">
<b>
REMUNERATION DU MANDATAIRE
</b>
</font>
</td>
</tr>
<tr>
<td align="justify">
<font size="4">
En cas de réalisation de l’opération avec un acheteur présenté par le mandataire ou un mandataire substitué, le mandataire aura droit à une rémunération fixée à &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;		hors taxe, à la charge de l’acquéreur.
En cas d’exercice d’un droit de substitution ou de préemption, la rémunération sera due par le préempteur.
</font>
<br>
</td>
</tr>
<tr>
<td style="background-color:yellow" height=20><font size="5">
<b>
CLAUSES PARTICULIERES
</b>
</font>
</td>
</tr>
<tr>
<td>
<br/>
<br/>
</td>
</tr>
<tr>
<td valign=bottom align=right height=100%>
Paraphes
<br/><br/>
</td>
</tr>
<tr>
<td align="justifiy"><font size="4">

-----------------   BORDERAU DETACHABLE   ---------------------------------------------------------------------------------------------------------------------
</font>
<font size="2">
<br><i>( Selon l'article L121-25 du code de la consommation, 
"Dans les sept jours, jours fériés compris, à compter de la commande ou de l'engagement d'achat, le client a la faculté d'y renoncer par lettre recommandée avec accusé de réception. Si ce délai expire normalement un samedi, un dimanche ou un jour férié ou chômé, il est prorogé jusqu'au premier jour ouvrable suivant."
</i>
</font>
<br><br>
<font size="3">
<i>Je soussigné <%string Refer = (string)Session["idmandat"];
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
<br><br>Fait à &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;le
<br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Signature
</i>
</font>
<br><br><br>
</td>
</table>


<table width="1100"   cellspacing="3" cellpadding="0" border="0" align=center>

<tr>
<td align=center>
<font size="4">
<b>CONDITIONS GENERALES DU MANDAT</b>
</font>
</td>
</tr>
<tr>
<td style="background-color:yellow" height=20><font size="4">
<b>
CONDITIONS CONCERNANT LE MANDANT
</b>
</font>
</td>
</tr>
<tr>
<td align="justify">
<font size="3,5">
En conséquence du présent mandat, le mandant :
<br>— déclare ne pas avoir consenti, par ailleurs, de mandat de vente non expiré ou dénoncé ; 
<br>— s'interdit de le faire ultérieurement sans avoir préalablement dénoncé le présent mandat ;
<br>— s'engage à produire toutes les pièces justificatives de propriété demandées par le mandataire et à l'informer de toutes modifications concernant le bien et/ou le propriétaire ;
<br>— donne au mandataire tous pouvoirs pour réclamer toutes pièces utiles auprès de toutes personnes privées ou publiques, notamment le certificat d'urbanisme ;
<br>— autorise expressément le mandataire à :
<br>- saisir l'ensemble des informations contenu dans le présent mandat sur fichier télématique ; le mandant pourra exercer son droit d'accès et de recti-fication conformément à l'article 27 de la loi du 6 janvier 1978 ;
<br>- faire tout ce qu'il jugera utile pour parvenir à la vente, effectuer toute publicité à sa convenance avec diffusion éventuelle de photos et notamment pose de panonceaux, insertion dans des supports électroniques et notamment www.fnaim.fr, aux frais du mandataire ;
<br>- indiquer, présenter et faire visiter les biens désignés sur le présent mandat à toutes personnes qu'il jugera utile. A cet effet, il s'oblige à lui assurer le moyen de visiter pendant le cours du présent mandat ; substituer, faire appel à tout concours et faire tout ce qu'il jugera utile en vue de mener à bonne fin la conclusion de la vente des biens sus désignés ;
<br>— autorise le mandataire à établir tous actes sous seing privé aux clauses et conditions nécessaires à l'accomplissement des présentes et recueillir la signature de l’acquéreur. A cet effet, le mandant s’engage à fournir au mandataire dans les plus brefs délais tout document nécessaire à la rédaction de l’acte et notamment les diagnostics techniques obligatoires.
<br><b>Si le présent mandat porte sur un ou plusieurs lots ou fractions de lots de copropriété</b>, il est ici rappelé que l’article 46 de la loi n° 65 557 du 10 juillet 1965 dispose que, sauf pour les caves, garages, emplacements de stationnement ou lots ou fractions de lots d'une superficie inférieure à 8 m², toute promesse unilatérale de vente, tout contrat réalisant ou constatant la vente d'un lot ou d'une fraction de lot mentionne la superficie de la partie privative de ce lot ou de cette fraction de lot. La nullité de l'acte peut être invoquée sur le fondement de l'absence de toute mention de superficie.  
<br>Le bénéficiaire   en cas de promesse de vente    ou l’acquéreur peut intenter l’action en nullité, au plus tard à l’expiration d’un délai d’un mois à compter de l’acte authentique constatant la réalisation de la vente.
<br>La signature de l’acte authentique constatant la réalisation de la vente mentionnant la superficie de la partie privative du lot ou de la fraction de lot entraîne la déchéance du droit à engager ou à poursuivre une action en nullité de la promesse ou du contrat qui l’a précédé, fondée sur l’absence de mention de cette superficie.
<br>Si la superficie est supérieure à celle exprimée dans l'acte, l'excédent de mesure ne donne lieu à aucun supplément de prix. 
<br>Si la superficie est inférieure de plus d'un vingtième à celle exprimée dans l'acte, le vendeur, à la demande de l'acquéreur, supporte une diminution du prix proportionnelle à la moindre mesure. 
<br>L'action en diminution du prix doit être intentée par l'acquéreur dans un délai d'un an à compter de l'acte authentique constatant la réalisation de la vente, à peine de déchéance. 
<br>Cela rappelé, il est ici convenu que :
<br>&#9675; Le mandant prend acte de ces dispositions et fournira, sous son entière et seule responsabilité, la superficie de la partie privative des biens ob-jets du présent mandat dans les huit jours des présentes. 
<br>&#9675; Le mandataire procèdera au mesurage de la partie privative des biens objets du présent mandat à l’effet de reporter sa superficie dans tout acte sous seing privé qu’il pourra être amené à établir en vue de réaliser la vente desdits biens.
<br><b>Si le présent mandat porte sur un ou plusieurs biens immobiliers situés dans des zones couvertes par un plan de prévention des risques technologiques ou par un plan de prévention des risques naturels prévisibles, prescrit ou approuvé, ou dans des zones de sismicité définies par décret en Conseil d’Etat</b>, il est ici rappelé que conformément à l’article L 125-5 du code de l’environnement, l’acquéreur est informé par le vendeur de l’existence des risques visés par ces plans ou ce décret. De plus, lorsqu’un immeuble bâti a subi un sinistre ayant donné lieu au versement d’une indemnité d’assurance garantissant les risques de catastrophes naturelles ou technologiques visés respectivement par les articles L 125-2 et L 128-2 du code des assurances, le vendeur est tenu d’informer par écrit l’acquéreur de tout sinistre survenu pendant la période où il a été propriétaire ou dont il a été lui-même informé en application des présentes dispositions. En cas de non-respect, l’acquéreur peut poursuivre la résolution du contrat ou demander au juge une diminution du prix de vente.
<br>       Cela rappelé, il est ici convenu que :
<br>       - Le mandant prend acte de ces dispositions et fournira, sous son entière et seule responsabilité, l’état des risques technologiques, naturels ou sismiques afférent aux biens objets du présent mandat dans les huit jours des présentes
<br>       - Le mandant charge le mandataire de dresser un état des risques sur la base des informations mises à disposition par la préfecture, à l’effet d’en faire mention dans tout acte sous seing privé que ce dernier pourra être amené à établir en vue de réaliser la vente des biens objets du présent man-dat.
<br>— autorise le mandataire, en cas d’exercice d’un droit de préemption, à négocier et conclure avec le préempteur, bénéficiaire de ce droit, sauf à en référer à son mandant, lequel conserve la faculté d’accepter le prix finalement obtenu par le mandataire ;
<br>— <b>s'oblige à ratifier la vente avec l'acquéreur présenté par le mandataire ou un mandataire substitué aux prix, charges et conditions du présent mandat. A défaut, il s’expose à devoir au mandataire le montant des honoraires ci-dessus mentionnés, à titre d’indemnité.</b>
<br>— autorise expressément le mandataire à recevoir un versement d'un montant maximum de 10 % du prix total de la vente. Ce versement sera effectué à la banque où est ouvert le compte spécial (article 55 du décret du 20 juillet 1972) du mandataire.
<br>La rémunération du mandataire sera exigible le jour où l'opération sera effectivement conclue et réitérée par acte authentique.
<br><b>Pendant toute la durée du présent mandat et de ses renouvellements, le mandant pourra traiter directement ou par l’intermédiaire d’un autre mandataire la vente des biens ci-dessus désignés sous réserve de reverser 50% de commissions prévu par la vente du bien. Il s’engage à diriger vers le mandataire toutes les demandes qui lui seraient adressées personnellement. A défaut de respecter cette clause, le mandataire aurait droit à une indemnité forfaitaire, à titre de clause pé-nale, à la charge du mandant, d’un montant égal à celui de la rémunération toutes taxes comprises du mandataire prévue au présent man-dat.
<br>En outre, dans les 12 mois suivant l’expiration ou la résiliation du présent mandat, le mandant s’interdit de traiter avec un acheteur à qui le bien aurait été présenté par le mandataire ou un mandataire substitué. A défaut de respecter cette clause, le mandataire aura droit à une indemnité forfaitaire, à titre de clause pénale, à la charge du mandant d’un montant égal à celui de la rémunération toutes taxes comprise du mandataire prévue au présent mandat.</b>
</font>
</td>
</tr>
<tr>
<td style="background-color:yellow" height=20><font size="4">
<b>
CONDITIONS CONCERNANT LE MANDATAIRE
</b>
</font>
</td>
</tr>
<tr>
<td align="justify">
<font size="3,5">
En conséquence du présent mandat, le mandataire : 
<br>— entreprendra les démarches et mettra en œuvre les moyens qu'il jugera nécessaires en vue de réaliser la mission confiée ; effectuera de la publicité par tout moyen et notamment sur le site www.fnaim.fr; rendra compte dans les conditions de l'article 6 de la loi du 2 janvier 1970 et de l'article 77 du décret du 20 juillet 1972 ; 
<br>— ne pourra, en aucun cas, être considéré comme le gardien juridique des biens à vendre, sa mission étant essentiellement de rechercher un acquéreur. En conséquence, il appartiendra au mandant de prendre toutes dispositions, jusqu'à la vente, pour assurer la bonne conservation de ses biens et de souscrire toutes assurances qu'il estimerait nécessaires ; 
<br>— conservera, dans tous les cas, son exemplaire du présent mandat par dérogation aux dispositions de l'article 2004 du Code civil.

<br>Fait par <%Response.Write(member.PRENOM + " " + member.NOM);%> agent mandataire de PATRIMO en deux exemplaires dont l’un est remis au mandant qui le reconnaît.
<br>Mots nuls ...            	Lignes nulles ...
<br>A &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;	LE 

<br>	LE MANDANT	
&nbsp;&nbsp;&nbsp;
</font>
<font size="2"><i>( mention " Lu et approuvé " )</i>
</font>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
LE MANDATAIRE
&nbsp;&nbsp;&nbsp;
<font size="2"><i>( mention " Lu et approuvé " )</i>
</font>
</td>
</tr>
<tr>
<td valign=bottom align=right height=100%>
Paraphes
</td>
</tr>
</table>



</body>
</html>



