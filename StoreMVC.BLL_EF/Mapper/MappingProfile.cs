using AutoMapper;
using StoreMVC.BLL.Dto;
using StoreMVC.BLL.Dto.Product;
using StoreMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMVC.BLL_EF.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // nullable types
            CreateMap<decimal?, decimal>().ConvertUsing((src, dest) => src ?? dest);


            // Basket position
            CreateMap<BasketPositionRequestDto, BasketPosition>();
            CreateMap<BasketPosition, BasketPositionResponseDto>();

            // Product
            CreateMap<ProductRequestDto, Product>();
            CreateMap<Product, ProductResponseDto>();
            CreateMap<ProductUpdateRequestDto, Product>()
             .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            // Order position
            CreateMap<OrderPosition, OrderPositionResponseDto>();

            // Order
            CreateMap<Order, OrderResponseDto>();
            CreateMap<IEnumerable<BasketPosition>, Order>().ForMember(src => src.OrderPositions, o => o.MapFrom(bps => bps.Select(bp => new OrderPosition
            {
                Product = bp.Product,
                ProductId = bp.ProductId,
                Order = null!,
                Amount = bp.Amount,
                Price = bp.Product.Price * bp.Amount
            })))
                 .ForMember(src => src.UserId, o => o.MapFrom(bps => bps.FirstOrDefault().UserId))
                 .ForMember(src => src.User, o => o.MapFrom(bps => bps.FirstOrDefault().User));
               
        }
    }
}
