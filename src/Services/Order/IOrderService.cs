using System.Collections.Generic;

namespace Services.Order
{
    public interface IOrderService
    {
       List<Data.Models.SalesOrder> GetAllOrders(); 
    }
}