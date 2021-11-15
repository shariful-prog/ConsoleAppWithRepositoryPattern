using System;
using System.Collections.Generic;

#nullable disable

namespace HogevardeOrderAutoProcesstoDelivered.Models
{
    public partial class ServiceType
    {
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public decimal YearlyServiceFee { get; set; }
        public string VoucherType { get; set; }
    }
}
