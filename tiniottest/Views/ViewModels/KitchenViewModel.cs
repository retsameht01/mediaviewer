using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tiniottest.core.Model;

namespace tiniottest.Views.ViewModels
{
    public class KitchenViewModel
    {

        private List<int> completedOrders;
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

        public ObservableCollection<RestaurantOrder> Orders { get; set; }


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
    }
}
