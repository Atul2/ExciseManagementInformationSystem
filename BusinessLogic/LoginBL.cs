using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
namespace BusinessLogic
{
    public class LoginBL
    {
        LoginDA dallogin = new LoginDA();
        public int ballog(string userid, string passw)//checking the usename and password
        {
            try
            {
                //int a = dallogin.userlogin(userid, passw);
                string a = dallogin.verifyusername(userid, passw);
                if (a == "admin")
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ec)
            {
                ec.GetType();
            }
            return 0;
        }
       
    }
}
