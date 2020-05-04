using System.Collections.Generic;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

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
            return _dbContext.Customers
                    .Include(x => x.PrimaryAddress)
                    .OrderBy(x => x.LastName)
                    .ToList();
        }

        public Data.Models.Customer GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}