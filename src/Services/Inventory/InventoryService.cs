using System.Collections.Generic;
using Data.Models;

namespace Services.Inventory
{
    public class InventoryService : IInventoryService
    {
        public void CreateSnapshot()
        {
            throw new System.NotImplementedException();
        }

        public List<ProductInventory> GetCurrentInventory()
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }
    }
}