<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadPhotos.aspx.cs" Inherits="TPcis3342.UploadPhotos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Upload Photos</title>

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
                    <asp:Button ID="btnLogout" CssClass="btn btn-primary" Text="Logout" runat="server" OnClick="btnLogout_Click" />
                </ul>
            </div>
        </nav>

        <!--Jumbotron-->
        <div class="jumbotron">
            <h1>Upload photos!</h1>
            <p>Click the upload button and select photos to upload, create albums and more!</p>
        </div>
        <!--Page Content-->
        <div class="col-xs-4">
            <asp:Label ID="lblStatus" Text="" runat="server"></asp:Label>
            <div class="form-group">
                <asp:Label ID="lblAlbumName" Text="Album name" runat="server"></asp:Label>
                <asp:TextBox ID="txtAlbumName" CssClass="form-control" placeholder="Album name" runat="server"></asp:TextBox>
            </div>

            <%--<div class="form-group">
                <asp:Label ID="lblAlbums" Text="Choose an album:" runat="server"></asp:Label>
                <div class="row">
                    <asp:DropDownList ID="ddlAlbums" CssClass="form-control" Width="180px" runat="server">
                        <asp:ListItem>Choose an album</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                    <asp:Button ID="btnCreateAlbum" CssClass="btn btn-success" Text="Add Album" data-toggle="modal" data-target="#myModal" runat="server" />
                </div>
                <!-- Modal -->
                <div id="myModal" class="modal fade" role="dialog">
                    <div class="modal-dialog">
                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Create an album</h4>
                            </div>
                            <div class="modal-body">
                                <p>Create your own album title.</p>
                                <asp:TextBox ID="txtAlbumTitle" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvAlbumTitle" runat="server" ControlToValidate="txtAlbumTitle" ErrorMessage="Oops, you forgot to add an album title!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                                <asp:Button ID="btnAddAlbum" Text="Add Album" CssClass="btn btn-success" runat="server" ValidationGroup="AddAlbum" OnClick="btnAddAlbum_Click"/> 
                            </div>
                        </div>

                    </div>
                </div>--%>
        </div>
        <div class="form-group" style="padding-left: 10px">
            <asp:Label ID="lblTitle" Text="Title:" runat="server"></asp:Label>
            <asp:TextBox ID="txtTitle" CssClass="form-control" placeholder="Enter title here" Width="180px" runat="server"></asp:TextBox>
         <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                ControlToValidate="txtTitle" ErrorMessage="Oops, looks like you forgot to add a title, please try again!" ForeColor="Red">
            </asp:RequiredFieldValidator>--%>
        </div>
        <div class="form-group" style="padding-left: 10px">
            <asp:Label ID="lblDescription" Text="Description:" runat="server"></asp:Label>
            <asp:TextBox ID="txtDescription" CssClass="form-control" placeholder="Enter description here" TextMode="MultiLine" Rows="5" Width="180px" runat="server"></asp:TextBox>
     <%--       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                ControlToValidate="txtDescription" ErrorMessage="Oops, looks like you forgot to add a description, please try again!" ForeColor="Red">
            </asp:RequiredFieldValidator>--%>
        </div>
        <div class="form-group" style="padding-left: 10px">
            <asp:Label ID="lblImage" Text="Image:" runat="server"></asp:Label>
            <asp:FileUpload ID="fileUpload" Width="280px" runat="server" />
    <%--        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="fileUpload" ErrorMessage="Oops, looks like did not select an image, please try again!" ForeColor="Red">
            </asp:RequiredFieldValidator>--%>
        </div>
        <div class="form-group" style="padding-left: 10px">
            <asp:Button ID="btnUpload" CssClass="btn btn-lg btn-primary" Text="Upload" runat="server" OnClick="btnUpload_Click" />
        </div>

        <div class="col-xs-8">
            <div>
                <h3>All Your Photos</h3>
            </div>
            <asp:Repeater ID="GVallYourPictures" runat="server" Visible="true" OnItemCommand="GVallYourPictures_ItemCommand">
                <ItemTemplate>
                    <table style="border: 1px solid; background-color: #FFF7E7">
                        <tr>
                            <td style="width: 200px">
                                <asp:Image ID="Image1" ImageUrl='<%# Eval("ImageURL") %>' runat="server" Width="200px" />
                            </td>
                            <td style="width: 450px">

                                <table>
                                    <tr>
                                        <td>
                                            <b>Image Id:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblImageId" runat="server" Text='<%# Eval("ImageId") %>'></asp:Label>

                                            <%--                                                <asp:LinkButton ID="LinkButtonUserID" OnClick="LinkButtonUserID_Click" runat="server" Text='<%# Eval("UserID")%>'>'></asp:LinkButton>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Title:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Image Description:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblImageDescription" runat="server" Text='<%# Eval("ImageDescription") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Username:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblUsername" runat="server" Text='<%# Eval("Username") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>State:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAlbum_ID" runat="server" Text='<%# Eval("Album_ID") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    
                                </table>
                            </td>
                            <td style="width: 400px">

                                <div>
                                    <asp:Button ID="btnDeletePhoto" runat="server" Text="Delete Photo" CommandName="CmdbtnDeletePhoto" />
                                </div>

                            </td>

                        </tr>
                    </table>

                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
