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



partial class convertisseur: System.Web.UI.Page
{
    public static int flagCalculer;

 public void Page_Load(object sender, EventArgs e)
    {
     flagCalculer=0;
     ((Label)Page.Master.FindControl("titrebandeau")).Text = "Simulation";
    }

   
    public void TextBoxm_TextChanged(object sender, System.EventArgs e)
    {

        TextBoxm.Text = remplace(TextBoxm.Text);
        if (IsNumeric(TextBoxm.Text))
        {
            flagCalculer = 1;
        }
        else
        {
            flagCalculer = 0;
        }
    }


    public void TextBoxf_TextChanged(object sender, System.EventArgs e)
    {

        TextBoxf.Text = remplace(TextBoxf.Text);

        if (IsNumeric(TextBoxf.Text))
        {
            flagCalculer = 2;
        }
        else
        {
            flagCalculer = 0;
        }
    }

    public void TextBoxa_TextChanged(object sender, System.EventArgs e)
    {

        TextBoxa.Text = remplace(TextBoxa.Text);
        if (IsNumeric(TextBoxa.Text))
        {
            flagCalculer = 3;
        }
        else
        {
            flagCalculer = 0;
        }
    }

    public void TextBoxy_TextChanged(object sender, System.EventArgs e)
    {

        TextBoxy.Text = remplace(TextBoxy.Text);
        if (IsNumeric(TextBoxy.Text))
        {
            flagCalculer = 4;
        }
        else
        {
            flagCalculer = 0;
        }
    }

    public void TextBoxh_TextChanged(object sender, System.EventArgs e)
    {

        TextBoxf.Text = remplace(TextBoxf.Text);
        if (IsNumeric(TextBoxh.Text))
        {
            flagCalculer = 5;
        }
        else
        {
            flagCalculer = 0;
        }
    }

    public void TextBoxc_TextChanged(object sender, System.EventArgs e)
    {

        TextBoxc.Text = remplace(TextBoxc.Text);
        if (IsNumeric(TextBoxc.Text))
        {
            flagCalculer = 6;
        }
        else
        {
            flagCalculer = 0;
        }
    }




    private void Calcul()
    {
        switch ((flagCalculer))
        {
           
            case 1:
                Double lavariable1 = Convert.ToDouble(TextBoxm.Text);
                TextBoxm.Text = TextBoxm.Text;
                TextBoxf.Text = Convert.ToString(lavariable1 * 10.76391);
                TextBoxa.Text = Convert.ToString(lavariable1 * 0.01);
                TextBoxy.Text = Convert.ToString(lavariable1 * 1.19599);
                TextBoxh.Text = Convert.ToString(lavariable1 * 0.0001);
                TextBoxc.Text = Convert.ToString(lavariable1 * 0.000247105);
                break;
            case 2:
                Double lavariable2 = Convert.ToDouble(TextBoxf.Text);
                TextBoxm.Text = Convert.ToString(lavariable2 * 0.09290304);
                TextBoxf.Text = Convert.ToString(lavariable2);
                TextBoxa.Text = Convert.ToString(lavariable2 * 0.00092903);
                TextBoxy.Text = Convert.ToString(lavariable2 * 0.111111);
                TextBoxh.Text = Convert.ToString(lavariable2 * 9.2903E-06);
                TextBoxc.Text = Convert.ToString(lavariable2 * 2.29568E-05);
                break;
            case 3:
                Double lavariable3 = Convert.ToDouble(TextBoxa.Text);
                TextBoxm.Text = Convert.ToString(lavariable3 * 100);
                TextBoxf.Text = Convert.ToString(lavariable3 * 1076.39104);
                TextBoxa.Text = Convert.ToString(lavariable3);
                TextBoxy.Text = Convert.ToString(lavariable3 * 119.599);
                TextBoxh.Text = Convert.ToString(lavariable3 * 0.01);
                TextBoxc.Text = Convert.ToString(lavariable3 * 0.0247105);
                break;

            case 4:
                Double lavariable4 = Convert.ToDouble(TextBoxy.Text);
                TextBoxm.Text = Convert.ToString(lavariable4 * 0.83612736);
                TextBoxf.Text = Convert.ToString(lavariable4 * 9);
                TextBoxa.Text = Convert.ToString(lavariable4 * 0.00836127);
                TextBoxy.Text = Convert.ToString(lavariable4);
                TextBoxh.Text = Convert.ToString(lavariable4 * 8.36127E-05);
                TextBoxc.Text = Convert.ToString(lavariable4 * 0.000206612);
                break;
            case 5:

                Double lavariable5 = Convert.ToDouble(TextBoxh.Text);
                TextBoxm.Text = Convert.ToString(lavariable5 * 10000);
                TextBoxf.Text = Convert.ToString(lavariable5 * 107639.10417);
                TextBoxa.Text = Convert.ToString(lavariable5 * 100);
                TextBoxy.Text = Convert.ToString(lavariable5 * 11959.90046);
                TextBoxh.Text = Convert.ToString(lavariable5);
                TextBoxc.Text = Convert.ToString(lavariable5 * 2.47105);
                break;
            case 6:

                Double lavariable6 = Convert.ToDouble(TextBoxc.Text);
                TextBoxm.Text = Convert.ToString(lavariable6 * 4046.8564224);
                TextBoxf.Text = Convert.ToString(lavariable6 * 43560);
                TextBoxa.Text = Convert.ToString(lavariable6 * 40.46856);
                TextBoxy.Text = Convert.ToString(lavariable6 * 4840);
                TextBoxh.Text = Convert.ToString(lavariable6 * 0.404686);
                TextBoxc.Text = Convert.ToString(lavariable6);
                break;
            case 0:
                TextBoxm.Text = "0";
                TextBoxf.Text = "0";
                TextBoxa.Text = "0";
                TextBoxy.Text = "0";
                TextBoxh.Text = "0";
                TextBoxc.Text = "0";
                break;
        }
    }

 
    public void ButtonCalculer_Click(object sender, System.EventArgs e)
    {
        Calcul();
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
      return myRegex.Replace(chaine,","); //renvoi la chaine modifiée
  }
    
}
