using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Services.Inventory
{
    public class InventoryService : IInventoryService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<InventoryService> _logger;

        public InventoryService(ApplicationDbContext dbContext, ILogger<InventoryService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public void CreateSnapshot()
        {
            throw new System.NotImplementedException();
        }

        public List<ProductInventory> GetCurrentInventory()
        {
            return _dbContext.ProductInventories
                .Include(pi => pi.Product)
                .Where(pi => !pi.Product.IsArchived)
                .ToList();
        }

        public ProductInventory GetProductId(int productId)
        {
            throw new System.NotImplementedException();
        }

        public List<ProductInventorySnapshot> GetSnapshotHistory()
        {
            throw new System.NotImplementedException();
        }

        public ServiceResponse<ProductInventory> UpdateUnitsAvailable(int id, int adjusted)
        {
            try
            {
                var inventory = _dbContext.ProductInventories
                    .Include(inv => inv.Product)
                    .First(inv => inv.Product.Id == id);

                inventory.QuantityOnHand += adjusted;

                try
                {
                    CreateSnapshot();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"There was an error creating inventory snapshot, see the following error: {ex}");
                }

                _dbContext.SaveChanges();

                return new ServiceResponse<ProductInventory> 
                {
                    IsSuccess = true,
                    Data = inventory,
                    Message = $"Product with {id} had its inventory adjusted",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<ProductInventory> 
                {
                    IsSuccess = false,
                    Data = null,
                    Message = $"Error updating Product Inventory and Quantity On Hand, see the following error: {ex}",
                    Time = DateTime.UtcNow
                };
            }
        }
    }
}