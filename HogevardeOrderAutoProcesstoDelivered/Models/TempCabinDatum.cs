using System;
using System.Collections.Generic;

#nullable disable

namespace HogevardeOrderAutoProcesstoDelivered.Models
{
    public partial class TempCabinDatum
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int? Zipcode { get; set; }
        public string City { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string Cabintype { get; set; }
        public string Plot { get; set; }
        public string Felt { get; set; }
        public string Gnr { get; set; }
        public string Bnr { get; set; }
    }
}
