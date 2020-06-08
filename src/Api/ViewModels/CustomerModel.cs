using System;

namespace Api.ViewModels
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public CustomerAddressModel PrimaryAddress { get; set; }
    }
}