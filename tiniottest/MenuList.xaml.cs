
using core;
using System.Collections.Generic;
using tiniottest.core;
using tiniottest.core.Model;
using tiniottest.Views.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace tiniottest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MenuList : Page
    {
        private SettingsManager settingsMgr;
        private GposApi<List<ProductCategory>> gposApi2;
        public MenuList()
        {
            Loaded += MainWindow_Loaded;
            this.InitializeComponent();
            ViewModel = new MenuViewModel();
            DataContext = ViewModel;
            settingsMgr = new SettingsManager();
            gposApi2 = new GposApi<List<ProductCategory>>(settingsMgr.getStringSettings(SettingKey.GPOS_API_URL_KEY), settingsMgr.getStringSettings(SettingKey.GPOS_API_PASS_KEY));
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            /*
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            dispatcherTimer.Tick += loadAsyncData;
            dispatcherTimer.Start();

            */
            //This is to start the timer immediately
            loadAsyncData(sender, e);
        }

        public MenuViewModel ViewModel { get; set; }

       
        private async void loadAsyncData(object sender, object e)
        {
            var categories = await gposApi2.GetAsync("Categories");//"ListProducts/?showProducts=true");
            ViewModel.setData(categories);
            //priceList.ItemsSource = products;
        }

    }
}
