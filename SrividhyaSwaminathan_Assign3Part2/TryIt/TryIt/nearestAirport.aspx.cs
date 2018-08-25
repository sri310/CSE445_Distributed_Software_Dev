using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryIt
{
    public partial class nearestAirport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_InvokeNAS_Click(object sender, EventArgs e)
        {
            lblNearestAirports.Text = "";
           electiveLocationBasedServices.Service1Client elsPxy = new electiveLocationBasedServices.Service1Client();
            decimal latitude = Convert.ToDecimal(txtLatitude.Text.ToString());
            decimal longitude = Convert.ToDecimal(txtLongitude.Text.ToString());
            try
            {
                string[][] response = elsPxy.nearestAirport(latitude, longitude);
                lblNearestAirports.Text += "<table>";
                for (int i = 0; i < response.Length; i++)
                {
                    lblNearestAirports.Text += "<tr>";
                    for (int j = 0; j < response[i].Length; j++)
                    {
                        lblNearestAirports.Text += "&nbsp;<td style=\"padding-right:15px\">";
                        lblNearestAirports.Text += response[i][j];
                        lblNearestAirports.Text += "</td>&nbsp;";
                    }
                    lblNearestAirports.Text += "</tr>";
                }
                lblNearestAirports.Text += "</table>";
            }
            catch (Exception em)
            {
                lblNearestAirports.Text = em.Message.ToString();
            }
        }
    }
}