using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DateWeatherTime : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        dateTime.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
        if (Session["Zipcode"] != null)
        {
            dateTime.Text += "<br>Zipcode Selected: " + Session["Zipcode"];
        }
    }
}