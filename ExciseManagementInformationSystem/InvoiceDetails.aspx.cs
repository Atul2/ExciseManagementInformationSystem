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
    public partial class InvoiceDetails : System.Web.UI.Page
    {
        #region ClassnObjectVariable
        DispatchDataOperation ddo = new DispatchDataOperation();
        DispatchEntities de = new DispatchEntities();
        DispatchRowCountLogic drc = new DispatchRowCountLogic();

        string selectedText1 = "";
        string selectedText2 = "";
        string selectedText3 = "";
        string frmdt = "";
        string todt = "";

        #endregion
        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BinddropdownFY();
                BinddropdownWareHouse();
                BinddropdownDistrictName();
                from.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy"));
                to.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy"));
                from.Attributes.Add("ReadOnly", "true");
                to.Attributes.Add("ReadOnly", "true");
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
        protected void dropdownFYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (Session["lastSelectedCountryIndex"] != null)
            {
                dropdownFYear.SelectedIndex = Convert.ToInt32((Session["lastSelectedCountryIndex"]).ToString());
                if (dropdownFYear.SelectedIndex != -1)
                {
                    selectedText1 = dropdownFYear.SelectedItem.Text;
                    dt = ddo.FilterInvoiceMaster(selectedText1, selectedText2, selectedText3, frmdt, todt);
                    rptr.DataSource = dt;
                    rptr.DataBind();
                    Session["lastSelectedCountryIndex"] = null;
                }
            }
            if (Session["lastSelectedCountryIndex"] == null)
            {

                if (dropdownFYear.SelectedIndex != -1)
                {
                    if ( dropdownWareHouse.SelectedIndex != 0)
                    {
                        if (DropdownDistrict.SelectedIndex != 0)
                        {
                            if (from.Text != Convert.ToString(DateTime.Now.ToString("dd / MM / yyyy")) && to.Text != Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")))
                            {
                                DateTime s1 = System.Convert.ToDateTime(from.Text);
                                DateTime Date = (s1);
                                String frmdt = Date.ToString("yyyy-MM-dd");
                                DateTime s2 = System.Convert.ToDateTime(to.Text);
                                DateTime date = (s2);
                                String todt = date.ToString("yyyy-MM-dd");
                                selectedText1 = dropdownFYear.SelectedItem.Text;
                                selectedText2 =  dropdownWareHouse.SelectedValue.ToString();
                                selectedText3 = DropdownDistrict.SelectedValue.ToString();
                                dt = ddo.FilterInvoiceMaster(selectedText1, selectedText2, selectedText3, frmdt, todt);
                                rptr.DataSource = dt;
                                rptr.DataBind();
                            }
                            else
                            {
                                selectedText1 = dropdownFYear.SelectedItem.Text;
                                selectedText2 =  dropdownWareHouse.SelectedValue.ToString();
                                selectedText3 = DropdownDistrict.SelectedValue.ToString();
                                dt = ddo.FilterInvoiceMaster(selectedText1, selectedText2, selectedText3, frmdt, todt);
                                rptr.DataSource = dt;
                                rptr.DataBind();
                            }
                        }
                        else
                        {
                            if (from.Text != Convert.ToString(DateTime.Now.ToString("dd / MM / yyyy")) && to.Text != Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")))
                            {
                                DateTime s1 = System.Convert.ToDateTime(from.Text);
                                DateTime Date = (s1);
                                String frmdt = Date.ToString("yyyy-MM-dd");
                                DateTime s2 = System.Convert.ToDateTime(to.Text);
                                DateTime date = (s2);
                                String todt = date.ToString("yyyy-MM-dd");
                                selectedText1 = dropdownFYear.SelectedItem.Text;
                                selectedText2 =  dropdownWareHouse.SelectedValue.ToString();
                                dt = ddo.FilterInvoiceMaster(selectedText1, selectedText2, selectedText3, frmdt, todt);
                                rptr.DataSource = dt;
                                rptr.DataBind();
                            }
                            else
                            {
                                selectedText1 = dropdownFYear.SelectedItem.Text;
                                selectedText2 =  dropdownWareHouse.SelectedValue.ToString();
                                dt = ddo.FilterInvoiceMaster(selectedText1, selectedText2, selectedText3, frmdt, todt);
                                rptr.DataSource = dt;
                                rptr.DataBind();
                            }
                        }
                    }
                    else
                    {
                        if (DropdownDistrict.SelectedIndex != 0)
                        {
                            if (from.Text != Convert.ToString(DateTime.Now.ToString("dd / MM / yyyy")) && to.Text != Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")))
                            {
                                DateTime s1 = System.Convert.ToDateTime(from.Text);
                                DateTime Date = (s1);
                                String frmdt = Date.ToString("yyyy-MM-dd");
                                DateTime s2 = System.Convert.ToDateTime(to.Text);
                                DateTime date = (s2);
                                String todt = date.ToString("yyyy-MM-dd");
                                selectedText1 = dropdownFYear.SelectedItem.Text;
                                selectedText3 = DropdownDistrict.SelectedValue.ToString();
                                dt = ddo.FilterInvoiceMaster(selectedText1, selectedText2, selectedText3, frmdt, todt);
                                rptr.DataSource = dt;
                                rptr.DataBind();
                            }
                            else
                            {
                                selectedText1 = dropdownFYear.SelectedItem.Text;
                                selectedText3 = DropdownDistrict.SelectedValue.ToString();
                                dt = ddo.FilterInvoiceMaster(selectedText1, selectedText2, selectedText3, frmdt, todt);
                                rptr.DataSource = dt;
                                rptr.DataBind();
                            }
                        }
                        else
                        {
                            if (from.Text != Convert.ToString(DateTime.Now.ToString("dd / MM / yyyy")) && to.Text != Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")))
                            {
                                DateTime s1 = System.Convert.ToDateTime(from.Text);
                                DateTime Date = (s1);
                                String frmdt = Date.ToString("yyyy-MM-dd");
                                DateTime s2 = System.Convert.ToDateTime(to.Text);
                                DateTime date = (s2);
                                String todt = date.ToString("yyyy-MM-dd");

                                selectedText1 = dropdownFYear.SelectedItem.Text;
                                dt = ddo.FilterInvoiceMaster(selectedText1, selectedText2, selectedText3, frmdt, todt);
                                rptr.DataSource = dt;
                                rptr.DataBind();
                            }
                            else
                            {
                                selectedText1 = dropdownFYear.SelectedItem.Text;
                                dt = ddo.FilterInvoiceMaster(selectedText1, selectedText2, selectedText3, frmdt, todt);
                                rptr.DataSource = dt;
                                rptr.DataBind();
                            }
                        }
                    }
                }
             }
        }

        protected void  dropdownWareHouse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void from_TextChanged(object sender, EventArgs e)
        {

        }

        protected void to_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (dropdownFYear.SelectedIndex != -1)
            {
                if (from.Text != Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")) && to.Text != Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")))
                {
                    if ( dropdownWareHouse.SelectedIndex != 0)
                    {
                        if (DropdownDistrict.SelectedIndex != 0)
                        {
                            DateTime s1 = System.Convert.ToDateTime(from.Text);
                            DateTime Date = (s1);
                            String frmdt = Date.ToString("yyyy-MM-dd");
                            DateTime s2 = System.Convert.ToDateTime(to.Text);
                            DateTime date = (s2);
                            String todt = date.ToString("yyyy-MM-dd");
                            DataTable dt = new DataTable();
                            selectedText1 = dropdownFYear.SelectedItem.Text;
                            selectedText2 =  dropdownWareHouse.SelectedValue.ToString();
                            selectedText3 = DropdownDistrict.SelectedValue.ToString();
                            dt = ddo.FilterInvoiceMaster(selectedText1, selectedText2, selectedText3, frmdt, todt);
                            rptr.DataSource = dt;
                            rptr.DataBind();
                        }
                        else
                        {
                            DateTime s1 = System.Convert.ToDateTime(from.Text);
                            DateTime Date = (s1);
                            String frmdt = Date.ToString("yyyy-MM-dd");
                            DateTime s2 = System.Convert.ToDateTime(to.Text);
                            DateTime date = (s2);
                            String todt = date.ToString("yyyy-MM-dd");
                            DataTable dt = new DataTable();
                            selectedText1 = dropdownFYear.SelectedItem.Text;
                            selectedText2 =  dropdownWareHouse.SelectedValue.ToString();
                            dt = ddo.FilterInvoiceMaster(selectedText1, selectedText2, selectedText3, frmdt, todt);
                            rptr.DataSource = dt;
                            rptr.DataBind();
                        }

                    }
                    else
                    {
                        if (DropdownDistrict.SelectedIndex != 0)
                        {
                            DateTime s1 = System.Convert.ToDateTime(from.Text);
                            DateTime Date = (s1);
                            String frmdt = Date.ToString("yyyy-MM-dd");
                            DateTime s2 = System.Convert.ToDateTime(to.Text);
                            DateTime date = (s2);
                            String todt = date.ToString("yyyy-MM-dd");
                            DataTable dt = new DataTable();
                            selectedText1 = dropdownFYear.SelectedItem.Text;
                            selectedText3 = DropdownDistrict.SelectedValue.ToString();
                            dt = ddo.FilterInvoiceMaster(selectedText1, selectedText2, selectedText3, frmdt, todt);
                            rptr.DataSource = dt;
                            rptr.DataBind();
                        }
                        else
                        {
                            DateTime s1 = System.Convert.ToDateTime(from.Text);
                            DateTime Date = (s1);
                            String frmdt = Date.ToString("yyyy-MM-dd");
                            DateTime s2 = System.Convert.ToDateTime(to.Text);
                            DateTime date = (s2);
                            String todt = date.ToString("yyyy-MM-dd");
                            DataTable dt = new DataTable();
                            selectedText1 = dropdownFYear.SelectedItem.Text;
                            dt = ddo.FilterInvoiceMaster(selectedText1, selectedText2, selectedText3, frmdt, todt);
                            rptr.DataSource = dt;
                            rptr.DataBind();
                        }
                    }
                }
            }
        }

        protected void DropdownDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}