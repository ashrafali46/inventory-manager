using System.Collections.Generic;
using Data.Models;

namespace Services.Inventory
{
    public interface IInventoryService
    {
         List<ProductInventory> GetCurrentInventory();
         ServiceResponse<ProductInventory> UpdateUnitsAvailable(int id, int adjusted);
         ProductInventory GetProductId(int productId);
         List<ProductInventorySnapshot> GetSnapshotHistory();   
    }
}