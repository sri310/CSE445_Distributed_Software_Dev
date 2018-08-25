using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class location2zip : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_Invokel2z_Click(object sender, EventArgs e)
    {
        lblZipCodes.Text = "";
        electiveLocationBasedServices.Service1Client elsPxy = new electiveLocationBasedServices.Service1Client();
        string cityName = txtInputCityName.Text.ToString();
        string stateCode = txtInputStateCode.Text.ToString();
        try
        {
            string[] response = elsPxy.location2zip(cityName, stateCode);
            for (int i = 0; i < response.Length; i++)
            {
                lblZipCodes.Text += response[i] + "<br/>";
            }
        }
        catch (Exception em)
        {
            lblZipCodes.Text = em.Message.ToString();
        }
    }
}