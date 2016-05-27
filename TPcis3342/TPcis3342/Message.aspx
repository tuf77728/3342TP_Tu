<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="TPcis3342.Message" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Message Ok Baby!</title>

    <!--Bootstrap CSS-->
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/font-awesome.min.css" rel="stylesheet" />

    <!--Custom CSS-->
    <link href="Content/style.css" rel="stylesheet" />

    <!--Scripts-->
    <script src="Scripts/jquery-2.2.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/script.js"></script>
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

        <div class="container-fluid">
            <div class="row">
                <div class="col-md-1 col-xs-12">
                </div>
                <div class="col-md-10 col-xs-12">

                    <h2>*Your Inbox For Messages*</h2>

                    <asp:GridView ID="GVMessages" runat="server" AutoGenerateColumns="False" Width="785px" BackColor="White" BorderColor="#999999"
                        BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnSelectedIndexChanged="GVMessages_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <Columns>

  <asp:CommandField ButtonType="Button" HeaderText="Delete Review" ShowSelectButton="True" ></asp:CommandField>


                            <asp:BoundField DataField="RecordID" HeaderText="RecordID" />

                            <asp:BoundField DataField="SenderID" HeaderText="SenderID" />
                            <asp:BoundField DataField="SenderIDFirstName" HeaderText="Sender's First Name" />
                            <asp:BoundField DataField="SenderIDLastName" HeaderText="Sender's Last Name" />
                            <asp:BoundField DataField="MessageBody" HeaderText="MessageBody" />

                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <HeaderStyle BackColor="#A41E35" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />

                    </asp:GridView>

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
                    <div>
                        <h2>*Send A Friend A Message*</h2>
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
                                                    <asp:Label ID="lblUserID" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>

                                                    <%--                                                <asp:LinkButton ID="LinkButtonUserID" OnClick="LinkButtonUserID_Click" runat="server" Text='<%# Eval("UserID")%>'>'></asp:LinkButton>--%>
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
                                                    <asp:Label ID="lblFriendsWall" runat="server" Text="Write your message here:"></asp:Label></td>
                                            </tr>
                                            <tr>

                                                <td>
                                                    <asp:TextBox ID="txtMessageBody" runat="server" TextMode="MultiLine" Height="120px" Width="400px"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                        <div>
                                            <asp:Button ID="btnWriteOnWall" runat="server" Text="Send Message" CommandName="CmdbtnSendFriendAMessage" />
                                        </div>

                                    </td>

                                </tr>
                            </table>

                        </ItemTemplate>
                    </asp:Repeater>
                </div>

            </div>
        </div>

        <!--Page Content-->

        <%--<div class="chatBox">
            <div class="chatHead">Friends</div>
            <div class="chatBody">
                <div class="chatUser">Connor Skiro</div>
            </div>
        </div>
        <div class="messageBox" style="right: 290px">
            <div class="messageHead">
                Connor Skiro
                <div class="close">x</div>
            </div>
            <div class="messageWrap">
                <div class="messageBody">
                    <div class="messageInput">This is a test from User A</div>
                    <div class="messageInput2">This is a test from User B</div>
                    <div class="messageInsert"></div>
                </div>
                <div class="messageFooter">
                    <asp:TextBox ID="txtMessageInput" CssClass="messageInput" TextMode="MultiLine" Rows="4" Width="100%" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>--%>
    </form>
</body>
</html>
