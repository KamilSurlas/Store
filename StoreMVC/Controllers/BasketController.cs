using Microsoft.AspNetCore.Mvc;
using StoreMVC.BLL.Dto;
using StoreMVC.BLL.Repository.Basket;
using StoreMVC.BLL_EF.Repository;

namespace StoreMVC.Controllers
{
    [Route("api/basket")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }
        [HttpGet("{userId}")]
        public ActionResult<IEnumerable<BasketPositionResponseDto>> GetUserBasket(int userId)
        {
            var userBasket = _basketRepository.GetUserBasket(userId);

            return Ok(userBasket);
        }
        [HttpPost("basketPosition")]
        public ActionResult AddBasketPosition([FromBody] BasketPositionRequestDto dto)
        {
            var id = _basketRepository.AddBasketPosition(dto);

            return Created($"/api/basket/basketPosition/{id}", null);
        }
        [HttpDelete("{basketPositionId}")]
        public ActionResult DeleteBasketPosition(int basketPositionId)
        {
            _basketRepository.DeleteBasketPosition(basketPositionId);

            return NoContent();
        }
        [HttpPut("{basketPositionId}")]
        public ActionResult UpdateBasketPositionAmount(int basketPositionId,[FromQuery] int newAmount)
        {
            _basketRepository.UpdateBasketPositionAmount(basketPositionId, newAmount);

            return Ok();
        }
    }
}
