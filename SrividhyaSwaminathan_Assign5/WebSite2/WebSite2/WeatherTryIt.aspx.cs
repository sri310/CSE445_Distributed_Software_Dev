using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WeatherTryIt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_InvokeWS_Click(object sender, EventArgs e)
    {
        locationBasedServices.Service1Client lsPxy = new locationBasedServices.Service1Client();
        string zipcode = txtInput.Text.ToString();
        try
        {
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
        catch (Exception em)
        {
            lblWeatherForecast.Text = em.Message.ToString();
        }
    }
}