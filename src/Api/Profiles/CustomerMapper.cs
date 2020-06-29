using Api.ViewModels;
using Data.Models;

namespace Api.Profiles
{
    public class CustomerMapper
    {
        public static CustomerModel SerializeCustomer(Customer customer)
        {
            var address = new CustomerAddressModel 
            {
                Id = customer.Id,
                CreatedOn = customer.CreatedOn,
                UpdatedOn = customer.UpdatedOn,
                AddressLine1 = customer.PrimaryAddress.AddressLine1,
                AddressLine2 = customer.PrimaryAddress.AddressLine2,
                Country = customer.PrimaryAddress.Country,
                State = customer.PrimaryAddress.State,
                City = customer.PrimaryAddress.City,
                PostalCode = customer.PrimaryAddress.PostalCode
            };

            return new CustomerModel
            {
                Id = customer.Id,
                CreatedOn = customer.CreatedOn,
                UpdatedOn = customer.UpdatedOn,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PrimaryAddress = address
            };
        }

        public static Customer SerializeCustomer(CustomerModel customer)
        {
            var address = new CustomerAddress
            {
                CreatedOn = customer.CreatedOn,
                UpdatedOn = customer.UpdatedOn,
                AddressLine1 = customer.PrimaryAddress.AddressLine1,
                AddressLine2 = customer.PrimaryAddress.AddressLine2,
                Country = customer.PrimaryAddress.Country,
                State = customer.PrimaryAddress.State,
                City = customer.PrimaryAddress.City,
                PostalCode = customer.PrimaryAddress.PostalCode
            };

            return new Customer
            {
                CreatedOn = customer.CreatedOn,
                UpdatedOn = customer.UpdatedOn,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PrimaryAddress = address
            };
        }
    }
}