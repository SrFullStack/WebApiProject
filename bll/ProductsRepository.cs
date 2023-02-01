using Entitiy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace T_Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly UserContext _dbContext;
        public ProductsRepository(UserContext dbContext)
        {
            _dbContext = dbContext;


        }

        public async Task<Product> GetProductById(int id)
        {

            var list = (from product in _dbContext.Products
                        where product.Id == id
                        select product).ToArray<Product>();
            return list.FirstOrDefault();

        }
        public async Task<List<Product>> GetProducts(string? name, int?[] categoryIds, int? minPrice, int? maxPrice, int? start, int? limit, string? direction = "ASC")
        {
            var query = _dbContext.Products.Where(product =>
            (name == null ? (true) : (product.Name.Contains(name)))
            && ((minPrice == null) ? (true) : (product.Price >= minPrice))
              && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
&& ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId))))
.OrderBy(product => product.Price).Include(p=>p.Category);
            List<Product> products = await query.ToListAsync();


            return products;

            
        }

    }
}
