using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryIt
{
    public partial class AirQualityServiceTryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Event Handler
        /// Invokes the AirQualityService
        /// Sends 2 input parameters - Decimal lattitude, Decimal Longitude
        /// Receives - a string "{Air Quality Index},{Pollution level}"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void btn_InvokeAQ_Click(object sender, EventArgs e)
        {
            try
            {
                locationBasedServices.Service1Client lsPxy = new locationBasedServices.Service1Client();
                decimal lattitude = Convert.ToDecimal(txtInputLattitude.Text);
                decimal longitude = Convert.ToDecimal(txtInputLongitude.Text);
                lblAirQuality.Text = lsPxy.airQuality(lattitude, longitude);
            }
            catch(Exception em)
            {
                lblAirQuality.Text = em.Message.ToString();
            }
           
        }
    }
}