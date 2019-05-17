using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Text;
using System.Data.Odbc;
using PATRIMO.Outils;
using System.Collections.Generic;
using GestionEmplacement;

/// <summary>
/// Summary description for RequeteBien
/// </summary>
[Serializable]
public class RequeteBien
{


    #region attributs

    private ListeEmplacementRecherche listeRecherche;
    private bool coupDeCoeur = true;
    private bool prestige = true;
    private int ancienPrix = 0;
    private bool mandatSimple = true;
    private bool mandatExc = true;
    private bool mandatSemExc = true;
    private bool neufOuPas = false;
    private bool neuf = false;
    private bool pubLocale = false;
    private DateTime dateEnregistrement = DateTime.Now;

    private String idClient = "";
    private int idAlerte = 0;
    private Int64 prixMin = 0;
    private Int64 prixMax = 999999999;
	private Int64 loyerMin = 0;
	private Int64 loyerMax = 9999999;
    private Int64 surfaceMin = 0;
    private Int64 surfaceMax = 9999999;
    private Int64 surfaceSMin = 0;
    private Int64 surfaceSMax = 9999999;
    private Int64 surfaceTMin = 0;
    private Int64 surfaceTMax = 99999999;
    private String typeVente = "";
    private String typeBien = "";
    private String typeMandat = "";
    private String negociateur = "";
    private DateTime dateCreationMin;
    private DateTime dateCreationMax;
    private DateTime dateMajMin;
    private DateTime dateMajMax;
    private String numAgence = "";
    private String mailVendeur = "";
	private String adresseBien = "";
	
    private Boolean piece1 = false;
    private Boolean piece2 = false;
    private Boolean piece3 = false;
    private Boolean piece4 = false;
    private Boolean piece5 = false;
    private Boolean pieceAll = false;  ///on teste pas si checkbox piece checked ou non

    private Boolean chambre1 = false;
    private Boolean chambre2 = false;
    private Boolean chambre3 = false;
    private Boolean chambre4 = false;
    private Boolean chambre5 = false;
    private Boolean chambreAll = false;  ///on teste pas si checkbox piece checked ou non

    private Boolean esti = false;
    private Boolean disp = false;
    private Boolean offr = false;
    private Boolean susp = false;
    private Boolean reti = false;
    private Boolean comp = false;
    private Boolean etatAll = false;

    private Boolean libre = false;
    private Boolean occupe = false;
    private Boolean loue = false;
    private Boolean option = false;
    private Boolean reserv = false;
    private Boolean retire = false;
    private Boolean suspen = false;
    private Boolean etatAll2 = false;

    private String dep = "";
    private String motCle1 = "";
    private String motCle2 = "";
    private String motCle3 = "";
    private String motCle4 = "";

  
    private String ville1 = "";
    //private String ville2 = "";
    //private String ville3 = "";
    //private String ville4 = "";
    private String cible = "";

    private Boolean radio0km = true;
    private Boolean radio5km = true;


    private String ville1CodeDep = "";// permet de savoir si c un code postal, departement ou le nom de la ville
    //private String ville2CodeDep = "";// permet de savoir si c un code postal, departement ou le nom de la ville
    //private String ville3CodeDep = "";// permet de savoir si c un code postal, departement ou le nom de la ville
    //private String ville4CodeDep = "";// permet de savoir si c un code postal, departement ou le nom de la ville


    private Boolean ville1Reg = false;


    private int idclient = 0;
    private int actif = 0;


    private string requeteSQLArchive = "";
    private string requeteSQLRecherche = "";
    private string requeteSQL="";
    private string requeteOrder = "";
	

    private Boolean rechercheOk = false;
    public string tel1;
	
	

    #endregion

    #region getters/setters
	
    public bool NeufOuPas
    {
        get
        {
            return neufOuPas;
        }
        set
        {
            neufOuPas = value;
        }
    }

    public DateTime DateEnregistrement
    {
        get
        {
            return dateEnregistrement;
        }
        set
        {
            dateEnregistrement = value;
        }
    }

    public String Cible
    {
        get
        {
            return cible;
        }
        set
        {
            this.cible = value;
        }
    }

    public Int64 PRIXMIN
    {
        get
        {
            return prixMin;
        }

        set
        {
            this.prixMin = value;
        }

    }
    public Int64 PRIXMAX
    {
        get
        {
            return prixMax;
        }
        set
        {
            this.prixMax = value;
        }
	}
	public Int64 LOYERMIN
    {
        get
        {
            return loyerMin;
        }

        set
        {
            this.loyerMin = value;
        }

    }
    public Int64 LOYERMAX
    {
        get
        {
            return loyerMax;
        }
        set
        {
            this.loyerMax = value;
        }
    }
    public Int64 SURFACEMIN
    {
        get
        {
            return surfaceMin;
        }
        set
        {
            this.surfaceMin = value;

        }

    }
    public Int64 SURFACEMAX
    {
        get
        {
            return surfaceMax;
        }
        set
        {
            this.surfaceMax = value;
        }
    }
    public Int64 SURFACESMIN
    {
        get
        {
            return surfaceSMin;
        }
        set
        {
            this.surfaceSMin = value;

        }

    }
    public Int64 SURFACESMAX
    {
        get
        {
            return surfaceSMax;
        }
        set
        {
            this.surfaceSMax = value;
        }
    }
    public Int64 SURFACETMIN
    {
        get
        {
            return surfaceTMin;
        }
        set
        {
            this.surfaceTMin = value;

        }

    }
    public Int64 SURFACETMAX
    {
        get
        {
            return surfaceTMax;
        }
        set
        {
            this.surfaceTMax = value;
        }
    }
    public String TYPEVENTE
    {
        get
        {
            return typeVente;
        }
        set
        {
            this.typeVente = value;
        }
    }
    public String TYPEBIEN
    {
        get
        {
            return typeBien;
        }
        set
        {
            this.typeBien = value;
        }

    }
    public String TYPEMANDAT
    {
        get
        {
            return typeMandat;
        }
        set
        {
            this.typeMandat = value;
        }

    }
    public String NEGOCIATEUR
    {
        get
        {
            return negociateur;
        }
        set
        {
            this.negociateur = value;
        }

    }
    public DateTime DATECREATIONMIN
    {
        get
        {
            return dateCreationMin;
        }
        set
        {
            this.dateCreationMin = value;
        }
    }
    public DateTime DATECREATIONMAX
    {
        get
        {
            return dateCreationMax;
        }
        set
        {
            this.dateCreationMax = value;
        }
    }
    public DateTime DATEMAJMIN
    {
        get
        {
            return dateMajMin;
        }
        set
        {
            this.dateMajMin = value;
        }
    }
    public DateTime DATEMAJMAX
    {
        get
        {
            return dateMajMax;
        }
        set
        {
            this.dateMajMax = value;
        }
    }
	
	public String ADRESSEBIEN
    {
        get
        {
            return adresseBien;
        }
        set
        {
            this.adresseBien = value;
        }
    }
	
	
	
	
	
    public String NUMAGENCE
    {
        get
        {
            return numAgence;
        }
        set
        {
            this.numAgence = value;
        }
    }
    public String MAILVENDEUR
    {
        get
        {
            return mailVendeur;
        }
        set
        {
            this.mailVendeur = value;
        }
    }
    public Boolean PIECE1
    {
        get
        {
            return piece1;
        }
        set
        {
            this.piece1 = value;
        }
    }

    public Boolean PIECE2
    {
        get
        {
            return piece2;
        }
        set
        {
            this.piece2 = value;
        }
    }
    public Boolean PIECE3
    {
        get
        {
            return piece3;
        }
        set
        {
            this.piece3 = value;
        }
    }
    public Boolean PIECE4
    {
        get
        {
            return piece4;
        }
        set
        {
            this.piece4 = value;
        }
    }
    public Boolean PIECE5
    {
        get
        {
            return piece5;
        }
        set
        {
            this.piece5 = value;
        }
    }
    public Boolean PIECE_ALL
    {
        get
        {
            return pieceAll;
        }
        set
        {
            this.pieceAll = value;
        }
    }

    public Boolean CHAMBRE1
    {
        get
        {
            return chambre1;
        }
        set
        {
            this.chambre1 = value;
        }
    }

    public Boolean CHAMBRE2
    {
        get
        {
            return chambre2;
        }
        set
        {
            this.chambre2 = value;
        }
    }
    public Boolean CHAMBRE3
    {
        get
        {
            return chambre3;
        }
        set
        {
            this.chambre3 = value;
        }
    }
    public Boolean CHAMBRE4
    {
        get
        {
            return chambre4;
        }
        set
        {
            this.chambre4 = value;
        }
    }
    public Boolean CHAMBRE5
    {
        get
        {
            return chambre5;
        }
        set
        {
            this.chambre5 = value;
        }
    }
    public Boolean CHAMBRE_ALL
    {
        get
        {
            return chambreAll;
        }
        set
        {
            this.chambreAll = value;
        }
    }

    public Boolean ESTI
    {
        get
        {
            return esti;
        }
        set
        {
            this.esti = value;
        }
    }

    public Boolean DISP
    {
        get
        {
            return disp;
        }
        set
        {
            this.disp = value;
        }
    }
    public Boolean OFFR
    {
        get
        {
            return offr;
        }
        set
        {
            this.offr = value;
        }
    }
    public Boolean SUSP
    {
        get
        {
            return susp;
        }
        set
        {
            this.susp = value;
        }
    }
    public Boolean RETI
    {
        get
        {
            return reti;
        }
        set
        {
            this.reti = value;
        }
    }
    public Boolean COMP
    {
        get
        {
            return comp;
        }
        set
        {
            this.comp = value;
        }
    }
    public Boolean ETAT_ALL
    {
        get
        {
            return etatAll;
        }
        set
        {
            this.etatAll = value;
        }
    }

    public Boolean LIBRE
    {
        get
        {
            return libre;
        }
        set
        {
            this.libre = value;
        }
    }
    public Boolean OCCUPE
    {
        get
        {
            return occupe;
        }
        set
        {
            this.occupe = value;
        }
    }

    public Boolean LOUE
    {
        get
        {
            return loue;
        }
        set
        {
            this.loue = value;
        }
    }
    public Boolean OPTION
    {
        get
        {
            return option;
        }
        set
        {
            this.option = value;
        }
    }
    public Boolean RESERV
    {
        get
        {
            return reserv;
        }
        set
        {
            this.reserv = value;
        }
    }
    public Boolean RETIRE
    {
        get
        {
            return retire;
        }
        set
        {
            this.retire = value;
        }
    }
    public Boolean SUSPEN
    {
        get
        {
            return suspen;
        }
        set
        {
            this.suspen = value;
        }
    }
    public Boolean ETAT_ALL2
    {
        get
        {
            return etatAll2;
        }
        set
        {
            this.etatAll2 = value;
        }
    }

    public String MOTCLE1
    {
        get
        {
            return motCle1;
        }
        set
        {
            this.motCle1 = value;
        }
    }
    public String MOTCLE2
    {
        get
        {
            return motCle2;
        }
        set
        {
            this.motCle2 = value;
        }
    }
    public String MOTCLE3
    {
        get
        {
            return motCle3;
        }
        set
        {
            this.motCle3 = value;
        }
    }
    public String MOTCLE4
    {
        get
        {
            return motCle4;
        }
        set
        {
            this.motCle4 = value;
        }
    }

    public String VILLE1
    {
        get
        {
            return ville1;
        }
        set
        {
            this.ville1 = value;
        }
    }
    public List<string> villepostal { get; set; }
    public string lareferance1 { get; set; }
    public string telVendeur1 { get; set; }
    public string nomvendeur1 { get;set; }


    //public String VILLE2
    //{
    //    get
    //    {
    //        return ville2;
    //    }
    //    set
    //    {
    //        this.ville2 = value;
    //    }
    //}
    //public String VILLE3
    //{
    //    get
    //    {
    //        return ville3;
    //    }
    //    set
    //    {
    //        this.ville3 = value;
    //    }
    //}
    //public String VILLE4
    //{
    //    get
    //    {
    //        return ville4;
    //    }
    //    set
    //    {
    //        this.ville4 = value;
    //    }
    //}


    public String VILLE1_CODE_DEP
    {
        get
        {
            return ville1CodeDep;
        }
        set
        {
            this.ville1CodeDep = value;
        }
    }
    //public String VILLE2_CODE_DEP
    //{
    //    get
    //    {
    //        return ville2CodeDep;
    //    }
    //    set
    //    {
    //        this.ville2CodeDep = value;
    //    }
    //}
    //public String VILLE3_CODE_DEP
    //{
    //    get
    //    {
    //        return ville3CodeDep;
    //    }
    //    set
    //    {
    //        this.ville3CodeDep = value;
    //    }
    //}
    //public String VILLE4_CODE_DEP
    //{
    //    get
    //    {
    //        return ville4CodeDep;
    //    }
    //    set
    //    {
    //        this.ville4CodeDep = value;
    //    }
    //}

    public Boolean VILLE1_REG
    {
        get
        {
            return this.ville1Reg;
        }
        set
        {
            this.ville1Reg = value;
        }
    }


    public String ID_CLIENT
    {
        get { return this.idClient; }
        set { this.idClient = value; }

    }

    public int ID_ALERTE
    {
        get { return this.idAlerte; }
        set { this.idAlerte = value; }

    }


    public int IDCLIENT
    {
        get { return this.idclient; }
        set { this.idclient = value; }

    }

    public int ACTIF
    {
        get { return this.actif; }
        set { this.actif = value;}
    }

    public String REQUETE_SQL_Archive
    {
        get
        {
            creationRequeteArchive();
            return requeteSQLArchive;
        }
    }
    public String REQUETE_SQL_Recherche
    {
        get
        {
            creationRequeteRecherche();
            return requeteSQLRecherche;
        }
    }
    public String REQUETE_SQL
    {
        get
        {
            creationRequete();
            return requeteSQL;
        }

    }
    public String REQUETE_ORDER
    {
        get
        {
            return this.requeteOrder;
        }
        set
        {
            this.requeteOrder = value;
        }
    }

    public Boolean RECHERCHE_OK
    {
        get
        {
            return rechercheOk;
        }
        set
        {
            this.rechercheOk = value;
        }
    }
    public bool COUP_DE_COEUR
    {
        get { return coupDeCoeur; }
        set { coupDeCoeur = value; }
    }
    public bool PRESTIGE
    {
        get { return prestige; }
        set { prestige = value; }
    }
    public int ANCIEN_PRIX
    {
        get { return ancienPrix; }
        set { ancienPrix = value; }
    }
    public bool MANDAT_SIMPLE
    {
        get { return mandatSimple; }
        set { mandatSimple = value; }
    }
    public bool MANDAT_EXCLUSIF
    {
        get { return mandatExc; }
        set { mandatExc = value; }
    }
    public bool MANDAT_SEMI_EXCLUSIF
    {
        get { return mandatSemExc; }
        set { mandatSemExc = value; }
    }
    public bool NEUF
    {
        get { return neuf; }
        set { neuf = value; }
    }
    public bool PUB_LOCALE
    {
        get { return pubLocale; }
        set { pubLocale = value; }
    }

    #endregion
    
    public RequeteBien()
    {

    }

    #region methode private
    private void creationRequete()
    {
        String ville = "";
		String paysb = "";
        String adresseb = " AND Biens.[adresse du bien] LIKE '%" + adresseBien + "%' ";
        String nombreDePiece = nombrePiece();
        String nombreDeChambre = nombreChambre();
        String etatDuBien = "";
		
		
        if (typeVente == "V")
        {
            etatDuBien = etatBien();
        }
        else
        {
            etatDuBien = etatBienL();
        }
        String motCle = " AND Biens.[texte internet] LIKE '%" + motCle1 +
                          "%' AND Biens.[texte internet] LIKE '%" + motCle2 +
                          "%' AND Biens.[texte internet] LIKE '%" + motCle3 +
                          "%' AND Biens.[texte internet] LIKE '%" + motCle4 + "%' ";
        #region comment
        /// Si aucune des 4 villes/code_postaux ou dep n'est renseigné alors on sort toutes les annonces
        /// sinon on filtre en fonction des critères
        ///
        /// ville = liste de Code Postaux générée à partir du critere de distance
        /// ex param="92700" result: "Biens.[code postal du bien]=CP1 AND Biens.[code postal du bien]=CP2 ...etc"
        /// la liste des codes postaux est tirée de la table ville

        //Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //StringBuilder sb = new StringBuilder();

        //c.Open();
        //sb.Append("SELECT * FROM Ville WHERE [Code Postal] IN (");

        //if (!string.IsNullOrEmpty(ville1) && ville1CodeDep == "code postal")
        //{
        //    sb.AppendFormat("{0}", ville1);
        //}
        //if (!string.IsNullOrEmpty(ville2) && ville2CodeDep == "code postal")
        //{
        //    sb.AppendFormat(",{0}", ville2);
        //}
        //if (!string.IsNullOrEmpty(ville3) && ville3CodeDep == "code postal")
        //{
        //    sb.AppendFormat(",{0}", ville3);
        //}
        //if (!string.IsNullOrEmpty(ville4) && ville4CodeDep == "code postal")
        //{
        //    sb.AppendFormat(",{0}", ville4);
        //}
        //sb.Append(")");

        //System.Data.DataSet dsvillelist = c.exeRequette(sb.ToString());
        //c.Close();
        #endregion
        Regex rCodePostal = new Regex(@"\d{5}");
        String lareferance = " AND Biens.[ref] LIKE '%" + lareferance1 + "%'";
        String leTelVendeur = " AND  Biens.[tel domicile vendeur] LIKE '%" + leTelVendeur1 + "%'";
        String nomvendeur = " Biens.[nom vendeur] LIKE '%" + nomvendeur1 + "%'";

        if (!ville1Reg)
        {
            ville = " AND Biens.[ville du bien] LIKE '%%'";
        }
        else
        {
            ville = ((ville1CodeDep.Contains("nom") ? "AND Biens.[ville du bien] Like '%" + ville1 + "%' " : ""));
            // + (ville1CodeDep.Contains("departement") ? "Biens.[code postal du bien] Like '" + ville1 + "%' " : ""));
            //+ (ville1CodeDep.Contains("code postal") ? "Biens.[code postal du bien] IN ('" + ville1 + "') " : ""));
            if (ville1CodeDep.Contains("code postal"))
            {
                ville += " AND Biens.[code postal du bien] IN (";

                foreach (string city in villepostal)
                {
                    ville += "'" + city + "',";
                }
                ville = ville.Substring(0, ville.Length - 1);

                ville += ") ";
            }

            if (ville1CodeDep.Contains("departement"))
            {
				ville += " AND ";
                foreach (string city in villepostal)
                {
                    ville += " Biens.[code postal du bien] Like '" + city + "%' OR ";
                /*
                    List<String> tmp = OutilsDistance.CPListDistance(Convert.ToInt32(city), 10, " ");
                    foreach (string tmpCP in tmp)
                    {
                        ville += " Biens.[code postal du bien] Like '" + tmpCP + "%' OR ";
                    }

                    */
                }
                ville = ville.Substring(0, ville.Length - 4);
            }
        }

        String TypeMandat = " AND Biens.[type mandat] LIKE '" + typeMandat + "%' ";       
        String budget = " AND Biens.[prix de vente] >= " + prixMin + " AND Biens.[prix de vente] <= " + prixMax;		
        String budgetlocation = " AND Biens.[loyer_cc] >= " + loyerMin + " AND Biens.[loyer_cc] <= " + loyerMax;
        String surface = " AND Biens.[surface habitable] >= " + surfaceMin + " AND Biens.[surface habitable] <=  " + surfaceMax;
        String surfaceS = " AND Biens.[surface séjour] >= " + surfaceSMin + " AND Biens.[surface séjour] <=  " + surfaceSMax;
        String surfaceT = " AND Biens.[surface terrain] >= " + surfaceTMin + " AND Biens.[surface terrain] <=  " + surfaceTMax;
        String achatVente = " AND Biens.[ref] LIKE '" + typeVente + "%' ";
        String MailVendeur;
        if (mailVendeur != null && mailVendeur != "") MailVendeur = " AND Biens.[adresse mail vendeur] LIKE '" + mailVendeur + "%' ";
        else MailVendeur = " ";
        DateTime date = new DateTime (0001, 01, 01, 00, 00, 00);
        String dateCreation = "";
        if (System.DateTime.Compare(dateCreationMax, date) != 0 && System.DateTime.Compare(dateCreationMin,date) != 0)
        {
            dateCreation = " AND Biens.[date dossier] BETWEEN #" + dateCreationMin.Day + "/" + dateCreationMin.Month + "/" + dateCreationMin.Year + "# AND #" + dateCreationMax.Day + "/" + dateCreationMax.Month + "/" + dateCreationMax.Year + "# ";
        }
        else
        {
            dateCreation = "";
        }

        String dateMaj = "";
        if (System.DateTime.Compare(dateMajMax, date) != 0 && System.DateTime.Compare(dateMajMin, date) != 0)
        {
            dateMaj = " AND Biens.[date modification] BETWEEN #" + dateMajMin.Day + "/" + dateMajMin.Month + "/" + dateMajMin.Year + "# AND #" + dateMajMax.Day + "/" + dateMajMax.Month + "/" + dateMajMax.Year + "# ";
        }
        else
        {
            dateMaj = "";
        }

        String idClientNego;
        if (idclient == 0 && actif == 0)
        { 
            if (negociateur != "")
            {
                idClientNego = "AND Biens.[actif]='actif' AND Biens.[negociateur] LIKE '%" + negociateur + "%'";
            }
            else
            {
                idClientNego = "AND Biens.[actif]='actif'";
            }
        }
        else if (idclient == 0 && actif == 1)
        {
            idClientNego = "AND Biens.[actif]='archive'";
        }
        else if (idclient == 01 && actif == 0)
        {
            idClientNego = "AND Biens.[actif]='actif' AND Biens.[num] ='" + numAgence + "' AND Biens.[negociateur] LIKE '%" + negociateur + "%'";
        }
        else if (idclient == 02 && actif == 0)
        {
            idClientNego = "AND Biens.[actif]='actif'";
        }
        else if (idclient != 0 && actif == 0)
        {
            idClientNego = "AND Biens.[actif]='actif' AND Biens.[idclient] =" + idclient;
        }
        else
		{
            idClientNego = "AND Biens.[actif]='archive' AND Biens.[idclient]  =" + idclient;
		}
        //permet de ne pas restreindre la recherche si l'utilisateur ne rempli pas la textBox surface Max
        if (surfaceMax == 0) surfaceMax = 999;

        if (surfaceTMax == 0) surfaceTMax = 999;

        if (surfaceTMax == 0) surfaceTMax = 999;

        string CdC = "";
        string prestige = "";
        if (COUP_DE_COEUR && PRESTIGE)
        {
            CdC = " AND (CoupDeCoeur = " + COUP_DE_COEUR + " ";
            prestige = "AND Prestige = " + PRESTIGE + ") ";
        }
        else if (COUP_DE_COEUR)
        {
            CdC = " AND CoupDeCoeur = " + COUP_DE_COEUR + " ";
        }
        else if (PRESTIGE)
        {
            prestige = " AND Prestige = " + PRESTIGE + " ";
        }

        string neuf = "";
        if(!neufOuPas){
            neuf = " AND Neuf = " + NEUF + " ";
        }

        string pubLocale = "";
        if (PUB_LOCALE)
        {
            pubLocale = " AND Neuf = " + PUB_LOCALE + " ";
        }

        if (typeBien.Contains("A"))
        {
            //requet appart
            requeteSQL = "   SELECT * FROM Biens INNER JOIN optionsBiens ON Biens.ref = optionsBiens.refOptions WHERE " + nomvendeur + lareferance + adresseb + leTelVendeur + ville + achatVente + idClientNego + surface + surfaceS + surfaceT + MailVendeur + budget + budgetlocation + motCle + nombreDePiece + nombreDeChambre + etatDuBien + TypeMandat + dateCreation + dateMaj + " AND (  Biens.[type de bien]='Z' " + ((typeBien.Contains("M")) ? " OR Biens.[type de bien] = 'M'" : "") + " " + ((typeBien.Contains("T")) ? " OR Biens.[type de bien] = 'T'" : "") + " " + ((typeBien.Contains("X")) ? " OR Biens.[type de bien] = 'I' OR Biens.[type de bien] = 'F' OR Biens.[type de bien] = 'L'" : "") + " OR Biens.[type de bien] = 'A')" + CdC + prestige + neuf;
        }
        else
        {
            //requete maison
            requeteSQL = "   SELECT * FROM Biens INNER JOIN optionsBiens ON Biens.ref = optionsBiens.refOptions WHERE " + nomvendeur + lareferance + adresseb + leTelVendeur + ville + achatVente + idClientNego + surface + surfaceS + surfaceT + MailVendeur + budget + budgetlocation + motCle + nombreDePiece + nombreDeChambre + etatDuBien + TypeMandat + dateCreation + dateMaj + " AND (  Biens.[type de bien]='Z' " + ((typeBien.Contains("M")) ? " OR Biens.[type de bien] = 'M'" : "") + " " + ((typeBien.Contains("T")) ? " OR Biens.[type de bien] = 'T'" : "") + " " + ((typeBien.Contains("X")) ? " OR Biens.[type de bien] = 'I' OR Biens.[type de bien] = 'F' OR Biens.[type de bien] = 'L'" : "") + ")" + CdC + prestige + neuf;
        }

        requeteSQL = requeteSQL + requeteOrder;
}

    private void creationRequeteRecherche()
    {

		string paysb = "";
		if(paysbien != "")
		{
			paysb = " AND PaysBien='" + paysbien + "' ";
		}
		
        String villes = " ";
        
        String nombreDePiece = nombrePiece();

        String nombreDeChambre = nombreChambre();

		String adresseb = "AND Biens.[adresse du bien] LIKE '%" + adresseBien + "%'";
		
        String motCle = " AND Biens.[texte internet] LIKE '%" + motCle1 +
                          "%' AND Biens.[texte internet] LIKE '%" + motCle2 +
                          "%' AND Biens.[texte internet] LIKE '%" + motCle3 +
                          "%' AND Biens.[texte internet] LIKE '%" + motCle4 + "%' ";

        #region coment
        /// Si aucune des 4 villes/code_postaux ou dep n'est renseigné alors on sort toutes les annonces
        /// sinon on filtre en fonction des critères
        ///
        /// ville = liste de Code Postaux générée à partir du critere de distance
        /// ex param="92700" result: " Biens.[code postal du bien]=CP1 AND Biens.[code postal du bien]=CP2 ...etc"
        /// la liste des codes postaux est tirée de la table ville

        //Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //StringBuilder sb = new StringBuilder();

        //c.Open();
        //sb.Append("SELECT * FROM Ville WHERE [Code Postal] IN (");

        //if (!string.IsNullOrEmpty(ville1) && ville1CodeDep == "code postal")
        //{
        //    sb.AppendFormat("{0}", ville1);
        //}
        //if (!string.IsNullOrEmpty(ville2) && ville2CodeDep == "code postal")
        //{
        //    sb.AppendFormat(",{0}", ville2);
        //}
        //if (!string.IsNullOrEmpty(ville3) && ville3CodeDep == "code postal")
        //{
        //    sb.AppendFormat(",{0}", ville3);
        //}
        //if (!string.IsNullOrEmpty(ville4) && ville4CodeDep == "code postal")
        //{
        //    sb.AppendFormat(",{0}", ville4);
        //}
        //sb.Append(")");

        //System.Data.DataSet dsvillelist = c.exeRequette(sb.ToString());
        //c.Close();
        #endregion

        Regex rCodePostal = new Regex(@"\d{5}");

        String lareferance = " AND Biens.[ref] LIKE '%" + lareferance1 + "%' ";
        String leTelVendeur = " AND Biens.[tel domicile vendeur] LIKE '%" + leTelVendeur1 + "%' ";
        String nomvendeur = " Biens.[nom vendeur] LIKE '%" + nomvendeur1 + "%' ";
        if (rCodePostal.IsMatch(ville1))
        {
            ville1Reg = true;
        }

        //string test = OutilsDistance.CPStringDistance(ville1, 10, " ", "");

        listeRecherche = new ListeEmplacementRecherche();
        listeRecherche.importerString(cible);
        //traitement de a cible
        bool hasvilles = false;
        bool hasdep = false;
        

        villes = " (";
        dep = " AND ( 0 ";
        foreach (EmplacementRecherche ER in listeRecherche)
        {
            if (ER.Dep == false)
            {
                hasvilles = true;
                if (ER.HasArrondissement == false)
                {
                    villes += "'" + ER.CP + "',";
                }
                else
                {
                    foreach (Arrondissement arr in ER.ListeArrondissement)
                    {
                        villes += "'" + arr.CP + "',";
                    }
                }
            }
            else
            {
                hasdep = true;
                string param;
                if (ER.CodeINSEE.ToLower() != "2a" && ER.CodeINSEE.ToLower() != "2b") param = ER.CodeINSEE + "%";
                else param = "20%";

                dep += " OR Biens.[code postal du bien] like '" + param + "' ";
            }
        }
        villes = villes.Substring(0, villes.Length - 1);
        villes += " ) ";
        dep += " ) ";
        
        
        
        //fin traitement de la cible




        String TypeMandat = " AND Biens.[type mandat] LIKE '" + typeMandat + "%' "; //" AND Biens.[type mandat]='Exclusif' OR Biens.[type mandat]='SemiExclusif' ";//

        String budget = " AND Biens.[prix de vente] >= " + prixMin + " AND Biens.[prix de vente] <= " + prixMax;
		
        String budgetlocation = " AND Biens.[loyer_cc] >= " + loyerMin + " AND Biens.[loyer_cc] <= " + loyerMax;

        String surface = " AND Biens.[surface habitable] >= " + surfaceMin + " AND Biens.[surface habitable] <=  " + surfaceMax;

        String surfaceS = " AND Biens.[surface séjour] >= " + surfaceSMin + " AND Biens.[surface séjour] <=  " + surfaceSMax;

        String surfaceT = " AND Biens.[surface terrain] >= " + surfaceTMin + " AND Biens.[surface terrain] <= " + surfaceTMax;

        String achatVente = " AND Biens.[ref] LIKE '%" + typeVente + "%' ";

		String surfaceST = " AND ((Biens.[surface habitable] >= " + surfaceMin + " AND Biens.[surface habitable] <=  " + surfaceMax + ") OR  (Biens.[surface terrain] >= " + surfaceMin + " AND Biens.[surface terrain] <= " + surfaceMax + "))";
		
        String idClientNego;

        if (idclient != 0)
        {
            if (negociateur != "")
            {
                idClientNego = "AND Biens.[actif]='actif' AND Biens.[idclient] =" + idclient + " AND Biens.[negociateur] LIKE '%" + negociateur + "%'";
            }
            else
            {
                idClientNego = "AND Biens.[actif]='actif' AND Biens.[idclient] =" + idclient;
            }
        }
        else
        {
            if (negociateur != "")
            {
                idClientNego = "AND Biens.[actif]='actif' AND Biens.[negociateur] LIKE '%" + negociateur + "%'";
            }
            else
            {
                idClientNego = "AND Biens.[actif]='actif'";
            }
        }

        //permet de ne pas restreindre la recherche si l'utilisateur ne rempli pas la textBox surface Max
        if (surfaceMax == 0) surfaceMax = 99999;

        if (surfaceSMax == 0) surfaceSMax = 99999;

        if (surfaceTMax == 0) surfaceTMax = 99999;


        string mandatSimple = "";
        string mandatExc = "";
        string mandatSemEx = "";

        if (MANDAT_SIMPLE)
        {
            mandatSimple = "Biens.[type mandat] = 'Simple'";
        }
        if (MANDAT_EXCLUSIF)
        {
            mandatExc = "Biens.[type mandat] = 'Exclusif'";
        }
        if (MANDAT_SEMI_EXCLUSIF)
        {
            mandatSemEx = "Biens.[type mandat] = 'SemiExclusif'";
        }

        string typeContrat = "";
        if (mandatSimple != "")
        {
            typeContrat = " AND (" + mandatSimple;
            if (mandatExc != "")
            {
                typeContrat += " OR " + mandatExc;
            }
            if (mandatSemEx != "")
            {
                typeContrat += " OR " + mandatSemEx;
            }
            typeContrat += ") ";
        }
        else if (mandatExc != "")
        {
            typeContrat = " AND (" + mandatExc;
            if (mandatSemEx != "")
            {
                typeContrat += " OR " + mandatSemEx;
            }
            typeContrat += ") ";
        }
        else if (mandatSemEx != "")
        {
            typeContrat = " AND " + mandatSemEx + " ";
        }

        string CdC = "";
        string prestige = "";
        if (COUP_DE_COEUR && PRESTIGE)
        {
            CdC = " AND (CoupDeCoeur = " + COUP_DE_COEUR + " ";
            prestige = "OR Prestige = " + PRESTIGE + ") ";
        }
        else if (COUP_DE_COEUR)
        {
            CdC = " AND CoupDeCoeur = " + COUP_DE_COEUR + " ";
        }
        else if (PRESTIGE)
        {
            prestige = " AND Prestige = " + PRESTIGE + " ";
        }

        string neuf = "";
        if (!NeufOuPas)
        {
            if (NEUF) neuf = " AND Neuf = " + NEUF + " ";
        }

        string etatBien;
        etatBien = "AND (Biens.[etat]='Disponible' OR Biens.[etat]='Libre' OR (Biens.[etat]='Estimation' AND PubLocale = True))";

        if (negociateur != "")
        {
            CdC = "";
            prestige = "";
            neuf = "";
        }

        //requete maison
        requeteSQLRecherche = "SELECT DISTINCT * FROM Biens INNER JOIN optionsBiens ON Biens.ref = optionsBiens.refOptions "
            + "WHERE " + nomvendeur + lareferance + adresseb + leTelVendeur + (hasvilles?" AND [code postal du bien] in "+villes: " ") + (hasdep?dep:" ") + achatVente + idClientNego + budget + budgetlocation + motCle + nombreDePiece + nombreDeChambre + TypeMandat 
            + " AND Biens.[actif]='actif' AND (  0 " + ((typeBien.Contains("A")) ? " OR (Biens.[type de bien] = 'A' AND (Biens.[surface habitable] >= " + surfaceMin + " AND Biens.[surface habitable] <=  " + surfaceMax + "))" : "") + " " + ((typeBien.Contains("M")) ? " OR (Biens.[type de bien] = 'M' AND (Biens.[surface habitable] >= " + surfaceMin + " AND Biens.[surface habitable] <=  " + surfaceMax + "))" : "") + " " + ((typeBien.Contains("T")) ? " OR (Biens.[type de bien] = 'T' AND (Biens.[surface terrain] >= " + surfaceMin + " AND Biens.[surface terrain] <=  " + surfaceMax + "))" : "") + " " + ((typeBien.Contains("X")) ? " OR (Biens.[type de bien] = 'I' AND (Biens.[surface habitable] >= " + surfaceMin + " AND Biens.[surface habitable] <=  " + surfaceMax + "))  OR (Biens.[type de bien] = 'L' AND (Biens.[surface habitable] >= " + surfaceMin + " AND Biens.[surface habitable] <=  " + surfaceMax + "))" : "") + ") "
            + etatBien + typeContrat + CdC + prestige + neuf + paysb;
        requeteSQLRecherche = requeteSQLRecherche + " " + requeteOrder;

    }

    private void creationRequeteArchive()
    {

        String ville = "";

        String nombreDePiece = nombrePiece();

        String nombreDeChambre = nombreChambre();

		String adresseb = "AND Biens.[adresse du bien] LIKE '%" + adresseBien + "%'";

        String etatDuBien = "";
        if (typeVente == "V")
        {
            etatDuBien = etatBien();
        }
        else
        {
            etatDuBien = etatBienL();
        }

        String motCle = " AND Biens.[texte internet] LIKE '%" + motCle1 +
                          "%' AND Biens.[texte internet] LIKE '%" + motCle2 +
                          "%' AND Biens.[texte internet] LIKE '%" + motCle3 +
                          "%' AND Biens.[texte internet] LIKE '%" + motCle4 + "%' ";

        #region comment
        /// Si aucune des 4 villes/code_postaux ou dep n'est renseigné alors on sort toutes les annonces
        /// sinon on filtre en fonction des critères
        ///
        /// ville = liste de Code Postaux générée à partir du critere de distance
        /// ex param="92700" result: "Biens.[code postal du bien]=CP1 AND Biens.[code postal du bien]=CP2 ...etc"
        /// la liste des codes postaux est tirée de la table ville

        //Connexion c = new Connexion(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //StringBuilder sb = new StringBuilder();

        //c.Open();
        //sb.Append("SELECT * FROM Ville WHERE [Code Postal] IN (");

        //if (!string.IsNullOrEmpty(ville1) && ville1CodeDep == "code postal")
        //{
        //    sb.AppendFormat("{0}", ville1);
        //}
        //if (!string.IsNullOrEmpty(ville2) && ville2CodeDep == "code postal")
        //{
        //    sb.AppendFormat(",{0}", ville2);
        //}
        //if (!string.IsNullOrEmpty(ville3) && ville3CodeDep == "code postal")
        //{
        //    sb.AppendFormat(",{0}", ville3);
        //}
        //if (!string.IsNullOrEmpty(ville4) && ville4CodeDep == "code postal")
        //{
        //    sb.AppendFormat(",{0}", ville4);
        //}
        //sb.Append(")");

        //System.Data.DataSet dsvillelist = c.exeRequette(sb.ToString());
        //c.Close();
        #endregion

        Regex rCodePostal = new Regex(@"\d{5}");

        String lareferance = " AND Biens.[ref] LIKE '" + lareferance1 + "%%' ";
        String leTelVendeur = "AND  Biens.[tel domicile vendeur] LIKE '%" + leTelVendeur1 + "%' ";
        String nomvendeur = " Biens.[nom vendeur] LIKE '%" + nomvendeur1 + "%' ";
        if (rCodePostal.IsMatch(ville1))
        {
            ville1Reg = true;
        }

        //string test = OutilsDistance.CPStringDistance(ville1, 10, " ", "");

        if (!ville1Reg)
        {
            ville = " AND Biens.[ville du bien] LIKE '%%'";
        }
        else
        {
            ville = ((ville1CodeDep.Contains("nom") ? "AND Biens.[ville du bien] Like '%" + ville1 + "%' " : ""));
            // + (ville1CodeDep.Contains("departement") ? "Biens.[code postal du bien] Like '" + ville1 + "%' " : ""));
            //+ (ville1CodeDep.Contains("code postal") ? "Biens.[code postal du bien] IN ('" + ville1 + "') " : ""));
            if (ville1CodeDep.Contains("code postal"))
            {
                ville += "Biens.[code postal du bien] IN (";

                foreach (string city in villepostal)
                {
                    ville += "'" + city + "',";
                }
                ville = ville.Substring(0, ville.Length - 1);

                ville += ") ";
            }

            if (ville1CodeDep.Contains("departement"))
            {
				ville += " AND ";
                foreach (string city in villepostal)
                {
                    ville += " Biens.[code postal du bien] Like '" + city + "%' OR ";
                }
                ville = ville.Substring(0, ville.Length - 4);
            }
        }

        String TypeMandat = " AND Biens.[type mandat] LIKE '" + typeMandat + "%' ";

        String budget = " AND Biens.[prix de vente] >= " + prixMin + " AND Biens.[prix de vente] <= " + prixMax;
		
        String budgetlocation = " AND Biens.[loyer_cc] >= " + loyerMin + " AND Biens.[loyer_cc] <= " + loyerMax;

        String surface = " AND Biens.[surface habitable] >= " + surfaceMin + " AND Biens.[surface habitable] <=  " + surfaceMax;

        String surfaceS = " AND Biens.[surface séjour] >= " + surfaceSMin + " AND Biens.[surface séjour] <=  " + surfaceSMax;

        String surfaceT = " AND Biens.[surface terrain] >= " + surfaceTMin + " AND Biens.[surface terrain] <= " + surfaceTMax;

        String achatVente = " AND Biens.[ref] LIKE '" + typeVente + "%' ";

        String MailVendeur = " AND Biens.[adresse mail vendeur] LIKE '" + mailVendeur + "%'";

        String LeTelVendeur = " AND  Biens.[tel domicile vendeur] LIKE '%" + leTelVendeur1 + "%'";

        DateTime date = new DateTime(0001, 01, 01, 00, 00, 00);
        String dateCreation = "";
        if (System.DateTime.Compare(dateCreationMax, date) != 0 && System.DateTime.Compare(dateCreationMin, date) != 0)
        {
            dateCreation = " AND Biens.[date dossier] BETWEEN #" + dateCreationMin.Day + "/" + dateCreationMin.Month + "/" + dateCreationMin.Year + "# AND #" + dateCreationMax.Day + "/" + dateCreationMax.Month + "/" + dateCreationMax.Year + "# ";
        }
        else
        {
            dateCreation = "";
        }

        String dateMaj = "";
        if (System.DateTime.Compare(dateMajMax, date) != 0 && System.DateTime.Compare(dateMajMin, date) != 0)
        {
            dateMaj = " AND Biens.[date modification] BETWEEN #" + dateMajMin.Day + "/" + dateMajMin.Month + "/" + dateMajMin.Year + "# AND #" + dateMajMax.Day + "/" + dateMajMax.Month + "/" + dateMajMax.Year + "# ";
        }
        else
        {
            dateMaj = "";
        }

        String idClientNego;
        if (idclient == 01)
        {
            idClientNego = "AND Biens.[actif] LIKE 'archive' AND Biens.[num] ='" + numAgence + "' AND Biens.[negociateur] LIKE '%" + negociateur + "%'";
        }
        else if (idclient == 02)
        {
            idClientNego = "AND Biens.[actif] LIKE 'archive'";
        }
        else if (idclient == 0)
        {
            if (negociateur != "")
            {
                idClientNego = "AND Biens.[actif] LIKE 'archive' AND Biens.[negociateur] LIKE '%" + negociateur + "%'";
            }
            else
            {
                idClientNego = "AND Biens.[actif] LIKE 'archive'";
            }
        }
        else
        {
            idClientNego = "AND Biens.[actif] LIKE 'archive' AND Biens.[idclient]  =" + idclient;
        }

        //permet de ne pas restreindre la recherche si l'utilisateur ne rempli pas la textBox surface Max
        if (surfaceMax == 0) surfaceMax = 999;

        if (surfaceSMax == 0) surfaceSMax = 999;

        if (surfaceTMax == 0) surfaceTMax = 999;

        /*
        //requete maison
        requeteSQLArchive = "   SELECT * FROM Biens INNER JOIN optionsBiens WHERE " + nomvendeur + LeTelVendeur + lareferance + adresseb + ville + achatVente + idClientNego + surface + surfaceS + surfaceT + MailVendeur + budget + budgetlocation + motCle + nombreDePiece + nombreDeChambre + etatDuBien + TypeMandat + dateCreation + dateMaj + " AND (  Biens.[ville du bien]='Z' " + ((typeBien.Contains("M")) ? " OR Biens.[type de bien] = 'M'" : "") + " " + ((typeBien.Contains("T")) ? " OR Biens.[type de bien] = 'T'" : "") + " " + ((typeBien.Contains("X")) ? " OR Biens.[type de bien] = 'I' OR Biens.[type de bien] = 'F' OR Biens.[type de bien] = 'L'" : "") + ") AND Biens.[actif] LIKE 'archive'";

        //requet appart
        if (typeBien.Contains("A"))
        {
            requeteSQLArchive = requeteSQLArchive + " UNION SELECT * FROM Biens INNER JOIN optionsBiens WHERE " + nomvendeur + leTelVendeur + lareferance + adresseb + achatVente + ville + idClientNego + surface + surfaceS + surfaceT + MailVendeur + budget + budgetlocation + motCle + nombreDePiece + nombreDeChambre + etatDuBien + TypeMandat + dateCreation + dateMaj + " AND Biens.[type de bien] = 'A' AND Biens.[actif] LIKE 'archive'";
        }*/


        string CdC = "";
        string prestige = "";
        if (COUP_DE_COEUR && PRESTIGE)
        {
            CdC = " AND (CoupDeCoeur = " + COUP_DE_COEUR + " ";
            prestige = "OR Prestige = " + PRESTIGE + ") ";
        }
        else if (COUP_DE_COEUR)
        {
            CdC = " AND CoupDeCoeur = " + COUP_DE_COEUR + " ";
        }
        else if (PRESTIGE)
        {
            prestige = " AND Prestige = " + PRESTIGE + " ";
        }

        string neuf = "";
        if (!NeufOuPas)
        {
            if (NEUF) neuf = " AND Neuf = " + NEUF + " ";
        }
        /*
        requeteSQL = "   SELECT * FROM Biens INNER JOIN optionsBiens ON Biens.ref = optionsBiens.refOptions "
            + "WHERE " + nomvendeur + lareferance + adresseb + leTelVendeur + ville + achatVente + idClientNego + surface + surfaceS + surfaceT + MailVendeur + budget
            + budgetlocation + motCle + nombreDePiece + nombreDeChambre + etatDuBien + TypeMandat + dateCreation + dateMaj
            + " AND (  Biens.[ville du bien]='Z' " + ((typeBien.Contains("M")) ? " OR Biens.[type de bien] = 'M'" : "") + " " + ((typeBien.Contains("T")) ? " OR Biens.[type de bien] = 'T'" : "") + " " + ((typeBien.Contains("X")) ? " OR Biens.[type de bien] = 'I' OR Biens.[type de bien] = 'F' OR Biens.[type de bien] = 'L'" : "") + ")" + ((typeBien.Contains("A")) ? " AND Biens.[type de bien] = 'A'" : "")
            + CdC + prestige + neuf;
        */
        requeteSQL = "   SELECT * FROM Biens INNER JOIN optionsBiens ON Biens.ref = optionsBiens.refOptions "
            + "WHERE " + nomvendeur + lareferance + adresseb + leTelVendeur + ville + achatVente + idClientNego + surface + surfaceS + surfaceT + MailVendeur + budget
            + budgetlocation + motCle + nombreDePiece + nombreDeChambre + etatDuBien + TypeMandat + dateCreation + dateMaj
            + " AND Biens.[actif]='archive' AND (  Biens.[ville du bien]='Z' " + ((typeBien.Contains("A")) ? " OR (Biens.[type de bien] = 'A' AND (Biens.[surface habitable] >= " + surfaceMin + " AND Biens.[surface habitable] <=  " + surfaceMax + "))" : "") + " " + ((typeBien.Contains("M")) ? " OR (Biens.[type de bien] = 'M' AND (Biens.[surface habitable] >= " + surfaceMin + " AND Biens.[surface habitable] <=  " + surfaceMax + "))" : "") + " " + ((typeBien.Contains("T")) ? " OR (Biens.[type de bien] = 'T' AND (Biens.[surface terrain] >= " + surfaceMin + " AND Biens.[surface terrain] <=  " + surfaceMax + "))" : "") + " " + ((typeBien.Contains("X")) ? " OR (Biens.[type de bien] = 'I' AND (Biens.[surface habitable] >= " + surfaceMin + " AND Biens.[surface habitable] <=  " + surfaceMax + "))  OR (Biens.[type de bien] = 'L' AND (Biens.[surface habitable] >= " + surfaceMin + " AND Biens.[surface habitable] <=  " + surfaceMax + "))" : "") + ") "
            + CdC + prestige + neuf;
        /*
        requeteSQLRecherche = "SELECT DISTINCT * FROM Biens INNER JOIN optionsBiens ON Biens.ref = optionsBiens.refOptions "
            + "WHERE " + nomvendeur + lareferance + adresseb + leTelVendeur + ville + achatVente + idClientNego + budget + budgetlocation + motCle + nombreDePiece + nombreDeChambre + TypeMandat
            + " AND Biens.[actif]='archive' AND (  Biens.[ville du bien]='Z' " + ((typeBien.Contains("A")) ? " OR (Biens.[type de bien] = 'A' AND (Biens.[surface habitable] >= " + surfaceMin + " AND Biens.[surface habitable] <=  " + surfaceMax + "))" : "") + " " + ((typeBien.Contains("M")) ? " OR (Biens.[type de bien] = 'M' AND (Biens.[surface habitable] >= " + surfaceMin + " AND Biens.[surface habitable] <=  " + surfaceMax + "))" : "") + " " + ((typeBien.Contains("T")) ? " OR (Biens.[type de bien] = 'T' AND (Biens.[surface terrain] >= " + surfaceMin + " AND Biens.[surface terrain] <=  " + surfaceMax + "))" : "") + " " + ((typeBien.Contains("X")) ? " OR (Biens.[type de bien] = 'I' AND (Biens.[surface habitable] >= " + surfaceMin + " AND Biens.[surface habitable] <=  " + surfaceMax + "))  OR (Biens.[type de bien] = 'L' AND (Biens.[surface habitable] >= " + surfaceMin + " AND Biens.[surface habitable] <=  " + surfaceMax + "))" : "") + ") "
            + CdC + prestige + neuf;*/
        requeteSQLArchive = requeteSQL + requeteOrder;

    }

    private String nombrePiece() 
    {
        /*********************************************************************************************************
        *                       Test quel type de bien a été coché ( Appartement ou Maison):                     *
        *                     rempli la requète avec l'opération appropriée dans operationType                   *
        **********************************************************************************************************/
        String[] operande = new String[4];
        String[] operationPiece = new String[5];
        String nombreDePiece = "";

        if (pieceAll) operationPiece[0] = " ";

        if (piece1) operationPiece[0] = "  Biens.[nombre de pieces]=1 ";

        if (piece2)
        {
            operationPiece[1] = "  Biens.[nombre de pieces]=2 ";
            if (piece1) operande[0] = " OR ";
            else operande[0] = "";
        }
        if (piece3)
        {
            operationPiece[2] = "  Biens.[nombre de pieces]=3 ";
            if (piece2 || piece1 == true) operande[1] = " OR ";
            else operande[1] = "";
        }
        if (piece4)
        {
            operationPiece[3] = "  Biens.[nombre de pieces]=4 ";
            if (piece3 || piece2 || piece1) operande[2] = " OR ";
            else operande[2] = "";
        }
        if (piece5)
        {
            operationPiece[4] = "  Biens.[nombre de pieces]>=5 ";
            if (piece4 || piece3 || piece2 || piece1) operande[3] = " OR ";
            else operande[3] = "";
        }

        nombreDePiece = "AND (" + operationPiece[0] + operande[0] + operationPiece[1] + operande[1] + operationPiece[2] + operande[2] + operationPiece[3] + operande[3] + operationPiece[4] + ") ";


        if (piece5 == false && piece4 == false && piece3 == false && piece2 == false && piece1 == false || piece5 == true && piece4 == true && piece3 == true && piece2 == true && piece1 == true)
        {
            nombreDePiece = " ";
        }
        //FIN DE TEST***********************************************************************************************************************************************************************


        return nombreDePiece;
    }

    private String nombreChambre()
    {
        String[] operande = new String[4];
        String[] operationChambre = new String[5];
        String nombreDeChambre = "";

        if (chambreAll) operationChambre[0] = " ";

        if (chambre1) operationChambre[0] = "  Biens.[nombre de chambres]=1 ";

        if (chambre2)
        {
            operationChambre[1] = "  Biens.[nombre de chambres]=2 ";
            if (chambre1) operande[0] = " OR ";
            else operande[0] = "";
        }
        if (chambre3)
        {
            operationChambre[2] = "  Biens.[nombre de chambres]=3 ";
            if (chambre2 || chambre1 == true) operande[1] = " OR ";
            else operande[1] = "";
        }
        if (chambre4)
        {
            operationChambre[3] = "  Biens.[nombre de chambres]=4 ";
            if (chambre3 || chambre2 || chambre1) operande[2] = " OR ";
            else operande[2] = "";
        }
        if (chambre5)
        {
            operationChambre[4] = "  Biens.[nombre de chambres]>=5 ";
            if (chambre4 || chambre3 || chambre2 || chambre1) operande[3] = " OR ";
            else operande[3] = "";
        }

        nombreDeChambre = "AND (" + operationChambre[0] + operande[0] + operationChambre[1] + operande[1] + operationChambre[2] + operande[2] + operationChambre[3] + operande[3] + operationChambre[4] + ") ";


        if (chambre5 == false && chambre4 == false && chambre3 == false && chambre2 == false && chambre1 == false || chambre5 == true && chambre4 == true && chambre3 == true && chambre2 == true && chambre1 == true)
        {
            nombreDeChambre = " ";
        }
        //FIN DE TEST***********************************************************************************************************************************************************************


        return nombreDeChambre;
    }

    private String etatBien()
    {
        String[] operande = new String[5];
        String[] operationBien = new String[6];
        String etatDuBien = "";

        if (etatAll) operationBien[0] = " ";

        if (esti)
        {
            operationBien[0] = "  Biens.[etat]='Estimation' ";
        }

        if (disp)
        {
            operationBien[1] = "  Biens.[etat]='Disponible' ";
            if (esti) operande[0] = " OR ";
            else operande[0] = "";
        }
        if (offr)
        {
            operationBien[2] = "  Biens.[etat]='Offre' ";
            if (disp || esti == true) operande[1] = " OR ";
            else operande[1] = "";
        }
        if (susp)
        {
            operationBien[3] = "  Biens.[etat]='Suspendu' ";
            if (susp || disp || esti) operande[2] = " OR ";
            else operande[2] = "";
        }
        if (reti)
        {
            operationBien[4] = "  Biens.[etat]='Retiré' ";
            if (susp || offr || disp || esti) operande[3] = " OR ";
            else operande[3] = "";
        }
        if (comp)
        {
            operationBien[5] = "  Biens.[etat]='Compromis' ";
            if (reti || susp || offr || disp || esti) operande[4] = " OR ";
            else operande[4] = "";
        }

        etatDuBien = "AND (" + operationBien[0] + operande[0] + operationBien[1] + operande[1] + operationBien[2] + operande[2] + operationBien[3] + operande[3] + operationBien[4] + operande[4] + operationBien[5] + ") ";


        if (esti == false && disp == false && offr == false && susp == false && reti == false && comp == false || esti == true && disp == true && offr == true && susp == true && reti == true && comp == true)
        {
            etatDuBien = " ";
        }
        //FIN DE TEST***********************************************************************************************************************************************************************


        return etatDuBien;
    }

    private String etatBienL()
    {
        String[] operande = new String[6];
        String[] operationBienL = new String[7];
        String etatDuBien = "";

        if (etatAll2) operationBienL[0] = " ";

        if (libre) operationBienL[0] = "  Biens.[etat]='Libre' ";

        if (occupe)
        {
            operationBienL[1] = "  Biens.[etat]='Occupé' ";
            if (libre) operande[0] = " OR ";
            else operande[0] = "";
        }
        if (loue)
        {
            operationBienL[2] = "  Biens.[etat]='Loué' ";
            if (occupe || libre == true) operande[1] = " OR ";
            else operande[1] = "";
        }
        if (option)
        {
            operationBienL[3] = "  Biens.[etat]='Option' ";
            if (loue || occupe || libre) operande[2] = " OR ";
            else operande[2] = "";
        }
        if (reserv)
        {
            operationBienL[4] = "  Biens.[etat]='Réservé' ";
            if (option || loue || occupe || libre) operande[3] = " OR ";
            else operande[3] = "";
        }
        if (retire)
        {
            operationBienL[5] = "  Biens.[etat]='Retiré' ";
            if (reserv || option || loue || occupe || libre) operande[4] = " OR ";
            else operande[4] = "";
        }
        if (suspen)
        {
            operationBienL[6] = " Biens.[etat]='Suspendu' ";
            if (retire || reserv || option || loue || occupe || libre) operande[5] = " OR ";
            else operande[5] = "";
        }

        etatDuBien = "AND (" + operationBienL[0] + operande[0] + operationBienL[1] + operande[1] + operationBienL[2] + operande[2] + operationBienL[3] + operande[3] + operationBienL[4] + operande[4] + operationBienL[5] + operande[5] + operationBienL[6] + ") ";


        if (libre == false && occupe == false && loue == false && option == false && reserv == false && retire == false && suspen == false || libre == true && occupe == true && loue == true && option == true && reserv == true && retire == true && suspen == true)
        {
            etatDuBien = " ";
        }
        //FIN DE TEST***********************************************************************************************************************************************************************


        return etatDuBien;
    }

    private bool verifChampSaisi()
    {
        Regex maRegexp = new Regex("^[0-9]+$");
        Regex maReg2 = new Regex("^[0-9]+$|^[a-zA-Zéèçàâù ]+$|^()+$");


        bool reglareferance = maReg2.IsMatch(lareferance1.ToString());
        bool regleTelVendeur = maRegexp.IsMatch(leTelVendeur1.ToString());
        
        bool regnomvendeur = maReg2.IsMatch(nomvendeur1.ToString());
        bool regSurfaceMin = maRegexp.IsMatch(surfaceMin.ToString());
        bool regSurfaceMax = maRegexp.IsMatch(surfaceMax.ToString());
        bool regNomVille1 = maReg2.IsMatch(ville1);

        bool regBudgetMin = maRegexp.IsMatch(prixMin.ToString());
        bool regBudgetMax = maRegexp.IsMatch(prixMin.ToString());

        if (regSurfaceMin == true && regSurfaceMax == true && regNomVille1 == true && regBudgetMin == true && regBudgetMax == true && reglareferance == true && regleTelVendeur == true && regnomvendeur == true) return true;
        else return false;

    }
    #endregion

    public string leTelVendeur1 { get; set; }
}