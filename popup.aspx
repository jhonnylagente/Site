<%@ Page Language="C#" AutoEventWireup="true" CodeFile="popup.aspx.cs" Inherits="popup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .textbox
        {}
        #form1
        {
            height: 311px;
            width: 269px;
        }
    </style>
</head>
<body style="height: 279px; width: 265px">
    <form id="form1" runat="server">

Référence du bien:
<asp:label id="reference_bien" runat="server" CssClass="centerimage"></asp:label></br>  

Prix:
<asp:label id="Prix" runat="server" ></asp:label>€ 
</br> 
Type de bien:
<asp:label id="Type_de_bien" runat="server" ></asp:label> </br>
Localisation:
<asp:label id="Localisation" runat="server" ></asp:label> </br>

    <div style="width: 267px">        
<asp:textbox id="textarea1" runat="server" Height="140px" 
             Width="264px" TextMode="MultiLine" CssClass="textbox"></asp:textbox> 
    </div>
    <p>
<asp:button ID="btnModif" runat="server" Text="modifier memo" onclick="addnote_onclick" />

    </p>
    </form>

</body>
</html>
