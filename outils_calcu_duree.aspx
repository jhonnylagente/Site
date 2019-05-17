
<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="outils_calcu_duree.aspx.cs" Inherits="outils_calcu_duree"Title="PATRIMONIUM : Outils" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
<script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE1_onclick() {

}

// ]]>
</script>


<%--    <div class="ssmenuoutils">
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
              <table>
                <tr><td>
                <div class="outilscalcu1">
                 <table>

                <tr>
         
                <td class="outilscalcu1trucselectionné" colspan="1" rowspan="1" style="height: 40px">
                    &nbsp;<a href="outils_calcu_duree.aspx" style="border-bottom: gray 1px dotted">
                    <strong class="outilscalcu1ssnoir">Durée</strong></a>  
                </td>
             
                <td rowspan="5" 
                    style="border-left-width: thin; border-left-color: white; width: 447px;">
                    <br />
                    <table style="left: 2px; width: 99%; top: 0px; height: 158%; background-color: #31536c;" id="TABLE1" onclick="return TABLE1_onclick()">
                        <tr>
                            <td style="width: 194px; height: 30px;">
                                <span class="outilscalcu1ssblanc"><strong>Entrez le montant :</strong></span></td>
                            <td style="width: 100px; height: 30px;">
                                <asp:TextBox ID="TextBoxMontant" runat="server" Width="75px" OnTextChanged="TextBoxMontant_TextChanged" style="text-align: right">200000</asp:TextBox></td>
                            <td style="width: 57px; height: 30px;">
                                <span class="outilscalcu1ssblanc">Euro</span></td>
                            <td rowspan="1">
                                <strong><span class="outilscalcu1ssblanc"></span></strong>
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 194px; height: 30px">
                                <span class="outilscalcu1ssblanc"><strong>Entrez la mensualité :</strong></span></td>
                            <td style="width: 100px; height: 30px">
                                <asp:TextBox ID="TextBoxMensualité" runat="server" Width="75px" OnTextChanged="TextBoxMensualité_TextChanged" style="text-align: right">1000</asp:TextBox></td>
                            <td style="width: 57px; height: 30px">
                                <span class="outilscalcu1ssblanc">Euro</span></td>
                            <td rowspan="1">
                                <asp:Button ID="ButtonCalculer" runat="server"  Text="CALCULER" CssClass="myButtopetiteeffacer" OnClick="ButtonCalculer_Click" /></td>
                        </tr>
                        <tr>
                            <td style="width: 194px; height: 30px">
                                <span class="outilscalcu1ssblanc"><strong>Taux d'intérêt :</strong></span></td>
                            <td style="width: 100px; height: 30px; font-size: 12pt;">
                                <asp:TextBox ID="TextBoxTaux" runat="server" OnTextChanged="TextBoxTauxAssu_TextChanged"
                                    Width="75px" style="Text.Align = right; text-align: right; text: right;">4,5</asp:TextBox></td>
                            <td style="width: 57px; height: 30px; font-size: 12pt;">
                                <span class="outilscalcu1ssblanc">%</span></td>
                            <td style="height: 30px; font-size: 12pt;">
                                <asp:Button ID="ButtonEffacer" runat="server"  Text="EFFACER" CssClass="myButtopetiteeffacer" OnClick="ButtonEffacer_Click" /></td>
                        </tr>
                        <tr>
                            <td style="width: 194px; height: 30px">
                            </td>
                            <td style="font-size: 12pt; width: 100px; height: 30px">
                            </td>
                            <td style="font-size: 12pt; width: 57px; height: 30px">
                            </td>
                            <td style="font-size: 12pt; height: 30px">
                            </td>
                        </tr>
                        <tr class="outilscalcu1trucselectionné">
                            <td colspan="4" >
                                <strong class="outilscalcu1ssnoir">&nbsp; Votre crédit s'étalera sur :<asp:TextBox ID="TextBoxCredit" runat="server" OnTextChanged="TextBoxCredit_TextChanged" ReadOnly="True" style="text-align: right"></asp:TextBox>(résultalt)</strong></td>
                        </tr>
                    </table>
                    <br />
                    <br />
                </td>
            </tr>
                <tr style="font-size: 12pt">
                <td colspan="1" rowspan="1" style="width: 85px; height: 40px; border-bottom-width: thin; border-bottom-color: white; border-top-width: thin; border-left-width: thin; border-left-color: white; border-top-color: white; border-right-width: thin; border-right-color: white;">
                    &nbsp;<a href="outils_calcu_montant.aspx" style="border-bottom: gray 1px dotted"><strong><span
                       class="outilscalcu1ssblanc">Montant</span></strong></a><strong><span class="outilscalcu1ssblanc">
                        </span></strong>
        
             
                </td>
            </tr>
           
                <tr style="font-size: 12pt">
                <td colspan="1" rowspan="1" style="height: 41px">
                
             
                     &nbsp;<a href="outils_calcu_mensualite.aspx" style="border-bottom: gray 1px dotted"><strong><span
                        class="outilscalcu1ssblanc">Mensualité</span></strong></a></td>
                     
            </tr>
          
                <tr>
                <td colspan="1" rowspan="1" style="width: 85px; height: 10px">
                    <br />
                    <br />
                </td>
            </tr>
                <tr>
                    <td colspan="1" rowspan="2" style="width: 85px; height: 40px;">
                    </td>
                </tr>
        </table>
    
            </div>
                </td></tr>
                <tr><td colspan="3" style="height: 108px">
                    <asp:Label ID="LabelErreur" runat="server" Height="97px" Style="color: red" Width="538px"></asp:Label></td>
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
