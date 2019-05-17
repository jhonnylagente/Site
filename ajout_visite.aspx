<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="ajout_visite.aspx.cs" Inherits="pages_ajout_visite" Title="PATRIMONIUM : Mon espace client" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<% 
// Message d'acquisition de la visite
if (Request.Params["valid"] == "oui")
{
    LabelVisite.Visible = true;
    LabelVisite.Text = "Félicitations !!!";
}

%>

<table class="moncompte" >
    <tr>   
        <td class="moncompteG1">
            <b>Visites</b>
        </td>
           
        <td class="moncompteD1">                                   
            <strong>Bienvenue
            <asp:Label ID="LabelPrenom" runat="server" Text="LabelPrenom"></asp:Label>&nbsp
            <asp:Label ID="LabelNom" runat="server" Text="LabelNom"></asp:Label></strong> 
            <asp:Label ID="LabelVisite" runat="server" Font-Bold="True" class="rouge" Visible="False" ></asp:Label>                              
        </td>        
    </tr>
    
    <tr >
        <td class="moncompteG">
            <% Membre member = (Membre)Session["Membre"];%>
            <!-- Menu de liens à gauche -->
            <!--#include file="./menumoncompte.aspx"-->            
        </td>
        <td  class="moncompteD"> 
      
       <asp:Label ID="LabelMessage" class="rouge" runat="server"></asp:Label>&nbsp
       
       
<%  
/*Response.Write("<fieldset class=\"affiche_visite\">");
        Response.Write("<legend>Vous souhaitez faire visiter </legend>");

        if (Session["ref_sel"] != null)
        {
            if (Session["ref_sel"] != "")
            {
                string Ref = (string)Session["ref_sel"];
                string[] WordArray;
                string[] stringSeparators = new string[] { ";" };
                WordArray = Ref.Split(stringSeparators, StringSplitOptions.None);
                int i = 0;
                if (WordArray.Length >= 1)
                {
                    while (i < WordArray.Length)
                    {
                        String requette = "select ref, `prix de vente`, `ville du bien`, `surface habitable` from biens where `ref`='" + WordArray[i] + "'";
                        System.Data.DataSet ds = null;
                        Connexion c = null;

                        c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                        c.Open();
                        ds = c.exeRequette(requette);
                        c.Close();
                        c = null;

                        System.Data.DataRowCollection dr = ds.Tables[0].Rows;
                        foreach (System.Data.DataRow ligne in dr)
                        {
                            Response.Write(ligne["ref"].ToString() + " - " + ligne["prix de vente"].ToString() + "€" + " - " + ligne["ville du bien"].ToString() + " - " + ligne["surface habitable"].ToString() + " m2" + " <br/>");
                        }
                        i++;
                    }
                }
            }
            else
           Response.Write("Aucun bien. Choisissez en un puis cocher la case visite.");
        }
        else
            Response.Write("Aucun bien. Choisissez en un puis cocher la case visite.");
   
Response.Write("</fieldset>"); */
%> 







   
 <!-- CHOIX ACQUEREUR -->
<%Response.Write("<fieldset class=\"affiche_visite\">");
  Response.Write("<legend>Acquéreur </legend>"); 
               %>
                <asp:DropDownList ID="DropDownListAcquereurs" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ItemChange">
               </asp:DropDownList> 
               <% //Response.Write(DropDownListAcquereurs.SelectedItem.Text);  
Response.Write("</fieldset>"); %> 
 <!-- FIN CHOIX ACQUEREURS -->





 <!-- LES TROIS BOUTTONS -->
        <br />
        <asp:Button ID="ButtonEnregistrer" runat="server" Text="Enregistrer la visite" OnClick="ButtonImpressionBon_Click2"/>     
        <asp:Button ID="ButtonImpressionBon" runat="server" Text="Générer un bon de visite" OnClick="ButtonImpressionBon_Click1"/>
        <!-- <asp:Button ID="ButtonRecommencer" runat="server" Text="Recommencer" OnClick="ButtonImpressionBon_Click3"/> --> 
			
 <!-- FIN TROIS BOUTTONS -->
<br/>
        <asp:RadioButton ID="RadioButtonMesBiens" GroupName="displayTupe" runat="server" Text="Mes biens" AutoPostBack="true"/>
		<%           
			if(int.Parse(member.NUM_AGENCE) < 999 && int.Parse(member.NUM_AGENCE) >0)
			{
			%>
				<asp:RadioButton ID="RadioButtonMonAgence" GroupName="displayTupe" runat="server" Text="Mon agence" AutoPostBack="true"/>
		 <% } %>
                <asp:RadioButton ID="RadioButtonTousLesBiens" GroupName="displayTupe" runat="server" Text="Tous les biens" AutoPostBack="true"/>
  
  
  
 <!-- RADIOBUTTON pour affcher mes biens / tous les biens>
             <asp:PlaceHolder id="Place" runat="server"/>
             
FIN RADIOBUTTON  -->            
     
     
     
     
     
<!-- TABLEAU DES BIENS A VISITER -->
   <asp:Table class="tableaubilan" ID="TablePlanif" runat="server"></asp:Table>
<br />
</td>     
<!-- FIN DU TABLEAU -->     
          
          
          
          
</tr>
</table>
   
</asp:Content>

