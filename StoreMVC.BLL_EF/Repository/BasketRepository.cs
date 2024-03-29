using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreMVC.BLL.Dto;
using StoreMVC.BLL.Repository.Basket;
using StoreMVC.BLL_EF.Exceptions;
using StoreMVC.DataAccess;
using StoreMVC.Model;

namespace StoreMVC.BLL_EF
{
    public class BasketRepository : IBasketRepository
    {
        private readonly StoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public BasketRepository(StoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        private Product GetProductById(int productId)
        {
            var product = _dbContext.Products.Include(p => p.BasketPositions)
                .Include(p=>p.OrderPositions).FirstOrDefault(p=>p.ProductId == productId);

            if (product is null) throw new ContentNotFoundException($"Product with id: {product} was not found");

            return product;
        }
        private User GetUserById(int userId)
        {
            var user = _dbContext.Users
               .Include(u=>u.UserBasketPositions)
               .FirstOrDefault(u => u.UserId == userId);

            if (user is null) throw new ContentNotFoundException($"User with id: {userId} was not found");

            return user;
        }
        private BasketPosition GetBasketPositionById(int basketPositionId) 
        {
            var basketPosition = _dbContext.BasketPositions.Include(bp => bp.Product)
                .FirstOrDefault(b => b.BasketPositionId == basketPositionId);

            if (basketPosition is null) throw new ContentNotFoundException($"Basket position with id: {basketPosition} was not found");

            return basketPosition;
        }
        public int AddBasketPosition(BasketPositionRequestDto dto)
        {
            var product = GetProductById(dto.ProductId);

            if (dto.Amount <= 0) throw new InvalidAmountException("Basket position amount can't be less or equal 0");
            if (!product.IsActive) throw new InvalidDataException("Before adding product to basket, make sure to activate product");

            var basketPosition = _mapper.Map<BasketPosition>(dto);

            _dbContext.BasketPositions.Add(basketPosition);
            _dbContext.SaveChanges();

            return basketPosition.BasketPositionId;
        }

        public void DeleteBasketPosition(int basketPositionId)
        {
            var basketPosition = GetBasketPositionById(basketPositionId);

            _dbContext.BasketPositions.Remove(basketPosition);
            _dbContext.SaveChanges();
        }

        public IEnumerable<BasketPositionResponseDto> GetUserBasket(int userId)
        {
            var user = GetUserById(userId);

            var results = _mapper.Map<List<BasketPositionResponseDto>>(user.UserBasketPositions);
            return results;
        }

        public void UpdateBasketPositionAmount(int basketPositionId, int amount)
        {
            if (amount <= 0) throw new InvalidAmountException("Basket position amount can't be less or equal 0");

            var basketPosition = GetBasketPositionById(basketPositionId);

            basketPosition.Amount = amount;
            _dbContext.SaveChanges();
        }
    }
}
