using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Text;
using DataAccess;

namespace ExciseManagementInformationSystem
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void resetbtn_Click(object sender, EventArgs e)
        {

            if (emailtxt.Value != null)
            {
                string mail = emailtxt.Value;
                DataTable dt = new DataTable();
                userloginDataOperation uldo = new userloginDataOperation();
                dt = uldo.GetResetLink(mail);

                foreach (DataRow dr in dt.Rows)
                {
                    if (Convert.ToBoolean(dr["ReturnCode"]))
                    {
                        SendPasswordResetEmail(dt.Rows[0]["Email_ID"].ToString(), emailtxt.Value, dt.Rows[0]["UniqueId"].ToString());

                        Label2.Text = "<b>An email with instructions to reset your password is sent to your registered Email-Id!</b>";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('An email with instructions to reset your password is sent to your registered Email-Id!')", true);

                    }
                    else
                    {
                        Label2.ForeColor = System.Drawing.Color.Red;
                        Label2.Text = "Email Id not found!!!";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Email Id not found!!!')", true);

                    }
                }
            }
        }
        private void SendPasswordResetEmail(string Tomail, string username, string uniqueId)
        {
            MailMessage mailmessage = new MailMessage("atulasrani12@gmail.com", Tomail);
            StringBuilder sbEmailBody = new StringBuilder();
            sbEmailBody.Append("Dear&nbsp" + username + "<br/><br/>");
            sbEmailBody.Append("Please click on the following link to reset your password");
            sbEmailBody.Append("<br/>");
            sbEmailBody.Append("http://localhost:54974/resetpassword.aspx?uid=" + uniqueId);
            sbEmailBody.Append("<br/><br/>");
            sbEmailBody.Append("<b>Excise Department,National Informatics Centre@2019");

            mailmessage.IsBodyHtml = true;
            mailmessage.Body = sbEmailBody.ToString();
            mailmessage.Subject = "Reset Your Password";

            SmtpClient smtpclient = new SmtpClient("smtp.gmail.com", 587);

            smtpclient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "atulasrani12@gmail.com",
                Password = "atul008143"
            };
            smtpclient.EnableSsl = true;
       
            smtpclient.Send(mailmessage);
        }
    }
}