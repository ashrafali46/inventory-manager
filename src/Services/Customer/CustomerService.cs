using System;
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
            try
            {
                _dbContext.Customers.Add(customer);

                _dbContext.SaveChanges();

                return new ServiceResponse<Data.Models.Customer>
                {
                    IsSuccess = true,
                    Message = "New customer added",
                    Time = DateTime.UtcNow,
                    Data = customer
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Data.Models.Customer>
                {
                    IsSuccess = false,
                    Message = $"Failed to add a new customer with the following error: {ex}",
                    Time = DateTime.UtcNow,
                    Data = customer
                };
            }
        }

        public ServiceResponse<bool> DeleteCustomer(int id)
        {
            var customer = _dbContext.Customers.Find(id);

            if (customer == null)
                return new ServiceResponse<bool>
                {
                    Time = DateTime.UtcNow,
                    IsSuccess = false,
                    Message = $"the Customer object by {id} could not be found",
                    Data = false
                };

            try
            {
                _dbContext.Customers.Remove(customer);

                _dbContext.SaveChanges();

                return new ServiceResponse<bool>
                {
                    IsSuccess = true,
                    Message = $"The customer object with {id} was removed from the database",
                    Time = DateTime.UtcNow,
                    Data = false
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>
                {
                    IsSuccess = false,
                    Message = $"Failed to add a new customer with the following error: {ex}",
                    Time = DateTime.UtcNow,
                    Data = false
                };
            }
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
            return _dbContext.Customers.Find(id);
        }
    }
}