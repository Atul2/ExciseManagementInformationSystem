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
    public partial class Dutydetails : System.Web.UI.Page
    {
        #region ClassnObjectVariable
        DispatchDataOperation ddo1 = new DispatchDataOperation();
        DispatchEntities de = new DispatchEntities();
        DispatchRowCountLogic drc = new DispatchRowCountLogic();

        string selectedText1 = "";
        string selectedText2 = "";
        string selectedText3 = "";
        string frmdt = "";
        string to1dt = "";
       
        #endregion
        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BinddropdownFY1();
                BinddropdownWareHouse11();
                BinddropdownDistrictName1();
                from1.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy"));
                to1.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy"));
                from1.Attributes.Add("ReadOnly", "true");
                to1.Attributes.Add("ReadOnly", "true");               
                          
            }
        }
        #endregion
        #region BindDataDropdownFinancialYear
        public void BinddropdownFY1()
        {
            DataTable dt = new DataTable();
            dt = ddo1.GetFilterByFinancialYear();
            dropdownFYear1.DataSource = dt;
            dropdownFYear1.DataTextField = "FinancialYear";
            dropdownFYear1.DataValueField = "yearID";
            dropdownFYear1.DataBind();
        }
        #endregion
        #region BindDatadropdownWareHouse1
        public void BinddropdownWareHouse11()
        {
            DataTable dt = new DataTable();
            dt = ddo1.GetValueWareHouse();
            dropdownWareHouse1.DataSource = dt;
            dropdownWareHouse1.DataTextField = "WareHouseName";
            dropdownWareHouse1.DataValueField = "WareHouseId";
            dropdownWareHouse1.DataBind();
            dropdownWareHouse1.Items.Insert(0, new ListItem { Text = "--Choose-WareHouse--", Value = "0" });
        }
        #endregion
        #region BindDataDropDownDistrictName
        public void BinddropdownDistrictName1()
        {
            DataTable dt = new DataTable();
            dt = ddo1.DistrictName();
            DropdownDistrict.DataSource = dt;
            DropdownDistrict.DataTextField = "DistrictName";
            DropdownDistrict.DataValueField = "DistrictId";
            DropdownDistrict.DataBind();
            DropdownDistrict.Items.Insert(0, new ListItem { Text = "--Choose-District--", Value = "0" });
        }
        #endregion
        protected void dropdownFYear1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (Session["lastSelectedCountryIndex"] != null)
            {
                dropdownFYear1.SelectedIndex = Convert.ToInt32((Session["lastSelectedCountryIndex"]).ToString());
                if (dropdownFYear1.SelectedIndex != -1)
                {
                    selectedText1 = dropdownFYear1.SelectedItem.Text;
                    dt = ddo1.FilterInvoiceMaster(selectedText1, selectedText2, selectedText3, frmdt, to1dt);
                    Label1.Text = dt.Compute("Sum(DutyAmount)", "").ToString();
                    rptr.DataSource = dt;
                    rptr.DataBind();
                    Session["lastSelectedCountryIndex"] = null;
                }
            }
            if (Session["lastSelectedCountryIndex"] == null)
            {

                if (dropdownFYear1.SelectedIndex != -1)
                {
                    if ( dropdownWareHouse1.SelectedIndex != 0)
                    {
                        if (DropdownDistrict.SelectedIndex != 0)
                        {
                            if (from1.Text != Convert.ToString(DateTime.Now.ToString("dd / MM / yyyy")) && to1.Text != Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")))
                            {
                                DateTime s1 = System.Convert.ToDateTime(from1.Text);
                                DateTime Date = (s1);
                                String frmdt = Date.ToString("yyyy-MM-dd");
                                DateTime s2 = System.Convert.ToDateTime(to1.Text);
                                DateTime date = (s2);
                                String to1dt = date.ToString("yyyy-MM-dd");
                                selectedText1 = dropdownFYear1.SelectedItem.Text;
                                selectedText2 =  dropdownWareHouse1.SelectedValue.ToString();
                                selectedText3 = DropdownDistrict.SelectedValue.ToString();
                                dt = ddo1.FilterInvoiceMaster(selectedText1, selectedText2, selectedText3, frmdt, to1dt);
                                Label1.Text = dt.Compute("Sum(DutyAmount)", "").ToString();
                                rptr.DataSource = dt;
                                rptr.DataBind();
                            }
                            else
                            {
                                selectedText1 = dropdownFYear1.SelectedItem.Text;
                                selectedText2 =  dropdownWareHouse1.SelectedValue.ToString();
                                selectedText3 = DropdownDistrict.SelectedValue.ToString();
                                dt = ddo1.FilterInvoiceMaster(selectedText1, selectedText2, selectedText3, frmdt, to1dt);
                                Label1.Text = dt.Compute("Sum(DutyAmount)", "").ToString();
                                rptr.DataSource = dt;
                                rptr.DataBind();
                            }
                        }
                        else
                        {
                            if (from1.Text != Convert.ToString(DateTime.Now.ToString("dd / MM / yyyy")) && to1.Text != Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")))
                            {
                                DateTime s1 = System.Convert.ToDateTime(from1.Text);
                                DateTime Date = (s1);
                                String frmdt = Date.ToString("yyyy-MM-dd");
                                DateTime s2 = System.Convert.ToDateTime(to1.Text);
                                DateTime date = (s2);
                                String to1dt = date.ToString("yyyy-MM-dd");
                                selectedText1 = dropdownFYear1.SelectedItem.Text;
                                selectedText2 =  dropdownWareHouse1.SelectedValue.ToString();
                                dt = ddo1.FilterInvoiceMaster(selectedText1, selectedText2, selectedText3, frmdt, to1dt);
                                Label1.Text = dt.Compute("Sum(DutyAmount)", "").ToString();
                                rptr.DataSource = dt;
                                rptr.DataBind();
                            }
                            else
                            {
                                selectedText1 = dropdownFYear1.SelectedItem.Text;
                                selectedText2 =  dropdownWareHouse1.SelectedValue.ToString();
                                dt = ddo1.FilterInvoiceMaster(selectedText1, selectedText2, selectedText3, frmdt, to1dt);
                                Label1.Text = dt.Compute("Sum(DutyAmount)", "").ToString();
                                rptr.DataSource = dt;
                                rptr.DataBind();
                            }
                        }
                    }
                    else
                    {
                        if (DropdownDistrict.SelectedIndex != 0)
                        {
                            if (from1.Text != Convert.ToString(DateTime.Now.ToString("dd / MM / yyyy")) && to1.Text != Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")))
                            {
                                DateTime s1 = System.Convert.ToDateTime(from1.Text);
                                DateTime Date = (s1);
                                String frmdt = Date.ToString("yyyy-MM-dd");
                                DateTime s2 = System.Convert.ToDateTime(to1.Text);
                                DateTime date = (s2);
                                String to1dt = date.ToString("yyyy-MM-dd");
                                selectedText1 = dropdownFYear1.SelectedItem.Text;
                                selectedText3 = DropdownDistrict.SelectedValue.ToString();
                                dt = ddo1.FilterInvoiceMaster(selectedText1, selectedText2, selectedText3, frmdt, to1dt);
                                Label1.Text = dt.Compute("Sum(DutyAmount)", "").ToString();
                                rptr.DataSource = dt;
                                rptr.DataBind();
                            }
                            else
                            {
                                selectedText1 = dropdownFYear1.SelectedItem.Text;
                                selectedText3 = DropdownDistrict.SelectedValue.ToString();
                                dt = ddo1.FilterInvoiceMaster(selectedText1, selectedText2, selectedText3, frmdt, to1dt);
                                Label1.Text = dt.Compute("Sum(DutyAmount)", "").ToString();
                                rptr.DataSource = dt;
                                rptr.DataBind();
                            }

                        }
                        else
                        {
                            if (from1.Text != Convert.ToString(DateTime.Now.ToString("dd / MM / yyyy")) && to1.Text != Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")))
                            {
                                DateTime s1 = System.Convert.ToDateTime(from1.Text);
                                DateTime Date = (s1);
                                String frmdt = Date.ToString("yyyy-MM-dd");
                                DateTime s2 = System.Convert.ToDateTime(to1.Text);
                                DateTime date = (s2);
                                String to1dt = date.ToString("yyyy-MM-dd");

                                selectedText1 = dropdownFYear1.SelectedItem.Text;
                                dt = ddo1.FilterInvoiceMaster(selectedText1, selectedText2, selectedText3, frmdt, to1dt);
                                Label1.Text = dt.Compute("Sum(DutyAmount)", "").ToString();
                                rptr.DataSource = dt;
                                rptr.DataBind();
                            }
                            else
                            {
                                selectedText1 = dropdownFYear1.SelectedItem.Text;
                                dt = ddo1.FilterInvoiceMaster(selectedText1, selectedText2, selectedText3, frmdt, to1dt);
                                Label1.Text = dt.Compute("Sum(DutyAmount)", "").ToString();
                                rptr.DataSource = dt;
                                rptr.DataBind();
                            }
                        }
                    }
                }
            }
        }

        protected void  dropdownWareHouse1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void from1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void to1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (dropdownFYear1.SelectedIndex != -1)
            {
                if (from1.Text != Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")) && to1.Text != Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")))
                {
                    if ( dropdownWareHouse1.SelectedIndex != 0)
                    {
                        if (DropdownDistrict.SelectedIndex != 0)
                        {
                            DateTime s1 = System.Convert.ToDateTime(from1.Text);
                            DateTime Date = (s1);
                            String frmdt = Date.ToString("yyyy-MM-dd");
                            DateTime s2 = System.Convert.ToDateTime(to1.Text);
                            DateTime date = (s2);
                            String to1dt = date.ToString("yyyy-MM-dd");
                            DataTable dt = new DataTable();
                            selectedText1 = dropdownFYear1.SelectedItem.Text;
                            selectedText2 =  dropdownWareHouse1.SelectedValue.ToString();
                            selectedText3 = DropdownDistrict.SelectedValue.ToString();
                            dt = ddo1.FilterInvoiceMaster(selectedText1, selectedText2, selectedText3, frmdt, to1dt);
                            Label1.Text = dt.Compute("Sum(DutyAmount)", "").ToString();
                            rptr.DataSource = dt;
                            rptr.DataBind();
                        }
                        else
                        {
                            DateTime s1 = System.Convert.ToDateTime(from1.Text);
                            DateTime Date = (s1);
                            String frmdt = Date.ToString("yyyy-MM-dd");
                            DateTime s2 = System.Convert.ToDateTime(to1.Text);
                            DateTime date = (s2);
                            String to1dt = date.ToString("yyyy-MM-dd");
                            DataTable dt = new DataTable();
                            selectedText1 = dropdownFYear1.SelectedItem.Text;
                            selectedText2 =  dropdownWareHouse1.SelectedValue.ToString();
                            dt = ddo1.FilterInvoiceMaster(selectedText1, selectedText2, selectedText3, frmdt, to1dt);
                            Label1.Text = dt.Compute("Sum(DutyAmount)", "").ToString();
                            rptr.DataSource = dt;
                            rptr.DataBind();
                        }

                    }
                    else
                    {
                        if (DropdownDistrict.SelectedIndex != 0)
                        {
                            DateTime s1 = System.Convert.ToDateTime(from1.Text);
                            DateTime Date = (s1);
                            String frmdt = Date.ToString("yyyy-MM-dd");
                            DateTime s2 = System.Convert.ToDateTime(to1.Text);
                            DateTime date = (s2);
                            String to1dt = date.ToString("yyyy-MM-dd");
                            DataTable dt = new DataTable();
                            selectedText1 = dropdownFYear1.SelectedItem.Text;
                            selectedText3 = DropdownDistrict.SelectedValue.ToString();
                            dt = ddo1.FilterInvoiceMaster(selectedText1, selectedText2, selectedText3, frmdt, to1dt);
                            Label1.Text = dt.Compute("Sum(DutyAmount)", "").ToString();
                            rptr.DataSource = dt;
                            rptr.DataBind();
                        }
                        else
                        {
                            DateTime s1 = System.Convert.ToDateTime(from1.Text);
                            DateTime Date = (s1);
                            String frmdt = Date.ToString("yyyy-MM-dd");
                            DateTime s2 = System.Convert.ToDateTime(to1.Text);
                            DateTime date = (s2);
                            String to1dt = date.ToString("yyyy-MM-dd");
                            DataTable dt = new DataTable();
                            selectedText1 = dropdownFYear1.SelectedItem.Text;
                            dt = ddo1.FilterInvoiceMaster(selectedText1, selectedText2, selectedText3, frmdt, to1dt);
                            Label1.Text = dt.Compute("Sum(DutyAmount)", "").ToString();
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