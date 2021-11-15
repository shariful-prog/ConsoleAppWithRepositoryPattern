using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogevardeOrderAutoProcesstoDelivered.Setting
{
    public class Notification 
    {
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string ImageUrl { get; set; }
        public string ExpiredOn { get; set; }
        public bool IsRead { get; set; }
    }
}
