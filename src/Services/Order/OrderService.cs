using System.Collections.Generic;
using Data.Models;

namespace Services.Order
{
    public class OrderService : IOrderService
    {
        public ServiceResponse<bool> GenerateInvoiceForOrder(SalesOrder order)
        {
            throw new System.NotImplementedException();
        }

        public List<SalesOrder> GetAOrders()
        {
            throw new System.NotImplementedException();
        }

        public ServiceResponse<bool> MarkComplete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}