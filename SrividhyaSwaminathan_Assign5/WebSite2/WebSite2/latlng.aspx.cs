using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class latlng : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_InvokeGLLS_Click(object sender, EventArgs e)
    {

        try
        {
            locationBasedServices.Service1Client lsPxy = new locationBasedServices.Service1Client();
            string zipcode = txtInputZipCode.Text;
            lblLatLong.Text = lsPxy.getLatLng(zipcode);
        }
        catch (Exception em)
        {
            lblLatLong.Text = em.Message.ToString();
        }
    }
}