using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseManagementInformationSystem
{
    public partial class ExciseMIS : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (Session["LoginName"].ToString() != "admin")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Label1.Text = Session["LoginName"].ToString();
            }
        }
        protected string SetCssClass(string page)
        {
            return Request.Url.AbsolutePath.ToLower().EndsWith(page.ToLower()) ? "active" : "";
        }

    }
}