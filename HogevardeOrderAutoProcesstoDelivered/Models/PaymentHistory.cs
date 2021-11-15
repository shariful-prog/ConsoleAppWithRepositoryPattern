using System;
using System.Collections.Generic;

#nullable disable

namespace HogevardeOrderAutoProcesstoDelivered.Models
{
    public partial class PaymentHistory
    {
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public string OrderId { get; set; }
        public string OrderDetailId { get; set; }
        public string TransactionId { get; set; }
        public string PaidWith { get; set; }
        public decimal PaidAmount { get; set; }
        public string Status { get; set; }
    }
}
