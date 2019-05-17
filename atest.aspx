<%@ Page Language="C#" AutoEventWireup="true" CodeFile="atest.aspx.cs" Inherits="pages_atest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <script type="text/javascript">
        function distance(lat1, lon1, lat2, lon2) {
            var R = 6371; // km (change this constant to get miles)
            var dLat = (lat2 - lat1) * Math.PI / 180;
            var dLon = (lon2 - lon1) * Math.PI / 180;
            var a = Math.sin(dLat / 2) * Math.sin(dLat / 2) +
    Math.cos(lat1 * Math.PI / 180) * Math.cos(lat2 * Math.PI / 180) *
    Math.sin(dLon / 2) * Math.sin(dLon / 2);
            var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
            var d = R * c;
            if (d > 1) return Math.round(d) + "km";
            else if (d <= 1) return Math.round(d * 1000) + "m";
            return d;
        }

        document.write("<br />Returned value: " + distance(43.6, 1.433333, 48.866667, 2.333333));
   </script> 
 
    </div>
    </form>
</body>
</html>
