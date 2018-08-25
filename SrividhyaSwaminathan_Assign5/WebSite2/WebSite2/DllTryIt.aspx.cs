using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SecureString;
public partial class DllTryIt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_Encrypt_Click(object sender, EventArgs e)
    {
        string s = txtEncrypt.Text;
        try
        {
            lblEncrypt.Text = s.EnCrypt();
        }
        catch(Exception em)
        {
            lblEncrypt.Text = em.Message;
        }
    }

    protected void btn_Decrypt_Click(object sender, EventArgs e)
    {
        string s = txtDecrypt.Text;
        try
        {
            lblDecrypt.Text = s.Decrypt();
        }
        catch (Exception em)
        {
            lblDecrypt.Text = em.Message;
        }
    }
}