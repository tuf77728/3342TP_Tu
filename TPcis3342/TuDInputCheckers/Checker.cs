using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuDInputCheckers
{
    public class Checker
    {
        public Checker() 
        { 
        
        }

        public static Boolean AllNumber(string inputString) 
        {
            char[] charArray = inputString.ToCharArray();//converts input into an Array of char values
            char[] numberCharArray = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            Boolean allNumbers = true;
            foreach (char item in charArray)
            {
                if (!numberCharArray.Contains(item))//checks each character in charArray, and makes sure no number values are present
                {
                    allNumbers = false;
                }
            }
            return allNumbers;
        }

        public static Boolean AllAlphabetChars(string inputString)
        {
            char[] charArray = inputString.ToCharArray();//converts input into an Array of char values
            char[] numberCharArray = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            Boolean allAlphabetChars = true;
            foreach (char item in charArray)
            {
                if (numberCharArray.Contains(item))//checks each character in charArray, and makes sure no number values are present
                {
                    allAlphabetChars = false;
                }
            }
            return allAlphabetChars;
        }

        public static Boolean ValidPhoneNumber(String inputString) 
        {
            char[] charArray = inputString.ToCharArray();//converts input into an Array of char values
                char[] numberCharArray = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

                Boolean validPhoneNumber = true;

                if (charArray.Length != 12)
                {
                    validPhoneNumber = false;
                }
                else if ((charArray[3] == '-') & (charArray[7] == '-'))
                {
                    for (int i = 0; i < charArray.Length; i++)
                    {
                        if ((i != 3) & (i != 7))
                        {
                            if (!numberCharArray.Contains(charArray[i]))
                            {
                                validPhoneNumber = false;
                            }
                        }
                    }
                }
                else 
                {
                    validPhoneNumber = false;
                }

                return validPhoneNumber;
        }

        public static Boolean GoodEmailAddress(String inputString) 
        {
            char[] intputStringChar = inputString.ToCharArray();
            int hits = 0;
            Boolean goodEmailAddress = true;

            foreach (char item in intputStringChar)
            {
                if (item == '@')
                {
                    hits++;
                }
            }
            
            if (inputString.Length >= 4)
            {
                String tempString = inputString;
                int tempStringLength = tempString.Length;
                String dotCom = tempString.Substring((tempStringLength - 4));

                if ((hits == 1) && ((dotCom == ".com") || (dotCom == ".edu") || (dotCom == ".gov")))
                {
                    goodEmailAddress = true;
                }
                else if (hits > 1)
                {
                    goodEmailAddress = false;
                }
                else
                {
                    goodEmailAddress = false;
                }
            }
            else
            {
                goodEmailAddress = false;
            }
            return goodEmailAddress;
        }

        public static Boolean GoodDateOfBirth(String inputString)
        {
            Boolean GoodDateOfBirth = true;
            DateTime tempDateOfSession;

            if (DateTime.TryParse(inputString, out tempDateOfSession))//the input feild that gets checked first 
            {
                int year = int.Parse(tempDateOfSession.Year.ToString());

                if ((year > 1900) & (year < 2010))
                {
                    GoodDateOfBirth = true;
                }
                else
                {
                    GoodDateOfBirth = false;
                }
            }
            else
            {
                GoodDateOfBirth = false;
            }

            return GoodDateOfBirth;
        }

        public static String  GoodLikesInput(String inputString)
        {
            String modifiedString = "";

            char[] charArray = { ',' };
            String[] tempLikesArray;

            Boolean isFirst = true;
      
            if (inputString.Contains(','))//more than one "likes" input
            {
                tempLikesArray = inputString.Split(charArray);

                for (int i = 0; i < tempLikesArray.Length; i++)
                {
                    String tempString = tempLikesArray[i].Trim();

                    if (tempString == "")//blank spots
                    {
                        continue;
                    }
                    else
                    {
                        if (isFirst)
                        {
                            modifiedString += tempString;
                            isFirst = false;
                        }
                        else
                        {
                            modifiedString += ", " + tempString;//adds comma inbetween likes
                        }
                    
                    }
                    
                }
                return modifiedString;
            }
            else
            {
                modifiedString= inputString;
                return modifiedString;
            }
            
        }
    }
}
