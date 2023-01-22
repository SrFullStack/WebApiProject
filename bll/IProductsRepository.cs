using Entitiy;

namespace T_Repository
{
    public interface IProductsRepository
    {
        //Task<IEnumerable<Product>> GetProducts();
        Task<List<Product>> GetProducts(string? name, int?[] categoryIds, int? minPrice, int? maxPrice, int? start, int? limit, string? direction = "ASC");
        
        }
}