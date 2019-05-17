<%@ Page Language="C#" MasterPageFile ="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="afficherprofil.aspx.cs" Inherits="pages_afficherprofil" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div style="width:488px;text-align:center;height:30px;margin-left:236px">
</div>
  
<table>
    <tr>
	    <td valign="top" style="width:200px; height:530px">
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
	    </td>
	    <td valign="top" style="width:490px; height:530px">
	        <fieldset>
	            <legend>
	                <strong> Informations</strong>
	            </legend>
                <table  cellpadding="5" cellspacing="0">
                    <tr>
                        <td style="height: 3px; width: 84px;"> civilité </td>
                        <td style="height: 3px; width: 203px;">
                            <asp:Label ID="lblcivilite" runat="server" style="font-weight: 700"></asp:Label>
                        </td>
                        <td rowspan="5" style="height: 3px">
                            <asp:Image ID="Image1" runat="server" Height="131px" 
                                ImageUrl="~/img_site/001.png" Width="137px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:84px; height: 24px;" valign="top" class="normal3"> Nom </td>
                        <td style="width:203px; height: 24px;"  >
                            <asp:Label ID="lblnom" runat="server" style="font-weight: 700"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:84px" valign="top"  class="normal3">Prénom </td>
                        <td style="width:203px">
                            <asp:Label ID="lblprenom" runat="server" style="font-weight: 700"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:84px" valign="top" class="normal3">Email </td>
                        <td style="width:203px">
                            <asp:Label ID="lblemail" runat="server" style="font-weight: 700"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:84px" valign="top" class="normal3">Adresse  </td>
                        <td style="width:203px">
                            <asp:Label ID="lbladd" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:84px" valign="top" class="normal3">Code Postal  </td>
                        <td style="width:203px">
                            <asp:Label ID="lblcp" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:84px" valign="top" class="normal3">Ville  </td>
                        <td style="width:203px">
                            <asp:Label ID="lblville" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>

                        <td style="width:84px" valign="top" class="normal3">Pays </td>
                        <td style="width:203px">
                            <asp:Label ID="lblpays" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:84px" valign="top" class="normal3">Téléphone  </td>
                        <td style="width:203px">
                            <asp:Label ID="lbltel" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:84px" valign="top" class="normal3">fax  </td>
                        <td style="width:203px">
                            <asp:Label ID="lblfax" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="normal3" style="width: 84px; height: 24px;" valign="top">Société </td>
                        <td style="width: 203px; height: 24px;">
                            <asp:Label ID="lblsocie" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="normal3" style="width: 84px; height: 24px;" valign="top">Parain </td>
                        <td style="width: 203px; height: 24px;">
                            <asp:Label ID="lblparrain" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="normal3" style="width: 84px; height: 24px;" valign="top">Statut </td>
                        <td style="width: 203px; height: 24px;">
                            <asp:Label ID="lblstatus" runat="server" style="font-weight: 700" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="normal3" style="width: 84px; height: 24px;" valign="top">&nbsp;</td>
                        <td style="width: 203px; height: 24px;">
                            <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
                                Text="Retourner" Width="192px" />
                        </td>
                    </tr>
                        </table>
            </fieldset>
	    </td>
	</tr>
</table>
<div class="aumilieu" style="text-align: center;">
    - Les champs précédés d'une astérisque * sont obligatoires.
</div>	

    
    

    
</asp:Content>


