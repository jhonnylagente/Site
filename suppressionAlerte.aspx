<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="suppressionAlerte.aspx.cs" Inherits="pages_suppressionAlerte" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<table border="0" cellpadding="10px" cellspacing="10px">
    <tr>
        <td>
            <table>
                <tr>
                    <td style="width: 1103px;text-align:center">
                        <span style="color:#31536c"><strong>Suppression alerte E-Mail</strong></span>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

<table border="1" cellpadding="10px" cellspacing="10px" align="center">
    <tr style="margin-left:5px;" valign="top" >
        <td  valign="top" style="border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
            <span style="color:#CC3333">Voulez-vous vraiment supprimer cette alerte E-Mail ?</span><br /><br />
                       
            <%
                Response.Write("<div style=\"background-color:#F5F5F5;\">");

                Int32 reference = new Int32();
                
                    reference = Int32.Parse(Session["referenceAlerteMail"].ToString());
                
                Membre member = (Membre)Session["membre"];
                RequeteBien b = AlerteMailDAO.getAlerteMail(reference);
                
                if(b.TYPEBIEN.Length==1)
                {
                    if (b.TYPEBIEN.Contains("M")) Response.Write("Maison");
                    else if(b.TYPEBIEN.Contains("A")) Response.Write("Appartement");
                    else if (b.TYPEBIEN.Contains("T"))Response.Write("Terrain");
                }
                
                if(b.TYPEBIEN.Length==2)
                {
                    if (b.TYPEBIEN.Contains("M") && b.TYPEBIEN.Contains("A")) Response.Write("Maisons et appartements ");
                    else if (b.TYPEBIEN.Contains("M") && b.TYPEBIEN.Contains("T")) Response.Write("Maisons et terrains ");
                    else if (b.TYPEBIEN.Contains("M") && b.TYPEBIEN.Contains("X")) Response.Write("Maisons et autres ");
                    else if (b.TYPEBIEN.Contains("A") && b.TYPEBIEN.Contains("T")) Response.Write("Appartements et terrains ");
                    else if (b.TYPEBIEN.Contains("A") && b.TYPEBIEN.Contains("X")) Response.Write("Appartements et autres ");
                    else if (b.TYPEBIEN.Contains("T") && b.TYPEBIEN.Contains("X")) Response.Write("Terrains et autres ");      
                }

                if (b.TYPEBIEN.Length == 3)
                {
                    if (b.TYPEBIEN.Contains("M") && b.TYPEBIEN.Contains("A") && b.TYPEBIEN.Contains("T")) Response.Write("Maisons, appartements et terrains ");
                    if (b.TYPEBIEN.Contains("M") && b.TYPEBIEN.Contains("A") && b.TYPEBIEN.Contains("X")) Response.Write("Maisons, appartements et autres ");
                    if (b.TYPEBIEN.Contains("A") && b.TYPEBIEN.Contains("T") && b.TYPEBIEN.Contains("X")) Response.Write("Appartements, terrains et autres ");
                }
                
                if (b.TYPEBIEN.Length == 4) Response.Write("Maisons, appartements, terrains et autres ");
                
                if (b.TYPEVENTE == "V") Response.Write("à acheter <br/>");
                else if (b.TYPEVENTE == "L") Response.Write("à louer <br/>");

                if (b.PRIXMIN != 0) Response.Write("Budget minimal : " + b.PRIXMIN+" € ");
                if (b.PRIXMAX != 1000000000) Response.Write("Budget maximal : " + b.PRIXMAX + " € <br/>");

                if (b.SURFACEMIN != 0) Response.Write(" Surface minimale : " + b.SURFACEMIN+" m² ");
                if (b.SURFACEMAX != 9999999) Response.Write(" Surface maximale : " + b.SURFACEMAX+" m² <br/>");

                if (b.TYPEBIEN.Contains("A"))
                {
                    Response.Write("Nombre de pièces pour l'appartement: ");
                    if (b.PIECE1.Equals(true) && b.PIECE2.Equals(false) && b.PIECE3.Equals(false) && b.PIECE4.Equals(false) && b.PIECE5.Equals(false)) Response.Write("1");
                    if (b.PIECE1.Equals(true) && b.PIECE2.Equals(true) && b.PIECE3.Equals(false) && b.PIECE4.Equals(false) && b.PIECE5.Equals(false)) Response.Write("1 et 2");
                    if (b.PIECE1.Equals(true) && b.PIECE2.Equals(false) && b.PIECE3.Equals(true) && b.PIECE4.Equals(false) && b.PIECE5.Equals(false)) Response.Write("1 et 3");
                    if (b.PIECE1.Equals(true) && b.PIECE2.Equals(false) && b.PIECE3.Equals(false) && b.PIECE4.Equals(true) && b.PIECE5.Equals(false)) Response.Write("1 et 4");
                    if (b.PIECE1.Equals(true) && b.PIECE2.Equals(false) && b.PIECE3.Equals(false) && b.PIECE4.Equals(false) && b.PIECE5.Equals(true)) Response.Write("1 et 5");
                    if (b.PIECE1.Equals(true) && b.PIECE2.Equals(true) && b.PIECE3.Equals(true) && b.PIECE4.Equals(false) && b.PIECE5.Equals(false)) Response.Write("1, 2 et 3");
                    if (b.PIECE1.Equals(true) && b.PIECE2.Equals(true) && b.PIECE3.Equals(false) && b.PIECE4.Equals(true) && b.PIECE5.Equals(false)) Response.Write("1, 2 et 4");
                    if (b.PIECE1.Equals(true) && b.PIECE2.Equals(true) && b.PIECE3.Equals(false) && b.PIECE4.Equals(false) && b.PIECE5.Equals(true)) Response.Write("1, 2 et 5");
                    if (b.PIECE1.Equals(true) && b.PIECE2.Equals(false) && b.PIECE3.Equals(true) && b.PIECE4.Equals(true) && b.PIECE5.Equals(false)) Response.Write("1, 3 et 4");
                    if (b.PIECE1.Equals(true) && b.PIECE2.Equals(false) && b.PIECE3.Equals(true) && b.PIECE4.Equals(false) && b.PIECE5.Equals(true)) Response.Write("1, 3 et 5");
                    if (b.PIECE1.Equals(true) && b.PIECE2.Equals(false) && b.PIECE3.Equals(false) && b.PIECE4.Equals(true) && b.PIECE5.Equals(true)) Response.Write("1, 4 et 5");
                    if (b.PIECE1.Equals(true) && b.PIECE2.Equals(true) && b.PIECE3.Equals(true) && b.PIECE4.Equals(true) && b.PIECE5.Equals(false)) Response.Write("1, 2, 3 et 4");
                    if (b.PIECE1.Equals(true) && b.PIECE2.Equals(true) && b.PIECE3.Equals(true) && b.PIECE4.Equals(false) && b.PIECE5.Equals(true)) Response.Write("1, 2, 3 et 5");
                    if (b.PIECE1.Equals(true) && b.PIECE2.Equals(true) && b.PIECE3.Equals(false) && b.PIECE4.Equals(true) && b.PIECE5.Equals(true)) Response.Write("1, 2, 4 et 5");
                    if (b.PIECE1.Equals(true) && b.PIECE2.Equals(false) && b.PIECE3.Equals(true) && b.PIECE4.Equals(true) && b.PIECE5.Equals(true)) Response.Write("1, 3, 4 et 5");
                    if (b.PIECE1.Equals(true) && b.PIECE2.Equals(true) && b.PIECE3.Equals(true) && b.PIECE4.Equals(true) && b.PIECE5.Equals(true)) Response.Write("1, 2, 3, 4 et 5");

                    if (b.PIECE1.Equals(false) && b.PIECE2.Equals(true) && b.PIECE3.Equals(false) && b.PIECE4.Equals(false) && b.PIECE5.Equals(false)) Response.Write("2");
                    if (b.PIECE1.Equals(false) && b.PIECE2.Equals(true) && b.PIECE3.Equals(true) && b.PIECE4.Equals(false) && b.PIECE5.Equals(false)) Response.Write("2 et 3");
                    if (b.PIECE1.Equals(false) && b.PIECE2.Equals(true) && b.PIECE3.Equals(false) && b.PIECE4.Equals(true) && b.PIECE5.Equals(false)) Response.Write("2 et 4");
                    if (b.PIECE1.Equals(false) && b.PIECE2.Equals(true) && b.PIECE3.Equals(false) && b.PIECE4.Equals(false) && b.PIECE5.Equals(true)) Response.Write("2 et 5");
                    if (b.PIECE1.Equals(false) && b.PIECE2.Equals(true) && b.PIECE3.Equals(true) && b.PIECE4.Equals(true) && b.PIECE5.Equals(false)) Response.Write("2, 3 et 4");
                    if (b.PIECE1.Equals(false) && b.PIECE2.Equals(true) && b.PIECE3.Equals(true) && b.PIECE4.Equals(false) && b.PIECE5.Equals(true)) Response.Write("2, 3 et 5");
                    if (b.PIECE1.Equals(false) && b.PIECE2.Equals(true) && b.PIECE3.Equals(false) && b.PIECE4.Equals(true) && b.PIECE5.Equals(true)) Response.Write("2, 4 et 5");
                    if (b.PIECE1.Equals(false) && b.PIECE2.Equals(true) && b.PIECE3.Equals(true) && b.PIECE4.Equals(true) && b.PIECE5.Equals(true)) Response.Write("2, 3, 4 et 5");

                    if (b.PIECE1.Equals(false) && b.PIECE2.Equals(false) && b.PIECE3.Equals(true) && b.PIECE4.Equals(false) && b.PIECE5.Equals(false)) Response.Write("3");
                    if (b.PIECE1.Equals(false) && b.PIECE2.Equals(false) && b.PIECE3.Equals(true) && b.PIECE4.Equals(true) && b.PIECE5.Equals(false)) Response.Write("3 et 4");
                    if (b.PIECE1.Equals(false) && b.PIECE2.Equals(false) && b.PIECE3.Equals(true) && b.PIECE4.Equals(false) && b.PIECE5.Equals(true)) Response.Write("3 et 5");
                    if (b.PIECE1.Equals(false) && b.PIECE2.Equals(false) && b.PIECE3.Equals(true) && b.PIECE4.Equals(true) && b.PIECE5.Equals(true)) Response.Write("3,4 et 5");

                    if (b.PIECE1.Equals(false) && b.PIECE2.Equals(false) && b.PIECE3.Equals(false) && b.PIECE4.Equals(true) && b.PIECE5.Equals(false)) Response.Write("4");
                    if (b.PIECE1.Equals(false) && b.PIECE2.Equals(false) && b.PIECE3.Equals(false) && b.PIECE4.Equals(true) && b.PIECE5.Equals(true)) Response.Write("4 et 5");

                    if (b.PIECE1.Equals(false) && b.PIECE2.Equals(false) && b.PIECE3.Equals(false) && b.PIECE4.Equals(false) && b.PIECE5.Equals(true)) Response.Write("5");
                }
                Response.Write("<br/>");
                if (b.VILLE1.Length != 0) Response.Write("Localité n°1: " + b.VILLE1 + "<br/>");
                //if (b.VILLE2.Length != 0) Response.Write("Localité n°2: " + b.VILLE2 + "<br/>");
                //if (b.VILLE3.Length != 0) Response.Write("Localité n°3: " + b.VILLE3  + "<br/>");
                //if (b.VILLE4.Length != 0) Response.Write("Localité n°4: " + b.VILLE4 + "<br/>");
                Response.Write("</div><br/>"); 
            %>
             
            <div style="float:right">
                <asp:Button ID="ButtonSupprimer" runat="server" Text="oui" OnClick="ButtonSupprimer_Click" class="myButton" />
                <asp:Button ID="ButtonRetour" runat="server" Text="non" OnClick="ButtonRetour_Click" class="myButton" />
            </div>
            <br />
        </td>
    </tr>
</table>

</asp:Content>

