using Microsoft.AspNetCore.Mvc;
using Service;
using Entitiy;
using DTO;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication_first.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductsService _IProductsService;
        private readonly IMapper _mapper;


        public ProductsController(IProductsService IProductsService , IMapper IMapper)
        {
            _IProductsService = IProductsService;
            _mapper = IMapper;
        }

        // GET: api/<ProductsController>
        [HttpGet]
      
       


            public async Task<IEnumerable<ProductDTO>> Get([FromQuery] string? name, [FromQuery] int?[] categoryIds, [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int start, [FromQuery] int limit, [FromQuery] string? direction = "ASC" )
        {
            //int a = 5;
            //int b = a / 0;
            IEnumerable<Product> products = await _IProductsService.GetProducts(name, categoryIds, minPrice, maxPrice,start,limit,direction);

            IEnumerable<ProductDTO> res = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            return res;
        

    }


        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
