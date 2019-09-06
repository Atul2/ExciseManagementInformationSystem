using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataAccess;

namespace ExciseManagementInformationSystem
{
    public partial class StockStatus : System.Web.UI.Page
    {
        DispatchDataOperation ddo = new DispatchDataOperation();
        string hologramno = "";
        string caseserialno = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GetDetailsbtn_Click(object sender, EventArgs e)
        {

            hologramno = hologram.Value;
            if (hologramno != "")
            {
                hologramno = hologram.Value;
                DataTable dt, dt1,dt2 = new DataTable();
                dt = ddo.StockStatusHologram(hologramno);
                if (dt.Rows[0]["TransactionType"].ToString() == "SALE")
                {
                    rptr1.Visible = true;
                    dt1 = ddo.StockInvoiceNoHologram(hologramno);
                    rptr1.DataSource = dt1;
                    rptr1.DataBind();

                    dt = ddo.StockStatusHologram(hologramno);
                    rptr.DataSource = dt;
                    rptr.DataBind();

                    rptr2.Visible = true;
                    dt2 = ddo.StockCaseSerialNo(hologramno);
                    rptr2.DataSource = dt2;
                    rptr2.DataBind();
                }
                else
                {
                    rptr1.Visible = false;
                    rptr2.Visible = false;
                    rptr.DataSource = dt;
                    rptr.DataBind();
                }
            }
        }
        protected void AtLeastOneContact_ServerValidate(object source, ServerValidateEventArgs args)
        {
            hologramno = hologram.Value;
            caseserialno = serial.Value;
            if (hologramno != "" || caseserialno != "")
                args.IsValid = true;
            else
            {
                args.IsValid = false;
            }
        }
        protected void GetDetailserialbtn_Click(object sender, EventArgs e)
        {
            caseserialno = serial.Value;
            if (caseserialno != "")
            {
                caseserialno = Convert.ToDecimal(serial.Value).ToString("0.00");
                DataTable dt, dt1, dt2 = new DataTable();
                dt = ddo.StockStatusCaseSerialNo(caseserialno);

                if (dt.Rows[0]["TransactionType"].ToString() == "SALE")
                {
                    rptr1.Visible = true;
                    dt1 = ddo.StockInvoiceNoCaseserial(caseserialno);
                    rptr1.DataSource = dt1;
                    rptr1.DataBind();

                    dt = ddo.StockStatusCaseSerialNo(caseserialno);
                    rptr.DataSource = dt;
                    rptr.DataBind();

                    rptr2.Visible = true;
                    dt2 = ddo.StockAllHologram(caseserialno);
                    rptr2.DataSource = dt2;
                    rptr2.DataBind();
                }
                else
                {
                    rptr1.Visible = false;
                    rptr2.Visible = false;
                    rptr.DataSource = dt;
                    rptr.DataBind();
                }
            }
        }
    }
}