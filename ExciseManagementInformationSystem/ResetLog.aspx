<%@ Page Title="" Language="C#" MasterPageFile="~/ExciseMIS.Master" AutoEventWireup="true" CodeBehind="ResetLog.aspx.cs" Inherits="ExciseManagementInformationSystem.ResetLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <br />
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Change your Password
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <form role="form" runat="server">
                                <div class="form-group">
                                    <label>Current Password</label>
                                    <input class="form-control" id="currentpasstxt" runat="server" type="Password" placeholder="Current Password" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="currentpasstxt" ErrorMessage="Current Password  is required!" ForeColor="Red" SetFocusOnError="True" Display="Dynamic" />

                                <div class="form-group">
                                    <label>New Password</label>
                                    <input class="form-control" id="newpasstxt" runat="server" type="Password" placeholder="New Password" />
                                </div>
                                <asp:RequiredFieldValidator ID="confirmPasswordReq" runat="server" ControlToValidate="newpasstxt" ErrorMessage="New Password  is required!" ForeColor="Red" SetFocusOnError="True" Display="Dynamic" />


                                <div class="form-group">
                                    <label>Confirm Password</label>
                                    <input class="form-control" type="Password" id="confirmpasswordtxt" runat="server" placeholder="Confirm Password" />
                                </div>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="confirmpasswordtxt" ErrorMessage="Password confirmation is required!" ForeColor="Red" SetFocusOnError="True" Display="Dynamic" />

                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password doesnt match!!" ControlToValidate="confirmpasswordtxt" ControlToCompare="newpasstxt"></asp:CompareValidator>

                                <asp:Button ID="resetbtn" runat="server" Text="Change Password" type="reset" class="btn btn-primary" OnClick="resetbtn_Click" />
                                <asp:Label ID="Label2" runat="server"></asp:Label>
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
</asp:Content>
