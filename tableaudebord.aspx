<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="tableaudebord.aspx.cs" Inherits="pages_monCompte" Title="PATRIMONIUM : Mon espace client" EnableEventValidation="true" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script language="javascript" type="text/javascript"> 
    
    // <!CDATA[
    //Appelée lorsque l'utilisateur choisit d'afficher plus ou moins d'annonces sur une page.
    //La page est appelée avec en paramètre GET le nombre d'annonces par page demandé.
    function Select1_onchange() 
    {
        var url = window.location.href;
        var taille = url.length - 2;
        var partie1 = url.substring(0,taille);
        var temp = new Array();
        temp = partie1.split('=');  
        //cas où l'url ne contient pas les paramètres GET
        if(temp[1] == null){
        window.location.href=window.location.href+"?Numpage=1&typedetri=dateC&nbannonces=30";
        }
        
        var temp2 = temp[1].split('&');
        //Quand l'utilisateur affiche davantage d'annonces par pages, il doit être redirigé vers la première page car il se peut que celle sur laquelle il se trouve n'existe plus.
        var url_built= temp[0] + "=1" + "&" + temp2[1] + "="  + temp[2]+"=" + document.getElementById("Select1").value; 
      
        window.location.href=url_built;
        //window.location.href = partie1+document.getElementById("Select1").value;
  

                                    
                         
    }

</script>







<!-- VERIFICATION DES PARAMETRES DE L'AFFICHAGE -->
<%
    
    //LE SYSTEME DE PAGINATION EST IDENTIQUE A CELUI DE affichagerecherche.aspx 
    
     
    int var1 = 30;
    Session["annoncesPage"] = 30;

    if (Request.Params["nbannonces"] != null)
    {
        if (Request.Params["nbannonces"].ToString() == "10")
        {
            Session["annoncesPage"] = 10;
            var1 = 10;
        }
        else if (Request.Params["nbannonces"].ToString() == "20")
        {
            Session["annoncesPage"] = 20;
            var1 = 20;
        }
        else if (Request.Params["nbannonces"].ToString() == "30")
        {
            Session["annoncesPage"] = 30;
            var1 = 30;
        }
        else if (Request.Params["nbannonces"].ToString() == "50")
        {
            Session["annoncesPage"] = 50;
            var1 = 50;
        }
        
   
if(Request.Params["Numpage"] != null ){
        Session["Numpage"] = Request.Params["Numpage"];
}
else {
    Session["Numpage"]=1;
}
    }
       
    //permet de récupérer les biens ajouté par le négociateur : MailNego   
    Membre member = (Membre)Session["Membre"];
    String MailNego = member.ID_CLIENT;
            
    int i = 0;
    String typedetri = "";
    if (Request.Params["typedetri"] != null)
    {
        typedetri = Request.Params["typedetri"];
    }
    else 
    {
        typedetri="dateD";
    } 
    
    System.Collections.Generic.List<Bien> biens = null;
        biens = BienDAO.getAllBiensTableauDeBord(MailNego,typedetri);
    //
	Response.Write(MailNego);
	Response.Write(biens);
	Response.Write(typedetri);

	
	//
    int nbrBiens = biens.Count;
    int j = biens.Count;
    int nbrePage = 0;
    string typeTri = "";
    typeTri = Session["Tri"].ToString();
    int indexPage = 1; //index de la page utilisateur
    if (Session["Numpage"] != null)
    {
        indexPage = Int32.Parse(Session["Numpage"].ToString());
    }

        
    if (j % var1 != 0) { nbrePage = (j / var1) + 1; }
    else { nbrePage = (j / var1); }
%>


<table class="moncompte" >
    <tr>   
        <td class="moncompteG1">
            <b>Mes options</b>
        </td>
           
        <td class="moncompteD1">                                   
                        <strong>Bienvenue
                            <asp:Label ID="LabelPrenom" runat="server" Text="LabelPrenom"></asp:Label>&nbsp
                            <asp:Label ID="LabelNom" runat="server" Text="LabelNom"></asp:Label>                        </strong>                                 
        </td>        
    </tr>
    <!-- Menu mon compte -->
    <%if(member.STATUT == "ultranego" || member.STATUT == "nego" || member.STATUT == "nego_agence")
              { %>
            <!--#include file="./menumoncompte.aspx"-->
            <%} %>
            <%else
              { %>
            <!--#include file="./menumoncompte1.aspx"-->
            <%} %>
    <tr > 
        <td class="moncompteG">
        <%
               
                Response.Write("<div class=\"Imagecentre\"><img class=\"ImageProfilPetite\" src=\"../img_nego/" + member.NOM + member.PRENOM + "_PHOTO.jpg" + "\" /></div><br /> <br />"); %>
            <a href="./moncomteCoordonnees.aspx" style="cursor: hand"><img src='../img_site/fleche2.ico' border='0' width='15px' height='13px'> Modifier mes coordonnées</a><br /><br />
            <a href="./monCompteAlertes.aspx" style="cursor: hand"><img src='../img_site/fleche2.ico' border='0' width='15px' height='13px'> Afficher mes alertes</a><br /><br />
            <a href="./monCompteAnnonces.aspx" style="cursor: hand"><img src='../img_site/fleche2.ico' border='0' width='15px' height='13px'> Consulter ma sélection</a><br /><br />            
            <a href="./monCompteDeconnexion.aspx" style="cursor: hand"><img src='../img_site/fleche2.ico' border='0' width='15px' height='13px'> Se déconnecter</a><br /><br />
            <!-- Affiche le lien si statut nego -->
            <%if (member.STATUT == "nego")
                {
            %>
            <a href="./completerprofil.aspx" style="cursor: hand"><img src='../img_site/fleche2.ico' border='0' width='15px' height='13px'> Compléter son profil</a><br /><br />
            <a href="./choixtransaction.aspx" style="cursor: hand"><img src='../img_site/fleche2.ico' border='0' width='15px' height='13px'> Ajout d'un bien</a>
            <% } %>
       
       
        </td>
        <td  class="moncompteD">
  
          <!-- on affiche les biens dans un tableau --> 
            <table class="tableaubilan">
                <tr class="champs">
                    <td><strong>Références</strong> </td>
                    <td><strong>Date de dossier</strong></td>
                    <td><strong>Type de transaction</strong></td>
                    <td><strong>Type de bien</strong></td>
                    <td><strong>Etat du bien</strong></td>
                    <td><strong>Code postal</strong></td>
                    <td><strong>Ville</strong></td>
                    <td><strong>Prix de vente</strong></td>
                    <td><strong>Nombre de pièces</strong></td>
                    <td><strong>Surface</strong></td>
                    <td><strong>Photos</strong></td>
                    <td><strong>Modifier</strong></td>
                    <td><strong>Retirer</strong></td>
                </tr>
                <tr class="tritableaudebord"> <!-- Choix du tri de tableau, les images sont des liens vers la meme page -->
                   <% Response.Write("<td><a href=\"tableaudebord.aspx" + "?Numpage=" + indexPage + "&typedetri=refD" + "&nbannonces=" + var1 + "\"><img  src=\"../img_site/fleche_tri_bas.png\" /></a>"
                  +"      <a href=\"tableaudebord.aspx" + "?Numpage=" + indexPage + "&typedetri=refC" + "&nbannonces=" + var1 + "\"><img  src=\"../img_site/fleche_tri_haut.png\" /></a> </td>"
                  +"  <td><a href=\"tableaudebord.aspx" + "?Numpage=" + indexPage + "&typedetri=dateD" + "&nbannonces=" + var1 + "\"><img  src=\"../img_site/fleche_tri_bas.png\" /></a>"
                  +"      <a href=\"tableaudebord.aspx" + "?Numpage=" + indexPage + "&typedetri=dateC" + "&nbannonces=" + var1 + "\"><img  src=\"../img_site/fleche_tri_haut.png\" /></a> </td>"
                  +"  <td><a href=\"tableaudebord.aspx" + "?Numpage=" + indexPage + "&typedetri=transD" + "&nbannonces=" + var1 + "\"><img  src=\"../img_site/fleche_tri_bas.png\" /></a>"
                  +"      <a href=\"tableaudebord.aspx" + "?Numpage=" + indexPage + "&typedetri=transC" + "&nbannonces=" + var1 + "\"><img  src=\"../img_site/fleche_tri_haut.png\" /></a> </td>"
                  +"  <td><a href=\"tableaudebord.aspx" + "?Numpage=" + indexPage + "&typedetri=typeD" + "&nbannonces=" + var1 + "\"><img  src=\"../img_site/fleche_tri_bas.png\" /></a>"
                  +"      <a href=\"tableaudebord.aspx" + "?Numpage=" + indexPage + "&typedetri=typeC" + "&nbannonces=" + var1 + "\"><img  src=\"../img_site/fleche_tri_haut.png\" /></a> </td>"
                  +"  <td><a href=\"tableaudebord.aspx" + "?Numpage=" + indexPage + "&typedetri=etatD" + "&nbannonces=" + var1 + "\"><img  src=\"../img_site/fleche_tri_bas.png\" /></a>"
                  +"      <a href=\"tableaudebord.aspx" + "?Numpage=" + indexPage + "&typedetri=etatC" + "&nbannonces=" + var1 + "\"><img  src=\"../img_site/fleche_tri_haut.png\" /></a> </td>"
                  +"  <td><a href=\"tableaudebord.aspx" + "?Numpage=" + indexPage + "&typedetri=cpD" + "&nbannonces=" + var1 + "\"><img  src=\"../img_site/fleche_tri_bas.png\" /></a>"
                  +"      <a href=\"tableaudebord.aspx" + "?Numpage=" + indexPage + "&typedetri=cpC" + "&nbannonces=" + var1 + "\"><img  src=\"../img_site/fleche_tri_haut.png\" /></a> </td>"
                  +"  <td><a href=\"tableaudebord.aspx" + "?Numpage=" + indexPage + "&typedetri=villeD" + "&nbannonces=" + var1 + "\"><img  src=\"../img_site/fleche_tri_bas.png\" /></a>"
                  +"      <a href=\"tableaudebord.aspx" + "?Numpage=" + indexPage + "&typedetri=villeC" + "&nbannonces=" + var1 + "\"><img  src=\"../img_site/fleche_tri_haut.png\" /></a> </td>"
                  +"  <td><a href=\"tableaudebord.aspx" + "?Numpage=" + indexPage + "&typedetri=prixD" + "&nbannonces=" + var1 + "\"><img  src=\"../img_site/fleche_tri_bas.png\" /></a>"
                  +"      <a href=\"tableaudebord.aspx" + "?Numpage=" + indexPage + "&typedetri=prixC" + "&nbannonces=" + var1 + "\"><img  src=\"../img_site/fleche_tri_haut.png\" /></a> </td>"
                  +"  <td><a href=\"tableaudebord.aspx" + "?Numpage=" + indexPage + "&typedetri=piecesD" + "&nbannonces=" + var1 + "\"><img  src=\"../img_site/fleche_tri_bas.png\" /></a>"
                  +"      <a href=\"tableaudebord.aspx" + "?Numpage=" + indexPage + "&typedetri=piecesC" + "&nbannonces=" + var1 + "\"><img  src=\"../img_site/fleche_tri_haut.png\" /></a> </td>"
                  +"  <td><a href=\"tableaudebord.aspx" + "?Numpage=" + indexPage + "&typedetri=surfaceD" + "&nbannonces=" + var1 + "\"><img  src=\"../img_site/fleche_tri_bas.png\" /></a>"
                  +"      <a href=\"tableaudebord.aspx" + "?Numpage=" + indexPage + "&typedetri=surfaceC" + "&nbannonces=" + var1 + "\"><img  src=\"../img_site/fleche_tri_haut.png\" /></a> </td>"
                    
                    +"<td></td>"
                    +"<td></td>"); %>
                </tr>
                
          <%
              #region type de tri
               
                object nbannonces = Session["annoncesPage"]; 
            %>
                <select name="choix_nbpages" size="1" onchange="Select1_onchange()" id="Select1" onclick="return Select1_onclick()">
                    <option value="10" <%if(var1==10){Response.Write("selected");}%>>10</option>
                    <option value="20" <%if(var1==20){Response.Write("selected");}%>>20</option>
                    <option value="30" <%if(var1==30){Response.Write("selected");}%>>30</option>
                    <option value="50" <%if(var1==50){Response.Write("selected");}%>>50</option>
                </select> 

        


        <% 
            if (nbrePage > 1)
            {
                Response.Write("<center>");
                if (indexPage == 1) Response.Write("<a href=\"#\">Page pr&eacute;c&eacute;dente &lt;&lt; </a>");
                else Response.Write("<a href=\"./tableaudebord.aspx?Numpage=" + (indexPage - 1) + "&typedetri=" + typedetri + "&nbannonces=" + Session["annoncesPage"] + "\">Page Pr&eacute;c&eacute;dente &lt;&lt; </a>");

                for (int p = 1; p < nbrePage + 1; p++)
                {
                    if (p > 1)
                    {
                        Response.Write(" | " + "<a href=\"./tableaudebord.aspx?Numpage=" + p.ToString() + "&typedetri=" + typedetri + "&nbannonces=" + Session["annoncesPage"] + "\">" + ((p == indexPage) ? "<b>" : "") + p + ((p == indexPage) ? "</b>" : "") + "</a>");
                    }
                    else Response.Write("<a href=\"./tableaudebord.aspx?Numpage=" + p.ToString() + "&typedetri=" + typedetri +"&nbannonces=" + Session["annoncesPage"] + "\">" + ((p == indexPage) ? "<b>" : "") + p + ((p == indexPage) ? "</b>" : "") + "</a>");
                }

                if (indexPage == nbrePage) Response.Write("<a href=\"#\"> &gt;&gt; Page Suivante");
                else Response.Write("<a href=\"./tableaudebord.aspx?Numpage=" + (indexPage + 1) + "&typedetri=" + typedetri + "&nbannonces=" + Session["annoncesPage"] + "\"> &gt;&gt; Page Suivante</a>");

                Response.Write("</center>");
            }        
  
              Response.Write("Page " + indexPage + " sur " + nbrePage);

              #endregion
                %>

              
              
              

              <%
              
              /*Boucle d'affichage des resultats de la recherche*/
              System.Collections.Generic.List<Bien> dixBiens = null;
              try
              {
                  dixBiens = biens.GetRange((indexPage - 1) * var1, var1);
              }
              catch
              {
                  dixBiens = biens.GetRange((indexPage - 1) * var1, (int)(biens.Count - var1 * (indexPage - 1)));
              }

              System.Collections.Generic.IEnumerator<Bien> b = dixBiens.GetEnumerator();


              String couleur_texte = "";               
              while (b.MoveNext())
            {
                // Attribution couleur de fond et de texte
                if (b.Current.ETAT.ToString().Substring(0, 2) == "Di")
                {
                    Response.Write("<tr bgcolor=" + HttpContext.Current.Session["couleur_fond_di"] + ">");
                    couleur_texte = (String)HttpContext.Current.Session["couleur_texte_di"];
                }

                else if (b.Current.ETAT.ToString().Substring(0, 2) == "Of")
                {
                    Response.Write("<tr bgcolor=" + HttpContext.Current.Session["couleur_fond_of"] + ">");
                    couleur_texte = (String)HttpContext.Current.Session["couleur_texte_of"];
                }
                else if (b.Current.ETAT.ToString().Substring(0, 2) == "Re" && b.Current.REFERENCE.ToString().Substring(0, 1) == "V")
                {
                    Response.Write("<tr bgcolor=" + HttpContext.Current.Session["couleur_fond_re"] + ">");
                    couleur_texte = (String)HttpContext.Current.Session["couleur_texte_re"];
                }
                else if (b.Current.ETAT.ToString().Substring(0, 2) == "Co")
                {
                    Response.Write("<tr bgcolor=" + HttpContext.Current.Session["couleur_fond_co"] + ">");
                    couleur_texte = (String)HttpContext.Current.Session["couleur_texte_co"];
                }
                else if (b.Current.ETAT.ToString().Substring(0, 2) == "Es")
                {
                    Response.Write("<tr bgcolor=" + HttpContext.Current.Session["couleur_fond_es"] + ">");
                    couleur_texte = (String)HttpContext.Current.Session["couleur_texte_es"];
                }
                else if (b.Current.ETAT.ToString().Substring(0, 2) == "Su" && b.Current.REFERENCE.ToString().Substring(0, 1) == "V")
                {
                    Response.Write("<tr bgcolor=" + HttpContext.Current.Session["couleur_fond_su"] + ">");
                    couleur_texte = (String)HttpContext.Current.Session["couleur_texte_su"];
                }
                else if (b.Current.ETAT.ToString().Substring(0, 2) == "Oc")
                {
                    Response.Write("<tr bgcolor=" + HttpContext.Current.Session["couleur_fond_oc"] + ">");
                    couleur_texte = (String)HttpContext.Current.Session["couleur_texte_oc"];
                }
                else if (b.Current.ETAT.ToString().Substring(0, 2) == "Lo")
                {
                    Response.Write("<tr bgcolor=" + HttpContext.Current.Session["couleur_fond_lo"] + ">");
                    couleur_texte = (String)HttpContext.Current.Session["couleur_texte_lo"];
                }
                else if (b.Current.ETAT.ToString().Substring(0, 2) == "Op")
                {
                    Response.Write("<tr bgcolor=" + HttpContext.Current.Session["couleur_fond_op"] + ">");
                    couleur_texte = (String)HttpContext.Current.Session["couleur_texte_op"];
                }
                else if (b.Current.ETAT.ToString().Substring(0, 2) == "Ré")
                {
                    Response.Write("<tr bgcolor=" + HttpContext.Current.Session["couleur_fond_res"] + ">");
                    couleur_texte = (String)HttpContext.Current.Session["couleur_texte_res"];
                }
                else if (b.Current.ETAT.ToString().Substring(0, 2) == "Re" && b.Current.REFERENCE.ToString().Substring(0, 1) == "L")
                {
                    Response.Write("<tr bgcolor=" + HttpContext.Current.Session["couleur_fond_rel"] + ">");
                    couleur_texte = (String)HttpContext.Current.Session["couleur_texte_rel"];
                }
                else if (b.Current.ETAT.ToString().Substring(0, 2) == "Su" && b.Current.REFERENCE.ToString().Substring(0, 1) == "L")
                {
                    Response.Write("<tr bgcolor=" + HttpContext.Current.Session["couleur_fond_sul"] + ">");
                    couleur_texte = (String)HttpContext.Current.Session["couleur_texte_sul"];
                }
                else if (b.Current.ETAT.ToString().Substring(0, 2) == "Li")
                {
                    Response.Write("<tr bgcolor=" + HttpContext.Current.Session["couleur_fond_li"] + ">");
                    couleur_texte = (String)HttpContext.Current.Session["couleur_texte_li"];
                }
                i++;
                  
                  //référence du bien
                Response.Write("<td>"); Response.Write("<a> <font color=" + couleur_texte + "> <href=\"fichedetail1.aspx?ref=" + b.Current.REFERENCE + "\">" + b.Current.REFERENCE + "</font></a>"); Response.Write("</td>");

                  // date du dossier
                Response.Write("<td>"); Response.Write("<a> <font color=" + couleur_texte + "> <href=\"fichedetail1.aspx?ref=" + b.Current.REFERENCE + "\">" + b.Current.DATE_DOSSIER.ToString() + "</font></a>"); Response.Write("</td>");

                  //Type de transaction
                Response.Write("<td>"); if (b.Current.REFERENCE.ToString().Substring(0, 1) == "L") Response.Write("<a> <font color=" + couleur_texte + "> <href=\"fichedetail1.aspx?ref=" + b.Current.REFERENCE + "\">" + "Location" + "</font></a>");
                else if (b.Current.REFERENCE.ToString().Substring(0, 1) == "V") Response.Write("<a> <font color=" + couleur_texte + "> <href=\"fichedetail1.aspx?ref=" + b.Current.REFERENCE + "\">" + "Vente" + "</font></a>");
                Response.Write("</td>");

                  // Type de bien
                  Response.Write("<td>"); if (b.Current.TYPE_BIEN.ToString().Substring(0, 1) == "M") Response.Write("<a> <font color=" + couleur_texte + "> <href=\"fichedetail1.aspx?ref=" + b.Current.REFERENCE + "\">" + "Maison" + "</font></a>");
                  else if (b.Current.TYPE_BIEN.ToString().Substring(0, 1) == "A") Response.Write("<a> <font color=" + couleur_texte + "> <href=\"fichedetail1.aspx?ref=" + b.Current.REFERENCE + "\">" + "Appartement" + "</font></a>");
                  else if (b.Current.TYPE_BIEN.ToString().Substring(0, 1) == "L") Response.Write("<a> <font color=" + couleur_texte + "> <href=\"fichedetail1.aspx?ref=" + b.Current.REFERENCE + "\">" + "Loft" + "</font></a>");
                  else if (b.Current.TYPE_BIEN.ToString().Substring(0, 1) == "T") Response.Write("<a> <font color=" + couleur_texte + "> <href=\"fichedetail1.aspx?ref=" + b.Current.REFERENCE + "\">" + "Terrain" + "</font></a>");
                  Response.Write("</td>");

                  // Etat du bien
                  Response.Write("<td>"); Response.Write("<a> <font color=" + couleur_texte + "> <href=\"fichedetail1.aspx?ref=" + b.Current.REFERENCE + "\">" + b.Current.ETAT.ToString() + "</font></a>");
                  Response.Write("</td>");
                 
                  // code postal du bien
                  Response.Write("<td class=\"centre\">"); Response.Write("<a> <font color=" + couleur_texte + "> <href=\"fichedetail1.aspx?ref=" + b.Current.REFERENCE + "\">" + b.Current.CODE_POSTAL_BIEN.ToString() + "</font></a>"); Response.Write("</td>");
                  
                  // ville du bien
                  if (b.Current.VILLE_BIEN.Length > 15)
                  { Response.Write("<td>"); Response.Write("<a> <font color=" + couleur_texte + "> <href=\"fichedetail1.aspx?ref=" + b.Current.REFERENCE + "\">" + b.Current.VILLE_BIEN.Substring(0, 15) + "</font></a>"); Response.Write("</td>"); }
                  else
                  { Response.Write("<td>"); Response.Write("<a> <font color=" + couleur_texte + "> <href=\"fichedetail1.aspx?ref=" + b.Current.REFERENCE + "\">" + b.Current.VILLE_BIEN + "</font></a>"); Response.Write("</td>"); }
                  // prix de vente
                  if (b.Current.REFERENCE.ToString().Substring(0, 1) == "L")
                  { Response.Write("<td class=\"droite\">"); Response.Write("<a> <font color=" + couleur_texte + "> <href=\"fichedetail1.aspx?ref=" + b.Current.REFERENCE + "\">" + b.Current.LOYER_HC + " €" + "</font></a>"); Response.Write("</td>"); }
                  else
                  { Response.Write("<td class=\"droite\">"); Response.Write("<a> <font color=" + couleur_texte + "> <href=\"fichedetail1.aspx?ref=" + b.Current.REFERENCE + "\">" + b.Current.PRIX_VENTE + " €" + "</font></a>"); Response.Write("</td>"); }
                  
                  // nombre de pieces
                  Response.Write("<td class=\"centre\">"); Response.Write("<a> <font color=" + couleur_texte + "> <href=\"fichedetail1.aspx?ref=" + b.Current.REFERENCE + "\">" + b.Current.NBRE_PIECE + "</font></a>"); Response.Write("</td>");
                  
                  // surface habitable
                  Response.Write("<td class=\"centre\">"); Response.Write("<a> <font color=" + couleur_texte + "> <href=\"fichedetail1.aspx?ref=" + b.Current.REFERENCE + "\">" + b.Current.S_HABITABLE + " m²" + "</font></a>"); Response.Write("</td>");                  
                  Response.Write("</a>");
                  
                  //Photos
                  Response.Write("<td class=\"centerimage\">");
                  
                  if (CheckNombrePhotos(b.Current.REFERENCE) == 1)
                      Response.Write("<a href=\"fichedetail1.aspx?ref=" + b.Current.REFERENCE + "\"><img class=\"icone_photo\" src=\"../img_site/miniature_image.jpg\" /></a>");
                  else if (CheckNombrePhotos(b.Current.REFERENCE) >= 2)
                          Response.Write("<a href=\"fichedetail1.aspx?ref=" + b.Current.REFERENCE + "\"><img class=\"icone_photo\" src=\"../img_site/miniature_multiples_images.png\" /></a>");
                  else
                          Response.Write("<a href=\"fichedetail1.aspx?ref=" + b.Current.REFERENCE + "\"><img class=\"icone_photo\" src=\"../img_site/miniature_image_croix_rouge.png\" /></a>");
                      
                  Response.Write("</td>");
                  
                  // modifier
                  if (b.Current.REFERENCE.ToString().Substring(0, 1) == "L")
                  { Response.Write("<td class=\"centerimage\">"); Response.Write("<a href=\"modifier_nego_loc.aspx?reference=" + b.Current.REFERENCE + "\"><img class=\"croix_rouge\" src=\"../img_site/calepin3.png\" /></a>"); Response.Write("</td>"); }
                  else
                  { Response.Write("<td class=\"centerimage\">"); Response.Write("<a href=\"modifier_nego.aspx?reference=" + b.Current.REFERENCE + "\"><img class=\"croix_rouge\" src=\"../img_site/calepin3.png\" /></a>"); Response.Write("</td>"); }
                  // supprimer
                  Response.Write("<td class=\"centerimage\">"); Response.Write("<a href=\"supprimervente.aspx?reference=" + b.Current.REFERENCE + "\"><img class=\"croix_rouge\" src=\"../img_site/croix_rouge.png\" /></a>"); Response.Write("</td>");          
 
              }  %>

                </tr>
               
                

   
             
            </table>   
            
           
<tr><td></td><td>

            <% 
            if (nbrePage > 1)
            {
                Response.Write("<center>");
                if (indexPage == 1) Response.Write("<a href=\"#\">Page pr&eacute;c&eacute;dente &lt;&lt; </a>");
                else Response.Write("<a href=\"./tableaudebord.aspx?Numpage=" + (indexPage - 1) + "&typedetri=" + typedetri + "&nbannonces=" + Session["annoncesPage"] + "\">Page Pr&eacute;c&eacute;dente &lt;&lt; </a>");

                for (int p = 1; p < nbrePage + 1; p++)
                {
                    if (p > 1)
                    {
                        Response.Write(" | " + "<a href=\"./tableaudebord.aspx?Numpage=" + p.ToString() + "&typedetri=" + typedetri + "&nbannonces=" + Session["annoncesPage"] + "\">" + ((p == indexPage) ? "<b>" : "") + p + ((p == indexPage) ? "</b>" : "") + "</a>");
                    }
                    else Response.Write("<a href=\"./tableaudebord.aspx?Numpage=" + p.ToString() + "&typedetri=" + typedetri +"&nbannonces=" + Session["annoncesPage"] + "\">" + ((p == indexPage) ? "<b>" : "") + p + ((p == indexPage) ? "</b>" : "") + "</a>");
                }

                if (indexPage == nbrePage) Response.Write("<a href=\"#\"> &gt;&gt; Page Suivante");
                else Response.Write("<a href=\"./tableaudebord.aspx?Numpage=" + (indexPage + 1) + "&typedetri=" + typedetri + "&nbannonces=" + Session["annoncesPage"] + "\"> &gt;&gt; Page Suivante</a>");

                Response.Write("</center>");
            }        
        %> 
        </td></tr>
          
</table>

</asp:Content>

