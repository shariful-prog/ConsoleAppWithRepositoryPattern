using System;
using System.Collections.Generic;

#nullable disable

namespace HogevardeOrderAutoProcesstoDelivered.Models
{
    public partial class SnowPlowingOrderHistory
    {
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public string OrderId { get; set; }
        public string Status { get; set; }
        public string OrderInvoiceId { get; set; }
        public string OrderDetailsId { get; set; }
    }
}
