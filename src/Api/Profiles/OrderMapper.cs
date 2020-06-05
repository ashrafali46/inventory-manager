using Api.ViewModels;

namespace Api.Profiles
{
    public class OrderMapper
    {
        public static OrderModel SerializedInvoiceOrder(Data.Models.SalesOrder order)
        {
            return new OrderModel
            {

            };

        }

        public static Data.Models.SalesOrder OrderSerializedModel(OrderModel order)
        {
            return new Data.Models.SalesOrder
            {
                Id = order.Id,

            };
        }
    }
}