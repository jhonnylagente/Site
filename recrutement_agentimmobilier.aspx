<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="recrutement_agentimmobilier.aspx.cs" Inherits="pages_recrutement_agentimmobilier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table cellpadding="6" cellspacing="15" style="font-size: 12pt" >
<tr><td valign="top">
<!--#include file="./recrutementmenugauche.aspx"-->
</td>
<td>
<fieldset class="fieldsetContact"> 
    <legend><strong>Nous contacter</strong></legend> 
<table>
    <tr>   
        <td valign="top">                
           	
            <table class="table_contact">  
                  
                    <tr>
                        <td style="width:50px; height: 24px;" valign="top" class="normal3"> Nom  *</td>
                        <td style="width:150px; height: 24px;"  >
                            <asp:TextBox ID="TextBoxNomrecrutement" runat="server" Width="150px"></asp:TextBox>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxNomrecrutement" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:50px" valign="top"  class="normal3">Pr&eacute;nom  *</td>
                        <td style="width:150px">
                            <asp:TextBox ID="TextBoxPrenomrecrutement" runat="server" Width="150px"></asp:TextBox>
                         <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxPrenomrecrutement" ErrorMessage="*"></asp:RequiredFieldValidator>  
                    </td>
                    </tr>           
                    <tr>
                        <td style="width:50px" valign="top" class="normal3">Téléphone  </td>
                        <td style="width:150px">
                            <asp:TextBox ID="TextBoxTelrecrutement" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:50px" valign="top" class="normal3">Email  *</td>
                        <td style="width:150px">
                            <asp:TextBox ID="TextBoxEmailrecrutement" runat="server" Width="150px"></asp:TextBox> 
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator1" ControlToValidate="TextBoxEmailrecrutement" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:50px" valign="top" class="normal3">Adresse  </td>
                        <td style="width:150px">
                            <asp:TextBox ID="TextBoxAdresserecrutement" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:50px" valign="top" class="normal3">Code Postal  </td>
                        <td style="width:150px">
                            <asp:TextBox ID="TextBoxCodePostalrecrutement" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:50px" valign="top" class="normal3">Ville  </td>
                        <td style="width:150px">
                          <asp:TextBox ID="TextBoxVillerecrutement" runat="server" Width="150px"></asp:TextBox>
                       
                        </td>        
                     </tr> 
                           

                </table>
                 <center>
                   - Les champs précédés d'une astérisque * sont obligatoires.
                  </center>
        </td>
        <td align="center" valign="top">

 
                      <table>
                            <tr>
                                <td>
                                 <strong>Ajouter votre CV (.pdf, .doc, .odt) : </strong><br /><br />
                                   
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </td>
                            </tr>
                            <tr>  
            
                                <!-- Envoie de mail -->
                                <td valign="top"> Merci de préciser votre demande:<br /> </td>
                            </tr>
                               <tr> 
                                   <td >
                                            <asp:TextBox class="textmail" ID="TextBoxmessagerecrutement" runat="server" TextMode="MultiLine"></asp:TextBox><br/>
                                            <asp:Button ID="Button1" runat="server" Text="Envoyer" OnClick="Button1_Click" /> 
                                   </td>
                               </tr>
                               <tr>
                                   <td>
                                          <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                                          <asp:Label ID="LabelError" runat="server" ForeColor="Red" Visible="False" ></asp:Label>
                                   </td>
                              </tr>
                      </table>      
         
          </td>
   </tr>
   </table>
</fieldset> 
</td>
</tr>
</table>
</asp:Content>