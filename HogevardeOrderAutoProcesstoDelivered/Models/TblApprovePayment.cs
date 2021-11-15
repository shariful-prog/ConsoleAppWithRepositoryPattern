using System;
using System.Collections.Generic;

#nullable disable

namespace HogevardeOrderAutoProcesstoDelivered.Models
{
    public partial class TblApprovePayment
    {
        public string TransId { get; set; }
        public string Msisdn { get; set; }
        public string OrderId { get; set; }
        public string ApproveToken { get; set; }
        public string AccessToken { get; set; }
        public string Status { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }
        public DateTime? RequestTime { get; set; }
        public DateTime? ResponseTime { get; set; }
    }
}
