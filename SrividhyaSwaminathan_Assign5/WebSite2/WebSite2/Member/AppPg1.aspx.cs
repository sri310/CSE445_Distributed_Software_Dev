using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Member_AppPg1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       output.Text = "";
      
    }

    protected void submitSearch_Click(object sender, EventArgs e)
    {
        output.Text = "";
        try
        {
            string searchTerm = yelpSearch.Text;
            string zip = Session["Zipcode"].ToString();
            locationBasedServices.Service1Client lsPxy = new locationBasedServices.Service1Client();
            string geocode = lsPxy.getLatLng(zip);
            string[] latLng = geocode.Split(',');
            Decimal lat = Convert.ToDecimal(latLng[0]);
            Decimal lng = Convert.ToDecimal(latLng[1]);
            Session["lat"] = lat;
            Session["lng"] = lng;
            WebClient webClient = new WebClient();
            string address = webClient.DownloadString("http://webstrar61.fulton.asu.edu/page0/Service1.svc/findNearestStore3?latitude=" + lat + "&longitude=" + lng + "&storeName=" + searchTerm);
            output.Text = "Nearest " + searchTerm + " is at ";
            output.Text += address;
        }
        catch(Exception em)
        {
            output.Text = em.Message.ToString();
        }

    }

    protected void AppPg2_Click(object sender, EventArgs e)
    {
        Response.Redirect("AppPg2.aspx");
    }

    protected void home_Click(object sender, EventArgs e)
    {
        Response.Redirect("MemberHome.aspx");
    }
}