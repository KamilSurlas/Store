using Microsoft.AspNetCore.Mvc;
using StoreMVC.BLL.Dto;
using StoreMVC.BLL.Repository.Basket;
using StoreMVC.BLL.Repository.Order;
using StoreMVC.BLL_EF;

namespace StoreMVC.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<OrderResponseDto>> GetAll() 
        {
            var orders = _orderRepository.GetOrders();
        
            return Ok(orders);  
        }
        [HttpGet("{userId}")]
        public ActionResult<OrderResponseDto> GetUserOrders(int userId)
        {
            var userOrders = _orderRepository.GetUserOrders(userId);

            return Ok(userOrders);
        }
        [HttpPost("{userId}")]
        public ActionResult AddOrder(int userId)
        {
            var id = _orderRepository.AddOrder(userId);

            return Created($"/api/basket/{id}", null);
        }
        [HttpGet("{orderId}")]
        public ActionResult<OrderPositionResponseDto> GetOrderPosition(int orderId,[FromQuery] int orderPositionId)
        {
            var orderPosition = _orderRepository.GetOrderPosition(orderId, orderPositionId);

            return Ok(orderPosition);
        }
    }
}
