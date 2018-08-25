using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class imageProcess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        ImageVerifier.ServiceClient imgPxy = new ImageVerifier.ServiceClient();
        string myStr, userLen;

        if (Session["userLength"] == null)
            userLen = "4";
        else
            userLen = Session["userLength"].ToString();
        myStr = imgPxy.GetVerifierString(userLen);
        Session["generatedString"] = myStr;


        Stream myStream = imgPxy.GetImage(myStr);
        System.Drawing.Image myImage = System.Drawing.Image.FromStream(myStream);
        Response.ContentType = "image/jpeg";
        myImage.Save(Response.OutputStream, ImageFormat.Jpeg);


    }    
}