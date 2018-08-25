using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Xml;
using WebSite2;
using SecureString;
using System.Web.Security;

public partial class Account_Login : Page
{
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
            // Validate the user password              
            string flocation = Path.Combine(Request.PhysicalApplicationPath, @"App_Data\memberUsers.xml"); ;
            if (File.Exists(flocation))
            {
                FileStream fs = new FileStream(flocation, FileMode.Open);
                XmlDocument xd = new XmlDocument();
                xd.Load(fs);
                bool exists = false;
                XmlElement node = xd.DocumentElement;
                XmlNodeList Children = node.ChildNodes;
                foreach (XmlNode child in Children)
                {
                   
                    if (child["username"].InnerText == UserName.Text)
                    {
                        if(child["password"].InnerText.Decrypt() == Password.Text)
                        {
                            fs.Close();
                            exists = true;
                            FormsAuthentication.RedirectFromLoginPage(UserName.Text, false);
                            break;
                        }                       

                    }

                }
                if (exists == false)
                {

                    FailureText.Text = "Invalid username or password.";
                    ErrorMessage.Visible = true;
                }

                fs.Close();
            }
            else
            {
                FailureText.Text = "Invalid username or password.";
                ErrorMessage.Visible = true;
            }
            }
        }
}