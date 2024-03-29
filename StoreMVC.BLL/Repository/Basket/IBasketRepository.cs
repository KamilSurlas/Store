using StoreMVC.BLL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMVC.BLL.Repository.Basket
{
    public interface IBasketRepository
    {
        IEnumerable<BasketPositionResponseDto> GetUserBasket(int userId);
        int AddBasketPosition(BasketPositionRequestDto dto);
        void DeleteBasketPosition(int basketPositionId);
        void UpdateBasketPositionAmount(int basketPositionId, int amount);
    }
}
