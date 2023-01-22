using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitiy;
using T_Repository;

namespace Service
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _IProductsRepository;
        public ProductsService(IProductsRepository IProductsRepository)
        {
            _IProductsRepository = IProductsRepository;
        }


        async public Task<IEnumerable<Product>> GetProducts(string? name, int?[] categoryIds, int? minPrice, int? maxPrice, int? start, int? limit, string? direction)
        {
            {
                return await _IProductsRepository.GetProducts(name, categoryIds, minPrice, maxPrice,start,limit,direction);
               
              
                
              




            }

        }


    }
}
