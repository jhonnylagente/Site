<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="contact3.aspx.cs" Inherits="contact3" Title="PATRIMONIUM : Nous contacter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <br />

    <!-- INFOS CONTACT -->
    <div class="bloc_contact">
    
        <table width='100%'>
            <tr>
                <!-- Titre -->
                <td colspan=2>
                    <center>
                            <div style='font-weight: bold; font-size:20px'>CONTACTER L'AGENCE</div>
                            <br />
                            <strong><asp:Label ID="LBLInfoMail" runat="server" ></asp:Label></strong>
                    </center>
                </td>
            </tr>
            <tr>
                <!-- Formulaire -->
                <td width='50%' valign='top'>
                    <asp:TextBox ID="TextBoxNomcontact" placeholder="Nom*" CssClass="big_textbox" style="margin-left:5%; margin-bottom:5px" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxNomcontact" ErrorMessage="*"></asp:RequiredFieldValidator>
                        
                    <asp:TextBox ID="TextBoxPrenomcontact" placeholder="Prénom*" CssClass="big_textbox" style="margin-left:5%; margin-bottom:5px"  runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxPrenomcontact" ErrorMessage="*"></asp:RequiredFieldValidator>  
                 
                    <asp:TextBox ID="TextBoxTelcontact" placeholder="Téléphone" CssClass="big_textbox" style="margin-left:5%; margin-bottom:5px" runat="server"></asp:TextBox>

                    <asp:TextBox ID="TextBoxEmailcontact" placeholder="Email*" CssClass="big_textbox" style="margin-left:5%; margin-bottom:5px"  runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TextBoxEmailcontact" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                       
                    <asp:TextBox ID="TextBoxAdressecontact" placeholder="Adresse Complète" CssClass="big_textbox" style="margin-left:5%; margin-bottom:5px"  runat="server"></asp:TextBox>     

                    <div style="text-align:left; margin-left:5%; color:grey; margin-bottom:5px"><i>Les champs suivis d'une astérisque * sont obligatoires</i></div>
                </td>

                <!-- Texte et envoie -->
                <td width='50%' valign='top'>
                    <asp:TextBox ID="tbBody" TextMode="MultiLine"  CssClass="big_textbox" Placeholder="  Ecrivez votre message ici." style="font-family: sans-serif;font-size: 16px;margin-left:5%;width:88%" runat="server"  Height="200px" />
                    <br /><br />
                    <center>
                        <asp:Button ID="BtnEnvoiMail" class='flat-button' style='margin-bottom:10px' onclick="Button1_Click" runat="server" Text="Envoyer Mail" /> 
                    </center>
                </td>
            </tr>
        </table>
    </div>
    <br />

    <!-- SIEGE SOCIAL -->
     <div class="bloc_contact">
        <table width="100%">
            <tr>
                <!-- Titre -->
                <td colspan=2>
                     <center>
                        <div style='font-weight: bold; font-size:20px'>SIEGE SOCIAL</div>
                        <br />
                     </center>
                </td>
            </tr>
            <tr>
                <!-- Siege social -->
                <td style="width:50%" valign="top">
                    <center>
                        Remplissez le formulaire ci-dessus, <br /> Nous vous recontacterons afin de répondre à votre demande.
                    </center>
                    <br /> <br /> <br />
                    <img alt="vitrine de la boutique" border="0" src="../img_site/blank_patrimo.png" style="float:left; margin-left:10px; margin-right:10px" />
                   
                    <% 
                        String adresse = "", CP = "", ville = "", mail = "", telephone = "", lien_plan_google = "";
                        if (agence[1].Length > 1)
                        { adresse = agence[1] + "<br/>"; }
                        if (agence[2] != null) CP = agence[2];
                        if (agence[3] != null) ville = agence[3];
                        if (agence[4] != null) mail = agence[4];
                        if (agence[5] != null) telephone = agence[5];
                        if (agence[6] != null) lien_plan_google = agence[6];
								
                        Response.Write("<font color='#000000' size='4'>");
                        Response.Write("<strong>SAGLIO Olivier </strong><br/>"+ adresse + CP + " " + ville + "<br>" + telephone + "<br>");
                        Response.Write("<a href='mailto:info@patrimo.net'>" + mail + "</a>");
                    %>   
                </td>
                <!-- Maps -->
                <td style="width:50%" valign="top">
                    <%
                        lien_plan_google = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d11364.742628463433!2d-0.28467014533241886!3d44.59322802411773!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0xd556dee67abf07d%3A0x390cee7b436fd4ee!2s1+ter+Mounet+Sud!5e0!3m2!1sfr!2sfr!4v1525861986813";
                    %>
                    <center>
                        <iframe src="<% Response.Write(lien_plan_google); %>" width="400" height="300" frameborder="0" style="border:0" allowfullscreen></iframe>
                    </center>
                </td>
            </tr>     
        </table>

    </div>
    <br />
</asp:Content>

