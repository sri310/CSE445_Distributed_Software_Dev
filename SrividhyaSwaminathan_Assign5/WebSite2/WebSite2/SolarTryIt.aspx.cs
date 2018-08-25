using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SolarTryIt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_InvokeSIS_Click(object sender, EventArgs e)
    {
        electiveLocationBasedServices.Service1Client elsPxy = new electiveLocationBasedServices.Service1Client();
        decimal latitude = Convert.ToDecimal(txtInputLattitude.Text.ToString());
        decimal longitude = Convert.ToDecimal(txtInputLongitude.Text.ToString());
        try
        {
            string response = Convert.ToString(elsPxy.SolarIntensity(latitude, longitude));
            lblSolarIntensity.Text = response;
        }
        catch (Exception em)
        {
            lblSolarIntensity.Text = em.Message.ToString();
        }
    }
}