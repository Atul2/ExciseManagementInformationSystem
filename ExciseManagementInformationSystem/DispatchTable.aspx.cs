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
    public partial class DispatchTable : System.Web.UI.Page
    {
        #region ClassnObjectVariable
        DispatchDataOperation ddo = new DispatchDataOperation();
        DispatchEntities de = new DispatchEntities();
        DispatchRowCountLogic drc = new DispatchRowCountLogic();

        string selectedText1 = "";
        string selectedText2 = "";
        string selectedText3 = "";
        #endregion

        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BinddropdownFY();
                BinddropdownSupplier();
                BinddropdownWareHouse();
                Bindrpt();
                from.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy"));
                to.Text= Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy"));
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
        #region BindReapterTable
        public void Bindrpt()
        {
            DataTable dt = new DataTable();
            dt = ddo.CountRow();
            rptr.DataSource = dt;
            rptr.DataBind();
        }

        #endregion
        #region DropdownFinancialYear
        protected void dropdownFYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["lastSelectedCountryIndex"] != null)
            {
                dropdownFYear.SelectedIndex = Convert.ToInt32((Session["lastSelectedCountryIndex"]).ToString());
                if (dropdownFYear.SelectedIndex != -1)
                {
                    selectedText1 = dropdownFYear.SelectedItem.Text;
                    DataTable dt = new DataTable();
                    dt = ddo.FilterFY(selectedText1, selectedText2, selectedText3);
                    rptr.DataSource = dt;
                    rptr.DataBind();
                    Session["lastSelectedCountryIndex"] = null;
                }
            }
            if (Session["lastSelectedCountryIndex"] == null)
            {
                if (dropdownFYear.SelectedIndex != -1)
                {
                    DataTable dt = new DataTable();
                    if (dropdownSupplier.SelectedIndex != 0)
                    {
                        if (dropdownWareHouse.SelectedIndex != 0)
                        {
                            selectedText1 = dropdownFYear.SelectedItem.Text;
                            selectedText2 = dropdownSupplier.SelectedItem.Text;
                            selectedText3 = dropdownWareHouse.SelectedItem.Text;
                            dt = ddo.FilterSupplier(selectedText1, selectedText2, selectedText3);
                            rptr.DataSource = dt;
                            rptr.DataBind();
                        }
                        else
                        {
                            selectedText1 = dropdownFYear.SelectedItem.Text;
                            selectedText2 = dropdownSupplier.SelectedItem.Text;
                            dt = ddo.FilterSupplier(selectedText1, selectedText2, selectedText3);
                            rptr.DataSource = dt;
                            rptr.DataBind();
                        }
                    }
                    else
                    {
                        if (dropdownWareHouse.SelectedIndex != 0)
                        {
                            selectedText1 = dropdownFYear.SelectedItem.Text;
                            selectedText3 = dropdownWareHouse.SelectedItem.Text;
                            dt = ddo.FilterFY(selectedText1, selectedText2, selectedText3);
                            rptr.DataSource = dt;
                            rptr.DataBind();
                        }
                        else
                        {
                            selectedText1 = dropdownFYear.SelectedItem.Text;
                            dt = ddo.FilterFY(selectedText1, selectedText2, selectedText3);
                            rptr.DataSource = dt;
                            rptr.DataBind();
                        }
                    }
                }
            }
        }
        #endregion
        #region DropDownSupplier
        protected void dropdownSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropdownSupplier.SelectedIndex == 0)
            {
                if (dropdownFYear.SelectedIndex != 0)
                {
                    if (dropdownWareHouse.SelectedIndex != 0)
                    {
                        selectedText1 = dropdownFYear.SelectedItem.Text;
                        selectedText3 = dropdownWareHouse.SelectedItem.Text;
                        DataTable dt = new DataTable();
                        dt = ddo.FilterWareHouse(selectedText1, selectedText2, selectedText3);
                        rptr.DataSource = dt;
                        rptr.DataBind();
                    }
                    else
                    {
                        selectedText1 = dropdownFYear.SelectedItem.Text;
                        DataTable dt = new DataTable();
                        dt = ddo.FilterSupplier(selectedText1, selectedText2, selectedText3);
                        rptr.DataSource = dt;
                        rptr.DataBind();
                    }
                }

            }
            else
            {
                if (dropdownFYear.SelectedIndex != 0)
                {
                    if (dropdownWareHouse.SelectedIndex != 0)
                    {
                        selectedText1 = dropdownFYear.SelectedItem.Text;
                        selectedText2 = dropdownSupplier.SelectedItem.Text;
                        selectedText3 = dropdownWareHouse.SelectedItem.Text;
                        DataTable dt = new DataTable();
                        dt = ddo.FilterSupplier(selectedText1, selectedText2, selectedText3);
                        rptr.DataSource = dt;
                        rptr.DataBind();
                    }
                    else
                    {
                        selectedText1 = dropdownFYear.SelectedItem.Text;
                        selectedText2 = dropdownSupplier.SelectedItem.Text;
                        DataTable dt = new DataTable();
                        dt = ddo.FilterSupplier(selectedText1, selectedText2, selectedText3);
                        rptr.DataSource = dt;
                        rptr.DataBind();
                    }
                }
            }
        }
        #endregion
        #region DropdownWareHouse
        protected void dropdownWareHouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropdownWareHouse.SelectedIndex == 0)
            {
                if (dropdownFYear.SelectedIndex != 0)
                {
                    if (dropdownSupplier.SelectedIndex != 0)
                    {
                        selectedText1 = dropdownFYear.SelectedItem.Text;
                        selectedText2 = dropdownSupplier.SelectedItem.Text;
                        DataTable dt = new DataTable();
                        dt = ddo.FilterWareHouse(selectedText1, selectedText2, selectedText3);
                        rptr.DataSource = dt;
                        rptr.DataBind();
                    }
                    else
                    {
                        selectedText1 = dropdownFYear.SelectedItem.Text;
                        DataTable dt = new DataTable();
                        dt = ddo.FilterWareHouse(selectedText1, selectedText2, selectedText3);
                        rptr.DataSource = dt;
                        rptr.DataBind();
                    }

                }
            }
            else
            {
                if (dropdownFYear.SelectedIndex != 0)
                {
                    if (dropdownSupplier.SelectedIndex != 0)
                    {
                        selectedText1 = dropdownFYear.SelectedItem.Text;
                        selectedText2 = dropdownSupplier.SelectedItem.Text;
                        selectedText3 = dropdownWareHouse.SelectedItem.Text;
                        DataTable dt = new DataTable();
                        dt = ddo.FilterSupplier(selectedText1, selectedText2, selectedText3);
                        rptr.DataSource = dt;
                        rptr.DataBind();
                    }
                    else
                    {
                        selectedText1 = dropdownFYear.SelectedItem.Text;
                        selectedText3 = dropdownWareHouse.SelectedItem.Text;
                        DataTable dt = new DataTable();
                        dt = ddo.FilterWareHouse(selectedText1, selectedText2, selectedText3);
                        rptr.DataSource = dt;
                        rptr.DataBind();
                    }
                }
            }
        }
        #endregion
        #region BlankDefinitionFromTextBox
        protected void from_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #region BlankDefinitionToTextBox
        protected void to_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #region SearchButtonForBetweenDates
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (dropdownFYear.SelectedIndex != -1 || dropdownSupplier.SelectedIndex != 0 || dropdownWareHouse.SelectedIndex != 0)
            {
                if (from.Text != "" && to.Text != "")
                {
                    if (dropdownSupplier.SelectedIndex != 0 || dropdownWareHouse.SelectedIndex != 0)
                    {
                        if (dropdownWareHouse.SelectedIndex != 0 || dropdownSupplier.SelectedIndex != 0)
                        {

                          
                            DateTime s1 = System.Convert.ToDateTime(from.Text);
                           
                            DateTime Date = (s1);
                            String frmdt = Date.ToString("yyyy-MM-dd");
                           
                            DateTime s2 = System.Convert.ToDateTime(to.Text);
                           
                            DateTime date = (s2);
                            String todt = date.ToString("yyyy-MM-dd");

                            DataTable dt = new DataTable();
                            dt = ddo.BetweenDates(frmdt, todt);


                            rptr.DataSource = dt;
                            rptr.DataBind();
                        }
                        else
                        {
                            DateTime s1 = System.Convert.ToDateTime(from.Text);
                            from.Attributes.Add("ReadOnly", "true");
                            DateTime Date = (s1);
                            String frmdt = Date.ToString("yyyy-MM-dd");

                            DateTime s2 = System.Convert.ToDateTime(to.Text);
                            to.Attributes.Add("ReadOnly", "true");
                            DateTime date = (s2);
                            String todt = date.ToString("yyyy-MM-dd");

                            DataTable dt = new DataTable();
                            dt = ddo.BetweenDates(frmdt, todt);


                            rptr.DataSource = dt;
                            rptr.DataBind();
                        }

                    }
                    else
                    {
                        DateTime s1 = System.Convert.ToDateTime(from.Text);
                        from.Attributes.Add("ReadOnly", "true");
                        DateTime Date = (s1);
                        String frmdt = Date.ToString("yyyy-MM-dd");

                        DateTime s2 = System.Convert.ToDateTime(to.Text);
                        to.Attributes.Add("ReadOnly", "true");
                        DateTime date = (s2);
                        String todt = date.ToString("yyyy-MM-dd");

                        DataTable dt = new DataTable();
                        dt = ddo.BetweenDates(frmdt, todt);


                        rptr.DataSource = dt;
                        rptr.DataBind();
                    }

                }
            }
        }
        #endregion
    }
}