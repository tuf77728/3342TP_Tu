<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreferencesSettings.aspx.cs" Inherits="TPcis3342.PreferencesSettings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Password Recovery</title>

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
                </ul>
                <ul class="nav navbar-nav navbar-right" style="padding-top: 8px; padding-right: 10px;">
                    <asp:Button ID="btnLogout" CssClass="btn btn-primary" Text="Login" runat="server" OnClick="btnLogout_Click" />
                </ul>
            </div>
        </nav>
        <!--Page Content-->
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-3">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblEmailAddress" runat="server" Text="Email Address:"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtEmailAddress" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnFindAccount" runat="server" Text="Find Account" OnClick="btnFindAccount_Click" /></td>
                        </tr>
                    </table>
                    <div>
                        <asp:Label ID="lblFindAccountInfo" runat="server" Text="" Visible="false"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row">

                <div class="col-md-10">
                    <div>
                        <asp:Label ID="lblGreetingUserName" runat="server" Text="" Visible="false"></asp:Label>
                    </div>

                    <asp:GridView ID="GridViewSecurityQuestions" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Security1Question" HeaderText="Security Question 1:" />
                            <asp:TemplateField HeaderText="Answer:">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAnswer1" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="Security2Question" HeaderText="Security Question 2:" />
                            <asp:TemplateField HeaderText="Answer:">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAnswer2" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="Security3Question" HeaderText="Security Question 3:" />
                            <asp:TemplateField HeaderText="Answer:">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAnswer3" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div>
                        <asp:Button ID="btnSumbitAnswers" runat="server" Text="Button" Visible="false" OnClick="btnSumbitAnswers_Click" />
                    </div>
                    <div>
                        <asp:Label ID="lblSumbitAnswersInfo" runat="server" Text="" Visible="false"></asp:Label>
                    </div>
                </div>

                <div class="col-md-2">
                </div>
            </div>
        </div>



        <div class="container-fluid">
            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-4">

                    <div>
                        <asp:Label ID="lblCredentials" runat="server" Text="Your Login Credentials Linked To Email Address " Visible="false"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblUsername" runat="server" Text="Your user name is " Visible="false"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblUserPassword" runat="server" Text="Your pass word is " Visible="false"></asp:Label>
                    </div>
                </div>
                <div class="col-md-4"></div>
            </div>
        </div>
    </form>
</body>
</html>
