using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FaceBookHelper;
using Utilities;


namespace TPcis3342
{

    public partial class SearchForStuffPage : System.Web.UI.Page
    {
        FaceBookHelper.DataBaseRequest objDBhelper;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepeaterUsers();///ok

                FillArrayListWithUsersForSearches();
                Session["userArrayList"] = objDBhelper.userArrayList;

                UpdateGVfriendRequestStatus();
                UpdateGVotherPeopleRequests();
            }
            else if (!IsPostBack && Request.Cookies["CIS3342_Cookie"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }

            if (Request.Cookies["CIS3342_CookieCustom"] != null)
            {
                SetCustomSetting();
            }
        }

        public void UpdateGVotherPeopleRequests()
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

            ArrayList allFriendRequest = objDBhelper.friendRequest;
            ArrayList OtherPeopleRequests = new ArrayList();

            HttpCookie myCookie = Request.Cookies["CIS3342_Cookie"];
            String myUserID = myCookie.Values["userID"];

            foreach (FriendRequest item in allFriendRequest)
            {
                if (item.Friend2 == myUserID)
                {
                    OtherPeopleRequests.Add(item);
                }
            }

            GVotherPeopleRequests.DataSource = OtherPeopleRequests;
            GVotherPeopleRequests.DataBind();

        }

        public void UpdateGVfriendRequestStatus()
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

            ArrayList allFriendRequest = objDBhelper.friendRequest;
            ArrayList allYourRequests = new ArrayList();

            HttpCookie myCookie = Request.Cookies["CIS3342_Cookie"];
            String myUserID = myCookie.Values["userID"];

            foreach (FriendRequest item in allFriendRequest)
            {
                if (item.Friend1 == myUserID)
                {
                    allYourRequests.Add(item);
                }
            }

            GVfriendRequestStatus.DataSource = allYourRequests;
            GVfriendRequestStatus.DataBind();

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

        public void FillArrayListWithUsersForSearches()
        {
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
        }

        public void BindRepeaterUsers()
        {
            objDBhelper = new FaceBookHelper.DataBaseRequest();
            AllUsersRepeater.DataSource = objDBhelper.GetAllUsersInTable();
            AllUsersRepeater.DataBind();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }

        protected void btnShowAllUsers_Click(object sender, EventArgs e)
        {
            SearchResultsRepeater.Visible = false;
            AllUsersRepeater.Visible = true;

            AllUsersRepeater.Visible = true;
            //btnHideAllUsers.Visible = true;
        }

        //protected void btnHideAllUsers_Click(object sender, EventArgs e)
        //{
        //    btnShowAllUsers.Visible = true;
        //    AllUsersRepeater.Visible = false;
        //    btnHideAllUsers.Visible = false;
        //}

        protected void AllUsersRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            objDBhelper = new FaceBookHelper.DataBaseRequest();

            int rowIndex = e.Item.ItemIndex;
            String cmd = e.CommandName;

            Label tempFriendBeingAdded = (Label)AllUsersRepeater.Items[rowIndex].FindControl("lblUserID");
            String friendBeingAddedID = tempFriendBeingAdded.Text;

            HttpCookie myCookie = Request.Cookies["CIS3342_Cookie"];
            String userID = myCookie.Values["userID"];

            //informatin from the user that's going to be also inserted into the email//
            String userfirstName = myCookie.Values["firstName"];
            String userlastName = myCookie.Values["lastName"];
            String userEmailAddress = myCookie.Values["Email"];

            //informatin from the user that's going to be also inserted into the email//


            String status = "false";

            // Retrieve a value from a control in the Repeater's Items collection
            Label firstNameLabel = (Label)AllUsersRepeater.Items[rowIndex].FindControl("lblFirstName");
            String firstName = firstNameLabel.Text;

            Label lastNameLabel = (Label)AllUsersRepeater.Items[rowIndex].FindControl("lblLastName");
            String lastName = lastNameLabel.Text;

            Label friendsIDLabel = (Label)AllUsersRepeater.Items[rowIndex].FindControl("lblUserID");
            String friendsID = lastNameLabel.Text;

            if (cmd == "CmdbtnbtnAddFriend")
            {
                cmd = "Button Add Friend Clicked";

                //Code here to add a friend
                //objDBhelper.FriendRequest(userID, friendBeingAddedID, status);
                objDBhelper.FriendRequest(userID, friendBeingAddedID, status, firstName, lastName, userfirstName, userlastName);


                //String friendsEmail = "";
                //DataSet friendsRecord = objDBhelper.GetUserRecordByID(int.Parse(friendsID));
                //for (int i = 0; i < friendsRecord.Tables[0].Rows.Count; i++)
                //{
                //    friendsEmail = friendsRecord.Tables[0].Rows[i]["Email"].ToString();
                //}

                ////code here to send an email confirmation after the friend request is sent out //
                //Email objEmail = new Email();
                //String strTO = friendsEmail;//insert the recipient's email address here
                //String strFROM = userEmailAddress;
                //String strSubject = "Adding Friend";
                //String strMessage = userfirstName + " " + userlastName + " sent you a friend request";
                //objEmail.SendMail(strTO, strFROM, strSubject, strMessage);
                ////code here to send an email confirmation after the friend request is sent//

            }
            else if (cmd == "CmdbtnSendMessage")
            {
                cmd = "Button Send Message Clicked";
            }

            //txtDisplay.Text = cmd + " was clicked on row " + rowIndex.ToString() + "<br/> First Name: " + firstName + "<br/> Last Name: " + lastName;
            UpdateGVfriendRequestStatus();
            UpdateGVotherPeopleRequests();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            SearchResultsRepeater.Visible = true;
            AllUsersRepeater.Visible = false;

            objDBhelper = new FaceBookHelper.DataBaseRequest();

            String firstName = txtFirstNameSearch.Text;
            String lastName = txtLastNameSearch.Text;
            String city = txtCitySearch.Text;
            String likes = txtLikesSearch.Text;

            ArrayList userArrayList = (ArrayList)Session["userArrayList"];

            ArrayList endSearchResultA = new ArrayList();
            ArrayList endSearchResultB = new ArrayList();

            if ((txtFirstNameSearch.Text == "") && (txtLastNameSearch.Text == "") && (txtCitySearch.Text == "") && (txtStateSearch.Text == "") && (txtLikesSearch.Text == ""))
            {
                lblSearch.Visible = true;
                lblSearch.Text = "*To Run A Search, You Need At Least One Search Parameter*";
            }
            else
            {
                lblSearch.Visible = false;

                String queryString = "";
                Boolean hasFristValue = false;

                if (txtFirstNameSearch.Text != "")
                {
                    if (hasFristValue == true)
                    {
                        //queryString += "AND()"; //will never run!
                    }
                    else
                    {
                        queryString += "(FirstName='" + txtFirstNameSearch.Text + "')";
                        hasFristValue = true;
                    }


                }

                if (txtLastNameSearch.Text != "")
                {
                    if (hasFristValue == true)
                    {
                        queryString += "AND(LastName='" + txtLastNameSearch.Text + "')";
                    }
                    else
                    {
                        queryString += "(LastName='" + txtLastNameSearch.Text + "')";
                        hasFristValue = true;
                    }
                }

                if (txtCitySearch.Text != "")
                {
                    if (hasFristValue == true)
                    {
                        queryString += "AND(City='" + txtCitySearch.Text + "')";
                    }
                    else
                    {
                        queryString += "(City='" + txtCitySearch.Text + "')";
                        hasFristValue = true;
                    }


                }

                if (txtStateSearch.Text != "")
                {
                    if (hasFristValue == true)
                    {
                        queryString += "AND(State='" + txtStateSearch.Text + "')";
                    }
                    else
                    {
                        queryString += "(State='" + txtStateSearch.Text + "')";
                        hasFristValue = true;
                    }
                }

                DataSet searchResults = objDBhelper.GetDataSetFromCustomSearch(queryString);

                if (txtLikesSearch.Text != "")
                {
                    char[] charArray = { ',' };
                    String[] tempLikesArray;

                    ArrayList searchResultsUserID = new ArrayList();//a final list of UserID with matching "likes" matches

                    for (int i = 0; i < searchResults.Tables[0].Rows.Count; i++)
                    {
                        int userFriendID = int.Parse(searchResults.Tables[0].Rows[i]["UserID"].ToString());
                        String tempLikes = searchResults.Tables[0].Rows[i]["Likes"].ToString();

                        tempLikesArray = tempLikes.Split(charArray);

                        for (int j = 0; j < tempLikesArray.Length; j++)
                        {
                            String tempStringA = tempLikesArray[j].ToUpper();
                            String tempStringB = likes.ToUpper();

                            if (tempStringA.Trim() == tempStringB.Trim())//casts all comparisons to uppercase characters and also gets rid of spaces before and after string values
                            {
                                searchResultsUserID.Add(userFriendID);
                            }
                        }
                    }

                    userArrayList = (ArrayList)Session["userArrayList"];

                    ArrayList finalResultsAfterLikesScreening = new ArrayList();

                    foreach (int item in searchResultsUserID)
                    {
                        foreach (User user in userArrayList)
                        {
                            if (user.UserID == item)
                            {
                                finalResultsAfterLikesScreening.Add(user);
                            }
                        }
                    }

                    SearchResultsRepeater.DataSource = finalResultsAfterLikesScreening;
                    SearchResultsRepeater.DataBind();
                }
                else
                {
                    SearchResultsRepeater.DataSource = searchResults;
                    SearchResultsRepeater.DataBind();
                }

            }
        }



        protected void GVfriendRequestStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            objDBhelper = new FaceBookHelper.DataBaseRequest();

            lblDeleteRequestINFO.Visible = true;
            lblDeleteRequestINFO.Text = "*The friend request with an ID of " + GVfriendRequestStatus.SelectedRow.Cells[0].Text + " was deleted from the system*";

            String deleteRequestID = GVfriendRequestStatus.SelectedRow.Cells[0].Text;
            ///////////////////////
            objDBhelper.DeleteFriendRequest(deleteRequestID);

            UpdateGVfriendRequestStatus();
            UpdateGVotherPeopleRequests();
        }

        protected void GVotherPeopleRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            objDBhelper = new FaceBookHelper.DataBaseRequest();
            String userFriendID = GVotherPeopleRequests.SelectedRow.Cells[0].Text;

            String friendStatus = GVotherPeopleRequests.SelectedRow.Cells[4].Text;

            if (friendStatus == "true")
            {
                friendStatus = "false";
            }
            else if (friendStatus == "false")
            {
                friendStatus = "true";
            }

            //code to switch friendStatus from true to false or vice versa 
            objDBhelper.AcceptDeclineFriendRequest(userFriendID, friendStatus);//the userFriendID value in the database table is a int type, but here it's a string type. It doesn't crash though 
            //code to switch friendStatus from true to false or vice versa 

            lblConfirmOrNot.Visible = true;
            lblConfirmOrNot.Text = "*Your friend status with " + GVotherPeopleRequests.SelectedRow.Cells[2].Text + " " + GVotherPeopleRequests.SelectedRow.Cells[3].Text + " was updated in the system*";

            UpdateGVfriendRequestStatus();
            UpdateGVotherPeopleRequests();
        }

        protected void SearchResultsRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            objDBhelper = new FaceBookHelper.DataBaseRequest();

            int rowIndex = e.Item.ItemIndex;
            String cmd = e.CommandName;

            Label tempFriendBeingAdded = (Label)SearchResultsRepeater.Items[rowIndex].FindControl("lblUserIDSearchGV");
            String friendBeingAddedID = tempFriendBeingAdded.Text;

            HttpCookie myCookie = Request.Cookies["CIS3342_Cookie"];
            String userID = myCookie.Values["userID"];

            String userfirstName = myCookie.Values["firstName"];
            String userlastName = myCookie.Values["lastName"];

            String status = "false";

            // Retrieve a value from a control in the Repeater's Items collection
            Label firstNameLabel = (Label)SearchResultsRepeater.Items[rowIndex].FindControl("lblFirstNameSearchGV");
            String firstName = firstNameLabel.Text;

            Label lastNameLabel = (Label)SearchResultsRepeater.Items[rowIndex].FindControl("lblLastNameSearchGV");
            String lastName = lastNameLabel.Text;

            Label friendsID = (Label)SearchResultsRepeater.Items[rowIndex].FindControl("lblUserIDSearchGV");
            String friendsIDID = friendsID.Text;



            if (cmd == "CmdbtnbtnAddFriendSearchGV")
            {
                cmd = "Button Add Friend Clicked";

                //Code here to add a friend
                //objDBhelper.FriendRequest(userID, friendBeingAddedID, status);
                objDBhelper.FriendRequest(userID, friendBeingAddedID, status, firstName, lastName, userfirstName, userlastName);



                String friendsEmail = "";
                DataSet friendsRecord = objDBhelper.GetUserRecordByID(int.Parse(friendsIDID));
                for (int i = 0; i < friendsRecord.Tables[0].Rows.Count; i++)
                {
                    friendsEmail = friendsRecord.Tables[0].Rows[i]["Email"].ToString();
                }


                //HttpCookie myYCookie = Request.Cookies["CIS3342_Cookie"];
                //String myEmail = myYCookie.Values["Email"];
                ////code here to send an email confirmation after the friend request is sent out //
                //Email objEmail = new Email();
                //String strTO = friendsEmail;//insert the recipient's email address here
                //String strFROM = myEmail;
                //String strSubject = "Adding Friend";
                //String strMessage = userfirstName + " " + userlastName + " sent you a friend request";
                //objEmail.SendMail(strTO, strFROM, strSubject, strMessage);
                ////code here to send an email confirmation after the friend request is sent//

            }


            else if (cmd == "CmdbtnSendMessageSearchGV")
            {
                cmd = "Button Send Message Clicked";
            }

            //txtDisplay.Text = cmd + " was clicked on row " + rowIndex.ToString() + "<br/> First Name: " + firstName + "<br/> Last Name: " + lastName;
            UpdateGVfriendRequestStatus();
            UpdateGVotherPeopleRequests();
        }

        protected void btnLogout_Click1(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }


    }
}