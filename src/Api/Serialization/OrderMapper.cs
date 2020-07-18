using System;
using System.Collections.Generic;
using System.Linq;
using Api.ViewModels;
using Data.Models;

namespace Api.Serialization
{
    public static class OrderMapper
    {
        ///<summary>
        /// Maps an InvoiceModel (view model) to a SalesOrder (data) model
        ///</summary>
        ///<param name="invoice"></param>
        ///<returns></returns>
        
        public static SalesOrder SerializeInvoiceOrder(InvoiceModel invoice)
        {
            var salesOrderItems = invoice.LineItems.Select(item => new SalesOrderItem
            {
                Id = item.Id,
                Quantity = item.Quantity,
                Product = ProductMapper.SerializeProductModel(item.Product)
            }).ToList();

            return new SalesOrder
            {
                SalesOrderItems = salesOrderItems,
                UpdatedOn = DateTime.UtcNow,
                CreatedOn = DateTime.UtcNow
            };
        }

        public static List<OrderModel> SerializeOrdersToViewModels(IEnumerable<SalesOrder> orders)
        {
            return orders.Select(order => new OrderModel 
            {
                Id = order.Id,
                CreatedOn = order.CreatedOn,
                UpdatedOn = order.UpdatedOn,
                SalesOrderItems = SerializeSalesOrderItems(order.SalesOrderItems),
                Customer = CustomerMapper.SerializeCustomer(order.Customer),
                IsPaid = order.IsPaid
            }).ToList();
        }

        private static List<SalesOrderItemModel> SerializeSalesOrderItems(IEnumerable<SalesOrderItem> orderItems)
        {
            return orderItems.Select(item => new SalesOrderItemModel
            {
                Id = item.Id,
                Quantity = item.Quantity,
                Product = ProductMapper.SerializeProductModel(item.Product)
            }).ToList();
        }
    }
}