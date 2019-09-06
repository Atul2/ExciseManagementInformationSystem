<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resetpassword.aspx.cs" Inherits="ExciseManagementInformationSystem.resetpassword" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title></title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- MetisMenu CSS -->
    <link href="css/metisMenu.min.css" rel="stylesheet">

    <!-- Timeline CSS -->
    <link href="css/timeline.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="css/startmin.css" rel="stylesheet">

    <!-- Morris Charts CSS -->
    <link href="css/morris.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/html5shiv/3.7.3/html5shiv.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>

<div id="wrapper">

    <!-- Navigation -->
    <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
        <div class="navbar-header">
            <a class="navbar-brand" href="#">ExciseMIS</a>
        </div>

        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
        </button>

        <!-- Top Navigation: Left Menu -->
       
        <!-- Top Navigation: Right Menu -->
      
        <!-- Sidebar -->
        <div class="navbar-default sidebar" role="navigation">
            <div class="sidebar-nav navbar-collapse">

                <ul class="nav" id="side-menu">
                    
                    <li>
                        <a href="Login.aspx" class="active"><i class="fa fa-dashboard fa-fw"></i> Back to Login!!</a>
                    </li>
                   
                </ul>

            </div>
        </div>
    </nav>

    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">

            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Reset Password</h1>
                </div>
            </div>

            <!-- ... Your content goes here ... -->
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
                                                    <label>New Password</label>
                                                    <input class="form-control" id="newpasstxt" runat="server"  type="Password" placeholder="New Password" />
                                                </div>
                                               <asp:RequiredFieldValidator id="confirmPasswordReq"  runat="server"   ControlToValidate="newpasstxt"  ErrorMessage="New Password  is required!" SetFocusOnError="True"  Display="Dynamic" />


                                                <div class="form-group">
                                                    <label>Confirm Password</label>
                                                    <input class="form-control" type="Password"  id="confirmpasswordtxt" runat="server" placeholder="Confirm Password"/>
                                                </div>
                                               
                                                   <asp:RequiredFieldValidator id="RequiredFieldValidator1"  runat="server"   ControlToValidate="confirmpasswordtxt"  ErrorMessage="Password confirmation is required!" SetFocusOnError="True"  Display="Dynamic" />
                                               
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password doesnt match!!" ControlToValidate="confirmpasswordtxt" ControlToCompare="newpasstxt"></asp:CompareValidator>
                                              
                                               
                                                
                                                
                                              <asp:Button ID="resetbtn" runat="server" Text="Reset" type="reset" class="btn btn-primary" OnClick="resetbtn_Click" />
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

        </div>
    </div>

</div>

<!-- jQuery -->
<script src="js/jquery.min.js"></script>

<!-- Bootstrap Core JavaScript -->
<script src="js/bootstrap.min.js"></script>

<!-- Metis Menu Plugin JavaScript -->
<script src="js/metisMenu.min.js"></script>

<!-- Custom Theme JavaScript -->
<script src="js/startmin.js"></script>

</body>
</html>

