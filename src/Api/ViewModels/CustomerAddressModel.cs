using System;
using System.ComponentModel.DataAnnotations;

namespace Api.ViewModels
{
    public class CustomerAddressModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        [MaxLength(100)]
        public string AddressLine1 { get; set; }

        [MaxLength(100)]
        public string AddressLine2 { get; set; }

        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}