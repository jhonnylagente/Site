<%@ Page Language="C#" AutoEventWireup="true" CodeFile="listAffaires.aspx.cs" Inherits="pages_listAffaires" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <table class="table_bdv"  border="3px">
    <tr class="entete_table_bdv texte_gras">
        <td>N° dossier</td>
        <td>Mandat</td>
        <td>Type Mandat</td>
        <td>Vendeur</td>
        <td>Adresse</td>
        <td>Ville</td>
        <td>Tele.domicile</td>
        <td>Pces</td>
        <td>Chb.</td>
        <td>hab.</td>
        <td>séj.</td>
        <td>Etg.</td>
        <td>Terr.</td>
        <% if (Session["ref_sel"] != null)
           {
               if (Session["ref_sel"] != "")
               {
                   if (Session["ref_sel"].ToString().Substring(0, 1) == "L")
                   { 
                        %>
                        <td>Loyer</td>
                        <%          
                   }
                   else if (Session["ref_sel"].ToString().Substring(0, 1) == "V")
                   { 
                        %>
                        <td>Prix de vente</td>
                        <%          
                   }
                   
               }
               else
               {
                    %>
                    <td>Prix de vente</td>
                    <%
               }
           } 
        %>
    </tr>
    <%
        if (Session["ref_sel"] != null)
        {
            string Ref = (string)Session["ref_sel"];
            string[] stringSeparators = new string[] { ";" };
            string[] WordArray = Ref.Split(stringSeparators, StringSplitOptions.None);
            int i = 0;
            if (WordArray.Length >= 1)
            {
                while (i < WordArray.Length)
                {
                    String requette2 =  "select * from Biens where ref='" + WordArray[i] + "'";
                    System.Data.DataSet ds = null;
                    Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    c.Open();
                    ds = c.exeRequette(requette2);
                    c.Close();
                    c = null;

                    System.Data.DataRowCollection dr = ds.Tables[0].Rows;
                    foreach (System.Data.DataRow ligne in dr)
                    {
                        Response.Write("<tr>");
                        if (ligne["ref"].ToString().Substring(0, 1) == "V")
                            Response.Write("<td>" + ligne["ref"].ToString() + "</td><td>" + ligne["num_mandat"].ToString() + "</td><td>"  + ligne["type mandat"].ToString() + "</td><td>" + ligne["nom vendeur"].ToString() + "</td><td>" + ligne["adresse du bien"].ToString() + "</td><td>"  + ligne["ville du bien"].ToString() + "</td><td>" + ligne["tel domicile vendeur"].ToString() + "</td><td>"
                                + ligne["nombre de pieces"].ToString() + "</td><td>" + ligne["nombre de chambres"].ToString() + "</td><td>" + ligne["surface habitable"].ToString() + "</td><td>" + ligne["surface séjour"].ToString() + "</td><td>" + ligne["nombre etages"].ToString() + "</td><td>" + ligne["terrasse"].ToString() 
                                + "</td><td class=\"textright\">" + ligne["prix de vente"].ToString() + " €</td>" + " <br/>");
                        else
                            Response.Write("<td>" + ligne["ref"].ToString() + "</td><td>" + ligne["num_mandat"].ToString() + "</td><td>" + "</td><td>" + ligne["type mandat"].ToString() + "</td><td>" + ligne["nom vendeur"].ToString() + "</td><td>" + ligne["adresse du bien"].ToString() + "</td><td>" + ligne["ville du bien"].ToString() + "</td><td>" + ligne["tel domicile vendeur"].ToString() + "</td><td>"
                               + ligne["nombre de pieces"].ToString() + "</td><td>" + ligne["nombre de chambres"].ToString() + "</td><td>" + ligne["surface habitable"].ToString() + "</td><td>" + ligne["surface séjour"].ToString() + "</td><td>" + ligne["nombre etages"].ToString() + "</td><td>" + ligne["terrasse"].ToString() 
                               + "</td><td class=\"textright\">" + ligne["loyer_cc"].ToString() + " €</td>" + " <br/>");
                        Response.Write("</tr>");
                    }
                    i++;
                }
            }
        } %>
</table>
</body>
</html>
