using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_transform_Click(object sender, EventArgs e)
        {
            lblHtml.Text = "";
            try
            {
                XMLServices.Service1Client xmlPxy = new XMLServices.Service1Client();
                string xml = txtXMLUrl.Text.ToString();
                string xsl = txtXslUrl.Text.ToString();
                Byte[] b = xmlPxy.transformation(xml, xsl);               
                string path = AppDomain.CurrentDomain.BaseDirectory;
                path += "Persons.html";
                File.WriteAllBytes(path, b);               
                lblHtml.Text += System.Text.Encoding.Default.GetString(b);
                
                lblHtml.Text += "<br/> Path: "+path;
            }
           
            catch(Exception em)
            {
                lblHtml.Text = em.Message.ToString();
            }
        }
    }
}