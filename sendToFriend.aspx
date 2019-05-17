<% @ Page Language="C#"  AutoEventWireup="true" CodeFile="sendToFriend.aspx.cs" Inherits="pages_sendAtFriend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">
    <title>site de l'agence immobili&eacute;re Patrimo Colombes</title>
    </head>
    
    <style type="text/css">
        .rouge
        {
        	color:Red;
        	font-weight:bold;
        }    	
    </style>
    
    <body>
    <form id="form1" runat="server">

        <asp:Label ID="LabelEnvoi" class="rouge" runat="server"></asp:Label>&nbsp
        
        <div style="width:410px;height:410px;" runat="server">
            <div style="width:410px;height:40px;text-align:center;margin-bottom:30px;color:#31536c;font-size:20px;font-weight:bold;border:0px;border-bottom:1px;border-style:solid;border-color:black">
                Envoyer cette annonce à un ami
            </div>
            <div style="float:left;width:120px;height:360px"> 
                <div style="float:left;width:118px;height:30px">
                    Son prénom
                </div>
                <div style="float:left;width:118px;height:30px">
                    Son mail
                </div>
                <div style="float:left;width:118px;height:100px">
                    Votre message
                </div>
                <div style="float:left;width:118px;height:30px">
                    Votre prénom
                </div>
            </div>
            
            
            <div style="float:right;width:280px;height:360px">
                <div style="float:left;width:278px;height:30px">
                    <asp:TextBox ID="prenom1" runat="server" Width="120px"></asp:TextBox>
                </div>
                <div style="float:left;width:278px;height:30px">
                    <asp:TextBox ID="mail" runat="server" Width="120px"></asp:TextBox>
                </div>
                <div style="float:left;width:278px;height:100px">
                <asp:TextBox ID="message1" runat="server" Width="250px" TextMode="MultiLine" height="90px">Bonjour,&#13;&#10;Voici une annonce interessante que je viens de decouvrir sur www.patrimo.net :</asp:TextBox>
                </div>
                <div style="float:left;width:278px;height:30px">
                <asp:TextBox ID="prenom2" runat="server" Width="120px"></asp:TextBox>
                </div>
                <div style="float:left;width:278px;height:50px">
                    <asp:Button ID="buttontest" runat="server" Text="Envoyer" OnClick="send_Click" Width="76px" />
                </div>
            </div>
        </div>
    
   </form>
 </body>

 </html> 

