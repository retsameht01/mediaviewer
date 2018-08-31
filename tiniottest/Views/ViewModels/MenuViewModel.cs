using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tiniottest.core.Model;

namespace tiniottest.Views.ViewModels
{
    public class MenuViewModel
    {
        public MenuViewModel()
        {
            productCategories = new ObservableCollection<ProductCategory>();
        }

        public void setData(List<ProductCategory> categories)
        {
            productCategories.Clear();
            foreach(ProductCategory cat in categories)
            {
                productCategories.Add(cat);
            }   
        }

        public ObservableCollection<ProductCategory> productCategories{ get; }
    }
}
