<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

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


<style type="text/css">
<!--#include file="../bon_de_visite.css"-->
</style>

</head>

<body>
<div class="divbonvisite">

<table class="tablebonvisite">
    <tr>
        <td>
        <img src="../img_site/logo_320.jpg" alt="logo de patrimo" />
        </td>
        <td>
        <% 
            Membre member3 = new Membre();
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

            dr2 = ds2.Tables[0].Rows;

            foreach (System.Data.DataRow ligne2 in dr2)
            {
                Response.Write("<strong>" + Session["nom_agence"].ToString() +"</strong><br />");
                Response.Write(Session["adresse_agence"].ToString() + "<br />");
                Response.Write(Session["code_postal_agence"].ToString() + " " + Session["ville_agence"].ToString() + "<br />");
                Response.Write("Tél : " + ligne2["telephone_agence"].ToString());
            }              
        %>

        </td>
    </tr>
</table>
<span class="petit_texte">
Garantie VERSPIEREN 110000€<br />
Carte professionnelle de la préfecture des Hauts de Seine<br />
Compte SOCIETE GENERALE
</span>

<div class="titre_bdv">
<span class="cadre_titre_bdv texte_gras">Reconnaissance d'indications et de visites</span>
</div>
<asp:label id="LabelNom" runat="server"/>
    <table class="coordonnees_visiteur">
        <tr>
            <td class="cell40"><u>Coordonnées visiteur</u> <br/>
            <%   
                string Acq="";
                if ((string)Session["acq_sel"] != null)
                {
                    Acq = (string)Session["acq_sel"];
                }
                else
                {
                    Acq = "0";

                }


            String requette = "select `adresse`,`prenom`,`nom`,`code_postal`, `ville`, `tel` from acquereurs where `id_acq`=" + Acq;
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
                Response.Write("<strong>" + ligne["prenom"].ToString()+ " " +ligne["nom"].ToString()+ "</strong><br />");

                Response.Write(ligne["adresse"].ToString() + "<br/>");
                Response.Write(ligne["code_postal"].ToString() + " " + ligne["ville"].ToString() + "<br/>");
                if (ligne["tel"].ToString() != null)
                {
                    if (ligne["tel"].ToString() != "")
                    {
                        Response.Write("tel : " + ligne["tel"].ToString());
                    }
                }
				

            }
             
             
             %>
            </td>
            <td class="cell20">
         
            </td>
            <td class="cell40">
                <table>
                    <tr>
             
             <% 
              
              Membre member = (Membre)Session["Membre"];
              Response.Write(" <tr> ");
              Response.Write(" <td><u>Références<u></td><td></td> ");
              Response.Write(" </tr> ");

              Response.Write(" <tr> ");   
              Response.Write("<td class=\"textright\">Accompagnateur :</td><td><strong> " + member.PRENOM + " " + member.NOM + "</strong></td>");
              Response.Write(" </tr> ");

              Response.Write(" <tr> ");
              Response.Write("<td class=\"textright\">Courriel :</td><td><strong>" + member.ID_CLIENT + "</strong></td>");
              Response.Write(" </tr> ");

              Response.Write(" <tr> ");
              Response.Write("<td class=\"textright\">Tel :</td><td><strong>" + member.TEL + "</strong></td>");
                Response.Write(" </tr> ");

              Response.Write(" <tr> ");
              Response.Write("<td class=\"textright\">Date de visite :</td><td><strong> " + DateTime.Now.ToString().Substring(0, 10) + "</strong></td>");
              Response.Write(" </tr> ");
                 
              //Response.Write("Date de visite : " + DateTime.Now.ToString().Substring(0,10) );
         
             
             %>
                    </tr>
                </table>
             </td>
             </tr>
             </table>
             
             <br />
             
             
             


<span class="italique texte"><i>
Nous soussignés<br />
<br />
&nbsp;  Agissant en qualité d'acquéreurs éventuels, reconnaissons avoir demandé et reçu à l'instant de votre cabinet les noms, adresses et conditions de ventes
des affaires désignées ci-après.
Nous déclarons que ces affaires nous ont été présentées en premier lieu par votre cabinet et que nous n'en avions aucune connaissance auparavant.<br />
<br />
En conséquence nous nous engageons expressément : <br /><br />
- A ne communiquer à personne ces renseignements qui nous ont été donnés à titre personnel et confidentiel ; <br />
- A informer de notre visite de ce jour toute personne qui pourrait à l'avenir nous présenter le même bien ; <br />
- A ne traiter l'achat de l'une ou de plusieurs de ces affaires que par votre seul intermédiaire, même après expiration des mandats qui vous ont été remis.<br />
<br />
En cas de violation des engagements ci-dessus, nous serions tenus à l'entière réparation des préjudices causés à votre cabinet par son éviction,
ce préjudice ne pouvant être inférieur à la commision que vous auriez perçue en concourant à l'acte.<br />
<br />
</i></span>
<span class="italique texte_gras texte_souligne grand_texte">Liste des affaires visitées</span>

<table class="table_bdv">
    <tr class="entete_table_bdv texte_gras texte">
        <td>N° dossier</td>
        <td>Mandat</td>
        <td>Adresse</td>
        <td>C.P</td>
        <td>Ville</td>
        <% if (Session["ref_sel"] != null)
           {
               if (Session["ref_sel"] != "")
               {
                   if (Session["ref_sel"].ToString().Substring(0, 1) == "L")
                   { 
                        %>
                        <td>Loyer</td>
                        <%          
                   }
                   else if (Session["ref_sel"].ToString().Substring(0, 1) == "V")
                   { 
                        %>
                        <td>Prix de vente</td>
                        <%          
                   }
                   
               }
               else
               {
                    %>
                    <td>Prix de vente</td>
                    <%
               }
           } 
        %>
        
        
        <%if(Session["ref_sel"] != null){
                string Ref = (string)Session["ref_sel"];
                string[] stringSeparators = new string[] { ";" };
                string[] WordArray = Ref.Split(stringSeparators, StringSplitOptions.None);
                int i=0;
                if (WordArray.Length >= 1)
                {
                    while( i<WordArray.Length)
                    {
                        String requette2 = "select ref, `num_mandat`, `adresse du bien`,`code postal du bien`, `ville du bien`, `prix de vente`, `loyer_cc` from biens where `ref`='" + WordArray[i] + "'";
                        ds2 = null;
                        c2= null;
                           
                        c2 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                        c2.Open();
                        ds2 = c2.exeRequette(requette2);
                        c2.Close();
                        c2 = null;

                        dr2 = ds2.Tables[0].Rows;
                        foreach (System.Data.DataRow ligne in dr2)
                        {
                            Response.Write("<tr>");
                            if(ligne["ref"].ToString().Substring(0,1) == "V")
                                Response.Write("<td>" + ligne["ref"].ToString() + "</td><td>" + ligne["num_mandat"].ToString() + "</td><td class=\"cell40\">" + ligne["adresse du bien"].ToString() + "</td><td>" + ligne["code postal du bien"].ToString() + "</td><td>" + ligne["ville du bien"].ToString() + "</td><td class=\"textright\">" + ligne["prix de vente"].ToString() + " €</td>" + " <br/>");
                            else
                                Response.Write("<td>" + ligne["ref"].ToString() + "</td><td>" + ligne["num_mandat"].ToString() + "</td><td class=\"cell40\">" + ligne["adresse du bien"].ToString() + "</td><td>" + ligne["code postal du bien"].ToString() + "</td><td>" + ligne["ville du bien"].ToString() + "</td><td class=\"textright\">" + ligne["loyer_cc"].ToString() + " €</td>" + " <br/>");
                            Response.Write("</tr>");
                        }
                       i++;
                    }
                }
        }

		  

       %>
 
    </tr>
</table>

<%
			 if(Session["ref_sel"] == "")
		{
			Response.Write("<br /><br /><br /><br /><br /><br /><br />");
		}
          Session["ref_sel"] = "";
%>
		
<p class="texte">Signature des visiteurs précédée <br />
de la mention "lu et approuvé"</p>





</div>
</body>

</html>