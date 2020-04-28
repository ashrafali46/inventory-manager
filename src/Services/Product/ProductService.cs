using System.Collections.Generic;

namespace Services.Product
{
    public class ProductService : IProductService
    {
        public List<Data.Models.Product> GetAllProducts()
        {
            throw new System.NotImplementedException();
        }

        public Data.Models.Product GetProductById(int id)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResponse<bool> CreateProduct(Data.Models.Product product)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResponse<bool> ArchiveProduct(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}