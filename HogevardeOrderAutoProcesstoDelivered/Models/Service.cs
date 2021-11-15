using System;
using System.Collections.Generic;

#nullable disable

namespace HogevardeOrderAutoProcesstoDelivered.Models
{
    public partial class Service
    {
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public string ServiceType { get; set; }
        public string ServiceName { get; set; }
        public string About { get; set; }
        public string RegularDelevery { get; set; }
        public decimal RegularDeleveryCharge { get; set; }
        public string EmergencyDelevery { get; set; }
        public decimal EmergencyDeleveryCharge { get; set; }
        public decimal ServiceCharge { get; set; }
        public string Unit { get; set; }
        public string DeleveryLocation { get; set; }
        public string Session { get; set; }
        public string Specification { get; set; }
        public string ServiceDetail { get; set; }
        public string ReturnCancelPolicy { get; set; }
        public decimal DeleveryLatitude { get; set; }
        public decimal DeleveryLongitude { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
