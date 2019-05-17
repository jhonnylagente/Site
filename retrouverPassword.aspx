<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="retrouverPassword.aspx.cs" Inherits="pages_retrouverPassword" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
    <br />
    <table style="width: 795px; height: 198px">
        <tr>
            <td rowspan="3" style="width: 3px">
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp;
            </td>
            <td rowspan="3" style="text-align: left">
   


<table style="width:570px; margin-left:120px;" cellpadding="10" cellspacing="0">
    <tr>
        <td style="width:250">
            <center><h4 class="titrecreation" style="color:#31536c;">Retrouver mon mot de passe</h4></center>
        </td>
        <td style="width:350"></td>
    </tr>
    <tr> 
        <td colspan="2"> 
            <table width="100%" border="0" cellpadding="4" cellspacing="0">
                <tr> 
                    <td valign="top" style="border:1px solid black; background-color:#F5F5F5">
                        <b>Nous allons vous envoyer votre mot de passe à votre adresse email<br /></b>
                        <b><br />Entrez votre adresse email :</b>&nbsp;
                        <asp:TextBox ID="TextBoxMail" runat="server"></asp:TextBox>
                        <div style="float:right">
                            <asp:Button ID="Button1" runat="server" Text="Envoyer" OnClick="Button1_Click" />
                        </div>
                        <br /><br />
                        <strong><span class="textrouge"><asp:Label ID="LabelError" runat="server" ForeColor="Red"></asp:Label></span></strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width:40%; background-color:#F5F5F5; border: 1px solid black">
                        <table style="width:100%" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <b>Pas encore inscrit ?</b>
                                </td>
                                <td align="right">
                                    <a href="./inscription.aspx"><strong><span class="textrouge">Nouveau compte</span></strong></a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
            </td>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
    </table>
      
    <br />
    <br />
    <br />
    <br />

</asp:Content>

