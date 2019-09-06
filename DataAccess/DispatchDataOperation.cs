using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DataAccess
{
    public class DispatchDataOperation
    {
        private db_connection conn;
        public DispatchDataOperation()
        {
            conn = new db_connection();
        }
        public DataTable CountRow()
        {
            string query = string.Format("selectDispatch");
            return conn.executeSelect(query);
        }
        public DataTable SelectWareHouseWiseTotalInvoice()
        {
            string query = string.Format("SelectWareHouseWiseTotalInvoice");
            return conn.executeSelect(query);
        }
        public DataTable selectInvoiceByDistrict()
        {
            string query = string.Format("selectInvoiceByDistrict");
            return conn.executeSelect(query);
        }
        public DataTable WareHouseWiseDutyAmnt()
        {
            string query = string.Format("WareHouseWiseDutyAmnt");
            return conn.executeSelect(query);
        }
        public DataTable DistrictWiseDutyAmnt()
        {
            string query = string.Format("DistrictWiseDutyAmnt");
            return conn.executeSelect(query);
        }
        public DataTable TotalCurrntyrInvoice()
        {
            string query = string.Format("TotalCurrntyrInvoice");
            return conn.executeSelect(query);
        }
        public DataTable TotalCurrntMonthInvoice()
        {
            string query = string.Format("TotalCurrntMonthInvoice");
            return conn.executeSelect(query);
        }
        public DataTable TotalDutyAmntMnth()
        {
            string query = string.Format("TotalDutyAmntMnth");
            return conn.executeSelect(query);
        }
        public DataTable TotalDutyAmntYear()
        {
            string query = string.Format("TotalDutyAmntYear");
            return conn.executeSelect(query);
        }
        public DataTable TotalDutyAmnt(string _FinYear)
        {
            string query = string.Format("TotalDutyAmnt");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@financialYear", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_FinYear);
            return conn.executeSelectQuery(query, sqlParameters);
        }
        public DataTable GraphWareHouseDutyAmount(string _FinYear, string _Supp, string _Ware, string _from, string _to)
        {
            string query = string.Format("GraphWareHouseDutyAmount");
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@financialYear", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_FinYear);
            sqlParameters[1] = new SqlParameter("@supplierId", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(_Supp);
            sqlParameters[2] = new SqlParameter("@warehouseID", SqlDbType.NVarChar);
            sqlParameters[2].Value = Convert.ToString(_Ware);
            sqlParameters[3] = new SqlParameter("@Fromdate", SqlDbType.VarChar);
            sqlParameters[3].Value = Convert.ToString(_from);
            sqlParameters[4] = new SqlParameter("@Todate", SqlDbType.VarChar);
            sqlParameters[4].Value = Convert.ToString(_to);
            return conn.executeSelectQuery(query, sqlParameters);
        }
        public DataTable GraphWareHouseDispatch(string _FinYear, string _Supp, string _Ware, string _from, string _to)
        {
            string query = string.Format("GraphWareHouseDispatch");
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@financialYear", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_FinYear);
            sqlParameters[1] = new SqlParameter("@supplierId", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(_Supp);
            sqlParameters[2] = new SqlParameter("@warehouseID", SqlDbType.NVarChar);
            sqlParameters[2].Value = Convert.ToString(_Ware);
            sqlParameters[3] = new SqlParameter("@Fromdate", SqlDbType.VarChar);
            sqlParameters[3].Value = Convert.ToString(_from);
            sqlParameters[4] = new SqlParameter("@Todate", SqlDbType.VarChar);
            sqlParameters[4].Value = Convert.ToString(_to);
            return conn.executeSelectQuery(query, sqlParameters);
        }

        public DataTable GraphWareHouseInvoice(string _FinYear, string _Supp, string _Ware, string _from, string _to)
        {
            string query = string.Format("GraphWareHouseInvoice");
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@financialYear", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_FinYear);
            sqlParameters[1] = new SqlParameter("@supplierId", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(_Supp);
            sqlParameters[2] = new SqlParameter("@warehouseID", SqlDbType.NVarChar);
            sqlParameters[2].Value = Convert.ToString(_Ware);
            sqlParameters[3] = new SqlParameter("@Fromdate", SqlDbType.VarChar);
            sqlParameters[3].Value = Convert.ToString(_from);
            sqlParameters[4] = new SqlParameter("@Todate", SqlDbType.VarChar);
            sqlParameters[4].Value = Convert.ToString(_to);
            return conn.executeSelectQuery(query, sqlParameters);
        }
        public DataTable GraphSupplierDispatch(string _FinYear, string _Supp, string _Ware, string _from, string _to)
        {
            string query = string.Format("GraphSupplierDispatch");
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@financialYear", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_FinYear);
            sqlParameters[1] = new SqlParameter("@supplierId", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(_Supp);
            sqlParameters[2] = new SqlParameter("@warehouseID", SqlDbType.NVarChar);
            sqlParameters[2].Value = Convert.ToString(_Ware);
            sqlParameters[3] = new SqlParameter("@Fromdate", SqlDbType.VarChar);
            sqlParameters[3].Value = Convert.ToString(_from);
            sqlParameters[4] = new SqlParameter("@Todate", SqlDbType.VarChar);
            sqlParameters[4].Value = Convert.ToString(_to);
            return conn.executeSelectQuery(query, sqlParameters);
        }

        public DataTable GetFilterByFinancialYear()
        {
            string query = string.Format("FinancialYears");
            return conn.executeSelect(query);
        }
        public DataTable GetFilterBySupplierDetail()
        {
            string query = string.Format("SupplierDetail");
            return conn.executeSelect(query);
        }
        public DataTable Districts()
        {
            string query = string.Format("Districts");
            return conn.executeSelect(query);
        }
        public DataTable GetValueWareHouse()
        {
            string query = string.Format("wareHome");
            return conn.executeSelect(query);
        }
        public DataTable DistrictName()
        {
            string query = string.Format("DistrictName");
            return conn.executeSelect(query);
        }
        public DataTable GetBindFY()
        {
            string query = string.Format("stpSelectFinancialYear");
            return conn.executeSelect(query);
        }
        public DataTable GetFY(string _FinYear)
        {
            string query = string.Format("SelectDispactFilterFy");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@financialYear", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_FinYear);
            return conn.executeSelectQuery(query, sqlParameters);
        }
        public DataTable InvoiceInfo(string _FinYear)
        {
            string query = string.Format("InvoiceInfo");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@invoiceID", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_FinYear);
            return conn.executeSelectQuery(query, sqlParameters);
        }
        public DataTable FilterFY(string _FinYear, string _Supp, string _Ware)
        {
            string query = string.Format("FilterFinSuppWare");
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@financialYear", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_FinYear);
            sqlParameters[1] = new SqlParameter("@suppliername", SqlDbType.VarChar);
            sqlParameters[1].Value = Convert.ToString(_Supp);
            sqlParameters[2] = new SqlParameter("@warehousename", SqlDbType.VarChar);
            sqlParameters[2].Value = Convert.ToString(_Ware);
            return conn.executeSelectQuery(query, sqlParameters);
        }
        public DataTable FilterInvoiceMaster(string _FinYear, string _Supp, string _Ware, string _from, string _to)
        {
            string query = string.Format("FilterInvoiceMaster");
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@financialYear", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_FinYear);
            sqlParameters[1] = new SqlParameter("@warehouseID", SqlDbType.VarChar);
            sqlParameters[1].Value = Convert.ToString(_Supp);
            sqlParameters[2] = new SqlParameter("@districtID", SqlDbType.VarChar);
            sqlParameters[2].Value = Convert.ToString(_Ware);
            sqlParameters[3] = new SqlParameter("@Fromdate", SqlDbType.VarChar);
            sqlParameters[3].Value = Convert.ToString(_from);
            sqlParameters[4] = new SqlParameter("@Todate", SqlDbType.VarChar);
            sqlParameters[4].Value = Convert.ToString(_to);
            return conn.executeSelectQuery(query, sqlParameters);
        }
        public DataTable FilterSupplier(string _FinYear, string _Supp, string _Ware)
        {
            string query = string.Format("FilterFinSuppWare");
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@financialYear", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_FinYear);
            sqlParameters[1] = new SqlParameter("@suppliername", SqlDbType.VarChar);
            sqlParameters[1].Value = Convert.ToString(_Supp);
            sqlParameters[2] = new SqlParameter("@warehousename", SqlDbType.VarChar);
            sqlParameters[2].Value = Convert.ToString(_Ware);
            return conn.executeSelectQuery(query, sqlParameters);
        }
        public DataTable FilterWareHouse(string _FinYear, string _Supp, string _Ware)
        {
            string query = string.Format("FilterFinSuppWare");
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@financialYear", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_FinYear);
            sqlParameters[1] = new SqlParameter("@suppliername", SqlDbType.VarChar);
            sqlParameters[1].Value = Convert.ToString(_Supp);
            sqlParameters[2] = new SqlParameter("@warehousename", SqlDbType.VarChar);
            sqlParameters[2].Value = Convert.ToString(_Ware);
            return conn.executeSelectQuery(query, sqlParameters);
        }
        public DataTable StockStatusHologram(string _hologram)
        {
            string query = string.Format("StockStatusHologram");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@hologramserial", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_hologram);

            return conn.executeSelectQuery(query, sqlParameters);
        }
        public DataTable StockCaseSerialNo(string _hologram)
        {
            string query = string.Format("StockCaseSerialNo");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@hologramserial", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_hologram);

            return conn.executeSelectQuery(query, sqlParameters);
        }
        public DataTable StockInvoiceNoHologram(string _hologram)
        {
            string query = string.Format("StockInvoiceNoHologram");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@hologramserial", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_hologram);

            return conn.executeSelectQuery(query, sqlParameters);
        }
        public DataTable StockStatusCaseSerialNo(string _caseserial)
        {
            string query = string.Format("StockStatusCaseSerialNo");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Caseserial", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_caseserial);

            return conn.executeSelectQuery(query, sqlParameters);
        }
        public DataTable StockAllHologram(string _caseserial)
        {
            string query = string.Format("StockAllHologram");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Caseserial", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_caseserial);

            return conn.executeSelectQuery(query, sqlParameters);
        }
        public DataTable StockInvoiceNoCaseserial(string _caseserial)
        {
            string query = string.Format("StockInvoiceNoCaseserial");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@caseserial", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_caseserial);

            return conn.executeSelectQuery(query, sqlParameters);
        }

        public DataTable FilterFinSuppWareHouseInvoice(string _FinYear, string _Supp, string _Ware)
        {
            string query = string.Format("FilterFinSuppWareHouseInvoice");
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@financialYear", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_FinYear);
            sqlParameters[1] = new SqlParameter("@supplierId", SqlDbType.VarChar);
            sqlParameters[1].Value = Convert.ToString(_Supp);
            sqlParameters[2] = new SqlParameter("@warehouseId", SqlDbType.VarChar);
            sqlParameters[2].Value = Convert.ToString(_Ware);
            return conn.executeSelectQuery(query, sqlParameters);
        }
        public DataTable FilterWareHouseWiseDutyAmnt(string _FinYear, string _Supp, string _Ware)
        {
            string query = string.Format("FilterWareHouseWiseDutyAmnt");
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@financialYear", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_FinYear);
            sqlParameters[1] = new SqlParameter("@supplierId", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(_Supp);
            sqlParameters[2] = new SqlParameter("@warehouseId", SqlDbType.NVarChar);
            sqlParameters[2].Value = Convert.ToString(_Ware);
            return conn.executeSelectQuery(query, sqlParameters);
        }
        public DataTable FILTERInvoiceByDistrictSuppFin(string _FinYear, string _Supp, string _Ware)
        {
            string query = string.Format("FILTERInvoiceByDistrictSuppFin");
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@financialYear", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_FinYear);
            sqlParameters[1] = new SqlParameter("@supplierId", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(_Supp);
            sqlParameters[2] = new SqlParameter("@districtId", SqlDbType.NVarChar);
            sqlParameters[2].Value = Convert.ToString(_Ware);
            return conn.executeSelectQuery(query, sqlParameters);
        }
        public DataTable FilterDistrictWiseDutyAmnt(string _FinYear, string _Supp, string _Ware)
        {
            string query = string.Format("FilterDistrictWiseDutyAmnt");
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@financialYear", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_FinYear);
            sqlParameters[1] = new SqlParameter("@supplierId", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(_Supp);
            sqlParameters[2] = new SqlParameter("@districtId", SqlDbType.NVarChar);
            sqlParameters[2].Value = Convert.ToString(_Ware);
            return conn.executeSelectQuery(query, sqlParameters);
        }
        public DataTable BetweenDates(string fromdate, string todate)
        {
            string query = string.Format("BetweenDates");
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@Fromdate", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(fromdate);
            sqlParameters[1] = new SqlParameter("@Todate", SqlDbType.VarChar);
            sqlParameters[1].Value = Convert.ToString(todate);
            return conn.executeSelectQuery(query, sqlParameters);
        }
    }
}
