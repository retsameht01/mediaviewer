using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tiniottest.core.Model
{
    public class Product
    {
        public int Id { get; set; }
        public int ListProductId { get; set; }
        public int DisplayOrder { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public object Details { get; set; }
        public string SKU { get; set; }
        public string StandardCost { get; set; }
        public string Price { get; set; }
        public string QOH { get; set; }
        public string Duration { get; set; }
        public string SaleTaxRate { get; set; }
        public string ImageUri { get; set; }
        public int MinQuantity { get; set; }
        public int MaxQuantity { get; set; }
        public bool ShowOnApp { get; set; }
        public object PrinterName { get; set; }
    }
}
