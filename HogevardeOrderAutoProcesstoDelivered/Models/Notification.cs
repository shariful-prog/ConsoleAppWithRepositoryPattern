using System;
using System.Collections.Generic;

#nullable disable

namespace HogevardeOrderAutoProcesstoDelivered.Models
{
    public partial class Notification
    {
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public string UserId { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string ImageUrl { get; set; }
        public string ExpiredOn { get; set; }
        public bool? IsRead { get; set; }
        public string OrderId { get; set; }
    }
}
