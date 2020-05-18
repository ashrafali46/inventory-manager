using System.Collections.Generic;
using Data.Models;

namespace Services.Order
{
    public interface IOrderService
    {
       List<SalesOrder> GetAllOrders();
       ServiceResponse<bool> GenerateOpenOrder(SalesOrder order);
       ServiceResponse<bool> MarkComplete(int id); //mark fulfilled
    }
}