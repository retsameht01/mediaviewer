using core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using tiniottest.core;
using tiniottest.core.Model;
using tiniottest.Views.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class KitchenOrdersBinding : Page
    {
        private GposApi<List<RestaurantOrder>> gposApi;
        private SettingsManager settingsManager;
        private int REFRESH_DELAY = 30;
        public KitchenOrdersBinding()
        {
            Loaded += MainWindow_Loaded;
            
            this.InitializeComponent();
            ViewModel = new KitchenViewModel();
            


            DataContext = ViewModel;
            timeLbl.Text = getCurrentTime();
        }

        public KitchenViewModel ViewModel { get; set; }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            settingsManager = new SettingsManager();
            gposApi = new GposApi<List<RestaurantOrder>>(settingsManager.getStringSettings(SettingKey.GPOS_API_URL_KEY),
                settingsManager.getStringSettings(SettingKey.GPOS_API_PASS_KEY));
            //timeLbl.Text = getCurrentTime();
            //weatherLbl.Text = "";
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, REFRESH_DELAY);
            dispatcherTimer.Tick += loadAsyncData;
            dispatcherTimer.Start();
            //This is to start the timer immediately
            loadAsyncData(null, null);
        }

        private String getCurrentTime()
        {
            DateTime localDate = DateTime.Now;
            var timeString = localDate.ToString("ddd MMM dd, hh:mm tt");
            return timeString;
        }


        private async void loadAsyncData(object sender, object e)
        {
            try
            {
                var result = await gposApi.GetAsync("SaleOrders");
                ViewModel.SetData(result);
                ordersCount.Text = String.Format("Orders: {0}", result.Count);

                /*var orderItems = new List<SaleOrderItem>();
                foreach (var order in result)
                {
                    orderItems.AddRange(order.SaleOrderItems);
                }
                ordersCount.Text = String.Format("Orders: {0}", orderItems.Count);
                foodOrdersList.ItemsSource = orderItems;

    */
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
           
        }

        
        private void RunOnUIThread()
        {

        }

        private void settingsBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Settings), null);
        }

        

        private void onOrderItemClick(object sender, ItemClickEventArgs e)
        {
            /*
            RestaurantOrder order = (RestaurantOrder)((GridView)sender).SelectedItem;
            if(order != null)
            {
                var dialog = new MessageDialog("Table Clicked: " + order.TableInfo, "Click");
                var result = dialog.ShowAsync();
            }
            */
            
        }

        private async void onOrderSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
            RestaurantOrder order = (RestaurantOrder)((GridView)sender).SelectedItem;
            if (order != null)
            {
                var completeMsg = String.Format("Complete Order #{0}?", order.Id);
                var title = String.Format("Table {0}", order.TableId);
                var dialog = new MessageDialog(completeMsg, title);
                dialog.Commands.Clear();
                dialog.Commands.Add(new UICommand { Label = "Yes", Id = 0 });
                dialog.Commands.Add(new UICommand { Label = "No", Id = 1 });

                var res = await dialog.ShowAsync();

                if ((int)res.Id == 0)
                {
                    //MessageDialog msgbox2 = new MessageDialog("Yes clicked", "User Response");
                    //await msgbox2.ShowAsync();
                    ViewModel.removeOrder(order);
                    //Handle update order from server

                }

                if ((int)res.Id == 1)
                {
                    MessageDialog msgbox2 = new MessageDialog("No clicked", "User Response");
                   await msgbox2.ShowAsync();
                }

                var result = dialog.ShowAsync();
            }
            */
        }

        private async void CompleteOrderClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            RestaurantOrder order = ViewModel.getOrder(button.Name);

            if (order != null && !ViewModel.wasOrderCompleted(order.Id))
            {
                var completeMsg = String.Format("Complete Order #{0}?", order.Id);
                var title = String.Format("Table {0}", order.TableId);
                var dialog = new MessageDialog(completeMsg, title);
                dialog.Commands.Clear();
                dialog.Commands.Add(new UICommand { Label = "Yes", Id = 0 });
                dialog.Commands.Add(new UICommand { Label = "No", Id = 1 });

                var res = await dialog.ShowAsync();

                if ((int)res.Id == 0)
                {


                    //Handle update order from server
                    order.Status = "Completed";
                   string result = await gposApi.PatchAsync("SaleOrders", order);
                    string removeMsg = string.Format("Order Removed result:{0}", result);
                    ViewModel.removeOrder(order);
                    MessageDialog deleteConfirmation = new MessageDialog(removeMsg, "Notice");
                    await deleteConfirmation.ShowAsync();
                }

                if ((int)res.Id == 1)
                {
                    MessageDialog msgbox2 = new MessageDialog("No clicked", "User Response");
                    await msgbox2.ShowAsync();
                }
            }

        }
    }
}
