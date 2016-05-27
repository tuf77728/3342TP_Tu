using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceBookHelper
{
    public class Message
    {
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }

        public String MessageBody { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public Message(int senderID, int receiverID, String messageBody, String firstName, String lastName)
        {
            SenderID = senderID;
            ReceiverID = receiverID;
            MessageBody = messageBody;
            FirstName = firstName;
            LastName = lastName;

        }
    }
}
