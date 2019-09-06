using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using BusinessObject;
using System.Data;
using System.Data.SqlClient;
namespace BusinessLogic
{
    public class userloginBLogic
    {
        private userloginDataOperation uldo;
        public userloginBLogic()
        {
            uldo = new userloginDataOperation();
        }
        public userloginEntities GetUserLoginByNamePass(string loginname,string pass)
        {
            userloginEntities ue = new userloginEntities();
            DataTable dt = new DataTable();
            dt = uldo.searchByLoginNamePassword(loginname,pass);
            foreach (DataRow dr in dt.Rows)
            {
                ue.LoginName = dr["LoginName"].ToString();
                ue.password = dr["password"].ToString();
            }
            return ue;
        }
       
    }
}
