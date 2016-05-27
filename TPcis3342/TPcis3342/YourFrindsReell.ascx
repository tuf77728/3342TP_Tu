<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="YourFrindsReell.ascx.cs" Inherits="TPcis3342.YourFrindsReell" %>


<asp:ScriptManager ID="ScriptManagerReel" runat="server"></asp:ScriptManager>

<asp:UpdatePanel ID="UpdatePanelReel" runat="server">
    <ContentTemplate>
        <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>

        <div><h3>Some of the many faces on this site that you may know!</h3></div>
        <table style="border: 1px solid; background-color: #FFF7E7">
            <tr>
                <td style="width: 300px; height: 300px">
                    <asp:Image ID="profilePicture" ImageUrl="#" runat="server" Width="200px" />
                </td>
                <td style="width: 500px">

                    <table>
                        <tr>
                            <td>
                                <b>ID:</b>
                            </td>
                            <td>
                                <asp:Label ID="lblUserID" runat="server" Text=""></asp:Label>

                                <%--                                                <asp:LinkButton ID="LinkButtonUserID" OnClick="LinkButtonUserID_Click" runat="server" Text='<%# Eval("UserID")%>'>'></asp:LinkButton>--%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>First Name:</b>
                            </td>
                            <td>
                                <asp:Label ID="lblFirstName" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>Last Name:</b>
                            </td>
                            <td>
                                <asp:Label ID="lblLastName" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>City:</b>
                            </td>
                            <td>
                                <asp:Label ID="lblCity" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>State:</b>
                            </td>
                            <td>
                                <asp:Label ID="lblState" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>Likes:</b>
                            </td>
                            <td>
                                <asp:Label ID="lblLikes" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="TimerReel" EventName="Tick" />
    </Triggers>
</asp:UpdatePanel>

<asp:Timer ID="TimerReel" runat="server" Interval="1500" OnTick="Timer1_Tick"></asp:Timer>
