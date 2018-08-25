using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Member_AppPg2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        locationBasedServices.Service1Client lsPxy = new locationBasedServices.Service1Client();
        string geocode = lsPxy.getLatLng(Session["Zipcode"].ToString());
        string[] latLng = geocode.Split(',');
        Decimal lat = Convert.ToDecimal(latLng[0]);
        Decimal lng = Convert.ToDecimal(latLng[1]);
        Session["lat"] = lat;
        Session["lng"] = lng;
    }

    protected void AppPg1_Click(object sender, EventArgs e)
    {
        Response.Redirect("AppPg1.aspx");
    }

    protected void home_Click(object sender, EventArgs e)
    {
        Response.Redirect("MemberHome.aspx");
    }

    protected void weather_Click(object sender, EventArgs e)
    {
        output.Text = "";
        try
        {
            locationBasedServices.Service1Client lPxy = new locationBasedServices.Service1Client();
            string zip = Session["Zipcode"].ToString();
            string[][] weather = lPxy.weatherService(zip);
            output.Text = "Today's weather is  <br> ";
            for (int i=0; i<weather[0].Length; i++)
            {
                output.Text += weather[0][i] + " : " + weather[1][i]+"<br>";
            }
            
        }
        catch (Exception em)
        {
            output.Text = em.Message;
        }
    }   

    protected void airQuality_Click(object sender, EventArgs e)
    {
        output.Text = "";
        try
        {
           locationBasedServices.Service1Client lPxy = new locationBasedServices.Service1Client();
            decimal lat = Convert.ToDecimal(Session["lat"].ToString());
            decimal lng = Convert.ToDecimal(Session["lng"].ToString());
            string op = lPxy.airQuality(lat, lng);
            output.Text = "The Air Quality index and status is => " + op;
        }
        catch (Exception em)
        {
            output.Text = em.Message;
        }
    }

    protected void windIntensity_Click(object sender, EventArgs e)
    {
        output.Text = "";
        try
        {
            electiveLocationBasedServices.Service1Client elPxy = new electiveLocationBasedServices.Service1Client();
            decimal lat = Convert.ToDecimal(Session["lat"].ToString());
            decimal lng = Convert.ToDecimal(Session["lng"].ToString());
            decimal op = elPxy.WindIntensity(lat, lng);
            output.Text = "The wind intensity is " + op.ToString();
        }
        catch (Exception em)
        {
            output.Text = em.Message;
        }
    }

    protected void solarIntensity_Click(object sender, EventArgs e)
    {
        output.Text = "";
        try
        {
            electiveLocationBasedServices.Service1Client elPxy = new electiveLocationBasedServices.Service1Client();
            decimal lat = Convert.ToDecimal(Session["lat"].ToString());
            decimal lng = Convert.ToDecimal(Session["lng"].ToString());
            decimal op = elPxy.SolarIntensity(lat, lng);
            output.Text = "The solar intensity is " + op.ToString();
        }
        catch(Exception em)
        {
            output.Text = em.Message;
        }
    }
}