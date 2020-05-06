using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Models;

namespace Services.Product
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Data.Models.Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public Data.Models.Product GetProductById(int id)
        {
            return _dbContext.Products.Find(id);
        }

        public ServiceResponse<Data.Models.Product> CreateProduct(Data.Models.Product product)
        {
            try
            {
                _dbContext.Products.Add(product);

                var newInventory = new ProductInventory
                {
                    Product = product,
                    QuantityOnHand = 0,
                    IdealQuantity = 10
                };

                _dbContext.ProductInventories.Add(newInventory);

                _dbContext.SaveChanges();

                return new ServiceResponse<Data.Models.Product>
                {
                    Data = product,
                    Time = DateTime.UtcNow,
                    Message = "Saved new Product",
                    IsSuccess = true
                };

            }
            catch (Exception ex)
            {
                return new ServiceResponse<Data.Models.Product>
                {
                    Data = product,
                    Time = DateTime.UtcNow,
                    Message = $"Could not save new the Product to the database, see the following error: {ex}",
                    IsSuccess = false
                };
            }

        }

        public ServiceResponse<Data.Models.Product> ArchiveProduct(int id)
        {
            try
            {
                var product = _dbContext.Products.Find(id);
                product.IsArchived = true;
                _dbContext.SaveChanges();

                return new ServiceResponse<Data.Models.Product>
                {
                    Data = product,
                    Time = DateTime.UtcNow,
                    Message = "Archived product",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Data.Models.Product>
                {
                    Data = null,
                    Time = DateTime.UtcNow,
                    Message = ex.StackTrace,
                    IsSuccess = false
                };
            }
        }
    }
}