<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/pages/MasterPage.master" CodeFile="Reunions_gerer.aspx.cs" Inherits="pages_AjouterConference" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type="text/javascript">

    function checksize_field(value) {
        if(value.length>0) document.getElementById("<%=TBDate2.ClientID%>").value = value;
    }
</script>

<script src="../Jquery/jquery-1.7.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="../JSplugins/dynDateCal/jquery.dynDateTime.js"></script>
<script type="text/javascript" src="../JSplugins/dynDateCal/calendar-fr.min.js"></script>
<link rel="stylesheet" type="text/css" media="all" href="../JSplugins/dynDateCal/calendar-blue2.css"  />

<script type="text/javascript">
	jQuery(document).ready(function() {
	
		jQuery("#date input").dynDateTime({	
			showsTime: true,	
			ifFormat: "%d/%m/%Y %H:%M",										
		}); 		
	});
</script>
 <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>



    <br />
    <!-- AJOUT CONF -->
   <div class="bloc_add_conf">
    
        <table width='100%'>
            <tr>
                <!-- Titre -->
                <td colspan="2">
                    <center>
                        <div style='font-weight: bold; font-size:20px'>AJOUTER UNE REUNION</div>
                        <br />
                        <strong><asp:Label ID="LBLInfoMail" runat="server" ></asp:Label></strong>
                    </center>
                </td>
            </tr>
            <tr>
                <!-- Nego et lieu -->
                <td width='50%' valign='top'>
                <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                
                        <asp:DropDownList ID="DDL_Select_Client" CssClass="big_textbox" OnSelectedIndexChanged="Load_member" Visible="false" AutoPostBack="true" style="margin-left:5%; margin-bottom:5px"  runat="server"></asp:DropDownList>

                        <asp:TextBox ID="TBNomNego" placeholder="Nom" ReadOnly="true" CssClass="big_textbox" style="color:grey;margin-left:5%; margin-bottom:5px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  runat="server" ControlToValidate="TBNomNego" ErrorMessage="*" ValidationGroup="infosConf" ></asp:RequiredFieldValidator>
                        
                        <asp:TextBox ID="TBPrenomNego" placeholder="Prénom"  ReadOnly="true"  CssClass="big_textbox" style="color:grey;margin-left:5%; margin-bottom:5px"  runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TBPrenomNego" ErrorMessage="*" ValidationGroup="infosConf" ></asp:RequiredFieldValidator>  
                 
                        <asp:TextBox ID="TBTelNego" placeholder="Téléphone" ReadOnly="true"  CssClass="big_textbox" style="color:grey;margin-left:5%; margin-bottom:5px" runat="server"></asp:TextBox>

                        <asp:TextBox ID="TBMailNego" placeholder="Email"  ReadOnly="true"  CssClass="big_textbox" style="color:grey;margin-left:5%; margin-bottom:5px"  runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TBMailNego" runat="server" ErrorMessage="*" ValidationGroup="infosConf" ></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TBMailNego" ErrorMessage="<br/>Mail invalide" Display="dynamic"
	    ValidationExpression="^[_a-zA-Z0-9-]+(\.[_a-zA-Z0-9-]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*\.(([0-9]{1,3})|([a-zA-Z]{2,3})|(aero|coop|info|museum|name))$" />
                    
                        <asp:TextBox ID="TBAdresseConf" placeholder="Adresse de la conference*" CssClass="big_textbox" style="margin-left:5%; margin-bottom:5px"  runat="server"></asp:TextBox>     
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="TBAdresseConf" runat="server" ErrorMessage="*" ValidationGroup="infosConf"></asp:RequiredFieldValidator>
                    
                        <asp:TextBox ID="TBCPConf" placeholder="Code Postal*" CssClass="big_textbox" style="width:34%; float:left; margin-left:5%; margin-bottom:5px"  runat="server"></asp:TextBox>     
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="TBCPConf" runat="server"  style=" float:left;" ErrorMessage="*" ValidationGroup="infosConf"></asp:RequiredFieldValidator>

                        <asp:TextBox ID="TBVilleConf" placeholder="Ville*" CssClass="big_textbox" style="margin-left:7%;width:34%; float:left; margin-bottom:5px"  runat="server"></asp:TextBox>     
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="TBVilleConf" style=" float:left;" runat="server" ErrorMessage="*" ValidationGroup="infosConf"></asp:RequiredFieldValidator>
                        <br /><br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TBCPConf" ErrorMessage="<br/><br/>CP invalide" Display="dynamic" ValidationExpression="^\d{5}$" />
                
                    </ContentTemplate>
                </asp:UpdatePanel>

                </td>

                <!-- Conf et envoie -->
                <td width='50%' valign='top'>
                <div id="date"  style="float:left;width:40%;margin-left:5%">
                    <asp:TextBox ID="TBDate" onChange='javascript:checksize_field(this.value)' placeholder="Date/Heure Debut*" ReadOnly="true" CssClass="big_textbox" style=" margin-bottom:5px; width:80%"  runat="server"></asp:TextBox>    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="TBDate" runat="server" ErrorMessage="*" ValidationGroup="infosConf"></asp:RequiredFieldValidator>
                </div>  
                    <asp:DropDownList ID="DDLDuree" placeholder="Duree" CssClass="big_textbox" style="float:left;margin-left:11px; margin-bottom:5px; width:35%" runat="server">
                        <asp:ListItem Value="0">Durée</asp:ListItem>
                        <asp:ListItem Value="0">Pas de durée</asp:ListItem>
                        <asp:ListItem Value="30">0h 30</asp:ListItem>
                        <asp:ListItem Value="60">1h 00</asp:ListItem>
                        <asp:ListItem Value="90">1h 30</asp:ListItem>
                        <asp:ListItem Value="120">2h 00</asp:ListItem>
                        <asp:ListItem Value="150">2h 30</asp:ListItem>
                        <asp:ListItem Value="180">3h 00</asp:ListItem>
                        <asp:ListItem Value="210">3h 30</asp:ListItem>
                        <asp:ListItem Value="240">4h 00</asp:ListItem>
                    </asp:DropDownList>
            
                    <asp:TextBox ID="TBBody" TextMode="MultiLine"  CssClass="big_textbox" Placeholder="Description de la Conference*" style="font-family: sans-serif;font-size: 16px;margin-left:5%;width:80%" runat="server"  Height="150px" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="TBBody" runat="server" ErrorMessage="*" ValidationGroup="infosConf"></asp:RequiredFieldValidator>
                       <div style="text-align:left; margin-left:5%; color:grey; margin-bottom:5px"><i>Les champs suivis d'une astérisque * sont obligatoires</i></div>
               
                    <br /><br />
                    <center>
                        <asp:Button ID="BtnEnvoiMail" class='flat-button' style='margin-bottom:10px; width:150px' runat="server" Text="Ajouter Conference" OnClick="Add_conf" ValidationGroup="infosConf" /> 
                    </center>
                </td>
            </tr>
        </table>
        
    </div>
    <br /> 

    <!--CONFERENCES -->
    <table width="100%">
        <tr>
            <td>
              <div>
                <center>
                    <div style='font-weight: bold; font-size:20px'>VOS 10 PROCHAINES REUNIONS</div>
                </center>
                <br /><br />
                <asp:Label ID="LBLConferences" runat="server"></asp:Label>
             </div>
            </td>
        </tr>
        <tr>
            <td>
                <div>
                    <center>
                        <div style='font-weight: bold; font-size:20px'>VOS 10 DERNIERES REUNIONS </div>
                    </center>
                    <br /><br />
                    <asp:Label ID="LBLOldConferences" runat="server"></asp:Label>
                </div>
            </td>
        </tr>
    </table>
    
    <!-- Trucs invisibles -->
    <asp:TextBox ID="TBDate2" style="display:none" runat="server"></asp:TextBox> 
</asp:Content>
