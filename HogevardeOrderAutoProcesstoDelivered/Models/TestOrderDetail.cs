using System;
using System.Collections.Generic;

#nullable disable

namespace HogevardeOrderAutoProcesstoDelivered.Models
{
    public partial class TestOrderDetail
    {
        public double? CabinCharge { get; set; }
        public string CabinType { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string CurrentStatus { get; set; }
        public string DeliveryDate { get; set; }
        public double? EmergencyDeleveryCharge { get; set; }
        public string Id { get; set; }
        public double? IsEmergencyDelevery { get; set; }
        public string Issue { get; set; }
        public double? NeedDeliver { get; set; }
        public string Note { get; set; }
        public string OrderFor { get; set; }
        public string OrderId { get; set; }
        public double? Quantity { get; set; }
        public double? ServiceCharge { get; set; }
        public string ServiceId { get; set; }
        public double? TotalAmount { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
    }
}
