<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="fichedetail1_stats.aspx.cs" Inherits="fichedetail1_stats" Title="PATRIMONIUM : Détail de l'offre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style>
	.chartdiv
	{
		width		: 700px;
		height		: 250px;
		font-size	: 11px;
		margin		: auto;
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
	
		/******************************************
		 *Graphe des visites de la fiche detaillee.
		 ******************************************/
		
		var chart = AmCharts.makeChart("chartdiv2", {
			"type": "serial",
			"theme": "light",
			"dataProvider": [
			
<%		for(int i = 0; i< 11; i++)
		{
			Response.Write("{\"country\": \""+listeMois[i] + "\",\"visits\":" + (string)listeVisiteFiche[i] + "},");
		}
		Response.Write("{\"country\": \""+listeMois[11] + "\",\"visits\":" + (string)listeVisiteFiche[11] + "}");
%>
			
			],
			"valueAxes": [{
				"gridColor":"#FFFFFF",
				"gridAlpha": 0.2,
				"dashLength": 0
			}],
			"gridAboveGraphs": true,
			"startDuration": 1,
			"graphs": [{
				"balloonText": "visites : <b>[[value]]</b>",
				"fillAlphas": 0.8,
				"lineAlpha": 0.2,
				"type": "column",
				"valueField": "visits"		
			}],
			"chartCursor": {
				"categoryBalloonEnabled": false,
				"cursorAlpha": 0,
				"zoomable": false
			},
			"categoryField": "country",
			"categoryAxis": {
				"gridPosition": "start",
				"gridAlpha": 0,
				 "tickPosition":"start",
				 "tickLength":20
			},
			"exportConfig":{
			  "menuTop": 0,
			  "menuItems": [{
			  "icon": '/lib/3/images/export.png',
			  "format": 'png'	  
			  }]  
			}
		});
		
		
		
		/******************************************
		 *Graphe du nombre de fois ou l'annonce est apparu dans un resultat de recherche
		 ******************************************/
		
		var chart2 = AmCharts.makeChart("chartdiv", {
			"type": "serial",
			"theme": "light",
			"dataProvider": [
			
<%		for(int i = 0; i< 11; i++)
		{
			Response.Write("{\"country\": \""+listeMois[i] + "\",\"visits\":" + (string)listeVisite[i] + "},");
		}
		Response.Write("{\"country\": \""+listeMois[11] + "\",\"visits\":" + (string)listeVisite[11] + "}");
%>
			
			],
			"valueAxes": [{
				"gridColor":"#FFFFFF",
				"gridAlpha": 0.2,
				"dashLength": 0
			}],
			"gridAboveGraphs": true,
			"startDuration": 1,
			"graphs": [{
				"balloonText": "visites : <b>[[value]]</b>",
				"fillAlphas": 0.8,
				"lineAlpha": 0.2,
				"type": "column",
				"valueField": "visits"		
			}],
			"chartCursor": {
				"categoryBalloonEnabled": false,
				"cursorAlpha": 0,
				"zoomable": false
			},
			"categoryField": "country",
			"categoryAxis": {
				"gridPosition": "start",
				"gridAlpha": 0,
				 "tickPosition":"start",
				 "tickLength":20
			},
			"exportConfig":{
			  "menuTop": 0,
			  "menuItems": [{
			  "icon": '/lib/3/images/export.png',
			  "format": 'png'	  
			  }]  
			}
		});
		
		
		setTimeout(function(){$("#chartdiv a").css("opacity","0.1");},300);
		setTimeout(function(){$("#chartdiv2 a").css("opacity","0.1");},300);
	});
</script>

<div style="float:left">
	<br/>
	<a href="fichedetail1.aspx?ref=<%=Request.QueryString["ref"]%>" style="margin-left:15px"><span class="myButtonClear" style="margin-right:0px">< Fiche détaillée</span></a>
</div>

<div class="tamid" style="width: 750px; margin:auto">
	<div id="chartdiv" class="chartdiv"></div>
	<br/>
	Nombre de visite de la fiche détaillée.
	<br/>
	<br/>
	<br/>
	<div id="chartdiv2" class="chartdiv"></div>
	<br/>
	Nombre de fois où votre annonce est apparue dans les résultats d'une recherche.
</div>
<br/><br/>
</asp:Content>
