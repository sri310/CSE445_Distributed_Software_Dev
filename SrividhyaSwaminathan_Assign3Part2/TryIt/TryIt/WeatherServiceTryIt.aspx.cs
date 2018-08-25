using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryIt
{
    public partial class WeatherServiceTryIt : System.Web.UI.Page
    {
       /// <summary>
       /// Event handler
       /// Invokes the weather service
       /// Sends a string  - zipcode as input to the service
       /// Gets Backe a 2d string array consisting of 5 day weather forecast
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>

        protected void btn_InvokeWS_Click(object sender, EventArgs e)
        {
            lblWeatherForecast.Text = "";
            locationBasedServices.Service1Client lsPxy = new locationBasedServices.Service1Client();
            string zipcode = txtInput.Text.ToString();
            try {
                string[][] response = lsPxy.weatherService(zipcode);
                lblWeatherForecast.Text += "<table>";
                for (int i = 0; i < response.Length; i++)
                {
                    lblWeatherForecast.Text += "<tr>";
                    for (int j = 0; j < response[i].Length; j++)
                    {
                        lblWeatherForecast.Text += "&nbsp;<td style=\"padding-right:15px\">";
                        lblWeatherForecast.Text += response[i][j];
                        lblWeatherForecast.Text += "</td>&nbsp;";
                    }
                    lblWeatherForecast.Text += "</tr>";
                }
                lblWeatherForecast.Text += "</table>";
            }
            catch(Exception em)
            {
                lblWeatherForecast.Text = em.Message.ToString();
            }
           
        }
    }
}