<%@ Page Title="" Language="C#" MasterPageFile="~/ExciseMIS.Master" AutoEventWireup="true" CodeBehind="InvoiceDetails.aspx.cs" Inherits="ExciseManagementInformationSystem.InvoiceDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <form runat="server">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Invoice Details</h1>
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
                    <label for="exampleFormControlSelect1">WareHouse</label>
                    <asp:DropDownList class="form-control" ID="dropdownWareHouse" runat="server" OnSelectedIndexChanged="dropdownWareHouse_SelectedIndexChanged" AppendDataBoundItems="True" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-3 col-md-6">
                <div class="form-group">
                    <label for="exampleFormControlSelect1">District</label>
                    <asp:DropDownList class="form-control" ID="DropdownDistrict" runat="server" OnSelectedIndexChanged=" DropdownDistrict_SelectedIndexChanged" AppendDataBoundItems="True" AutoPostBack="True">
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
                $('#example').dataTable({
                    dom: 'Bfrtip',
                    buttons: [{
                        extend: 'collection',
                        className: "btn-primary",
                        text: 'Export',
                        buttons: [
                                { extend: 'copy', className: "btn-primary" },
                                { extend: 'csv', filename: 'InvoiceDetails', className: "btn-primary" },
                                { extend: 'excel', filename: 'InvoiceDetails', className: "btn-primary" },
                                { extend: 'pdf', filename: 'InvoiceDetails', className: "btn-primary" }, 'print'
                        ]
                    }],
                    columnDefs: [{
                        targets: 1,
                        render: function (data, type, row, meta) {

                            if (type === 'display') {
                                data = '<a href="InvoiceInfo.aspx?id=' + row[0] + '">' + data + '</a>';
                            }
                            return data;
                        }
                    }]
                });
            });
        </script>
    </form>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Invoice Details Table
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div class="table-responsive">
                        <asp:Repeater ID="rptr" runat="server">
                            <HeaderTemplate>
                                <table id="example" class="display" style="width: 100%" data-page-length='100'>
                                    <thead>
                                        <tr>
                                            <th>InvoiceId</th>
                                            <th>InvoiceNo</th>
                                            <th>InvoiceDate</th>
                                            <th>PermitNo</th>
                                            <th>PermitValidityDate</th>
                                            <th>LicenseeId</th>
                                            <th>ProofLitre</th>
                                            <th>VehicleNo</th>
                                            <th>DutyAmountCalculated</th>
                                            <th>DutyAmount</th>
                                            <th>GrandTotal</th>
                                            <th>userid</th>
                                            <th>created_on</th>
                                            <th>modified_on</th>
                                            <th>financialyear</th>
                                            <th>DistrictId</th>
                                            <th>WareHouseId</th>
                                            <th>modified_by</th>
                                            <th>PermitDate</th>
                                            <th>InvoiceWareHouse</th>
                                            <th>GrandTotal_ChalanAmount</th>
                                            <th>DispatchTime</th>
                                            <th>DispatchTimeLimit</th>
                                            <th>ValidityTime</th>
                                            <th>LicenceeRouteId</th>
                                            <th>AuthorisedPerson</th>
                                            <th>PL_Calculated</th>
                                            <th>BL_Calculated</th>
                                            <th>Total_Cases</th>
                                            <th>Flag</th>
                                            <th>IsPrinted</th>
                                            <th>DeletingReason</th>
                                            <th>IsIssued</th>
                                            <th>IssueDate</th>
                                            <th>IssuedBy</th>
                                            <th>IsPosted</th>
                                            <th>TransportPermitNo</th>
                                            <th>TransportPermitDate</th>
                                            <th>TransportPermit_validityDate</th>
                                            <th>IsChallanPaid</th>
                                            <th>Remarks</th>
                                            <th>IsUpdated</th>
                                            <th>IsScanned</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("InvoiceId") %></td>
                                    <td style="white-space: nowrap; width: 50%;"><%# Eval("InvoiceNo") %></td>
                                    <td style="white-space: nowrap; width: 10%;"><%# Eval("InvoiceDate") %></td>
                                    <td><%# Eval("PermitNo") %></td>
                                    <td><%# Eval("PermitValidityDate") %></td>
                                    <td><%# Eval("LicenseeId") %></td>
                                    <td><%# Eval("ProofLitre") %></td>
                                    <td><%# Eval("VehicleNo") %></td>
                                    <td><%# Eval("DutyAmountCalculated")%></td>
                                    <td><%# Eval("DutyAmount")%></td>
                                    <td><%# Eval("GrandTotal") %></td>
                                    <td><%# Eval("userid") %></td>
                                    <td><%# Eval("created_on") %></td>
                                    <td><%# Eval("modified_on") %></td>
                                    <td><%# Eval("financialyear") %></td>
                                    <td><%# Eval("DistrictId") %></td>
                                    <td><%# Eval("WareHouseId") %></td>
                                    <td><%# Eval("modified_by") %></td>
                                    <td><%# Eval("PermitDate") %></td>
                                    <td><%# Eval("InvoiceWareHouse") %></td>
                                    <td><%# Eval("GrandTotal_ChalanAmount") %></td>
                                    <td><%# Eval("DispatchTime") %></td>
                                    <td><%# Eval("DispatchTimeLimit") %></td>
                                    <td><%# Eval("ValidityTime") %></td>
                                    <td><%# Eval("LicenceeRouteId") %></td>
                                    <td><%# Eval("AuthorisedPerson") %></td>
                                    <td><%# Eval("PL_Calculated") %></td>
                                    <td><%# Eval("BL_Calculated") %></td>
                                    <td><%# Eval("Total_Cases") %></td>
                                    <td><%# Eval("Flag") %></td>
                                    <td><%# Eval("IsPrinted") %></td>
                                    <td><%# Eval("DeletingReason") %></td>
                                    <td><%# Eval("IsIssued") %></td>
                                    <td style="white-space: nowrap; width: 10%;"><%# Eval("IssueDate") %></td>
                                    <td><%# Eval("IssuedBy") %></td>
                                    <td><%# Eval("IsPosted") %></td>
                                    <td><%# Eval("TransportPermitNo") %></td>
                                    <td><%# Eval("TransportPermitDate") %></td>
                                    <td><%# Eval("TransportPermit_validityDate") %></td>
                                    <td><%# Eval("IsChallanPaid") %></td>
                                    <td><%# Eval("Remarks") %></td>
                                    <td><%# Eval("IsUpdated") %></td>
                                    <td><%# Eval("IsScanned") %></td>
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
