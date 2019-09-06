using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DataAccess
{
    public class LoginDA
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
        public string verifyusername(string user, string passw)//getting the userType
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("selectUserByLoginPass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoginName", user);
                cmd.Parameters.AddWithValue("@password", passw);
                string a=cmd.ExecuteScalar().ToString();
                return a;
            }
            catch (Exception ex)
            {

                 throw ex;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
