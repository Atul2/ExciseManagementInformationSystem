using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class userloginDataOperation
    {
        private db_connection conn;
        public userloginDataOperation()
        {
            conn = new db_connection();
        }
        public DataTable searchByLoginNamePassword(string _loginname, string _password)
        {
            string query = string.Format("selectUserByLoginPass");
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@LoginName", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_loginname);
            sqlParameters[1] = new SqlParameter("@password", SqlDbType.VarChar);
            sqlParameters[1].Value = Convert.ToString(_password);
            return conn.executeSelectQuery(query, sqlParameters);
        }
        public DataTable GetResetLink(string _email)
        {
            string query = string.Format("spResetPassword");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@email", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_email);
            return conn.executeSelectQuery(query, sqlParameters);
        }
        public bool IsPasswordResetLinkValid(string uid)
        {
            List<SqlParameter> paramlist = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@GUID",
                    Value=uid
                }
            };
            return conn.ExecuteSP("spIsPasswordResetLinkValid", paramlist);
        }
        public bool ChangeUserPassword(string uid,string password)
        {
            List<SqlParameter> paramlist = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@GUID",
                    Value=uid
                },
                new SqlParameter()
                {
                    ParameterName="@Password",
                    Value= password
                },

            };
            return conn.ExecuteSP("spChangedPassword", paramlist);
        }
        public bool ChangeUserPasswordUsingCurrentPassword(string uname, string currentpassword,string newpassword)
        {
            List<SqlParameter> paramlist = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@UserName",
                    Value=uname
                },
                new SqlParameter()
                {
                    ParameterName="@CurrentPassword",
                    Value= currentpassword
                },
                new SqlParameter()
                {
                    ParameterName="@NewPassword",
                    Value= newpassword
                }

            };
            return conn.ExecuteSP("spChangePasswordUsingCurrentPassword", paramlist);
        }
    }
}
