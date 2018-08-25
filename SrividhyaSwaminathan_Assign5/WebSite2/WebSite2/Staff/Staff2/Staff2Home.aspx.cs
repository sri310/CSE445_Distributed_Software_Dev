using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml;
using WebSite2;

public partial class Staff_Staff2Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblUserStat.Text = "";
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

    protected void getUserStats_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text;
        lblUserStat.Text = "";
        try
        {
            string flocation = Path.Combine(Request.PhysicalApplicationPath, @"App_Data\UserStats.xml"); ;
            if (File.Exists(flocation))
            {
                FileStream fs = new FileStream(flocation, FileMode.Open);
                XmlDocument xd = new XmlDocument();
                xd.Load(fs);
                XmlElement node = xd.DocumentElement;
                XmlNodeList Children = node.ChildNodes;
                bool valueset = false;
                foreach (XmlNode child in Children)
                {
                    if (child["username"].InnerText == username)
                    {
                        lblUserStat.Text +="UserName: "+ child["username"].InnerText + "<br/>";
                        lblUserStat.Text += "#Location Searches: "+child["searches"].InnerText + "<br/>";
                        lblUserStat.Text += "Locations Searched (only unique entries): <br>";
                        XmlNodeList locations = child["locations"].ChildNodes;
                        foreach(XmlNode location in locations)
                        {
                            lblUserStat.Text += location.InnerText + "<br>";
                        }
                        valueset = true;
                        break;
                    }                   


                }
                if (valueset == false)
                {
                    lblUserStat.Text = "Either your user is not valid of He/She has not searched any location yet";
                }
                fs.Close();
            }
        }
        catch(Exception em)
        {
            lblUserStat.Text = em.Message;
        }
    }
}