<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="statsrecherche.aspx.cs" Inherits="statsrecherche" Title="PATRIMONUIM : Statistiques recherches" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style>
table
{
	margin:auto;
}

.myButtonClear
{
	padding: 0px 5px;
}

.myButtonSelected
{
	padding: 0px 5px;
}

.chartdiv {
	width		: 500px;
	height		: 270px;
	font-size	: 11px;
}

.chartdiv2
{
	width		: 80%;
	font-size	: 11px;
}	

</style>
<script type="text/javascript" src="../Javascript/amcharts/amcharts.js"></script>
<script type="text/javascript" src="../Javascript/amcharts/serial.js"></script>
<script type="text/javascript" src="../Javascript/amcharts/light.js"></script>
<script type="text/javascript" src="../Javascript/amcharts/pie.js"></script>
<script type="text/javascript" src="../Javascript/amcharts/none.js"></script>

<script>
function makePie(container, dataID)
{
	var formatData = new Array();
	if($("#"+dataID).html() != "")
	{
		var list = $("#"+dataID).html().split(",");
		
		for(var i = 0; i < list.length ; i++)
		{
			var ligne = list[i].split(":");
			formatData.push(
				{
					"country" : ligne[0].replace("&lt;", "<"),
					"litres": parseInt(ligne[1])
				}
			);
		}
		
		
		var chart = AmCharts.makeChart(container, {
		"type": "pie",
		"theme": "none",
		 "dataProvider": formatData,
		"valueField": "litres",
		"titleField": "country",
		"exportConfig":{	
		  menuItems: [{
		  icon: '/lib/3/images/export.png',
		  format: 'png'	  
		  }]  
		}
		});
	}
}

function makeChart(container, dataID)
{
	var formatData = new Array();
	if($("#"+dataID).html() != "")
		{
		var list = $("#"+dataID).html().split(",");
		
		for(var i = 0; i < list.length ; i++)
		{
			var ligne = list[i].split(":");
			formatData.push(
				{
					"country" : ligne[0],
					"visits": parseInt(ligne[1])
				}
			);
		}
		
		
		var chart = AmCharts.makeChart(container, {
			"rotate" : "true",
			"type": "serial",
			"theme": "light",
			"dataProvider": formatData,
			"valueAxes": [{
				"gridColor":"#FFFFFF",
				"gridAlpha": 0.2,
				"dashLength": 0
			}],
			"gridAboveGraphs": true,
			"startDuration": 1,
			"graphs": [{
				"balloonText": "[[category]]: <b>[[value]]</b>",
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
	}
}

</script>

<script type="text/javascript" src="../JavaScript/ajaxStatsRecherche.js"></script>
<script>
var onglet = "#<%=ongletSelected.ClientID%>";
$(function()
{
	
	requeteAjax("3m");
	
	function hideAll()
	{
		$("#General").hide();
		$("#ville").hide();
		$("#pays").hide();
		$("#dep").hide();
	}
	
	function resetButton1()
	{
		$("#buttonGeneral").attr("class", "myButtonClear");
		$("#buttonPays").attr("class", "myButtonClear");
		$("#buttonVille").attr("class", "myButtonClear");
		$("#buttonDep").attr("class", "myButtonClear");
	}
	
	function resetButton2()
	{
		$("#troismois").attr("class", "myButtonClear");
		$("#annee").attr("class", "myButtonClear");
		$("#tout").attr("class", "myButtonClear");
	}
	
	$("#troismois").click(function(){
		if($(this).attr("class") != "myButtonSelected")
		{
			resetButton2();
			$(this).attr("class", "myButtonSelected");
			requeteAjax("3m");
		}
	});
	
	$("#annee").click(function(){
		if($(this).attr("class") != "myButtonSelected")
		{
			resetButton2();
			$(this).attr("class", "myButtonSelected");
			requeteAjax("1a");
		}
	});
	
	$("#tout").click(function(){
		if($(this).attr("class") != "myButtonSelected")
		{
			resetButton2();
			$(this).attr("class", "myButtonSelected");
			requeteAjax("");
		}
	});
	
	
	
	$("#buttonGeneral").click(function(){
		$("#<%=ongletSelected.ClientID%>").html("General");
		hideAll();
		$("#General").show();
		resetButton1();
		$(this).attr("class", "myButtonSelected");
	});
	
	$("#buttonPays").click(function(){
		$("#<%=ongletSelected.ClientID%>").html("pays");
		hideAll();
		$("#pays").show();
		resetButton1();
		$(this).attr("class", "myButtonSelected");
	});
	
	$("#buttonVille").click(function(){
		$("#<%=ongletSelected.ClientID%>").html("ville");
		hideAll();
		$("#ville").show();
		resetButton1();
		$(this).attr("class", "myButtonSelected");
	});
	
	$("#buttonDep").click(function(){
		$("#<%=ongletSelected.ClientID%>").html("dep");
		hideAll();
		$("#dep").show();
		resetButton1();
		$(this).attr("class", "myButtonSelected");
	});
	
});

</script>
<asp:Label runat="server" id="ongletSelected" Text="General" style="display:none"></asp:Label>
<div class="tamid" style="width:70%;margin:auto;">
	Statistiques :
	<span id="buttonGeneral" class="myButtonSelected">Général</span>
	<span id="buttonVille" class="myButtonClear">Ville</span>
	<span id="buttonDep" class="myButtonClear">Département</span>
	<span id="buttonPays" class="myButtonClear">Pays</span>
	<br/>
	Filtre de date : 
	<span id="troismois" class="myButtonSelected">3 Derniers mois</span>
	<span id="annee" class="myButtonClear">Dernière année</span>
	<span id="tout" class="myButtonClear">Tout</span>
	<br/>
	<br/><span class="italic">Affiche le nombre de recherches faites pour chacun des types et critères de biens.</span>
	<br/>
	<br/>
	
	<div id="mycontent">
	</div>
	<br/>
</div>
</asp:Content>

