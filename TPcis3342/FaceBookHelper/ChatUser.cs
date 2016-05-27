using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceBookHelper
{
    public class ChatUser
    {
        string userID;
        string userName;
        bool isActive;
        DateTime lastOnline;
        int lastMessageReceived;

        public ChatUser(string newUserID, string newUsername)
        {
            userID = newUserID;
            userName = newUsername;
            isActive = false;
            lastOnline = DateTime.MinValue;
            lastMessageReceived = 9;
        } //end public ChatUser

        public void Dispose()
        {
            userID = "";
            userName = "";
            isActive = false;
            lastOnline = DateTime.MinValue;
            lastMessageReceived = 0;
        } //end public void Dispose()

        public String UserID
        {
            get { return userID; }
            set { userID = value; } 
        }

        public String Username
        {
            get { return userName; }
            set { userName = value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; } 
        }

        public DateTime LastOnline
        {
            get { return lastOnline; }
            set { lastOnline = value; }
        }

        public int LastMessageReceived
        {
            get { return lastMessageReceived; }
            set { lastMessageReceived = value; }
        }
    } //end class
} //end namespace
