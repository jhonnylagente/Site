<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="afficherLocationVentes.aspx.cs" Inherits="pages_afficherLocationVentes" Title="PATRIMONIUM: Résultat de la recherche" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">

        // <!CDATA[

        function Select1_onchange() {
            var url = window.location.href;
            var taille = url.length - 2;
            var partie1 = url.substring(0, taille);
            var temp = new Array();
            temp = partie1.split('=');
            var temp2 = temp[1].split('&');
            //Quand l'utilisateur affiche davantage d'annonces par pages, il doit être redirigé vers la première page car il se peut que celle sur laquelle il se trouve n'existe plus.
            var url_built = temp[0] + "=1" + "&" + temp2[1] + "=" + temp[2] + "=" + temp[3] + "=" + document.getElementById("Select1").value;

            window.location.href = url_built;
            //window.location.href = partie1+document.getElementById("Select1").value;

        }

    </script>
    <table>
        <tr>
            <td valign="top">
                <table>
                    <tr>
                        <td>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a href="Recherche_agent.aspx">
                                <img id="botton_votreagent" src="../img_site/image_patrimo_votreagent.jpg" alt="votreagent" /></a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a href="vendre_estimer.aspx">
                                <img id="botton_estimation" src="../img_site/image_patrimo_estimation.jpg" alt="estimation" /></a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a href="./recrutement.aspx">
                                <img id="botton_recrutement" src="../img_site/image_patrimo_recrutement.jpg" alt="recrutement" /></a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a href="recrutement_remuneration.aspx">
                                <img src="../img_site/remuneration.gif" alt="remuneration" /></a>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <!-- VERIFICATION DES PARAMETRES DE L'AFFICHAGE -->
                <% 
                    string typebien = "";
                    string nbpieces = "";
                    string surfterrain = "";
                    string typeTri = "";
                    string refer = "";
                    int var1 = 30;
                    int boole = 0;


                    Membre member = (Membre)Session["Membre"];

                    try
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
                    }
                    catch
                    {
                        boole = 1;
                        var1 = 30;

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
                    else if (Request.Params["Tri"] == "date")
                    {
                        Session["Tri"] = "date";
                    }

                    else if (Request.Params["Tri"] == "consommation")
                    {
                        Session["Tri"] = "consommation";
                    }

                    Session["NumPage"] = Request.Params["Numpage"];  
                %>
                <div class="Header-dessous">
                </div>
                <!-- VERIFICATION DU CHOIX DU CLASSEMENT DES RECHERCHES -->
                <% 
                    RequeteBien requete = (RequeteBien)Session["requete"];

                    if (Request.Params["ref"] != null)
                    {
                        requete.NEGOCIATEUR = Request.Params["ref"];
                    }
                    String ordre = Session["Ordre"].ToString();

                    System.Collections.Generic.List<Bien> biens = null;

                    switch (Session["Tri"].ToString())
                    {
                        case "date":
                            requete.REQUETE_ORDER = " ORDER BY Biens.[date modification] " + ordre;
                            break;
                        case "prix":
                            if (Session["Transaction"].ToString() == "achat")
                            {
                                requete.REQUETE_ORDER = " ORDER BY Biens.[prix de vente]" + ordre;
                            }
                            else requete.REQUETE_ORDER = " ORDER BY Biens.[loyer_cc]" + ordre;
                            break;
                        case "pieces":
                            requete.REQUETE_ORDER = " ORDER BY Biens.[nombre de pieces]" + ordre;
                            break;
                        case "surface":
                            requete.REQUETE_ORDER = " ORDER BY Biens.[surface habitable]" + ordre;
                            break;
                        case "codepostal":
                            requete.REQUETE_ORDER = " ORDER BY Biens.[code postal du bien]" + ordre;
                            break;
                        case "ville":
                            requete.REQUETE_ORDER = " ORDER BY Biens.[ville du bien]" + ordre;
                            break;
                        case "type":
                            requete.REQUETE_ORDER = " ORDER BY Biens.[type de bien] " + ordre;
                            break;
                        case "consommation":
                            requete.REQUETE_ORDER = " ORDER BY Biens.[nombre_conso] " + ordre;
                            break;
                        case "emission":
                            requete.REQUETE_ORDER = " ORDER BY Biens.[nombre_energie] " + ordre;
                            break;
                    }

                    if (requete != null)
                    {
                        //biens = BienDAO.getAllBiens("SELECT  * FROM Biens;");
                        biens = BienDAO.getAllBiens(requete.REQUETE_SQL_Recherche);
                        //Response.Write("requete = " + requete.REQUETE_SQL_Recherche);
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

                    typeTri = Session["Tri"].ToString();
                    int indexPage = 0;
                    if (Session["NumPage"] == null)
                    {
                        indexPage = 1;
                    }
                    else
                    {
                        indexPage = Int32.Parse(Session["NumPage"].ToString()); //index de la page utilisateur
                    }

                    if (j % var1 != 0) { nbrePage = (j / var1) + 1; }
                    else { nbrePage = (j / var1); }
                %>
                <!-- CHOIX ORDRE DE LA RECHERCHE -->
                <div class="ResultHaut">
                    <div class="ResultHaut2">
                        <table class="tableafficherecherche" width="100%" border="0">
                            <tr>
                                <td colspan="2">
                                    <%
                                        if (biens.Count != 0)
                                        {
                                            if (ordre == "ASC")
                                            {
                                                Response.Write("<CENTER> Trier les annonces par : <strong>" + Session["Tri"].ToString() + "</strong>&nbsp;&nbsp;");

                                                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=prix&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + " \">prix</a>" + " | ");
                                                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=pieces&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + " \">pièces</a>" + " | ");
                                                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=surface&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + " \">surface</a>" + " | ");
                                                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=codepostal&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + " \">code postal</a>" + " | ");
                                                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=ville&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + " \">ville</a>" + " | ");
                                                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=consommation&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + " \">consommation</a>" + " | ");
                                                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=emission&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + " \">émissions</a>" + " | ");
                                                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=date&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + " \">date</a>" + " | ");
                                                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=type&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + " \">type</a>");
                                                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=" + typeTri + "&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + " \"> <img border=\"0\" src=\"../img_site/haut.jpg\" /></a>");
                                            }
                                            if (ordre == "DESC")
                                            {
                                                Response.Write("<CENTER> Trier les annonces par : " + Session["Tri"].ToString() + "</strong>&nbsp;&nbsp;");

                                                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=prix&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + " \">prix</a>" + " | ");
                                                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=pieces&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + " \">pièces</a>" + " | ");
                                                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=surface&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + " \">surface</a>" + " | ");
                                                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=codepostal&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + " \">code postal</a>" + " | ");
                                                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=ville&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + " \">ville</a>" + " | ");
                                                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=consommation&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + " \">consommation</a>" + " | ");
                                                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=emission&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + " \">émissions</a>" + " | ");
                                                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=date&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + " \">date</a>" + " | ");
                                                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=type&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + " \">type</a>");
                                                Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=" + typeTri + "&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + " \"> <img border=\"0\" src=\"../img_site/bas.jpg\" /></a>");
                                            }
                                            Response.Write("</CENTER>");
                                        }
                                        else
                                        {%>
                                    <div style="font-size: 15px; color: #CC3333; font-weight: bold">
                                        Aucun bien ne correspond aux critères sélectionnés
                                    </div>
                                    <% } %>
                                </td>
                            </tr>
                            <tr>
                                <td width="33%">
                                    <a style="text-decoration: underline" href="recherche.aspx">Retour aux critères<br />
                                        <img alt="retour" height="65" src="../img_site/milou.jpg" width="65" /></a>
                                </td>
                                <td class="annoncesparpage">
                                    Annonces par page
                                    <%
                                        if (boole != 1)
                                        {
                                            object nbannonces = Session["annoncesPage"]; 
                                    %>
                                    <select name="choix_nbpages" size="1" onchange="Select1_onchange()" id="Select1"
                                        onclick="return Select1_onclick()">
                                        <option value="10" <%if(var1==10){Response.Write("selected");}%>>10</option>
                                        <option value="20" <%if(var1==20){Response.Write("selected");}%>>20</option>
                                        <option value="30" <%if(var1==30){Response.Write("selected");}%>>30</option>
                                        <option value="50" <%if(var1==50){Response.Write("selected");}%>>50</option>
                                    </select>
                                    <%
                                        }
                                    %>
                                </td>
                            </tr>
                            <font color="red" size="4">
                                <asp:Label ID="LabelErrorLogin" runat="server" Font-Bold="True" ForeColor="#CC3333"
                                    Visible="false" Width="350px"></asp:Label>
                            </font>
                        </table>
                    </div>
                    <br />
                    <!--<div style="width:801px;height:12px;border:1px">-->
                    <table border="0" width="100%">
                        <tr>
                            <td width="14%">
                                &nbsp;<br />
                            </td>
                            <td width="72%">
                                <font size="2">
                                    <% 
                                        if (nbrePage > 1)
                                        {
                                            Response.Write("<center>");
                                            if (indexPage == 1) Response.Write("<a href=\"#\">Page pr&eacute;c&eacute;dente &lt;&lt; </a>");
                                            else Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + (indexPage - 1) + "&Tri=" + typeTri + "&Ordre=" + ordre + "&nbannonces=" + Session["annoncesPage"] + "\">Page Pr&eacute;c&eacute;dente &lt;&lt; </a>");

                                            for (int p = 1; p < nbrePage + 1; p++)
                                            {
                                                if (p > 1)
                                                {
                                                    Response.Write(" | " + "<a href=\"./affichagerecherche.aspx?Numpage=" + p.ToString() + "&Tri=" + typeTri + "&Ordre=" + ordre + "&nbannonces=" + Session["annoncesPage"] + "\">" + ((p == indexPage) ? "<b>" : "") + p + ((p == indexPage) ? "</b>" : "") + "</a>");
                                                }
                                                else Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + p.ToString() + "&Tri=" + typeTri + "&Ordre=" + ordre + "&nbannonces=" + Session["annoncesPage"] + "\">" + ((p == indexPage) ? "<b>" : "") + p + ((p == indexPage) ? "</b>" : "") + "</a>");
                                            }

                                            if (indexPage == nbrePage) Response.Write("<a href=\"#\"> &gt;&gt; Page Suivante");
                                            else Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + (indexPage + 1) + "&Tri=" + typeTri + "&Ordre=" + ordre + "&nbannonces=" + Session["annoncesPage"] + "\"> &gt;&gt; Page Suivante</a>");

                                            Response.Write("</center>");
                                        }        
                                    %>
                                </font>
                            </td>
                            <td width="14%">
                                <p align="right">
                                    <br />
                                    <% 
                                        Response.Write("Page " + indexPage + " sur " + nbrePage); 
                                    %></p>
                            </td>
                        </tr>
                    </table>
                </div>

                <fieldset class="fieldsetMail">
                    <table style="width: 100%">
                        <tr>
                            <td>
                                <img id="Img1" src="../img_site/courrier.jpg" alt="courrier" />
                                <strong>Créer une alerte e-mail :</strong>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxMail" runat="server" Style="width: 300px"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Button ID="ButtonMail" runat="server" Text="Valider" CssClass="myButton" Style="width: 118px"
                                    OnClick="ButtonMail_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>

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
                    int indexF = -1;
                    int indexFin = -1;
                    int indexFinEuro = -1;
                    String Francs = "";
                    String euro = "";
                    double prixFranc = 0;
                    DateTime dateModNouveaute;

                    while (b.MoveNext())
                    {
                        path = b.Current.REFERENCE.ToString();
                        string srcJpg = racine_site + "images/" + path + "A.JPG";
                        string sourceJpg = "../images/" + path + "A.JPG";
                        string sourcePngHover = "../img_site/band_CdC_Lux/";
                        string sourceImg_site = "../img_site/";

                        if (System.IO.File.Exists(srcJpg) == false) sourceJpg = "../img_site/logo_320.jpg";

                        if (Session["Transaction"].ToString() == "achat")
                        {
                            prixFranc = b.Current.PRIX_VENTE * 6.55957;
                        }
                        else
                        {
                            prixFranc = b.Current.LOYER * 6.55957;
                        }

                        Francs = prixFranc.ToString();

                        if (Session["Transaction"].ToString() == "achat")
                        {
                            euro = b.Current.PRIX_VENTE.ToString();
                        }
                        else
                        {
                            euro = b.Current.LOYER.ToString();
                        }

                        indexF = Francs.IndexOf(',');
                        indexFin = Francs.Length;
                        indexFinEuro = euro.Length;

                        if (indexF != -1) Francs = Francs.Remove(indexF, indexFin - indexF);
                        indexFin = Francs.Length;

                        do
                        {
                            indexFin = indexFin - 3;
                            if (indexFin > 0) Francs = Francs.Insert(indexFin, " ");
                        }
                        while (indexFin > 0);

                        do
                        {
                            indexFinEuro = indexFinEuro - 3;
                            if (indexFinEuro > 0) euro = euro.Insert(indexFinEuro, " ");
                        }
                        while (indexFinEuro > 0);

                        if (b.Current.CATEGORIE == "")
                        {
                            if (b.Current.TYPE_BIEN == "A") typebien = "Appartement";
                            if (b.Current.TYPE_BIEN == "M") typebien = "Maison";
                            if (b.Current.TYPE_BIEN == "T") typebien = "Terrain";
                            if (b.Current.TYPE_BIEN == "L") typebien = "Local";
                        }
                        else
                        {
                            typebien = b.Current.CATEGORIE.ToString();
                        }


                        Response.Write(
                                    "<div class=\"Resultat-header\" >"
                            //+"<div class=\"Resultat-header-prix-franc\">" 
                            //    + Francs + " FF" 
                            //+"</div>"
                                        + "<div class=\"Resultat-header-prix-euro\">"
                                                + "<a href=\"./fichedetail1.aspx?ref=" + b.Current.REFERENCE + "&page=2 \">");
                        if (Session["Transaction"].ToString() == "achat")
                        {
                            Response.Write(b.Current.PRIX_VENTE + " &#8364;  ");
                        }
                        else
                        {

                            path = b.Current.REFERENCE.ToString();

                            String requette = "SELECT Biens.* FROM Biens WHERE (((Biens.ref)='" + b.Current.REFERENCE.ToString() + "'));";
                            System.Data.DataSet ds1 = null;
                            Connexion c1 = null;

                            c1 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                            c1.Open();
                            ds1 = c1.exeRequette(requette);
                            c1.Close();
                            c1 = null;

                            System.Data.DataRowCollection dr1 = ds1.Tables[0].Rows;
                            foreach (System.Data.DataRow ligne in dr1)
                            {
                                Response.Write(ligne["loyer_cc"].ToString() + " &#8364; CC");
                            }
                        }

                        if (b.Current.TYPE_BIEN == "T" || b.Current.TYPE_BIEN == "L")
                        {
                            if (b.Current.NBRE_PIECE == 0)
                            {
                                nbpieces = "";
                            }

                            String requette = "SELECT Biens.* FROM Biens WHERE (((Biens.ref)='" + b.Current.REFERENCE.ToString() + "'));";
                            System.Data.DataSet ds1 = null;
                            Connexion c1 = null;

                            c1 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                            c1.Open();
                            ds1 = c1.exeRequette(requette);
                            c1.Close();
                            c1 = null;

                            System.Data.DataRowCollection dr1 = ds1.Tables[0].Rows;
                            foreach (System.Data.DataRow ligne in dr1)
                            {
                                surfterrain = ligne["surface terrain"].ToString();
                            }

                            if (surfterrain != "")
                            {
                                surfterrain += " m² - ";
                            }
                        }
                        else
                        {
                            if (b.Current.NBRE_PIECE != 0)
                            {
                                nbpieces = b.Current.NBRE_PIECE + " pièces - ";
                            }
                            if (b.Current.S_HABITABLE != 0)
                            {
                                surfterrain = b.Current.S_HABITABLE + " m² - ";
                            }
                        }



                        Response.Write("</a>"
                + "</div>");

                        int nbJourNv = -15;
                        DateTime today = DateTime.Now;
                        int year = today.Year;
                        int month = today.Month;
                        int day = today.Day;
                        int tmp = 0;

                        DateTime todayMoinsJourNv = today.AddDays(nbJourNv);


                        Response.Write(
                        "<div class=\"Resultat-header-left\">"
                                + "<a href=\"./fichedetail1.aspx?ref=" + b.Current.REFERENCE + "&page=2 \">"
                                + typebien + " - " + nbpieces + surfterrain + b.Current.CODE_POSTAL_BIEN + " - " + b.Current.VILLE_BIEN);
                        Response.Write("</a>"
                        + "</div>");

                        Response.Write(
                                "</div>"
                                    + "<div class=\"Resultat\">"
                                        + "<div class=\"Resultat-photo\">"
                                            + "<a class=\"lienImage\" href=\"./fichedetail1.aspx?ref=" + b.Current.REFERENCE + "&page=2\"> ");
                        if (System.IO.File.Exists(srcJpg) == false)
                        {
                            sourceJpg = "../img_site/images_par_defaut/" + b.Current.TYPE_BIEN + ".jpg";
                        }

                        if (b.Current.TYPE_MANDAT != "SemiExclusif" && b.Current.TYPE_MANDAT != "Exclusif" && b.Current.DATE_MODIFICATION < todayMoinsJourNv && !b.Current.COUP_DE_COEUR && !b.Current.PRESTIGE)
                        {
                            Response.Write(
                                                "<img alt=\"photo\" src= \"" + sourceJpg + "\" width=\"128\" height=\"96\" "
                                                + "style=\"border:none; float:left; width:128px; height:96px\" />");
                        }
                        else
                        {
                            Response.Write(
                                                "<input type=\"image\" alt=\"photo\" src= \"" + sourceJpg + "\" width=\"128\" height=\"96\" "
                                                + "style=\"border:none; width:128px; height:96px\" >"
                                                    + "<img alt=\"photo\" src= \"");
                            string nomImg = "";
                            if (b.Current.TYPE_MANDAT == "Exclusif")
                            {
                                nomImg += "Exc";
                            }
                            else if (b.Current.TYPE_MANDAT == "SemiExclusif")
                            {
                                nomImg += "Sexc";
                            }
                            else if (b.Current.DATE_MODIFICATION >= todayMoinsJourNv)
                            {
                                nomImg += "Nv";
                            }
                            if (b.Current.COUP_DE_COEUR)
                            {
                                nomImg += "CdC";
                            }
                            if (b.Current.PRESTIGE)
                            {
                                nomImg += "Lux";
                            }
                            nomImg += ".png";
                            Response.Write(sourcePngHover + nomImg);
                            Response.Write(
                                                            "\" width=\"128\" height=\"96\" "
                                                            + "style=\"border:none; position:relative; bottom:96px; height:96px width:128px\" class=\"imgBandeau\" />"
                                                        + "</input>");
                        }

                        Response.Write(
                                        "</a>"
                                    + "</div>");

                        Response.Write(
                                    "<div class=\"Resultat-lien-droit\">"
                                        + "<a href=\"./fichedetail1.aspx?ref=" + b.Current.REFERENCE + "&page=2\"><img src='../img_site/loupe.ico' border='0' width='15px' height='13px'> Consulter l'offre</a><br />"
                                        + "<a href=\"./contact3.aspx?appelcontact='menu'\"><img src='../img_site/contacter.ico' border='0' width='15px' height='13px'> Contacter l'agence </a><br />"
                                        + "<a href=\"javascript:popUp('sendToFriend.aspx?ref=" + b.Current.REFERENCE + "')\"><img src='../img_site/courrier.jpg' border='0' width='15px' height='13px'> Envoyer à un ami </a><br />"
                                        + "<a href=\"./ajoutSelection.aspx?ref=" + b.Current.REFERENCE + "\"><img src='../img_site/plus.jpg' border='0' width='15px' height='13px'> Ajouter à ma selection</a><br />");

                        refer = b.Current.REFERENCE;

                        if (Session["Membre"] != null)
                        {
                            if (refer.Contains("L") && (member.STATUT == "ultranego" || (member.STATUT == "nego" && b.Current.NEGOCIATEUR == member.PRENOM + " " + member.NOM)))
                            {
                                Response.Write("<a href=\"./modifier_nego_loc.aspx?reference=" + b.Current.REFERENCE + "\"><img src='../img_site/calepin3.gif' border='0' width='15px' height='13px'> modifier le bien</a><br />");
                            }
                            if (refer.Contains("V") && (member.STATUT == "ultranego" || (member.STATUT == "nego" && b.Current.NEGOCIATEUR == member.PRENOM + " " + member.NOM)))
                            {
                                Response.Write("<a href=\"./modifier_nego.aspx?reference=" + b.Current.REFERENCE + "\"><img src='../img_site/calepin3.gif' border='0' width='15px' height='13px'> modifier le bien</a><br />");
                            }
                        }
                        if (b.Current.LETTRE_CONSO != "") { Response.Write("<img class=dpe_petit src=\"../img_dpe/high_quality/dpe/dpe_ic.gif\"/>"); }
                        if (b.Current.NOMBRE_CONSO != 0) { Response.Write(" " + b.Current.NOMBRE_CONSO + " "); }
                        if (b.Current.LETTRE_ENERGIE != "") { Response.Write("<img class=dpe_petit src=\"../img_dpe/high_quality/ges/ges_ic.gif\"/>"); }
                        if (b.Current.NOMBRE_ENERGIE != 0) { Response.Write(" " + b.Current.NOMBRE_ENERGIE); }

                        Response.Write("</div>");

                        Response.Write("<div class=\"Resultat-text\">");

                        if (b.Current.COUP_DE_COEUR && b.Current.PRESTIGE)
                        {
                            Response.Write("<img class=\"cdcPrestige\" src=\"" + sourcePngHover + "Trigl_cdcPrestige.png\" alt=\"Coup de Coeur et Prestige\"/>");
                        }
                        else if (b.Current.COUP_DE_COEUR)
                        {
                            Response.Write("<img class=\"cdcPrestige\" src=\"" + sourcePngHover + "Trigl_coupDeCoeur.png\" alt=\"Coup de Coeur\"/>");
                        }
                        else if (b.Current.PRESTIGE)
                        {
                            Response.Write("<img class=\"cdcPrestige\" src=\"" + sourcePngHover + "Trigl_prestige.png\" alt=\"Prestige\"/>");
                        }

                        if (b.Current.NEUF)
                        {
                            Response.Write("<img class=\"gifNeuf\" src=\"" + sourceImg_site + "Neuf.gif\" alt=\"PRIX EN BAISSE\"/><br/>");
                        }
                        if (b.Current.ANCIEN_PRIX > b.Current.PRIX_VENTE && b.Current.ANCIEN_PRIX != 0)
                        {
                            Response.Write("<img class=\"gifPrixEnBaisse\" src=\"" + sourceImg_site + "prixEnBaisse.gif\" alt=\"PRIX EN BAISSE\"/><br/>");
                        }

                        Response.Write(b.Current.TEXTE_INTERNET + "<br />");

                        if (b.Current.NEGOCIATEUR != "")
                        {
                            //Si l'annonce a été envoyée par un nego, on récupère dans la table Clients les coordonnées de ce nego.   
                            int idclient = b.Current.IDCLIENT;
                            String requette = "select nom_client, prenom_client, tel_client, id_client from Clients where `idclient`=" + idclient;
                            System.Data.DataSet ds2 = null;

                            Connexion c2 = null;

                            c2 = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                            c2.Open();
                            ds2 = c2.exeRequette(requette);
                            c2.Close();
                            c2 = null;

                            System.Data.DataRowCollection dr2 = ds2.Tables[0].Rows;

                            foreach (System.Data.DataRow ligne in dr2)
                            {
                                Response.Write("<STRONG>Reférence : </STRONG>" + b.Current.REFERENCE + " - tel: "
                                                                               + ligne["tel_client"].ToString() + "<br />");
                                Response.Write("<STRONG>Contact : </STRONG>" + ligne["nom_client"] + " " + ligne["prenom_client"] + " - "
                                               + "<A HREF=mailto:" + ligne["id_client"].ToString() + ">" + ligne["id_client"].ToString() + "</A>" + "<br />");
                            }
                        }
                        else if (b.Current.NUM_AGENCE != "")
                        {
                            Response.Write("<STRONG>Reférence : </STRONG>" + b.Current.REFERENCE + " - tel: " + b.Current.TEL_AGENCE + "<br />"
                            + "<STRONG>Contact : </STRONG>" + b.Current.NOM_AGENCE + " - " + b.Current.ADRESSE_AGENCE);
                            Response.Write(" - " + b.Current.CODE_POSTALE_AGENCE + "  " + b.Current.VILLE_AGENCE);
                        }


                        Response.Write("</div>");
                        /*
                       if (b.Current.COUP_DE_COEUR && b.Current.PRESTIGE)
                       {
                           Response.Write("<img src=\"" + sourcePngHover + "Trigl_cdcPrestige.png\" alt=\"Coup de Coeur et Prestige\"/>");
                       }
                       else if (b.Current.COUP_DE_COEUR)
                       {
                           Response.Write("<div class=\"Trigl_cdcPrestige\">"
                               + "<img src=\"" + sourcePngHover + "Trigl_coupDeCoeur.png\" alt=\"Coup de Coeur\"/>");
                           Response.Write("</div>");
                       }
                       else if (b.Current.PRESTIGE)
                       {
                           Response.Write("<div class=\"Trigl_cdcPrestige\">"
                               + "<img src=\"" + sourcePngHover + "Trigl_prestige.png\" alt=\"Prestige\"/>");
                           Response.Write("</div>");
                       }*/

                        Response.Write("</div>");
                    }
                %>
                <br />
                <fieldset class="fieldsetMail">
                    <table style="width: 100%">
                        <tr>
                            <td>
                                <strong>Créer une alerte e-mail :</strong>
                            </td>
                            <td>
                                <img id="Img2" src="../img_site/courrier.jpg" alt="courrier" />
                                <asp:TextBox ID="TextBoxMail2" runat="server" Style="width: 300px"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Button ID="ButtonMail2" runat="server" Text="Valider" CssClass="myButton" Style="width: 118px"
                                    OnClick="ButtonMail_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>

                <div class="ResultHaut">
                    <table border="0" width="100%">
                        <tr>
                            <td colspan="3">
                                <%
                                    //affichage des lien pour le tri
                                    if (biens.Count != 0)
                                    {
                                        if (ordre == "ASC")
                                        {
                                            Response.Write("<CENTER> Trier les annonces par : ");
                                            Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=prix&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + "  \">prix</a>" + " | ");
                                            Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=pieces&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + "  \">pièces</a>" + " | ");
                                            Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=surface&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + "  \">surface</a>" + " | ");
                                            Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=codepostal&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + "  \">code postal</a>" + " | ");
                                            Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=ville&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + "  \">ville</a>" + " | ");
                                            Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=consommation&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + "  \">consommation</a>" + " | ");
                                            Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=emission&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + "  \">émissions</a>" + " | ");
                                            Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=date&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + "  \">date</a>" + " | ");
                                            Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=type&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + "  \">type</a>");
                                            Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=" + typeTri + "&Ordre=DESC&nbannonces=" + Session["annoncesPage"] + " \"> <img border=\"0\" alt=\"Trier par ordre décroissant\" src=\"../img_site/haut.jpg\" /></a>");
                                        }
                                        if (ordre == "DESC")
                                        {
                                            Response.Write("<CENTER> Trier les annonces par : ");
                                            Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=prix&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + "  \">prix</a>" + " | ");
                                            Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=pieces&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + "  \">pièces</a>" + " | ");
                                            Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=surface&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + "  \">surface</a>" + " | ");
                                            Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=codepostal&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + "  \">code postal</a>" + " | ");
                                            Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=ville&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + "  \">ville</a>" + " | ");
                                            Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=consommation&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + "  \">consommation</a>" + " | ");
                                            Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=emission&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + "  \">émission</a>" + " | ");
                                            Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=date&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + "  \">date</a>" + " | ");
                                            Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=type&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + "  \">type</a>");
                                            Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + indexPage + "&Tri=" + typeTri + "&Ordre=ASC&nbannonces=" + Session["annoncesPage"] + " \">&nbsp<img border=\"0\" alt=\"Trier par ordre croissant\"src=\"../img_site/bas.jpg\" /></a>");
                                        }
                                        Response.Write("</CENTER>");
                                    }%>
                            </td>
                        </tr>
                        <tr>
                            <td width="33%">
                                <a href="recherche.aspx">Retour aux critères<br />
                                    <img alt="retour" height="65" src="../img_site/milou.jpg" width="65" /></a>
                            </td>
                            <td width="33%">
                            </td>
                            <td width="33%">
                                <p align="right">
                                    <% Response.Write("Page " + indexPage + " sur " + nbrePage); %>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" colspan="3">
                                <font size="2">
                                    <%

                                        //Affichage des liens de page de resultats - en haut 
                                        if (nbrePage > 1)
                                        {
                                            Response.Write("<center>");

                                            if (indexPage == 1) Response.Write("<a href=\"#\">Page pr&eacute;c&eacute;dente &lt;&lt; </a>");
                                            else Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + (indexPage - 1) + "&Tri=" + typeTri + "&Ordre=" + ordre + "&nbannonces=" + Session["annoncesPage"] + "\">Page Pr&eacute;c&eacute;dente &lt;&lt; </a>");

                                            for (int p = 1; p < nbrePage + 1; p++)
                                            {
                                                if (p > 1)
                                                {
                                                    Response.Write(" | " + "<a href=\"./affichagerecherche.aspx?Numpage=" + p.ToString() + "&Tri=" + typeTri + "&Ordre=" + ordre + "&nbannonces=" + Session["annoncesPage"] + " \">" + ((p == indexPage) ? "<b>" : "") + p + ((p == indexPage) ? "</b>" : "") + "</a>");
                                                }
                                                else Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + p.ToString() + "&Tri=" + typeTri + "&Ordre=" + ordre + "&nbannonces=" + Session["annoncesPage"] + "\">" + ((p == indexPage) ? "<b>" : "") + p + ((p == indexPage) ? "</b>" : "") + "</a>");
                                            }

                                            if (indexPage == nbrePage) Response.Write("<a href=\"#\"> &gt;&gt; Page Suivante");
                                            else Response.Write("<a href=\"./affichagerecherche.aspx?Numpage=" + (indexPage + 1) + "&Tri=" + typeTri + "&Ordre=" + ordre + "&nbannonces=" + Session["annoncesPage"] + "\"> &gt;&gt; Page Suivante</a>");

                                            Response.Write("</center>");
                                        }
                                    %>
                                </font>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>