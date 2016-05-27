using FaceBookHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections.Specialized;

namespace TPcis3342
{
    public partial class Home : System.Web.UI.Page
    {
        FaceBookHelper.DataBaseRequest objDBhelper;
        SerializeAndDeserializing SerializeAndDeserializing = new SerializeAndDeserializing();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.Cookies["CIS3342_Cookie"] != null)
            {
                HttpCookie cookieE = Request.Cookies["CIS3342_Cookie"];
                lblFirstName.Text = cookieE.Values["firstName"].ToString() + " ";
                lblFirstName.Text += cookieE.Values["lastName"].ToString();

                FillALlRecordsFromGetUserFriendsTable();//populates ArrayList with all friend requests
                NewFeedAndWall();//populates your wall and newfeed
            }
            else if (!IsPostBack && Request.Cookies["CIS3342_Cookie"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }

            if (!IsPostBack && Request.Cookies["CIS3342_CookieCustom"] != null)
            {
                //code here to deserialize the user's loginPreferences and background color
                HttpCookie cookieE = Request.Cookies["CIS3342_Cookie"];
                int userID = int.Parse(cookieE.Values["userID"]);

                SettingsObject tempSettingsObject = SerializeAndDeserializing.Deserializing(userID);
                HttpCookie myCookieTheme = new HttpCookie("CIS3342_CookieCustom");
                myCookieTheme.Values["backgroundColors"] = tempSettingsObject.BackGroundColor;

                //String backgroundColors  = myCookieTheme.Values["backgroundColors"];
                //PageBody.Attributes.Add("style", backgroundColors);

                Response.Cookies.Add(myCookieTheme);
                SetCustomSetting();
                //code here to deserialize the user's loginPreferences and background color            
            }
            else
            {
                //code here to deserialize the user's loginPreferences and background color
                HttpCookie cookieE = Request.Cookies["CIS3342_Cookie"];
                int userID = int.Parse(cookieE.Values["userID"]);

                SettingsObject tempSettingsObject = SerializeAndDeserializing.Deserializing(userID);

                HttpCookie myCookieTheme = new HttpCookie("CIS3342_CookieCustom");
                myCookieTheme.Values["backgroundColors"] = tempSettingsObject.BackGroundColor;

                //String backgroundColors  = myCookieTheme.Values["backgroundColors"];
                //PageBody.Attributes.Add("style", backgroundColors);

                Response.Cookies.Add(myCookieTheme);
                SetCustomSetting();
                //code here to deserialize the user's loginPreferences and background color
            }
            imgAJAX.ImageUrl = "../IMG/city.jpg";
        }

        public void NewFeedAndWall()
        {

            char[] targetChar = { '~' };

            HttpCookie cookieE = Request.Cookies["CIS3342_Cookie"];

            String wallPostString = "";
            String longStringPosts = "";

            if (cookieE.Values["WallPost"] != null)//needed for when a new user creates an account and redirected to this page
            {
                longStringPosts = cookieE.Values["WallPost"].ToString();
            }

            String[] posts = longStringPosts.Split(targetChar);

            for (int i = 0; i < posts.Length; i++)
            {
                wallPostString += posts[i] + "\n \n ";
            }

            txtYourWall.Text = wallPostString;

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

            ////code here to populate newsfeed////
            char[] targetChar = { '~' };

            String wallPostString = "";
            String allNewsFeed = "";

            foreach (User user in yourPersonalFriendList)
            {
                allNewsFeed += user.FirstName.ToString() + " " + user.LastName.ToString() + "'s news feed! \n";

                wallPostString = "";
                String[] posts = user.WallPost.Split(targetChar);

                for (int i = 0; i < posts.Length; i++)
                {
                    wallPostString += posts[i] + "\n ";
                }

                allNewsFeed += wallPostString;

                allNewsFeed += " \n";
            }

            txtNewsFeed.Text = allNewsFeed;
            ////code here to populate newsfeed////

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
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }

        protected void btnShowAllUsers_Click(object sender, EventArgs e)
        {
            YourFrindListRepeater.Visible = true;
            btnShowAllUsers.Visible = false;
            btnHideAllUsers.Visible = true;
        }

        protected void btnHideAllUsers_Click(object sender, EventArgs e)
        {
            YourFrindListRepeater.Visible = false;
            btnShowAllUsers.Visible = true;
            btnHideAllUsers.Visible = false;
        }

        protected void AllUsersRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            objDBhelper = new FaceBookHelper.DataBaseRequest();

            int rowIndex = e.Item.ItemIndex;
            String cmd = e.CommandName;

            HttpCookie myCookie = Request.Cookies["CIS3342_Cookie"];
            String userID = myCookie.Values["userID"];
            String myFirstName = myCookie.Values["firstName"];
            String myLastName = myCookie.Values["lastName"];


            // Retrieve a value from a control in the Repeater's Items collection
            LinkButton tempFriendID = (LinkButton)YourFrindListRepeater.Items[rowIndex].FindControl("LinkButtonUserID");
            String friendID = tempFriendID.Text;

            Label firstNameLabel = (Label)YourFrindListRepeater.Items[rowIndex].FindControl("lblFirstName");
            String firstName = firstNameLabel.Text;

            Label lastNameLabel = (Label)YourFrindListRepeater.Items[rowIndex].FindControl("lblLastName");
            String lastName = lastNameLabel.Text;



            TextBox wallMessage = (TextBox)YourFrindListRepeater.Items[rowIndex].FindControl("txtFriendsWall");

            String time = DateTime.Now.ToLongTimeString();
            String date = DateTime.Now.ToLongDateString();
            String message = wallMessage.Text;

            String writeOnWall = myFirstName + " " + myLastName + "  Date: " + date + " Time: " + time + "  ";
            writeOnWall += message + "~";

            if (cmd == "CmdbtnWriteOnFriendsWall")
            {
                cmd = "Button 'btnWriteOnWall' was Clicked";

                lblNewsFeedInfo.Text = cmd + " <br/> <br/>" + "row: " + rowIndex + " <br/> friend's ID: " + friendID + "<br/> <br/>" + "Author Of Post: " + writeOnWall;

                //code here to write on frind's wall, first get the user's record then append this post onto the orginal and then update the WallPost record
                DataSet friendRecord = objDBhelper.GetUserRecordByID(int.Parse(friendID));//gets target friend's record
                String friendRecordWallPost = "";
                for (int i = 0; i < friendRecord.Tables[0].Rows.Count; i++)
                {
                    friendRecordWallPost = friendRecord.Tables[0].Rows[i]["WallPost"].ToString();
                }
                friendRecordWallPost += writeOnWall;
                objDBhelper.UpdateWallPost(friendID, friendRecordWallPost);

                //code here to write on frind's wall, first get the user's record then append this post onto the orginal and then update the WallPost record


            }

        }

        protected void btnLogout_Click1(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");

            if (Request.Cookies["CIS3342_CookieCustom"] != null)
            {
                Response.Cookies["CIS3342_CookieCustom"].Expires = DateTime.Now.AddDays(-1);
            }
        }

        protected void LinkButtonUserID_Click(object sender, EventArgs e)
        {
            LinkButton tempBtnUserID = (LinkButton)sender;
            String userID = tempBtnUserID.Text;
            Session["FRIENDS_ID"] = userID;
            Response.Redirect("ProfileOfFriend.aspx");
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            ArrayList list = new ArrayList();
            list.Add("../IMG/privacy.jpg");
            list.Add("../IMG/forest.png");
            list.Add("../IMG/books.jpg");
            list.Add("../IMG/movie.jpg");
            list.Add("../IMG/clouds.png");
            Random random = new Random();
            int index = random.Next(0, 5);
            imgAJAX.ImageUrl = list[index].ToString();
        }
    }
}