using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using FaceBookHelper;

namespace FaceBookHelper
{
    public class DataBaseRequest
    {
        DBConnect objDB;//using Utilities;
        public ArrayList SecurityQuestions1;
        public ArrayList SecurityQuestions2;
        public ArrayList SecurityQuestions3;

        public ArrayList userArrayList;
        public ArrayList friendRequest;
        public ArrayList yourMessages;

        public DataBaseRequest()
        {
            SecurityQuestions1 = new ArrayList();
            SecurityQuestions2 = new ArrayList();
            SecurityQuestions3 = new ArrayList();

            userArrayList = new ArrayList();
            friendRequest = new ArrayList();
            yourMessages = new ArrayList();

            LoadQuestions();
        }

        public void AddMessageToYourMessagesArrayList(int senderID, int receiverID, String messageBody, String firstName, String lastName)
        {
            Message tempMessage = new Message(senderID, receiverID, messageBody, firstName, lastName);
            yourMessages.Add(tempMessage);
        }

        public void AddUserArrayListofUsers(int userID, String firstName, String lastName, String phoneNumber, String address, String email, String userName, String security1, String security2, String security3, String passWord, String security1Question, String security2Question, String security3Question, String loginPreferences, String likes, String photoPath, String city, String state, String wallPost)
        {
            User tempUser = new User(userID, firstName, lastName, phoneNumber, address, email, userName, security1, security2, security3, passWord, security1Question, security2Question, security3Question, loginPreferences, likes, photoPath, city, state, wallPost);
            userArrayList.Add(tempUser);
        }

        public void AddRequestToListofFriendRequests(int userFriendID, String friend1, String friend2, String status, String firstName, String lastName, String friend1FirstName, String friend1LastName)
        {
            FriendRequest tempFriendRequest = new FriendRequest(userFriendID, friend1, friend2, status, firstName, lastName, friend1FirstName, friend1LastName);
            friendRequest.Add(tempFriendRequest);
        }

        public void LoadQuestions()
        {
            String question1 = "Which is your favorite web browser?";
            String question2 = "What was your high school mascot?";
            String question3 = "What is the name of your first grade teacher?";
            String question4 = "What is your father's middle name?";
            String question5 = "What is your favorite color?";

            String question6 = "When is your anniversary?";
            String question7 = "What was the make of your first car?";
            String question8 = "What street did you grow up on?";
            String question9 = "What is your mother's maiden name?";
            String question10 = "What is your favorite movie?";

            String question11 = "What is the name of your first school?";
            String question12 = "What high school did you attend?";
            String question13 = "In what city were you born?";
            String question14 = "What is the name of your favorite pet?";
            String question15 = "Who is your favorite actor, musician, or artist?";

            SecurityQuestions1.Add(question1);
            SecurityQuestions1.Add(question2);
            SecurityQuestions1.Add(question3);
            SecurityQuestions1.Add(question4);
            SecurityQuestions1.Add(question5);

            SecurityQuestions2.Add(question6);
            SecurityQuestions2.Add(question7);
            SecurityQuestions2.Add(question8);
            SecurityQuestions2.Add(question9);
            SecurityQuestions2.Add(question10);

            SecurityQuestions3.Add(question11);
            SecurityQuestions3.Add(question12);
            SecurityQuestions3.Add(question13);
            SecurityQuestions3.Add(question14);
            SecurityQuestions3.Add(question15);

        }

        public int UserLogin(String username, String password)//returns the UserID associated to username/password combo
        {
            objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();//using System.Data.SqlClient;
            objCommand.CommandType = CommandType.StoredProcedure;//using System.Data;
            objCommand.CommandText = "UserLogin";

            objCommand.Parameters.AddWithValue("@UserName", username);
            objCommand.Parameters.AddWithValue("@Password", password);

            SqlParameter returnParameter = new SqlParameter("@ID", DbType.Int32);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            objCommand.Parameters.Add(returnParameter);

            objDB.GetDataSetUsingCmdObj(objCommand);

            int tempUserID;
            tempUserID = int.Parse(objCommand.Parameters["@ID"].Value.ToString());

            return tempUserID;
            // 0 = no password/username combo is exist in table
            // anything other than 0 = password/username combo exists in table and value is returned 
        }

        public int CreateUser(String firstName, String lastName, String phoneNumber, String address, String email, String username, String password, String security1Answer, String security2Answer, String security3Answer, String security1Question, String security2Question, String security3Question, String loginPreferences, String likes, String city, String state)
        {
            objDB = new DBConnect();

            int tempUserID = UserLogin(username, password);
            String tempPhotoPath = "Images/NoPhoto.jpg";//default profile image

            if (tempUserID == 0)// 0 means that the username/password combo doesn't exist yet, which is a good thing
            {
                SqlCommand objCommand = new SqlCommand();//using System.Data.SqlClient;
                objCommand.CommandType = CommandType.StoredProcedure;//using System.Data;
                objCommand.CommandText = "CreateUser";

                objCommand.Parameters.AddWithValue("@FirstName", firstName);
                objCommand.Parameters.AddWithValue("@LastName", lastName);
                objCommand.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                objCommand.Parameters.AddWithValue("@Address", address);

                objCommand.Parameters.AddWithValue("@Email", email);
                objCommand.Parameters.AddWithValue("@UserName", username);
                objCommand.Parameters.AddWithValue("@Password", password);


                objCommand.Parameters.AddWithValue("@Security1", security1Answer);
                objCommand.Parameters.AddWithValue("@Security2", security2Answer);
                objCommand.Parameters.AddWithValue("@Security3", security3Answer);

                objCommand.Parameters.AddWithValue("@security1Question", security1Question);
                objCommand.Parameters.AddWithValue("@security2Question", security2Question);
                objCommand.Parameters.AddWithValue("@security3Question", security3Question);

                objCommand.Parameters.AddWithValue("@loginPreferences", loginPreferences);
                objCommand.Parameters.AddWithValue("@tempPhotoPath", tempPhotoPath);
                objCommand.Parameters.AddWithValue("@Likes", likes);

                objCommand.Parameters.AddWithValue("@City", city);
                objCommand.Parameters.AddWithValue("@State", state);



                objDB.GetDataSetUsingCmdObj(objCommand);
            }
            else
            {
            }
            return tempUserID;
        }

        public int UpdateUserInformation(String firstName, String lastName, String phoneNumber, String address, String email, String oldUsername, String oldPassword, String newUsername, String newPassword, String security1Answer, String security2Answer, String security3Answer, String City, String State, String Likes)
        {
            objDB = new DBConnect();

            int tempUserID = UserLogin(oldUsername, oldPassword);//gets userID linked to password/username combo
            int usernamePasswordComboIsGood = UserLogin(newUsername, newPassword);//0 = the username/password combo is vacant

            if ((tempUserID != 0) && (usernamePasswordComboIsGood == 0))//anything other than 0 means that the username/password combo exist yet and the owner of that username/password combo UserID is returned 
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "UpdateUserInformation";

                objCommand.Parameters.AddWithValue("@UserID", tempUserID);

                objCommand.Parameters.AddWithValue("@FirstName", firstName);
                objCommand.Parameters.AddWithValue("@LastName", lastName);
                objCommand.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                objCommand.Parameters.AddWithValue("@Address", address);

                objCommand.Parameters.AddWithValue("@Email", email);
                objCommand.Parameters.AddWithValue("@UserName", newUsername);
                objCommand.Parameters.AddWithValue("@Password", newPassword);

                objCommand.Parameters.AddWithValue("@Security1", security1Answer);
                objCommand.Parameters.AddWithValue("@Security2", security2Answer);
                objCommand.Parameters.AddWithValue("@Security3", security3Answer);

                objCommand.Parameters.AddWithValue("@City", City);
                objCommand.Parameters.AddWithValue("@State", State);
                objCommand.Parameters.AddWithValue("@Likes", Likes);


                objDB.GetDataSetUsingCmdObj(objCommand);
            }
            else
            {
                return 0;//the new username/password combo was not vacant, the user needs to select anonther new username/password combo
            }
            return 1;//good 
        }

        public DataSet GetUserRecordByID(int userID)//returns the record linked to the passed in UserID
        {
            objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();//using System.Data.SqlClient;
            objCommand.CommandType = CommandType.StoredProcedure;//using System.Data;
            objCommand.CommandText = "GetUserRecordByID";

            objCommand.Parameters.AddWithValue("@UserID", userID);

            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        public DataSet GetUserRecordWithUsernamePassword(String username, String password)//returns the UserID associated to username/password combo
        {
            objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();//using System.Data.SqlClient;
            objCommand.CommandType = CommandType.StoredProcedure;//using System.Data;
            objCommand.CommandText = "GetUserRecordWithUsernamePassword";

            objCommand.Parameters.AddWithValue("@UserName", username);
            objCommand.Parameters.AddWithValue("@Password", password);

            return objDB.GetDataSetUsingCmdObj(objCommand);

        }

        public DataSet GetUserRecordByEmail(String userEmail)//returns the record linked to the passed in UserID
        {
            objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();//using System.Data.SqlClient;
            objCommand.CommandType = CommandType.StoredProcedure;//using System.Data;
            objCommand.CommandText = "GetUserRecordByEmail";

            objCommand.Parameters.AddWithValue("@UserEmail", userEmail);

            return objDB.GetDataSetUsingCmdObj(objCommand);
            // 0 = no password/username combo is exist in table
            // anything other than 0 = password/username combo exists in table and value is returned 
        }

        public int GetUserIDWithEmail(String userEmail)//returns the record linked to the passed in UserID
        {
            objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();//using System.Data.SqlClient;
            objCommand.CommandType = CommandType.StoredProcedure;//using System.Data;
            objCommand.CommandText = "GetUserIDWithEmail";

            objCommand.Parameters.AddWithValue("@UserEmail", userEmail);

            SqlParameter returnParameter = new SqlParameter("@ID", DbType.Int32);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            objCommand.Parameters.Add(returnParameter);

            objDB.GetDataSetUsingCmdObj(objCommand);

            int tempUserID;
            tempUserID = int.Parse(objCommand.Parameters["@ID"].Value.ToString());

            return tempUserID;
            // 0 = no UserId is linked to the passed in email address
            // anything other than 0 = passed in email address exists in the table and UserID value is returned
        }

        public int GetSecurityQuestion1Response(String userEmail, String securityQuestion1, String answer1)//0 = no match found question/answer combo //1 = match found question/answer combo
        {
            objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetSecurityQuestion1Response";

            objCommand.Parameters.AddWithValue("@UserEmail", userEmail);
            objCommand.Parameters.AddWithValue("@securityQuestion1", securityQuestion1);
            objCommand.Parameters.AddWithValue("@answer1", answer1);

            SqlParameter returnParameter = new SqlParameter("@thecount", DbType.Int32);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            objCommand.Parameters.Add(returnParameter);

            objDB.GetDataSetUsingCmdObj(objCommand);

            int questionRespons;
            questionRespons = int.Parse(objCommand.Parameters["@thecount"].Value.ToString());

            return questionRespons;
            //0 = no match found question/answer combo is incorrect 
            //1 = match found question/answer combo is correct
        }

        public int GetSecurityQuestion2Response(String userEmail, String securityQuestion2, String answer2)//0 = no match found question/answer combo //1 = match found question/answer combo
        {
            objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetSecurityQuestion2Response";

            objCommand.Parameters.AddWithValue("@UserEmail", userEmail);
            objCommand.Parameters.AddWithValue("@securityQuestion2", securityQuestion2);
            objCommand.Parameters.AddWithValue("@answer2", answer2);

            SqlParameter returnParameter = new SqlParameter("@thecount", DbType.Int32);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            objCommand.Parameters.Add(returnParameter);

            objDB.GetDataSetUsingCmdObj(objCommand);

            int questionRespons;
            questionRespons = int.Parse(objCommand.Parameters["@thecount"].Value.ToString());

            return questionRespons;
            //0 = no match found question/answer combo is incorrect 
            //1 = match found question/answer combo is correct
        }

        public int GetSecurityQuestion3Response(String userEmail, String securityQuestion3, String answer3)//0 = no match found question/answer combo //1 = match found question/answer combo
        {
            objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetSecurityQuestion3Response";

            objCommand.Parameters.AddWithValue("@UserEmail", userEmail);
            objCommand.Parameters.AddWithValue("@securityQuestion3", securityQuestion3);
            objCommand.Parameters.AddWithValue("@answer3", answer3);

            SqlParameter returnParameter = new SqlParameter("@thecount", DbType.Int32);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            objCommand.Parameters.Add(returnParameter);

            objDB.GetDataSetUsingCmdObj(objCommand);

            int questionRespons;
            questionRespons = int.Parse(objCommand.Parameters["@thecount"].Value.ToString());

            return questionRespons;
            //0 = no match found question/answer combo is incorrect 
            //1 = match found question/answer combo is correct
        }

        public void ChangeUserloginPreference(String username, String password, String loginPreferences)//returns the record linked to the passed in UserID
        {
            objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "ChangeUserloginPreference";

            objCommand.Parameters.AddWithValue("@username", username);
            objCommand.Parameters.AddWithValue("@password", password);
            objCommand.Parameters.AddWithValue("@loginPreferences", loginPreferences);

            objDB.GetDataSetUsingCmdObj(objCommand);
        }

        public DataSet GetAllUsersInTable()
        {
            objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetAllUsersInTable";

            return objDB.GetDataSetUsingCmdObj(objCommand);
        }


        public void FriendRequest(String userID, String friendBeingAddedID, String status, String firstName, String lastName, String userfirstName, String userlastName)
        {
            objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "FriendRequest";

            objCommand.Parameters.AddWithValue("@userID", userID);
            objCommand.Parameters.AddWithValue("@friendBeingAddedID", friendBeingAddedID);
            objCommand.Parameters.AddWithValue("@status", status);
            objCommand.Parameters.AddWithValue("@firstName", firstName);
            objCommand.Parameters.AddWithValue("@lastName", lastName);

            objCommand.Parameters.AddWithValue("@Friend1FirstName", userfirstName);
            objCommand.Parameters.AddWithValue("@Friend1LastName", userlastName);

            objDB.GetDataSetUsingCmdObj(objCommand);
        }

        public DataSet GetUserFriendsTable()
        {
            objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetUserFriendsTable";

            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        public void DeleteFriendRequest(String userFriendID)
        {
            objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeleteFriendRequest";

            objCommand.Parameters.AddWithValue("@UserFriendID", userFriendID);


            objDB.GetDataSetUsingCmdObj(objCommand);
        }

        public void AcceptDeclineFriendRequest(String userFriendID, String friendStatus)
        {
            objDB = new DBConnect();

            int userFriendIDintType = int.Parse(userFriendID);

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateFriendRequestStatus";

            objCommand.Parameters.AddWithValue("@UserFriendID", userFriendIDintType);
            objCommand.Parameters.AddWithValue("@Status", friendStatus);


            objDB.GetDataSetUsingCmdObj(objCommand);
        }

        public DataSet GetDataSetFromCustomSearch(String strSQL)
        {
            objDB = new DBConnect();
            String stringSQL = "";

            if (strSQL == "")
            {
                stringSQL = "SELECT * FROM TP_UserAccounts";

            }
            else
            {
                stringSQL = "SELECT * FROM TP_UserAccounts WHERE " + strSQL;
            }

            return objDB.GetDataSet(stringSQL);
        }

        //public DataSet GetDataSetFromCustomSearch(String strSQL)//won't work
        //{
        //    objDB = new DBConnect();

        //    SqlCommand objCommand = new SqlCommand();
        //    objCommand.CommandType = CommandType.StoredProcedure;
        //    objCommand.CommandText = "GetDataSetFromCustomSearch";

        //    objCommand.Parameters.AddWithValue("@strSQL", strSQL);

        //    return objDB.GetDataSetUsingCmdObj(objCommand);
        //}

        public void UpdateUserPhotoPath(String UserID, String PhotoPath)
        {
            objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateUserPhotoPath";

            objCommand.Parameters.AddWithValue("@UserID", UserID);
            objCommand.Parameters.AddWithValue("@PhotoPath", PhotoPath);

            objDB.GetDataSetUsingCmdObj(objCommand);
        }

        public void UpdateWallPost(String userID, String wallPost)
        {
            objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "UpdateWallPost";

            objCommand.Parameters.AddWithValue("@UserID", userID);
            objCommand.Parameters.AddWithValue("@WallPost", wallPost);

            objDB.GetDataSetUsingCmdObj(objCommand);
        }

        public void SendAFriendAMessage(int senderID, int receiverID, String messageBody, String firstName, String lastName)
        {
            objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "SendAFriendAMessage";

            objCommand.Parameters.AddWithValue("@senderID", senderID);
            objCommand.Parameters.AddWithValue("@receiverID", receiverID);
            objCommand.Parameters.AddWithValue("@messageBody", messageBody);
            objCommand.Parameters.AddWithValue("@firstName", firstName);
            objCommand.Parameters.AddWithValue("@lastName", lastName);

            objDB.GetDataSetUsingCmdObj(objCommand);
        }



        public DataSet GetMessagesTable()
        {
            objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetMessagesTable";

            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        public DataSet GetMyMessagesTable(int myID)
        {
            objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetMyMessagesTable";

            objCommand.Parameters.AddWithValue("@myID", myID);


            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        public DataSet GetAllPhotosForAUser(String userFirstName)
        {
            objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetAllPhotosForAUser";

            objCommand.Parameters.AddWithValue("@userFirstName", userFirstName);


            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        public void DeletePhotoWithImageId(String ImageId)
        {
            objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeletePhotoWithImageId";

            objCommand.Parameters.AddWithValue("@ImageId", int.Parse(ImageId));


            objDB.GetDataSetUsingCmdObj(objCommand);
        }



        public void DeleteMessageByRecordID(String RecordID)
        {
            objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "DeleteMessageByRecordID";

            objCommand.Parameters.AddWithValue("@RecordID", int.Parse(RecordID));


            objDB.GetDataSetUsingCmdObj(objCommand);
        }
    }
}
