<%@ Page Title="" Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="etatMails.aspx.cs" Inherits="pages_etatMails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder1" Runat="Server">

<br />
<div class="bloc_default" style="margin-left:5%;margin-right:5%">
    <center>
        <div style='font-weight: bold; font-size:20px'>ETAT ACTUEL DES MAILS</div>
        <br />
        
        <asp:Button ID="btn_refresh" runat="server" Text="Rafraichir" CssClass="flat-button" />
        
        <br /><br />
        <hr />
        <strong>Nous sommes le: <%=DateTime.Now %></strong>
        <br />
        Prochain mail à envoyer:<br />
        <%=type_dernier_mail %><%=id_dernier_mail %>
        <br />
        <br />
        Dernier mails envoyés:<br />
        <table>
            <asp:Label ID="Dernier_mails" runat="server" />
        </table>
        <hr />

        <table width="50%">
        <!-- Mail generaux -->
        <tr>
            <td> <strong>LETTRE PATRIMO</strong></td>
        </tr>
        <tr>
            <td>Mails restant à envoyer:</td>
            <td><%=MG_nb_mails %> </td>
        </tr>
        <tr>
            <td>Personnes restant à envoyer:</td>
            <td><%=MG_nb %> </td>
        </tr>
        <tr>
            <td>Temps estimé:</td>
            <td><%=MG_tps/60 %> minutes</td>
        </tr>
        <tr>
            <td>Date de fin estimée:</td>
            <td><%=MG_fin.ToString() %> </td>
        </tr>
        <tr>
            <td>Dernière lettre écrite le:</td>
            <td><%=date_dernier_mail_general%> </td>
        </tr>
         <!-- MAILS DE RAPPROCHEMENT -->
        <tr>
            <td>
             <strong>MAILS DE RAPPROCHEMENT</strong>
            </td>
        </tr>
        <tr>
            <td>Nombres de mails restant à envoyer:</td>
            <td><%=MR_nb %> </td>
        </tr>
        <tr>
            <td>Temps estimé:</td>
            <td><%=MR_tps/60 %> minutes</td>
        </tr>
        <tr>
            <td>Date de fin estimée:</td>
            <td><%=MR_fin.ToString() %> </td>
        </tr>
         <!-- ALERTES PERIMEES -->
        <tr>
            <td>
             <strong>ALERTES PERIMEES</strong>
            </td>
        </tr>
        <tr>
            <td>Nombres de mails restant à envoyer:</td>
            <td><%=AP_nb %> </td>
        </tr>
        <tr>
            <td>Temps estimé:</td>
            <td><%=AP_tps/60 %> minutes</td>
        </tr>
        <tr>
            <td>Date de fin estimée:</td>
            <td><%=AP_fin.ToString() %>  </td>
        </tr>
         <!-- ALERTES EMAIL -->
        <tr>
            <td>
             <strong>ALERTES EMAIL</strong>
            </td>
        </tr>
        <tr>
            <td>Alertes actives:</td>
            <td><%=AE_nb %> </td>
        </tr>
        <tr>
            <td>Durée estimé pour un cycle:</td>
            <td> <%=AE_tps/60 %> minutes</td>
        </tr>
        
        </table>
        <br />

        <hr />
        <strong> Dernier Log en date </strong><br />
        Le <% Response.Write(System.IO.File.GetLastWriteTime(@"C:\base_patrimo\Mailing\logMailingPatrimoFreuh.txt").ToString());%>
        <br /><br />
        <%getLog(); %>
        <br /><br />
    </center>
</div>

</asp:Content>

