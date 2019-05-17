

<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="outilconvertisseur.aspx.cs"  Inherits="convertisseur" Title="PATRIMONIUM : Outils" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >


    <%--<div class="ssmenuoutils">
        <br />
        
       &nbsp;<a href="outils_calcu_montant.aspx" style="border-bottom: gray 1px dotted">Calculette financiere</a>
        <br /><br />
       &nbsp;<a href="outilsendettement.aspx" style="border-bottom: gray 1px dotted">Capacité d'endettement</a>
        <br /><br />
        &nbsp;<a href="outilconvertisseur.aspx" style="border-bottom: gray 1px dotted">Conversions des mesures</a>
        <br /><br />
        &nbsp;<a href="outils_frais_notaire.aspx" style="border-bottom: gray 1px dotted">Frais de notaire</a>
   
    </div>--%>




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
                <td style="width: 7px">
                </td>
                <td style="width: 119px">
                </td>
                <td style="width: 98px">
                </td>
                <td style="width: 46px">
                </td>
                <td style="width: 38px">
                </td>
            </tr>
            <tr>
                <td style="width: 7px">
                </td>
                <td style="width: 119px">
                    <asp:Label ID="Labelm" runat="server" Text="Mètres carré (m²) :"></asp:Label>
                    </td>
                <td style="width: 98px">
                    <asp:TextBox ID="TextBoxm" OnTextChanged="TextBoxm_TextChanged" runat="server" Height="16px" CssClass=" tb10"></asp:TextBox></td>
                <td style="width: 46px">
                    <asp:Label ID="Labelf" runat="server" Text="Foot :"></asp:Label>
                    </td>
                <td style="width: 38px">
                    <asp:TextBox ID="TextBoxf" OnTextChanged="TextBoxf_TextChanged" runat="server" Height="16px" CssClass=" tb10"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 7px">
                </td>
                <td style="width: 119px">
                    &nbsp;<asp:Label ID="Labela" runat="server" Text="Area (a) :"></asp:Label>
                    </td>
                <td style="width: 98px">
                    <asp:TextBox ID="TextBoxa" OnTextChanged="TextBoxa_TextChanged" runat="server" Height="16px" CssClass=" tb10"></asp:TextBox></td>
                <td style="width: 46px">
                    <asp:Label ID="Labely" runat="server" Text="Yard :"></asp:Label>
                    </td>
                <td style="width: 38px">
                    <asp:TextBox ID="TextBoxy" OnTextChanged="TextBoxy_TextChanged" runat="server" Height="16px" CssClass=" tb10"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 7px">
                </td>
                <td style="width: 119px">
                    <asp:Label ID="Labeh" runat="server" Text="Hectare (ha) :"></asp:Label>
                    </td>
                <td style="width: 98px">
                    <asp:TextBox ID="TextBoxh" OnTextChanged="TextBoxh_TextChanged" runat="server" Height="16px" CssClass=" tb10"></asp:TextBox></td>
                <td style="width: 46px">
                    <asp:Label ID="Labelc" runat="server" Text="Acres :"></asp:Label>
                    </td>
                <td style="width: 38px">
                    <asp:TextBox ID="TextBoxc" OnTextChanged="TextBoxc_TextChanged" runat="server" Height="16px" CssClass=" tb10"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 7px">
                </td>
                <td style="width: 119px">
                </td>
                <td style="width: 98px">
                </td>
                <td style="width: 46px">
                    <asp:Button ID="Buttoncalculer" OnClick="ButtonCalculer_Click"  runat="server" Text="Calcul" CssClass="myButtopetiteeffacer"/></td>
                <td style="width: 38px">
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
