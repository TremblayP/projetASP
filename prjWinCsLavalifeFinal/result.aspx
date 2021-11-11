<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="result.aspx.cs" Inherits="prjWinCsLavalifeFinal.result" %>

<!DOCTYPE html>
<html lang="en" ng-app="Lavalife">
  <head>
    
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Log In – Lavalife.com Online Dating Site & Mobile Apps – Where Singles Click®</title>
	<meta name="description" content="Welcome back to Lavalife.com! Log in to your online dating profile to see your messages, likes and other notifications now." >
	<meta name="apple-itunes-app" content="app-id=888082770">
    <!-- Styles -->
    <link href="css/finalbuild.css" rel="stylesheet">
    <link href="css/bootstrap-tour.min.css" rel="stylesheet">
    <!--<script src="js/angular.min.js"></script>
    <script src="js/directives.js"></script>
	<script src="js/angulartics.js"></script>
	<script src="js/angulartics-ga.js"></script>-->
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    
	<script>
        /*(function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
                m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-56667868-1', 'auto');
        ga('require', 'displayfeatures');
        ga('send', 'pageview');*/
    </script>
	
      <style type="text/css">
          .auto-style1 {
              text-align: center;
              margin-left: 40px;
          }
          .auto-style2 {
              text-align: center;
              height: 24px;
          }
      </style>
	
  </head>
  <body style="background-color:silver;">
   	
   	<!-- Wrap all page content here -->
   	<div id="wrap" >
		<div class="mobile-dl">
			<a href=""><img /></a>
		</div>
   	
   		<a href="./index.aspx" id="logo-signup" class="visible-lg visible-md visible-sm"></a>
   			    	    
		<nav class="navbar navbar-default visible-xs" role="navigation">
	      	
	        <!-- Brand and toggle get grouped for better mobile display -->
			<div class="navbar-header col-xs-12">
	          
				<button type="button" class="navbar-toggle collapsed col-xs-4" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
					<span class="sr-only">Toggle navigation</span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
				</button>
	        	
				<a href="./" id="logo" class="navbar-brand"></a>
	        
			</div>
	    
	        <!-- Collect the nav links, forms, and other content for toggling -->
			<div class="collapse navbar-collapse col-xs-12" id="bs-example-navbar-collapse-1" style="margin-top: 10px;">
				<ul class="nav navbar-nav">
					<li><a href="privacy-policy.html" target="_blank">Privacy Policy</a></li>
		            <li><a href="terms-of-use.html" target="_blank">Terms of Service</a></li>
		            <li><a href="FAQ.html" target="_blank">FAQ</a></li>
		          </ul>

			</div><!-- /.navbar-collapse -->
		</nav>
	    <secton class="container" style="min-width:300px !important;background-color:white;">
	    	
	    	<div class="row login-holder">
	    		

	    		    		
	    		<div class=" col-12" id="login">
	    				<div class="lil-logo">
							<img src="images/landing/ll_logo_registration_circle_sml.png" />
	    				</div>
						
	    					<h2>Find the right partner <br /></h2>
						<div class="devider-line"></div>
						<div class="col-6">

							<asp:Panel ID="panResult" runat="server" BackColor="White" Height="583px">
								<form runat="server" id="formResult">
									<table style="width:100%; align-items:center;justify-content:center">
										<tr>
											<td  colspan="2" style="font-size:40px;text-align:center;color:gray">
												This is the list of the people that could interest you<hr />
											</td>
										</tr>
										<tr>
											<td colspan="2" class="auto-style2">
												</td>
										</tr>
										<tr>
											<td class="text-center">
												<asp:Label ID="Label1" runat="server" Text="Membres"></asp:Label>
											</td>
											<td class="text-center">
												<asp:Label ID="Label2" runat="server" Text="Informations"></asp:Label>
											</td>
										</tr>
										<tr>
											<td class="auto-style1">
												<asp:ListBox ID="lstUsers" runat="server" AutoPostBack="True" Height="166px" Width="100%" OnSelectedIndexChanged="lstUsers_SelectedIndexChanged"></asp:ListBox>
											</td>
											<td class="text-center">

											    <asp:Literal ID="litResult" runat="server"></asp:Literal>
                                                <br />
                                                <br />
                                                <asp:Button ID="btnMess" runat="server" OnClick="btnMess_Click"   Text="Envoyer un message" Visible="False" Width="200px" BackColor="#FF3300" ForeColor="White" />

											</td>
										</tr>
									</table>
									</form>
							</asp:Panel>
						</div>	

							
	
	
	    		</div>
			
			</div>
			
	    </secton>
	
	</div>
</body>
</html>
