using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
