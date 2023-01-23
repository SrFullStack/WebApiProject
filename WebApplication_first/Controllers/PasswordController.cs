using Microsoft.AspNetCore.Mvc;
using Service;
using Zxcvbn;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication_first.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IUserService _IUserService;


        public PasswordController(IUserService IUserService)
        {
            _IUserService = IUserService;
        }


        // GET: api/<PasswordController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PasswordController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        //

        // POST api/<PasswordController>
        [HttpPost]
         public int Post([FromBody] string code)
          
        {
       
            Result result = Zxcvbn.Core.EvaluatePassword(code);
            return result.Score;
        }

        // PUT api/<PasswordController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PasswordController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
