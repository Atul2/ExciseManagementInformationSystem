<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ExciseManagementInformationSystem.Login" %>

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

    <!-- Custom CSS -->
    <link href="css/startmin.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
        <![endif]-->


    <style type="text/css">
body, html {
  height: 100%;
  margin: 0;
}

.bg {
  /* The image used */
  background-image: url("images/report2.jpg");

  /* Full height */
  height: 100%; 
  width:100%;
  /* Center and scale the image nicely */
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
}
</style>
    <style>
.footer {
   position: fixed;
   left: 0;
   bottom: 0;
   width: 100%;
   height:7%;
   background-color: black;
   color: white;
   text-align: center;
}
</style>
    <style type="text/css">
        .login-panel {
    margin-top: 10%;
}
    </style>
</head>
    
<body>

<div class="container bg">
    <br />
       <div class="row">
             <div class="col-md-3 text-right" >
                 <img src="images/cglogo.gif" style="width:25%;height:25%;"/>
             </div> 
            <div class="col-md-9">
                <h2 class="text-left"><b>&nbsp;&nbsp;&nbsp;&nbsp;Excise Management Information System</b></h2>
                <h4 class="text-left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Excise Department, Raipur,Chhattisgarh</b></h4>
            </div>
       </div>
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Please Sign In</h3>
                    </div>
                    <div class="panel-body">
                        <form role="form" runat="server">
                            <fieldset>
                                <div class="form-group">
                                    <input class="form-control" id="nametxt" runat="server" placeholder="Login Name" name="email" type="text" required autofocus />
                                </div>
                                <div class="form-group">
                                    <input class="form-control" id="pswdtxt" runat="server" placeholder="Password" name="password" required type="password" />
                                </div>

                                <!-- Change this to a button or input when using this as a form -->

                                 <asp:Button ID="loginButton" runat="server"  Text="Login" class="btn btn-success btn-block" OnClick="loginButton_Click" />
                               
                                <div class="modal-footer"">
                                    <p>Forgot <a href="ForgotPassword.aspx">Password?</a></p>
                                </div>

                            </fieldset>

                            <asp:Label ID="Label1" runat="server"></asp:Label>
                       
  <!-- The Modal -->
  <div class="modal" id="myModal">
    <div class="modal-dialog">
      <div class="modal-content">
      
        <!-- Modal Header -->
        <div class="modal-header">
          <h4 class="modal-title">Forget Password?</h4>
          <button type="button" class="close" data-dismiss="modal">&times;</button>
        </div>
        
        <!-- Modal body -->
        <div class="modal-body">
          Enter E-Mail to reset your password:  <input id="emailtxt" runat="server" type="text" />
        </div>
        
        <!-- Modal footer -->
        <div class="modal-footer">
         <asp:Button ID="resetbtn" runat="server"  Text="Send Reset Link" class="btn btn-primary" OnClick="resetbtn_Click" />
             <asp:Label ID="Label2" runat="server"></asp:Label>
        </div>
        
      </div>
    </div>
  </div>
   </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <footer class="footer">
        <br />
  <!-- Copyright -->
  <div class="container">© 2019 Copyright:
    <a href="#"> Excise Management Information System</a>
  </div>
  <!-- Copyright -->

</footer>
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
