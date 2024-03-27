using StoreMVC.BLL.Dto;
using StoreMVC.BLL.Dto.Product;
using StoreMVC.BLL.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMVC.BLL.Repository.Product
{
    public interface IProductRepository
    {
        PageResult<ProductResponseDto> GetProducts(ProductQuery query);
        ProductResponseDto GetProduct(int id);
        int AddProduct(ProductRequestDto dto);
        void UpdateProduct(int id, ProductUpdateRequestDto dto);
        void DeleteProduct(int id);
        void SetProductAvailability(int id);
    }
}
