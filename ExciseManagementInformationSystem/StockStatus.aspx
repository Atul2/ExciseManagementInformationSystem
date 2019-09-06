<%@ Page Title="" Language="C#" MasterPageFile="~/ExciseMIS.Master" AutoEventWireup="true" CodeBehind="StockStatus.aspx.cs" Inherits="ExciseManagementInformationSystem.StockStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <br />
    <style>
            button.dt-button {
                background-image: linear-gradient(to bottom, #00c0ef 0%, #00c0ef 100%);
                color: #f9f9f9;
            }
        </style>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Get Details of Cases
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-6 text-center">
                            <form id="form1" runat="server">
                                <div class="form-group row">
                                    <label for="serial" class="col-sm-4 col-form-label">Enter Case Serial No.</label>
                                    <div class="col-sm-6">
                                        <input type="text" class="form-control" id="serial" runat="server">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="^[0-9]{0,15}$" ControlToValidate="serial" runat="server" ForeColor="Red" ErrorMessage="invalid case serial no."></asp:RegularExpressionValidator>
                                    </div>
                                    <div class="col-sm-2">
                                        <asp:Button ID="GetDetailserialbtn" Text="Get Details" runat="server" class="btn btn-primary" OnClick="GetDetailserialbtn_Click" />
                                    </div>
                                </div>
                                <script type="text/javascript">
                                    $(document).ready(function () {
                                        $('#example').DataTable({
                                            "paging": false,
                                            "ordering": false,
                                            "searching": false,
                                            "info": false,
                                            dom: 'Bfrtip',
                                            buttons: [{
                                                extend: 'collection',
                                                className: "btn-primary",
                                                text: 'Export',
                                                buttons: [
                                                        { extend: 'copy', className: "btn-primary" },
                                                        { extend: 'csv', filename: 'StockDispatchStatus', className: "btn-primary" },
                                                        { extend: 'excel', filename: 'StockDispatchStatus', className: "btn-primary" },
                                                        { extend: 'pdf', filename: 'StockDispatchStatus', className: "btn-primary" }, 'print'
                                                ],
                                            }]
                                        });
                                        //var none = document.getElementById("panel panel-default").style.display = "none";

                                        $('#<%=GetDetailserialbtn.ClientID %>').click(function () {

                                            //document.getElementById("panel panel-default").style.display = "block";
                                            $('#<%=hologram.ClientID %>').val("");

                                        });
                                        $('#<%=GetDetailsbtn.ClientID %>').click(function () {
                                            //document.getElementById("panel panel-default").style.display = "block";
                                            $('#<%=serial.ClientID %>').val("");
                                        });
                                    });
                                </script>
                                <div class="form-group row">
                                    <label for="hologram" class="col-sm-4 col-form-label">Enter Hologram No.</label>
                                    <div class="col-sm-6">
                                        <input type="text" class="form-control" id="hologram" runat="server">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationExpression="^[a-zA-Z][a-zA-Z0-9]*$" ControlToValidate="hologram" runat="server" ForeColor="Red" ErrorMessage="invalid Hologram No."></asp:RegularExpressionValidator>
                                    </div>
                                    <div class="col-sm-2">
                                        <asp:Button ID="GetDetailsbtn" Text="Get Details" runat="server" class="btn btn-primary" OnClick="GetDetailsbtn_Click" />
                                    </div>
                                    <asp:CustomValidator ID="AtLeastOneContact" runat="server" Display="Dynamic" ForeColor="Red" OnServerValidate="AtLeastOneContact_ServerValidate" ErrorMessage="case serial no. OR hologram No is required choose one" />
                                </div>
                            </form>
                        </div>
                        <!-- /.col-lg-6 (nested) -->

                        <!-- /.col-lg-6 (nested) -->
                    </div>
                    <!-- /.row (nested) -->
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#example1').DataTable({
                "paging": false,
                "ordering": false,
                "searching": false,
                "info": false,
                dom: 'Bfrtip',
                buttons: [{
                    extend: 'collection',
                    className: "btn-primary",
                    text: 'Export',
                    buttons: [
                            { extend: 'copy', className: "btn-primary" },
                            { extend: 'csv', filename: 'StockInvoiceStatus', className: "btn-primary" },
                            { extend: 'excel', filename: 'StockInvoiceStatus', className: "btn-primary" },
                            { extend: 'pdf', filename: 'StockInvoiceStatus', className: "btn-primary" }, 'print'
                    ],
                }]
            });


        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#example2').DataTable({
                "paging": false,
                "ordering": false,
                "searching": false,
                "info": false,
                dom: 'Bfrtip',
                buttons: [{
                    extend: 'collection',
                    className: "btn-primary",
                    text: 'Export',
                    buttons: [
                            { extend: 'copy', className: "btn-primary" },
                            { extend: 'csv', filename: 'StockOverAll', className: "btn-primary" },
                            { extend: 'excel', filename: 'StockOverAll', className: "btn-primary" },
                            { extend: 'pdf', filename: 'StockOverAll', className: "btn-primary" }, 'print'
                    ],
                }]
            });


        });
    </script>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default" id="panel panel-default">

                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div class="table-responsive">
                        <asp:Repeater ID="rptr" runat="server">
                            <HeaderTemplate>
                                <table id="example" class="table table-striped table-bordered" style="width: 100%">
                                    <thead>
                                        <tr>
                                            <th>Dispatch_Id</th>
                                            <th>DispatchNo</th>
                                            <th>TransactionType</th>
                                            <th>WareHouseName</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("Dispatch_Id") %></td>
                                    <td><%# Eval("DispatchNo") %></td>
                                    <td><%# Eval("TransactionType") %></td>
                                    <td><%# Eval("WareHouseName") %></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                                      </table>
                                      </div>
                            </FooterTemplate>
                        </asp:Repeater>
                        <div class="table-responsive">
                            <asp:Repeater ID="rptr1" runat="server" OnLoad="GetDetailserialbtn_Click" OnPreRender="GetDetailserialbtn_Click">
                                <HeaderTemplate>
                                    <table id="example1" class="table table-striped table-bordered" style="width: 100%">
                                        <thead>
                                            <tr>
                                                <th>InvoiceId</th>
                                                <th>InvoiceNo</th>
                                                <th>TransactionType</th>
                                                <th>WareHouseName</th>
                                            </tr>
                                        </thead>

                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("InvoiceId") %></td>
                                        <td><%# Eval("InvoiceNo") %></td>
                                        <td><%# Eval("TransactionType") %></td>
                                        <td><%# Eval("WareHouseName") %></td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                   </table>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>
                            <div class="table-responsive">
                                <asp:Repeater ID="rptr2" runat="server" OnLoad="GetDetailserialbtn_Click" OnPreRender="GetDetailserialbtn_Click">
                                    <HeaderTemplate>
                                        <table id="example2" class="table table-striped table-bordered" style="width: 100%">
                                            <thead>
                                                <tr>
                                                    <th>HG_Serial_No</th>
                                                    <th>DispatchNo</th>
                                                     <th>TransactionType</th>
                                                    <th>CaseSerialNo</th>
                                                </tr>
                                            </thead>

                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("HG_Serial_No") %></td>
                                            <td><%# Eval("DispatchNo") %></td>
                                            <td><%# Eval("TransactionType") %></td>
                                            <td><%# Convert.ToDecimal(Eval("CaseSerialNo")).ToString("0.") %></td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody>
                   </table>
                                    </div>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>

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
