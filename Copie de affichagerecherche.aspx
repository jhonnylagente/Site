<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="affichagerecherche.aspx.cs" Inherits="affichagerecherche" Title="PATRIMONIUM : Résultat de la recherche" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script language="javascript" type="text/javascript">
    
    // <!CDATA[

    function Select1_onchange() 
    {
        var url = window.location.href;
        var taille = url.length - 2;
        var partie1 = url.substring(0,taille);
        window.location.href = partie1+document.getElementById("Select1").value;
    }

</script>

<% 
    int var1 = 0;
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

    if (Request.Params["Tri"] == "prix")
    {
        Session["Tri"] = "prix";
    }
    else if (Request.Params["Tri"] == "pieces")
    {
        Session["Tri"] = "pieces";
    }
    else if (Request.Params["Tri"] == "surface")
    {
        Session["Tri"] = "surface";
    }
    else if (Request.Params["Tri"] == "codepostal")
    {
        Session["Tri"] = "codepostal";
    }
    else if (Request.Params["Tri"] == "ville")
    {
        Session["Tri"] = "ville";
    }
    else if (Request.Params["Tri"] == "type")
    {
        Session["Tri"] = "type";
    }
    Session["NumPage"] = Request.Params["Numpage"];  
%>

<div class="Header-dessous">
 <table border="0" cellpadding="0" cellspacing="0" style="border-top: rgb(255,255,255) 3px solid;
        left: 0px; width: 803px; border-bottom: rgb(255,255,255) 3px solid; top: 0px">
        <tr>
             <td bgcolor="#31536c" style="margin-left: 10px" width="10">
            </td>
            <td bgcolor="#31536c" style="margin-left: 10px" width="200">
                <p align="left">
                    <strong><big><big><font color="#ffffff">Recherche</font></big></big></strong></p>
            </td>
            <td style="width: 5px; height: 60px">
            </td>
            <td align="right" style="height: 60px">
                <img alt="Golfe de Saint-Tropez" src="../img_site/patrimoniumfond.jpg"
                    width="600" /></td>
        </tr>
    </table>

</div>
  
<% 
    RequeteBien requete = (RequeteBien)Session["requete"];
    String ordre = Session["Ordre"].ToString();
          
    System.Collections.Generic.List<Bien> biens = null;

    switch (Session["Tri"].ToString())
    {
        case "prix":
            requete.REQUETE_ORDER = " ORDER BY Biens.[prix de vente]"+ordre;
        break;
        case "pieces":
            requete.REQUETE_ORDER = " ORDER BY Biens.[nombre de pieces]"+ordre ;
        break;
        case "surface":
            requete.REQUETE_ORDER = " ORDER BY Biens.[surface habitable]"+ ordre;
        break;
        case "codepostal":
            requete.REQUETE_ORDER = " ORDER BY Biens.[code postal du bien]" + ordre;
        break;
        case "ville":
            requete.REQUETE_ORDER = " ORDER BY Biens.[ville du bien]"+ ordre;
        break;
        case "type":
            requete.REQUETE_ORDER = " ORDER BY Biens.[type de bien] "+ordre;
        break;
    }
    if (requete != null)
    {
        biens = BienDAO.getAllBiens(requete.REQUETE_SQL);
    }
    int nbrBiens = biens.Count;

    System.Collections.Generic.IEnumerator<Bien> enume = biens.GetEnumerator();
    ArrayList tabref = new ArrayList();
                
    while (enume.MoveNext())
    {
        tabref.Add(enume.Current.REFERENCE.ToString());
    }
    Session["tabref"] = tabref;
       
%>

<%/*-------------------------------------------------------------------------------------------------------------------*/ %> 
  
<%
    int j = biens.Count;
    int nbrePage = 0;
    string typeTri = "";
    typeTri = Session["Tri"].ToString();
    int indexPage = Int32.Parse(Session["NumPage"].ToString()); //index de la page utilisateur

    if (j % var1 != 0) { nbrePage = (j / var1) + 1; }
    else { nbrePage = (j / var1); }
%>
     
<div class="ResultHaut">
    <div class="ResultHaut2">
        <div class="ResultHaut3">
            <!--<span class="ResultHaut4">-->
                <a style="text-decoration:underline" href="recherche.aspx"> Retour aux critères</a> 
            <!--</span>-->
        </div>
        <div class="ResultHaut5">
        <%
            if (biens.Count != 0)
            {
                if (ordre == "ASC")
                {
                    Response.Write("<CENTER> Trier les annonces par : ");
                    Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=prix&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + " \">prix</a>" + " | ");
                    Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=pieces&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + " \">pieces</a>" + " | ");
                    Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=surface&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + " \">surface</a>" + " | ");
                    Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=codepostal&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + " \">code postal</a>" + " | ");
                    Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=ville&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + " \">ville</a>" + " | ");
                    Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=type&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + " \">type</a>");
                    Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=" + typeTri + "&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + " \"> <img border=\"0\" src=\"../img_site/haut.jpg\" /></a>");
                }
                if (ordre == "DESC")
                {
                    Response.Write("<CENTER> Trier les annonces par : ");
                    Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=prix&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + " \">prix</a>" + " | ");
                    Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=pieces&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + " \">pieces</a>" + " | ");
                    Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=surface&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + " \">surface</a>" + " | ");
                    Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=codepostal&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + " \">code postal</a>" + " | ");
                    Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=ville&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + " \">ville</a>" + " | ");
                    Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=type&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + " \">type</a>");
                    Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=" + typeTri + "&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + " \"> <img border=\"0\" src=\"../img_site/bas.jpg\" /></a>");
                }
                Response.Write("</CENTER>");
            }
            else
            {%>
                <div style="font-size:15px;color:#CC3333;font-weight:bold">
                    Aucun biens ne correspondent aux critères sélectionnés
                </div>
            <%}  
        %>
        </div>
        <div class="nbAnnonces"> annonces par page
            <%
                object nbannonces = Session["annoncesPage"]; 
            %>
                <select name="choix_nbpages" size="1" onchange="Select1_onchange()" id="Select1" onclick="return Select1_onclick()">
                    <option value="10" <%if(var1==10){Response.Write("selected");}%>>10</option>
                    <option value="20" <%if(var1==20){Response.Write("selected");}%>>20</option>
                    <option value="30" <%if(var1==30){Response.Write("selected");}%>>30</option>
                    <option value="50" <%if(var1==50){Response.Write("selected");}%>>50</option>
                </select> 
        </div>
    </div>
    <div style="width:801px;height:5px">
    </div>
    <div style="width:801px;height:12px;border:1px">
        <div style="width:150px;float:left;height:12px">
        </div>
        <div style="width:495px;float:left;height:12px"> 
        <% 
            if (nbrePage > 1)
            {
                Response.Write("<center>");
                if (indexPage == 1) Response.Write("Page précedente << ");
                else Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + (indexPage - 1) + "&Tri=" + typeTri + "&Ordre=" + ordre + "&nbannonces=" + Session["annoncesPage"] + "\">Page Precedente << </a>");

                for (int p = 1; p < nbrePage + 1; p++)
                {
                    if (p > 1)
                    {
                        Response.Write(" | " + "<a href=\"./affichagerecherche.aspx?Numpage=" + p.ToString() + "&Tri=" + typeTri + "&Ordre=" + ordre + "&nbannonces=" + Session["annoncesPage"] + "\">" + ((p == indexPage) ? "<b>" : "") + p + ((p == indexPage) ? "</b>" : "") + "</a>");
                    }
                    else Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + p.ToString() + "&Tri=" + typeTri + "&Ordre=" + ordre + "&nbannonces=" + Session["annoncesPage"] + "\">" + ((p == indexPage) ? "<b>" : "") + p + ((p == indexPage) ? "</b>" : "") + "</a>");
                }

                if (indexPage == nbrePage) Response.Write(" >> Page Suivante");
                else Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + (indexPage + 1) + "&Tri=" + typeTri + "&Ordre=" + ordre + "&nbannonces=" + Session["annoncesPage"] + "\"> >> Page Suivante</a>");

                Response.Write("</center>");
            }        
        %>
        </div>
        <div style="width:150px;float:left;height:12px">
            <span style="float:right; margin-right:2px">
                <% 
                     Response.Write("Page " + indexPage + " sur " + nbrePage); 
                %>
            </span>
        </div>
    </div>
</div>

<%--<script language="javascript" type="text/javascript">" 

function popUp(URL) 
{ 
    day = new Date(); 
    id = day.getTime(); 
    eval("page" + id + " = window.open(URL, '" + id + "', 'toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=no,width=430,height=430,left = 440,top = 312');"); 
}
 
</script>--%>

<% 
            Response.Write("<script language=\"javascript\" type=\"text/javascript\">" +
                            "function popUp(URL) {" +
                            "day = new Date();" +
                            "id = day.getTime();" +
                            "eval(\"page\" + id + \" = window.open(URL, '\" + id + \"', 'toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=no,width=430,height=430,left = 440,top = 312');\");" +
                            "}" +
                            "</script>");
%>
     
<%
    //récupération de la racine du site web pour la vérificaton de la présence des images :
    Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    c.Open();
    System.Data.DataSet ds = c.exeRequette("Select * from Environnement");
    c.Close();

    String racine_site = (String)ds.Tables[0].Rows[0]["Chemin_racine_site"];

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// FIN  
 
  
    //Boucle d'affichage des resultats de la recherche
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
    string path = "";
    int indexF=-1;
    int indexFin = -1;
    int indexFinEuro = -1;
    String Francs="";
    String euro = "";
    double prixFranc = 0;
      
    while ( b.MoveNext())
    {
        path = b.Current.REFERENCE.ToString();
        string srcJpg = racine_site + "images/" + path + "A.JPG";
        string sourceJpg = "../images/" + path + "A.JPG";
                
        if (System.IO.File.Exists(srcJpg) == false) sourceJpg = "../img_site/logo_320.jpg";

        if (Session["Transaction"] == "achat")
        {
            prixFranc = b.Current.PRIX_VENTE * 6.55957;
        }
        else
        {
            prixFranc = b.Current.LOYER * 6.55957;
        }
          
        Francs = prixFranc.ToString();

        if (Session["Transaction"] == "achat")
        {
            euro = b.Current.PRIX_VENTE.ToString();
        }
        else
        {
            euro = b.Current.LOYER.ToString();
        }

        indexF=Francs.IndexOf(',');
        indexFin = Francs.Length;
        indexFinEuro = euro.Length;
 
        if (indexF!=-1) Francs = Francs.Remove(indexF, indexFin-indexF);
        indexFin = Francs.Length;

        do
        {
            indexFin = indexFin - 3;
            if(indexFin>0)Francs = Francs.Insert(indexFin, " ");
        }
        while (indexFin > 0);

        do
        {
            indexFinEuro = indexFinEuro - 3;
            if (indexFinEuro>0) euro = euro.Insert(indexFinEuro, " ");
        }
        while (indexFinEuro > 0);

        Response.Write(
                    "<div class=\"Resultat-header\" >"
                        +"<div class=\"Resultat-header-prix-franc\">" 
                            + Francs + " FF" 
                        +"</div>"
            
                        + "<div class=\"Resultat-header-prix-euro\">"
                                + "<a href=\"./fichedetail1.aspx?ref=" + b.Current.REFERENCE +"&page=2 \">");
                                if (Session["Transaction"] == "achat")
                                {
                                    Response.Write(b.Current.PRIX_VENTE + " €  ");
                                }
                                else
                                {
                                    Response.Write(b.Current.LOYER + " € CC");
                                }
                                Response.Write("</a>"
                        +"</div>"

                        + "<div class=\"Resultat-header-left\">" 
                                +"<a href=\"./fichedetail1.aspx?ref=" + b.Current.REFERENCE +"&page=2 \">"
                                + b.Current.CATEGORIE+ " - "+ b.Current.NBRE_PIECE + " pièces - "+b.Current.S_HABITABLE+" m² - "+b.Current.CODE_POSTAL_BIEN+" - "+b.Current.VILLE_BIEN+"</a>"
                        +"</div>"
                    +"</div>" 

                    +"<div class=\"Resultat\">"
                        +"<div class=\"Resultat-photo\">"
                            + "<a class=\"lienImage\" href=\"./fichedetail1.aspx?ref=" + b.Current.REFERENCE + "&page=2\"> <img alt=\"photo\" src= \"" + sourceJpg + "\" width=\"128\" height=\"96\" style=\"border:none; float:left; width:128px; height:96px\" /></a>" 
                        +"</div>"   

                        +"<div class=\"Resultat-lien-droit\">"
                            + "<a href=\"./fichedetail1.aspx?ref=" + b.Current.REFERENCE + "&page=2\"><img src='../img_site/loupe.ico' border='0' width='15px' height='13px'> Consulter l'offre</a><br />"
                            + "<a href=\"./contact3.aspx?appelcontact='menu'\"><img src='../img_site/contacter.ico' border='0' width='15px' height='13px'> Contacter l'agence </a><br />"
                            + "<a href=\"javascript:popUp('sendToFriend.aspx?ref="+b.Current.REFERENCE+"')\"><img src='../img_site/courrier.jpg' border='0' width='15px' height='13px'> Envoyer à un ami </a><br />"
                            + "<a href=\"./ajoutSelection.aspx?ref=" + b.Current.REFERENCE + "\"><img src='../img_site/plus.jpg' border='0' width='15px' height='13px'> Ajouter à ma selection</a><br />"
                        +"</div>"
                            
                        +"<div class=\"Resultat-text\">"
                           + b.Current.TEXTE_INTERNET + "<br />" + "<br />" 
                           + "<STRONG>Reférence : </STRONG>" + b.Current.REFERENCE + " - tel: " + b.Current.TEL_AGENCE + "<br />" 
                           + "<STRONG>Contact : </STRONG>" + b.Current.NOM_AGENCE + " - " + b.Current.ADRESSE_AGENCE 
                           + " - " + b.Current.CODE_POSTALE_AGENCE+ "  " + b.Current.VILLE_AGENCE 
                        +"</div>"                                          
                   +"</div>"
                        );
    }
%>

<div class="ResultHaut" style="border:none">
    <div class="ResultHaut6" style="float:right; width:110px;">
        <span class="ResultHaut7"> <!--style="float:right; margin-right:2px"-->
        <% 
            Response.Write("Page " + indexPage + " sur " + nbrePage); 
        %>
        </span>
    </div>
    <div class="ResultHaut8" style="float:right; width:580px">
    <%
        //affichage des lien pour le tri
        if (biens.Count != 0)
        {
            if (ordre == "ASC")
            {
                Response.Write("<CENTER> Trier les annonces par : ");
                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=prix&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + "  \">prix</a>" + " | ");
                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=pieces&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + "  \">pieces</a>" + " | ");
                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=surface&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + "  \">surface</a>" + " | ");
                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=codepostal&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + "  \">code postal</a>" + " | ");
                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=ville&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + "  \">ville</a>" + " | ");
                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=type&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + "  \">type</a>");
                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=" + typeTri + "&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + " \"> <img border=\"0\" alt=\"Trier par ordre décroissant\" src=\"../img_site/haut.jpg\" /></a>");
            }
            if (ordre == "DESC")
            {
                Response.Write("<CENTER> Trier les annonces par : ");
                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=prix&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + "  \">prix</a>" + " | ");
                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=pieces&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + "  \">pieces</a>" + " | ");
                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=surface&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + "  \">surface</a>" + " | ");
                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=codepostal&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + "  \">code postal</a>" + " | ");
                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=ville&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + "  \">ville</a>" + " | ");
                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=type&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + "  \">type</a>");
                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=" + typeTri + "&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + " \">&nbsp<img border=\"0\" alt=\"Trier par ordre croissant\"src=\"../img_site/bas.jpg\" /></a>");
            }
            Response.Write("</CENTER>");
            Response.Write("<br/>");
        }

        //Affichage des liens de page de resultats - en haut 
        if (nbrePage > 1)
        {
            Response.Write("<center>");
            
            if (indexPage == 1) Response.Write("Page précedente << ");
            else Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + (indexPage - 1) + "&Tri=" + typeTri + "&Ordre=" + ordre + "&nbannonces=" + Session["annoncesPage"] + "\">Page Precedente << </a>");

            for (int p = 1; p < nbrePage + 1; p++)
            {
                if (p > 1)
                {
                    Response.Write(" | " + "<a href=\"./affichagerecherche.aspx?Numpage=" + p.ToString() + "&Tri=" + typeTri + "&Ordre=" + ordre + "&nbannonces=" + Session["annoncesPage"] + " \">" + ((p == indexPage) ? "<b>" : "") + p + ((p == indexPage) ? "</b>" : "") + "</a>");
                }
                else Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + p.ToString() + "&Tri=" + typeTri + "&Ordre=" + ordre + "&nbannonces=" + Session["annoncesPage"] + "\">" + ((p == indexPage) ? "<b>" : "") + p + ((p == indexPage) ? "</b>" : "") + "</a>");
            }

            if (indexPage == nbrePage) Response.Write(" >> Page Suivante");
            else Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + (indexPage + 1) + "&Tri=" + typeTri + "&Ordre=" + ordre + "&nbannonces=" + Session["annoncesPage"] + " \"> >> Page Suivante</a>");
            
            Response.Write("</center>");
        }
    %>
    </div>
    <div class="ResultHaut9" style="float:left; width:110px;"> 
        <span class="ResultHaut10" style="float:left; margin-left:2px">
            <a class="ResultHaut11" style="text-decoration:underline" href="recherche.aspx"> Retour aux critères</a> 
         </span>
    </div>
</div>
 
</asp:Content>

