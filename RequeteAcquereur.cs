using System;
using System.Collections.Generic;
using System.Linq;
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


/// <summary>
/// Description résumée de RequeteAcquereur
/// </summary>
public class RequeteAcquereur
{

    #region attributs

    private int idAcq = 0;
    private Int64 prixMin = 0;
    private Int64 prixMax = 0;
    private Int64 surfaceMin = 0;
    private Int64 surfaceMax = 0;
    private Int64 surfaceSMin = 0;
    private Int64 surfaceSMax = 0;
    private Int64 surfaceTMin = 0;
    private Int64 surfaceTMax = 0;
    private Int64 facadeMin = 0;
    private Int64 facadeMax = 0;
    private Int64 profondeurMin = 0;
    private Int64 profondeurMax = 0;
    private String appart = "";
    private String mais = "";
    private String terr = "";
    private String autr = "";
    private String typeAcq = "";
    private String EtatAvancement = "";
    private String asc = "";
    private String sous = "";
    private String park = "";

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
    private Boolean chambreAll = false;

    private String dep = "";
    private String motCle1 = "";
    private String motCle2 = "";
    private String motCle3 = "";
    private String motCle4 = "";

    private String ville1 = "";

    private Boolean radio0km = true;
    private Boolean radio5km = true;


    private String ville1CodeDep = "";// permet de savoir si c un code postal, departement ou le nom de la ville

    private Boolean ville1Reg = false;

    private int idclient = 0;
    private int actif = 0;

    private String mail = "";
    private String tel = "";
    private String portable = "";
    private String nom = "";
    private String prenom = "";

    private string requeteSQLArchive = "";
    private string requeteSQL = "";
    private String requeteOrder = "";

    private Boolean rechercheOk = false;

    #endregion

    #region getters/setters

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
    public Int64 FACADEMIN
    {
        get
        {
            return facadeMin;
        }
        set
        {
            this.facadeMin = value;

        }

    }
    public Int64 FACADEMAX
    {
        get
        {
            return facadeMax;
        }
        set
        {
            this.facadeMax = value;
        }
    }
    public Int64 PROFONDEURMIN
    {
        get
        {
            return profondeurMin;
        }
        set
        {
            this.profondeurMin = value;

        }

    }
    public Int64 PROFONDEURMAX
    {
        get
        {
            return profondeurMax;
        }
        set
        {
            this.profondeurMax = value;
        }
    }
    public String APPART
    {
        get
        {
            return appart;
        }
        set
        {
            this.appart = value;
        }
    }
    public String MAIS
    {
        get
        {
            return mais;
        }
        set
        {
            this.mais = value;
        }
    }
    public String TERR
    {
        get
        {
            return terr;
        }
        set
        {
            this.terr = value;
        }
    }
    public String AUTR
    {
        get
        {
            return autr;
        }
        set
        {
            this.autr = value;
        }
    }
    public String TYPEACQ
    {
        get
        {
            return typeAcq;
        }
        set
        {
            this.typeAcq = value;
        }
    }
    public String ETATAVANCEMENT
    {
        get
        {
            return EtatAvancement;
        }
        set
        {
            this.EtatAvancement = value;
        }

    }
    public String ASC
    {
        get
        {
            return asc;
        }
        set
        {
            this.asc = value;
        }

    }
    public String SOUS
    {
        get
        {
            return sous;
        }
        set
        {
            this.sous = value;
        }

    }
    public String PARK
    {
        get
        {
            return park;
        }
        set
        {
            this.park = value;
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

    public int IDCLIENT
    {
        get { return this.idclient; }
        set { this.idclient = value; }

    }

    public int ACTIF
    {
        get { return this.actif; }
        set { this.actif = value; }
    }

    public String MAIL
    {
        get { return this.mail; }
        set { this.mail = value; }
    }
    public DateTime Datedecreation { get; set; }
    public DateTime Datedefin { get; set; }
    public String TEL
    {
        get { return this.tel; }
        set { this.tel = value; }
    }

    public String PORTABLE
    {
        get { return this.portable; }
        set { this.portable = value; }
    }

    public String NOM
    {
        get { return this.nom; }
        set { this.nom = value; }
    }

    public String PRENOM
    {
        get { return this.prenom; }
        set { this.prenom = value; }
    }

    public String REQUETE_SQL_Archive
    {
        get
        {
            creationRequeteArchive();
            return requeteSQLArchive;
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

    #endregion

    public RequeteAcquereur()
	{
		//
		// TODO: ajoutez ici la logique du constructeur
		//
	}

    private void creationRequete()
    {


        String ville = "";
        String Nom = "";
        String Prenom = "";
        String Tel = "";
        String Portable = "";
        String Mail = "";
        String motCle = "";
        
     
        String nombreDePiece = nombrePiece();

        String nombreDeChambre = nombreChambre();

        if (motCle1 != "" && motCle2 != "" && motCle3 != "" && motCle4 != "")
        {
             motCle = " AND Acquereurs.[texte_complementaire] = '" + motCle1 +
                             "' AND Acquereurs.[texte_complementaire] = '" + motCle2 +
                             "' AND Acquereurs.[texte_complementaire] = '" + motCle3 +
                             "' AND Acquereurs.[texte_complementaire] = '" + motCle4 + "' ";
        }
        else {  motCle = ""; }

        Regex rCodePostal = new Regex(@"\d{5}");
        if (ville1 != "")
        {
            if (!ville1Reg)
            {
                ville = "";
            }
            else
            {
                ville = ((ville1CodeDep.Contains("nom") ? " AND Acquereurs.[ville_cible] = '" + ville1 + "' " : ""+" AND "));
                // + (ville1CodeDep.Contains("departement") ? "Biens.[code postal du bien] Like '" + ville1 + "%' " : ""));
                //+ (ville1CodeDep.Contains("code postal") ? "Biens.[code postal du bien] IN ('" + ville1 + "') " : ""));
                if (ville1CodeDep.Contains("code postal"))
                {
                    ville += "Acquereurs.[code_postal_cible] IN ( ";

                    foreach (string city in villepostal)
                    {
                        ville += "'" + city + "',";
                    }
                    ville = ville.Substring(0, ville.Length - 1);

                    ville += " ) ";
                }

                if (ville1CodeDep.Contains("departement"))
                {
                    ville += " ( ";
                    foreach (string city in villepostal)
                    {
                        ville += " Acquereurs.[dept_cible] Like '" + city + "%' OR ";
                    }
                    ville = ville.Substring(0, ville.Length - 3);
                    ville = ville + " ) ";
                }
            }
        }
        else { ville = ""; }

        //string test = OutilsDistance.CPStringDistance(ville1, 10, " ", "");




        String budget = " AND Acquereurs.[prix_min] >= " + prixMin + " AND Acquereurs.[prix_max] <= " + prixMax;

        String surface = " AND Acquereurs.[surface_habitable] >= " + surfaceMin + " AND Acquereurs.[surface_habitable] <=  " + surfaceMax;

        String surfaceS = " AND Acquereurs.[surface_sejour] >= " + surfaceSMin + " AND Acquereurs.[surface_sejour] <=  " + surfaceSMax;

        String surfaceT = " AND Acquereurs.[surface_terrain_min] >= " + surfaceTMin + " AND Acquereurs.[surface_terrain_max] <=  " + surfaceTMax;

        String facade = " AND Acquereurs.[facade] >= " + facadeMin + " AND Acquereurs.[facade] <=  " + facadeMax;

        String profondeur = " AND Acquereurs.[profondeur] >= " + profondeurMin + " AND Acquereurs.[profondeur] <=  " + profondeurMax;

        String typeacq = "  Acquereurs.[type_acquereur] =" + typeAcq;

        if (nom != "")
        { Nom = " AND Acquereurs.[nom] = '" + nom + "'"; }
        else {  Nom = ""; }

        if (prenom != "")
        {  Prenom = " AND Acquereurs.[prenom] = '" + prenom + "'"; }
        else {  Prenom = ""; }

        if (tel != "")
        { Tel = " AND Acquereurs.[tel] = '" + tel + "'";}
        else {  Tel = ""; }

        if (portable != "")
        { Portable = " AND Acquereurs.[portable] = '" + portable + "'";}
        else {  Portable = ""; }

        if (mail != "")
        {  Mail = " AND Acquereurs.[mail] = '" + mail + "'"; }
        else {  Mail = ""; }

        DateTime Date = new DateTime(0001, 01, 01, 00, 00, 00);
        String dateCreation = "";
        if (System.DateTime.Compare(Datedecreation, Date) != 0 && System.DateTime.Compare(Datedefin, Date) != 0)
        {
            dateCreation = " AND Acquereurs.[date_ajout] BETWEEN #" + Datedecreation.Day + "/" + Datedecreation.Month + "/" + Datedecreation.Year + "# AND #" + Datedefin.Day + "/" + Datedefin.Month + "/" + Datedefin.Year + "# ";
        }
        else
        {
            dateCreation = "";
        }

        String etat = " AND Acquereurs.[etat_avancement] = '" + EtatAvancement + "'";

        String ascenseur = " AND Acquereurs.[ascenseur] = '" + asc + "'";

        String soussol = " AND Acquereurs.[sous-sol] = '" + sous + "'";

        String parking = " AND Acquereurs.[parking/box] = '" + park + "'";

        String typeBien = typebien();

        String idClientNego;
        if (idclient == 0 && actif == 0)
        {
            idClientNego = " AND Acquereurs.[actif]='actif'";
        }
        else if (idclient == 0 && actif == 1)
        {
            idClientNego = " AND Acquereurs.[actif]='archive'";
        }
        else if (idclient != 0 && actif == 0)
        {
            idClientNego = " AND Acquereurs.[actif]='actif' AND Acquereurs.[idclient] =" + idclient;
        }
        else
            idClientNego = " AND Acquereurs.[actif]='archive' AND Acquereurs.[idclient]  =" + idclient;

        //permet de ne pas restreindre la recherche si l'utilisateur ne rempli pas la textBox surface Max
        if (surfaceMax == 0) surfaceMax = 999;

        if (surfaceSMax == 0) surfaceSMax = 999;


        //requete maison
        requeteSQL = "SELECT * FROM Acquereurs WHERE " + typeacq + ville + idClientNego + budget + motCle + surface + surfaceS + surfaceT + facade + profondeur + nombreDePiece + nombreDeChambre + Nom + Prenom + Tel + Portable + Mail + dateCreation + typeBien + etat + ascenseur + soussol + parking;

        //requet appart
        if (appart.Contains("T"))
        {
            requeteSQL = requeteSQL + " UNION SELECT * FROM Acquereurs WHERE " + typeacq + ville + idClientNego + budget + motCle + surface + surfaceS + surfaceT + facade + profondeur + nombreDePiece + nombreDeChambre + Nom + Prenom + Tel + Portable + Mail + dateCreation + typeBien + etat + ascenseur + soussol + parking;
        }

        requeteSQL = requeteSQL + requeteOrder;
    }

    private void creationRequeteArchive()
    {

        String ville = "";
        String Nom = "";
        String Prenom = "";
        String Tel = "";
        String Portable = "";
        String Mail = "";
        String motCle = "";
       
     
        String nombreDePiece = nombrePiece();

        String nombreDeChambre = nombreChambre();

        //String motCle = " AND Acquereurs.[texte_complementaire] = '" + motCle1 +
        //                  "' AND Acquereurs.[texte_complementaire] = '" + motCle2 +
        //                  "' AND Acquereurs.[texte_complementaire] = '" + motCle3 +
        //                  "' AND Acquereurs.[texte_complementaire] = '" + motCle4 + "' ";
        if (motCle1 != "" && motCle2 != "" && motCle3 != "" && motCle4 != "")
        {
            motCle = " AND Acquereurs.[texte_complementaire] = '" + motCle1 +
                            "' AND Acquereurs.[texte_complementaire] = '" + motCle2 +
                            "' AND Acquereurs.[texte_complementaire] = '" + motCle3 +
                            "' AND Acquereurs.[texte_complementaire] = '" + motCle4 + "' ";
        }
        else { motCle = ""; }


        Regex rCodePostal = new Regex(@"\d{5}");

        if (ville1 != "")
        {
            if (!ville1Reg)
            {
                ville = "";
            }
            else
            {
                ville = ((ville1CodeDep.Contains("nom") ? " AND Acquereurs.[ville_cible] = '" + ville1 + "' " : ""+" AND "));
                // + (ville1CodeDep.Contains("departement") ? "Biens.[code postal du bien] Like '" + ville1 + "%' " : ""));
                //+ (ville1CodeDep.Contains("code postal") ? "Biens.[code postal du bien] IN ('" + ville1 + "') " : ""));
                if (ville1CodeDep.Contains("code postal"))
                {
                    ville += "Acquereurs.[code_postal_cible] IN ( ";

                    foreach (string city in villepostal)
                    {
                        ville += "'" + city + "',";
                    }
                    ville = ville.Substring(0, ville.Length - 1);

                    ville += " ) ";
                }

                if (ville1CodeDep.Contains("departement"))
                {
                    ville += " ( ";
                    foreach (string city in villepostal)
                    {
                        ville += " Acquereurs.[dept_cible] Like '" + city + "%' OR ";
                    }
                    ville = ville.Substring(0, ville.Length - 3);
                    ville = ville + " ) ";
                }
            }
        }
        else { ville = ""; }


        //string test = OutilsDistance.CPStringDistance(ville1, 10, " ", "");

        String budget = " AND Acquereurs.[prix_min] >= " + prixMin + " AND Acquereurs.[prix_max] <= " + prixMax;

        String surface = " AND Acquereurs.[surface_habitable] >= " + surfaceMin + " AND Acquereurs.[surface_habitable] <=  " + surfaceMax;

        String surfaceS = " AND Acquereurs.[surface_sejour] >= " + surfaceSMin + " AND Acquereurs.[surface_sejour] <=  " + surfaceSMax;

        String surfaceT = " AND Acquereurs.[surface_terrain_min] >= " + surfaceTMin + " AND Acquereurs.[surface_terrain_max] <=  " + surfaceTMax;

        String facade = " AND Acquereurs.[facade] >= " + facadeMin + " AND Acquereurs.[facade] <=  " + facadeMax;

        String profondeur = " AND Acquereurs.[profondeur] >= " + profondeurMin + " AND Acquereurs.[profondeur] <=  " + profondeurMax;

        String typeacq = "  Acquereurs.[type_acquereur] =" + typeAcq;
        if (nom != "")
        { Nom = " AND Acquereurs.[nom] = '" + nom + "'"; }
        else { Nom = ""; }

        if (prenom != "")
        { Prenom = " AND Acquereurs.[prenom] = '" + prenom + "'"; }
        else { Prenom = ""; }

        if (tel != "")
        { Tel = " AND Acquereurs.[tel] = '" + tel + "'"; }
        else { Tel = ""; }

        if (portable != "")
        { Portable = " AND Acquereurs.[portable] = '" + portable + "'"; }
        else { Portable = ""; }

        if (mail != "")
        { Mail = " AND Acquereurs.[mail] = '" + mail + "'"; }
        else { Mail = ""; }

        DateTime Date = new DateTime(0001, 01, 01, 00, 00, 00);
        String dateCreation = "";
        if (System.DateTime.Compare(Datedecreation, Date) != 0 && System.DateTime.Compare(Datedefin, Date) != 0)
        {
            dateCreation = " AND Acquereurs.[date_ajout] BETWEEN #" + Datedecreation.Day + "/" + Datedecreation.Month + "/" + Datedecreation.Year + "# AND #" + Datedefin.Day + "/" + Datedefin.Month + "/" + Datedefin.Year + "# ";
        }
        else
        {
            dateCreation = "";
        }

        //String Nom = " AND Acquereurs.[nom] = '" + nom + "'";

        //String Prenom = " AND Acquereurs.[prenom] = '" + prenom + "'";

        //String Tel = " AND Acquereurs.[tel] = '" + tel + "'";

        //String Portable = " AND Acquereurs.[tel] = '" + portable + "'";

        //String Mail = " AND Acquereurs.[mail] = '" + mail + "'";

        //String Date = " AND Acquereurs.[date_ajout] = '" + Datedecreation + "'";

        String etat = " AND Acquereurs.[etat_avancement] = '" + EtatAvancement + "'";

        String ascenseur = " AND Acquereurs.[ascenseur] = '" + asc + "'";

        String soussol = " AND Acquereurs.[sous-sol] ='" + sous + "'";

        String parking = " AND Acquereurs.[parking/box] = '" + park + "'";

        String typeBien = typebien();

        String idClientNego;
        if (idclient != 0)
        {
            idClientNego = "AND Acquereurs.[actif] LIKE 'archive' AND Acquereurs.[idclient]  =" + idclient;
        }
        else
            idClientNego = "AND Acquereurs.[actif] LIKE 'archive'";

        //permet de ne pas restreindre la recherche si l'utilisateur ne rempli pas la textBox surface Max
        if (surfaceMax == 0) surfaceMax = 999;

        if (surfaceSMax == 0) surfaceSMax = 999;

        if (facadeMax == 0) facadeMax = 999;

        if (profondeurMax == 0) profondeurMax = 999;


        //requete maison
        requeteSQLArchive = " SELECT * FROM Acquereurs WHERE " + typeacq + ville + budget + motCle + surface + surfaceS + surfaceT + facade + profondeur + nombreDePiece + nombreDeChambre + Nom + Prenom + Tel + Portable + Mail + dateCreation + typeBien + etat + ascenseur + soussol + parking + " AND Acquereurs.[actif] LIKE 'archive'";

        //requet appart
        if (appart.Contains("T"))
        {
            requeteSQLArchive = requeteSQLArchive + " UNION SELECT * FROM Acquereurs WHERE " + typeacq + ville + idClientNego + surface + surfaceS + surfaceT + facade + profondeur + budget + motCle + surface + nombreDePiece + nombreDeChambre + Nom + Prenom + Tel + Portable + Mail + dateCreation + typeBien + etat + ascenseur + soussol + parking + " AND Acquereurs.[actif] LIKE 'archive'";
        }

        requeteSQLArchive = requeteSQLArchive + requeteOrder;

    }

    private String typebien()
    {
        /*********************************************************************************************************
        *                       Test quel type de bien a été coché ( Appartement ou Maison):                     *
        *                     rempli la requète avec l'opération appropriée dans operationType                   *
        **********************************************************************************************************/
        String[] oper = new String[3];
        String[] operationType = new String[4];
        String typeBien = "";

        if (appart == "True") operationType[0] = " Acquereurs.[appartement]=" + appart;

        if (mais == "True")
        {
            operationType[1] = " Acquereurs.[maison]=" + mais;
            if (appart == "True") oper[0] = " OR";
            else oper[0] = "";
        }

        if (terr == "True")
        {
            operationType[2] = " Acquereurs.[terrain]=" + terr;
            if (appart == "True" || mais == "True") oper[1] = " OR";
            else oper[1] = "";
        }

        if (autr == "True")
        {
            operationType[3] = " Acquereurs.[autre]=" + autr;
            if (appart == "True" || mais == "True" || terr == "True") oper[2] = " OR";
            else oper[2] = "";
        }
        if (operationType[0] != null || oper[0] != null || operationType[1] != null || oper[1] != null || operationType[2] != null || oper[2] != null || operationType[3] != null)
        {
            if (operationType[0] != "" || oper[0] != "" || operationType[1] != "" || oper[1] != "" || operationType[2] != "" || oper[2] != "" || operationType[3] != "")
            {
                typeBien = " AND ( " + operationType[0] + oper[0] + operationType[1] + oper[1] + operationType[2] + oper[2] + operationType[3] + ") ";
            }
        }
        if (appart == "False" && mais == "False" && terr == "False" && autr == "False")
        {
            typeBien = " ";
        }
        //FIN DE TEST***********************************************************************************************************************************************************************

        return typeBien;
    
    }

    private String nombrePiece()
    {
        /*********************************************************************************************************
        *                       Test quel nombre de pièces a été coché :                                         *
        *                     rempli la requète avec l'opération appropriée dans operationType                   *
        **********************************************************************************************************/
        String[] operande = new String[7];
        String[] operationPiece = new String[8];
        String nombreDePiece = "";

        if (pieceAll) operationPiece[0] = " ";

        if (piece1) operationPiece[0] = "  Acquereurs.[nombre_de_pieces_min]=1 ";

        if (piece2)
        {
            operationPiece[1] = "  Acquereurs.[nombre_de_pieces_min]<=2 ";
            if (piece1) operande[0] = " OR ";
            else operande[0] = "";
            operationPiece[2] = "  Acquereurs.[nombre_de_pieces_max]>=2 ";
            operande[1] = " AND ";
            
        }
        if (piece3)
        {
            operationPiece[3] = "  Acquereurs.[nombre_de_pieces_min]<=3 ";
            if (piece2 || piece1 == true) operande[2] = " OR ";
            else operande[2] = "";
            operationPiece[4] = "  Acquereurs.[nombre_de_pieces_max]>=3 ";
            operande[3] = " AND ";
            
        }
        if (piece4)
        {
            operationPiece[5] = "  Acquereurs.[nombre_de_pieces_min]<=4 ";
            if (piece3 || piece2 || piece1) operande[4] = " OR ";
            else operande[4] = "";
            operationPiece[6] = "  Acquereurs.[nombre_de_pieces_max]>=4 ";
            operande[5] = " AND ";
            
        }
        if (piece5)
        {
            operationPiece[7] = "  Acquereurs.[nombre_de_pieces_max]>=5 ";
            if (piece4 || piece3 || piece2 || piece1) operande[6] = " OR ";
            else operande[6] = "";
        }
        if (operationPiece[0] != null || operande[0] != null || operationPiece[1] != null || operande[1] != null || operationPiece[2] != null || operande[2] != null || operationPiece[3] != null || operande[3] != null || operationPiece[4] != null || operande[4] != null || operationPiece[5] != null || operande[5] != null || operationPiece[6] != null || operande[6] != null || operationPiece[7] != null)
        {
            if(operationPiece[0] != "" || operande[0] != "" || operationPiece[1] != "" || operande[1] != "" || operationPiece[2] != "" || operande[2] != "" || operationPiece[3] != "" || operande[3] != "" || operationPiece[4] != "" || operande[4] != "" || operationPiece[5] != "" || operande [5] != "" || operationPiece[6] != "" || operande[6] != "" || operationPiece[7] != ""){
            nombreDePiece = "AND (" + operationPiece[0] + operande[0] + operationPiece[1] + operande[1] + operationPiece[2] + operande[2] + operationPiece[3] + operande[3] + operationPiece[4] + operande[4] + operationPiece[5] + operande [5] + operationPiece[6] + operande[6] + operationPiece[7] + ") ";
            }
        }
        if (piece5 == false && piece4 == false && piece3 == false && piece2 == false && piece1 == false || piece5 == true && piece4 == true && piece3 == true && piece2 == true && piece1 == true)
        {
            nombreDePiece = " ";
        }
        //FIN DE TEST***********************************************************************************************************************************************************************


        return nombreDePiece;
    }

    private String nombreChambre()
    {
        /*********************************************************************************************************
        *                       Test quel type de bien a été coché ( Appartement ou Maison):                     *
        *                     rempli la requète avec l'opération appropriée dans operationType                   *
        **********************************************************************************************************/
        String[] operande = new String[4];
        String[] operationChambre = new String[5];
        String nombreDeChambre = "";

        if (chambreAll) operationChambre[0] = " ";

        if (chambre1) operationChambre[0] = "  Acquereurs.[nombre_de_chambres]=1 ";

        if (chambre2)
        {
            operationChambre[1] = "  Acquereurs.[nombre_de_chambres]=2 ";
            if (chambre1) operande[0] = " OR ";
            else operande[0] = "";
        }
        if (chambre3)
        {
            operationChambre[2] = "  Acquereurs.[nombre_de_chambres]=3 ";
            if (chambre2 || chambre1 == true) operande[1] = " OR ";
            else operande[1] = "";
        }
        if (chambre4)
        {
            operationChambre[3] = "  Acquereurs.[nombre_de_chambres]=4 ";
            if (chambre3 || chambre2 || chambre1) operande[2] = " OR ";
            else operande[2] = "";
        }
        if (chambre5)
        {
            operationChambre[4] = "  Acquereurs.[nombre_de_chambres]>=5 ";
            if (chambre4 || chambre3 || chambre2 || chambre1) operande[3] = " OR ";
            else operande[3] = "";
        }
        if (operationChambre[0] != null || operande[0] != null || operationChambre[1] != null || operande[1] != null || operationChambre[2] != null || operande[2] != null || operationChambre[3] != null || operande[3] != null || operationChambre[4] != null)
        {
            if(operationChambre[0] != "" || operande[0] != "" || operationChambre[1] != "" || operande[1] != "" || operationChambre[2] != "" || operande[2] != "" || operationChambre[3] != "" || operande[3] != "" || operationChambre[4] != ""){
            nombreDeChambre = "AND (" + operationChambre[0] + operande[0] + operationChambre[1] + operande[1] + operationChambre[2] + operande[2] + operationChambre[3] + operande[3] + operationChambre[4] + ") ";
            }
        }
        if (chambre5 == false && chambre4 == false && chambre3 == false && chambre2 == false && chambre1 == false || chambre5 == true && chambre4 == true && chambre3 == true && chambre2 == true && chambre1 == true)
        {
            nombreDeChambre = " ";
        }
        //FIN DE TEST***********************************************************************************************************************************************************************


        return nombreDeChambre;
    }

    private bool verifChampSaisi()
    {
        Regex maRegexp = new Regex("^[0-9]+$");
        Regex maReg2 = new Regex("^[0-9]+$|^[a-zA-Zéèçàâù-]+$|^()+$");



        bool regSurfaceMin = maRegexp.IsMatch(surfaceMin.ToString());
        bool regSurfaceMax = maRegexp.IsMatch(surfaceMax.ToString());
        bool regNomVille1 = maReg2.IsMatch(ville1);

        bool regBudgetMin = maRegexp.IsMatch(prixMin.ToString());
        bool regBudgetMax = maRegexp.IsMatch(prixMin.ToString());

        if (regSurfaceMin == true && regSurfaceMax == true && regNomVille1 == true && regBudgetMin == true && regBudgetMax == true) return true;
        else return false;

    }

}