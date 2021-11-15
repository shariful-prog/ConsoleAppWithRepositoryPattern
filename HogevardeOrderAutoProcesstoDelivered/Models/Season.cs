using System;
using System.Collections.Generic;

#nullable disable

namespace HogevardeOrderAutoProcesstoDelivered.Models
{
    public partial class Season
    {
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public string Name { get; set; }
        public string StartMonth { get; set; }
        public int StartMonthValue { get; set; }
        public string EndMonth { get; set; }
        public int EndMonthValue { get; set; }
    }
}
