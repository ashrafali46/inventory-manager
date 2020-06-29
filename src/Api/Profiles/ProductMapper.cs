using Api.ViewModels;

namespace Api.Profiles
{
    public class ProductMapper
    {
        ///<summary>
        /// Maps a Product data model to a Product View Model
        ///</summary>
        ///<params name="product"></params>
        ///<returns></returns>
        public static ProductModel SerializeProductModel(Data.Models.Product product)
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
        public static Data.Models.Product SerializeProductModel(ProductModel product)
        {
            return new Data.Models.Product
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