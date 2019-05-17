<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CS.aspx.cs" Inherits="pages_CS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
            </style>
            <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css" rel="Stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("[id$=txtSearch]").autocomplete({
                source: function (request, response) {
                         $.ajax({
                        url: '<%=ResolveUrl("~/pages/CS.aspx/Getvilles") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                //alert(item);
                                return {
                                    label: item.split('/')[1],
                                    // val: item.split('/')[1], + item.label.split('/')[1]+
                                    label: item

                                };
                            }));
                        }
                         });
                    
                },
                minLength: 2,
                select: function (e, ui) {
                    var div = document.getElementById('list_search');
                    div.innerHTML = div.innerHTML + ui.item.label.split('/')[1] + "</br>";
                    $("#txtSearch").val("");
                    return false;
                },
            }).data("autocomplete")._renderItem = function (ul, item) {
                     return $("<li>")
                    .data("item.autocomplete", item) 
                    .append("<table><tr><td><a><img src='../img_site/drapeau/" + item.label.split('/')[0] + "'/></td><td>" + item.label.split('/')[1] + "</a></td></tr></table>")
                    .appendTo(ul);
                     };
                    });
    </script>
    <h2>localité: </h2>
        <input id="txtSearch" type="text"/>
        <asp:HiddenField ID="hfCustomerId" runat="server" />
       <div id="list_search"> </div>
    <asp:Button ID="Button1" Text="Submit" runat="server" OnClick="Submit" />
    </form>
</body>
</html>

