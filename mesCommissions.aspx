<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="mesCommissions.aspx.cs" Inherits="mesCommissions" Title="Mes Commissions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .mid{margin:auto}
        .gridviewx
        {
            font-size:9pt;
        }
        .m{margin-left:100px}
        .ml{margin-left:20px}
    </style>

    <div class="tamid">
        <asp:Label ID="msg" runat="server" CssClass="rouge"></asp:Label>
    </div>
    <br />
    <!--<div class="m">

        <div class="paramValue ml">
            <span class="bold">Date de compromis<br /></span>
            <div class="taright">
            de <asp:TextBox runat="server" ID="TB_DateCompromisMin" CssClass="style2d" placeholder="JJ/MM/AAA"/><br />
            � <asp:TextBox runat="server" ID="TB_DateCompromisMax" CssClass="style2d" placeholder="JJ/MM/AAA"/>
            </div>
        </div>


        <div class="paramValue ml">
            <span class="bold">Date de signature<br /></span>
            <div class="taright">
             de <asp:TextBox runat="server" ID="TB_DateSignatureMin" CssClass="style2d" placeholder="JJ/MM/AAA"/><br />
             � <asp:TextBox runat="server" ID="TB_DateSignatureMax" CssClass="style2d" placeholder="JJ/MM/AAA"/>
            </div>
        </div>

        <div class=" clear"></div>

        <br/>
        <div class="tamid"><asp:Button ID="buttonFiltrer" class="myButton"  runat="server" OnClick="filtrer" Text="Filtrer" /></div>
		
    </div>
	-->

    <div align="right">R�sultats par page : 
        <asp:DropDownList ID="DropDownListPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ItemChange" > 
	        <asp:ListItem Value="10" Text="10" /> 
	        <asp:ListItem Value="20" Text="20" /> 
	        <asp:ListItem Value="30" Text="30" /> 
	        <asp:ListItem Value="50" Text="50" /> 
	        <asp:ListItem Value="100" Text="100" /> 
        </asp:DropDownList>
    </div>

    <div class="tamid"><asp:Label runat="server" ID="gtfo" Visible ="false" Text="Aucun r�sultat ne correspond � vos crit�res"></asp:Label></div>
    <div class="gridviewx">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true" DataKeyNames="ID" HorizontalAlign="Center"
         OnPageIndexChanging="PaginateTheData" PagerSettings-Mode="Numeric" OnRowDataBound="ReSelectSelectedRecords" AllowSorting="true" OnSorting="SortRecords" CellPadding="2" >
         <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" SortExpression="ID" HeaderStyle-CssClass="EntetAdresse" Visible="false"/>
            <asp:BoundField HeaderText="ID Vente" DataField="id_vente" SortExpression="id_vente" HeaderStyle-CssClass="EntetAdresse" />
            <asp:BoundField HeaderText="Date signature" DataField="date_signature" SortExpression="date_signature" DataFormatString="{0:d}" HeaderStyle-CssClass="EntetAdresse" />
            <asp:BoundField HeaderText="RefBien" DataField="ref_bien" SortExpression="ref_bien" HeaderStyle-CssClass="EntetAdresse" />
            <asp:BoundField HeaderText="Vendeur" DataField="prenom vendeur" SortExpression="prenom vendeur" HeaderStyle-CssClass="EntetAdresse" />
            <asp:BoundField HeaderText="Nego" DataField="prenom_client" SortExpression="prenom_client" HeaderStyle-CssClass="EntetAdresse" />
            <asp:BoundField HeaderText="ACQ" DataField="prenom" SortExpression="prenom" HeaderStyle-CssClass="EntetAdresse" />        
			<asp:TemplateField HeaderStyle-CssClass="Entet">
                <HeaderTemplate>
                    <asp:Label ID="Title" runat="server" Text='Type'></asp:Label>
                </HeaderTemplate>
                <itemtemplate> 
                    <asp:Label ID="Modifier" runat="server" Text=''></asp:Label>
                </itemtemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Commission" DataField="montant" SortExpression="montant" DataFormatString="{0:C0}" HeaderStyle-CssClass="EntetAdresse"> <ItemStyle CssClass="taright"></ItemStyle></asp:BoundField>

            <asp:TemplateField HeaderStyle-CssClass="Entet">
                <HeaderTemplate>
                    <asp:Image ID="Image1" ImageUrl="../img_site/loupe.png" CssClass="croix_rouge" runat="server" />
                </HeaderTemplate>
                <itemtemplate> 
                    <asp:Label ID="Modifier" runat="server" Text=''></asp:Label>
                </itemtemplate>
            </asp:TemplateField>
         </Columns>    
		 <pagerstyle horizontalalign="Center"/>
         </asp:GridView>
    </div>
    <br />

</asp:Content>

