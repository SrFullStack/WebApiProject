using Microsoft.AspNetCore.Mvc;
using Entitiy;
using Service;
using DTO;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication_first.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _ICategoryService;
        private readonly IMapper _mapper;



        public CategoryController(ICategoryService ICategoryService, IMapper IMapper)
        {
            _ICategoryService = ICategoryService;
            _mapper = IMapper;
        }
        // GET: api/<CategoryController>////
        [HttpGet]
        public async Task< IEnumerable<CategoryDTO>> Get()
        {
           IEnumerable<Category> category= await _ICategoryService.GetCategories();
            IEnumerable<CategoryDTO> res = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(category);
            return res;
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
