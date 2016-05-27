using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceBookHelper
{
    public class UserSettings
    {
        //int UserID { get; set; }
        string loginSettings;
        string privacySettings;
        string fontTypeSettings;
        string fontColorSettings;
        string backgroundColorSettings;
        string themeSettings;

        public UserSettings()
        {
            //UserID = 0;
            loginSettings = "";
            privacySettings = "";
            fontTypeSettings = "";
            fontColorSettings = "";
            backgroundColorSettings = "";
            themeSettings = "";
        } //end default constructor

        /*
         * For Users who select multiple settings
         */
        public UserSettings(string myLoginSettings, string myPrivacySettings, string myFontTypeSettings,
            string myFontColorSettings, string myBackgroundColorSettings)
        {
            //UserID = myUserID;
            loginSettings = myLoginSettings;
            privacySettings = myPrivacySettings;
            fontTypeSettings = myFontTypeSettings;
            fontColorSettings = myFontColorSettings;
            backgroundColorSettings = myFontColorSettings;
        } //end paramterzed constructor 

        /*
         * For users who select THE THEME SETTING
         */
        public UserSettings(string myLoginSettings, string myPrivacySettings,
            string myThemeSettings)
        {
            //UserID = myUserID;
            loginSettings = myLoginSettings;
            privacySettings = myPrivacySettings;
            themeSettings = myThemeSettings;
        } //end parameterized constructor 

        //Getter & Setters
        public String LoginSettings
        {
            get { return loginSettings; }
            set { loginSettings = value; }
        }

        public String PrivacySettings
        {
            get { return privacySettings; }
            set { privacySettings = value; }
        }

        public String FontTypeSettings
        {
            get { return fontTypeSettings; }
            set { fontTypeSettings = value; }
        }

        public String FontColorSettings
        {
            get { return fontColorSettings; }
            set { fontColorSettings = value; }
        }

        public String BackgroundColorSettings
        {
            get { return backgroundColorSettings; }
            set { backgroundColorSettings = value; }
        }

        public String ThemeSettings
        {
            get { return themeSettings; }
            set { themeSettings = value; }
        }

    } //end class

} //end namespace
