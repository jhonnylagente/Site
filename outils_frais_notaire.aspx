
<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="outils_frais_notaire.aspx.cs" Inherits="outils_frais_notaire"Title="PATRIMONIUM : Outils" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >


<%--    <div class="ssmenuoutils">
        <br />
        
       &nbsp;<a href="outils_calcu_montant.aspx" style="border-bottom: gray 1px dotted">Calculette financiere</a>
        <br /><br />
       &nbsp;<a href="outilsendettement.aspx" style="border-bottom: gray 1px dotted">Capacité d'endettement</a>
        <br /><br />
        &nbsp;<a href="outilconvertisseur.aspx" style="border-bottom: gray 1px dotted">Conversions des mesures</a>
        <br /><br />
        &nbsp;<a href="outils_frais_notaire.aspx" style="border-bottom: gray 1px dotted">Frais de notaire</a>
   
    </div>
--%>

    
    
<table>
       <tr>
          <td valign="top">
               <table>
                        <tr>    
                            <td><a href="Recherche_agent.aspx"><img id="botton_votreagent" src="../img_site/image_patrimo_votreagent.jpg" alt="votreagent" /></a></td> 
                        </tr>
                        <tr>     
                            <td><a href="vendre_estimer.aspx"><img id="botton_estimation" src="../img_site/image_patrimo_estimation.jpg" alt="estimation" /></a></td> 
                        </tr>
               </table>
          </td>
          <td valign="top">
            <table class="outilscalcu1">
            <tr>
                <td colspan="4" rowspan="5" class="outilsfraisdenotairebord">
                    &nbsp; &nbsp; &nbsp; &nbsp;
                    <table class="outilsfraisdenotairetableau">
                        <tr>
                            <td style="width: 194px; height: 30px;">
                                <span class="outilscalcu1ssblanc"><strong>Montant du bien 
                                    <br />
                                </strong></span></td>
                            <td style="width: 123px; height: 30px;">
                                <asp:TextBox ID="TextBoxMontantb" runat="server" CssClass=" tb10" OnTextChanged="TextBoxTaux_TextChanged">200000</asp:TextBox></td>
                            <td style="width: 57px; height: 30px;">
                                <span class="outilscalcu1ssblanc">Euro</span></td>
                            <td rowspan="1">
                                <asp:Button ID="ButtonCalculer" runat="server" Text="CALCULER" OnClick="ButtonCalculer_Click1"  CssClass="myButtopetiteeffacer"/></td>
                        </tr>
                        <tr>
                            <td style="width: 194px; height: 31px">
                                <span class="outilscalcu1ssblanc"><strong>Montant de votre emprunt <br />
                                </strong></span></td>
                            <td style="width: 123px; height: 31px">
                                <asp:TextBox ID="TextBoxMontante" runat="server" CssClass=" tb10" OnTextChanged="TextBoxMensualité_TextChanged">100000</asp:TextBox></td>
                            <td style="width: 57px; height: 31px">
                                <span class="outilscalcu1ssblanc">Euro</span></td>
                            <td style="height: 31px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 194px; height: 30px;">
                                <span class="outilscalcu1ssblanc"><strong>Indiquez l'etat du bien<br />
                                </strong></span></td>
                            <td style="width: 123px; height: 30px">
                                <asp:DropDownList ID="DropDownListSelection" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="0">-- S&#233;lection --</asp:ListItem>
                                    <asp:ListItem Value="1">Neuf (-5ans)</asp:ListItem>
                                    <asp:ListItem Value="2">Ancien</asp:ListItem>
                                </asp:DropDownList></td>
                            
                                   
                            <td style="width: 57px; height: 30px;">
                                <span class="outilscalcu1ssblanc"></span></td>
                            <td rowspan="1">
                                <asp:Button ID="ButtonEffacer" runat="server" Text="EFFACER" OnClick="ButtonEffacer_Click"  CssClass="myButtopetiteeffacer"/></td>
                        </tr>
                        <tr>
                            <td style="width: 194px;">
                            </td>
                            <td style="width: 123px; color: #000000;">
                            </td>
                            <td style="width: 57px; color: #000000;">
                            </td>
                            <td style="color: #000000;">
                            </td>
                        </tr>
                      
                         <tr class="outilscalcu1trucselectionné">
                            <td colspan="4" >
                                <strong class="outilscalcu1ssnoir">&nbsp;  frais de Notaire :<asp:TextBox ID="TextBoxResultf" runat="server" OnTextChanged="TextBoxResultf_TextChanged" ReadOnly="True"></asp:TextBox>Euro</strong></td>
                        </tr>
                    </table>
                </td>
            </tr>
            </table>
          </td>
          <td valign="top">
              <table>
                  <tr>
                      <td><a href="./recrutement.aspx"><img id="botton_recrutement" src="../img_site/image_patrimo_recrutement.jpg" alt="recrutement" /></a></td>
                  </tr>
                  <tr>
                      <td><a href="recrutement_remuneration.aspx"><img src="../img_site/remuneration.gif" alt="remuneration" /></a></td>
                  </tr>
              </table>
          </td>
       </tr>
    </table>
    

    <br />
    <br />
    
</asp:Content>
