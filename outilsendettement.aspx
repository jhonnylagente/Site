

<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="outilsendettement.aspx.cs"  Inherits="outilsendettement " Title="PATRIMONIUM : Outils" %>

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
             <table class="outilsendettementmenu">
        <tr>
            <td colspan="2" style="height: 25px">
                <strong>Revenus annuels disponible :</strong></td>
            <td style="width: 166px; height: 25px">
            </td>
            <td style="width: 166px; height: 25px">
            </td>
        </tr>
        <tr>
            <td style="width: 1101px; height: 25px">
                Salaire net mensuel</td>
            <td style="width: 630px; height: 25px">
                <asp:TextBox ID="SalaireMensuel" runat="server" OnTextChanged="SalaireMensuel_TextChanged" CssClass=" tb10" >0</asp:TextBox>Euro</td>
            <td style="width: 166px; height: 25px; text-align: left">
                x</td>
            <td style="width: 166px; height: 25px">
                <asp:TextBox ID="MultiMoisSalaire" runat="server" Width="40px" OnTextChanged="MultiMoisSalaire_TextChanged"  CssClass=" tbsanswidth">12</asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 1101px; height: 25px">
                Salaire net mensuel conjoint</td>
            <td style="width: 630px; height: 25px">
                <asp:TextBox ID="SalaireMensuelConjoint" runat="server" OnTextChanged="SalaireMensuel_TextChanged" CssClass=" tb10" >0</asp:TextBox>Euro</td>
            <td style="width: 166px; height: 25px">
                x</td>
            <td style="width: 166px; height: 25px">
                <asp:TextBox ID="MultiSalaireConjoint" runat="server" Width="40px" OnTextChanged="MultiSalaireConjoint_TextChanged" CssClass=" tbsanswidth" Height="16px">12</asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 1101px; height: 25px">
                Allocations familiales</td>
            <td style="width: 630px; height: 25px">
                <asp:TextBox ID="AllocationsFamiliales" runat="server" CssClass=" tb10" OnTextChanged="AllocationsFamiliales_TextChanged" >0</asp:TextBox>Euro</td>
            <td style="width: 166px; height: 25px">
                x</td>
            <td style="width: 166px; height: 25px">
                <asp:TextBox ID="MultAllocationsFamiliales" runat="server" Width="40px" OnTextChanged="MultAllocationsFamiliales_TextChanged" Height="16px" CssClass=" tbsanswidth">12</asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 1101px; height: 25px">
                Autres revenus</td>
            <td style="width: 630px; height: 25px">
                <asp:TextBox ID="AutresRevenus" runat="server" OnTextChanged="AutresRevenus_TextChanged" CssClass=" tbsanswidth" Width="150px">0</asp:TextBox>Euro</td>
            <td style="width: 166px; height: 25px">
            </td>
            <td style="width: 166px; height: 25px">
            </td>
        </tr>
        <tr>
            <td style="width: 1101px; height: 25px">
                <asp:Button ID="ButtonCalculRevenus" runat="server" Text="Total revenus annuels" Width="190px"
                    OnClick="ButtonCalculRevenus_Click"  CssClass="myButtopetite"/></td>
            <td style="width: 630px; height: 25px">
                <asp:TextBox ID="TotalRevenusAnnuels" runat="server" OnTextChanged="TotalRevenusAnnuels_TextChanged" Width="150px" CssClass=" tbsanswidth">0</asp:TextBox>Euro</td>
            <td style="width: 166px; height: 25px">
            </td>
            <td style="width: 166px; height: 25px">
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 25px">
                <strong>Annuité d'emprunt en cours :</strong></td>
            <td style="width: 166px; height: 25px">
            </td>
            <td style="width: 166px; height: 25px">
            </td>
        </tr>
        <tr>
            <td style="width: 1101px; height: 25px">
                Mensualtiés d'emprunt en cours</td>
            <td style="width: 630px; height: 25px">
                <asp:TextBox ID="MensualitésEmpruntEnCours" runat="server" CssClass=" tb10" OnTextChanged="MensualitésEmpruntEnCours_TextChanged" >0</asp:TextBox>Euro</td>
            <td style="width: 166px; height: 25px">
                x</td>
            <td style="width: 166px; height: 25px">
                <asp:TextBox ID="MultiMensualitésEmprunt" runat="server" Width="40px" OnTextChanged="MultiMensualitésEmprunt_TextChanged" CssClass=" tbsanswidth">12</asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 1101px; height: 13px">
                Autres charges mensuelles</td>
            <td style="width: 630px; height: 13px">
                <asp:TextBox ID="AutresChargesMensuelles" runat="server" CssClass=" tb10" OnTextChanged="AutresChargesMensuelles_TextChanged" >0</asp:TextBox>Euro</td>
            <td style="width: 166px; height: 13px">
                x</td>
            <td style="width: 166px; height: 13px">
                <asp:TextBox ID="MultiAutresChargesMensuelles" runat="server" Width="40px" OnTextChanged="MultiAutresChargesMensuelles_TextChanged" CssClass=" tbsanswidth">12</asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 1101px; height: 13px">
                <asp:Button ID="ButtonTotalChargesAnnuels" runat="server" Text="Total charges annuelles"
                    OnClick="ButtonTotalChargesAnnuels_Click"  Width="190px" CssClass="myButtopetite" /></td>
            <td style="width: 630px; height: 13px">
                <asp:TextBox ID="TotalChargesAnnuelles" runat="server" OnTextChanged="TotalChargesAnnuelles_TextChanged" Width="150px" CssClass=" tbsanswidth">0</asp:TextBox>Euro</td>
            <td style="width: 166px; height: 13px">
            </td>
            <td style="width: 166px; height: 13px">
            </td>
        </tr>
        <tr>
            <td style="width: 1101px; height: 13px">
            </td>
            <td style="width: 630px; height: 13px">
            </td>
            <td style="width: 166px; height: 13px">
            </td>
            <td style="width: 166px; height: 13px">
            </td>
        </tr>
        <tr>
            <td style="width: 1101px; height: 13px">
            </td>
            <td style="width: 630px; height: 13px">
            </td>
            <td style="width: 166px; height: 13px">
            </td>
            <td style="width: 166px; height: 13px">
            </td>
        </tr>
        <tr>
            <td style="width: 1101px; height: 13px">
                <strong>Revenus annuels disponibles</strong></td>
            <td style="width: 630px; height: 13px">
                <asp:TextBox ID="RevenusAnnuelsDisponibles" runat="server" OnTextChanged="RevenusAnnuelsDisponibles_TextChanged" Width="150px" CssClass=" tbsanswidth">0</asp:TextBox>Euro</td>
            <td style="width: 166px; height: 13px">
            </td>
            <td style="width: 166px; height: 13px">
            </td>
        </tr>
        <tr>
            <td style="width: 1101px; height: 13px">
                <strong>Plafond d'endettement</strong></td>
            <td style="width: 630px; height: 13px">
                <asp:TextBox ID="PlafondEndettement" runat="server" Width="50px" OnTextChanged="PlafondEndettement_TextChanged" CssClass=" tbsanswidth">33</asp:TextBox>%</td>
            <td style="width: 166px; height: 13px">
            </td>
            <td style="width: 166px; height: 13px">
            </td>
        </tr>
        <tr>
            <td style="width: 1101px; height: 13px">
                <strong>Annuité maximum possible</strong></td>
            <td style="width: 630px; height: 13px">
                <asp:TextBox ID="AnnuitéMaximumuPossible" runat="server" OnTextChanged="AnnuitéMaximumuPossible_TextChanged" Width="150px" CssClass=" tbsanswidth">0</asp:TextBox>Euro</td>
            <td style="width: 166px; height: 13px">
            </td>
            <td style="width: 166px; height: 13px">
            </td>
        </tr>
        <tr>
            <td style="width: 1101px; height: 13px">
                <strong>Mensualité maximum possible</strong></td>
            <td style="width: 630px; height: 13px">
                <asp:TextBox ID="MensualitéMaximumPossible" runat="server" OnTextChanged="MensualitéMaximumPossible_TextChanged" Width="150px" CssClass=" tbsanswidth">0</asp:TextBox>Euro</td>
            <td style="width: 166px; height: 13px">
            </td>
            <td style="width: 166px; height: 13px">
            </td>
        </tr>
        <tr>
            <td style="width: 1101px; height: 13px">
                <asp:Button ID="ButtonCalcul" runat="server" Font-Bold="True" Width="190px" OnClick="ButtonCalcul_Click" CssClass="myButtopetite"
                    Text="Calcul" /></td>
            <td style="width: 630px; height: 13px">
            </td>
            <td style="width: 166px; height: 13px">
            </td>
            <td style="width: 166px; height: 13px">
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
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                
                

</asp:Content>
