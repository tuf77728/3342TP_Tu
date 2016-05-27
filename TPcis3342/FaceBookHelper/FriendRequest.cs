using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceBookHelper
{
    public class FriendRequest
    {
        public int UserFriendID { get; set; }
        public String Friend1 { get; set; }
        public String Friend2 { get; set; }
        public String Status { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public String Friend1FirstName { get; set; }
        public String Friend1LastName { get; set; }

        public FriendRequest(int userFriendID, String friend1, String friend2, String status, String firstName, String lastName, String friend1FirstName, String friend1LastName) 
        {
            UserFriendID = userFriendID;
            Friend1 = friend1;
            Friend2 = friend2;
            Status = status;
            FirstName = firstName;
            LastName = lastName;

            Friend1FirstName = friend1FirstName;
            Friend1LastName = friend1LastName;
        }
    }
}
