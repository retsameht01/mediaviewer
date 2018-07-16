using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tiniottest.core
{
    class SaleOrderItem
    {
        public int Id { get; set; }
        public string CreatedOn { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public object Location { get; set; }
        public int Quantity { get; set; }
        public int SaleTaxRate { get; set; }
        public int UnitPrice { get; set; }
        public int SaleTax { get; set; }
        public int Tip { get; set; }
        public int SubTotalBeforeTax { get; set; }
        public int GrandTotal { get; set; }
        public object Notes { get; set; }
        public string NameNotes { get; set; }
        public bool ServicePrinted { get; set; }
        public List<FoodModifier> Modifiers { get; set; }
    }
}
