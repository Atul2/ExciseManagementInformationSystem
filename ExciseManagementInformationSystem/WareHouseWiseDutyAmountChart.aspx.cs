using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataAccess;
using System.Web.Services;

namespace ExciseManagementInformationSystem
{
    public partial class WareHouseWiseDutyAmountChart : System.Web.UI.Page
    {
        #region Data_Members_String_Variables
        DispatchDataOperation ddo = new DispatchDataOperation();
        string selectedText1 = "";
        string selectedText2 = "";
        string selectedText3 = "";
        string frmdt = "";
        string todt = "";
        #endregion
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BinddropdownFY();
                BinddropdownSupplier();
                BinddropdownWareHouse();
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
        #region BindDataDropDownSupplier
        public void BinddropdownSupplier()
        {
            DataTable dt = new DataTable();
            dt = ddo.GetFilterBySupplierDetail();
            dropdownSupplier.DataSource = dt;
            dropdownSupplier.DataTextField = "SupplierName";
            dropdownSupplier.DataValueField = "SupplierId";
            dropdownSupplier.DataBind();
            dropdownSupplier.Items.Insert(0, new ListItem { Text = "--Choose-Supplier--", Value = " " });
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
            dropdownWareHouse.Items.Insert(0, new ListItem { Text = "--Choose-WareHouse--", Value = " " });
        }
        #endregion
        #region GraphWareHouseWiseDutyAmount
        [WebMethod]
        public static List<GraphData> GraphWDA(string selectedText1, string selectedText2, string selectedText3, string frmdt, string todt)
        {
            DispatchDataOperation ddo = new DispatchDataOperation();
            DataTable dt = new DataTable();
            dt = ddo.GraphWareHouseDutyAmount(selectedText1, selectedText2, selectedText3, frmdt, todt);
            List<GraphData> chartData = new List<GraphData>();
            foreach (DataRow dr in dt.Rows)
            {
                chartData.Add(new GraphData
                {
                    w = Convert.ToString(dr["WareHouseName"]).Remove(10),
                    x = (Convert.ToInt32(dr["total_dutyAmount"]))
                });
            }
            return chartData;
        }
        #endregion
        #region GraphData
        public class GraphData
        {
            public string w { get; set; }
            public int x { get; set; }
        }
        #endregion
        #region DropdownFilterAllGraphs
        protected void dropdownFYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["lastSelectedCountryIndex"] != null)
            {
                dropdownFYear.SelectedIndex = Convert.ToInt32((Session["lastSelectedCountryIndex"]).ToString());
                if (dropdownFYear.SelectedIndex != -1)
                {
                    selectedText1 = dropdownFYear.SelectedItem.Text;
                    List<GraphData> obj = new List<GraphData>();
                    obj = GraphWDA(selectedText1, selectedText2, selectedText3, frmdt, todt);
                   
                    Session["lastSelectedCountryIndex"] = null;
                }
            }

            if (Session["lastSelectedCountryIndex"] == null)
            {
                if (dropdownFYear.SelectedIndex != -1)
                {
                    if (dropdownWareHouse.SelectedIndex != 0)
                    {
                        if (dropdownSupplier.SelectedIndex != 0)
                        {
                            if (from.Text != Convert.ToString(DateTime.Now.ToString("dd / MM / yyyy")) && to.Text != Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")))
                            {
                                DateTime s1 = System.Convert.ToDateTime(from.Text);
                                DateTime Date = (s1);
                                frmdt = Date.ToString("yyyy-MM-dd");
                                DateTime s2 = System.Convert.ToDateTime(to.Text);
                                DateTime date = (s2);
                                todt = date.ToString("yyyy-MM-dd");
                                selectedText1 = dropdownFYear.SelectedItem.Text;
                                selectedText2 = dropdownSupplier.SelectedValue.ToString();
                                selectedText3 = dropdownWareHouse.SelectedValue.ToString();
                                List<GraphData> obj = new List<GraphData>();
                                obj = GraphWDA(selectedText1, selectedText2, selectedText3, frmdt, todt);
                             
                            }
                            else
                            {
                                selectedText1 = dropdownFYear.SelectedItem.Text;
                                selectedText2 = dropdownWareHouse.SelectedValue.ToString();
                                selectedText3 = dropdownSupplier.SelectedValue.ToString();
                                List<GraphData> obj = new List<GraphData>();
                                obj = GraphWDA(selectedText1, selectedText2, selectedText3, frmdt, todt);
                               
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
                                selectedText2 = dropdownWareHouse.SelectedValue.ToString();
                                List<GraphData> obj = new List<GraphData>();
                                obj = GraphWDA(selectedText1, selectedText2, selectedText3, frmdt, todt);
                                
                            }
                            else
                            {
                                selectedText1 = dropdownFYear.SelectedItem.Text;
                                selectedText2 = dropdownWareHouse.SelectedValue.ToString();
                                List<GraphData> obj = new List<GraphData>();
                                obj = GraphWDA(selectedText1, selectedText2, selectedText3, frmdt, todt);
                              
                            }
                        }
                    }
                    else
                    {
                        if (dropdownSupplier.SelectedIndex != 0)
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
                                selectedText3 = dropdownSupplier.SelectedValue.ToString();
                                List<GraphData> obj = new List<GraphData>();
                                obj = GraphWDA(selectedText1, selectedText2, selectedText3, frmdt, todt);
                                
                            }
                            else
                            {
                                selectedText1 = dropdownFYear.SelectedItem.Text;
                                selectedText3 = dropdownSupplier.SelectedValue.ToString();
                                List<GraphData> obj = new List<GraphData>();
                                obj = GraphWDA(selectedText1, selectedText2, selectedText3, frmdt, todt);
                               
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
                                List<GraphData> obj = new List<GraphData>();
                                obj = GraphWDA(selectedText1, selectedText2, selectedText3, frmdt, todt);
                               
                            }
                            else
                            {
                                selectedText1 = dropdownFYear.SelectedItem.Text;
                                List<GraphData> obj = new List<GraphData>();
                                obj = GraphWDA(selectedText1, selectedText2, selectedText3, frmdt, todt);
                                
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region BlankDropdownSupplier
        protected void dropdownSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #region BlankDropdownWareHouse
        protected void dropdownWareHouse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #region BLank_from_textbox
        protected void from_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #region Blank_to_textbox
        protected void to_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #region Between_Dates_Search_Button_Click
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (dropdownFYear.SelectedIndex != -1)
            {
                if (from.Text != Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")) && to.Text != Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")))
                {
                    if (dropdownWareHouse.SelectedIndex != 0)
                    {
                        if (dropdownSupplier.SelectedIndex != 0)
                        {
                            DateTime s1 = System.Convert.ToDateTime(from.Text);
                            DateTime Date = (s1);
                            String frmdt = Date.ToString("yyyy-MM-dd");
                            DateTime s2 = System.Convert.ToDateTime(to.Text);
                            DateTime date = (s2);
                            String todt = date.ToString("yyyy-MM-dd");
                            DataTable dt = new DataTable();
                            selectedText1 = dropdownFYear.SelectedItem.Text;
                            selectedText2 = dropdownWareHouse.SelectedValue.ToString();
                            selectedText3 = dropdownSupplier.SelectedValue.ToString();
                            List<GraphData> obj = new List<GraphData>();
                            obj = GraphWDA(selectedText1, selectedText2, selectedText3, frmdt, todt);
                           
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
                            selectedText2 = dropdownWareHouse.SelectedValue.ToString();
                            List<GraphData> obj = new List<GraphData>();
                            obj = GraphWDA(selectedText1, selectedText2, selectedText3, frmdt, todt);
                           
                        }

                    }
                    else
                    {
                        if (dropdownSupplier.SelectedIndex != 0)
                        {
                            DateTime s1 = System.Convert.ToDateTime(from.Text);
                            DateTime Date = (s1);
                            String frmdt = Date.ToString("yyyy-MM-dd");
                            DateTime s2 = System.Convert.ToDateTime(to.Text);
                            DateTime date = (s2);
                            String todt = date.ToString("yyyy-MM-dd");
                            DataTable dt = new DataTable();
                            selectedText1 = dropdownFYear.SelectedItem.Text;
                            selectedText3 = dropdownSupplier.SelectedValue.ToString();
                            List<GraphData> obj = new List<GraphData>();
                            obj = GraphWDA(selectedText1, selectedText2, selectedText3, frmdt, todt);
                            
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
                            List<GraphData> obj = new List<GraphData>();
                            obj = GraphWDA(selectedText1, selectedText2, selectedText3, frmdt, todt);
                            
                        }
                    }
                }
            }
        }
        #endregion
    }
}