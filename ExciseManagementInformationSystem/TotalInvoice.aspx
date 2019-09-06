<%@ Page Title="" Language="C#" MasterPageFile="~/ExciseMIS.Master" AutoEventWireup="true" CodeBehind="TotalInvoice.aspx.cs" Inherits="ExciseManagementInformationSystem.TotalInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <section class="content">
         <div class="row">
            <div class="col-lg-3 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-aqua">
                <div class="inner">
                  <h4><b><asp:Label ID="Label1" runat="server" /></b></h4>

                  <p>Total Invoice Current Financial Yr</p>
                </div>
                <div class="icon">
                  <i class="ion-arrow-graph-up-right"></i>
                </div>
        
              </div>
            </div>
            <div class="col-lg-3 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-green">
                <div class="inner">
                  <h4><b><asp:Label ID="Label2" runat="server" /></b></h4>

                  <p>Total Invoice Current Month</p>
                </div>
                <div class="icon">
                  <i class="ion-arrow-graph-up-right"></i>
                </div>
            
              </div>
            </div>
            <div class="col-lg-3 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-yellow">
                <div class="inner">
                  <h4><b><asp:Label ID="Label4" runat="server" /></b></h4>

                  <p>Total Duty Current Financial Year</p>
                </div>
                <div class="icon">
                  <i class="ion-arrow-graph-up-right"></i>
                </div>
            
              </div>
            </div>
            <div class="col-lg-3 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-red">
                <div class="inner">
                  <h4><b><asp:Label ID="Label3" runat="server" /></b></h4>

                  <p>Total Duty Current Month</p>
                </div>
                <div class="icon">
                  <i class="ion-arrow-graph-up-right"></i>
                </div>
            
              </div>
            </div>
          </div>
         <div class="row">
              <form runat="server">
            <div class="col-lg-3 col-md-6">
                <div class="form-group">
                    <label for="exampleFormControlSelect1">Financial Year</label>
                    <asp:DropDownList class="form-control" ID="dropdownFYear" runat="server" OnLoad="dropdownFYear_SelectedIndexChanged" OnSelectedIndexChanged="dropdownFYear_SelectedIndexChanged" AppendDataBoundItems="True" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-3 col-md-6">
                <div class="form-group">
                    <label for="exampleFormControlSelect1">Supplier</label>
                    <asp:DropDownList class="form-control" ID="dropdownSupplier" runat="server" OnSelectedIndexChanged="dropdownSupplier_SelectedIndexChanged" AppendDataBoundItems="True" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-3 col-md-6">
                <div class="form-group">
                    <label for="exampleFormControlSelect1">WareHouse</label>
                    <asp:DropDownList class="form-control" ID="dropdownWareHouse" runat="server" OnSelectedIndexChanged="dropdownWareHouse_SelectedIndexChanged" AppendDataBoundItems="True" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-3 col-md-6">
                <div class="form-group">
                    <label for="exampleFormControlSelect1">District</label>
                    <asp:DropDownList class="form-control" ID="DropdownDistrict" runat="server" onload="DropdownDistrict_SelectedIndexChanged"  AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="DropdownDistrict_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
             </form>
         </div>
        <div class="row">
            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">WareHouse Wise Invoice Counting Table</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class= "panel-body">
                          <div class="table-responsive">
                        <asp:Repeater ID="rptr" runat="server">
                            <HeaderTemplate>

                                <table id="example2" class="table table-striped table-bordered table-sm">
                                    <thead>
                                        <tr>
                                            <th>WareHouseName</th>
                                            <th colspan="2">Total Invoice</th>
                                            <th colspan="2">Supplier No. 1</th>
                                            <th colspan="2">Supplier No. 2</th>
                                            <th colspan="2">Supplier No. 3</th>
                                        </tr>
                                        <tr>
                                            <th></th>
                                            <th>Total Year</th>
                                            <th>Total Month</th>
                                            <th>Year</th>
                                            <th>Month</th>
                                            <th>Year</th>
                                            <th>Month</th>
                                            <th>Year</th>
                                            <th>Month</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("WareHouseName") %></td>
                                    <td><%# Eval("TotalInvoiceCurrYr") %></td>
                                    <td><%# Eval("TotalInvoceCurrmt") %></td>
                                    <td><%# Eval("Spplier1CurrYr") %></td>
                                    <td><%# Eval("Spplier1Currmth") %></td>
                                    <td><%# Eval("Spplier2CurrYr") %></td>
                                    <td><%# Eval("Spplier2Currmth") %></td>
                                    <td><%# Eval("Spplier3CurrYr") %></td>
                                    <td><%# Eval("Spplier3Currmth") %></td>

                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                                     <tfoot>
                                         <itemtemplate>
                                    <tr>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                    </tr>
                                </itemtemplate>
                                     </tfoot>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                              </div>
                    </div>

                    <!-- /.box-body -->
                </div>
            </div>
             <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">District Wise Invoice Counting Table</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class= "panel-body">
                          <div class="table-responsive">
                        <asp:Repeater ID="rptr1" runat="server">
                            <HeaderTemplate>

                                <table id="example3" class="table right  table-striped table-bordered table-sm">
                                    <thead>
                                        <tr>
                                            <th>DistrictName</th>
                                            <th colspan="2">Total Invoice</th>
                                            <th colspan="2">Supplier No. 1</th>
                                            <th colspan="2">Supplier No. 2</th>
                                            <th colspan="2">Supplier No. 3</th>
                                        </tr>
                                        <tr>
                                            <th></th>
                                            <th>Total Year</th>
                                            <th>Total Month</th>
                                            <th>Year</th>
                                            <th>Month</th>
                                            <th>Year</th>
                                            <th>Month</th>
                                            <th>Year</th>
                                            <th>Month</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("DistrictName") %></td>
                                    <td><%# Eval("TotalInvoiceCurrYr") %></td>
                                    <td><%# Eval("TotalInvoceCurrmt") %></td>
                                    <td><%# Eval("Spplier1CurrYr") %></td>
                                    <td><%# Eval("Spplier1Currmth") %></td>
                                    <td><%# Eval("Spplier2CurrYr") %></td>
                                    <td><%# Eval("Spplier2Currmth") %></td>
                                    <td><%# Eval("Spplier3CurrYr") %></td>
                                    <td><%# Eval("Spplier3Currmth") %></td>

                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                                     <tfoot>
                                         <itemtemplate>
                                    <tr>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                    </tr>
                                </itemtemplate>
                                     </tfoot>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                              </div>
                    </div>

                    <!-- /.box-body -->
                </div>
            </div>
        </div>
        <div class="row">
             <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Warehouse Wise Duty Payment Table</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class= "panel-body">
                          <div class="table-responsive">
                        <asp:Repeater ID="rptr2" runat="server">
                            <HeaderTemplate>

                                <table id="example4" class="table table-striped table-bordered table-sm">
                                    <thead>
                                        <tr>
                                            <th>WareHouseName</th>
                                            <th colspan="2">Total Invoice</th>
                                            <th colspan="2">Supplier No. 1</th>
                                            <th colspan="2">Supplier No. 2</th>
                                            <th colspan="2">Supplier No. 3</th>
                                        </tr>
                                        <tr>
                                            <th></th>
                                            <th>Total Year</th>
                                            <th>Total Month</th>
                                            <th>Year</th>
                                            <th>Month</th>
                                            <th>Year</th>
                                            <th>Month</th>
                                            <th>Year</th>
                                            <th>Month</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("WareHouseName") %></td>
                                    <td><%# Eval("TotalDutyAmtCurrYr") %></td>
                                    <td><%# Eval("TotalDutyAmtCurrmt") %></td>
                                    <td><%# Eval("Spplier1CurrYr") %></td>
                                    <td><%# Eval("Spplier1Currmth") %></td>
                                    <td><%# Eval("Spplier2CurrYr") %></td>
                                    <td><%# Eval("Spplier2Currmth") %></td>
                                    <td><%# Eval("Spplier3CurrYr") %></td>
                                    <td><%# Eval("Spplier3Currmth") %></td>

                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                                     <tfoot>
                                         <itemtemplate>
                                    <tr>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                    </tr>
                                </itemtemplate>
                                     </tfoot>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                              </div>
                    </div>

                    <!-- /.box-body -->
                </div>
            </div>
             <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">District Wise Duty Payment Table</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class= "panel-body">
                          <div class="table-responsive">
                        <asp:Repeater ID="rptr3" runat="server">
                            <HeaderTemplate>

                                <table id="example5" class="table table-striped table-bordered table-sm">
                                    <thead>
                                        <tr>
                                            <th>DistrictName</th>
                                            <th colspan="2">Total Invoice</th>
                                            <th colspan="2">Supplier No. 1</th>
                                            <th colspan="2">Supplier No. 2</th>
                                            <th colspan="2">Supplier No. 3</th>
                                        </tr>
                                        <tr>
                                            <th></th>
                                            <th>Total Year</th>
                                            <th>Total Month</th>
                                            <th>Year</th>
                                            <th>Month</th>
                                            <th>Year</th>
                                            <th>Month</th>
                                            <th>Year</th>
                                            <th>Month</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("DistrictName") %></td>
                                    <td><%# Eval("TotalDutyAmtCurrYr") %></td>
                                    <td><%# Eval("TotalDutyAmtCurrmt") %></td>
                                    <td><%# Eval("Spplier1CurrYr") %></td>
                                    <td><%# Eval("Spplier1Currmth") %></td>
                                    <td><%# Eval("Spplier2CurrYr") %></td>
                                    <td><%# Eval("Spplier2Currmth") %></td>
                                    <td><%# Eval("Spplier3CurrYr") %></td>
                                    <td><%# Eval("Spplier3Currmth") %></td>

                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                                     <tfoot>
                                         <itemtemplate>
                                    <tr>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                    </tr>
                                </itemtemplate>
                                     </tfoot>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                              </div>
                    </div>

                    <!-- /.box-body -->
                </div>
            </div>
        </div>

    </section>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#example2').DataTable({
               
                "paging": false,
               "searching":false,
                "footerCallback": function (row, data, start, end, display) {
                    var api = this.api(), data;

                    // converting to interger to find total
                    var intVal = function (i) {
                        return typeof i === 'string' ?
                            i.replace(/[\$,]/g, '') * 1 :
                            typeof i === 'number' ?
                            i : 0;
                    };

                    // computing column Total of the complete result 
                    var TotalCurrentYearInvoice = api
                        .column(1)
                        .data()
                        .reduce(function (a, b) {
                            return intVal(a) + intVal(b);
                        }, 0);

                    var TotalCurrentMonthInvoice = api
                            .column(2)
                            .data()
                            .reduce(function (a, b) {
                                return intVal(a) + intVal(b);
                            }, 0);

                    var TotalSupplier1currntYr = api
                        .column(3)
                        .data()
                        .reduce(function (a, b) {
                            return intVal(a) + intVal(b);
                        }, 0);

                    var TotalSupplier1currntMnth = api
                           .column(4)
                           .data()
                           .reduce(function (a, b) {
                               return intVal(a) + intVal(b);
                           }, 0);

                    var TotalSupplier2currntYr = api
                           .column(5)
                           .data()
                           .reduce(function (a, b) {
                               return intVal(a) + intVal(b);
                           }, 0);

                    var TotalSupplier2currntMnth = api
                            .column(6)
                            .data()
                            .reduce(function (a, b) {
                                return intVal(a) + intVal(b);
                            }, 0);


                    var TotalSupplier3currntYr = api
                            .column(7)
                            .data()
                            .reduce(function (a, b) {
                                return intVal(a) + intVal(b);
                            }, 0);


                    var TotalSupplier3currntMnth = api
                           .column(8)
                           .data()
                           .reduce(function (a, b) {
                               return intVal(a) + intVal(b);
                           }, 0);
                    // Update footer by showing the total with the reference of the column index 
                    $(api.column(0).footer()).html('Grand Total');
                    $(api.column(1).footer()).html(TotalCurrentYearInvoice);
                    $(api.column(2).footer()).html(TotalCurrentMonthInvoice);
                    $(api.column(3).footer()).html(TotalSupplier1currntYr);
                    $(api.column(4).footer()).html(TotalSupplier1currntMnth);
                    $(api.column(5).footer()).html(TotalSupplier2currntYr);
                    $(api.column(6).footer()).html(TotalSupplier2currntMnth);
                    $(api.column(7).footer()).html(TotalSupplier3currntYr);
                    $(api.column(8).footer()).html(TotalSupplier3currntMnth);
                },
                "scrollX": true,
                "scrollY": '38vh',
                "scrollCollapse": true,
                "scroller": true

            });
            $('#example3').DataTable({
          
                "scrollX": true,
                "scrollY": '38vh',
                "scrollCollapse": true,
                "scroller": true,
                "searching": false,
                "paging": false,
                "footerCallback": function (row, data, start, end, display) {
                    var api = this.api(), data;

                    // converting to interger to find total
                    var intVal = function (i) {
                        return typeof i === 'string' ?
                            i.replace(/[\$,]/g, '') * 1 :
                            typeof i === 'number' ?
                            i : 0;
                    };

                    // computing column Total of the complete result 
                    var TotalCurrentYearInvoice = api
                        .column(1)
                        .data()
                        .reduce(function (a, b) {
                            return intVal(a) + intVal(b);
                        }, 0);

                    var TotalCurrentMonthInvoice = api
                            .column(2)
                            .data()
                            .reduce(function (a, b) {
                                return intVal(a) + intVal(b);
                            }, 0);

                    var TotalSupplier1currntYr = api
                        .column(3)
                        .data()
                        .reduce(function (a, b) {
                            return intVal(a) + intVal(b);
                        }, 0);

                    var TotalSupplier1currntMnth = api
                           .column(4)
                           .data()
                           .reduce(function (a, b) {
                               return intVal(a) + intVal(b);
                           }, 0);

                    var TotalSupplier2currntYr = api
                           .column(5)
                           .data()
                           .reduce(function (a, b) {
                               return intVal(a) + intVal(b);
                           }, 0);

                    var TotalSupplier2currntMnth = api
                            .column(6)
                            .data()
                            .reduce(function (a, b) {
                                return intVal(a) + intVal(b);
                            }, 0);


                    var TotalSupplier3currntYr = api
                            .column(7)
                            .data()
                            .reduce(function (a, b) {
                                return intVal(a) + intVal(b);
                            }, 0);


                    var TotalSupplier3currntMnth = api
                           .column(8)
                           .data()
                           .reduce(function (a, b) {
                               return intVal(a) + intVal(b);
                           }, 0);
                    // Update footer by showing the total with the reference of the column index 
                    $(api.column(0).footer()).html('Grand Total');
                    $(api.column(1).footer()).html(TotalCurrentYearInvoice);
                    $(api.column(2).footer()).html(TotalCurrentMonthInvoice);
                    $(api.column(3).footer()).html(TotalSupplier1currntYr);
                    $(api.column(4).footer()).html(TotalSupplier1currntMnth);
                    $(api.column(5).footer()).html(TotalSupplier2currntYr);
                    $(api.column(6).footer()).html(TotalSupplier2currntMnth);
                    $(api.column(7).footer()).html(TotalSupplier3currntYr);
                    $(api.column(8).footer()).html(TotalSupplier3currntMnth);
                }


            });
            $('#example4').DataTable({
               
                "scrollX": true,
                "scrollY": '38vh',
                "scrollCollapse": true,
                "scroller": true,
                "searching": false,
                "paging": false,
                "footerCallback": function (row, data, start, end, display) {
                    var api = this.api(), data;

                    // converting to interger to find total
                    var intVal = function (i) {
                        return typeof i === 'string' ?
                            i.replace(/[\$,]/g, '') * 1 :
                            typeof i === 'number' ?
                            i : 0;
                    };

                    // computing column Total of the complete result 
                    var TotalCurrentYearInvoice = api
                        .column(1)
                        .data()
                        .reduce(function (a, b) {
                            return intVal(a) + intVal(b);
                        }, 0);

                    var TotalCurrentMonthInvoice = api
                            .column(2)
                            .data()
                            .reduce(function (a, b) {
                                return intVal(a) + intVal(b);
                            }, 0);

                    var TotalSupplier1currntYr = api
                        .column(3)
                        .data()
                        .reduce(function (a, b) {
                            return intVal(a) + intVal(b);
                        }, 0);

                    var TotalSupplier1currntMnth = api
                           .column(4)
                           .data()
                           .reduce(function (a, b) {
                               return intVal(a) + intVal(b);
                           }, 0);

                    var TotalSupplier2currntYr = api
                           .column(5)
                           .data()
                           .reduce(function (a, b) {
                               return intVal(a) + intVal(b);
                           }, 0);

                    var TotalSupplier2currntMnth = api
                            .column(6)
                            .data()
                            .reduce(function (a, b) {
                                return intVal(a) + intVal(b);
                            }, 0);


                    var TotalSupplier3currntYr = api
                            .column(7)
                            .data()
                            .reduce(function (a, b) {
                                return intVal(a) + intVal(b);
                            }, 0);


                    var TotalSupplier3currntMnth = api
                           .column(8)
                           .data()
                           .reduce(function (a, b) {
                               return intVal(a) + intVal(b);
                           }, 0);
                    // Update footer by showing the total with the reference of the column index 
                    $(api.column(0).footer()).html('Grand Total');
                    $(api.column(1).footer()).html(TotalCurrentYearInvoice);
                    $(api.column(2).footer()).html(TotalCurrentMonthInvoice);
                    $(api.column(3).footer()).html(TotalSupplier1currntYr);
                    $(api.column(4).footer()).html(TotalSupplier1currntMnth);
                    $(api.column(5).footer()).html(TotalSupplier2currntYr);
                    $(api.column(6).footer()).html(TotalSupplier2currntMnth);
                    $(api.column(7).footer()).html(TotalSupplier3currntYr);
                    $(api.column(8).footer()).html(TotalSupplier3currntMnth);
                }


            });

            $('#example5').DataTable({

               
                "scrollX": true,
                "scrollY": '38vh',
                "scrollCollapse": true,
                "scroller": true,
                "searching": false,
                "paging": false,
                "footerCallback": function (row, data, start, end, display) {
                    var api = this.api(), data;

                    // converting to interger to find total
                    var intVal = function (i) {
                        return typeof i === 'string' ?
                            i.replace(/[\$,]/g, '') * 1 :
                            typeof i === 'number' ?
                            i : 0;
                    };

                    // computing column Total of the complete result 
                    var TotalCurrentYearInvoice = api
                        .column(1)
                        .data()
                        .reduce(function (a, b) {
                            return intVal(a) + intVal(b);
                        }, 0);

                    var TotalCurrentMonthInvoice = api
                            .column(2)
                            .data()
                            .reduce(function (a, b) {
                                return intVal(a) + intVal(b);
                            }, 0);

                    var TotalSupplier1currntYr = api
                        .column(3)
                        .data()
                        .reduce(function (a, b) {
                            return intVal(a) + intVal(b);
                        }, 0);

                    var TotalSupplier1currntMnth = api
                           .column(4)
                           .data()
                           .reduce(function (a, b) {
                               return intVal(a) + intVal(b);
                           }, 0);

                    var TotalSupplier2currntYr = api
                           .column(5)
                           .data()
                           .reduce(function (a, b) {
                               return intVal(a) + intVal(b);
                           }, 0);

                    var TotalSupplier2currntMnth = api
                            .column(6)
                            .data()
                            .reduce(function (a, b) {
                                return intVal(a) + intVal(b);
                            }, 0);


                    var TotalSupplier3currntYr = api
                            .column(7)
                            .data()
                            .reduce(function (a, b) {
                                return intVal(a) + intVal(b);
                            }, 0);


                    var TotalSupplier3currntMnth = api
                           .column(8)
                           .data()
                           .reduce(function (a, b) {
                               return intVal(a) + intVal(b);
                           }, 0);
                    // Update footer by showing the total with the reference of the column index 
                    $(api.column(0).footer()).html('Grand Total');
                    $(api.column(1).footer()).html(TotalCurrentYearInvoice);
                    $(api.column(2).footer()).html(TotalCurrentMonthInvoice);
                    $(api.column(3).footer()).html(TotalSupplier1currntYr);
                    $(api.column(4).footer()).html(TotalSupplier1currntMnth);
                    $(api.column(5).footer()).html(TotalSupplier2currntYr);
                    $(api.column(6).footer()).html(TotalSupplier2currntMnth);
                    $(api.column(7).footer()).html(TotalSupplier3currntYr);
                    $(api.column(8).footer()).html(TotalSupplier3currntMnth);
                }


            });
          
            function myFunction() {
                var input, filter, table, tr, td, i, txtValue;
                input = document.getElementById("DropdownDistrict");
                filter = input.value.toUpperCase();
                table = document.getElementById("example3");
                tr = table.getElementsByTagName("tr");
                for (i = 0; i < tr.length; i++) {
                    td = tr[i].getElementsByTagName("td")[0];
                    if (td) {
                        txtValue = td.textContent || td.innerText;
                        if (txtValue.toUpperCase().indexOf(filter) > -1) {
                            tr[i].style.display = "";
                        } else {
                            tr[i].style.display = "none";
                        }
                    }
                }
            }
        });
       
    </script>
    
</asp:Content>
