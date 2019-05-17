<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hierarchie.aspx.cs" Inherits="pages_hierarchie" MasterPageFile="~/pages/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

    <script type="text/javascript">
    
        function btnIdClick(idclient) {
            $("#<%=HiddenField.ClientID %>").val(idclient);
            document.getElementById("<%=btnClickID.ClientID%>").click();
        }

        function btnOverID(idclient, pos) {
            $("#<%=HiddenFieldOver.ClientID %>").val(idclient);
            $("#<%=HiddenFieldOverPos.ClientID %>").val(pos);
            $("#<%=position.ClientID %>").val("");
            document.getElementById("<%=btnOverID.ClientID%>").click();
        }

        function displayFilleuls(pos) {
            $("#<%=position.ClientID %>").val(pos);
        }

    </script>

    <center>
        <asp:Panel runat="server" ID="panelBienvenue">         
        </asp:Panel>
    </center> 
    <br /><br />

    <asp:TextBox runat="server" ID="HiddenField" style="display:none" Text="" />
    <asp:TextBox runat="server" ID="HiddenFieldOver" style="display:none" Text="" />
    <asp:TextBox runat="server" ID="HiddenFieldOverPos" style="display:none" Text="" />
    <asp:TextBox runat="server" ID="position" style="display:none" Text="" />
    <asp:Button runat="server" ID="btnClickID" style="display:none" OnClick="onClickID" />

    <asp:Panel ID="PanelTop" runat="server">
           <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" >
                <ContentTemplate>
                    <asp:CheckBox runat="server" ID="aspCheckBoxParrain" style="display:none" Checked="false" />
                    <asp:Table id="affichageP" runat="server" CssClass="table" >
                        <asp:TableRow ID="TableRow6" runat="server" CssClass="rowtitle" >
                            <asp:TableCell ID="TableCell2" runat="server" CssClass="cell" ColumnSpan="7">
                                <font color="#333">VOS PARRAINS :</font>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow3" runat="server" CssClass="rownbf">
                            <asp:TableCell ID="TableCellP1" runat="server" CssClass="cell"></asp:TableCell>
                            <asp:TableCell ID="TableCellP2" runat="server" CssClass="cell"></asp:TableCell>
                            <asp:TableCell ID="TableCellP3" runat="server" CssClass="cell"></asp:TableCell>
                            <asp:TableCell ID="TableCellP4" runat="server" CssClass="cell"></asp:TableCell>
                            <asp:TableCell ID="TableCellP5" runat="server" CssClass="cell"></asp:TableCell>
                            <asp:TableCell ID="TableCellP6" runat="server" CssClass="cell"></asp:TableCell>
                            <asp:TableCell ID="TableCellP7" runat="server" CssClass="cell"></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow4" runat="server" CssClass="rowbis">
                            <asp:TableCell ID="TableCellP8" runat="server" CssClass="cell">1er niveau</asp:TableCell>
                            <asp:TableCell ID="TableCellP9" runat="server" CssClass="cell">2ème niveau</asp:TableCell>
                            <asp:TableCell ID="TableCellP10" runat="server" CssClass="cell">3ème niveau</asp:TableCell>
                            <asp:TableCell ID="TableCellP11" runat="server" CssClass="cell">4ème niveau</asp:TableCell>
                            <asp:TableCell ID="TableCellP12" runat="server" CssClass="cell">5ème niveau</asp:TableCell>           
                            <asp:TableCell ID="TableCellP13" runat="server" CssClass="cell">6ème niveau</asp:TableCell>
                            <asp:TableCell ID="TableCellP14" runat="server" CssClass="cell">7ème niveau</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br /><br />
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" OnLoad="displayFilleul" >
                <ContentTemplate>
                    <asp:CheckBox runat="server" ID="aspCheckBoxFilleul" style="display:none" Checked="false" />  
                    <asp:Button runat="server" ID="btnOverID" style="display:none" OnClick="onOverID" />  
                    <asp:Table id="affichageF" runat="server" CssClass="table" >
                        <asp:TableRow ID="TableRow5" runat="server" CssClass="rowtitle" >
                            <asp:TableCell ID="TableCell1" runat="server" CssClass="cell" ColumnSpan="7">
                                <font color="#333">VOS FILLEULS :</font>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow9" runat="server" CssClass="rownbf">
                            <asp:TableCell ID="TableCellNbF1" runat="server" CssClass="cell"></asp:TableCell>
                            <asp:TableCell ID="TableCellNbF2" runat="server" CssClass="cell"></asp:TableCell>
                            <asp:TableCell ID="TableCellNbF3" runat="server" CssClass="cell"></asp:TableCell>
                            <asp:TableCell ID="TableCellNbF4" runat="server" CssClass="cell"></asp:TableCell>
                            <asp:TableCell ID="TableCellNbF5" runat="server" CssClass="cell"></asp:TableCell>
                            <asp:TableCell ID="TableCellNbF6" runat="server" CssClass="cell"></asp:TableCell>
                            <asp:TableCell ID="TableCellNbF7" runat="server" CssClass="cell"></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow2" runat="server" CssClass="row" style="display:none"> 
                            <asp:TableCell ID="TableCellF1" runat="server" CssClass="cell"></asp:TableCell>
                            <asp:TableCell ID="TableCellF2" runat="server" CssClass="cell"></asp:TableCell>
                            <asp:TableCell ID="TableCellF3" runat="server" CssClass="cell"></asp:TableCell>
                            <asp:TableCell ID="TableCellF4" runat="server" CssClass="cell"></asp:TableCell>
                            <asp:TableCell ID="TableCellF5" runat="server" CssClass="cell"></asp:TableCell>
                            <asp:TableCell ID="TableCellF6" runat="server" CssClass="cell"></asp:TableCell>
                            <asp:TableCell ID="TableCellF7" runat="server" CssClass="cell"></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow1" runat="server" CssClass="rowbis">
                            <asp:TableCell ID="TableCellF8" runat="server" CssClass="cell">1er niveau</asp:TableCell>
                            <asp:TableCell ID="TableCellF9" runat="server" CssClass="cell">2ème niveau</asp:TableCell>
                            <asp:TableCell ID="TableCellF10" runat="server" CssClass="cell">3ème niveau</asp:TableCell>
                            <asp:TableCell ID="TableCellF11" runat="server" CssClass="cell">4ème niveau</asp:TableCell>
                            <asp:TableCell ID="TableCellF12" runat="server" CssClass="cell">5ème niveau</asp:TableCell>           
                            <asp:TableCell ID="TableCellF13" runat="server" CssClass="cell">6ème niveau</asp:TableCell>
                            <asp:TableCell ID="TableCellF14" runat="server" CssClass="cell">7ème niveau</asp:TableCell>
                        </asp:TableRow>   
                        <asp:TableRow ID="TableRow7" runat="server" CssClass="rowter">
                            <asp:TableCell ID="TableCellCA1" runat="server" CssClass="cell"></asp:TableCell>
                            <asp:TableCell ID="TableCellCA2" runat="server" CssClass="cell"></asp:TableCell>
                            <asp:TableCell ID="TableCellCA3" runat="server" CssClass="cell"></asp:TableCell>
                            <asp:TableCell ID="TableCellCA4" runat="server" CssClass="cell"></asp:TableCell>
                            <asp:TableCell ID="TableCellCA5" runat="server" CssClass="cell"></asp:TableCell>           
                            <asp:TableCell ID="TableCellCA6" runat="server" CssClass="cell"></asp:TableCell>
                            <asp:TableCell ID="TableCellCA7" runat="server" CssClass="cell"></asp:TableCell>
                        </asp:TableRow>   <asp:TableRow ID="TableRow8" runat="server" CssClass="rowqua">
                            <asp:TableCell ID="TableCellCATot" runat="server" CssClass="cell" ColumnSpan="7"></asp:TableCell>
                        </asp:TableRow>         
                    </asp:Table>
                </ContentTemplate>
            </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>