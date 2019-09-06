using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataAccess;
using BusinessObject;
using BusinessLogic;

namespace ExciseManagementInformationSystem
{
    public partial class InvoiceInfo : System.Web.UI.Page
    {
        DispatchDataOperation ddo = new DispatchDataOperation();
        string selectedText1 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bindrpt();
            }
        }
        #region BindReapterTable
        public void Bindrpt()
        {
            DataTable dt = new DataTable();
            selectedText1 = Request.QueryString["id"];
            dt = ddo.InvoiceInfo(selectedText1);
            rptr.DataSource = dt;
            rptr.DataBind();
        }

        #endregion
    }
}