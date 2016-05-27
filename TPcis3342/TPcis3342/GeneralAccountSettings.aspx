<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeneralAccountSettings.aspx.cs" Inherits="TPcis3342.GeneralAccountSettings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>General Account Settings</title>

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


        <!--Jumbotron-->
        <div class="jumbotron">
            <h1>General Account Settings</h1>
        </div>
        <!--Login Settings-->
        <div class="col-md-3 col-xs-12">
            <h3><strong>Login Settings</strong></h3>
            <div class="form-group">
                <!--Login Preferences-->
                <asp:Label ID="lblLoginSettings" Text="Please choose a login preference:" runat="server"></asp:Label>
                <div class="input-group">
                    <asp:RadioButtonList ID="radLoginPreferences" runat="server">
                        <asp:ListItem Value="1" Selected="True">None</asp:ListItem>
                        <asp:ListItem Value="2">Fast-login</asp:ListItem>
                        <asp:ListItem Value="3">Auto-login</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
        </div>
        <!--Privacy Settings-->
        <div class="col-md-3 col-xs-12">
            <h3><strong>Privacy Settings</strong></h3>
            <p>Your privacy level determines who can view your information and content.</p>
            <div class="form-group">
                <asp:Label ID="lblPrivacyLevel" Text="Please select your level of privacy:" runat="server"></asp:Label>
                <div class="input-group">
                    <asp:RadioButtonList ID="radPrivacySettings" runat="server">
                        <asp:ListItem Value="1" Selected="True">Public</asp:ListItem>
                        <asp:ListItem Value="2">Friends only</asp:ListItem>
                        <asp:ListItem Value="3">Friends & Friends of friends</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
        </div>
        <!--Themes Settings-->
        <div class="col-md-3 col-xs-12">
            <h3><strong>Themes Settings</strong></h3>
            <!--Font Type-->
            <div class="form-group">
                <asp:Label ID="lblFontTypeSettings" Text="Please select the font type that you'd like to use:" runat="server"></asp:Label>
                <div class="input-group">
                    <asp:DropDownList ID="ddlFontTypes" CssClass="form-control" runat="server" Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddlFontTypes_SelectedIndexChanged">
                        <%--                        <asp:ListItem>Font type</asp:ListItem>--%>
                        <asp:ListItem Value="1">Serif</asp:ListItem>
                        <asp:ListItem Value="2">Sans-Serif</asp:ListItem>
                        <asp:ListItem Value="3">Monospace</asp:ListItem>
                        <asp:ListItem Value="4">Fantasy</asp:ListItem>
                        <asp:ListItem Value="5">Script</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!--Font Color-->
            <div class="form-group">
                <asp:Label ID="lblFontColorSettings" Text="Please select the font color that you'd like to use:" runat="server"></asp:Label>
                <div class="input-group">
                    <asp:DropDownList ID="ddlFontColors" CssClass="form-control" runat="server" Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddlFontColors_SelectedIndexChanged">
                        <%--                        <asp:ListItem>Font color</asp:ListItem>--%>
                        <asp:ListItem Value="1">Black</asp:ListItem>
                        <asp:ListItem Value="2">Red</asp:ListItem>
                        <asp:ListItem Value="3">Green</asp:ListItem>
                        <asp:ListItem Value="4">Blue</asp:ListItem>
                        <asp:ListItem Value="5">Yellow</asp:ListItem>
                        <asp:ListItem Value="6">Cyan</asp:ListItem>
                        <asp:ListItem Value="7">Pink</asp:ListItem>
                        <asp:ListItem Value="8">White</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!--Background Color-->
            <div class="form-group">
                <asp:Label ID="lblBackgroundColorSettings" Text="Please select the background color that you'd like to use:" runat="server"></asp:Label>
                <div class="input-group">
                    <asp:DropDownList ID="ddlBackgroundColors" CssClass="form-control" runat="server" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlBackgroundColors_SelectedIndexChanged">
                        <%--                        <asp:ListItem>Background color</asp:ListItem>--%>
                        <asp:ListItem Value="1">Facebook</asp:ListItem>
                        <asp:ListItem Value="2">Red</asp:ListItem>
                        <asp:ListItem Value="3">Green</asp:ListItem>
                        <asp:ListItem Value="4">Blue</asp:ListItem>
                        <asp:ListItem Value="5">Yellow</asp:ListItem>
                        <asp:ListItem Value="6">Cyan</asp:ListItem>
                        <asp:ListItem Value="7">Pink</asp:ListItem>
                        <asp:ListItem Value="8">White</asp:ListItem>
                        <asp:ListItem Value="9">Black</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!--Pre-Configured Themes-->
            <div class="form-group">
                <asp:Label ID="lblThemesSettings" Text="Please select a theme that you'd like to use:" runat="server"></asp:Label>
                <div class="input-group">
                    <asp:DropDownList ID="ddlThemes" CssClass="form-control" runat="server" Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddlThemes_SelectedIndexChanged">
                        <asp:ListItem Value="">Theme</asp:ListItem>
                        <asp:ListItem Value="1">Dark</asp:ListItem>
                        <asp:ListItem Value="2">Light</asp:ListItem>
                        <asp:ListItem Value="3">Christmas</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="col-xs-3">
            <h3>Email Settings</h3>
            <asp:CheckBoxList ID="checkListEmailSettings" runat="server">
                <asp:ListItem>Friend Request</asp:ListItem>
                <asp:ListItem>Wall Posts</asp:ListItem>
                <asp:ListItem>Likes</asp:ListItem>
                <asp:ListItem>Updates</asp:ListItem>
            </asp:CheckBoxList>

            <div class="form-group">
            <div class="row" style="padding-left: 15px">
                <br />
                <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-lg btn-primary" runat="server" OnClick="btnSave_Click" />
                &nbsp;
               <%-- <a href="Home.aspx" style="font-size: 16px">Skip</a>--%>
            </div>
        </div>
        </div>
        <div>
            <asp:Label ID="lblSaveINFO" runat="server" Text="" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>
