﻿<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" CodeFile="WebForm1.aspx.cs" Inherits="pages_monCompte" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Default</title>
<script src="pop.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 110px; width: 126px">
    
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:Label ID="Label1" runat="server" Text="btnpopup"></asp:Label>
    
    </div>
    </form>
</body>
</html>
