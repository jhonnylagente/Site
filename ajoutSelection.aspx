<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="ajoutSelection.aspx.cs" Inherits="pages_ajoutSelection" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<%
    
    try
    {
        String reference = Request.Params["ref"].ToString();
        if (Session["logged"].Equals(true))
        {
            Membre member=(Membre)Session["membre"];
            String requete = "";
            Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            try
            {
                requete = " DELETE * FROM r_client_bien  WHERE ( id_client='" + member.ID_CLIENT + "' AND ref_bien='" + reference + "')";
                c.Open();
                c.exeRequette(requete);
                c.Close();
                requete = "";
            }
            catch
            {

            }
            requete = " INSERT INTO r_client_bien values ('"+member.ID_CLIENT+"' , '"+reference+"')";
            c.Open();
            c.exeRequette(requete);
            c.Close();
            c = null;
            Response.Redirect("./affichagerecherche.aspx?Numpage=" + Session["NumPage"] + "&Tri=" + Session["Tri"] + "&Ordre=" + Session["Ordre"] + "&nbannonces=" + Session["annoncesPage"]);
        }
        else
        {
            Response.Redirect("./inscriptionAccueil.aspx");
        }
    }
    catch
    {
    }

 %>

</asp:Content>

