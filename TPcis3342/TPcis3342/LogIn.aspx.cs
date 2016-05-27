using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;  
using System.IO;                        
using System.Text;                      
using System.Net;
using FaceBookHelper;              

namespace TPcis3342
{
    public partial class LogIn : System.Web.UI.Page
    {
        FaceBookHelper.DataBaseRequest objDBhelper;
        EncryptedAndDecrypted crypto = new EncryptedAndDecrypted();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.Cookies["CIS3342_Cookie"] != null)
            {
                HttpCookie cookie = Request.Cookies["CIS3342_Cookie"];
                String loginPreferences = cookie.Values["loginPreferences"].ToString();

                if (loginPreferences == "Auto")
                {
                    txtUserName.Text = cookie.Values["userName"].ToString();

                    txtPassWord.Text = crypto.PerformDecryption(cookie.Values["passWord"].ToString());//Decrypts password stored in cookie
                }
                else if (loginPreferences == "Fast")
                {
                    txtUserName.Text = cookie.Values["userName"].ToString();
                }

                lblGreetings.Visible = true;
                lblGreetings.Text = "Welcome Back ";
                lblGreetings.Text += cookie.Values["firstName"].ToString() + " ";
                lblGreetings.Text += cookie.Values["lastName"].ToString();

                btnNotMe.Visible = true;
            }
        }



      
        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(2000);
            objDBhelper = new FaceBookHelper.DataBaseRequest();

            if ((txtUserName.Text == "") || (txtPassWord.Text == ""))
            {
                lblLoginInfo.Visible = true;
                lblLoginInfo.Text = "*All Feilds Must Be Filled Out*";
            }
            else
            {
                lblLoginInfo.Visible = false;

                String username = txtUserName.Text;
                String password = txtPassWord.Text;

                int goodUsernamePassword = objDBhelper.UserLogin(username, password);

                if (goodUsernamePassword == 0)
                {
                    lblLoginInfo.Visible = true;
                    lblLoginInfo.Text = "*Invalid Username/Password combo*";

                }
                else //good UsernamePassword combo did not return 0
                {
                    lblLoginInfo.Visible = false;

                    DataSet dsUserRecord = objDBhelper.GetUserRecordWithUsernamePassword(username, password);//pulls User record linked to valid username/password combo

                    for (int i = 0; i < dsUserRecord.Tables.Count; i++)//loops through User record and creates a new cookie with all information linked to the User
                    {
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
                    Response.Redirect("Home.aspx");
                }
            }
        }

        protected void btnNotMe_Click(object sender, EventArgs e)
        {
            btnNotMe.Visible = false;
            lblGreetings.Visible = false;
            txtUserName.Text = "";
            txtPassWord.Text = "";

            if (Request.Cookies["CIS3342_CookieCustom"] != null)
            {
                Response.Cookies["CIS3342_CookieCustom"].Expires = DateTime.Now.AddDays(-1);
            }
            
        }

        //protected void btnEncrypt_Click(object sender, EventArgs e)
        //{
        //    lblencrypt.Text = crypto.PerformEncryption(txtencrypt.Text);

        //}

        //protected void btnDecrypt_Click(object sender, EventArgs e)
        //{
        //    lbldecrypt.Text = crypto.PerformDecryption(txtdecrypt.Text);
        //}
    }
}