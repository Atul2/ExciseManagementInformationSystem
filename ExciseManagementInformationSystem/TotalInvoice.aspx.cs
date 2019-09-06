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
    public partial class TotalInvoice : System.Web.UI.Page
    {
        #region ClassAndvariable
        DispatchDataOperation ddo = new DispatchDataOperation();
        string selectedText1 = "";
        string selectedText2 = "";
        string selectedText3 = "";
        #endregion
        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                BindTotalInvoiceTableWarehouseWise();
                TotalCurrntyrInvoice();
                TotalCurrntMonthInvoice();
                selectInvoiceByDistrict();
                WareHouseWiseDutyAmnt();
                DistrictWiseDutyAmnt();
                TotalDutyAmntMnth();
                TotalDutyAmntYear();
                BinddropdownFY();
                BinddropdownSupplier();
                BinddropdownWareHouse();
                BinddropdownDistrictName();
            }
        }
        #endregion
        #region BindTotalInvoiceTableWarehouseWise
        public void BindTotalInvoiceTableWarehouseWise()
        {
            DataTable dt = new DataTable();
            dt = ddo.SelectWareHouseWiseTotalInvoice();
            rptr.DataSource = dt;
            rptr.DataBind();
        }
        #endregion
        #region selectInvoiceByDistrict
        public void selectInvoiceByDistrict()
        {
            DataTable dt = new DataTable();
            dt = ddo.selectInvoiceByDistrict();
            rptr1.DataSource = dt;
            rptr1.DataBind();
        }
        #endregion
        #region WareHouseWiseDutyAmnt
        public void WareHouseWiseDutyAmnt()
        {
            DataTable dt = new DataTable();
            dt = ddo.WareHouseWiseDutyAmnt();
            rptr2.DataSource = dt;
            rptr2.DataBind();
        }
        #endregion
        #region DistrictWiseDutyAmnt
        public void DistrictWiseDutyAmnt()
        {
            DataTable dt = new DataTable();
            dt = ddo.DistrictWiseDutyAmnt();
            rptr3.DataSource = dt;
            rptr3.DataBind();
        }
        #endregion
        #region TotalCurrntyrInvoice
        public void TotalCurrntyrInvoice()
        {
            DataTable dt = new DataTable();
            dt = ddo.TotalCurrntyrInvoice();
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
        #endregion
        #region TotalCurrntMonthInvoice
        public void TotalCurrntMonthInvoice()
        {
            DataTable dt = new DataTable();
            dt = ddo.TotalCurrntMonthInvoice();
            int a = dt.Rows.Count;
            if (a > 0)
            {
                Label2.Text = a.ToString();
            }
            else if (a == 0)
            {
                Label2.Text = "0";
            }
        }
        #endregion
        #region TotalDutyAmntMnth
        public void TotalDutyAmntMnth()
        {
            DataTable dt = new DataTable();
            dt = ddo.TotalDutyAmntMnth();
            string l3 = dt.Rows[0][0].ToString();
            if (l3 == "")
            {
                Label3.Text = "0";
            }
            else
            {
                Label3.Text = Math.Round(Convert.ToDecimal(l3), 2).ToString();
            }

        }
        #endregion
        #region  TotalDutyAmntYear
        public void TotalDutyAmntYear()
        {
            DataTable dt = new DataTable();
            dt = ddo.TotalDutyAmntYear();
            string l4 = dt.Rows[0][0].ToString();
            if (l4 == "")
            {
                Label4.Text = "0";
            }
            else
            {
                Label4.Text = Math.Round(Convert.ToDecimal(l4), 2).ToString();
            }

        }
        #endregion
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
        #region BindDataDropDownSupplier
        public void BinddropdownSupplier()
        {
            DataTable dt = new DataTable();
            dt = ddo.GetFilterBySupplierDetail();
            dropdownSupplier.DataSource = dt;
            dropdownSupplier.DataTextField = "SupplierName";
            dropdownSupplier.DataValueField = "SupplierId";
            dropdownSupplier.DataBind();

            dropdownSupplier.Items.Insert(0, new ListItem { Text = "--Choose-Supplier--", Value = "0" });
        }
        #endregion
        #region BindDataDropDownWareHouse
        public void BinddropdownWareHouse()
        {
            DataTable dt = new DataTable();
            dt = ddo.GetValueWareHouse();
            dropdownWareHouse.DataSource = dt;
            dropdownWareHouse.DataTextField = "WareHouseName";
            dropdownWareHouse.DataValueField = "WareHouseId";
            dropdownWareHouse.DataBind();
            dropdownWareHouse.Items.Insert(0, new ListItem { Text = "--Choose-WareHouse--", Value = "0" });
        }
        #endregion
        #region BindDataDropDownDistrictName
        public void BinddropdownDistrictName()
        {
            DataTable dt = new DataTable();
            dt = ddo.DistrictName();
            DropdownDistrict.DataSource = dt;
            DropdownDistrict.DataTextField = "DistrictName";
            DropdownDistrict.DataValueField = "DistrictId";
            DropdownDistrict.DataBind();
            DropdownDistrict.Items.Insert(0, new ListItem { Text = "--Choose-District--", Value = "0" });
        }
        #endregion
        #region DropdownFinancialYear
        protected void dropdownFYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropdownFYear.SelectedIndex != -1)
            {
                DataTable dt = new DataTable();
                if (dropdownSupplier.SelectedIndex != 0)
                {
                    if (dropdownWareHouse.SelectedIndex != 0)
                    {
                        selectedText1 = dropdownFYear.SelectedItem.Text;
                        selectedText2 = dropdownSupplier.SelectedValue.ToString();
                        selectedText3 = dropdownWareHouse.SelectedValue.ToString();
                        dt = ddo.FilterFinSuppWareHouseInvoice(selectedText1, selectedText2, selectedText3);
                        rptr.DataSource = dt;
                        rptr.DataBind();
                    }
                    else
                    {
                        selectedText1 = dropdownFYear.SelectedItem.Text;
                        selectedText2 = dropdownSupplier.SelectedValue.ToString();
                        dt = ddo.FilterFinSuppWareHouseInvoice(selectedText1, selectedText2, selectedText3);
                        rptr.DataSource = dt;
                        rptr.DataBind();
                    }
                }
                else
                {
                    if (dropdownWareHouse.SelectedIndex != 0)
                    {
                        selectedText1 = dropdownFYear.SelectedItem.Text;
                        selectedText3 = dropdownWareHouse.SelectedValue.ToString();
                        dt = ddo.FilterFinSuppWareHouseInvoice(selectedText1, selectedText2, selectedText3);
                        rptr.DataSource = dt;
                        rptr.DataBind();
                    }
                    else
                    {
                        selectedText1 = dropdownFYear.SelectedItem.Text;
                        dt = ddo.FilterFinSuppWareHouseInvoice(selectedText1, selectedText2, selectedText3);
                        rptr.DataSource = dt;
                        rptr.DataBind();
                    }
                }
            }

            if (dropdownFYear.SelectedIndex != -1)
            {
                DataTable dt = new DataTable();
                if (dropdownSupplier.SelectedIndex != 0)
                {
                    if (dropdownWareHouse.SelectedIndex != 0)
                    {
                        selectedText1 = dropdownFYear.SelectedItem.Text;
                        selectedText2 = dropdownSupplier.SelectedValue.ToString();
                        selectedText3 = dropdownWareHouse.SelectedValue.ToString();
                        dt = ddo.FilterWareHouseWiseDutyAmnt(selectedText1, selectedText2, selectedText3);
                        rptr2.DataSource = dt;
                        rptr2.DataBind();
                    }
                    else
                    {
                        selectedText1 = dropdownFYear.SelectedItem.Text;
                        selectedText2 = dropdownSupplier.SelectedValue.ToString();
                        dt = ddo.FilterWareHouseWiseDutyAmnt(selectedText1, selectedText2, selectedText3);
                        rptr2.DataSource = dt;
                        rptr2.DataBind();
                    }
                }
                else
                {
                    if (dropdownWareHouse.SelectedIndex != 0)
                    {
                        selectedText1 = dropdownFYear.SelectedItem.Text;
                        selectedText3 = dropdownWareHouse.SelectedValue.ToString();
                        dt = ddo.FilterWareHouseWiseDutyAmnt(selectedText1, selectedText2, selectedText3);
                        rptr2.DataSource = dt;
                        rptr2.DataBind();
                    }
                    else
                    {
                        selectedText1 = dropdownFYear.SelectedItem.Text;
                        dt = ddo.FilterWareHouseWiseDutyAmnt(selectedText1, selectedText2, selectedText3);
                        rptr2.DataSource = dt;
                        rptr2.DataBind();
                    }
                }
            }
        }
        #endregion
        #region BlankBodyDropDownsupplier
        protected void dropdownSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #region BlankBodyDropDownwareHouse
        protected void dropdownWareHouse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #region DropDownDistrict
        protected void DropdownDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropdownFYear.SelectedIndex != -1)
            {
                DataTable dt = new DataTable();
                if (dropdownSupplier.SelectedIndex != 0)
                {
                    if (DropdownDistrict.SelectedIndex != 0)
                    {
                        selectedText1 = dropdownFYear.SelectedItem.Text;
                        selectedText2 = dropdownSupplier.SelectedValue.ToString();
                        selectedText3 = DropdownDistrict.SelectedValue.ToString();
                        dt = ddo.FILTERInvoiceByDistrictSuppFin(selectedText1, selectedText2, selectedText3);
                        rptr1.DataSource = dt;
                        rptr1.DataBind();
                    }
                    else
                    {
                        selectedText1 = dropdownFYear.SelectedItem.Text;
                        selectedText2 = dropdownSupplier.SelectedValue.ToString();
                        dt = ddo.FILTERInvoiceByDistrictSuppFin(selectedText1, selectedText2, selectedText3);
                        rptr1.DataSource = dt;
                        rptr1.DataBind();
                    }
                }
                else
                {
                    if (DropdownDistrict.SelectedIndex != 0)
                    {
                        selectedText1 = dropdownFYear.SelectedItem.Text;
                        selectedText3 = DropdownDistrict.SelectedValue.ToString();
                        dt = ddo.FILTERInvoiceByDistrictSuppFin(selectedText1, selectedText2, selectedText3);
                        rptr1.DataSource = dt;
                        rptr1.DataBind();
                    }
                    else
                    {
                        selectedText1 = dropdownFYear.SelectedItem.Text;
                        dt = ddo.FILTERInvoiceByDistrictSuppFin(selectedText1, selectedText2, selectedText3);
                        rptr1.DataSource = dt;
                        rptr1.DataBind();
                    }
                }
            }


            if (dropdownFYear.SelectedIndex != -1)
            {
                DataTable dt = new DataTable();
                if (dropdownSupplier.SelectedIndex != 0)
                {
                    if (DropdownDistrict.SelectedIndex != 0)
                    {
                        selectedText1 = dropdownFYear.SelectedItem.Text;
                        selectedText2 = dropdownSupplier.SelectedValue.ToString();
                        selectedText3 = DropdownDistrict.SelectedValue.ToString();
                        dt = ddo.FilterDistrictWiseDutyAmnt(selectedText1, selectedText2, selectedText3);
                        rptr3.DataSource = dt;
                        rptr3.DataBind();
                    }
                    else
                    {
                        selectedText1 = dropdownFYear.SelectedItem.Text;
                        selectedText2 = dropdownSupplier.SelectedValue.ToString();
                        dt = ddo.FilterDistrictWiseDutyAmnt(selectedText1, selectedText2, selectedText3);
                        rptr3.DataSource = dt;
                        rptr3.DataBind();
                    }
                }
                else
                {
                    if (DropdownDistrict.SelectedIndex != 0)
                    {
                        selectedText1 = dropdownFYear.SelectedItem.Text;
                        selectedText3 = DropdownDistrict.SelectedValue.ToString();
                        dt = ddo.FilterDistrictWiseDutyAmnt(selectedText1, selectedText2, selectedText3);
                        rptr3.DataSource = dt;
                        rptr3.DataBind();
                    }
                    else
                    {
                        selectedText1 = dropdownFYear.SelectedItem.Text;
                        dt = ddo.FilterDistrictWiseDutyAmnt(selectedText1, selectedText2, selectedText3);
                        rptr3.DataSource = dt;
                        rptr3.DataBind();
                    }
                }
            }
        }
        #endregion
    }
}