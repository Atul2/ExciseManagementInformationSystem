using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataAccess;
using System.Web.Security;
namespace ExciseManagementInformationSystem
{
    public partial class resetpassword : System.Web.UI.Page
    {
        userloginDataOperation uldo = new userloginDataOperation();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["uid"] != null)
                {
                    string uid = Request.QueryString["uid"];
                    bool b = uldo.IsPasswordResetLinkValid(uid);
                    if (!b)
                    {
                        Label2.ForeColor = System.Drawing.Color.Red;
                        Label2.Text = "Password Reset Link has expired or is invalid!!";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Password Reset Link has expired or is invalid!!')", true);
                    }
                }
                else
                {
                    newpasstxt.Disabled=true;
                    confirmpasswordtxt.Disabled = true;
                    Label2.ForeColor = System.Drawing.Color.Red;
                    Label2.Text = "Sorry Invalid Request , user has not requested to forgot password!!!";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Sorry Invalid Request , user has not requested to forgot password!!!')", true);
                }
            }
        }

        protected void resetbtn_Click(object sender, EventArgs e)
        {
            userloginDataOperation uldo = new userloginDataOperation();
            string uid = Request.QueryString["uid"];
            string pass = FormsAuthentication.HashPasswordForStoringInConfigFile(newpasstxt.Value, "MD5");
            bool a = uldo.ChangeUserPassword(uid,pass);
            if (a == true)
            {
                Label2.Text = "Password Change Successfully!!";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Password Change Successfully!!')", true);
            }
            else
            {
                Label2.ForeColor = System.Drawing.Color.Red;
                Label2.Text = "Password Reset Link has expired or is invalid!!";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Password Reset Link has expired or is invalid!!')", true);
            }
        }
    }
}