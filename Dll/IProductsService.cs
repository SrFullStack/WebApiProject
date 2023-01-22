using Entitiy;

namespace Service
{
    public interface IProductsService
    {
        //git changes
        Task<IEnumerable<Product>> GetProducts(string? name, int?[] categoryIds, int? minPrice, int? maxPrice); 
    }
}