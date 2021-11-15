using System;
using System.Collections.Generic;

#nullable disable

namespace HogevardeOrderAutoProcesstoDelivered.Models
{
    public partial class TblOrderStatus
    {
        public string TransId { get; set; }
        public string OrderId { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }
        public string TransactionId { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string AccessToken { get; set; }
        public string ResponseBody { get; set; }
        public DateTime? ResquestTime { get; set; }
        public DateTime? ResponseTime { get; set; }
    }
}
