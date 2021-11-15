using System;
using System.Collections.Generic;

#nullable disable

namespace HogevardeOrderAutoProcesstoDelivered.Models
{
    public partial class Cabin
    {
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string ImageUrl { get; set; }
        public string OwnerId { get; set; }
        public string CabinType { get; set; }
        public string PlotNo { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
