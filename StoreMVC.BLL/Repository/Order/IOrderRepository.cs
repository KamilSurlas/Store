using StoreMVC.BLL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMVC.BLL.Repository.Order
{
    public interface IOrderRepository
    {
        int AddOrder();
        IEnumerable<OrderResponseDto> GetOrders();
        IEnumerable<OrderResponseDto> GetUserOrders();
        OrderPositionResponseDto GetOrderPosition(int orderId, int orderPositionId);
        OrderResponseDto GetOrderById(int orderId);
    }
}
