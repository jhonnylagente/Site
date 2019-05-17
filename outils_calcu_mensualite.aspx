
<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="outils_calcu_mensualite.aspx.cs" Inherits="outils_calcu_mensualite" Title="PATRIMONIUM : Outils" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
<script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE1_onclick() {

}

function TABLE2_onclick() {

}

// ]]>
</script>

  
<%--    <div class="ssmenuoutils" style="height: 413px">
        <br /> 
       &nbsp;<a href="outils_calcu_montant.aspx" style="border-bottom: gray 1px dotted">Calculette financiere</a>
        <br /><br />
       &nbsp;<a href="outilsendettement.aspx" style="border-bottom: gray 1px dotted">Capacité d'endettement</a>
        <br /><br />
        &nbsp;<a href="outilconvertisseur.aspx" style="border-bottom: gray 1px dotted">Conversions des mesures</a>
        <br /><br />
        &nbsp;<a href="outils_frais_notaire.aspx" style="border-bottom: gray 1px dotted">Frais de notaire</a>&nbsp;<br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
        <br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</div>



--%>
<table>
<tr>
<td>
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
                  <tr>
                  <td style="width: 604px">
                  <div class="outilscalcu1">
        <table id="TABLE2" onclick="return TABLE2_onclick()" >
            <tr>
                <td colspan="1" rowspan="1" style="width: 85px; height: 40px; border-bottom-width: thin; border-bottom-color: white; border-top-width: thin; border-left-width: thin; border-left-color: white; border-top-color: white; border-right-width: thin; border-right-color: white;">
                    &nbsp;<a href="outils_calcu_duree.aspx" style="border-bottom: gray 1px dotted"><strong><span
                       class="outilscalcu1ssblanc">Durée</span></strong></a><strong><span style="color: #ffffff">
                        </span></strong>
        
             
                </td>
                <td colspan="4" rowspan="5" 
                    style="border-left-width: thin; border-left-color: white">
                    &nbsp; &nbsp; &nbsp; &nbsp;<table style="left: 2px; width: 99%; top: 0px; height: 158%; background-color: #31536c;">
                   
                        <tr>
                            <td style="width: 224px; height: 40px">
                                <span class="outilscalcu1ssblanc"><strong>Montant du prêt :</strong></span></td>
                            <td style="width: 116px; height: 40px">
                                <asp:TextBox ID="TextBoxMMontant" runat="server" Width="75px" OnTextChanged="TextBoxMontant_TextChanged" style="text-align: right; letter-spacing: normal;">200000</asp:TextBox></td>
                            <td style="width: 57px; height: 40px">
                                <span class="outilscalcu1ssblanc">Euro</span></td>
                            <td style="height: 40px; width: 103px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 224px; height: 40px;">
                                <span class="outilscalcu1ssblanc"><strong>Taux d'intérêt :</strong></span></td>
                            <td style="width: 116px; height: 40px; font-size: 12pt;">
                                <asp:TextBox ID="TextBoxMTaux" runat="server" Width="75px" OnTextChanged="TextBoxTaux_TextChanged" style="text-align: right">4,40</asp:TextBox></td>
                            <td style="width: 57px; height: 40px; font-size: 12pt;">
                                <span class="outilscalcu1ssblanc">
                                %</span></td>
                            <td style="font-size: 12pt; width: 103px; height: 40px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 224px; height: 40px">
                                <span class="outilscalcu1ssblanc"><strong>Taux assurance :</strong></span></td>
                            <td style="font-size: 12pt; width: 116px; height: 40px">
                                <asp:TextBox ID="TextBoxMTauxAssu" runat="server" OnTextChanged="TextBoxTauxAssu_TextChanged"
                                    Width="75px" style="text-align: right">0,36</asp:TextBox></td>
                            <td style="font-size: 12pt; width: 57px; height: 40px">
                                <span class="outilscalcu1ssblanc">%</span></td>
                            <td style="font-size: 12pt; width: 103px; height: 40px">
                                <asp:Button ID="ButtonCalculer" runat="server"  Text="CALCULER" OnClick="ButtonCalculer_Click" CssClass="myButtopetiteeffacer" /></td>
                        </tr>
                        <tr>
                            <td style="width: 224px; height: 40px;">
                                <span class="outilscalcu1ssblanc"><strong>Durée du prêt :</strong></span></td>
                            <td style="width: 116px; height: 40px;">
                                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                                    Width="85px" style="text-align: right">                                 
                                    <asp:ListItem>-- Dur&#233;e --</asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem Value="3"></asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                    <asp:ListItem>13</asp:ListItem>
                                    <asp:ListItem>14</asp:ListItem>
                                    <asp:ListItem>15</asp:ListItem>
                                    <asp:ListItem>16</asp:ListItem>
                                    <asp:ListItem>17</asp:ListItem>
                                    <asp:ListItem>18</asp:ListItem>
                                    <asp:ListItem>19</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>21</asp:ListItem>
                                    <asp:ListItem>22</asp:ListItem>
                                    <asp:ListItem>23</asp:ListItem>
                                    <asp:ListItem>24</asp:ListItem>
                                    <asp:ListItem>25</asp:ListItem>
                                    <asp:ListItem>26</asp:ListItem>
                                    <asp:ListItem>27</asp:ListItem>
                                    <asp:ListItem>28</asp:ListItem>
                                    <asp:ListItem>29</asp:ListItem>
                                    <asp:ListItem>30</asp:ListItem>
                                    <asp:ListItem>31</asp:ListItem>
                                    <asp:ListItem>32</asp:ListItem>
                                    <asp:ListItem>33</asp:ListItem>
                                    <asp:ListItem>34</asp:ListItem>
                                    <asp:ListItem>35</asp:ListItem>
                                    <asp:ListItem>36</asp:ListItem>
                                    <asp:ListItem>37</asp:ListItem>
                                    <asp:ListItem>38</asp:ListItem>
                                    <asp:ListItem>39</asp:ListItem>
                                    <asp:ListItem>40</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 57px; height: 40px;">
                                <span class="outilscalcu1ssblanc">Ans</span></td>
                            <td rowspan="1" style="width: 103px; height: 40px">
                                <asp:Button ID="ButtonEffacer" runat="server"  Text=" EFFACER "  OnClick="ButtonEffacer_Click"  CssClass="myButtopetiteeffacer" /></td>
                        </tr>
                        <tr class="outilscalcu1trucselectionné">
                            <td colspan="4" >
                                <strong class="outilscalcu1ssnoir">&nbsp; Vos mensualités seront de :<asp:TextBox ID="TextBoxMResultat" runat="server"   OnDataBinding ="TextBoxResultat_TextChanged" ReadOnly="True" Width="121px" style="text-align: right"></asp:TextBox>&nbsp;
                                    (résultat)</strong></td>
                        </tr>
                    </table>
                    &nbsp;
                  

                 </td>
            </tr>
            <tr>
                <td colspan="1" rowspan="1" style="width: 85px; height: 40px; border-bottom-width: thin; border-bottom-color: white; border-top-width: thin; border-left-width: thin; border-left-color: white; border-top-color: white; border-right-width: thin; border-right-color: white;">
                    &nbsp;<a href="outils_calcu_montant.aspx" style="border-bottom: gray 1px dotted"><strong><span
                       class="outilscalcu1ssblanc">Montant</span></strong></a><strong><span style="color: #ffffff">
                        </span></strong>
                </td>
            </tr>
           
            <tr>
        
                      <td class="outilscalcu1trucselectionné" colspan="1" rowspan="1" style="height: 40px">  
                    &nbsp;<a href="outils_calcu_mensualite.aspx" style="border-bottom: gray 1px dotted"><strong class="outilscalcu1ssnoir">Mensualité</strong></a></td>
                
                
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
                  <tr><td style="width: 604px">
                      <span class="labeldutableau">
                    <asp:Label ID="LabelErreur" runat="server" Style="color: red; text-align: left; font-size: 12px; top: 7px;" ></asp:Label><br />
                        &nbsp;
                    </span>  
                  </td></tr>
               </table>
         
            <table>
                    <tr>
                    <td>
                    <center> 

                    <br />
                                    <asp:Label id="LabelTableau" runat="server" Font-Bold="True" Font-Size="12pt"
                                        Font-Underline="True" ForeColor="#FFFFFF" Height="1px" Text="Tableau d'amortissement :"
                                        Visible="False" Width="248px" style="color: white"></asp:Label>
                                    <asp:Button ID="ButtonDétails" runat="server" OnClick="ButtonDétails_Click"
                                        Text="Détails" Visible="False"  CssClass="myButtopetiteeffacer" />
                     </center> 
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
</td>
</tr>
</table>


 

    
 

</asp:Content>

