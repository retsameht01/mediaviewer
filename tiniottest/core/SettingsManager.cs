using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tiniottest.core
{
    class SettingsManager
    {
       private Windows.Storage.ApplicationDataContainer localSettings;
       private Windows.Storage.StorageFolder localFolder;
        public SettingsManager()
        {
            localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        }


        public void saveSetting(string settingsKey, string settingValue)
        {
            localSettings.Values[settingsKey] = settingValue;
        }

        public string getStringSettings(string settingsKey)
        {
            string value = localSettings.Values[settingsKey] as string;
            return value;
        }


        public void loadSettings()
        { 
            //TODO test the saving and loading of settings to make sure it works
            if (this.getStringSettings(SettingKey.BUSINESS_NAME_KEY) == null || 
                this.getStringSettings(SettingKey.CITY_NAME_KEY) == null ||
                this.getStringSettings(SettingKey.GPOS_API_PASS_KEY) == null ||
                this.getStringSettings(SettingKey.GPOS_API_URL_KEY) == null ||
                this.getStringSettings(SettingKey.OPERATION_MODE_KEY) == null ||
                this.getStringSettings(SettingKey.OPERATION_MODE_KEY) == null
                ){
                this.saveSetting(SettingKey.BUSINESS_NAME_KEY, SettingKey.BUSINESS_NAME);
                this.saveSetting(SettingKey.CITY_NAME_KEY, SettingKey.CITY_NAME);
                this.saveSetting(SettingKey.GPOS_API_PASS_KEY, SettingKey.GPOS_API_PASS);
                this.saveSetting(SettingKey.GPOS_API_URL_KEY, SettingKey.GPOS_API_URL);
                this.saveSetting(SettingKey.OPERATION_MODE_KEY, SettingKey.OPERATING_MODE);
                this.saveSetting(SettingKey.THEME_OPTION_KEY, SettingKey.THEME_OPTION);
            }
            else
            {
                Console.WriteLine(" Settings " + SettingKey.BUSINESS_NAME_KEY + " value:" + this.getStringSettings(SettingKey.BUSINESS_NAME));

            }
        }

    }
}
