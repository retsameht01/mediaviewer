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
        public KitchenViewModel()
        {
            Orders = new ObservableCollection<RestaurantOrder>();

        }

        public void SetData(List<RestaurantOrder> orders)
        {
            foreach (RestaurantOrder order in orders)
            {
                Orders.Add(order);
            }
        }

        public ObservableCollection<RestaurantOrder> Orders { get; set; }
    }
}
