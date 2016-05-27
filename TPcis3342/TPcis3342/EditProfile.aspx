<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="TPcis3342.EditProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Profile</title>

    <!--Bootstrap CSS-->
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/font-awesome.min.css" rel="stylesheet" />

    <!--Custom CSS-->
    <link href="Content/style.css" rel="stylesheet" />

    <!--Scripts-->
    <script src="Scripts/jquery-2.2.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</head>

<body id="PageBody" runat="server">

    <form id="form1" runat="server">

        <!--Navbar-->
        <nav class="navbar navbar-default" id="theNavbar">
            <div class="container-fluid">
                <div class="navbar-header">
                    <a class="navbar-brand" id="theNavbarBrand" href="Home.aspx" style="color: #fff">facebook</a>
                </div>
                <ul class="nav navbar-nav">
                    <li><a href="Home.aspx" style="color: #fff">Home</a></li>
                    <li><a href="SearchForStuffPage.aspx" style="color: #fff">Search</a></li>
                    <li><a href="GeneralAccountSettings.aspx" style="color: #fff">Settings</a></li>
                    <li><a href="EditProfile.aspx" style="color: #fff">Profile</a></li>
                    <li><a href="Message.aspx" style="color: #fff">Message</a></li>
                    <li><a href="UploadPhotos.aspx" style="color: #fff">Upload</a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right" style="padding-top: 8px; padding-right: 10px;">
                    <asp:Button ID="btnLogout" CssClass="btn btn-primary" Text="Logout" runat="server" OnClick="btnLogout_Click1" />
                </ul>
            </div>
        </nav>
  <%--      <div id="customCalendar">
            <My:calendar runat="server" id="calendar" />
        </div>--%>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-4 col-xs-12">
                    <!--Contact Information-->
                    <h2>Contact Information</h2>
                </div>
                <div class="col-md-4 col-xs-12">
                </div>
                <div class="col-md-4 col-xs-12">
                    <h2>Security Questions</h2>
                </div>
            </div>

            <div class="row">

                <div class="col-md-4 col-xs-12" style="padding-left: 90px">

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
                        <!--Phone Number-->
                        <asp:Label ID="lblPhoneNumber" Text="Phone Number" runat="server"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-phone"></i></span>
                            <asp:TextBox ID="txtPhoneNumber" CssClass="form-control" placeholder="Phone Number" runat="server"></asp:TextBox>
                        </div>
                        <asp:Label ID="lblPhoneNumberInfo" runat="server" Text="" Visible="false"></asp:Label>
                    </div>

                    <div class="form-group">
                        <!--Address-->
                        <asp:Label ID="lblCity" Text="City:" runat="server"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-home"></i></span>
                            <asp:TextBox ID="txtCity" CssClass="form-control" placeholder="City" runat="server"></asp:TextBox>
                        </div>
                        <asp:Label ID="lblCityInfo" runat="server" Text="" Visible="false"></asp:Label>

                    </div>

                    <div class="form-group">
                        <!--Address-->
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


                </div>

                <div class="col-md-4 col-xs-12" style="padding-left: 90px">

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
                            <asp:TextBox ID="txtPassWord" CssClass="form-control" placeholder="Password" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <!--Confirm Password-->
                        <asp:Label ID="lblConfirmPassWord" Text="Confirm Password" runat="server"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                            <asp:TextBox ID="txtConfirmPassword" TextMode="Password" CssClass="form-control" placeholder="Confirm Password" runat="server"></asp:TextBox>
                        </div>
                        <asp:Label ID="lblPassWordConfim" runat="server" Text="" Visible="false"></asp:Label>
                    </div>

                    <div class="form-group">
                        <!--Confirm Password-->
                        <asp:Label ID="lblLikes" Text="Things you like:" runat="server"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                            <asp:TextBox ID="txtLikes" CssClass="form-control" placeholder="List things you like:" runat="server"></asp:TextBox>
                        </div>
                        <asp:Label ID="lblLikesINFO" runat="server" Text="*Your items need to be separated by commas.*"></asp:Label>

                    </div>

                </div>
                <div class="col-md-4 col-xs-12" style="padding-left: 90px">
                    <div class="form-group">
                        <!--Security Question 1-->
                        <asp:Label ID="lblSecurityQuestionText1" Text="Choose a security question:" runat="server"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-question-sign"></i></span>
                            <asp:Label ID="lblQuestion1" runat="server" Text=""></asp:Label>
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
                            <asp:Label ID="lblQuestion2" runat="server" Text=""></asp:Label>
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
                            <asp:Label ID="lblQuestion3" runat="server" Text=""></asp:Label>
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

                    <div class="form-group">
                        <asp:Label ID="Label4" Text="*Upload a profile picture here*" runat="server"></asp:Label>

                        <div>
                            <asp:FileUpload ID="fileUploadProfilePic" runat="server" />
                            <asp:Button ID="btnUploadProfilePic" runat="server" Text="Update Profile Picture" OnClick="btnUploadProfilePic_Click" />
                        </div>
                        <div>
                            <asp:Label ID="lblfileUploadProfilePic" runat="server" Text="" Visible="false"></asp:Label>
                        </div>

                    </div>


                </div>

            </div>
        </div>

        <div class="container-fluid">
            <div class="row">
                <div class="col-md-4">
                </div>
                <div class="col-md-4">
                </div>
                <div class="col-md-4">
                </div>
            </div>
        </div>

        <div class="container-fluid">
            <div class="row">
                <div class="col-md-4">
                </div>
                <div class="col-md-4">
                    <div>
                        <asp:Button ID="btnSubmitUpdate" runat="server" Text="Update Information" OnClick="btnSubmitUpdate_Click" />
                    </div>
                    <div>
                        <asp:Label ID="lblSubmitUpdate" runat="server" Text="" Visible="false"></asp:Label>
                    </div>

                </div>
                <div class="col-md-4">
                </div>
            </div>
        </div>
    </form>
</body>
</html>
