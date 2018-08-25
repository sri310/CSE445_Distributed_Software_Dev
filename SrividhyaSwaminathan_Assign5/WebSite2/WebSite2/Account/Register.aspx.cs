using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Xml;
using WebSite2;
using SecureString;
using System.Web.Security;
using System.Web;

public partial class Account_Register : Page
{
    protected void CreateUser_Click(object sender, EventArgs e)
    {
        if (Session["generatedString"].Equals(txtUserIp.Text))
        {
            imgOp.Text = "Congratulations! the code is correct";
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
                    string decryptPwd = child["password"].InnerText.Decrypt();
                    if (child["username"].InnerText == UserName.Text)
                    {
                        fs.Close();
                        exists = true;
                        ErrorMessage.Text = "User name already exists, Choose another one";
                        break;                     
                        
                    }

                }
                if (exists == false)
                {
                    XmlNode userNode = xd.CreateElement("User");
                    XmlNode usernameNode = xd.CreateElement("username");
                    usernameNode.InnerText = UserName.Text;
                    userNode.AppendChild(usernameNode);
                    XmlNode pwdNode = xd.CreateElement("password");
                    pwdNode.InnerText = Password.Text.EnCrypt();
                    userNode.AppendChild(pwdNode);
                    node.AppendChild(userNode);
                    
                    
                }
                fs.Close();
                xd.Save(flocation);
                FormsAuthentication.RedirectFromLoginPage(UserName.Text, false);
            }

            


        }
        else
        {
            
            ErrorMessage.Text = "Sorry, the string that you entered does not match the image. Try, again!";
            UserName.Text = "";
            ConfirmPassword.Text = "";
            Password.Text = "";
            txtUserIp.Text = "";
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Abandon();
        Context.GetOwinContext().Authentication.SignOut();
        Image1.ImageUrl = "~/imageProcess.aspx";
       
    }

    protected void submit_img_Click(object sender, EventArgs e)
    {
    }

    protected void show_img_Click(object sender, EventArgs e)
    {
        ImageVerifier.ServiceClient imgPxy = new ImageVerifier.ServiceClient();
        Session["userLength"] = "4";
        string ans = imgPxy.GetVerifierString("4");
        show_img.Text = "Show Me another Image string";
        Image1.Visible = true;
    }
}