using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreMVC.BLL.Dto;
using StoreMVC.BLL.Repository.Order;
using StoreMVC.BLL_EF.Exceptions;
using StoreMVC.DataAccess;
using StoreMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMVC.BLL_EF.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderRepository(StoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        private User GetUserById(int userId)
        {
            var user = _dbContext.Users
               .Include(u => u.UserBasketPositions)
               .FirstOrDefault(u => u.UserId == userId);

            if (user is null) throw new ContentNotFoundException($"User with id: {userId} was not found");

            return user;
        }
        private Order GetOrderById(int orderId)
        {
            var order = _dbContext.Orders.Include(o => o.OrderPositions)
                .FirstOrDefault(o => o.OrderId == orderId);

            if (order is null) throw new ContentNotFoundException($"Order with id: {orderId} was not found");

            return order;
        }
        private OrderPosition GetOrderPositionById(int orderPositionId)
        {
            var orderPosition = _dbContext.OrderPositions.FirstOrDefault(op => op.OrderPositionId == orderPositionId);

            if (orderPosition is null) throw new ContentNotFoundException($"Order position with id: {orderPositionId} was not found");

            return orderPosition;
        }
        public int AddOrder(int userId)
        {
            var user = GetUserById(userId);

            if (user.UserBasketPositions is null) throw new ContentNotFoundException($"User's with id: {userId} basket is empty");

            var order = _mapper.Map<Order>(user.UserBasketPositions);
            //var order = new Order()
            //{
            //    UserId = userId,
            //    User = user,
            //    OrderPositions = user.UserBasketPositions.Select(bp => new OrderPosition
            //    {
            //        Order = null!,
            //        ProductId = bp.ProductId,
            //        Product = bp.Product,
            //        Price = bp.Product.Price * bp.Amount,
            //        Amount = bp.Amount
            //    })   
            //};
            //foreach (var orderPosition in order.OrderPositions)
            //{
            //    orderPosition.Order = order;
            //}

            _dbContext.BasketPositions.RemoveRange(user.UserBasketPositions);
            _dbContext.SaveChanges();

            return order.OrderId;
        }

        public OrderPositionResponseDto GetOrderPosition(int orderId, int orderPositionId)
        {
            var order = GetOrderById(orderId);

            var orderPosition = GetOrderPositionById(orderPositionId);

            if (orderPosition.OrderId != orderId) throw new InvalidDataException($"Order position with id: {orderPositionId} is not assigned to order with id: {orderId}");
                       

            var result = _mapper.Map<OrderPositionResponseDto>(orderPosition);
            return result;
        }

        public IEnumerable<OrderResponseDto> GetOrders()
        {
            var orders = _dbContext.Orders.ToList();

            var results = _mapper.Map<IEnumerable<OrderResponseDto>>(orders);
            return results;
        }

        public IEnumerable<OrderResponseDto> GetUserOrders(int userId)
        {
            var user = GetUserById(userId);

            var orders = _dbContext.Orders.Where(o => o.UserId == userId).ToList();
            if (orders is null) throw new ContentNotFoundException($"User with id: {userId} does not have order history");

            var results = _mapper.Map<IEnumerable<OrderResponseDto>>(orders);
            return results;
        }
    }
}
