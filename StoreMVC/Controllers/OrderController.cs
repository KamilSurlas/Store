using Microsoft.AspNetCore.Mvc;
using StoreMVC.BLL.Dto;
using StoreMVC.BLL.Repository.Basket;
using StoreMVC.BLL.Repository.Order;
using StoreMVC.BLL_EF;

namespace StoreMVC.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [HttpGet("all")]
        public ActionResult<IEnumerable<OrderResponseDto>> GetAll() 
        {
            var orders = _orderRepository.GetOrders();
        
            return Ok(orders);  
        }
        [HttpGet]
        public ActionResult<OrderResponseDto> GetUserOrders()
        {
            var userOrders = _orderRepository.GetUserOrders();

            return Ok(userOrders);
        }
        [HttpPost("{userId}")]
        public ActionResult AddOrder()
        {
            var id = _orderRepository.AddOrder();

            return Created($"/api/basket/{id}", null);
        }
        [HttpGet("{orderId}/orderPosition/{orderPositionId}")]
        public ActionResult<OrderPositionResponseDto> GetOrderPosition([FromRoute]int orderId,[FromRoute] int orderPositionId)
        {
            var orderPosition = _orderRepository.GetOrderPosition(orderId, orderPositionId);

            return Ok(orderPosition);
        }
        [HttpGet("{orderId}")]
        public ActionResult<OrderResponseDto> GetOrderById([FromRoute] int orderId)
        {
            var order = _orderRepository.GetOrderById(orderId);
            return Ok(order);
        }
    }
}
