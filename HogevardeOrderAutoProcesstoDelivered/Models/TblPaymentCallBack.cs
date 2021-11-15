using System;
using System.Collections.Generic;

#nullable disable

namespace HogevardeOrderAutoProcesstoDelivered.Models
{
    public partial class TblPaymentCallBack
    {
        public string TransId { get; set; }
        public string Msisdn { get; set; }
        public string OrderId { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }
        public string TransactionId { get; set; }
        public string TransTimeStamp { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserId { get; set; }
        public string UserSsn { get; set; }
        public string ShippingAdressOne { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingCity { get; set; }
        public string PostCode { get; set; }
        public string ShippingCost { get; set; }
        public string ShippingMethod { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
