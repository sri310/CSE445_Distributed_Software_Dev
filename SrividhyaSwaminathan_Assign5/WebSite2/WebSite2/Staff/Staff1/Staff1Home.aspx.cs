using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml;
using WebSite2;

public partial class Staff_Staff1Home : System.Web.UI.Page
{
    /// <summary>
    /// on page load, the event handler gets all user names both from inbuilt account mgmt and xml file and displays
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //lblUsers.Text = "Hello staff! You can view all the users registerd in the system. <br>";
        lblUsers.Text = "Member Users<br/>";
        //lblUsers.Text = "Hello staff! You can view all the users registerd in the system. <br>";
        lblUsers.Text = "Member Users<br/>";
        string flocation = Path.Combine(Request.PhysicalApplicationPath, @"App_Data\memberUsers.xml"); ;
        if (File.Exists(flocation))
        {
            FileStream fs = new FileStream(flocation, FileMode.Open);
            XmlDocument xd = new XmlDocument();
            xd.Load(fs);
            XmlElement node = xd.DocumentElement;
            XmlNodeList Children = node.ChildNodes;
            foreach (XmlNode child in Children)
            {
                lblUsers.Text += child["username"].InnerText + "<br>";


            }
            fs.Close();
        }
        lblUsers.Text += "<br/> Admin Users <br/>";
        flocation = Path.Combine(Request.PhysicalApplicationPath, @"App_Data\Users.xml"); ;
        if (File.Exists(flocation))
        {
            FileStream fs = new FileStream(flocation, FileMode.Open);
            XmlDocument xd = new XmlDocument();
            xd.Load(fs);
            XmlElement node = xd.DocumentElement;
            XmlNodeList Children = node.ChildNodes;
            foreach (XmlNode child in Children)
            {
                lblUsers.Text += child["username"].InnerText + "&nbsp;&nbsp;";
                lblUsers.Text += child["role"].InnerText + "<br/>";


            }
            fs.Close();
        }

    }
}