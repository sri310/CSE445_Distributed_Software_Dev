using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Staff_StaffHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void staff1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Staff1/Staff1Home.aspx");
    }

    protected void staff2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Staff2/Staff2Home.aspx");
    }
}