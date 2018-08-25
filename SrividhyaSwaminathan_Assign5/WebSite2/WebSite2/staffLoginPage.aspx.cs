using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using SecureString;

public partial class staffLoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    bool myAuthenticate(string username, string password)
    {
        string flocation = Path.Combine(Request.PhysicalApplicationPath, @"App_Data\Users.xml"); ;
        if (File.Exists(flocation))
        {
            FileStream fs = new FileStream(flocation, FileMode.Open);
            XmlDocument xd = new XmlDocument();
            xd.Load(fs);
            XmlElement node = xd.DocumentElement;
            XmlNodeList Children = node.ChildNodes;
            foreach (XmlNode child in Children)
            {
                string decryptPwd = child["password"].InnerText.Decrypt();
                if (child["username"].InnerText == username && decryptPwd == password)
                {
                    fs.Close();
                    return true;
                }

            }
            fs.Close();
        }

        return false;
    }

    protected void click_Click(object sender, EventArgs e)
    {
        if (myAuthenticate(txtUserName.Text, txtPassword.Text))
            FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, Persistent.Checked);
        else
            Output.Text = "Invalid Login";
    }
}