using System;
using System.Collections.Generic;

#nullable disable

namespace HogevardeOrderAutoProcesstoDelivered.Models
{
    public partial class Profile
    {
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public string Gender { get; set; }
        public string Dob { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string RegisterWith { get; set; }
        public string Languages { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
    }
}
