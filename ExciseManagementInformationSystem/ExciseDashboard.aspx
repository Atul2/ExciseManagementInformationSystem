<%@ Page Title="" Language="C#" MasterPageFile="~/ExciseMIS.Master" AutoEventWireup="true" CodeBehind="ExciseDashboard.aspx.cs" Inherits="ExciseManagementInformationSystem.ExciseDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div class="header">
        <div class="row">
            <div class="col-md-4">
                <h1>Dashboard</h1>
            </div>
            <div class="col-md-2">
                <form class="form-horizontal" runat="server">
                    <div class="form-group">
                        <label for="exampleFormControlSelect1"></label>
                        <asp:DropDownList class="form-control" ID="dropdownFYear" runat="server" OnLoad="dropdownFYear_SelectedIndexChanged" OnSelectedIndexChanged="dropdownFYear_SelectedIndexChanged" AppendDataBoundItems="True" AutoPostBack="True">
                        </asp:DropDownList>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <div class="row">
        <%--<div class="col-lg-3 col-md-6">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="fa fa-comments fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="huge">
                                <asp:Label ID="Label1" runat="server" />
                            </div>
                            <div>Dispatch</div>
                        </div>
                    </div>
                </div>
                <a href="DispatchTable.aspx">
                    <div class="panel-footer">
                        <span class="pull-left">View Details</span>
                        <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>--%>

        <div class="col-lg-3 col-xs-6">
            <!-- small box -->
            <div class="small-box bg-aqua">
                <div class="inner">
                    <h4><asp:Label ID="Label1" runat="server" /></h4>
                    <p>Dispatch</p>
                </div>
                <div class="icon">
                    <i class="ion-arrow-graph-up-right"></i>
                </div>
                <a href="DispatchTable.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>
        <div class="col-lg-3 col-xs-6">
            <!-- small box -->
            <div class="small-box bg-green">
                <div class="inner">
                    <h4><asp:Label ID="Label2" Text="0" runat="server" /></h4>
                    <p>Invoice</p>
                </div>
                <div class="icon">
                    <i class="ion-ios-paper-outline"></i>
                </div>
                <a href="InvoiceDetails.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>
         <div class="col-lg-3 col-xs-6">
            <!-- small box -->
            <div class="small-box bg-red">
                <div class="inner">
                    <h4><asp:Label ID="Label3"  runat="server" /></h4>
                    <p>Duty Rate</p>
                </div>
                <div class="icon">
                    <i class="ion-arrow-graph-up-right"></i>
                </div>
                <a href="Dutydetails.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>
    </div>
</asp:Content>


