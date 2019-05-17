using System;
using System.Data;
using System.Data.Odbc;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Globalization;
/// <summary>
/// Description résumée de Class1
/// </summary>
public partial class popup : System.Web.UI.Page
{
    
    string _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    public static OdbcConnection db   = new OdbcConnection();
    public static OdbcConnection db2 = new OdbcConnection();
    protected String idvisite;
    
    protected void addnote_onclick(object sender, EventArgs e)
	{
        idvisite = Request.QueryString["id_visite"];

                
            var memory = textarea1.Text;
            OdbcCommand update = new OdbcCommand();
            update.CommandType = System.Data.CommandType.Text;
            update.CommandText = "UPDATE visite SET Memo = '" + memory + "' WHERE id_visite = '" + idvisite + "'";
            db2 = new OdbcConnection(_ConnectionString);
            update.Connection = db2;
            db2.Open(); 
            update.ExecuteNonQuery();
            db2.Close();
            Response.Write("<body><script>window.opener.location.reload();opener=parent;parent.close();</script></body>");
        
	}
    /*protected void modnote_onclick(object sender, EventArgs e)
    {
               
    }*/

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }  
    protected void Page_Init(object sender, EventArgs e)
{
    {
        idvisite = Request.QueryString["id_visite"];
        
            
            String sql1 = "SELECT visite.Memo, visite.id_bien  FROM visite WHERE visite.id_visite = '" + idvisite + "'";
        using (OdbcConnection db =
            new OdbcConnection(_ConnectionString))
            {
                // Create the Command and Parameter objects.
                OdbcCommand command = new OdbcCommand(sql1, db);
                OdbcCommand command2 = new OdbcCommand();
                command2.CommandType = System.Data.CommandType.Text;
                command2.Connection = db;
                

                // Open the connection in a try/catch block. 
                // Create and execute the DataReader, writing the result
                // set to the console window.

                db.Open();
            OdbcDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                textarea1.Text = reader[0].ToString();
                reference_bien.Text = (String)reader[1];
                string ref_bien = reference_bien.Text;
                command2.CommandText = "SELECT Biens.disponibilité, Biens.[prix de vente], Biens.[type de bien], Biens.[ville vendeur], Biens.[code postal vendeur], Biens.[nombre de pieces], Biens.[surface séjour], Biens.[surface habitable], Biens.[surface terrain], Biens.etat FROM Biens WHERE Biens.ref = '" + ref_bien + "'";
                OdbcDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {

                    Prix.Text = reader2[1].ToString();
                    if ((String)reader2[2] == "M")
                        Type_de_bien.Text = "Maison";
                    else if ((String)reader2[2] == "A")
                        Type_de_bien.Text = "Appartement";
                    else if ((String)reader2[2] == "L")
                        Type_de_bien.Text = "Local";
                    else if ((String)reader2[2] == "T")
                        Type_de_bien.Text = "Terrain";
                    else if ((String)reader2[2] == "I")
                        Type_de_bien.Text = "Immeuble";
                    Localisation.Text = "" + (String)reader2[3] + "(" + (String)reader2[4] + ")";

                }
                reader2.Close();
            }
            reader.Close();
               
                db.Close();

            }


        }


    }


}
