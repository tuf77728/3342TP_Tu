<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateUserAccount.aspx.cs" Inherits="TPcis3342.CreateUserAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Account</title>

    <!--Bootstrap CSS-->
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/font-awesome.min.css" rel="stylesheet" />

    <!--Custom CSS-->
    <link href="Content/style.css" rel="stylesheet" />

    <!--Scripts-->
    <script src="Scripts/jquery-2.2.1.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
    <!--Navbar-->
    <nav class="navbar navbar-default" id="theNavbar">
        <div class="container-fluid">
            <div class="navbar-header">
                <a class="navbar-brand" id="theNavbarBrand" href="#" style="color: #fff">facebook</a>
            </div>
            <ul class="nav navbar-nav navbar-right">
                <li><a href="Login.aspx" style="color: #fff"><span class="glyphicon glyphicon-log-in"></span>Login</a></li>
            </ul>
        </div>
    </nav>
    <!--Jumbotron-->
    <div class="jumbotron">
        <h1>Sign Up</h1>
        <p>Please fill in all required fields with valid information.</p>
    </div>
    <!--Page Content-->
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div class="container-fluid">

            <div class="row">

                <div class="col-md-6 col-xs-12">
                    <h3 style="padding-left: 100px"><strong>Connect with friends and meet new people around the world.</strong></h3>
                    <br />
                    <div class="row">
                        <div class="col-xs-4">
                            <img style="padding-left: 100px" src="../IMG/news-feed.png" />
                        </div>
                        <div class=" col-xs-8">
                            <h3 style="padding-right: 50px">See photos and updates.</h3>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-4">
                            <img style="padding-left: 100px" src="../IMG/timeline.png" />
                        </div>
                        <div class="col-xs-8">
                            <h3 style="padding-right: 50px">Share what's new.</h3>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-4">
                            <img style="padding-left: 100px" src="../IMG/find-more.png" />
                        </div>
                        <div class=" col-xs-8">
                            <h3 style="padding-right: 50px">Discover your interests and more.</h3>
                        </div>
                    </div>
                </div>

                <div class="col-md-6 col-xs-12" style="padding-left: 90px">
                    <!--Sign Up-->
                    <h2>Sign Up</h2>
                    <div class="form-group">
                        <!--First Name-->
                        <asp:Label ID="lblFirstName" Text="First Name" runat="server"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                            <asp:TextBox ID="txtFirstName" CssClass="form-control" placeholder="First Name" runat="server"></asp:TextBox>
                        </div>
                        <asp:Label ID="lblFirstNameInfo" runat="server" Text="" Visible="false"></asp:Label>
                    </div>
                    <div class="form-group">
                        <!--Last Name-->
                        <asp:Label ID="lblLastName" Text="Last Name" runat="server"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                            <asp:TextBox ID="txtLastName" CssClass="form-control" placeholder="Last Name" runat="server"></asp:TextBox>
                        </div>
                        <asp:Label ID="lblLastNameInfo" runat="server" Text="" Visible="false"></asp:Label>
                    </div>
                    <div class="form-group">
                        <!--Email Address-->
                        <asp:Label ID="lblEmail" Text="Email Address" runat="server"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-envelope"></i></span>
                            <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="Email Address" runat="server"></asp:TextBox>
                        </div>
                        <asp:Label ID="lblEmailInfo" runat="server" Text="" Visible="false"></asp:Label>
                    </div>
                    <div class="form-group">
                        <!--Username-->
                        <asp:Label ID="lblUserName" Text="Username" runat="server"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                            <asp:TextBox ID="txtUserName" CssClass="form-control" placeholder="Username" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <!--Password-->
                        <asp:Label ID="lblPassWord" Text="Password" runat="server"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                            <asp:TextBox ID="txtPassWord" CssClass="form-control" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <!--Confirm Password-->
                        <asp:Label ID="lblConfirmPassWord" Text="Confirm Password" runat="server"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                            <asp:TextBox ID="txtConfirmPassword" TextMode="Password" CssClass="form-control" placeholder="Confirm Password" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>


                <div class="col-md-4 col-xs-12">
                    <!--Contact Information-->
                    <h2>Contact Information</h2>
                    <div class="form-group">
                        <!--Phone Number-->
                        <asp:Label ID="lblPhoneNumber" Text="Phone Number" runat="server"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-phone"></i></span>
                            <asp:TextBox ID="txtPhoneNumber" CssClass="form-control" placeholder="Phone Number" runat="server"></asp:TextBox>
                        </div>
                        <asp:Label ID="lblPhoneNumberInfo" runat="server" Text="" Visible="false"></asp:Label>
                    </div>

                    <div class="form-group">
                        <!--City-->
                        <asp:Label ID="lblCity" Text="City:" runat="server"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-home"></i></span>
                            <asp:TextBox ID="txtCity" CssClass="form-control" placeholder="City" runat="server"></asp:TextBox>
                        </div>
                        <asp:Label ID="lblCityInfo" runat="server" Text="" Visible="false"></asp:Label>

                    </div>

                    <div class="form-group">
                        <!--State-->
                        <asp:Label ID="lblState" Text="State:" runat="server"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-home"></i></span>
                            <asp:TextBox ID="txtState" CssClass="form-control" placeholder="State" runat="server"></asp:TextBox>
                        </div>
                        <asp:Label ID="lblStateInfo" runat="server" Text="" Visible="false"></asp:Label>

                    </div>

                    <div class="form-group">
                        <!--Address-->
                        <asp:Label ID="lblAddress" Text="Address" runat="server"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-home"></i></span>
                            <asp:TextBox ID="txtAddress" CssClass="form-control" placeholder="Address" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <!--Like-->
                        <asp:Label ID="lblLikes" Text="Things you like:" runat="server"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                            <asp:TextBox ID="txtLikes" CssClass="form-control" placeholder="List things you like:" runat="server"></asp:TextBox>
                        </div>
                        <asp:Label ID="lblLikesINFO" runat="server" Text="*Your items need to be separated by commas.*"></asp:Label>

                    </div>
                </div>

                <div class="col-md-4 col-xs-12">
                    <!--Security Information-->
                    <h2>Security Information</h2>
                    <div class="form-group">
                        <!--Security Question 1-->
                        <asp:Label ID="lblSecurityQuestionText1" Text="Choose a security question:" runat="server"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-question-sign"></i></span>
                            <asp:DropDownList ID="DropDownListQuestionSet1" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <!--Answer 1-->
                        <asp:Label ID="Label1" Text="Answer:" runat="server"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-info-sign"></i></span>
                            <asp:TextBox ID="txtQuestion1" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <!--Security Question 2-->
                        <asp:Label ID="lblSecurityQuestionText2" Text="Choose a security question:" runat="server"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-question-sign"></i></span>
                            <asp:DropDownList ID="DropDownListQuestionSet2" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <!--Answer 2-->
                        <asp:Label ID="Label2" Text="Answer:" runat="server"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-info-sign"></i></span>
                            <asp:TextBox ID="txtQuestion2" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <!--Security Question 3-->
                        <asp:Label ID="lblSecurityQuestionText3" Text="Choose a security question:" runat="server"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-question-sign"></i></span>
                            <asp:DropDownList ID="DropDownListQuestionSet3" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <!--Answer 3-->
                        <asp:Label ID="Label3" Text="Answer:" runat="server"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-info-sign"></i></span>
                            <asp:TextBox ID="txtQuestion3" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-xs-4">

                    <h3><strong>Login Settings</strong></h3>
                    <div class="form-group">
                        <div class="input-group">
                            <asp:RadioButtonList ID="radLoginPreferences" runat="server">
                                <asp:ListItem Value="1" Selected="True">None</asp:ListItem>
                                <asp:ListItem Value="2">Fast-login</asp:ListItem>
                                <asp:ListItem Value="3">Auto-login</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>


                    <h3><strong>Adjust Settings Now?</strong></h3>
                    <div class="form-group">
                        <!--Adjust Settings-->
                        <div class="input-group">
                            <asp:RadioButtonList ID="radAdjustSettingsNow" runat="server">
                                <asp:ListItem Value="1" Selected="True">No</asp:ListItem>
                                <asp:ListItem Value="2">Yes</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="container-fluid">
                        <div class="row">
                            <!--AJAX CONTROL-->
                            <asp:UpdateProgress runat="server" ID="PageUpdateProgress">
                                <ProgressTemplate>
                                    <div style="position: fixed; width: 100%; height: 100%; padding-left: 175px;">
                                        <img src="../IMG/ajax-spinner.gif" />
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:UpdatePanel runat="server" ID="Panel">
                                <ContentTemplate>
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-lg btn-primary btn-block" OnClick="btnSubmit_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <asp:Label ID="lblSubmitInfo" runat="server" Text="" Visible="false"></asp:Label>
                        </div>
                        <%--<div class="col-md-4">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="test button" OnClick="Button1_Click" />
                    <div>
                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>

                    </div>
                </div>--%>
                    </div>
                </div>
            </div>
        </div>


    </form>
</body>
</html>
