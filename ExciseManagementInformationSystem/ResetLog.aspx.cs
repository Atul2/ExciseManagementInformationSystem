using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using System.Web.Security;

namespace ExciseManagementInformationSystem
{
    public partial class ResetLog : System.Web.UI.Page
    {
        userloginDataOperation uldo = new userloginDataOperation();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void resetbtn_Click(object sender, EventArgs e)
        {
            if (Session["LoginName"] != null)
            {
                string uname = Session["LoginName"].ToString();
                string currentpassword= FormsAuthentication.HashPasswordForStoringInConfigFile(currentpasstxt.Value, "MD5");
                string newpassword= FormsAuthentication.HashPasswordForStoringInConfigFile(newpasstxt.Value, "MD5");
                bool n = uldo.ChangeUserPasswordUsingCurrentPassword(uname,currentpassword,newpassword);
                if (n == true)
                {
                    Label2.Text = "Password Changed Successfully!!";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Password Change Successfully!!')", true);
                }
                else
                {
                    Label2.ForeColor = System.Drawing.Color.Red;
                    Label2.Text = "Operation Failed!!!!!!!";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Operation Failed!!!!!!!')", true);
                }
            }
        }
    }
}