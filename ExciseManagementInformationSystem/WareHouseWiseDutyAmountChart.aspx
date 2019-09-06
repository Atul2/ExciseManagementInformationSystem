 <%@ Page Title="" Language="C#" MasterPageFile="~/ExciseMIS.Master" AutoEventWireup="true" CodeBehind="WareHouseWiseDutyAmountChart.aspx.cs" Inherits="ExciseManagementInformationSystem.WareHouseWiseDutyAmountChart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/moment.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            var obj = {};
            obj.selectedText1 = $('#<%=dropdownFYear.ClientID %> option:selected').text();
            obj.selectedText2 = $('#<%=dropdownSupplier.ClientID %> option:selected').val();
            obj.selectedText3 = $('#<%=dropdownWareHouse.ClientID %> option:selected').val();
            obj.frmdt = "";
            obj.todt = "";

            if ($('#<%=from.ClientID %>').val() != $('#<%=to.ClientID %>').val()) {

                var fdateString = $('#<%=from.ClientID %>').val();
                var fmomentObj = moment(fdateString, 'DD-MM-YYYY');
                var fmomentString = fmomentObj.format('YYYY-MM-DD');
                obj.frmdt = fmomentString;

                var tdateString = $('#<%=to.ClientID %>').val();
                var tmomentObj = moment(tdateString, 'DD-MM-YYYY');
                var tmomentString = tmomentObj.format('YYYY-MM-DD');
                obj.todt = tmomentString
            }

            console.log(JSON.stringify(obj));

            $.ajax({
                type: 'POST',
                url: "Graph.aspx/GraphWDA",
                data: JSON.stringify(obj),
                dataType: 'json',
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    new Morris.Bar({
                        element: 'bar-chart',
                        data: result.d,
                        barColors: ['orange'],
                        xkey: 'w',
                        ykeys: 'x',
                        xLabelAngle: 50,
                        resize: true,
                        labels: ['DutyAmount']
                    });
                },
                error: function (error) { alert(error.responseText); }
            });

        });
    </script>
    <script type="text/javascript">
        function printDiv(divName) {
            var printContents = document.getElementById(divName).innerHTML;
            var originalContents = document.body.innerHTML;
            document.body.innerHTML = printContents;
            window.print();
            document.body.innerHTML = originalContents;
        }
    </script>
    <section class="content">
        <form runat="server">
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
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                </div>
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
            <section id="WareHouse Wise DutyAmount Chart">
                <div class="row">
                    <div class="col-xs-12">
                        <div class="panel panel-warning">
                            <div class="panel-heading">
                                <h3 class="panel-title"><strong>WareHouse Wise DutyAmount Chart</strong> &nbsp; &nbsp;&nbsp;
                                    <button onclick="printDiv('bar-chart')" class="btn btn-warning btn-sm">print</button></h3>
                            </div>
                            <div class="panel-body">
                                <div id="bar-chart" style="height: 400px;"></div>
                            </div>
                            <!-- /.box-body -->
                        </div>
                    </div>
                </div>
            </section>
        </form>
    </section>
</asp:Content>
