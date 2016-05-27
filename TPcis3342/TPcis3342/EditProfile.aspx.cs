using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TuDInputCheckers;
using FaceBookHelper;

namespace TPcis3342
{
    public partial class EditProfile : System.Web.UI.Page
    {
        DataBaseRequest objDBhelper;
        EncryptedAndDecrypted crypto = new EncryptedAndDecrypted();
        SerializeAndDeserializing SerializeAndDeserializing;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.Cookies["CIS3342_Cookie"] != null)
            {
                HttpCookie cookieEdit = Request.Cookies["CIS3342_Cookie"];

                txtFirstName.Text = cookieEdit.Values["firstName"];
                txtLastName.Text = cookieEdit.Values["lastName"];
                txtPhoneNumber.Text = cookieEdit.Values["phoneNumber"];

                txtCity.Text = cookieEdit.Values["City"];
                txtState.Text = cookieEdit.Values["State"];
                // myCookie.Values["PhotoPath"];
                txtLikes.Text = cookieEdit.Values["Likes"];

                txtAddress.Text = cookieEdit.Values["address"];
                txtEmail.Text = cookieEdit.Values["email"];


                txtUserName.Text = cookieEdit.Values["userName"];
                //txtPassWord.Text = cookieEdit.Values["passWord"];
                txtPassWord.Text = crypto.PerformDecryption(cookieEdit.Values["passWord"]);//Decrypts password!

                lblQuestion1.Text = cookieEdit.Values["security1Question"];
                lblQuestion2.Text = cookieEdit.Values["security2Question"];
                lblQuestion3.Text = cookieEdit.Values["security3Question"];
                txtQuestion1.Text = cookieEdit.Values["security1"];
                txtQuestion2.Text = cookieEdit.Values["security2"];
                txtQuestion3.Text = cookieEdit.Values["security3"];


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

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }

        protected void btnSubmitUpdate_Click(object sender, EventArgs e)
        {
            SerializeAndDeserializing = new FaceBookHelper.SerializeAndDeserializing();

            HttpCookie cookie = Request.Cookies["CIS3342_Cookie"];

            String oldUsername = cookie.Values["userName"];
            String oldPassword = cookie.Values["passWord"];

            String firstName = txtFirstName.Text;
            String lastName = txtLastName.Text;
            String phoneNumber = txtPhoneNumber.Text;
            String address = txtAddress.Text;
            String email = txtEmail.Text;
            String newUserName = txtUserName.Text;
            String newPassWord = txtPassWord.Text;
            String newPassWordConfim = txtConfirmPassword.Text;
            String question1Response = txtQuestion1.Text;
            String question2Response = txtQuestion2.Text;
            String question3Response = txtQuestion3.Text;

            String city = txtCity.Text;
            String state = txtState.Text;
            String likes = txtLikes.Text;

            if ((firstName == "") || (lastName == "") || (phoneNumber == "") || (address == "") || (email == "") || (newUserName == "") || (newPassWord == "") || (newPassWordConfim == "") || (question1Response == "") || (question2Response == "") || (question3Response == "") || (city == "") || (state == "") || (likes == ""))
            {
                lblSubmitUpdate.Visible = true;
                lblSubmitUpdate.Text = "*All fields must be filled out*";
            }
            else
            {
                lblSubmitUpdate.Visible = false;
                Boolean passwordsMatch = false;
                if ((txtPassWord.Text) != (txtConfirmPassword.Text))
                {
                    lblPassWordConfim.Visible = true;
                    lblPassWordConfim.Text = "*Your passwords do not match*";
                    passwordsMatch = false;
                }
                else
                {
                    lblPassWordConfim.Visible = false;
                    passwordsMatch = true;
                }

                

                ////////code to check all the feilds have the right inputs 
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
                ////////code to check all the feilds have the right inputs 
                if ((Checker.AllAlphabetChars(firstName)) && (Checker.AllAlphabetChars(lastName)) && (Checker.ValidPhoneNumber(phoneNumber)) && (Checker.GoodEmailAddress(email)) && (passwordsMatch) && (Checker.AllAlphabetChars(city)) && (Checker.AllAlphabetChars(state)))
                {

                    objDBhelper = new FaceBookHelper.DataBaseRequest();

                    //alter this
                    int usernamePasswordComboUpdated = objDBhelper.UpdateUserInformation(txtFirstName.Text, txtLastName.Text, txtPhoneNumber.Text, txtAddress.Text, txtEmail.Text, oldUsername, oldPassword, txtUserName.Text, txtPassWord.Text, txtQuestion1.Text, txtQuestion2.Text, txtQuestion3.Text, txtCity.Text, txtState.Text, Checker.GoodLikesInput(txtLikes.Text));
                    //alter this



                    if (usernamePasswordComboUpdated != 0)
                    {
                        lblSubmitUpdate.Visible = false;

                        DataSet dsUserRecord = objDBhelper.GetUserRecordWithUsernamePassword(txtUserName.Text, txtPassWord.Text);//pulls User record linked to valid username/password combo

                        for (int i = 0; i < dsUserRecord.Tables.Count; i++)//loops through User record and creates a new cookie with all information linked to the User
                        {
                            HttpCookie myCookie = new HttpCookie("CIS3342_Cookie");//new cookie!

                            myCookie.Values["firstName"] = dsUserRecord.Tables[0].Rows[i]["FirstName"].ToString();
                            myCookie.Values["lastName"] = dsUserRecord.Tables[0].Rows[i]["LastName"].ToString();
                            myCookie.Values["phoneNumber"] = dsUserRecord.Tables[0].Rows[i]["PhoneNumber"].ToString();
                            myCookie.Values["address"] = dsUserRecord.Tables[0].Rows[i]["Address"].ToString();
                            myCookie.Values["email"] = dsUserRecord.Tables[0].Rows[i]["Email"].ToString();

                            myCookie.Values["userName"] = dsUserRecord.Tables[0].Rows[i]["UserName"].ToString();
                            //myCookie.Values["passWord"] = dsUserRecord.Tables[0].Rows[i]["PassWord"].ToString();
                            myCookie.Values["passWord"] = crypto.PerformEncryption(dsUserRecord.Tables[0].Rows[i]["PassWord"].ToString());//encrypt data

                            myCookie.Values["security1"] = dsUserRecord.Tables[0].Rows[i]["Security1"].ToString();
                            myCookie.Values["security2"] = dsUserRecord.Tables[0].Rows[i]["Security2"].ToString();
                            myCookie.Values["security3"] = dsUserRecord.Tables[0].Rows[i]["Security3"].ToString();

                            myCookie.Values["Security1Question"] = dsUserRecord.Tables[0].Rows[i]["Security1Question"].ToString();
                            myCookie.Values["Security2Question"] = dsUserRecord.Tables[0].Rows[i]["Security2Question"].ToString();
                            myCookie.Values["Security3Question"] = dsUserRecord.Tables[0].Rows[i]["Security3Question"].ToString();

                            myCookie.Values["loginPreferences"] = dsUserRecord.Tables[0].Rows[i]["loginPreferences"].ToString();

                            myCookie.Values["LastVisited"] = DateTime.Now.ToString();
                            myCookie.Expires = new DateTime(2025, 1, 1);

                            Response.Cookies.Add(myCookie);
                        }

                        lblSubmitUpdate.Visible = true;
                        lblSubmitUpdate.Text = "*Update Completed*";
                        





                        ////code here to send an email confirmation after the friend request is sent out ////code here to send an email confirmation after the friend request is sent out //
                        //HttpCookie cookieEdit = Request.Cookies["CIS3342_Cookie"];
                        //String myID = crypto.PerformDecryption(cookieEdit.Values["passWord"]);//Decrypts password!

                        //String yourEmail = "";
                        //DataSet friendsRecord = objDBhelper.GetUserRecordByID(int.Parse(myID));
                        //for (int i = 0; i < friendsRecord.Tables[0].Rows.Count; i++)
                        //{
                        //    yourEmail = friendsRecord.Tables[0].Rows[i]["Email"].ToString();
                        //}

                        ////code here to send an email confirmation after the friend request is sent out //
                        //Email objEmail = new Email();
                        //String strTO = yourEmail;
                        //String strFROM = "FaceBookAutomatedEmail.com";
                        //String strSubject = "testing out the email feature bro!";
                        //String strMessage = "Thanks for updating you information on " + DateTime.Now.ToString(); ;
                        //objEmail.SendMail(strTO, strFROM, strSubject, strMessage);
                        ////code here to send an email confirmation after the friend request is sent////code here to send an email confirmation after the friend request is sent out //
                    
                    }
                    else
                    {
                        lblSubmitUpdate.Visible = true;
                        lblSubmitUpdate.Text = "*Your password and username combination is already taken*";
                    }
                }
                else
                {
                    lblSubmitUpdate.Visible = true;
                    lblSubmitUpdate.Text = "*One or more of your fields are invalid in format*";
                }
            }


        }

        protected void btnUploadProfilePic_Click(object sender, EventArgs e)
        {
            objDBhelper = new FaceBookHelper.DataBaseRequest();

            HttpCookie myCookie = Request.Cookies["CIS3342_Cookie"];//Requests Cookie 
            String userId = myCookie.Values["userID"];

            if (fileUploadProfilePic.HasFile)
            {
                lblfileUploadProfilePic.Visible = false;

                String fileExtention = System.IO.Path.GetExtension(fileUploadProfilePic.FileName);//gets file's extention
                if ((fileExtention.ToLower() == ".png") || ((fileExtention.ToLower() == ".jpg")) || ((fileExtention.ToLower() == ".gif")) || ((fileExtention.ToLower() == ".jpeg")))
                {
                    lblfileUploadProfilePic.Visible = false;

                    int fileSize = fileUploadProfilePic.PostedFile.ContentLength;//gets size of file
                    if (fileSize > 1000000)
                    {
                        lblfileUploadProfilePic.Visible = true;
                        lblfileUploadProfilePic.Text = "*Maxium file size (1MB) exceeded*";
                        lblfileUploadProfilePic.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lblfileUploadProfilePic.Visible = false;

                        fileUploadProfilePic.SaveAs(Server.MapPath("~/Images/" + fileUploadProfilePic.FileName));
                        lblfileUploadProfilePic.Visible = true;
                        lblfileUploadProfilePic.Text = "*File Uploaded*";
                        lblfileUploadProfilePic.ForeColor = System.Drawing.Color.Green;//changes color of texts

                        //code here to update user's profile picture//
                        objDBhelper.UpdateUserPhotoPath(userId, "~/Images/" + fileUploadProfilePic.FileName);
                        //code here to update user's profile picture//
                    }

                }
                else
                {
                    lblfileUploadProfilePic.Visible = true;
                    lblfileUploadProfilePic.Text = "*Only files with file extentions .png and .jpg and .gif and .jpeg are allowed.*";
                    lblfileUploadProfilePic.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblfileUploadProfilePic.Visible = true;
                lblfileUploadProfilePic.Text = "*No picture is selescted*";
                lblfileUploadProfilePic.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnLogout_Click1(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }
    }
}