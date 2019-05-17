

<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="outils_calcu_montant.aspx.cs" Inherits="outils_calcu_montant" Title="PATRIMONIUM : Outils" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
  

<%--    <div class="ssmenuoutils" style="width: 179px; height: 465px">
        <br />
        
       &nbsp;<a href="outils_calcu_montant.aspx" style="border-bottom: gray 1px dotted">Calculette financiere</a>
        <br /><br />
       &nbsp;<a href="outilsendettement.aspx" style="border-bottom: gray 1px dotted">Capacité d'endettement</a>
        <br /><br />
        &nbsp;<a href="outilconvertisseur.aspx" style="border-bottom: gray 1px dotted">Conversions des mesures</a>
        <br /><br />
        &nbsp;<a href="outils_frais_notaire.aspx" style="border-bottom: gray 1px dotted">Frais de notaire</a><br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;<br />
        <br />
        <br />
        <br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
   
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
            <div class="outilscalcu1">
        <table>
            <tr>
           <td colspan="1" rowspan="1" style="width: 85px; height: 40px; border-bottom-width: thin; border-bottom-color: white; border-top-width: thin; border-left-width: thin; border-left-color: white; border-top-color: white; border-right-width: thin; border-right-color: white;">
                    &nbsp;<a href="outils_calcu_duree.aspx" style="border-bottom: gray 1px dotted"><strong><span
                       class="outilscalcu1ssblanc">Durée</span></strong></a><strong><span class="outilscalcu1ssblanc">
                        </span></strong>
                </td>
                    
                    
                <td colspan="4" rowspan="5" 
                    style="border-left-width: thin; border-left-color: white; width: 447px;">
                    <br />
                    <table style="left: 2px; width: 99%; top: 0px; height: 158%; background-color: #31536c;">
                        <tr>
                            <td style="width: 194px; height: 40px">
                                <strong><span class="outilscalcu1ssblanc">Entrez la mensualité :</span></strong><br />
                            </td>
                            <td style="width: 100px; height: 40px">
                                <asp:TextBox ID="TextBoxMensualité" runat="server"  CssClass="tb10" OnTextChanged="TextBoxMensualité_TextChanged" style="text-align: right">1000</asp:TextBox></td>
                            <td style="width: 57px; height: 40px">
                                <span class="outilscalcu1ssblanc">Euro</span></td>
                            <td rowspan="1" style="height: 40px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 194px; height: 30px;">
                                <span class="outilscalcu1ssblanc"><strong>Taux d'intérêt :<br />
                                </strong><span style="font-size: 11pt">
                                </span></span></td>
                            <td style="width: 100px; height: 30px;">
                                <asp:TextBox ID="TextBoxTaux" runat="server" CssClass="tb10" OnTextChanged="TextBoxTaux_TextChanged" style="text-align: right">4,40</asp:TextBox></td>
                            <td style="width: 57px; height: 30px;">
                                <span class="outilscalcu1ssblanc">
                                %</span></td>
                            <td rowspan="1">
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 194px; height: 30px">
                                <strong><span class="outilscalcu1ssblanc">Taux assurance :</span></strong></td>
                            <td style="width: 100px; height: 30px">
                                <asp:TextBox ID="TextBoxTauxAssu" runat="server" OnTextChanged="TextBoxTauxAssu_TextChanged"
                                    Style="text-align: right;" CssClass="tb10" >0,36</asp:TextBox></td>
                            <td style="width: 57px; height: 30px">
                                <span class="outilscalcu1ssblanc">%</span></td>
                            <td rowspan="1">
                                <asp:Button ID="ButtonCalculer" runat="server" Text="CALCULER" CssClass="myButtopetiteeffacer" OnClick="ButtonCalculer_Click" /></td>
                        </tr>
                        <tr>
                            <td style="width: 194px; height: 30px;">
                                <span class="outilscalcu1ssblanc"><strong>Entrez la durée :</strong></span></td>
                            <td style="width: 100px; height: 30px;">
                                <asp:DropDownList ID="DropDownListDurée" runat="server" CssClass="tb10" OnSelectedIndexChanged="DropDownListDurée_SelectedIndexChanged">
                                    <asp:ListItem Value="0">-- Dur&#233;e --</asp:ListItem>
                                    <asp:ListItem Value="1"></asp:ListItem>
                                    <asp:ListItem Value="2"></asp:ListItem>
                                    <asp:ListItem Value="3"></asp:ListItem>
                                    <asp:ListItem Value="4"></asp:ListItem>
                                    <asp:ListItem Value="5"></asp:ListItem>
                                    <asp:ListItem Value="6"></asp:ListItem>
                                    <asp:ListItem Value="7"></asp:ListItem>
                                    <asp:ListItem Value="8"></asp:ListItem>
                                    <asp:ListItem Value="9"></asp:ListItem>
                                    <asp:ListItem Value="10"></asp:ListItem>
                                    <asp:ListItem Value="11"></asp:ListItem>
                                    <asp:ListItem Value="12"></asp:ListItem>
                                    <asp:ListItem Value="13"></asp:ListItem>
                                    <asp:ListItem Value="14"></asp:ListItem>
                                    <asp:ListItem Value="15"></asp:ListItem>
                                    <asp:ListItem Value="16"></asp:ListItem>
                                    <asp:ListItem Value="17"></asp:ListItem>
                                    <asp:ListItem Value="18"></asp:ListItem>
                                    <asp:ListItem Value="19"></asp:ListItem>
                                    <asp:ListItem Value="20"></asp:ListItem>
                                    <asp:ListItem Value="21"></asp:ListItem>
                                    <asp:ListItem Value="22"></asp:ListItem>
                                    <asp:ListItem Value="23"></asp:ListItem>
                                    <asp:ListItem Value="24"></asp:ListItem>
                                    <asp:ListItem Value="25"></asp:ListItem>
                                    <asp:ListItem Value="26"></asp:ListItem>
                                    <asp:ListItem Value="27"></asp:ListItem>
                                    <asp:ListItem Value="28"></asp:ListItem>
                                    <asp:ListItem Value="29"></asp:ListItem>
                                    <asp:ListItem Value="30"></asp:ListItem>
                                    <asp:ListItem Value="31"></asp:ListItem>
                                    <asp:ListItem Value="32"></asp:ListItem>
                                    <asp:ListItem Value="33"></asp:ListItem>
                                    <asp:ListItem Value="34"></asp:ListItem>
                                    <asp:ListItem Value="35"></asp:ListItem>
                                    <asp:ListItem Value="36"></asp:ListItem>
                                    <asp:ListItem Value="37"></asp:ListItem>
                                    <asp:ListItem Value="38"></asp:ListItem>
                                    <asp:ListItem Value="39"></asp:ListItem>
                                    <asp:ListItem Value="40"></asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 57px; height: 30px;">
                                <span class="outilscalcu1ssblanc">Ans</span></td>
                            <td rowspan="1" style="color: #000000">
                                <asp:Button ID="ButtonEffacer" runat="server" Text="EFFACER" CssClass="myButtopetiteeffacer"  OnClick="ButtonEffacer_Click" /></td>
                        </tr>
                        <tr style="color: #000000">
                            <td style="width: 194px;">
                            </td>
                            <td style="width: 100px; color: #000000;">
                            </td>
                            <td style="width: 57px; color: #000000;">
                            </td>
                            <td style="color: #000000;">
                            </td>
                        </tr>     
                         <tr class="outilscalcu1trucselectionné">
                            <td colspan="4" >
                                <strong class="outilscalcu1ssnoir">&nbsp; Votre crédit sera de<asp:TextBox ID="TextBoxPret" runat="server" OnTextChanged="TextBoxPret_TextChanged" ReadOnly="True" CssClass=" tbsanswidth" style="text-align: right"></asp:TextBox>(résultalt)</strong></td>
                        </tr>
                        
                        
                    </table>
                </td>
            </tr>
            <tr style="color: #000000">
             <td class="outilscalcu1trucselectionné" colspan="1" rowspan="1" style="height: 40px">
                    &nbsp;<a href="outils_calcu_montant.aspx" style="border-bottom: gray 1px dotted">
                    <strong class="outilscalcu1ssnoir">Montant</strong></a>  
                </td>

            </tr>
            <tr style="color: #000000">
                <td colspan="1" rowspan="1" style="width: 85px; height: 40px; border-top-width: thin; border-left-width: thin; border-left-color: white; border-bottom-width: thin; border-bottom-color: white; border-top-color: white; border-right-width: thin; border-right-color: white;">
                     &nbsp;<a href="outils_calcu_mensualite.aspx" style="border-bottom: gray 1px dotted"><strong><span
                        class="outilscalcu1ssblanc">Mensualité</span></strong></a><br />
                    <strong><span class="outilscalcu1ssblanc">
                        </span></strong>
            </td>
            </tr>
            <tr>
                <td colspan="1" rowspan="1" style="width: 85px; height: 10px">
                </td>
            </tr>
            <tr>
                <td colspan="1" rowspan="2" style="width: 85px; height: 40px;">
                </td>
            </tr>
            </table>
    <br />
    <br />
    
    </div>
            <br />
            <table style="left: 211px; width: 66%; top: 27px;">
                <tr>
                    <td colspan="3">
                        <asp:Label ID="LabelErreur" runat="server" Style="color: red" Width="538px"></asp:Label></td>
                </tr>
                </table>
            <br />
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
