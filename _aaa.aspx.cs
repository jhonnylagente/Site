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

public partial class aaa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		Regex rgx = new Regex("ab|c");
		Response.Write(rgx.Replace("abcabO","z")); 
		DateTime today = DateTime.Now;
		Response.Write("#" + today.Month + "/" + today.Day + "/" + today.Year + "#<br/>") ;

		int z = 0;
		for(int i = z ; i<12 ; i++)
		{
			//Response.Write( ((today.Month + i)%12 + 1) + "<br/>");
			if(i == 5)
			{	
				z = i;
				break;
			}
		}
		Response.Write(z + " ");
    }
	
	protected void test(object sender, EventArgs e)
	{
		ab.Text = ((ImageButton)sender).Attributes["customValue"];
	}
}
