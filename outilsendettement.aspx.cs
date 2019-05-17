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

partial class outilsendettement : System.Web.UI.Page
{
    
    public static Boolean flagSalaireMensuel;
    public static Boolean flagMultiMoisSalaire;
    public static Boolean flagSalaireMensuelConjoint;
    public static Boolean flagMultiSalaireConjoint;
    public static Boolean flagAllocationsFamiliales;
    public static Boolean flagMultAllocationsFamiliales;
    public static Boolean flagAutresRevenus;
    public static Boolean flagTotalRevenusAnnuels;
    public static Boolean flagMensualitésEmpruntEnCours;
    public static Boolean flagMultiMensualitésEmprunt;
    public static Boolean flagAutresChargesMensuelles;
    public static Boolean flagMultiAutresChargesMensuelles;
    public static Boolean flagTotalChargesAnnuelles;
    public static Boolean flagRevenusAnnuelsDisponibles;
    public static Boolean flagPlafondEndettement;
    public static Boolean flagAnnuitéMaximumuPossible;
    public static Boolean flagMensualitéMaximumPossible;
   
   
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Page.Master.FindControl("titrebandeau")).Text = "Simulation";
	
      flagSalaireMensuel=true;
      flagMultiMoisSalaire = true;
      flagSalaireMensuelConjoint = true;
      flagMultiSalaireConjoint = true;
      flagAllocationsFamiliales = true;
      flagMultAllocationsFamiliales = true;
      flagAutresRevenus = true;
      flagTotalRevenusAnnuels = true;
      flagMensualitésEmpruntEnCours = true;
      flagMultiMensualitésEmprunt = true;
      flagAutresChargesMensuelles = true;
      flagMultiAutresChargesMensuelles = true;
      flagTotalChargesAnnuelles = true;
      flagRevenusAnnuelsDisponibles = true;
      flagPlafondEndettement = true;
      flagAnnuitéMaximumuPossible = true;
      flagMensualitéMaximumPossible = true;

    }

    

    protected void SalaireMensuel_TextChanged(object sender, EventArgs e)
    {
        SalaireMensuel.Text = remplace(SalaireMensuel.Text);
        if (IsNumeric(SalaireMensuel.Text))
        {
            flagSalaireMensuel = true;
        }
        else
        {
            flagSalaireMensuel = false;
        }
    }
    
  
    protected void MultiMoisSalaire_TextChanged(object sender, EventArgs e)
    {
        MultiMoisSalaire.Text = remplace(MultiMoisSalaire.Text);
        if (IsNumeric(MultiMoisSalaire.Text))
        {
            flagMultiMoisSalaire = true;
        }
        else
        {
            flagMultiMoisSalaire = false;
        }
    }
    protected void SalaireMensuelConjoint_TextChanged(object sender, EventArgs e)
    {
        SalaireMensuelConjoint.Text = remplace(SalaireMensuelConjoint.Text);
        if (IsNumeric(SalaireMensuelConjoint.Text))
        {
            flagSalaireMensuelConjoint = true;
        }
        else
        {
            flagSalaireMensuelConjoint = false;
        }
    }

    protected void MultiSalaireConjoint_TextChanged(object sender, EventArgs e)
    {
        MultiSalaireConjoint.Text = remplace(MultiSalaireConjoint.Text);
        if (IsNumeric(MultiSalaireConjoint.Text))
        {
            flagMultiSalaireConjoint = true;
        }
        else
        {
            flagMultiSalaireConjoint = false;
        }
    }
    protected void AllocationsFamiliales_TextChanged(object sender, EventArgs e)
    {
        AllocationsFamiliales.Text = remplace(AllocationsFamiliales.Text);
        if (IsNumeric(AllocationsFamiliales.Text))
        {
            flagAllocationsFamiliales = true;
        }
        else
        {
            flagAllocationsFamiliales = false;
        }
    }
    protected void MultAllocationsFamiliales_TextChanged(object sender, EventArgs e)
    {
        MultAllocationsFamiliales.Text = remplace(MultAllocationsFamiliales.Text);
        if (IsNumeric(MultAllocationsFamiliales.Text))
        {
            flagMultAllocationsFamiliales = true;
        }
        else
        {
            flagMultAllocationsFamiliales = false;
        }
    }
    protected void AutresRevenus_TextChanged(object sender, EventArgs e)
    {
        AutresRevenus.Text = remplace(AutresRevenus.Text);
        if (IsNumeric(AutresRevenus.Text))
        {
            flagAutresRevenus = true;
        }
        else
        {
            flagAutresRevenus = false;
        }
    }
    protected void TotalRevenusAnnuels_TextChanged(object sender, EventArgs e)
    {
        TotalRevenusAnnuels.Text = remplace(TotalRevenusAnnuels.Text);
        if (IsNumeric(TotalRevenusAnnuels.Text))
        {
            flagTotalRevenusAnnuels = true;
        }
        else
        {
            flagTotalRevenusAnnuels = false;
        }
    }
    protected void MensualitésEmpruntEnCours_TextChanged(object sender, EventArgs e)
    {
        MensualitésEmpruntEnCours.Text = remplace(MensualitésEmpruntEnCours.Text);
        if (IsNumeric(MensualitésEmpruntEnCours.Text))
        {
            flagMensualitésEmpruntEnCours = true;
        }
        else
        {
            flagMensualitésEmpruntEnCours = false;
        }
    }
    protected void MultiMensualitésEmprunt_TextChanged(object sender, EventArgs e)
    {
        MultiMensualitésEmprunt.Text = remplace(MultiMensualitésEmprunt.Text);
        if (IsNumeric(MultiMensualitésEmprunt.Text))
        {
            flagMultiMensualitésEmprunt = true;
        }
        else
        {
            flagMultiMensualitésEmprunt = false;
        }
    }
    protected void AutresChargesMensuelles_TextChanged(object sender, EventArgs e)
    {
        AutresChargesMensuelles.Text = remplace(AutresChargesMensuelles.Text);
        if (IsNumeric(AutresChargesMensuelles.Text))
        {
            flagAutresChargesMensuelles = true;
        }
        else
        {
            flagAutresChargesMensuelles = false;
        }
    }
    protected void MultiAutresChargesMensuelles_TextChanged(object sender, EventArgs e)
    {
        MultiAutresChargesMensuelles.Text = remplace(MultiAutresChargesMensuelles.Text);
        if (IsNumeric(MultiAutresChargesMensuelles.Text))
        {
            flagMultiAutresChargesMensuelles = true;
        }
        else
        {
            flagMultiAutresChargesMensuelles = false;
        }
    }
    protected void TotalChargesAnnuelles_TextChanged(object sender, EventArgs e)
    {
        TotalChargesAnnuelles.Text = remplace(TotalChargesAnnuelles.Text);
        if (IsNumeric(TotalChargesAnnuelles.Text))
        {
            flagTotalChargesAnnuelles = true;
        }
        else
        {
            flagTotalChargesAnnuelles = false;
        }
    }
    protected void RevenusAnnuelsDisponibles_TextChanged(object sender, EventArgs e)
    {
        RevenusAnnuelsDisponibles.Text = remplace(RevenusAnnuelsDisponibles.Text);
        if (IsNumeric(RevenusAnnuelsDisponibles.Text))
        {
            flagRevenusAnnuelsDisponibles = true;
        }
        else
        {
            flagRevenusAnnuelsDisponibles = false;
        }
    }
    protected void PlafondEndettement_TextChanged(object sender, EventArgs e)
    {
        PlafondEndettement.Text = remplace(PlafondEndettement.Text);
        if (IsNumeric(PlafondEndettement.Text))
        {
            flagPlafondEndettement = true;
        }
        else
        {
            flagPlafondEndettement = false;
        }
    }
    protected void AnnuitéMaximumuPossible_TextChanged(object sender, EventArgs e)
    {
        AnnuitéMaximumuPossible.Text = remplace(AnnuitéMaximumuPossible.Text);
        if (IsNumeric(AnnuitéMaximumuPossible.Text))
        {
            flagAnnuitéMaximumuPossible = true;
        }
        else
        {
            flagAnnuitéMaximumuPossible = false;
        }
    }
    protected void MensualitéMaximumPossible_TextChanged(object sender, EventArgs e)
    {
        MensualitéMaximumPossible.Text = remplace(MensualitéMaximumPossible.Text);
        if (IsNumeric(MensualitéMaximumPossible.Text))
        {
            flagMensualitéMaximumPossible = true;
        }
        else
        {
            flagMensualitéMaximumPossible = false;
        }
    }

    protected void ButtonCalculRevenus_Click(object sender, EventArgs e)
    {
        if  (flagSalaireMensuel & flagMultiMoisSalaire & flagSalaireMensuelConjoint & flagMultiSalaireConjoint & flagAllocationsFamiliales & flagMultAllocationsFamiliales & flagAutresRevenus)
        CalculRevenus();
    }

    protected void CalculRevenus()
    {
        Double SalaireM = Convert.ToDouble(SalaireMensuel.Text);
        Double MultiMoisS = Convert.ToDouble(MultiMoisSalaire.Text);
        Double SalaireMensuelc = Convert.ToDouble(SalaireMensuelConjoint.Text);
        Double MultiSalairec = Convert.ToDouble(MultiSalaireConjoint.Text);
        Double Allocationsf = Convert.ToDouble(AllocationsFamiliales.Text);
        Double MultAllocf = Convert.ToDouble(MultAllocationsFamiliales.Text);
        Double AutresR = Convert.ToDouble(AutresRevenus.Text);
        Double Result;
        Result = SalaireM * MultiMoisS + SalaireMensuelc * MultiSalairec + Allocationsf * MultAllocf + AutresR;
        TotalRevenusAnnuels.Text = Convert.ToString(Result);
        flagTotalRevenusAnnuels = true;
    }


    protected void ButtonTotalChargesAnnuels_Click(object sender, EventArgs e)
    {
        if (flagMultiMensualitésEmprunt & flagMultiMensualitésEmprunt & flagAutresChargesMensuelles & flagMultiAutresChargesMensuelles)
        CalculCharges();
    }
    protected void CalculCharges()
    {
        Double Mensualitée = Convert.ToDouble(MensualitésEmpruntEnCours.Text);
        Double MultiMensualitée = Convert.ToDouble(MultiMensualitésEmprunt.Text);
        Double Autrescm = Convert.ToDouble(AutresChargesMensuelles.Text);
        Double MultiAutrescs = Convert.ToDouble(MultiAutresChargesMensuelles.Text);
        Double Resultc;
        Resultc = Mensualitée * MultiMensualitée + Autrescm * MultiAutrescs;
        TotalChargesAnnuelles.Text = Convert.ToString(Resultc);
        flagTotalChargesAnnuelles = true;
    }

    protected void ButtonCalcul_Click(object sender, EventArgs e)
    {
        if (flagTotalRevenusAnnuels & flagTotalChargesAnnuelles)
        CalculFinal();
    }

    protected void CalculFinal()
    {
        Double Revenusad = Convert.ToDouble(TotalRevenusAnnuels.Text);
        Double Chargesa = Convert.ToDouble(TotalChargesAnnuelles.Text);
        RevenusAnnuelsDisponibles.Text = Convert.ToString(Revenusad - Chargesa);
        Double Plafe = Convert.ToDouble(PlafondEndettement.Text);
        AnnuitéMaximumuPossible.Text = Convert.ToString((Revenusad - Chargesa) * Plafe / 100);
        MensualitéMaximumPossible.Text = Convert.ToString((Revenusad - Chargesa) * Plafe / 1200);
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
 
}
