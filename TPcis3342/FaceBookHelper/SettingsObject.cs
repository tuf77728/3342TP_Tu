using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceBookHelper
{
    [Serializable]
    public class SettingsObject
    {
        public String LoginPreferences { get; set; }
        public String BackGroundColor { get; set; }

        public SettingsObject(String loginPreferences, String backGroundColor)
        {
            LoginPreferences = loginPreferences;
            BackGroundColor = backGroundColor;
        }
    }
}
