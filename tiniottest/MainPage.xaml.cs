
using core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using tiniottest.core;
using tiniottest.Views;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

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
        public MainPage()
        {
            Loaded += MainWindow_Loaded;
            this.InitializeComponent();
            settingsMgr = new SettingsManager();
            gposApi = new GposApi<List<WaitingCustomer>>(settingsMgr.getStringSettings(SettingKey.GPOS_API_URL_KEY),
                settingsMgr.getStringSettings(SettingKey.GPOS_API_PASS_KEY));
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            timeLbl.Text = getCurrentTime();
            weatherLbl.Text = "";
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            dispatcherTimer.Tick += loadAsyncData;
            dispatcherTimer.Start();
            //This is to start the timer immediately
            loadAsyncData(null, null);
            loadWeather();
        }

        private async void loadWeather()
        {
            WeatherApi weatherApi = new WeatherApi();
            WeatherInfo weather;
            var city = settingsMgr.getStringSettings(SettingKey.CITY_NAME_KEY);
            if ( city != null)
            {
                weather = await weatherApi.GetWeatherByCity(city);
            } else
            {
                weather = await weatherApi.GetWeather("30047");
            }
            
            if(weather != null)
            {
                weatherLbl.Text = weather.WeatherDisplayText;
                BitmapImage bitmap = new BitmapImage(new Uri(base.BaseUri, @"/Assets/" + weather.IconString+".png"));
                weatherIcon.Source = bitmap;
                
                // "/Assets/" + weather.IconString + ".png";
            }
        }

        private async void loadAsyncData(object sender, object e)
        {
            
            var result = await gposApi.GetAsync("signIns");
            signinList.ItemsSource = result;
            timeLbl.Text = getCurrentTime();
        }

        private String getCurrentTime()
        {
            DateTime localDate = DateTime.Now;
            var timeString = localDate.ToString("ddd MMM dd, hh:mm tt");
            return timeString;
        }

        private void settingsBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Settings), null);   
        }

        private void setTheme(string theme)
        {
            if (theme.Equals("LIGHT")) {



            }  else
            {

            }

        }
    }
}
