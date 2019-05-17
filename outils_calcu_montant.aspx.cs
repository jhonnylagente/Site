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


public partial class outils_calcu_montant : System.Web.UI.Page
{
    public static Boolean flagMontantt;
    public static Boolean flagMontantta;
    public static Boolean flagMontantm;
    public static Boolean flagMontantd;
    public static Int32 mintaux = 0;
    public static Int32 maxtaux = 20;
    public static Int32 maxcap = 10000000;
    public static Int32 mincap = 5000;
    public static Int32 minmens = 100;
    public static Int32 maxmens = 10000;
    public static Int32 mindur = 5;
    public static Int32 maxdur = 40;
    public static Boolean flagCredit;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Page.Master.FindControl("titrebandeau")).Text = "Simulation";
    }



    protected void verifTauxAssu()
    {
    
        flagMontantta = false;
           if (IsNumeric(TextBoxTauxAssu.Text) == false)
           {
               flagMontantta = false;
               
           }
           else
           {
               flagMontantta = true;
               Double t;
               t = Convert.ToDouble(TextBoxTauxAssu.Text);
               if (t < mintaux)
               {
                   LabelErreur.Text = "Veuillez saisir un taux supérieur à " + mintaux + "<br />";
                   flagMontantta = false;
               }

               if (t > maxtaux)
               {
                   LabelErreur.Text = "Veuillez saisir un taux inférieur à " + maxtaux + "<br />";
                   flagMontantta = false;
               }

           }
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
                LabelErreur.Text = "Veuillez saisir un taux supérieur à " + mintaux + "<br />";
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
                    LabelErreur.Text = LabelErreur.Text + "Veuillez saisir une mensualité supérieure à " + minmens + "<br />";
                    flagMontantm = false;
                }
                if (m > maxmens)
                {
                    LabelErreur.Text = LabelErreur.Text + "Veuillez saisir une mensualité inférieure à " + maxmens + "<br />";
                    flagMontantm = false;
                }
            }
        }









    protected void verifDurée()
    {

        flagMontantd = false;
        if (DropDownListDurée.SelectedIndex == 0)
        {
            flagMontantd = false;
        }
        else
        {
            flagMontantd = true;
        }
    }






protected void  TextBoxTaux_TextChanged(object sender, EventArgs e)
{
    TextBoxTaux.Text = remplace(TextBoxTaux.Text);
}

protected void TextBoxTauxAssu_TextChanged(object sender, EventArgs e)
    {
        TextBoxTauxAssu.Text = remplace(TextBoxTauxAssu.Text); 
    }

protected void TextBoxMensualité_TextChanged(object sender, EventArgs e)
    {
        TextBoxMensualité.Text = remplace(TextBoxMensualité.Text);
    }


  
  
    protected void ButtonCalculer_Click(object sender, EventArgs e)
    {
        calcul();
    }
    protected void ButtonEffacer_Click(object sender, EventArgs e)
    {
        TextBoxPret.Text = "";
        TextBoxTauxAssu.Text = "";
        TextBoxTaux.Text = "";
        TextBoxMensualité.Text = "";
        DropDownListDurée.SelectedIndex = 0;
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
        return myRegex.Replace(chaine, ","); //renvoi la chaine modifiée
    }




   

    public void calcul()
    {
        LabelErreur.Text = "";
        TextBoxPret.Text = "";
        verifTaux();
        verifTauxAssu();
        verifMensualité();
        verifDurée();

        if ((flagMontantt == true) & (flagMontantta == true) & (flagMontantm == true) & (flagMontantd == true))
        {

            Double Montantt = (Convert.ToDouble(TextBoxTaux.Text) / 1200);
            Double Montantm = Convert.ToDouble(TextBoxMensualité.Text);
            Double Montantd = (Convert.ToDouble(DropDownListDurée.SelectedIndex) * 12);
            Double Result;
            Double pow;

            pow = power(Montantt, Montantd);
            Result = Convert.ToDouble(Montantm * (pow - 1) / (pow * Montantt));
            Double ResultR = Math.Round((Result), 0);
            TextBoxPret.Text = ResultR.ToString("### ### ### ###") + " Euros";
           
        }
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


    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {


    }

    protected void DropDownListDurée_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void TextBoxPret_TextChanged(object sender, EventArgs e)
    {

    }
}