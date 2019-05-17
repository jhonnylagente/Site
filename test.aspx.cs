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

using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.IO;

public partial class pages_test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        ((Label)Page.Master.FindControl("titrebandeau")).Text = "Mon espace";
    }

    protected void Button_Click1(object sender, EventArgs e)
    {
        Uri uri = new Uri("http://192.168.1.3/patrimodev/pages/test.aspx");
        GetUrl(uri, "C:\\SITESWEB\\PATRIMOdev\\patrimo\\Temp\\toto.txt");
    }


    static void GetUrl(Uri uri, string localFileName)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
        HttpWebResponse response;
        response = (HttpWebResponse)request.GetResponse();
        // Save the stream to file 
        Stream responseStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(responseStream, Encoding.Default);
        Stream fileStream = File.OpenWrite(localFileName);
        using (StreamWriter sw = new StreamWriter(fileStream, Encoding.Default))
        {
            sw.Write(reader.ReadToEnd());
            sw.Flush();
            sw.Close();
        }
    }




    protected void Button1_Click(object sender, System.EventArgs e)
    {

        GestionSMTP mail = new GestionSMTP();
    }
}
