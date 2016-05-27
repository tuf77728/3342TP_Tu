<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TPcis3342.Home" %>

<%@ Register Src="~/YourFrindsReell.ascx" TagPrefix="uc1" TagName="YourFrindsReell" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home ok</title>

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

        <!--Jumbotron-->
        <div class="jumbotron">
            <h1>Welcome to Facebook!</h1>
        </div>
        <!--AJAX Pictures-->
        <div class="col-xs-12">
            <div class="row">

                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ViewStateMode="Enabled">
                    <ContentTemplate>
                        <asp:Image ID="imgAJAX" runat="server" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:Timer ID="Timer1" Interval="3000" runat="server" OnTick="Timer1_Tick"></asp:Timer>

            </div>
        </div>

        <div class="container-fluid">
            <div class="row">
                <div class="col-md-3">
                    <table>
                        <tr>
                            <td>Welcome Back </td>
                            <td>
                                <asp:Label ID="lblFirstName" runat="server" Text=""></asp:Label></td>
                        </tr>
                    </table>
                </div>
                <div class="col-md-3">
                </div>
                <div class="col-md-3"></div>
                <div class="col-md-3">
                </div>
            </div>
        </div>

        <br />

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

        <br />
        <br />

        <div class="container-fluid">
            <div class="row">
                <div class="col-md-6 col-xs-12">
                    <div>
                        <asp:Label ID="Label1" runat="server" Text="Your Wall"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="txtYourWall" runat="server" Height="200px" TextMode="MultiLine" Width="650px"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-xs-12">
                    <div>
                        <asp:Label ID="Label2" runat="server" Text="Your News Feed"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="txtNewsFeed" runat="server" Height="200px" TextMode="MultiLine" Width="650px"></asp:TextBox>
                    </div>
                </div>
            </div>

            <br />
            <br />
            <div class="col-md-10 col-xs-12">
                <div>All Your Friends In The System</div>
                <div>
                    <asp:Label ID="lblNewsFeedInfo" runat="server" Text=""></asp:Label>
                </div>
                <div>
                    <asp:Button ID="btnShowAllUsers" runat="server" Text="Show All Your Friend List" Visible="false" OnClick="btnShowAllUsers_Click" />
                    <asp:Button ID="btnHideAllUsers" runat="server" Text="Hide All Your Friend List" Visible="true" OnClick="btnHideAllUsers_Click" />

                </div>
                <div>
                    <h2>*To view a friend's profile, click on the ID, which will be a "Link Button".*</h2>
                </div>
                <asp:Repeater ID="YourFrindListRepeater" runat="server" Visible="true" OnItemCommand="AllUsersRepeater_ItemCommand">
                    <ItemTemplate>
                        <table style="border: 1px solid; background-color: #FFF7E7">
                            <tr>
                                <td style="width: 200px">
                                    <asp:Image ID="Image1" ImageUrl='<%# Eval("PhotoPath") %>' runat="server" Width="200px" />
                                </td>
                                <td style="width: 450px">

                                    <table>
                                        <tr>
                                            <td>
                                                <b>ID:</b>
                                            </td>
                                            <td>
                                                <%--                                                <asp:Label ID="lblUserID" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>--%>

                                                <asp:LinkButton ID="LinkButtonUserID" OnClick="LinkButtonUserID_Click" runat="server" Text='<%# Eval("UserID")%>'>'></asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>First Name:</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>Last Name:</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>City:</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblCity" runat="server" Text='<%# Eval("City") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>State:</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblState" runat="server" Text='<%# Eval("State") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>Likes:</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblLikes" runat="server" Text='<%# Eval("Likes") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 400px">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblFriendsWall" runat="server" Text="Friend's Wall:"></asp:Label></td>
                                        </tr>
                                        <tr>

                                            <td>
                                                <asp:TextBox ID="txtFriendsWall" runat="server" TextMode="MultiLine" Height="120px" Width="400px"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                    <div>
                                        <asp:Button ID="btnWriteOnWall" runat="server" Text="Write On Wall" CommandName="CmdbtnWriteOnFriendsWall" />
                                    </div>

                                </td>

                            </tr>
                        </table>

                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="col-md-1">
            </div>
        </div>

    </form>
</body>
</html>
