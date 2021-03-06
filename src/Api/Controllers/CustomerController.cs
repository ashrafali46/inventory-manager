using System.Linq;
using Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Customer;

namespace Api.Controllers
{
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly CustomerService _customerService;
        
        public CustomerController(ILogger<CustomerController> logger, CustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }
        
        [HttpGet]
        public ActionResult GetCustomers()
        {
            _logger.LogInformation("Fetching all customers");

            var customers = _customerService.GetAllCustomers();

            var customerModels = customers.Select(customer => new CustomerModel {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                CreatedOn = customer.CreatedOn,
                UpdatedOn = customer.UpdatedOn
            })
            .OrderByDescending(customer => customer.CreatedOn)
            .ToList();

            return Ok(customerModels);
        }

        [HttpGet("id")]
        public ActionResult GetCustomer(int id)
        {
            _logger.LogInformation($"Getting a single customer of id: {id}");
            
            return Ok();
        }
    }
}