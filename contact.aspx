<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="contact" Title="PATRIMONIUM : Nous contacter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
<div style="width:700px;margin-left:51.5px;margin-top:10px;height:400px">
    <div style="width:300px;float:left;height:400px">
        <div style="width:300px;height:180px;border:1px">
            <a href="../img_site/cartes de visite patrimonium.zip"><img alt="Cartes de visite" border="0" height="123" src="../img_site/carte.jpg" width="196" /><br />Télécharger</a>
        </div>
        <div style="width:300px;height:220px">
            <a href="http://www.viamichelin.fr/viamichelin/fra/dyn/controller/mapPerformPage?strAddress=25+rue+gabriel+peri&strCP=92700&strLocation=colombes&strCountry=1424&image2.x=0&image2.y="><img alt="plan du quartier" border="0" height="215" src="../img_site/France.gif" width="250" /></a>
        </div>
    </div>
    <div style="float:right;width:350px;height:400px">
        <div style="border:1px solid black;width:350px;height:180px">
            <div style="float:left;width:350px;background-color:#31536c;height:22px;font-size:16px;text-align:center;color:White;font-weight: bold">
                Notre agence
            </div>
            <div style="float:left;width:150px;height:139px">
                <img alt="vitrine de la boutique" border="0" height="139" src="../img_site/facade.jpg" width="150" />    
            </div>
            <div style="float:right;width:150px;height:139px">
                <br />
                25 rue Gabriel Peri<br />
                92700 Colombes<br />
                Tél: 0146498260<br />
                Fax: 0142420302
            </div>
            
        </div>
        <div style="width:350px;height:220px">
            <center>
                <asp:Label ID="Label1" ForeColor="#CC3333" runat="server"></asp:Label><br /><br />
            </center>
            Votre email:&nbsp<asp:TextBox ID="tbExpediteur2" runat="server" Width="180px"></asp:TextBox>
                             <asp:Button ID="Button1" runat="server" Text="Envoyer" OnClick="Button1_Click" /><br />
                        &nbsp<asp:TextBox ID="tbBody" runat="server" Height="110px" Width="345px" TextMode="MultiLine"></asp:TextBox>

        </div>
    </div>
</div>
    
</asp:Content>

