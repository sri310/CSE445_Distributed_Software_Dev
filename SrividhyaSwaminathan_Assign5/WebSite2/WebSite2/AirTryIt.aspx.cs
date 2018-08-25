using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AirTryIt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_InvokeAQS_Click(object sender, EventArgs e)
    {
        try
        {
            locationBasedServices.Service1Client lsPxy = new locationBasedServices.Service1Client();
            decimal lattitude = Convert.ToDecimal(txtInputLattitude.Text);
            decimal longitude = Convert.ToDecimal(txtInputLongitude.Text);
            lblAirQuality.Text = lsPxy.airQuality(lattitude, longitude);
        }
        catch (Exception em)
        {
            lblAirQuality.Text = em.Message.ToString();
        }

    }
}