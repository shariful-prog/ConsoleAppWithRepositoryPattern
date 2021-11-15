using System;
using System.Collections.Generic;

#nullable disable

namespace HogevardeOrderAutoProcesstoDelivered.Models
{
    public partial class CleaningOrder
    {
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public string ServiceType { get; set; }
        public string OrderStatus { get; set; }
        public string StatusChangedAt { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderDate { get; set; }
        public string ExpectedDeleveryDate { get; set; }
        public string ActualDeleveryDate { get; set; }
        public string OrderCode { get; set; }
        public string PaymentId { get; set; }
        public string CabinId { get; set; }
    }
}
