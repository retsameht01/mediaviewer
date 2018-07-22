using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tiniottest.core.Model
{
    public class RestaurantOrder
    {
        public int Id { get; set; }
        public string OrderDate { get; set; }
        public string Status { get; set; }
        public string OrderNumber { get; set; }
        public string TerminalId { get; set; }
        public string TableName { get; set; }
        public int TableId { get; set; }
        public string Notes { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmailAddress { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public List<SaleOrderItem> SaleOrderItems { get; set; }
        // public List<object> Payments { get; set; }
        public decimal SubTotalBeforeTax { get; set; }
        public decimal SaleTax { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal Tips { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal BalanceDue { get; set; }
        public string CreatedBy { get; set; }

    }
}
