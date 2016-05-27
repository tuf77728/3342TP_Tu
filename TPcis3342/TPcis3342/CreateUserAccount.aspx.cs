using FaceBookHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TuDInputCheckers;

namespace TPcis3342
{
    public partial class CreateUserAccount : System.Web.UI.Page
    {
        FaceBookHelper.DataBaseRequest objDBhelper;
        EncryptedAndDecrypted crypto = new EncryptedAndDecrypted();
        SerializeAndDeserializing SerializeAndDeserializing = new SerializeAndDeserializing();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objDBhelper = new FaceBookHelper.DataBaseRequest();

                Session["SecurityQuestions1"] = objDBhelper.SecurityQuestions1;
                Session["SecurityQuestions2"] = objDBhelper.SecurityQuestions2;
                Session["SecurityQuestions3"] = objDBhelper.SecurityQuestions3;

                BindDropDownLists();
            }

        }

        public void BindDropDownLists()
        {
            ArrayList questionSet1 = (ArrayList)Session["SecurityQuestions1"];
            ArrayList questionSet2 = (ArrayList)Session["SecurityQuestions2"];
            ArrayList questionSet3 = (ArrayList)Session["SecurityQuestions3"];

            DropDownListQuestionSet1.DataSource = questionSet1;
            DropDownListQuestionSet1.DataBind();
            DropDownListQuestionSet2.DataSource = questionSet2;
            DropDownListQuestionSet2.DataBind();
            DropDownListQuestionSet3.DataSource = questionSet3;
            DropDownListQuestionSet3.DataBind();
        }



        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    Label4.Text = Checker.GoodLikesInput(txtLikes.Text);
        //}

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(2000);
            objDBhelper = new FaceBookHelper.DataBaseRequest();

            if ((txtFirstName.Text == "") || (txtLastName.Text == "") || (txtPhoneNumber.Text == "") || (txtAddress.Text == "") || (txtEmail.Text == "") || (txtUserName.Text == "") || (txtPassWord.Text == "") || (txtLikes.Text == "") || (txtCity.Text == "") || (txtState.Text== ""))
            {
                lblSubmitInfo.Visible = true;
                lblSubmitInfo.Text = "*All Fields Have To Be Filled Out*";
            }
            else
            {
                lblSubmitInfo.Visible = false;

                String firstName = txtFirstName.Text;
                String lastName = txtLastName.Text;
                String phoneNumber = txtPhoneNumber.Text;
                String address = txtAddress.Text;
                String email = txtEmail.Text;
                String userName = txtUserName.Text;
                String passWord = txtPassWord.Text;

                String security1 = txtQuestion1.Text;
                String security2 = txtQuestion2.Text;
                String security3 = txtQuestion3.Text;
                String likes = txtLikes.Text;
                String city = txtCity.Text;
                String state = txtState.Text;

                if (!Checker.AllAlphabetChars(city))
                {
                    lblCityInfo.Visible = true;
                    lblCityInfo.Text = "*Only Alphabetical Characters Allowed*";
                }
                else
                {
                    lblCityInfo.Visible = false;
                }

                if (!Checker.AllAlphabetChars(state))
                {
                    lblStateInfo.Visible = true;
                    lblStateInfo.Text = "*Only Alphabetical Characters Allowed*";
                }
                else
                {
                    lblStateInfo.Visible = false;
                }

                if (!Checker.AllAlphabetChars(firstName))
                {
                    lblFirstNameInfo.Visible = true;
                    lblFirstNameInfo.Text = "*Only Alphabetical Characters Allowed*";
                }
                else
                {
                    lblFirstNameInfo.Visible = false;
                }

                if (!Checker.AllAlphabetChars(lastName))
                {
                    lblLastNameInfo.Visible = true;
                    lblLastNameInfo.Text = "*Only Alphabetical Characters Allowed*";
                }
                else
                {
                    lblLastNameInfo.Visible = false;
                }


                if (!Checker.ValidPhoneNumber(phoneNumber))
                {
                    lblPhoneNumberInfo.Visible = true;
                    lblPhoneNumberInfo.Text = "*Vailid Format* <br/> Correct Format: 123-123-4567 ";
                }
                else
                {
                    lblPhoneNumberInfo.Visible = false;
                }

                if (!Checker.GoodEmailAddress(email))
                {
                    lblEmailInfo.Visible = true;
                    lblEmailInfo.Text = "*Invaild Email Format* <br/> Correct Format: <br/> abc@temple.edu or xyz@yahoo.com or love@gmail.gov";
                }
                else
                {
                    lblEmailInfo.Visible = false;
                }

                Boolean passwordsMatch = false;
                if ((txtPassWord.Text != txtConfirmPassword.Text))
                {
                    lblConfirmPassWord.Visible = true;
                    lblConfirmPassWord.Text = "*Your Passwords don't match*";
                    passwordsMatch = false;
                }
                else
                {
                    lblConfirmPassWord.Visible = false;
                    passwordsMatch = true;
                }

                //code here to check the txtLikes feild... the list of things the user likes to do has to be seperated by a comma

                //likes = objDBhelper.GoodLikesInput(likes);
                String modifedLikesInput = Checker.GoodLikesInput(likes);

                //code here to check the txtLikes feild... the list of things the user likes to do has to be seperated by a comma

                if ((Checker.AllAlphabetChars(firstName)) && (Checker.AllAlphabetChars(lastName)) && (Checker.ValidPhoneNumber(phoneNumber)) && (Checker.GoodEmailAddress(email)) && (passwordsMatch) && (Checker.AllAlphabetChars(city)) && (Checker.AllAlphabetChars(state)))
                {

                    int test = Convert.ToInt32(radLoginPreferences.SelectedValue);
                    String loginPreferences = "";
                    switch (test)
                    {
                        case 1:
                            loginPreferences = "None";
                            break;
                        case 2:
                            loginPreferences = "Fast";
                            break;
                        case 3:
                            loginPreferences = "Auto";
                            break;
                        default:
                            break;
                    }

                    lblSubmitInfo.Visible = false;

                    int goodUsernamePassword = objDBhelper.CreateUser(firstName, lastName, phoneNumber, address, email, userName, passWord, security1, security2, security3, DropDownListQuestionSet1.SelectedValue, DropDownListQuestionSet2.SelectedValue, DropDownListQuestionSet3.SelectedValue, loginPreferences, modifedLikesInput, city, state);
                    //if the username/password combo is not already taken than a user is created and added to the table

                    //the return from the "CreateUser" method will be an int
                    //0 = means the username/password combo is not in the system yet
                    // andything other than 0 means the username/password combo exists and the UserID of that user with this username/password combo is returned
                    if (goodUsernamePassword == 0)
                    {
                        lblSubmitInfo.Visible = true;
                        lblSubmitInfo.Text = "*Account Created*";

                        //code here to update the SettingsObject record in the database table for this user//
                        DataSet dsUserRecord = objDBhelper.GetUserRecordWithUsernamePassword(userName, passWord);//pulls User record linked to valid username/password combo
                        for (int i = 0; i < dsUserRecord.Tables.Count; i++)//loops through User record and creates a new cookie with all information linked to the User
                        {
                            int userID = int.Parse(dsUserRecord.Tables[0].Rows[i]["UserID"].ToString());
                            SerializeAndDeserializing.SerializingUserSettingsOBJ(userID, loginPreferences, "background-color:#dfe3ee");

                            if (Request.Cookies["CIS3342_CookieCustom"] != null)
                            {
                                Response.Cookies["CIS3342_CookieCustom"].Expires = DateTime.Now.AddDays(-1);
                            }

                            HttpCookie myCookie = new HttpCookie("CIS3342_Cookie");

                            myCookie.Values["userID"] = dsUserRecord.Tables[0].Rows[i]["UserID"].ToString();
                            myCookie.Values["firstName"] = dsUserRecord.Tables[0].Rows[i]["FirstName"].ToString();
                            myCookie.Values["lastName"] = dsUserRecord.Tables[0].Rows[i]["LastName"].ToString();
                            myCookie.Values["phoneNumber"] = dsUserRecord.Tables[0].Rows[i]["PhoneNumber"].ToString();

                            myCookie.Values["City"] = dsUserRecord.Tables[0].Rows[i]["City"].ToString();
                            myCookie.Values["State"] = dsUserRecord.Tables[0].Rows[i]["State"].ToString();
                            myCookie.Values["PhotoPath"] = dsUserRecord.Tables[0].Rows[i]["PhotoPath"].ToString();
                            myCookie.Values["Likes"] = dsUserRecord.Tables[0].Rows[i]["Likes"].ToString();

                            myCookie.Values["address"] = dsUserRecord.Tables[0].Rows[i]["Address"].ToString();
                            myCookie.Values["email"] = dsUserRecord.Tables[0].Rows[i]["Email"].ToString();

                            myCookie.Values["userName"] = dsUserRecord.Tables[0].Rows[i]["UserName"].ToString();
                            //myCookie.Values["passWord"] = dsUserRecord.Tables[0].Rows[i]["PassWord"].ToString();
                            myCookie.Values["passWord"] = crypto.PerformEncryption(dsUserRecord.Tables[0].Rows[i]["PassWord"].ToString());//encrypts password!

                            myCookie.Values["security1"] = dsUserRecord.Tables[0].Rows[i]["Security1"].ToString();
                            myCookie.Values["security2"] = dsUserRecord.Tables[0].Rows[i]["Security2"].ToString();
                            myCookie.Values["security3"] = dsUserRecord.Tables[0].Rows[i]["Security3"].ToString();

                            myCookie.Values["Security1Question"] = dsUserRecord.Tables[0].Rows[i]["Security1Question"].ToString();
                            myCookie.Values["Security2Question"] = dsUserRecord.Tables[0].Rows[i]["Security2Question"].ToString();
                            myCookie.Values["Security3Question"] = dsUserRecord.Tables[0].Rows[i]["Security3Question"].ToString();

                            myCookie.Values["WallPost"] = dsUserRecord.Tables[0].Rows[i]["WallPost"].ToString();

                            myCookie.Values["loginPreferences"] = dsUserRecord.Tables[0].Rows[i]["loginPreferences"].ToString();

                            myCookie.Values["LastVisited"] = DateTime.Now.ToString();
                            myCookie.Expires = new DateTime(2025, 1, 1);

                            Response.Cookies.Add(myCookie);
                        }
                        //code here to update the SettingsObject record in the database table for this user//
                        


                        int adjustSettingsNowValue = Convert.ToInt32(radAdjustSettingsNow.SelectedValue);
                        switch (adjustSettingsNowValue)
                        {
                            case 1:// user selects no, they do not want to change these setting now
                                Response.Redirect("Home.aspx");
                                break;
                            case 2://user selects yes, they do not want to change these setting now
                                Response.Redirect("GeneralAccountSettings.aspx");
                                break;
                            default:
                                break;
                        }

                        
                    }
                    else //goodUsernamePassword is not 0
                    {
                        lblSubmitInfo.Visible = true;
                        lblSubmitInfo.Text = "*Username/Password combination is already taken**";
                    }
                }
                else
                {
                    lblSubmitInfo.Visible = true;
                    lblSubmitInfo.Text = "*One Or More Fields Are Invalid*";
                }
            }


        }

       
    }
}