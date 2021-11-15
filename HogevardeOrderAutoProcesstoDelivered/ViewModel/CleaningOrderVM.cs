using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogevardeOrderAutoProcesstoDelivered.ViewModel
{
    class CleaningOrderVM
    {
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public string OrderId { get; set; }
        public string PaymentId { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentStatus { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }
        public string Phone { get; set; }
        public string InvoiceId { get; set; }
        public string ServiceTypeName { get; set; }
        public string ServiceName { get; set; }
    }
}
