using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilities;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using FaceBookHelper;

namespace TPcis3342
{
    public partial class GeneralAccountSettings : System.Web.UI.Page
    {
        FaceBookHelper.DataBaseRequest objDBhelper;
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        SerializeAndDeserializing SerializeAndDeserializing = new SerializeAndDeserializing();


        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    if (Request.Cookies["CIS3342_Cookie"] == null)
            //    {
            //        Response.Redirect("Login.aspx");
            //    }
            //    else
            //    {
            //        /*
            //         * Deserialize user settings by getting their userID stored in the cookie
            //         */
            //        HttpCookie myCookie = Request.Cookies["CIS3342_Cookie"];
            //        String userName = myCookie.Values["UserName"].ToString();
            //        String loginPreferences = myCookie.Values["loginPreferences"].ToString();
            //        String strSQL = "SELECT UserSettings FROM TP_UserAccounts WHERE UserName = '" + userName + "'";
            //        objDB.GetDataSet(strSQL);

            //        if (objDB.GetField("UserSettings", 21) != System.DBNull.Value)
            //        {
            //            Byte[] byteArray = (Byte[])objDB.GetField("UserSettings", 21);
            //            BinaryFormatter deSerializer = new BinaryFormatter();
            //            MemoryStream memStream = new MemoryStream(byteArray);

            //            UserSettings objUserSettings = (UserSettings)deSerializer.Deserialize(memStream);
            //            lblSaveINFO.Text = "Your settings were found!";
            //        }
            //        else
            //        {
            //            lblSaveINFO.Text = "Your settings were never saved for this account.";
            //            lblSaveINFO.Visible = true;
            //        }
            //    }
            //}


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
        }
        protected void ddlBackgroundColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            int strDdlValue = Convert.ToInt32(ddlBackgroundColors.SelectedValue);

            switch (strDdlValue)
            {
                case 1:
                    PageBody.Attributes.Add("style", "background-color:#dfe3ee");
                    break;
                case 2:
                    PageBody.Attributes.Add("style", "background-color:#ff0000");
                    break;
                case 3:
                    PageBody.Attributes.Add("style", "background-color:#00ff00");
                    break;
                case 4:
                    PageBody.Attributes.Add("style", "background-color:#0000ff");
                    break;
                case 5:
                    PageBody.Attributes.Add("style", "background-color:#ffff00");
                    break;
                case 6:
                    PageBody.Attributes.Add("style", "background-color:#00ffff");
                    break;
                case 7:
                    PageBody.Attributes.Add("style", "background-color:#ffb6c1");
                    break;
                case 8:
                    PageBody.Attributes.Add("style", "background-color:#fff");
                    break;
                case 9:
                    PageBody.Attributes.Add("style", "background-color:#000");
                    break;

                default:
                    break;
            }
        }

        protected void ddlFontColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            int strDdlValue = Convert.ToInt32(ddlFontColors.SelectedValue);

            switch (strDdlValue)
            {
                case 1:
                    PageBody.Attributes.Add("style", "color:#000");
                    break;
                case 2:
                    PageBody.Attributes.Add("style", "color:#ff0000");
                    break;
                case 3:
                    PageBody.Attributes.Add("style", "color:#00ff00");
                    break;
                case 4:
                    PageBody.Attributes.Add("style", "color:#0000ff");
                    break;
                case 5:
                    PageBody.Attributes.Add("style", "color:#ffff00");
                    break;
                case 6:
                    PageBody.Attributes.Add("style", "color:#00ffff");
                    break;
                case 7:
                    PageBody.Attributes.Add("style", "color:#ffb6c1");
                    break;
                case 8:
                    PageBody.Attributes.Add("style", "color:#fff");
                    break;


                default:
                    break;
            }

        }

        protected void ddlFontTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int strDdlValue = Convert.ToInt32(ddlFontTypes.SelectedValue);

            switch (strDdlValue)
            {
                case 1:
                    PageBody.Attributes.Add("style", "font-family:Serif");
                    break;
                case 2:
                    PageBody.Attributes.Add("style", "font-family:Sans-Serif");
                    break;
                case 3:
                    PageBody.Attributes.Add("style", "font-family:Monospace");
                    break;
                case 4:
                    PageBody.Attributes.Add("style", "font-family:Fantasy");
                    break;
                case 5:
                    PageBody.Attributes.Add("style", "font-family:Script");
                    break;
                default:
                    break;
            }
        }

        protected void ddlThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int strDdlValue = Convert.ToInt32(ddlThemes.SelectedValue);

            switch (strDdlValue)
            {
                case 1:
                    PageBody.Attributes.Add("style", "background-color:#000;color:#fff;font-family:Monospace");
                    break;
                case 2:
                    PageBody.Attributes.Add("style", "background-color:#fff;color:#000;font-family:Fantasy");
                    break;
                case 3:
                    PageBody.Attributes.Add("style", "background-color:#00ff00;color:#ff0000;font-family:Script");
                    break;
                default:
                    break;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            objDBhelper = new FaceBookHelper.DataBaseRequest();
            SerializeAndDeserializing = new FaceBookHelper.SerializeAndDeserializing();

            String backgroundColors = "";
            String fontColors = "";
            String fontTypes = "";
            String theme = "";

            ////backgroundColors
            int strDdlValue = Convert.ToInt32(ddlBackgroundColors.SelectedValue);
            switch (strDdlValue)
            {
                case 1:
                    backgroundColors = "background-color:#000";
                    break;
                case 2:
                    backgroundColors = "background-color:#ff0000";
                    break;
                case 3:
                    backgroundColors = "background-color:#00ff00";
                    break;
                case 4:
                    backgroundColors = "background-color:#0000ff";
                    break;
                case 5:
                    backgroundColors = "background-color:#ffff00";
                    break;
                case 6:
                    backgroundColors = "background-color:#00ffff";
                    break;
                case 7:
                    backgroundColors = "background-color:#ffb6c1";
                    break;
                case 8:
                    backgroundColors = "background-color:#fff";
                    break;
                case 9:
                    backgroundColors = "background-color:#dfe3ee";
                    break;

                default:
                    break;
            }

            int strDdlValuefontColors = Convert.ToInt32(ddlFontColors.SelectedValue);

            switch (strDdlValuefontColors)
            {
                case 1:
                    fontColors = "color:#000";
                    break;
                case 2:
                    fontColors = "color:#ff0000";
                    break;
                case 3:
                    fontColors = "color:#00ff00";
                    break;
                case 4:
                    fontColors = "color:#0000ff";
                    break;
                case 5:
                    fontColors = "color:#ffff00";
                    break;
                case 6:
                    fontColors = "color:#00ffff";
                    break;
                case 7:
                    fontColors = "color:#ffb6c1";
                    break;
                case 8:
                    fontColors = "color:#fff";
                    break;

                default:
                    break;
            }

            int strDdlValuefontTypes = Convert.ToInt32(ddlFontTypes.SelectedValue);

            switch (strDdlValuefontTypes)
            {
                case 1:
                    fontTypes = "font-family:Serif";
                    break;
                case 2:
                    fontTypes = "font-family:Sans-Serif";
                    break;
                case 3:
                    fontTypes = "font-family:Monospace";
                    break;
                case 4:
                    fontTypes = "font-family:Fantasy";
                    break;
                case 5:
                    fontTypes = "font-family:Script";
                    break;
                default:
                    break;
            }

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

            HttpCookie myCookieTheme = new HttpCookie("CIS3342_CookieCustom");

            myCookieTheme.Values["backgroundColors"] = backgroundColors;
            myCookieTheme.Values["fontColors"] = fontColors;
            myCookieTheme.Values["fontTypes"] = fontTypes;
            myCookieTheme.Values["themes"] = theme;
            myCookieTheme.Expires = new DateTime(2025, 1, 1);

            Response.Cookies.Add(myCookieTheme);

            HttpCookie cookie = Request.Cookies["CIS3342_Cookie"];
            String tempUsername = cookie.Values["userName"].ToString();
            String tempPassword = cookie.Values["passWord"].ToString();

            objDBhelper.ChangeUserloginPreference(tempUsername, tempPassword, loginPreferences);//updates user's "Login Preferences" record in database table

            cookie.Values["loginPreferences"] = loginPreferences;//updates cookie "loginPreferences" value
            Response.Cookies.Add(cookie);


            lblSaveINFO.Visible = true;
            lblSaveINFO.Text = "*User's Settings Saved*";

            //code here to serialize the user's loginPreferences and background color
            HttpCookie cookieUser = Request.Cookies["CIS3342_Cookie"];

            int userIDCookie = int.Parse(cookieUser.Values["userID"]);
            String loginPreferencesCookie = cookieUser.Values["loginPreferences"];

            SerializeAndDeserializing.SerializingUserSettingsOBJ(userIDCookie, loginPreferencesCookie, backgroundColors);
            //code here to serialize the user's loginPreferences and background color


            //HttpCookie myCookie = Request.Cookies["CIS3342_Cookie"];
            //String myEmail = myCookie.Values["Email"];
            ////code here to send an email confirmation after the friend request is sent out //
            //Email objEmail = new Email();
            //String strTO = myEmail;//insert the recipient's email address here
            //String strFROM = "Face Book Maintenance Team";
            //String strSubject = "Update Account";
            //String strMessage = "Thank For Updating Your Account!";
            //objEmail.SendMail(strTO, strFROM, strSubject, strMessage);
            ////code here to send an email confirmation after the friend request is sent//




            //string loginSettings, privacySettings, fontTypeSettings, fontColorSettings,
            //    backgroundColorSettings, themeSettings;

            //loginSettings = radLoginPreferences.Text;
            //privacySettings = radPrivacySettings.SelectedItem.Text;
            //fontTypeSettings = ddlFontTypes.SelectedItem.Text;
            //fontColorSettings = ddlFontColors.SelectedItem.Text;
            //backgroundColorSettings = ddlBackgroundColors.SelectedItem.Text;
            //themeSettings = ddlThemes.SelectedItem.Text;

            //if (themeSettings == null)
            //{
            //    UserSettings objUserSettings = new UserSettings();
            //    objUserSettings.LoginSettings = loginSettings;
            //    objUserSettings.PrivacySettings = privacySettings;
            //    objUserSettings.FontTypeSettings = fontTypeSettings;
            //    objUserSettings.FontColorSettings = fontColorSettings;
            //    objUserSettings.BackgroundColorSettings = backgroundColorSettings;

            //    BinaryFormatter serializer = new BinaryFormatter();
            //    MemoryStream memStream = new MemoryStream();
            //    Byte[] byteArray;
            //    serializer.Serialize(memStream, objUserSettings);
            //    byteArray = memStream.ToArray();

            //    objCommand.CommandType = CommandType.StoredProcedure;
            //    objCommand.CommandText = "StoreUserSettings";


            //    objCommand.Parameters.AddWithValue("@theUserSettings", byteArray);

            //    int retVal = objDB.DoUpdateUsingCmdObj(objCommand);

            //    if (retVal > 0)
            //    {
            //        lblSaveINFO.Text = "Your settings were successfully saved!";
            //    }
            //    else
            //    {
            //        lblSaveINFO.Text = "Oops, a problem occured while storing your settings.";
            //    }
            //}
            //else
            //{
            //    UserSettings objUserSettings = new UserSettings();
            //    objUserSettings.LoginSettings = loginSettings;
            //    objUserSettings.PrivacySettings = privacySettings;
            //    objUserSettings.ThemeSettings = themeSettings;

            //    BinaryFormatter serializer = new BinaryFormatter();
            //    MemoryStream memStream = new MemoryStream();
            //    Byte[] byteArray;
            //    serializer.Serialize(memStream, objUserSettings);
            //    byteArray = memStream.ToArray();

            //    objCommand.CommandType = CommandType.StoredProcedure;
            //    objCommand.CommandText = "StoreUserSettings";

            //    objCommand.Parameters.AddWithValue("@theUserSettings", byteArray);

            //    int retVal = objDB.DoUpdateUsingCmdObj(objCommand);

            //    if (retVal > 0)
            //    {
            //        lblSaveINFO.Text = "Your settings were successfully saved!";
            //    }
            //    else
            //    {
            //        lblSaveINFO.Text = "Oops, a problem occured while storing your settings.";
            //    }


            //}



        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }

        protected void btnLogout_Click1(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }
    }
}