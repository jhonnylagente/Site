using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_MandatSimple : System.Web.UI.Page
{
    protected Membre member2 = null;

    protected void Page_Load(object sender, EventArgs e)
    {
       
            member2 = (Membre)Session["membre"];
        
   }

}