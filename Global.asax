<%@ Application Language="C#" %>
<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
		Application["OnlineUsers"] = 0;
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

	
	
    void Application_Error(object sender, EventArgs e)
    {
        string logDir = System.IO.Path.Combine(Server.MapPath("~"), "Logs");
        
        System.Web.HttpContext context = HttpContext.Current;
        System.Exception ex = Context.Server.GetLastError();

        PATRIMO.Outils.OutilsLog.LogError(logDir, ex);
        
    }

    //System.Threading.Timer timer = new System.Threading.Timer(new System.Threading.TimerCallback(TimerElapsed), null, new TimeSpan(0), new TimeSpan(24, 0, 0

    //    ));

    void Session_Start(object sender, EventArgs e)
    {
		
		Application.Lock();
        Application["OnlineUsers"] = (int)Application["OnlineUsers"] + 1;
        Application.UnLock();
		
        Session["NomVendeur"] = "";
        Session["lareferance"] = "";
        Session["ConnexionString"] = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        Session["NumPage"] = "1";
        Session["Tri"] = "date";
        Session["Ordre"] = "DESC";
        Session["logged"] = false;
        Session["requete"] = "";
        Session["id_ref"] = 0;
        Session["alerte"] = 0;
        Session["annoncesPage"] = 30;
        Session["annoncesPageT"] = 30;
        Session["annoncesPageA"] = 30;
        Session["annoncesPageH"] = 30;
        Session["Transaction"] = "achat";
        Session["Smin"] = "";
        Session["Smax"] = "";
        Session["Localisation"] = "";
        Session["textBoxMotCle1"] = "";
        Session["textBoxMotCle2"] = "";
        Session["textBoxMotCle3"] = "";
        Session["textBoxMotCle4"] = "";
        Session["TextBoxBudgetMin"] = "";
        Session["TextBoxBudgetMax"] = "";
        Session["textBoxSurfaceMin"] = "";              
        Session["textBoxSurfaceMax"] = "";
        Session["TextBoxSurfaceSMin"] = "";
        Session["TextBoxSurfaceSMax"] = "";
        Session["textBoxSurfaceTMin"] = "";
        Session["textBoxSurfaceTMax"] = "";
        Session["textBoxDateCreationMin"] = "";
        Session["textBoxDateCreationMax"] = "";
        Session["textBoxDateMajMin"] = "";
        Session["textBoxDateMajMax"] = "";
        Session["radioButtonAchat"] = true;
        Session["radioButtonLocation"] = false;
        Session["checkBoxPiece1"] = true;
        Session["checkBoxPiece2"] = true;
        Session["checkBoxPiece3"] = true;
        Session["checkBoxPiece4"] = true;
        Session["checkBoxPiece5"] = true;
        Session["checkBoxChambre1"] = true;
        Session["checkBoxChambre2"] = true;
        Session["checkBoxChambre3"] = true;
        Session["checkBoxChambre4"] = true;
        Session["checkBoxChambre5"] = true;
        Session["checkBoxEstimation"] = true;
        Session["checkBoxDisponible"] = true;
        Session["checkBoxOffre"] = true;
        Session["checkBoxSuspendu"] = true;
        Session["checkBoxRetire"] = true;
        Session["checkBoxCompromis"] = true;
        Session["checkBoxLibre"] = true;
        Session["checkBoxOccupe"] = true;
        Session["checkBoxLoue"] = true;
        Session["checkBoxOption"] = true;
        Session["checkBoxReserve"] = true;
        Session["checkBoxRet"] = true;
        Session["checkBoxSusp"] = true;
        Session["checkBoxAppart"] = true;
        Session["checkBoxMaison"] = true;
        Session["checkBoxTerrain"] = true;
        Session["checkBoxAutre"] = true;
		
		Session["DropDownListChoixNegociateur"] = "";
		Session["NumAgence"] = "";
		Session["LastradioButtonMesBiens"] = true;
		Session["radioButtonMesBiens"] = true;
		Session["radioButtonMonAgence"] = false;
		Session["radioButtonTousLesBiens"] = false;
		
        Session["DropDownListTypeMandat"] = "";
        Session["requeteAcq"] = "";
        Session["annoncesPageAcq"] = 10;
        Session["TransactionAcq"] = "achat";
        Session["SminAcq"] = "";
        Session["SmaxAcq"] = "";
        Session["LocalisationAcq"] = "";
		Session["textBoxAdresseBien"] = "";
        Session["textBoxMotCle1Acq"] = "";
        Session["textBoxMotCle2Acq"] = "";
        Session["textBoxMotCle3Acq"] = "";
        Session["textBoxMotCle4Acq"] = "";
        Session["TextBoxBudgetMinAcq"] = "";
        Session["TextBoxBudgetMaxAcq"] = "";
        Session["textBoxSurfaceMinAcq"] = "";
        Session["textBoxSurfaceMaxAcq"] = "";
        Session["TextBoxSurfaceSMinAcq"] = "";
        Session["TextBoxSurfaceSMaxAcq"] = "";
        Session["textBoxSurfaceTMinAcq"] = "";
        Session["textBoxSurfaceTMaxAcq"] = "";
        Session["textBoxFacadeMin"] = "";
        Session["textBoxFacadeMax"] = "";

        Session["NomVendeur2"] = "";
        Session["lareferance2"] = "";
        Session["NumPage"] = "1";
        
        Session["Smin2"] = "";
        Session["Smax2"] = "";
        Session["Localisation2"] = "";
        Session["textBoxMotCle12"] = "";
        Session["textBoxMotCle22"] = "";
        Session["textBoxMotCle32"] = "";
        Session["textBoxMotCle42"] = "";
        Session["TextBoxBudgetMin2"] = "";
        Session["TextBoxBudgetMax2"] = "";
        Session["textBoxSurfaceMin2"] = "";
        Session["textBoxSurfaceMax2"] = "";
        Session["TextBoxSurfaceSMin2"] = "";
        Session["TextBoxSurfaceSMax2"] = "";
        Session["textBoxSurfaceTMin2"] = "";
        Session["textBoxSurfaceTMax2"] = "";
        Session["textBoxDateCreationMin2"] = "";
        Session["textBoxDateCreationMax2"] = "";
        Session["textBoxDateMajMin2"] = "";
        Session["textBoxDateMajMax2"] = "";
        Session["checkBoxPiece12"] = true;
        Session["checkBoxPiece22"] = true;
        Session["checkBoxPiece32"] = true;
        Session["checkBoxPiece42"] = true;
        Session["checkBoxPiece52"] = true;
        Session["checkBoxChambre12"] = true;
        Session["checkBoxChambre22"] = true;
        Session["checkBoxChambre32"] = true;
        Session["checkBoxChambre42"] = true;
        Session["checkBoxChambre52"] = true;

        Session["checkBoxAppart2"] = true;
        Session["checkBoxMaison2"] = true;
        Session["checkBoxTerrain2"] = true;
        Session["checkBoxAutre2"] = true;

        Session["DropDownListChoixNegociateur2"] = "";
        
        Session["DropDownListTypeMandat2"] = "";
        Session["textBoxAdresseBien2"] = "";
		
        Session["radioButtonAcheteur"] = true;
        Session["radioButtonLoueur"] = false;
        Session["checkBoxPiece1Acq"] = true;
        Session["checkBoxPiece2Acq"] = true;
        Session["checkBoxPiece3Acq"] = true;
        Session["checkBoxPiece4Acq"] = true;
        Session["checkBoxPiece5Acq"] = true;
        Session["checkBoxChambre1Acq"] = true;
        Session["checkBoxChambre2Acq"] = true;
        Session["checkBoxChambre3Acq"] = true;
        Session["checkBoxChambre4Acq"] = true;
        Session["checkBoxChambre5Acq"] = true;
        Session["checkBoxAppartAcq"] = true;
        Session["checkBoxMaisonAcq"] = true;
        Session["checkBoxTerrainAcq"] = true;
        Session["checkBoxAutreAcq"] = true;
        Session["dropDownListEtat"] = "";
        Session["checkBoxAsc"] = true;
        Session["checkBoxSous"] = true;
        Session["checkBoxPark"] = true;
        Session["textBoxNom1"] = "";
        Session["textBoxPrenom1"] = "";
        Session["textBoxTel"] = "";
        Session["textBoxPortable"] = "";
        Session["textBoxMail"] = "";
        Session["TextBoxBudgetMinR"] = "";
        Session["TextBoxBudgetMaxR"] = "";
        Session["SminR"] = "";
        Session["SmaxR"] = "";
        Session["MotCle1R"] = "";
        Session["MotCle2R"] = "";
        Session["MotCle3R"] = "";
        Session["MotCle4R"] = "";
        Session["LocalisationR"] = "";
        Session["radioButtonAchatR"] = true;
        Session["radioButtonLocationR"] = false;
        Session["checkBoxPiece1R"] = true;
        Session["checkBoxPiece2R"] = true;
        Session["checkBoxPiece3R"] = true;
        Session["checkBoxPiece4R"] = true;
        Session["checkBoxPiece5R"] = true;
        Session["checkBoxMaisonR"] = true;
        Session["checkBoxAppartR"] = true;
        Session["checkBoxTerrainR"] = true;
        Session["checkBoxAutreR"] = true;
        Session["LocalisationR"] = "";
        Session["requeteR"] = "";
        Session["idbien"] = "";
        Session["idmandat"] = "";
        Session["idmandatRecherche"] = "";
        Session["checkBoxAsc"]=false;
        Session["checkBoxSous"] = false;
        Session["checkBoxPark"] = false;
		Session["photoA"] = "";
		Session["photoB"] = "";
		Session["photoC"] = "";
		Session["photoD"] = "";
		Session["photoE"] = "";
		Session["photoF"] = "";
		Session["photoG"] = "";
        Session["photoH"] = "";
        Session["chckBxCdC"] = false;
        Session["chckBxPrestige"] = false;
        Session["chckBxMer"] = false;
        Session["chckBxMontagne"] = false;
        Session["chckBxNeuf"] = false;
        Session["chckBxCdC2"] = false;
        Session["chckBxPrestige2"] = false;
        Session["chckBxNeuf2"] = false;
        Session["nbClientParPage"] = 9;
        Session["DDLContractuel"] = "0";
        Session["TableCell"] = "-1";
        
    }
	
    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
		
		
		Application.Lock();
        Application["OnlineUsers"] = (int)Application["OnlineUsers"] - 1;
        Application.UnLock();
    }
    
  

       
</script>
