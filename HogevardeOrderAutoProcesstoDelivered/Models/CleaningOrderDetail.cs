using System;
using System.Collections.Generic;

#nullable disable

namespace HogevardeOrderAutoProcesstoDelivered.Models
{
    public partial class CleaningOrderDetail
    {
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public string OrderId { get; set; }
        public string ServiceId { get; set; }
        public decimal ServiceCharge { get; set; }
        public string ServiceDeliveryType { get; set; }
        public decimal DeliveryCharge { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }
        public string PaymentStatus { get; set; }
        public string Session { get; set; }
        public string CalenderDate { get; set; }
        public int Quantity { get; set; }
        public string DeleveryLocation { get; set; }
        public string DeleveryLatitude { get; set; }
        public string DeleveryLongitude { get; set; }
        public string Issue { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string CleaningTypeName { get; set; }
        public string CleaningTypeId { get; set; }
        public string CleaningTypeAreaName { get; set; }
        public string CleaningTypeAreaId { get; set; }
        public decimal? CleaningTypeAreaPrice { get; set; }
    }
}
