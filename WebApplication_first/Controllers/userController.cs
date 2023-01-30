using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApplication_first.wwwroot;

using   Entitiy;
using T_Repository;
using Service;
using AutoMapper;
using DTO;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication_first.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
       
        private readonly IUserService _IUserService;
        private readonly ILogger<userController> _logger;
        private readonly IMapper _mapper;
        public userController(IUserService IUserService, ILogger<userController> logger, IMapper IMapper)
        {
            _logger = logger;
            _IUserService = IUserService;
            _mapper= IMapper;
        }
        ///
        [HttpGet]
      
        // GET api/<userControler>/5
        [HttpGet("{id}")]
        async public Task<ActionResult<UserDTO>> Get([FromQuery] string nameuser, [FromQuery] int password)
        {
            try
            {
                _logger.LogInformation($"enter this {nameuser} nameuser");
                UserTable user = await _IUserService.Get(nameuser, password);
                if (user != null)
                {
                    UserDTO res = _mapper.Map<UserTable, UserDTO>(user);
                    return res;
                }
            }
            catch
                (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return NoContent();

        }

        // POST api/<userControler>//
        [HttpPost]
        public ActionResult<UserTable> Post([FromBody] UserTable user)
        {

          
            if (_IUserService.Post(user) != null)
            {
                return user;
            }
            return StatusCode(204);

        }

        // PUT api/<userControler>/5
        [HttpPut("{userid}")]
        public void Put( int userid, [FromBody] UserTable user)
        {
            _IUserService.Put(userid, user);
        }




        // DELETE api/<userControler>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

      
    }
}
