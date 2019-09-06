using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;


namespace DataAccess
{
    class db_connection
    {
        public SqlDataAdapter adapter;
        private static string con_str = WebConfigurationManager.ConnectionStrings["mydb"].ToString();
        SqlConnection con = new SqlConnection(con_str); 
        #region SelectClass
        public DataTable executeSelectQuery(string _query, SqlParameter[] sqlparameter)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(con_str))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = _query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(sqlparameter);
                        using (adapter = new SqlDataAdapter())
                        {
                            adapter.SelectCommand = cmd;
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        public DataSet executeSelectSet(string _query, SqlParameter[] sqlparameter)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(con_str))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = _query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(sqlparameter);
                        using (adapter = new SqlDataAdapter())
                        {
                            adapter.SelectCommand = cmd;
                            adapter.Fill(ds, "tblProduct");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ds;
        }

        public SqlDataReader executeSelectReader(string _query, SqlParameter[] sqlparameter)
        {
            SqlDataReader dr;
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(con_str))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = _query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(sqlparameter);
                        using (adapter = new SqlDataAdapter())
                        {
                            adapter.SelectCommand = cmd;
                            adapter.Fill(dt);
                        }
                        dr = cmd.ExecuteReader();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return dr;
        }
        public DataTable executeSelect(string _query)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(con_str))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = _query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (adapter = new SqlDataAdapter())
                        {
                            adapter.SelectCommand = cmd;
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        #endregion
        #region NonQueryClass
        public bool executeNonQuery(string _query, SqlParameter[] sqlparameter)
        {
            bool dt = new bool();
            try
            {
                using (adapter = new SqlDataAdapter())
                {
                    using (SqlConnection con = new SqlConnection(con_str))
                    {
                        using (SqlCommand cmd = new SqlCommand(_query, con))
                        {
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandText = _query;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddRange(sqlparameter);
                            cmd.ExecuteNonQuery();
                            dt = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dt = false;
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        #endregion

        public bool ExecuteSP(string SPName, List<SqlParameter> SPParameters)
        {

            using (SqlConnection con = new SqlConnection(con_str))
            {
                SqlCommand cmd = new SqlCommand(SPName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter parameter in SPParameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                con.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }
    }
}
