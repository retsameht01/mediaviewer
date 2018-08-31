using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using tiniottest.core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace tiniottest.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Settings : Page
    {
        SettingsManager settingsMgr;
        public Settings()
        {
            Loaded += MainWindow_Loaded;
            this.InitializeComponent();

            
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            settingsMgr = new SettingsManager();
            var businessName = settingsMgr.getStringSettings(SettingKey.BUSINESS_NAME_KEY);
            var businessCity = settingsMgr.getStringSettings(SettingKey.CITY_NAME_KEY);
            var theme = settingsMgr.getStringSettings(SettingKey.THEME_OPTION_KEY);
            var gposUrl = settingsMgr.getStringSettings(SettingKey.GPOS_API_URL_KEY);
            var gposPass = settingsMgr.getStringSettings(SettingKey.GPOS_API_PASS_KEY);
            var mode = settingsMgr.getStringSettings(SettingKey.OPERATION_MODE_KEY);

            settingsBusinessName.Text = businessName;
            this.settingsCity.Text = businessCity;
            this.themColor.ItemsSource = new List<String>
            {
                "DARK",
                "LIGHT"
            };

            themColor.SelectedIndex = theme.Equals("DARK") ? 0 : 1;

            this.gposURL.Text = gposUrl;
            this.gposPassword.Text = gposPass;
            this.operationMode.ItemsSource = new List<String>
            {
                "WAITING LIST",
                "KITCHEN LIST"
            };
            operationMode.SelectedIndex = mode.Equals("WAITING LIST") ? 0 : 1;

        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            settingsMgr.saveSetting(SettingKey.BUSINESS_NAME_KEY, settingsBusinessName.Text);
            settingsMgr.saveSetting(SettingKey.CITY_NAME_KEY, settingsCity.Text);
            settingsMgr.saveSetting(SettingKey.GPOS_API_PASS_KEY, gposPassword.Text);
            settingsMgr.saveSetting(SettingKey.GPOS_API_URL_KEY, gposURL.Text);
            settingsMgr.saveSetting(SettingKey.OPERATION_MODE_KEY, operationMode.SelectionBoxItem.ToString());
            settingsMgr.saveSetting(SettingKey.THEME_OPTION_KEY, themColor.SelectionBoxItem.ToString());

            var OperationMode = settingsMgr.getStringSettings(SettingKey.OPERATION_MODE_KEY);
            this.Frame.GoBack();
            
            /*
            switch (OperationMode)
            {
                case "WAITING LIST":
                    this.Frame.Navigate(typeof(MainPage), null);
                    break;

                case "KITCHEN LIST":
                    this.Frame.Navigate(typeof(KitchenOrdersBinding), null);
                    break;
            }
            */
        }
    }
}
