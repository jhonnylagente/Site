<%@ Page Title="" Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="MailGeneral2.aspx.cs" Inherits="pages_Default2" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder1" Runat="Server">

<script src="http://code.jquery.com/jquery-1.9.1.min.js" type="text/javascript" language="javascript"></script> 
<script src="../Jquery/jquery.MultiFile.js" type="text/javascript" language="javascript"></script>

<script type="text/javascript" src="../tinymce/jscripts/tiny_mce/tiny_mce.js"></script>

<script type="text/javascript">
    tinyMCE.init({
        mode: "textareas",
        theme: "advanced",
        plugins: "safari,spellchecker,pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template,imagemanager,filemanager",
        theme_advanced_buttons1: "newdocument,|,undo,redo,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|,styleselect,formatselect,fontselect,fontsizeselect",
        theme_advanced_buttons2: "link,unlink,image,|,code,preview,fullscreen,|,forecolor,backcolor,|,sub,sup,|,spellchecker,|,del,ins,attribs,|,template,|,hr,removeformat,visualaid,|,charmap,insertfile,insertimage,",
        theme_advanced_buttons3: "",
        theme_advanced_toolbar_location: "top",
        theme_advanced_toolbar_align: "left",
        theme_advanced_statusbar_location: "bottom",
        theme_advanced_resizing: false,
        template_external_list_url: "js/template_list.js",
        external_link_list_url: "js/link_list.js",
        external_image_list_url: "js/image_list.js",
        media_external_list_url: "js/media_list.js",
        height: 450
    });

</script>


<asp:Label runat="server" ID="LabelResultat" Text=""></asp:Label>
<asp:Button runat="server" ID="ButtonConfirmation" Visible="false" OnClick="confirmerEnvoye" Text="Confirmer"/>
<br/>
<div style="display:table">
    <div style="display:table-row">
        <div style="display:table-cell">
            &nbsp;&nbsp;Titre:
        </div>
        <div style="display:table-cell">
            <asp:TextBox ID="TBTitre" runat="server" width="500px"></asp:TextBox>
        </div>
    </div>
	<br/>
    <div style="display:table-row">
        <div style="display:table-cell;vertical-align:middle;" >
            &nbsp;&nbsp;Corps:
        </div>
        <div style="display:table-cell">
            <asp:TextBox ID="TBCorp" runat="server" TextMode="MultiLine" Height="10em" Width="500px" CssClass="invisible"></asp:TextBox>
           
        </div>
    </div>
	<br/>
    <div style="display:table-row">
        <div style="display:table-cell">
            &nbsp;&nbsp;Destinataire:&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
        <div style="display:table-cell">
            <asp:DropDownList runat="server" ID="DDLDestinataire" >
                <asp:ListItem Value="1" Text="ultraNego uniquement"></asp:ListItem>
                <asp:ListItem Value="2" Text="nego Uniquement"></asp:ListItem>
                <asp:ListItem Value="3" Text="nego et ultraNego" Selected="True"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
</div>
<br />
<hr/>
<div style="display:table-row">
  <div style="display:table-cell">
        &nbsp;&nbsp;Pieces Jointes : &nbsp;&nbsp; 
    </div>
    <div style="display:table-cell">
        <input type="file" class="multi"/>
        <br />   
    </div>
</div>


<br /><br /><br />
<div style="display:table-row">
    <div style="display:table-cell">
        <asp:Button ID="ButtonEnvoyer" Text="Envoyer" runat="server" OnClick="envoyerMail" />
    </div>
</div>
<script type="text/javascript">
    function verifForm() {
        $('#<%=TBCorp.ClientID %>').val($('#<%=TBCorp.ClientID %>').text($('#TBCorpFake').val()).html());
        return true;
    };
    $('#TBCorpFake').val($('#TBCorpFake').html($('#<%=TBCorp.ClientID %>').val()).text());
        
</script> 

</asp:Content>

