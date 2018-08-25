using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       

    }

    protected void staffPgBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Staff/StaffHome.aspx");
    }

    protected void mbrPgBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Member/MemberHome.aspx");
    }

    

    protected void registerBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Account/Register.aspx");
    }

    protected void mbrLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Account/Login.aspx");
    }

    protected void staffLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("staffLoginPage.aspx");
    }
}