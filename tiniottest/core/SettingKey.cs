using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tiniottest.core
{
    static class SettingKey
    {

        public static string GPOS_SETTINGS_LOADED = "SETTINGS_LOADED";
        //Default settings value
        public static string GPOS_API_URL_KEY = "GPOS_API_URL";
        public static string GPOS_API_PASS_KEY = "GPOS_API_PASS";
        public static string OPERATION_MODE_KEY = "OPERATION_MODE";
        public static string THEME_OPTION_KEY = "THEME_OPTION";
        public static string BUSINESS_NAME_KEY = "BUSINESS_NAME";
        public static string CITY_NAME_KEY = "CITY_NAME";
        public static string IS_INTIAL_SETTINGS_LOADED_KEY = "INITIAL_SETTINGS_LOADED";

        public static string GPOS_API_URL = "https://www.gposdev.com/20002/api/";
        public static string GPOS_API_PASS = "6786716888";
        public static string OPERATING_MODE = "WAITING_LIST";
        public static string THEME_OPTION ="DARK";
        public static string BUSINESS_NAME = "GPOS";
        public static string CITY_NAME = "Atlanta";

        //Color scheme
        public static string DarkHeaderBGColor = "#344955";
        public static string DarkSignInListBGColor = "#232f34";
        public static string DarkListRowBGColor = "#4A6572";

    }
}
