using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace tiniottest.core.Model
{
    public class SaleOrderItem
    {
        public int Id { get; set; }
        public string CreatedOn { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public string Location { get; set; }
        public decimal Quantity { get; set; }
        public decimal SaleTaxRate { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SaleTax { get; set; }
        public decimal Tip { get; set; }
        public decimal SubTotalBeforeTax { get; set; }
        public decimal GrandTotal { get; set; }
        public string Notes { get; set; }
        public string NameNotes { get; set; }
        public bool ServicePrinted { get; set; }
        public List<FoodModifier> Modifiers { get; set; }
        public string OrderItems
        {
            get
            {
                return "" + Name + " Quantity " + Quantity;
            }


        }

        public string ItemDetails
        {
            get
            {
                return String.Format("{0}", Name);
            }
        }

        public string ItemQuantity
        {
            get
            {
                return "" + Quantity;
            }
        }

        public string ModifiersList        {
            get
            {
                var output = "";
                if (Modifiers != null && Modifiers.Count > 0)
                {
                    foreach(var mod in Modifiers)
                    {
                        output += "* " + mod.Name + "\n"; 
                    }
                }

                return output.ToUpper();
            }
        }

        public string OrderItemId
        {
            get
            {
                return "" + Id;
            }
        }

        private Visibility visibility = Visibility.Collapsed;
        public Visibility Vis
        {
            get
            {
                return visibility;
            }
            set
            {
                visibility = value;
            }
        }

        public bool ItemProcessed { get; set; }
    }
}
