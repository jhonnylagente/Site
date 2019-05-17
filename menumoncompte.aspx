            <%--<%               
                Response.Write("<div class=\"Imagecentre\"><img class=\"ImageProfilPetite\" src=\"../img_nego/" + member.IDCLIENT + "_PHOTO.jpg" + "\" /></div><br /> <br />"); 
            %>%>
            
            <%if (member.STATUT == "nego" || member.STATUT == "ultranego")
               {
            --%>          
            <a href="./completerprofil.aspx" style="cursor: hand"><img src='../img_site/fleche2.ico' border='0' width='15px' height='13px'> Ajouter une photo de profil</a><br /><br />
            <a href="./choixtransaction.aspx" style="cursor: hand"><img src='../img_site/fleche2.ico' border='0' width='15px' height='13px'> Ajouter un bien</a><br /><br />
            <a href="./moncomptetableaudebord_bis.aspx" style="cursor: hand"><img src='../img_site/fleche2.ico' border='0' width='15px' height='13px'> Tableau de bord</a><br /><br />
            <a href="./monCompteAcquereur.aspx" style="cursor: hand"><img src='../img_site/fleche2.ico' border='0' width='15px' height='13px'> Acquéreurs</a><br /><br />
            <a href="./monComptevisite.aspx" style="cursor: hand"><img src='../img_site/fleche2.ico' border='0' width='15px' height='13px'> Visites</a><br /><br /><br />
         
          <%--  }--%>
            <a href="./moncompte.aspx" style="cursor: hand"><img src='../img_site/fleche2.ico' border='0' width='15px' height='13px'> Mon compte</a><br /><br />
            <a href="./moncomteCoordonnees.aspx" style="cursor: hand"><img src='../img_site/fleche2.ico' border='0' width='15px' height='13px'> Modifier mes coordonnées</a><br /><br />
            <a href="./monCompteAlertes.aspx" style="cursor: hand"><img src='../img_site/fleche2.ico' border='0' width='15px' height='13px'> Afficher mes alertes</a><br /><br />
            <a href="./monCompteAnnonces.aspx" style="cursor: hand"><img src='../img_site/fleche2.ico' border='0' width='15px' height='13px'> Consulter ma sélection</a><br /><br /><br /><br />            
            
            
            <a href="./monCompteDeconnexion.aspx" style="cursor: hand"><img src='../img_site/fleche2.ico' border='0' width='15px' height='13px'> Se déconnecter</a>
            
            
                
           
