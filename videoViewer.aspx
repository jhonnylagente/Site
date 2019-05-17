<%@ Page Language="C#" AutoEventWireup="true" CodeFile="videoViewer.aspx.cs" Inherits="videoViewer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>Video</title>

        <style type="text/css">

            body
            {
                background-color:#31536c;
            }

            #moduleVideo
            {
                top:15px;
                left:15px;
                bottom:15px;
                position:absolute;
            }

        </style>

</head>

<%
    //pour le debug ... a virer ...
    //<embed type="video/x-ms-asf-plugin" pluginspage="http://www.microsoft.com/Windows/Downloads/Contents/Products/MediaPlayer/" src= name="myPlayer"  autostart="1" showcontrols="1"  animationatstart="0" transparentatstart="1" allowchangedisplaysize="1" enablecontextmenu="1" width="400" height="400" showstatusbar="0"/>
%>

<body>
    <form id="form1" runat="server">
        <div id="moduleVideo">
            <object id="myPlayer" name="myPlayer" classid="CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6" width="400" height="400">
                <param name="uiMode" value="full"/>
                <param name="autoStart" value="true"/>
	            <param name="stretchToFit" value="true"/>
	            <%  	     
                    //regarde les lettres disponibles dans les dossiers de lettres : 
                    //récupération de la racine du site web :
                    Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    c.Open();
                    System.Data.DataSet ds = c.exeRequette("Select * from Environnement");
                    c.Close();
                    String racine_site = (String)ds.Tables[0].Rows[0]["Chemin_racine_site"];
                    String id_video = (String)(Request.Params["videoid"]);
                    String path_video = "http://www.patrimo.fr/videos/" + id_video.ToString() + ".wmv";
                    Response.Write("<param name=\"URL\" value=\"" + path_video + "\"/>");
                    Response.Write("<embed src=\""+path_video+"\" width=400 height=400 loop=\"false\" controller=\"true\" autoplay=\"true\" alt=\"\">");
                %>
            </object>
        </div>
    </form>
</body>

</html>
