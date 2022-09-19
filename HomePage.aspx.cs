using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HangManAsp
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
            if (Session["Game"] != null)
            {
                string message = "לא ניתן לצאת ממשחק קיים";
                string urlRedirect = "HangMan.aspx";
                string script = "window.onload = function(){ alert('"+message+"'); window.location = '"+urlRedirect+"'; }";
                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
            }
        }
    }
}