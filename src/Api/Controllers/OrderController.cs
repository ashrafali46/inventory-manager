using Api.Serialization;
using Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Customer;
using Services.Order;

namespace Api.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;

        public OrderController(ILogger<OrderController> logger,IOrderService orderService, ICustomerService customerService)
        {
            _customerService = customerService;
            _orderService = orderService;
            _logger = logger;
        }

        [HttpPost("api/invoice")]
        public ActionResult GenerateNewOrder([FromBody] InvoiceModel invoice)
        {
            _logger.LogInformation("Getting an order");

            var order = OrderMapper.SerializeInvoiceOrder(invoice);

            order.Customer = _customerService.GetById(invoice.CustomerId);

            _orderService.GenerateOpenOrder(order);

            return Ok();
        }
    }
}