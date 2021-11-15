using System;
using System.Collections.Generic;

#nullable disable

namespace HogevardeOrderAutoProcesstoDelivered.Models
{
    public partial class Activity
    {
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public decimal? Charge { get; set; }
        public string Unit { get; set; }
        public string ImageUrl { get; set; }
        public string WebUrl { get; set; }
        public string Address { get; set; }
    }
}
