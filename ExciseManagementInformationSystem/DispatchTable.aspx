<%@ Page Title="" Language="C#" MasterPageFile="~/ExciseMIS.Master" AutoEventWireup="true" CodeBehind="DispatchTable.aspx.cs" Inherits="ExciseManagementInformationSystem.DispatchTable" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <form runat="server">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Dispatch Details</h1>
            </div>
        </div>
        <div class="row">
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
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        </div>

        <div id="row">
            <div class="col-lg-2 col-md-4">
                <div class="form-group">
                    <b>
                        <asp:Label for="from" runat="server" Text="From Date"></asp:Label></b>
                    <div class="input-group date">
                        <asp:TextBox class="form-control" type="text" ID="from" runat="server" OnTextChanged="from_TextChanged" />
                        <div class="input-group-addon">
                            <i id="cal" class="fa fa-calendar"></i>
                        </div>
                    </div>
                    <ajaxToolkit:CalendarExtender TargetControlID="from" runat="server" Format="dd/MM/yyyy" PopupButtonID="cal" PopupPosition="BottomRight" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[/](0[1-9]|1[012])[/]\d{4}" ControlToValidate="from" runat="server" ForeColor="Red" ErrorMessage="invalid date"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="col-lg-2 col-md-4">
                <div class="form-group">
                    <b>
                        <asp:Label for="to" runat="server" Text="To Date"></asp:Label></b>
                    <div class="input-group date">
                        <asp:TextBox class="form-control" type="text" ID="to" runat="server" OnTextChanged="to_TextChanged" />
                        <div class="input-group-addon">
                            <i id="cal2" class="fa fa-calendar"></i>
                        </div>
                    </div>
                    <ajaxToolkit:CalendarExtender TargetControlID="to" runat="server" Format="dd/MM/yyyy" PopupButtonID="cal2" PopupPosition="BottomRight" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[/](0[1-9]|1[012])[/]\d{4}" ControlToValidate="to" runat="server" ForeColor="Red" ErrorMessage="invalid date"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="col-lg-2 col-md-4">
                <br>

                <div class="input-group">
                    <div class="input-group-btn">
                        <asp:Button ID="Button1" class="btn btn-info" runat="server" Text="search" OnClick="Button1_Click" />
                    </div>
                </div>

            </div>

        </div>
        <style>
            button.dt-button {
                background-image: linear-gradient(to bottom, #00c0ef 0%, #00c0ef 100%);
                color: #f9f9f9;
            }
        </style>

        <script type="text/javascript">
            $(document).ready(function () {
                $('#example').DataTable({
                    dom: 'Bfrtip',
                    buttons: [{
                        extend: 'collection',
                        className: "btn-primary",
                        text: 'Export',
                        buttons: [
                                { extend: 'copy', className: "btn-primary" },
                                { extend: 'csv', filename: 'DispatchTable', className: "btn-primary" },
                                { extend: 'excel', filename: 'DispatchTable', className: "btn-primary" },
                                { extend: 'pdf', filename: 'DispatchTable', className: "btn-primary" }, 'print'
                        ],
                    }]

                });
            });

            $('#example').dataTable({
                "pageLength": 100,
                "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]]
            });
        </script>
    </form>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Dispatch Table
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div class="table-responsive">
                        <asp:Repeater ID="rptr" runat="server">
                            <HeaderTemplate>
                                <table id="example" class="display" style="width: 200%" data-page-length='100'>
                                    <thead>

                                        <tr>
                                            <th>Dispatch_Id</th>
                                            <th>SupplierId</th>
                                            <th>WareHouseId</th>
                                            <th>DispatchNo</th>
                                            <th>Dispatch_Date</th>
                                            <th>UserId</th>
                                            <th>FinancialYear</th>
                                            <th>Modified_On</th>
                                            <th>Created_on</th>
                                            <th>PermitNo</th>
                                            <th>PermitDate</th>
                                            <th>PermitValidityDate</th>
                                            <th>New_PermitValidityDate</th>
                                            <th>NOC_No</th>
                                            <th>NOC_Date</th>
                                            <th>NOC_ValidityDate</th>
                                            <th>New_NOCValidityDate</th>
                                            <th>VehicleNo</th>
                                            <th>TransporterName</th>
                                            <th>TransporterAddress</th>
                                            <th>DriverName</th>
                                            <th>Compny_InvoiceNo</th>
                                            <th>Compny_InvoiceDate</th>
                                            <th>Remarks</th>
                                            <th>Total_Amt</th>
                                            <th>IsRecieved</th>
                                            <th>DriverMob_No</th>
                                            <th>DispatchTime</th>
                                            <th>ExpectedArrival</th>
                                            <th>SupplierRouteId</th>
                                        </tr>


                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("Dispatch_Id") %></td>
                                    <td><%# Eval("SupplierId") %></td>
                                    <td><%# Eval("WareHouseId") %></td>
                                    <td style="white-space: nowrap; width: 50%;"><%# Eval("DispatchNo") %></td>
                                    <td style="white-space: nowrap; width: 10%;"><%# Eval("Dispatch_Date") %></td>
                                    <td><%# Eval("UserId") %></td>
                                    <td><%# Eval("FinancialYear") %></td>
                                    <td><%# Eval("Modified_On") %></td>
                                    <td><%# Eval("Created_on")%></td>
                                    <td><%# Eval("PermitNo")%></td>
                                    <td style="white-space: nowrap; width: 10%;"><%# Eval("PermitDate") %></td>
                                    <td><%# Eval("PermitValidityDate") %></td>
                                    <td><%# Eval("New_PermitValidityDate") %></td>
                                    <td><%# Eval("NOC_No") %></td>
                                    <td><%# Eval("NOC_Date") %></td>
                                    <td><%# Eval("NOC_ValidityDate") %></td>
                                    <td><%# Eval("New_NOCValidityDate") %></td>
                                    <td><%# Eval("VehicleNo") %></td>
                                    <td><%# Eval("TransporterName") %></td>
                                    <td><%# Eval("TransporterAddress") %></td>
                                    <td><%# Eval("DriverName") %></td>
                                    <td><%# Eval("Compny_InvoiceNo") %></td>
                                    <td><%# Eval("Compny_InvoiceDate") %></td>
                                    <td><%# Eval("Remarks") %></td>
                                    <td><%# Eval("Total_Amt") %></td>
                                    <td><%# Eval("IsRecieved") %></td>
                                    <td><%# Eval("DriverMob_No") %></td>
                                    <td><%# Eval("DispatchTime") %></td>
                                    <td><%# Eval("ExpectedArrival") %></td>
                                    <td><%# Eval("SupplierRouteId") %></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                                      </table>
                                      </div>
                            </FooterTemplate>
                        </asp:Repeater>

                    </div>
                    <!-- /.table-responsive -->
                </div>
                <!-- /.panel-body -->
            </div>

            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
    </div>



</asp:Content>
