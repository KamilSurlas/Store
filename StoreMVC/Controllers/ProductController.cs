using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using StoreMVC.BLL.Dto;
using StoreMVC.BLL.Dto.Product;
using StoreMVC.BLL.Query;
using StoreMVC.BLL.Repository.Product;


namespace StoreMVC.Controllers
{
    [Route("api/product")]
    [ApiController]
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
        [HttpGet("{productId}")]
        [AllowAnonymous]
        public ActionResult<ProductResponseDto> GetById(int productId)
        {
            var product = _productRepository.GetById(productId);

            return Ok(product);
        }
        [HttpPost]
        public ActionResult AddProduct([FromBody] ProductRequestDto dto)
        {
            var id = _productRepository.AddProduct(dto);

            return Created($"/api/product/{id}", null);
        }
        [HttpPut("{productId}")]
        public ActionResult Update([FromBody] ProductUpdateRequestDto dto, [FromRoute] int productId)
        {
            _productRepository.UpdateProduct(productId, dto);

            return Ok();
        }
        [HttpDelete("{productId}")]
        public ActionResult DeleteById(int productId)
        {
            _productRepository.DeleteProduct(productId);

            return NoContent();
        }
        [HttpPatch("{productId}")]
        public ActionResult ActivateProduct(int productId)
        {
            _productRepository.ActivateProduct(productId);

            return Ok();
        }
    }
}
