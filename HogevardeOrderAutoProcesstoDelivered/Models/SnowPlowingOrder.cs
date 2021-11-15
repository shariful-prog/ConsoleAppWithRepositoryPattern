using System;
using System.Collections.Generic;

#nullable disable

namespace HogevardeOrderAutoProcesstoDelivered.Models
{
    public partial class SnowPlowingOrder
    {
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public string ServiceType { get; set; }
        public string VoucherType { get; set; }
        public string OrderStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderDate { get; set; }
        public string Session { get; set; }
        public string EndDate { get; set; }
        public string StartDate { get; set; }
        public string Month { get; set; }
        public string ServiceTypeName { get; set; }
        public string SessionName { get; set; }
        public string Week { get; set; }
        public string CabinId { get; set; }
        public string OrderFor { get; set; }
    }
}
