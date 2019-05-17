using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de Ville
/// </summary>
public class Ville
{
    public int id;
    public string nom;
    public string MAJ;
    public string cp;
    public string insee;
    public int codeRegion;
    public double eloignement;
    public double lattitude;
    public double longitude;
    public Ville(int id, string nom, string maj, string cp, string insee, double lattitude,double longitude)
    {
        this.id = id;
        this.nom = nom;
        this.MAJ = maj;
        this.cp = cp;
        this.insee = insee;
        this.lattitude = lattitude;
        this.longitude = longitude;
    }
}