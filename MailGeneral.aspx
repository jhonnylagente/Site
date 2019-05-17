<%@ Page Title="" Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="MailGeneral.aspx.cs" Inherits="pages_Default2" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder1" Runat="Server">

<script type="text/javascript" src="../JSplugins/tinymce/jscripts/tiny_mce/tiny_mce.js"></script>

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
<!-- Pour restaurer la TextBox, effacer tinymce de la racine et supprimer les 2 scripts du dessus-->

<script src="http://code.jquery.com/jquery-1.9.1.min.js" type="text/javascript" language="javascript"></script> 
<script src="../Jquery/jquery.MultiFile.js" type="text/javascript" language="javascript"></script>


<asp:panel ID="infoPanel" Visible="false" runat="server">
    <br />
    <center>
        <asp:Label ID="lblInfo" runat="server"></asp:Label>
    </center>
    <br />
    <hr />
</asp:panel>
<br />
<div style="display:table">
    <div style="display:table-row">
        <div style="display:table-cell">
            &nbsp;&nbsp;Titre:
        </div>
        <div style="display:table-cell">
            <asp:TextBox ID="TBTitre" runat="server" width="500px"></asp:TextBox>
        </div>
        <br /><br />
    </div>
    <div style="display:table-row">
        <div style="display:table-cell;vertical-align:middle;" >
            &nbsp;&nbsp;Corps:
        </div>
        <div style="display:table-cell">
            <asp:TextBox ID="TBCorp" runat="server" TextMode="MultiLine" Height="10em" Width="600px" CssClass="invisible"></asp:TextBox>    
        </div>
    </div>
    <br />

    <div style="display:table-row">
        <div style="display:table-cell">
            &nbsp;&nbsp;Destinataire:&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
        <div style="display:table-cell">
            <asp:DropDownList id="DestList" runat="server">
                <asp:ListItem Selected="True" Value="3"> Nego et UltraNego </asp:ListItem>
                <asp:ListItem Value="1"> UltraNégo </asp:ListItem>
                <asp:ListItem Value="2"> Négo </asp:ListItem>
                <asp:ListItem Value="4"> Autres Clients </asp:ListItem>
                <asp:ListItem Value="5"> Tout le monde </asp:ListItem> 
            </asp:DropDownList>
        </div>
    </div>
</div>


<!-- PJ -->
<br /><hr />
<div style="display:table-row">
  <div style="display:table-cell">
        &nbsp;&nbsp;Pieces Jointes : &nbsp;&nbsp; 
    </div>
    <div style="display:table-cell">
       <asp:FileUpload ID="file_upload" class="multi" runat="server" />
        <br />   
    </div>
</div>
<br />
<hr />

<center>
    <asp:Button ID="Button1" Text="ok" class="myButtonOK cursor_link" runat="server" OnClick="envoyerMessage"  />
</center>
<br />

<script type="text/javascript">
    function verifForm() {
        $('#<%=TBCorp.ClientID %>').val($('#<%=TBCorp.ClientID %>').text($('#TBCorpFake').val()).html());
        return true;
    };
    $('#TBCorpFake').val($('#TBCorpFake').html($('#<%=TBCorp.ClientID %>').val()).text());        
</script> 


</asp:Content>

