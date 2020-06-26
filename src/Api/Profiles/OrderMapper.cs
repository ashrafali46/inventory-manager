using System;
using System.Collections.Generic;
using System.Linq;
using Api.ViewModels;
using Data.Models;

namespace Api.Profiles
{
    public class OrderMapper
    {
        public static InvoiceModel SerializedInvoiceOrder(SalesOrder invoice)
        {
            return new InvoiceModel
            {

            };
        }

        public static SalesOrder SerializedInvoiceOrder(InvoiceModel invoice)
        {
            var salesOrderItems = invoice.LineItems.Select(item => new SalesOrderItem
            {
                Id = item.Id,
                    Quantity = item.Quantity,
                    Product = ProductMapper.SerializedProductModel(item.Product)
            }).ToList();

            return new SalesOrder
            {
                SalesOrderItems = salesOrderItems,
                    UpdatedOn = DateTime.UtcNow,
                    CreatedOn = DateTime.UtcNow
            };
        }

        public static List<OrderModel> SerializeOrderToViewModel(IEnumerable<SalesOrder> orders)
        {
            return orders.Select(order => new OrderModel 
            {
                Id = order.Id,
                CreatedOn = order.CreatedOn,
                UpdatedOn = order.UpdatedOn,
                SalesOrderItems = SerializeSalesOrderItems(order.SalesOrderItems),
                Customer = CustomerMapper.SerializesCustomer(order.Customer),
                IsPaid = order.IsPaid
            });
        }

        public static List<SalesOrderItem> SerializeSalesOrderItem(IEnumerable<SalesOrderItem> orderItems)
        {
            
        }
    }
}