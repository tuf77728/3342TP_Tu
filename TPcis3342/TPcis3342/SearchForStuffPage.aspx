<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchForStuffPage.aspx.cs" Inherits="TPcis3342.SearchForStuffPage" %>

<%@ Register Src="~/YourFrindsReell.ascx" TagPrefix="uc1" TagName="YourFrindsReell" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Search</title>

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

        <br />
        <br />

        <div class="container-fluid">
            <div class="row">
                <div class="col-xs-8 col-xs-offset-2" >
                    <uc1:YourFrindsReell runat="server" ID="YourFrindsReell" />
                </div>
             
              
            </div>
        </div>

        <div class="container">

            <div class="row">
                <div class="col-md-5 col-xs-12">
                    <div>
                        <asp:Label ID="lblOtherPeopleRequests" runat="server" Text="People Who Sent You A Friend Request"></asp:Label>
                    </div>
                    <asp:GridView ID="GVotherPeopleRequests" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnSelectedIndexChanged="GVotherPeopleRequests_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="UserFriendID" HeaderText="UserFriendID:" />
                            <asp:BoundField DataField="Friend1" HeaderText="Sender's UserID:" />
                            <asp:BoundField DataField="Friend1FirstName" HeaderText="Sender's First Name:" />
                            <asp:BoundField DataField="Friend1LastName" HeaderText="Sender's Last Name" />
                            <asp:BoundField DataField="Status" HeaderText="Friend Status" />

                            <%--<asp:TemplateField HeaderText="Delete Request">
                                <ItemTemplate>
                                    <asp:Button ID="btnDeleteFriendRequest" runat="server" Text="Delete" />
                                </ItemTemplate>   
                            </asp:TemplateField>--%>

                            <asp:CommandField ButtonType="Button" HeaderText="Friend/Unfriend" ShowSelectButton="True" SelectText="Friend/Unfriend"></asp:CommandField>


                        </Columns>

                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                        <SortedDescendingHeaderStyle BackColor="#002876" />

                    </asp:GridView>
                    <div>
                        <asp:Label ID="lblConfirmOrNot" runat="server" Text="" Visible="false"></asp:Label>
                    </div>
                </div>
                <div class="col-md-5 col-xs-12">
                    <div>
                        <asp:Label ID="lblGVfrindsHeader" runat="server" Text="Friend Requests That You Sent Out"></asp:Label>
                    </div>
                    <asp:GridView ID="GVfriendRequestStatus" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnSelectedIndexChanged="GVfriendRequestStatus_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="UserFriendID" HeaderText="UserFriendID:" />
                            <asp:BoundField DataField="Friend2" HeaderText="Friend's UserID:" />
                            <asp:BoundField DataField="FirstName" HeaderText="Friend's First Name:" />
                            <asp:BoundField DataField="LastName" HeaderText="Friend's Last Name" />
                            <asp:BoundField DataField="Status" HeaderText="Friend Status" />

                            <%--<asp:TemplateField HeaderText="Delete Request">
                                <ItemTemplate>
                                    <asp:Button ID="btnDeleteFriendRequest" runat="server" Text="Delete" />
                                </ItemTemplate>   
                            </asp:TemplateField>--%>

                            <asp:CommandField ButtonType="Button" HeaderText="Delete Friend Request" ShowSelectButton="True" SelectText="Delete Friend Request"></asp:CommandField>


                        </Columns>

                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                        <SortedDescendingHeaderStyle BackColor="#002876" />

                    </asp:GridView>
                    <div>
                        <asp:Label ID="lblDeleteRequestINFO" runat="server" Text="" Visible="false"></asp:Label>
                    </div>
                </div>

            </div>
        </div>

        <br />
        <br />

        <div class="container">
            <div class="row">
                <div class="col-md-3 col-xs-12">
                    <div>
                        <asp:Label ID="lblFirstNameSearch" runat="server" Text="First Name:"></asp:Label>
                        <asp:TextBox ID="txtFirstNameSearch" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-3 col-xs-12">
                    <div>
                        <asp:Label ID="lblLastNameSearch" runat="server" Text="Last Name:"></asp:Label>
                        <asp:TextBox ID="txtLastNameSearch" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-3 col-xs-12">
                    <div>
                        <asp:Label ID="lblCitySearch" runat="server" Text="City:"></asp:Label>
                        <asp:TextBox ID="txtCitySearch" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblStateSearch" runat="server" Text="State:"></asp:Label>
                        <asp:TextBox ID="txtStateSearch" runat="server"></asp:TextBox>
                    </div>

                </div>
                <div class="col-md-3 col-xs-12">
                    <div>
                        <asp:Label ID="lblLikesSearch" runat="server" Text="Likes:"></asp:Label>
                        <asp:TextBox ID="txtLikesSearch" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 col-xs-12">
                </div>
                <div class="col-md-4 col-xs-12">
                    
                    <div>
                        <asp:Button ID="btnSearch" runat="server" Text="Run Search" OnClick="btnSearch_Click" />
                        <asp:Label ID="lblSearch" runat="server" Text="" Visible="false"></asp:Label>
                    </div>
                    <div>
                        <asp:Button ID="btnShowAllUsers" runat="server" Text="Show All Users" OnClick="btnShowAllUsers_Click" />
<%--                        <asp:Button ID="btnHideAllUsers" runat="server" Text="Hide All Users" Visible="false" OnClick="btnHideAllUsers_Click" />--%>
                    </div>
                </div>
                <div class="col-md-4 col-xs-12">
                </div>
            </div>
        </div>

        <br />
        <br />


        <div class="container-fluid">
            <div class="row">
                <div class="col-md-1 col-xs-12">
                </div>
                <div class="col-md-10 col-xs-12">
                    <div>
                        <asp:Repeater ID="SearchResultsRepeater" runat="server" OnItemCommand="SearchResultsRepeater_ItemCommand">
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
                                                        <asp:Label ID="lblUserIDSearchGV" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                                                    </td>
                                                </tr>


                                                <tr>
                                                    <td>
                                                        <b>First Name:</b>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblFirstNameSearchGV" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                        <b>Last Name:</b>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblLastNameSearchGV" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <b>City:</b>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("City") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <b>State:</b>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("State") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <b>Likes:</b>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Likes") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 200px">
                                            <asp:Button ID="btnAddFriend" runat="server" Text="Add Friend" CommandName="CmdbtnbtnAddFriendSearchGV" />
                                        </td>
                                       <%-- <td style="width: 400px">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblMessage" runat="server" Text="Message:"></asp:Label></td>
                                                </tr>
                                                <tr>

                                                    <td>
                                                        <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Height="120px" Width="200px"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                            <div>
                                                <asp:Button ID="btnSendMessage" runat="server" Text="Send Message" CommandName="CmdbtnSendMessageSearchGV" />
                                            </div>

                                        </td>--%>
                                    </tr>
                                </table>

                            </ItemTemplate>

                        </asp:Repeater>

                    </div>
                </div>
                <div class="col-md-1 col-xs-12">
                </div>
            </div>
        </div>

        <div class="container-fluid">
            <div class="row">
                <div class="col-md-1 col-xs-12">
                </div>
                <div class="col-md-10 col-xs-12">
                    
                    <asp:Repeater ID="AllUsersRepeater" runat="server" Visible="false" OnItemCommand="AllUsersRepeater_ItemCommand">
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
                                                    <asp:Label ID="lblUserID" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
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

                                    <td style="width: 150px">
                                        <asp:Button ID="btnAddFriend" runat="server" Text="Add Friend" CommandName="CmdbtnbtnAddFriend" />
                                    </td>
                                    <%--<td style="width: 350px">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblMessage" runat="server" Text="Message:"></asp:Label></td>
                                            </tr>
                                            <tr>

                                                <td>
                                                    <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Height="120px" Width="350px"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                        <div>
                                            <asp:Button ID="btnSendMessage" runat="server" Text="Send Message" CommandName="CmdbtnSendMessage" />
                                        </div>

                                    </td>--%>
                                </tr>
                            </table>

                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="col-md-1 col-xs-12">
                </div>
            </div>
        </div>

        <div class="container-fluid">
            <div class="row">
                <div class="col-md-4 col-xs-12">
                </div>
                <div class="col-md-4 col-xs-12">
<%--                    <asp:Label ID="txtDisplay" runat="server" Text="test!"></asp:Label>--%>
                </div>
                <div class="col-md-4 col-xs-12">
                </div>
            </div>
        </div>

    </form>
</body>
</html>
