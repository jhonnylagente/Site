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


public partial class outils_calcu_mensualite : System.Web.UI.Page
{



    public static Boolean flagMontantt;
    public static Boolean flagMontantta;
    public static Boolean flagMontantm;
    public static Boolean flagMontantd;
    public static Int32 mintaux = 0;
    public static Int32 maxtaux = 10000;
    public static Int32 maxcap = 1000000000;
    public static Int32 mincap = 1;
    public static Int32 minmens = 1;
    public static Int32 maxmens = 1000000000;
    public static Int32 mindur = 1;
    public static Int32 maxdur = 1000;
    public static Boolean flagCredit;

    protected void Page_Load(object sender, EventArgs e)
    {
        ((Label)Page.Master.FindControl("titrebandeau")).Text = "Simulation";
    }

    protected void verifMontantt()
    {
        flagMontantt = false;
        if (IsNumeric(TextBoxMTaux.Text) == false)
        {

            LabelErreur.Text = LabelErreur.Text + "Veuillez entrer une valeur numérique";
            flagMontantt = false;
        }
        else
        {
            flagMontantt = true;
            Double m;
            m = Convert.ToDouble(TextBoxMTaux.Text);
            if (m < mintaux)
            {
                LabelErreur.Text = LabelErreur.Text + "Veuillez saisir un taux supérieur à " + mintaux + "<br />";
                flagMontantt = false;
            }
            if (m > maxtaux)
            {
                LabelErreur.Text = LabelErreur.Text + "Veuillez saisir un taux inférieur à " + maxtaux + "<br />";
                flagMontantt = false;
            }
        }
    }
    protected void verifMontantta()
    {
        flagMontantta = false;
        if (IsNumeric(TextBoxMTauxAssu.Text) == false)
        {

            LabelErreur.Text = LabelErreur.Text + "Veuillez entrer une valeur numérique";
            flagMontantta = false;
        }
        else
        {
            flagMontantta = true;
            Double m;
            m = Convert.ToDouble(TextBoxMTauxAssu.Text);
            if (m < mintaux)
            {
                LabelErreur.Text = LabelErreur.Text + "Veuillez saisir un taux supérieur à " + mintaux + "<br />";
                flagMontantta = false;
            }
            if (m > maxtaux)
            {
                LabelErreur.Text = LabelErreur.Text + "Veuillez saisir un taux inférieur à " + maxtaux + "<br />";
                flagMontantta = false;
            }
        }
    }
    protected void verifMontant()
    {
        flagMontantm = false;
        if (IsNumeric(TextBoxMMontant.Text) == false)
        {

            LabelErreur.Text = LabelErreur.Text + "Veuillez entrer une valeur numérique";
            flagMontantm = false;
        }
        else
        {
            flagMontantm = true;
            Double m;
            m = Convert.ToDouble(TextBoxMMontant.Text);
            if (m < mincap)
            {
                LabelErreur.Text = LabelErreur.Text + "Veuillez saisir un montant supérieur à " + mincap + "<br />";
                flagMontantm = false;
            }
            if (m > maxcap)
            {
                LabelErreur.Text = LabelErreur.Text + "Veuillez saisir un montant inférieur à " + maxcap + "<br />";
                flagMontantm = false;
            }
        }
    }
    protected void verifDuree()
    {
       
        flagMontantd = false;
        if (DropDownList1.SelectedIndex == 0)
        {
            flagMontantd = false;
        }
        else
        {
            flagMontantd = true;       
        }
    }

 

    protected void TextBoxTaux_TextChanged(object sender, EventArgs e)
    {
        TextBoxMTaux.Text = remplace(TextBoxMTaux.Text);
    }
    protected void TextBoxTauxAssu_TextChanged(object sender, EventArgs e)
    {
        TextBoxMTauxAssu.Text = remplace(TextBoxMTauxAssu.Text);
    }
    protected void TextBoxMontant_TextChanged(object sender, EventArgs e)
    {
        TextBoxMMontant.Text = remplace(TextBoxMMontant.Text);

    }
    protected void TextBoxDuree_TextChanged(object sender, EventArgs e)
    {
        //TextBoxMDuree.Text = remplace(TextBoxMDuree.Text);

    }
    protected void TextBoxResultat_TextChanged(object sender, EventArgs e)
    {
        calcul();
    }
    protected void ButtonCalculer_Click(object sender, EventArgs e)
    {
        calcul();
    }
    protected void ButtonEffacer_Click(object sender, EventArgs e)
    {
        LabelErreur.Text = "";
        TextBoxMTaux.Text = "4,40";
        TextBoxMTauxAssu.Text = "0,36";
        TextBoxMMontant.Text = "";
        TextBoxMResultat.Text = "";
        LabelTableau.Visible = false;
        ButtonDétails.Visible = false;
        DropDownList1.SelectedIndex = 0;
        
    }

    protected bool IsNumeric(object Expression)
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
            LabelErreur.Text = LabelErreur.Text+"Veuillez saisir une valeur numérique correcte";
            return false;
        }
        else
        {
            // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
            // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);

            if ((isNum == false)&(Convert.ToString(Expression)!=""))
            {
                    LabelErreur.Text = "Veuillez saisir une valeur numérique correcte";
                    //Réponses non contractuelles
      
            }
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
        LabelErreur.Attributes.Add("style", "color:red;");
        LabelErreur.Text = "";
        TextBoxMResultat.Text = "";
        LabelTableau.Visible = false;
        ButtonDétails.Visible = false;
        verifMontantt();
        verifMontantta();
        verifDuree();
        verifMontant();

        if ((flagMontantta == true) & (flagMontantt == true) & (flagMontantm == true) & (flagMontantd == true))
        {
            LabelTableau.Visible = true;
            ButtonDétails.Visible = true;
            Double taux = Convert.ToDouble(TextBoxMTaux.Text);
            Double Montantta = Convert.ToDouble(TextBoxMTauxAssu.Text);
            Double credit = Convert.ToDouble(TextBoxMMontant.Text);
            Double duree = Convert.ToDouble(DropDownList1.SelectedIndex) * 12;
            Double Tp = ((taux / 100) / 12);
            Double Tpx = 1 + Tp;
            Double reste = credit;
            Double capital = 0; // Le capital du crédit
            Double interet = 0; // Intérêt du crédit
            Double assurance = credit * Montantta / 1200;
            assurance = Math.Round(assurance, 0);
            Tpx = (Double)Math.Pow(Tpx, duree);
            Double mensualite = (credit * Tpx * Tp) / (Tpx - 1); // Le montant de l'échéache      
            Double mensualiteR = Math.Round(mensualite + assurance, 0);
            TextBoxMResultat.Text = mensualiteR.ToString("### ### ### ###") + " euros";
            //tableau();
            // Create the HtmlTable control.
            HtmlTable table = new HtmlTable();
            table.Border = 1;
            table.CellPadding = 5;
            

        

            int rowcount = 0;
            int cellcount = 0;
            HtmlTableRow row;
            HtmlTableCell cell;
                    row = new HtmlTableRow();
                    cellcount = 0;
                    cell = new HtmlTableCell("th");
                    cell.Align = "left";
                    // Create the text for the cell.
                    cell.Controls.Add(new LiteralControl("Année"));
                    // Add the cell to the Cells collection of a row. 
                    row.Cells.Add(cell);

                    cellcount = 1;
                    //HtmlTableCell cell;
                    cell = new HtmlTableCell("th");
                    cell.Align = "left";
                    // Create the text for the cell.
                    cell.Controls.Add(new LiteralControl("Capital restant dû"));
                    // Add the cell to the Cells collection of a row. 
                    row.Cells.Add(cell);

                    cellcount = 2;
                    //HtmlTableCell cell;
                    cell = new HtmlTableCell("th");
                    // Create the text for the cell.
                    cell.Align = "left";
                    cell.Controls.Add(new LiteralControl("Capital amorti"));
                    // Add the cell to the Cells collection of a row. 
                    row.Cells.Add(cell);

                    cellcount = 3;
                    //HtmlTableCell cell;
                    cell = new HtmlTableCell("th");
                    cell.Align = "left";
                    // Create the text for the cell.
                    cell.Controls.Add(new LiteralControl("Intérêts"));
                    // Add the cell to the Cells collection of a row. 
                    row.Cells.Add(cell);

                    cellcount = 4;
                    //HtmlTableCell cell;
                    cell = new HtmlTableCell("th");
                    cell.Align = "left";
                    // Create the text for the cell.
                    cell.Controls.Add(new LiteralControl("Assurance"));
                    // Add the cell to the Cells collection of a row. 
                    row.Cells.Add(cell);

                    cellcount = 5;
                    //HtmlTableCell cell;
                    cell = new HtmlTableCell("th");
                    cell.Align = "left";
                    // Create the text for the cell.
                    cell.Controls.Add(new LiteralControl("Mensualité"));
                    // Add the cell to the Cells collection of a row. 
                    row.Cells.Add(cell);
                    table.Rows.Add(row);
                    double sommeint = 0;
            for (rowcount = 0; rowcount < (DropDownList1.SelectedIndex); rowcount++)
            {
           

                sommeint = 0;
                for (int a = 0; a<12; a++)
                {
                interet = ((reste * (taux / 100)) / 12);
                sommeint = sommeint + interet;
                capital += mensualite - interet;
                reste = credit - capital;
                }
                row = new HtmlTableRow();
                // Create the cells of a row.   
                    for (cellcount = 0; cellcount <= 5; cellcount++)
                    {
                        // Create the text for the cell.

                        cell = new HtmlTableCell();
                        cell.Align = "right";
                    
                        switch (cellcount)
                        {

                            case 0:
                                cell.Controls.Add(new LiteralControl((rowcount+1).ToString("### ### ### ###")));
                                break;
                            case 1:
                                Double resteR = Math.Round(reste, 0);
                                if (resteR == 0)
                                {
                                    cell.Controls.Add(new LiteralControl("0"));
                                }
                                else
                                {
                                    cell.Controls.Add(new LiteralControl(resteR.ToString("### ### ### ###")));
                                }
                                break;
                            case 2:
                                Double capitalR = Math.Round(capital, 0);
                                if (capitalR == 0)
                                {
                                    cell.Controls.Add(new LiteralControl("0"));
                                }
                                else
                                {
                                    cell.Controls.Add(new LiteralControl(capitalR.ToString("### ### ### ###")));
                                    //cell.Controls.Add(new LiteralControl(Convert.ToString(calcula(rowcount))));
                                }
                                break;
                            case 3:
                                Double sommeintR = Math.Round(sommeint, 0);
                                if (sommeintR == 0)
                                {
                                    cell.Controls.Add(new LiteralControl("0"));
                                }
                                else
                                {
                                    cell.Controls.Add(new LiteralControl(sommeintR.ToString("### ### ### ###")));
                                    // Add the cell to the Cells collection of a row.     
                                }
                                break;
                            case 4:
                                if (assurance == 0)
                                {
                                    cell.Controls.Add(new LiteralControl("0"));
                                }
                                else
                                {
                                    cell.Controls.Add(new LiteralControl(assurance.ToString("### ### ### ###")));
                                }
                                break;
                            case 5:
                                if (mensualiteR == 0)
                                {
                                    cell.Controls.Add(new LiteralControl("0"));
                                }
                                else
                                {
                                    cell.Controls.Add(new LiteralControl(mensualiteR.ToString("### ### ### ###")));
                                }
                                break;         
                        }
                        row.Cells.Add(cell);
                    }
                    table.Rows.Add(row);
                    
                }
              
                   
    
            // Add the row to the Rows collection of the table.
            LabelErreur.Attributes.Add("style", "color:black;");
            LabelErreur.Controls.Clear();
            LabelErreur.Controls.Add(table);

        
        }
    }
       
    private void calculdetail()
    {
        LabelErreur.Attributes.Add("style", "color:red;");
        LabelErreur.Text = "";
        TextBoxMResultat.Text = ""; 
        verifMontantt();
        verifMontantta();
        verifDuree();
        verifMontant();

        if ((flagMontantta == true) & (flagMontantt == true) & (flagMontantm == true) & (flagMontantd == true))
        {
         
            Double taux = Convert.ToDouble(TextBoxMTaux.Text);
            Double Montantta = Convert.ToDouble(TextBoxMTauxAssu.Text);
            Double credit = Convert.ToDouble(TextBoxMMontant.Text);
            Double duree = Convert.ToDouble(DropDownList1.SelectedIndex) * 12;
            Double Tp = ((taux / 100) / 12);
            Double Tpx = 1 + Tp;
            Double reste = credit;
            Double capital = 0; // Le capital du crédit
            Double interet = 0; // Intérêt du crédit
            Double assurance = credit * Montantta / 1200;
            assurance = Math.Round(assurance, 0);
            Tpx = (Double)Math.Pow(Tpx, duree);
            Double mensualite = (credit * Tpx * Tp) / (Tpx - 1); // Le montant de l'échéache      
            Double mensualiteR = Math.Round(mensualite + assurance, 0);
            TextBoxMResultat.Text = mensualiteR.ToString("### ### ### ###") + " euros";
            //tableau();
            // Create the HtmlTable control.
            HtmlTable table = new HtmlTable();
            table.Border = 1;
            table.CellPadding = 5;




            int rowcount = 0;
            int cellcount = 0;
            double sommeint = 0;
            HtmlTableRow row;
            HtmlTableCell cell;
            for (rowcount = 0; rowcount < (DropDownList1.SelectedIndex * 12); rowcount++)
            {
         

                row = new HtmlTableRow();
                // Create the cells of a row.   





                if ((rowcount % 12) == 0)
                {
                    if ((rowcount != 0))
                    {
                        for (cellcount = 0; cellcount <= 5; cellcount++)
                        {
                            // Create the text for the cell.

                            cell = new HtmlTableCell("th");
                            cell.Align = "right";
                            switch (cellcount)
                            {

                                case 0:
                                    cell.Controls.Add(new LiteralControl("Total"));
                                    break;
                                case 1:
                                    Double resteR = Math.Round(reste, 0);
                                    if (resteR == 0)
                                    {
                                        cell.Controls.Add(new LiteralControl("0"));
                                    }
                                    else
                                    {
                                        cell.Controls.Add(new LiteralControl(resteR.ToString("### ### ### ###")));
                                    }
                                        break;
                                case 2:
                                    Double capitalR = Math.Round(capital, 0);
                                    if (capitalR == 0)
                                    {
                                        cell.Controls.Add(new LiteralControl("0"));
                                    }
                                    else
                                    {
                                        cell.Controls.Add(new LiteralControl(capitalR.ToString("### ### ### ###")));
                                        //cell.Controls.Add(new LiteralControl(Convert.ToString(calcula(rowcount))));
                                    }
                                    break;
                                case 3:
                                    Double sommeintR = Math.Round((sommeint), 0);
                                    if (sommeintR == 0)
                                    {
                                        cell.Controls.Add(new LiteralControl("0"));
                                    }
                                    else
                                    {
                                        cell.Controls.Add(new LiteralControl(sommeintR.ToString("### ### ### ###")));
                                        // Add the cell to the Cells collection of a row.     
                                    }
                                    break;
                                case 4:
                                    if (assurance == 0)
                                    {
                                        cell.Controls.Add(new LiteralControl("0"));
                                    }
                                    else
                                    {
                                        cell.Controls.Add(new LiteralControl((assurance * 12).ToString("### ### ### ###")));
                                    }
                                        break;
                                case 5:
                                    if (mensualiteR == 0)
                                    {
                                        cell.Controls.Add(new LiteralControl("0"));
                                    }
                                    else
                                    {
                                        cell.Controls.Add(new LiteralControl((mensualiteR * 12).ToString("### ### ### ###")));
                                    }
                                        break;
                            }
                            row.Cells.Add(cell);


                        }
                        sommeint = 0;
                        table.Rows.Add(row);
                        row = new HtmlTableRow();
                    }
                   
                    cell = new HtmlTableCell("th");
                    cell.Align = "left";
                    cell.Controls.Add(new LiteralControl("Année " + ((rowcount / 12) + 1).ToString("### ### ### ###")));
                    row.Cells.Add(cell);
                    table.Rows.Add(row);

                  
                    row = new HtmlTableRow();
                    cellcount = 0;
                    cell = new HtmlTableCell("th");
                    cell.Align = "left";
                    // Create the text for the cell.
                    cell.Controls.Add(new LiteralControl("Mois"));
                    // Add the cell to the Cells collection of a row. 
                    row.Cells.Add(cell);

                    cellcount = 1;
                    //HtmlTableCell cell;
                    cell = new HtmlTableCell("th");
                    cell.Align = "left";
                    // Create the text for the cell.
                    cell.Controls.Add(new LiteralControl("Capital restant dû"));
                    // Add the cell to the Cells collection of a row. 
                    row.Cells.Add(cell);

                    cellcount = 2;
                    //HtmlTableCell cell;
                    cell = new HtmlTableCell("th");
                    // Create the text for the cell.
                    cell.Align = "left";
                    cell.Controls.Add(new LiteralControl("Capital amorti"));
                    // Add the cell to the Cells collection of a row. 
                    row.Cells.Add(cell);

                    cellcount = 3;
                    //HtmlTableCell cell;
                    cell = new HtmlTableCell("th");
                    cell.Align = "left";
                    // Create the text for the cell.
                    cell.Controls.Add(new LiteralControl("Intérêts"));
                    // Add the cell to the Cells collection of a row. 
                    row.Cells.Add(cell);

                    cellcount = 4;
                    //HtmlTableCell cell;
                    cell = new HtmlTableCell("th");
                    cell.Align = "left";
                    // Create the text for the cell.
                    cell.Controls.Add(new LiteralControl("Assurance"));
                    // Add the cell to the Cells collection of a row. 
                    row.Cells.Add(cell);

                    cellcount = 5;
                    //HtmlTableCell cell;
                    cell = new HtmlTableCell("th");
                    cell.Align = "left";
                    // Create the text for the cell.
                    cell.Controls.Add(new LiteralControl("Mensualité"));
                    // Add the cell to the Cells collection of a row. 
                    row.Cells.Add(cell);
                    table.Rows.Add(row);
                    row = new HtmlTableRow();
                }


                interet = ((reste * (taux / 100)) / 12);
                capital += mensualite - interet;
                sommeint = sommeint + interet;
                reste = credit - capital;

                for (cellcount = 0; cellcount <= 5; cellcount++)
                {
                    // Create the text for the cell.

                    cell = new HtmlTableCell();
                    cell.Align = "right";

                    switch (cellcount)
                    {

                        case 0:
                            cell.Controls.Add(new LiteralControl((rowcount + 1).ToString("### ### ### ###")));
                            break;
                        case 1:
                            Double resteR = Math.Round(reste, 0);

                            if (resteR == 0)
                            {
                                cell.Controls.Add(new LiteralControl("0"));
                            }
                            else
                            {
                                cell.Controls.Add(new LiteralControl(resteR.ToString("### ### ### ###")));
                            }
                            break;
                        case 2:
                            Double capitalR = Math.Round(capital, 0);
                            if (capitalR == 0)
                            {
                                cell.Controls.Add(new LiteralControl("0"));
                            }
                            else
                            {
                                cell.Controls.Add(new LiteralControl(capitalR.ToString("### ### ### ###")));
                            } //cell.Controls.Add(new LiteralControl(Convert.ToString(calcula(rowcount))));
                            break;
                        case 3:
                            Double interetR = Math.Round(interet, 0);
                            if (interetR == 0)
                            {
                                cell.Controls.Add(new LiteralControl("0"));
                            }
                            else
                            {
                                cell.Controls.Add(new LiteralControl(interetR.ToString("### ### ### ###")));
                            } // Add the cell to the Cells collection of a row.     
                            break;
                        case 4:
                            if (assurance == 0)
                            {
                                cell.Controls.Add(new LiteralControl("0"));
                            }
                            else
                            {
                                cell.Controls.Add(new LiteralControl(assurance.ToString("### ### ### ###")));
                            }
                            break;
                        case 5:
                            if (mensualiteR == 0)
                            {
                                cell.Controls.Add(new LiteralControl("0"));
                            }
                            else
                            {
                                cell.Controls.Add(new LiteralControl(mensualiteR.ToString("### ### ### ###")));
                            }
                            break;
                    }
                    row.Cells.Add(cell);
                }
                table.Rows.Add(row);

            }

            row = new HtmlTableRow();
            for (cellcount = 0; cellcount <= 5; cellcount++)
            {
                // Create the text for the cell.

                cell = new HtmlTableCell("th");
                cell.Align = "right";

                switch (cellcount)
                {

                    case 0:
                        cell.Controls.Add(new LiteralControl("Total"));
                        break;
                    case 1:
                        Double resteR = Math.Round(reste, 0);
                        if (resteR == 0)
                        {
                            cell.Controls.Add(new LiteralControl("0"));
                        }
                        else
                        {
                            cell.Controls.Add(new LiteralControl(resteR.ToString("### ### ### ###")));
                        }
                        break;
                    case 2:
                        Double capitalR = Math.Round(capital, 0);
                        if (capitalR == 0)
                        {
                            cell.Controls.Add(new LiteralControl("0"));
                        }
                        else
                        {
                            cell.Controls.Add(new LiteralControl(capitalR.ToString("### ### ### ###")));
                        }
                    //cell.Controls.Add(new LiteralControl(Convert.ToString(calcula(rowcount))));
                        break;
                    case 3:
                        Double sommeintR = Math.Round((sommeint), 0);
                        if (sommeintR == 0)
                        {
                            cell.Controls.Add(new LiteralControl("0"));
                        }
                        else
                        {
                            cell.Controls.Add(new LiteralControl(sommeintR.ToString("### ### ### ###")));
                            // Add the cell to the Cells collection of a row.     
                        } break;
                    case 4:
                        if (assurance == 0)
                        {
                            cell.Controls.Add(new LiteralControl("0"));
                        }
                        else
                        {
                            cell.Controls.Add(new LiteralControl((assurance * 12).ToString("### ### ### ###")));
                        }
                        break;
                    case 5:
                        if (mensualiteR == 0)
                        {
                            cell.Controls.Add(new LiteralControl("0"));
                        }
                        else
                        {
                            cell.Controls.Add(new LiteralControl((mensualiteR * 12).ToString("### ### ### ###")));
                        }
                        break;
                }
               
                row.Cells.Add(cell);


            }
            sommeint = 0;
            table.Rows.Add(row);


            // Add the row to the Rows collection of the table.
            LabelErreur.Attributes.Add("style", "color:black;");
            LabelErreur.Controls.Clear();
            LabelErreur.Controls.Add(table);


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




    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       /* bha ca marche pas
        * 
        * 
        * if ((DropDownList1.SelectedIndex < 9)&(DropDownList1.SelectedIndex >=0))
        {
            TextBoxMTaux.Text = "4,20";
        }
        if ((DropDownList1.SelectedIndex < 12)&(DropDownList1.SelectedIndex >=9))
        {
            TextBoxMTaux.Text = "4,25";
        } 
        if ((DropDownList1.SelectedIndex < 14)&(DropDownList1.SelectedIndex >=12))
        {
            TextBoxMTaux.Text = "4,30";
        }
        if ((DropDownList1.SelectedIndex < 18)&(DropDownList1.SelectedIndex >=14))
        {
            TextBoxMTaux.Text = "4,40";
        }
        if ((DropDownList1.SelectedIndex < 23)&(DropDownList1.SelectedIndex >=18))
        {
            TextBoxMTaux.Text = "4,45";
        }
        if ((DropDownList1.SelectedIndex < 28)&(DropDownList1.SelectedIndex >=23))
        {
            TextBoxMTaux.Text = "4,55";
        }
        if ((DropDownList1.SelectedIndex <= 40)&(DropDownList1.SelectedIndex >=28))
        {
            TextBoxMTaux.Text = "4,8";
        }
        */ 
    }

    protected void ButtonDétails_Click(object sender, EventArgs e)
    {
        calculdetail();
    }
}
