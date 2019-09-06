using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;
using BusinessObject;
namespace BusinessLogic
{
    public class DispatchRowCountLogic
    {
        private DispatchDataOperation ddo;
        public DispatchRowCountLogic()
        {
            ddo = new DispatchDataOperation();
        }
        public int GetRowCount()
        {
            DataTable dt = new DataTable();
            dt = ddo.CountRow();
            int count = dt.Rows.Count;
            string newcount = count.ToString();
            if (!string.IsNullOrEmpty(newcount))
            {
                return count;
            }
            else
            {
                return 0;
            }
        }
        //public DispatchEntities GetDispatchFilterFY(string finY)
        //{
        //    DispatchEntities de = new DispatchEntities();
        //    DataTable dt = new DataTable();
        //    dt = ddo.FilterFY(finY);
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        de.FinancialYear = dr["FinancialYear"].ToString();
        //    }
        //    return de;
        //}
        //public DispatchEntities GetFYfilter(string FY)
        //{
        //    DispatchEntities de = new DispatchEntities();
        //    DataTable dt = new DataTable();
        //    dt = ddo.GetFilterByFinancialYear(FY);
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        de.FinancialYear = dr["FinancialYear"].ToString();

        //    }
        //    return de;
        //}
    }
}
