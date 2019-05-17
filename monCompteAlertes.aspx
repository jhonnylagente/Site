<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="monCompteAlertes.aspx.cs" Inherits="pages_monCompteAlertes" Title="PATRIMONIUM : Mon alerte E-Mail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
<table class="moncompte">
    <tr>
        <td class="moncompteG1">
            <%--<b >Mes options</b>--%>  
        </td>
           
        <td class="moncompteD1">
            <strong>Mes alertes E-Mail</strong>
        </td>                     
    </tr>

    <tr >
        <td  class="moncompteG">
            <% Membre member = (Membre)Session["Membre"]; %>
            <!-- Menu de liens à gauche -->
            <%--<%if(member.STATUT == "ultranego" || member.STATUT == "nego" || member.STATUT == "nego_agence")
              { %>
            <!--#include file="./menumoncompte.aspx"-->
            <%} %>
            <%else
              { %>
            <!--#include file="./menumoncompte1.aspx"-->
            <%} %>  --%>    
        </td>
        <td  class="moncompteD">
        <%
            int index = 1;
            System.Collections.Generic.IList<RequeteBien> memberAlerte = MembreDAO.getAlerteMembre(member);
            System.Collections.Generic.IEnumerator<RequeteBien> b = memberAlerte.GetEnumerator();

            Response.Write("<img src='../img_site/fleche05.bmp' width='17px' height='17px'/>&nbsp&nbsp <a href='alerteMail.aspx' style='color:#CC3333;text-decoration:underline'>ajouter une alerte E-Mail</a><br/><br/>");

            Response.Write("Vous avez choisit d'être avertit pour les nouveaux biens correspondant aux critères suivants:<br/><br/>");

            while (b.MoveNext())
            {
                Response.Write("<div style=\"background-color:#F5F5F5;\">");
                Response.Write("<strong> ALERTE n°" + index + "</strong><br/>");

                if (b.Current.TYPEBIEN.Length == 1)
                {
                    if (b.Current.TYPEBIEN.Contains("M")) Response.Write("Maison ");
                    else if (b.Current.TYPEBIEN.Contains("A")) Response.Write("Appartement ");
                    else if (b.Current.TYPEBIEN.Contains("T")) Response.Write("Terrain ");
                    else if (b.Current.TYPEBIEN.Contains("X")) Response.Write("Autres ");
                }

                if (b.Current.TYPEBIEN.Length == 2)
                {
                    if (b.Current.TYPEBIEN.Contains("M") && b.Current.TYPEBIEN.Contains("A")) Response.Write("Maisons et appartements ");
                    else if (b.Current.TYPEBIEN.Contains("M") && b.Current.TYPEBIEN.Contains("T")) Response.Write("Maisons et terrains ");
                    else if (b.Current.TYPEBIEN.Contains("M") && b.Current.TYPEBIEN.Contains("X")) Response.Write("Maisons et autres ");
                    else if (b.Current.TYPEBIEN.Contains("A") && b.Current.TYPEBIEN.Contains("T")) Response.Write("Appartements et terrains ");
                    else if (b.Current.TYPEBIEN.Contains("A") && b.Current.TYPEBIEN.Contains("X")) Response.Write("Appartements et autres ");
                    else if (b.Current.TYPEBIEN.Contains("T") && b.Current.TYPEBIEN.Contains("X")) Response.Write("Terrains et autres ");
                }

                if (b.Current.TYPEBIEN.Length == 3)
                {
                    if (b.Current.TYPEBIEN.Contains("M") && b.Current.TYPEBIEN.Contains("A") && b.Current.TYPEBIEN.Contains("T")) Response.Write("Maisons, appartements et terrains ");
                    if (b.Current.TYPEBIEN.Contains("M") && b.Current.TYPEBIEN.Contains("A") && b.Current.TYPEBIEN.Contains("X")) Response.Write("Maisons, appartements et autres ");
                    if (b.Current.TYPEBIEN.Contains("A") && b.Current.TYPEBIEN.Contains("T") && b.Current.TYPEBIEN.Contains("X")) Response.Write("Appartements, terrains et autres ");
                }

                if (b.Current.TYPEBIEN.Length == 4) Response.Write("Maisons, appartements, terrains et autres ");

                if (b.Current.TYPEVENTE == "V") Response.Write("à acheter <br/>");
                else if (b.Current.TYPEVENTE == "L") Response.Write("à louer <br/>");

                if (b.Current.PRIXMIN != 0) Response.Write("Budget minimal : " + b.Current.PRIXMIN + " € <br/>");
                if (b.Current.PRIXMAX != 1000000000) Response.Write("Budget maximal : " + b.Current.PRIXMAX + " € <br/>");

                if (b.Current.SURFACEMIN != 0) Response.Write(" Surface minimale : " + b.Current.SURFACEMIN + " m² <br/>");
                if (b.Current.SURFACEMAX != 9999999) Response.Write(" Surface maximale : " + b.Current.SURFACEMAX + " m² <br/>");

                if (b.Current.TYPEBIEN.Contains("A"))
                {
                    Response.Write("Nombre de pièces pour l'appartement: ");
                    if (b.Current.PIECE1.Equals(true) && b.Current.PIECE2.Equals(false) && b.Current.PIECE3.Equals(false) && b.Current.PIECE4.Equals(false) && b.Current.PIECE5.Equals(false)) Response.Write("1");
                    if (b.Current.PIECE1.Equals(true) && b.Current.PIECE2.Equals(true) && b.Current.PIECE3.Equals(false) && b.Current.PIECE4.Equals(false) && b.Current.PIECE5.Equals(false)) Response.Write("1 et 2");
                    if (b.Current.PIECE1.Equals(true) && b.Current.PIECE2.Equals(false) && b.Current.PIECE3.Equals(true) && b.Current.PIECE4.Equals(false) && b.Current.PIECE5.Equals(false)) Response.Write("1 et 3");
                    if (b.Current.PIECE1.Equals(true) && b.Current.PIECE2.Equals(false) && b.Current.PIECE3.Equals(false) && b.Current.PIECE4.Equals(true) && b.Current.PIECE5.Equals(false)) Response.Write("1 et 4");
                    if (b.Current.PIECE1.Equals(true) && b.Current.PIECE2.Equals(false) && b.Current.PIECE3.Equals(false) && b.Current.PIECE4.Equals(false) && b.Current.PIECE5.Equals(true)) Response.Write("1 et 5");
                    if (b.Current.PIECE1.Equals(true) && b.Current.PIECE2.Equals(true) && b.Current.PIECE3.Equals(true) && b.Current.PIECE4.Equals(false) && b.Current.PIECE5.Equals(false)) Response.Write("1, 2 et 3");
                    if (b.Current.PIECE1.Equals(true) && b.Current.PIECE2.Equals(true) && b.Current.PIECE3.Equals(false) && b.Current.PIECE4.Equals(true) && b.Current.PIECE5.Equals(false)) Response.Write("1, 2 et 4");
                    if (b.Current.PIECE1.Equals(true) && b.Current.PIECE2.Equals(true) && b.Current.PIECE3.Equals(false) && b.Current.PIECE4.Equals(false) && b.Current.PIECE5.Equals(true)) Response.Write("1, 2 et 5");
                    if (b.Current.PIECE1.Equals(true) && b.Current.PIECE2.Equals(false) && b.Current.PIECE3.Equals(true) && b.Current.PIECE4.Equals(true) && b.Current.PIECE5.Equals(false)) Response.Write("1, 3 et 4");
                    if (b.Current.PIECE1.Equals(true) && b.Current.PIECE2.Equals(false) && b.Current.PIECE3.Equals(true) && b.Current.PIECE4.Equals(false) && b.Current.PIECE5.Equals(true)) Response.Write("1, 3 et 5");
                    if (b.Current.PIECE1.Equals(true) && b.Current.PIECE2.Equals(false) && b.Current.PIECE3.Equals(false) && b.Current.PIECE4.Equals(true) && b.Current.PIECE5.Equals(true)) Response.Write("1, 4 et 5");
                    if (b.Current.PIECE1.Equals(true) && b.Current.PIECE2.Equals(true) && b.Current.PIECE3.Equals(true) && b.Current.PIECE4.Equals(true) && b.Current.PIECE5.Equals(false)) Response.Write("1, 2, 3 et 4");
                    if (b.Current.PIECE1.Equals(true) && b.Current.PIECE2.Equals(true) && b.Current.PIECE3.Equals(true) && b.Current.PIECE4.Equals(false) && b.Current.PIECE5.Equals(true)) Response.Write("1, 2, 3 et 5");
                    if (b.Current.PIECE1.Equals(true) && b.Current.PIECE2.Equals(true) && b.Current.PIECE3.Equals(false) && b.Current.PIECE4.Equals(true) && b.Current.PIECE5.Equals(true)) Response.Write("1, 2, 4 et 5");
                    if (b.Current.PIECE1.Equals(true) && b.Current.PIECE2.Equals(false) && b.Current.PIECE3.Equals(true) && b.Current.PIECE4.Equals(true) && b.Current.PIECE5.Equals(true)) Response.Write("1, 3, 4 et 5");
                    if (b.Current.PIECE1.Equals(true) && b.Current.PIECE2.Equals(true) && b.Current.PIECE3.Equals(true) && b.Current.PIECE4.Equals(true) && b.Current.PIECE5.Equals(true)) Response.Write("1, 2, 3, 4 et 5");

                    if (b.Current.PIECE1.Equals(false) && b.Current.PIECE2.Equals(true) && b.Current.PIECE3.Equals(false) && b.Current.PIECE4.Equals(false) && b.Current.PIECE5.Equals(false)) Response.Write("2");
                    if (b.Current.PIECE1.Equals(false) && b.Current.PIECE2.Equals(true) && b.Current.PIECE3.Equals(true) && b.Current.PIECE4.Equals(false) && b.Current.PIECE5.Equals(false)) Response.Write("2 et 3");
                    if (b.Current.PIECE1.Equals(false) && b.Current.PIECE2.Equals(true) && b.Current.PIECE3.Equals(false) && b.Current.PIECE4.Equals(true) && b.Current.PIECE5.Equals(false)) Response.Write("2 et 4");
                    if (b.Current.PIECE1.Equals(false) && b.Current.PIECE2.Equals(true) && b.Current.PIECE3.Equals(false) && b.Current.PIECE4.Equals(false) && b.Current.PIECE5.Equals(true)) Response.Write("2 et 5");
                    if (b.Current.PIECE1.Equals(false) && b.Current.PIECE2.Equals(true) && b.Current.PIECE3.Equals(true) && b.Current.PIECE4.Equals(true) && b.Current.PIECE5.Equals(false)) Response.Write("2, 3 et 4");
                    if (b.Current.PIECE1.Equals(false) && b.Current.PIECE2.Equals(true) && b.Current.PIECE3.Equals(true) && b.Current.PIECE4.Equals(false) && b.Current.PIECE5.Equals(true)) Response.Write("2, 3 et 5");
                    if (b.Current.PIECE1.Equals(false) && b.Current.PIECE2.Equals(true) && b.Current.PIECE3.Equals(false) && b.Current.PIECE4.Equals(true) && b.Current.PIECE5.Equals(true)) Response.Write("2, 4 et 5");
                    if (b.Current.PIECE1.Equals(false) && b.Current.PIECE2.Equals(true) && b.Current.PIECE3.Equals(true) && b.Current.PIECE4.Equals(true) && b.Current.PIECE5.Equals(true)) Response.Write("2, 3, 4 et 5");

                    if (b.Current.PIECE1.Equals(false) && b.Current.PIECE2.Equals(false) && b.Current.PIECE3.Equals(true) && b.Current.PIECE4.Equals(false) && b.Current.PIECE5.Equals(false)) Response.Write("3");
                    if (b.Current.PIECE1.Equals(false) && b.Current.PIECE2.Equals(false) && b.Current.PIECE3.Equals(true) && b.Current.PIECE4.Equals(true) && b.Current.PIECE5.Equals(false)) Response.Write("3 et 4");
                    if (b.Current.PIECE1.Equals(false) && b.Current.PIECE2.Equals(false) && b.Current.PIECE3.Equals(true) && b.Current.PIECE4.Equals(false) && b.Current.PIECE5.Equals(true)) Response.Write("3 et 5");
                    if (b.Current.PIECE1.Equals(false) && b.Current.PIECE2.Equals(false) && b.Current.PIECE3.Equals(true) && b.Current.PIECE4.Equals(true) && b.Current.PIECE5.Equals(true)) Response.Write("3,4 et 5");

                    if (b.Current.PIECE1.Equals(false) && b.Current.PIECE2.Equals(false) && b.Current.PIECE3.Equals(false) && b.Current.PIECE4.Equals(true) && b.Current.PIECE5.Equals(false)) Response.Write("4");
                    if (b.Current.PIECE1.Equals(false) && b.Current.PIECE2.Equals(false) && b.Current.PIECE3.Equals(false) && b.Current.PIECE4.Equals(true) && b.Current.PIECE5.Equals(true)) Response.Write("4 et 5");

                    if (b.Current.PIECE1.Equals(false) && b.Current.PIECE2.Equals(false) && b.Current.PIECE3.Equals(false) && b.Current.PIECE4.Equals(false) && b.Current.PIECE5.Equals(true)) Response.Write("5");
                }
                
                Response.Write("<br/>");
                if (b.Current.VILLE1.Length != 0) Response.Write("Localité n°1: " + b.Current.VILLE1 + "<br/>");
                //if (b.Current.VILLE2.Length != 0) Response.Write("Localité n°2: " + b.Current.VILLE2 + "<br/>");
                //if (b.Current.VILLE3.Length != 0) Response.Write("Localité n°3: " + b.Current.VILLE3 + "<br/>");
                //if (b.Current.VILLE4.Length != 0) Response.Write("Localité n°4: " + b.Current.VILLE4 + "<br/>");

                Random r = new Random();
                double d1 = r.NextDouble();
                double d2 = r.NextDouble();

                String l1 = d1.ToString();
                String l2 = d2.ToString();

                Session["double1"] = l1;
                Session["double2"] = l2;

                int index1 = l1.IndexOf(',');
                int index2 = l2.IndexOf(',');

                l1 = l1.Substring(index1 + 2);
                l2 = l2.Substring(index2 + 2);

                Session["double1"] = l1;
                Session["double2"] = l2;

                Session["alerteMail" + index] = b.Current.ID_ALERTE;
                DateTime dateAlerte = b.Current.DateEnregistrement;
                DateTime dateValiditee = dateAlerte.AddMonths(3);
                Response.Write("Valide jusqu'au : " + dateValiditee + "<br/><br/>");
                Response.Write("<a href=\"./suppressionAlerte.aspx?ref=" + l1 + b.Current.ID_ALERTE + l2 + "\"><img src='../img_site/boutton_Supprimer.png' alt='supprimer'>Supprimer</a>");
                //Response.Write(" <a href=\"./alerteMail.aspx?ref=" + l1 + b.Current.ID_ALERTE + l2 + "\">Modifier</a>");
                Response.Write("</div><br/>");
                index++;
            }
        %>
        </td>
    </tr>
</table>
      
</asp:Content>
