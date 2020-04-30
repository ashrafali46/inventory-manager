using Api.ViewModels;

namespace Api.Profiles
{
    public class ProductMapper
    {
        ///<summary>
        /// Maps a Product data model to a Product VM
        ///</summary>
        ///<params name="product"></params>
        ///<returns></returns>
        public static ProductModel SerializedProductModel(Data.Models.Product product)
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
    }
}