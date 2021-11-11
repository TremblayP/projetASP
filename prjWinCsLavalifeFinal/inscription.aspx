<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inscription.aspx.cs" Inherits="prjWinCsLavalifeFinal.inscription" %>


<!DOCTYPE html>
<html lang="en" ng-app="Lavalife">
  <head>
    
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Sign Up – Lavalife.com Online Dating Site & Mobile Apps – Where Singles Click®</title>
	<meta name="description" content="Sign up for Lavalife.com online dating and get a 7 day free trial. Browse unlimited profiles, send unlimited messages and start having fun." />
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
	
	<!-- CJ -->
	<script>
	var MasterTmsUdo = { 
		'CJ' : { 
			'CID': '1531962', 
			'TYPE': '375813', 
		} 
	}; 
	</script>
	<script>/*DO NOT ALTER *** New Site*/(function(e){var t="1614",n=document,r,i,s={http:"http://cdn.mplxtms.com/s/MasterTMS.min.js",https:"https://secure-cdn.mplxtms.com/s/MasterTMS.min.js"},o=s[/\w+/.exec(window.location.protocol)[0]];i=n.createElement("script"),i.type="text/javascript",i.async=!0,i.src=o+"#"+t,r=n.getElementsByTagName("script")[0],r.parentNode.insertBefore(i,r),i.readyState?i.onreadystatechange=function(){if(i.readyState==="loaded"||i.readyState==="complete")i.onreadystatechange=null}:i.onload=function(){try{e()}catch(t){}}})(function(){});</script>
	<!-- end -->

	<script>
	  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
	  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
	  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
	  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

	  ga('create', 'UA-56667868-1', 'auto');
	  ga('require', 'displayfeatures');
	  ga('send', 'pageview');
	</script>
	
	<script type="text/javascript">
		/* <![CDATA[ */
		var google_conversion_id = 1062502675;
		var google_custom_params = window.google_tag_params;
		var google_remarketing_only = true;
		/* ]]> */
	</script>
	<script type="text/javascript" src="//www.googleadservices.com/pagead/conversion.js">
	</script>
	<noscript>
		<div style="display:inline;">
			<img height="1" width="1" style="border-style:none;" alt="" src="//googleads.g.doubleclick.net/pagead/viewthroughconversion/1062502675/?value=0&amp;guid=ON&amp;script=0"/>
		</div>
	</noscript>
	
  </head>
  
  <style>
	.auto-style1 {
            width: 39%;
     }
	label {
		color:#757575;
		font-size:13px;
	}
	
	.label {
		color:#212121 !important;
		padding-left:0px !important;
		font-family:"Open Sans", sans-serif !important;
		font-size:14px !important;
		font-weight: 500 !important;
	}
	
	h2{
		margin-top: 12px;
		text-align: left;
		line-height: 25px;
		margin: 10px 0;
		color: #ff0000;
		font-weight: 300;
		padding-left: 50px;
		background-repeat: repeat-y;
	}
	
	.selectric{
		border-color:#e5e5e5 !important;
	}
	
	input {
		color:#212121;
		border-color:#e5e5e5 !important;
	}
	
	.devider-line{
		margin-top:30px;
	}
	
	.itemPanel{
		-webkit-box-shadow: 0px 2px 2px 1px #555;
		-moz-box-shadow: 0px 2px 2px 1px #555;
		box-shadow: 0px 2px 2px 1px #555;
		border:solid 1px #757575;
	}

	.crop-cancel{
		display:none;
	}
  </style>
  <body  ng-controller="SignupController as signup">
 
  	<!-- Wrap all page content here -->
	<div id="wrap">
    
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
	    
	    <section class="container" style="min-width:300px !important;">
	    	
	    	<div class="row register-holder">
	    		
	    		<div class="col-md-8 hidden-sm hidden-xs" style="position: relative; height: 100%; padding: 0px;">
	    
	    			<div class="backgrounds"><img class="selected" src="images/spring/ll_step1_img.jpg" /></div>	    				    			
	    		</div>
	    		
	    		<div class="col-md-4 col-sm-12" id="register">
	    			
					<div class="lil-logo">
						<img src="images/landing/ll_logo_registration_circle_sml.png" />
					</div>
	    			
	    			<div class="step-1">
	    				
	    				<h2>Create Your Profile <br /><span>AND RECEIVE A 7-DAY FREE TRIAL.</span></h2>
	    				
	    				<div class="step-content">
	    					
	    					<div class="errors-holder">&nbsp;</div>
		    				
							<form runat="server" id="form3">
								<div>
									<table class="auto-style1">
										<tr>
											<td>
                                                <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
											</td>
											<td> 
                                                <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
											</td>
										</tr>
										<tr>
											<td>
                                                <asp:TextBox ID="txtFirstName" runat="server" Width="150px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="#FF3300" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
											</td>
											<td>
                                                <asp:TextBox ID="txtLastName" runat="server" Width="150px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="#FF3300" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
											</td>
										</tr>
										<tr>
											<td>
                                                <asp:Label ID="Label3" runat="server" Text="I'm a"></asp:Label>
											</td>
										</tr>
										<tr>
											<td colspan="2">
                                                <asp:DropDownList ID="cboSexeI" runat="server" Width="300px" Height="35px">
                                                    <asp:ListItem>Man</asp:ListItem>
                                                    <asp:ListItem>Woman</asp:ListItem>
                                                </asp:DropDownList>
											</td>
										</tr>
										<tr>
											<td colspan="2">
                                                <asp:Label ID="Label4" runat="server" Text="Birthday"></asp:Label>
											</td>
										</tr>
										<tr>
											<td colspan="2">
                                                <asp:TextBox ID="txtBirth" runat="server" Width="300px" TextMode="Date"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="#FF3300" ControlToValidate="txtBirth"></asp:RequiredFieldValidator>
											</td>
										</tr>
										<tr>
											<td colspan="2">
                                                <asp:Label ID="Label5" runat="server" Text="Email Address"></asp:Label>
											</td>
										</tr>
										<tr>
											<td colspan="2">
                                                <asp:TextBox ID="txtEmailI" runat="server" Width="300px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="#FF3300" ControlToValidate="txtEmailI"></asp:RequiredFieldValidator>
											</td>
										</tr>
										<tr>
											<td colspan="2">
                                                <asp:Label ID="Label6" runat="server" Text="Password"></asp:Label>
											</td>
										</tr>
										<tr>
											<td colspan="2">
                                                <asp:TextBox ID="txtPasswordI" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="#FF3300" ControlToValidate="txtPasswordI"></asp:RequiredFieldValidator>
											</td>
										</tr>
										<tr>
											<td colspan="2">

											</td>
										</tr>
										<tr>
											<td colspan="2">
                                                <asp:Button ID="btnInscription" runat="server" Text="JOIN NOW" BackColor="#FF3300" ForeColor="White" Width="300px" OnClick="btnInscription_Click"/>
											</td>
										</tr>
									</table>
								</div>
							</form>
							
							
	    				
	    		
	    				
	    			</div>
	    			
	    			<div class="step-3 hidden">
	    				<h2>Just A Few More Things <br /><span>YOUR FREE TRIAL IS NEARLY READY.</span></h2>
	    				
	    				<div class="step-content">
	    				
	    					<div class="errors-holder">&nbsp;</div>
	    					
		    				<form class="register-form" action="post">
		    				    
	                            <div class="form-group">
		    						<label for="interested">Looking for</label>
		    						<select data-validation="required" name="looking" id="looking" class="col-md-12 col-sm-12 col-xs-12">
		    							<option style="display:none" value="">Select</option>
		    							<option ng-repeat="looking in looking" value="{{ looking.letter }}">{{ looking.name }}</option>
		    						</select>
		    					</div>

		    					<div class="form-group">
		    						<label for="interested">Education</label>
		    						<select data-validation="required" name="education" id="education" class="col-md-12 col-sm-12 col-xs-12">
		    							<option style="display:none" value="">Select</option>
		    							<option ng-repeat="education in education" value="{{ education.letter }}">{{ education.name }}</option>
		    						</select>
		    					</div>
		    					
		    					<div class="form-group">
		    						<label for="interested">Smoking Habits</label>
		    						<select name="smoking" id="smoking" data-validation="required" class="col-md-12 col-sm-12 col-xs-12">
		    							<option style="display:none" value="">Select</option>
		    							<option ng-repeat="smoking in smoking" value="{{ smoking.letter }}">{{ smoking.name }}</option>
		    						</select>
		    					</div>
		    					
		    					<div class="form-group">
		    						<label for="interested">Drinking Habits</label>
		    						<select name="drinking" id="drinking" data-validation="required" class="col-md-12 col-sm-12 col-xs-12">
		    							<option style="display:none" value="">Select</option>
		    							<option ng-repeat="drinking in drinking" value="{{ drinking.letter }}">{{ drinking.name }}</option>
		    						</select>
		    					</div>
		    					
		    					<div class="form-group col-md-6 col-sm-6 col-xs-6" style="padding-left:0px">
		    						<label for="interested">Have Children</label>
		    						<select name="children-have" data-validation="required" id="have-children">
		    							<option style="display:none" value="">Select</option>
		    							<option ng-repeat="children in hasChildren" value="{{ children.letter }}">{{ children.name }}</option>
		    						</select>
		    					</div>
		    					
		    					<div class="form-group col-md-6 col-sm-6 col-xs-6" style="padding-right:0px">
		    						<label for="interested">Want Children</label>
		    						<select name="children-want" data-validation="required" id="want-children" >
		    							<option style="display:none" value="">Select</option>
		    							<option ng-repeat="children in children" value="{{ children.letter }}">{{ children.name }}</option>
		    						</select>
		    					</div>		    			

		    					<div class="form-group">
		    						<label for="interested">Annual Income</label>
		    						<select name="income" data-validation="required" id="income" class="col-md-12 col-sm-12 col-xs-12">
		    							<option style="display:none" value="">Select</option>
		    							<option ng-repeat="income in income" value="{{ income.letter }}">{{ income.name }}</option>
		    						</select>
		    					</div>
		    					
								<div class="clearfix"></div>
								
								<img class="center-block" src="images/ajax-loader.gif" ng-if="step3Loading"/>

		    					<button class="sign-up">Continue</button>
		    				
		    				</form>
		    				
		    			</div>
		    			
	    			</div>
	    			
	    			<p class="dot-nav-holder">
	    			
	    				<span class="round-button current"></span>
	    				<span class="round-button"></span>
	    				<span class="round-button"></span>
	    			
	    			</p>
	
	    			
	    		</div>
			
				<div id="upload-avatar" class="col-md-4 hidden">
					
					<div id="avatar-top" class="col-md-12">
						
						<div class="width-90">
						
							<h2 style="background-image: url('images/landing/red_text_mark.png');padding-left:50px;margin-left:-50px;">Choose Your Profile Photo<br /><span>Fun Photos Get More Views!</span></h2>
							<p>
                                Don't worry, you can always switch it later.
							</p>
							
							<p style="text-align: center; background-image: url(images/icons/ll_registration_ic_photo.png); width: 100px; height: 82px; display: block; position: relative; margin: auto; line-height: 82px;" class="image-loader">
								<img class="hidden" src="images/ajax-loader.gif" />
							</p>
							
							<form action="/videoProcessor/json_upload.epl" class="dropzone" id="my-awesome-dropzone"></form>
							
						</div>
						
					</div>
					
					<div class="avatar-bottom col-md-12">
												
						<div class="width-90">
						
						<p class="title">{{ userInfo.nickname }} <br /><span> {{ userInfo.age }}<!--, Toronto!--></span></p>
							
							
							<div class="devider-line"></div>
							
							<label>I'm a:</label>
							<p> {{ userInfo.gender }}</p>
							
							<label>Height:</label>
							<p>{{ userInfo.heightFt }}' {{ userInfo.heightIn }}</p>
							
							<label>Body Type:</label>
							<p>{{ userInfo.body }}</p>
							
							<label>Ethnicity:</label>
							<p>{{ userInfo.ethnicity }}</p>
							
							<label>Religion:</label>
							<p>{{ userInfo.religion }}</p>
							
							<label>DOB:</label>
							<p>{{ userInfo.dob }}</p>
							
							<label>Display Name:</label>
							<p>{{ userInfo.nickname }}</p>
						    
                            <label>Looking:</label>
							<p>{{ userInfo.looking }}</p>

							<label>Education:</label>
							<p>{{ userInfo.education }}</p>
							
							<label>Smoking Habits:</label>
							<p>{{ userInfo.smoking }}</p>
							
							<label>Drinking Habits:</label>
							<p>{{ userInfo.drinking }}</p>
							
							<label>Have Children:</label>
							<p>{{ userInfo.haveChildren }}</p>
							
							<label>Want Children:</label>
							<p>{{ userInfo.wantChildren }}</p>
							
							<label>Annual Income:</label>
							<p>{{ userInfo.income }}</p>
						
						</div>
						
					</div>
					
				</div>
			
			</div>
		
	    </section>
		
	</div>
	
	<div id="footer" class="hidden-sm hidden-xs">
		
		<footer class="container" style="min-width:300px !important;">
			<div class="col-md-1"></div>
			<div class="col-md-2">
				<img style="margin-top:40px;" src="images/landing/ll_logodotcom_footer.png" />
			</div>
			
			<div class="col-md-8">
				<p class="terms" style="text-transform:capitalize;">All images design and other intellectual materials and copyrights © 2015 Lavalife Ltd. All Rights Reserved. This is an adult service. By selecting any of the options above and/or creating your Lavalife profile, you are confirming that you are 18 years of age or older. 
				Please be sure you have read and agree to our <a href="privacy-policy.html" target="_blank">Privacy Policy</a> and <a href="terms-of-use.html" target="_blank">Terms of Use</a>.</p>
			</div>
			
			<div class="col-md-1"></div>
		</footer>
		
	</div>
	
	<div id="loader"></div>
	
	<div class="modal"  data-backdrop="static" id="location-modal"></div>
	
	<div id="fb-root"></div>
	
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="//ajax.googleapis.com/ajax/libs/jqueryui/1.11.0/jquery-ui.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/plugins.js"></script>
    <script src="js/app.js"></script>
    <script src="js/controllers.js"></script>
    <script src="js/functions.js"></script>
          
    <script type="text/javascript">
    	$("body").backstretch("images/spring/lavalife_bg_spring_2015.jpg");
    	
    	$( document ).ready(function() {
    		
            $('select').selectric({ 
                disableOnMobile: false 
            });
            dropThatSelect();
		});
		
		var io_operation = 'ioBegin';
		var io_bbout_element_id = 'ioBB';
		var io_install_stm = false;
		var io_install_flash = false;
		var io_exclude_stm  = 12; // don't use Active X on Vista or XP as they cause warnings on IE8
		var wsResponseForm;
			
		function redirectActiveX(){ document.location.href="explainActiveX.html"; }
			
		function redirectFlash(){ document.location.href = "http://www.macromedia.com/flash"; }
			
			  //var io_install_stm_error_handler = "redirectFlash();";
			
		var io_max_wait = 5000;
			
		var io_submit_form_id = wsResponseForm;
			
		var io_submit_element_id = 'submit1';
		
    </script>
    
    <script src="https://mpsnare.iesnare.com/snare.js"></script>
    <script src="js/cj-lavalife.js"></script>
  </body>
</html>
