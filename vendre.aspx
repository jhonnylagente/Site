<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="vendre.aspx.cs" Inherits="vendre" Title="PATRIMONIUM : Vendre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<br />
<center><div style='font-weight: bold; font-size:20px'><asp:Label ID="lbl_titre" runat="server" /></div>
<br />
Veuillez remplir le formulaire ci-dessous afin que nous puissions traiter votre demande dans les meilleurs conditions.<br />
<asp:Label ID="Label1" runat="server" />
<br />

<div style="width:70%; background-color:#F2EDED">
<table>
    <!-- Votre bien -->
    <tr>
        <td  class="estimertitle">
            <strong>Votre bien</strong>
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="tb_type_bien" runat="server" placeholder="Type de bien (maison, appartement ...)" CssClass="big_textbox tb_vendre"></asp:TextBox>
            <br />
            
            <asp:TextBox ID="tb_adresse_bien" runat="server" placeholder="Adresse complete du bien" CssClass="big_textbox tb_vendre"></asp:TextBox><br />
            <asp:TextBox ID="tb_prix_bien" runat="server" placeholder="Prix de vente souhaité (en €)" CssClass="big_textbox tb_vendre"></asp:TextBox><br />
        </td>
        <td>
            <asp:TextBox ID="tb_surf_hab" runat="server" placeholder="Surface habitable (en m²)" CssClass="big_textbox tb_vendre"></asp:TextBox><br />
            <asp:TextBox ID="tb_surf_ter" runat="server" placeholder="Surface terrain (en m²)" CssClass="big_textbox tb_vendre"></asp:TextBox><br />
            <asp:TextBox ID="tb_nb_pieces" runat="server" placeholder="Nombre de pièces" CssClass="big_textbox tb_vendre"></asp:TextBox><br />
        </td>
    </tr>

    </table>
    <br />
</div>
<br />


<div style="width:70%; background-color:#F2EDED">
    <table>
    <!-- Vous -->
    <tr>
        <td  class="estimertitle">
        <br />
            <strong>Vos coordonnées</strong>
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="tb_nom_client" runat="server" placeholder="Votre nom" CssClass="big_textbox tb_vendre"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5"  runat="server" ControlToValidate="tb_nom_client" ErrorMessage="*" ValidationGroup="infosacq" ></asp:RequiredFieldValidator><br />
            <asp:TextBox ID="tb_prenom_client" runat="server" placeholder="Votre prénom" CssClass="big_textbox tb_vendre"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6"  runat="server" ControlToValidate="tb_prenom_client" ErrorMessage="*" ValidationGroup="infosacq" ></asp:RequiredFieldValidator><br />
            <asp:TextBox ID="tb_tel_client" runat="server" placeholder="Telephone" CssClass="big_textbox tb_vendre"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7"  runat="server" ControlToValidate="tb_tel_client" ErrorMessage="*" ValidationGroup="infosacq" ></asp:RequiredFieldValidator><br />
        </td>
        <td>
            <asp:TextBox ID="tb_mail_client" runat="server" placeholder="Adresse Email" CssClass="big_textbox tb_vendre"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8"  runat="server" ControlToValidate="tb_mail_client" ErrorMessage="*" ValidationGroup="infosacq" ></asp:RequiredFieldValidator><br />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tb_mail_client" ValidationGroup="infosacq" ErrorMessage="Mail invalide<br/>" Display="dynamic"
	ValidationExpression="^[_a-zA-Z0-9-]+(\.[_a-zA-Z0-9-]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*\.(([0-9]{1,3})|([a-zA-Z]{2,3})|(aero|coop|info|museum|name))$" />
            
            <asp:TextBox ID="tb_adresse_client" runat="server" placeholder="Adresse complete" CssClass="big_textbox tb_vendre"></asp:TextBox><br />
            <asp:TextBox ID="tb_conseiller_client" runat="server" placeholder="Nom du conseiller Patrimo" CssClass="big_textbox tb_vendre"></asp:TextBox><br />
        </td>
    </tr> 
    <!-- Message -->
    </table>
    <br />
    </div>
    <br />
<div style="width:70%; background-color:#F2EDED">
<table>
    <tr>
        <td  class="estimertitle">
        <br />
            <strong>Laissez nous un message</strong>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align:center">
         <asp:TextBox ID="tb_message" runat="server" TextMode="MultiLine" CssClass="big_textbox" placeholder="N'hesitez pas a préciser vos besoins ou ajouter des informations." style="width:585px; margin-left:5px" Height="120px"></asp:TextBox>
         <br /><br />
         Merci pour votre confiance. Nous vous recontacterons dès que possible.<br /><br />
         <asp:Button ID="btn_envoie" runat="server" Text="Envoyer" CssClass="flat-button" OnClick="Buttonvestimer_Click" ValidationGroup="infosacq" />
        
        </td>
    </tr>
</table>
<br />
</div>


</center>





   
    <script type="text/javascript">
    
    </script>
</asp:Content>
