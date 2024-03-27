using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using StoreMVC.BLL.Dto;
using StoreMVC.BLL.Query;
using StoreMVC.BLL.Repository.Product;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace StoreMVC.Controllers
{
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<ProductResponseDto>> GetAll([FromQuery] ProductQuery query)
        {
            var products = _productRepository.GetProducts(query);

            return Ok(products);
        }
    }
}
