using core;
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
    public sealed partial class KitchenOrders : Page
    {
        public KitchenOrders()
        {
            Loaded += MainWindow_Loaded;
            this.InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //timeLbl.Text = getCurrentTime();
            //weatherLbl.Text = "";
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            dispatcherTimer.Tick += loadAsyncData;
            dispatcherTimer.Start();
            //This is to start the timer immediately
            loadAsyncData(null, null);

            //settingsMgr = new SettingsManager();
            //settingsMgr.loadDefaultSettings();
            //loadWeather();
        }


        private async void loadAsyncData(object sender, object e)
        {
            GposApi<List<RestaurantOrder>> gposApi = new GposApi<List<RestaurantOrder>>();
            var result = await gposApi.GetAsync("SaleOrders"); 
            foodOrdersList.ItemsSource = result;
        }
    }
}
