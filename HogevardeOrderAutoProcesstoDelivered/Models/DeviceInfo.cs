using System;
using System.Collections.Generic;

#nullable disable

namespace HogevardeOrderAutoProcesstoDelivered.Models
{
    public partial class DeviceInfo
    {
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public string UserId { get; set; }
        public string DeviceId { get; set; }
        public string DeviceType { get; set; }
        public string DeviceName { get; set; }
        public string DeviceVersion { get; set; }
    }
}
