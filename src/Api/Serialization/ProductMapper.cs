using Api.ViewModels;
using Data.Models;

namespace Api.Serialization
{
    public static class ProductMapper
    {
        ///<summary>
        /// Maps a Product data model to a Product View Model
        ///</summary>
        ///<params name="product"></params>
        ///<returns></returns>
        public static ProductModel SerializeProductModel(Product product)
        {
            return new ProductModel
            {
                Id = product.Id,
                CreatedOn = product.CreatedOn,
                UpdatedOn = product.UpdatedOn,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                IsTaxable = product.IsTaxable,
                IsArchived = product.IsArchived
            };
        }

        ///<summary>
        /// Maps a Product View Model to a Product data model reverse map
        ///</summary>
        ///<params name="product"></params>
        ///<returns></returns>
        public static Product SerializeProductModel(ProductModel product)
        {
            return new Product
            {
                Id = product.Id,
                CreatedOn = product.CreatedOn,
                UpdatedOn = product.UpdatedOn,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                IsTaxable = product.IsTaxable,
                IsArchived = product.IsArchived
            };
        }
    }
}