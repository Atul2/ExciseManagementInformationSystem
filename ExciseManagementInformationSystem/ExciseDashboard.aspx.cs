using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using DataAccess;

namespace ExciseManagementInformationSystem
{
    public partial class ExciseDashboard : System.Web.UI.Page
    {
        DispatchDataOperation ddo = new DispatchDataOperation();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (Session["LoginName"].ToString() != "admin")
            {
                Response.Redirect("Login.aspx");
            }
            DispatchRowCountLogic drc = new DispatchRowCountLogic();

            if (!Page.IsPostBack)
            {
                BinddropdownFY();
            }
        }
        #region BindDataDropdownFinancialYear
        public void BinddropdownFY()
        {
            DataTable dt = new DataTable();
            dt = ddo.GetFilterByFinancialYear();
            dropdownFYear.DataSource = dt;
            dropdownFYear.DataTextField = "FinancialYear";
            dropdownFYear.DataValueField = "yearID";
            dropdownFYear.DataBind();
        }

        #endregion

        protected void dropdownFYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["lastSelectedCountryIndex"] = dropdownFYear.SelectedIndex;
            string selectedText1 = dropdownFYear.SelectedItem.Text;
            string a1 = "";
            string a2 = "";
            string a3 = "";
            string a4 = "";
            DataTable dt, dt1, dt2 = new DataTable();
            dt2 = ddo.TotalDutyAmnt(selectedText1);
            string l3 = dt2.Rows[0][0].ToString();

            if (l3 == "")
            {
                Label3.Text = "0";
            }
            else
            {
                Label3.Text = Math.Round(Convert.ToDecimal(l3), 2).ToString();
            }
            dt1 = ddo.FilterInvoiceMaster(selectedText1, a1, a2, a3, a4);
            int b = dt1.Rows.Count;
            if (b > 0)
            {
                Label2.Text = b.ToString();
            }
            else if (b == 0)
            {
                Label2.Text = "0";
            }
            dt = ddo.GetFY(selectedText1);
            int a = dt.Rows.Count;
            if (a > 0)
            {
                Label1.Text = a.ToString();
            }
            else if (a == 0)
            {
                Label1.Text = "0";
            }
        }
    }
}