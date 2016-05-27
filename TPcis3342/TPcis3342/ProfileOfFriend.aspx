<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfileOfFriend.aspx.cs" Inherits="TPcis3342.ProfileOfFriend" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Friend's Profile Page</title>

    <!--Bootstrap CSS-->
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/font-awesome.min.css" rel="stylesheet" />

    <!--Custom CSS-->
    <link href="Content/style.css" rel="stylesheet" />

    <!--Scripts-->
    <script src="Scripts/jquery-2.2.1.min.js"></script>
    <script src="Scripts/jquery.validate.unobtrusive.bootstrap.js"></script>
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
                <%--<ul class="nav navbar-nav">
                    <li><a href="Home.aspx" style="color: #fff">Home</a></li>
                    <li><a href="SearchForStuffPage.aspx" style="color: #fff">Search</a></li>
                    <li><a href="GeneralAccountSettings.aspx" style="color: #fff">Settings</a></li>
                    <li><a href="EditProfile.aspx" style="color: #fff">Profile</a></li>
                    <li><a href="Message.aspx" style="color: #fff">Message</a></li>
                    <li><a href="UploadPhotos.aspx" style="color: #fff">Upload</a></li>
                </ul>--%>
                <ul class="nav navbar-nav navbar-right" style="padding-top: 8px; padding-right: 10px;">
                    <asp:Button ID="btnLogout" CssClass="btn btn-primary" Text="Logout" runat="server" OnClick="btnLogout_Click1" />
                </ul>
            </div>
        </nav>

        <div class="container">
            <div class="row">
          
                <div class="col-md-3 col-xs-12">
                    <asp:Label ID="lblGreetings" runat="server" Text=""></asp:Label>
                    <div>
                        <asp:Button ID="btnToHomePage" runat="server" Text="*Go Back To HomePage*" OnClick="btnToHomePage_Click" />
                    </div>
                </div>
                <div class="col-md-3 col-xs-12">
                    <div>
                        <asp:Image ID="imgUserProfilePic" runat="server" Height="250px"
                            ImageUrl="#"
                            Width="200px" />
                    </div>
                </div>
                <div class="col-md-6 col-xs-12">
                    <div>
                        <asp:Label ID="Label1" runat="server" Text="First Name: "></asp:Label><asp:Label ID="lblFirstName" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="Label2" runat="server" Text="Last Name: "></asp:Label><asp:Label ID="lblLastName" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="Label7" runat="server" Text="City: "></asp:Label><asp:Label ID="lblCity" runat="server" Text=""></asp:Label>
                        <div>
                        <asp:Label ID="Label9" runat="server" Text="State: "></asp:Label><asp:Label ID="lblState" runat="server" Text=""></asp:Label>
                    </div>

                    </div>
                    <div>
                        <asp:Label ID="Label3" runat="server" Text="Address: "></asp:Label><asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="Label4" runat="server" Text="Phone Number: "></asp:Label><asp:Label ID="lblPhoneNumber" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="Label5" runat="server" Text="Email Address: "></asp:Label><asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="Label6" runat="server" Text="Likes: "></asp:Label><asp:Label ID="lblLikes" runat="server" Text=""></asp:Label>
                    </div>

                </div>
            </div>
        </div>

        <div class="container">
            <div class="row">
                <div class="col-md-4 col-xs-12">
                    <div>
                        <asp:Label ID="lblWall" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="txtFrindsWall" runat="server" Height="200px" TextMode="MultiLine" Width="650px"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4 col-xs-12">

                </div>
                <div class="col-md-4 col-xs-12">
                </div>
            </div>
        </div>

        <div class="container-fluid">
            <div class="row">
                <div class="col-md-3 col-xs-12">
                </div>
                <div class="col-md-3 col-xs-12">

                </div>
                <div class="col-md-3 col-xs-12">
                </div>
            </div>
        </div>

        <div class="container-fluid">
            <div class="row">
                <div class="col-md-3 col-xs-12">
                </div>
                <div class="col-md-3 col-xs-12">
                </div>
                <div class="col-md-3 col-xs-12">
                </div>
            </div>
        </div>
    </form>
</body>
</html>
