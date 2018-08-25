using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class XPathSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";
            XMLServices.Service1Client xmlPxy = new XMLServices.Service1Client();
            try
            {
                string[] result = xmlPxy.XPathSearch(txtXMLUrl.Text, txtPath.Text);
                if (result.Length == 0)
                {
                    lblResult.Text = "No results found, check path";
                }
                for(int i=0; i<result.Length; i++)
                {
                    string encodedXml = String.Format("<pre>{0}</pre>", HttpUtility.HtmlEncode(result[i]));
                    lblResult.Text += encodedXml + "<br/>";
                }
            }
            catch(Exception em)
            {
                lblResult.Text = em.Message.ToString();
            }
        }
    }
}