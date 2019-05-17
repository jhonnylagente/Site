using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;


/// <summary>
/// classe qui permet de représenter un utilisateur de l'Adnim
/// </summary>
public class User
{

    #region propriétés
    private String nom;
    private String prenom;
    private String tel;
    private String agence;
    private Droit droits;
    private String mail;
    private String pass;
    private int id;
    #endregion


    #region getters setters
    /// <summary>
    /// get / set le nom de l'utilisateur
    /// </summary>
    public String Nom
    {
        get { return this.nom; }
        set { this.nom = value; }
    }


    /// <summary>
    /// get / set le prénom de l'utilisateur
    /// </summary>
    public String Prenom 
    {
        get { return this.prenom; }
        set { this.prenom = value; }
    }

    /// <summary>
    /// get / set le téléphone de l'utilisateur
    /// </summary>
    public String Tel 
    {
        get { return this.tel; }
        set { this.tel = value; }
    }

    /// <summary>
    /// get / set l'email de l'utilisateur
    /// </summary>
    public String Mail 
    {
        get { return this.mail; }
        set { this.mail = value; }
    }
    
    /// <summary>
    /// get / set les droits pour l'utilisateur
    /// </summary>
    public Droit DroitUtilisateur
    {
        get { return this.droits; }
        set { this.droits = value; }
    }

    /// <summary>
    /// get / set le pass pour l'utilisateur
    /// </summary>
    public String Pass 
    {
        get { return this.pass; }
        set { this.pass = value; }
    }

    /// <summary>
    /// get / set l'agence de l'utilisateur
    /// </summary>
    public String Agence 
    {
        get { return this.agence; }
        set { this.agence = value; }
    }


    /// <summary>
    /// get / set l'ID de l'utilisateur
    /// </summary>
    public int ID
    {
        get { return this.id; }
        set { this.id = value; }
    }

    #endregion // fin getters setters 




    /// <summary>
    /// construit un utilisateur vide qui n'a pas de droits
    /// </summary>
    public User()
    {
        this.nom = "";
        this.prenom = "";
        this.tel = "";
        this.agence = "";
        //pas de droit par defaut
        this.droits = Droit.None;
    }



}
