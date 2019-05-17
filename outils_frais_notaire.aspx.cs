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


   
public partial class outils_frais_notaire : System.Web.UI.Page
{
    public static Boolean flagMontantb;
    public static Boolean flagMontante;
  
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Page.Master.FindControl("titrebandeau")).Text = "Simulation";
    }
   

    
 

    public void calcul()
    {
        if (/*(flagMontantb == true)&(flagMontante == true)*/true)
    {
        Double Montantb = Convert.ToDouble(TextBoxMontantb.Text);
        Double Montante = Convert.ToDouble (TextBoxMontante.Text);
        Int32 Result;
       switch ((DropDownListSelection.SelectedIndex))
       {
           case 0:
               TextBoxResultf.Text = "choisir l'etat du bien";
               break;
           case 1 :
               //neuf

               Result = Convert.ToInt32(((Montantb * 0.78936) / 100) +
                                 ((Montantb * 0.615) / 100) +
                         ((Montantb * 0.10) / 100) +
                         ((Montante * 0.6578) / 100) +
                         ((Montante * 0.05) / 100));
               if (Montantb != 0) { Result = Result + 1044; }
               if (Montante != 0) { Result = Result + 615; }
               TextBoxResultf.Text = Convert.ToString(Result);
               break;
                   
           case 2 :
               //ancien
               Result = Convert.ToInt32(((Montantb * 0.9867) / 100) +
                         ((Montantb * 4.89) / 100) +
                         ((Montantb * 0.10) / 100) +
                         ((Montante * 0.6578) / 100) +
                         ((Montante * 0.05) / 100));

               if (Montantb != 0) { Result = Result + 1524; }
               if (Montante != 0) { Result = Result + 615; }

               TextBoxResultf.Text = Convert.ToString(Result);
               break;
       }

    }
    }

        /*
        var s = document.form.sel.selectedIndex;
        if (document.form.mont.value == "")
        {
            alert("Veuillez saisir le montant du bien");
            document.form.mont.focus();
            return;
        }
        if (document.form.emprunt.value == "")
        {
            alert("Veuillez saisir le montant de votre emprunt");
            document.form.emprunt.focus();
            return;
        }
        if (s == 0)
        {
            alert("Vous devez indiquer si le bien est neuf ou ancien");
            return;
        }

        mtbien = parseInt(document.form.mont.value);
        mtemprunt = parseInt(document.form.emprunt.value);

        if (s == 1)
        { // NEUF
            montant = Math.round(((mtbien * 0.78936) / 100) +
                                 ((mtbien * 0.615) / 100) +
                         ((mtbien * 0.10) / 100) +
                         ((mtemprunt * 0.6578) / 100) +
                         ((mtemprunt * 0.05) / 100));

            if (mtbien != "0") { montant = montant + 1044; }
            if (mtemprunt != "0") { montant = montant + 615; }

            document.form.total.value = montant;
        }

        if (s == 2)
        { //ANCIEN
            montant = Math.round(((mtbien * 0.9867) / 100) +
                         ((mtbien * 4.89) / 100) +
                         ((mtbien * 0.10) / 100) +
                         ((mtemprunt * 0.6578) / 100) +
                         ((mtemprunt * 0.05) / 100));

            if (mtbien != "0") { montant = montant + 1524; }
            if (mtemprunt != "0") { montant = montant + 615; }

            document.form.total.value = montant;
        }

    }*/



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



   

    protected void ButtonCalculer_Click1(object sender, EventArgs e)
    {
        calcul();
    }

    protected void TextBoxTaux_TextChanged(object sender, EventArgs e)
    {
        TextBoxMontantb.Text = remplace(TextBoxMontantb.Text);
        if (IsNumeric(TextBoxMontantb.Text))
        {
            flagMontantb = true;
        }
        else
        {
            flagMontantb = false;
        }
    }
    protected void TextBoxMensualité_TextChanged(object sender, EventArgs e)
    {
        TextBoxMontante.Text = remplace(TextBoxMontante.Text);
        if (IsNumeric(TextBoxMontante.Text))
        {
            flagMontante = true;
        }
        else
        {
            flagMontante = false;
        }
    }
  
    
    /*
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    DropDownList DropDownList1 = new DropDownList();
    PlaceHolder PlaceHolder1 = new PlaceHolder();
  
  // Get the number of labels to create.
 int numlabels = System.Convert.ToInt32(DropDownList1.SelectedItem.Text);
 for (int i=1; i<=numlabels; i++)
 {
   Label myLabel = new Label();
     
   // Set the label's Text and ID properties.
   myLabel.Text = "Label" + i.ToString();
   myLabel.ID = "Label" + i.ToString();
   PlaceHolder1.Controls.Add(myLabel);
   // Add a spacer in the form of an HTML <br /> element.
   PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
 } 
}
     * 
     */


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void TextBoxResultf_TextChanged(object sender, EventArgs e)
    {

    }

    protected void ButtonEffacer_Click(object sender, EventArgs e)
    {
        TextBoxMontantb.Text= "";
        TextBoxMontante.Text = "";
        TextBoxResultf.Text = "";
        DropDownListSelection.SelectedIndex = 0;
    }
}
