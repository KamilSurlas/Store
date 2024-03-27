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
            // Basket position
            CreateMap<BasketPositionRequestDto, BasketPosition>();
            CreateMap<BasketPosition, BasketPositionResponseDto>();

            // Product
            CreateMap<ProductRequestDto, Product>();
            CreateMap<Product, ProductResponseDto>();
            CreateMap<ProductUpdateRequestDto, Product>()
                .ForAllMembers(opt => opt.Condition(src => src != null));

            // Order position
            CreateMap<OrderPosition, OrderPositionResponseDto>();

            // Order
            CreateMap<Order, OrderResponseDto>();
        }
    }
}
