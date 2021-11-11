<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recherche.aspx.cs" Inherits="prjWinCsLavalifeFinal.recherche" %>

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
						<div class="col-8">
							<asp:Panel ID="panFiltres" runat="server" BackColor="White" Height="583px">
								<form runat="server" id="formR">
								<table style="width:100%; align-items:center;justify-content:center">
									<tr>
										<td  colspan="2"style="font-size:50px;text-align:center;color:gray">
											Enter de traits of the person you are looking for<hr />
										</td>
									</tr>
									<tr>
										<td colspan="2" class="text-center">
											<asp:Label ID="Label1" runat="server" Text="Gender"></asp:Label>
										</td>
									</tr>
									<tr>
										<td colspan="2" class="text-center">
											<asp:DropDownList ID="cboGenderR" runat="server" Font-Size="15px" Width="30%" AutoPostBack="True" OnSelectedIndexChanged="cboGenderR_SelectedIndexChanged">
                                                <asp:ListItem>Man</asp:ListItem>
                                                <asp:ListItem>Woman</asp:ListItem>
                                            </asp:DropDownList>
										</td>
									</tr>
									<tr>
										<td colspan="2" class="text-center">
										<br />
											<asp:Label ID="Label2" runat="server" Text="Nationality (Enter a country)"></asp:Label>
										</td>
									</tr>
									<tr>
										<td colspan="2" class="text-center">
										<br />
											<asp:TextBox ID="txtNationalityR" runat="server" Width="40%"></asp:TextBox>	
										</td>
									</tr>
									<tr>
										<td colspan="2" class="text-center">
										<br />
											<asp:Label ID="Label3" runat="server" Text="Specific color of hair"></asp:Label>
										</td>
									</tr>
									<tr>
										<td colspan="2" class="text-center">
										<br />
											<asp:TextBox ID="txtHairR" runat="server"  Width="40%"></asp:TextBox>
										</td>
									</tr>
									<tr>
										<td class="text-center">
										<br />
											<asp:Label ID="Label4" runat="server" Text="Min. Height"></asp:Label>
										</td>
										<td class="text-center">
										<br />
											<asp:Label ID="Label5" runat="server" Text="Max. Height"></asp:Label>
										</td>
									</tr>
									<tr>
										<td class="text-center">
										<br />
											<asp:TextBox ID="txtMinHeight" runat="server" TextMode="Number" Width="50%"></asp:TextBox>
										</td>
										<td class="text-center">
										<br />
											<asp:TextBox ID="txtMaxHeight" runat="server" TextMode="Number" Width="50%"></asp:TextBox>
										</td>
									</tr>
									<tr>
										<td colspan="2" class="text-center">
										<br />
											<asp:Label ID="Label6" runat="server" Text="Specific color of eyes"></asp:Label>
										</td>
									</tr>
									<tr>
										<td colspan="2" class="text-center">
										<br />
											<asp:TextBox ID="txtEyesR" runat="server" Width="40%"></asp:TextBox>
										</td>
									</tr>
									<tr>
										<td colspan="2" class="text-center">
										<br /><br />
											<asp:Button ID="btnRecherche" runat="server" Text="Search" BackColor="#FF3300" ForeColor="White" Width="50%" Height="59px" OnClick="btnRecherche_Click"></asp:Button>
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
