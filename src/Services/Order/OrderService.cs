using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<OrderService> _logger;

        public OrderService(ApplicationDbContext dbContext, ILogger<OrderService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public ServiceResponse<bool> GenerateInvoiceForOrder(SalesOrder order)
        {
            throw new System.NotImplementedException();
        }

        public List<SalesOrder> GetAllOrders()
        {
            return _dbContext.SalesOrders
                .Include(so => so.Customer)
                .Include(so => so.SalesOrderItems)
                .ToList();
        }

        public ServiceResponse<bool> MarkComplete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}