
using core;
using core.Model;
using System;
using System.Collections.Generic;
using tiniottest.core;
using tiniottest.core.Model;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace tiniottest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private SettingsManager settingsMgr;
        private GposApi<List<WaitingCustomer>> gposApi;
        private GposApi<List<ListProduct>> gposApi2;
        private int runningTime;
        private static int TIME_BETWEEN_CHANGES = 60;
        public MainPage()
        {
            Loaded += MainWindow_Loaded;
            this.InitializeComponent();
            runningTime = 0;
            settingsMgr = new SettingsManager();
            gposApi = new GposApi<List<WaitingCustomer>>(settingsMgr.getStringSettings(SettingKey.GPOS_API_URL_KEY),
                settingsMgr.getStringSettings(SettingKey.GPOS_API_PASS_KEY));

            gposApi2 = new GposApi<List<ListProduct>>(settingsMgr.getStringSettings(SettingKey.GPOS_API_URL_KEY), settingsMgr.getStringSettings(SettingKey.GPOS_API_PASS_KEY));
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            dispatcherTimer.Tick += loadAsyncData;
            dispatcherTimer.Start();
            //This is to start the timer immediately
            loadAsyncData(null, null);
        }

       

        private async void loadAsyncData(object sender, object e)
        {
            var result = await gposApi.GetAsync("signIns");
            signinList.ItemsSource = result;
        }

        private String getCurrentTime()
        {
            DateTime localDate = DateTime.Now;
            var timeString = localDate.ToString("ddd MMM dd, hh:mm tt");
            return timeString;
        }
    }
}
