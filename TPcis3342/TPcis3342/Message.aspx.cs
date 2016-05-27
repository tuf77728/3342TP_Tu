using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FaceBookHelper;
using Utilities;
using System.Collections;
using System.Data;

namespace TPcis3342
{
    public partial class Message : System.Web.UI.Page
    {
        DBConnect objDb = new DBConnect();
        HttpCookie myCookie;
        FaceBookHelper.DataBaseRequest objDBhelper = new DataBaseRequest();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["CIS3342_Cookie"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                myCookie = Request.Cookies["CIS3342_Cookie"];

            }

            if (!IsPostBack)
            {
                FillALlRecordsFromGetUserFriendsTable();
                GetAllMyMesages();
            }

            if (Request.Cookies["CIS3342_CookieCustom"] != null)
            {
                SetCustomSetting();
            }
            
        }
        public void SetCustomSetting()
        {
            HttpCookie cookieE = Request.Cookies["CIS3342_CookieCustom"];

            String backgroundColors = cookieE.Values["backgroundColors"].ToString();
            //String fontColors = cookieE.Values["fontColors"].ToString();
            //String fontTypes = cookieE.Values["fontTypes"].ToString();
            //String theme = cookieE.Values["themes"].ToString();

            //PageBody.Attributes.Add("style", fontColors);
            //PageBody.Attributes.Add("style", fontTypes);
            PageBody.Attributes.Add("style", backgroundColors);

            //if (backgroundColors != "")
            //{
            //    PageBody.Attributes.Add("style", backgroundColors);

            //}

            //if (fontColors != "")
            //{
            //    PageBody.Attributes.Add("style", fontColors);
            //}

            //if (fontTypes != "")
            //{
            //    PageBody.Attributes.Add("style", fontTypes);
            //}

            //if (theme != "")
            //{
            //    PageBody.Attributes.Add("style", theme);
            //}
        }

        public void GetAllMyMesages() 
        {
            HttpCookie myCookie = Request.Cookies["CIS3342_Cookie"];
            int myUserID = int.Parse(myCookie.Values["userID"]);

            GVMessages.DataSource=objDBhelper.GetMyMessagesTable(myUserID);

            //DataSet messageTable = objDBhelper.GetMessagesTable();
            //for (int i = 0; i < messageTable.Tables[0].Rows.Count; i++)
            //{
            //    int senderID = int.Parse(messageTable.Tables[0].Rows[i]["SenderID"].ToString());
            //    int receiverID = int.Parse(messageTable.Tables[0].Rows[i]["ReceiverID"].ToString());

            //    String messageBody = messageTable.Tables[0].Rows[i]["MessageBody"].ToString();
            //    String senderIDFirstName = messageTable.Tables[0].Rows[i]["SenderIDFirstName"].ToString();
            //    String senderIDLastName = messageTable.Tables[0].Rows[i]["SenderIDLastName"].ToString();
            //    objDBhelper.AddMessageToYourMessagesArrayList(senderID, receiverID, messageBody, senderIDFirstName, senderIDLastName);
            //}

            //ArrayList allMessages = (ArrayList)objDBhelper.yourMessages;

            //ArrayList yourMessages = new ArrayList();

            //GVMessages.DataSource = messageTable;
            GVMessages.DataBind();
        }



        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }

        protected void btnLogout_Click1(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");

            if (Request.Cookies["CIS3342_CookieCustom"] != null)
            {
                Response.Cookies["CIS3342_CookieCustom"].Expires = DateTime.Now.AddDays(-1);
            }
        }

        protected void AllUsersRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HttpCookie myCookie = Request.Cookies["CIS3342_Cookie"];
            int myID = int.Parse(myCookie.Values["userID"]);
            String firstName = myCookie.Values["firstName"];
            String lastName = myCookie.Values["lastName"];

            int rowIndex = e.Item.ItemIndex;
            String cmdITEM = e.CommandName;

            Label idLabel = (Label)YourFrindListRepeater.Items[rowIndex].FindControl("lblUserID");
            int friendsID = int.Parse(idLabel.Text);

            TextBox messageBody = (TextBox)YourFrindListRepeater.Items[rowIndex].FindControl("txtMessageBody");
            String message = messageBody.Text;

            if (cmdITEM == "CmdbtnSendFriendAMessage")
            {
                objDBhelper.SendAFriendAMessage(myID, friendsID, message, firstName, lastName);
            }
        }

        public void FillALlRecordsFromGetUserFriendsTable()
        {
            objDBhelper = new FaceBookHelper.DataBaseRequest();

            DataSet allFriendRequests = objDBhelper.GetUserFriendsTable();

            for (int i = 0; i < allFriendRequests.Tables[0].Rows.Count; i++)
            {
                int userFriendID = int.Parse(allFriendRequests.Tables[0].Rows[i]["UserFriendID"].ToString());
                String friend1 = allFriendRequests.Tables[0].Rows[i]["Friend1"].ToString();
                String friend2 = allFriendRequests.Tables[0].Rows[i]["Friend2"].ToString();
                String status = allFriendRequests.Tables[0].Rows[i]["Status"].ToString();
                String firstName = allFriendRequests.Tables[0].Rows[i]["FirstName"].ToString();
                String lastName = allFriendRequests.Tables[0].Rows[i]["LastName"].ToString();

                String friend1FirstName = allFriendRequests.Tables[0].Rows[i]["Friend1FirstName"].ToString();
                String friend1LastName = allFriendRequests.Tables[0].Rows[i]["Friend1LastName"].ToString();

                ///////// code here to add record to ArrayList
                objDBhelper.AddRequestToListofFriendRequests(userFriendID, friend1, friend2, status, firstName, lastName, friend1FirstName, friend1LastName);
            }

            ArrayList allFriendRequest = objDBhelper.friendRequest;//an ArrayList will all friend requests in the system
            ArrayList idOfAllYourFriends = new ArrayList();//A list of all your friends

            HttpCookie myCookie = Request.Cookies["CIS3342_Cookie"];
            String myUserID = myCookie.Values["userID"];

            foreach (FriendRequest item in allFriendRequest)
            {
                if (item.Status == "true")
                {
                    if ((item.Friend1 == myUserID) || (item.Friend2 == myUserID))
                    {

                        idOfAllYourFriends.Add(item);
                    }
                }
            }

            /////////////////////////////////////////////////////////////// 
            DataSet dsUserRecords = objDBhelper.GetAllUsersInTable();
            for (int i = 0; i < dsUserRecords.Tables[0].Rows.Count; i++)
            {
                int userID = int.Parse(dsUserRecords.Tables[0].Rows[i]["UserID"].ToString());
                String fName = dsUserRecords.Tables[0].Rows[i]["FirstName"].ToString();
                String lName = dsUserRecords.Tables[0].Rows[i]["LastName"].ToString();
                String phoneNumber = dsUserRecords.Tables[0].Rows[i]["PhoneNumber"].ToString();
                String address = dsUserRecords.Tables[0].Rows[i]["Address"].ToString();
                String email = dsUserRecords.Tables[0].Rows[i]["Email"].ToString();
                String userName = dsUserRecords.Tables[0].Rows[i]["UserName"].ToString();
                String passWord = dsUserRecords.Tables[0].Rows[i]["PassWord"].ToString();
                String security1 = dsUserRecords.Tables[0].Rows[i]["Security1"].ToString();
                String security2 = dsUserRecords.Tables[0].Rows[i]["Security2"].ToString();
                String security3 = dsUserRecords.Tables[0].Rows[i]["Security3"].ToString();

                String security1Question = dsUserRecords.Tables[0].Rows[i]["Security1Question"].ToString();
                String security2Question = dsUserRecords.Tables[0].Rows[i]["Security2Question"].ToString();
                String security3Question = dsUserRecords.Tables[0].Rows[i]["Security3Question"].ToString();

                String likes = dsUserRecords.Tables[0].Rows[i]["Likes"].ToString();
                String photoPath = dsUserRecords.Tables[0].Rows[i]["PhotoPath"].ToString();
                String city = dsUserRecords.Tables[0].Rows[i]["City"].ToString();
                String state = dsUserRecords.Tables[0].Rows[i]["State"].ToString();
                String loginPreferences = dsUserRecords.Tables[0].Rows[i]["loginPreferences"].ToString();

                String wallPost = dsUserRecords.Tables[0].Rows[i]["WallPost"].ToString();
                ////add code here to add each record to the ArrayList
                objDBhelper.AddUserArrayListofUsers(userID, fName, lName, phoneNumber, address, email, userName, security1, security2, security3, passWord, security1Question, security2Question, security3Question, loginPreferences, likes, photoPath, city, state, wallPost);
            }

            ArrayList yourPersonalFriendList = new ArrayList();

            foreach (User user in objDBhelper.userArrayList)
            {
                if (user.UserID.ToString() != myUserID)//prevents you from adding yourself to your friends list
                {
                    foreach (FriendRequest friendRequest in idOfAllYourFriends)
                    {
                        if ((user.UserID.ToString() == friendRequest.Friend1) || (user.UserID.ToString() == friendRequest.Friend2))
                        {
                            yourPersonalFriendList.Add(user);
                        }
                    }
                }

            }
            YourFrindListRepeater.DataSource = yourPersonalFriendList;
            YourFrindListRepeater.DataBind();
        }

        protected void GVMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            String reviewID = GVMessages.SelectedRow.Cells[1].Text;
            objDBhelper.DeleteMessageByRecordID(reviewID);
            GetAllMyMesages();
        }
    }
}