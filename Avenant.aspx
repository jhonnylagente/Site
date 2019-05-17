<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server" class="divbonvisite">
    <title>site de l'agence immobili&eacute;re Patrimo Colombes</title>
    <meta name="TITLE" content="Patrimo" />
    <meta name="AUTHOR" content="Olivier Saglio"/>
    <meta name="OWNER" content="info@patrimo.net"/>
    <meta name="SUBJECT" content="agence immobilière"/>
    <meta name="RATING" content="renseignement"/>
    <meta name="ABSTRACT" content="patrimo.net site de l'agence immobili&grave;re Patrimo situ&eacute;e 25 rue Gabriel Peri à Colombes, vente, achat, location de maisons, d'appartements et de terrains en France"/>
    <meta name="REVISIT-AFTER" content="15 DAYS"/>
    <meta name="LANGUAGE" content="FR"/>
    <meta name="ROBOTS" content="All"/>
    <meta name="description" content="patrimo,achat vente location biens immobiliers, colombes, ile de france, hauts de seine, appartement,maison,terrain"/>
    <meta name="keywords" content="92,92000,a vendre,achat immobilier,acheter immobilier,acheter louer,agence,agence immobiliere,agence immobilieres,agence immobiliã re,agence immobilière,agence immobilières,agence immobiliére,agences immobiliere,agences immobilieres,agences immobiliers,agences immobilières,agences immobiliéres,agent immobilier,agents immobiliers,annonce,annonce immobilières,annonces,annonces immobilieres,annonces immobilières,annonces location immobilier,annonces particulier immobilier,appart,appartement,appartements,ateliers lofts,centrale des particuliers,courbevoie,dans le,departement,fnaim,france mutualiste,git immo,guy hoquet,hautes seines,hauts de seine,hautsdeseine,hlm,ile de france,immo,immobilier,immobilier achats,immobilier cher,immobilier de france,immobilier de particulier a particulier,immobilier en france,immobilier fnaim,immobilier france,immobilier locations,immobilier particulier,immobilier terrain,immobilier à vendre,immobiliere,immobilieres,immobiliers,immobiliers france,location,location immobilier,location immobiliers,location immobilières,locations immobilières,locaux commerciaux,logement,louer,maison,maisons,meublés,mmobilier,notaire,notaires,ommobilier,panorimmo,petites annonces,programmes neufs,promoteur,recherche immobilier,se loger,se loger com,site immobilier,sites immobiliers,terrain,terrains,vente,ventes,92700,colombes,patrimo,patrimo"/>
    <meta name="dc.keywords" content="92,92000,a vendre,achat immobilier,acheter immobilier,acheter louer,agence,agence immobiliere,agence immobilieres,agence immobiliã re,agence immobilière,agence immobilières,agence immobiliére,agences immobiliere,agences immobilieres,agences immobiliers,agences immobilières,agences immobiliéres,agent immobilier,agents immobiliers,annonce,annonce immobilières,annonces,annonces immobilieres,annonces immobilières,annonces location immobilier,annonces particulier immobilier,appart,appartement,appartements,ateliers lofts,centrale des particuliers,courbevoie,dans le,departement,fnaim,france mutualiste,git immo,guy hoquet,hautes seines,hauts de seine,hautsdeseine,hlm,ile de france,immo,immobilier,immobilier achats,immobilier cher,immobilier de france,immobilier de particulier a particulier,immobilier en france,immobilier fnaim,immobilier france,immobilier locations,immobilier particulier,immobilier terrain,immobilier à vendre,immobiliere,immobilieres,immobiliers,immobiliers france,location,location immobilier,location immobiliers,location immobilières,locations immobilières,locaux commerciaux,logement,louer,maison,maisons,meublés,mmobilier,notaire,notaires,ommobilier,panorimmo,petites annonces,programmes neufs,promoteur,recherche immobilier,se loger,se loger com,site immobilier,sites immobiliers,terrain,terrains,vente,ventes,92700,colombes,patrimo,patrimo"/>
    <meta name="copyright" content="© 2007 Patrimo"/>
    <meta name="revisit-after" content="15 days"/>
    <meta name="identifier-url" content="http://www.patrimo.net"/>
    <meta name="reply-to" content="info@patrimo.net"/>
    <meta name="publisher" content="Olivier Saglio"/>
    <meta name="date-creation-ddmmyyyy" content="(22012007)"/>
    <meta http-equiv="VW96.OBJECT TYPE" content="Document"/>
    <meta name="Category" content="Document"/>
    <meta name="Page-topic" content="Document"/>
    <meta name="Generator" content="visual studio"/>
    <meta name="organization" content="Patrimo"/>
    <meta name="contact" content="info@patrimo.net"/>
    <meta name="contactName" content="Olivier Saglio"/>
    <meta name="contactOrganization" content="Olivier Saglio"/>
    <meta name="contactStreetAddress1" content="25 ru Gabriel Peri"/>
    <meta name="contactZip" content="92700"/>
    <meta name="contactCity" content="Colombes"/>
    <meta name="contactState" content="France"/>
    <meta name="Classification" content="Patrimo agence immobili&grave;e Colombes"/>
    <meta http-equiv="content-Language" content="fr"/>
    <meta http-equiv="content-type" content="text/html;charset=iso-8859-1"/>
    <meta name="location" content="France, FRANCE"/>
    <meta name="expires" content="never"/>
    <meta name="date-revision-ddmmyyyy" content="(22062007)"/>
    <meta name="Distribution" content="Global"/>
    <meta name="Audience" content="General"/>
    <meta http-equiv="content-Script-Type" content="text/javascript"/>
    <meta http-equiv="content-Style-Type" content="text/ccs"/>
    <link rel="Stylesheet" type="text/css" href="../bon_de_visite.css" />

<!--<style type="text/css">
<!--#include file="../bon_de_visite.css"
</style>-->

</head>

<body >
	<div class="divbonvisite">

	<table class="tablebonvisite">
		<tr>
			<td>
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<img width="128px" src="../img_site/logo_320.jpg" alt="logo de patrimo" />
			</td>
			<td>
			<% 
           /* Membre member3 = new Membre();
            member3 = (Membre)Session["Membre"];
            String req = "select `num_agence` from Clients where `idclient`=" + member3.IDCLIENT ;
            System.Data.DataSet ds2 = null;
            Connexion c2 = null;
                           
            c2 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c2.Open();
            ds2 = c2.exeRequette(req);
            c2.Close();
            c2 = null;

            System.Data.DataRowCollection dr2 = ds2.Tables[0].Rows;

            string num_agence="";
            foreach (System.Data.DataRow ligne2 in dr2)
                num_agence = ligne2["num_agence"].ToString();
                
            if (num_agence == "999")
            {
                num_agence="001";
            }
            
            String req2 = "Select * from Agences where `num_agence`='" + num_agence + "'";
            
            c2 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c2.Open();
            ds2 = c2.exeRequette(req2);
            c2.Close();
            c2 = null;

            dr2 = ds2.Tables[0].Rows;*/

           // foreach (System.Data.DataRow ligne2 in dr2)
            //{

            //on utilise les valeurs de l'id de session pour ne pas refaire une requette
                Response.Write("<strong>" + Session["nom_agence"].ToString() + "</strong><br />");
                Response.Write(Session["adresse_agence"].ToString() + "<br />");
                Response.Write(Session["code_postal_agence"].ToString() + " " + Session["ville_agence"].ToString() + "<br />");
                Response.Write("Tél : " + Session["telephone_agence"].ToString());
            //}           
			%>
			</td>
	</tr>
</table>

<table>
	<tr>

		<br />
		<!--<div class="titre_bdv">-->

            
		<!--<span class="cadre_titre_bdv texte_gras">BOIS COLOMBES, le <% //Response.Write(DateTime.Now.ToShortDateString()); %></span>
		</div>-->

		<asp:label id="LabelNom" runat="server"/>
        <td class="cell40">
            <% 
            Membre member = (Membre)Session["Membre"];
			
			String requette = "select Biens.[ref], Biens.[negociateur], Biens.[nom vendeur], Biens.[prix de vente], Biens.[net vendeur], Biens.[adresse vendeur], Biens.[code postal vendeur], Biens.[ville vendeur], Biens.[adresse du bien], Biens.[code postal du bien], Biens.[ville du bien] FROM Biens WHERE Biens.[ref]='" + Session["ref_sel"] + "' ;";
            System.Data.DataSet ds = null;
            Connexion c = null;
            c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            c.Open();
            ds = c.exeRequette(requette);
            c.Close();
            c = null;

            System.Data.DataRowCollection dr = ds.Tables[0].Rows;
            foreach (System.Data.DataRow ligne in dr)
            {
            %>

             <br />
        </td>


<p class="texte" >
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <strong>AVENANT AU MANDAT N° <%Response.Write(ligne["ref"].ToString()); %></strong><br /><br /><br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
Madame, Monsieur  
			<strong><%
                Response.Write(ligne["nom vendeur"].ToString().ToUpper());
			%></strong><br /><br />

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
Nous avons pris bonne note que vous acceptiez d'abaisser le prix de l'objet 
<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
du mandat de vente n° 
			<strong><%
                Response.Write(ligne["ref"].ToString());
			%></strong>.<br /><br />

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
Le nouveau prix est donc de 
			<strong><%
                Response.Write(ligne["net vendeur"].ToString());
			%></strong> euros net vendeur. <br /><br />

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
Nous vous serions reconnaissants de bien vouloir nour retourner l'avenant 
<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

à ce mandat dans les plus brefs délais afin que nous puissions travailler sur 
<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

ces nouvelles bases et que nous vous donnions satisfaction dès que possible.<br /><br />

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
Restant à votre disposition,
<br /><br />

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
Nous vous prions de croire, Madame, Monsieur, en l'assurance de nos sentiments dévoués.
</p>

<br />
<p class="texte">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    A <%Response.Write(Session["ville_agence"]);%> le  <%Response.Write(DateTime.Now.ToShortDateString());%><br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<%Response.Write(ligne["negociateur"].ToString().ToUpper());%>
</p>
<hr class="separation"/>
<!--<p class="texte">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;........................................................................................................................................................</p>-->
<p class="texte" >
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<strong>AVENANT AU MANDAT N°<%Response.Write(ligne["ref"].ToString()); %></strong> <br /><br /><br />

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
Je sousigné, 
	<strong><%
		Response.Write(ligne["nom vendeur"].ToString().ToUpper());
			%></strong> 
			demeurant : <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
	<strong><%
		Response.Write(ligne["adresse vendeur"].ToString() + "  ");
		Response.Write(ligne["code postal vendeur"].ToString() + "  ");
		Response.Write(ligne["ville vendeur"].ToString());
			%></strong> 
			<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			autorise l'agence à présenter de ce jour mon bien sis : <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<%
		Response.Write(ligne["adresse du bien"].ToString() + "  ");
		Response.Write(ligne["code postal du bien"].ToString() + "  ");
		Response.Write(ligne["ville du bien"].ToString());
			%>
			au prix de 
	<strong><%
		Response.Write(ligne["prix de vente"].ToString());
			%></strong>
			euros <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			y compris notre rémunération.
			<br />
</p>
		
<p class="texte">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
A:................................................  Le:................................................<br /><br /><br />

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
Signature(s) </p>
<%}%>
	</tr>
</table>

</div>
</body>

</html>