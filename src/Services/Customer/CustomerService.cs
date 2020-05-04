using System.Collections.Generic;

namespace Services.Customer
{
    public class CustomerService : ICustomerService
    {
        public ServiceResponse<Data.Models.Customer> CreateCustomer(Data.Models.Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResponse<bool> DeleteCustomer(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Data.Models.Customer> GetAllCustomers()
        {
            throw new System.NotImplementedException();
        }

        public Data.Models.Customer GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}