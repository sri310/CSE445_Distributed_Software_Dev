using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Member_MemberHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblZips.Text = "";
        error.Text = "";
    }

    protected void zipLookup_Click(object sender, EventArgs e)
    {
        lblZips.Text = "";
        electiveLocationBasedServices.Service1Client eLpxy = new electiveLocationBasedServices.Service1Client();
        try
        {
            string cityname = cityName.Text;
            string statecode = stateCode.Text;
            string[] zips = eLpxy.location2zip(cityname, statecode);
            for(int i=0; i < zips.Length; i++)
            {
                lblZips.Text += zips[i] + "<br/>";
            }
        }
        catch(Exception em)
        {
            lblZips.Text = em.Message.ToString();
        }
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        error.Text = "";
        string zip = zipCode.Text;
        try
        {
            if (zip == "")
            {
                error.Text = "zipcode is a required field";
            }
            else if(zip.Length!=5)
            {
                error.Text = "zipcode is a number of 5 difgits";
            }
            else if(!int.TryParse(zip,out int n))
            {
                error.Text = "Zipcode must be a number";
            }
            else
            {
                Session["ZipCode"] = zip;
                writeToUserStats(zip);
                Response.Redirect("AppPg1.aspx");
            }
        }
        catch(Exception em)
        {
            error.Text = em.Message.ToString();

        }

    }
    public void writeToUserStats(string zip)
    {
        
        string flocation = Path.Combine(Request.PhysicalApplicationPath, @"App_Data\UserStats.xml"); ;
        if (File.Exists(flocation))
        {
            FileStream fs = new FileStream(flocation, FileMode.Open);
            XmlDocument xd = new XmlDocument();           
            xd.Load(fs);
            XmlElement node = xd.DocumentElement;
            XmlNodeList Children = node.ChildNodes;
            bool valueSet = false;
            foreach (XmlNode child in Children)
            {
                if(child["username"].InnerText ==  Context.User.Identity.GetUserName())
                {
                    XmlNodeList locations = child["locations"].ChildNodes;
                    if (locations.Count == 0)
                    {
                        XmlNode locationNode = xd.CreateElement("location");
                        locationNode.InnerText = Session["zipcode"].ToString();
                        child["locations"].AppendChild(locationNode);
                        int count = Convert.ToInt32(child["searches"].InnerText) + 1;
                        child["searches"].InnerText = (count).ToString();
                    }
                    else
                    {
                        foreach (XmlNode location in locations)
                        {
                            if (location.InnerText == Session["Zipcode"].ToString())
                            {
                                int count = Convert.ToInt32(child["searches"].InnerText) + 1;
                                child["searches"].InnerText = (count).ToString();

                            }
                            else
                            {
                                XmlNode locationNode = xd.CreateElement("location");
                                locationNode.InnerText = Session["zipcode"].ToString();
                                child["locations"].AppendChild(locationNode);
                                int count = Convert.ToInt32(child["searches"].InnerText) + 1;
                                child["searches"].InnerText = (count).ToString();
                            }
                        }
                    }
                    valueSet = true;
                    break;
                }            

            }
            if (valueSet == false)
            {
                XmlNode userNode = xd.CreateElement("User");
                XmlNode userNameNode = xd.CreateElement("username");
                XmlNode locationsNode = xd.CreateElement("locations");
                XmlNode searchesNode = xd.CreateElement("searches");
                searchesNode.InnerText = "1";
                userNameNode.InnerText = Context.User.Identity.GetUserName();
                userNode.AppendChild(userNameNode);
                userNode.AppendChild(locationsNode);
                userNode.AppendChild(searchesNode);
                XmlNode locationNode = xd.CreateElement("location");
                locationNode.InnerText = Session["ZipCode"].ToString();
                locationsNode.AppendChild(locationNode);
                node.AppendChild(userNode);
            }
            fs.Close();
            xd.Save(flocation);
        }
    }
}