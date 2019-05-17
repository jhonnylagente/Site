<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="inscriptionAccueil.aspx.cs" Inherits="pages_inscriptionAccueil" Title="PATRIMONIUM : Identifiez-vous" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
    
    <% if (Request.Params["valid"] == "oui")
   {
       Label1.Visible = true;
       Label1.Text = "F�licitations, votre inscription a bien �t� enregistr�e";
   }
   else if (Request.Params["valid"] == "mail")
   {
       Label1.Visible = true;
       Label1.Text = "Un EMail contenant votre mot de passe vous a �t� envoy�";
   } %>

   
<div style="width:615px;text-align:center;margin-left:87px;">
    <strong><asp:Label class="rouge" ID="Label1" runat="server" Font-Bold="True" ForeColor="Red" Visible="False" Width="615px"></asp:Label></strong>
</div>
    <div class="LoginLeft">
        <fieldset class="fieldsetLogin">
		<legend><strong>D�j� inscrit(e) ?</strong></legend>
                <asp:Label ID="LabelErrorLogin" runat="server" Font-Bold="True" ForeColor="Red" Visible="False" Width="230px"></asp:Label>
                <br />
                Connectez vous :
                <br /><br />
                <table style="text-align:center">
                    <tr>
                        <td>
                            <asp:TextBox ID="TextBoxEmail"  CssClass="big_textbox" placeholder="Adresse Email"  runat="server" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr >
                        <td >
                            <asp:TextBox ID="TextBoxPassword" style="margin-top:10px" CssClass="big_textbox" placeholder="Mot de passe" runat="server" Width="280px" TextMode="Password"></asp:TextBox>
                            <br /><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="ButtonOpenSession" runat="server" CssClass="flat-button" Text="Ouvrir une session" Width="175px" OnClick="Button1_Click" />
                            <br />
                            <span class="mdpoublie"><asp:LinkButton class="mdpoublie"  ID="ButtonRecoveryPassword" runat="server" Text="Mot de passe oubli� ?" Width="175px" OnClick="ButtonRecoveryPassword_Click1" /></span>
                        </td>
                    </tr>
                </table>
        </fieldset>   
        <br />
        <br />
        <br />  
    </div>
    <div class="Login">
        <fieldset class="fieldsetLogin">
    		<legend style="color: rgb(0, 0, 0);"><strong>Nouvelle inscription ?</strong>
    		</legend>
    		<p style="margin-left:15px;">Cr�ez gratuitement votre espace personnalis� et sauvegardez toutes vos informations : 
    		</p>
    		    <center>
                <asp:Button  CssClass="Quickinscription" ID="Quickinscription" runat="server" 
                                Text="Cr�ez votre compte en 1 minute !&#13;Cliquez ici !"  
                                OnClick="Quickinscription_Click"  />
    		    </center>
                    <p style="margin-left:15px;">Avec votre espace personnalis� vous pourrez : </p>
                    <ul>
                    <li> Mettre en <b>m�moire vos recherches</b>.</li><li>Recevoir les <b>nouvelles annonces</b> d�s leur publication.</li><li> Obtenir gratuitement nos <b>conseils pratiques et bons plans</b>.</li><li> Profiter des avantages de Patrimo et de ses partenaires.</li></ul>
        </fieldset>
    </div>

    
    <br />
    <br />
    
</asp:Content>


