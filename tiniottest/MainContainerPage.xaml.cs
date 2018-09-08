using System;
using System.Collections.Generic;
using tiniottest.core;
using tiniottest.core.Model;
using tiniottest.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace tiniottest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainContainerPage : Page
    {

        private SettingsManager settingsMgr;
        private static int TICK_INTERVAL = 60;
        private List<Type> mPages;
        private int currentPageIndex;
        private bool isSettingsActive = false;
       
        public MainContainerPage()
        {
            Loaded += MainWindow_Loaded;
            this.InitializeComponent();
            settingsMgr = new SettingsManager();

            var gposUrl = settingsMgr.getStringSettings(SettingKey.GPOS_API_URL_KEY);
            CoreSingle.Instance.BASE_ASSET_URL = gposUrl.Replace("api", "images");
            pageTitle.Text = "Menu List";
            var businessName = settingsMgr.getStringSettings(SettingKey.BUSINESS_NAME_KEY);
            this.businessTitle.Text = businessName;
            this.pageContent.Navigate(typeof(MenuList));
            currentPageIndex = 0;
            mPages = new List<Type>();
            mPages.Add(typeof(MenuList));
            mPages.Add(typeof(MainPage));

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            timeLbl.Text = getCurrentTime();
            weatherLbl.Text = "";
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, TICK_INTERVAL);
            dispatcherTimer.Tick += handlePageChange;
            dispatcherTimer.Start();
            loadWeather();
        }


        private void handlePageChange(object sender, object e)
        {
            currentPageIndex++;
            currentPageIndex = currentPageIndex % mPages.Count;
            this.pageContent.BackStack.Clear();
            if(currentPageIndex == 1)
            {
                pageTitle.Text = "Waiting List";
            }
            else
            {
                pageTitle.Text = "Menu List";
            }
            this.pageContent.Navigate(mPages[currentPageIndex]);
        }

        private async void loadWeather()
        {
            WeatherApi weatherApi = new WeatherApi();
            WeatherInfo weather;
            var city = settingsMgr.getStringSettings(SettingKey.CITY_NAME_KEY);
            if (city != null)
            {
                weather = await weatherApi.GetWeatherByCity(city);
            }
            else
            {
                weather = await weatherApi.GetWeather("30047");
            }

            if (weather != null)
            {
                weatherLbl.Text = weather.WeatherDisplayText;
                BitmapImage bitmap = new BitmapImage(new Uri(base.BaseUri, @"/Assets/" + weather.IconString + ".png"));
                weatherIcon.Source = bitmap;
                // "/Assets/" + weather.IconString + ".png";
            }
        }

        private String getCurrentTime()
        {
            DateTime localDate = DateTime.Now;
            var timeString = localDate.ToString("ddd MMM dd, hh:mm tt");
            return timeString;
        }

        private void goto_settings(object sender, RoutedEventArgs e)
        {
            this.pageContent.Navigate(typeof(Settings));
        }
    }
}
