using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceBookHelper
{
    public class User
    {
        public int  UserID{get; set;}
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String PhoneNumber { get; set; }
        public String Address { get; set; }
        public String Email { get; set; }
        public String UserName { get; set; }
        public String Security1 { get; set; }
        public String Security2 { get; set; }
        public String Security3 { get; set; }
        public String PassWord { get; set; }
        public String Security1Question { get; set; }
        public String Security2Question { get; set; }
        public String Security3Question { get; set; }
        public String LoginPreferences { get; set; }
        public String Likes { get; set; }
        public String PhotoPath { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String WallPost { get; set; }

        public User(int userID, String firstName, String lastName, String phoneNumber, String address, String email, String userName, String security1, String security2, String security3, String passWord, String security1Question, String security2Question, String security3Question, String loginPreferences, String likes, String photoPath, String city, String state, String wallPost) 
        {
            UserID = userID; FirstName = firstName; LastName = lastName; PhoneNumber = phoneNumber;
            Address = address; Email = email; UserName = userName; Security1 = security1; Security2 = security2;
            Security3 = security3; PassWord = passWord; Security1Question = security1Question; Security2Question = security2Question;
            Security3Question = security3Question; LoginPreferences = loginPreferences; Likes = likes;
            PhotoPath = photoPath; City = city; State = state;
            WallPost = wallPost;
        }
    }
}
