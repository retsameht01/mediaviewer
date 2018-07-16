using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tiniottest.core
{
    class RestaurantOrder
    {
        public int Id { get; set; }
        public string OrderDate { get; set; }
        public string Status { get; set; }
        public string OrderNumber { get; set; }
        public object TerminalId { get; set; }
        public object TableName { get; set; }
        public int TableId { get; set; }
        public object Notes { get; set; }
        public object CustomerPhone { get; set; }
        public object CustomerEmailAddress { get; set; }
        public object CustomerFirstName { get; set; }
        public object CustomerLastName { get; set; }
        public List<SaleOrderItem> SaleOrderItems { get; set; }
        // public List<object> Payments { get; set; }
        public int SubTotalBeforeTax { get; set; }
        public int SaleTax { get; set; }
        public int GrandTotal { get; set; }
        public int Tips { get; set; }
        public int PaidAmount { get; set; }
        public int BalanceDue { get; set; }
        public string CreatedBy { get; set; }

    }
}
