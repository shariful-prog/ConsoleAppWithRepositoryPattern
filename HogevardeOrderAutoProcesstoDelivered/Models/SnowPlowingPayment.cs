using System;
using System.Collections.Generic;

#nullable disable

namespace HogevardeOrderAutoProcesstoDelivered.Models
{
    public partial class SnowPlowingPayment
    {
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal PayAmount { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentId { get; set; }
        public int Quantity { get; set; }
    }
}
