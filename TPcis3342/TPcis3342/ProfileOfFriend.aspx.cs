using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FaceBookHelper;


namespace TPcis3342
{
    public partial class ProfileOfFriend : System.Web.UI.Page
    {
        DataBaseRequest objDBhelper;//using FaceBookHelper;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objDBhelper = new DataBaseRequest();

                lblGreetings.Text = "Welcome to ";
                lblWall.Text = "";

                int friendsID = int.Parse(Session["FRIENDS_ID"].ToString());//pulls stored ID linked to friend's record
                DataSet friendsRecord = objDBhelper.GetUserRecordByID(friendsID);

                for (int i = 0; i < friendsRecord.Tables[0].Rows.Count; i++)
                {
                    lblGreetings.Text += friendsRecord.Tables[0].Rows[i]["FirstName"].ToString() + " ";
                    lblGreetings.Text += friendsRecord.Tables[0].Rows[i]["LastName"].ToString() + "'s Profile";
                    lblWall.Text += friendsRecord.Tables[0].Rows[i]["FirstName"].ToString() + " ";
                    lblWall.Text += friendsRecord.Tables[0].Rows[i]["LastName"].ToString() + "'s Wall";

                    lblFirstName.Text = friendsRecord.Tables[0].Rows[i]["FirstName"].ToString();
                    lblLastName.Text = friendsRecord.Tables[0].Rows[i]["LastName"].ToString();

                    lblPhoneNumber.Text = friendsRecord.Tables[0].Rows[i]["PhoneNumber"].ToString();
                    lblAddress.Text = friendsRecord.Tables[0].Rows[i]["Address"].ToString();
                    lblEmail.Text = friendsRecord.Tables[0].Rows[i]["Email"].ToString();
                    lblLikes.Text = friendsRecord.Tables[0].Rows[i]["Likes"].ToString();

                    imgUserProfilePic.ImageUrl = friendsRecord.Tables[0].Rows[i]["PhotoPath"].ToString();
                    lblCity.Text = friendsRecord.Tables[0].Rows[i]["City"].ToString();
                    lblState.Text = friendsRecord.Tables[0].Rows[i]["State"].ToString();
                }

                FillWall();//populates wall with posts from friends
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

        public void FillWall()
        {
            char[] targetChar = { '~' };
            String wallPostString = "";
            String longStringPosts = "";

            int friendsID = int.Parse(Session["FRIENDS_ID"].ToString());//pulls stored ID linked to friend's record

            DataSet friendsRecord = objDBhelper.GetUserRecordByID(friendsID);
            for (int i = 0; i < friendsRecord.Tables[0].Rows.Count; i++)
            {
                longStringPosts = friendsRecord.Tables[0].Rows[i]["WallPost"].ToString();
            }

            String[] posts = longStringPosts.Split(targetChar);

            for (int i = 0; i < posts.Length; i++)
            {
                wallPostString += posts[i] + "\n \n ";
            }

            txtFrindsWall.Text = wallPostString;
        }

        protected void btnLogout_Click1(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }

        protected void btnToHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}