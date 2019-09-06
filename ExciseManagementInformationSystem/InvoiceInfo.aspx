<%@ Page Title="" Language="C#" MasterPageFile="~/ExciseMIS.Master" AutoEventWireup="true" CodeBehind="InvoiceInfo.aspx.cs" Inherits="ExciseManagementInformationSystem.InvoiceInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                }]

            });
        });
    </script>
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
                                            <th>InvoiceDetailId</th>
                                            <th>InvoiceId</th>
                                            <th>LabelId</th>
                                            <th>UnitId</th>
                                            <th>Rate</th>
                                            <th>Amount</th>
                                            <th>Quantity</th>
                                            <th>financialyear</th>
                                            <th>flag</th>
                                            <th>SupplierId</th>
                                            <th>BL</th>
                                            <th>PL</th>
                                            <th>QtyInShop</th>
                                            <th>Stock_inShop</th>
                                            <th>IsIssued</th>
                                            <th>IssueDate</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("InvoiceDetailId") %></td>
                                    <td><%# Eval("InvoiceId") %></td>
                                    <td><%# Eval("LabelId") %></td>
                                    <td><%# Eval("UnitId") %></td>
                                    <td><%# Eval("Rate") %></td>
                                    <td><%# Eval("Amount") %></td>
                                    <td><%# Eval("Quantity")%></td>
                                    <td><%# Eval("financialyear")%></td>
                                    <td><%# Eval("flag") %></td>
                                    <td><%# Eval("SupplierId") %></td>
                                    <td><%# Eval("BL") %></td>
                                    <td><%# Eval("PL") %></td>
                                    <td><%# Eval("QtyInShop") %></td>
                                    <td><%# Eval("Stock_inShop") %></td>
                                    <td><%# Eval("IsIssued") %></td>
                                    <td><%# Eval("IssueDate") %></td>

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
               <div class="panel-footer"><a href="javascript:history.go(-1)" title="Return to the previous page">&laquo; Go back</a></div>
            </div>

            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
    </div>
</asp:Content>
