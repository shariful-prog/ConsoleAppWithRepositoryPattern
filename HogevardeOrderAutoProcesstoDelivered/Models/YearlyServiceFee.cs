using System;
using System.Collections.Generic;

#nullable disable

namespace HogevardeOrderAutoProcesstoDelivered.Models
{
    public partial class YearlyServiceFee
    {
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public string Type { get; set; }
        public decimal PayAmount { get; set; }
        public string PayStatus { get; set; }
        public string Detail { get; set; }
        public string CabinId { get; set; }
        public string PaymentId { get; set; }
        public string ServiceType { get; set; }
        public int PayYearEnd { get; set; }
        public int PayYearStart { get; set; }
    }
}
