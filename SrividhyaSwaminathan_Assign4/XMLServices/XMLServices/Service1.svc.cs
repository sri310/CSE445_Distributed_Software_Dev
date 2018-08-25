using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace XMLServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        /// <summary>
        /// Method searches the xml document for a given xpath expression and returns the child nodes or content value based on 
        /// the search expression
        /// Input - stirng url for xml, string path to search
        /// Output - List<stirng> showing child nodes or content value
        /// </summary>
        /// <param name="URL"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<string> XPathSearch(string URL, string path)
        {
            XPathDocument dx = new XPathDocument(URL);
            XPathNavigator nav = dx.CreateNavigator();
            XPathNodeIterator iterator = nav.Select(path);
            List<string> res = new List<string>();
            try
            {
                while (iterator.MoveNext())
                {
                    //XPathNavigator n = iterator.Current;

                   res.Add(iterator.Current.InnerXml);                   

                }
                return res;
            }
            catch(Exception e)
            {
               res.Add(e.Message.ToString());
                return res;
            }
           
        }

        /// <summary>
        /// Method transforms an xml into html using a xsl doucument
        /// Input - string url for xml, string url for xsl
        /// Output-  byte array representing the html
        /// </summary>
        /// <param name="XmlURl"></param>
        /// <param name="XslURl"></param>
        /// <returns></returns>
        public Byte[] transformation(string XmlURl, string XslURl)
        {
            try
            {
                XPathDocument doc = new XPathDocument(XmlURl);
                XslCompiledTransform xt = new XslCompiledTransform();
                xt.Load(XslURl);
                StringWriter stringWriter = new StringWriter();
                xt.Transform(doc, null, stringWriter);
                //MemoryStream htmlMemoryStream = new MemoryStream(ASCIIEncoding.Default.GetBytes(stringWriter.ToString()));
                Byte[] bytes = Encoding.Default.GetBytes(stringWriter.ToString());
                return bytes;
            }
            catch(Exception e)
            {
                Byte[] bytes = Encoding.ASCII.GetBytes(e.Message.ToString());
                return bytes;
            }           
            
        }
       
    }
}
