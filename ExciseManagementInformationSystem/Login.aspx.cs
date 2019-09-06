using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using BusinessLogic;
using System.Data;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Configuration;
using BusinessObject;
using System.Net.Mail;
using System.Text;

namespace ExciseManagementInformationSystem
{

    public partial class Login : System.Web.UI.Page
    {
        private userloginBLogic ulb;
        public Login()
        {
            ulb = new userloginBLogic();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void loginButton_Click(object sender, EventArgs e)
        {

            string LoginName = nametxt.Value;
            string password = md5(pswdtxt.Value);
            userloginEntities ue = new userloginEntities();
            ue = ulb.GetUserLoginByNamePass(LoginName, password);

            if (ue.LoginName == null && ue.password == null)
            {
                Label1.Text = "no match found,invalid username and password please check!!!";
                if (ue.LoginName != null || ue.password == null)
                {
                    Label1.Text = "invalid password please check!!!";
                }
                else if (ue.password != null || ue.LoginName == null)
                {
                    Label1.Text = "invalid username please check!!!";
                }
            }
            else
            {
                Session["LoginName"] = LoginName;
                Response.Redirect("ExciseDashboard.aspx");
            }

        }
        private string md5(string sPasswrd)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(sPasswrd);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();
        }

        protected void resetbtn_Click(object sender, EventArgs e)
        {
           
           
        }
      
    }
}