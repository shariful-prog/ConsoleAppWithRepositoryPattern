using System;
using System.Collections.Generic;

#nullable disable

namespace HogevardeOrderAutoProcesstoDelivered.Models
{
    public partial class SnowPlowingOrderDetail
    {
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public string OrderId { get; set; }
        public string ServiceId { get; set; }
        public decimal ServiceCharge { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public string CurrentStatus { get; set; }
        public string Issue { get; set; }
        public string Note { get; set; }
        public bool? IsEmergencyDelevery { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal CabinCharge { get; set; }
        public string CabinType { get; set; }
        public bool? NeedDeliver { get; set; }
        public string OrderFor { get; set; }
        public decimal EmergencyDeleveryCharge { get; set; }
    }
}
