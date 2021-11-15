using System;
using System.Collections.Generic;

#nullable disable

namespace HogevardeOrderAutoProcesstoDelivered.Models
{
    public partial class TblAccessTokenRequest
    {
        public string TransId { get; set; }
        public string TokenType { get; set; }
        public string AccessToken { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string RequestUrl { get; set; }
        public string Response { get; set; }
        public DateTime? RequestTime { get; set; }
        public DateTime? ResponseTime { get; set; }
    }
}
