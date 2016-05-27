<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="TPcis3342.LogIn" %>

<%@ Register Src="~/footer.ascx" TagName="footer" TagPrefix="Tfooter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>

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
    <!--Navbar-->
    <nav class="navbar navbar-default" id="theNavbar">
        <div class="container-fluid">
            <div class="navbar-header">
                <a class="navbar-brand" id="theNavbarBrand" href="#" style="color: #fff">facebook</a>
            </div>
        </div>
    </nav>
    <!--Page Content-->
    <form id="form1" runat="server">
        <!--Script Manager-->
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <!--Login Form-->
        <div class="form-signin">
            <div class="col-xs-8 col-xs-offset-2" style="padding-top: 100px">
                <h2 class="form-signin-heading">Please log in</h2>
                <asp:Label ID="lblGreetings" runat="server" Text="" Visible="false"></asp:Label>
                <div class="form-group" style="height:40px">
                    <asp:Button ID="btnNotMe" CssClass="btn btn-warning" runat="server" Text="This Is Not Me" Visible="false" OnClick="btnNotMe_Click" />
                </div>
                <div class="form-group">
                    <asp:Label ID="lblUserName" Text="UserName" runat="server"></asp:Label>
                    <asp:TextBox ID="txtUserName" CssClass="form-control" placeholder="Username" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUserName" ErrorMessage="Username is required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </>
                <div class="form-group">
                    <asp:Label ID="lblPassword" Text="Password" runat="server"></asp:Label>
                    <asp:TextBox ID="txtPassWord" CssClass="form-control" placeholder="Password" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassWord" ErrorMessage="Password is required!" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
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
                            <asp:Button ID="btnSignIn" CssClass="btn btn-lg btn-primary btn-block" Text="Log in" OnClick="btnSignIn_Click" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>


                    <!--Encrypt/Decrypt Test-->
                    <div class="form-group">
                        <asp:Label ID="lblLoginInfo" runat="server" Text="" Visible="false"></asp:Label>
                    </div>
                    <div>
                        <br />
                        <p><a href="PreferencesSettings.aspx">Forgot email or password?</a></p>
                        <p>Don't have an account? Create one <a href="CreateUserAccount.aspx">here</a></p>
                    </div>
                    </>
                </div>
                <%--<div class="form-group">
                    <div>
                        <asp:Label ID="Label1" runat="server" Text="encrypt:"></asp:Label><asp:TextBox ID="txtencrypt" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblencrypt" runat="server" Text=""></asp:Label>
                    </div>
                    <asp:Button ID="btnEncrypt" runat="server" Text="encrypt" OnClick="btnEncrypt_Click" />
                    <br />
                    <br />

                    <div>
                        <asp:Label ID="Label2" runat="server" Text="decrypt:"></asp:Label><asp:TextBox ID="txtdecrypt" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lbldecrypt" runat="server" Text=""></asp:Label>
                    </div>
                    <asp:Button ID="btnDecrypt" runat="server" Text="decrypt" OnClick="btnDecrypt_Click" />
                </div>--%>
            </div>
        </div>
        <!--Custom Control Footer-->
        <div class="col-xs-8 col-xs-offset-2">
            <div id="customFooter">
                <Tfooter:footer ID="footer1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
