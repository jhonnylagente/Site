<%@ Page Language="C#" MasterPageFile="~/pages/MasterPage.master" AutoEventWireup="true" CodeFile="recrutement-old.aspx.cs" Inherits="pages_recrutement_old" Title="Recrutement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


      <table cellpadding="6" cellspacing="15" style="font-size: 12pt">
          <tr>
              <td style="width: 405px">
              
                <p>
                &nbsp; &nbsp; &nbsp;</p>
                  <p style="text-align: justify">
                      &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<strong> A</strong>ujourd’hui vous avez envie de vous lancer dans une nouvelle carrière.<br />
                Dans tous les cas vous êtes confronté au problème crucial :
                "Comment assurer la réussite et l’avenir de sa carrière professionnelle malgré 
                les incertitudes d’une vie professionnelle ?" <br />
                Bref, comment agir, se lancer dans une nouvelle voie, développer sa réussite et s’épanouir ? <br />
                A ces questions nous avons la réponse concrète<br />
                <center><img src="../img_site/\fnaim.gif"   alt="FNAIM" height="55" width="62"/><br /></center>


                <strong>&nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; P</strong>atrimonium, en partenariat avec
                      la FNAIM, &nbsp;&nbsp;apporte aux nouvelles recrues toute la formation nécessaire pour 
                apprendre le métier de l’immobilier dans les meilleures conditions. <br />
                Nous apportons aussi tous les moyens marketing pour assurer la réussite de nos futurs conseillers. &nbsp; &nbsp; &nbsp;&nbsp;<br />
                Il n’est donc pas obligatoire d’être déjà négociateur ou conseiller en immobilier pour venir nous rejoindre. Que vous soyez jeune diplômé, ou autodidacte, sénior , votre candidature nous 
                intéresse.<br />
                      &nbsp; &nbsp;&nbsp;<br />
                <strong>&nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; U</strong>ne bonne ambiance de travail, la transparence, la valorisation des performances 
                sont des valeurs que nous partageons. 
                  </p>
                  <p style="text-align: justify">
                     <strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; S</strong>aisissez votre chance, prenez votre destin en main !</p>
                  <center>&nbsp;
                <img src="../img_site/\logo_patrimonium.jpg"   alt="Patrimonuim" height="55" width="62"/></center>
                  <center>
                      &nbsp;</center>
              </td>
              <td style="text-align: center">
              <p  align ="center" style="text-align: center">
            
              
                        <b><span style="font-size: 14pt">Nos offres d'emploi</span> </b>
                        <br /><br />
                        

<strong>P</strong>atrimonuim propose de postes dans son agence à Colombes,<br /> 
</p>                    
<p align="left" style="text-align: center">
    &nbsp; &nbsp;
<strong>&nbsp;&nbsp; S</strong>i vous cherchez un poste de : <br /><br />
        <table  style=" left: 50px;width:250px; top: 0px;">
            <tr>
        &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<img src="../img_site/fleche.bmp"  width="15px" height="12px" alt=""/>Conseiller immobilier ;<br />
        &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<img src="../img_site/fleche.bmp"  width="15px" height="12px" alt=""/>Négociateur immobilier ;<br />
        &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<img src="../img_site/fleche.bmp"  width="15px" height="12px" alt=""/>Assistante commerciale ;<br />
        &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<img src="../img_site/fleche.bmp"  width="15px" height="12px" alt=""/>Responsable d'agence ;<br />
        &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<img src="../img_site/fleche.bmp"  width="15px" height="12px" alt=""/>Directeur
    des Ventes ;<br /><br />
</tr>
</table>
    

                 
                  <p align="left" style="text-align: center">
                      <strong>&nbsp; V</strong>ous pouvez&nbsp; écrire à l'agence :<br />
                      <%
                          // On va chercher les informations de l'agence dans la table environnement
                          Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                          c.Open();
                          System.Data.DataSet ds = c.exeRequette("Select * from Environnement");
                          c.Close();

                          String nom = (String)ds.Tables[0].Rows[0]["nom_societe"];
                          String adresse = (String)ds.Tables[0].Rows[0]["adresse_societe"];
                          String ville = (String)ds.Tables[0].Rows[0]["ville_societe"];
                          String cp = (String)ds.Tables[0].Rows[0]["cp_societe"];
                          String tel = (String)ds.Tables[0].Rows[0]["tel_societe"];
                          String fax = (String)ds.Tables[0].Rows[0]["fax_societe"];
                          String email = (String)ds.Tables[0].Rows[0]["email_information"];

                          Response.Write(nom + "<br />");
                          Response.Write(adresse + "<br />");
                          Response.Write(cp + "<br />");
                          Response.Write(ville + "<br />");
                          Response.Write("tel : " + tel + "<br />");
                          Response.Write("fax : " + fax + "<br />");
                          Response.Write("<a href=\"mailto:" + email + "\">" + email + "</a><br />");

                       %>
                     
                  </p>
<strong>&nbsp; &nbsp;P</strong>ar courrier ou par mail, joignez votre CV, une lettre de&nbsp; motivation
                  et une photo.

              </td>
          </tr>
      </table>
    
     
</asp:Content>