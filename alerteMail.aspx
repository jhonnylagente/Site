<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="alerteMail.aspx.cs" Inherits="pages_alerteMail" Title="alerte Mail" %>
<%@ Register TagPrefix="uc" TagName="controlCible" Src="~/pages/controlAjoutAcquereur.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

<table class="moncompte">
    <tr>
        <td class="moncompteG1">
            <%--<b>Mes options</b>--%>
        </td>
        <td class="moncompteD1">
            <strong>Ajouter une alerte E-Mail</strong>
            <div style="margin-left:240px;width:515px;text-align:center">
                <asp:Label ID="LabelErrorLogin"  runat="server" Font-Bold="True" ForeColor="#CC3333" Visible="false" Width="350px"></asp:Label>
            </div>
        </td>
    </tr>
    
    <tr>
        <td class="moncompteG">
             <% Membre member = (Membre)Session["Membre"]; %>
            <!-- Menu de liens à gauche -->
            <%--<%if(member.STATUT == "ultranego" || member.STATUT == "nego" || member.STATUT == "nego_agence")
              { %>
            <!--#include file="./menumoncompte.aspx"-->
            <%} %>
            <%else
              { %>
            <!--#include file="./menumoncompte1.aspx"-->
            <%} %>   --%>     
        </td>
        <td  class="moncompteD_alertemail">
            <div class="Recherche">
<fieldset>
		<legend><strong class="marecherchecolor">Ma recherche</strong></legend>
  
        <table class="tablerecheche">
            <tr>
                <td>
                    <strong>Type de transaction<br />
                    </strong>
                    <asp:RadioButton ID="radioButtonAchat" runat="server"  Checked="true"  GroupName="radioButtonGroup" Font-Bold="False"  />Achat
                    <br />
                    <asp:RadioButton ID="radioButtonLocation" runat="server" Checked="false" GroupName="radioButtonGroup" />Location
                </td>
                <td>
                    <strong>Type de biens</strong><br />                
                    <asp:CheckBox ID="checkBoxMaison"  runat="server" Checked="True" Font-Bold="False" />Maison
                    <asp:CheckBox ID="checkBoxAppart"  runat="server" Checked="True" />Appartement<br />
                    <asp:CheckBox ID="checkBoxTerrain" runat="server" Checked="false" />Terrain
                    <asp:CheckBox ID="checkBoxAutre"   runat="server" Checked="false" />Autre                 
                </td>
                <td>                  
                    <strong>Nombre de pièce</strong><br />
                    <asp:CheckBox ID="checkBoxPiece1" runat="server" Checked="True" />1
                    <asp:CheckBox ID="checkBoxPiece2" runat="server" Checked="True" />2
                    <asp:CheckBox ID="checkBoxPiece3" runat="server" Checked="True" />3
                    <asp:CheckBox ID="checkBoxPiece4" runat="server" Checked="True" />4
                    <asp:CheckBox ID="checkBoxPiece5" runat="server" Checked="True" />5+
                </td>
                <td>
                    <div style="padding-left:20px">
                        Coup de coeur <asp:CheckBox ID="CBCoeur" runat="server" /> <br />
                        Prestige <asp:CheckBox ID="CBPrestige" runat="server" />  <br />
                        Neuf <asp:DropDownList ID="ListeNeuf" runat="server">
                            <asp:ListItem Value="1" Text="neuf"></asp:ListItem>
                            <asp:ListItem Value="0" Text="pas neuf"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Tous" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                        
                       
                    </div>
                </td>
            </tr>
            
            <tr>
                <td rowspan=2>        

                        <strong>Situation</strong><br />

                            <%--
                        <asp:TextBox ID="textBoxVille1" runat="server"></asp:TextBox><br />--%>
                                <uc:controlCible runat="server" ID="ucCible" />
                                <div id="xingZQYTree" class="pop">
                                    <div id="pop_title" class="pop_title" onmousedown="_enableDragForAll(event,'xingZQYTree');"
                                        title='trag popup'>
                                        <div class="pop_title_left" style="font-size: 14px">
                                            &nbsp;&nbsp;Choisir aux alentours
                                        </div>
                                        <div class="pop_title_right">
                                            <label title="close popup" onclick="document.getElementById('xingZQYTree').style.display='none';">
                                                &nbsp;X&nbsp;</label>
                                        </div>
                                    </div>
                                    <div class="pop_content">
                                        <h3 onmousemove="this.style.backgroundColor='#E6E6FA'" onmouseout="this.style.backgroundColor='#fff'"
                                            onclick="_Show('2 KM')" style = "font-size:12px">
                                            Rechercher sur &nbsp;&nbsp;2 KM <span id="suggestions2km" style = "font-size:12px"></span>
                                            <input id="suggestion2kmvalue" type="hidden" />
                                        </h3>
                                        <h3 onmousemove="this.style.backgroundColor='#E6E6FA'" onmouseout="this.style.backgroundColor='#fff'"
                                            onclick="_Show('5 KM')" style = "font-size:12px">
                                            Rechercher sur &nbsp;&nbsp;5 KM <span id="suggestions5km" style = "font-size:12px"></span>
                                            <input id="suggestion5kmvalue" type="hidden" />
                                        </h3>
                                        <h3 onmousemove="this.style.backgroundColor='#E6E6FA'" onmouseout="this.style.backgroundColor='#fff'"
                                            onclick="_Show('7 KM')" style = "font-size:12px">
                                            Rechercher sur &nbsp;&nbsp;7 KM <span id="suggestions7km" style = "font-size:12px"></span>
                                            <input id="suggestion7kmvalue" type="hidden" />
                                        </h3>
                                        <h3 onmousemove="this.style.backgroundColor='#E6E6FA'" onmouseout="this.style.backgroundColor='#fff'"
                                            onclick="_Show('10 KM')" style = "font-size:12px">
                                            Rechercher sur 10 KM <span id="suggestions10km" style = "font-size:12px"></span>
                                            <input id="suggestion10kmvalue" type="hidden" />
                                        </h3>
                                        <h3 onmousemove="this.style.backgroundColor='#E6E6FA'" onmouseout="this.style.backgroundColor='#fff'"
                                            onclick="_Show('30 KM')" style = "font-size:12px">
                                            Rechercher sur 30 KM <span id="suggestions30km" style = "font-size:12px"></span>
                                            <input id="suggestion30kmvalue" type="hidden" />
                                        </h3>
                                    </div>
                                </div>


                </td>
                <td colspan=2 class="td2">
                    <strong>Budget</strong><br />                   
                    &nbsp de &nbsp <asp:TextBox ID="TextBoxBudgetMin" runat="server" class="rechercheTextBoxPetite" MaxLength="10" style="text-align: right"></asp:TextBox> €
                    &nbsp à &nbsp <asp:TextBox ID="TextBoxBudgetMax" runat="server" class="rechercheTextBoxPetite" MaxLength="11" style="text-align: right"></asp:TextBox> €
                </td>
                
            </tr>
            <tr>
                <td colspan=2 class="td2">
                    <strong>Surface</strong><br />
                    &nbsp de &nbsp <asp:TextBox ID="textBoxSurfaceMin" runat="server"  class="rechercheTextBoxPetite" MaxLength="3" style="text-align: right"></asp:TextBox>m²
                    &nbsp à &nbsp <asp:TextBox ID="textBoxSurfaceMax" runat="server"  class="rechercheTextBoxPetite" MaxLength="11" style="text-align: right"></asp:TextBox>m²
                </td>
            </tr>
            
            <tr>
                
                <td colspan=2>                        
                    <strong>Mot clé (optionel)</strong><br />                       
                    <span>Cheminée, balcon, garage...</span><br />
                    <asp:TextBox ID="textBoxMotCle1" runat="server" Width="80px"></asp:TextBox>
                    <asp:TextBox ID="textBoxMotCle2" runat="server" Width="80px"></asp:TextBox>
                    <asp:TextBox ID="textBoxMotCle3" runat="server" Width="80px"></asp:TextBox>
                    <asp:TextBox ID="textBoxMotCle4" runat="server" Width="80px"></asp:TextBox>
                </td>
                <td >   
                    <asp:Button ID="ButtonAlerteMail" runat="server" Text="Ajouter" OnClick="ButtonAlerteMail_Click"  CssClass="myButton" /><br />
                    <asp:Button ID="ButtonAnnuler" runat="server" Text="effacer" OnClick="ButtonAnnuler_Click"  CssClass="myButton"/>
                </td>
            </tr>
            
        
        </table>
        
</fieldset>
</div>
        </td>
    </tr>
</table>
<span style=" background-color:Red;" >
            <asp:Label ID="Label1" runat="server" BorderStyle="None"></asp:Label>
        </span>
       <script src="../Jquery/jquery-1.7.2.js" type="text/javascript"></script>
    <script type="text/javascript">
        function getxy(e) {
            var a = new Array();
            var t = e.offsetTop;
            var l = e.offsetLeft;
            var w = e.offsetWidth;
            var h = e.offsetHeight;
            while (e = e.offsetParent) {
                t += e.offsetTop;
                l += e.offsetLeft;
            }
            a[0] = t;
            a[1] = l;
            a[2] = w;
            a[3] = h;
            return a;
        }
        //---------------------------------- 
        var DragForAll = {};
        function _enableDragForAll(e, toMoveObj, obj2, obj3) {
            if (DragForAll.o) {
                return false;
            }
            var clickObj = document.getElementById(toMoveObj);
            if (!clickObj) {
                return;
            }
            DragForAll.o = clickObj;
            if (document.getElementById(obj2)) {
                DragForAll.p = document.getElementById(obj2);
            }
            DragForAll.xy = getxy(DragForAll.o);
            e = e || event;
            if (!clickObj.style.left) {//=================== 
                DragForAll.xx = new Array((e.clientX - DragForAll.xy[1]), (e.clientY - DragForAll.xy[0]));
            } else {
                DragForAll.xgap = parseInt(clickObj.style.left.substring(0, clickObj.style.left.indexOf("px")));
                DragForAll.ygap = parseInt(clickObj.style.top.substring(0, clickObj.style.top.indexOf("px")));
                //=================== 
                DragForAll.xx = new Array((e.clientX - DragForAll.xgap), (e.clientY - DragForAll.ygap));
                DragForAll.xgap -= DragForAll.xy[1];
                DragForAll.ygap -= DragForAll.xy[0];
            }
            DragForAll.fitToCont = obj3;
            if (obj3) {
                DragForAll.fitArea = getxy(DragForAll.fitToCont);
            }
            return false;
        }
        function _DragObjForAll(e) {
            if (!DragForAll.o) {
                return;
            }
            e = e || event; //=================== 
            var old_left = e.clientX - DragForAll.xx[0];
            var old_top = e.clientY - DragForAll.xx[1];

            if (DragForAll.fitToCont) {
                if ((old_left - DragForAll.xgap) - DragForAll.fitArea[1] <= 0 || old_top - DragForAll.ygap - DragForAll.fitArea[0] <= 0) {
                    return;
                }
                if (old_left - DragForAll.xgap + DragForAll.xy[2] >= DragForAll.fitArea[1] + DragForAll.fitArea[2] || old_top - DragForAll.ygap + DragForAll.xy[3] >= DragForAll.fitArea[0] + DragForAll.fitArea[3]) {
                    return;
                }
            };
            DragForAll.o.style.left = old_left + "px";
            DragForAll.o.style.top = old_top + "px";
            if (DragForAll.p) {
                DragForAll.p.style.left = (old_left + 5) + "px";
                DragForAll.p.style.top = (old_top + 5) + "px";
            }
        }
        function _releaseDragObjForAll(e) {
            DragForAll = {};
        }
        document.onmousemove = function (e) {
            _DragObjForAll(e);
        };
        document.onmouseup = function (e) {
            _releaseDragObjForAll(e);
            e = e || event;
        }

        // delete the repeated postcode
        Array.prototype.deldistinct = function () {
            var a = [], b = [];
            for (var prop in this) {
                var d = this[prop];
                if (d === a[prop]) continue;
                if (b[d] != 1) {
                    a.push(d);
                    b[d] = 1;
                }
            }
            return a;
        }

        //when click the KM line then use this function

        
    </script>
</asp:Content>
