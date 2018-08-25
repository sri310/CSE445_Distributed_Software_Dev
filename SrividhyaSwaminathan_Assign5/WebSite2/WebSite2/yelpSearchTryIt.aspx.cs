using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class yelpSearchTryIt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_InvokeRestful_Click(object sender, EventArgs e)
    {
        string latitude = txtInputLatitude.Text.ToString();
        string longitude = txtInputLongitude.Text.ToString();
        string storeName = txtStoreName.Text.ToString();
        string baseURL = "http://webstrar61.fulton.asu.edu/page0/Service1.svc/findNearestStore3?";
        string fullURL = baseURL + "latitude=" + latitude + "&longitude=" + longitude + "&storeName=" + storeName;
        WebClient webClient = new WebClient();
        try
        {
            string response = webClient.DownloadString(fullURL);
            lblAddress.Text = response;
        }
        catch (Exception em)
        {
            lblAddress.Text = em.Message.ToString();
        }
    }
}