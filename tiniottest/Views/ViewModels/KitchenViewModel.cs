using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tiniottest.core.Model;
using Windows.UI.Xaml;

namespace tiniottest.Views.ViewModels
{
    public class KitchenViewModel

    {

        private List<int> completedOrders;

        public event PropertyChangedEventHandler PropertyChanged;

        public KitchenViewModel()
        {
            Orders = new ObservableCollection<RestaurantOrder>();
            completedOrders = new List<int>();

        }

        public void SetData(List<RestaurantOrder> orders)
        {
            Orders.Clear();
            foreach (RestaurantOrder order in orders)
            {
                if (!completedOrders.Contains(order.Id) && order.Status.Equals("Pending", StringComparison.CurrentCultureIgnoreCase))
                {
                    Orders.Add(order);
                }
            }
        }

        public ObservableCollection<RestaurantOrder> Orders { get; }


        public void removeOrder(RestaurantOrder order)
        {
            completedOrders.Add(order.Id);
            Orders.Remove(order);
        }

        public RestaurantOrder getOrder(string orderId)
        {
            foreach(RestaurantOrder order in Orders)
            {
                if(order.IdString == orderId)
                {
                    return order;
                }
            }

            return null;
        }

        public bool wasOrderCompleted(int orderId)
        {
            return completedOrders.Contains(orderId);
        }

        public void UpdateItem(string orderId, string itemId)
        {
            foreach(RestaurantOrder order in Orders)
            {
                if(order.IdString.Equals(orderId, StringComparison.CurrentCultureIgnoreCase))
                {
                  foreach(SaleOrderItem item in order.SaleOrderItems)
                    {
                        if(item.OrderItemId.Equals(itemId))
                        {
                            item.ItemProcessed = true;
                            item.Vis = Visibility.Visible;
                        }
                    }
                }
            }
        }

    }
}
