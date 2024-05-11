using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreMVC.BLL.Dto;
using StoreMVC.BLL.Dto.Product;
using StoreMVC.BLL.Query;
using StoreMVC.BLL.Repository.Product;
using StoreMVC.BLL_EF.Exceptions;
using StoreMVC.DataAccess;
using StoreMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using StoreMVC.BLL;
namespace StoreMVC.BLL_EF.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductRepository(StoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        private bool CanPoductBeDeleted(Product product)
        {       
            foreach (var order in _dbContext.Orders)
            {
                if (order.OrderPositions.Any(o=>o.ProductId == product.ProductId))
                {
                    return false;
                }
            }
            foreach (var basketPosition in _dbContext.BasketPositions)
            {
                if (basketPosition.ProductId == product.ProductId)
                {
                    return false;
                }
            }
            return true;
        }
        private Product GetProductById(int productId)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product is null) throw new ContentNotFoundException($"Product with id: {productId} was not found");

            return product;
        }
        public int AddProduct(ProductRequestDto dto)
        {
            if (dto.Price <= 0.0M) throw new InvalidPriceException("Product price can't be less or equal 0.0");

            var product = _mapper.Map<Product>(dto);
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            return product.ProductId;
        }
        
        public void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (!CanPoductBeDeleted(product)) throw new InvalidDataException($"Product with id: {id} can not be deleted");


            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }

        public ProductResponseDto GetById(int id)
        {
            var product = GetProductById(id);

            var result = _mapper.Map<ProductResponseDto>(product);
            return result;
        }

        public PageResult<ProductResponseDto> GetProducts(ProductQuery query)
        {
            var baseQuery = _dbContext
              .Products
              .Include(p => p.OrderPositions)
              .Include(p => p.BasketPositions)
               .Where(p => query.SearchPhrase == null || p.Name.ToLower().Contains(query.SearchPhrase.ToLower()));
         



            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var columnsSelector = new Dictionary<string, Expression<Func<Product, object>>>()
                {
                      {nameof(Product.Name), p=>p.Name },
                      {nameof(Product.IsActive), p=>p.IsActive },
                };

                var selected = columnsSelector[query.SortBy];

                baseQuery = query.SortDirection == SortDirection.ASC ? baseQuery.OrderBy(selected)
                     : baseQuery.OrderByDescending(selected);

            }


            var products = baseQuery
              .Skip(query.PageSize * (query.PageNumber - 1))
              .Take(query.PageSize)
              .ToList();
            var productResults = _mapper.Map<List<ProductResponseDto>>(products);

            var result = new PageResult<ProductResponseDto>(productResults, baseQuery.Count(), query.PageSize, query.PageNumber);

            return result;
        }

        public void ActivateProduct(int id)
        {
            var product = GetProductById(id);
            if (product.IsActive) throw new InvalidDataException($"Product with id: {id} is already active");
                
            product.IsActive = true;
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(int id, ProductUpdateRequestDto dto)
        {
            var product = GetProductById(id);

            _mapper.Map(dto, product);

            _dbContext.SaveChanges();
        }

      
    }
}
