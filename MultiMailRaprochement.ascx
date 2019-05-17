<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MultiMailRaprochement.ascx.cs" Inherits="pages_MultiMailRaprochement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head> <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
</head>
 <body>
<%
    
    List<string> listeBien = new List<string>();
    if (Session["ListeBien"] != null)
    {
        listeBien = (List<string>)Session["ListeBien"];
    }
    foreach (string idBien in listeBien)
    {
        //on donne les chaines de remplacement:
        Bien b = BienDAO.getBien(idBien);

    //en tete
    string enTeteBien;
    String type_bien = "";
    String nbpieces = "";

    if (b.CATEGORIE == "")
    {
        if (b.TYPE_BIEN == "A")
        {
            type_bien = "Appartement";
        }
        else if (b.TYPE_BIEN == "M")
        {
            type_bien = "Maison";
        }
        else if (b.TYPE_BIEN == "L")
        {
            type_bien = "Local";
        }
        else if (b.TYPE_BIEN == "T")
        {
            type_bien = "Terrain";
        }
        else if (b.TYPE_BIEN == "I")
        {
            type_bien = "Immeuble";
        }
    }
    else type_bien = b.CATEGORIE.ToString();

    if (b.NBRE_PIECE != 0)
    {
        nbpieces = b.NBRE_PIECE + " pièces - ";
    }

    if ((b.REFERENCE.Substring(0, 1) == "V"))
    {
        enTeteBien = type_bien + " - " + nbpieces + b.S_HABITABLE + " m² - " + b.CODE_POSTAL_BIEN + " " + b.VILLE_BIEN + " - " + b.PRIX_VENTE + " €";
    }
    else
    {
        enTeteBien = type_bien + " - " + nbpieces + b.S_HABITABLE + " m² - " + b.CODE_POSTAL_BIEN + " " + b.VILLE_BIEN + " - " + b.LOYER + " €";
    }
    //fin en tete

    //refBien
    String refBien = b.REFERENCE;

    //lienImageBien
    String lienImageBien;
    String path = b.REFERENCE.ToString();

    string relativePath = "/images/";
    string absolutePath = "~/images/";
    String JpgA = path + "A.JPG";

    if (testFile(absolutePath + JpgA) == false)
    {
        lienImageBien = "http://" + hote + "/img_site/images_par_defaut/" + b.TYPE_BIEN + ".jpg";
    }
    else
    {
        lienImageBien = "http://" + hote + relativePath + JpgA;
    }
    //fin lienImagebien

    //descriptionBien
    String descriptionBien = b.TEXTE_INTERNET;

    //info nego
    String infoNego = "";


    string PrenomNomNego = b.NEGOCIATEUR;
    string[] WordArray;
    string[] stringSeparators = new string[] { " " };
    WordArray = PrenomNomNego.Split(stringSeparators, StringSplitOptions.None);
    if (WordArray.Length > 1)
    {
        infoNego = "";
        String NomNego = WordArray[1];
        String PrenomNego = WordArray[0];
        System.Data.Odbc.OdbcCommand requetteNego = new System.Data.Odbc.OdbcCommand("select id_client, tel_client from Clients where `idclient`= ?");
        System.Data.Odbc.OdbcParameter paraIdClient = new System.Data.Odbc.OdbcParameter("@idClient", System.Data.DbType.String);
        paraIdClient.Value = b.IDCLIENT;
        requetteNego.Parameters.Add(paraIdClient);

        Connexion c = new Connexion();
        System.Data.DataSet dst = c.exeRequetteParametree(requetteNego);
        System.Data.DataRow ligne = dst.Tables[0].Rows[0];
            
        infoNego += PrenomNego + " " + NomNego + "<br/>"
        + "tel: " + ligne["tel_client"].ToString() + "<br/>"
        + ligne["id_client"].ToString();
    }
    //fin infoNego
    
    //fin parametres debut message
 %>       
        
    <div class="fiche" style="width:100%;
    max-width:600px;
    border-right:#000000 1px solid;
    border-top:#000000 3px solid;
    border-left:#000000 1px solid;
    height:auto;
    margin:auto;">

    <div class="ficheDetail" style="font-size:20px;
    font-family:Verdana;
    color:Black;
    background-color:White;
    width:100%;">

    <img style='margin-top:-3px;margin-bottom:-3px' src='http://<%=hote%>/img_site/drapeau/<%=b.CODEPAYS%>.png' alt='<%=b.CODEPAYS%>'/>
    <a href= 'https://www.google.fr/maps/place/<%=b.VILLE_BIEN %>+<%=b.PAYS%>' target="_blank"><img style='margin-top:-3px;margin-bottom:-3px' src='http://<%=hote%>/img_site/globe.png' alt='<%=b.VILLE_BIEN%>' height="20px" width="20px"/></a>
     
        <%=enTeteBien%>     
    </div>
    <table>
        <tr>
            <td>
                <div class="fichePhoto" style="color:White; max-width:250px; margin-right: 10px; overflow:hidden;">
                    <div class="fichePhotoGauche" style="height:100%; width:100%; margin-left:2px;">
                        <div >
                        <a href="http://<%=hote%>/pages/fichedetail1.aspx?ref=<%=refBien%>&page=2" ><img alt="" style="width:100%; max-width:250px;" id="grosseImage<%=refBien%>" src="<%=lienImageBien%>" /></a>
                        </div>
                        <br />
                    </div>
                </div>
            </td>
            <td align="justify" style="vertical-align: top; width:350px;" > 
                <p><%=descriptionBien%></p>
                <a style="text-align:left;" href="http://<%=hote%>/pages/fichedetail1.aspx?ref=<%=refBien%>&page=2">Plus d'informations</a> 
            </td>
        </tr>
    </table> 
    <table class="info_agence" style="width:100%; border-bottom : 1px solid black; border-collapse:collapse;">
            <tr>
                <td class="titre_dpe" style="font-family:Times New Roman;width:100%; font-size:12pt; border-bottom:1px solid black; vertical-align:middle;">
                    <strong>Votre contact : </strong>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="width:50px">
                    <img src="http://<%=hote%>/img_site/logoMini.jpg" alt="Patrimo" />
                </td>
                <td>
                    <%=infoNego%>
                </td>
        </tr>
        </table>
    </div>    
        
<%
}%>
</body></html>
