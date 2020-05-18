using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.Inventory;
using Services.Product;

namespace Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<OrderService> _logger;
        private readonly IProductService _productService;
        private readonly IInventoryService _inventoryService;

        public OrderService(ApplicationDbContext dbContext,
            ILogger<OrderService> logger, IProductService productService, IInventoryService inventoryService)
        {
            _dbContext = dbContext;
            _logger = logger;
            _productService = productService;
            _inventoryService = inventoryService;
        }

        public ServiceResponse<bool> GenerateOpenOrder(SalesOrder order)
        {
            _logger.LogInformation("Generating new order");

            foreach (var item in order.SalesOrderItems)
            {
                item.Product = _productService.GetProductById(item.Product.Id);

                var inventoryId = _inventoryService.GetProductId(item.Product.Id).Id;

                _inventoryService.UpdateUnitsAvailable(inventoryId, -item.Quantity);
            }

            try
            {
                _dbContext.SalesOrders.Add(order);
                _dbContext.SaveChanges();

                return new ServiceResponse<bool>
                {
                    IsSuccess = true,
                    Data = true,
                    Message = "An order was created",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>
                {
                    IsSuccess = false,
                    Data = false,
                    Message = $"An error occurred with the following: {ex}",
                    Time = DateTime.UtcNow
                };
            }
        }

        public List<SalesOrder> GetAllOrders()
        {
            return _dbContext.SalesOrders
                .Include(so => so.Customer)
                .ThenInclude(customer => customer.PrimaryAddress)
                .Include(so => so.SalesOrderItems)
                .ThenInclude(item => item.Product)
                .ToList();
        }

        /// <summary>
        /// Marks an open SalesOrder as paid
        /// </summary>
        public ServiceResponse<bool> MarkComplete(int id)
        {
            var order = _dbContext.SalesOrders.Find(id);
            order.UpdatedOn = DateTime.UtcNow;
            order.IsPaid = true;

            try
            {
                _dbContext.SalesOrders.Update(order);
                _dbContext.SaveChanges();

                return new ServiceResponse<bool>
                {
                    IsSuccess = true,
                    Data = true,
                    Message = $"Order {order.Id} was completed and paid",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred with the following: {ex}");

                return new ServiceResponse<bool>
                {
                    IsSuccess = false,
                    Data = false,
                    Message = $"An error occurred with the following: {ex}", // e.StackTrace
                    Time = DateTime.UtcNow
                };
            }
        }
    }
}