<%@ Page Title="" Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="Mentions_Legales.aspx.cs" Inherits="pages_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder1" Runat="Server">
    <div id="MentionsLegales" 
        style="color: #333399; font-family: Verdana; font-size: small">
       <p>
            Les informations présentes répondent aux obligations de publication demandées par la loi n°2004-575 pour la Confiance dans l&#8217;Economie Numérique : L.E.N.
       </p>
            <p style="font-size: medium"><strong>EDITEUR</strong></p>
       <p>      
            <strong>PATRIMO<br />
        </strong>reseau d'agents mandataires<br />
        EURL au capital de 10.000 euros<br />
            Siège social : 	<% Response.Write(Session["adresse_agence"] + " " + Session["code_postal_agence"] + " " + Session["ville_agence"]); %> 
        <br />
        <br />
            Siret : 454 067 596 00030 
        <br />
       Code APE : 6831Z<br />
        <br />
            Directeur : Olivier SAGLIOO<br />
            N° de téléphone : 01 46 49 82 60<br />
       </p>
       
       <p style="font-size: medium"> <strong>1. CONFIDENTIALITE</strong></p>
       <p>
            a. Collecte d&#8217;informations personnelles<br />
            Au cours de votre navigation sur le site, il peut vous être demandé de remplir certains champs de formulaires qui sont destinés à une utilisation interne.
       </p>
       <p>
            b. Mise à jour de vos informations personnelles
            Conformément à l&#8217;article 34 de la loi du 6 janvier 1978 relative à l&#8217;informatique, aux fichiers et aux libertés, vous avez un droit d&#8217;accès, de modification, de rectification et de suppression des données qui vous concernent, ainsi que vos préférences de confidentialité. Pour ce faire, accédez à vos informations via votre compte ou écrivez à :
            PATRIMO	56 B Rue Victor Hugo 92270 BOIS COLOMBES
       </p>
       <p>
        N&#8217;oubliez pas de nous communiquer vos noms, adresse et/ou adresse email.
       </p>
       <p> 
            c. Sécurité de vos informations personnelles
        </p>
        <p>
            PATRIMO ne communiquera pas vos informations personnelles à des tiers.
            PATRIMO vous informe que l&#8217;ensemble des lois et règlements en vigueur est applicable à Internet.
            Tout Utilisateur de ce site est notamment tenu de respecter &#8211; les dispositions de la loi du 6 janvier 1978 relative à l&#8217;Informatique, aux fichiers et aux libertés, dont la violation est passible de sanctions pénales.
            Vous devez également vous abstenir, s&#8217;agissant des données personnelles auxquelles vous accédez, de toute collecte, de toute utilisation détournée, et d&#8217;une manière générale, de tout acte susceptible de porter atteinte à la vie privée ou à la réputation des personnes.
         </p>
         <p style="font-size: medium">
             <strong>2. LIMITATION DE RESPONSABILITE
         </strong>
         </p>
         <p>
            a. Informations contenues dans le site<br />
            PATRIMO souhaite que les informations contenues dans le site soient correctes et fiables. Cependant, des erreurs peuvent éventuellement apparaître. Par conséquent, les informations sont fournies « telles quelles » sans aucune garantie. PATRIMO rejette toute garantie, explicite ou implicite, concernant les informations référencées par le site, incluant mais ne se limitant pas à la garantie liée la valeur marchande ou l&#8217;aptitude à un objectif défini, titre et non violation.
            PATRIMO se réserve le droit de modifier les informations contenues dans le site sans prévenir ses clients ou prospects. Dans aucun cas PATRIMO ne sera tenue pour responsable de dommage direct, spécial, accidentel ou indirect venant de l&#8217;utilisation de ou des paiements basés sur l&#8217;information contenue dans le site.
         </p>
         <p>
            b. Accès au site<br />
            Le site est accessible 24h/24h et 7 jours/7. Toutefois PATRIMO ne saurait être responsable en cas d&#8217;impossibilité momentanée d&#8217;utiliser le site en cas, notamment, de force majeure, difficultés informatiques, difficultés liées aux réseaux de télécommunications, difficultés techniques, difficultés liées au réseau EDF.
            Pour des raisons de maintenance, PATRIMO pourra interrompre l&#8217;accès au site et s&#8217;efforcera d&#8217;en avertir préalablement les utilisateurs.
         </p>
         <p style="font-size: medium">
             <strong>3. DROITS D&#8217;AUTEUR &#8211; COPYRIGHTS
         </strong>
         </p>
        <p>
            PATRIMO est propriétaire ou détient les droits sur la structure générale du site, l&#8217;arborescence, les logiciels, les textes et les représentations iconographiques et photographiques, témoignages, certains graphismes et sons appartenant à des tiers mis à part.
            Toute reproduction, représentation, modification, publication, transmission, dénaturation, totale ou partielle des sites ou de leur contenu, par quelque procédé que ce soit, et sur quelque support que ce soit est strictement et formellement interdite.
            Toute exploitation non autorisée des sites ou de leur contenu, des informations qui y sont divulguées engagerait la responsabilité de l&#8217;utilisateur et constituerait une contrefaçon sanctionnée par les articles L 335-2 et suivants du Code de la Propriété Intellectuelle.
            Il en est de même des bases de données figurant, le cas échéant, sur le site qui sont protégées par les dispositions de la loi du 1er juillet 1998 portant transposition dans le Code de la Propriété Intellectuelle de la Directive Européenne du 11 mars 1996 relative à la protection juridique des bases de données. A ce titre, toute reproduction ou extraction engagerait la responsabilité de l&#8217;utilisateur.
         </p>
         <p style="font-size: medium">
             <strong>4. MODIFICATION DES PRESENTES INFORMATIONS LEGALES
         </strong>
         </p>
         <p>   
            PATRIMO se réserve le droit de modifier les présentes mentions à tout moment. L&#8217;utilisateur s&#8217;engage donc à les consulter régulièrement.
         </p>
         <p style="font-size: medium">   
             <strong>5. DROIT APPLICABLE EN CAS DE LITIGE
         </strong>
         </p>
         <p>   
            En cas de litige, le droit applicable sera le droit français.
         </p>
         <p style="font-size: medium">   
             <strong>6. ATTRIBUTION DE JURIDICTION
         </strong>
         </p>
         <p>   
            Tout différend n&#8217;ayant pu trouver une issue transactionnelle sera porté devant les tribunaux compétents .
         </p>
    </div>

</asp:Content>

