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

public partial class outils_calcu_duree : System.Web.UI.Page
{
    public static Boolean flagMontantt;
    public static Boolean flagMontantm;
    public static Boolean flagMontant;
    public static Int32 mintaux = 0;
    public static Int32 maxtaux = 20;
    public static Int32 maxcap = 10000000;
    public static Int32 mincap = 5000;
    public static Int32 minmens = 100;
    public static Int32 maxmens = 100000;
    public static Int32 mindur = 2;
    public static Int32 maxdur = 40;
    public static Boolean flagCredit;

    protected void Page_Load(object sender, EventArgs e)
    {
		((Label)Page.Master.FindControl("titrebandeau")).Text = "Simulation";
    }

    protected void TextBoxTauxAssu_TextChanged(object sender, EventArgs e)
    {
        TextBoxTaux.Text = remplace(TextBoxTaux.Text);  
    }



protected void TextBoxMensualité_TextChanged(object sender, EventArgs e)
    {
       TextBoxMensualité.Text = remplace(TextBoxMensualité.Text);

    }


    protected void TextBoxMontant_TextChanged(object sender, EventArgs e)
    {
       TextBoxMontant.Text = remplace(TextBoxMontant.Text);


    }

    protected void TextBoxCredit_TextChanged(object sender, EventArgs e)
    {

    }
  
    protected void ButtonCalculer_Click(object sender, EventArgs e)
    {
        calcul();
    }
    protected void ButtonEffacer_Click(object sender, EventArgs e)
    {
        LabelErreur.Text = "";
        TextBoxTaux.Text = "";
        TextBoxMensualité.Text = "";
        TextBoxMontant.Text = "";
        TextBoxCredit.Text = "";

    }
  
     
    protected void verifTaux()
    {
        flagMontantt = false;
           if (IsNumeric(TextBoxTaux.Text) == false)
           {
               flagMontantt = false;
               
           }
           else
           {
               flagMontantt = true;
               Double t;
               t = Convert.ToDouble(TextBoxTaux.Text);
               if (t < mintaux)
               {
                   LabelErreur.Text = ("Veuillez saisir un taux supérieur à " + mintaux + "<br />");
                   
                    flagMontantt = false; 
                   
               }

               if (t > maxtaux)
               {
                   LabelErreur.Text = "Veuillez saisir un taux inférieur à " + maxtaux + "<br />";
               
                   flagMontantt = false;
               }

           }
}


    protected void verifMensualité()
    {
        flagMontantm = false;
      if (IsNumeric(TextBoxMensualité.Text) == false)
            {
               
                flagMontantm = false;
            }
            else
            {
                flagMontantm = true;
                Double m;
                m = Convert.ToDouble(TextBoxMensualité.Text);
                if (m < minmens)
                {
                    LabelErreur.Text =LabelErreur.Text+ "Veuillez saisir une mensualité supérieur à " + minmens+"<br />";
                   
                    flagMontantm = false;
                }
                if (m > maxmens)
                {
                    LabelErreur.Text = LabelErreur.Text + "Veuillez saisir une mensualité inférieur à " + maxmens + "<br />";
                 
                    flagMontantm = false;
                }
            }
        }
    
    protected void verifMontant()
    {
        flagMontant = false;
      if (IsNumeric(TextBoxMontant.Text) == false)
            {
                flagMontant = false;
            }
            else
            {
                flagMontant = true;
                Double d;
                d = Convert.ToDouble(TextBoxMontant.Text);
                if (d < mincap)
                {
                    LabelErreur.Text = LabelErreur.Text + "Veuillez saisir un montant supérieur à " + mincap + "<br />";
                    flagMontant = false;
                    
                }
                if (d > maxcap)
                {
                    LabelErreur.Text = LabelErreur.Text + ("Veuillez saisir un montant inférieur à " + maxcap) + "<br />";
                    flagMontant = false;
                    
                }
            }
        }

    static bool IsNumeric(object Expression)
    {
        // Variable to collect the Return value of the TryParse method.

        bool isNum;

        // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
        double retNum;


        Regex myRegex;
         myRegex = new Regex("((\\,)(\\d)*){2,}");
        // Si on a plus de 2 ","
         if (myRegex.IsMatch(Convert.ToString(Expression)))
         {
             return false;
         }
         else
         {
             // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
             // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
             isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
             return isNum;
         }
    }

    private string remplace(string chaine)
    {
        System.Text.RegularExpressions.Regex myRegex = new Regex("(\\.)");
        return myRegex.Replace(chaine, ","); 
            //renvoi la chaine modifiée
    }




    public void calcul()
    {
        /*TextBoxTaux.Attributes.Add("style", "color:black");
        TextBoxMensualité.Attributes.Add("style", "color:black");
        TextBoxMontant.Attributes.Add("style", "color:black");
        
         * */

       
        
       LabelErreur.Text = "";
        TextBoxCredit.Text = "";
        verifTaux();
        verifMensualité();
        verifMontant();


        if ((flagMontantt == true) & (flagMontantm == true) & (flagMontant == true))
        {

            Double Montantt = (Convert.ToDouble(TextBoxTaux.Text) / 1200);
            Double Montantm = Convert.ToDouble(TextBoxMensualité.Text);
            Double Montant = (Convert.ToDouble(TextBoxMontant.Text));

            Double Result = calculn(Montantt, Montant, Montantm);

            if (Result == 0)
            {
                LabelErreur.Text = LabelErreur.Text + "Cette solution n'est pas réaliste, modifiez l'un des paramètres." + "<br />";
            }
            else
            {
                Double ResultR = Math.Round((Result), 0);
                Double ResultAns = Math.Round((Result/12),0);
                TextBoxCredit.Text = ResultR.ToString("### ### ### ###") + " mois (" + (ResultAns) + " ans)";
            }
        }
       
        }


private Double calculn(Double i,Double cap, Double m)
{
    Double n;
		for(n = 0; ((cap > 0)&(n<600)); n++)
        {
			cap = ( cap * ( 1 + i)) - m;
		
		}

		//n /= 12;

		if (n < 0){
			return 0;
		}

		if (n > 40*12){
           return 0;
		}

		return (n);

}

    private Double power(Double a, Double dure)
    {
        
		Double p = 1;
        for (Int32 j = 0; j < (dure); j++)
        {
            p *= (1 + a);
        }

		return p;	      
}




  
}
