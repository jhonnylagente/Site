<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/pages/MasterPage.master" CodeFile="agent.aspx.cs" Inherits="pages_agent" %>


<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder1" Runat="Server">

<style type="text/css">
.tooltiploupe {position: absolute;}

.tooltiploupe span
{
	display: none;
	white-space: nowrap; /* on change la valeur de la propriété white-space pour qu'il n'y ait pas de retour à la ligne non-désiré */ 
	padding: 4px;
	font-size:16pt;
}

</style>
<script type='text/javascript' src='http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js?ver=1.4.2'></script>
<script type="text/javascript" language="javascript">

    function afficher_cacher(id) {
        
        if (document.getElementById(id).style.display == "none") {
            document.getElementById(id).style.display = "block";
            document.getElementById('span_contrat').style.display = "none";
        }
        else {
            document.getElementById(id).style.display = "none";
            document.getElementById('span_contrat').style.display = "block";
        }
        return true;
    }


    function CheckFile() {

        var filePath = document.getElementById('<%= this.file_upload.ClientID %>').value;

        if (filePath.length < 1) {
            alert("Vous n'avez pas selectionné de contrat !"); return false;
        }

        var ext = filePath.substring(filePath.lastIndexOf('.') + 1).toLowerCase();
        if (ext == 'pdf') return true;

        alert('Votre fichier doit etre un pdf !');

        return false;
    }

    function OpenContract() {
        var win = window.open(window.open('../Contrats/Contrat_'+<%=idClient %>+'.pdf', '_blank'), '_blank');
        win.focus();
    }


</script>

<br />
<asp:Label ID="LBLerreur" Visible=false runat="server" />

<br />
<asp:Button ID="BtnBackToList" class='flat-button' style='margin-left:15px' onclick="BackToList" runat="server" Text="Retour à la liste" /> 
<br /><br />

<asp:Panel ID="site_nego_Panel" style="font-family:PT Sans" runat="Server" Visible="false">

  <!-- Infos generales agent -->
  <div class="bloc_agent">

  <asp:Label ID="LBLNom_nego" runat="server"/>
  <br /><br /><br /><br />
  <asp:Label ID="LBLCitation" runat="server"/>
  <br /><br /><br />
  
  </div>
  <br />

  <!-- Paneau admin -->
  <asp:Panel ID="admin_Panel" Visible="false" runat="server">
    <div class="bloc_agent">
        <br/>
        <center><div style='font-weight: bold; font-size:20px'>PANNEAU D'ADMINISTRATION</div></center>
        <br/>
        <table width="100%">
            <tr>
                <td width="30%">
                    <asp:Label ID="LBLAdmin" runat="server"/>
                    <br />
                    <center><asp:Button ID="BtnModif" class='flat-button' onclick="Modifier" runat="server" Text="Modifier Agent" /></center>
                    <br />
                    <center>                                  
                        <div id="Contract_Panel">
                            <hr />
                            <asp:label ID="LBLContract" runat="server"/>
                            <asp:FileUpload ID="file_upload" runat="server" />
                            <br /><br />
                            <asp:Button ID="Save_Contract" class='flat-button' onclick="Add_Contract" OnClientClick="return CheckFile()" runat="server" Text="Enregistrer" />
                            
                            <asp:Label ID="Show_Contract" runat="server"><br /><br /><a href="../Contrats/Contrat_<%=idClient %>.pdf" target="_blank" class='flat-button' style="color:White; font-size: 16px; font-family: Sans-Serif; padding-top:4px; padding-bottom:4px; padding-left:17px; padding-right:17px">Voir Contrat</a></asp:Label>
                            
                        </div>
                    </center>
                </td>

                <td style="padding-left:2%; vertical-align:top; border-left: 1px solid lightgrey;">
                    <center><strong>Suivi</strong></center>
                    <br/>

                    <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                         <ContentTemplate>
                             <asp:TextBox ID="TBSuivi" TextMode="MultiLine"  MaxLength='255' runat="server" Width="90%" Height="200px" />
                            <br />
                             <asp:Label ID="LBLInfoText" Visible="false" runat="server">Modifications enregistrées </asp:Label>
                            <br />
                            <center><asp:Button ID="BtnSuivi" class='flat-button' onclick="Modifier_suivi" runat="server" Text="Enregistrer" /></center>
                         </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="padding-left:2%; vertical-align:top; border-left: 1px solid lightgrey;">
                     <center><strong>Disponibilités</strong></center>
                    <br/>

                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                         <ContentTemplate>
                             <asp:TextBox ID="TBDispo" TextMode="MultiLine"  MaxLength='255' runat="server" Width="90%" Height="200px" />
                            <br />
                             <asp:Label ID="LBLInfoDispo" Visible=false runat="server">Modifications enregistrées </asp:Label>
                            <br />
                            <center><asp:Button ID="BtnDispo" class='flat-button' onclick="Modifier_dispo" runat="server" Text="Enregistrer" /></center>
                         </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <br />
        
    </div>
    <br />
  </asp:Panel>

  <!-- Panneau chiffres d'affaires -->
  <asp:Panel ID="PanelBilan" runat="server" style="display:none">
    <div class="bloc_agent">
        <br/>
        <center><div style='font-weight: bold; font-size:20px'>BILAN DU NEGOCIATEUR</div></center>
        <br/>
            <table width="100%" style="padding-left:100px">
                <tr>
                    <td colspan="5" style="text-indent:40px;">
                        <asp:TextBox runat="server" ID="caTotal" ReadOnly="true" CssClass="big_textboxreadonly" style="width:700px; color:red; resize:none" TextMode="MultiLine"/>
                    </td>
                </tr>
                <tr style="text-indent:80px;" class="fontCA">
                    <td>
                        CHIFFRE D'AFFAIRE
                    </td>
                    <td colspan="2">
                        Chiffres personnels :
                    </td>
                    <td colspan="2">
                        Chiffres filleuls :
                    </td>
                </tr>
                <tr style="text-align:center">
                    <td></td>
                    <td>Ventes</td>
                    <td>Locations</td>
                    <td>Ventes</td>
                    <td>Locations</td>
                </tr>
                <tr>
                    <td>
                        <font class="fontCA"> Mois en cours (<% if (DateTime.Now.Month == 1) Response.Write("Janvier");
                                                                if (DateTime.Now.Month == 2) Response.Write("Février");
                                                                if (DateTime.Now.Month == 3) Response.Write("Mars");
                                                                if (DateTime.Now.Month == 4) Response.Write("Avril");
                                                                if (DateTime.Now.Month == 5) Response.Write("Mai");
                                                                if (DateTime.Now.Month == 6) Response.Write("Juin");
                                                                if (DateTime.Now.Month == 7) Response.Write("Juillet");
                                                                if (DateTime.Now.Month == 8) Response.Write("Août");
                                                                if (DateTime.Now.Month == 9) Response.Write("Septembre");
                                                                if (DateTime.Now.Month == 10) Response.Write("Octobre");
                                                                if (DateTime.Now.Month == 11) Response.Write("Novembre");
                                                                if (DateTime.Now.Month == 12) Response.Write("Décembre"); %>) :</font>
                    </td>
                    <td>
                        <asp:TextBox ID="caMensuelVentes" runat="server" ReadOnly="true" CssClass="big_textboxreadonlyBis" />
                    </td>
                     <td>
                        <asp:TextBox ID="caMensuelLocations" runat="server" ReadOnly="true" CssClass="big_textboxreadonlyBis" />
                    </td>
                    <td>
                        <asp:TextBox ID="caMensuelVentesF" runat="server" ReadOnly="true" CssClass="big_textboxreadonlyBis" />
                    </td>
                     <td>
                        <asp:TextBox ID="caMensuelLocationsF" runat="server" ReadOnly="true" CssClass="big_textboxreadonlyBis" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <font class="fontCA">Trimestre en cours (<% if (DateTime.Now.Month < 4) Response.Write("T1");
                                                                   else if (DateTime.Now.Month < 7) Response.Write("T2");
                                                                   else if (DateTime.Now.Month < 10) Response.Write("T3");
                                                                   else Response.Write("T4");  %>) :
                        </font>
                    </td>
                    <td>
                        <asp:TextBox ID="caTrimestrielVentes" runat="server" ReadOnly="true" CssClass="big_textboxreadonlyBis" />
                    </td>
                    <td>
                        <asp:TextBox ID="caTrimestrielLocations" runat="server" ReadOnly="true" CssClass="big_textboxreadonlyBis" />
                    </td>
                    <td>
                        <asp:TextBox ID="caTrimestrielVentesF" runat="server" ReadOnly="true" CssClass="big_textboxreadonlyBis" />
                    </td>
                    <td>
                        <asp:TextBox ID="caTrimestrielLocationsF" runat="server" ReadOnly="true" CssClass="big_textboxreadonlyBis" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <font class="fontCA">Année en cours (<%Response.Write(DateTime.Now.Year); %>) :</font>
                    </td>
                    <td>
                        <asp:TextBox ID="caAnnuelVentes" runat="server" ReadOnly="true" CssClass="big_textboxreadonlyBis" />
                    </td>
                    <td>
                        <asp:TextBox ID="caAnnuelLocations" runat="server" ReadOnly="true" CssClass="big_textboxreadonlyBis" />
                    </td>
                    <td>
                        <asp:TextBox ID="caAnnuelVentesF" runat="server" ReadOnly="true" CssClass="big_textboxreadonlyBis" />
                    </td>
                    <td>
                        <asp:TextBox ID="caAnnuelLocationsF" runat="server" ReadOnly="true" CssClass="big_textboxreadonlyBis" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <font class="fontCA">Toute son activité :</font>
                    </td>
                    <td>
                        <asp:TextBox ID="caVentesTotal" runat="server" ReadOnly="true" CssClass="big_textboxreadonlyBis" />
                    </td>
                    <td>
                        <asp:TextBox ID="caLocationsTotal" runat="server" ReadOnly="true" CssClass="big_textboxreadonlyBis" />
                    </td>
                    <td>
                        <asp:TextBox ID="caVentesTotalF" runat="server" ReadOnly="true" CssClass="big_textboxreadonlyBis" />
                    </td>
                    <td>
                        <asp:TextBox ID="caLocationsTotalF" runat="server" ReadOnly="true" CssClass="big_textboxreadonlyBis" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <font class="fontCA">Totaux :</font>
                    </td>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="caTotA" ReadOnly="true" CssClass="big_textboxreadonly" style="color:Red" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="caTotAF" ReadOnly="true" CssClass="big_textboxreadonly" style="color:Red" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5" style="text-indent:40px">
                        <asp:TextBox runat="server" ID="nbVentes" ReadOnly="true" CssClass="big_textboxreadonly" style="color:Green; width:700px" />
                    </td>
                </tr>
                <tr style="text-indent:110px;" class="fontCA">
                    <td>
                        TRANSACTIONS
                    </td>
                    <td colspan="2">
                        Ventes :
                    </td>
                    <td colspan="2">
                        Locations :
                    </td>
                </tr>
                <tr>
                    <td>
                        <font class="fontCA">Mois en cours (<%if (DateTime.Now.Month == 1) Response.Write("Janvier");
                                                             if (DateTime.Now.Month == 2) Response.Write("Février");
                                                             if (DateTime.Now.Month == 3) Response.Write("Mars");
                                                             if (DateTime.Now.Month == 4) Response.Write("Avril");
                                                             if (DateTime.Now.Month == 5) Response.Write("Mai");
                                                             if (DateTime.Now.Month == 6) Response.Write("Juin");
                                                             if (DateTime.Now.Month == 7) Response.Write("Juillet");
                                                             if (DateTime.Now.Month == 8) Response.Write("Août");
                                                             if (DateTime.Now.Month == 9) Response.Write("Septembre");
                                                             if (DateTime.Now.Month == 10) Response.Write("Octobre");
                                                             if (DateTime.Now.Month == 11) Response.Write("Novembre");
                                                             if (DateTime.Now.Month == 12) Response.Write("Décembre"); %>) :</font>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="ventesMensuel" runat="server" ReadOnly="true" CssClass="big_textboxreadonly" style="color:Green;"/>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="locationsMensuel" runat="server" ReadOnly="true" CssClass="big_textboxreadonly" style="color:Green;"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font class="fontCA">Trimestre en cours (<% if (DateTime.Now.Month < 4) Response.Write("T1");
                                                                   else if (DateTime.Now.Month < 7) Response.Write("T2");
                                                                   else if (DateTime.Now.Month < 10) Response.Write("T3");
                                                                   else Response.Write("T4");  %>) :
                        </font>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="ventesTrimestriel" runat="server" ReadOnly="true" CssClass="big_textboxreadonly" style="color:Green;"/>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="locationsTrimestriel" runat="server" ReadOnly="true" CssClass="big_textboxreadonly" style="color:Green;"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font class="fontCA">Année en cours (<%Response.Write(DateTime.Now.Year); %>) :</font>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="ventesAnnuel" runat="server" ReadOnly="true" CssClass="big_textboxreadonly" style="color:Green;"/>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="locationsAnnuel" runat="server" ReadOnly="true" CssClass="big_textboxreadonly" style="color:Green;"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <center>
                            <asp:Button ID="btnDetailsCA" runat="server" Text="Détails des ventes" CssClass="flat-button" style="width:160px" OnClick="btnCADetails" />
                        </center>
                    </td>
                </tr>
            </table>
        <br />        
    </div>
    <br />
  </asp:Panel>

  <!-- Biens agent -->
    <div class="bloc_agent">
    <br/>
    <center><div style='font-weight: bold; font-size:20px'>LES OFFRES DU CONSEILLER</div></center>
    <br/>  
     
    <table width="100%">
        <tr>
            <td>     
                <asp:Label ID="LBLVentes" style="color:Black" runat="server"/>
                <br />
            </td> 
        </tr>
        <tr>
            <td>
                <center><asp:Button ID="BtnVoirVentes" visible="false" class='flat-button' onclick="VoirVentes" runat="server" Text="Voir plus" /></center>
            </td>
        </tr>
        <tr>
         <td>
             <asp:Label ID="LBLLocs" runat="server"/>
            </td>
        </tr>
        <tr>
            <td>
                <center><asp:Button ID="BtnVoirLocs" visible="false" class='flat-button' onclick="VoirLocs" runat="server" Text="Voir plus" /></center>
                <br /><br />
            </td>
        </tr>
    </table>
    <br />
  </div>
  <br />

  <!-- Contact agent -->
    <div class="bloc_agent">
        <br /><br />
        <center>
            <div style='font-weight: bold; font-size:20px'>CONTACTER LE CONSEILLER</div>
            <br />
            <strong><asp:Label ID="LBLInfoMail" runat="server" Visible=false></asp:Label></strong>
        </center>
        <br />
        <asp:TextBox ID="TBNom" placeholder="Nom*" CssClass="big_textbox" style="float:left;margin-left:5%" runat="server"></asp:TextBox>
        <asp:TextBox ID="TBPrenom" placeholder="Prénom*" CssClass="big_textbox" style="float:left;margin-left:5%"  runat="server"></asp:TextBox>
        <br /><br /><br />
        <asp:TextBox ID="TBTel" placeholder="Téléphone*" CssClass="big_textbox" style="float:left;margin-left:5%" runat="server"></asp:TextBox>
        <asp:TextBox ID="TBMail" placeholder="Email*" CssClass="big_textbox" style="float:left;margin-left:5%"  runat="server"></asp:TextBox>
        <br /><br /><br />
        <asp:TextBox ID="TBAdresse" placeholder="Adresse Complète" CssClass="big_textbox" style="float:left;margin-left:5%;width:88%"  runat="server"></asp:TextBox>     
        <br /><br /><br />
        <asp:TextBox ID="TBContent" TextMode="MultiLine"  CssClass="big_textbox" Placeholder="  Ecrivez votre message ici." style="font-family: sans-serif;font-size: 16px;margin-left:5%;width:88%" runat="server"  Height="200px" />
        <br />
        <div style="text-align:left; margin-left:5%; color:grey"><i>Les champs suivis d'une astérisque * sont obligatoires</i></div>
        <br /><br />
        <center>
            <asp:Button ID="BtnEnvoiMail" class='flat-button' style='margin-left:15px' onclick="EnvoiMail" runat="server" Text="Envoyer Mail" /> 
        </center>
        <br /><br />
     </div>
     <br />
     <asp:Button ID="Button1" class='flat-button' style='margin-left:15px' onclick="BackToList" runat="server" Text="Retour à la liste" /> 
     <br /><br />


</asp:Panel>

<br /><br />
</asp:Content>