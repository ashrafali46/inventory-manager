using System.Collections.Generic;

namespace Services.Inventory
{
    public interface IInventoryService
    {
         List<Data.Models.ProductInventory> GetCurrentInventory();
         ServiceResponse<Data.Models.ProductInventory> UpdateUnitsAvailable(int id, int adjusted);
         Data.Models.ProductInventory GetProductId(int productId);
         void CreateSnapshot();
         List<Data.Models.ProductInventorySnapshot> GetSnapshotHistory();   
    }
}