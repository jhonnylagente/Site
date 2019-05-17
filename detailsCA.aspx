<%@ Page Language="C#" AutoEventWireup="true" CodeFile="detailsCA.aspx.cs" Inherits="pages_detailsCA" MasterPageFile="~/pages/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
	    .chartdiv
	    {
		    width		: 1103px;
		    height		: 250px;
		    font-size	: 11px;
	    }
    </style>

    <script type="text/javascript" src="../JavaScript/amcharts/amcharts.js"></script>
    <script type="text/javascript" src="../JavaScript/amcharts/serial.js"></script>
    <script type="text/javascript" src="../JavaScript/amcharts/light.js"></script>
    <script>
	/*
		Made by AmChart (http://www.amcharts.com)
		Graphe utilisant le template et le theme suivant : http://www.amcharts.com/demos/simple-column-chart/#theme-light
	*/
	
	    $(function(){
	var chart = AmCharts.makeChart("chartdiv2", {
    "type": "serial",
	"theme": "light",
    "legend": {
        "horizontalGap": 10,
        "maxColumns": 1,
        "position": "right",
		"useGraphSettings": true,
		"markerSize": 10
    },
    "dataProvider": [
    <%for(int i = 0; i< 11; i++)
		{
			Response.Write("{\"mois\": \""+listeMois[i]+"\",\"ventes\":" + (string)listeVisiteFicheF[i] + ", \"locations\":" + (string)listeVisiteFiche[i] + "},");
		}
		Response.Write("{\"mois\": \""+listeMois[11]+"\",\"ventes\":" + (string)listeVisiteFicheF[11] + ", \"locations\":" + (string)listeVisiteFiche[11] + "}");
        %>],
    "valueAxes": [{
        "stackType": "regular",
        "axisAlpha": 0.3,
        "gridAlpha": 0
    }],
    "graphs": [{
        "balloonText": "<b>[[title]]</b><br><span style='font-size:14px'>[[category]]: <b>[[value]]</b></span>",
        "fillAlphas": 0.8,
        "labelText": "[[value]]",
        "lineAlpha": 0.3,
        "title": "Ventes",
        "type": "column",
		"color": "#000000",
        "valueField": "ventes"
    }, {
        "balloonText": "<b>[[title]]</b><br><span style='font-size:14px'>[[category]]: <b>[[value]]</b></span>",
        "fillAlphas": 0.8,
        "labelText": "[[value]]",
        "lineAlpha": 0.3,
        "title": "Locations",
        "type": "column",
		"color": "#000000",
        "valueField": "locations"
    }],
    "categoryField": "mois",
    "categoryAxis": {
        "gridPosition": "start",
        "axisAlpha": 0,
        "gridAlpha": 0,
        "position": "left"
    },
    "export": {
    	"enabled": true
     }

});
		
		
		var chart = AmCharts.makeChart("chartdiv", {
    "type": "serial",
	"theme": "light",
    "legend": {
        "horizontalGap": 10,
        "maxColumns": 1,
        "position": "right",
		"useGraphSettings": true,
		"markerSize": 10
    },
    "dataProvider": [
    <%for(int i = 0; i< 11; i++)
		{
			Response.Write("{\"mois\": \""+listeMois[i]+"\",\"ca\":" + (string)listeVisite[i] + ", \"caF\":" + (string)listeVisiteF[i] + "},");
		}
		Response.Write("{\"mois\": \""+listeMois[11]+"\",\"ca\":" + (string)listeVisite[11] + ", \"caF\":" + (string)listeVisiteF[11] + "}");
        %>],
    "valueAxes": [{
        "stackType": "regular",
        "axisAlpha": 0.3,
        "gridAlpha": 0
    }],
    "graphs": [{
        "balloonText": "<b>[[title]]</b><br><span style='font-size:14px'>[[category]]: <b>[[value]] €</b></span>",
        "fillAlphas": 0.8,
        "labelText": "[[value]] €",
        "lineAlpha": 0.3,
        "title": "Chiffre d'affaire personnel",
        "type": "column",
		"color": "#000000",
        "valueField": "ca"
    }, {
        "balloonText": "<b>[[title]]</b><br><span style='font-size:14px'>[[category]]: <b>[[value]] €</b></span>",
        "fillAlphas": 0.8,
        "labelText": "[[value]] €",
        "lineAlpha": 0.3,
        "title": "Chiffre d'affaire filleul",
        "type": "column",
		"color": "#000000",
        "valueField": "caF"
    }],
    "categoryField": "mois",
    "categoryAxis": {
        "gridPosition": "start",
        "axisAlpha": 0,
        "gridAlpha": 0,
        "position": "left"
    },
    "export": {
    	"enabled": true
     }

});
			
		
		setTimeout(function(){$("#chartdiv a").css("opacity","0.1");},300);
		setTimeout(function(){$("#chartdiv2 a").css("opacity","0.1");},300);
	});
</script>

    <div style="float:left">
    	<br/>
	    <a href="agent.aspx?id_client=<%=Request.QueryString["id_client"]%>" style="margin-left:15px"><span class="myButtonClear" style="margin-right:0px">< Fiche négociateur</span></a>
        <br />
    </div>

    <div class="tamid" >
	    <div id="chartdiv" class="chartdiv"></div>
    	<br/>
	    Chiffre d'affaire du négociateur.
    	<br/>
	    <br/>
    	<br/>
	    <div id="chartdiv2" class="chartdiv"></div>
    	<br/>
	    Nombre de participations aux transactions.

        <div id="chartdiv3" class="chartdiv"></div>
    	<br/>
    </div>
<br/><br/>
</asp:Content>
